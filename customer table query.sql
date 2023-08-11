
Create table rooms(
roomid int Identity (1,1) primary key,
roomNo varchar(250) NOT NULL unique,
roomType varchar(250) NOT NULL,
bed varchar (250) NOT NULL,
price bigint NOT NULL,
booked varchar (50) default 'NO'
);
 SELECT  roomNo, roomType, bed, price FROM rooms;

 SELECT * FROM rooms;

CREATE table customer(
cid int Identity (1,1) primary key,
cname varchar (250) NOT NULL,
mobile bigint NOT NULL,
nationality varchar (250) NOT NULL,
gender varchar (50) NOT NULL,
dob varchar (50) NOT NULL,
id_passport varchar (250) NOT NULL,
address varchar (350) NOT NULL,
checkin varchar (250) NOT NULL,
checkout varchar (250),
check_out varchar (250) NOT NULL default 'NO',
roomid int NOT NULL,
foreign key (roomid) references rooms(roomid)
);
SELECT * FROM customer;

create table employees(
eid int Identity(1,1) primary key,
ename varchar (250) NOT NULL,
mobile bigint  NOT NULL,
gender varchar (50) NOT NULL,
username varchar (250) NOT NULL,
password varchar (150) NOT NULL
);

SELECT * FROM employees;