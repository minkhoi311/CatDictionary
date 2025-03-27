using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class MainFrm : BaseForm
    {
        bool isClosing = false;
        public MainFrm()
        {
            Loading f = new Loading();
            f.ShowDialog();
            InitializeComponent();
        }

        private void Init()
        {
            lbEX1.Text = lbEX2.Text = lbEX3.Text = lbIPA.Text = lbMeaning.Text = lbWord.Text = "";
        }

        // xử lý form load 
        private void Form1_Load_1(object sender, EventArgs e)
        {
            btnCopy.Image = ResizeImage(Properties.Resources.copy, btnCopy.Width - 15, btnCopy.Height - 15);
            Init();
        }

        //Chức năng Thêm từ 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng chọn file trước khi thêm từ vựng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddForm dgl2 = new AddForm(excelData, filePath);
            DialogResult result = dgl2.ShowDialog();
        }

        // import file
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadExcelData(openFileDialog.FileName))
                {
                    MessageBox.Show("Dữ liệu đã được nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        // Chức năng tìm kiếm
        private void TimKiem()
        {
            if (excelData == null || excelData.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lbWord.Text = "";
                //lbWord.Focus();
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
                lbWord.Text = "";
                lbIPA.Text = "";
                lbMeaning.Text = "";
                lbEX1.Text = "";
                lbEX2.Text = "";
                lbEX3.Text = "";
            }
            txtSearch.Focus();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                TimKiem();
            }
            return base.ProcessDialogKey(keyData);
        }

        // Chức năng sửa từ 
        private void btnFix_Click(object sender, EventArgs e)
        {
            if (excelData == null)
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FixWordForm fixWordForm = new FixWordForm(excelData, filePath);
            fixWordForm.ShowDialog();
        }

        // Chức năng xóa từ 
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (excelData == null)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu từ file Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RemoveForm removeForm = new RemoveForm(excelData, filePath);
            removeForm.ShowDialog();
        }


        // Chức năng copy từ 
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
                MessageBox.Show("Không có nội dung để sao chép!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng thêm từ vào list myWords
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
            if (!string.IsNullOrEmpty(word) && !savedWord.ContainsKey(word))
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
                MessageBox.Show("Không có từ để lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMyWord_Click(object sender, EventArgs e)
        {
            MyWordForm myWordForm = new MyWordForm(this);//gọi phần form1
            myWordForm.ShowDialog();
        }


        // Chức năng chơi game ôn bài 
        private void btnGame_Click(object sender, EventArgs e)
        {
            if (savedWord.Count == 0)
            {
                MessageBox.Show("Bạn chưa lưu từ nào để chơi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                GameForm gameForm = new GameForm(this);
                gameForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Xử lý đóng form mờ dần 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = true;
                    timer1.Start();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity != 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                timer1.Stop();
                isClosing = true;
                this.Close();
            }
        }
    }
}
