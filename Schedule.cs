using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace Flight_Reservation_System
{
    public partial class Schedule : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Schedule()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Schedule", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool ScheduleIDExists(int scheduleID)
        {
            string query = "SELECT COUNT(*) FROM Schedule WHERE ScheduleID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", scheduleID);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
            string.IsNullOrWhiteSpace(textBox1.Text) || // ScheduleID
            string.IsNullOrWhiteSpace(textBox2.Text) || // FlightID
            string.IsNullOrWhiteSpace(textBox3.Text) || // Weekday
                string.IsNullOrWhiteSpace(textBox4.Text) || // Frequency
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) || // ValidFrom
                string.IsNullOrWhiteSpace(dateTimePicker2.Text))   // ValidTo
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int scheduleID) || !int.TryParse(textBox2.Text, out int flightID))
            {
                MessageBox.Show("Schedule ID and Flight ID must be valid numbers.");
                return;
            }

            if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime validFrom) ||
                !DateTime.TryParse(dateTimePicker2.Text, out DateTime validTo))
            {
                MessageBox.Show("Please enter valid dates for Valid From and Valid To.");
                return;
            }

            if (ScheduleIDExists(scheduleID))
            {
                MessageBox.Show("Schedule ID already exists.");
                return;
            }

            string query = "INSERT INTO Schedule (ScheduleID, FlightID, Weekday, Frequency, ValidFrom, ValidTo) " +
                           "VALUES (@ScheduleID, @FlightID, @Weekday, @Frequency, @ValidFrom, @ValidTo)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
            cmd.Parameters.AddWithValue("@FlightID", flightID);
            cmd.Parameters.AddWithValue("@Weekday", textBox3.Text);
            cmd.Parameters.AddWithValue("@Frequency", textBox4.Text);
            cmd.Parameters.AddWithValue("@ValidFrom", validFrom);
            cmd.Parameters.AddWithValue("@ValidTo", validTo);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Schedule added successfully.");
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
            if (!int.TryParse(textBox1.Text, out int scheduleID))
            {
                MessageBox.Show("Please enter a valid Schedule ID to delete.");
                return;
            }

            string query = "DELETE FROM Schedule WHERE ScheduleID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", scheduleID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Schedule deleted.");
                else
                    MessageBox.Show("Schedule ID not found.");
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
            if (
            string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker2.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int scheduleID) || !int.TryParse(textBox2.Text, out int flightID))
            {
                MessageBox.Show("Schedule ID and Flight ID must be valid numbers.");
                return;
            }

            if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime validFrom) ||
                !DateTime.TryParse(dateTimePicker2.Text, out DateTime validTo))
            {
                MessageBox.Show("Enter valid dates for Valid From and Valid To.");
                return;
            }

            string query = "UPDATE Schedule SET FlightID=@FlightID, Weekday=@Weekday, Frequency=@Frequency, ValidFrom=@ValidFrom, ValidTo=@ValidTo " +
                           "WHERE ScheduleID=@ScheduleID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
            cmd.Parameters.AddWithValue("@FlightID", flightID);
            cmd.Parameters.AddWithValue("@Weekday", textBox3.Text);
            cmd.Parameters.AddWithValue("@Frequency", textBox4.Text);
            cmd.Parameters.AddWithValue("@ValidFrom", validFrom);
            cmd.Parameters.AddWithValue("@ValidTo", validTo);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Schedule updated successfully.");
                else
                    MessageBox.Show("Schedule ID not found.");
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
                textBox1.Text = row.Cells["ScheduleID"].Value.ToString();
                textBox2.Text = row.Cells["FlightID"].Value.ToString();
                textBox3.Text = row.Cells["Weekday"].Value.ToString();
                textBox4.Text = row.Cells["Frequency"].Value.ToString();
                dateTimePicker1.Text = Convert.ToDateTime(row.Cells["ValidFrom"].Value).ToString("yyyy-MM-dd");
                dateTimePicker2.Text = Convert.ToDateTime(row.Cells["ValidTo"].Value).ToString("yyyy-MM-dd");
            }
        }
        private void Schedule_Load(object sender, EventArgs e) { }

    }
}
