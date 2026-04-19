==================================================
   KÜTÜPHANE OTOMASYON SİSTEMİ
==================================================

C# Windows Forms (.NET 9) ve Microsoft SQL Server kullanılarak
geliştirilmiş basit bir kütüphane yönetim uygulamasıdır.
Uygulama ilk çalıştırıldığında gerekli veritabanını ve tabloyu
otomatik olarak oluşturur.


--------------------------------------------------
ÖZELLİKLER
--------------------------------------------------
- Kitap ekleme, güncelleme ve silme (CRUD)
- Kitap adı, yazar, yayınevi ve kategoriye göre arama
- Kategoriye göre filtreleme
- "Mevcut" / "Ödünç Verildi" durum takibi
- Durum bazlı satır renklendirmesi (yeşil / kırmızı)
- Toplam, mevcut ve ödünç verilen kitap sayaçları
- Uygulama ilk açılışta veritabanını (KutuphaneDB)
  ve Kitaplar tablosunu otomatik oluşturur


--------------------------------------------------
KULLANILAN TEKNOLOJİLER
--------------------------------------------------
- C# / .NET 9 (net9.0-windows)
- Windows Forms
- Microsoft SQL Server
- Microsoft.Data.SqlClient 5.2.2


--------------------------------------------------
GEREKSİNİMLER
--------------------------------------------------
- Windows 10 / 11
- .NET 9 SDK
- SQL Server (LocalDB veya Express uygundur)
- Visual Studio 2022 (veya üstü) - önerilir


--------------------------------------------------
KURULUM
--------------------------------------------------
1) Depoyu klonlayın veya indirin:
   git clone https://github.com/<kullanici-adi>/kutuphane-otomasyon.git

2) Projeyi Visual Studio ile açın:
   WinFormsApp9.sln

3) Form1.cs dosyasındaki bağlantı cümlesini kendi
   SQL Server kurulumunuza göre düzenleyin:

   Server=localhost;Database=KutuphaneDB;Integrated Security=True;TrustServerCertificate=True;

4) Projeyi derleyip çalıştırın (F5).
   İlk çalıştırmada KutuphaneDB veritabanı ve
   Kitaplar tablosu otomatik oluşturulur.


--------------------------------------------------
VERİTABANI ŞEMASI (Kitaplar)
--------------------------------------------------
Id            INT, PRIMARY KEY, IDENTITY
KitapAdi      NVARCHAR(200), NOT NULL
YazarAdi      NVARCHAR(200)
Yayinevi      NVARCHAR(200)
YayinYili     INT
SayfaSayisi   INT
Kategori      NVARCHAR(50), DEFAULT 'Diğer'
Durum         NVARCHAR(50), DEFAULT 'Mevcut'


--------------------------------------------------
KULLANIM
--------------------------------------------------
- Kitap Ekle : Formu doldurup "Ekle" butonuna basın.
- Güncelle   : Tablodan bir kitap seçin, bilgileri
               düzenleyip "Güncelle" butonuna basın.
- Sil        : Tablodan bir kitap seçin ve "Sil" butonuna
               basarak onaylayın.
- Ara        : Arama kutusuna kelime yazıp "Ara" butonuna
               basın (kitap adı, yazar, yayınevi veya
               kategori üzerinde arar).
- Filtrele   : Kategori seçerek listeyi filtreleyin.


--------------------------------------------------
PROJE YAPISI
--------------------------------------------------
kutuphane-otomasyon/
├── WinFormsApp9.sln
└── WinFormsApp9/
    ├── Form1.cs              (uygulama mantığı)
    ├── Form1.Designer.cs     (arayüz tasarımı)
    ├── Form1.resx
    ├── Program.cs
    └── WinFormsApp9.csproj


--------------------------------------------------
LİSANS
--------------------------------------------------
Bu proje eğitim amaçlı geliştirilmiştir.
Dilediğiniz gibi kullanabilir ve geliştirebilirsiniz.
