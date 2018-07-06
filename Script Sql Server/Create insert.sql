create database Banking
go

use [Banking]
go

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [customer_id] bigint IDENTITY(1,1) primary key,
    [first_name] varchar(50)  NOT NULL,
    [last_name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Bank_account'
CREATE TABLE [dbo].[Bank_account] (
    [bank_account_id] bigint IDENTITY(1,1) NOT NULL,
    [number] varchar(50)  NOT NULL,
    [balance] decimal(10,2)  NOT NULL,
    [locked] bit  NOT NULL,
    [customer_id] bigint foreign key references Customer(customer_id)
);
GO

insert into Customer(first_name, last_name) values('Juan', 'Perez')
insert into Bank_account(number, balance, locked, customer_id) values('123-456-001','1160.00',0,1)
insert into Bank_account(number, balance, locked, customer_id) values('123-456-002','2140.00',0,1)