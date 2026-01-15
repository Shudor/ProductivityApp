# ProductivityApp

Personal Productivity web application built with ASP.NET Core MVC.
The app allows users to manage tasks and track daily productivity while demonstrating clean MVC architecture, Entity Framework Core, and Git best practices.

---

✨ Features

* ✅ Create, edit, delete tasks (CRUD)
* 📅 Due dates and task status (Pending / Done)
* 🗂️ Clean MVC structure (Models, Views, Controllers)
* 🗄️ SQLite database with Entity Framework Core
* 🔐 Ready for future authentication & extensions

---

🛠️ Tech Stack

* **C#**
* **ASP.NET Core MVC** (.NET 7/8)
* **Entity Framework Core**
* **SQLite**
* **Razor Views**
* **Bootstrap**

---

📂 Project Structure

```
ProductivityApp
│
├── Controllers
│   └── TasksController.cs
├── Models
│   └── TaskItem.cs
├── Data
│   └── AppDbContext.cs
├── Views
│   └── Tasks
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       └── Delete.cshtml
├── Migrations
├── wwwroot
└── Program.cs
```

---

▶️ Getting Started

Prerequisites

* .NET SDK 7 or 8
* Visual Studio 2022

Run Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/Shudor/ProductivityApp.git
   ```

2. Open the solution in **Visual Studio**

3. Restore NuGet packages

4. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application (F5)

6. Open in browser:

   ```
   https://localhost:xxxx/Tasks
   ```

---

🧠 What I Practiced

* ASP.NET Core MVC fundamentals
* Entity Framework Core & migrations
* Dependency Injection
* Razor syntax & model binding
* Git & GitHub workflow

---

🚀 Future Improvements

* Habit tracker with streak counter
* Dashboard view (Today / This Week)
* User authentication (ASP.NET Identity)
* REST API + frontend (React / Blazor)
* UI/UX improvements

---

📸 Screenshots

*(Add screenshots here once UI is polished)*

---

📄 License

This project is licensed under the **MIT License**.

---

👤 Author

Built as a learning & portfolio project to refresh C# and ASP.NET Core skills.

---

⭐ If you find this project useful, feel free to star the repository!
