using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProjectContext>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
     }
   
    }
