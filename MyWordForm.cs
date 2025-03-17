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
    public partial class MyWordForm : BaseForm
    {
        private Form1 mainForm;
        public MyWordForm(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
            LoadSavedWords();
        }
        private void LoadSavedWords()
        {
            listView1.Items.Clear();
            foreach (var word in mainForm.SavedWord) // Gọi Getter
            {
                ListViewItem item = new ListViewItem(new[] { word.Key, word.Value.ipa, word.Value.meaning });
                listView1.Items.Add(item);
            }
        }

    }
}
