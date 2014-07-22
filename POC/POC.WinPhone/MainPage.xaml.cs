using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using Microsoft.Phone.Controls;
using POC.Data;
using SQLite.Net.Platform.WindowsPhone8;
using Windows.Storage;
using Xamarin.Forms;


namespace POC.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            
            //Sqlite connection

            this.Loaded += MainPage_Loaded;

        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var sqliteFilename = "db.sqlite";
            string path = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename));
            var file = await StorageFile.GetFileFromPathAsync(path);


            // Copy the database across (if it doesn't exist)
            IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication();
            if (!ISF.FileExists(sqliteFilename))
            {

                CopyFromContentToStorage(ISF, "Assets/" + sqliteFilename, sqliteFilename);

            }

            VelibDatabase dataBase = new VelibDatabase(new SQLitePlatformWP8(), path);

        }


        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "db.sqlite";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            // Copy the database across (if it doesn't exist)
            IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication();
            if (!ISF.FileExists(sqliteFilename)) CopyFromContentToStorage(ISF, "Assets/" + sqliteFilename, sqliteFilename);

            
            // Create the connection
            var plat = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
            var conn = new SQLite.Net.SQLiteConnection(plat, sqliteFilename);

            // Return the database connection 
            return conn;
        }


        private void CopyFromContentToStorage(IsolatedStorageFile ISF, String SourceFile, String DestinationFile)
        {
            Stream Stream = Application.GetResourceStream(new Uri(SourceFile, UriKind.Relative)).Stream;


            IsolatedStorageFileStream ISFS = new IsolatedStorageFileStream(DestinationFile, System.IO.FileMode.Create, System.IO.FileAccess.Write, ISF);
            CopyStream(Stream, ISFS);
            ISFS.Flush();
            ISFS.Close();
            Stream.Close();
            ISFS.Dispose();
        }

        private void CopyStream(Stream Input, IsolatedStorageFileStream Output)
        {
            Byte[] Buffer = new Byte[5120];
            Int32 ReadCount = Input.Read(Buffer, 0, Buffer.Length);
            while (ReadCount > 0)
            {
                Output.Write(Buffer, 0, ReadCount);
                ReadCount = Input.Read(Buffer, 0, Buffer.Length);
            }
        }


    }
}
