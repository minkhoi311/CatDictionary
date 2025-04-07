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
        protected DataTable excelData;
        protected string filePath;


        // Chỉnh kích thước ảnh
        protected Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))  // sau khi ra khỏi using đối tượng g được hủy tự động 
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // tính toán lại màu sắc của từng điểm ảnh(nội suy), kh bể hình 
                g.DrawImage(img, 0, 0, width, height);
            }
            return resized;
        }

        // Import data từ file Excel vào dataTable 
        public bool LoadExcelData(string filePath) // import data
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))  // using tự động đóng file sau khi làm việc 
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  // tạo một trình đọc file Excel 
                {
                    //ExcelDataSetConfiguration config = new ExcelDataSetConfiguration()
                    //{
                    //    ConfigureDataTable = (tableReader) =>
                    //    {
                    //        return new ExcelDataTableConfiguration()
                    //        {
                    //            UseHeaderRow = true
                    //        };
                    //    }
                    //};
                    //DataSet result = reader.AsDataSet(config);
                    //excelData = result.Tables[0];

                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }  // bỏ dùng dòng đầu tiên 
                    });

                    excelData = result.Tables[0]; // Lưu dữ liệu vào biến
                    this.filePath = filePath; // Lưu đường dẫn file
                }
            }
            return true;
        }


        // Lưu trữ dữ liệu xuống file Excel từ dataTable 
        public bool SaveToExcel()
        {
            if (!File.Exists(filePath)) // lỗi file kh tồn tại 
            {
                MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Bắt lỗi không mở được file 
            try
            {
                // Kiểm tra xem file có đang được mở không
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }
            }
            catch (IOException) // Nếu bắt lỗi là file đang mở
            {
                MessageBox.Show("File Excel đang mở! Vui lòng đóng file trước khi lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // lưu file thành công 
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;  // sử dụng EPPlus ghi dữ liệu vào Excel ban phi thuong mai voi Hoc tap
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {

                //while (package.Workbook.Worksheets.Count > 0)
                //{
                //    package.Workbook.Worksheets.Delete(0); // Xóa từng sheet từ index 0
                //}

                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Sheet lưu data từ excelData");
                worksheet.Cells.Clear(); // Thay vì xóa sheet, chỉ xóa dữ liệu

                for (int i = 0; i < excelData.Rows.Count; i++)
                {
                    for (int j = 0; j < excelData.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 1, j + 1].Value = excelData.Rows[i][j].ToString();
                    }
                }

                package.Save();
            }
            return true;

        }
    }
}
