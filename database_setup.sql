-- Crear la base de datos
CREATE DATABASE BEATIFUL;
GO

USE BEATIFUL;
GO

-- Crear tabla PERSONA
CREATE TABLE PERSONA (
    dni VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(200),
    telefono VARCHAR(20)
);
GO

-- Crear tabla TIPO_EMPLEADO
CREATE TABLE TIPO_EMPLEADO (
    id VARCHAR(10) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL
);
GO

-- Crear tabla EMPLEADO
CREATE TABLE EMPLEADO (
    dni VARCHAR(20) PRIMARY KEY,
    tipo_empleado_id VARCHAR(10) NOT NULL,
    usuario VARCHAR(50) UNIQUE NOT NULL,
    contrasena VARCHAR(50) NOT NULL,
    FOREIGN KEY (dni) REFERENCES PERSONA(dni),
    FOREIGN KEY (tipo_empleado_id) REFERENCES TIPO_EMPLEADO(id)
);
GO

-- Crear tabla CLIENTE
CREATE TABLE CLIENTE (
    ci VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(200),
    telefono VARCHAR(20)
);
GO

-- Crear tabla AUTO_NUEVO
CREATE TABLE AUTO_NUEVO (
    id INT IDENTITY(1,1) PRIMARY KEY,
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    anio INT NOT NULL,
    precio DECIMAL(18,2) NOT NULL
);
GO

-- Crear tabla STOCK
CREATE TABLE STOCK (
    auto_id INT PRIMARY KEY,
    cantidad INT NOT NULL,
    FOREIGN KEY (auto_id) REFERENCES AUTO_NUEVO(id)
);
GO

-- Insertar tipos de empleado básicos
INSERT INTO TIPO_EMPLEADO (id, descripcion) VALUES
('ADMIN', 'Administrador'),
('VEND', 'Vendedor');
GO

-- Insertar un usuario administrador por defecto
-- Primero en PERSONA
INSERT INTO PERSONA (dni, nombre, direccion, telefono) VALUES
('12345678', 'Administrador', 'Dirección Administrativa', '123456789');
GO

-- Luego en EMPLEADO
INSERT INTO EMPLEADO (dni, tipo_empleado_id, usuario, contrasena) VALUES
('12345678', 'ADMIN', 'admin', 'admin123');
GO 