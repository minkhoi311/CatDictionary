using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;
using ClosedXML.Excel;

namespace Dictionary
{
    public partial class Form1 : BaseForm
    {
        private string filePath;
        public Form1()
        {
            InitializeComponent();
            label1.Paint += Label_Paint;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ApplyButtonDesign(new Button[] { btnImport, btnAdd, btnRemove, btnFix, btnMyWord, btnGame }, 30);
            ApplyButtonDesign(new Button[] { btnCopy, btnSave }, 20);
            btnCopy.Image = ResizeImage(Properties.Resources.copy, btnCopy.Width - 15, btnCopy.Height - 15);
        }
<<<<<<< HEAD
        private void btnFix_Click(object sender, EventArgs e)
        {
            FixWordForm fixWordForm = new FixWordForm();
            fixWordForm.ShowDialog();
=======
        //btn Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm dgl2 = new AddForm();
            dgl2.ShowDialog();
>>>>>>> KhoiLee
        }
        private DataTable excelData;
        private string importedFilePath;
        //getter và setter
        public DataTable GetExcelData()
        {
<<<<<<< HEAD
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                LoadExcelData(filePath);
                MessageBox.Show("Đã nhập dữ liệu từ: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        
=======
            return excelData;
        }
        public void SetExcelData(DataTable data)
        {
            excelData = data;
        }

        public string GetImportedFilePath()
        {
            return importedFilePath;
        }

        // thêm từ
>>>>>>> KhoiLee
        private void LoadExcelData(string filePath)
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
                        if (excelData.Rows.Count == 0)
                        {
                            MessageBox.Show("File Excel không có dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu đã được nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importedFilePath = openFileDialog.FileName;
                LoadExcelData(importedFilePath);
                MessageBox.Show("Đã nhập dữ liệu từ: " + importedFilePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // logo tìm kiếm
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (excelData == null || excelData.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchWord = txtSearch.Text.Trim().ToLower();
            var row = excelData.AsEnumerable().FirstOrDefault(r => r[0].ToString().Trim().ToLower() == searchWord);

            if (row != null)
            {
                lbWord.Text = row[0].ToString();
                lbIPA.Text = row[1].ToString();
                lbMeaning.Text = row[2].ToString();
                lbEX1.Text = row[3].ToString();
                lbEX2.Text = row[4].ToString();
                lbEX3.Text = row[5].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // sửa từ lại
        private void btnFix_Click(object sender, EventArgs e)
        {
            if (excelData == null)
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FixWordForm fixWordForm = new FixWordForm(GetExcelData(), GetImportedFilePath());
            fixWordForm.ShowDialog();
            SetExcelData(fixWordForm.GetUpdatedData());
        }

        //nút để xóa
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveForm removeForm = new RemoveForm();
            removeForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng chọn file trước khi thêm từ vựng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem file có tồn tại không
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddForm dgl2 = new AddForm();
            DialogResult result = dgl2.ShowDialog();



            if (result == DialogResult.OK)
            {

                string word = dgl2.WordValue;
                string ipa = dgl2.IpaValue;
                string mean = dgl2.MeanValue;
                string ex1 = dgl2.Ex1Value;
                string ex2 = dgl2.Ex2Value;
                string ex3 = dgl2.Ex3Value;

                if (excelData != null) 
                {
                    DataRow newRow = excelData.NewRow();

                    newRow[0] = word;
                    newRow[1] = ipa;
                    newRow[2] = mean;
                    newRow[3] = ex1;
                    newRow[4] = ex2;
                    newRow[5] = ex3;

                    excelData.Rows.Add(newRow);
                    SaveDataToExcel(filePath);
                    
                }
                dgl2.Close();
            }

        }
        private void SaveDataToExcel(string filePath)
        {
            try
            {
                // Sử dụng ClosedXML để lưu lại dữ liệu vào Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    // Ghi dữ liệu vào worksheet
                    for (int i = 0; i < excelData.Rows.Count; i++)
                    {
                        for (int j = 0; j < excelData.Columns.Count; j++)
                        {
                            var cellValue = excelData.Rows[i][j].ToString();
                            worksheet.Cell(i + 1, j + 1).SetValue(cellValue);
                        }
                    }

                    // Lưu workbook vào file
                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
