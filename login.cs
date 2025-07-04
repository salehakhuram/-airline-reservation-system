using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public login()
        {
            InitializeComponent();
        }

        // Get UserID from username
        private string GetUserID(string username)
        {
            string id = null;
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                string query = "SELECT UserID FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                        id = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting UserID: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return id;
        }

        private bool IsStrongPassword(string password)
        {
            var pattern = @"^(?=.*\d)(?=.*[@$!%*?&])\S{8,}$";
            return Regex.IsMatch(password, pattern);
        }
        // Main login button click
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            // Input Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            try
            {
                conn.Open();

                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // 🔐 Use hashing in production
                if (!IsStrongPassword(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include at least one digit and one special character.");
                    return;
                }

                var roleObj = cmd.ExecuteScalar();

                if (roleObj != null)
                {
                    string role = roleObj.ToString();
                    string userID = GetUserID(username);

                    MessageBox.Show($"Login successful! Role: {role}");
                    this.Hide(); // Hide login form

                    // Role-based navigation
                    switch (role)
                    {
                        case "Admin":
                            new AdminDashboard(username, role).Show();
                            break;
                        case "Employee":
                            new EmployeeDashboard(role).Show();
                            break;
                        case "Passenger":
                            new UserDashboard(role, userID).Show();
                            break;
                        default:
                            MessageBox.Show("Unknown role.");
                            this.Show(); // Redisplay login if error
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
