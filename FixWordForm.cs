using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class FixWordForm : BaseForm
    {
        public FixWordForm()
        {
            InitializeComponent();
        }
        private void FixWordForm_Load(object sender, EventArgs e)
        {
            ApplyButtonDesign(new Button[] { btnDone }, 30);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {

        }

    }
}
