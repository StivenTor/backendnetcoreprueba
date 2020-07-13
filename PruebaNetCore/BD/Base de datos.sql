CREATE DATABASE pruebanetcore;

CREATE table persons(
id int primary key auto_increment,
name varchar(40),
lastname varchar(40),
age varchar(40),
address varchar(40),
cellphone varchar(40),
email varchar(40)
);

SELECT * FROM persons;