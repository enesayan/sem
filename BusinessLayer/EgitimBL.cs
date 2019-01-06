using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;

namespace BusinessLayer
{
    public class EgitimBL : BusinessBase
    {
        public bool Egitim_Ekle(Egitim E)
        {
            return base.EgitimIslemleri.Egitim_Ekle(E);
        }
        public List<Egitim> Tum_Egitimleri_Listele()
        {
            return base.EgitimIslemleri.Tum_Egitimleri_Listele();
        }

        public bool Egitim_Sil(int id)
        {
            return base.EgitimIslemleri.Egitim_Sil(id);
        }

        public Egitim Id_ile_Egitim_Getir(int id)
        {
            return base.EgitimIslemleri.Id_ile_Egitim_Getir(id);
        }

        public List<Egitim> Aktif_Egitimleri_Getir()
        {
            return base.EgitimIslemleri.Aktif_Egitimleri_Getir();
        }

        public bool Egitim_Guncelle(Egitim ge)
        {
            return base.EgitimIslemleri.Egitim_Guncelle(ge);
        }
    }
}
