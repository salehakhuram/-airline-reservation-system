namespace Flight_Reservation_System
{
    partial class BaggageForm : Form
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
            label3 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(369, 18);
            label3.Name = "label3";
            label3.Size = new Size(152, 30);
            label3.TabIndex = 4;
            label3.Text = "Baggage Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 144);
            label1.Name = "label1";
            label1.Size = new Size(88, 30);
            label1.TabIndex = 5;
            label1.Text = "Weight";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(195, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(308, 31);
            textBox1.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(569, 153);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(176, 56);
            button1.TabIndex = 44;
            button1.Text = "Add Baggage";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnAddBaggage_Click;

            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 243);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1012, 225);
            dataGridView1.TabIndex = 45;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 85);
            label5.Name = "label5";
            label5.Size = new Size(158, 30);
            label5.TabIndex = 46;
            label5.Text = "ReservationID";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(195, 85);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(308, 31);
            textBox3.TabIndex = 47;
            // 
            // BaggageForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 552);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "BaggageForm";
            Text = "BaggageForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox textBox3;
    }
}