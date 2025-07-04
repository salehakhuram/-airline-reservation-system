using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class BookingHistoryForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");
        private string currentUserId;  // Store passed user ID

        public BookingHistoryForm(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void BookingHistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Step 1: Get PassengerID for the given UserID
                SqlCommand getPassengerCmd = new SqlCommand("SELECT PassengerID FROM Passenger WHERE UserID = @uid", con);
                getPassengerCmd.Parameters.AddWithValue("@uid", currentUserId);

                object result = getPassengerCmd.ExecuteScalar();

                if (result != null)
                {
                    int passengerId = Convert.ToInt32(result);

                    // Step 2: Get Reservation history for the PassengerID
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Reservation WHERE PassengerID = @pid", con);
                    da.SelectCommand.Parameters.AddWithValue("@pid", passengerId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Passenger not found for this user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking history: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
