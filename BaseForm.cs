using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExcelDataReader;
using OfficeOpenXml;

namespace Dictionary
{
    public class BaseForm : Form
    {
        //bo tròn nút
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        protected static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);
        protected void ApplyRoundedButton(Button btn, int radius)
        {
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, radius, radius));
        }
        protected void ApplyButtonDesign(Button[] buttons, int radius)
        {
            foreach (var btn in buttons)
            {
                ApplyRoundedButton(btn, radius);
            }
        }

        // hợp thức hóa ảnh
        protected Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resized;
        }

        //// design lại label
        public void Label_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;

            int borderRadius = 30;
            Color fillColor = Color.LightGray;

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, lbl.Width - 1, lbl.Height - 1);
                int radius = borderRadius * 2;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Xóa nền mặc định khi chạy
                if (DesignMode == false)
                {
                    lbl.BackColor = Color.Transparent; // Ẩn màu nền góc vuông
                }
                // Tô màu nền bên trong
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
        /// import excel
        protected DataTable excelData;
        protected string filePath;
        public void LoadExcelData(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = false }
                        });

                        excelData = result.Tables[0];
                        this.filePath = filePath;

                        MessageBox.Show("Dữ liệu đã được nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // lưu excel
        public void SaveToExcel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Sheet1");

                    for (int i = 0; i < excelData.Rows.Count; i++)
                    {
                        for (int j = 0; j < excelData.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 1, j + 1].Value = excelData.Rows[i][j].ToString();
                        }
                    }

                    package.Save();
                    MessageBox.Show("Đã lưu dữ liệu vào file: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
