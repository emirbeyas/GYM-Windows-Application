
--***********************************************
--************ DATABASE OLUŞTURMA ***************
--***********************************************

CREATE DATABASE SporSalonuDB
GO
USE SporSalonuDB
GO

--***********************************************
--****************  TABLOLAR   ******************
--***********************************************
CREATE TABLE tblUyeler
(
	uye_id				INT PRIMARY KEY IDENTITY,
	ad					NVARCHAR(50),
	soyad				NVARCHAR(50),
	dtarih				DATE,
	kayıt_tarih			DATE DEFAULT GETDATE(),
	uyelik_son_tarih	DATE,
	tel_no				NVARCHAR(11)
)
GO
CREATE TABLE tblUyeOlculeri
(
	olcu_id		INT PRIMARY KEY IDENTITY,
	kol			DECIMAL(5,2),
	gogus		DECIMAL(5,2),
	kalca		DECIMAL(5,2),
	bel			DECIMAL(5,2),
	boy			DECIMAL(5,2),
	kg			DECIMAL(5,2),
	tarih		DATE,
	uye_id		INT,
	CONSTRAINT fk_tblUyeler_to_tblUyeOlculeri FOREIGN KEY (uye_id) REFERENCES tblUyeler(uye_id) ON DELETE CASCADE
)
GO
CREATE TABLE tblOdemeler
(
	odeme_id		INT PRIMARY KEY IDENTITY,
	tarihsaat		DATETIME DEFAULT GETDATE(),
	odenen_ay_adet	TINYINT,
	ucret			SMALLMONEY, 
	uye_id			INT,
	CONSTRAINT fk_tblUyeler_to_tblOdemeler FOREIGN KEY (uye_id) REFERENCES tblUyeler(uye_id) ON DELETE CASCADE
)
GO
CREATE TABLE tblUyeProgramlari
(
	prog_id			INT PRIMARY KEY IDENTITY,
	prog_bas_tarih	DATE,
	is_aktif		BIT DEFAULT 1,
	aciklama		TEXT DEFAULT NULL,
	bitis_tarih		DATE,
	uye_id			INT,
	CONSTRAINT fk_tblUyeler_to_tblUyeProgramlari FOREIGN KEY (uye_id) REFERENCES tblUyeler(uye_id) ON DELETE CASCADE
)
GO

CREATE TABLE tblEgzersizKategorileri
(
	kat_id	INT PRIMARY KEY IDENTITY,
	kat_ad	NVARCHAR(50)
)
GO
CREATE TABLE tblEgzersizler
(
	egzersiz_id		INT PRIMARY KEY IDENTITY,
	egzersiz_ad		NVARCHAR(50),
	kat_id			INT,
	aciklama		TEXT DEFAULT NULL,
	birim_type			TINYINT, --tekrar sayisi için adet ya da dk...
	
	CONSTRAINT fk_tblEgzersizKategorileri_to_tblEgzersizler FOREIGN KEY (kat_id) REFERENCES tblEgzersizKategorileri(kat_id) ON DELETE SET NULL
)
GO

CREATE TABLE tblProgramEgzersizleri
(
	prog_egzersiz_id	INT PRIMARY KEY IDENTITY,
	gun					TINYINT,
	prog_id				INT,
	egzersiz_id			INT,
	set_adet			TINYINT,
	tekrar_sayisi		TINYINT,
	CONSTRAINT fk_tblUyeProgramlari_to_tblProgramDetaylari FOREIGN KEY (prog_id) REFERENCES tblUyeProgramlari(prog_id) ON DELETE CASCADE,
	CONSTRAINT fk_tblEgzersizler_to_tblProgramDetaylari FOREIGN KEY (egzersiz_id) REFERENCES tblEgzersizler(egzersiz_id) ON DELETE CASCADE,
)
GO

