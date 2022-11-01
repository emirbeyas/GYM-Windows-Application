
GO
USE SporSalonuDB
GO

--***********************************************************
--Egzersiz Kategoriler Ekle
--***********************************************************
INSERT INTO tblEgzersizKategorileri VALUES('Ön Kol (Biceps)') --id = 1
INSERT INTO tblEgzersizKategorileri VALUES('Arka Kol (Triceps)') --id=2
INSERT INTO tblEgzersizKategorileri VALUES('Omuz')--id=3
INSERT INTO tblEgzersizKategorileri VALUES('Göğüs')--id=4
INSERT INTO tblEgzersizKategorileri VALUES('Sırt')--id=5
INSERT INTO tblEgzersizKategorileri VALUES('Karın')--id=6
INSERT INTO tblEgzersizKategorileri VALUES('Bacak')--id=7

--***********************************************************
--Egzersizleri Ekle
--***********************************************************
--ÖnKol Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Barbel Curl', 1,
'Hareketi ayakta yapın. Sırtınız dik olsun.
Barı omuz genişliğinden biraz fazla olacak şekilde tutun.
Nefes alın ve barı omuz hizanıza kadar kaldırın.
Kalçanızın, karnınızın ve bel kaslarınızın salınmamasını sağlayın', 0)

INSERT INTO tblEgzersizler VALUES('Concentration Curl', 1,
'Biceps hareketleri içerisinde etkili biceps büyütme hareketidir.
Bir dambıl alarak sehpaya oturun.
Dambılı baldırınızın iç kısmında kolunuz gergin olacak şekilde tutun.
Nefes alın ve dambılı kendinize doğru çekin.
Yukarı kaldırırken nefes verin.
Kolun tam olarak açılmasına dikkat edin.', 0)

INSERT INTO tblEgzersizler VALUES('Dumbell Curl', 1,
'Bu hareket biceps geliştirme için en iyi hareketlerden birisidir.
Her bir elinize birer dambıl alın ve dambıllar yanda olacak şekilde sehpaya oturun.
Nefes alın ve bir kolunuzu avuç içiniz yukarıyı gösterecek şekilde baş hizasına kadar kaldırın.
Kaldırırken nefesinizi verin. Sonra indirin ve diğerini aynı şekilde kaldırın.
Not: Her iki kolun hareketinin tamamlanması 1 tekrar sayılır', 0)


--Arka Kol Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Dumbbell Triceps Extension', 2,
'Bu hareketle triceps kasınızın tüm bölümlerini eşit oranda çalıştırırsınız.
İki dambıl alın ve sehpa üzerine sırt üstü uzanın.
Hareketin başlangıcında dambıllar yukarıda olsun.
Nefes alın ve yavaşça kollarınızı bükün.
Başlangıç pozisyonuna dönün ve nefesinizi verin.', 0)

INSERT INTO tblEgzersizler VALUES('One Arm Triceps Extension', 2,
'Kolunuz yukarıda gergin olacak şekilde bir elinizde dambıl ile birlikte ayakta durun ya da oturun.
Nefes alın ve kolunuzu dambıl ile birlikte ensenize doğru indirin.
Hareketi tamamlarken nefes verin ve başlangıç pozisyonuna dönün',0)

INSERT INTO tblEgzersizler VALUES('Triceps Dips', 2,
'Ellerinizi düz bir sehpanın kenarına yerleştirin.
Ayaklarınızı da hemen karşınızdaki diğer sehpaya uzatın.
Gövde ile bacaklarınız arasındaki açı 90 derece olsun.
Nefes alın ve kollarınızı bükün.
Kollarınızı gerginleştirerek başlangıç noktasına dönün. Nefesinizi verin.
NOT: Baldırlarınıza ağırlık koyarsanız hareketin zorluk derecesi artar', 0)




--Omuz Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Front Press', 3,
'Sırtınız dik olacak şekilde sehpaya oturun.
Barı göğsünüzde olacak şekilde tutun.
Nefes alın ve barı dik olarak, belinizi bükmeden başınızın üstüne doğru itin.
Barı kaldırdığınızda nefes verin.
NOT: Bu hareketi ayakta da yapabilirsiniz.', 0)

INSERT INTO tblEgzersizler VALUES('Back Press', 3,
'Sırtınız dik olacak şekilde sehpaya oturun.
Barı ensenizde olacak şekilde tutun.
Nefes alın ve barı dik olarak, belinizi bükmeden başınızın üstüne doğru itin.
Başlangıç pozisyonuna geri dönün ve hareketi bitirdiğinizde nefes verin', 0)

INSERT INTO tblEgzersizler VALUES('Lateral Raises', 3,
'Her iki elinize birer dambıl alın ve ayaklarınız omuz genişliğinde açık olacak şekilde ayakta durun.
Kollarınızı yanlara doğru omuz hizasına kadar kaldırın.
Dambılları kaldırırken nefes verin.
NOT: Başlangıç pozisyonu olarak dambılları önde, arkada ve yanda tutabilirsiniz', 0)

INSERT INTO tblEgzersizler VALUES('Bent Over Lateral Raises', 3,
'Dizleriniz hafif bükülü ve ayaklar açık olarak durun.
Öne doğru belinizi bükün, sırtınız düz olsun.
Dambılları dirsekleriniz hafif bükülü olarak tutun.
Nefes alın ve dambılları yana doğru kaldırın.
Hareket bittiğinde nefesinizi verin', 0)



--Göğüs Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Bench Press', 4,
'Bench sehpasına uzanın.
Ayaklarınız yerde, kalçanız sehpada temas halinde olsun.
Kollarınız omuz genişliğinden bira fazla açık barı kavrayın.
Nefes alın ve barı yavaş bir şekilde göğsünüze kadar indirin.
Tekrar kaldırın. Nefes verin', 0)


INSERT INTO tblEgzersizler VALUES('Medium Grip Bench Press', 4,
'Bench sehpasına uzanın.
Ayaklarınız yerde, kalçanız sehpada temas halinde olsun.
Omuz genişliğinden biraz dar bir şekilde barı kavrayın.
Nefes alın ve barı yavaş bir şekilde göğsünüze kadar indirin.
Dirseklerinizin gövdenizden yanlara doğru iyice açılmasına dikkat edin.
Barı tekrar kaldırın ve nefes verin', 0)


INSERT INTO tblEgzersizler VALUES('Decline Press', 4,
'Aşağı 20-40 derece eğimli sehpaya uzanın.
Ayaklarınızı destekleyici aparatlara takın.
Barı omuz genişliğinden biraz fazla olacak şekilde kavrayın.
Nefes alın ve barı yavaş bir şekilde göğsün alt hizasına kadar indirin.
Barı tekrar kaldırın ve nefes verin', 0)


INSERT INTO tblEgzersizler VALUES('Incline Press', 4,
'Yukarı doğru 45-60 derece ayarlı sehpaya uzanın.
Barı omuz genişliğinden biraz fazla olacak şekilde kavrayın.
Nefes alın.
Barı kürek kemiklerinin birleşme yerine kadar indirin.
Barı tekrar kaldırın ve nefes verin.', 0)





--Sırt Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Back Extension', 5,
'Sehpaya yüzüstü uzanın.
Ayak bileklerinizi destekleyicilere yerleştirin.
Üst baldırınız minder üzerinde olsun.
Baldırınızı kasın ve üst vücudunuzu yere paralel oluncaya kadar yukarı kaldırın.
Sakatlanmamak için hareketi dikkatli ve yavaş yapın. Kalkma açısına dikkat edin', 0)

INSERT INTO tblEgzersizler VALUES('Back Lat Pulldown', 5,
'Yüzünüz makineye dönük dizleriniz minderin altında olacak şekilde oturun.
Barı geniş tutuşta kavrayın.
Nefes alın ve barı ensenizin gerisine çekin.
Dirseklerinizi de aynı anda geriye alın.
Hareket bittiğinde nefes verin', 0)

INSERT INTO tblEgzersizler VALUES('Barbell Shrugs', 5,
'Ayaklarınız omuz genişliğinden biraz açık olarak barı üstten kavrama ile tutun.
Nefes alın ve barı sırtınız gergin olarak yukarı olabildiğice yükseltin, karın kasınızı kasın.
Başlangıç pozisyonuna dönerken nefes verin', 0)

INSERT INTO tblEgzersizler VALUES('Bent Rows', 5,
'Gövdeniz 45 derece, sırtınız düz, dizleriniz hafif bükülü olarak ayakta barı kavrayın.
Kollarınızı aşağı doğru bırakın.
Nefes alın ve karın kaslarınızı kasarak bar göğsünüze hafif temas edecek şekilde kaldırın.
Nefes vererek başlangıç durumuna dönün', 0)



--Karın Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Bench Sit Ups', 6,
'Ayaklarınızı destek bölümüne yerleştirin.
Ellerinizi ensenizde tutun.
Nefes alın ve boynunuza yüklenmeyecek şekilde dizlerinize doğru kapanın.
Başlangıç pozisyonunuza yavaşça geri dönün ve nefes verin.',0)

INSERT INTO tblEgzersizler VALUES('Crunches ', 6,
'Sırt üstü uzanın.
Ellerinizi başınızın üzerine koyarak kalçanızı ve dizlerinizi 90 drece bükün
Nefes alın ve omuzlarınızı yukarı doğru kaldırırken dizlerinizi de başınıza doğru çekin.
Başlangıç pozisyonunuza dönün ve nefes verin', 0)

INSERT INTO tblEgzersizler VALUES('Incline Bench Sit Ups ', 6,
'Sehpaya ayaklarınız minderli kısımlara gelecek şekilde oturun.
Elleriniz başınızın gerisinde olsun.
Nefes alın ve geriye doğru yatın.
Tam olarak sehpaya uzanmadan tekrar kalkın.
Hareketi tamamladığınızda nefes verin', 0)

INSERT INTO tblEgzersizler VALUES('Incline Leg Raises ', 6,
'Açılı sehpaya sırt üstü uzanın ve borudan tutun.
Ayaklarınızı kalça seviyesinin üzerine kadar kaldırın.
Kalçanızı kaldırın ve dizlerinizi başınıza doğru değdirin', 0)

--Bacak Haraketleri Ekle
INSERT INTO tblEgzersizler VALUES('Squat ', 7,
'Barı omuzlarınızın üzerine alın ve kavrayın.
Kalçanızı hafif dışarıda tutun, nefes alın.
Karşıya doğru bakın ve sırtınız gergin, omuzlarınız dik olarak çömelin.
Nefes verirken kalkın.', 0)

INSERT INTO tblEgzersizler VALUES('Front Squat ', 7,
'Üst kollarınız yere paralel olacak şekilde dirseklerinizi bükülü barı kavrayın.
Nefes alın ve çömelin.
Tekrar kalkın ve nefes verin.', 0)

INSERT INTO tblEgzersizler VALUES('Hack Squat ', 7,
'Dizleriniz gerin, sırtınızı ve omuzlarınızı mindere yaslayın, ayaklarınızı eşit ölçüde açın.
Nefes alın ve dizlerinizi kontrollü biçimde bükün.
Başlangıç pozisyonuna dönün. Nefes verin', 0)

INSERT INTO tblEgzersizler VALUES('Leg Extensio ', 7,
'Makineye oturun.
Dizlerinizi bükün ve ayak bileklerinizi minderin altına yerleştirin.
Nefes alın, bacaklarınızı yere paralel olana dek kaldırın.
Hareket bittiğinde nefes verin', 0)



--***********************************************************
-- Üye Ekle
--***********************************************************
INSERT INTO tblUyeler VALUES('Kemalettin', 'Kamiloğlu', '1.1.2000', '1.12.2020', '1.1.2021', '03802232323') --id = 1
INSERT INTO tblUyeler VALUES('Muhittin', 'Sarı', '10.10.1998', '1.4.2020', '10.8.2020', '03802252525')      --id = 2
INSERT INTO tblUyeler VALUES('Hayrettin', 'Lacivert', '9.7.1998', '4.3.2020', '8.3.2020', '03802262626')   --id = 3

--***********************************************************
-- Üye Program Ekle
--***********************************************************
INSERT INTO tblUyeProgramlari VALUES('1.12.2020', 1, 'Üye Demo Programı',NULL, 1) --id = 1
INSERT INTO tblUyeProgramlari VALUES('1.4.2020', 0, 'Üye Demo Programı','4.5.2020', 2) --id = 2
INSERT INTO tblUyeProgramlari VALUES('4.5.2020', 0, 'Üye Demo Programı','8.10.2020', 2) --id = 3
INSERT INTO tblUyeProgramlari VALUES('8.10.2020', 1, 'Üye Demo Programı',NULL, 2) --id = 4
INSERT INTO tblUyeProgramlari VALUES('4.3.2020', 1, 'Üye Demo Programı',NULL, 3) --id = 5

--***********************************************************
-- Program Detayları Ekle
--***********************************************************
INSERT INTO tblProgramEgzersizleri VALUES(1, 1,1, 4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(3, 1,3,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(5, 1,5,4, 12)

INSERT INTO tblProgramEgzersizleri VALUES(2, 2,7,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(4, 2,4,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(6, 2,10,4, 12)

INSERT INTO tblProgramEgzersizleri VALUES(2, 3,9,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(4, 3,7,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(5, 3,3,4, 12)

INSERT INTO tblProgramEgzersizleri VALUES(2, 4,5,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(4, 4,8,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(6, 4,10,4,12)

INSERT INTO tblProgramEgzersizleri VALUES(1, 5, 1,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(3, 5,3,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(3, 5,2,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(5, 5,5,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(5, 5,2,4, 12)
INSERT INTO tblProgramEgzersizleri VALUES(6, 5,10,4, 12)

--***********************************************************
-- Uye Olcu Ekle
--***********************************************************
INSERT INTO tblUyeOlculeri VALUES(38, 94, 105, 68, 180, 84, '1.15.2020', 1)
INSERT INTO tblUyeOlculeri VALUES(39, 92, 100, 62, 180, 78, '2.13.2020', 1)


--*******************************************************
--Kullanıcı Ekleme
--*******************************************************
-- kullanıcı tipleri 1-DefaultAdmin, 2-Admin, 3-User

INSERT INTO tblKullanicilar VALUES('Admin', '1234', 1, 'Admin', 'Adminoğlu')
INSERT INTO tblKullanicilar VALUES('user1', '1234', 2, 'User1', 'Admin')
INSERT INTO tblKullanicilar VALUES('user2', '1234', 3, 'User2', 'User')