using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class ShowTicketForm : Form
    {
        private string userId;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public ShowTicketForm(string loggedInUserId)
        {
            InitializeComponent();
            userId = loggedInUserId;
            LoadTicketInfo();
        }

        private void LoadTicketInfo()
        {
            try
            {
                con.Open();

                // Step 1: Get Passenger Info using UserID
                string getPassengerQuery = "SELECT PassengerID , FullName  FROM Passenger WHERE UserID = @UserID";
                SqlCommand getPassengerCmd = new SqlCommand(getPassengerQuery, con);
                getPassengerCmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataReader passengerReader = getPassengerCmd.ExecuteReader();

                if (!passengerReader.Read())
                {
                    MessageBox.Show("No passenger found for this user.");
                    return;
                }

                int passengerId = Convert.ToInt32(passengerReader["PassengerID"]);
                string passengerName = passengerReader["FullName"].ToString();

                passengerReader.Close();

                // Step 2: Get Ticket Info
                string query = @"
        SELECT t.TicketID, t.TicketNumber, t.TicketType, t.IssueDate,
               r.ReservationID, r.Class, r.TotalFare,
               f.FlightNumber, f.DepartureTime, f.ArrivalTime,
               a1.City AS FromCity, a2.City AS ToCity
        FROM Reservation r
        INNER JOIN Ticket t ON r.ReservationID = t.ReservationID
        INNER JOIN Flight f ON r.FlightID = f.FlightID
        INNER JOIN Route rt ON f.RouteID = rt.RouteID
        INNER JOIN Airport a1 ON rt.OriginAirportID = a1.AirportID
        INNER JOIN Airport a2 ON rt.DestinationAirportID = a2.AirportID
        WHERE r.PassengerID = @PassengerID AND r.ResStatus = 'Confirmed'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PassengerID", passengerId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Mapping to default labels
                    label1.Text = reader["TicketID"].ToString();               // Ticket ID
                    label2.Text = reader["TicketNumber"].ToString();           // Ticket Number
                    label3.Text = reader["TicketType"].ToString();             // Ticket Type
                    label4.Text = Convert.ToDateTime(reader["IssueDate"]).ToString("yyyy-MM-dd"); // Issue Date
                    label6.Text = reader["ReservationID"].ToString();          // Reservation ID
                    label7.Text = passengerName;                               // Passenger Name
                    label8.Text = reader["FlightNumber"].ToString();           // Flight Number
                    label9.Text = reader["FromCity"].ToString();               // Departure City
                    label10.Text = reader["ToCity"].ToString();                 // Arrival City
                    label11.Text = "Rs. " + reader["TotalFare"].ToString();    // Total Fare
                }
                else
                {
                    MessageBox.Show("No confirmed ticket found for this passenger.");
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

      
    }
}
