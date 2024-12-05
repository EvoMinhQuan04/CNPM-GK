namespace WinFormsApp1
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lb_sec = new Label();
            label3 = new Label();
            lb_min = new Label();
            pictureBox1 = new PictureBox();
            editQR = new Button();
            timer = new System.Windows.Forms.Timer(components);
            panelSize = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelSize.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(81, 56);
            label1.Name = "label1";
            label1.Size = new Size(415, 57);
            label1.TabIndex = 0;
            label1.Text = "Bắt đầu đếm ngược";
            // 
            // lb_sec
            // 
            lb_sec.AutoSize = true;
            lb_sec.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lb_sec.Location = new Point(579, 68);
            lb_sec.Name = "lb_sec";
            lb_sec.Size = new Size(60, 46);
            lb_sec.TabIndex = 1;
            lb_sec.Text = "00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(559, 66);
            label3.Name = "label3";
            label3.Size = new Size(27, 46);
            label3.TabIndex = 2;
            label3.Text = ":";
            // 
            // lb_min
            // 
            lb_min.AutoSize = true;
            lb_min.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lb_min.Location = new Point(502, 68);
            lb_min.Name = "lb_min";
            lb_min.Size = new Size(60, 46);
            lb_min.TabIndex = 3;
            lb_min.Text = "00";
            lb_min.Click += lb_min_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(81, 201);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(653, 735);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // editQR
            // 
            editQR.BackColor = SystemColors.ActiveBorder;
            editQR.Location = new Point(81, 140);
            editQR.Margin = new Padding(3, 4, 3, 4);
            editQR.Name = "editQR";
            editQR.Size = new Size(86, 31);
            editQR.TabIndex = 5;
            editQR.Text = "Hủy QR";
            editQR.UseVisualStyleBackColor = false;
            editQR.Click += editQR_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick_1;
            // 
            // panelSize
            // 
            panelSize.Controls.Add(label1);
            panelSize.Controls.Add(editQR);
            panelSize.Controls.Add(lb_min);
            panelSize.Controls.Add(pictureBox1);
            panelSize.Controls.Add(lb_sec);
            panelSize.Controls.Add(label3);
            panelSize.Location = new Point(202, 16);
            panelSize.Margin = new Padding(3, 4, 3, 4);
            panelSize.Name = "panelSize";
            panelSize.Size = new Size(808, 956);
            panelSize.TabIndex = 6;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 988);
            Controls.Add(panelSize);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QRCode";
            FormClosed += Form2_FormClosed;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelSize.ResumeLayout(false);
            panelSize.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lb_sec;
        private Label label3;
        private Label lb_min;
        private PictureBox pictureBox1;
        private Button editQR;
        private System.Windows.Forms.Timer timer;
        private Panel panelSize;
    }
}