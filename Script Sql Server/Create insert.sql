create database Banking
go

use [Banking]
go

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [id] bigint IDENTITY(1,1) primary key,
    [firstName] varchar(50)  NOT NULL,
    [lastName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Bank_account'
CREATE TABLE [dbo].[BankAccount] (
    [id] bigint IDENTITY(1,1) primary key,
    [number] varchar(50)  NOT NULL,
    [balance] decimal(10,2)  NOT NULL,
    [isLocked] bit  NOT NULL,
    [customer_id] bigint foreign key references Customer(id)
);
GO

insert into Customer(firstName, lastName) values('Juan', 'Perez')
insert into Customer(firstName, lastName) values('Rafael', 'Bravo')
insert into Customer(firstName, lastName) values('Rufino', 'Alcantara')
insert into Customer(firstName, lastName) values('Jose', 'Morales')
insert into BankAccount(number, balance, isLocked, customer_id) values('123-456-001','1160.00',0,1)
insert into BankAccount(number, balance, isLocked, customer_id) values('123-456-002','2140.00',0,1)
insert into BankAccount(number, balance, isLocked, customer_id) values('123-456-003','2140.00',0,2)
insert into BankAccount(number, balance, isLocked, customer_id) values('123-456-004','2140.00',0,3)
insert into BankAccount(number, balance, isLocked, customer_id) values('123-456-005','2140.00',0,4)
