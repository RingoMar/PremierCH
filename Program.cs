using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremierCH_MGMT
{
    static class Program
    {
        static ApplicationContext MainContext = new ApplicationContext();

        public static bool isVaildUser = false;
        public static bool isAdmin = false;
        public static String email = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainContext.MainForm = new login();
            Application.Run(MainContext);

        }

        public static void SetMainForm(Form MainForm)
        {
            MainContext.MainForm = MainForm;
        }

        public static void ShowMainForm()
        {
            MainContext.MainForm.Show();
        }
    }
}
