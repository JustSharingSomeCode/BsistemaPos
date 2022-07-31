create database sistemaPosDB;
go
use sistemaPosDB;

create table clients(
clientId varchar(10) primary key,
c_name varchar(100) not null,
phone varchar(20) not null,
c_address varchar(50) not null,
);

create table invoices(
invoiceId int identity primary key,
clientId_fk varchar(10) not null,
total money not null,
invoice_date date not null
);

alter table invoices add constraint invoices_client_fk
foreign key (clientId_fk) references clients(clientId);

create table products(
productId int identity primary key,
p_name varchar(150) not null,
p_description varchar(250) not null,
stock int not null,
img varchar(350),
price money
);

create table sales(
saleId int identity primary key,
invoiceId_fk int not null,
productId_fk int not null,
quantity int not null,
unit_price money not null,
sub_total money not null
);

alter table sales add constraint sales_invoices_fk
foreign key (invoiceId_fk) references invoices(invoiceId);

alter table sales add constraint sales_products_fk
foreign key (productId_fk) references products(productId);

go

create trigger act_invoicetotal_insert on sales
for insert as
begin
	if((select quantity from inserted) > (select stock from products where productId = (select productId_fk from inserted)))
	begin
		RAISERROR('product stock is less than the required quantity',16,1)
		ROLLBACK TRANSACTION
	end

	update invoices set total = (total + (select quantity * unit_price from inserted)) where invoiceId = (select invoiceId_fk from inserted);
	update products set stock = (stock - (select quantity from inserted)) where productId = (select productId_fk from inserted);
end

go

create trigger act_invoicetotal_delete on sales
for delete as
begin
	update invoices set total = (total - (select sum(sub_total) from deleted where invoiceId = invoiceId_fk)) where invoiceId in (select invoiceId_fk from deleted);
	update products set stock = (stock + (select sum(quantity) from deleted where productId = productId_fk)) where productId in (select productId_fk from deleted);
end