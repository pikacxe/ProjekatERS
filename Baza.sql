create table Brojilo(
	ID int not null unique,
	ImeK nvarchar(20) not null,
	PrzK nvarchar(20) not null,
	Ulica nvarchar(40) not null,
	Broj int not null,
	PostanskiBroj int,
	Grad nvarchar(20)

	constraint pk_brojilo primary key (ID),
	);

create table Potrosnja(
	IDB int not null ,
	Potrosnja float,
	Mesec int not null,
	constraint pk_potrosnja primary key (IDB,Mesec),
	constraint fk_potrosnja foreign key(IDB) references Brojilo(ID) on delete cascade
);

drop table Potrosnja;