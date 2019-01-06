<%@ Page Title="" Language="C#" MasterPageFile="~/SemMasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="sem._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="KKU" runat="server">
    <!-- *****************************************************************************************************************
	 BLUE WRAP
	 ***************************************************************************************************************** -->
    <div id="blue">

        <div class="container">
            <div class="row">
                <h3>
                    <asp:Label ID="Hosgeldiniz_label" runat="server" Text="Hoşgeldiniz"></asp:Label></h3>
            </div>
            <!-- /row -->
        </div>
        <!-- /container -->
    </div>
    <!-- /blue -->


    <!-- *****************************************************************************************************************
	 AGENCY ABOUT
	 ***************************************************************************************************************** -->
    <div class="container mtb">
        <div class="row">
            <div class="col-lg-6">
                <img class="img-responsive" src="assets/img/surekliegitim.jpg" alt="">
            </div>

            <div class="col-lg-6">
                <h4>Kırıkkale Üniversitesi Sürekli Eğitim Merkezi Kurs Talep ve İzlem Programı</h4>
                <p>
                    Bu progrem Kırıkkale Üniversitesi Sürekli Eğitim Merkezi bünyesinde açılması planlanan eğitimlerin takip edilmesi, eğiticilerin atanması, başvuru işlemlerinin yapılması için tasarlanmıştır.<p>
            </div>
        </div>
        <! --/row -->
    </div>
    <! --/container -->

</asp:Content>