CREATE TABLE tblKullanicilar
(
	kullanici_adi	NVARCHAR(50) PRIMARY KEY,
	parola			NVARCHAR(16) NOT NULL,
	kullanici_type	TINYINT DEFAULT 3,
	ad				NVARCHAR(50),
	soyad			NVARCHAR(50),
)
GO

CREATE TABLE tblKullaniciYetkileri
(
	kullanici_adi	NVARCHAR(50) REFERENCES tblKullanicilar(kullanici_adi) ON DELETE CASCADE ON UPDATE CASCADE,
	tablo_type		TINYINT NOT NULL,
	islem_type		TINYINT NOT NULL,
	yetki_durum		BIT DEFAULT 0,
	CONSTRAINT pk_tblKullaniciYetkileri PRIMARY KEY CLUSTERED(kullanici_adi, tablo_type, islem_type)
)
GO


--***********************************************
--******* SİLİNEN KAYIT TABLOLARI   *************
--***********************************************

--tablo
CREATE TABLE SilinenOdemeKayitlari
(
	odeme_id		INT,
	tarihsaat		DATETIME,
	odenen_ay_adet	TINYINT,
	ucret			SMALLMONEY, 
	uye_id			INT,
)
GO
--Trigger'ı
CREATE TRIGGER trg_OdemeSilinenlereEkleme
ON tblOdemeler
AFTER DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM deleted) > 0
		INSERT INTO SilinenOdemeKayitlari SELECT * FROM deleted
END
GO




--tablo
CREATE TABLE SilinenUyeKayitlari
(
	uye_id				INT,
	ad					NVARCHAR(50),
	soyad				NVARCHAR(50),
	dtarih				DATE,
	kayıt_tarih			DATE,
	uyelik_son_tarih	DATE,
	tel_no				NVARCHAR(11)
)
GO
--Trigger'ı
CREATE TRIGGER trg_UyeSilinenlereEkleme
ON tblUyeler
AFTER DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM deleted) > 0
		INSERT INTO SilinenUyeKayitlari SELECT * FROM deleted
END


GO

--***************************************************
--***************************************************
--****************      VIEWS         ***************
--***************************************************
--***************************************************
CREATE VIEW vw_odemeler
AS
		SELECT  o.odeme_id,
				o.tarihsaat,
				o.odenen_ay_adet,
				o.ucret,
				o.uye_id,
				u.ad,
				u.soyad,
				u.dtarih,
				u.kayıt_tarih,
				u.uyelik_son_tarih,
				u.tel_no
		FROM tblOdemeler o
		INNER JOIN tblUyeler u ON u.uye_id = o.uye_id

GO

CREATE VIEW vw_ProgramEgzersizleri
AS
	SELECT	peg.prog_egzersiz_id,
			peg.gun,
			peg.prog_id,
			peg.egzersiz_id,
			eg.egzersiz_ad,
			eg.aciklama,
			eg.kat_id,
			egkat.kat_ad,
			peg.set_adet,
			peg.tekrar_sayisi,
			eg.birim_type
	FROM tblProgramEgzersizleri peg
	JOIN tblEgzersizler eg ON eg.egzersiz_id = peg.egzersiz_id
	JOIN tblEgzersizKategorileri egkat ON egkat.kat_id = eg.kat_id

GO

CREATE VIEW vw_Egzersizler
AS
	SELECT	eg.egzersiz_id,
				eg.egzersiz_ad,
				eg.kat_id,
				egkat.kat_ad,
				eg.aciklama,
				eg.birim_type
		FROM tblEgzersizler eg
		FULL JOIN tblEgzersizKategorileri egkat ON egkat.kat_id = eg.kat_id
GO
--***************************************************
--***************************************************
--****************      TRIGGERS      ***************
--***************************************************
--***************************************************
CREATE TRIGGER trg_OdemeEkle
ON tblOdemeler
AFTER INSERT
AS
BEGIN
	DECLARE @odenenAyAdet INT, @uye_id INT
	SELECT @uye_id = uye_id, @odenenAyAdet = odenen_ay_adet FROM inserted
	UPDATE tblUyeler SET uyelik_son_tarih = DATEADD(MONTH, @odenenAyAdet, uyelik_son_tarih) WHERE uye_id = @uye_id
