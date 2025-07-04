using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Flight_Reservation_System
{
    public partial class Airline : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Airline()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Airline", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) || // AirlineID
                string.IsNullOrWhiteSpace(textBox2.Text) || // AirlineName
                string.IsNullOrWhiteSpace(textBox3.Text) || // Country
                string.IsNullOrWhiteSpace(textBox4.Text) || // ContactNum
                string.IsNullOrWhiteSpace(textBox5.Text))   // Website
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int airlineID))
            {
                MessageBox.Show("Airline ID must be a valid number.");
                return;
            }

            string query = "INSERT INTO Airline (AirlineID, AirlineName, Country, ContactNum, Website) " +
                           "VALUES (@ID, @Name, @Country, @Contact, @Website)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", airlineID);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Country", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Website", textBox5.Text);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Airline added successfully.");
          
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
            if (!int.TryParse(textBox1.Text, out int airlineID))
            {
                MessageBox.Show("Please enter a valid Airline ID to delete.");
                return;
            }

            string query = "DELETE FROM Airline WHERE AirlineID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", airlineID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Airline deleted.");
                else
                    MessageBox.Show("Airline ID not found.");
     
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

            if (!int.TryParse(textBox1.Text, out int airlineID))
            {
                MessageBox.Show("Airline ID must be a valid number.");
                return;
            }

            string query = "UPDATE Airline SET AirlineName=@Name, Country=@Country, ContactNum=@Contact, Website=@Website " +
                           "WHERE AirlineID=@ID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", airlineID);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Country", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Website", textBox5.Text);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Airline updated successfully.");
                else
                    MessageBox.Show("Airline ID not found.");
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
                textBox1.Text = row.Cells["AirlineID"].Value.ToString();
                textBox2.Text = row.Cells["AirlineName"].Value.ToString();
                textBox3.Text = row.Cells["Country"].Value.ToString();
                textBox4.Text = row.Cells["ContactNum"].Value.ToString();
                textBox5.Text = row.Cells["Website"].Value.ToString();
            }
        }
    }
}
