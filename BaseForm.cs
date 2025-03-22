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
        // Chỉnh kích thước ảnh
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

        // Lưu trữ dữ liệu từ file Excel
        protected DataTable excelData;
        protected string filePath;
        public bool LoadExcelData(string filePath) // import data
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = false }
                    });

                    excelData = result.Tables[0]; // Lưu dữ liệu vào biến
                    this.filePath = filePath; // Lưu đường dẫn file
                }
            }
            return true;
        }


        // Lưu dữ liệu trở lại file Excel
        public bool SaveToExcel()
        {
            if (!File.Exists(filePath)) // 
            {
                MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // bat loi kh mo dc file 
            try
            {
                // Kiểm tra xem file có đang bị khóa không
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    fs.Close(); // Đóng file sau khi kiểm tra
                }
            }
            catch (IOException) // Nếu bắt lỗi này, nghĩa là file đang mở
            {
                MessageBox.Show("File Excel đang mở! Vui lòng đóng file trước khi lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // luu thanh cong 
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
            return true;

        }
    }
}
