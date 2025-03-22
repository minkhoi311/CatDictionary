using System;   
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public class CustomeButton : Button
    {
        private int borderRadius = 20;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            int arcSize = borderRadius * 2;
            GraphicsPath path  = new GraphicsPath();
            // Vẽ hình chữ nhật bo góc
            path.AddArc(0, 0, arcSize, arcSize, 180, 90); // Góc trên trái
            path.AddArc(Width - arcSize, 0, arcSize, arcSize, 270, 90); // Góc trên phải
            path.AddArc(Width - arcSize, Height - arcSize, arcSize, arcSize, 0, 90); // Góc dưới phải
            path.AddArc(0, Height - arcSize, arcSize, arcSize, 90, 90); // Góc dưới trái
            path.CloseFigure();
            this.Region = new Region(path);
        }
    }
}
