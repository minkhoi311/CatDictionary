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
        private Form1 mainForm;
        private string currentWord;
        private Random random = new Random();
        public GameForm(Form1 form1)
        {
            InitializeComponent();
            this.mainForm = form1;
            LoadNewWord();
        }

        private void LoadNewWord()
        {
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
            {
                lbAnnouce.ForeColor = Color.Red;
                lbAnnouce.Text = "Sai rồi! Vui lòng đoán lại";
                txtAns.Text = "";
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
    }
}
