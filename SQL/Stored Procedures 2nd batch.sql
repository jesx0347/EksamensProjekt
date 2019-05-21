drop procedure if exists [spListOfEvents]
drop procedure if exists [spListOfKategorier]
drop procedure if exists [spListOfSale]
drop procedure if exists [spGetEvent]
drop procedure if exists [spGetEventKategorier]
drop procedure if exists [spGetAfviklinger]
drop procedure if exists [spGetBilletTyper]
drop procedure if exists [spGetSalgsTal]

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

go
create procedure [spGetEvent](
	@ID		as	INT)
as
begin
select
	[Markedsføring], 
	[Koda], 
	[Garantisum], 
	ArtistSplit, 
	VariableOmkostninger, 
	OmkostningerNote, 
	VariableIndtægter, 
	IndtægterNote, 
	UnderskudsGodtgørelse
from
	[EVENT]
where
	[EVENT].EventId = @ID
end

go

create procedure [spGetEventKategorier](
	@EventID as int)
as
begin
select
	Kategori
from
	[EVENT_KATEGORI]
where
	[Event] = @EventID
end

go

create procedure [spGetAfviklinger](
	@EventID as int)
as
begin
select
	DatoId, 
	Dato, 
	Sal
from
	[AFVIKLING]
where
	[Event] = @EventID
end

go

create procedure [spGetBilletTyper](
	@AfviklingID as int)
as
begin
select
	BilletTypeId, 
	Udbud, 
	Pris 
from 
	BILLET_TYPE
where
	@AfviklingID = Afvikling
end

go

create procedure [spGetSalgsTal](
	@BilletID as INT)
as
begin
select
	Bevægelse, 
	SalgsDato
from
	[SALGS_TAL]
where
	BilletType = @BilletID
end