drop database if exists Parcial3;
create database Parcial3;

use Parcial3;

create table Usuarios(
    id int primary key auto_increment,
    NomUser varchar(50) not null,
    ContraUser varchar(250) not null
);

create table Intentos(
    id int primary key auto_increment,
    IntentUser varchar(50) not null,
    Estado varchar(20) not null, 
    FechaHora datetime not null
);

insert into Usuarios (NomUser, ContraUser) 
values ('admin', '$2a$12$pL2Iiwt3ZFi2vuSfYl7cmeUKUmOiIxCz6KuLey6HviqPsfJpqbJaO'); -- contraseña 1234567

