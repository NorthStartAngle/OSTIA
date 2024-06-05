using System.Data.OleDb;

namespace OSTIA
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

            
            try
            {
                Global.Instance.db?.connect("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ostia.accdb;Jet OLEDB:Database Password=northstar");

            }
            catch (Exception)
            {
                MessageBox.Show("Database connection is failed, so you can't work more");
                return;
            }

            (new Login()).Show();
            Application.Run();
        }
    }
}