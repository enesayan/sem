<%@ Page Title="" Language="C#" MasterPageFile="~/SemMasterPage.Master" AutoEventWireup="true" CodeBehind="semislemler.aspx.cs" Inherits="sem.semislemler" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="KKU" runat="server">

    <!-- *****************************************************************************************************************
	 BLUE WRAP
	 ***************************************************************************************************************** -->
    <div id="blue">
        <div class="container">
            <div class="row">
                <h3>
                    <asp:Label ID="Hosgeldiniz_label" runat="server" Text="Sürekli Eğitim Merkezi İşlemler"></asp:Label></h3>
            </div>
            <!-- /row -->
        </div>
        <!-- /container -->
    </div>
    <!-- /blue -->
    <!-- *****************************************************************************************************************
	 İşlemler 
	 ***************************************************************************************************************** -->

    <form id="form1" runat="server">
        <div class="container mtb" id="islemler_list_div" runat="server">
            <div class="row centered">

                <div id="yonetim_islemleri" runat="server" visible="true">

                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <div class="he-wrap tpl6">
                            <img src="assets/img/process_img/fakulte_ekle.jpg" alt="">
                            <div class="he-view">
                                <div class="bg a0" data-animate="fadeIn">
                                    <h3 class="a1" data-animate="fadeInDown">Eğitim Ekle</h3>
                                    <a href="?Egitim=Ekle" class="dmbutton a2" data-animate="fadeInUp"><i class="fa fa-external-link-square fa-2x"></i></a>
                                </div>
                                <!-- he bg -->
                            </div>
                            <!-- he view -->
                        </div>
                        <!-- he wrap -->
                        <h5 class="ctitle"><a href="?Egitim=Listele">Egitimleri Listele</a></h5>
                        <p><a href="?Egitim=Ekle">Eğitim Ekle</a></p>
                        <div class="hline"></div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <div class="he-wrap tpl6">
                            <img src="assets/img/process_img/bolum_ekle.jpg" alt="">
                            <div class="he-view">
                                <div class="bg a0" data-animate="fadeIn">
                                    <h3 class="a1" data-animate="fadeInDown">Atanmış Eğiticiler</h3>
                                    <a href="?Egitim=Ekle" class="dmbutton a2" data-animate="fadeInUp"><i class="fa fa-external-link-square fa-2x"></i></a>
                                </div>
                                <!-- he bg -->
                            </div>
                            <!-- he view -->
                        </div>
                        <!-- he wrap -->
                        <h5 class="ctitle"><a href="?Egitici=BasvuruListele">Başvuruları Listele</a></h5>
                        <p><a href="?Egitici=Ata">Atanmış Eğiticiler</a></p>
                        <div class="hline"></div>
                    </div>

                </div>

            </div>
            <! --/row -->
        </div>
        <! --/container -->

	 <div class="container" id="islemler_div" runat="server">
         <div class="row">

             <!-- Eğitim Veri Ekleme Bölümü -->

             <div id="EgitimVeriEkleDiv" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Eğitim Ekleme - <a href="?Egitim=Listele" runat="server" id="A1">Eğitim Listele</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>
                     <p id="P_Kaydet" runat="server" visible="false">Açılması Planlanan Eğitim ile İlgili Bilgileri Bu Bölümden Ekleyebilirsiniz</p>
                     <p id="P_Guncelle" runat="server" visible="false">Eğitimler ile İlgili Bilgileri Bu Bölümden Güncelleyebilirsiniz</p>
                     <div class="hline"></div>
                     <asp:Label ID="Label_Egitim_Id" runat="server" Visible="false"></asp:Label>
                     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
                     <form role="form">
                         <asp:Label ID="EgitimId" runat="server" Visible="false"></asp:Label>
                         <div class="form-group">
                             <label for="EgitimAdi">Eğitim Adı</label>
                             <input type="text" class="form-control" id="TxtEgitimAdi" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="EgitimTanimi">Eğitimin Genel Tanımı</label>
                             <textarea class="form-control" rows="5" id="TxtEgitimTanimi" runat="server"></textarea>
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Eğitim Başlama Tarihi</label>
                             <asp:TextBox ID="Baslama_Tarihi_tb" class="form-control" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtenderEgitimBaslangic" runat="server" TargetControlID="Baslama_Tarihi_tb" PopupButtonID="Baslama_Tarihi_tb"></asp:CalendarExtender>

                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Eğitim Bitiş Tarihi</label>

                             <asp:TextBox ID="Bitis_Tarihi_tb" class="form-control" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtenderEğitimBitis" runat="server" TargetControlID="Bitis_Tarihi_tb" PopupButtonID="Bitis_Tarihi_tb"></asp:CalendarExtender>
                         </div>

                         <div class="form-group">
                             <label for="InputAdi">Eğitici Olmak için Son Başvuru Tarihi</label>

                             <asp:TextBox ID="Son_Basvuru_Tarihi_Tb" class="form-control" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalenderSonBasvuruTarihi" runat="server" TargetControlID="Son_Basvuru_Tarihi_tb" PopupButtonID="Son_Basvuru_Tarihi_tb"></asp:CalendarExtender>
                         </div>

                         <div class="form-group">
                             <label for="EgiticiSartlar">Eğitici Olmak için Gerekli Şartlar</label>
                             <textarea class="form-control" rows="5" id="TxtEgiticiSartlari" runat="server"></textarea>
                         </div>


                         <div class="form-group">
                             <label for="DersSaati">Toplam Ders Saati</label>
                             <input type="text" class="form-control" id="TxtToplamDersSaati" runat="server">
                         </div>

                         <div class="form-group">
                             <label for="DersTanimlar">Haftalık Ders Tanımları</label>
                             <textarea class="form-control" rows="10" id="TxtHaftalikDersTanim" runat="server"></textarea>
                         </div>

                         <div class="form-group">
                             <label for="DersSaatler">Haftalık Ders Saatleri</label>
                             <textarea class="form-control" rows="10" id="TxtHaftalikDersSaatler" runat="server"></textarea>
                         </div>

                         <div class="form-group">
                             <label for="InputAdi">Eğitim Ücreti</label>
                             <input type="text" class="form-control" id="TxtEgitimUcreti" runat="server">
                         </div>
                         <asp:CheckBox ID="ChckEgitimDurum" class="form-check-input" runat="server" AutoPostBack="False" TextAlign="Right" Visible="false" Checked="false" Text=" Eğitim Durumu Aktif (Seçili Evet)" />
                         <br />
                         <asp:Button ID="EgitimKaydetButton" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClick="EgitimKaydetButton_Click" />
                         <asp:Button ID="EgitimGucelleButton" class="btn btn-theme" Visible="false" runat="server" Text="Güncelle" OnClick="EgitimGuncelleButton_Click" />
                     </form>
                 </div>
                 <! --/col-lg-8 -->
             </div>

             <!-- /Eğitim Listeleme Bölümü -->
             <div id="EgitimListeleDiv" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Eğitim Listeleme - <a href="?Egitim=Ekle" runat="server" id="Deger_link">Eğitim Ekle</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>
                     <br />
                     <asp:CheckBox ID="ChckAktifEgitimler" class="form-check-input" runat="server" AutoPostBack="True" TextAlign="Right" Visible="true" Checked="false" Text=" Aktif Eğitimleri Getir" OnCheckedChanged="CheckAktifEgitimler_Clicked" />
                     <br />
                     <div class="hline"></div>

                     <asp:DataGrid ID="DGEgitimListele" AutoGenerateColumns="false" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderWidth="0px" BorderColor="white" OnItemCommand="DGEgitim_ItemCommand">
                         <Columns>
                             <asp:TemplateColumn ItemStyle-CssClass="col-lg-12">
                                 <ItemTemplate>
                                     <asp:Label ID="My_Content" runat="server">
                                         <p>
                                             <asp:Label ID="Label_e_Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                             <asp:LinkButton ID="Link_pd_bak" runat="server" CommandName="Egitim_bak" Width="40%">
                                                 <i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label_f_adi"><%# Eval("EgitimAdi") %></asp:Label>
                                             </asp:LinkButton>
                                             <asp:LinkButton ID="Link_e_sil" runat="server" CommandName="Egitim_Sil" OnClientClick="return confirm('Silmek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-remove-circle"> </i>  Sil </asp:LinkButton>
                                             <asp:LinkButton ID="Link_e_duzenle" runat="server" CommandName="Egitim_Duzenle" OnClientClick="return confirm('Düzenlemek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-pencil"> </i>  Düzenle  </asp:LinkButton>
                                             <span class="badge badge-theme pull-right"><%# Eval("Durum") %></span>
                                         </p>
                                     </asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateColumn>
                         </Columns>

                     </asp:DataGrid>
                     <div class="spacing"></div>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Eğitim Listeleme Bölümü -->


         </div>
         <%--<row div>--%>
     </div>
        <%--<asp:TabContainer div>--%>
    </form>


</asp:Content>
