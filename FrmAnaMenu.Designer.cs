namespace StokTakipSistemi
{
    partial class FrmAnaMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnKategoriIslemleri = new System.Windows.Forms.Button();
            this.lblAltBaslik = new System.Windows.Forms.Label();
            this.btnUrunIslemleri = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnStokTakibi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(535, 31);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(253, 58);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Ana Menü";
            // 
            // btnKategoriIslemleri
            // 
            this.btnKategoriIslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategoriIslemleri.Location = new System.Drawing.Point(512, 206);
            this.btnKategoriIslemleri.Name = "btnKategoriIslemleri";
            this.btnKategoriIslemleri.Size = new System.Drawing.Size(276, 74);
            this.btnKategoriIslemleri.TabIndex = 1;
            this.btnKategoriIslemleri.Text = "Kategori İşlemleri";
            this.btnKategoriIslemleri.UseVisualStyleBackColor = true;
            this.btnKategoriIslemleri.Click += new System.EventHandler(this.btnKategoriIslemleri_Click);
            // 
            // lblAltBaslik
            // 
            this.lblAltBaslik.AutoSize = true;
            this.lblAltBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAltBaslik.Location = new System.Drawing.Point(236, 126);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(845, 29);
            this.lblAltBaslik.TabIndex = 2;
            this.lblAltBaslik.Text = "Ana Menüye Hoş Geldiniz Lütfen İşlem Yapmak İstediğiniz İşelemi seçiniz";
            // 
            // btnUrunIslemleri
            // 
            this.btnUrunIslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunIslemleri.Location = new System.Drawing.Point(512, 311);
            this.btnUrunIslemleri.Name = "btnUrunIslemleri";
            this.btnUrunIslemleri.Size = new System.Drawing.Size(276, 74);
            this.btnUrunIslemleri.TabIndex = 3;
            this.btnUrunIslemleri.Text = "Ürün İşlemleri";
            this.btnUrunIslemleri.UseVisualStyleBackColor = true;
            this.btnUrunIslemleri.Click += new System.EventHandler(this.btnUrunIslemleri_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Location = new System.Drawing.Point(512, 517);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(276, 74);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnStokTakibi
            // 
            this.btnStokTakibi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokTakibi.Location = new System.Drawing.Point(512, 412);
            this.btnStokTakibi.Name = "btnStokTakibi";
            this.btnStokTakibi.Size = new System.Drawing.Size(276, 74);
            this.btnStokTakibi.TabIndex = 5;
            this.btnStokTakibi.Text = "Stok Takibi";
            this.btnStokTakibi.UseVisualStyleBackColor = true;
            this.btnStokTakibi.Click += new System.EventHandler(this.btnStokTakibi_Click);
            // 
            // FrmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 726);
            this.Controls.Add(this.btnStokTakibi);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnUrunIslemleri);
            this.Controls.Add(this.lblAltBaslik);
            this.Controls.Add(this.btnKategoriIslemleri);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAnaMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnKategoriIslemleri;
        private System.Windows.Forms.Label lblAltBaslik;
        private System.Windows.Forms.Button btnUrunIslemleri;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnStokTakibi;
    }
}