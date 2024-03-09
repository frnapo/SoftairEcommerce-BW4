<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modifica.aspx.cs" Inherits="eCommerce_BuildWeek.Modifica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modifica</h2>


    <div class="d-flex justify-content-center">
        <div class="text-end">

            

            <div class="d-flex justify-content-end mb-2">
    <asp:Image ID="img" ImageUrl="imageurl" runat="server" CssClass="" Width="100" />
</div>

            <p runat="server" class="text-warning small">id: <span id="codiceProdotto" runat="server" class="text-secondary"> </span></p>

            <div class="d-flex justify-content-end mb-2">
                <p class="text-warning small me-4 mb-0">Nome</p>
                <asp:TextBox runat="server" ID="Nome" Text="" CssClass="form-control w-75" />
            </div>

            <div class="d-flex justify-content-end mb-2">
                <p class="text-warning small me-3 mb-0">Descrizione</p>
                <asp:TextBox runat="server" ID="Descrizione" TextMode="MultiLine" Rows="5" Text="" CssClass="form-control" />
            </div>

            <div class="d-flex justify-content-end mb-2">
                <p class="text-warning small me-4 mb-0">Prezzo</p>
                <asp:TextBox runat="server" ID="Prezzo" Text="" CssClass="form-control w-75" />
            </div>

            <div class="d-flex justify-content-end mb-2">
                <p class="text-warning small me-4 mb-0">Unità</p>
                <asp:TextBox runat="server" ID="Unita" Text="" CssClass="form-control w-75" />
            </div>

            <div class="d-flex justify-content-end mb-2">
                <p class="text-warning small me-4 mb-0">Cat.</p>
                <asp:TextBox runat="server" ID="Categoria" Text="" CssClass="form-control w-75" />
            </div>

            <div class="d-flex justify-content-end mb-2">
                <p class="text-warning small me-4 mb-0">Img</p>
                <asp:TextBox runat="server" ID="Immagine" Text="" CssClass="form-control w-75" />
            </div>

            
                      


            <asp:Button runat="server" ID="invioModifica" OnClick="invioModifica_Click" CssClass="btn btn-sm btn-success w-75 mt-3" Text="Salva" />

        </div>
    </div>

</asp:Content>
