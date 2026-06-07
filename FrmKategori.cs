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
    public partial class FrmKategori : Form
    {
        int secilenKategoriId = 0;
        public FrmKategori()
        {
            InitializeComponent();
            BuildModernLayout();
        }

        private void BuildModernLayout()
        {
            ModernTheme.ApplyFormStyle(this, new Size(1120, 700));
            Text = "Kategori Islemleri";
            SuspendLayout();
            Controls.Clear();

            lblBaslik.AutoSize = true;
            lblBaslik.Text = "Kategori Islemleri";
            lblBaslik.Font = ModernTheme.GetFont(24F, FontStyle.Regular);
            lblBaslik.ForeColor = ModernTheme.TextPrimary;
            lblBaslik.Location = new Point(18, 18);
            Controls.Add(lblBaslik);

            Label lblAciklamaUst = ModernTheme.CreateLabel("Kategori yonetimini tek bir panelden hizli sekilde yapin.", 11F, FontStyle.Regular, ModernTheme.TextMuted);
            lblAciklamaUst.Location = new Point(20, 58);
            Controls.Add(lblAciklamaUst);

            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Location = new Point(18, 104);
            mainLayout.Size = new Size(ClientSize.Width - 36, ClientSize.Height - 122);
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 1;
            mainLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainLayout.Margin = Padding.Empty;
            mainLayout.Padding = Padding.Empty;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 332));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(mainLayout);

            RoundedPanel leftCard = ModernTheme.CreateCard(28, new Padding(22));
            leftCard.Dock = DockStyle.Fill;
            leftCard.Margin = new Padding(0, 0, 16, 0);
            mainLayout.Controls.Add(leftCard, 0, 0);

            FlowLayoutPanel leftStack = new FlowLayoutPanel();
            leftStack.Dock = DockStyle.Fill;
            leftStack.FlowDirection = FlowDirection.TopDown;
            leftStack.WrapContents = false;
            leftCard.Controls.Add(leftStack);

            Label lblFormTitle = ModernTheme.CreateLabel("Yeni kategori ekle", 12F, FontStyle.Bold);
            leftStack.Controls.Add(lblFormTitle);
            leftStack.Controls.Add(CreateSpacer(8));

            PrepareFieldLabel(lblKategoriAdi, "Kategori Adi");
            txtKategoriAdi.Width = 260;
            RoundedPanel kategoriHost = ModernTheme.WrapInput(txtKategoriAdi);
            kategoriHost.Width = 260;

            PrepareFieldLabel(lblAciklama, "Aciklama");
            txtAciklama.Width = 260;
            RoundedPanel aciklamaHost = ModernTheme.WrapInput(txtAciklama);
            aciklamaHost.Width = 260;

            leftStack.Controls.Add(lblKategoriAdi);
            leftStack.Controls.Add(CreateSpacer(8));
            leftStack.Controls.Add(kategoriHost);
            leftStack.Controls.Add(CreateSpacer(14));
            leftStack.Controls.Add(lblAciklama);
            leftStack.Controls.Add(CreateSpacer(8));
            leftStack.Controls.Add(aciklamaHost);
            leftStack.Controls.Add(CreateSpacer(18));

            btnEkle.Text = "Kategori Ekle";
            btnEkle.Width = 260;
            ModernTheme.StylePrimaryButton(btnEkle);
            leftStack.Controls.Add(btnEkle);
            leftStack.Controls.Add(CreateSpacer(26));

            lblIslem.AutoSize = true;
            lblIslem.Text = "Islemler";
            lblIslem.Font = ModernTheme.GetFont(12F, FontStyle.Bold);
            lblIslem.ForeColor = ModernTheme.TextPrimary;
            leftStack.Controls.Add(lblIslem);
            leftStack.Controls.Add(CreateSpacer(10));

            btnGuncelle.Text = "Kategori Guncelle";
            btnGuncelle.Width = 260;
            ModernTheme.StyleWarningButton(btnGuncelle);

            btnSil.Text = "Kategori Sil";
            btnSil.Width = 260;
            ModernTheme.StyleDangerButton(btnSil);

            btnTemizle.Text = "Temizle";
            btnTemizle.Width = 260;
            ModernTheme.StyleSecondaryButton(btnTemizle);

            btnCikis.Text = "Ana Menuye Don";
            btnCikis.Width = 260;
            ModernTheme.StyleSecondaryButton(btnCikis);

            leftStack.Controls.Add(btnGuncelle);
            leftStack.Controls.Add(CreateSpacer(10));
            leftStack.Controls.Add(btnSil);
            leftStack.Controls.Add(CreateSpacer(10));
            leftStack.Controls.Add(btnTemizle);
            leftStack.Controls.Add(CreateSpacer(10));
            leftStack.Controls.Add(btnCikis);

            RoundedPanel gridCard = ModernTheme.CreateCard(28, new Padding(18));
            gridCard.Dock = DockStyle.Fill;
            gridCard.Margin = new Padding(0);
            mainLayout.Controls.Add(gridCard, 1, 0);

            dgvKategoriler.Dock = DockStyle.Fill;
            ModernTheme.StyleGrid(dgvKategoriler);
            gridCard.Controls.Add(dgvKategoriler);

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


        private void FrmKategori_Load(object sender, EventArgs e)
        {
            KategorileriListele();
        }

        private void KategorileriListele()
        {
            dgvKategoriler.AutoGenerateColumns = true;

            dgvKategoriler.DataSource = null;
            dgvKategoriler.Rows.Clear();
            dgvKategoriler.Columns.Clear();

            dgvKategoriler.DataSource = SanalVeritabani.Kategoriler.ToList();
            ModernTheme.ApplyColumnHeaders(dgvKategoriler, new Dictionary<string, string>
            {
                { "KategoriId", "Kategori ID" },
                { "KategoriAdi", "Kategori Adi" },
                { "Aciklama", "Aciklama" }
            });

            dgvKategoriler.Refresh();
        }





        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text.Trim() == "")
            {
                MessageBox.Show("Kategori adı boş bırakılamaz.");
                return;
            }

            Kategori yeniKategori = new Kategori();
            yeniKategori.KategoriId = SanalVeritabani.KategoriIdSayac++;
            yeniKategori.KategoriAdi = txtKategoriAdi.Text;
            yeniKategori.Aciklama = txtAciklama.Text;

            SanalVeritabani.Kategoriler.Add(yeniKategori);

            KategorileriListele();
            Temizle();
            MessageBox.Show("Kategori başarıyla eklendi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenKategoriId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kategoriyi seçiniz.");
                return;
            }

            Kategori kategori = SanalVeritabani.Kategoriler
                .FirstOrDefault(x => x.KategoriId == secilenKategoriId);

            if (kategori != null)
            {
                kategori.KategoriAdi = txtKategoriAdi.Text;
                kategori.Aciklama = txtAciklama.Text;

                KategorileriListele();
                Temizle();

                MessageBox.Show("Kategori güncellendi.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenKategoriId == 0)
            {
                MessageBox.Show("Lütfen silinecek kategoriyi seçiniz.");
                return;
            }

            Kategori kategori = SanalVeritabani.Kategoriler
                .FirstOrDefault(x => x.KategoriId == secilenKategoriId);

            if (kategori != null)
            {
                SanalVeritabani.Kategoriler.Remove(kategori);

                KategorileriListele();
                Temizle();

                MessageBox.Show("Kategori silindi.");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenKategoriId = Convert.ToInt32(dgvKategoriler.Rows[e.RowIndex].Cells["KategoriId"].Value);
                txtKategoriAdi.Text = dgvKategoriler.Rows[e.RowIndex].Cells["KategoriAdi"].Value.ToString();
                txtAciklama.Text = dgvKategoriler.Rows[e.RowIndex].Cells["Aciklama"].Value.ToString();
            }
        }
        private void Temizle()
        {
            secilenKategoriId = 0;
            txtKategoriAdi.Clear();
            txtAciklama.Clear();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
