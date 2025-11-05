# Profil

| Field | Keterangan |
|-------|-----------|
| **Nama** | Ridho fauzi |
| **NIM** | 312310563 |
| **Kelas** | TI.23.A.5 |
| **Mata Kuliah** | Pemrograman Visual |
| **Semester** | Ganjil 2024/2025 |


# 🧸 ToyStore - Online Toy Store System

<div align="center">

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![MongoDB](https://img.shields.io/badge/MongoDB-6.0+-47A248?style=for-the-badge&logo=mongodb&logoColor=white)](https://www.mongodb.com/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)

**E-Commerce Platform untuk Toko Mainan Online**

[Features](#-features) • [Tech Stack](#-tech-stack) • [Installation](#-installation) • [Usage](#-usage) • [Project Structure](#-project-structure)

</div>

---

## 🎮 Tentang Project

**ToyStore** adalah aplikasi web e-commerce berbasis ASP.NET Core MVC yang memungkinkan customer untuk berbelanja mainan secara online dan admin untuk mengelola inventori, pesanan, dan user dengan mudah. Sistem ini menggunakan MongoDB sebagai database dan menerapkan session-based authentication untuk keamanan.

### 🎯 Tujuan Project

- Menyediakan platform online untuk transaksi jual-beli mainan
- Memudahkan customer dalam mencari dan membeli mainan
- Memberikan admin tools untuk mengelola toko secara efisien
- Implementasi best practices dalam web development

---

## ✨ Features

### 👤 Customer Features

- **Authentication**
  - Register akun baru dengan validasi email
  - Login/Logout dengan session management
  - Password hashing untuk keamanan

- **Shopping Experience**
  - Browse katalog mainan dengan detail lengkap
  - View detail produk (name, brand, price, description, stock)
  - Add to cart dengan quantity selection
  - Update/remove items dari cart
  - Real-time cart total calculation

- **Order Management**
  - Checkout dengan input alamat pengiriman
  - Order confirmation dengan order number
  - Track order status (Pending, Processing, Shipped, Delivered)
  - View order history lengkap

### 🔧 Admin Features

- **Dashboard**
  - Overview statistik toko
  - Quick access ke management features

- **Toy Management (CRUD)**
  - Create: Tambah mainan baru dengan upload image
  - Read: View semua mainan dengan filter & search
  - Update: Edit detail mainan existing
  - Delete: Soft delete untuk maintain data integrity

- **Order Management**
  - View semua order dari customer
  - Filter order by status, date, customer
  - Update order status (Processing, Shipped, Delivered, Cancelled)
  - View detail order lengkap

- **User Management**
  - View semua user (Admin & Customer)
  - Manage user roles
  - Activate/Deactivate user accounts

---

## 🛠️ Tech Stack

| Layer | Technology | Version |
|-------|------------|---------|
| **Backend Framework** | ASP.NET Core MVC | 9.0 |
| **Database** | MongoDB | 6.0+ |
| **Frontend** | Razor Pages + Bootstrap | 5.3 |
| **Authentication** | Session-based | Built-in |
| **Language** | C# | 12.0 |
| **Password Hashing** | BCrypt | - |

---

## 📦 Installation

### Prerequisites

Pastikan sudah terinstall:
- [.NET SDK 9.0](https://dotnet.microsoft.com/download)
- [MongoDB Community Server](https://www.mongodb.com/try/download/community)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) atau [VS Code](https://code.visualstudio.com/)

### Setup Steps

1. **Clone repository**
   ```bash
   git clone <repository-url>
   cd ToyStore
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure MongoDB Connection**
   
   Edit `appsettings.json`:
   ```json
   {
     "MongoDB": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "ToyStoreDB"
     }
   }
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the application**
   
   Open browser: `https://localhost:5001` atau `http://localhost:5000`

---

## 🚀 Usage

### First Time Setup

1. **Create Admin Account**
   - Register akun baru
   - Manually update role di MongoDB:
     ```javascript
     db.users.updateOne(
       { email: "admin@example.com" },
       { $set: { role: "Admin" } }
     )
     ```

2. **Add Sample Toys**
   - Login sebagai Admin
   - Navigate ke "Kelola Mainan"
   - Tambah mainan dengan detail lengkap

### Customer Flow

1. Register/Login
2. Browse katalog mainan
3. Add items ke cart
4. Checkout dengan alamat pengiriman
5. Track order di "My Orders"

### Admin Flow

1. Login sebagai Admin
2. Manage toys (CRUD operations)
3. Process orders (update status)
4. Manage users

---

## 📁 Project Structure

```
ToyStore/
├── Controllers/
│   ├── AccountController.cs      # Authentication logic
│   ├── AdminController.cs         # Admin dashboard & management
│   ├── ToysController.cs          # Toy CRUD operations
│   ├── CustomerController.cs      # Customer features
│   └── HomeController.cs          # Landing page
├── Models/
│   ├── Toy.cs                     # Toy entity
│   ├── Cart.cs                    # Shopping cart model
│   ├── Order.cs                   # Order & OrderItem entities
│   └── User.cs                    # User entity
├── Services/
│   └── MongoDBService.cs          # MongoDB connection & collections
├── Views/
│   ├── Account/                   # Login, Register views
│   ├── Admin/                     # Admin management views
│   ├── Customer/                  # Customer dashboard views
│   ├── Home/                      # Public views
│   └── Shared/                    # Layout & partials
├── wwwroot/
│   ├── css/                       # Stylesheets
│   ├── js/                        # JavaScript files
│   └── images/                    # Static images
├── appsettings.json               # Configuration
├── Program.cs                     # Application entry point
└── ToyStore.csproj                # Project file
```

---

## 🗄️ Database Schema

### Collections

#### **users**
```json
{
  "_id": ObjectId,
  "username": String,
  "email": String (unique),
  "password": String (hashed),
  "role": String ("Admin" | "Customer"),
  "fullName": String,
  "phoneNumber": String,
  "address": String,
  "createdAt": DateTime
}
```

#### **toys**
```json
{
  "_id": ObjectId,
  "name": String,
  "brand": String,
  "category": String,
  "ageRange": String,
  "price": Decimal,
  "stock": Integer,
  "description": String,
  "imageUrl": String,
  "createdAt": DateTime
}
```

#### **orders**
```json
{
  "_id": ObjectId,
  "customerId": ObjectId,
  "items": [
    {
      "toyId": ObjectId,
      "toyName": String,
      "quantity": Integer,
      "price": Decimal
    }
  ],
  "totalAmount": Decimal,
  "status": String ("Pending" | "Processing" | "Shipped" | "Delivered" | "Cancelled"),
  "shippingAddress": String,
  "orderDate": DateTime
}
```

---

## 🔐 Security Features

- **Password Hashing**: BCrypt algorithm untuk hash password
- **Session Management**: Session-based authentication dengan timeout 30 menit
- **Role-Based Access**: Admin dan Customer memiliki akses berbeda
- **Input Validation**: Server-side validation untuk semua form input
- **SQL Injection Prevention**: MongoDB driver dengan parameterized queries

---

## 🧪 Testing

### Manual Testing Checklist

**Authentication:**
- [ ] Register dengan email valid
- [ ] Register dengan email duplicate (should fail)
- [ ] Login dengan credentials benar
- [ ] Login dengan credentials salah (should fail)
- [ ] Logout dan session cleared

**Customer Features:**
- [ ] Browse katalog mainan
- [ ] View detail produk
- [ ] Add to cart
- [ ] Update quantity di cart
- [ ] Remove item dari cart
- [ ] Checkout dengan alamat valid
- [ ] View order history

**Admin Features:**
- [ ] Create mainan baru
- [ ] Edit mainan existing
- [ ] Delete mainan
- [ ] View semua orders
- [ ] Update order status
- [ ] View user list

---

## 🐛 Known Issues & Limitations

- Image upload belum ada size validation
- Search & filter di katalog masih basic
- Email notification belum diimplementasi
- Payment gateway belum terintegrasi
- Stock management belum otomatis update saat order

---

## 🚧 Future Improvements

- [ ] Implement email notifications untuk order updates
- [ ] Add payment gateway integration (Midtrans, etc.)
- [ ] Advanced search & filter (by category, age range, brand, price)
- [ ] Product reviews & ratings
- [ ] Wishlist feature
- [ ] Automatic stock update saat order completed
- [ ] Admin analytics dashboard dengan charts
- [ ] Export order reports (PDF, Excel)
- [ ] Multi-language support
- [ ] Toy recommendations based on age

---

## 📝 License

This project is for educational purposes.

---

## 👨‍💻 Developer

Developed with ❤️ using ASP.NET Core & MongoDB

---

## 📞 Support

Jika ada pertanyaan atau issue, silakan buat issue di repository ini.

---

<div align="center">

**Happy Coding! 🚀**

</div>