END
GO

CREATE TRIGGER trg_OdemeSil
ON tblOdemeler
AFTER DELETE
AS
BEGIN
	DECLARE @odenenAyAdet INT, @uye_id INT
	SELECT @uye_id = uye_id, @odenenAyAdet = odenen_ay_adet FROM deleted
	UPDATE tblUyeler SET uyelik_son_tarih = DATEADD(MONTH, -@odenenAyAdet, uyelik_son_tarih) WHERE uye_id = @uye_id
END







GO
CREATE TRIGGER trg_UyeProgramEkleme
ON tblUyeProgramlari
INSTEAD OF INSERT, UPDATE
AS
BEGIN
	DECLARE @prog_id INT,
			@prog_bas_tarih DATE, 
			@is_aktif BIT, 
			@aciklama NVARCHAR(MAX),
			@bitis_tarih DATE,
			@uye_id INT

	SELECT	@prog_id = prog_id, 
			@prog_bas_tarih = prog_bas_tarih, 
			@is_aktif = is_aktif, 
			@aciklama = aciklama, 
			@bitis_tarih = bitis_tarih, 
			@uye_id = uye_id 
	FROM inserted

	--IF @is_aktif = 1
		--UPDATE tblUyeProgramlari SET is_aktif = 0, bitis_tarih = GETDATE() WHERE prog_id = (SELECT prog_id FROM tblUyeProgramlari WHERE is_aktif = 1 AND uye_id = @uye_id )  --tüm programlarını pasif yap
	IF @is_aktif = 1
		UPDATE tblUyeProgramlari SET is_aktif = 0, bitis_tarih = GETDATE() WHERE uye_id = @uye_id AND is_aktif = 1 --onceki aktif prog'u pasif yap

	IF(SELECT COUNT(*) FROM deleted) = 0 --güncelleme değilse kayıtı ekle
	BEGIN
		INSERT INTO tblUyeProgramlari VALUES(@prog_bas_tarih, @is_aktif, @aciklama, @bitis_tarih, @uye_id)
		SELECT @@IDENTITY
	END
	ELSE --guncellemeyse kaydı güncelle
	BEGIN
		UPDATE tblUyeProgramlari SET prog_bas_tarih = @prog_bas_tarih,
									 is_aktif = @is_aktif,
									 aciklama = @aciklama,
									 bitis_tarih = @bitis_tarih,
									 uye_id = @uye_id
		WHERE prog_id = @prog_id
	END
END

GO

CREATE TRIGGER trg_KullaniciYetkiEkle
ON tblKullanicilar
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @kullanici_adi NVARCHAR(50)
	DECLARE @kullanici_type TINYINT
	SELECT @kullanici_adi = kullanici_adi, @kullanici_type = kullanici_type FROM inserted


	DECLARE @tablo TINYINT = 1
	DECLARE @islem TINYINT = 1
	DECLARE @durum BIT
	IF @kullanici_type = 1 OR @kullanici_type = 2 --admin ise hepsine yetki ver
		SET @durum = 1
	ELSE
		SET @durum = 0

	WHILE @tablo <= 9
	BEGIN
		WHILE @islem <= 4
		BEGIN
			INSERT INTO tblKullaniciYetkileri VALUES(@kullanici_adi, @tablo, @islem, @durum)
			SET @islem = @islem + 1
		END
		SET @islem = 1
		SET @tablo = @tablo + 1
	END

	SET NOCOUNT OFF
END

GO

--***************************************************
--***************************************************
--**************** STORED PROCEDURES ***************
--***************************************************
--***************************************************

