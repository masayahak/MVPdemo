using MVPdemo.Presenters;
using MVPdemo.Repositories;
using MVPdemo.Views;

namespace MVPdemo
{
    internal static class Program
    {
        static Program()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            I利用者View view = new 利用者View();
            I利用者Repository repo = new 利用者Repository();
            
            _ = new 利用者Presenter(view, repo);

            Application.Run((Form)view);
        }
    }
}