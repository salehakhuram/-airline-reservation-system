using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class Flight : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Flight()
        {
            InitializeComponent();
            ConfigureDatePickers();
        }

        private void ConfigureDatePickers()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm tt";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm tt";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "HH:mm"; // only hours and minutes
            dateTimePicker3.ShowUpDown = true;

        }

        private void LoadData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Flight", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private bool ValidateInput(out int flightID, out int aircraftID, out int airlineID, out int routeID)
        {
            flightID = aircraftID = airlineID = routeID = 0;
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (!int.TryParse(textBox1.Text, out flightID) ||
                !int.TryParse(textBox3.Text, out aircraftID) ||
                !int.TryParse(textBox5.Text, out airlineID) ||
                !int.TryParse(textBox6.Text, out routeID))
            {
                MessageBox.Show("FlightID, AircraftID, AirlineID, and RouteID must be valid numbers.");
                return false;
            }
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out int flightID, out int aircraftID, out int airlineID, out int routeID)) return;

            string query = "INSERT INTO Flight (FlightID, FlightNumber, Duration, AircraftID, AirlineID, RouteID, Status, DepartureTime, ArrivalTime) " +
                           "VALUES (@FlightID, @FlightNumber, @Duration, @AircraftID, @AirlineID, @RouteID, @Status, @DepartureTime, @ArrivalTime)";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FlightID", flightID);
            cmd.Parameters.AddWithValue("@FlightNumber", textBox2.Text);
            cmd.Parameters.AddWithValue("@Duration", dateTimePicker3.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("@AircraftID", aircraftID);
            cmd.Parameters.AddWithValue("@AirlineID", airlineID);
            cmd.Parameters.AddWithValue("@RouteID", routeID);
            cmd.Parameters.AddWithValue("@Status", textBox7.Text);
            cmd.Parameters.AddWithValue("@DepartureTime", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ArrivalTime", dateTimePicker2.Value);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Flight added successfully.");
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
            if (!int.TryParse(textBox1.Text, out int flightID))
            {
                MessageBox.Show("Enter a valid FlightID to delete.");
                return;
            }

            string query = "DELETE FROM Flight WHERE FlightID = @FlightID";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FlightID", flightID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Flight deleted successfully." : "FlightID not found.");
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
            if (!ValidateInput(out int flightID, out int aircraftID, out int airlineID, out int routeID)) return;

            string query = "UPDATE Flight SET FlightNumber = @FlightNumber, Duration = @Duration, AircraftID = @AircraftID, " +
                           "AirlineID = @AirlineID, RouteID = @RouteID, Status = @Status, DepartureTime = @DepartureTime, " +
                           "ArrivalTime = @ArrivalTime WHERE FlightID = @FlightID";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FlightID", flightID);
            cmd.Parameters.AddWithValue("@FlightNumber", textBox2.Text);
            cmd.Parameters.AddWithValue("@Duration", dateTimePicker3.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("@AircraftID", aircraftID);
            cmd.Parameters.AddWithValue("@AirlineID", airlineID);
            cmd.Parameters.AddWithValue("@RouteID", routeID);
            cmd.Parameters.AddWithValue("@Status", textBox7.Text);
            cmd.Parameters.AddWithValue("@DepartureTime", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ArrivalTime", dateTimePicker2.Value);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Flight updated successfully." : "FlightID not found.");
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

                textBox1.Text = row.Cells["FlightID"].Value.ToString();
                textBox2.Text = row.Cells["FlightNumber"].Value.ToString();
                textBox3.Text = row.Cells["AircraftID"].Value.ToString();
                textBox5.Text = row.Cells["AirlineID"].Value.ToString();
                textBox6.Text = row.Cells["RouteID"].Value.ToString();
                textBox7.Text = row.Cells["Status"].Value.ToString();

                if (DateTime.TryParse(row.Cells["DepartureTime"].Value.ToString(), out DateTime departure))
                    dateTimePicker1.Value = departure;

                if (DateTime.TryParse(row.Cells["ArrivalTime"].Value.ToString(), out DateTime arrival))
                    dateTimePicker2.Value = arrival;

                if (TimeSpan.TryParse(row.Cells["Duration"].Value.ToString(), out TimeSpan duration))
                    dateTimePicker3.Value = DateTime.Today.Add(duration);
            }
        }

      
    }
}
