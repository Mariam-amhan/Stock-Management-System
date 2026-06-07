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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
            BuildModernLayout();
        }

        private void BuildModernLayout()
        {
            ModernTheme.ApplyFormStyle(this, new Size(920, 560));
            Text = "Stok Takip Sistemi";
            SuspendLayout();
            Controls.Clear();

            RoundedPanel chipCard = ModernTheme.CreateCard(16, new Padding(12, 8, 12, 8));
            chipCard.Size = new Size(118, 36);
            chipCard.Location = new Point(24, 22);
            Controls.Add(chipCard);

            Label lblChip = ModernTheme.CreateLabel("STOK TAKIP", 9.2F, FontStyle.Bold, ModernTheme.PrimaryColor);
            lblChip.Location = new Point(12, 8);
            chipCard.Controls.Add(lblChip);

            lblBaslik.AutoSize = true;
            lblBaslik.Text = "Stok Takip Sistemi";
            lblBaslik.Font = ModernTheme.GetFont(23F, FontStyle.Regular);
            lblBaslik.ForeColor = ModernTheme.TextPrimary;
            lblBaslik.Location = new Point((ClientSize.Width - lblBaslik.PreferredWidth) / 2, 68);
            Controls.Add(lblBaslik);

            Label lblAltMetin = ModernTheme.CreateLabel("Sisteme giris yaparak stok, kategori ve urun yonetimini tek ekrandan surdurun.", 11F, FontStyle.Regular, ModernTheme.TextMuted);
            lblAltMetin.Location = new Point((ClientSize.Width - lblAltMetin.PreferredWidth) / 2, 112);
            Controls.Add(lblAltMetin);

            RoundedPanel loginCard = ModernTheme.CreateCard(28, new Padding(22));
            loginCard.Size = new Size(394, 320);
            loginCard.Location = new Point((ClientSize.Width - loginCard.Width) / 2, 150);
            Controls.Add(loginCard);

            FlowLayoutPanel stack = new FlowLayoutPanel();
            stack.Dock = DockStyle.Fill;
            stack.FlowDirection = FlowDirection.TopDown;
            stack.WrapContents = false;
            loginCard.Controls.Add(stack);

            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Text = "Kullanici Adi";
            lblKullaniciAdi.Font = ModernTheme.GetFont(10.3F, FontStyle.Regular);
            lblKullaniciAdi.ForeColor = ModernTheme.TextPrimary;

            txtKullaniciAdi.Width = 330;
            RoundedPanel userHost = ModernTheme.WrapInput(txtKullaniciAdi);
            userHost.Width = 330;

            lblSifre.AutoSize = true;
            lblSifre.Text = "Parola";
            lblSifre.Font = ModernTheme.GetFont(10.3F, FontStyle.Regular);
            lblSifre.ForeColor = ModernTheme.TextPrimary;

            txtSifre.Width = 330;
            RoundedPanel passwordHost = ModernTheme.WrapInput(txtSifre);
            passwordHost.Width = 330;

            chkSifreGoster.Text = "Parolayi Goster";
            ModernTheme.StyleCheckBox(chkSifreGoster);
            chkSifreGoster.Margin = new Padding(0, 2, 0, 12);

            btnGiris.Text = "Giris Yap";
            btnGiris.Width = 330;
            ModernTheme.StylePrimaryButton(btnGiris);
            btnGiris.Margin = new Padding(0, 0, 0, 10);

            btnCikis.Text = "Cikis";
            btnCikis.Width = 330;
            ModernTheme.StyleSecondaryButton(btnCikis);
            btnCikis.Margin = new Padding(0);

            stack.Controls.Add(CreateSpacer(4));
            stack.Controls.Add(lblKullaniciAdi);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(userHost);
            stack.Controls.Add(CreateSpacer(14));
            stack.Controls.Add(lblSifre);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(passwordHost);
            stack.Controls.Add(CreateSpacer(8));
            stack.Controls.Add(chkSifreGoster);
            stack.Controls.Add(btnGiris);
            stack.Controls.Add(btnCikis);

            lblHaklar.AutoSize = true;
            lblHaklar.Text = "Görsel Programlama Deney Projesi | Mariam Amhan @2026";
            lblHaklar.Font = ModernTheme.GetFont(8.7F, FontStyle.Regular);
            lblHaklar.ForeColor = ModernTheme.TextMuted;
            lblHaklar.Location = new Point((ClientSize.Width - lblHaklar.PreferredWidth) / 2, ClientSize.Height - 34);
            Controls.Add(lblHaklar);

            AcceptButton = btnGiris;
            CancelButton = btnCikis;
            ResumeLayout(false);
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



        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            if (kullaniciAdi == "admin" && sifre == "1234")
            {
                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmAnaMenu anaMenu = new FrmAnaMenu();
                anaMenu.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSifreGoster.Checked)
            {
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

            SanalVeritabani.KategorileriYukle();
            SanalVeritabani.UrunleriYukle();
            
        }
    }
}
