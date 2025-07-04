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



using System;
using System.Windows.Forms;

namespace Flight_Reservation_System
{
    public partial class EmployeeDashboard : Form
    {
        private string userRole; // Store the role for later use

        public EmployeeDashboard(string role)
        {
            InitializeComponent();
            userRole = role;

        }

        private void btnFlights_Click(object sender, EventArgs e)
        {
            Flight flightsForm = new Flight();
            flightsForm.ShowDialog();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            Reservation reservationsForm = new Reservation();
            reservationsForm.ShowDialog();
        }

        private void btnPassengers_Click(object sender, EventArgs e)
        {
            Passenger passengersForm = new Passenger();
            passengersForm.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            Payment paymentsForm = new Payment();
            paymentsForm.ShowDialog();
        }

        private void btnSeats_Click(object sender, EventArgs e)
        {
            Seat seatsForm = new Seat();
            seatsForm.ShowDialog();
        }

        private void btnBoardingPasses_Click(object sender, EventArgs e)
        {
            BoardingPass boardingPassesForm = new BoardingPass();
            boardingPassesForm.ShowDialog();
        }

        private void btnBaggage_Click(object sender, EventArgs e)
        {
            Baggage baggageForm = new Baggage();
            baggageForm.ShowDialog();
        }
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            UpdateStatus fsForm = new UpdateStatus();
            fsForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Close dashboard, assuming login form re-shown or app exits
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.ShowDialog();
        }
    }
}
