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
    public partial class Ticket : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Ticket()
        {
            InitializeComponent();

            // Fill the ComboBox here
            comboBox1.Items.Add("Economy");
            comboBox1.Items.Add("Premium Economy");
            comboBox1.Items.Add("Business");
            comboBox1.Items.Add("First Class");

            comboBox1.SelectedIndex = 0; // Set default value
        }


        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ticket", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        

        private bool TicketIDExists(int ticketID)
        {
            string query = "SELECT COUNT(*) FROM Ticket WHERE TicketID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ticketID);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) || // TicketID
                string.IsNullOrWhiteSpace(textBox2.Text) || // ReservationID
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) || // IssueDate
                string.IsNullOrWhiteSpace(textBox3.Text) || // TicketNum
                string.IsNullOrWhiteSpace(comboBox1.Text))   // TicketType
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int ticketID) ||
                !int.TryParse(textBox2.Text, out int reservationID))
            {
                MessageBox.Show("Ticket ID and Reservation ID must be valid integers.");
                return;
            }

            if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime issueDate))
            {
                MessageBox.Show("Please enter a valid issue date.");
                return;
            }

            if (TicketIDExists(ticketID))
            {
                MessageBox.Show("Ticket ID already exists.");
                return;
            }

            string query = "INSERT INTO Ticket (TicketID, ReservationID, IssueDate, TicketNumber, TicketType) " +
                           "VALUES (@TicketID, @ReservationID, @IssueDate, @TicketNum, @TicketType)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TicketID", ticketID);
            cmd.Parameters.AddWithValue("@ReservationID", reservationID);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@TicketNum", textBox3.Text);
            cmd.Parameters.AddWithValue("@TicketType", comboBox1.SelectedItem.ToString());


            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ticket added successfully.");
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
            if (!int.TryParse(textBox1.Text, out int ticketID))
            {
                MessageBox.Show("Please enter a valid Ticket ID to delete.");
                return;
            }

            string query = "DELETE FROM Ticket WHERE TicketID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ticketID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Ticket deleted.");
                else
                    MessageBox.Show("Ticket ID not found.");
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
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int ticketID) ||
                !int.TryParse(textBox2.Text, out int reservationID) ||
                !DateTime.TryParse(dateTimePicker1.Text, out DateTime issueDate))
            {
                MessageBox.Show("Invalid input: TicketID and ReservationID must be integers, and IssueDate must be valid.");
                return;
            }

            string query = "UPDATE Ticket SET ReservationID=@ReservationID, IssueDate=@IssueDate, TicketNumber=@TicketNum, TicketType=@TicketType " +
                           "WHERE TicketID=@TicketID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TicketID", ticketID);
            cmd.Parameters.AddWithValue("@ReservationID", reservationID);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@TicketNum", textBox3.Text);
            cmd.Parameters.AddWithValue("@TicketType", comboBox1.SelectedItem.ToString());


            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Ticket updated successfully.");
                else
                    MessageBox.Show("Ticket ID not found.");
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
                textBox1.Text = row.Cells["TicketID"].Value.ToString();
                textBox2.Text = row.Cells["ReservationID"].Value.ToString();
                dateTimePicker1.Text = Convert.ToDateTime(row.Cells["IssueDate"].Value).ToString("yyyy-MM-dd");
                textBox3.Text = row.Cells["TicketNumber"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["TicketType"].Value.ToString();

            }
        }

        
    }
}

