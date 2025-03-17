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
    public partial class AddForm: BaseForm
    {
        public string WordValue { get;private set; }
        public string IpaValue { get;private set; }
        public string MeanValue { get; private set; }
        public string Ex1Value { get; private set; }
        public string Ex2Value { get; private set; }
        public string Ex3Value { get; private set; }
        public AddForm()
        {
            InitializeComponent();
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

            if (MessageBox.Show("Bạn có chắc muốn thêm từ vựng này vào danh sách?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                WordValue = txtWord.Text.Trim();
                IpaValue = txtIPA.Text.Trim();
                MeanValue = txtDefinition.Text.Trim();
                Ex1Value = txtEx1.Text.Trim();
                Ex2Value = txtEx2.Text.Trim();
                Ex3Value = txtEx3.Text.Trim();

                MessageBox.Show("Thêm từ vựng thành công!", "Thông báo!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
