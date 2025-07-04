using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Flight_Reservation_System
{
    public partial class Users : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Users()
        {
            InitializeComponent();
            LoadUsers();

            comboBox1.Items.AddRange(new string[] { "Admin", "Employee", "User" });
            comboBox1.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private string BuildUserID(string role, string numericPart)
        {
            string prefix = role switch
            {
                "Admin" => "ADM",
                "Employee" => "EMP",
                "User" => "USR",
                _ => "USR"
            };
            return prefix + numericPart.PadLeft(3, '0');
        }

        private string ExtractNumericPart(string userID)
        {
            if (userID.Length > 3)
                return userID.Substring(3);
            return "";
        }

        private bool UserIdExists(string userId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserID=@UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();
                    return count > 0;
                }
            }
            catch
            {
                if (con.State == ConnectionState.Open) con.Close();
                return false;
            }
        }

        private void ClearInputs()
        {
            textBox1.Clear(); // UserID numeric part
            textBox2.Clear(); // FullName
            textBox3.Clear(); // Username
            textBox4.Clear(); // Password
            comboBox1.SelectedIndex = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string numericPart = textBox1.Text.Trim();

            if (!int.TryParse(numericPart, out _))
            {
                MessageBox.Show("Please enter a valid numeric UserID part.");
                return;
            }

            string fullUserID = BuildUserID(comboBox1.SelectedItem.ToString(), numericPart);

            try
            {
                if (UserIdExists(fullUserID))
                {
                    MessageBox.Show("UserID already exists. Please enter a unique numeric UserID part.");
                    return;
                }

                string query = "INSERT INTO Users (UserID, FullName, Username, Password, Role) VALUES (@UserID, @FullName, @Username, @Password, @Role)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", fullUserID);
                    cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Username", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Role", comboBox1.SelectedItem.ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("User Added!");
                LoadUsers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting user: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string numericPart = textBox1.Text.Trim();

            if (!int.TryParse(numericPart, out _))
            {
                MessageBox.Show("Please enter a valid numeric UserID part.");
                return;
            }

            string fullUserID = BuildUserID(comboBox1.SelectedItem.ToString(), numericPart);

            try
            {
                string query = "UPDATE Users SET FullName=@FullName, Username=@Username, Password=@Password, Role=@Role WHERE UserID=@UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", fullUserID);
                    cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Username", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Role", comboBox1.SelectedItem.ToString());

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rows == 0)
                    {
                        MessageBox.Show("User not found for update.");
                    }
                    else
                    {
                        MessageBox.Show("User Updated!");
                        LoadUsers();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string numericPart = textBox1.Text.Trim();

            if (!int.TryParse(numericPart, out _))
            {
                MessageBox.Show("Please enter a valid numeric UserID part.");
                return;
            }

            string fullUserID = BuildUserID(comboBox1.SelectedItem.ToString(), numericPart);

            try
            {
                string query = "DELETE FROM Users WHERE UserID=@UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", fullUserID);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rows == 0)
                    {
                        MessageBox.Show("User not found for deletion.");
                    }
                    else
                    {
                        MessageBox.Show("User Deleted!");
                        LoadUsers();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string userID = row.Cells["UserID"].Value.ToString();
                string role = row.Cells["Role"].Value.ToString();

                textBox1.Text = ExtractNumericPart(userID);
                textBox2.Text = row.Cells["FullName"].Value.ToString();
                textBox3.Text = row.Cells["Username"].Value.ToString();
                textBox4.Text = row.Cells["Password"].Value.ToString();

                int index = comboBox1.Items.IndexOf(role);
                comboBox1.SelectedIndex = (index >= 0) ? index : 0;
            }
        }

       
    }
}
