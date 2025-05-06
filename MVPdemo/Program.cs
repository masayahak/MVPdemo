using MVPdemo.Presenters;
using MVPdemo.Repositories;

namespace MVPdemo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IView利用者 view = new 利用者View();
            I利用者Repository repo = new 利用者Repository();
            
            _ = new 利用者Presenter(view, repo);

            Application.Run((Form)view);
        }
    }
}