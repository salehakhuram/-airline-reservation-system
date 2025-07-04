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
    public partial class PaymentForm : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True");

        public PaymentForm()
            {
                InitializeComponent();
            }

            private void btnPay_Click(object sender, EventArgs e)
            {
                string reservationId = textBox1.Text.Trim();
                string amountText = textBox2.Text.Trim();

                if (string.IsNullOrEmpty(reservationId) || string.IsNullOrEmpty(amountText))
                {
                    MessageBox.Show("Please enter Reservation ID and Payment Amount.");
                    return;
                }

                if (!decimal.TryParse(amountText, out decimal amount))
                {
                    MessageBox.Show("Invalid amount entered.");
                    return;
                }

                if (MakePayment(reservationId, amount))
                {
                    MessageBox.Show("Payment successful! Status updated.");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Payment failed or reservation not found.");
                }
            }

        private bool MakePayment(string reservationId, decimal amount)
        {
            string connectionString = @"Data Source=DESKTOP-5NPQD72\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if reservation exists and payment is pending
                string checkQuery = "SELECT PayStatus FROM Payment WHERE ReservationID = @ReservationID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@ReservationID", reservationId);

                var statusObj = checkCmd.ExecuteScalar();
                if (statusObj == null)
                {
                    return false;
                }

                string status = statusObj.ToString();
                if (status == "Paid")
                {
                    MessageBox.Show("Payment already done for this reservation.");
                    return false;
                }

                // Update payment status
                string updateQuery = @"
            UPDATE Payment
            SET PayStatus = 'Paid',
                Amount = @Amount,
                PayDate = @PaymentDate
            WHERE ReservationID = @ReservationID";

                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@Amount", amount);
                updateCmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                updateCmd.Parameters.AddWithValue("@ReservationID", reservationId);

                int rows = updateCmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        private void ClearForm()
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
