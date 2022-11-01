USE [master]
GO
/****** Object:  Database [SporSalonuDB]    Script Date: 1.01.2021 12:31:20 ******/
CREATE DATABASE [SporSalonuDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SporSalonuDB_v2', FILENAME = N'C:\Users\Âdem\SporSalonuDB_v2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SporSalonuDB_v2_log', FILENAME = N'C:\Users\Âdem\SporSalonuDB_v2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SporSalonuDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SporSalonuDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SporSalonuDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SporSalonuDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SporSalonuDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SporSalonuDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SporSalonuDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SporSalonuDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SporSalonuDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SporSalonuDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SporSalonuDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SporSalonuDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SporSalonuDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SporSalonuDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SporSalonuDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SporSalonuDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SporSalonuDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SporSalonuDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SporSalonuDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SporSalonuDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SporSalonuDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SporSalonuDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SporSalonuDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SporSalonuDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SporSalonuDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SporSalonuDB] SET  MULTI_USER 
GO
ALTER DATABASE [SporSalonuDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SporSalonuDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SporSalonuDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SporSalonuDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SporSalonuDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SporSalonuDB] SET QUERY_STORE = OFF
GO
USE [SporSalonuDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SporSalonuDB]
GO
/****** Object:  Table [dbo].[tblUyeler]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUyeler](
	[uye_id] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[dtarih] [date] NULL,
	[kayıt_tarih] [date] NULL,
	[uyelik_son_tarih] [date] NULL,
	[tel_no] [nvarchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[uye_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOdemeler]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOdemeler](
	[odeme_id] [int] IDENTITY(1,1) NOT NULL,
	[tarihsaat] [datetime] NULL,
	[odenen_ay_adet] [tinyint] NULL,
	[ucret] [smallmoney] NULL,
	[uye_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[odeme_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_odemeler]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_odemeler]
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
/****** Object:  Table [dbo].[tblEgzersizKategorileri]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEgzersizKategorileri](
	[kat_id] [int] IDENTITY(1,1) NOT NULL,
	[kat_ad] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[kat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEgzersizler]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEgzersizler](
	[egzersiz_id] [int] IDENTITY(1,1) NOT NULL,
	[egzersiz_ad] [nvarchar](50) NULL,
	[kat_id] [int] NULL,
	[aciklama] [text] NULL,
	[birim_type] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[egzersiz_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProgramEgzersizleri]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProgramEgzersizleri](
	[prog_egzersiz_id] [int] IDENTITY(1,1) NOT NULL,
	[gun] [tinyint] NULL,
	[prog_id] [int] NULL,
	[egzersiz_id] [int] NULL,
	[set_adet] [tinyint] NULL,
	[tekrar_sayisi] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[prog_egzersiz_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_ProgramEgzersizleri]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ProgramEgzersizleri]
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
/****** Object:  View [dbo].[vw_Egzersizler]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Egzersizler]
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
/****** Object:  Table [dbo].[SilinenOdemeKayitlari]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenOdemeKayitlari](
	[odeme_id] [int] NULL,
	[tarihsaat] [datetime] NULL,
	[odenen_ay_adet] [tinyint] NULL,
	[ucret] [smallmoney] NULL,
	[uye_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenUyeKayitlari]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenUyeKayitlari](
	[uye_id] [int] NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[dtarih] [date] NULL,
	[kayıt_tarih] [date] NULL,
	[uyelik_son_tarih] [date] NULL,
	[tel_no] [nvarchar](11) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKullanicilar]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKullanicilar](
	[kullanici_adi] [nvarchar](50) NOT NULL,
	[parola] [nvarchar](16) NOT NULL,
	[kullanici_type] [tinyint] NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[kullanici_adi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKullaniciYetkileri]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKullaniciYetkileri](
	[kullanici_adi] [nvarchar](50) NOT NULL,
	[tablo_type] [tinyint] NOT NULL,
	[islem_type] [tinyint] NOT NULL,
	[yetki_durum] [bit] NULL,
 CONSTRAINT [pk_tblKullaniciYetkileri] PRIMARY KEY CLUSTERED 
(
	[kullanici_adi] ASC,
	[tablo_type] ASC,
	[islem_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUyeOlculeri]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUyeOlculeri](
	[olcu_id] [int] IDENTITY(1,1) NOT NULL,
	[kol] [decimal](5, 2) NULL,
	[gogus] [decimal](5, 2) NULL,
	[kalca] [decimal](5, 2) NULL,
	[bel] [decimal](5, 2) NULL,
	[boy] [decimal](5, 2) NULL,
	[kg] [decimal](5, 2) NULL,
	[tarih] [date] NULL,
	[uye_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[olcu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUyeProgramlari]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUyeProgramlari](
	[prog_id] [int] IDENTITY(1,1) NOT NULL,
	[prog_bas_tarih] [date] NULL,
	[is_aktif] [bit] NULL,
	[aciklama] [text] NULL,
	[bitis_tarih] [date] NULL,
	[uye_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[prog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[SilinenOdemeKayitlari] ADD  DEFAULT (getdate()) FOR [tarihsaat]
GO
ALTER TABLE [dbo].[SilinenUyeKayitlari] ADD  DEFAULT (getdate()) FOR [kayıt_tarih]
GO
ALTER TABLE [dbo].[tblEgzersizler] ADD  DEFAULT (NULL) FOR [aciklama]
GO
ALTER TABLE [dbo].[tblKullanicilar] ADD  DEFAULT ((3)) FOR [kullanici_type]
GO
ALTER TABLE [dbo].[tblKullaniciYetkileri] ADD  DEFAULT ((0)) FOR [yetki_durum]
GO
ALTER TABLE [dbo].[tblOdemeler] ADD  DEFAULT (getdate()) FOR [tarihsaat]
GO
ALTER TABLE [dbo].[tblUyeler] ADD  DEFAULT (getdate()) FOR [kayıt_tarih]
GO
ALTER TABLE [dbo].[tblUyeProgramlari] ADD  DEFAULT ((1)) FOR [is_aktif]
GO
ALTER TABLE [dbo].[tblUyeProgramlari] ADD  DEFAULT (NULL) FOR [aciklama]
GO
ALTER TABLE [dbo].[tblEgzersizler]  WITH CHECK ADD  CONSTRAINT [fk_tblEgzersizKategorileri_to_tblEgzersizler] FOREIGN KEY([kat_id])
REFERENCES [dbo].[tblEgzersizKategorileri] ([kat_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[tblEgzersizler] CHECK CONSTRAINT [fk_tblEgzersizKategorileri_to_tblEgzersizler]
GO
ALTER TABLE [dbo].[tblKullaniciYetkileri]  WITH CHECK ADD FOREIGN KEY([kullanici_adi])
REFERENCES [dbo].[tblKullanicilar] ([kullanici_adi])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblOdemeler]  WITH CHECK ADD  CONSTRAINT [fk_tblUyeler_to_tblOdemeler] FOREIGN KEY([uye_id])
REFERENCES [dbo].[tblUyeler] ([uye_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblOdemeler] CHECK CONSTRAINT [fk_tblUyeler_to_tblOdemeler]
GO
ALTER TABLE [dbo].[tblProgramEgzersizleri]  WITH CHECK ADD  CONSTRAINT [fk_tblEgzersizler_to_tblProgramDetaylari] FOREIGN KEY([egzersiz_id])
REFERENCES [dbo].[tblEgzersizler] ([egzersiz_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblProgramEgzersizleri] CHECK CONSTRAINT [fk_tblEgzersizler_to_tblProgramDetaylari]
GO
ALTER TABLE [dbo].[tblProgramEgzersizleri]  WITH CHECK ADD  CONSTRAINT [fk_tblUyeProgramlari_to_tblProgramDetaylari] FOREIGN KEY([prog_id])
REFERENCES [dbo].[tblUyeProgramlari] ([prog_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblProgramEgzersizleri] CHECK CONSTRAINT [fk_tblUyeProgramlari_to_tblProgramDetaylari]
GO
ALTER TABLE [dbo].[tblUyeOlculeri]  WITH CHECK ADD  CONSTRAINT [fk_tblUyeler_to_tblUyeOlculeri] FOREIGN KEY([uye_id])
REFERENCES [dbo].[tblUyeler] ([uye_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUyeOlculeri] CHECK CONSTRAINT [fk_tblUyeler_to_tblUyeOlculeri]
GO
ALTER TABLE [dbo].[tblUyeProgramlari]  WITH CHECK ADD  CONSTRAINT [fk_tblUyeler_to_tblUyeProgramlari] FOREIGN KEY([uye_id])
REFERENCES [dbo].[tblUyeler] ([uye_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUyeProgramlari] CHECK CONSTRAINT [fk_tblUyeler_to_tblUyeProgramlari]
GO
/****** Object:  StoredProcedure [dbo].[sp_bugun_antrenmani_olanlar]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_bugun_antrenmani_olanlar]
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
/****** Object:  StoredProcedure [dbo].[sp_egzersiz_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersiz_ekle]
	@egzersiz_ad	NVARCHAR(50),
	@kat_id			INT,
	@aciklama		TEXT,
	@birim_type		INT
AS
	INSERT INTO tblEgzersizler VALUES(@egzersiz_ad, @kat_id, @aciklama, @birim_type)
	SELECT @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[sp_egzersiz_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_egzersiz_get]
	@egzersiz_id	INT
AS
	SELECT	* FROM vw_Egzersizler WHERE egzersiz_id = @egzersiz_id
GO
/****** Object:  StoredProcedure [dbo].[sp_egzersiz_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersiz_guncelle]
	@egzersiz_id	INT,
	@egzersiz_ad	NVARCHAR(50),
	@kat_id			INT,
	@aciklama		TEXT,
	@birim_type		INT
AS
	UPDATE tblEgzersizler SET egzersiz_ad = @egzersiz_ad, kat_id = @kat_id, aciklama = @aciklama, birim_type = @birim_type
	WHERE egzersiz_id = @egzersiz_id

GO
/****** Object:  StoredProcedure [dbo].[sp_egzersiz_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_egzersiz_listele]
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
/****** Object:  StoredProcedure [dbo].[sp_egzersiz_listele_kategori]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_egzersiz_listele_kategori]
	@kat_id	int
AS
	SELECT	* FROM vw_Egzersizler WHERE kat_id = @kat_id
GO
/****** Object:  StoredProcedure [dbo].[sp_egzersiz_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersiz_sil]
	@egzersiz_id	INT
AS
	DELETE FROM tblEgzersizler
	WHERE egzersiz_id = @egzersiz_id
GO
/****** Object:  StoredProcedure [dbo].[sp_egzersizKategori_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersizKategori_ekle]
	@kat_ad NVARCHAR(50)
AS
	INSERT INTO tblEgzersizKategorileri VALUES(@kat_ad)
	SELECT @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[sp_egzersizKategori_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersizKategori_get]
	@kat_id	INT
AS
	SELECT * FROM tblEgzersizKategorileri WHERE kat_id = @kat_id

GO
/****** Object:  StoredProcedure [dbo].[sp_egzersizKategori_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersizKategori_guncelle]
	@kat_id	INT,
	@kat_ad NVARCHAR(50)
AS
	UPDATE tblEgzersizKategorileri SET kat_ad = @kat_ad WHERE kat_id = @kat_id
GO
/****** Object:  StoredProcedure [dbo].[sp_egzersizKategori_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Egzersiz Kategorileri
CREATE PROCEDURE [dbo].[sp_egzersizKategori_listele]
AS
	SELECT * FROM tblEgzersizKategorileri

GO
/****** Object:  StoredProcedure [dbo].[sp_egzersizKategori_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_egzersizKategori_sil]
	@kat_id	INT
AS
	DELETE FROM tblEgzersizKategorileri WHERE kat_id = @kat_id

GO
/****** Object:  StoredProcedure [dbo].[sp_kullanici_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_kullanici_ekle]
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
/****** Object:  StoredProcedure [dbo].[sp_kullanici_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_kullanici_get]
	@kullanici_adi NVARCHAR(50)
AS
	SELECT * FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi
	SELECT * FROM tblKullaniciYetkileri WHERE kullanici_adi = @kullanici_adi --Multiple Recorset

GO
/****** Object:  StoredProcedure [dbo].[sp_kullanici_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_kullanici_guncelle]
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
/****** Object:  StoredProcedure [dbo].[sp_kullanici_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_kullanici_listele]
AS
	SELECT * FROM tblKullanicilar

GO
/****** Object:  StoredProcedure [dbo].[sp_kullanici_login]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_kullanici_login]
	@kullanici_adi	NVARCHAR(50),
	@parola			NVARCHAR(16)
AS
	IF (SELECT COUNT(*) FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi AND parola = @parola) > 0
		SELECT 1 --Giriş başarılı
	ELSE
		SELECT 0 --kullanıcı adı ya da parola hatalı

GO
/****** Object:  StoredProcedure [dbo].[sp_kullanici_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_kullanici_sil]
	@kullanici_adi NVARCHAR(50)
AS
	DELETE FROM tblKullanicilar WHERE kullanici_adi = @kullanici_adi

GO
/****** Object:  StoredProcedure [dbo].[sp_kullanici_yetki_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Kullanıcı Yetki İşlemleri

CREATE PROCEDURE [dbo].[sp_kullanici_yetki_get]
	@kullanici_adi	NVARCHAR(50),
	@tablo_type		TINYINT
AS
	SELECT * FROM tblKullaniciYetkileri WHERE kullanici_adi = @kullanici_adi AND tablo_type = @tablo_type

GO
/****** Object:  StoredProcedure [dbo].[sp_kullanici_yetki_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_kullanici_yetki_guncelle]
	@kullanici_adi	NVARCHAR(50),
	@tablo_type		TINYINT,
	@islem_type		TINYINT,
	@yetki_durum	BIT
AS
	UPDATE tblKullaniciYetkileri SET yetki_durum = @yetki_durum 
	WHERE kullanici_adi = @kullanici_adi AND tablo_type = @tablo_type AND islem_type = @islem_type
GO
/****** Object:  StoredProcedure [dbo].[sp_main_view_counts]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_main_view_counts]
AS
	SELECT	(SELECT COUNT(*) FROM tblUyeler) as uye_count,
			(SELECT COUNT(*) FROM tblEgzersizler) as egzersiz_count,
			(SELECT COUNT(*) FROM tblUyeProgramlari WHERE is_aktif = 1) AS aktif_prog_count,
			(SELECT COUNT(*) FROM tblKullanicilar) AS kullanici_count

GO
/****** Object:  StoredProcedure [dbo].[sp_odeme_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_odeme_ekle]
	@tarihsaat		DATETIME,
	@odenen_ay_adet	TINYINT,
	@ucret			SMALLMONEY,
	@uye_id			INT
AS
	INSERT INTO tblOdemeler VALUES(@tarihsaat, @odenen_ay_adet, @ucret, @uye_id)
	SELECT @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[sp_odeme_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_odeme_get]
	@odeme_id	INT

AS
	SELECT  * FROM vw_odemeler WHERE odeme_id = @odeme_id
GO
/****** Object:  StoredProcedure [dbo].[sp_odeme_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_odeme_guncelle]
	@odeme_id		INT,
	@tarihsaat		DATETIME,
	@odenen_ay_adet	TINYINT,
	@ucret			SMALLMONEY,
	@uye_id			INT
AS
	UPDATE tblOdemeler SET tarihsaat = @tarihsaat, odenen_ay_adet = @odenen_ay_adet,
	ucret = @ucret, uye_id = @uye_id WHERE odeme_id = @odeme_id

GO
/****** Object:  StoredProcedure [dbo].[sp_odeme_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_odeme_listele]
	@uye_id INT = NULL, @alt DATETIME = NULL, @ust DATETIME = NULL, 
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
/****** Object:  StoredProcedure [dbo].[sp_odeme_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_odeme_sil]
	@odeme_id		INT
AS
	DELETE FROM tblOdemeler WHERE odeme_id = @odeme_id
GO
/****** Object:  StoredProcedure [dbo].[sp_progEgzersiz_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_progEgzersiz_ekle]
	@gun			INT,
	@prog_id		INT,
	@egzersiz_id	INT,
	@set_adet		INT,
	@tekrar_sayisi	INT
AS
	INSERT INTO tblProgramEgzersizleri VALUES(@gun, @prog_id, @egzersiz_id, @set_adet, @tekrar_sayisi)
	SELECT @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[sp_progEgzersiz_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_progEgzersiz_get]
	@prog_egzersiz_id	INT
AS
	SELECT	* FROM vw_ProgramEgzersizleri
	WHERE prog_egzersiz_id = @prog_egzersiz_id
GO
/****** Object:  StoredProcedure [dbo].[sp_progEgzersiz_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_progEgzersiz_guncelle]
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
/****** Object:  StoredProcedure [dbo].[sp_progEgzersiz_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_progEgzersiz_listele]
	@prog_id	INT
AS
	SELECT	* FROM vw_ProgramEgzersizleri
	WHERE prog_id = @prog_id
GO
/****** Object:  StoredProcedure [dbo].[sp_progEgzersiz_listele_all]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_progEgzersiz_listele_all]
AS
	SELECT	* FROM vw_ProgramEgzersizleri
GO
/****** Object:  StoredProcedure [dbo].[sp_progEgzersiz_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_progEgzersiz_sil]
	@prog_egzersiz_id	INT
AS
	DELETE FROM tblProgramEgzersizleri WHERE prog_egzersiz_id = @prog_egzersiz_id
GO
/****** Object:  StoredProcedure [dbo].[sp_uye_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--***************************************************
--***************************************************
--**************** STORED PROCEDURES ***************
--***************************************************
--***************************************************

-- Üye
CREATE PROCEDURE [dbo].[sp_uye_ekle]
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
/****** Object:  StoredProcedure [dbo].[sp_uye_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uye_get]
	@uye_id	INT
AS
	SELECT * FROM tblUyeler WHERE uye_id = @uye_id

GO
/****** Object:  StoredProcedure [dbo].[sp_uye_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uye_guncelle]
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
/****** Object:  StoredProcedure [dbo].[sp_uye_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_uye_listele] 
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
/****** Object:  StoredProcedure [dbo].[sp_uye_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_uye_sil]
	@uye_id	INT
AS
	DELETE FROM tblUyeler WHERE uye_id = @uye_id

GO
/****** Object:  StoredProcedure [dbo].[sp_uyeolcu_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeolcu_ekle]
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
/****** Object:  StoredProcedure [dbo].[sp_uyeolcu_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeolcu_get]
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
/****** Object:  StoredProcedure [dbo].[sp_uyeolcu_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeolcu_guncelle]
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
/****** Object:  StoredProcedure [dbo].[sp_uyeolcu_list_uye]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Üye Ölçüleri
CREATE PROCEDURE [dbo].[sp_uyeolcu_list_uye]
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
/****** Object:  StoredProcedure [dbo].[sp_uyeolcu_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeolcu_sil]
	@olcu_id	INT
AS
	DELETE FROM tblUyeOlculeri WHERE olcu_id = @olcu_id

GO
/****** Object:  StoredProcedure [dbo].[sp_uyeProg_ekle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeProg_ekle]
	@prog_bas_tarih	DATE,
	@is_aktif		BIT,
	@aciklama		TEXT,
	@bitis_tarih	DATE,
	@uye_id			INT
AS
	INSERT INTO tblUyeProgramlari VALUES(@prog_bas_tarih, @is_aktif, @aciklama, @bitis_tarih, @uye_id)
	SELECT @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[sp_uyeProg_get]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeProg_get]
	@prog_id INT
AS
	SELECT * FROM tblUyeProgramlari WHERE prog_id = @prog_id

GO
/****** Object:  StoredProcedure [dbo].[sp_uyeProg_guncelle]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeProg_guncelle]
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
/****** Object:  StoredProcedure [dbo].[sp_uyeProg_listele]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeProg_listele]
	@uye_id	INT
AS
	SELECT * FROM tblUyeProgramlari WHERE uye_id = @uye_id

GO
/****** Object:  StoredProcedure [dbo].[sp_uyeProg_listele_all]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--UyeProgramlari
CREATE PROCEDURE [dbo].[sp_uyeProg_listele_all]
AS
	SELECT * FROM tblUyeProgramlari

GO
/****** Object:  StoredProcedure [dbo].[sp_uyeProg_sil]    Script Date: 1.01.2021 12:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_uyeProg_sil]
	@prog_id		INT
AS
	DELETE FROM tblUyeProgramlari WHERE prog_id = @prog_id

GO
USE [master]
GO
ALTER DATABASE [SporSalonuDB] SET  READ_WRITE 
GO
