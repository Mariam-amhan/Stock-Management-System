using System;
using System.Linq;
using System.Windows.Forms;
using StokTakipSistemi.Data;
using StokTakipSistemi.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using StokTakipSistemi.UI;

namespace StokTakipSistemi
{
    public partial class FrmUrun : Form
    {
        int secilenUrunId = 0;
        public FrmUrun()
        {
            InitializeComponent();
            BuildModernLayout();
        }

        private void BuildModernLayout()
        {
            ModernTheme.ApplyFormStyle(this, new Size(1180, 760));
            Text = "Urun Islemleri";
            SuspendLayout();
            Controls.Clear();

            label1.AutoSize = true;
            label1.Text = "Urun Islemleri";
            label1.Font = ModernTheme.GetFont(24F, FontStyle.Regular);
            label1.ForeColor = ModernTheme.TextPrimary;
            label1.Location = new Point(18, 18);
            Controls.Add(label1);

            Label lblUstAciklama = ModernTheme.CreateLabel("Urun kaydi, guncelleme ve stok bilgilerini modern form akisi ile yonetin.", 11F, FontStyle.Regular, ModernTheme.TextMuted);
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
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 364));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(mainLayout);

            RoundedPanel leftCard = ModernTheme.CreateCard(28, new Padding(22));
            leftCard.Dock = DockStyle.Fill;
            leftCard.Margin = new Padding(0, 0, 16, 0);
            mainLayout.Controls.Add(leftCard, 0, 0);

            TableLayoutPanel leftLayout = new TableLayoutPanel();
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.ColumnCount = 1;
            leftLayout.RowCount = 2;
            leftLayout.Margin = Padding.Empty;
            leftLayout.Padding = Padding.Empty;
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftCard.Controls.Add(leftLayout);

            Panel formScrollHost = new Panel();
            formScrollHost.Dock = DockStyle.Fill;
            formScrollHost.AutoScroll = true;
            formScrollHost.Margin = Padding.Empty;
            leftLayout.Controls.Add(formScrollHost, 0, 0);

            FlowLayoutPanel stack = new FlowLayoutPanel();
            stack.AutoSize = true;
            stack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            stack.WrapContents = false;
            stack.FlowDirection = FlowDirection.TopDown;
            stack.Dock = DockStyle.Top;
            stack.Margin = Padding.Empty;
            formScrollHost.Controls.Add(stack);

            Label lblFormTitle = ModernTheme.CreateLabel("Yeni urun kaydi", 12F, FontStyle.Bold);
            stack.Controls.Add(lblFormTitle);
            stack.Controls.Add(CreateSpacer(8));

            PrepareFieldLabel(lblUrunAdi, "Urun Adi");
            txtUrunAdi.Width = 292;
            RoundedPanel urunHost = ModernTheme.WrapInput(txtUrunAdi);
            urunHost.Width = 292;

            PrepareFieldLabel(lblKategori, "Kategori");
            cmbKategori.Width = 292;
            RoundedPanel kategoriHost = ModernTheme.WrapInput(cmbKategori);
            kategoriHost.Width = 292;

            PrepareFieldLabel(lblStok, "Stok Miktari");
            txtStok.Width = 292;
            RoundedPanel stokHost = ModernTheme.WrapInput(txtStok);
            stokHost.Width = 292;

            PrepareFieldLabel(lblFiyat, "Fiyat");
            txtFiyat.Width = 292;
            RoundedPanel fiyatHost = ModernTheme.WrapInput(txtFiyat);
            fiyatHost.Width = 292;

            PrepareFieldLabel(lblTarih, "Giris Tarihi");
            dtpGirisTarihi.Width = 292;
            RoundedPanel tarihHost = ModernTheme.WrapInput(dtpGirisTarihi);
            tarihHost.Width = 292;

            label2.AutoSize = true;
            label2.Text = "Durum";
            label2.Font = ModernTheme.GetFont(10.3F, FontStyle.Regular);
            label2.ForeColor = ModernTheme.TextPrimary;

            ModernTheme.StyleRadioButton(rbAktif);
            ModernTheme.StyleRadioButton(rbPasif);
            rbAktif.Text = "Aktif";
            rbPasif.Text = "Pasif";
            Panel durumPanel = ModernTheme.CreateRadioHost(rbAktif, rbPasif);

            stack.Controls.Add(lblUrunAdi);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(urunHost);
            stack.Controls.Add(CreateSpacer(12));
            stack.Controls.Add(lblKategori);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(kategoriHost);
            stack.Controls.Add(CreateSpacer(12));
            stack.Controls.Add(lblStok);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(stokHost);
            stack.Controls.Add(CreateSpacer(12));
            stack.Controls.Add(lblFiyat);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(fiyatHost);
            stack.Controls.Add(CreateSpacer(12));
            stack.Controls.Add(lblTarih);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(tarihHost);
            stack.Controls.Add(CreateSpacer(12));
            stack.Controls.Add(label2);
            stack.Controls.Add(CreateSpacer(6));
            stack.Controls.Add(durumPanel);
            stack.Controls.Add(CreateSpacer(12));

