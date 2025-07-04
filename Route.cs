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
    public partial class Route : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Route()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Route", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool RouteIDExists(int routeID)
        {
            string query = "SELECT COUNT(*) FROM Route WHERE RouteID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", routeID);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count > 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) || // RouteID
                string.IsNullOrWhiteSpace(textBox2.Text) || // OriginAirportID
                string.IsNullOrWhiteSpace(textBox3.Text) || // DestinationAirportID
                string.IsNullOrWhiteSpace(textBox4.Text))   // Distance
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int routeID) ||
                !int.TryParse(textBox2.Text, out int originAirportID) ||
                !int.TryParse(textBox3.Text, out int destinationAirportID) ||
                !decimal.TryParse(textBox4.Text, out decimal distance))
            {
                MessageBox.Show("Please enter valid values. IDs must be integers and Distance must be a decimal number.");
                return;
            }

            if (RouteIDExists(routeID))
            {
                MessageBox.Show("Route ID already exists.");
                return;
            }

            string query = "INSERT INTO Route (RouteID, OriginAirportID, DestinationAirportID, Distance) " +
                           "VALUES (@RouteID, @OriginAirportID, @DestinationAirportID, @Distance)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@RouteID", routeID);
            cmd.Parameters.AddWithValue("@OriginAirportID", originAirportID);
            cmd.Parameters.AddWithValue("@DestinationAirportID", destinationAirportID);
            cmd.Parameters.AddWithValue("@Distance", distance);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Route added successfully.");
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
            if (!int.TryParse(textBox1.Text, out int routeID))
            {
                MessageBox.Show("Please enter a valid Route ID to delete.");
                return;
            }

            string query = "DELETE FROM Route WHERE RouteID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", routeID);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Route deleted.");
                else
                    MessageBox.Show("Route ID not found.");
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
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int routeID) ||
                !int.TryParse(textBox2.Text, out int originAirportID) ||
                !int.TryParse(textBox3.Text, out int destinationAirportID) ||
                !decimal.TryParse(textBox4.Text, out decimal distance))
            {
                MessageBox.Show("Please enter valid values. IDs must be integers and Distance must be a decimal number.");
                return;
            }

            string query = "UPDATE Route SET OriginAirportID=@OriginAirportID, DestinationAirportID=@DestinationAirportID, Distance=@Distance " +
                           "WHERE RouteID=@RouteID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@RouteID", routeID);
            cmd.Parameters.AddWithValue("@OriginAirportID", originAirportID);
            cmd.Parameters.AddWithValue("@DestinationAirportID", destinationAirportID);
            cmd.Parameters.AddWithValue("@Distance", distance);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Route updated successfully.");
                else
                    MessageBox.Show("Route ID not found.");
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
                textBox1.Text = row.Cells["RouteID"].Value.ToString();
                textBox2.Text = row.Cells["OriginAirportID"].Value.ToString();
                textBox3.Text = row.Cells["DestinationAirportID"].Value.ToString();
                textBox4.Text = row.Cells["Distance"].Value.ToString();
            }
        }

        private void Route_Load(object sender, EventArgs e) { }
    }
}

