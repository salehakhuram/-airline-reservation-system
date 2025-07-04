namespace Flight_Reservation_System
{
    partial class Airline
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
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 79);
            label1.Name = "label1";
            label1.Size = new Size(103, 30);
            label1.TabIndex = 0;
            label1.Text = "AirlineID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(74, 141);
            label2.Name = "label2";
            label2.Size = new Size(141, 30);
            label2.TabIndex = 1;
            label2.Text = "AirlineName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 193);
            label3.Name = "label3";
            label3.Size = new Size(97, 30);
            label3.TabIndex = 2;
            label3.Text = "Country";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(74, 253);
            label4.Name = "label4";
            label4.Size = new Size(150, 30);
            label4.TabIndex = 3;
            label4.Text = "Contact Num";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(80, 311);
            label5.Name = "label5";
            label5.Size = new Size(97, 30);
            label5.TabIndex = 4;
            label5.Text = "Website";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(260, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 31);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(260, 140);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(277, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(260, 192);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(277, 31);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(260, 252);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(277, 31);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(260, 311);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(277, 31);
            textBox5.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(625, 50);
            button1.Name = "button1";
            button1.Size = new Size(112, 47);
            button1.TabIndex = 37;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnInsert_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GrayText;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(625, 141);
            button2.Name = "button2";
            button2.Size = new Size(112, 42);
            button2.TabIndex = 38;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnDelete_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GrayText;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(625, 228);
            button3.Name = "button3";
            button3.Size = new Size(112, 41);
            button3.TabIndex = 39;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnUpdate_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GrayText;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(625, 305);
            button4.Name = "button4";
            button4.Size = new Size(112, 41);
            button4.TabIndex = 40;
            button4.Text = "ViewAll";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnViewAll_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(57, 404);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(828, 344);
            dataGridView1.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(320, 18);
            label7.Name = "label7";
            label7.Size = new Size(141, 30);
            label7.TabIndex = 42;
            label7.Text = "Airline Table";
            // 
            // Airline
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 782);
            Controls.Add(label7);
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
            Name = "Airline";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Label label7;
    }
}