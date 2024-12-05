namespace WinFormsApp1
{
    partial class frmEditData
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
            dataGridViewEdit = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEdit).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewEdit
            // 
            dataGridViewEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEdit.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewEdit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEdit.GridColor = SystemColors.Menu;
            dataGridViewEdit.Location = new Point(14, 164);
            dataGridViewEdit.Margin = new Padding(3, 4, 3, 4);
            dataGridViewEdit.Name = "dataGridViewEdit";
            dataGridViewEdit.RowHeadersWidth = 51;
            dataGridViewEdit.Size = new Size(1071, 404);
            dataGridViewEdit.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(863, 576);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(104, 75);
            button1.TabIndex = 1;
            button1.Text = "Lưu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(974, 576);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(111, 75);
            button2.TabIndex = 2;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(351, 97);
            label1.Name = "label1";
            label1.Size = new Size(398, 29);
            label1.TabIndex = 3;
            label1.Text = "Chỉnh sửa trực tiếp các cột hoặc hàng!";
            // 
            // frmEditData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1098, 667);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewEdit);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmEditData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa dữ liệu";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEdit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewEdit;
        private Button button1;
        private Button button2;
        private Label label1;
    }
}