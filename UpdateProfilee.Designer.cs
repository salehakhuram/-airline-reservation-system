namespace Flight_Reservation_System
{
    partial class UpdateProfilee : Form
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
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(625, 213);
            button1.Name = "button1";
            button1.Size = new Size(112, 40);
            button1.TabIndex = 50;
            button1.Text = "Update Status";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(237, 331);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(287, 31);
            textBox4.TabIndex = 49;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(237, 268);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(287, 31);
            textBox3.TabIndex = 48;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(237, 202);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(287, 31);
            textBox2.TabIndex = 47;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(237, 147);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(287, 31);
            textBox1.TabIndex = 46;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(74, 331);
            label6.Name = "label6";
            label6.Size = new Size(124, 30);
            label6.TabIndex = 45;
            label6.Text = "Password :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(70, 267);
            label5.Name = "label5";
            label5.Size = new Size(129, 30);
            label5.TabIndex = 44;
            label5.Text = "Username :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(70, 201);
            label4.Name = "label4";
            label4.Size = new Size(128, 30);
            label4.TabIndex = 43;
            label4.Text = "Full Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 140);
            label2.Name = "label2";
            label2.Size = new Size(95, 30);
            label2.TabIndex = 42;
            label2.Text = "UserID :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(64, 140);
            label1.Name = "label1";
            label1.Size = new Size(0, 30);
            label1.TabIndex = 41;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(347, 88);
            label3.Name = "label3";
            label3.Size = new Size(164, 30);
            label3.TabIndex = 40;
            label3.Text = "Update Profile";
            // 
            // UpdateProfilee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "UpdateProfilee";
            Text = "UpdateProfilee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}