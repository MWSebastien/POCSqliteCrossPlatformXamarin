using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.DataModels;
using SQLite.Net;

namespace POC.Data
{
    public class VelibDatabase
    {

        static object locker = new object();

        SQLiteConnection database;

        public VelibDatabase(SQLiteConnection conn)
        {
            database = conn;
            //database.CreateTable<VelibData>();
        }

        public IEnumerable<VelibData> GetItems()
        {
            lock (locker)
            {
                var db = database.Table<VelibData>();

                return (from i in db select i).ToList();
            }
        }


        public VelibData GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<VelibData>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(VelibData item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<VelibData>(id);
            }
        }

    }
}
