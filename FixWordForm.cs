using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Dictionary
{
    public partial class FixWordForm : BaseForm
    {
        private DataTable excelData;
        private string filePath;

        public FixWordForm(DataTable data, string importedFilePath)
        {
            InitializeComponent();
            excelData = data;
            filePath = importedFilePath;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOldWord.Text) || string.IsNullOrWhiteSpace(txtNewWord.Text))
                {
                    MessageBox.Show("Vui lòng nhập từ cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string oldWord = txtOldWord.Text.Trim().ToLower();
                string newWord = txtNewWord.Text.Trim();

                var row = excelData.AsEnumerable().FirstOrDefault(r => r[0].ToString().Trim().ToLower() == oldWord);

                if (row != null)
                {
                    row[0] = newWord;
                    MessageBox.Show("Sửa từ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveToExcel(filePath);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy từ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa từ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Thêm dòng này để tránh lỗi
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

        public DataTable GetUpdatedData()
        {
            return excelData;
        }
    }
}
