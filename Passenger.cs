using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Flight_Reservation_System
{
    public partial class Passenger : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Passenger()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Passenger", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool PassengerIDExists(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Passenger WHERE PassengerID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", id);
            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            return count > 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) || // PassengerID
                string.IsNullOrWhiteSpace(textBox2.Text) || // FullName
                string.IsNullOrWhiteSpace(textBox3.Text) || // Gender
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || // Email
                string.IsNullOrWhiteSpace(textBox6.Text) || // Phone
                string.IsNullOrWhiteSpace(textBox7.Text) || // Nationality
                string.IsNullOrWhiteSpace(textBox8.Text) || // PassportNum
                string.IsNullOrWhiteSpace(textBox4.Text))   // UserID
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int passengerID))
            {
                MessageBox.Show("Passenger ID must be a number.");
                return;
            }

            string userID = textBox4.Text;

            if (PassengerIDExists(passengerID))
            {
                MessageBox.Show("Passenger ID already exists.");
                return;
            }

            string query = "INSERT INTO Passenger (PassengerID, FullName, Gender, DateOfBirth, Email, PhoneNum, Nationality, PassportNum, UserID) " +
                           "VALUES (@ID, @Name, @Gender, @DOB, @Email, @Phone, @Nationality, @Passport, @UserID)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", passengerID);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
            cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox6.Text);
            cmd.Parameters.AddWithValue("@Nationality", textBox7.Text);
            cmd.Parameters.AddWithValue("@Passport", textBox8.Text);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Passenger added successfully.");
                ClearInputFields();
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
            if (!int.TryParse(textBox1.Text, out int passengerID))
            {
                MessageBox.Show("Enter a valid Passenger ID.");
                return;
            }

            SqlCommand cmd = new SqlCommand("DELETE FROM Passenger WHERE PassengerID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", passengerID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Passenger deleted." : "Passenger ID not found.");
                ClearInputFields();
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
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int passengerID))
            {
                MessageBox.Show("Passenger ID must be a number.");
                return;
            }

            string userID = textBox4.Text;

            string query = "UPDATE Passenger SET FullName=@Name, Gender=@Gender, DateOfBirth=@DOB, Email=@Email, PhoneNum=@Phone, Nationality=@Nationality, PassportNum=@Passport, UserID=@UserID " +
                           "WHERE PassengerID=@ID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", passengerID);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
            cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox6.Text);
            cmd.Parameters.AddWithValue("@Nationality", textBox7.Text);
            cmd.Parameters.AddWithValue("@Passport", textBox8.Text);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Passenger updated." : "Passenger ID not found.");
                ClearInputFields();
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
                textBox1.Text = row.Cells["PassengerID"].Value.ToString();
                textBox2.Text = row.Cells["FullName"].Value.ToString();
                textBox3.Text = row.Cells["Gender"].Value.ToString();
                dateTimePicker1.Text = row.Cells["DateOfBirth"].Value.ToString();
                textBox5.Text = row.Cells["Email"].Value.ToString();
                textBox6.Text = row.Cells["PhoneNum"].Value.ToString();
                textBox7.Text = row.Cells["Nationality"].Value.ToString();
                textBox8.Text = row.Cells["PassportNum"].Value.ToString();
                textBox4.Text = row.Cells["UserID"].Value.ToString();
            }
        }

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox4.Clear();
        }

        private void Passenger_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