            btnEkle.Text = "Urun Ekle";
            btnEkle.Width = 292;
            ModernTheme.StylePrimaryButton(btnEkle);

            btnGuncelle.Text = "Urun Guncelle";
            btnGuncelle.Width = 292;
            ModernTheme.StyleWarningButton(btnGuncelle);

            btnSil.Text = "Urun Sil";
            btnSil.Width = 292;
            ModernTheme.StyleDangerButton(btnSil);

            btnTemizle.Text = "Temizle";
            btnTemizle.Width = 292;
            ModernTheme.StyleSecondaryButton(btnTemizle);

            button1.Text = "Ana Menuye Don";
            button1.Width = 292;
            ModernTheme.StyleSecondaryButton(button1);

            Panel divider = new Panel();
            divider.Dock = DockStyle.Top;
            divider.Height = 1;
            divider.BackColor = ModernTheme.BorderColor;
            divider.Margin = new Padding(0, 0, 0, 14);

            FlowLayoutPanel actionStack = new FlowLayoutPanel();
            actionStack.AutoSize = true;
            actionStack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actionStack.Dock = DockStyle.Top;
            actionStack.FlowDirection = FlowDirection.TopDown;
            actionStack.WrapContents = false;
            actionStack.Margin = Padding.Empty;
            actionStack.Padding = new Padding(0, 14, 0, 0);

            actionStack.Controls.Add(btnEkle);
            actionStack.Controls.Add(CreateSpacer(10));
            actionStack.Controls.Add(btnGuncelle);
            actionStack.Controls.Add(CreateSpacer(10));
            actionStack.Controls.Add(btnSil);
            actionStack.Controls.Add(CreateSpacer(10));
            actionStack.Controls.Add(btnTemizle);
            actionStack.Controls.Add(CreateSpacer(10));
            actionStack.Controls.Add(button1);

            Panel actionHost = new Panel();
            actionHost.Dock = DockStyle.Top;
            actionHost.AutoSize = true;
            actionHost.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actionHost.Margin = new Padding(0, 14, 0, 0);
            actionHost.Controls.Add(actionStack);
            actionHost.Controls.Add(divider);
            leftLayout.Controls.Add(actionHost, 0, 1);

            RoundedPanel gridCard = ModernTheme.CreateCard(28, new Padding(18));
            gridCard.Dock = DockStyle.Fill;
            gridCard.Margin = new Padding(0);
            mainLayout.Controls.Add(gridCard, 1, 0);

            dgvUrunler.Dock = DockStyle.Fill;
            ModernTheme.StyleGrid(dgvUrunler);
            gridCard.Controls.Add(dgvUrunler);

