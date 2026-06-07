using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StokTakipSistemi.UI
{
    public class RoundedPanel : Panel
    {
        public RoundedPanel()
        {
            BorderColor = ModernTheme.BorderColor;
            BorderThickness = 1;
            CornerRadius = 24;
            DoubleBuffered = true;
            Resize += delegate { Invalidate(); };
        }

        public Color BorderColor { get; set; }

        public int BorderThickness { get; set; }

        public int CornerRadius { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = ClientRectangle;
            if (bounds.Width <= 1 || bounds.Height <= 1)
            {
                return;
            }

            bounds.Width -= 1;
            bounds.Height -= 1;

            using (GraphicsPath path = CreatePath(bounds, CornerRadius))
            using (SolidBrush brush = new SolidBrush(BackColor))
            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Parent != null ? Parent.BackColor : SystemColors.Control);
        }

        private static GraphicsPath CreatePath(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
