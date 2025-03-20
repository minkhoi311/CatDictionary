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
    public partial class ListView : UserControl
    {
        public ListView(DataTable data, String path)
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;

            int totalWidth = listView1.ClientSize.Width;
            listView1.Columns.Add("Word", (int)(totalWidth * 0.2));
            listView1.Columns.Add("IPA", (int)(totalWidth * 0.2), HorizontalAlignment.Center);
            listView1.Columns.Add("Meaning", (int)(totalWidth * 0.6));
        }
    }
}
