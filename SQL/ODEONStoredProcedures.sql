drop procedure if exists spInsertEvent
drop procedure if exists spInsertEventKategori
drop procedure if exists spInsertAfvikling
drop procedure if exists spInsertBilletType
drop procedure if exists spGetBilletTypeId
drop procedure if exists spInsertSalgsTal
drop procedure if exists spGetAfviklingId
drop procedure if exists spGetUnderskudsGodtg�relse

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

CREATE PROCEDURE spGetUnderskudsGodtg�relse
AS
BEGIN
SELECT
	ReturProcent
	,Udl�bsDato
FROM
	[UNDERSKUDS_GODTG�RELSE]
WHERE
	Udl�bsDato > GETDATE()
--order by Udl�bsDato ASC
END
