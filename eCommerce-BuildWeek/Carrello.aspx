<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Carrello.aspx.cs" Inherits="eCommerce_BuildWeek.Carrello" %>

<asp:Content ID="BodyContent2" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BlackMarket - Carrello</title>
</head>
<body>
        <div class="container">
    <p class="alert custom-alert text-center title-up" runat="server" id="alert"></p>


            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <div class="row border border-1 border-secondary border-start-0 border-end-0 border-top-0 mb-3">
                        <div class="col-7">
                            <img src='<%# Eval("Immagine") %>' class="card-img-top img-fluid mb-3" style="max-height: 250px; object-fit: contain" alt='<%# Eval("Nome") %>'>
                        </div>

                        <div class="col-5">

                         <div class="d-flex justify-content-between align-items-end">
                            <h5 class="card-title title-up fs-1"><%# Eval("Nome") %></h5>
                            <p class="fw-semibold fs-6 mb-0"><%# Eval("Prezzo", "{0:c2}") %></p>
                         </div>

                            
                            <span class="badge p-0 text-success" id="Disponibilita" runat="server">Disponibilità immediata</span>
                            <h2 class="fs-6 mt-3 mb-0 pb-0">Descrizione:</h2>
                            <p class="card-text mt-0 pt-0 text-truncate"><%# Eval("Descrizione") %></p>


                            <div class="d-flex">
                                <p class="fw-semibold fs-6 mb-0 d-flex align-items-end">
                                    Q.tà:
                                <asp:Button ID="incrementaQuantita" runat="server" Text="+" OnClick="incrementaQuantita_Click" CommandArgument='<%# Eval("Id") %>' CssClass="ms-2 btn title-up text-white" />
                                    <asp:TextBox ID="quantita" runat="server" Text='<%# Eval("QuantityInCart") %>' CssClass="ms-2 " Width="30px" ReadOnly="true" />
                                    <asp:Button ID="decrementaQuantita" runat="server" Text="-" OnClick="decrementaQuantita_Click" CommandArgument='<%# Eval("Id") %>' CssClass="ms-2 btn title-up text-white" />

                                    <%--<p runat="server" id="n_prodotti" class="mb-0"><%# Eval("Quantità") %></p>--%>
                                    <asp:Button ID="rimuoviCarrello" runat="server" OnClick="rimuoviCarrello_Click" Text="Rimuovi" CssClass="btn2q ms-2 btn title-up text-white" CommandArgument='<%# Eval("Id") %>' />
                            </div>

                        </div>



                    </div>
                </ItemTemplate>
            </asp:Repeater>


<div class="d-flex flex-column align-items-end">
    <p runat="server" id="contoTotale" class="text-end mb-0"></p>
    <asp:Button  id="procediOrdine" OnClick="procediOrdine_Click" runat="server" Text="Procedi all'acquisto" Visible="false" CssClass="p-3 mt-2 btn btn btn2o title-up text-white"/>
</div>
</div>
</body>
</html>
</asp:Content>

 




