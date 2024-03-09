<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Dettagli.aspx.cs"
Inherits="eCommerce_BuildWeek.Dettagli" EnableEventValidation="false" %>

<asp:Content ID="BodyContent1" ContentPlaceHolderID="MainContent" runat="server">
  <!DOCTYPE html>

  <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title></title>
      <link href="./Content/style.css" rel="stylesheet" />
    </head>
    <body>
      <div class="container mt-5 text-white">
        <p class="alert alert-danger" runat="server" id="alert"></p>

        <div class="row">
          <div class="col-md-7">
            <img id="Immagine" runat="server" src="" alt="" class="img-thumbnail border-0 bg-transparent" />
          </div>
          <div class="col-md-5">
            <p id="Categoria" class="title-up fs-5" runat="server"></p>

            <div class="d-flex">
              <h2 id="Nome" class="fs-1" runat="server"></h2>
              <span class="badge mt-2 ms-3" id="Disponibilita" runat="server"></span>
            </div>

            <h4 id="Prezzo" runat="server"></h4>
            <h4 class="my-4 fw-bold fs-5 orange">Descrizione</h4>
            <p id="Descrizione" runat="server"></p>

            <h4 class="my-4 fw-bold fs-5">Scegli una <span class="orange">mimetica</span></h4>

             <div class="mb-3">
<img class="material rounded-1 selezione-colore <%= Mimetica.SelectedValue == "Default" ? "bordo-selezionato" : "" %>" src="./Content/assets/default.jpg" alt="Default" data-value="Default">
<img class="material rounded-1 selezione-colore <%= Mimetica.SelectedValue == "Silver" ? "bordo-selezionato" : "" %>" src="./Content/assets/silver.jpg" alt="Silver" data-value="Silver">
<img class="material rounded-1 selezione-colore <%= Mimetica.SelectedValue == "Gold" ? "bordo-selezionato" : "" %>" src="./Content/assets/gold.jpg" alt="Gold" data-value="Gold">
<img class="material rounded-1 selezione-colore <%= Mimetica.SelectedValue == "Copper" ? "bordo-selezionato" : "" %>" src="./Content/assets/copper.jpg" alt="Copper" data-value="Copper">

 
            <asp:RadioButtonList runat="server" ID="Mimetica" AutoPostBack="true"
                OnSelectedIndexChanged="Mimetica_SelectedIndexChanged" CssClass="d-flex d-none" >
                <asp:ListItem Value="Default" Text="Default" />
                <asp:ListItem Value="Silver" Text="Silver" />
                <asp:ListItem Value="Gold" Text="Gold" />
                <asp:ListItem Value="Copper" Text="Copper" />
            </asp:RadioButtonList>



            </div>


            <br />

            <div class="d-flex mb-5">
            <asp:Button
              runat="server"
              id="aggiungiCarrello"
              OnClick="aggiungiCarrello_Click"
              cssClass="py-3 px-4 btn btn2o fw-bolder"
              Text="Aggiungi al carrello"
            />

            <asp:TextBox runat="server" ID="Quantità" CssClass="textBox ms-3 fw-bold" TextMode="Number" Text="1" min="1" step="1" />

            </div>


          </div>
        </div>

          <h2 class="h4 mt-5 ms-3">Articoli correlati</h2>

          <div class="row">
              <asp:Repeater runat="server" ID="Repeater10">
               <ItemTemplate>
                   <div class="col-4">

                       <div class="card mx-2 my-2 bg-transparent border-0 text-white overflow-hidden shadow">

                           <div class="d-flex  align-items-center mx-auto">
                               <h5 class="title-up card-title m-0 fs-2 fw-bold mt-3"><%# Eval("Nome") %></h5>
                           </div>

                           <div class="position-relative">
                               <img src='<%# Eval("Immagine") %>' class="px-3 card-img-top img-fluid" style="max-height: 250px; object-fit: contain" alt='<%# Eval("Nome") %>'>
                               <span class="custom-span fs-5 bg-opacity-75 shadow rounded-0 badge w-100  bg-opacity-75"><%# Eval("Prezzo", "{0:c2}") %></span>
                           </div>

                           <a href="<%# "Dettagli.aspx?IdProdotto=" + Eval("idProdotto") %>" class="text-decoration-none rounded-0 w-100 text-white btn btn2i fw-bolder text-white">Dettagli
                           </a>

                       </div>
                    </div>
                  </ItemTemplate>
                </asp:Repeater>
          </div>


      </div>
    </body>

      <script>

          //scriptino per far prendere alle img i valori del radio button

          document.addEventListener('DOMContentLoaded', function () {


              document.querySelectorAll('.selezione-colore').forEach(function (img) {
                  img.addEventListener('click', function () {
                      var value = this.getAttribute('data-value');
                      document.querySelectorAll('#<%= Mimetica.ClientID %> input').forEach(function(radio) {
                if (radio.value === value) {
                    radio.checked = true;
                    __doPostBack('<%= Mimetica.UniqueID %>', '');
                }
            });
        });
    });
});
      </script>
  </html>
</asp:Content>
