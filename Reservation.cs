using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class Reservation : Form
    {
        // Connection string - adjust as needed
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Reservation()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Reservation", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool ReservationIDExists(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reservation WHERE ReservationID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", id);
            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            return count > 0;
        }

        private bool ValidateInputs()
        {
            // Assuming you have these textboxes:
            // textBox1 = ReservationID (int)
            // textBox2 = PassengerID (int)
            // textBox3 = FlightID (int)
            // dateTimePicker1 = BookingDate (DateTime)
            // textBox5 = ResStatus (string)
            // textBox6 = Class (string)
            // textBoxFare = TotalFare (decimal) --> you should create this textbox instead of reusing textBox7
            // textBox7 = SeatID (int)

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }
            // Optional: add numeric validation here (TryParse)
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            int resID = int.Parse(textBox1.Text);
            int seatID = int.Parse(textBox7.Text);

            if (ReservationIDExists(resID))
            {
                MessageBox.Show("Reservation ID already exists.");
                return;
            }

            string query = @"INSERT INTO Reservation (ReservationID, PassengerID, FlightID, BookingDate, ResStatus, Class, TotalFare) 
                             VALUES (@ResID, @PassID, @FlightID, @BookingDate, @ResStatus, @Class, @Fare)";

            string seatQuery = "INSERT INTO ReservationSeat (ReservationID, SeatID) VALUES (@ResID, @SeatID)";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlCommand cmdSeat = new SqlCommand(seatQuery, connection);

            cmd.Parameters.AddWithValue("@ResID", resID);
            cmd.Parameters.AddWithValue("@PassID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@FlightID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@BookingDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ResStatus", textBox4.Text);
            cmd.Parameters.AddWithValue("@Class", textBox5.Text);
            cmd.Parameters.AddWithValue("@Fare", decimal.Parse(textBox6.Text));  // Use textBoxFare here

            cmdSeat.Parameters.AddWithValue("@ResID", resID);
            cmdSeat.Parameters.AddWithValue("@SeatID", seatID);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmdSeat.ExecuteNonQuery();
                MessageBox.Show("Reservation and seat assigned successfully.");
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
            if (!ValidateInputs()) return;

            int resID = int.Parse(textBox1.Text);
            int seatID = int.Parse(textBox7.Text);

            string query = @"UPDATE Reservation 
                             SET PassengerID=@PassID, FlightID=@FlightID, BookingDate=@BookingDate, 
                                 ResStatus=@ResStatus, Class=@Class, TotalFare=@Fare 
                             WHERE ReservationID=@ResID";

            string seatUpdateQuery = "UPDATE ReservationSeat SET SeatID=@SeatID WHERE ReservationID=@ResID";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlCommand cmdSeat = new SqlCommand(seatUpdateQuery, connection);

            cmd.Parameters.AddWithValue("@ResID", resID);
            cmd.Parameters.AddWithValue("@PassID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@FlightID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@BookingDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ResStatus", textBox4.Text);
            cmd.Parameters.AddWithValue("@Class", textBox5.Text);
            cmd.Parameters.AddWithValue("@Fare", decimal.Parse(textBox6.Text));

            cmdSeat.Parameters.AddWithValue("@SeatID", seatID);
            cmdSeat.Parameters.AddWithValue("@ResID", resID);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmdSeat.ExecuteNonQuery();
                MessageBox.Show("Reservation and seat updated successfully.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reservation: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Reservation ID to delete.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int resID))
            {
                MessageBox.Show("Invalid Reservation ID.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            string deleteSeatQuery = "DELETE FROM ReservationSeat WHERE ReservationID = @ResID";
            string deleteReservationQuery = "DELETE FROM Reservation WHERE ReservationID = @ResID";

            SqlCommand cmdSeat = new SqlCommand(deleteSeatQuery, connection);
            SqlCommand cmdReservation = new SqlCommand(deleteReservationQuery, connection);

            cmdSeat.Parameters.AddWithValue("@ResID", resID);
            cmdReservation.Parameters.AddWithValue("@ResID", resID);

            try
            {
                connection.Open();
                cmdSeat.ExecuteNonQuery();         // Delete seat assignment first due to FK
                cmdReservation.ExecuteNonQuery();  // Then delete reservation
                MessageBox.Show("Reservation deleted successfully.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting reservation: " + ex.Message);
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
                textBox1.Text = row.Cells["ReservationID"].Value.ToString();
                textBox2.Text = row.Cells["PassengerID"].Value.ToString();
                textBox3.Text = row.Cells["FlightID"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["BookingDate"].Value);
                textBox5.Text = row.Cells["ResStatus"].Value.ToString();
                textBox6.Text = row.Cells["Class"].Value.ToString();
                textBox6.Text = row.Cells["TotalFare"].Value.ToString();

                int resID = int.Parse(textBox1.Text);
                SqlCommand cmd = new SqlCommand("SELECT SeatID FROM ReservationSeat WHERE ReservationID = @resID", connection);
                cmd.Parameters.AddWithValue("@resID", resID);

                try
                {
                    connection.Open();
                    object seatResult = cmd.ExecuteScalar();
                    textBox7.Text = seatResult?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading seat: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        
    }
}
