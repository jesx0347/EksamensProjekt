drop procedure if exists spInsertEvent
drop procedure if exists spInsertEventKategori
drop procedure if exists spInsertAfvikling
drop procedure if exists spInsertBilletType
drop procedure if exists spGetBilletTypeId
drop procedure if exists spInsertSalgsTal
drop procedure if exists spGetAfviklingId

go
Create PROCEDURE spInsertEvent(
	@EventNavn				AS		NVARCHAR(200)
	,@Markedsf�ring			AS		MONEY
	,@Koda					AS		FLOAT(24)
	,@Garantisum			AS		MONEY
	,@ArtistSplit			AS		FLOAT(24)
	,@VariableOmkostninger	AS		MONEY	
	,@OmkostningerNote		AS		NVARCHAR(400)
	,@VariableIndt�gter		AS		MONEY
	,@Indt�gterNote			AS		NVARCHAR(400)
	,@UnderskudsGodtg�relse AS		DATETIME2
)
AS
BEGIN
--SELECT TOP (1) Udl�bsDato
--FROM UNDERSKUDS_GODTG�RELSE
--WHERE	Udl�bsDato > GETDATE()
--order by Udl�bsDato asc
-- as u
INSERT INTO [EVENT] VALUES (@EventNavn
							,@Markedsf�ring
							,@Koda
							,@Garantisum
							,@ArtistSplit
							,@VariableOmkostninger
							,@OmkostningerNote
							,@VariableIndt�gter
							,@Indt�gterNote
							,@UnderskudsGodtg�relse);
END

EXECUTE spInsertEvent	@EventNavn='ODEON'
						,@Markedsf�ring='500.55'
						,@Koda='10'
						,@Garantisum='4599.346'
						,@ArtistSplit='70'
						,@VariableOmkostninger='300'
						,@OmkostningerNote='Ekstra lys: 300kr'
						,@VariableIndt�gter='300'
						,@Indt�gterNote='D�kning af lys: 300'
						,@UnderskudsGodtg�relse='31-12-2020'

GO

CREATE PROCEDURE spInsertEventKategori(
		@Event				INT
		,@Kategori			INT
)
AS
BEGIN
INSERT INTO [EVENT_KATEGORI] VALUES (@Event
									 ,@Kategori);
END

--EXECUTE	spInsertEventKategori	@Event='35'
--								,@Kategori='1'
--EXECUTE	spInsertEventKategori	@Event='35'
--								,@Kategori='3'

GO

CREATE PROCEDURE spInsertAfvikling(
		@Dato			DATETIME2
		,@Event			INT
		,@Sal			INT
)
AS
BEGIN
INSERT INTO [AFVIKLING] VALUES (@Dato
								,@Event
								,@Sal);
END

EXECUTE spInsertAfvikling	@Dato='23-10-2019'
							,@Event='35'
							,@Sal='2'

GO

CREATE PROCEDURE spInsertBilletType(
		@Udbud			INT
		,@Pris			MONEY
		,@Afvikling		INT
)
AS
BEGIN
INSERT INTO [BILLET_TYPE] VALUES (@Udbud
									,@Pris
									,@Afvikling);
END

EXECUTE spInsertBilletType	@Udbud=200
							,@Pris=234.99
							,@Afvikling=1

GO

CREATE PROCEDURE spGetBilletTypeId(
	@Pris			money
	,@Afvikling		INT
)
AS
BEGIN
SELECT
	BilletTypeId
FROM
	[BILLET_TYPE]
WHERE
	Pris = @Pris AND Afvikling = @Afvikling
END

EXECUTE spGetBilletTypeId @Pris = 234.99, @Afvikling = 1

GO


CREATE PROCEDURE spInsertSalgsTal(
		@Bev�gelse		INT
		,@BilletType	INT
		,@SalgsDato		DATETIME2
)
AS
BEGIN
INSERT INTO [SALGS_TAL] VALUES (@Bev�gelse
								,@BilletType
								,@SalgsDato);
END

EXECUTE spInsertSalgsTal	@Bev�gelse=23
						,@BilletType=1
						,@SalgsDato='20-10-2020'

GO

CREATE PROCEDURE spGetAfviklingId(
	@Event		INT
	,@Dato		DATETIME2
)
AS
BEGIN
SELECT
	DatoId
FROM
	[AFVIKLING]
WHERE
	Dato = @Dato AND [Event] = @Event
END



--EXECUTE spGetAfviklingId @Event = 35, @Dato = '23-10-2019'

--INSERT INTO [UNDERSKUDS_GODTG�RELSE] VALUES( '70', '31-12-2020')

--INSERT INTO [KATEGORI] VALUES ('Rock')
--INSERT INTO [KATEGORI] VALUES ('Jazz')
--INSERT INTO [KATEGORI] VALUES ('Gastronomi')

--INSERT INTO [SAL] VALUES ('Store Sal', '200', 1500)