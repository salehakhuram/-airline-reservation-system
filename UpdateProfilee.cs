using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class UpdateProfilee : Form
    {
        // Connection string
        private string connectionString = "Data Source=DESKTOP-5NPQD72\\SQLEXPRESS;Initial Catalog=Flight Reservation System;Integrated Security=True";

        public UpdateProfilee(string userID)
        {
            InitializeComponent();
            textBox1.Text = userID; // Fill UserID from login
            textBox1.Enabled = false; // Prevent editing UserID
            LoadUserData(userID);
        }

        private void LoadUserData(string userID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName, Username, Password FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader["FullName"].ToString();
                    textBox3.Text = reader["Username"].ToString();
                    textBox4.Text = reader["Password"].ToString();
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
      BEGIN TRANSACTION;

    UPDATE Users
    SET FullName = @FullName, Username = @Username, Password = @Password
    WHERE UserID = @UserID;

    UPDATE Passenger
    SET FullName = @FullName
    WHERE UserID = @UserID;

    COMMIT;";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", textBox1.Text);
                cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Username", textBox3.Text);
                cmd.Parameters.AddWithValue("@Password", textBox4.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Profile updated successfully.");
            }
        }
    }
}
