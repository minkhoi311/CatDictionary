using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Dictionary
{
    public partial class RemoveForm : BaseForm
    {
        private ListViewManager listViewManager;
        public RemoveForm(ref DataTable data, string path)
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
                    DataRow row = null;
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        row = excelData.AsEnumerable().FirstOrDefault(r => r[0].ToString().Trim().ToLower() == item.Text);
                        excelData.Rows.Remove(row); // xoa dc o file
                        //excelData.Rows.RemoveAt(item.Index + 1);
                    }
                    bool result = SaveToExcel();
                    if (result)
                    {
                        MessageBox.Show("Lưu thành công vào file Excel", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listViewManager.RemoveSelectedItems(); // xóa trong list
                        lbTuXoa.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công vào file Excel", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
