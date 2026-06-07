namespace StokTakipSistemi
{
    partial class FrmStokTakibi
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
            this.dgvStoklar = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTumUrunler = new System.Windows.Forms.Button();
            this.btnKritikStok = new System.Windows.Forms.Button();
            this.btnStoktaVar = new System.Windows.Forms.Button();
            this.btnKapan = new System.Windows.Forms.Button();
            this.lblToplamUrun = new System.Windows.Forms.Label();
            this.lblKritikUrun = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(26, 32);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(228, 48);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Stok Takibi";
            // 
            // dgvStoklar
            // 
            this.dgvStoklar.AllowUserToAddRows = false;
            this.dgvStoklar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStoklar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoklar.Location = new System.Drawing.Point(477, 105);
            this.dgvStoklar.MultiSelect = false;
            this.dgvStoklar.Name = "dgvStoklar";
            this.dgvStoklar.ReadOnly = true;
            this.dgvStoklar.RowHeadersWidth = 51;
            this.dgvStoklar.RowTemplate.Height = 24;
            this.dgvStoklar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStoklar.Size = new System.Drawing.Size(915, 624);
            this.dgvStoklar.TabIndex = 1;
            this.dgvStoklar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStoklar_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblKritikUrun);
            this.groupBox1.Controls.Add(this.lblToplamUrun);
            this.groupBox1.Controls.Add(this.btnKapan);
            this.groupBox1.Controls.Add(this.btnStoktaVar);
            this.groupBox1.Controls.Add(this.btnKritikStok);
            this.groupBox1.Controls.Add(this.btnTumUrunler);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 624);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnTumUrunler
            // 
            this.btnTumUrunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumUrunler.Location = new System.Drawing.Point(6, 46);
            this.btnTumUrunler.Name = "btnTumUrunler";
            this.btnTumUrunler.Size = new System.Drawing.Size(286, 54);
            this.btnTumUrunler.TabIndex = 0;
            this.btnTumUrunler.Text = "Tüm Ürünler";
            this.btnTumUrunler.UseVisualStyleBackColor = true;
            this.btnTumUrunler.Click += new System.EventHandler(this.btnTumUrunler_Click);
            // 
            // btnKritikStok
            // 
            this.btnKritikStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKritikStok.Location = new System.Drawing.Point(6, 125);
            this.btnKritikStok.Name = "btnKritikStok";
            this.btnKritikStok.Size = new System.Drawing.Size(286, 54);
            this.btnKritikStok.TabIndex = 1;
            this.btnKritikStok.Text = "Kritik Stoktakiler";
            this.btnKritikStok.UseVisualStyleBackColor = true;
            this.btnKritikStok.Click += new System.EventHandler(this.btnKritikStok_Click);
            // 
            // btnStoktaVar
            // 
            this.btnStoktaVar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStoktaVar.Location = new System.Drawing.Point(6, 217);
            this.btnStoktaVar.Name = "btnStoktaVar";
            this.btnStoktaVar.Size = new System.Drawing.Size(286, 54);
            this.btnStoktaVar.TabIndex = 2;
            this.btnStoktaVar.Text = "Stokta Olanlar";
            this.btnStoktaVar.UseVisualStyleBackColor = true;
            this.btnStoktaVar.Click += new System.EventHandler(this.btnStoktaVar_Click);
            // 
            // btnKapan
            // 
            this.btnKapan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKapan.Location = new System.Drawing.Point(6, 301);
            this.btnKapan.Name = "btnKapan";
            this.btnKapan.Size = new System.Drawing.Size(286, 54);
            this.btnKapan.TabIndex = 3;
            this.btnKapan.Text = "Kapat";
            this.btnKapan.UseVisualStyleBackColor = true;
            this.btnKapan.Click += new System.EventHandler(this.btnKapan_Click);
            // 
            // lblToplamUrun
            // 
            this.lblToplamUrun.AutoSize = true;
            this.lblToplamUrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamUrun.Location = new System.Drawing.Point(14, 381);
            this.lblToplamUrun.Name = "lblToplamUrun";
            this.lblToplamUrun.Size = new System.Drawing.Size(251, 39);
            this.lblToplamUrun.TabIndex = 3;
            this.lblToplamUrun.Text = "Toplam Ürün: 0";
            // 
            // lblKritikUrun
            // 
            this.lblKritikUrun.AutoSize = true;
            this.lblKritikUrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKritikUrun.Location = new System.Drawing.Point(14, 450);
            this.lblKritikUrun.Name = "lblKritikUrun";
            this.lblKritikUrun.Size = new System.Drawing.Size(207, 39);
            this.lblKritikUrun.TabIndex = 4;
            this.lblKritikUrun.Text = "Kritik Stok: 0";
            // 
            // FrmStokTakibi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 741);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvStoklar);
            this.Controls.Add(this.lblBaslik);
            this.MaximizeBox = false;
            this.Name = "FrmStokTakibi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takibi";
            this.Load += new System.EventHandler(this.FrmStokTakibi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.DataGridView dgvStoklar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblKritikUrun;
        private System.Windows.Forms.Label lblToplamUrun;
        private System.Windows.Forms.Button btnKapan;
        private System.Windows.Forms.Button btnStoktaVar;
        private System.Windows.Forms.Button btnKritikStok;
        private System.Windows.Forms.Button btnTumUrunler;
    }
}