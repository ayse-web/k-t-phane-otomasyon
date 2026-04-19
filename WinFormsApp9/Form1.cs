using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            "Server=localhost;Database=KutuphaneDB;Integrated Security=True;TrustServerCertificate=True;";

        private int seciliKitapId = -1;

        public Form1()
        {
            InitializeComponent();
            cmbDurum.SelectedIndex = 0;
            cmbKategori.SelectedIndex = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                TabloOlustur();
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başlangıç hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabloOlustur()
        {
            try
            {
                using (var masterBaglanti = new SqlConnection(
                    "Server=localhost;Database=master;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    masterBaglanti.Open();
                    string dbSql = @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'KutuphaneDB')
                                     CREATE DATABASE KutuphaneDB";
                    using var dbKomut = new SqlCommand(dbSql, masterBaglanti);
                    dbKomut.ExecuteNonQuery();
                }

                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Kitaplar')
                    BEGIN
                        CREATE TABLE Kitaplar (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            KitapAdi NVARCHAR(200) NOT NULL,
                            YazarAdi NVARCHAR(200),
                            Yayinevi NVARCHAR(200),
                            YayinYili INT,
                            SayfaSayisi INT,
                            Kategori NVARCHAR(50) DEFAULT 'Diğer',
                            Durum NVARCHAR(50) DEFAULT 'Mevcut'
                        )
                    END
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'Kategori' AND Object_ID = Object_ID('Kitaplar'))
                        BEGIN
                            ALTER TABLE Kitaplar ADD Kategori NVARCHAR(50) DEFAULT 'Diğer'
                        END
                    END";

                using var komut = new SqlCommand(sql, baglanti);
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KitaplariListele()
        {
            try
            {
                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = "SELECT Id, KitapAdi AS [Kitap Adı], YazarAdi AS [Yazar Adı], " +
                             "Yayinevi AS [Yayınevi], YayinYili AS [Yayın Yılı], " +
                             "SayfaSayisi AS [Sayfa Sayısı], Kategori, Durum FROM Kitaplar";

                string secilenKategori = cmbFiltre.SelectedItem?.ToString() ?? "Tümü";
                bool filtreVar = secilenKategori != "Tümü";

                if (filtreVar)
                    sql += " WHERE Kategori = @Kategori";

                sql += " ORDER BY Id";

                using var adapter = new SqlDataAdapter(sql, baglanti);
                if (filtreVar)
                    adapter.SelectCommand.Parameters.AddWithValue("@Kategori", secilenKategori);

                var tablo = new DataTable();
                adapter.Fill(tablo);

                dgvKitaplar.DataSource = tablo;

                if (dgvKitaplar.Columns["Id"] != null)
                    dgvKitaplar.Columns["Id"]!.Visible = false;

                SatirlariRenklendir();
                SayaclariGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SatirlariRenklendir()
        {
            foreach (DataGridViewRow satir in dgvKitaplar.Rows)
            {
                string durum = satir.Cells["Durum"].Value?.ToString() ?? "";

                if (durum == "Ödünç Verildi")
                {
                    satir.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    satir.DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0);
                }
                else
                {
                    satir.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                    satir.DefaultCellStyle.ForeColor = Color.FromArgb(0, 100, 0);
                }
            }
        }

        private void SayaclariGuncelle()
        {
            try
            {
                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = "SELECT COUNT(*) FROM Kitaplar";
                using var komut = new SqlCommand(sql, baglanti);
                int toplam = (int)komut.ExecuteScalar();

                string mevcutSql = "SELECT COUNT(*) FROM Kitaplar WHERE Durum = 'Mevcut'";
                using var mevcutKomut = new SqlCommand(mevcutSql, baglanti);
                int mevcut = (int)mevcutKomut.ExecuteScalar();

                int odunc = toplam - mevcut;

                lblToplam.Text = "Toplam Kitap: " + toplam;
                lblDurumSayaci.Text = "Mevcut: " + mevcut + "  |  Ödünç: " + odunc;
            }
            catch
            {
                lblToplam.Text = "Toplam Kitap: 0";
                lblDurumSayaci.Text = "Mevcut: 0  |  Ödünç: 0";
            }
        }

        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            KitaplariListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKitapAdi.Text))
            {
                MessageBox.Show("Kitap adı boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = "INSERT INTO Kitaplar (KitapAdi, YazarAdi, Yayinevi, YayinYili, SayfaSayisi, Kategori, Durum) " +
                             "VALUES (@KitapAdi, @YazarAdi, @Yayinevi, @YayinYili, @SayfaSayisi, @Kategori, @Durum)";

                using var komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@KitapAdi", txtKitapAdi.Text.Trim());
                komut.Parameters.AddWithValue("@YazarAdi", txtYazarAdi.Text.Trim());
                komut.Parameters.AddWithValue("@Yayinevi", txtYayinevi.Text.Trim());
                komut.Parameters.AddWithValue("@YayinYili", int.TryParse(txtYayinYili.Text, out int yil) ? yil : (object)DBNull.Value);
                komut.Parameters.AddWithValue("@SayfaSayisi", int.TryParse(txtSayfaSayisi.Text, out int sayfa) ? sayfa : (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem?.ToString() ?? "Diğer");
                komut.Parameters.AddWithValue("@Durum", cmbDurum.SelectedItem?.ToString() ?? "Mevcut");

                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap başarıyla eklendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliKitapId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek kitabı tablodan seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKitapAdi.Text))
            {
                MessageBox.Show("Kitap adı boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = "UPDATE Kitaplar SET KitapAdi=@KitapAdi, YazarAdi=@YazarAdi, " +
                             "Yayinevi=@Yayinevi, YayinYili=@YayinYili, SayfaSayisi=@SayfaSayisi, " +
                             "Kategori=@Kategori, Durum=@Durum WHERE Id=@Id";

                using var komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@Id", seciliKitapId);
                komut.Parameters.AddWithValue("@KitapAdi", txtKitapAdi.Text.Trim());
                komut.Parameters.AddWithValue("@YazarAdi", txtYazarAdi.Text.Trim());
                komut.Parameters.AddWithValue("@Yayinevi", txtYayinevi.Text.Trim());
                komut.Parameters.AddWithValue("@YayinYili", int.TryParse(txtYayinYili.Text, out int yil) ? yil : (object)DBNull.Value);
                komut.Parameters.AddWithValue("@SayfaSayisi", int.TryParse(txtSayfaSayisi.Text, out int sayfa) ? sayfa : (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem?.ToString() ?? "Diğer");
                komut.Parameters.AddWithValue("@Durum", cmbDurum.SelectedItem?.ToString() ?? "Mevcut");

                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap başarıyla güncellendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliKitapId == -1)
            {
                MessageBox.Show("Lütfen silinecek kitabı tablodan seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sonuc = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc != DialogResult.Yes)
                return;

            try
            {
                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = "DELETE FROM Kitaplar WHERE Id=@Id";

                using var komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@Id", seciliKitapId);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap başarıyla silindi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aranan = txtArama.Text.Trim();

            if (string.IsNullOrWhiteSpace(aranan))
            {
                KitaplariListele();
                return;
            }

            try
            {
                using var baglanti = new SqlConnection(connectionString);
                baglanti.Open();

                string sql = "SELECT Id, KitapAdi AS [Kitap Adı], YazarAdi AS [Yazar Adı], " +
                             "Yayinevi AS [Yayınevi], YayinYili AS [Yayın Yılı], " +
                             "SayfaSayisi AS [Sayfa Sayısı], Kategori, Durum FROM Kitaplar " +
                             "WHERE KitapAdi LIKE @Aranan OR YazarAdi LIKE @Aranan OR Yayinevi LIKE @Aranan " +
                             "OR Kategori LIKE @Aranan " +
                             "ORDER BY Id";

                using var adapter = new SqlDataAdapter(sql, baglanti);
                adapter.SelectCommand.Parameters.AddWithValue("@Aranan", "%" + aranan + "%");

                var tablo = new DataTable();
                adapter.Fill(tablo);

                dgvKitaplar.DataSource = tablo;

                if (dgvKitaplar.Columns["Id"] != null)
                    dgvKitaplar.Columns["Id"]!.Visible = false;

                SatirlariRenklendir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            KitaplariListele();
        }

        private void dgvKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var satir = dgvKitaplar.Rows[e.RowIndex];

            seciliKitapId = Convert.ToInt32(satir.Cells["Id"].Value);
            txtKitapAdi.Text = satir.Cells["Kitap Adı"].Value?.ToString() ?? "";
            txtYazarAdi.Text = satir.Cells["Yazar Adı"].Value?.ToString() ?? "";
            txtYayinevi.Text = satir.Cells["Yayınevi"].Value?.ToString() ?? "";
            txtYayinYili.Text = satir.Cells["Yayın Yılı"].Value?.ToString() ?? "";
            txtSayfaSayisi.Text = satir.Cells["Sayfa Sayısı"].Value?.ToString() ?? "";

            string kategori = satir.Cells["Kategori"].Value?.ToString() ?? "Diğer";
            if (cmbKategori.Items.Contains(kategori))
                cmbKategori.SelectedItem = kategori;
            else
                cmbKategori.SelectedIndex = 0;

            string durum = satir.Cells["Durum"].Value?.ToString() ?? "Mevcut";
            cmbDurum.SelectedItem = durum;
        }

        private void Temizle()
        {
            txtKitapAdi.Text = "";
            txtYazarAdi.Text = "";
            txtYayinevi.Text = "";
            txtYayinYili.Text = "";
            txtSayfaSayisi.Text = "";
            txtArama.Text = "";
            cmbDurum.SelectedIndex = 0;
            cmbKategori.SelectedIndex = 0;
            seciliKitapId = -1;
        }
    }
}
