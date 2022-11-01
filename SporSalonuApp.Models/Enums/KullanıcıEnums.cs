namespace SporSalonuApp.Models.Enums
{
    public enum KullanıcıType
    {
        DefaultAdmin    = 1,
        Admin           = 2,
        User            = 3
    }

    public enum DbTablo
    {
        Uyeler              = 1,
        UyeOlculeri         = 2,
        UyeProgramları      = 3,
        ProgramEgzersizleri = 4,
        Odemeler            = 5,
        Kullanıcılar        = 6,
        KullanıcıYetkileri  = 7,
        Egzersizler         = 8,
        EgzersizKategorileri= 9
    }

    public enum YetkiIslem
    {
        Listeleme   = 1,
        Ekleme      = 2,
        Silme       = 3,
        Güncelleme  = 4
    }
}
