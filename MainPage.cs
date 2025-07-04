using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    partial class MainPage : Form
        {
            public MainPage()
            {
                InitializeComponent();
            }

            private void btnLogin_Click(object sender, EventArgs e)
            {
            this.Hide();
            login loginForm = new login();
                loginForm.ShowDialog();
            }

            private void btnSignup_Click(object sender, EventArgs e)
            {
            this.Hide();
            signup signupForm = new signup();
                signupForm.ShowDialog();
            }
        }
    }

