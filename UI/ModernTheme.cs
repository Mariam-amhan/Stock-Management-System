using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StokTakipSistemi.UI
{
    public static class ModernTheme
    {
        public static readonly Color AppBackgroundColor = Color.FromArgb(243, 246, 251);
        public static readonly Color SurfaceColor = Color.White;
        public static readonly Color SidebarColor = Color.FromArgb(236, 240, 246);
        public static readonly Color BorderColor = Color.FromArgb(214, 222, 232);
        public static readonly Color PrimaryColor = Color.FromArgb(78, 120, 163);
        public static readonly Color PrimaryDarkColor = Color.FromArgb(58, 96, 136);
        public static readonly Color WarningColor = Color.FromArgb(244, 190, 73);
        public static readonly Color DangerColor = Color.FromArgb(225, 92, 83);
        public static readonly Color SuccessColor = Color.FromArgb(61, 153, 112);
        public static readonly Color TextPrimary = Color.FromArgb(31, 41, 55);
        public static readonly Color TextMuted = Color.FromArgb(96, 108, 128);
        public static readonly Color HoverSurfaceColor = Color.FromArgb(248, 250, 252);
        public static readonly Color PressedSurfaceColor = Color.FromArgb(236, 242, 247);

        public static void ApplyFormStyle(Form form, Size size)
        {
            form.BackColor = AppBackgroundColor;
            form.ForeColor = TextPrimary;
            form.Font = GetFont(10F);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ClientSize = size;
            form.Padding = new Padding(16);
        }

        public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style, GraphicsUnit.Point, 162);
        }

        public static RoundedPanel CreateCard(int radius = 24, Padding? padding = null)
        {
            RoundedPanel card = new RoundedPanel();
            card.BackColor = SurfaceColor;
            card.BorderColor = BorderColor;
            card.BorderThickness = 1;
            card.CornerRadius = radius;
            card.Padding = padding ?? new Padding(24);
            return card;
        }

        public static Label CreateLabel(string text, float size, FontStyle style, Color? color = null)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = text;
            label.Font = GetFont(size, style);
            label.ForeColor = color ?? TextPrimary;
            label.BackColor = Color.Transparent;
            return label;
        }

        public static void StyleActionButton(Button button, Color background, Color foreground, bool outlined)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Cursor = Cursors.Hand;
            button.BackColor = background;
            button.ForeColor = foreground;
            button.Font = GetFont(10.5F, FontStyle.Regular);
            button.Height = 42;
            button.FlatAppearance.BorderSize = outlined ? 1 : 0;
            button.FlatAppearance.BorderColor = outlined ? BorderColor : background;
            button.FlatAppearance.MouseOverBackColor = outlined ? HoverSurfaceColor : background;
            button.FlatAppearance.MouseDownBackColor = outlined ? PressedSurfaceColor : background;
            button.UseVisualStyleBackColor = false;
            ApplyRoundedRegion(button, 10);
        }

        public static void StylePrimaryButton(Button button)
        {
            StyleActionButton(button, PrimaryColor, Color.White, false);
        }

        public static void StyleDangerButton(Button button)
        {
            StyleActionButton(button, DangerColor, Color.White, false);
        }

        public static void StyleWarningButton(Button button)
        {
            StyleActionButton(button, WarningColor, TextPrimary, false);
        }

        public static void StyleSecondaryButton(Button button)
        {
            StyleActionButton(button, SurfaceColor, TextPrimary, true);
        }

        public static RoundedPanel WrapInput(Control control, int height = 46)
        {
            RoundedPanel host = CreateCard(16, new Padding(14, 11, 14, 11));
            host.Height = height;
            host.Width = control.Width;

            if (control is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.None;
                textBox.Font = GetFont(10.8F);
                textBox.ForeColor = TextPrimary;
                textBox.BackColor = Color.White;
                textBox.Dock = DockStyle.Fill;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = GetFont(10.8F);
                comboBox.ForeColor = TextPrimary;
                comboBox.BackColor = Color.White;
                comboBox.Dock = DockStyle.Fill;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (control is DateTimePicker dateTimePicker)
            {
                dateTimePicker.Font = GetFont(10.5F);
                dateTimePicker.CalendarForeColor = TextPrimary;
                dateTimePicker.CalendarMonthBackground = Color.White;
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "dd.MM.yyyy";
                dateTimePicker.Dock = DockStyle.Fill;
            }

            control.Margin = Padding.Empty;
            host.Controls.Add(control);
            return host;
        }

        public static Panel CreateRadioHost(params Control[] controls)
        {
            Panel panel = new Panel();
            panel.Height = 36;
            panel.Width = 260;
            panel.BackColor = Color.Transparent;

            int left = 0;
            foreach (Control control in controls)
            {
                control.Location = new Point(left, 5);
                control.BackColor = Color.Transparent;
                panel.Controls.Add(control);
                left += control.Width + 20;
            }

            return panel;
        }

        public static void StyleRadioButton(RadioButton radioButton)
        {
            radioButton.AutoSize = true;
            radioButton.Font = GetFont(10.5F);
            radioButton.ForeColor = TextPrimary;
        }

        public static void StyleCheckBox(CheckBox checkBox)
        {
            checkBox.AutoSize = true;
            checkBox.Font = GetFont(9.5F);
            checkBox.ForeColor = TextMuted;
            checkBox.BackColor = Color.Transparent;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = BorderColor;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = GetFont(10.2F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 252);
            grid.ColumnHeadersHeight = 42;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 234, 247);
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.DefaultCellStyle.Font = GetFont(10F);
            grid.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            grid.RowTemplate.Height = 36;
        }

        public static void ApplyColumnHeaders(DataGridView grid, IDictionary<string, string> headers)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (headers.ContainsKey(column.Name))
                {
                    column.HeaderText = headers[column.Name];
                }
            }
        }

        public static void ApplyRoundedRegion(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(Point.Empty, control.Size);
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return;
            }

            using (GraphicsPath path = CreateRoundedPath(bounds, radius))
            {
                control.Region = new Region(path);
            }
        }

        public static GraphicsPath CreateRoundedPath(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