-- Üye
CREATE PROCEDURE sp_uye_ekle
	@ad			NVARCHAR(50),
	@soyad		NVARCHAR(50),
	@dtarih		DATE,
	@kayit_tarih DATE,
	@uyelik_son_tarih DATE,
	@tel_no		NVARCHAR(11)
AS

	 INSERT INTO tblUyeler VALUES(@ad, @soyad, @dtarih, @kayit_tarih, @uyelik_son_tarih, @tel_no)
	 SELECT @@IDENTITY
GO
CREATE PROCEDURE sp_uye_sil
	@uye_id	INT
AS
	DELETE FROM tblUyeler WHERE uye_id = @uye_id

GO
CREATE PROCEDURE sp_uye_guncelle
	@uye_id		INT,
	@ad			NVARCHAR(50),
	@soyad		NVARCHAR(50),
	@dtarih		DATE,
	@kayit_tarih DATE,
	@uyelik_son_tarih DATE,
	@tel_no		NVARCHAR(11)
AS
	 UPDATE tblUyeler SET ad = @ad, soyad = @soyad, dtarih = @dtarih, kayıt_tarih = @kayit_tarih, uyelik_son_tarih = @uyelik_son_tarih, tel_no = @tel_no WHERE uye_id = @uye_id
GO
CREATE PROCEDURE sp_uye_listele 
	@ad nvarchar(50) = NULL, 
	@soyad nvarchar(50) = NULL, 
	@tel_no nvarchar(11) = NULL,
	@sırala nvarchar(25) = 'ad DESC'
AS
	DECLARE @sorgu	nvarchar(max) = N''
	DECLARE @where nvarchar(max) = N''
	DECLARE @select nvarchar(MAX) = N'SELECT * FROM tblUyeler'

	IF @ad IS NOT NULL
		SET @where = ' WHERE ad LIKE ''%'+@ad+'%'''

	IF @soyad IS NOT NULL
		IF LEN(@where) > 0
			SET @where = @where+ ' AND soyad LIKE ''%' + @soyad+'%'''
		ELSE
			SET @where = ' WHERE soyad LIKE ''%'+@soyad+'%'''

	IF @tel_no IS NOT NULL
		IF LEN(@where) > 0
			SET @where = @where + ' AND tel_no LIKE ''%' + @tel_no+'%'''
		ELSE
			SET @where = ' WHERE tel_no LIKE ''%'+@tel_no+'%'''
	SET @sorgu = @select + @where + ' ORDER BY '+@sırala

	EXECUTE sp_executesql @sorgu


GO
CREATE PROCEDURE sp_uye_get
	@uye_id	INT
AS
	SELECT * FROM tblUyeler WHERE uye_id = @uye_id

GO

--Üye Ölçüleri
CREATE PROCEDURE sp_uyeolcu_list_uye
	@uye_id	INT
AS
	SELECT	ol.olcu_id,
			ol.uye_id,
			ol.kol,
			ol.gogus,
			ol.kalca,
			ol.bel,
			ol.boy,
			ol.kg,
			ol.tarih
	FROM tblUyeOlculeri ol
	WHERE ol.uye_id = @uye_id

GO
CREATE PROCEDURE sp_uyeolcu_get
	@olcu_id	INT
AS
	SELECT	ol.olcu_id,
			ol.uye_id,
			ol.kol,
			ol.gogus,
			ol.kalca,
			ol.bel,
			ol.boy,
			ol.kg,
			ol.tarih
	FROM tblUyeOlculeri ol WHERE olcu_id = @olcu_id

GO
CREATE PROCEDURE sp_uyeolcu_ekle
	@uye_id		INT,
	@kol		DECIMAL(5,2),
	@gogus		DECIMAL(5,2),
	@kalca		DECIMAL(5,2),
	@bel		DECIMAL(5,2),
	@boy		DECIMAL(5,2),
	@kg			DECIMAL(5,2),
	@tarih		DATE
