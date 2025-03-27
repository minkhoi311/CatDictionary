using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class GameForm : BaseForm
    {
        private MainFrm mainForm;
        private string currentWord;
        private Random random = new Random();
        int count = 0;
        public GameForm(MainFrm form1)
        {
            InitializeComponent();
            this.mainForm = form1;
            LoadNewWord();
        }

        private void LoadNewWord()
        {
            count = 0;
            if (mainForm.SavedWord.Count < 3)
            {
                MessageBox.Show("Cần lưu ít nhất 3 từ để chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            // Lấy ngẫu nhiên 1 từ từ danh sách
            int index = random.Next(mainForm.SavedWord.Count);
            var wordPair = mainForm.SavedWord.ElementAt(index);
            currentWord = wordPair.Key;

            // Hiển thị nghĩa của từ
            lbIPA.Text = wordPair.Value.ipa;
            lbMeaning.Text = wordPair.Value.meaning;

            // Xóa nội dung TextBox
            txtAns.Text = "";
            txtAns.Focus();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAns.Text.Trim().ToLower();
            if (userAnswer == currentWord.ToLower())
            {
                lbAnnouce.ForeColor = Color.Green;
                lbAnnouce.Text = "Chính xác! Bạn có muốn tiếp tục?";
                btnConfirm.Visible = false;
                btnContinue.Visible = true;
            }
            else
            {   if (txtAns.Text == "")
                {
                    MessageBox.Show("Bạn vui lòng nhập đáp án", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }           
                count++;
                lbAnnouce.ForeColor = Color.Red;
                lbAnnouce.Text = "Sai rồi! Bạn còn " + (3-count).ToString() + " lượt!";
                txtAns.Text = "";
                if (count == 3)
                {
                    lbAnnouce.Text = "Sai rồi! Đáp án là: " + currentWord;
                    lbMeaning.Text = lbIPA.Text = "";
                    btnContinue.Visible = true;
                }
            }
            
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            lbAnnouce.Text = "";
            btnConfirm.Visible = true;
            btnContinue.Visible = false;
            LoadNewWord();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string lbForm = lbWord.Text;
            lbForm = lbForm.Substring(1) + lbForm[0];
            lbWord.Text = lbForm;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
