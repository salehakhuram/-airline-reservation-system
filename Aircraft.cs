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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Flight_Reservation_System
{
    public partial class Aircraft : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Aircraft()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Aircraft", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) ||  // ID is required now
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please fill all required fields including Aircraft ID.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int aircraftID))
            {
                MessageBox.Show("Aircraft ID must be a valid number.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int capacity))
            {
                MessageBox.Show("Capacity must be a valid number.");
                return;
            }

            if (!int.TryParse(textBox6.Text, out int airlineID))
            {
                MessageBox.Show("AirlineID must be a valid number.");
                return;
            }

            string query = "INSERT INTO Aircraft (AircraftID, Model, Manufacturer, Capacity, AircraftCode, AirlineID) VALUES (@ID, @Model, @Manufacturer, @Capacity, @Code, @AirlineID)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ID", aircraftID);
            cmd.Parameters.AddWithValue("@Model", textBox2.Text);
            cmd.Parameters.AddWithValue("@Manufacturer", textBox3.Text);
            cmd.Parameters.AddWithValue("@Capacity", capacity);
            cmd.Parameters.AddWithValue("@Code", textBox5.Text);
            cmd.Parameters.AddWithValue("@AirlineID", airlineID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aircraft added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
                LoadData();
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter an Aircraft ID to delete.");
                return;
            }

            string query = "DELETE FROM Aircraft WHERE AircraftID=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aircraft deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
                LoadData();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            string query = "UPDATE Aircraft SET Model=@Model, Manufacturer=@Manufacturer, Capacity=@Capacity, AircraftCode=@Code, AirlineID=@AirlineID WHERE AircraftID=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Model", textBox2.Text);
            cmd.Parameters.AddWithValue("@Manufacturer", textBox3.Text);
            cmd.Parameters.AddWithValue("@Capacity", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Code", textBox5.Text);
            cmd.Parameters.AddWithValue("@AirlineID", int.Parse(textBox6.Text));

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    MessageBox.Show("Aircraft updated successfully.");
                else
                    MessageBox.Show("Aircraft ID not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
                LoadData();
            }
        }



        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void BtnViewAll_Click (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["AircraftID"].Value.ToString();
                textBox2.Text = row.Cells["Model"].Value.ToString();
                textBox3.Text = row.Cells["Manufacturer"].Value.ToString();
                textBox4.Text = row.Cells["Capacity"].Value.ToString();
                textBox5.Text = row.Cells["AircraftCode"].Value.ToString();
                textBox6.Text = row.Cells["AirlineID"].Value.ToString();
            }
        }

       
    }
}
