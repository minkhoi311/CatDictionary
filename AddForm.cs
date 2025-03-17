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
            ApplyButtonDesign(new Button[] { btnDone }, 30);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Bạn có chắc muốn thêm từ vựng này vào danh sách?", "Xác nhận",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    WordValue = txtWord.Text;
                    IpaValue = txtIPA.Text;
                    MeanValue = txtDefinition.Text;
                    Ex1Value = txtEx1.Text;
                    Ex2Value = txtEx2.Text;
                    Ex3Value = txtEx3.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    MessageBox.Show("Thêm từ vựng thành công!", "Thông báo!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
        }

    }
}
