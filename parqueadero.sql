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