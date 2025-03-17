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
    public partial class RemoveForm : BaseForm
    {
        public RemoveForm()
        {
            InitializeComponent();
        }
        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedItem != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa từ vựng này khỏi danh sách?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    MessageBox.Show("Xóa từ vựng thành công!", "Thông báo!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbTuXoa.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Không có từ vựng để xóa!", "Thông báo!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                lbTuXoa.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void RemoveForm_Load(object sender, EventArgs e)
        {
        }
    }
}
