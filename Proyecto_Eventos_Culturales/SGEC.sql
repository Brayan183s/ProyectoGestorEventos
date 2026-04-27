create database SGEC;
use SGEC;

CREATE TABLE Usuario (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    contrasena VARCHAR(100),
    tipo_usuario ENUM('usuario', 'administrador') NOT NULL
);

drop table evento_interes;

CREATE TABLE evento_interes (
    id_evento INT,
    id_usuario INT,
    fecha_marcado DATETIME,
    PRIMARY KEY (id_evento, id_usuario),
    FOREIGN KEY (id_evento) REFERENCES Evento_cultural(id_evento),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Evento_cultural (
    id_evento INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    descripcion TEXT,
    fecha DATE,
    hora TIME,
    lugar VARCHAR(100),
    organizador VARCHAR(100),
    costo DOUBLE
);

/* usuarios */
INSERT INTO Usuario(nombre, contrasena, tipo_usuario)
VALUES('Brayan','brayan123','1');
INSERT INTO Usuario(nombre, contrasena, tipo_usuario)
VALUES('Admin','Admin','2');

select * from sgec.usuario;

SELECT user, host, plugin FROM mysql.user;
ALTER USER 'root'@'localhost'
IDENTIFIED WITH mysql_native_password
BY 'Gears.20s';
FLUSH PRIVILEGES;
SELECT user, host, plugin FROM mysql.user

SELECT user, host, plugin FROM mysql.user;

ALTER TABLE Evento_cultural 
ADD tipo VARCHAR(50),
ADD cupo INT;

/* forzar metodo utf8 */
SET NAMES 'utf8';
ALTER DATABASE sgec CHARACTER SET utf8 COLLATE utf8_general_ci;
ALTER TABLE Evento_cultural CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci;

/* deshacer cambios */
ALTER DATABASE sgec CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
ALTER TABLE Evento_cultural 
CONVERT TO CHARACTER SET utf8mb4 
COLLATE utf8mb4_0900_ai_ci;