# ParqueaderoAPI
API con servicios orientados a la administración de un Parqueadero, desarrollado con C# .NET7 y MySql.

1. Requisitos.
Un IDE (Visual Studio recomendado).
.NET7.
Un navegador web.
MySql( MySql Workbrench Recomendado).
Git.

2. Clonar el Repositorio.
Abre tu terminal o línea de comandos.
Navega al directorio donde deseas clonar el repositorio. Puedes usar el comando cd (cambiar directorio) para hacerlo. Por ejemplo:
cd rutadeldirectorio
Una vez estés en el directorio correcto, utiliza el comando git clone seguido de la URL del repositorio:
git clone https://github.com/cristianzeravla/ParqueaderoAPI

3. Configurar la Base de Datos.
Iniciar MySql Workbrench o cualquier cliente de base de datos MySql.
Ejecutar el siguiente script Sql para crear la base de datos y sus respectivas tablas.

CREATE DATABASE parqueadero;

USE parqueadero;

CREATE TABLE inicio (
    id_inicio INT AUTO_INCREMENT PRIMARY KEY,
    fecha_inicio DATETIME NOT NULL
);

CREATE TABLE ingresos (
    id_ingreso INT AUTO_INCREMENT PRIMARY KEY,
    placa VARCHAR(5) NOT NULL,
    id_inicio INT,
    fecha_ingreso DATETIME NOT NULL,
    FOREIGN KEY (id_inicio) REFERENCES inicio(id_inicio)
);

CREATE TABLE facturas (
    id_factura INT AUTO_INCREMENT PRIMARY KEY,
    id_ingreso INT,
    valor_factura DOUBLE NOT NULL,
    fecha_factura DATETIME NOT NULL,
    FOREIGN KEY (id_ingreso) REFERENCES ingresos(id_ingreso)
);

CREATE TABLE salidas (
    id_salida INT AUTO_INCREMENT PRIMARY KEY,
    id_factura INT,
    fecha_salida DATETIME NOT NULL,
    FOREIGN KEY (id_factura) REFERENCES facturas(id_factura)
);

CREATE TABLE cierres (
    id_cierre INT AUTO_INCREMENT PRIMARY KEY,
    id_inicio INT,
    total_facturas DOUBLE NOT NULL,
    fecha_cierre DATETIME NOT NULL,
    FOREIGN KEY (id_inicio) REFERENCES inicio(id_inicio)
);

4. Actualizar la cadena de conexión dentro del proyecto:
Abre el archivo appsettings.json del proyecto y agrega estas líneas de código remplazando los datos por tu información de base de datos.
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=parqueadero;User=(tu-usuario);Password=(tu-contraseña);"
  }
}

Al final debe quedar algo asi:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=parqueadero;User=(tu-usuario);Password=(tu-contraseña);"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

5. Restaurar los paquetes NuGet.
Abre una terminal en el directorio del proyecto (donde está el archivo .csproj).

Ejecuta el siguiente comando para restaurar los paquetes NuGet:
dotnet restore

6. Ejecutar el proyecto.
Se puede ejecutar el proyecto en la parte superior del IDE, en la flecha verde o presionando F5.

Después de estos pasos se abrirá la API en el navegador y se podrá probar los distintos servicios de la API del parqueadero.