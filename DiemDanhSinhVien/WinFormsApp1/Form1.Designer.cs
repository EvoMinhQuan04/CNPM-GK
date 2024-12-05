namespace WinFormsApp1
{
    partial class Form1
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
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            txtRadius = new TextBox();
            label4 = new Label();
            txt_time = new TextBox();
            btnCreate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(172, 85);
            label1.Name = "label1";
            label1.Size = new Size(297, 31);
            label1.TabIndex = 0;
            label1.Text = "Nhập thông tin tạo mã QR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(82, 153);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Thời gian hiện tại:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(280, 149);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(248, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(82, 200);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 3;
            label3.Text = "Nhập bán kính(m):";
            // 
            // txtRadius
            // 
            txtRadius.Location = new Point(280, 196);
            txtRadius.Name = "txtRadius";
            txtRadius.Size = new Size(248, 23);
            txtRadius.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(82, 247);
            label4.Name = "label4";
            label4.Size = new Size(192, 20);
            label4.TabIndex = 5;
            label4.Text = "Nhập thời gian hợp lệ(giây)";
            // 
            // txt_time
            // 
            txt_time.Location = new Point(280, 245);
            txt_time.Name = "txt_time";
            txt_time.Size = new Size(248, 23);
            txt_time.TabIndex = 6;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.ForestGreen;
            btnCreate.Location = new Point(204, 313);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(216, 63);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Xác nhận tạo QRCode";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 485);
            Controls.Add(btnCreate);
            Controls.Add(txt_time);
            Controls.Add(label4);
            Controls.Add(txtRadius);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin mã QRCode";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label4;
        private TextBox txt_time;
        private Button btnCreate;
        public TextBox txtRadius;
    }
}