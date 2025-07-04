using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class FlightStaff : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public FlightStaff()
        {
            InitializeComponent();
        }

        private void FlightStaff_Load(object sender, EventArgs e)
        {
            LoadFlightStaff();
            LoadFlights();
            LoadStaff();
        }

        private void LoadFlightStaff()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FlightStaff", connection))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void LoadFlights()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT FlightID, FlightNumber, Departure, Arrival FROM Flight", connection))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void LoadStaff()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT StaffID, Name, Position FROM Staff", connection))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int flightId) || !int.TryParse(textBox2.Text, out int staffId) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter valid FlightID, StaffID, and Assignment Role.");
                return;
            }

            using (SqlCommand cmd = new SqlCommand("INSERT INTO FlightStaff (FlightID, StaffID, AssignmentRole) VALUES (@FlightID, @StaffID, @Role)", connection))
            {
                cmd.Parameters.AddWithValue("@FlightID", flightId);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.Parameters.AddWithValue("@Role", textBox3.Text);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("FlightStaff record added.");
                    LoadFlightStaff();
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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int flightId) || !int.TryParse(textBox2.Text, out int staffId) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter valid FlightID, StaffID, and Assignment Role.");
                return;
            }

            using (SqlCommand cmd = new SqlCommand("UPDATE FlightStaff SET AssignmentRole = @Role WHERE FlightID = @FlightID AND StaffID = @StaffID", connection))
            {
                cmd.Parameters.AddWithValue("@FlightID", flightId);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.Parameters.AddWithValue("@Role", textBox3.Text);

                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Updated successfully." : "Record not found.");
                    LoadFlightStaff();
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int flightId) || !int.TryParse(textBox2.Text, out int staffId))
            {
                MessageBox.Show("Please enter valid FlightID and StaffID.");
                return;
            }

            using (SqlCommand cmd = new SqlCommand("DELETE FROM FlightStaff WHERE FlightID = @FlightID AND StaffID = @StaffID", connection))
            {
                cmd.Parameters.AddWithValue("@FlightID", flightId);
                cmd.Parameters.AddWithValue("@StaffID", staffId);

                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Deleted successfully." : "Record not found.");
                    LoadFlightStaff();
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
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadFlightStaff();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["FlightID"].Value.ToString();
                textBox2.Text = row.Cells["StaffID"].Value.ToString();
                textBox3.Text = row.Cells["AssignmentRole"].Value.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells["FlightID"].Value.ToString();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView3.Rows[e.RowIndex].Cells["StaffID"].Value.ToString();
            }
        }
    }
}
