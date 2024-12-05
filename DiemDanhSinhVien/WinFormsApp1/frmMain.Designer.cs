namespace WinFormsApp1
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dataGridView1 = new DataGridView();
            button8 = new Button();
            button10 = new Button();
            txtNgay = new TextBox();
            txtTongso = new TextBox();
            txtComat = new TextBox();
            txtVang = new TextBox();
            dataGridView2 = new DataGridView();
            button7 = new Button();
            dataGridView3 = new DataGridView();
            button9 = new Button();
            groupBox1 = new GroupBox();
            groupBox5 = new GroupBox();
            txtFail = new TextBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            button4 = new Button();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            splitContainer1 = new SplitContainer();
            groupBox6 = new GroupBox();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Times New Roman", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 1);
            label1.Name = "label1";
            label1.Size = new Size(1752, 77);
            label1.TabIndex = 0;
            label1.Text = "PHẦN MỀM HỖ TRỢ ĐIỂM DANH SINH VIÊN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Beige;
            button1.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(3, 19);
            button1.Name = "button1";
            button1.Size = new Size(88, 89);
            button1.TabIndex = 0;
            button1.Text = "Nhập dữ liệu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(3, 31);
            button2.Name = "button2";
            button2.Size = new Size(145, 71);
            button2.TabIndex = 6;
            button2.Text = "Lấy vị trí admin";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Beige;
            button3.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(93, 19);
            button3.Name = "button3";
            button3.Size = new Size(78, 91);
            button3.TabIndex = 1;
            button3.Text = "Tạo QR";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Beige;
            button5.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(329, 19);
            button5.Name = "button5";
            button5.Size = new Size(77, 91);
            button5.TabIndex = 3;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Info;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(255, 33);
            label2.Name = "label2";
            label2.Size = new Size(1302, 65);
            label2.TabIndex = 8;
            label2.Text = "GROUP 6 ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 53);
            label5.Name = "label5";
            label5.Size = new Size(77, 25);
            label5.TabIndex = 11;
            label5.Text = "Ngày : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(250, 55);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 12;
            label6.Text = "Tổng số : ";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(443, 56);
            label7.Name = "label7";
            label7.Size = new Size(136, 25);
            label7.TabIndex = 13;
            label7.Text = "Hiện có mặt : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(664, 57);
            label8.Name = "label8";
            label8.Size = new Size(69, 25);
            label8.TabIndex = 14;
            label8.Text = "Vắng :";
            label8.Click += label8_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(613, 316);
            dataGridView1.TabIndex = 18;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button8
            // 
            button8.BackColor = Color.MistyRose;
            button8.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(1651, 31);
            button8.Name = "button8";
            button8.Size = new Size(90, 67);
            button8.TabIndex = 8;
            button8.Text = "Thoát";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.RosyBrown;
            button10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.Location = new Point(1558, 32);
            button10.Name = "button10";
            button10.Size = new Size(90, 67);
            button10.TabIndex = 7;
            button10.Text = "Lưu";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // txtNgay
            // 
            txtNgay.Location = new Point(90, 51);
            txtNgay.Name = "txtNgay";
            txtNgay.ReadOnly = true;
            txtNgay.Size = new Size(131, 30);
            txtNgay.TabIndex = 24;
            // 
            // txtTongso
            // 
            txtTongso.Location = new Point(351, 52);
            txtTongso.Name = "txtTongso";
            txtTongso.ReadOnly = true;
            txtTongso.Size = new Size(39, 30);
            txtTongso.TabIndex = 25;
            txtTongso.TextChanged += textBox2_TextChanged;
            // 
            // txtComat
            // 
            txtComat.Location = new Point(579, 53);
            txtComat.Name = "txtComat";
            txtComat.ReadOnly = true;
            txtComat.Size = new Size(52, 30);
            txtComat.TabIndex = 26;
            txtComat.TextChanged += textBox3_TextChanged;
            // 
            // txtVang
            // 
            txtVang.Location = new Point(735, 53);
            txtVang.Name = "txtVang";
            txtVang.ReadOnly = true;
            txtVang.Size = new Size(52, 30);
            txtVang.TabIndex = 27;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ControlLight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 27);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(613, 312);
            dataGridView2.TabIndex = 28;
            // 
            // button7
            // 
            button7.BackColor = Color.Beige;
            button7.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button7.Location = new Point(170, 19);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(159, 91);
            button7.TabIndex = 2;
            button7.Text = "Nhập dữ liệu vị trí ";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click_1;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.BackgroundColor = SystemColors.ControlLight;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Bottom;
            dataGridView3.Location = new Point(3, 171);
            dataGridView3.Margin = new Padding(3, 4, 3, 4);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(1115, 648);
            dataGridView3.TabIndex = 30;
            // 
            // button9
            // 
            button9.BackColor = Color.Beige;
            button9.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button9.Location = new Point(406, 19);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(107, 91);
            button9.TabIndex = 4;
            button9.Text = "Điểm danh";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonShadow;
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(dataGridView3);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1121, 823);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dữ liệu điểm danh:";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.LightGray;
            groupBox5.Controls.Add(txtFail);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(txtNgay);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(txtTongso);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(txtVang);
            groupBox5.Controls.Add(txtComat);
            groupBox5.Controls.Add(label8);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Font = new Font("Segoe UI", 10F);
            groupBox5.Location = new Point(3, 27);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(1115, 135);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Thông tin buổi học:";
            groupBox5.Enter += groupBox5_Enter;
            // 
            // txtFail
            // 
            txtFail.Location = new Point(986, 53);
            txtFail.Margin = new Padding(3, 4, 3, 4);
            txtFail.Name = "txtFail";
            txtFail.ReadOnly = true;
            txtFail.Size = new Size(36, 30);
            txtFail.TabIndex = 29;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 13F);
            label9.Location = new Point(825, 57);
            label9.Name = "label9";
            label9.Size = new Size(169, 25);
            label9.TabIndex = 28;
            label9.Text = "Không có dữ liệu:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(button7);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button5);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Segoe UI", 11F);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(626, 115);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Info;
            button4.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button4.Location = new Point(513, 19);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(103, 92);
            button4.TabIndex = 5;
            button4.Text = "Lọc dữ liệu";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.Location = new Point(3, 116);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(619, 347);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dữ liệu sinh viên:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dataGridView2);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.Location = new Point(0, 471);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(619, 343);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Dữ liệu vị trí sinh viên:";
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.WhiteSmoke;
            splitContainer1.Location = new Point(0, 83);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlDark;
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox4);
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.MistyRose;
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1752, 823);
            splitContainer1.SplitterDistance = 626;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 9;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.Silver;
            groupBox6.Controls.Add(button6);
            groupBox6.Controls.Add(button2);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(button10);
            groupBox6.Controls.Add(button8);
            groupBox6.Location = new Point(3, 909);
            groupBox6.Margin = new Padding(3, 4, 3, 4);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 4, 3, 4);
            groupBox6.Size = new Size(1749, 124);
            groupBox6.TabIndex = 10;
            groupBox6.TabStop = false;
            // 
            // button6
            // 
            button6.BackColor = Color.DarkGray;
            button6.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button6.Location = new Point(155, 33);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(93, 65);
            button6.TabIndex = 9;
            button6.Text = "Xuất file";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click_1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1924, 1055);
            Controls.Add(groupBox6);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DataGridView dataGridView1;
        private Button button8;
        private Button button10;
        private TextBox txtNgay;
        private TextBox txtTongso;
        private TextBox txtComat;
        private TextBox txtVang;
        private DataGridView dataGridView2;
        private Button button7;
        private DataGridView dataGridView3;
        private Button button9;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label9;
        private TextBox txtFail;
        private SplitContainer splitContainer1;
        private GroupBox groupBox6;
        private Button button4;
        private Button button6;
    }
}
