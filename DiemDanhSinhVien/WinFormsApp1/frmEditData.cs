using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmEditData : Form
    {
        public DataTable? UpdatedData { get; private set; }
        public frmEditData(DataTable datatoEdit)
        {
            InitializeComponent();
            dataGridViewEdit.DataSource = datatoEdit.Copy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatedData = (DataTable)dataGridViewEdit.DataSource;  // Cập nhật dữ liệu
            MessageBox.Show("Thay đổi dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();  // Đóng form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
