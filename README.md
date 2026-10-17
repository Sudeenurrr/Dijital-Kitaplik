# 📚 Dijital Kitaplık — Kütüphane Yönetim Uygulaması

C# **Windows Forms** ve **Microsoft SQL Server** ile geliştirilmiş bir masaüstü kütüphane uygulaması. Kullanıcılar kayıt olup giriş yapabilir; kitapları listeleyebilir, arayabilir, ödünç alıp teslim edebilir ve kütüphanede olmayan kitapları önerebilir.

Görsel Programlama dersi kapsamında geliştirilmiştir.

---

## ✨ Özellikler

**👤 Kullanıcı İşlemleri**
- Kullanıcı adı ve şifre ile **giriş yapma**
- Yeni hesap ile **kayıt olma**
- Kullanıcı adı ve şifre doğrulanarak **hesap silme**

**📖 Kitap İşlemleri**
- Tüm kitapları tablo hâlinde **listeleme**
- Kitap adına göre **arama**
- Kitabı **ödünç alma**: teslim tarihi otomatik olarak 7 gün sonrası belirlenir, zaten alınmış kitap tekrar ödünç alınamaz
- Ödünç alınan kitabı **teslim etme**
- Seçili kitabı onay alarak **silme**
- Aranan kitap bulunamazsa **yeni kitap önerme / ekleme** ekranına yönlendirme

---

## 🧭 Uygulama Akışı

```
Giriş Ekranı (Form1) ──── Kayıt Ol ────▶ Kayıt Ekranı (Form3)
        │                                      │
   Giriş Yap                          Kaydol / Ana Sayfa
        │                                      │
        ▼                                      ▼
Kitaplık Ekranı (Form2) ◀──────────── Giriş Ekranı'na dönüş
        │
  Aranan kitap bulunamazsa
        │
        ▼
Kitap Önerme Ekranı (Form4)
```

| Form | Görevi |
|---|---|
| `Form1` | Giriş ekranı: giriş yapma, kayıt ekranına geçiş, hesap silme |
| `Form2` | Ana kitaplık ekranı: listeleme, arama, ödünç alma, teslim etme, silme, çıkış |
| `Form3` | Kayıt ekranı: yeni kullanıcı oluşturma |
| `Form4` | Kitap önerme ekranı: kitap adı ve yazar ile yeni kitap ekleme |

---

## 🗄️ Veritabanı

Uygulama, SQL Server üzerinde **LibraryDB** adlı bir veritabanı kullanır. İki tablodan oluşur:

**Users** — Kullanıcı hesapları
| Sütun | Tür | Özellik |
|---|---|---|
| UserId | INT | Birincil anahtar, otomatik artan (IDENTITY) |
| Username | NVARCHAR(50) | Zorunlu, benzersiz (UNIQUE) |
| Password | NVARCHAR(50) | Zorunlu |

**Books** — Kitaplar
| Sütun | Tür | Özellik |
|---|---|---|
| BookId | INT | Birincil anahtar, otomatik artan (IDENTITY) |
| Title | NVARCHAR(100) | Kitap adı, zorunlu |
| Author | NVARCHAR(100) | Yazar |
| IsBorrowed | BIT | Ödünç alınma durumu, varsayılan `0` |
| BorrowedDate | DATETIME | Ödünç alınma tarihi |
| ReturnDate | DATETIME | Son teslim tarihi (ödünç alındıktan 7 gün sonra) |

**Örnek veriler:** Kurulum betiği aşağıdaki kitapları ve bir örnek kullanıcıyı (`admin` / `1234`) ekler:

| Kitap | Yazar |
|---|---|
| Kürk Mantolu Madonna | Sabahattin Ali |
| Tutunamayanlar | Oğuz Atay |
| Simyacı | Paulo Coelho |
| 1984 | George Orwell |
| Sefiller | Victor Hugo |

Kurulum betiği: [`database.sql`](database.sql)

**Uygulamanın kullandığı sorgular:**
| İşlem | Form | SQL |
|---|---|---|
| Giriş | Form1 | `SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p` |
| Hesap silme | Form1 | `DELETE FROM Users WHERE Username=@u AND Password=@p` |
| Kayıt | Form3 | `INSERT INTO Users (Username, Password) VALUES (@u, @p)` |
| Listeleme | Form2 | `SELECT * FROM Books` |
| Arama | Form2 | `SELECT * FROM Books WHERE Title LIKE @t` |
| Ödünç alma | Form2 | `UPDATE Books SET IsBorrowed=1, BorrowedDate=@b, ReturnDate=@r WHERE BookId=@id` |
| Teslim etme | Form2 | `UPDATE Books SET IsBorrowed=0, BorrowedDate=NULL, ReturnDate=NULL WHERE BookId=@id` |
| Kitap silme | Form2 | `DELETE FROM Books WHERE BookId=@id` |
| Kitap ekleme | Form4 | `INSERT INTO Books (Title, Author) VALUES (@t, @a)` |

Tüm sorgular **parametreli** yazılmıştır (SQL Injection'a karşı).

---

## 🛠️ Kullanılan Teknolojiler

- C# / .NET 8 (Windows Forms)
- Microsoft SQL Server Express
- ADO.NET (`System.Data.SqlClient`)
- Visual Studio 2022

---

## 📁 Proje Yapısı

```
Dijital-Kitaplik/
├── WinFormsApp6.sln              # Visual Studio çözüm dosyası
├── database.sql                  # Veritabanı kurulum betiği
└── WinFormsApp6/
    ├── Program.cs                # Uygulamanın başlangıç noktası
    ├── Form1.cs                  # Giriş ekranı
    ├── Form2.cs                  # Kitaplık ekranı
    ├── Form3.cs                  # Kayıt ekranı
    ├── Form4.cs                  # Kitap önerme ekranı
    ├── Properties/               # Kaynak (resource) ayarları
    ├── Resources/                # Arka plan görselleri
    └── WinFormsApp6.csproj       # Proje dosyası
```

---

## 🚀 Kurulum ve Çalıştırma

**Gereksinimler:** Windows, Visual Studio 2022 (".NET masaüstü geliştirme" iş yükü ile), SQL Server Express ve SQL Server Management Studio (SSMS)

**1. Projeyi indirin**

Bu sayfadaki yeşil **Code** butonu → **Download ZIP** ile indirip klasörü çıkarın.

**2. Veritabanını oluşturun**

SSMS'i açıp SQL Server'a bağlanın, `database.sql` dosyasını açın ve **Execute (F5)** ile çalıştırın. `LibraryDB` veritabanı, tablolar ve örnek veriler oluşturulur.

**3. Bağlantı adresini kendi bilgisayarınıza göre düzenleyin**

`Form1.cs`, `Form2.cs`, `Form3.cs` ve `Form4.cs` dosyalarındaki bağlantı satırında yer alan sunucu adını kendi SQL Server adınızla değiştirin:

```csharp
"Data Source=SUNUCU_ADINIZ\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True"
```

> Sunucu adınızı SSMS'e bağlanırken açılan pencerede **Server name** kutusunda görebilirsiniz.

**4. Çalıştırın**

`WinFormsApp6.sln` dosyasını Visual Studio ile açın ve **▶ Başlat (F5)** butonuna basın.

Örnek verilerle giriş yapmak için: kullanıcı adı `admin`, şifre `1234`
