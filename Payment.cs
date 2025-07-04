using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class Payment : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

    
        private bool fromUserDashboard;

        public Payment(bool fromUserDashboard = false)
        {
            InitializeComponent();
            this.fromUserDashboard = fromUserDashboard;
        }


        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Payment", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private bool PaymentIDExists(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Payment WHERE PayId = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", id);
            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            return count > 0;
        }

        private void ClearForm()
        {
            textBox1.Clear();  // PayId
            textBox2.Clear();  // ReservationID
            dateTimePicker1.Value = DateTime.Today;  // PayDate
            textBox3.Clear();  // Amount
            textBox4.Clear();  // PayMethod
            textBox5.Clear();  // PayStatus
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) ||  // PayId
                string.IsNullOrWhiteSpace(textBox2.Text) ||  // ReservationID
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||  // PayDate
                string.IsNullOrWhiteSpace(textBox3.Text) ||  // Amount
                string.IsNullOrWhiteSpace(textBox4.Text) ||  // PayMethod
                string.IsNullOrWhiteSpace(textBox5.Text)     // PayStatus
               )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int payId))
            {
                MessageBox.Show("PayId must be a number.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int reservationId))
            {
                MessageBox.Show("ReservationID must be a number.");
                return;
            }

            if (!decimal.TryParse(textBox3.Text, out decimal amount))
            {
                MessageBox.Show("Amount must be a valid number.");
                return;
            }

            if (PaymentIDExists(payId))
            {
                MessageBox.Show("PayId already exists.");
                return;
            }

            string query = "INSERT INTO Payment (PayId, ReservationID, PayDate, Amount, PayMethod, PayStatus) " +
                           "VALUES (@PayId, @ReservationID, @PayDate, @Amount, @PayMethod, @PayStatus)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PayId", payId);
            cmd.Parameters.AddWithValue("@ReservationID", reservationId);
            cmd.Parameters.AddWithValue("@PayDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@PayMethod", textBox4.Text);
            cmd.Parameters.AddWithValue("@PayStatus", textBox5.Text);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment added successfully.");
                LoadData();
                ClearForm();
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
            if (!int.TryParse(textBox1.Text, out int payId))
            {
                MessageBox.Show("Enter a valid PayId.");
                return;
            }

            SqlCommand cmd = new SqlCommand("DELETE FROM Payment WHERE PayId = @PayId", connection);
            cmd.Parameters.AddWithValue("@PayId", payId);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Payment deleted." : "PayId not found.");
                LoadData();
                ClearForm();
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
                string.IsNullOrWhiteSpace(textBox1.Text) ||  // PayId
                string.IsNullOrWhiteSpace(textBox2.Text) ||  // ReservationID
                string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||  // PayDate
                string.IsNullOrWhiteSpace(textBox3.Text) ||  // Amount
                string.IsNullOrWhiteSpace(textBox4.Text) ||  // PayMethod
                string.IsNullOrWhiteSpace(textBox5.Text)     // PayStatus
               )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int payId))
            {
                MessageBox.Show("PayId must be a number.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int reservationId))
            {
                MessageBox.Show("ReservationID must be a number.");
                return;
            }

            if (!decimal.TryParse(textBox3.Text, out decimal amount))
            {
                MessageBox.Show("Amount must be a valid number.");
                return;
            }

            string query = "UPDATE Payment SET ReservationID=@ReservationID, PayDate=@PayDate, Amount=@Amount, PayMethod=@PayMethod, PayStatus=@PayStatus " +
                           "WHERE PayId=@PayId";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PayId", payId);
            cmd.Parameters.AddWithValue("@ReservationID", reservationId);
            cmd.Parameters.AddWithValue("@PayDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@PayMethod", textBox4.Text);
            cmd.Parameters.AddWithValue("@PayStatus", textBox5.Text);

            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Payment updated." : "PayId not found.");
                LoadData();
                ClearForm();
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
                textBox1.Text = row.Cells["PayId"].Value.ToString();
                textBox2.Text = row.Cells["ReservationID"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["PayDate"].Value);
                textBox3.Text = row.Cells["Amount"].Value.ToString();
                textBox4.Text = row.Cells["PayMethod"].Value.ToString();
                textBox5.Text = row.Cells["PayStatus"].Value.ToString();
            }
        }

       
    }
}
