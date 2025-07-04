using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class Baggage : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public Baggage()
        {
            InitializeComponent();
            LoadBaggage();
            comboBox1.Items.AddRange(new string[] { "Checked In", "Loaded", "In Transit", "Claimed", "Lost" });
        }

        private void LoadBaggage()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT BaggageID, ReservationID, Weight, BaggageTag, Status FROM Baggage", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ClearFields()
        {
            textBox4.Clear(); // BaggageID
            textBox1.Clear(); // ReservationID
            textBox2.Clear(); // Weight
            textBox3.Clear(); // BaggageTag
            comboBox1.SelectedIndex = -1;
        }

        private void Button1_Click(object sender, EventArgs e) // Add
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Baggage (BaggageID, ReservationID, Weight, BaggageTag, Status) " +
                                                "VALUES (@BaggageID, @ReservationID, @Weight, @BaggageTag, @Status)", con);
                cmd.Parameters.AddWithValue("@BaggageID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@ReservationID", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Weight", decimal.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@BaggageTag", textBox4.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox1.SelectedItem.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Baggage Added");
                LoadBaggage();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) // Update
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            try
            {
                int baggageID = int.Parse(textBox4.Text);

                SqlCommand cmd = new SqlCommand("UPDATE Baggage SET ReservationID=@ReservationID, Weight=@Weight, BaggageTag=@BaggageTag, Status=@Status " +
                                                "WHERE BaggageID=@BaggageID", con);
                cmd.Parameters.AddWithValue("@BaggageID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@ReservationID", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Weight", decimal.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@BaggageTag", textBox4.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox1.SelectedItem.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Baggage Updated");
                LoadBaggage();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            try
            {
                int baggageID = int.Parse(textBox4.Text);

                SqlCommand cmd = new SqlCommand("DELETE FROM Baggage WHERE BaggageID=@BaggageID", con);
                cmd.Parameters.AddWithValue("@BaggageID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@ReservationID", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Weight", decimal.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@BaggageTag", textBox4.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox1.SelectedItem.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Baggage Deleted");
                LoadBaggage();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e) // View All
        {
            LoadBaggage();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["BaggageID"].Value.ToString();
                textBox2.Text = row.Cells["ReservationID"].Value.ToString();
                textBox3.Text = row.Cells["Weight"].Value.ToString();
                textBox4.Text = row.Cells["BaggageTag"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }

        
       
    }
}
