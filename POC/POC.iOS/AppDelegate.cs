using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using System.Net.Http;

namespace POC.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);


            //Sqlite connection
            App.SetDatabaseConnection(GetConnection());


            window.RootViewController = App.GetMainPage().CreateViewController();

            window.MakeKeyAndVisible();

            HttpMethod x = HttpMethod.Post;

            return true;
        }


        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "db.sqlite";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // Copy the database across (if it doesn't exist)
            var appdir = NSBundle.MainBundle.ResourcePath;
            var seedFile = Path.Combine(appdir, sqliteFilename);
            if (!File.Exists(path))
                File.Copy(seedFile, path);


            // Create the connection
            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection
            return conn;
        }


    }
}
