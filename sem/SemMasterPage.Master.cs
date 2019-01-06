using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sem
{
    public partial class SemMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* oturum kapatma işlemi*/
            if (Request.QueryString["logout"] == "ok")
            {
                Session.Abandon();
                Response.Redirect("default.aspx");
            }

            if (Session["Sem"] != null)
            {
                Menu_Logout.Visible = true;
                Menu_Login.Visible = false;
                islemler_goster.Visible = true;
                islemler_Link.HRef = "semislemler.aspx";
            }

            if (Session["Hoca"] != null)
            {
                Menu_Logout.Visible = true;
                Menu_Login.Visible = false;
                islemler_goster.Visible = true;
                islemler_Link.HRef = "hocaislemler.aspx";
            }

            if (Session["Rektorluk"] != null)
            {
                Menu_Logout.Visible = true;
                Menu_Login.Visible = false;
                islemler_goster.Visible = true;
                islemler_Link.HRef = "rektorlukislemler.aspx";
            }

            /*
            else
            {
                Menu_Login.Visible = true;
            }

            if (Session["BirimId"] != null)
            {
                Menu_Logout.Visible = true;
                Menu_Login.Visible = false;
                Menu_Birim_Hesap.Visible = true;
                islemler_goster.Visible = true;
                islemler_Link.HRef = "birimislemler.aspx";
            }
            if (Session["Strateji"] != null)
            {
                Menu_Logout.Visible = true;
                Menu_Login.Visible = false;
                Menu_Birim_Hesap.Visible = true;
                islemler_goster.Visible = true;
                islemler_Link.HRef = "stratejislemler.aspx";
            }*/
        }
    }
}