drop database if exists Guitars;
create database Guitars;
use Guitars;
create table Maker (
	Maker_Name varchar(15) not null unique,
	Maker_Year_Founded integer,
	Maker_Country varchar(15),
	primary key (Maker_Name)
);
insert into Maker values ("Gibson",1910,"USA");
insert into Maker values ("Fender",1919,"USA");
insert into Maker values ("Ibanez",1949,"Japan");
select * from Maker;
select Maker_Name from Maker where Maker_Country = "Japan";
create table Guitar(
	Guitar_NickName varchar(10) not null unique,
	Maker_Name varchar(15),
	Guitar_Year integer,
	Guitar_Model varchar(15),
	Guitar_Color enum("red","black","natural"),
	primary key(Guitar_NickName),
	foreign key(Maker_Name) references Maker (Maker_Name)
		on delete cascade on update cascade
);
insert into Guitar values ("Conor","Gibson",1974,"SG","red");
insert into Guitar values ("Lauren","Gibson",2012,"SG","black");
insert into Guitar values ("Evan","Gibson",1986,"Flying V","black");