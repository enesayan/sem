using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{

    public class Egitim : ContainerBase
    {
        public int Id { get; set; }
        public string EgitimAdi { get; set; }
        public string EgitimGenelTanimi { get; set; }
        public DateTime EgitimBaslamaTarihi { get; set; }
        public DateTime EgitimBitisTarihi { get; set; }
        public string EgiticiSartlar { get; set; }
        public int ToplamDersSaati { get; set; }
        public string HaftalikDersTanimlari { get; set; }
        public string HaftalikDersSaatleri { get; set; }
        public string UcretBilgisi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime SonBasvuruTarihi { get; set; }
        public int Durum { get; set; }
    }

}