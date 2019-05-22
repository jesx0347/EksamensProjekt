insert into [UNDERSKUDS_GODTGØRELSE] values(75, '2020-12-31');
insert into [UNDERSKUDS_GODTGØRELSE] values(0, '9999-12-31');

insert into [SAL] (SalNavn, Leje, Kapacitet) values ('Store Sal', 50000, 1740) -- id 1
insert into [SAL] (SalNavn, Leje, Kapacitet) values ('Sidescenen', 37500, 600) -- id 2

insert into [KATEGORI] ([KategoriNavn]) values('Comedy'); -- 1
insert into [KATEGORI] ([KategoriNavn]) values('Familie & Børn'); -- 2
insert into [KATEGORI] ([KategoriNavn]) values('Fællesskab'); -- 3
insert into [KATEGORI] ([KategoriNavn]) values('Foredrag o.ling.'); -- 4
insert into [KATEGORI] ([KategoriNavn]) values('Fri Entré'); -- 5
insert into [KATEGORI] ([KategoriNavn]) values('Gastronomi'); -- 6
insert into [KATEGORI] ([KategoriNavn]) values('Jazz'); --7
insert into [KATEGORI] ([KategoriNavn]) values('Klassisk, Opera & Ballet'); -- 8
insert into [KATEGORI] ([KategoriNavn]) values('Koncertmenu'); -- 9
insert into [KATEGORI] ([KategoriNavn]) values('Kunst & Udstilling'); -- 10
insert into [KATEGORI] ([KategoriNavn]) values('Musical'); -- 11
insert into [KATEGORI] ([KategoriNavn]) values('Pop & Rock'); -- 12
insert into [KATEGORI] ([KategoriNavn]) values('Rundvisning'); -- 13
insert into [KATEGORI] ([KategoriNavn]) values('Show'); -- 14
insert into [KATEGORI] ([KategoriNavn]) values('Teater'); -- 15
insert into [KATEGORI] ([KategoriNavn]) values('Velvære'); -- 16

--insert into [EVENT] values(
--	('Kage Smaning', 1000.00, 0, 1500, 15, 0, 'none', 0, 'none', CONVERT(datetime2, '2020-01-01 00:00:01 AM',5)),
--	('Metel', 10000.00, 12, 8000.00, 65, 0, 'none', 0, 'none', CONVERT(datetime2, '2020-01-01 00:00:01 AM',5)),
--	('Jazz', 8000.00, 10, 6500, 60, 0, 'none', 0, 'none', CONVERT(datetime2, '2020-01-01 00:00:01 AM',5)),
--	);

insert into [EVENT] values ('Kage Smaning', 1000.00, 0, 1500, 15, 0, 'none', 0, 'none', '2020-12-31') -- id 1
	insert into [EVENT_KATEGORI] ([Event], [Kategori]) values (1, 6)
	insert into [AFVIKLING] values ('2020-01-01', 1, 2) -- id 1
		insert into [BILLET_TYPE] values (600, 100, 1) -- 1
			insert into [SALGS_TAL] values (25, 1, '2019-12-25')
			insert into [SALGS_TAL] values (18, 1, '2019-12-26')
			insert into [SALGS_TAL] values (15, 1, '2019-12-27')
			insert into [SALGS_TAL] values (30, 1, '2019-12-28')
	insert into [AFVIKLING] values ('2020-01-02', 1, 2) -- id 2
		insert into [BILLET_TYPE] values (600, 100, 2) -- 2
			insert into [SALGS_TAL] values (25, 2, '2019-12-25')
			insert into [SALGS_TAL] values (18, 2, '2019-12-26')
			insert into [SALGS_TAL] values (15, 2, '2019-12-27')
			insert into [SALGS_TAL] values (30, 2, '2019-12-28')


