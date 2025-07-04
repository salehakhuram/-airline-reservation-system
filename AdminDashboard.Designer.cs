namespace Flight_Reservation_System
{
    public partial class AdminDashboard : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label5 = new Label();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(80, 104);
            button1.Name = "button1";
            button1.Size = new Size(230, 50);
            button1.TabIndex = 1;
            button1.Text = "Manage Flights";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnManageFlights_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(366, 104);
            button2.Name = "button2";
            button2.Size = new Size(275, 50);
            button2.TabIndex = 2;
            button2.Text = "Manage Users";
            button2.UseVisualStyleBackColor = false;
            button2.Click += BtnManageUsers_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDark;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(702, 104);
            button3.Name = "button3";
            button3.Size = new Size(247, 50);
            button3.TabIndex = 3;
            button3.Text = "Manage Staff";
            button3.UseVisualStyleBackColor = false;
            button3.Click += BtnManageStaff_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(80, 226);
            button4.Name = "button4";
            button4.Size = new Size(230, 50);
            button4.TabIndex = 4;
            button4.Text = "Manage Airlines";
            button4.UseVisualStyleBackColor = false;
            button4.Click += BtnManageAirlines_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ControlDark;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(366, 229);
            button5.Name = "button5";
            button5.Size = new Size(275, 47);
            button5.TabIndex = 5;
            button5.Text = "Assign Staff to Flights";
            button5.UseVisualStyleBackColor = false;
            button5.Click += BtnAssignStaffToFlights_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ButtonShadow;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(702, 221);
            button6.Name = "button6";
            button6.Size = new Size(247, 47);
            button6.TabIndex = 6;
            button6.Text = "Manage Airports";
            button6.UseVisualStyleBackColor = false;
            button6.Click += BtnManageAirports_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(440, 33);
            label5.Name = "label5";
            label5.Size = new Size(189, 30);
            label5.TabIndex = 13;
            label5.Text = "Welcome Admin!";
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ButtonShadow;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(80, 339);
            button7.Name = "button7";
            button7.Size = new Size(230, 42);
            button7.TabIndex = 14;
            button7.Text = "Manage Routes";
            button7.UseVisualStyleBackColor = false;
            button7.Click += BtnManageRoutes_Click;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.ButtonShadow;
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(366, 339);
            button8.Name = "button8";
            button8.Size = new Size(275, 42);
            button8.TabIndex = 15;
            button8.Text = "Manage Schedule";
            button8.UseVisualStyleBackColor = false;
            button8.Click += BtnManageSchedule_Click;
            // 
            // button9
            // 
            button9.BackColor = SystemColors.ButtonShadow;
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(702, 330);
            button9.Name = "button9";
            button9.Size = new Size(247, 39);
            button9.TabIndex = 16;
            button9.Text = "Manage Aircrafts";
            button9.UseVisualStyleBackColor = false;
            button9.Click += BtnManageAircrafts_Click;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.ButtonShadow;
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.Location = new Point(80, 443);
            button10.Name = "button10";
            button10.Size = new Size(230, 36);
            button10.TabIndex = 17;
            button10.Text = "Manage Reservations";
            button10.UseVisualStyleBackColor = false;
            button10.Click += BtnManageReservations_Click;
            // 
            // button11
            // 
            button11.BackColor = SystemColors.ButtonShadow;
            button11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.Location = new Point(366, 440);
            button11.Name = "button11";
            button11.Size = new Size(275, 39);
            button11.TabIndex = 18;
            button11.Text = "Manage Payments";
            button11.UseVisualStyleBackColor = false;
            button11.Click += BtnManagePayment_Click;
            // 
            // button12
            // 
            button12.BackColor = SystemColors.ButtonShadow;
            button12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button12.Location = new Point(702, 440);
            button12.Name = "button12";
            button12.Size = new Size(247, 39);
            button12.TabIndex = 19;
            button12.Text = "Manage Seats";
            button12.UseVisualStyleBackColor = false;
            button12.Click += BtnManageSeats_Click;
            // 
            // button13
            // 
            button13.BackColor = SystemColors.ButtonShadow;
            button13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button13.Location = new Point(80, 537);
            button13.Name = "button13";
            button13.Size = new Size(247, 39);
            button13.TabIndex = 20;
            button13.Text = "Manage Boarding Passes";
            button13.UseVisualStyleBackColor = false;
            button13.Click += BtnManageBoardingPass_Click;
            // 
            // button14
            // 
            button14.BackColor = SystemColors.ButtonShadow;
            button14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button14.Location = new Point(366, 537);
            button14.Name = "button14";
            button14.Size = new Size(247, 39);
            button14.TabIndex = 21;
            button14.Text = "Manage Baggage";
            button14.UseVisualStyleBackColor = false;
            button14.Click += BtnManageBaggages_Click;
            // 
            // button15
            // 
            button15.BackColor = SystemColors.ButtonShadow;
            button15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button15.Location = new Point(702, 546);
            button15.Name = "button15";
            button15.Size = new Size(247, 39);
            button15.TabIndex = 22;
            button15.Text = "Log Out";
            button15.UseVisualStyleBackColor = false;
            button15.Click += btnLogout_Click;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 629);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "AdminDashboard";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label5;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
    }
}