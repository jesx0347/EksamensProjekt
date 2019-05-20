EXECUTE spInsertEvent	@EventNavn='ODEON'
						,@Markedsf�ring='500.55'
						,@Koda='10'
						,@Garantisum='4599.346'
						,@ArtistSplit='70'
						,@VariableOmkostninger='300'
						,@OmkostningerNote='Ekstra lys: 300kr'
						,@VariableIndt�gter='300'
						,@Indt�gterNote='D�kning af lys: 300'
						,@UnderskudsGodtg�relse='2020-12-31'


EXECUTE	spInsertEventKategori	@Event='35'
								,@Kategori='1'
EXECUTE	spInsertEventKategori	@Event='35'
								,@Kategori='3'

EXECUTE spInsertAfvikling	@Dato='23-10-2019'
							,@Event='35'
							,@Sal='2'

EXECUTE spInsertBilletType	@Udbud=200
							,@Pris=234.99
							,@Afvikling=1

EXECUTE spGetBilletTypeId @Pris = 234.99, @Afvikling = 1

EXECUTE spInsertSalgsTal	@Bev�gelse=23
						,@BilletType=1
						,@SalgsDato='20-10-2020'

EXECUTE spGetAfviklingId @Event = 35, @Dato = '23-10-2019'

INSERT INTO [UNDERSKUDS_GODTG�RELSE] VALUES( '70', '31-12-2020')

INSERT INTO [KATEGORI] VALUES ('Rock')
INSERT INTO [KATEGORI] VALUES ('Jazz')
INSERT INTO [KATEGORI] VALUES ('Gastronomi')

INSERT INTO [SAL] VALUES ('Store Sal', '200', 1500)

EXECUTE spGetAfviklingId @Event = 35, @Dato = '23-10-2019'
