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
        private ListViewManager listViewManager;
        public RemoveForm(DataTable data, string path)
        {
            InitializeComponent();
            this.excelData = data;
            this.filePath = path;

            listViewManager = new ListViewManager(listView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa từ vựng này khỏi danh sách?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    listViewManager.RemoveSelectedItems();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTuXoa.Text = listViewManager.GetSelectedItemsText();
        }
        private void RemoveForm_Load(object sender, EventArgs e)
        {
            if (excelData == null || excelData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            listViewManager.LoadData(excelData);
        }
    }
}
