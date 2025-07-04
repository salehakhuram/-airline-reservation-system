using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class BookTicketsForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public BookTicketsForm()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[] { "Economy", "Business", "First Class" });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadFlights();
            LoadSeats();
        }

        private void LoadFlights()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT FlightID, FlightNumber, Duration, DepartureTime, Flight.RouteID FROM Flight JOIN Route ON Flight.RouteID = Route.RouteID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load flights: " + ex.Message);
            }
        }

        private void LoadSeats()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Seat WHERE AvailabilityStatus = 'Available'", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load seats: " + ex.Message);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a class.");
                return;
            }

            try
            {
                con.Open();

                // Step 0: Generate next ReservationID
                SqlCommand getMaxID = new SqlCommand("SELECT ISNULL(MAX(ReservationID), 0) + 1 FROM Reservation", con);
                int reservationID = Convert.ToInt32(getMaxID.ExecuteScalar());

                // Step 1: Insert into Reservation
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Reservation (ReservationID, PassengerID, FlightID, BookingDate, ResStatus, Class, TotalFare)
            VALUES (@rid, @pid, @fid, @bdate, @status, @class, @fare)", con);

                cmd.Parameters.AddWithValue("@rid", reservationID); // auto-generated
                cmd.Parameters.AddWithValue("@pid", textBox1.Text); // PassengerID
                cmd.Parameters.AddWithValue("@fid", int.Parse(textBox2.Text)); // FlightID
                cmd.Parameters.AddWithValue("@bdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", "Confirmed");
                cmd.Parameters.AddWithValue("@class", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@fare", decimal.Parse(textBox3.Text));

                cmd.ExecuteNonQuery();
               
                // Step 2: Insert into ReservationSeat
                SqlCommand cmdSeat = new SqlCommand(@"
            INSERT INTO ReservationSeat (ReservationID, SeatID)
            VALUES (@rid, @seatID)", con);
                cmdSeat.Parameters.AddWithValue("@rid", reservationID);
                cmdSeat.Parameters.AddWithValue("@seatID", int.Parse(textBox4.Text));
                cmdSeat.ExecuteNonQuery();

                SqlCommand updateSeat = new SqlCommand(@"
            UPDATE Seat SET AvailabilityStatus = 'Reserved' WHERE SeatID = @seatID", con);
                updateSeat.Parameters.AddWithValue("@seatID", int.Parse(textBox4.Text));
                updateSeat.ExecuteNonQuery();



                MessageBox.Show("Reserved successfully!\nReservation ID: " + reservationID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


    }
}

