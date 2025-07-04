namespace Flight_Reservation_System
{
    partial class signup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            UserID = new Label();
            FullName = new Label();
            Username = new Label();
            Password = new Label();
            TxtUserID = new TextBox();
            TxtFullName = new TextBox();
            TxtUsername = new TextBox();
            TxtPassword = new TextBox();
            TxtSignup = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // UserID
            // 
            UserID.AutoSize = true;
            UserID.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserID.Location = new Point(89, 78);
            UserID.Name = "UserID";
            UserID.Size = new Size(83, 30);
            UserID.TabIndex = 0;
            UserID.Text = "UserID";
            // 
            // FullName
            // 
            FullName.AutoSize = true;
            FullName.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FullName.Location = new Point(80, 141);
            FullName.Name = "FullName";
            FullName.Size = new Size(116, 30);
            FullName.TabIndex = 1;
            FullName.Text = "Full Name";
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Username.Location = new Point(79, 205);
            Username.Name = "Username";
            Username.Size = new Size(117, 30);
            Username.TabIndex = 2;
            Username.Text = "Username";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Password.Location = new Point(79, 263);
            Password.Name = "Password";
            Password.Size = new Size(112, 30);
            Password.TabIndex = 3;
            Password.Text = "Password";
            // 
            // TxtUserID
            // 
            TxtUserID.Location = new Point(236, 79);
            TxtUserID.Name = "TxtUserID";
            TxtUserID.Size = new Size(253, 31);
            TxtUserID.TabIndex = 4;
            // 
            // TxtFullName
            // 
            TxtFullName.Location = new Point(236, 140);
            TxtFullName.Name = "TxtFullName";
            TxtFullName.Size = new Size(253, 31);
            TxtFullName.TabIndex = 5;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(238, 204);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(251, 31);
            TxtUsername.TabIndex = 6;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(240, 264);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(249, 31);
            TxtPassword.TabIndex = 7;
            // 
            // TxtSignup
            // 
            TxtSignup.AutoSize = true;
            TxtSignup.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSignup.Location = new Point(318, 20);
            TxtSignup.Name = "TxtSignup";
            TxtSignup.Size = new Size(94, 30);
            TxtSignup.TabIndex = 8;
            TxtSignup.Text = "Sign Up";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(240, 329);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 33);
            comboBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(89, 332);
            label1.Name = "label1";
            label1.Size = new Size(57, 30);
            label1.TabIndex = 10;
            label1.Text = "Role";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(291, 381);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(149, 56);
            button1.TabIndex = 41;
            button1.Text = "Sign Up";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Signup_Click;
            // 
            // signup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(TxtSignup);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUsername);
            Controls.Add(TxtFullName);
            Controls.Add(TxtUserID);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(FullName);
            Controls.Add(UserID);
            Name = "signup";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserID;
        private Label FullName;
        private Label Username;
        private Label Password;
        private TextBox TxtUserID;
        private TextBox TxtFullName;
        private TextBox TxtUsername;
        private TextBox TxtPassword;
        private Label TxtSignup;
        private Button Signup;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
    }
}
