using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class frmMain : Form
    {
        private double adminLatitude; // Biến để lưu tọa độ Admin
        private double adminLongitude;
        private double radius; // Biến để lưu bán kính
        private frmImportExcel? frmImportExcel;
        private Form1? form1;

        private string? excelFilePath; // Đường dẫn file Excel được chọn
        private string? selectedSheetName; // Tên sheet do người dùng chọn

        public frmMain()
        {
            InitializeComponent();
        }

        // Hàm này sẽ nhận bán kính từ Form1 và lưu vào frmMain
        public void SetRadius(double inputRadius)
        {
            radius = inputRadius;
        }

        // Phương thức để thiết lập dữ liệu cho DataGridView1
        public void SetDataGridViewDataForGridView1(DataTable data)
        {
            dataGridView1.DataSource = data;
        }

        // Phương thức để thiết lập dữ liệu cho DataGridView2
        public void SetDataGridViewDataForGridView2(DataTable data)
        {
            dataGridView2.DataSource = data;
        }

        // Hàm này sẽ nhận tọa độ Admin từ Form2 và lưu vào frmMain
        public void SetAdminLocation(double lat, double lon)
        {
            adminLatitude = lat;
            adminLongitude = lon;

        }

        // Hàm để tạo và mở Form1
        private void button3_Click(object sender, EventArgs e)
        {


            form1 = new Form1(this); // Truyền frmMain vào Form1
            form1.Show();

            form1.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmImportExcel == null || frmImportExcel.IsDisposed)
            {
                frmImportExcel = new frmImportExcel(this, "student");
                frmImportExcel.FormClosed += frmImportExcel_FormClosed;
                frmImportExcel.Show();
            }
            else
            {
                frmImportExcel.BringToFront();
            }
        }

        //nút thêm tọa độ sinh viên
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (frmImportExcel == null || frmImportExcel.IsDisposed)
            {
                frmImportExcel = new frmImportExcel(this, "user");

                frmImportExcel.FormClosed += frmImportExcel_FormClosed;

                frmImportExcel.Show();
            }
            else
            {
                frmImportExcel.BringToFront();
            }
        }

        private void frmImportExcel_FormClosed(object? sender, FormClosedEventArgs e)
        {
            frmImportExcel = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //nút sửa
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa có dữ liệu để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Tạo form sửa và truyền dữ liệu từ DataGridView1
            frmEditData editForm = new frmEditData((DataTable)dataGridView1.DataSource);

            // Đăng ký sự kiện FormClosed cho frmEditData
            editForm.FormClosed += new FormClosedEventHandler(EditForm_FormClosed);

            // Hiển thị form sửa
            editForm.Show();

        }

        private void EditForm_FormClosed(object? sender, FormClosedEventArgs e)
        {

            if (sender is frmEditData editForm)
            {
                // Chỉ cập nhật DataGridView nếu người dùng nhấn "Lưu" và có dữ liệu mới
                if (editForm.UpdatedData != null)
                {
                    dataGridView1.DataSource = editForm.UpdatedData;
                    dataGridView3.DataSource = editForm.UpdatedData;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //nút thủ công để lấy vị trí admin
            Form3 form3 = new Form3(this);
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Thêm
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát chương trình?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveDataGridView3ToDatabase();

            DialogResult result = MessageBox.Show(
                "Bạn có muốn lưu dữ liệu đã điểm danh xong về file ban đầu không?",
                "Lưu dữ liệu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Mở hộp thoại chọn file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    excelFilePath = openFileDialog.FileName;
                    MessageBox.Show("Đã chọn file: " + excelFilePath);

                    LoadExcelSheets();
                }
            }
        }


        private void SaveDataGridView3ToDatabase()
        {
            string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DATA;Integrated Security=True";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Xóa dữ liệu cũ trong bảng AttendanceStatus nếu cần
                //SqlCommand deleteCmd = new SqlCommand("DELETE FROM AttendanceStatus", sqlConnection);
                //deleteCmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua hàng trống cuối DataGridView nếu có

                    int stt = Convert.ToInt32(row.Cells["STT"].Value);
                    int studentID = Convert.ToInt32(row.Cells["ID"].Value);
                    string fullName = row.Cells["Họ và tên"].Value?.ToString() ?? "";
                    string className = row.Cells["Lớp"].Value?.ToString() ?? "";
                    string group = row.Cells["Nhóm"].Value?.ToString() ?? "";
                    string status = row.Cells["Trạng thái"].Value?.ToString()?.Trim() ?? "Không có dữ liệu hoặc không tìm thấy vị trí";

                    DateTime attendanceDate;
                    string? studyDateStr = row.Cells["Ngày học"].Value.ToString();


                    if (!DateTime.TryParseExact(studyDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out attendanceDate))
                    {
                        MessageBox.Show($"Ngày học '{studyDateStr}' không đúng định dạng dd/MM/yyyy. Vui lòng kiểm tra lại.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"
                IF EXISTS (SELECT 1 FROM AttendanceStatus WHERE MaSinhVien = @MaSinhVien AND NgayHoc = @NgayHoc)
                    UPDATE AttendanceStatus 
                    SET STT = @STT, HoVaTen = @HoVaTen, Lop = @Lop, Nhom = @Nhom, TrangThai = @TrangThai 
                    WHERE MaSinhVien = @MaSinhVien AND NgayHoc = @NgayHoc
                ELSE
                    INSERT INTO AttendanceStatus (STT, MaSinhVien, HoVaTen, Lop, Nhom, NgayHoc, TrangThai) 
                    VALUES (@STT, @MaSinhVien, @HoVaTen, @Lop, @Nhom, @NgayHoc, @TrangThai)";

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@STT", stt);
                        cmd.Parameters.AddWithValue("@MaSinhVien", studentID);
                        cmd.Parameters.AddWithValue("@HoVaTen", fullName);
                        cmd.Parameters.AddWithValue("@Lop", className);
                        cmd.Parameters.AddWithValue("@Nhom", group);
                        cmd.Parameters.AddWithValue("@NgayHoc", attendanceDate);
                        cmd.Parameters.AddWithValue("@TrangThai", status);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được lưu vào hệ thống thành công!", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadExcelSheets()
        {
            if (string.IsNullOrEmpty(excelFilePath)) return;

            try
            {
                using (var workbook = new XLWorkbook(excelFilePath))
                {
                    var sheets = workbook.Worksheets; // Lấy tất cả các sheet

                    if (sheets.Any())
                    {
                        // Hiển thị danh sách sheet để người dùng chọn
                        ComboBox comboBox = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Width = 482
                        };

                        foreach (var sheet in sheets)
                        {
                            comboBox.Items.Add(sheet.Name); // Thêm tên sheet vào combobox
                        }

                        if (comboBox.Items.Count > 0)
                        {
                            comboBox.SelectedIndex = 0; // Chọn sheet đầu tiên mặc định
                        }

                        Form sheetForm = new Form
                        {
                            Text = "Chọn Sheet để Lưu Dữ Liệu",
                            StartPosition = FormStartPosition.CenterScreen,
                            Width = 500,
                            Height = 150
                        };

                        Button confirmButton = new Button
                        {
                            Text = "Xác nhận",
                            Dock = DockStyle.Bottom
                        };

                        confirmButton.Click += (s, ev) =>
                        {
                            selectedSheetName = comboBox.SelectedItem?.ToString() ?? string.Empty; // Lấy tên sheet từ combobox
                            sheetForm.Close();
                            SaveDataToExcel(); // Gọi hàm lưu dữ liệu sau khi chọn sheet
                        };

                        sheetForm.Controls.Add(comboBox);
                        sheetForm.Controls.Add(confirmButton);
                        sheetForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sheet nào trong file Excel.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sheet: " + ex.Message);
            }
        }

        private void SaveDataToExcel()
        {
            if (string.IsNullOrEmpty(excelFilePath) || string.IsNullOrEmpty(selectedSheetName))
            {
                MessageBox.Show("Vui lòng chọn file Excel và sheet trước khi lưu.");
                return;
            }
            try
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    using (var workbook = new XLWorkbook(excelFilePath))
                    {
                        // Lấy sheet được chọn
                        var worksheet = workbook.Worksheet(selectedSheetName);

                        // Lấy hàng đầu tiên (tiêu đề) để xác định vị trí cột ID và các cột khác
                        var firstRow = worksheet.FirstRowUsed();

#nullable disable
                        var headers = firstRow.Cells().Select(c => c.Value.ToString()).ToList();
#nullable restore

                        int idColumnIndex = headers.IndexOf("ID") + 1;
                        if (idColumnIndex == 0)
                        {

                            MessageBox.Show("Không tìm thấy cột ID trong sheet.");
                            return;
                        }


                        if (!headers.Contains("Trạng thái"))
                        {

                            worksheet.Cell(1, headers.Count + 1).Value = "Trạng thái";
                            headers.Add("Trạng thái");
                        }

                        // Lưu toàn bộ các thay đổi từ DataGridView3 vào file Excel
                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {
                            var row = dataGridView3.Rows[i];
                            if (!row.IsNewRow)
                            {
                                string studentId = row.Cells["ID"].Value?.ToString() ?? string.Empty;
                                if (string.IsNullOrEmpty(studentId))
                                {
                                    MessageBox.Show("Dòng có ID rỗng, bỏ qua.");
                                    continue;
                                }

                                var excelRow = worksheet.RowsUsed().FirstOrDefault(r => r.Cell(idColumnIndex).GetValue<string>() == studentId);

                                if (excelRow != null)
                                {
                                    for (int j = 0; j < row.Cells.Count; j++)
                                    {
                                        if (dataGridView3.Columns[j].Name != "ID")
                                        {
                                            string columnName = dataGridView3.Columns[j].HeaderText;
                                            int excelColIndex = headers.IndexOf(columnName) + 1;

                                            // Kiểm tra nếu không tìm thấy cột
                                            if (excelColIndex > 0)
                                            {
                                                excelRow.Cell(excelColIndex).Value = row.Cells[j].Value?.ToString() ?? string.Empty;
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Không tìm thấy cột: {columnName}");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Không tìm thấy sinh viên với ID: {studentId}");
                                }
                            }
                        }

                        workbook.Save();
                        MessageBox.Show("Lưu dữ liệu thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để lưu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}\nChi tiết: {ex.StackTrace}");
            }
        }




        private void button9_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ DataGridView1 (sinh viên) và DataGridView2 (tọa độ user)
            DataTable studentData = (DataTable)dataGridView1.DataSource;
            DataTable userData = (DataTable)dataGridView2.DataSource;

            if (studentData == null || userData == null)
            {
                MessageBox.Show("Vui lòng nhập cả dữ liệu sinh viên và dữ liệu tọa độ của sinh viên.");
                return;
            }


            if (adminLatitude == 0 || adminLongitude == 0)
            {
                MessageBox.Show("Tọa độ trung tâm chưa được thiết lập, vui lòng ấn nút phía dưới góc trái để lấy!");
                return;
            }


            if (radius <= 0)
            {
                MessageBox.Show("Vui lòng nhập bán kính hợp lệ.");
                return;
            }


            if (!studentData.Columns.Contains("Trạng thái"))
            {
                studentData.Columns.Add("Trạng thái");
            }


            foreach (DataRow studentRow in studentData.Rows)
            {
                string? studentId = studentRow["ID"].ToString();
                DataRow[] matchingUser = userData.Select($"ID = '{studentId}'");

                if (matchingUser.Length > 0)
                {
                    string? geoCode = matchingUser[0]["GeoCode"].ToString();
                    if (!string.IsNullOrEmpty(geoCode))
                    {
                        var (userLat, userLon) = ParseCoordinates(geoCode);

                        double distance = CalculateDistance(adminLatitude, adminLongitude, userLat, userLon);

                        // Cập nhật trạng thái điểm danh
                        studentRow["Trạng thái"] = distance > radius ? "Vắng mặt" : "Có mặt";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tọa độ.");
                    }
                }
                else
                {
                    studentRow["Trạng thái"] = "Không có dữ liệu hoặc không tìm thấy vị trí";
                }
            }

            dataGridView3.DataSource = studentData;


            if (dataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Xử lí điểm danh và thông tin thất bại!");
                return;
            }

            int tongSoSinhVien = 0;
            int tongCoMat = 0;
            int tongVangMat = 0;
            int tongFail = 0;
            string ngayHoc = "";

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongSoSinhVien++;

                    string trangThai = row.Cells["Trạng thái"].Value?.ToString() ?? "";

                    if (trangThai == "Có mặt")
                    {
                        tongCoMat++;
                    }
                    else if (trangThai == "Vắng mặt")
                    {
                        tongVangMat++;
                    }
                    else
                    {
                        tongFail++;
                    }

                    string ngayHocHienTai = row.Cells["Ngày học"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(ngayHocHienTai))
                    {
                        ngayHoc = ngayHocHienTai;
                    }
                }
            }


            txtTongso.Text = tongSoSinhVien.ToString();
            txtNgay.Text = ngayHoc;
            txtComat.Text = tongCoMat.ToString();
            txtVang.Text = tongVangMat.ToString();
            txtFail.Text = tongFail.ToString();
        }


        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371000;
            double latRad1 = DegreesToRadians(lat1);
            double latRad2 = DegreesToRadians(lat2);
            double deltaLat = DegreesToRadians(lat2 - lat1);
            double deltaLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(latRad1) * Math.Cos(latRad2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // Khoảng cách tính bằng mét
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        // Hàm tách tọa độ từ GeoCode
        public (double Latitude, double Longitude) ParseCoordinates(string geoCode)
        {
            string[] coordinates = geoCode.Split(',');
            if (coordinates.Length == 2)
            {
                double latitude = double.Parse(coordinates[0]);
                double longitude = double.Parse(coordinates[1]);
                return (latitude, longitude);
            }
            throw new Exception("GeoCode định dạng sai!.");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            DataTable? dataToFilter = null;

            if (dataGridView3.DataSource is DataTable table3 && table3.Columns.Contains("Trạng thái") && table3.Rows.Count > 0)
            {
                dataToFilter = table3;
            }

            else if (dataGridView1.DataSource is DataTable table1 && table1.Columns.Contains("Trạng thái") && table1.Rows.Count > 0)
            {
                dataToFilter = table1;
            }

            if (dataToFilter != null)
            {
                frmFilterData filterForm = new frmFilterData(dataToFilter);
                filterForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu điểm danh hợp lệ để lọc. Vui lòng kiểm tra lại!");
            }


        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // Tạo Form chọn ngày
            using (Form dateForm = new Form())
            {
                dateForm.Text = "Chọn ngày xuất dữ liệu";
                dateForm.Size = new Size(300, 200);
                dateForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                dateForm.StartPosition = FormStartPosition.CenterScreen;

                Label label = new Label
                {
                    Text = "Vui lòng chọn ngày muốn xuất:",
                    Location = new Point(20, 20),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };

                DateTimePicker datePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dd/MM/yyyy",
                    Location = new Point(20, 50),
                    Width = 250,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };

                Button confirmButton = new Button
                {
                    Text = "Xác nhận",
                    Location = new Point(100, 90),
                    Size = new Size(80, 40),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    DialogResult = DialogResult.OK
                };

                dateForm.Controls.Add(label);
                dateForm.Controls.Add(datePicker);
                dateForm.Controls.Add(confirmButton);
                dateForm.AcceptButton = confirmButton;

                if (dateForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = datePicker.Value.Date; // Lấy ngày được chọn

                    string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DATA;Integrated Security=True";
                    string query = @"
            SELECT
                STT AS [STT],
                MaSinhVien AS [ID], 
                HoVaTen AS [Họ và Tên], 
                Lop AS [Lớp], 
                Nhom AS [Nhóm], 
                FORMAT(NgayHoc, 'dd/MM/yyyy') AS [Ngày Học], 
                TrangThai AS [Trạng Thái] 
            FROM AttendanceStatus
            WHERE NgayHoc = @SelectedDate"; // Điều kiện lọc ngày

                    DataTable dt = new DataTable();

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                            sqlConnection.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }

                    // Kiểm tra nếu không có dữ liệu cho ngày được chọn
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu cho ngày đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Dừng lại nếu không có dữ liệu
                    }

                    // Hộp thoại lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Lưu dữ liệu",
                        FileName = $"Dữ liệu điểm danh_{selectedDate:ddMMyyyy}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("AttendanceStatus");
                            worksheet.Cell(1, 1).InsertTable(dt);  // Chèn DataTable vào Excel

                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Dữ liệu đã được xuất ra file Excel thành công!", "Xuất File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
