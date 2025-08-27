-- Script para crear la base de datos Negocios2023 y sus componentes
-- EXAMEN FINAL POOII - Mantenimiento de Herramientas

-- Crear la base de datos
CREATE DATABASE Negocios2023;
GO

USE Negocios2023;
GO

-- Crear tabla tb_categorias
CREATE TABLE tb_categorias (
    Idcategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombrecategoria VARCHAR(150) NOT NULL
);
GO

-- Crear tabla tb_herramienta
CREATE TABLE tb_herramienta (
    idHer VARCHAR(7) PRIMARY KEY,
    desHer VARCHAR(100) NOT NULL,
    medHer VARCHAR(50) NOT NULL,
    idcategoria INT NOT NULL,
    preUni DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY (idcategoria) REFERENCES tb_categorias(Idcategoria)
);
GO

-- Insertar datos iniciales en tb_categorias
INSERT INTO tb_categorias (Nombrecategoria) VALUES 
('Herramientas Manuales'),
('Herramientas Eléctricas'),
('Herramientas de Medición'),
('Herramientas de Corte'),
('Herramientas de Construcción');
GO

-- Insertar 5 registros en tb_herramienta
INSERT INTO tb_herramienta (idHer, desHer, medHer, idcategoria, preUni, stock) VALUES 
('HER001', 'Martillo de Garra', 'Unidad', 1, 25.50, 15),
('HER002', 'Taladro Eléctrico', 'Unidad', 2, 120.00, 8),
('HER003', 'Metro de Medición', 'Unidad', 3, 12.75, 25),
('HER004', 'Sierra Circular', 'Unidad', 4, 85.90, 5),
('HER005', 'Nivel de Burbuja', 'Unidad', 5, 18.30, 12);
GO

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

-- Procedimiento para listar categorías
CREATE PROCEDURE sp_ListarCategorias
AS
BEGIN
    SELECT Idcategoria, Nombrecategoria 
    FROM tb_categorias
    ORDER BY Nombrecategoria;
END
GO

-- Procedimiento para listar herramientas
CREATE PROCEDURE sp_ListarHerramientas
AS
BEGIN
    SELECT h.idHer, h.desHer, h.medHer, h.idcategoria, 
           c.Nombrecategoria, h.preUni, h.stock
    FROM tb_herramienta h
    INNER JOIN tb_categorias c ON h.idcategoria = c.Idcategoria
    ORDER BY h.desHer;
END
GO

-- Procedimiento para buscar herramienta por ID
CREATE PROCEDURE sp_BuscarHerramientaPorId
    @idHer VARCHAR(7)
AS
BEGIN
    SELECT h.idHer, h.desHer, h.medHer, h.idcategoria, 
           c.Nombrecategoria, h.preUni, h.stock
    FROM tb_herramienta h
    INNER JOIN tb_categorias c ON h.idcategoria = c.Idcategoria
    WHERE h.idHer = @idHer;
END
GO

-- Procedimiento para agregar herramienta
CREATE PROCEDURE sp_AgregarHerramienta
    @idHer VARCHAR(7),
    @desHer VARCHAR(100),
    @medHer VARCHAR(50),
    @idcategoria INT,
    @preUni DECIMAL(10,2),
    @stock INT
AS
BEGIN
    INSERT INTO tb_herramienta (idHer, desHer, medHer, idcategoria, preUni, stock)
    VALUES (@idHer, @desHer, @medHer, @idcategoria, @preUni, @stock);
END
GO

-- Procedimiento para actualizar herramienta
CREATE PROCEDURE sp_ActualizarHerramienta
    @idHer VARCHAR(7),
    @desHer VARCHAR(100),
    @medHer VARCHAR(50),
    @idcategoria INT,
    @preUni DECIMAL(10,2),
    @stock INT
AS
BEGIN
    UPDATE tb_herramienta 
    SET desHer = @desHer,
        medHer = @medHer,
        idcategoria = @idcategoria,
        preUni = @preUni,
        stock = @stock
    WHERE idHer = @idHer;
END
GO

PRINT 'Base de datos Negocios2023 creada exitosamente con todas las tablas y procedimientos almacenados.';