insert into [EVENT] values ('Metel', 10000.00, 12, 8000.00, 65, 0, 'none', 0, 'none', '2020-12-31') -- id 2
	insert into [EVENT_KATEGORI] ([Event], [Kategori]) values (2, 12)
	insert into [AFVIKLING] values ('2020-10-01', 2, 1) -- id 3
		insert into [BILLET_TYPE] values (240, 1000, 3) -- 3
			insert into [SALGS_TAL] values (50, 3, '2020-05-01')
			insert into [SALGS_TAL] values (45, 3, '2020-06-01')
			insert into [SALGS_TAL] values (49, 3, '2020-07-01')
			insert into [SALGS_TAL] values (60, 3, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 750, 3)  -- 4
			insert into [SALGS_TAL] values (100, 4, '2020-05-01')
			insert into [SALGS_TAL] values (90, 4, '2020-06-01')
			insert into [SALGS_TAL] values (98, 4, '2020-07-01')
			insert into [SALGS_TAL] values (120, 4, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 500, 3) -- 5
			insert into [SALGS_TAL] values (50, 5, '2020-05-01')
			insert into [SALGS_TAL] values (45, 5, '2020-06-01')
			insert into [SALGS_TAL] values (49, 5, '2020-07-01')
			insert into [SALGS_TAL] values (60, 5, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 250, 3) -- 6
			insert into [SALGS_TAL] values (50, 6, '2020-05-01')
			insert into [SALGS_TAL] values (45, 6, '2020-06-01')
			insert into [SALGS_TAL] values (49, 6, '2020-07-01')
			insert into [SALGS_TAL] values (60, 6, '2020-08-01')
	insert into [AFVIKLING] values ('2020-10-02', 2, 1) -- id 4
		insert into [BILLET_TYPE] values (240, 1000, 4) -- 7
			insert into [SALGS_TAL] values (50, 7, '2020-05-01')
			insert into [SALGS_TAL] values (45, 7, '2020-06-01')
			insert into [SALGS_TAL] values (49, 7, '2020-07-01')
			insert into [SALGS_TAL] values (60, 7, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 750, 4) -- 8
			insert into [SALGS_TAL] values (50, 8, '2020-05-01')
			insert into [SALGS_TAL] values (45, 8, '2020-06-01')
			insert into [SALGS_TAL] values (49, 8, '2020-07-01')
			insert into [SALGS_TAL] values (60, 8, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 500, 4) -- 9
			insert into [SALGS_TAL] values (50, 9, '2020-05-01')
			insert into [SALGS_TAL] values (45, 9, '2020-06-01')
			insert into [SALGS_TAL] values (49, 9, '2020-07-01')
			insert into [SALGS_TAL] values (60, 9, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 250, 4) -- 10
			insert into [SALGS_TAL] values (50, 10, '2020-05-01')
			insert into [SALGS_TAL] values (45, 10, '2020-06-01')
			insert into [SALGS_TAL] values (49, 10, '2020-07-01')
			insert into [SALGS_TAL] values (60, 10, '2020-08-01')
	insert into [AFVIKLING] values ('2020-10-03', 2, 1) -- id 5
		insert into [BILLET_TYPE] values (240, 1000, 5) -- 11
			insert into [SALGS_TAL] values (50, 11, '2020-05-01')
			insert into [SALGS_TAL] values (45, 11, '2020-06-01')
			insert into [SALGS_TAL] values (49, 11, '2020-07-01')
			insert into [SALGS_TAL] values (60, 11, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 750, 5) -- 12
			insert into [SALGS_TAL] values (50, 12, '2020-05-01')
			insert into [SALGS_TAL] values (45, 12, '2020-06-01')
			insert into [SALGS_TAL] values (49, 12, '2020-07-01')
			insert into [SALGS_TAL] values (60, 12, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 500, 5) -- 13
			insert into [SALGS_TAL] values (50, 13, '2020-05-01')
			insert into [SALGS_TAL] values (45, 13, '2020-06-01')
			insert into [SALGS_TAL] values (49, 13, '2020-07-01')
			insert into [SALGS_TAL] values (60, 13, '2020-08-01')
		insert into [BILLET_TYPE] values (500, 250, 5) -- 14
			insert into [SALGS_TAL] values (50, 14, '2020-05-01')
			insert into [SALGS_TAL] values (45, 14, '2020-06-01')
			insert into [SALGS_TAL] values (49, 14, '2020-07-01')
			insert into [SALGS_TAL] values (60, 14, '2020-08-01')

	
insert into [EVENT] values ('Jazz', 8000.00, 10, 6500, 60, 0, 'none', 0, 'none', '2020-12-31') -- id 3
	insert into [EVENT_KATEGORI] ([Event], [Kategori]) values (3, 7)
	insert into [AFVIKLING] values ('2020-06-12', 3, 1) -- id 6
		insert into [BILLET_TYPE] values (740, 375, 6) -- 15
			insert into [SALGS_TAL] values (60, 15, '2020-06-08')
			insert into [SALGS_TAL] values (60, 15, '2020-06-09')
			insert into [SALGS_TAL] values (60, 15, '2020-06-10')
		insert into [BILLET_TYPE] values (1000, 250, 6) -- 16
			insert into [SALGS_TAL] values (60, 16, '2020-06-08')
			insert into [SALGS_TAL] values (60, 16, '2020-06-09')
			insert into [SALGS_TAL] values (60, 16, '2020-06-10')
	insert into [AFVIKLING] values ('2020-06-13', 3, 1) -- id 7
		insert into [BILLET_TYPE] values (740, 375, 7) -- 17
			insert into [SALGS_TAL] values (60, 17, '2020-06-08')
			insert into [SALGS_TAL] values (60, 17, '2020-06-09')
			insert into [SALGS_TAL] values (60, 17, '2020-06-10')
		insert into [BILLET_TYPE] values (1000, 250, 7) -- 18
			insert into [SALGS_TAL] values (60, 18, '2020-06-08')
			insert into [SALGS_TAL] values (60, 18, '2020-06-09')
			insert into [SALGS_TAL] values (60, 18, '2020-06-10')
	insert into [AFVIKLING] values ('2020-06-19', 3, 1) -- id 8
		insert into [BILLET_TYPE] values (740, 375, 8) -- 19
			insert into [SALGS_TAL] values (60, 19, '2020-06-08')
			insert into [SALGS_TAL] values (60, 19, '2020-06-09')
			insert into [SALGS_TAL] values (60, 19, '2020-06-10')
		insert into [BILLET_TYPE] values (1000, 250, 8) -- 20
			insert into [SALGS_TAL] values (60, 20, '2020-06-08')
			insert into [SALGS_TAL] values (60, 20, '2020-06-09')
			insert into [SALGS_TAL] values (60, 20, '2020-06-10')