            ResumeLayout(false);
        }

        private void PrepareFieldLabel(Label label, string text)
        {
            label.AutoSize = true;
            label.Text = text;
            label.Font = ModernTheme.GetFont(10.3F, FontStyle.Regular);
            label.ForeColor = ModernTheme.TextPrimary;
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

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            KategorileriComboBoxaDoldur();
            UrunleriListele();

            rbAktif.Checked = true;
        }

        private void KategorileriComboBoxaDoldur()
        {
            cmbKategori.DataSource = null;
            cmbKategori.DataSource = SanalVeritabani.Kategoriler;
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriId";
        }

        private void UrunleriListele()
        {
            dgvUrunler.DataSource = null;

            if (SanalVeritabani.Urunler.Count == 0)
            {
                return;
            }

            dgvUrunler.DataSource = SanalVeritabani.Urunler.ToList();
            ModernTheme.ApplyColumnHeaders(dgvUrunler, new Dictionary<string, string>
            {
                { "UrunId", "Urun ID" },
                { "UrunAdi", "Urun Adi" },
                { "KategoriId", "Kategori ID" },
                { "KategoriAdi", "Kategori" },
                { "StokMiktari", "Stok" },
                { "Fiyat", "Fiyat" },
                { "GirisTarihi", "Giris Tarihi" },
                { "Durum", "Durum" }
            });

            if (dgvUrunler.Columns["Fiyat"] != null)
            {
                dgvUrunler.Columns["Fiyat"].DefaultCellStyle.Format = "N2";
            }

            if (dgvUrunler.Columns["GirisTarihi"] != null)
            {
                dgvUrunler.Columns["GirisTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            dgvUrunler.ClearSelection();
            dgvUrunler.CurrentCell = null;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text.Trim() == "")
            {
                MessageBox.Show("Ürün adı boş bırakılamaz.");
                return;
            }

            Kategori seciliKategori = cmbKategori.SelectedItem as Kategori;
            if (seciliKategori == null)
            {
                MessageBox.Show("Lütfen kategori seçiniz.");
                return;
            }

            int stok;
            if (!int.TryParse(txtStok.Text, out stok))
            {
                MessageBox.Show("Stok miktarı sayı olmalıdır.");
                return;
            }

            decimal fiyat;
            if (!decimal.TryParse(txtFiyat.Text, out fiyat))
            {
                MessageBox.Show("Fiyat sayı olmalıdır.");
                return;
            }

            string durum = rbAktif.Checked ? "Aktif" : "Pasif";

            Urun yeniUrun = new Urun();
            yeniUrun.UrunId = SanalVeritabani.UrunIdSayac++;
            yeniUrun.UrunAdi = txtUrunAdi.Text;
            yeniUrun.KategoriId = seciliKategori.KategoriId;
            yeniUrun.KategoriAdi = seciliKategori.KategoriAdi;
            yeniUrun.StokMiktari = stok;
            yeniUrun.Fiyat = fiyat;
            yeniUrun.GirisTarihi = dtpGirisTarihi.Value;
            yeniUrun.Durum = durum;

            SanalVeritabani.Urunler.Add(yeniUrun);

            UrunleriListele();
            Temizle();

            MessageBox.Show("Ürün başarıyla eklendi.");
        }

     

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenUrunId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek ürünü seçiniz.");
                return;
            }

            if (txtUrunAdi.Text.Trim() == "")
            {
                MessageBox.Show("Ürün adı boş bırakılamaz.");
                return;
            }

            int stok;
            if (!int.TryParse(txtStok.Text, out stok))
            {
                MessageBox.Show("Stok miktarı sayı olmalıdır.");
                return;
            }

            decimal fiyat;
            if (!decimal.TryParse(txtFiyat.Text, out fiyat))
            {
                MessageBox.Show("Fiyat sayı olmalıdır.");
                return;
            }

            Kategori seciliKategori = cmbKategori.SelectedItem as Kategori;
            if (seciliKategori == null)
            {
                MessageBox.Show("Lütfen kategori seçiniz.");
                return;
            }

            Urun urun = SanalVeritabani.Urunler
                .FirstOrDefault(x => x.UrunId == secilenUrunId);

            if (urun != null)
            {
                urun.UrunAdi = txtUrunAdi.Text;
                urun.KategoriId = seciliKategori.KategoriId;
                urun.KategoriAdi = seciliKategori.KategoriAdi;
                urun.StokMiktari = stok;
                urun.Fiyat = fiyat;
                urun.GirisTarihi = dtpGirisTarihi.Value;
                urun.Durum = rbAktif.Checked ? "Aktif" : "Pasif";

                UrunleriListele();
                Temizle();

                MessageBox.Show("Ürün güncellendi.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenUrunId == 0)
            {
                MessageBox.Show("Lütfen silinecek ürünü seçiniz.");
                return;
            }

            DialogResult cevap = MessageBox.Show(
                "Seçili ürünü silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cevap == DialogResult.Yes)
            {
                Urun urun = SanalVeritabani.Urunler
                    .FirstOrDefault(x => x.UrunId == secilenUrunId);

                if (urun != null)
                {
                    SanalVeritabani.Urunler.Remove(urun);

                    UrunleriListele();
                    Temizle();

                    MessageBox.Show("Ürün silindi.");
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            secilenUrunId = 0;
            txtUrunAdi.Clear();
            txtStok.Clear();
            txtFiyat.Clear();

            if (cmbKategori.Items.Count > 0)
            {
                cmbKategori.SelectedIndex = 0;
            }

            dtpGirisTarihi.Value = DateTime.Now;
            rbAktif.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvUrunler.CurrentRow == null || dgvUrunler.CurrentRow.Index < 0)
                return;

            Urun secilenUrun = dgvUrunler.CurrentRow.DataBoundItem as Urun;
            if (secilenUrun == null)
                return;

            secilenUrunId = secilenUrun.UrunId;
            txtUrunAdi.Text = secilenUrun.UrunAdi;
            txtStok.Text = secilenUrun.StokMiktari.ToString();
            txtFiyat.Text = secilenUrun.Fiyat.ToString();
            dtpGirisTarihi.Value = secilenUrun.GirisTarihi;

            KategoriyiGuvenliSec(secilenUrun.KategoriId);

            rbAktif.Checked = secilenUrun.Durum == "Aktif";
            rbPasif.Checked = secilenUrun.Durum == "Pasif";
        }

        private void KategoriyiGuvenliSec(int kategoriId)
        {
            if (cmbKategori.Items.Count == 0)
            {
                cmbKategori.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < cmbKategori.Items.Count; i++)
            {
                Kategori kategori = cmbKategori.Items[i] as Kategori;
                if (kategori != null && kategori.KategoriId == kategoriId)
                {
                    cmbKategori.SelectedIndex = i;
                    return;
                }
            }

            cmbKategori.SelectedIndex = 0;
        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
         
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
