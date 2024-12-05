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
    public partial class frmFilterData : Form
    {
        private DataTable originalData;
        public frmFilterData(DataTable data)
        {
            InitializeComponent();
            originalData = data;
            dataGridViewFilter.ReadOnly = true;  
            BindDataToDataGridView(originalData); 
        }

        private void BindDataToDataGridView(DataTable data)
        {
            dataGridViewFilter.DataSource = data;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                FilterDataByStatus("Có mặt");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                FilterDataByStatus("Vắng mặt");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                FilterDataByStatus("Không có dữ liệu hoặc không tìm thấy vị trí");
            }
        }

        // Hàm để lọc dữ liệu theo trạng thái
        private void FilterDataByStatus(string status)
        {
            if (originalData != null)
            {
                DataView dv = new DataView(originalData);
                dv.RowFilter = $"[Trạng thái] = '{status}'";
                dataGridViewFilter.DataSource = dv.ToTable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
