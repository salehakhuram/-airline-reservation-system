using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace Flight_Reservation_System
{
    public partial class Staff : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Staff()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Staff", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool StaffIDExists(int staffID)
        {
            string query = "SELECT COUNT(*) FROM Staff WHERE StaffID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", staffID);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }
        private int GetUserIDByFullName(string fullName)
        {
            string query = "SELECT UserID FROM Users WHERE FullName = @FullName";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FullName", fullName);

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) || // StaffID
                string.IsNullOrWhiteSpace(textBox2.Text) || // FullName
                string.IsNullOrWhiteSpace(textBox3.Text) || // Role
                string.IsNullOrWhiteSpace(textBox4.Text))   // ContactInfo
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int staffID))
            {
                MessageBox.Show("Staff ID must be a valid integer.");
                return;
            }

            if (StaffIDExists(staffID))
            {
                MessageBox.Show("Staff ID already exists.");
                return;
            }

            int userID = GetUserIDByFullName(textBox2.Text);
            if (userID == -1)
            {
                MessageBox.Show("No matching User found with this full name.");
                return;
            }

            string query = "INSERT INTO Staff (StaffID, FullName, Role, ContactInfo, UserID) " +
                           "VALUES (@StaffID, @FullName, @Role, @ContactInfo, @UserID)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@StaffID", staffID);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Role", textBox3.Text);
            cmd.Parameters.AddWithValue("@ContactInfo", textBox4.Text);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff added successfully.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int staffID))
            {
                MessageBox.Show("Please enter a valid Staff ID to delete.");
                return;
            }

            string query = "DELETE FROM Staff WHERE StaffID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", staffID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Staff deleted.");
                else
                    MessageBox.Show("Staff ID not found.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (
            string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int staffID))
            {
                MessageBox.Show("Staff ID must be a valid integer.");
                return;
            }

            string query = "UPDATE Staff SET FullName=@FullName, Role=@Role, ContactInfo=@ContactInfo " +
                           "WHERE StaffID=@StaffID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@StaffID", staffID);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Role", textBox3.Text);
            cmd.Parameters.AddWithValue("@ContactInfo", textBox4.Text);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Staff updated successfully.");
                else
                    MessageBox.Show("Staff ID not found.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["StaffID"].Value.ToString();
                textBox2.Text = row.Cells["FullName"].Value.ToString();
                textBox3.Text = row.Cells["Role"].Value.ToString();
                textBox4.Text = row.Cells["ContactInfo"].Value.ToString();
            }
        }

        private void Staff_Load(object sender, EventArgs e) { }
    }
}
