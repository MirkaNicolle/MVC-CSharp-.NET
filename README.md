
# 📝 Guía completa - Crear un CRUD en ASP.NET Core MVC con SQL Server y EF Core (VS Code)

---

## 🎒 Herramientas necesarias

- ✅ [.NET SDK 8.x o superior](https://dotnet.microsoft.com/en-us/download/dotnet)
- ✅ [Visual Studio Code](https://code.visualstudio.com/)
- ✅ Extensiones para VS Code:
  - C#
  - C# Dev Kit (opcional)
- ✅ [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (motor de base de datos)
- ✅ [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (cliente para ver la base de datos)

---

## 🚀 Pasos que seguí

---

### 1️⃣ Crear el proyecto ASP.NET Core MVC

```bash
dotnet new mvc -n MiProyectoWeb
cd MiProyectoWeb
```

---

### 2️⃣ Agregar paquetes necesarios

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

### 3️⃣ Configurar la conexión a la base de datos

`appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MiBaseDeDatos;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

### 4️⃣ Crear el DbContext

`Data/AppDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using MiProyectoWeb.Models;

namespace MiProyectoWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
```

---

### 5️⃣ Registrar DbContext en Program.cs

```csharp
builder.Services.AddDbContext<MiProyectoWeb.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

### 6️⃣ Crear la entidad (modelo)

`Models/Producto.cs`:

```csharp
namespace MiProyectoWeb.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
```

---

### 7️⃣ Crear la migración e inicializar la base de datos

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 8️⃣ Crear el controlador y las vistas (CRUD)

Crear `Controllers/ProductosController.cs` con acciones para:

- Index
- Create
- Edit
- Delete
- Details

Crear las vistas correspondientes en `Views/Productos/`:

- `Index.cshtml`
- `Create.cshtml`
- `Edit.cshtml`
- `Delete.cshtml`
- `Details.cshtml`

---

### 9️⃣ Modificar la barra de navegación

Editar `Views/Shared/_Layout.cshtml`:

```html
<ul class="navbar-nav flex-grow-1">
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Productos" asp-action="Index">Productos</a>
    </li>
</ul>
```

---

### 10️⃣ Correr la aplicación

```bash
dotnet run
```

Abrir en el navegador: `http://localhost:xxxx`

---

## 📁 Estructura de carpetas

```
MiProyectoWeb
├── Controllers
│   └── ProductosController.cs
├── Data
│   └── AppDbContext.cs
├── Models
│   └── Producto.cs
├── Views
│   ├── Shared
│   │   └── _Layout.cshtml
│   ├── Productos
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
├── appsettings.json
├── Program.cs
└── ...
```

---

## 📚 Resumen de las partes del proyecto

- **Controllers** → Controla la lógica de la aplicación (CRUD).
- **Models** → Define las entidades que representan la base de datos.
- **Data/AppDbContext** → Maneja la conexión a la base de datos y las tablas.
- **Views** → Interfaz de usuario (HTML generado dinámicamente con Razor).
- **Program.cs** → Configura los servicios (incluye el DbContext).
- **appsettings.json** → Configuración de la conexión a SQL Server.

---

✅ ¡Con esto ya tienes un CRUD completo funcionando! 🎉
