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
 

        public partial class UpdateStatus: Form
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

            public UpdateStatus()
            {
                InitializeComponent();
                LoadFlights();
                comboBox1.Items.AddRange(new string[] { "On Time", "Delayed", "Cancelled" });
            }

            private void LoadFlights()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT FlightID, Status FROM Flight", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            private void button1_Click(object sender, EventArgs e) // Update status
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a flight and status.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("UPDATE Flight SET Status = @Status WHERE FlightID = @FlightID", con);
                cmd.Parameters.AddWithValue("@Status", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@FlightID", textBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Flight status updated.");
                LoadFlights();
            }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["FlightID"].Value.ToString();
                    comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                }
            }
        }
    }

