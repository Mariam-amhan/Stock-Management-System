using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StokTakipSistemi.UI
{
    public class ModernTileButton : Button
    {
        private bool isHovered;
        private bool isPressed;

        public ModernTileButton()
        {
            Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            TabStop = false;

            Size = new Size(208, 138);
            BackColor = Color.Transparent;
            Font = ModernTheme.GetFont(12F, FontStyle.Bold);
            ForeColor = ModernTheme.TextPrimary;

            IconGlyph = "◫";
            TitleText = "Kart";
            AccentBackground = false;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true
            );

            UpdateStyles();
        }

        public bool AccentBackground { get; set; }

        public string IconGlyph { get; set; }

        public string TitleText { get; set; }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Arka planı Windows'un varsayılan şekilde boyamasını engeller.
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            isHovered = false;
            isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            isPressed = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            isPressed = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pevent.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);

            Rectangle bounds = new Rectangle(1, 1, Width - 3, Height - 3);

            Color background = AccentBackground ? ModernTheme.PrimaryColor : Color.White;
            Color iconColor = AccentBackground ? Color.White : ModernTheme.PrimaryColor;
            Color borderColor = AccentBackground ? ModernTheme.PrimaryColor : ModernTheme.BorderColor;
            Color textColor = AccentBackground ? Color.White : ModernTheme.TextPrimary;

            if (isHovered)
            {
                background = AccentBackground
                    ? ModernTheme.PrimaryDarkColor
                    : ModernTheme.HoverSurfaceColor;
            }

            if (isPressed)
            {
                background = AccentBackground
                    ? ModernTheme.PrimaryDarkColor
                    : ModernTheme.PressedSurfaceColor;
            }

            using (GraphicsPath path = ModernTheme.CreateRoundedPath(bounds, 24))
            using (SolidBrush brush = new SolidBrush(background))
            using (Pen pen = new Pen(borderColor))
            {
                pevent.Graphics.FillPath(brush, path);
                pevent.Graphics.DrawPath(pen, path);
            }

            using (StringFormat centered = new StringFormat())
            {
                centered.Alignment = StringAlignment.Center;
                centered.LineAlignment = StringAlignment.Center;

                Rectangle iconRect = new Rectangle(16, 18, Width - 32, 44);
                Rectangle titleRect = new Rectangle(16, 64, Width - 32, Height - 78);

                using (Font iconFont = ModernTheme.GetFont(24F, FontStyle.Regular))
                using (Font titleFont = ModernTheme.GetFont(12.5F, FontStyle.Bold))
                using (SolidBrush iconBrush = new SolidBrush(iconColor))
                using (SolidBrush textBrush = new SolidBrush(textColor))
                {
                    pevent.Graphics.DrawString(IconGlyph, iconFont, iconBrush, iconRect, centered);
                    pevent.Graphics.DrawString(TitleText, titleFont, textBrush, titleRect, centered);
                }
            }
        }
    }
}