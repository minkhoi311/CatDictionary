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

namespace Dictionary
{
    public partial class Form1 : BaseForm
    {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm dgl2 = new AddForm();
            dgl2.ShowDialog();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            FixWordForm fixWordForm = new FixWordForm();
            fixWordForm.ShowDialog();
        }
        private DataTable excelData;
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                LoadExcelData(filePath);
                MessageBox.Show("Đã nhập dữ liệu từ: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
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
    }
}
