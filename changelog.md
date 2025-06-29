# 📦 Changelog – Sistem Manajemen Perpustakaan Internal

---

## [v1.0.0] – 2025-06-29

🎉 Initial internal release

### 🚀 Core System

- Inisialisasi project dengan ASP.NET Core 9 + EF Core + SQLite
- Penerapan clean architecture (Domain, Application, Infrastructure, Web)
- Dependency Injection aktif untuk semua service dan repository
- Setup Entity Framework Core, migrasi awal, dan integrasi database

---

### 📚 Modul Buku

- CRUD lengkap untuk Book, Author, dan Category
- Validasi relasi antar entitas (Book ↔ Author, Book ↔ Category)
- Fitur update buku: termasuk penggantian author dan kategori
- Penanganan update stock buku saat transaksi

---

### 👤 Modul User

- Model `User` dilengkapi `Email`, `PasswordHash`, `Role`, `IsActive`, dan `CreatedAt`
- Enum `Role` untuk membedakan `Admin` dan `Member`
- Penggunaan `IPasswordHasher<T>` untuk menyimpan password secara aman
- CRUD user dengan validasi dan hashing otomatis
- Serialisasi enum diperbaiki menggunakan `JsonStringEnumConverter`

---

### 🔐 Autentikasi

- Endpoint: `POST /api/auth/login`
- Verifikasi password melalui hash
- Login response berisi `Token`, `UserId`, `Email`, dan `Role`
- Token bersifat dummy (versi stateless) dan siap diintegrasi dengan JWT ke depannya
- Role-aware: fondasi sistem autorisasi berdasarkan peran sudah siap

---

### 📦 Sistem Peminjaman

- Model `Loan` dan `LoanDetail` menyimpan banyak buku dalam satu transaksi
- Penambahan properti:
  - `DueDate`, `LoanDate`, `ReturnDate`, `IsReturned`
- Validasi peminjaman:
  - Verifikasi stok buku
  - Otomatis mengurangi jumlah stok saat pinjam
- Endpoint `POST /api/loans` untuk memproses peminjaman berhasil diuji
- Endpoint `GET /api/loans` dan `GET /api/loans/{id}` untuk melihat histori peminjaman

---

### 🔁 Fitur Pengembalian

- Endpoint: `PUT /api/loans/{id}/return`
- Menandai `Loan` sebagai dikembalikan (`IsReturned = true`)
- Mengisi `ReturnDate` otomatis
- Stok buku dikembalikan sesuai jumlah di `LoanDetail`
- Validasi pengembalian ganda (tidak bisa return dua kali)

---

### 🛠️ Debugging & Refleksi

- Perbaikan error enum binding pada model `User`
- Penanganan `404` akibat tidak menyertakan `[ApiController]`
- Validasi `PUT` memerlukan `id` dalam body JSON
- Troubleshooting SQLite `table already exists` saat migrasi ulang
- Refleksi pentingnya ketelitian saat coding lebih dari 4 jam 🧠

---

### 📎 Infrastruktur

- Registrasi semua service & repository melalui DI container
- Struktur folder modular untuk scalability jangka panjang
- Open API endpoint untuk semua modul internal (non-authenticated)

---

📝 Catatan:
Versi ini merupakan fondasi stabil untuk penggunaan internal oleh pustakawan. Modul `Member`, reservasi buku, dan integrasi frontend (Nuxt/Blazor) akan dikembangkan di versi mendatang.