AS
	INSERT INTO tblUyeOlculeri VALUES(@kol, @gogus, @kalca, @bel, @boy, @kg, @tarih, @uye_id)
	SELECT @@IDENTITY
GO
CREATE PROCEDURE sp_uyeolcu_sil
	@olcu_id	INT
AS
	DELETE FROM tblUyeOlculeri WHERE olcu_id = @olcu_id

GO
CREATE PROCEDURE sp_uyeolcu_guncelle
	@olcu_id	INT,
	@uye_id		INT,
	@kol		DECIMAL(5,2),
	@gogus		DECIMAL(5,2),
	@kalca		DECIMAL(5,2),
	@bel		DECIMAL(5,2),
	@boy		DECIMAL(5,2),
	@kg			DECIMAL(5,2),
	@tarih		DATE
AS
	UPDATE tblUyeOlculeri SET kol = @kol, gogus = @gogus, kalca = @kalca, bel = @bel, boy = @boy, kg = @kg, tarih = @tarih, uye_id = @uye_id
	WHERE olcu_id = @olcu_id


GO

--Egzersiz Kategorileri
CREATE PROCEDURE sp_egzersizKategori_listele
AS
	SELECT * FROM tblEgzersizKategorileri
GO
CREATE PROCEDURE sp_egzersizKategori_get
	@kat_id	INT
AS
	SELECT * FROM tblEgzersizKategorileri WHERE kat_id = @kat_id

GO
CREATE PROCEDURE sp_egzersizKategori_ekle
	@kat_ad NVARCHAR(50)
AS
	INSERT INTO tblEgzersizKategorileri VALUES(@kat_ad)
	SELECT @@IDENTITY

GO
CREATE PROCEDURE sp_egzersizKategori_guncelle
	@kat_id	INT,
	@kat_ad NVARCHAR(50)
AS
	UPDATE tblEgzersizKategorileri SET kat_ad = @kat_ad WHERE kat_id = @kat_id
GO
CREATE PROCEDURE sp_egzersizKategori_sil
	@kat_id	INT
AS
	DELETE FROM tblEgzersizKategorileri WHERE kat_id = @kat_id
GO

--UyeProgramlari
CREATE PROCEDURE sp_uyeProg_listele_all
AS
	SELECT * FROM tblUyeProgramlari
GO
CREATE PROCEDURE sp_uyeProg_listele
	@uye_id	INT
AS
	SELECT * FROM tblUyeProgramlari WHERE uye_id = @uye_id

GO
CREATE PROCEDURE sp_uyeProg_get
	@prog_id INT
AS
	SELECT * FROM tblUyeProgramlari WHERE prog_id = @prog_id

GO
CREATE PROCEDURE sp_uyeProg_ekle
	@prog_bas_tarih	DATE,
	@is_aktif		BIT,
	@aciklama		TEXT,
	@bitis_tarih	DATE,
	@uye_id			INT
AS
	INSERT INTO tblUyeProgramlari VALUES(@prog_bas_tarih, @is_aktif, @aciklama, @bitis_tarih, @uye_id)
	SELECT @@IDENTITY

GO
CREATE PROCEDURE sp_uyeProg_guncelle
	@prog_id		INT,
	@prog_bas_tarih	DATE,
	@is_aktif		BIT,
	@aciklama		TEXT,
	@bitis_tarih	DATE,
	@uye_id			INT
AS
	UPDATE tblUyeProgramlari SET prog_bas_tarih = @prog_bas_tarih, is_aktif = @is_aktif, aciklama = @aciklama, bitis_tarih = @bitis_tarih, uye_id = @uye_id
	WHERE prog_id = @prog_id

GO
CREATE PROCEDURE sp_uyeProg_sil
	@prog_id		INT
AS
	DELETE FROM tblUyeProgramlari WHERE prog_id = @prog_id

GO

--Program Egzersizleri
CREATE PROCEDURE sp_progEgzersiz_listele_all
AS
	SELECT	* FROM vw_ProgramEgzersizleri
