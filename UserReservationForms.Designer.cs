namespace Flight_Reservation_System
{
    public partial class BookTicketsForm : Form
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
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(364, 24);
            label7.Name = "label7";
            label7.Size = new Size(247, 30);
            label7.TabIndex = 32;
            label7.Text = "User Reservation Form";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 110);
            label1.Name = "label1";
            label1.Size = new Size(141, 30);
            label1.TabIndex = 33;
            label1.Text = "PassengerID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 179);
            label2.Name = "label2";
            label2.Size = new Size(95, 30);
            label2.TabIndex = 34;
            label2.Text = "FlightID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 374);
            label4.Name = "label4";
            label4.Size = new Size(81, 30);
            label4.TabIndex = 36;
            label4.Text = "SeatID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(252, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(352, 31);
            textBox1.TabIndex = 37;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(252, 178);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(352, 31);
            textBox2.TabIndex = 38;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(252, 373);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(352, 31);
            textBox4.TabIndex = 40;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(347, 419);
            button1.Name = "button1";
            button1.Size = new Size(112, 47);
            button1.TabIndex = 43;
            button1.Text = "Book";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnBook_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(699, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(698, 225);
            dataGridView1.TabIndex = 44;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(699, 419);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(698, 225);
            dataGridView2.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 242);
            label5.Name = "label5";
            label5.Size = new Size(65, 30);
            label5.TabIndex = 46;
            label5.Text = "Class";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(252, 239);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(352, 33);
            comboBox1.TabIndex = 47;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 311);
            label3.Name = "label3";
            label3.Size = new Size(113, 30);
            label3.TabIndex = 48;
            label3.Text = "Total Fare";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(252, 312);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(352, 31);
            textBox3.TabIndex = 49;
            // 
            // BookTicketsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 781);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label7);
            Name = "BookTicketsForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label5;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox3;
    }
}