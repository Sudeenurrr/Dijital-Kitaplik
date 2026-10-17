-- =============================================
-- Dijital Kitaplık - Veritabanı Kurulum Betiği
-- SQL Server Management Studio'da açıp çalıştırın (Execute / F5)
-- =============================================

CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

-- Kullanıcılar
CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

-- Kitaplar
CREATE TABLE Books (
    BookId INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100),
    IsBorrowed BIT DEFAULT 0,
    BorrowedDate DATETIME,
    ReturnDate DATETIME
);
GO

-- Örnek kullanıcı (giriş için: admin / 1234)
INSERT INTO Users (Username, Password)
VALUES ('admin', '1234');

-- Örnek kitaplar
INSERT INTO Books (Title, Author)
VALUES
('Kürk Mantolu Madonna', 'Sabahattin Ali'),
('Tutunamayanlar', 'Oğuz Atay'),
('Simyacı', 'Paulo Coelho'),
('1984', 'George Orwell'),
('Sefiller', 'Victor Hugo');
GO
