using System;

using System.Windows.Forms;

namespace Diet_note
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>SqliteException: SQLite Error 19: 'UNIQUE constraint failed: Edges.Id'.
        [STAThread]
        static void Main()
        {
            

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
             Application.Run(new Main()); 
           
                
        }
    }
}
