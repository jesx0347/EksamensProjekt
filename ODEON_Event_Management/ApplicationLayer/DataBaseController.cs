using System;
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
        public static DataBaseController Instance { get; }
        private string ConnectionString;
        static DataBaseController()
        {
            Instance = new DataBaseController();
        }
        private DataBaseController()
        {
            StreamReader sr = new StreamReader("ConnectionString.txt");
            ConnectionString = sr.ReadLine();
            sr.Close();
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
            UploadEvent(ODEONEventRepository.Instance.GetItem(name));
        }

        public void UploadEvent(int ID)
        {
            UploadEvent(ODEONEventRepository.Instance.GetItem(ID));
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
            }

        }
    }
}
