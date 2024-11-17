CREATE TABLE Users(
user_id int primary key,
username varchar(50) not null,
password varchar(255) not null,
email varchar(100) not null,
role enum('customer','employee','admin') not null,
created_at timestamp default current_timestamp,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
create table Cakoi(
Cakoi_id int primary key,
user_id int not null,
name varchar(50) not null,
giong varchar(50) not null,
kichthuocca decimal(5,2),
cannang decimal(5,2),
tuoi int,
tinhtrangsuckhoe varchar(255),
created_at timestamp default current_timestamp,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
FOREIGN key( user_id) references users(user_id)
);
CREATE table hoca(
hoca_id int primary key,
user_id int not null,
kichthuocho decimal(8,2),
chatluongnuoc varchar(255),
created_at timestamp default current_timestamp,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
FOREIGN key( user_id) references users(user_id)
);
Create table spchamsoc(
spchamsoc_id int primary key,
ten varchar(100) not null,
loai varchar(50),
gia decimal(10,2) not null,
mieuta text,
tondong int default 0,
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
create table donhang (
donhang_id int primary key,
user_id int not null,
trangthaidh enum('dang xu li','da hoan thanh','da huy') default'dang xu li',
tongtien decimal(10,2) not null,
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
create table mucdh(
mucdh_id int primary key,
donhang_id int not null,
spchamsoc_id int not null,
soluong int not null,
gia decimal(10,2) not null,
FOREIGN KEY (donhang_id) REFERENCES donhang(donhang_id),
FOREIGN KEY (spchamsoc_id) REFERENCES spchamsoc(spchamsoc_id)
);
create table bcsuckhoe(
baocao_id int primary key,
Cakoi_id int not null,
ngaybaocao date not null,
tinhtrangsuckhoe varchar(255),
ghichu text,
FOREIGN KEY (Cakoi_id) REFERENCES Cakoi(Cakoi_id)
);


















