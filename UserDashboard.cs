using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class UserDashboard : Form
    {
        private string role;
        private string userID;
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public UserDashboard(string role, string userID)
        {
            InitializeComponent();

            this.role = role;
            this.userID = userID;
        }

        private int GetReservationID(string userID)
        {
            int resID = -1;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = @"
                    SELECT TOP 1 r.ReservationID
                    FROM Reservation r
                    INNER JOIN Passenger p ON r.PassengerID = p.PassengerID
                    WHERE p.UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        resID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting ReservationID: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return resID;
        }

        private void btnSearchFlights_Click(object sender, EventArgs e)
        {
            new SearchFlightsForm().Show();
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            new BookTicketsForm().ShowDialog();
        }

        private void btnBookingHistory_Click(object sender, EventArgs e)
        {
            new BookingHistoryForm(userID).ShowDialog();
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            new PaymentForm().ShowDialog();
        }

        private void btnShowTicket_Click(object sender, EventArgs e)
        {
            new ShowTicketForm(userID).ShowDialog();
        }

        private void btnDownloadBoardingPass_Click(object sender, EventArgs e)
        {
            new BoardingPassForm().ShowDialog();
        }

        private void btnManageProfile_Click(object sender, EventArgs e)
        {
            new UpdateProfilee(userID).ShowDialog();
        }

        private void btnBaggageAddons_Click(object sender, EventArgs e)
        {
            new BaggageForm(userID).ShowDialog();
        }

        private void btnModifyReservation_Click(object sender, EventArgs e)
        {
            int resID = GetReservationID(userID);

            if (resID != -1)
            {
                new ModifyReservations(userID).ShowDialog();
            }
            else
            {
                MessageBox.Show("No reservation found for this user.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
