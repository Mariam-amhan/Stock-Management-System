using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StokTakipSistemi.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using StokTakipSistemi.UI;

namespace StokTakipSistemi
{
    public partial class FrmStokTakibi : Form
    {
        public FrmStokTakibi()
        {
            InitializeComponent();
            BuildModernLayout();
        }

        private void BuildModernLayout()
        {
            ModernTheme.ApplyFormStyle(this, new Size(1160, 720));
            Text = "Stok Takibi";
            SuspendLayout();
            Controls.Clear();

            lblBaslik.AutoSize = true;
            lblBaslik.Text = "Stok Takibi";
            lblBaslik.Font = ModernTheme.GetFont(24F, FontStyle.Regular);
            lblBaslik.ForeColor = ModernTheme.TextPrimary;
            lblBaslik.Location = new Point(18, 18);
            Controls.Add(lblBaslik);

            Label lblUstAciklama = ModernTheme.CreateLabel("Tum urunleri, kritik stoklari ve aktif stok durumunu tek panelde goruntuleyin.", 11F, FontStyle.Regular, ModernTheme.TextMuted);
            lblUstAciklama.Location = new Point(20, 58);
            Controls.Add(lblUstAciklama);

            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Location = new Point(18, 104);
            mainLayout.Size = new Size(ClientSize.Width - 36, ClientSize.Height - 122);
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 1;
            mainLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainLayout.Margin = Padding.Empty;
            mainLayout.Padding = Padding.Empty;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 310));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(mainLayout);

            RoundedPanel leftCard = ModernTheme.CreateCard(28, new Padding(18));
            leftCard.Dock = DockStyle.Fill;
            leftCard.Margin = new Padding(0, 0, 16, 0);
            mainLayout.Controls.Add(leftCard, 0, 0);

            FlowLayoutPanel stack = new FlowLayoutPanel();
            stack.Dock = DockStyle.Fill;
            stack.FlowDirection = FlowDirection.TopDown;
            stack.WrapContents = false;
            leftCard.Controls.Add(stack);

            btnTumUrunler.Text = "Tum Urun Listesi";
            btnTumUrunler.Width = 256;
            ModernTheme.StylePrimaryButton(btnTumUrunler);

            btnKritikStok.Text = "Kritik Stok Listesi";
            btnKritikStok.Width = 256;
            ModernTheme.StylePrimaryButton(btnKritikStok);

            btnStoktaVar.Text = "Stokta Olanlar Listesi";
            btnStoktaVar.Width = 256;
            ModernTheme.StylePrimaryButton(btnStoktaVar);

            btnKapan.Text = "Pencereyi Kapat";
            btnKapan.Width = 256;
            ModernTheme.StyleSecondaryButton(btnKapan);

            stack.Controls.Add(btnTumUrunler);
            stack.Controls.Add(CreateSpacer(10));
            stack.Controls.Add(btnKritikStok);
            stack.Controls.Add(CreateSpacer(10));
            stack.Controls.Add(btnStoktaVar);
            stack.Controls.Add(CreateSpacer(10));
            stack.Controls.Add(btnKapan);
            stack.Controls.Add(CreateSpacer(18));

            RoundedPanel toplamCard = CreateMetricCard("Toplam Urun Sayisi", "◔", lblToplamUrun);
            RoundedPanel kritikCard = CreateMetricCard("Kritik Stok Sayisi", "!", lblKritikUrun);
            stack.Controls.Add(toplamCard);
            stack.Controls.Add(CreateSpacer(12));
            stack.Controls.Add(kritikCard);

            RoundedPanel gridCard = ModernTheme.CreateCard(28, new Padding(18));
            gridCard.Dock = DockStyle.Fill;
            gridCard.Margin = new Padding(0);
            mainLayout.Controls.Add(gridCard, 1, 0);

            dgvStoklar.Dock = DockStyle.Fill;
            ModernTheme.StyleGrid(dgvStoklar);
            gridCard.Controls.Add(dgvStoklar);

