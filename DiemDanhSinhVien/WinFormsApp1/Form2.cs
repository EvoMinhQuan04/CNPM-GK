using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.IO;
using QRCoder;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private frmMain mainForm;
        //public double adminLatitude { get; private set; }
        //public double adminLongitude { get; private set; }
        private Image qrCodeImage;
        private int timeLeft;
        private string googleFormUrl;
        private string expiredFormUrl = "https://forms.gle/AmVh2zpsnSSGZ7LG9"; // URL Form thông báo hết hạn


        public Form2(frmMain mainForm, Image qrImage, int countdownTime, string formUrl)
        {
            this.mainForm = mainForm;
            qrCodeImage = qrImage;
            timeLeft = countdownTime;
            googleFormUrl = formUrl;
            InitializeComponent();

            // Đăng ký sự kiện Resize
            this.Resize += new EventHandler(Form2_Resize);

        }

        private void Form2_Resize(object? sender, EventArgs e)
        {
            CenterPanel();
        }

        private void CenterPanel()
        {
            // Tính toán vị trí mới để giữ panelSize ở giữa form
            int x = (this.ClientSize.Width - panelSize.Width) / 2;
            int y = (this.ClientSize.Height - panelSize.Height) / 2;
            panelSize.Location = new Point(x, y);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Hiển thị mã QR
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = qrCodeImage;

            // Bắt đầu đếm thời gian
            timer.Start();


            // Đăng ký sự kiện đóng form
            this.FormClosed += Form2_FormClosed;
        }


        private void timer_Tick_1(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                lb_min.Text = (timeLeft / 60).ToString();  // Phút
                lb_sec.Text = (timeLeft % 60).ToString();  // Giây
                timeLeft--;  // Giảm thời gian
            }
            else
            {
                timer.Stop();

                // Mở Form thông báo hết hạn
                UpdateQRCode(expiredFormUrl);

                // Hiển thị thông báo không chặn luồng
                Task.Run(() =>
                {
                    MessageBox.Show("Hết thời gian!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });


                //đợi 3s
                Task.Delay(4000).Wait();


                DialogResult result = MessageBox.Show(
                    "Vui lòng tải dữ liệu tọa độ vị trí sinh viên tại đây về máy tính dưới dạng tệp excel!",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var psi = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "https://docs.google.com/spreadsheets/d/1M1Pl5e35FX2QXbhYUJ3veBRbrLSotGBDOi7KrOYscIE/edit?resourcekey=&gid=1700244266#gid=1700244266",
                            UseShellExecute = true // Quan trọng để đảm bảo hệ thống mở URL với trình duyệt mặc định
                        };
                        System.Diagnostics.Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mở liên kết: " + ex.Message);
                    }

                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn đã hủy tải file.", "Hủy bỏ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.Close();
            }
        }

        private void UpdateQRCode(string url)
        {
            // Tạo mã QR mới từ URL
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrData);
                qrCodeImage = qrCode.GetGraphic(20); // Tạo mã QR mới
                pictureBox1.Image = qrCodeImage; // Hiển thị mã QR mới trên PictureBox
            }
        }

        private void editQR_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form2 và quay lại Form1 để chỉnh sửa QR code
        }

        private void Form2_FormClosed(object? sender, FormClosedEventArgs e)
        {

            mainForm.Show();
            mainForm.BringToFront();
        }

        private void lb_min_Click(object sender, EventArgs e)
        {

        }
    }
}
