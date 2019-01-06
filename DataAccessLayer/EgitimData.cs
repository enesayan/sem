using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class EgitimData : DataAccessBase
    {

        // Yeni Egitim Ekler
        public bool Egitim_Ekle(Egitim E)
        {
            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {
                    sql = "INSERT INTO  Egitimler (EgitimAdi,EgitimGenelTanimi,EgitimBaslamaTarihi,EgitimBitisTarihi,EgiticiSartlar,ToplamDersSaati,HaftalikDersTanimlari,HaftalikDersSaatleri,UcretBilgisi,OlusturulmaTarihi,SonBasvuruTarihi,Durum) OUTPUT INSERTED.Id VALUES(@e_adi,@e_tanim,@e_bas_tar,@e_bit_tar,@e_sartlar,@ders_saati,@h_ders_tanim,@h_ders_saat,@ucret,@olusturma_tar,@son_bas_tar,@durum)";
                    connect.Open();
                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@e_adi", E.EgitimAdi);
                    command.Parameters.AddWithValue("@e_tanim", E.EgitimGenelTanimi);
                    command.Parameters.AddWithValue("@e_bas_tar", E.EgitimBaslamaTarihi);
                    command.Parameters.AddWithValue("@e_bit_tar", E.EgitimBitisTarihi);
                    command.Parameters.AddWithValue("@e_sartlar", E.EgiticiSartlar);
                    command.Parameters.AddWithValue("@ders_saati", E.ToplamDersSaati);
                    command.Parameters.AddWithValue("@h_ders_tanim", E.HaftalikDersTanimlari);
                    command.Parameters.AddWithValue("@h_ders_saat", E.HaftalikDersSaatleri);
                    command.Parameters.AddWithValue("@ucret", E.UcretBilgisi);
                    command.Parameters.AddWithValue("@olusturma_tar", E.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@son_bas_tar", E.SonBasvuruTarihi);
                    command.Parameters.AddWithValue("@durum", E.Durum);
                    id = (int)command.ExecuteScalar();
                    connect.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connect.State == System.Data.ConnectionState.Open)
                        connect.Close();
                }
            }
            return id > 0 ? true : false;
        }

        /* Güncelle */

        public bool Egitim_Guncelle(Egitim ge)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Egitimler SET  EgitimAdi=@e_adi,EgitimGenelTanimi=@e_tanim,EgitimBaslamaTarihi=@e_bas_tar,EgitimBitisTarihi=@e_bit_tar,EgiticiSartlar=@e_sartlar,ToplamDersSaati=@ders_saati,HaftalikDersTanimlari=@h_ders_tanim,HaftalikDersSaatleri=@h_ders_saat,UcretBilgisi=@ucret,SonBasvuruTarihi=@son_bas_tar,Durum=@durum WHERE Id=@e_Id";
                    connect.Open();
                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@e_Id", ge.Id);
                    command.Parameters.AddWithValue("@e_adi", ge.EgitimAdi);
                    command.Parameters.AddWithValue("@e_tanim", ge.EgitimGenelTanimi);
                    command.Parameters.AddWithValue("@e_bas_tar", ge.EgitimBaslamaTarihi);
                    command.Parameters.AddWithValue("@e_bit_tar", ge.EgitimBitisTarihi);
                    command.Parameters.AddWithValue("@e_sartlar", ge.EgiticiSartlar);
                    command.Parameters.AddWithValue("@ders_saati", ge.ToplamDersSaati);
                    command.Parameters.AddWithValue("@h_ders_tanim", ge.HaftalikDersTanimlari);
                    command.Parameters.AddWithValue("@h_ders_saat", ge.HaftalikDersSaatleri);
                    command.Parameters.AddWithValue("@ucret", ge.UcretBilgisi);
                    command.Parameters.AddWithValue("@son_bas_tar", ge.SonBasvuruTarihi);
                    command.Parameters.AddWithValue("@durum", ge.Durum);
                    command.ExecuteNonQuery();
                    connect.Close();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connect.State == System.Data.ConnectionState.Open)
                        connect.Close();
                }
            }
            return result;
        }

        /* Tüm Eğitimleri Getir*/
        public List<Egitim> Tum_Egitimleri_Listele()
        {

            List<Egitim> egitim_list = new List<Egitim>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,EgitimAdi,EgitimGenelTanimi,EgitimBaslamaTarihi,EgitimBitisTarihi,EgiticiSartlar,ToplamDersSaati,HaftalikDersTanimlari,HaftalikDersSaatleri,UcretBilgisi,OlusturulmaTarihi,SonBasvuruTarihi, Durum FROM Egitimler";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Egitim e = new Egitim();
                    e.Id = (int)read["Id"];
                    e.EgitimAdi = (string)read["EgitimAdi"];
                    e.EgitimGenelTanimi = (string)read["EgitimGenelTanimi"];
                    e.EgitimBaslamaTarihi = (DateTime)read["EgitimBaslamaTarihi"];
                    e.EgitimBitisTarihi = (DateTime)read["EgitimBitisTarihi"];
                    e.EgiticiSartlar = (string)read["EgiticiSartlar"];
                    e.ToplamDersSaati = (int)read["ToplamDersSaati"];
                    e.HaftalikDersTanimlari = (string)read["HaftalikDersTanimlari"];
                    e.HaftalikDersSaatleri = (string)read["HaftalikDersSaatleri"];
                    e.UcretBilgisi = (string)read["UcretBilgisi"];
                    e.OlusturmaTarihi = (DateTime)read["OlusturulmaTarihi"];
                    e.SonBasvuruTarihi = (DateTime)read["SonBasvuruTarihi"];
                    e.Durum = (int)read["Durum"];

                    egitim_list.Add(e);
                }
                connect.Close();
            }
            return egitim_list;

        }

        public List<Egitim> Aktif_Egitimleri_Getir()
        {
            List<Egitim> egitim_list = new List<Egitim>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT * FROM Egitimler Where Durum=1";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Egitim e = new Egitim();
                    e.Id = (int)read["Id"];
                    e.EgitimAdi = (string)read["EgitimAdi"];
                    e.EgitimGenelTanimi = (string)read["EgitimGenelTanimi"];
                    e.EgitimBaslamaTarihi = (DateTime)read["EgitimBaslamaTarihi"];
                    e.EgitimBitisTarihi = (DateTime)read["EgitimBitisTarihi"];
                    e.EgiticiSartlar = (string)read["EgiticiSartlar"];
                    e.ToplamDersSaati = (int)read["ToplamDersSaati"];
                    e.HaftalikDersTanimlari = (string)read["HaftalikDersTanimlari"];
                    e.HaftalikDersSaatleri = (string)read["HaftalikDersSaatleri"];
                    e.UcretBilgisi = (string)read["UcretBilgisi"];
                    e.OlusturmaTarihi = (DateTime)read["OlusturulmaTarihi"];
                    e.SonBasvuruTarihi = (DateTime)read["SonBasvuruTarihi"];
                    e.Durum = (int)read["Durum"];

                    egitim_list.Add(e);
                }
                connect.Close();
            }
            return egitim_list;
        }

        /* Silme İşlemleri*/

        public bool Egitim_Sil(int id)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "DELETE Egitimler WHERE Id=@e_id";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@e_id", id);
                    command.ExecuteNonQuery();
                    connect.Close();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connect.State == System.Data.ConnectionState.Open)
                        connect.Close();
                }
            }
            return result;
        }

        /* Id ile Eğitim Getir*/
        public Egitim Id_ile_Egitim_Getir(int id)
        {
            Egitim e = new Egitim();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT * FROM Egitimler WHERE Id=@e_id";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@e_id", id);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    e.Id = (int)read["Id"];
                    e.EgitimAdi = (string)read["EgitimAdi"];
                    e.EgitimGenelTanimi = (string)read["EgitimGenelTanimi"];
                    e.EgitimBaslamaTarihi = (DateTime)read["EgitimBaslamaTarihi"];
                    e.EgitimBitisTarihi = (DateTime)read["EgitimBitisTarihi"];
                    e.EgiticiSartlar = (string)read["EgiticiSartlar"];
                    e.ToplamDersSaati = (int)read["ToplamDersSaati"];
                    e.HaftalikDersTanimlari = (string)read["HaftalikDersTanimlari"];
                    e.HaftalikDersSaatleri = (string)read["HaftalikDersSaatleri"];
                    e.UcretBilgisi = (string)read["UcretBilgisi"];
                    e.OlusturmaTarihi = (DateTime)read["OlusturulmaTarihi"];
                    e.SonBasvuruTarihi = (DateTime)read["SonBasvuruTarihi"];
                    e.Durum = (int)read["Durum"];
                }
                connect.Close();
            }

            return e;
        }
    }
}