            ResumeLayout(false);
        }

        private RoundedPanel CreateMetricCard(string title, string icon, Label valueLabel)
        {
            RoundedPanel card = ModernTheme.CreateCard(22, new Padding(16));
            card.Size = new Size(256, 88);

            Label iconLabel = ModernTheme.CreateLabel(icon, 22F, FontStyle.Bold, ModernTheme.PrimaryColor);
            iconLabel.Location = new Point(16, 22);
            card.Controls.Add(iconLabel);

            Label titleLabel = ModernTheme.CreateLabel(title, 10.2F, FontStyle.Regular, ModernTheme.TextMuted);
            titleLabel.Location = new Point(54, 18);
            card.Controls.Add(titleLabel);

            valueLabel.AutoSize = true;
            valueLabel.Text = "0";
            valueLabel.Font = ModernTheme.GetFont(20F, FontStyle.Bold);
            valueLabel.ForeColor = ModernTheme.TextPrimary;
            valueLabel.Location = new Point(54, 40);
            card.Controls.Add(valueLabel);

            return card;
        }

        private static Control CreateSpacer(int height)
        {
            return new Panel
            {
                Width = 1,
                Height = height,
                Margin = Padding.Empty
            };
        }

        private void btnTumUrunler_Click(object sender, EventArgs e)
        {
            TumUrunleriListele();
            IstatistikleriGuncelle();
        }

        private void FrmStokTakibi_Load(object sender, EventArgs e)
        {
            TumUrunleriListele();
            IstatistikleriGuncelle();
        }

        private void TumUrunleriListele()
        {
            dgvStoklar.AutoGenerateColumns = true;

            dgvStoklar.DataSource = null;
            dgvStoklar.Rows.Clear();
            dgvStoklar.Columns.Clear();

            dgvStoklar.DataSource = SanalVeritabani.Urunler.ToList();
            ConfigureGridColumns();

            dgvStoklar.Refresh();
        }

        private void KritikStoklariListele()
        {
            var kritikler = SanalVeritabani.Urunler
                .Where(x => x.StokMiktari < 10)
                .ToList();

            dgvStoklar.DataSource = null;
            dgvStoklar.DataSource = kritikler;
            ConfigureGridColumns();
        }

        private void StoktaOlanlariListele()
        {
            var stoktaOlanlar = SanalVeritabani.Urunler
                .Where(x => x.StokMiktari > 0)
                .ToList();

            dgvStoklar.DataSource = null;
            dgvStoklar.DataSource = stoktaOlanlar;
            ConfigureGridColumns();
        }

        private void ConfigureGridColumns()
        {
            ModernTheme.ApplyColumnHeaders(dgvStoklar, new Dictionary<string, string>
            {
                { "UrunId", "Urun ID" },
                { "UrunAdi", "Urun Adi" },
                { "KategoriAdi", "Kategori" },
                { "StokMiktari", "Stok" },
                { "Fiyat", "Fiyat" },
                { "GirisTarihi", "Giris Tarihi" },
                { "Durum", "Durum" }
            });

            if (dgvStoklar.Columns["KategoriId"] != null)
            {
                dgvStoklar.Columns["KategoriId"].Visible = false;
            }

            if (dgvStoklar.Columns["Fiyat"] != null)
            {
                dgvStoklar.Columns["Fiyat"].DefaultCellStyle.Format = "N2";
            }

            if (dgvStoklar.Columns["GirisTarihi"] != null)
            {
                dgvStoklar.Columns["GirisTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }


        private void IstatistikleriGuncelle()
        {
            int toplamUrun = SanalVeritabani.Urunler.Count;
            int kritikUrun = SanalVeritabani.Urunler.Count(x => x.StokMiktari < 10);

            lblToplamUrun.Text = toplamUrun.ToString();
            lblKritikUrun.Text = kritikUrun.ToString();
        }

        private void btnKritikStok_Click(object sender, EventArgs e)
        {
            KritikStoklariListele();
            IstatistikleriGuncelle();
        }

        private void btnStoktaVar_Click(object sender, EventArgs e)
        {
            StoktaOlanlariListele();
            IstatistikleriGuncelle();
        }

        private void btnKapan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStoklar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStoklar.Columns[e.ColumnIndex].Name == "StokMiktari")
            {
                if (e.Value != null)
                {
                    int stok = Convert.ToInt32(e.Value);

                    if (stok < 10)
                    {
                        dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(253, 234, 234);
                        dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = ModernTheme.TextPrimary;
                    }
                    else
                    {
                        dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = ModernTheme.TextPrimary;
                    }
                }
            }
        }
    }
}