GO
CREATE PROCEDURE sp_progEgzersiz_listele
	@prog_id	INT
AS
	SELECT	* FROM vw_ProgramEgzersizleri
	WHERE prog_id = @prog_id

GO
ALTER PROCEDURE sp_progEgzersiz_get
	@prog_egzersiz_id	INT
AS
	SELECT	* FROM vw_ProgramEgzersizleri
	WHERE prog_egzersiz_id = @prog_egzersiz_id
GO
CREATE PROCEDURE sp_progEgzersiz_ekle
	@gun			INT,
	@prog_id		INT,
	@egzersiz_id	INT,
	@set_adet		INT,
	@tekrar_sayisi	INT
AS
	INSERT INTO tblProgramEgzersizleri VALUES(@gun, @prog_id, @egzersiz_id, @set_adet, @tekrar_sayisi)
	SELECT @@IDENTITY

GO
CREATE PROCEDURE sp_progEgzersiz_guncelle
	@prog_egzersiz_id	INT,
	@gun				INT,
	@prog_id			INT,
	@egzersiz_id		INT,
	@set_adet			INT,
	@tekrar_sayisi		INT
AS
	UPDATE tblProgramEgzersizleri 
	SET gun = @gun, prog_id = @prog_id, egzersiz_id = @egzersiz_id, set_adet = @set_adet, tekrar_sayisi = @tekrar_sayisi
	WHERE prog_egzersiz_id = @prog_egzersiz_id

GO
CREATE PROCEDURE sp_progEgzersiz_sil
	@prog_egzersiz_id	INT
AS
	DELETE FROM tblProgramEgzersizleri WHERE prog_egzersiz_id = @prog_egzersiz_id

GO

--Egzersizler
CREATE PROCEDURE sp_egzersiz_listele
	@kat_id		INT =  NULL, @egzersiz_ad NVARCHAR(50) = NULL
AS 
	IF @egzersiz_ad IS NULL
		SET @egzersiz_ad = N''
	PRINT @egzersiz_ad
	IF @kat_id IS NOT NULL
		SELECT * FROM vw_Egzersizler WHERE kat_id = @kat_id AND egzersiz_ad LIKE '%'+@egzersiz_ad+'%'
	ELSE
		SELECT	* FROM vw_Egzersizler WHERE egzersiz_ad LIKE '%'+@egzersiz_ad+'%'
GO
CREATE PROCEDURE sp_egzersiz_listele_kategori
	@kat_id	int
AS
	SELECT	* FROM vw_Egzersizler WHERE kat_id = @kat_id

GO
CREATE PROCEDURE sp_egzersiz_get
	@egzersiz_id	INT
AS
	SELECT	* FROM vw_Egzersizler WHERE egzersiz_id = @egzersiz_id

GO
CREATE PROCEDURE sp_egzersiz_ekle
	@egzersiz_ad	NVARCHAR(50),
	@kat_id			INT,
	@aciklama		TEXT,
	@birim_type		INT
AS
	INSERT INTO tblEgzersizler VALUES(@egzersiz_ad, @kat_id, @aciklama, @birim_type)
	SELECT @@IDENTITY

GO
CREATE PROCEDURE sp_egzersiz_guncelle
	@egzersiz_id	INT,
	@egzersiz_ad	NVARCHAR(50),
	@kat_id			INT,
	@aciklama		TEXT,
	@birim_type		INT
AS
	UPDATE tblEgzersizler SET egzersiz_ad = @egzersiz_ad, kat_id = @kat_id, aciklama = @aciklama, birim_type = @birim_type
	WHERE egzersiz_id = @egzersiz_id

GO
CREATE PROCEDURE sp_egzersiz_sil
	@egzersiz_id	INT
AS
	DELETE FROM tblEgzersizler WHERE egzersiz_id = @egzersiz_id

GO

