using System;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with the signup form
            Application.Run(new MainPage());
        }
    }
}
