using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class DataBaseController
    {
        internal string ConnectionString;

        private readonly SalRepository SalRepo;
        private readonly KategoriRepository KatRepo;
        private readonly ODEONEventRepository OERepo;
        private readonly GodtGørelsesRepository GGRepo;

        public DataBaseController(SalRepository SR, KategoriRepository KR, ODEONEventRepository OER, GodtGørelsesRepository GGR)
        {
            SalRepo = SR;
            KatRepo = KR;
            OERepo = OER;
            GGRepo = GGR;

            LoadConnectionString();
        }
        public DataBaseController()
        {
            SalRepo = new SalRepository();
            KatRepo = new KategoriRepository();
            OERepo = new ODEONEventRepository();
            GGRepo = new GodtGørelsesRepository();

            LoadConnectionString();
        }

        private void LoadConnectionString()
        {
            ////multiline
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Stream stream = assembly.GetManifestResourceStream(GetType(), "ConnectionString.txt");
            //StreamReader reader = new StreamReader(stream);
            //ConnectionString = reader.ReadToEnd();

            //one line version
            ConnectionString = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "ConnectionString.txt")).ReadToEnd();
        }

        public void StartUp(Controller control)
        {
            DownloadEventListe();
            DownloadKategorier();
            DownloadSale();
            DownloadUnderskudsGodtgørelse(control);
        }

        private void DownloadEventListe()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("spListOfEvents", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //command.CommandText = "EXECUTE [spListOfEvents]";
                //command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int id = (int)sqlDataReader["EventId"];
                    string navn = (string)sqlDataReader["EventNavn"];
                    ODEONEvent OE = new ODEONEvent(navn, id);
                    OERepo.AddItem(OE);
                }
                sqlDataReader.Close();
                connection.Close();
            }
        }

        private void DownloadKategorier()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spListOfKategorier]";
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int id = (int)sqlDataReader["KategoriId"];
                    string navn = (string)sqlDataReader["KategoriNavn"];
                    Kategori kat = new Kategori(navn, id);
                    KatRepo.AddItem(kat);
                }
                sqlDataReader.Close();
                connection.Close();
            }
        }

        private void DownloadSale()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spListOfSale]";
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int id = (int)sqlDataReader["SalId"];
                    string navn = (string)sqlDataReader["SalNavn"];
                    decimal leje = (decimal)sqlDataReader["Leje"];
                    int cap = (int)sqlDataReader["Kapacitet"];
                    Sal sal = new Sal(navn, id, leje, cap);
                    SalRepo.AddItem(sal);
                }
                sqlDataReader.Close();
                connection.Close();
            }

        }

        private void DownloadUnderskudsGodtgørelse(Controller controller)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spGetUnderskudsGodtgørelse]";
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    double returProcent = Convert.ToDouble(sqlDataReader["ReturProcent"]);
                    DateTime udløbsDato = (DateTime)sqlDataReader["UdløbsDato"];
                    UnderskudsGodtgørelse underskudsGodtgørelse = new UnderskudsGodtgørelse()
                        { Godtgørelse = returProcent, UdløbsDato = udløbsDato };
                    GGRepo.AddItem(underskudsGodtgørelse);
                }



                sqlDataReader.Close();
                connection.Close();
            }
        }

        public void DownloadHeleEvent(ODEONEvent OE)
        {
            spGetEvent(OE);
            spGetEventKategorier(OE);
            spGetAfviklinger(OE);
            foreach (Afvikling afvikling in OE.Afviklinger)
            {
                spGetBilletTyper(afvikling);
                foreach (BilletType billet in afvikling.BilletTyper)
                {
                    spGetSalgsTal(billet);
                }
            }
        }

        public void DownloadHeleEvent(int id)
        {
            DownloadHeleEvent(OERepo.GetItem(id));
        }

        public void DownloadHeleEvent(string navn)
        {
            DownloadHeleEvent(OERepo.GetItem(navn));
        }

        public void UploadEvent(ODEONEvent upload)
        {
            spInsertEvent(upload);
            foreach (Kategori item in upload.Kategorier)
            {
                spInsertEventKategori(upload, item);
            }
            foreach (Afvikling afvik in upload.Afviklinger)
            {
                spInsertAfvikling(upload, afvik);
                foreach (BilletType billet in afvik.BilletTyper)
                {
                    spInsertBilletType(billet, afvik);
                }
            }
        }

        public void UploadEvent(string name)
        {
            UploadEvent(OERepo.GetItem(name));
        }

        public void UploadEvent(int ID)
        {
            UploadEvent(OERepo.GetItem(ID));
        }

        private void spInsertEvent(ODEONEvent target)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spInsertEvent @EventNavn, @Markedsføring, @Koda, @Garantisum, @ArtistSplit, @VariableOmkostninger, @OmkostningerNote, @VariableIndtægter, @IndtægterNote, @UnderskudsGodtgørelse";
                command.Parameters.AddWithValue("@EventNavn", target.Navn);
                command.Parameters.AddWithValue("@Markedsføring", target.Omkostninger.MarkedsFøring);
                command.Parameters.AddWithValue("@Koda", target.Omkostninger.KODA);
                command.Parameters.AddWithValue("@Garantisum", target.Omkostninger.Garantisum);
                command.Parameters.AddWithValue("@ArtistSplit", target.Omkostninger.ArtistSplit);
                command.Parameters.AddWithValue("@VariableOmkostninger", target.Omkostninger.VariableOmkostninger);
                command.Parameters.AddWithValue("@OmkostningerNote", target.Omkostninger.Note);
                command.Parameters.AddWithValue("@VariableIndtægter", target.VariableIndtjening.Beløb);
                command.Parameters.AddWithValue("@IndtægterNote", target.VariableIndtjening.Note);
                command.Parameters.AddWithValue("@UnderskudsGodtgørelse", target.Godtgørelse.UdløbsDato);
                command.Connection = connection;
                command.Connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private void spInsertEventKategori(ODEONEvent OE, Kategori Kat)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spInsertEventKategori @Event, @Kategori";
                command.Parameters.AddWithValue("@Event", OE.ID);
                command.Parameters.AddWithValue("@Kategori", Kat.ID);
                command.Connection = connection;
                command.Connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void spInsertAfvikling(ODEONEvent OE, Afvikling afvikling)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spInsertAfvikling @Dato, @Event, @Sal";
                command.Parameters.AddWithValue("@Dato", afvikling.Dato);
                command.Parameters.AddWithValue("@Event", OE.ID);
                command.Parameters.AddWithValue("@Sal", afvikling.Sal.ID);
                command.Connection = connection;
                command.Connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spGetAfviklingId @Event, @Dato";
                command.Parameters.AddWithValue("@Event", OE.ID);
                command.Parameters.AddWithValue("@Dato", afvikling.Dato);
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                sqlDataReader.Read();
                afvikling.ID = (int)sqlDataReader["DatoId"];
                sqlDataReader.Close();
                connection.Close();
            }
        }

        private void spInsertBilletType(BilletType billetType, Afvikling afvikling)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spInsertBilletType @Udbud, @Pris, @Afvikling";
                command.Parameters.AddWithValue("@Udbud", billetType.Udbud);
                command.Parameters.AddWithValue("@Pris", billetType.Pris);
                command.Parameters.AddWithValue("@Afvikling", afvikling.ID);
                command.Connection = connection;
                command.Connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spGetBilletTypeId @Pris, @Afvikling";
                command.Parameters.AddWithValue("@Pris", billetType.Pris);
                command.Parameters.AddWithValue("@Afvikling", afvikling.ID);
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                sqlDataReader.Read();
                billetType.ID = (int)sqlDataReader["BilletTypeId"];
                sqlDataReader.Close();
                connection.Close();
            }
        }

        private void spSalgsTal(SalgsTal salgsTal, BilletType billetType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE spSalgsTal @Bevægelse, @BilletType, @SalgsDato";
                command.Parameters.AddWithValue("@Bevægelse", salgsTal.Solgt);
                command.Parameters.AddWithValue("@BilletType", billetType.ID);
                command.Parameters.AddWithValue("@SalgsDato", salgsTal.Dato);
                command.Connection = connection;
                command.Connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void spGetEvent(ODEONEvent OE)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spGetEvent]";
                command.Parameters.AddWithValue("@ID", OE.ID);
                command.Connection = connection;
                SqlDataReader Reader = command.ExecuteReader();
                Reader.Read();

                decimal marked = (decimal)Reader["Markedsføring"];
                double koda = (double)Reader["Koda"];
                decimal garanti = (decimal)Reader["Garantisum"];
                double split = (double)Reader["ArtistSplit"];
                Omkostninger omkostninger = new Omkostninger(marked, koda, garanti, split);
                omkostninger.VariableOmkostninger = (decimal)Reader["VariableOmkostninger"];
                omkostninger.Note = (string)Reader["OmkostningerNote"];

                OE.Omkostninger = omkostninger;

                VariableIndtægter indtægter = new VariableIndtægter();
                indtægter.Beløb = (decimal)Reader["VariableIndtægter"];
                indtægter.Note = (string)Reader["IndtægterNote"];

                OE.VariableIndtjening = indtægter;

                DateTime dateTime = (DateTime)Reader["UnderskudsGodtgørelse"];
                if (dateTime.CompareTo(Controller.Singleton.Godtgørelse.UdløbsDato) == 0)
                {
                    OE.Godtgørelse = Controller.Singleton.Godtgørelse;
                }
            }
        }

        private void spGetEventKategorier(ODEONEvent OE)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spGetEventKategorier]";
                command.Parameters.AddWithValue("@EventID", OE.ID);
                command.Connection = connection;
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    OE.Kategorier.Add(KatRepo.GetItem((int)Reader["Kategori"]));
                }
            }
        }

        private void spGetAfviklinger(ODEONEvent OE)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spGetAfviklinger]";
                command.Parameters.AddWithValue("@EventID", OE.ID);
                command.Connection = connection;
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    Afvikling afvikling = new Afvikling((DateTime)Reader["Dato"]);
                    afvikling.ID = (int)Reader["DatoId"];
                    afvikling.Sal = SalRepo.GetItem((int)Reader["Sal"]);
                    OE.Afviklinger.Add(afvikling);
                }
            }
        }

        private void spGetBilletTyper(Afvikling afvikling)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spGetBilletTyper]";
                command.Parameters.AddWithValue("@AfviklingID", afvikling.ID);
                command.Connection = connection;
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    int udbud = (int)Reader["Udbud"];
                    decimal pris = (decimal)Reader["Pris"];
                    BilletType billet = new BilletType(udbud, pris);
                    billet.ID = (int)Reader["BilletTypeId"];
                    afvikling.BilletTyper.Add(billet);
                }
            }
        }

        private void spGetSalgsTal(BilletType billet)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spGetSalgsTal]";
                command.Parameters.AddWithValue("@BilletID", billet.ID);
                command.Connection = connection;
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        DateTime date = (DateTime)Reader["SalgsDato"];
                        int sold = (int)Reader["Bevægelse"];
                        SalgsTal tal = new SalgsTal(date, sold);
                        billet.SamledeSalgsTal.Add(tal);
                    }
                }
                
            }

        }

        public override string ToString()
        {
            return ConnectionString;
        }

        //private void spUnderskudsGodtgørelse(UnderskudsGodtgørelse UG)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "EXECUTE spUnderskudsGodtgørelse @ReturProcent, @UdløbsDato";
        //        command.Parameters.AddWithValue("@ReturProcent", UG.Godtgørelse);
        //        command.Parameters.AddWithValue("@UdløbsDato", UG.UdløbsDato);
        //        command.Connection = connection;
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}