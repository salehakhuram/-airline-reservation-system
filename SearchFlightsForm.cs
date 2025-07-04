using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class SearchFlightsForm : Form
    {
        // Define your connection string here (update as needed)
        private readonly string connectionString = @"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True";

        public SearchFlightsForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Validate input first
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both Source and Destination.");
                return;
            }

            string query = @"
                SELECT 
                    f.FlightID AS [Flight ID], 
                    f.FlightNumber AS [Flight Number],
                    f.DepartureTime AS [Departure Time], 
                    f.ArrivalTime AS [Arrival Time], 
                    src.AirportName AS [From Airport], 
                    dest.AirportName AS [To Airport],
                    a.AirlineName AS [Airline]
                FROM Flight f
                INNER JOIN Route r ON f.RouteID = r.RouteID
                INNER JOIN Airport src ON r.OriginAirportID = src.AirportID
                INNER JOIN Airport dest ON r.DestinationAirportID = dest.AirportID
                INNER JOIN Airline a ON f.AirlineID = a.AirlineID
                WHERE UPPER(src.City) = @src AND UPPER(dest.City) = @dest";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@src", textBox1.Text.Trim().ToUpper());
                    da.SelectCommand.Parameters.AddWithValue("@dest", textBox2.Text.Trim().ToUpper());

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No flights found for the given route.");
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error retrieving flights: " + ex.Message);
                }
            }
        }
    }
}