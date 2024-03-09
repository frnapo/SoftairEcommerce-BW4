<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="backOffice.aspx.cs" Inherits="eCommerce_BuildWeek.backOffice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="d-flex justify-content-between">

            <h2>Back Office</h2>
            <a href="Aggiungi.aspx" class="btn btn-warning title-up mb-3 p-2">Aggiungi</a>
        </div>
        <!-- intestazione tabella -->
        <div class="row text-bg-light bg-opacity-10">

            <div class="col-2">
                <p class="text-warning small m-0">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-card-image" viewBox="0 0 16 16">
                        <path d="M6.002 5.5a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0" />
                        <path d="M1.5 2A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2zm13 1a.5.5 0 0 1 .5.5v6l-3.775-1.947a.5.5 0 0 0-.577.093l-3.71 3.71-2.66-1.772a.5.5 0 0 0-.63.062L1.002 12v.54L1 12.5v-9a.5.5 0 0 1 .5-.5z" />
                    </svg>
                </p>
            </div>
            <div class="col-2">
                <p class="text-warning small m-0">Nome</p>
            </div>
            <div class="col-4">
                <p class="text-warning small m-0">Descrizione</p>
            </div>
            <div class="col-2">
                <p class="text-warning small m-0">Prezzo</p>
            </div>
            <div class="col-1">
                <p class="text-warning text-center small m-0">Qt.a</p>
            </div>
            <div class="col-1 text-end">
                <p class="text-warning small m-0">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-gear" viewBox="0 0 16 16">
                        <path d="M8 4.754a3.246 3.246 0 1 0 0 6.492 3.246 3.246 0 0 0 0-6.492M5.754 8a2.246 2.246 0 1 1 4.492 0 2.246 2.246 0 0 1-4.492 0" />
                        <path d="M9.796 1.343c-.527-1.79-3.065-1.79-3.592 0l-.094.319a.873.873 0 0 1-1.255.52l-.292-.16c-1.64-.892-3.433.902-2.54 2.541l.159.292a.873.873 0 0 1-.52 1.255l-.319.094c-1.79.527-1.79 3.065 0 3.592l.319.094a.873.873 0 0 1 .52 1.255l-.16.292c-.892 1.64.901 3.434 2.541 2.54l.292-.159a.873.873 0 0 1 1.255.52l.094.319c.527 1.79 3.065 1.79 3.592 0l.094-.319a.873.873 0 0 1 1.255-.52l.292.16c1.64.893 3.434-.902 2.54-2.541l-.159-.292a.873.873 0 0 1 .52-1.255l.319-.094c1.79-.527 1.79-3.065 0-3.592l-.319-.094a.873.873 0 0 1-.52-1.255l.16-.292c.893-1.64-.902-3.433-2.541-2.54l-.292.159a.873.873 0 0 1-1.255-.52zm-2.633.283c.246-.835 1.428-.835 1.674 0l.094.319a1.873 1.873 0 0 0 2.693 1.115l.291-.16c.764-.415 1.6.42 1.184 1.185l-.159.292a1.873 1.873 0 0 0 1.116 2.692l.318.094c.835.246.835 1.428 0 1.674l-.319.094a1.873 1.873 0 0 0-1.115 2.693l.16.291c.415.764-.42 1.6-1.185 1.184l-.291-.159a1.873 1.873 0 0 0-2.693 1.116l-.094.318c-.246.835-1.428.835-1.674 0l-.094-.319a1.873 1.873 0 0 0-2.692-1.115l-.292.16c-.764.415-1.6-.42-1.184-1.185l.159-.291A1.873 1.873 0 0 0 1.945 8.93l-.319-.094c-.835-.246-.835-1.428 0-1.674l.319-.094A1.873 1.873 0 0 0 3.06 4.377l-.16-.292c-.415-.764.42-1.6 1.185-1.184l.292.159a1.873 1.873 0 0 0 2.692-1.115z" />
                    </svg>
                </p>
            </div>
        </div>


        

        <!-- contenuto tabella -->
        <asp:Repeater ID="backOfficeRepeater" runat="server">
            <ItemTemplate>

                <div class="row border-bottom py-3">

                    <div class="col-2">
                        <img src='<%# Eval("Immagine") %>' class="card-img-top img-fluid"  alt='<%# Eval("Nome") %>'>
                    </div>
                    <div class="col-2">
                        <h5 class="card-title text-white fw-semibold mb-2"><%# Eval("Nome") %></h5>
                        <p class="small">id:<%# Eval("idProdotto") %></p>
                    </div>
                    <div class="col-4">
                        <p class="fw-normal small mb-0"><%# Eval("Descrizione") %></p>
                    </div>
                    <div class="col-2">
                        <p class="fw-semibold fs-6 mb-0"><%# Eval("Prezzo", "{0:c2}") %></p>
                    </div>
                    <div class="col-1">
                        <p class="fw-normal small text-center mb-0"><%# Eval("Unita") %></p>
                    </div>
                    <div class="col-1 text-end p-0">
                        <a id="A1" href='<%# "Modifica.aspx?ProdottoId=" + Eval("idProdotto") %>' runat="server" class="btn btn-sm btn-warning pb-2 mb-1">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z" />
                            </svg>
                        </a>


                        
                    </div>


                </div>







            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
