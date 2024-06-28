create database FPEA_Proyecto

create table FPEA_centro_salud(
ID_centro int primary key not null,
nombre_centro varchar (20),
direccion_centro varchar (20),
tel_centro varchar (10))

create table FPEA_matrona(
ID_matrona int primary key not null,
nombre_matrona varchar(15),
horario_consulta varchar(5),
dirrecion_matrona varchar (20),
tel_matrona varchar (10))

create table FPEA_centro_matrona(
ID_centro1 int foreign key references FPEA_centro_salud(ID_centro),
ID_matrona1 int foreign key references FPEA_matrona(ID_matrona))

create table FPEA_clase_preparacion(
ID_clase int primary key not null,
fecha varchar (8),
duracion int,
lugar_clase varchar (20),
hora_clase varchar (5),
descripcion_clase varchar(30),
ID_centro2 int foreign key references FPEA_centro_salud(ID_centro))

create table FPEA_embarazada(
ID_embarazada int primary key not null,
nombre_embarazada varchar (15),
edad int,
semanas_embarazo int,
numero_hijos int,
direccion_embarazada varchar (20),
NSS_embarazada varchar (11),
ID_matrona2 int foreign key references FPEA_matrona(ID_matrona))

CREATE TABLE FPEA_clase_embarazada(
    ID_embarazada1 INT FOREIGN KEY REFERENCES FPEA_embarazada(ID_embarazada),
    ID_clase1 INT FOREIGN KEY REFERENCES FPEA_clase_preparacion(ID_clase)
);
select*from Embarazadas_Matronas;
select*from FPEA_centro_salud;
select*from FPEA_matrona;
select*from FPEA_clase_preparacion;
select*from FPEA_embarazada;
select*from FPEA_centro_matrona;


insert into FPEA_centro_salud(ID_centro, nombre_centro, direccion_centro, tel_centro, correo)
values 
(1, 'Miguel Hidalgo', 'Calle 123 #21', '5501234567', 'mhidalgo@salud.com'),
(2, 'Julio Verne', 'Av 18 #345', '5598745612', 'jverne@salud.com'),
(3, 'Afrodita', 'Calle 63 #69', '5591738264', 'afrodita@salud.com');

insert into FPEA_matrona(ID_matrona, nombre_matrona, horario_consulta, dirrecion_matrona, tel_matrona, correo_matrona)
values 
(1, 'Mabel Diaz', '8-16', 'Calle 98 #33', '5536251478', 'mabel@matronas.com'),
(2, 'Marta Benson', '10-18', 'Av Reforma #11', '5598278569', 'marta@matronas.com'),
(3, 'Karen Paredes', '14-22', 'Calle 127 #69', '5544886678', 'karen@matronas.com');

insert into FPEA_centro_matrona(ID_centro1, ID_matrona1)
values 
(1, 1),
(2, 2),
(3, 3);

insert into FPEA_clase_preparacion(ID_clase, fecha, duracion, lugar_clase, hora_clase, descripcion_clase, ID_centro2, Materiales)
values 
(11, '24/05/24', 2, 'Julio Verne', '12:30', 'Como cambiar al bebe', 2, 'Pañales'),
(12, '14/06/24', 2, 'Afrodita', '14:00', 'Como alimentar al bebe', 3, 'Biberones'),
(13, '10/06/24', 2, 'Miguel Hidalgo', '10:00', 'Kit para el dia de parto', 1, 'Kit de parto');

insert into FPEA_embarazada(ID_embarazada, nombre_embarazada, edad, semanas_embarazo, numero_hijos, direccion_embarazada, NSS_embarazada, ID_matrona2, numero_emergencia)
values 
(101, 'Mariana Rivera', 23, 12, 0, 'Charles Dickens #13', '12365478901', 1, '5512345678'),
(102, 'Alejandra Vera', 28, 20, 3, 'AV Rojo Gomez #33', '36541278208', 2, '5598765432'),
(103, 'Sofia Gomez', 26, 22, 2, 'Rio Frio #53', '65874231008', 3, '5532145678');

INSERT INTO FPEA_clase_embarazada(ID_embarazada1, ID_clase1)
VALUES 
(101, 11),
(102, 12),
(103, 13);

-- Actualizar datos
UPDATE FPEA_centro_salud
SET tel_centro = '5614785308'
WHERE ID_centro = 2;

UPDATE FPEA_matrona
SET dirrecion_matrona = 'Sur 24 #12'
WHERE ID_matrona = 2;

UPDATE FPEA_clase_preparacion
SET duracion = 3
WHERE ID_clase = 13;

UPDATE FPEA_embarazada
SET direccion_embarazada = 'Sur 214 #132'
WHERE ID_embarazada = 102;

-- Consultas
SELECT * FROM FPEA_centro_salud;
SELECT * FROM FPEA_matrona;
SELECT * FROM FPEA_centro_matrona;
SELECT * FROM FPEA_embarazada;
SELECT * FROM FPEA_clase_preparacion;
SELECT * FROM FPEA_clase_embarazada;

-- Estadísticas
SELECT 
    MIN(duracion) AS Duracion_Minima,
    MAX(duracion) AS Duracion_Maxima,
    AVG(duracion) AS Duracion_Promedio
