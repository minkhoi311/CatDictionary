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
                string selectedWord = listBox1.SelectedItem.ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa từ vựng này khỏi danh sách?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    listBox1.Items.Remove(selectedWord);
                    RemoveWordFromData(selectedWord);
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

        private void RemoveWordFromData(string w)
        {
            if (excelData == null || excelData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu Excel để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow rowToDelete = excelData.AsEnumerable()
                .FirstOrDefault(row => row[0].ToString() == w);
            if (rowToDelete != null)
            {
                excelData.Rows.Remove(rowToDelete);
                SaveToExcel();
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                lbTuXoa.Text = listBox1.SelectedItem.ToString();
            }
        }
        private void loadData()
        {
            if (excelData == null || excelData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBox1.Items.Clear(); // Xóa dữ liệu cũ trước khi load mới

            foreach (DataRow row in excelData.Rows)
            {
                listBox1.Items.Add(row[0].ToString()); // Hiển thị cột đầu tiên (từ vựng) lên ListBox
            }
        }
        private void RemoveForm_Load(object sender, EventArgs e)
        {
            ApplyButtonDesign(new Button[] { btnXoa }, 30);
            loadData();
        }
    }
}
