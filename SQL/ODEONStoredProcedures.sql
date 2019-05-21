drop procedure if exists spInsertEvent
drop procedure if exists spInsertEventKategori
drop procedure if exists spInsertAfvikling
drop procedure if exists spInsertBilletType
drop procedure if exists spGetBilletTypeId
drop procedure if exists spInsertSalgsTal
drop procedure if exists spGetAfviklingId
drop procedure if exists spGetUnderskudsGodtgørelse

go
Create PROCEDURE spInsertEvent(
	@EventNavn				AS		NVARCHAR(200)
	,@Markedsføring			AS		MONEY
	,@Koda					AS		FLOAT(24)
	,@Garantisum			AS		MONEY
	,@ArtistSplit			AS		FLOAT(24)
	,@VariableOmkostninger	AS		MONEY	
	,@OmkostningerNote		AS		NVARCHAR(400)
	,@VariableIndtægter		AS		MONEY
	,@IndtægterNote			AS		NVARCHAR(400)
	,@UnderskudsGodtgørelse AS		DATETIME2
)
AS
BEGIN
INSERT INTO [EVENT] VALUES (@EventNavn
							,@Markedsføring
							,@Koda
							,@Garantisum
							,@ArtistSplit
							,@VariableOmkostninger
							,@OmkostningerNote
							,@VariableIndtægter
							,@IndtægterNote
							,@UnderskudsGodtgørelse);
END

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

go


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

GO


CREATE PROCEDURE spInsertSalgsTal(
		@Bevægelse		INT
		,@BilletType	INT
		,@SalgsDato		DATETIME2
)
AS
BEGIN
INSERT INTO [SALGS_TAL] VALUES (@Bevægelse
								,@BilletType
								,@SalgsDato);
END


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

go

CREATE PROCEDURE spGetUnderskudsGodtgørelse
AS
BEGIN
SELECT
	ReturProcent
	,UdløbsDato
FROM
	[UNDERSKUDS_GODTGØRELSE]
WHERE
	UdløbsDato > GETDATE()
--order by UdløbsDato ASC
END
