namespace WinFormsApp9
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblKitapAdi = new Label();
            lblYazarAdi = new Label();
            lblYayinevi = new Label();
            lblYayinYili = new Label();
            lblSayfaSayisi = new Label();
            lblDurum = new Label();
            lblKategori = new Label();
            lblArama = new Label();
            lblFiltre = new Label();
            lblToplam = new Label();
            lblDurumSayaci = new Label();
            txtKitapAdi = new TextBox();
            txtYazarAdi = new TextBox();
            txtYayinevi = new TextBox();
            txtYayinYili = new TextBox();
            txtSayfaSayisi = new TextBox();
            txtArama = new TextBox();
            cmbDurum = new ComboBox();
            cmbKategori = new ComboBox();
            cmbFiltre = new ComboBox();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnTemizle = new Button();
            btnAra = new Button();
            dgvKitaplar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).BeginInit();
            SuspendLayout();
            // 
            // lblKitapAdi
            // 
            lblKitapAdi.AutoSize = true;
            lblKitapAdi.Location = new Point(20, 20);
            lblKitapAdi.Name = "lblKitapAdi";
            lblKitapAdi.Size = new Size(58, 15);
            lblKitapAdi.TabIndex = 0;
            lblKitapAdi.Text = "Kitap Adı:";
            // 
            // lblYazarAdi
            // 
            lblYazarAdi.AutoSize = true;
            lblYazarAdi.Location = new Point(390, 20);
            lblYazarAdi.Name = "lblYazarAdi";
            lblYazarAdi.Size = new Size(58, 15);
            lblYazarAdi.TabIndex = 2;
            lblYazarAdi.Text = "Yazar Adı:";
            // 
            // lblYayinevi
            // 
            lblYayinevi.AutoSize = true;
            lblYayinevi.Location = new Point(20, 55);
            lblYayinevi.Name = "lblYayinevi";
            lblYayinevi.Size = new Size(53, 15);
            lblYayinevi.TabIndex = 4;
            lblYayinevi.Text = "Yayınevi:";
            // 
            // lblYayinYili
            // 
            lblYayinYili.AutoSize = true;
            lblYayinYili.Location = new Point(390, 55);
            lblYayinYili.Name = "lblYayinYili";
            lblYayinYili.Size = new Size(57, 15);
            lblYayinYili.TabIndex = 6;
            lblYayinYili.Text = "Yayın Yılı:";
            // 
            // lblSayfaSayisi
            // 
            lblSayfaSayisi.AutoSize = true;
            lblSayfaSayisi.Location = new Point(20, 90);
            lblSayfaSayisi.Name = "lblSayfaSayisi";
            lblSayfaSayisi.Size = new Size(70, 15);
            lblSayfaSayisi.TabIndex = 8;
            lblSayfaSayisi.Text = "Sayfa Sayısı:";
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(390, 90);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(47, 15);
            lblDurum.TabIndex = 10;
            lblDurum.Text = "Durum:";
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(20, 125);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(54, 15);
            lblKategori.TabIndex = 12;
            lblKategori.Text = "Kategori:";
            // 
            // lblArama
            // 
            lblArama.AutoSize = true;
            lblArama.Location = new Point(20, 213);
            lblArama.Name = "lblArama";
            lblArama.Size = new Size(45, 15);
            lblArama.TabIndex = 18;
            lblArama.Text = "Arama:";
            // 
            // lblFiltre
            // 
            lblFiltre.AutoSize = true;
            lblFiltre.Location = new Point(20, 248);
            lblFiltre.Name = "lblFiltre";
            lblFiltre.Size = new Size(36, 15);
            lblFiltre.TabIndex = 21;
            lblFiltre.Text = "Filtre:";
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblToplam.ForeColor = Color.FromArgb(52, 73, 94);
            lblToplam.Location = new Point(20, 590);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(114, 19);
            lblToplam.TabIndex = 24;
            lblToplam.Text = "Toplam Kitap: 0";
            // 
            // lblDurumSayaci
            // 
            lblDurumSayaci.AutoSize = true;
            lblDurumSayaci.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDurumSayaci.ForeColor = Color.FromArgb(52, 73, 94);
            lblDurumSayaci.Location = new Point(200, 590);
            lblDurumSayaci.Name = "lblDurumSayaci";
            lblDurumSayaci.Size = new Size(154, 19);
            lblDurumSayaci.TabIndex = 25;
            lblDurumSayaci.Text = "Mevcut: 0  |  Ödünç: 0";
            // 
            // txtKitapAdi
            // 
            txtKitapAdi.Location = new Point(120, 17);
            txtKitapAdi.Name = "txtKitapAdi";
            txtKitapAdi.Size = new Size(250, 23);
            txtKitapAdi.TabIndex = 1;
            // 
            // txtYazarAdi
            // 
            txtYazarAdi.Location = new Point(470, 17);
            txtYazarAdi.Name = "txtYazarAdi";
            txtYazarAdi.Size = new Size(250, 23);
            txtYazarAdi.TabIndex = 3;
            // 
            // txtYayinevi
            // 
            txtYayinevi.Location = new Point(120, 52);
            txtYayinevi.Name = "txtYayinevi";
            txtYayinevi.Size = new Size(250, 23);
            txtYayinevi.TabIndex = 5;
            // 
            // txtYayinYili
            // 
            txtYayinYili.Location = new Point(470, 52);
            txtYayinYili.Name = "txtYayinYili";
            txtYayinYili.Size = new Size(100, 23);
            txtYayinYili.TabIndex = 7;
            // 
            // txtSayfaSayisi
            // 
            txtSayfaSayisi.Location = new Point(120, 87);
            txtSayfaSayisi.Name = "txtSayfaSayisi";
            txtSayfaSayisi.Size = new Size(100, 23);
            txtSayfaSayisi.TabIndex = 9;
            // 
            // txtArama
            // 
            txtArama.Location = new Point(120, 210);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(320, 23);
            txtArama.TabIndex = 19;
            // 
            // cmbDurum
            // 
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.Items.AddRange(new object[] { "Mevcut", "Ödünç Verildi" });
            cmbDurum.Location = new Point(470, 87);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(150, 23);
            cmbDurum.TabIndex = 11;
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.Items.AddRange(new object[] { "Roman", "Bilim", "Tarih", "Şiir", "Çocuk", "Diğer" });
            cmbKategori.Location = new Point(120, 122);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(150, 23);
            cmbKategori.TabIndex = 13;
            // 
            // cmbFiltre
            // 
            cmbFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltre.Items.AddRange(new object[] { "Tümü", "Roman", "Bilim", "Tarih", "Şiir", "Çocuk", "Diğer" });
            cmbFiltre.Location = new Point(120, 245);
            cmbFiltre.Name = "cmbFiltre";
            cmbFiltre.Size = new Size(150, 23);
            cmbFiltre.TabIndex = 22;
            cmbFiltre.SelectedIndexChanged += cmbFiltre_SelectedIndexChanged;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.FromArgb(46, 204, 113);
            btnEkle.Cursor = Cursors.Hand;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(120, 160);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(100, 35);
            btnEkle.TabIndex = 14;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.FromArgb(52, 152, 219);
            btnGuncelle.Cursor = Cursors.Hand;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.Location = new Point(230, 160);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(100, 35);
            btnGuncelle.TabIndex = 15;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(231, 76, 60);
            btnSil.Cursor = Cursors.Hand;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(340, 160);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(100, 35);
            btnSil.TabIndex = 16;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.FromArgb(149, 165, 166);
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.ForeColor = Color.White;
            btnTemizle.Location = new Point(450, 160);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(100, 35);
            btnTemizle.TabIndex = 17;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.FromArgb(155, 89, 182);
            btnAra.Cursor = Cursors.Hand;
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.ForeColor = Color.White;
            btnAra.Location = new Point(450, 207);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(100, 29);
            btnAra.TabIndex = 20;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // dgvKitaplar
            // 
            dgvKitaplar.AllowUserToAddRows = false;
            dgvKitaplar.AllowUserToDeleteRows = false;
            dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKitaplar.BackgroundColor = Color.White;
            dgvKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKitaplar.Location = new Point(20, 280);
            dgvKitaplar.MultiSelect = false;
            dgvKitaplar.Name = "dgvKitaplar";
            dgvKitaplar.ReadOnly = true;
            dgvKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKitaplar.Size = new Size(740, 300);
            dgvKitaplar.TabIndex = 23;
            dgvKitaplar.CellClick += dgvKitaplar_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 625);
            Controls.Add(lblKitapAdi);
            Controls.Add(txtKitapAdi);
            Controls.Add(lblYazarAdi);
            Controls.Add(txtYazarAdi);
            Controls.Add(lblYayinevi);
            Controls.Add(txtYayinevi);
            Controls.Add(lblYayinYili);
            Controls.Add(txtYayinYili);
            Controls.Add(lblSayfaSayisi);
            Controls.Add(txtSayfaSayisi);
            Controls.Add(lblDurum);
            Controls.Add(cmbDurum);
            Controls.Add(lblKategori);
            Controls.Add(cmbKategori);
            Controls.Add(btnEkle);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnTemizle);
            Controls.Add(lblArama);
            Controls.Add(txtArama);
            Controls.Add(btnAra);
            Controls.Add(lblFiltre);
            Controls.Add(cmbFiltre);
            Controls.Add(dgvKitaplar);
            Controls.Add(lblToplam);
            Controls.Add(lblDurumSayaci);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kütüphane Otomasyonu";
            
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKitapAdi;
        private Label lblYazarAdi;
        private Label lblYayinevi;
        private Label lblYayinYili;
        private Label lblSayfaSayisi;
        private Label lblDurum;
        private Label lblKategori;
        private Label lblArama;
        private Label lblFiltre;
        private Label lblToplam;
        private Label lblDurumSayaci;
        private TextBox txtKitapAdi;
        private TextBox txtYazarAdi;
        private TextBox txtYayinevi;
        private TextBox txtYayinYili;
        private TextBox txtSayfaSayisi;
        private TextBox txtArama;
        private ComboBox cmbDurum;
        private ComboBox cmbKategori;
        private ComboBox cmbFiltre;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnTemizle;
        private Button btnAra;
        private DataGridView dgvKitaplar;
    }
}
