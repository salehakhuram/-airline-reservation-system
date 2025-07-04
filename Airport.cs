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
    public partial class Airport : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Airport()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Airport", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool AirportIDExists(int airportID)
        {
            string query = "SELECT COUNT(*) FROM Airport WHERE AirportID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", airportID);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) || // AirportID
                string.IsNullOrWhiteSpace(textBox2.Text) || // AirportName
                string.IsNullOrWhiteSpace(textBox3.Text) || // City
                string.IsNullOrWhiteSpace(textBox4.Text) || // Country
                string.IsNullOrWhiteSpace(textBox5.Text))   // IATACode
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int airportID))
            {
                MessageBox.Show("Airport ID must be a valid number.");
                return;
            }

            if (AirportIDExists(airportID))
            {
                MessageBox.Show("Airport ID already exists.");
                return;
            }

            string query = "INSERT INTO Airport (AirportID, AirportName, City, Country, IATA_Code) " +
                           "VALUES (@ID, @Name, @City, @Country, @Code)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", airportID);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@Country", textBox4.Text);
            cmd.Parameters.AddWithValue("@Code", textBox5.Text);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Airport added successfully.");
                
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
            if (!int.TryParse(textBox1.Text, out int airportID))
            {
                MessageBox.Show("Please enter a valid Airport ID to delete.");
                return;
            }

            string query = "DELETE FROM Airport WHERE AirportID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", airportID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Airport deleted.");
                else
                    MessageBox.Show("Airport ID not found.");
               
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
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int airportID))
            {
                MessageBox.Show("Airport ID must be a valid number.");
                return;
            }

            string query = "UPDATE Airport SET AirportName=@Name, City=@City, Country=@Country, IATACode=@Code " +
                           "WHERE AirportID=@ID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", airportID);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@Country", textBox4.Text);
            cmd.Parameters.AddWithValue("@Code", textBox5.Text);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Airport updated successfully.");
                else
                    MessageBox.Show("Airport ID not found.");
           
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
                textBox1.Text = row.Cells["AirportID"].Value.ToString();
                textBox2.Text = row.Cells["AirportName"].Value.ToString();
                textBox3.Text = row.Cells["City"].Value.ToString();
                textBox4.Text = row.Cells["Country"].Value.ToString();
                textBox5.Text = row.Cells["IATA_Code"].Value.ToString();
            }
        }
    }
}

