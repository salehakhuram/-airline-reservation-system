﻿namespace Flight_Reservation_System
{
    partial class Route
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
            label7 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 65);
            label1.Name = "label1";
            label1.Size = new Size(96, 30);
            label1.TabIndex = 23;
            label1.Text = "RouteID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(55, 131);
            label2.Name = "label2";
            label2.Size = new Size(177, 30);
            label2.TabIndex = 24;
            label2.Text = "OriginAirportID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(55, 202);
            label3.Name = "label3";
            label3.Size = new Size(222, 30);
            label3.TabIndex = 25;
            label3.Text = "DestinationAiportID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(55, 272);
            label4.Name = "label4";
            label4.Size = new Size(102, 30);
            label4.TabIndex = 26;
            label4.Text = "Distance";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(294, 19);
            label7.Name = "label7";
            label7.Size = new Size(134, 30);
            label7.TabIndex = 27;
            label7.Text = "Route Table";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(283, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 31);
            textBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(283, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(296, 31);
            textBox2.TabIndex = 29;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(283, 203);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(296, 31);
            textBox3.TabIndex = 30;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(283, 273);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(296, 31);
            textBox4.TabIndex = 31;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(617, 58);
            button1.Name = "button1";
            button1.Size = new Size(112, 44);
            button1.TabIndex = 32;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnInsert_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GrayText;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(617, 132);
            button2.Name = "button2";
            button2.Size = new Size(112, 42);
            button2.TabIndex = 33;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnDelete_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GrayText;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(617, 203);
            button3.Name = "button3";
            button3.Size = new Size(112, 41);
            button3.TabIndex = 34;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnUpdate_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GrayText;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(617, 273);
            button4.Name = "button4";
            button4.Size = new Size(112, 41);
            button4.TabIndex = 35;
            button4.Text = "ViewAll";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnViewAll_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(69, 365);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(660, 225);
            dataGridView1.TabIndex = 36;
            // 
            // Route
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 652);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Route";
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
        private Label label7;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
    }
}