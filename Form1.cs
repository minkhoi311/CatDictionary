using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
            label1.Paint += Label_Paint;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ApplyButtonDesign(new Button[] { btnImport, btnAdd, btnRemove, btnFix, btnMyWord, btnGame }, 30);
            ApplyButtonDesign(new Button[] { btnCopy, btnSave }, 20);

            btnCopy.Image = ResizeImage(Properties.Resources.copy, btnCopy.Width - 15, btnCopy.Height - 15);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm dgl2 = new AddForm();
            dgl2.ShowDialog();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            FixWordForm fixWordForm = new FixWordForm();
            fixWordForm.ShowDialog();
        }

    }
}
