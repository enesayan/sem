using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using Container;

namespace sem
{
    public abstract class PageBase : System.Web.UI.Page
    {

        /* Egitim isleri*/
        EgitimBL egitim_islemler_bl = null;
        public EgitimBL Get_egitim_bl
        {
            get
            {
                if (egitim_islemler_bl == null)
                    egitim_islemler_bl = new EgitimBL();
                return egitim_islemler_bl;
            }
        }


    }
}
