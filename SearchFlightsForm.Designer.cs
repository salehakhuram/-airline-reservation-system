﻿namespace Flight_Reservation_System
{
    partial class SearchFlightsForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(308, 22);
            label7.Name = "label7";
            label7.Size = new Size(216, 30);
            label7.TabIndex = 31;
            label7.Text = "Search Flights Form";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 162);
            label1.Name = "label1";
            label1.Size = new Size(132, 30);
            label1.TabIndex = 32;
            label1.Text = "Destination";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 97);
            label2.Name = "label2";
            label2.Size = new Size(83, 30);
            label2.TabIndex = 33;
            label2.Text = "Source";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(236, 98);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(294, 31);
            textBox1.TabIndex = 34;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(236, 163);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(294, 31);
            textBox2.TabIndex = 35;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(599, 113);
            button1.Name = "button1";
            button1.Size = new Size(112, 47);
            button1.TabIndex = 42;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1109, 225);
            dataGridView1.TabIndex = 43;
            // 
            // SearchFlightsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label7);
            Name = "SearchFlightsForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private DataGridView dataGridView1;
    }
}