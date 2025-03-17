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
        public RemoveForm(DataTable data, String path)
        {
            InitializeComponent();
            this.excelData = data;
            this.filePath = path;

            listView1.View = View.Details;
            listView1.GridLines = true;

            int totalWidth = listView1.ClientSize.Width;
            listView1.Columns.Add("Word", (int)(totalWidth * 0.2));
            listView1.Columns.Add("IPA", (int)(totalWidth * 0.2), HorizontalAlignment.Center);
            listView1.Columns.Add("Meaning", (int)(totalWidth * 0.6));

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa từ vựng này khỏi danh sách?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        listView1.Items.Remove(item);
                    }

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
            if (listView1.SelectedItems.Count > 0)
            {
                lbTuXoa.Text = String.Join(", ", 
                    listView1.SelectedItems.Cast<ListViewItem>().Select(item => item.Text));
            }
        }
        private void loadDataToList()
        {
            listView1.Items.Clear();

            ListViewItem item = null;
            foreach(var row in excelData.AsEnumerable())
            {
                if (row[0].ToString() != "Word")
                {
                    item = new ListViewItem(row[0].ToString());
                    item.SubItems.Add(row[1].ToString());
                    item.SubItems.Add(row[2].ToString());
                    listView1.Items.Add(item);
                }
                
            }
        }
        private void RemoveForm_Load(object sender, EventArgs e)
        {
            if (excelData == null)
            {
                MessageBox.Show("Vui lòng tải dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else if (excelData.AsEnumerable().Count() == 0) {
                MessageBox.Show("Không có dữ liệu trong Excel!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            loadDataToList();
        }

        private void RemoveForm_Load(object sender, EventArgs e)
        {
            ApplyButtonDesign(new Button[] { btnXoa }, 30);
        }
    }
}
