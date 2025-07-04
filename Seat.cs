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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Flight_Reservation_System
{
    public partial class Seat : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Seat()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Seat", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool SeatIDExists(int seatID)
        {
            string query = "SELECT COUNT(*) FROM Seat WHERE SeatID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", seatID);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||  // SeatID
                string.IsNullOrWhiteSpace(textBox2.Text) ||  // FlightID
                string.IsNullOrWhiteSpace(textBox3.Text) ||  // SeatNum
                string.IsNullOrWhiteSpace(textBox4.Text) ||  // Class
                string.IsNullOrWhiteSpace(textBox5.Text))    // AvailabilityStatus
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int seatID) || !int.TryParse(textBox2.Text, out int flightID))
            {
                MessageBox.Show("SeatID and FlightID must be valid integers.");
                return;
            }

            if (SeatIDExists(seatID))
            {
                MessageBox.Show("Seat ID already exists.");
                return;
            }

            string query = "INSERT INTO Seat (SeatID, FlightID, SeatNumber, Class, AvailabilityStatus) " +
                           "VALUES (@SeatID, @FlightID, @SeatNumber, @Class, @AvailabilityStatus)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SeatID", seatID);
            cmd.Parameters.AddWithValue("@FlightID", flightID);
            cmd.Parameters.AddWithValue("@SeatNumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@Class", textBox4.Text);
            cmd.Parameters.AddWithValue("@AvailabilityStatus", textBox5.Text);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seat added successfully.");
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
            if (!int.TryParse(textBox1.Text, out int seatID))
            {
                MessageBox.Show("Please enter a valid Seat ID to delete.");
                return;
            }

            string query = "DELETE FROM Seat WHERE SeatID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", seatID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Seat deleted." : "Seat ID not found.");
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
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int seatID) || !int.TryParse(textBox2.Text, out int flightID))
            {
                MessageBox.Show("SeatID and FlightID must be valid integers.");
                return;
            }

            string query = "UPDATE Seat SET FlightID=@FlightID, SeatNumber=@SeatNumber, Class=@Class, AvailabilityStatus=@AvailabilityStatus " +
                           "WHERE SeatID=@SeatID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SeatID", seatID);
            cmd.Parameters.AddWithValue("@FlightID", flightID);
            cmd.Parameters.AddWithValue("@SeatNumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@Class", textBox4.Text);
            cmd.Parameters.AddWithValue("@AvailabilityStatus", textBox5.Text);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Seat updated successfully." : "Seat ID not found.");
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
                textBox1.Text = row.Cells["SeatID"].Value.ToString();
                textBox2.Text = row.Cells["FlightID"].Value.ToString();
                textBox3.Text = row.Cells["SeatNumber"].Value.ToString();
                textBox4.Text = row.Cells["Class"].Value.ToString();
                textBox5.Text = row.Cells["AvailabilityStatus"].Value.ToString();
            }
        }

        private void Seat_Load(object sender, EventArgs e) { }
    }
}
