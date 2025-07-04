namespace Flight_Reservation_System
{
    partial class Seat
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
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(298, 21);
            label7.Name = "label7";
            label7.Size = new Size(119, 30);
            label7.TabIndex = 30;
            label7.Text = "Seat Table";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 63);
            label1.Name = "label1";
            label1.Size = new Size(81, 30);
            label1.TabIndex = 31;
            label1.Text = "SeatID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 128);
            label2.Name = "label2";
            label2.Size = new Size(95, 30);
            label2.TabIndex = 32;
            label2.Text = "FlightID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 196);
            label3.Name = "label3";
            label3.Size = new Size(149, 30);
            label3.TabIndex = 33;
            label3.Text = "Seat Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(37, 262);
            label4.Name = "label4";
            label4.Size = new Size(65, 30);
            label4.TabIndex = 34;
            label4.Text = "Class";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(37, 321);
            label5.Name = "label5";
            label5.Size = new Size(187, 30);
            label5.TabIndex = 35;
            label5.Text = "AvailablityStatus";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(230, 62);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 31);
            textBox1.TabIndex = 36;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(230, 129);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(306, 31);
            textBox2.TabIndex = 37;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(230, 197);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(306, 31);
            textBox3.TabIndex = 38;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(230, 263);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(306, 31);
            textBox4.TabIndex = 39;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(230, 322);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(306, 31);
            textBox5.TabIndex = 40;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(590, 53);
            button1.Name = "button1";
            button1.Size = new Size(112, 47);
            button1.TabIndex = 41;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnInsert_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GrayText;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(590, 151);
            button2.Name = "button2";
            button2.Size = new Size(112, 42);
            button2.TabIndex = 42;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnDelete_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GrayText;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(590, 234);
            button3.Name = "button3";
            button3.Size = new Size(112, 41);
            button3.TabIndex = 43;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnUpdate_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GrayText;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(590, 316);
            button4.Name = "button4";
            button4.Size = new Size(112, 41);
            button4.TabIndex = 44;
            button4.Text = "ViewAll";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnViewAll_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 391);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(978, 225);
            dataGridView1.TabIndex = 45;
            // 
            // Seat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 628);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label7);
            Name = "Seat";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
    }
}