# 🕒 Sistema de Registro de Horas Extra - Backend

Este es el backend del sistema de registro de horas extra de la empresa **Amadeus**, desarrollado por el **Grupo 5**. El proyecto está construido utilizando **C#** y sigue una arquitectura modular para facilitar su mantenimiento y escalabilidad.

## 📂 Estructura del Proyecto

El repositorio está organizado de la siguiente manera:

- `ExtraHours.API/`: Contiene la implementación de la API que expone los endpoints para interactuar con el sistema.
- `ExtraHours.CORE/`: Incluye las entidades y lógica de negocio fundamentales del sistema.
- `ExtraHours.Infrastructure/`: Gestiona la comunicación con la base de datos y otras infraestructuras externas.
- `ExtraHours.Test/`: Contiene las pruebas unitarias y de integración para garantizar la calidad del código.
- `ExtraHourGroup5.sln`: Archivo de solución que agrupa todos los proyectos mencionados anteriormente.

## 🛠️ Requisitos Previos

- [Visual Studio](https://visualstudio.microsoft.com/) (versión recomendada: 2022 o superior)
- [.NET SDK](https://dotnet.microsoft.com/download) (versión 6.0 o superior)
- [PostgreSQL](https://www.postgresql.org)

## 🚀 Instalación y Configuración

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/Teo1188/BackEnd-Grupo5.git
   ```

2. Abrir la solución en Visual Studio:

Navega al directorio del proyecto y abre el archivo ExtraHourGroup5.sln.

3. Configurar la cadena de conexión:

En el proyecto ExtraHours.API, localiza el archivo appsettings.json y actualiza la cadena de conexión para que coincida con tu configuración de base de datos:

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
}
```
4. Aplicar las migraciones de la base de datos:

Abre la Consola del Administrador de Paquetes en Visual Studio y ejecuta:

```bash
Update-Database
```
Esto creará las tablas necesarias en la base de datos especificada.

5. Ejecutar la aplicación:

Establece ExtraHours.API como el proyecto de inicio y ejecuta la aplicación. La API estará disponible en "https://localhost:5001->puerto asignado" + /swagger

6. ## 📁 Estructura del Proyecto

```bash
BackEnd-Grupo5/ ├── ExtraHourGroup5.sln # Archivo de solución principal │
                ├── ExtraHours.API/ # Proyecto principal de la API │
                ├── Controllers/ # Controladores de la API │
                ├── Models/ # Modelos de datos (DTOs, requests, responses) │
                ├── Program.cs # Punto de entrada principal │
                ├── appsettings.json # Configuración general y cadenas de conexión │
                └── Startup.cs # Configuración de servicios y middlewares │
                ├── ExtraHours.CORE/ # Lógica de negocio y entidades del dominio │
                ├── Entities/ # Entidades principales (Ej: Usuario, HorasExtras) │
                └── Interfaces/ # Interfaces para contratos de servicio/repositorios │
                ├── ExtraHours.Infrastructure/ # Implementación de acceso a datos │
                ├── Context/ # DbContext y configuración de EF Core │
                ├── Migrations/ # Archivos de migraciones de la base de datos │
                └── Repositories/ # Repositorios para acceder a la base de datos │
                ├── ExtraHours.Test/ # Proyecto de pruebas unitarias │
                └── ... # Casos de prueba para los servicios y controladores
```


## 🏃🏃🏃🏃🏃🏃🏃Equipo 5:

🏃 Duvan Andrés Contreras Franco.
🏃 Maria Alejandra Salazar Tangarife.
🏃 Mayerly Cristina Salas Pareja.
🏃 Juliana Zapata Restrepo.
🏃 Felipe Ramirez Yepes.
🏃 Michell Londoño Marin.
🏃 Estivenson Tadeo Gaviria Florez.