--ODEME işlemleri
CREATE PROCEDURE sp_odeme_listele
	@uye_id INT = NULL, 
	@alt DATETIME = NULL,
	@ust DATETIME = NULL, 
	@sırala INT
AS  
	
	IF @alt IS NULL AND @uye_id IS NULL --her ikisi null ise
		SELECT * FROM vw_odemeler 
		ORDER BY CASE WHEN @sırala = 1 THEN ad END DESC,
				 CASE WHEN @sırala = 2 THEN ad END ASC,
				 CASE WHEN @sırala = 3 THEN tarihsaat END DESC,
				 CASE WHEN @sırala = 4 THEN tarihsaat END ASC
	ELSE IF @alt IS NOT NULL AND @uye_id IS NOT NULL --her ikisi nul degilse
		SELECT * FROM vw_odemeler WHERE uye_id = @uye_id AND tarihsaat BETWEEN @alt AND @ust
		ORDER BY CASE WHEN @sırala = 1 THEN ad END DESC,
				 CASE WHEN @sırala = 2 THEN ad END ASC,
				 CASE WHEN @sırala = 3 THEN tarihsaat END DESC,
				 CASE WHEN @sırala = 4 THEN tarihsaat END ASC
	ELSE IF @alt IS NOT NULL --alt sınır null değilse
		SELECT * FROM vw_odemeler  WHERE  tarihsaat BETWEEN @alt AND @ust
		ORDER BY CASE WHEN @sırala = 1 THEN ad END DESC,
				 CASE WHEN @sırala = 2 THEN ad END ASC,
				 CASE WHEN @sırala = 3 THEN tarihsaat END DESC,
				 CASE WHEN @sırala = 4 THEN tarihsaat END ASC
	ELSE IF @uye_id IS NOT NULL --uye id null değilse
		SELECT * FROM vw_odemeler  WHERE  uye_id = @uye_id
		ORDER BY CASE WHEN @sırala = 1 THEN ad END DESC,
				 CASE WHEN @sırala = 2 THEN ad END ASC,
				 CASE WHEN @sırala = 3 THEN tarihsaat END DESC,
				 CASE WHEN @sırala = 4 THEN tarihsaat END ASC

GO
CREATE PROCEDURE sp_odeme_get
	@odeme_id	INT
AS
	SELECT  * FROM vw_odemeler WHERE odeme_id = @odeme_id

GO
CREATE PROCEDURE sp_odeme_ekle
	@tarihsaat		DATETIME,
	@odenen_ay_adet	TINYINT,
	@ucret			SMALLMONEY,
	@uye_id			INT
AS
	INSERT INTO tblOdemeler VALUES(@tarihsaat, @odenen_ay_adet, @ucret, @uye_id)
	SELECT @@IDENTITY

GO
CREATE PROCEDURE sp_odeme_guncelle
	@odeme_id		INT,
	@tarihsaat		DATETIME,
	@odenen_ay_adet	TINYINT,
	@ucret			SMALLMONEY,
	@uye_id			INT
AS
	UPDATE tblOdemeler SET tarihsaat = @tarihsaat, odenen_ay_adet = @odenen_ay_adet,
	ucret = @ucret, uye_id = @uye_id WHERE odeme_id = @odeme_id

GO
CREATE PROCEDURE sp_odeme_sil
	@odeme_id		INT
AS
	DELETE FROM tblOdemeler WHERE odeme_id = @odeme_id
GO

--***************************************
--Kullanici İşlemleri
--**********************************
CREATE PROCEDURE sp_kullanici_ekle
	@kullanici_adi		NVARCHAR(50),
	@parola				NVARCHAR(16),
	@kullanici_type		TINYINT,
	@ad					NVARCHAR(50),
	@soyad				NVARCHAR(50)
AS
	IF (SELECT COUNT(*) FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi) = 0
		INSERT INTO tblKullanicilar VALUES(@kullanici_adi, @parola, @kullanici_type, @ad, @soyad)
	ELSE
		RAISERROR('Bu kullanıcı adına sahip kullanıcı zaten mevcut. Başka bir kullanıcı adı belirleyin.', 16, 1)

