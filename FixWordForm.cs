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
    public partial class FixWordForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);
        public FixWordForm()
        {
            InitializeComponent();
            label1.Paint += Label_Paint;
        }
        // design lại form
        private void Label_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;

            int borderRadius = 30;
            Color fillColor = Color.LightGray;

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, lbl.Width - 1, lbl.Height - 1);
                int radius = borderRadius * 2;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Xóa nền mặc định khi chạy
                if (DesignMode == false)
                {
                    lbl.BackColor = Color.Transparent; // Ẩn màu nền góc vuông
                }
                // Tô màu nền bên trong
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        //design lại btn
        private void ApplyRoundedButton(Button btn, int radius)
        {
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, radius, radius));
        }

        private void FixWordForm_Load(object sender, EventArgs e)
        {
            ApplyRoundedButton(btnDone, 30);
        }
    }
}
