using StokTakipSistemi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakipSistemi.UI;

namespace StokTakipSistemi
{
    public partial class FrmAnaMenu : Form
    {
        public FrmAnaMenu()
        {
            InitializeComponent();
            BuildModernLayout();
        }

        private void BuildModernLayout()
        {
            ModernTheme.ApplyFormStyle(this, new Size(1080, 660));
            Text = "Ana Menu";
            SuspendLayout();
            Controls.Clear();

            RoundedPanel sidebar = ModernTheme.CreateCard(28, new Padding(14));
            sidebar.BackColor = ModernTheme.SidebarColor;
            sidebar.Size = new Size(176, ClientSize.Height - 32);
            sidebar.Location = new Point(16, 16);
            Controls.Add(sidebar);

            Label lblSidebarTitle = ModernTheme.CreateLabel("YONETIM", 9.2F, FontStyle.Bold, ModernTheme.PrimaryColor);
            lblSidebarTitle.Location = new Point(18, 18);
            sidebar.Controls.Add(lblSidebarTitle);

            FlowLayoutPanel navStack = new FlowLayoutPanel();
            navStack.Location = new Point(10, 62);
            navStack.Size = new Size(156, 510);
            navStack.FlowDirection = FlowDirection.TopDown;
            navStack.WrapContents = false;
            sidebar.Controls.Add(navStack);

            ConfigureSidebarButton(btnKategoriIslemleri, "Kategoriler");
            ConfigureSidebarButton(btnUrunIslemleri, "Urunler");
            ConfigureSidebarButton(btnStokTakibi, "Stok Takip");
            ConfigureSidebarButton(btnCikis, "Cikis");
            btnCikis.Margin = new Padding(0, 220, 0, 0);

            navStack.Controls.Add(btnKategoriIslemleri);
            navStack.Controls.Add(btnUrunIslemleri);
            navStack.Controls.Add(btnStokTakibi);
            navStack.Controls.Add(btnCikis);

            Panel contentPanel = new Panel();
            contentPanel.Location = new Point(220, 24);
            contentPanel.Size = new Size(ClientSize.Width - 244, ClientSize.Height - 48);
            contentPanel.BackColor = Color.Transparent;
            Controls.Add(contentPanel);

            lblBaslik.AutoSize = true;
            lblBaslik.Text = "Ana Menu";
            lblBaslik.Font = ModernTheme.GetFont(26F, FontStyle.Regular);
            lblBaslik.ForeColor = ModernTheme.TextPrimary;
            lblBaslik.Location = new Point(0, 18);
            contentPanel.Controls.Add(lblBaslik);

            lblAltBaslik.AutoSize = true;
            lblAltBaslik.Text = "Hos geldiniz. Lutfen yapmak istediginiz islemi seciniz.";
            lblAltBaslik.Font = ModernTheme.GetFont(11.5F, FontStyle.Regular);
            lblAltBaslik.ForeColor = ModernTheme.TextMuted;
            lblAltBaslik.Location = new Point(4, 62);
            contentPanel.Controls.Add(lblAltBaslik);

            TableLayoutPanel cardGrid = new TableLayoutPanel();
            cardGrid.Location = new Point(0, 118);
            cardGrid.Size = new Size(470, 322);
            cardGrid.ColumnCount = 2;
            cardGrid.RowCount = 2;
            cardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 224));
            cardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 224));
            cardGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 154));
            cardGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 154));
            contentPanel.Controls.Add(cardGrid);

            ModernTileButton kategoriKart = CreateTileButton("▦", "Kategori Islemleri", btnKategoriIslemleri_Click);
            ModernTileButton urunKart = CreateTileButton("⬢", "Urun Islemleri", btnUrunIslemleri_Click);
            ModernTileButton stokKart = CreateTileButton("↗", "Stok Takibi", btnStokTakibi_Click);
            ModernTileButton cikisKart = CreateTileButton("⇢", "Cikis", btnCikis_Click);

            cardGrid.Controls.Add(kategoriKart, 0, 0);
            cardGrid.Controls.Add(urunKart, 1, 0);
            cardGrid.Controls.Add(stokKart, 0, 1);
            cardGrid.Controls.Add(cikisKart, 1, 1);

           

            Label dekorMetin = ModernTheme.CreateLabel("Akilli stok yonetimi", 10.5F, FontStyle.Regular, ModernTheme.TextMuted);
            dekorMetin.Location = new Point(contentPanel.Width - 196, contentPanel.Height - 92);
            contentPanel.Controls.Add(dekorMetin);

            ResumeLayout(false);
        }

        private void ConfigureSidebarButton(Button button, string text)
        {
            button.Text = text;
            button.Width = 148;
            button.Height = 44;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(16, 0, 0, 0);
            button.Margin = new Padding(0, 0, 0, 10);
            ModernTheme.StyleSecondaryButton(button);
        }

        private ModernTileButton CreateTileButton(string icon, string text, EventHandler onClick)
        {
            ModernTileButton button = new ModernTileButton();
            button.IconGlyph = icon;
            button.TitleText = text;
            button.Margin = new Padding(0, 0, 16, 16);
            button.Click += onClick;
            return button;
        }






        private void btnKategoriIslemleri_Click(object sender, EventArgs e)
        {
            FrmKategori frm = new FrmKategori();
            frm.ShowDialog();
        }

        private void btnUrunIslemleri_Click(object sender, EventArgs e)
        {
            FrmUrun frm = new FrmUrun();
                
            frm.ShowDialog();                        
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmAnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            SanalVeritabani.KategorileriKaydet();
            SanalVeritabani.UrunleriKaydet();
        }

        private void btnStokTakibi_Click(object sender, EventArgs e)
        {
            FrmStokTakibi frm = new FrmStokTakibi();
            frm.ShowDialog();
        }
    }
}
