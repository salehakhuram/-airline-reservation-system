using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class ModifyReservations : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");
        private string userID;
        private int passengerID;

        public ModifyReservations(string userID)
        {
            InitializeComponent();
            this.userID = userID;

            textBox2.ReadOnly = true; // Make status read-only

            if (!GetPassengerID())
            {
                MessageBox.Show("No passenger found for this user.");
                this.Close();
                return;
            }

            LoadClassOptions();
            LoadSeatTable();
            LoadUserReservations();
        }

        private bool GetPassengerID()
        {
            string query = "SELECT PassengerID FROM Passenger WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    passengerID = Convert.ToInt32(result);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving PassengerID: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadClassOptions()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Economy");
            comboBox1.Items.Add("Business");
            comboBox1.Items.Add("First");
        }

        private void btnLoadReservation_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int reservationID))
            {
                MessageBox.Show("Please enter a valid Reservation ID.");
                return;
            }

            LoadReservationDetails(reservationID);
            LoadSeatTable();
        }

        private void LoadReservationDetails(int reservationID)
        {
            string query = @"SELECT Class, RS.SeatID, ResStatus
                             FROM Reservation R
                             JOIN ReservationSeat RS ON R.ReservationID = RS.ReservationID
                             WHERE R.ReservationID = @ResID AND PassengerID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ResID", reservationID);
            cmd.Parameters.AddWithValue("@UserID", passengerID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBox1.Text = reader["Class"].ToString();
                    textBox2.Text = reader["ResStatus"].ToString();
                    comboBox2.Text = reader["SeatID"].ToString();
                    label1.Text = reservationID.ToString();
                }
                else
                {
                    MessageBox.Show("Reservation not found or does not belong to this user.");
                    ClearForm();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadSeatTable()
        {
            comboBox2.Items.Clear();

            string query = "SELECT SeatID FROM Seat WHERE AvailabilityStatus = 'Available'";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["SeatID"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seats: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int reservationID))
            {
                MessageBox.Show("Please enter a valid Reservation ID.");
                return;
            }

            string newClass = comboBox1.Text;
            string newStatus = "Pending";

            if (!int.TryParse(comboBox2.Text, out int newSeatID))
            {
                MessageBox.Show("Please select a valid seat.");
                return;
            }

            string query = @"UPDATE Reservation 
                             SET Class = @Class, ResStatus = @Status
                             WHERE ReservationID = @ResID AND PassengerID = @UserID";

            string seatQuery = @"UPDATE ReservationSeat 
                                 SET SeatID = @SeatID 
                                 WHERE ReservationID = @ResID";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlCommand cmdSeat = new SqlCommand(seatQuery, conn);

            cmd.Parameters.AddWithValue("@Class", newClass);
            cmd.Parameters.AddWithValue("@Status", newStatus);
            cmd.Parameters.AddWithValue("@ResID", reservationID);
            cmd.Parameters.AddWithValue("@UserID", passengerID);

            cmdSeat.Parameters.AddWithValue("@SeatID", newSeatID);
            cmdSeat.Parameters.AddWithValue("@ResID", reservationID);

            try
            {
                conn.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                cmdSeat.ExecuteNonQuery();

                if (rowsUpdated > 0)
                {
                    MessageBox.Show("Reservation updated successfully. Status set to 'Pending'.");
                    ClearForm();
                    LoadSeatTable();
                    LoadUserReservations();
                }
                else
                {
                    MessageBox.Show("Reservation update failed. Check the Reservation ID and User.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancelRes_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int reservationID))
            {
                MessageBox.Show("Please enter a valid Reservation ID.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this reservation?", "Cancel", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string query = @"UPDATE Reservation 
                             SET ResStatus = 'Cancelled' 
                             WHERE ReservationID = @ResID AND PassengerID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ResID", reservationID);
            cmd.Parameters.AddWithValue("@UserID", passengerID);

            try
            {
                conn.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated > 0)
                {
                    MessageBox.Show("Reservation cancelled.");
                    ClearForm();
                    LoadSeatTable();
                    LoadUserReservations();
                }
                else
                {
                    MessageBox.Show("Cancellation failed. Check Reservation ID and User.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling reservation: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadUserReservations()
        {
            string query = @"SELECT R.ReservationID, R.Class, R.ResStatus, RS.SeatID 
                             FROM Reservation R
                             JOIN ReservationSeat RS ON R.ReservationID = RS.ReservationID
                             WHERE R.PassengerID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserID", passengerID);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            try
            {
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservations: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            comboBox1.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            textBox2.Text = "";
            label1.Text = "";
            textBox1.Text = "";
        }
    }
}
