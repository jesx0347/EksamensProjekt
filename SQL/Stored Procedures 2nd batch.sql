drop procedure if exists [spListOfEvents]
drop procedure if exists [spListOfKategorier]
drop procedure if exists [spListOfSale]

go

create PROCEDURE [spListOfEvents]
AS
Begin
select distinct
	[EventId],
	[EventNavn]
from
	[EVENT] join [AFVIKLING] on [EVENT].EventId = [AFVIKLING].[Event]
where
	[Dato] > GETDATE();
end

go

create procedure [spListOfKategorier]
as
begin
select
	[KategoriId],
	[KategoriNavn]
from
	[KATEGORI]
end

go

create procedure [spListOfSale]
as
begin
select
	[SalId],
	[SalNavn],
	[Leje],
	[Kapacitet]
from
	[SAL]
end