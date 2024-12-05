using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class frmImportExcel : Form
    {
        private OleDbConnection? conn;
        private frmMain mainForm;
        private string fileType;
        //private static readonly string[] requiredColumnsForStudent = { "ID", "Họ và tên", "Lớp", "Nhóm", "Ngày học" };
        //private static readonly string[] requiredColumnsForUser = { "Timestamp", "Name", "ID", "GeoStamp", "GeoCode", "GeoAddress" };

        public frmImportExcel(frmMain frm, string fileType)
        {
            InitializeComponent();
            this.mainForm = frm;
            this.fileType = fileType;
            this.FormClosing += frmImportExcel_FormClosing;
        }

        // Hàm mở file Excel và nạp các sheet vào ComboBox
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath);
                string connString = "";

                if (extension == ".xls")
                {
                    connString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                }
                else if (extension == ".xlsx")
                {
                    connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                }
                else
                {
                    MessageBox.Show("Định dạng file không được hỗ trợ.");
                    return;
                }

                try
                {
                    conn = new OleDbConnection(connString);
                    conn.Open();

                    DataTable? dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dtSheet == null || dtSheet.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sheet nào trong file Excel.");
                        conn.Close();
                        return;
                    }

                    comboBox1.Items.Clear();

                    foreach (DataRow row in dtSheet.Rows)
                    {
                        string? sheetName = row["TABLE_NAME"]?.ToString();
                        if (!string.IsNullOrEmpty(sheetName))
                        {
                            comboBox1.Items.Add(sheetName.Replace("'", ""));
                        }
                    }

                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Không có sheet nào trong file Excel.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

        // Khi chọn sheet từ ComboBox, nạp dữ liệu từ sheet đó và lưu vào database
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn == null || conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối đến file Excel.");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sheet hợp lệ.");
                return;
            }

            string sheetName = comboBox1.SelectedItem?.ToString() ?? string.Empty;
            if (!sheetName.EndsWith("$"))
            {
                sheetName += "$";
            }

            try
            {
                string query = $"SELECT * FROM [{sheetName}]";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Kiểm tra và yêu cầu cột cần thiết
                if (!ValidateColumns(dt))
                {
                    MessageBox.Show("File Excel thiếu các cột cần thiết. Vui lòng sử dụng file mẫu.", "Thiếu cột", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Hiển thị file mẫu dựa vào loại file
                    if (fileType == "student")
                    {
                        OpenSampleFile(); // Mở file mẫu cho dữ liệu sinh viên
                    }
                    else if (fileType == "user")
                    {
                        OpenSampleFileLocation(); // Mở file mẫu cho dữ liệu tọa độ
                    }

                    return;
                }

                dataGridView1.DataSource = dt;

                SaveDataToDatabase(dt);

                MessageBox.Show("Dữ liệu đã được lưu vào hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        // Hàm để lưu dữ liệu vào database
        private void SaveDataToDatabase(DataTable dataTable)
        {
            string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DATA;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                if (fileType == "student")
                {
                    // Xóa toàn bộ dữ liệu cũ trong bảng Students
                    //SqlCommand deleteCmd = new SqlCommand("DELETE FROM Students", sqlConnection);
                    //deleteCmd.ExecuteNonQuery();


                    foreach (DataRow row in dataTable.Rows)
                    {
                        //kiểm tra tồn tại thì cập nhật, chưa thì thêm.
                        string query = @"
                        IF EXISTS (SELECT 1 FROM Students WHERE ID = @ID)
                            UPDATE Students
                            SET STT = @STT, FullName = @FullName, Class = @Class, Groups = @Groups, StudyDate = @StudyDate, Status = @Status
                            WHERE ID = @ID
                        ELSE
                            INSERT INTO Students (STT, ID, FullName, Class, Groups, StudyDate, Status)
                            VALUES (@STT, @ID, @FullName, @Class, @Groups, @StudyDate, @Status)";

                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        cmd.Parameters.AddWithValue("@STT", row["STT"]);
                        cmd.Parameters.AddWithValue("@ID", row["ID"]);
                        cmd.Parameters.AddWithValue("@FullName", row["Họ và tên"]);
                        cmd.Parameters.AddWithValue("@Class", row["Lớp"]);
                        cmd.Parameters.AddWithValue("@Groups", row["Nhóm"]);

                        // Xử lý cột ngày học (StudyDate)
                        string? studyDateStr = row["Ngày học"].ToString();
                        if (DateTime.TryParseExact(studyDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime studyDate))
                        {
                            cmd.Parameters.AddWithValue("@StudyDate", studyDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@StudyDate", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@Status", row["Trạng thái"]);

                        cmd.ExecuteNonQuery();
                    }
                }
                else if (fileType == "user")
                {
                    // Xóa toàn bộ dữ liệu cũ trong bảng Locations
                    //SqlCommand deleteCmd = new SqlCommand("DELETE FROM Locations", sqlConnection);
                    //deleteCmd.ExecuteNonQuery();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Locations (Timestamp, Name, ID, GeoStamp, GeoCode, GeoAddress) VALUES (@Timestamp, @Name, @ID, @GeoStamp, @GeoCode, @GeoAddress)", sqlConnection);
                        cmd.Parameters.AddWithValue("@Timestamp", row["Timestamp"]);
                        cmd.Parameters.AddWithValue("@Name", row["Name"]);
                        cmd.Parameters.AddWithValue("@ID", row["ID"]);
                        cmd.Parameters.AddWithValue("@GeoStamp", row["GeoStamp"]);
                        cmd.Parameters.AddWithValue("@GeoCode", row["GeoCode"]);
                        cmd.Parameters.AddWithValue("@GeoAddress", row["GeoAddress"]);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Kiểm tra xem file có các cột cần thiết không
        private bool ValidateColumns(DataTable dt)
        {
            string[] requiredColumns;

            if (fileType == "student")
            {
                requiredColumns = new[] { "ID", "Họ và tên", "Lớp", "Nhóm", "Ngày học" };
            }
            else if (fileType == "user")
            {
                requiredColumns = new[] { "Timestamp", "Name", "ID", "GeoStamp", "GeoCode", "GeoAddress" };
            }
            else
            {
                return false;
            }

            foreach (var col in requiredColumns)
            {
                if (!dt.Columns.Contains(col))
                {
                    MessageBox.Show($"Thiếu cột bắt buộc: {col}. Vui lòng kiểm tra lại định dạng file.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }


        // Mở file mẫu sinh viên
        private void OpenSampleFile()
        {
            string sampleFilePath = Path.Combine(Application.StartupPath, "Resources", "Dữ liệu mẫu sinh viên.xlsx");
            if (File.Exists(sampleFilePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = sampleFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("File mẫu không tồn tại. Vui lòng kiểm tra lại.");
            }
        }
        // Mở file mẫu tọa độ
        private void OpenSampleFileLocation()
        {
            string sampleFilePath = Path.Combine(Application.StartupPath, "Resources", "Dữ liệu tọa độ mẫu.xlsx");
            if (File.Exists(sampleFilePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = sampleFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("File mẫu không tồn tại. Vui lòng kiểm tra lại.");
            }
        }

        // Chuyển dữ liệu từ DataGridView về mainForm dựa vào loại file
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable? dt = dataGridView1.DataSource as DataTable;

            if (dt != null)
            {
                // Chỉ kiểm tra khi loại file là "student"
                if (!ValidateColumns(dt))
                {
                    // Nếu xác thực không thành công, dừng việc nhập
                    return;
                }

                // Nhập dữ liệu dựa vào fileType
                if (fileType == "student")
                {
                    mainForm.SetDataGridViewDataForGridView1(dt.Copy());
                }
                else if (fileType == "user")
                {
                    mainForm.SetDataGridViewDataForGridView2(dt.Copy());
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để chuyển.");
            }
        }

        // Đóng kết nối khi form đóng
        private void frmImportExcel_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
