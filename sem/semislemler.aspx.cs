using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Container;


namespace sem
{
    public partial class semislemler : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Sem"] = "ok";
            yonetim_islemleri.Visible = true;
            Hosgeldiniz_label.Text = "Sürekli Eğitim Merkezi Yöneticisi";

            if (Request.QueryString["Egitim"] == "Ekle")
            {
                islemler_list_div.Visible = false;
                yonetim_islemleri.Visible = false;
                EgitimVeriEkleDiv.Visible = true;
                EgitimKaydetButton.Visible = true;
                P_Kaydet.Visible = true;
            }

            else if (Request.QueryString["Egitim"] == "Listele")
            {
                islemler_list_div.Visible = false;
                yonetim_islemleri.Visible = false;
                EgitimListeleDiv.Visible = true;
                DGEgitimListele.DataSource = base.Get_egitim_bl.Tum_Egitimleri_Listele();
                DGEgitimListele.DataBind();
            }

        }

        protected void EgitimKaydetButton_Click(object sender, EventArgs e)
        {
            Egitim yeni = new Egitim();
            yeni.EgitimAdi = TxtEgitimAdi.Value;
            yeni.EgitimGenelTanimi = TxtEgitimTanimi.Value;
            yeni.EgitimBaslamaTarihi = Convert.ToDateTime(Baslama_Tarihi_tb.Text);
            yeni.EgitimBitisTarihi = Convert.ToDateTime(Bitis_Tarihi_tb.Text);
            yeni.EgiticiSartlar = TxtEgiticiSartlari.Value;
            yeni.ToplamDersSaati = int.Parse(TxtToplamDersSaati.Value);
            yeni.HaftalikDersTanimlari = TxtHaftalikDersTanim.Value;
            yeni.HaftalikDersSaatleri = TxtHaftalikDersSaatler.Value;
            yeni.UcretBilgisi = TxtEgitimUcreti.Value;
            yeni.OlusturmaTarihi = DateTime.Now;
            yeni.SonBasvuruTarihi = Convert.ToDateTime(Son_Basvuru_Tarihi_Tb.Text);
            yeni.Durum = 0;

            bool result = base.Get_egitim_bl.Egitim_Ekle(yeni);

            if (result)
            {
                Response.Write("Başarılı");
                EgitimVeriEkleDiv.Visible = false;
                EgitimListeleDiv.Visible = true;
                DGEgitimListele.DataSource = base.Get_egitim_bl.Tum_Egitimleri_Listele();
                DGEgitimListele.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "toastr", "toastr.success('Eğitim Başarıyla Eklendi','Kayıt Mesajı')", true);

            }
            else
            {
                Response.Write("Başarısız");
                ScriptManager.RegisterStartupScript(this, GetType(), "toastr", "toastr.success('Eğitim Başarıyla Eklendi','Kayıt Mesajı')", true);
            }

        }

        protected void DGEgitim_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            // proses silmek için
            if (e.CommandName == "Egitim_Sil")
            {
                string proses_id = ((Label)((DataGridItem)e.Item).FindControl("Label_e_Id")).Text;
                bool result = base.Get_egitim_bl.Egitim_Sil(int.Parse(proses_id));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.success('Eğitim Başarıyla Silindi','Silme Mesajı')", true);
                    DGEgitimListele.DataSource = base.Get_egitim_bl.Tum_Egitimleri_Listele();
                    DGEgitimListele.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), ",toastr", "toastr.error('Poroses Silme Başarısız !!!','Silme Mesajı')", true);
                }
            }

            if (e.CommandName == "Egitim_Duzenle")
            {

                string proses_id = ((Label)((DataGridItem)e.Item).FindControl("Label_e_Id")).Text;
                Label_Egitim_Id.Text = proses_id;
                P_Guncelle.Visible = true;
                P_Kaydet.Visible = false;
                Label_Egitim_Id.Text = proses_id;
                EgitimListeleDiv.Visible = false;
                EgitimVeriEkleDiv.Visible = true;
                EgitimKaydetButton.Visible = false;
                EgitimGucelleButton.Visible = true;
                ChckEgitimDurum.Visible = true;

                Egitim egitim = base.Get_egitim_bl.Id_ile_Egitim_Getir(int.Parse(Label_Egitim_Id.Text));
                TxtEgitimAdi.Value = egitim.EgitimAdi;
                TxtEgitimTanimi.Value = egitim.EgitimGenelTanimi;
                Baslama_Tarihi_tb.Text = egitim.EgitimBaslamaTarihi.ToString("dd.MM.yyyy");
                Bitis_Tarihi_tb.Text = egitim.EgitimBitisTarihi.ToString("dd.MM.yyyy");
                Son_Basvuru_Tarihi_Tb.Text = egitim.SonBasvuruTarihi.ToString("dd.MM.yyyy");

                TxtEgiticiSartlari.Value = egitim.EgiticiSartlar;
                TxtToplamDersSaati.Value = egitim.ToplamDersSaati.ToString();
                TxtHaftalikDersTanim.Value = egitim.HaftalikDersTanimlari;
                TxtHaftalikDersSaatler.Value = egitim.HaftalikDersSaatleri;
                TxtEgitimUcreti.Value = egitim.UcretBilgisi;
                if (egitim.Durum == 1)
                {
                    ChckEgitimDurum.Checked = true;
                }
                else
                {
                    ChckEgitimDurum.Checked = false;
                }

            }
        }

        protected void EgitimGuncelleButton_Click(object sender, EventArgs e)
        {
            Egitim guncel = new Egitim();
            guncel.Id = int.Parse(Label_Egitim_Id.Text);
            guncel.EgitimAdi = TxtEgitimAdi.Value;
            guncel.EgitimGenelTanimi = TxtEgitimTanimi.Value;
            guncel.EgitimBaslamaTarihi = Convert.ToDateTime(Baslama_Tarihi_tb.Text);
            guncel.EgitimBitisTarihi = Convert.ToDateTime(Bitis_Tarihi_tb.Text);
            guncel.EgiticiSartlar = TxtEgiticiSartlari.Value;
            guncel.ToplamDersSaati = int.Parse(TxtToplamDersSaati.Value);
            guncel.HaftalikDersTanimlari = TxtHaftalikDersTanim.Value;
            guncel.HaftalikDersSaatleri = TxtHaftalikDersSaatler.Value;
            guncel.UcretBilgisi = TxtEgitimUcreti.Value;
            guncel.OlusturmaTarihi = DateTime.Now;
            guncel.SonBasvuruTarihi = Convert.ToDateTime(Son_Basvuru_Tarihi_Tb.Text);
            if (ChckEgitimDurum.Checked)
            {
                guncel.Durum = 1;
            }
            else
            {
                guncel.Durum = 0;
            }

            /* Güncelleme Methodu Çağrılacak*/
            bool result = base.Get_egitim_bl.Egitim_Guncelle(guncel);
            if (result)
            {
                DGEgitimListele.DataSource = base.Get_egitim_bl.Tum_Egitimleri_Listele();
                DGEgitimListele.DataBind();
                EgitimVeriEkleDiv.Visible = false;
            }
        }

        protected void CheckAktifEgitimler_Clicked(object sender, EventArgs e)
        {
            if (ChckAktifEgitimler.Checked)
            {
                DGEgitimListele.DataSource = base.Get_egitim_bl.Aktif_Egitimleri_Getir();
                DGEgitimListele.DataBind();
            }
            else
            {
                DGEgitimListele.DataSource = base.Get_egitim_bl.Tum_Egitimleri_Listele();
                DGEgitimListele.DataBind();
            }
        }

        public void mailGonder(List<string> mail_list, string konu, string icerik)
        {
            /*try
            {
                MailMessage mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("sem@kku.edu.tr");

                foreach (var m in mail_list)
                {
                    mail.To.Add(m);

                    mail.Subject = konu;

                    mail.Body = icerik;

                    SmtpServer.Port = 587;

                    SmtpServer.Credentials = new System.Net.NetworkCredential("sem@kku.edu.tr", "!asd123+");

                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }*/

        }
    }
}