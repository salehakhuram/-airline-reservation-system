using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Flight_Reservation_System
{
    public partial class BaggageForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public string LoggedInUserID; // Set this on login
       
        public BaggageForm(string userId)
        {
            InitializeComponent();
            LoggedInUserID = userId;
           

            LoadBaggageData();

        }


        private void LoadBaggageData()
        {
            string query = @"SELECT b.BaggageID, r.ReservationID, b.Weight, b.BaggageTag, b.Status
                             FROM Baggage b
                             JOIN Reservation r ON b.ReservationID = r.ReservationID
                             JOIN Passenger p ON r.PassengerID = p.PassengerID
                             WHERE p.UserID = @UserID";

            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            da.SelectCommand.Parameters.AddWithValue("@UserID", LoggedInUserID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private int GetReservationID()
        {
            string query = "SELECT TOP 1 ReservationID FROM Reservation r JOIN Passenger p ON r.PassengerID = p.PassengerID WHERE p.UserID = @uid ORDER BY BookingDate DESC";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@uid", LoggedInUserID);
            connection.Open();
            int reservationId = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return reservationId;
        }

        private void btnAddBaggage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter baggage weight.");
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal weight))
            {
                MessageBox.Show("Please enter a valid number for weight.");
                return;
            }

            int reservationId = GetReservationID();
            string tag = "TAG" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(); // auto-generated tag
            string status = "Pending"; // default status

            // 1. Get last BaggageID
            int newBaggageID = 1;
            string getLastIDQuery = "SELECT ISNULL(MAX(BaggageID), 0) + 1 FROM Baggage";
            SqlCommand getIdCmd = new SqlCommand(getLastIDQuery, connection);

            try
            {
                connection.Open();
                newBaggageID = Convert.ToInt32(getIdCmd.ExecuteScalar());

                // 2. Insert with custom ID
                string insertQuery = @"
            INSERT INTO Baggage (BaggageID, ReservationID, Weight, BaggageTag, Status) 
            VALUES (@BaggageID, @ResID, @Weight, @Tag, @Status)";

                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@BaggageID", newBaggageID);
                cmd.Parameters.AddWithValue("@ResID", reservationId);
                cmd.Parameters.AddWithValue("@Weight", weight);
                cmd.Parameters.AddWithValue("@Tag", tag);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Baggage added successfully.\nBaggageID: {newBaggageID}\nTag: {tag}");
                LoadBaggageData();
                ClearInputs();
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





        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Weight"].Value.ToString();
                
            }
        }

       

        private void ClearInputs()
        {
            textBox1.Clear();
          
        }
    }
}
