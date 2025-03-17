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

                        excelData = result.Tables[0]; // Lưu dữ liệu vào biến
                        this.filePath = filePath; // Lưu đường dẫn file
                        MessageBox.Show("Dữ liệu đã được nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Lưu dữ liệu trở lại file Excel
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
