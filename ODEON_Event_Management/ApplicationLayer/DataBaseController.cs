using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
