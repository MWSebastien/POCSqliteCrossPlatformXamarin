using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using POC.Data;
using POC.Views;
using Xamarin.Forms;

namespace POC
{
    public class App
    {
        public static Page GetMainPage()
        {
            //string result = "Résultat : " + Environment.NewLine;

            

            //return new ContentPage
            //{
            //    Content = new Label
            //    {
            //        Text = result,
            //        VerticalOptions = LayoutOptions.CenterAndExpand,
            //        HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    },
            //};

            return new PageTest();

        }


        //static SQLite.Net.SQLiteConnection _conn;
        //static VelibDatabase _database;

        //public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        //{
        //    _conn = connection;
        //    _database = new VelibDatabase(_conn);
        //}

        //public static VelibDatabase Database
        //{
        //    get { return _database; }
        //}

        //public static SQLite.Net.SQLiteConnection conn
        //{
        //    get { return _conn; }
        //}


    }
}
