using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class BoardingPassForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public BoardingPassForm()
        {
            InitializeComponent();
            ClearLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reservationId = textBox1.Text.Trim();
            string passengerId = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(reservationId) && string.IsNullOrEmpty(passengerId))
            {
                MessageBox.Show("Please enter Reservation ID or Passenger ID.");
                return;
            }

            FetchBoardingPassDetails(reservationId, passengerId);
        }

        private void FetchBoardingPassDetails(string reservationId, string passengerId)
        {
            string query = @"
                SELECT r.ReservationID, p.PassengerID, p.FullName AS PassengerName,
                       f.FlightNumber, a1.City AS OriginCity, a2.City AS DestinationCity,
                       f.DepartureTime, s.SeatNumber,
                       bp.BoardingTime, bp.GateNum
                FROM Reservation r
                INNER JOIN Passenger p ON r.PassengerID = p.PassengerID
                INNER JOIN Flight f ON r.FlightID = f.FlightID
                INNER JOIN Route rt ON f.RouteID = rt.RouteID
                INNER JOIN Airport a1 ON rt.OriginAirportID = a1.AirportID
                INNER JOIN Airport a2 ON rt.DestinationAirportID = a2.AirportID
                INNER JOIN ReservationSeat rs ON r.ReservationID = rs.ReservationID
                INNER JOIN Seat s ON rs.SeatID = s.SeatID
                INNER JOIN BoardingPass bp ON r.ReservationID = bp.ReservationID
                WHERE (@ReservationID = '' OR r.ReservationID = @ReservationID)
                  AND (@PassengerID = '' OR p.PassengerID = @PassengerID)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                cmd.Parameters.AddWithValue("@PassengerID", passengerId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    label12.Text = reader["ReservationID"].ToString();        // Reservation ID
                    label13.Text = reader["PassengerID"].ToString();          // Passenger ID
                    label14.Text = reader["PassengerName"].ToString();        // Passenger Name
                    label15.Text = reader["FlightNumber"].ToString();            // Flight Number
                    label16.Text = reader["OriginCity"].ToString();           // From
                    label17.Text = reader["DestinationCity"].ToString();      // To
                    label18.Text = Convert.ToDateTime(reader["DepartureTime"]).ToString("hh:mm tt"); // Departure Time
                    label19.Text = reader["SeatNumber"].ToString();              // Seat Number
                    label20.Text = Convert.ToDateTime(reader["BoardingTime"]).ToString("hh:mm tt");  // Boarding Time
                    label21.Text = reader["GateNum"].ToString();              // Gate Number
                }
                else
                {
                    MessageBox.Show("No reservation found for the given input.");
                    ClearLabels();
                }

                reader.Close();
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

        private void ClearLabels()
        {
            label12.Text = "-"; // Reservation ID
            label13.Text = "-"; // Passenger ID
            label14.Text = "-"; // Passenger Name
            label15.Text = "-"; // Flight Number
            label16.Text = "-"; // From
            label17.Text = "-"; // To
            label18.Text = "-"; // Departure Time
            label19.Text = "-"; // Seat Number
            label20.Text = "-"; // Boarding Time
            label21.Text = "-"; // Gate Number
        }
    }
}