FROM 
    FPEA_clase_preparacion;

SELECT 
    MIN(numero_hijos) AS Numero_Hijos_Minimo,
    MAX(numero_hijos) AS Numero_Hijos_Maximo,
    AVG(numero_hijos) AS Numero_Hijos_Promedio
FROM 
    FPEA_embarazada;

SELECT 
    MIN(edad) AS Edad_Minima,
    MAX(edad) AS Edad_Maxima,
    AVG(edad) AS Edad_Promedio
FROM 
    FPEA_embarazada;

-- Procedimientos almacenados
CREATE PROCEDURE CP_FPEA_Select_Matrona
    @ID_MATRONA INT
AS
BEGIN
    SELECT nombre_matrona, horario_consulta, direccion_matrona, tel_matrona
    FROM FPEA_matrona
    WHERE ID_matrona = @ID_MATRONA;
END;

CREATE PROCEDURE CP_FPEA_Update_Direccion_Embarazada
    @ID_EMBARAZADA INT,
    @DIRECCION_NUEVA VARCHAR(20)
AS
BEGIN
    UPDATE FPEA_embarazada
    SET direccion_embarazada = @DIRECCION_NUEVA
    WHERE ID_embarazada = @ID_EMBARAZADA;
END;

CREATE PROCEDURE CP_FPEA_Delete_Clase_Preparacion
    @ID_CLASE INT
AS
BEGIN
    DELETE FROM FPEA_clase_preparacion
    WHERE ID_clase = @ID_CLASE;
END;

CREATE PROCEDURE CP_FPEA_Insert_Centro_Salud
    @NOMBRE VARCHAR(20),
    @DIRECCION VARCHAR(20),
    @TELEFONO VARCHAR(10)
AS
BEGIN
    INSERT INTO FPEA_centro_salud (nombre_centro, direccion_centro, tel_centro, correo)
    VALUES (@NOMBRE, @DIRECCION, @TELEFONO, '');
END;

CREATE PROCEDURE CP_FPEA_Delete_Centro_Salud
    @ID_CENTRO INT
AS
BEGIN
    DELETE FROM FPEA_centro_salud
    WHERE ID_centro = @ID_CENTRO;
END;

-- Vistas
DROP VIEW IF EXISTS FPEA_Embarazadas_Matronas;

CREATE VIEW FPEA_Embarazadas_Matronas AS
SELECT 
    e.nombre_embarazada AS Nombre_Embarazada,
    e.edad AS Edad_Embarazada,
    m.nombre_matrona AS Nombre_Matrona
FROM 
    FPEA_embarazada e
JOIN 
    FPEA_matrona m ON e.ID_matrona2 = m.ID_matrona;

CREATE VIEW FPEA_Clases_Centros AS
SELECT 
    c.nombre_centro AS Nombre_Centro,
    cl.fecha AS Fecha_Clase,
    cl.lugar_clase AS Lugar_Clase
FROM 
    FPEA_clase_preparacion cl
JOIN 
    FPEA_centro_salud c ON cl.ID_centro2 = c.ID_centro;

CREATE VIEW FPEA_Embarazadas_Clases AS
SELECT 
    e.nombre_embarazada AS Nombre_Embarazada,
    c.fecha AS Fecha_Clase,
    c.lugar_clase AS Lugar_Clase
FROM 
    FPEA_embarazada e
JOIN 
    FPEA_clase_embarazada ce ON e.ID_embarazada = ce.ID_embarazada1
JOIN 
    FPEA_clase_preparacion c ON ce.ID_clase1 = c.ID_clase;

CREATE VIEW FPEA_Matronas_Centros AS
SELECT 
    m.nombre_matrona AS Nombre_Matrona,
    c.nombre_centro AS Nombre_Centro
FROM 
    FPEA_matrona m
JOIN 
    FPEA_centro_matrona cm ON m.ID_matrona = cm.ID_matrona1
JOIN 
    FPEA_centro_salud c ON cm.ID_centro1 = c.ID_centro;

-- Índices
CREATE INDEX FPEA_edad_embarazada ON FPEA_embarazada (edad);
CREATE INDEX FPEA_fecha_clase_preparacion ON FPEA_clase_preparacion (fecha);

-- Triggers
CREATE TRIGGER FPEA_trg_centro_matrona_ID_centro1
ON FPEA_centro_matrona
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO FPEA_centro_matrona (ID_centro1, ID_matrona1)
    SELECT inserted.ID_centro1, c.ID_matrona
    FROM inserted
    JOIN FPEA_matrona c ON inserted.ID_matrona1 = c.ID_matrona;
END;

CREATE TRIGGER FPEA_trg_clase_embarazada_ID_embarazada1
ON FPEA_clase_embarazada
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO FPEA_clase_embarazada (ID_embarazada1, ID_clase1)
    SELECT ID_embarazada1, ID_clase1
    FROM inserted;
END;

DELETE FROM FPEA_centro_salud
    WHERE ID_centro =01;
DELETE FROM FPEA_matrona
    WHERE ID_matrona = 01;
DELETE FROM FPEA_clase_preparacion
    WHERE ID_clase = 12;
DELETE FROM FPEA_embarazada
    WHERE ID_embarazada = 103;