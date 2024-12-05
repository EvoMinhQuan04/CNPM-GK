using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private frmMain mainForm;
        public Form3(frmMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nội dung trong clipboard không
            if (Clipboard.ContainsText())
            {
                // Lấy nội dung văn bản từ clipboard
                string clipboardText = Clipboard.GetText();

                

                // Tách giá trị vĩ độ và kinh độ
                ParseCoordinatesAndSendToMain(clipboardText);
            }
            else
            {
                MessageBox.Show("Không có nội dung nào trong clipboard!");
            }
        }

        private void ParseCoordinatesAndSendToMain(string clipboardText)
        {
            try
            {
                // Loại bỏ thẻ <br> và dấu xuống dòng
                clipboardText = clipboardText.Replace("<br>", "\n").Replace("\r", "").Trim();

                // Tách các dòng của văn bản
                var lines = clipboardText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length >= 2)
                {
                    // Lấy giá trị vĩ độ và kinh độ từ chuỗi đã tách
                    string latitudeText = lines[0].Replace("Vĩ độ: ", "").Trim();
                    string longitudeText = lines[1].Replace("Kinh độ: ", "").Trim();

                    // Chuyển đổi thành số thực
                    if (double.TryParse(latitudeText, out double latitude) && double.TryParse(longitudeText, out double longitude))
                    {

                        txtData.Text = $"{latitude}, {longitude}";

                        // Truyền giá trị vĩ độ và kinh độ về frmMain
                        mainForm.SetAdminLocation(latitude, longitude);

                        // Hiển thị thông báo thành công
                        MessageBox.Show($"Đã thiết lập tọa độ trung tâm thành công chi tiết: Vĩ độ {latitude}, Kinh độ {longitude}");
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu tọa độ không hợp lệ!");
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu clipboard không đúng định dạng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý tọa độ: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tiến hành mở trang web
            OpenWebPage();
        }

        //hàm mở trang web
        private void OpenWebPage()
        {
            try
            {
                // Lấy đường dẫn tới thư mục chạy file .exe của ứng dụng (bin/Debug hoặc bin/Release)
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Đường dẫn đến file geolocation.html (từ thư mục gốc dự án)
                //string filePath = Path.Combine(projectDirectory, "geolocation.html");
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "geolocation.html");

                // Kiểm tra nếu file tồn tại
                if (File.Exists(filePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true // Đảm bảo mở bằng trình duyệt mặc định
                    });
                }
                else
                {
                    MessageBox.Show("File HTML không tồn tại: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở trang web: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
