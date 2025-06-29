# 📚 Sistem Manajemen Perpustakaan – Internal v1.0.0

Proyek ini adalah aplikasi backend manajemen perpustakaan internal yang dibangun menggunakan ASP.NET Core dan Entity Framework Core. Aplikasi ini memungkinkan admin untuk mengelola koleksi buku, penulis, kategori, pengguna, serta mencatat proses peminjaman dan pengembalian buku.

---

## 🚀 Fitur Utama

- 🔐 Login admin dengan verifikasi hash password
- 👤 Manajemen user & peran (Admin / Member-ready)
- 📚 CRUD lengkap untuk Buku, Penulis, dan Kategori
- 🔄 Peminjaman buku dengan validasi stok otomatis
- 🔙 Pengembalian buku dengan restore stok dan pencatatan waktu
- 📅 Tracking tanggal jatuh tempo (`DueDate`) dan histori peminjaman
- 🧱 Arsitektur modular berbasis Clean Architecture
- 🛠️ Kode terstruktur, rapi, dan scalable

---

## 🛠️ Teknologi

- ✅ ASP.NET Core 9
- ✅ Entity Framework Core + SQLite
- ✅ Clean Architecture Pattern
- ✅ Dependency Injection
- ✅ JSON Enum Serialization
- ✅ RESTful API

---

## 📂 Struktur Proyek

├── Domain
│ └── Entities, Enums, Interfaces
├── Application
│ └── DTOs, Services, Validation Logic
├── Infrastructure
│ └── EF Core DBContext, Repositories
├── Web
│ └── Controllers, Program.cs, Middleware

---

## 📦 Persyaratan Sistem

Untuk menjalankan proyek ini secara lokal, berikut persyaratan minimum yang disarankan:

| Komponen            | Versi Minimum                   |
| ------------------- | ------------------------------- |
| .NET SDK            | .NET 9.0+                       |
| OS                  | Windows 10 / macOS / Linux      |
| IDE/Editor          | Visual Studio 2022+ / VS Code   |
| Database            | SQLite (disertakan via EF Core) |
| EF Tools (opsional) | `dotnet-ef` CLI                 |

### 🔧 Instalasi Tools

- Unduh .NET SDK: https://dotnet.microsoft.com/en-us/download
- (Opsional) Instal `dotnet ef` CLI:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## 📦 Cara Menjalankan

1. Clone repositori:

```bash
git clone https://github.com/mrakahaikal/LibraryApi.git
cd LibraryApi
```

2. Buat database lokal:

```bash
dotnet ef database update
```

3. Jalankan aplikasi

```bash
dotnet run
```

> Secara default aplikasi jalan di https://localhost:5000 atau http://localhost:5246

## 🔐 Endpoint Penting

| Endpoint                     | Deskripsi           |
| ---------------------------- | ------------------- |
| POST `/api/auth/login`       | Login admin         |
| GET `/api/books`             | Lihat semua buku    |
| POST `/api/users`            | Tambah user (Admin) |
| POST `/api/loans`            | Peminjaman buku     |
| PUT `/api/loans/{id}/return` | Kembalikan buku     |

## 🗂️ Rencana Pengembangan

Fitur lanjutan yang direncanakan untuk versi mendatang:

- 🔑 Autentikasi JWT + Role-based Authorization

- 👥 Dashboard pengguna (member): pinjam, histori, keterlambatan

- 📨 Fitur notifikasi keterlambatan atau siap ambil

- 🧾 Laporan statistik koleksi & sirkulasi

## 📄 Lisensi

Proyek ini dilisensikan di bawah MIT License. Silakan gunakan dan modifikasi sesuai kebutuhan.
