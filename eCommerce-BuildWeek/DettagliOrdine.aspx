<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
CodeBehind="DettagliOrdine.aspx.cs" Inherits="eCommerce_BuildWeek.DettagliOrdine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <h2 class="text-center mb-4">Dettaglio ordine</h2>

    <asp:Label Text='<%# "Dettagli ordine #" + Eval("Fk_IdOrdine") %>' runat="server"></asp:Label>
    <asp:Repeater ID="DettagliOrdiniRep" runat="server">
      <ItemTemplate>
        <div class="row border-bottom py-3 mb-3">
          <div class="col-6">
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PercorsoImmagine") %>' CssClass="img-fluid" />
          </div>
          <div class="col-6 text-center">
            <h2 class="fs-4 mt-4">
              Prodotto:&nbsp;
              <a
                href='<%# "/Dettagli.aspx?IdProdotto=" + Eval("FK_IdProdotto") %>'
                class="text-decoration-none text-warning"
              >
                <asp:Label runat="server" class="h5" Text='<%# Eval("Nome") %>'></asp:Label>
              </a>
            </h2>

            <h2 class="fs-4 mt-4">
              Quantità:&nbsp;
              <asp:Label runat="server" class="h5" Text='<%#Eval("quantita") %>'></asp:Label>
            </h2>

            <h2 class="fs-4 mt-4">
              Prezzo:&nbsp;
              <asp:Label runat="server" class="h5" Text='<%#Eval("TOTALE") + "€" %>'></asp:Label>
            </h2>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</asp:Content>
