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
    public partial class Form1 : System.Windows.Forms.Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);

        public Form1()
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
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ApplyRoundedButton(btnImport, 30);
            ApplyRoundedButton(btnAdd, 30);
            ApplyRoundedButton(btnRemove, 30);
            ApplyRoundedButton(btnFix, 30);
            ApplyRoundedButton(btnMyWord, 30);
            ApplyRoundedButton(btnGame, 30);
            ApplyRoundedButton(btnCopy, 20);
            ApplyRoundedButton(btnShare, 20);
            ApplyRoundedButton(btnSave, 20);
            ApplyRoundedButton(btnFB, 20);

            btnCopy.Image = ResizeImage(Properties.Resources.copy,
                            btnCopy.Width - 15, btnCopy.Height -15);
            btnShare.Image = ResizeImage(Properties.Resources.share,
                            btnCopy.Width - 15, btnCopy.Height - 15);
            btnFB.Image = ResizeImage(Properties.Resources.facebook,
                            btnCopy.Width - 10, btnCopy.Height - 10);
        }
        //design lại search
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resized;
        }
    }
}
