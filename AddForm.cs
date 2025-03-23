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

namespace Dictionary
{
    public partial class AddForm : BaseForm
    {
        public AddForm(ref DataTable data, string path)
        {
            InitializeComponent();
            this.excelData = data;
            this.filePath = path;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWord.Text) || string.IsNullOrWhiteSpace(txtDefinition.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin từ vựng và nghĩa!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc muốn thêm từ vựng này vào danh sách?",
        "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(confirmResult == DialogResult.OK)
            {
                // Gán giá trị từ input
                string word = txtWord.Text.Trim();
                string ipa = txtIPA.Text.Trim();
                string mean = txtDefinition.Text.Trim();
                string ex1 = txtEx1.Text.Trim();
                string ex2 = txtEx2.Text.Trim();
                string ex3 = txtEx3.Text.Trim();

                // Kiểm tra nếu dữ liệu Excel tồn tại
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
                    SaveToExcel();

                    MessageBox.Show("Thêm từ vựng thành công!", "Thông báo!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi: Dữ liệu Excel không khả dụng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }
    }
}

