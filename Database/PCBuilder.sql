create database CaseBuilder
go
use CaseBuilder
go
set dateformat dmy
go
create table [Processor]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Cores] varchar(20),
	[Threads] varchar(20),
	[Socket Type] varchar(100),
	[Memory Type] varchar(100),
	[Memory Speed] varchar(100),
	[Base Speed] varchar(50),
	[Turbo Speed] varchar(50),
	[Max Power Consumption] varchar(10),
	[Price] varchar(20),
	[Amazon URL] varchar(200),
	constraint PK_Processor primary key(Model)
)
go
create table [Motherboard]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Chipset] varchar(100),
	[Form Factor] varchar(50),
	[Socket Type] varchar(50),
	[Memory Slots] varchar(10),
	[Memory Type] varchar(10),
	[Memory Speed] varchar(200),
	[Storage Expansion] varchar(100),
	[Multi-GPU Support] varchar(3),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_Motherboard primary key(Model)
);
go
create table [CPU Cooler]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Fan RPM] varchar(200),
	[Noise Level] varchar(200),
	[Color] varchar(50),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_CPUCooler primary key(Model)
);
go
create table [Case]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Side Panel] varchar(200),
	[Carbinet Type] varchar(200),
	[Color] varchar(50),
	[Motherboard Support] varchar(200),
	[Max GPU Length] varchar(50),
	[CPU Cooler Height] varchar(50),
	[Supported PSU Size] varchar(10),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_Case primary key(Model)
);
go

