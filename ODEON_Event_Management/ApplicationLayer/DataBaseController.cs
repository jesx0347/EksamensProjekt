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
        private string ConnectionString;

        private readonly SalRepository SalRepo;
        private readonly KategoriRepository KatRepo;
        private readonly ODEONEventRepository OERepo;

        public DataBaseController(SalRepository SR, KategoriRepository KR, ODEONEventRepository OER)
        {
            SalRepo = SR;
            KatRepo = KR;
            OERepo = OER;

            LoadConnectionString();
        }
        public DataBaseController()
        {
            SalRepo = new SalRepository();
            KatRepo = new KategoriRepository();
            OERepo = new ODEONEventRepository();

            LoadConnectionString();
        }

        private void LoadConnectionString()
        {
            throw new NotImplementedException();
        }

        public void StartUp()
        {
            DownloadEventListe();
            DownloadKategorier();
            DownloadSale();
        }

        private void DownloadEventListe()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXECUTE [spListOfEvents]";
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int id = (int)sqlDataReader["[EventId]"];
                    string navn = (string)sqlDataReader["[EventNavn]"];
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
                    int id = (int)sqlDataReader["[KategoriId]"];
                    string navn = (string)sqlDataReader["[KategoriNavn]"];
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
                    int id = (int)sqlDataReader["[SalId]"];
                    string navn = (string)sqlDataReader["[SalNavn]"];
                    decimal leje = (decimal)sqlDataReader["[Leje]"];
                    int cap = (int)sqlDataReader["[Kapacitet]"];
                    Sal sal = new Sal(navn, id, leje, cap);
                    SalRepo.AddItem(sal);
                }
                sqlDataReader.Close();
                connection.Close();
            }

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
                //command.Parameters.AddWithValue("@Udbud", billetType.Udbud);
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
                command.Connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                sqlDataReader.Read();
                billetType.ID = (int)sqlDataReader["PrisAfvikling"];
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