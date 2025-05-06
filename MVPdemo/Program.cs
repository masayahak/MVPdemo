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

            IView���p�� view = new ���p��View();
            I���p��Repository repo = new ���p��Repository();
            
            _ = new ���p��Presenter(view, repo);

            Application.Run((Form)view);
        }
    }
}