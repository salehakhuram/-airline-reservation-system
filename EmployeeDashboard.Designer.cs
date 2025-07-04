namespace Flight_Reservation_System
{
    partial class EmployeeDashboard : Form
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
            label2 = new Label();
            label5 = new Label();
            button1 = new Button();
            button10 = new Button();
            button11 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(752, 138);
            label2.Name = "label2";
            label2.Size = new Size(0, 30);
            label2.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(509, 81);
            label5.Name = "label5";
            label5.Size = new Size(215, 30);
            label5.TabIndex = 21;
            label5.Text = "Welcome Employee";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(98, 153);
            button1.Name = "button1";
            button1.Size = new Size(230, 50);
            button1.TabIndex = 22;
            button1.Text = "Manage Flights";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnFlights_Click;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.ButtonShadow;
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.Location = new Point(461, 153);
            button10.Name = "button10";
            button10.Size = new Size(230, 50);
            button10.TabIndex = 23;
            button10.Text = "Manage Reservations";
            button10.UseVisualStyleBackColor = false;
            button10.Click += btnReservations_Click;
            // 
            // button11
            // 
            button11.BackColor = SystemColors.ButtonShadow;
            button11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.Location = new Point(98, 277);
            button11.Name = "button11";
            button11.Size = new Size(230, 50);
            button11.TabIndex = 24;
            button11.Text = "Manage Passengers";
            button11.UseVisualStyleBackColor = false;
            button11.Click += btnPassengers_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonShadow;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(461, 277);
            button2.Name = "button2";
            button2.Size = new Size(230, 50);
            button2.TabIndex = 25;
            button2.Text = "Manage Payments";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnPayments_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonShadow;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(98, 393);
            button3.Name = "button3";
            button3.Size = new Size(230, 52);
            button3.TabIndex = 26;
            button3.Text = "Assign Seats";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnSeats_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonShadow;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(461, 393);
            button4.Name = "button4";
            button4.Size = new Size(230, 67);
            button4.TabIndex = 27;
            button4.Text = "Manage Boarding Passes";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnBoardingPasses_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ButtonShadow;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(809, 153);
            button5.Name = "button5";
            button5.Size = new Size(275, 50);
            button5.TabIndex = 28;
            button5.Text = "Manage Baggage Handling";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnBaggage_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ButtonShadow;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(809, 277);
            button6.Name = "button6";
            button6.Size = new Size(275, 50);
            button6.TabIndex = 29;
            button6.Text = "Update Flight Status";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnUpdateStatus_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ButtonShadow;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(449, 521);
            button7.Name = "button7";
            button7.Size = new Size(275, 50);
            button7.TabIndex = 30;
            button7.Text = "Log Out";
            button7.UseVisualStyleBackColor = false;
            button7.Click += btnLogout_Click;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.ButtonShadow;
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(809, 401);
            button8.Name = "button8";
            button8.Size = new Size(275, 50);
            button8.TabIndex = 31;
            button8.Text = "Issue Tickets";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // EmployeeDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1369, 723);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label2);
            Name = "EmployeeDashboard";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label5;
        private Button button1;
        private Button button10;
        private Button button11;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}