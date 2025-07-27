# Sistema de Gestión y Control de Ventas 🚀
<div align="center">

![Logo del Proyecto](docs/images/logo.png)

[![Licencia MIT](https://img.shields.io/badge/Licencia-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2019+-blue.svg)](https://visualstudio.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red.svg)](https://www.microsoft.com/sql-server)
[![C#](https://img.shields.io/badge/C%23-.NET%20Framework-purple.svg)](https://docs.microsoft.com/dotnet)

*Un sistema integral de gestión empresarial desarrollado con las últimas tecnologías .NET*


</div>

---

## 📑 Tabla de Contenidos
- [Sobre el Proyecto](#-sobre-el-proyecto)
- [Arquitectura del Sistema](#-arquitectura-del-sistema)
- [Tecnologías Utilizadas](#%EF%B8%8F-tecnologías-utilizadas)
- [Características](#-características)
- [Comenzando](#-comenzando)
- [Uso](#-uso)
- [Documentación](#-documentación)
- [Roadmap](#-roadmap)
- [Contribuir](#-contribuir)
- [Licencia](#-licencia)
- [Contacto](#-contacto)

## 🎯 Sobre el Proyecto

<div align="center">
  <img src="docs/images/dashboard.png" alt="Dashboard" width="500"/>
</div>

Sistema integral desarrollado en C# con arquitectura en capas para la gestión empresarial, incluyendo:
- Sistema de autenticación robusto
- Gestión de empleados y roles
- Control de inventario
- Sistema de ventas
- Gestión de clientes
- Reportes y análisis

## 🏗 Arquitectura del Sistema

<div align="center">
  <img src="docs/images/architecture.png" alt="Arquitectura" width="800"/>
</div>

El sistema está construido siguiendo una arquitectura en capas:
- **Capa de Presentación (UI)**: Interfaces de usuario modernas con Bunifu UI
- **Capa de Lógica de Negocio (BLL)**: Reglas de negocio y validaciones
- **Capa de Acceso a Datos (DAL)**: Interacción con la base de datos
- **Base de Datos**: SQL Server con procedimientos almacenados optimizados

## 🛠️ Tecnologías Utilizadas

<div align="center">

| Tecnología | Versión | Uso |
|------------|---------|-----|
| C# | 7.0+ | Lenguaje principal |
| .NET Framework | 4.7.2+ | Framework de desarrollo |
| SQL Server | 2019 | Base de datos |
| Bunifu UI | 5.0.6 | Framework de UI |
| Visual Studio | 2019+ | IDE |

</div>

## ✨ Características

### Módulo de Autenticación
<div align="center">
  <img src="docs/images/login-screen.png" alt="Login" width="600"/>
</div>

- Sistema de login seguro
- Gestión de roles y permisos
- Recuperación de contraseña
- Registro de actividad

### Gestión de Empleados
<div align="center">
  <img src="docs/images/employees-management.png" alt="Empleados" width="600"/>
</div>
<div align="center">
  <img src="docs/images/registro-empleados.png" alt="Empleados" width="600"/>
</div>

- Alta, baja y modificación de empleados
- Asignación de roles
- Control de accesos
- Historial de actividades

### Control de Inventario
<div align="center">
  <img src="docs/images/vehicles-inventory.png" alt="Inventario" width="600"/>
</div>
<div align="center">
  <img src="docs/images/stock-accesorios.png" alt="Inventario" width="600"/>
</div>

- Gestión de vehículos
- Control de stock
- Alertas de inventario bajo
- Registro de movimientos

## 🚀 Comenzando

### Prerrequisitos
```powershell
# Verificar versión de .NET
dotnet --version

# Verificar SQL Server
sqlcmd -?
```

### Instalación

1. Clonar el repositorio
```powershell
git clone [URL_DEL_REPOSITORIO]
```

2. Configurar la base de datos
```sql
-- Ejecutar en SQL Server Management Studio
USE master
GO
CREATE DATABASE BEATIFUL
GO
```

3. Configurar la conexión
```xml
<!-- App.config -->
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=localhost;Database=BEATIFUL;Trusted_Connection=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

## 📖 Documentación

Documentación detallada disponible en la [Wiki del proyecto](../../wiki)

## 🗺 Roadmap

- [x] Sistema base de autenticación
- [x] Gestión de empleados
- [x] Control de inventario
- [ ] Sistema de reportes avanzados
- [ ] Integración con APIs externas
- [ ] Dashboard en tiempo real

## 🤝 Contribuir

Las contribuciones son bienvenidas. Por favor, lee [CONTRIBUTING.md](CONTRIBUTING.md) para más detalles.

## 📄 Licencia

Distribuido bajo la Licencia MIT. Ver [LICENSE.md](LICENSE.md) para más información.

## 📫 Contacto

Alex Jhail Sanchez Rea - [@AlexJhailSanchezRea](https://github.com/AlexJhailSanchezRea)

---

<div align="center">

**¿Te gustó el proyecto? Dale una ⭐️**

</div>

<!-- 
Instrucciones para las imágenes:
1. Crear un logo para el proyecto y guardarlo en docs/images/icons/logo.png
2. Tomar screenshots de cada módulo principal y guardarlos en docs/images/screenshots/
3. Crear el diagrama de arquitectura y guardarlo en docs/images/diagrams/architecture.png
4. Asegurarse de que todas las imágenes tengan un tamaño y formato consistente
--> 