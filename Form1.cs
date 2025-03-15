using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
        //btn Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm dgl2 = new AddForm();
            dgl2.ShowDialog();
        }

        // thêm từ
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadExcelData(openFileDialog.FileName);
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

            FixWordForm fixWordForm = new FixWordForm(excelData, filePath);
            fixWordForm.ShowDialog();
        }

        //nút để xóa
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveForm removeForm = new RemoveForm();
            removeForm.ShowDialog();
        }
        //nút copy từ hiện tại
        [STAThread] // Cần thiết cho Clipboard hoạt động đúng
        private void btnCopy_Click(object sender, EventArgs e)
        {
            string textToCopy = lbWord.Text.Trim(); // Loại bỏ khoảng trắng thừa nếu có

            if (!string.IsNullOrEmpty(textToCopy)) // Kiểm tra nếu lbWord có nội dung
            {
                Clipboard.SetText(textToCopy);
                MessageBox.Show($"Đã sao chép '{textToCopy}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có nội dung để sao chép!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Dictionary<string, (string ipa, string meaning)> savedWord = new Dictionary<string, (string, string)>();
        public Dictionary<string, (string ipa, string meaning)> SavedWord
        {
            get { return savedWord; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string word = lbWord.Text.Trim().ToLower();
            string ipa = lbIPA.Text.Trim();
            string mean = lbMeaning.Text;
            if(!string.IsNullOrEmpty(word) && !savedWord.ContainsKey(word))
            {
                savedWord[word] = (ipa, mean); 
                MessageBox.Show($"Đã lưu từ: {word}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (savedWord.ContainsKey(word))
            {
                MessageBox.Show("Từ này đã được lưu trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Không có từ để lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMyWord_Click(object sender, EventArgs e)
        {
            MyWordForm myWordForm = new MyWordForm(this);//gọi phần form1
            myWordForm.ShowDialog();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            if (savedWord.Count == 0)
            {
                MessageBox.Show("Bạn chưa lưu từ nào để chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                GameForm gameForm = new GameForm(this);
                gameForm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
