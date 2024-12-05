namespace WinFormsApp1
{
    partial class Form3
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
            button1 = new Button();
            txtData = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(101, 417);
            label1.Name = "label1";
            label1.Size = new Size(328, 20);
            label1.TabIndex = 0;
            label1.Text = "Vui lòng dán tọa độ được trả về từ trang web:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(331, 451);
            button1.Name = "button1";
            button1.Size = new Size(78, 40);
            button1.TabIndex = 1;
            button1.Text = "Dán";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtData
            // 
            txtData.Location = new Point(97, 461);
            txtData.Name = "txtData";
            txtData.Size = new Size(228, 23);
            txtData.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.huongdan;
            pictureBox1.Location = new Point(97, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(425, 286);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(190, 29);
            label2.Name = "label2";
            label2.Size = new Size(255, 20);
            label2.TabIndex = 4;
            label2.Text = "Hướng dẫn lấy tọa độ từ trang web";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(101, 363);
            label3.Name = "label3";
            label3.Size = new Size(201, 20);
            label3.TabIndex = 5;
            label3.Text = "Tiến hành lấy vị trí ở đây ->";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 255, 192);
            button2.Location = new Point(321, 354);
            button2.Name = "button2";
            button2.Size = new Size(86, 43);
            button2.TabIndex = 6;
            button2.Text = "Lấy";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.Location = new Point(437, 451);
            button3.Name = "button3";
            button3.Size = new Size(85, 40);
            button3.TabIndex = 7;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 532);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(txtData);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vị trí Admin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox txtData;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Button button2;
        private Button button3;
    }
}