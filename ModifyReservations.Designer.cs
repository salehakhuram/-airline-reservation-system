namespace Flight_Reservation_System
{
    partial class ModifyReservations : Form
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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            button3 = new Button();
            button1 = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(341, 28);
            label7.Name = "label7";
            label7.Size = new Size(225, 30);
            label7.TabIndex = 30;
            label7.Text = "Modify Reservations";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 82);
            label1.Name = "label1";
            label1.Size = new Size(158, 30);
            label1.TabIndex = 31;
            label1.Text = "ReservationID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(256, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(379, 31);
            textBox1.TabIndex = 32;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(262, 158);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(373, 33);
            comboBox1.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 158);
            label2.Name = "label2";
            label2.Size = new Size(65, 30);
            label2.TabIndex = 34;
            label2.Text = "Class";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 231);
            label3.Name = "label3";
            label3.Size = new Size(58, 30);
            label3.TabIndex = 35;
            label3.Text = "Seat";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(262, 245);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(373, 33);
            comboBox2.TabIndex = 36;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GrayText;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(686, 83);
            button3.Name = "button3";
            button3.Size = new Size(112, 41);
            button3.TabIndex = 43;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnUpdate_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(686, 186);
            button1.Name = "button1";
            button1.Size = new Size(146, 92);
            button1.TabIndex = 44;
            button1.Text = "Cancel Reservation";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnCancelRes_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(36, 308);
            label4.Name = "label4";
            label4.Size = new Size(77, 30);
            label4.TabIndex = 45;
            label4.Text = "Status";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(262, 320);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(373, 31);
            textBox2.TabIndex = 46;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(36, 398);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1051, 225);
            dataGridView2.TabIndex = 48;
            // 
            // ModifyReservations
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1595, 913);
            Controls.Add(dataGridView2);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label7);
            Name = "ModifyReservations";
            Text = "ModifyReservations";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private Button button3;
        private Button button1;
        private Label label4;
        private TextBox textBox2;
        private DataGridView dataGridView2;
    }
}