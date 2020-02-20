create database TaxPayer;

create table Payer(
	CPF varchar(14) not null PRIMARY KEY,
	Name varchar(100) not null,
	NumberDependents int not null,
	NetSalary decimal(12,2) not null,
	GrossSalary decimal(12,2) not null
);