using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
    public abstract class BusinessBase
    {
        /* Egitim veri tabani islemleri icin*/

        EgitimData egitimdata = null;
        protected EgitimData EgitimIslemleri
        {
            get
            {
                if(egitimdata==null)
                {
                    egitimdata = new EgitimData();
                }
                return egitimdata;
            }
        }

    }
}
