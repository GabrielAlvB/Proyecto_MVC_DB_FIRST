create database db_escuela
go

use db_escuela
go

create table Alumnos(
id_alumno int identity primary key,
nombre varchar(50) NOT NULL,
edad int NOT NULL,
grado int NOT NULL
)
GO

create table Cursos(
id_curso int identity primary key,
nombre varchar(50) NOT NULL,
disponible bit NOT NULL
)
GO

create table Alumno_Curso(
id int identity primary key,
id_Alumno int references Alumnos(id_alumno),
id_Curso int references Cursos(id_curso)
)
GO