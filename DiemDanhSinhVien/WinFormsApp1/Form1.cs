using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int tm;
        private frmMain _mainForm;

        public Form1(frmMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            // Đăng ký sự kiện FormClosed để hiển thị lại frmMain
            this.FormClosed += Form1_FormClosed;
        }

        // Hàm tạo mã QR
        public Bitmap GenerateQrCode(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
            return qrCodeImage;
        }

        // Hàm gửi yêu cầu HTTP để xóa dữ liệu trong Google Sheet
        public async Task ClearGoogleSheetData()
        {
            // URL của Google Apps Script Web App để xóa dữ liệu
            string webAppUrl = "https://script.google.com/macros/s/AKfycbxExP8RgeLU-wQOrYHdZSYUPZC0Z6SS6G7AAsDxEFgkgQRviMjr4zwhJnmAdR7_V4HZ/exec?clear=true";  

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(webAppUrl);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Dữ liệu trong Google Sheet đã được xóa thành công.");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu trong Google Sheet.");
                }
            }
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRadius.Text) || !double.TryParse(txtRadius.Text, out double radius))
            {
                MessageBox.Show("Vui lòng nhập bán kính hợp lệ.");
                return;
            }

            if (!int.TryParse(txt_time.Text, out tm))
            {
                MessageBox.Show("Vui lòng nhập thời gian hợp lệ.");
                return;
            }

            await ClearGoogleSheetData();

            _mainForm.SetRadius(radius);

            string url = "https://forms.gle/uFKjv4nmAxSibxPo7";
            Bitmap qrImage = GenerateQrCode(url);

            string uniqueData = radius + "_" + DateTime.Now.ToString() + "_" + Guid.NewGuid().ToString();

            this.Hide();
            Form2 frm = new Form2(_mainForm, qrImage, tm, url);
            frm.Show();
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {                    
            _mainForm.Show();
            _mainForm.BringToFront();
        }
    }
}
