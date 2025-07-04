using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.SqlClient;

namespace Flight_Reservation_System
{
    public partial class AdminDashboard : Form
    {

        private string _username;
        private string _role;

        public AdminDashboard(string username, string role)
        {
            InitializeComponent();

            _username = username;
            _role = role;


        }


        private void BtnManageFlights_Click(object sender, EventArgs e)
        {
            var flightsForm = new Flight();
            flightsForm.Show();
        }

        private void BtnManageUsers_Click(object sender, EventArgs e)
        {
            var usersForm = new Users();
            usersForm.Show();
        }

        private void BtnManageStaff_Click(object sender, EventArgs e)
        {
            var staffForm = new Staff();
            staffForm.Show();
        }

        private void BtnManageAirlines_Click(object sender, EventArgs e)
        {
            var airlinesForm = new Airline();
            airlinesForm.Show();
        }

        private void BtnAssignStaffToFlights_Click(object sender, EventArgs e)
        {
            var assignStaffForm = new FlightStaff();
            assignStaffForm.Show();
        }

        private void BtnManageAirports_Click(object sender, EventArgs e)
        {
            var airportsForm = new Airport();
            airportsForm.Show();
        }

        private void BtnManageRoutes_Click(object sender, EventArgs e)
        {
            var routesForm = new Route();
            routesForm.Show();
        }

        private void BtnManageSchedule_Click(object sender, EventArgs e)
        {
            var scheduleForm = new Schedule();
            scheduleForm.Show();
        }

        private void BtnManageAircrafts_Click(object sender, EventArgs e)
        {
            var airportForm = new Aircraft();
            airportForm.Show();
        }
        private void BtnManageReservations_Click(object sender, EventArgs e)
        {
            var reservationForm = new Reservation();
            reservationForm.Show();
        }
        private void BtnManagePayment_Click(object sender, EventArgs e)
        {
            var paymentsForm = new Payment();
            paymentsForm.Show();
        }
        private void BtnManageSeats_Click(object sender, EventArgs e)
        {
            var seatForm = new Seat();
            seatForm.Show();
        }
        private void BtnManageBoardingPass_Click(object sender, EventArgs e)
        {
            var boardingForm = new BoardingPass();
            boardingForm.Show();
        }
        private void BtnManageBaggages_Click(object sender, EventArgs e)
        {
            var BaggageForm = new Baggage();
            BaggageForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Close dashboard, assuming login form re-shown or app exits
        }
    }
}
