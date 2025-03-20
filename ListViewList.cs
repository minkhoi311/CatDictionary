using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dictionary
{
    public class ListViewManager
    {
        private ListView listView;

        public ListViewManager(ListView listView)
        {
            this.listView = listView;
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listView.View = View.Details;
            listView.GridLines = true;

            int totalWidth = listView.ClientSize.Width;
            listView.Columns.Add("Word", (int)(totalWidth * 0.2));
            listView.Columns.Add("IPA", (int)(totalWidth * 0.2), HorizontalAlignment.Center);
            listView.Columns.Add("Meaning", (int)(totalWidth * 0.6));
        }

        public void LoadData(DataTable data)
        {
            listView.Items.Clear();
            foreach (var row in data.AsEnumerable().Skip(1)) // Bỏ qua tiêu đề
            {
                var item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                listView.Items.Add(item);
            }
        }

        public void RemoveSelectedItems()
        {
            if (listView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    listView.Items.Remove(item);
                }
            }
        }

        public string GetSelectedItemsText()
        {
            return string.Join(", ", listView.SelectedItems.Cast<ListViewItem>().Select(item => item.Text));
        }
    }
}