GO
CREATE PROCEDURE sp_kullanici_guncelle
	@old_kullanici_adi	NVARCHAR(50),
	@kullanici_adi		NVARCHAR(50),
	@parola				NVARCHAR(16),
	@kullanici_type		TINYINT,
	@ad					NVARCHAR(50),
	@soyad				NVARCHAR(50)
AS
	IF @kullanici_adi = @old_kullanici_adi OR (SELECT COUNT(*) FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi) = 0
		UPDATE tblKullanicilar SET kullanici_adi = @kullanici_adi, parola = @parola, kullanici_type = @kullanici_type, ad = @ad, soyad = @soyad
		WHERE kullanici_adi = @old_kullanici_adi
	ELSE
		RAISERROR('Bu kullanıcı adına sahip kullanıcı zaten mevcut. Başka bir kullanıcı adı belirleyin.', 16, 1)

GO
CREATE PROCEDURE sp_kullanici_sil
	@kullanici_adi NVARCHAR(50)
AS
	DELETE FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi

GO
CREATE PROCEDURE sp_kullanici_get
	@kullanici_adi NVARCHAR(50)
AS
	SELECT * FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi
	SELECT * FROM tblKullaniciYetkileri WHERE kullanici_adi = @kullanici_adi --Multiple Recorset

GO
CREATE PROCEDURE sp_kullanici_listele
AS
	SELECT * FROM tblKullanicilar

GO
CREATE PROCEDURE sp_kullanici_login
	@kullanici_adi	NVARCHAR(50),
	@parola			NVARCHAR(16)
AS
	IF (SELECT COUNT(*) FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi AND parola = @parola) > 0
		SELECT 1 --Giriş başarılı
	ELSE
		SELECT 0 --kullanıcı adı ya da parola hatalı

GO

-- Kullanıcı Yetki İşlemleri
CREATE PROCEDURE sp_kullanici_yetki_get
	@kullanici_adi	NVARCHAR(50),
	@tablo_type		TINYINT
AS
	SELECT * FROM tblKullaniciYetkileri WHERE kullanici_adi = @kullanici_adi AND tablo_type = @tablo_type

GO
CREATE PROCEDURE sp_kullanici_yetki_guncelle
	@kullanici_adi	NVARCHAR(50),
	@tablo_type		TINYINT,
	@islem_type		TINYINT,
	@yetki_durum	BIT
AS
	UPDATE tblKullaniciYetkileri SET yetki_durum = @yetki_durum 
	WHERE kullanici_adi = @kullanici_adi AND tablo_type = @tablo_type AND islem_type = @islem_type


GO

--**************************************************
-- MainView Count Procedure
--*************************************************
CREATE PROCEDURE sp_main_view_counts
AS
	SELECT	(SELECT COUNT(*) FROM tblUyeler) as uye_count,
			(SELECT COUNT(*) FROM tblEgzersizler) as egzersiz_count,
			(SELECT COUNT(*) FROM tblUyeProgramlari WHERE is_aktif = 1) AS aktif_prog_count,
			(SELECT COUNT(*) FROM tblKullanicilar) AS kullanici_count

GO
CREATE PROCEDURE sp_bugun_antrenmani_olanlar
AS
	SELECT * FROM tblUyeler 
		WHERE uyelik_son_tarih > GETDATE() --üyelik son tarihi geçmemiş olanlar
		AND uye_id IN(
					  SELECT uye_id FROM tblUyeProgramlari
						WHERE is_aktif = 1  --aktif program
						AND prog_id IN(
										  SELECT DISTINCT prog_id FROM tblProgramEgzersizleri WHERE gun = DATEPART(WEEKDAY, GETDATE()) --bugünkü egzersizlerin prog_id'leri distinct
								      )
					 )

GO