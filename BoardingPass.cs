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
    public partial class BoardingPass : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public BoardingPass()
        {
            InitializeComponent();
            LoadBoardingPasses();
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker2.ShowUpDown = true; // Optional: use spin control instead of calendar

        }

        private void LoadBoardingPasses()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BoardingPass", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Add
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO BoardingPass (BoardingPassID,ReservationID, IssueDate, GateNum, BoardingTime) " +
                                                "VALUES (@BoardingPassID,@ReservationID, @IssueDate, @GateNumber, @BoardingTime)", con);
                cmd.Parameters.AddWithValue("@BoardingPassID", textBox1.Text);
                cmd.Parameters.AddWithValue("@ReservationID", textBox2.Text);
                cmd.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@GateNumber", textBox3.Text);
                cmd.Parameters.AddWithValue("@BoardingTime", dateTimePicker2.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Boarding Pass Added");
                LoadBoardingPasses();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Update
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

                SqlCommand cmd = new SqlCommand("UPDATE BoardingPass SET ReservationID=@ReservationID, IssueDate=@IssueDate, GateNum=@GateNum, BoardingTime=@BoardingTime " +
                                                "WHERE BoardingPassID=@BoardingPassID", con);
                cmd.Parameters.AddWithValue("@BoardingPassID", textBox1.Text);
                cmd.Parameters.AddWithValue("@ReservationID", textBox2.Text);
                cmd.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@GateNumber", textBox3.Text);
                cmd.Parameters.AddWithValue("@BoardingTime", dateTimePicker2.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Boarding Pass Updated");
                LoadBoardingPasses();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

                SqlCommand cmd = new SqlCommand("DELETE FROM BoardingPass WHERE BoardingPassID=@BoardingPassID", con);
                cmd.Parameters.AddWithValue("@BoardingPassID", textBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Boarding Pass Deleted");
                LoadBoardingPasses();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) // View All
        {
            LoadBoardingPasses();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["BoardingPassID"].Value.ToString();
                textBox2.Text = row.Cells["ReservationID"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["IssueDate"].Value);
                textBox3.Text = row.Cells["GateNum"].Value.ToString();
                dateTimePicker2.Value = Convert.ToDateTime(row.Cells["BoardingTime"].Value);
            }
        }

  
    }
}
