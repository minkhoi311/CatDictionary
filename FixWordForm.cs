using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dictionary
{
    public partial class FixWordForm : BaseForm
    {
        private ListViewManager listViewManager;
        public FixWordForm(DataTable data, string importedFilePath)
        {
            InitializeComponent();
            excelData = data;
            filePath = importedFilePath;
            listViewManager = new ListViewManager(listView1); // Quản lý ListView
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
                    SaveToExcel();
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

        private void btnDS_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            btnDS.Visible = false;
            btnAn.Visible = true;
            listViewManager.LoadData(excelData);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            btnDS.Visible = true;
            btnAn.Visible = false;
        }
    }
}