create table [Graphic Card]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Memory] varchar(200),
	[Memory Interface] varchar(200),
	[Length] varchar(50),
	[Interface] varchar(50),
	[Chipset] varchar(100),
	[Max Power Consumption] varchar(10),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_GraphicCard primary key(Model)
);
go
create table [RAM]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[RAM Size] varchar(200),
	[Quantity] varchar(100),
	[RAM Type] varchar(50),
	[RAM Speed] varchar(100),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_RAM primary key(Model)
);
go
create table [Storage]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Capacity] varchar(200),
	[Type] varchar(100),
	[RPM] varchar(100),
	[Interface] varchar(50),
	[Cache Memory] varchar(100),
	[Form Factor] varchar(100),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_Storage primary key(Model)
);
go
create table [Case Cooler]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Fan RPM] varchar(200),
	[Airflow] varchar(100),
	[Noise Level] varchar(50),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_CaseCooler primary key(Model)
);
go
create table [Power Supply]
(
	[Model] varchar(200),
	[Brand] varchar(100),
	[Power] varchar(200),
	[Efficiency] varchar(100),
	[Color] varchar(50),
	[Price] varchar(20),
	[Amazon URL] varchar (200),
	constraint PK_PowerSupply primary key(Model)
);
go
create table [Build List]
(
	
    [Name] varchar(200),
    [Processor] varchar(200),
    [Case] varchar(200),
    [Motherboard] varchar(200),
    [Case Cooler] varchar(200),
    [CPU Cooler] varchar(200),
    [Graphic Card] varchar(200),
    [RAM] varchar(200),
    [Storage] varchar(200),
    [Power Supply] varchar(200),
	[Date] smalldatetime,
	[Owner] varchar(20),
    constraint PK_Build primary key(Name,Owner)
);
go
create table [BuildShared]
(
	[ID] int primary key,
	[Name] Nvarchar(200),
	[Creator] Nvarchar(200),
	[Decription] Nvarchar(3000),
	[Like] int,
	[Processor] varchar(200),
    [Case] varchar(200),
    [Motherboard] varchar(200),
    [Case Cooler] varchar(200),
    [CPU Cooler] varchar(200),
    [Graphic Card] varchar(200),
    [RAM] varchar(200),
    [Storage] varchar(200),
    [Power Supply] varchar(200),
)
create table [SharedBuildInfo]
(
	[ID] int,
	[Sequence] int,
	[Username] Nvarchar(200),
	[Comment] Nvarchar(400),
)
create table [LiveChat]
(
	[ID] int,
	[UserName] varchar(40),
	[CustomName] Nvarchar(40),
	[Comment] Nvarchar(500),
	[Date] Nvarchar(100)
)
go
create table [UserInfo]
(
	[UserName] varchar(40),
	[Password] varchar(40),
	[CustomName] nvarchar(40)
)
go
insert into [Processor] values ('Ryzen Threadripper 3990X','AMD','64','128','sTRX4','DDR4', '3200 MHz','2.9 GHz','4.3 GHz','280 W','8078','https://www.amazon.com/dp/B0815SBQ9W?tag=pcbuilder00-20')
insert into [Processor] values ('Ryzen 9 7950X','AMD','16','32','AM5','DDR5','5200 MHz','4.5 GHz','5.7 GHz','170 W','699','https://amazon.com/dp/B0BBHD5D8Y?tag=pcbuilder00-20')
insert into [Processor] values ('i9-13900KF','Intel','24','32','LGA 1700','DDR5','5600 MHz','3.0 GHz','5.8 GHz','125 W','574','https://www.amazon.com/dp/B0BCFM3CJ4?tag=pcbuilder00-20')
insert into [Processor] values ('Ryzen Threadripper 3970X','AMD','32','64','sTRX4','DDR4','3200 MHz','3.7 GHz','4.5 GHz','280 W','2193.4','https://www.amazon.com/dp/B0815JJQQ8?tag=pcbuilder00-20')
insert into [Processor] values ('i9-13900K','Intel','24','32','LGA 1700','DDR5','5600 MHz','3.0 GHz','5.8 GHz','125 W','641.92','https://www.amazon.com/dp/B0BCF54SR1?tag=pcbuilder00-20')
insert into [Processor] values ('Ryzen 9 7900X','AMD','12','24','AM5','DDR5','5200 MHz','4.7 GHz','5.6 GHz','170 W','439.99','https://www.amazon.com/dp/B0BBJ59WJ4?tag=pcbuilder00-20')
insert into [Processor] values ('Ryzen 9 5950X','AMD','16','32','AM4','DDR4','3200 MHz','3.4 GHz','4.9 GHz','105 W','559.2','https://www.amazon.com/dp/B0815Y8J9N?tag=pcbuilder00-20')
insert into [Processor] values ('i5-13600K','Intel','14','20','LGA 1700','DDR5','5600 MHz','3.5 GHz','5.1 GHz','125 W','319.97','https://www.amazon.com/dp/B0BCDR9M33?tag=pcbuilder00-20')
insert into [Processor] values ('Ryzen 9 3950X','AMD','16','32','AM4','DDR4','3200 MHz','3.5 GHz','4.7 GHz','105 W','610','https://www.amazon.com/dp/B07ZTYKLZW?tag=pcbuilder00-20')
insert into [Processor] values ('i7-13700KF','Intel','16','24','LGA 1700','DDR5','5600 MHz','3.4 GHz','5.4 GHz','125 W','397.99','https://www.amazon.com/dp/B0BCDL7F5W?tag=pcbuilder00-20')
insert into [Processor] values ('i9-12900K','Intel','16','24','LGA 1700','DDR5','4800 MHz','3.2 GHz','5.2 GHz','125 W','479','https://www.amazon.com/dp/B09FXDLX95?tag=pcbuilder00-20')
insert into [Processor] values ('Ryzen 7 7700X','AMD','8','16','AM5','DDR5','5200 MHz','4.5 GHz','5.4 GHz','107 W','348.99','https://www.amazon.com/dp/B0BBHHT8LY?tag=pcbuilder00-20')
go
insert into [Motherboard] values ('TRX40 CREATOR','ASRock','AMD X570','ATX','sTRX4','8','DDR4','2666 MHz','SATA III, PCIe 4.0 x4','Yes','1549','https://amazon.com/dp/B081JX35ZK?tag=pcbuilder00-20/')
insert into [Motherboard] values ('TRX40 Aorus Pro WiFi','Gigabyte','AMD TRX40','ATX','sTRX4','8','DDR4','4400 MHz','SATA III, PCIe 4.0 x4','Yes','820','https://www.amazon.com/dp/B081JCCGQR?tag=pcbuilder00-20/')
insert into [Motherboard] values ('ROG ZENITH II EXTREME ALPHA','ASUS','AMD TRX40','Extended ATX','sTRX4','8','DDR4','2400 MHz','SATA III, PCIe 4.0 x4','yes','962.99','https://www.amazon.com/dp/B083ZC9L91?tag=pcbuilder00-20')
insert into [Motherboard] values ('TRX40 AORUS XTREME','Gigabyte','AMD TRX40','Extended ATX','sTRX4','8','DDR4','4400 MHz','SATA, SATA III, PCIe 4.0 x4, PCIe 4.0 x2','yes','1599.99','https://www.amazon.com/dp/B081JDP378?tag=pcbuilder00-20')
insert into [Motherboard] values ('TRX40 DESIGNARE','Gigabyte','AMD TRX40','Extended ATX','sTRX4','8','DDR4','4400 MHz','SATA, SATA III, PCIe 4.0 x4, PCIe 4.0 x2','yes','1449.99','https://www.amazon.com/dp/B081YW31GR?tag=pcbuilder00-20')
insert into [Motherboard] values ('TRX40P','MSI','AMD TRX40','ATX','sTRX4','8','DDR4','2666 MHz','SATA, SATA III, PCIe 4.0 x4, PCIe 4.0 x2','yes','669.6','https://www.amazon.com/dp/B081FX6KC1?tag=pcbuilder00-20')
insert into [Motherboard] values ('TUF GAMING X570-PLUS (WI-FI)','ASUS','AMD X570','ATX','AM4','4','DDR4','4400 MHz','SATA III, PCIe 4.0 x4','no','179.99','https://www.amazon.com/dp/B07SXF8GY3?tag=pcbuilder00-20&th=1')
insert into [Motherboard] values ('X570S AORUS ELITE AX','Gigabyte','AMD X570','ATX','AM4','4','DDR4','5400 MHz','SATA 6 Gb/s, 2260/2280/22110 M-key','no','189.99','https://www.amazon.com/dp/B083HZ3Y7L?tag=pcbuilder00-20&th=1')
insert into [Motherboard] values ('X570 AORUS ELITE','Gigabyte','AMD X570','ATX','AM4','4','DDR4','2133 MHz','SATA III, PCIe 4.0 x4','yes','264.45','https://www.amazon.com/dp/B07SVRZGMX?tag=pcbuilder00-20&th=1')
insert into [Motherboard] values ('X570 I AORUS PRO WIFI','Gigabyte','AMD X570','Mini ITX','AM4','2','DDR4','2666 MHz','SATA III, PCIe 4.0 x4','no','268.9','https://www.amazon.com/dp/B07T9PC9ZZ?tag=pcbuilder00-20&th=1')
insert into [Motherboard] values ('X570 PRO WIFI','MSI','AMD X570','ATX','AM4','4','DDR4','2666 MHz','SATA III, PCIe 4.0 x4, PCIe 3.0 x4','yes','338.99','https://www.amazon.com/dp/B07T4M3RTR?tag=pcbuilder00-20')
insert into [Motherboard] values ('ROG CROSSHAIR VIII HERO (WI-FI)','ASUS','AMD X570','ATX','AM4','4','DDR4','2133 MHz','SATA III, PCIe 4.0 x4','yes','380.75','https://www.amazon.com/dp/B07SZXBTNW?tag=pcbuilder00-20')
go
insert into [CPU Cooler] values ('Hyper 212 EVO','Cooler Master','600 to 2000 rpm','9 to 36 dBA','RGB','42.99','https://amazon.com/dp/B005O65JXI?tag=pcbuilder00-20/')
insert into [CPU Cooler] values ('Hyper 212 RGB','Cooler Master','650 to 2000 rpm','8 to 30 dBA','RGB','95.99','https://amazon.com/dp/B07H22TC1N?tag=pcbuilder00-20/')
insert into [CPU Cooler] values ('Hyper H412R','Cooler Master','600 to 2000 RPM','29.4 dBA','Black','32.99','https://www.amazon.com/dp/B076MQBZ2L?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Hyper 212 Black Edition','Cooler Master','800 to 2000 RPM','6.5 to 26 dBA','Black','34.99','https://www.amazon.com/dp/B09KX9V4CT?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Hyper T2','Cooler Master','2800 RPM','17 to 35 dBA','Black','39.99','https://www.amazon.com/dp/B00K7809O2?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken X53','NZXT','500 to 2000 RPM','21 to 36 dBA','RGB','123.99','https://www.amazon.com/dp/B082DYR131?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken Z73','NZXT','500 to 1800 RPM','21 to 36 dBA','Black','249.99','https://www.amazon.com/dp/B082DYPF57?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken M22','NZXT','200 to 2300 RPM','21 to 36 dBA','Black','105.67','https://www.amazon.com/dp/B082DYR131?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken X53 RGB','NZXT','500 to 1500 RPM','22 to 33 dBA','RGB','129','https://www.amazon.com/dp/B08MB5WDB2?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken X53 RGB 240mm','NZXT','500 to 1500 RPM','22 to 33 dBA','RGB','149.99','https://www.amazon.com/dp/B09CWCT5T5?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken X63 RGB','NZXT','500 to 1500 RPM','22 to 33 dBA','RGB','159.99','https://www.amazon.com/dp/B09CWGWL93?tag=pcbuilder00-20&th=1')
insert into [CPU Cooler] values ('Kraken Z73 RGB','NZXT','500 to 1500 RPM','22 to 33 dBA','RGB','290.99','https://www.amazon.com/dp/B09GKQJK5P?tag=pcbuilder00-20&th=1')
go
insert into [Case] values ('H510B-W1','NZXT','Tempered Glass, Steel','ATX Mid Tower','White','ATX, Micro-ATK, Mini-ITX','381 mm','165 mm','ATX','89.99','https://amazon.com/dp/B07TC76671?tag=pcbuilder00-20/')
insert into [Case] values ('H510B-B1','NZXT','Tempered Glass, Steel','ATX Full Tower','Black','ATX, Micro-ATX, Mini-ITX','381 mm','165 mm','ATX','83.13','https://amazon.com/dp/B07TD9C5HS?tag=pcbuilder00-20/')
insert into [Case] values ('H510 Elite','NZXT','Tempered Glass, Steel','ATX Mid Tower','White','ATX, Micro-ATX, Mini-ITX','368.6 mm','165 mm','ATX','99.99','https://www.amazon.com/dp/B07T7L875Z?tag=pcbuilder00-20')
insert into [Case] values ('H510B','NZXT','Tempered Glass, Steel','ATX Mid Tower','Black/Red','ATX, Micro-ATX, Mini-ITX','381 mm','165 mm','ATX','59.99','https://www.amazon.com/dp/B07TC73F6Y?tag=pcbuilder00-20&th=1')
insert into [Case] values ('H510i','NZXT','Tempered Glass, Steel','ATX Mid Tower','White','ATX, Micro-ATX, Mini-ITX','381 mm','165 mm','ATX','120.58','https://www.amazon.com/dp/B07TD9S3HZ?tag=pcbuilder00-20&th=1')
insert into [Case] values ('MasterBox Q500L','Cooler Master','Steel, Plastic','ATX Mid Tower','Black','ATX, Micro-ATX, Mini-ITX','360 mm','160 mm','ATX','56.11','https://www.amazon.com/dp/B07Q8VJ17J?tag=pcbuilder00-20&th=1')
insert into [Case] values ('Q300L','Cooler Master','Steel, Plastic','MicroATX Mid Tower','Black','Micro-ATX, Mini-ITX','360 mm','157 mm','ATX','66.49','https://www.amazon.com/dp/B0785GRMPG?tag=pcbuilder00-20&th=1')
insert into [Case] values ('CARBIDE SPEC-05','Cosair','Acrylic','ATX Mid Tower','Black','ATX, Micro-ATX, Mini-ITX','370 mm','N/A','ATX','116.12','https://www.amazon.com/dp/B07BH23K53?tag=pcbuilder00-20&th=1')
insert into [Case] values ('Carbide SPEC-Omega','Cosair','Tempered Glass','ATX Mid Tower','Black','ATX, Micro-ATX, Mini-ITX','370 mm','N/A','ATX','207.34','https://www.amazon.com/dp/B07B2YJXLM?tag=pcbuilder00-20&th=1')
insert into [Case] values ('4000D Airflow','Cosair','Tinted Tempered Glass','ATX Mid Tower','White','ATX, Micro-ATX, Mini-ITX','360 mm','N/A','ATX','89.99','https://www.amazon.com/dp/B08C74694Z?tag=pcbuilder00-20&th=1')
insert into [Case] values ('MasterBox TD500','Cooler Master','Tempered Glass, Steel','ATX Mid Tower','White ARGB','ATX, E-ATX, Micro-ATX, Mini-ITX, SSI-CEB','410 mm','165 mm','ATX','109.31','https://www.amazon.com/dp/B08412JPCH?tag=pcbuilder00-20&th=1')
insert into [Case] values ('CC-9011205-WW','Cosair','Tempered Glass','ATX Mid Tower','White','ATX, Micro-ATX, Mini-ITX','360 mm','N/A','ATX','119.99','https://www.amazon.com/dp/B08C76W2WM?tag=pcbuilder00-20')
go
Insert into [Graphic Card] values ('GeForce RTX 3080 Ti Gaming OC 12G','Gigabyte','12 GB','GDDR6X','320 mm','PCIe x16','GeForce RTX 3080 Ti','350 W','1529.86','https://amazon.com/dp/B095X51RHY?tag=pcbuilder00-20')
Insert into [Graphic Card] values ('TUF Gaming GeForce RTX 3080 Ti OC Edition','ASUS','12 GB','GDDR6X','300 mm','PCIe x16','GeForce RTX 3080 Ti','350 W','1159','https://amazon.com/dp/B096L3GLYS?tag=pcbuilder00-20')
insert into [Graphic Card] values ('RTX 4090 Gaming Trio 24G','MSI','24GB','GDDR6X','337 mm','PCIe 4.0 x16','GeForce RTX 4090','450 W','2999.99','https://www.amazon.com/dp/B0BG959RCF?tag=pcbuilder00-20')
insert into [Graphic Card] values ('GV-N4090WF3-24GD','Gigabyte','24GB','GDDR6X','331 mm','PCIe 4.0 x16','GeForce RTX 4090','450 W','2599.99','https://www.amazon.com/dp/B07TC73F6Y?tag=pcbuilder00-20&th=1')
insert into [Graphic Card] values ('GeForce RTX 4090 Founders Edition','NVIDIA','24GB','GDDR6X','304 mm','PCIe 4.0 x16','GeForce RTX 4090','450 W','2929.99','https://www.amazon.com/dp/B0BJFRT43X?tag=pcbuilder00-20')
insert into [Graphic Card] values ('GeForce RTX 4090 SUPRIM LIQUID X 24G','MSI','24GB','GDDR6X','280 mm','PCIe 4.0 x16','GeForce RTX 4090','450 W','2632','https://www.amazon.com/dp/B0BG94BM2G?tag=pcbuilder00-20')
insert into [Graphic Card] values ('Gaming GeForce RTX 4090 Trinity OC','ZOTAC','24GB','GDDR6X','356 mm','PCIe 4.0 x16','GeForce RTX 4090','450 W','2159','https://www.amazon.com/dp/B0BGJRHX1X?tag=pcbuilder00-20')
insert into [Graphic Card] values ('GeForce RTX 3090 Ti FTW3 Ultra Gaming','EVGA','24GB','GDDR6X','300 mm','PCIe 4.0 x16','GeForce RTX 3090Ti','450 W','2199.99','https://www.amazon.com/dp/B09W4SN2M7?tag=pcbuilder00-20')
insert into [Graphic Card] values ('GeForce RTX 3090 Ti AMP Extreme Holo','ZOTAC','24GB','GDDR6X','356 mm','PCIe 4.0 x16','GeForce RTX 3090Ti','450 W','1599.99','https://www.amazon.com/dp/B09WH4XGDM?tag=pcbuilder00-20')
insert into [Graphic Card] values ('RTX 3080 Ti FTW3 Ultra','EVGA','12GB','GDDR6X','300 mm','PCIe 4.0 x16','GeForce RTX 3080Ti','350 W','1340.08','https://www.amazon.com/dp/B09622N253?tag=pcbuilder00-20')
insert into [Graphic Card] values ('RTX 3080 Ti XC3 ULTRA','EVGA','12GB','GDDR6X','300 mm','PCIe 4.0 x16','GeForce RTX 3080Ti','350 W','1399','https://www.amazon.com/dp/B0979GYMHP?tag=pcbuilder00-20')
insert into [Graphic Card] values ('RTX 3080 Ti Ventus 3X 12G OC','MSI','12GB','GDDR6X','305 mm','PCIe 4.0 x16','GeForce RTX 3080Ti','350 W','1199.99','https://www.amazon.com/dp/B095W3S3LF?tag=pcbuilder00-20')
go
Insert into RAM values ('Trident Z5 RGB','G.Skill','32 GB','2x16 GB','DDR5','6400 MHz','269.99','https://amazon.com/dp/B09QS2K59B?tag=pcbuilder00-20')
Insert into RAM values ('Fury Renegade RGB','Kingston','32 GB','2x16 GB','DDR5','6400 MHz','307.20','https://amazon.com/dp/B0B72BM63Q?tag=pcbuilder00-20')
insert into [RAM] values ('XLR8','PNY','32 GB','2x16 GB','DDR5','6200 MHz','219.99','https://www.amazon.com/dp/B09XBWZ2GZ?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('FF3D532G6000HC38ADC0','TEAMGROUP','32 GB','2x16 GB','DDR5','6000 MHz','474.41','https://www.amazon.com/dp/B09LHQL3GF?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('AX5U6000C4016G-DCLARBK','XPG','32 GB','2x16 GB','DDR5','6000 MHz','284.91','https://www.amazon.com/dp/B09NCR1ZGK?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('DOMINATOR PLATINUM','Corsair','32 GB','2x16 GB','DDR5','6000 MHz','275.99','https://www.amazon.com/dp/B09WH7X8XH?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('Trident Z5','G.Skill','32 GB','2x16 GB','DDR5','6000 MHz','189.99','https://www.amazon.com/dp/B09PTPDKD2?tag=pcbuilder00-20')
insert into [RAM] values ('CMH32GX5M2D6000C36','Corsair','32 GB','2x16 GB','DDR5','6000 MHz','199.99','https://www.amazon.com/dp/B0B771BL4S?tag=pcbuilder00-20')
insert into [RAM] values ('Viper Venom RGB','Patriot Memory','32 GB','2x16 GB','DDR5','6000 MHz','219.99','https://www.amazon.com/dp/B09XZ6VVY9?tag=pcbuilder00-20')
insert into [RAM] values ('RipJaws S5','G.Skill','32 GB','2x16 GB','DDR5','6000 MHz','189.99','https://www.amazon.com/dp/B09Y16CDLG?tag=pcbuilder00-20')
insert into [RAM] values ('CMK32GX5M2B5600C36','Corsair','32 GB','2x16 GB','DDR5','5600 MHz','144.99','https://www.amazon.com/dp/B09NCNF2ZQ?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('KF556C40BBAK2-64','Kingston','32 GB','2x16 GB','DDR5','5600 MHz','423.99','https://www.amazon.com/dp/B0B1QPLJT1?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('Vengeance LPX','Corsair','16 GB','2x8 GB','DDR4','4600 MHz','423.99','https://www.amazon.com/dp/B07CGH547L?tag=pcbuilder00-20&th=1')
insert into [RAM] values ('Trident Z Royal','G.Skill','16 GB','2x8 GB','DDR4','4800 MHz','560','https://www.amazon.com/dp/B07PXGZDXZ?tag=pcbuilder00-20')
insert into [RAM] values ('Trident Z RGB','G.Skill','16 GB','2x8 GB','DDR4','4600 MHz','311.46','https://www.amazon.com/dp/B07GPQ45F1?tag=pcbuilder00-20')
go
Insert into Storage values ('970 EVO','Samsung','1 TB','SSD','N/A','PCIe 3.0 x4','1024 MB','M.2-2280','219.99','https://amazon.com/dp/B07BN217QG?tag=pcbuilder00-20')
Insert into Storage values ('BarraCuda','Seagate','2 TB','HHD','7200 RPM','SATA III','256 MB','3.5"','55.49','https://amazon.com/dp/B075WWN4QJ?tag=pcbuilder00-20')
insert into [Storage] values ('Caviar Blue','Western Digital','1 TB','HDD','7200RPM','SATA III','64 MB','3.5"','34.99','https://www.amazon.com/dp/B0088PUEPK?tag=pcbuilder00-20&th=1')
insert into [Storage] values ('P1','Crucial','1 TB','SSD','N/A','PCIe 3.0 x4','N/A','SATA III','129.99','https://www.amazon.com/dp/B07J2Q4SWZ?tag=pcbuilder00-20&th=1')
insert into [Storage] values ('Blue 500','Western Digital','500 GB','SSD','N/A','SATA III 6Gb/s','N/A','M.2-2280','68','https://www.amazon.com/dp/B073SBX6TY?tag=pcbuilder00-20')
insert into [Storage] values ('A400','Kingston','240 GB','SSD','N/A','SATA III','N/A','2.5"','19.99','https://www.amazon.com/dp/B01N5IB20Q?tag=pcbuilder00-20')
insert into [Storage] values ('Blue','Western Digital','1 TB','SSD','N/A','SATA III 6Gb/s','N/A','M.2-2280','122.11','https://www.amazon.com/dp/B073SB2MXT?tag=pcbuilder00-20&th=1')
insert into [Storage] values ('EVO 500','Samsung','500 GB','SSD','N/A','SATA III 6Gb/s','512 MB','2.5"','74.99','https://www.amazon.com/dp/B0781Z7Y3S?tag=pcbuilder00-20')
insert into [Storage] values ('Blue SN 550','Western Digital','1 TB','SSD','N/A','PCIe 4.0 x4','N/A','M.2-2280','156','https://www.amazon.com/dp/B07YFFX5MD?tag=pcbuilder00-20')
insert into [Storage] values ('GX2','TEAMGROUP','512 GB','SSD','N/A','SATA III','N/A','2.5"','36.99','https://www.amazon.com/dp/B07NRMXWHW?tag=pcbuilder00-20&th=1')
insert into [Storage] values ('MX 500','Crucial','1 TB','SSD','N/A','SATA III','N/A','2.5"','67.99','https://www.amazon.com/dp/B078211KBB?tag=pcbuilder00-20')
insert into [Storage] values ('SN 750','Western Digital','1 TB','SSD','N/A','PCIe 4.0 x4','N/A','M.2-2280','137.99','https://pcbuilder.net/component-details/storage/western-digital-sn-750-wds100t3x0c-00sjg0/')
go
Insert into [Case Cooler] values ('MasterFan MF120R','Cooler Master','650 to 2000 RPM','59 CFM','31 dBA','79','https://amazon.com/dp/B07GSRJJTQ?tag=pcbuilder00-20')
Insert into [Case Cooler] values ('AER RGB','NZXT','500 to 1500 RPM','17.48 to 52.44 CFM','22 to 33 dBA','24.55','')
insert into [Case Cooler] values ('P12 PST','ARCTIC','1800 RPM','56.3 CFM','56.3dBA','9.99','https://www.amazon.com/dp/B07GJG285F?tag=pcbuilder00-20&th=1')
insert into [Case Cooler] values ('P12 PST RGB','ARCTIC','2000 RPM','48.8 CFM','N/A','14.99','https://www.amazon.com/dp/B08Y8MVJGS?tag=pcbuilder00-20')
insert into [Case Cooler] values ('ACFAN00118A','ARCTIC','1800 RPM','56.3 CFM','N/A','8.49','https://www.amazon.com/dp/B07GB16RK7?tag=pcbuilder00-20')
insert into [Case Cooler] values ('ACFAN00170A','ARCTIC','1800 RPM','56.3 CFM','N/A','9.95','https://www.amazon.com/dp/B081VPP24C?tag=pcbuilder00-20')
insert into [Case Cooler] values ('P12 PWM','ARCTIC','2000 RPM','48.8 CFM','N/A','42.99','https://www.amazon.com/dp/B08Y8N5J89?tag=pcbuilder00-20')
insert into [Case Cooler] values ('P12 Silent','ARCTIC','1050 RPM','24.1 CFM','N/A','8.15','https://www.amazon.com/dp/B07GSTMRFB?tag=pcbuilder00-20')
insert into [Case Cooler] values ('CO-9050015-RLED','Corsair','1500 RPM','52.19 CFM','25.2dBA','43.1','https://www.amazon.com/dp/B00F6S10MI?tag=pcbuilder00-20')
insert into [Case Cooler] values ('CO-9050015-BLED','Corsair','1500 RPM','52.19 CFM','25.2dBA','19.99','https://www.amazon.com/dp/B00F6S10DC?tag=pcbuilder00-20&th=1')
insert into [Case Cooler] values ('SP120 RGB','Corsair','1400 RPM','52 CFM','26dBA','74.99','https://www.amazon.com/dp/B01LHYI3E2?tag=pcbuilder00-20')
insert into [Case Cooler] values ('HD140 RGB','Corsair','600 to 1350 RPM','74 CFM','18 to 28.6 dBA','142.98','https://www.amazon.com/dp/B06XRFXZ2C?tag=pcbuilder00-20')
go
Insert into [Power Supply] values ('RM750','Corsair','750 W','80+ Gold','Black','169','https://amazon.com/dp/B07RF237B1?tag=pcbuilder00-20')
Insert into [Power Supply] values ('RM850','Corsair','850 W','80+ Gold','Black','195','https://amazon.com/dp/B07RCKG95L?tag=pcbuilder00-20')
insert into [Power Supply] values ('Toughpower PF1','Thermaltake','850 W','80+Platinum','Black','149.99','https://www.amazon.com/dp/B08BR8RQ3Y?tag=pcbuilder00-20&th=1')
insert into [Power Supply] values ('SPD-0700NP','Thermaltake','700 W','80+','Black','54.99','https://www.amazon.com/dp/B014W3EAX8?tag=pcbuilder00-20&th=1')
insert into [Power Supply] values ('Toughpower GX1','Thermaltake','600 W','80+Gold','Black','59.99','https://www.amazon.com/dp/B07F9YFYLZ?tag=pcbuilder00-20')
insert into [Power Supply] values ('SMART 600','Thermaltake','600 W','80+','Black','42.99','https://www.amazon.com/dp/B014W3EMAO?tag=pcbuilder00-20')
insert into [Power Supply] values ('PS-SPD-0500NPCWUS-W','Thermaltake','500 W','80+','Black','39.99','https://www.amazon.com/dp/B014W3EM2W?tag=pcbuilder00-20&th=1')
insert into [Power Supply] values ('PS-SPD-0430NPCWUS-W','Thermaltake','450 W','80+','Black','27.99','https://www.amazon.com/dp/B07BFJ91TY?tag=pcbuilder00-20&th=1')
insert into [Power Supply] values ('220-G6-0850-X1','EVGA','850 W','80+Gold','Black','176.99','https://www.amazon.com/dp/B099821FWG?tag=pcbuilder00-20')
insert into [Power Supply] values ('SuperNOVA 1000 G6','EVGA','1000 W','80+Gold','Black','224.99','https://www.amazon.com/dp/B0997XYF3R?tag=pcbuilder00-20&th=1')
insert into [Power Supply] values ('SuperNOVA 750 G6','EVGA','750 W','80+Gold','Black','139.99','https://www.amazon.com/dp/B0998KZ8SP?tag=pcbuilder00-20')
insert into [Power Supply] values ('SuperNOVA','EVGA','1000 W','80+Gold','Black','379.99','https://www.amazon.com/dp/B01LZ3SFB3?tag=pcbuilder00-20&th=1')
go
Insert into [Build List] values ('temporary-cache','','','','','','','','','','','')
go


select Model, 'Processor' as Source from Processor
where Model ='Ryzen 7 7700X'
union all
select Model, 'Motherboard' as Source from Motherboard
where Model ='Ryzen 7 7700X'

