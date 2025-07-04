namespace Flight_Reservation_System
{
    partial class UserDashboard : Form
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
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            label5 = new Label();
            button2 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 25);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(48, 108);
            button1.Name = "button1";
            button1.Size = new Size(221, 53);
            button1.TabIndex = 6;
            button1.Text = "Search Flights";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnSearchFlights_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDark;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(461, 465);
            button3.Name = "button3";
            button3.Size = new Size(143, 58);
            button3.TabIndex = 8;
            button3.Text = "Log Out";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnLogout_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(506, 40);
            label5.Name = "label5";
            label5.Size = new Size(161, 30);
            label5.TabIndex = 12;
            label5.Text = "Welcome User";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(398, 225);
            button2.Name = "button2";
            button2.Size = new Size(197, 44);
            button2.TabIndex = 13;
            button2.Text = "Show Ticket";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnShowTicket_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(48, 225);
            button4.Name = "button4";
            button4.Size = new Size(221, 51);
            button4.TabIndex = 14;
            button4.Text = "Booking History";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnBookingHistory_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ControlDark;
            button5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ControlText;
            button5.Location = new Point(724, 108);
            button5.Name = "button5";
            button5.Size = new Size(197, 44);
            button5.TabIndex = 15;
            button5.Text = "Make Payment";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnMakePayment_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ControlDark;
            button6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ControlText;
            button6.Location = new Point(398, 112);
            button6.Name = "button6";
            button6.Size = new Size(197, 44);
            button6.TabIndex = 16;
            button6.Text = "Reservation";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnBookTicket_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ControlDark;
            button7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ControlText;
            button7.Location = new Point(736, 225);
            button7.Name = "button7";
            button7.Size = new Size(197, 44);
            button7.TabIndex = 17;
            button7.Text = "Boarding Pass";
            button7.UseVisualStyleBackColor = false;
            button7.Click += btnDownloadBoardingPass_Click;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.ControlDark;
            button8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = SystemColors.ControlText;
            button8.Location = new Point(736, 336);
            button8.Name = "button8";
            button8.Size = new Size(197, 44);
            button8.TabIndex = 18;
            button8.Text = "Manage Profile";
            button8.UseVisualStyleBackColor = false;
            button8.Click += btnManageProfile_Click;
            // 
            // button9
            // 
            button9.BackColor = SystemColors.ControlDark;
            button9.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = SystemColors.ControlText;
            button9.Location = new Point(48, 336);
            button9.Name = "button9";
            button9.Size = new Size(221, 44);
            button9.TabIndex = 19;
            button9.Text = "Baggage";
            button9.UseVisualStyleBackColor = false;
            button9.Click += btnBaggageAddons_Click;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.ControlDark;
            button10.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = SystemColors.ControlText;
            button10.Location = new Point(398, 336);
            button10.Name = "button10";
            button10.Size = new Size(226, 44);
            button10.TabIndex = 20;
            button10.Text = "Cancel Reservation";
            button10.UseVisualStyleBackColor = false;
            button10.Click += btnModifyReservation_Click;
            // 
            // UserDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 965);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "UserDashboard";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button3;
        private Label label5;
        private Button button2;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
    }
}