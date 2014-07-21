using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace POC.DataModels
{
    public class VelibData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string address { get; set; }


    }
}
