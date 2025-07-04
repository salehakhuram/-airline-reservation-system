using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class signup : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public signup()
        {
            InitializeComponent();
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Employee");
            comboBox1.Items.Add("Passenger");
            comboBox1.SelectedIndex = 2; // default to "User"

        }

        private bool IsStrongPassword(string password)
        {
            var pattern = @"^(?=.*\d)(?=.*[@$!%*?&])\S{8,}$";
            return Regex.IsMatch(password, pattern);
        }
        private bool ValidateInputs(string userId, string fullName, string username, string password, out string errorMsg)
        {
            errorMsg = "";

            if (string.IsNullOrWhiteSpace(userId))
                errorMsg = "UserID is required.";
            else if (userId.Length > 10)
                errorMsg = "UserID must be at most 10 characters.";
            else if (string.IsNullOrWhiteSpace(fullName))
                errorMsg = "Full Name is required.";
            else if (string.IsNullOrWhiteSpace(username))
                errorMsg = "Username is required.";
            else if (string.IsNullOrWhiteSpace(password))
                errorMsg = "Password is required.";
            else if (!IsStrongPassword(password))
                errorMsg = "Password must be at least 8 characters long, have at least one number, one special character, and no spaces.";

            return string.IsNullOrEmpty(errorMsg);
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            string userId = TxtUserID.Text.Trim();  // now string, e.g. "ADM001"
            string fullName = TxtFullName.Text.Trim();
            string username = TxtUsername.Text.Trim();
            string password = TxtPassword.Text;
            string role = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            if (!ValidateInputs(userId, fullName, username, password, out string error))
            {
                MessageBox.Show(error);
                return;
            }

            try
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID OR Username = @Username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@UserID", userId);
                checkCmd.Parameters.AddWithValue("@Username", username);

                int userExists = (int)checkCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    MessageBox.Show("UserID or Username already exists.");
                    return;
                }

                string query = @"
            INSERT INTO Users (UserID, FullName, Username, Password, Role)
            VALUES (@UserID, @FullName, @Username, @Password, @Role);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Signup successful! Please login now.");
                    this.Hide();
                    login loginForm = new login();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Signup failed!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Signup failed: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }



    }
}
