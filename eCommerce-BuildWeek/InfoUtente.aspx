<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoUtente.aspx.cs" Inherits="eCommerce_BuildWeek.InfoUtente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
           <div class="col-12 text-center">
                        <div class="center-form justify-content-center mx-auto text-center">
                        <h2 class="mb-2">Informazioni Utente</h2>
                        <asp:Label Text="Nome" CssClass="text-white mb-1  mx-auto" runat="server" />
                        <asp:TextBox id="Nome" runat="server" class="form-control mx-auto mb-1"/>

                        <asp:Label Text="Cognome" CssClass=" text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Cognome" runat="server" class="form-control mx-auto mb-1"/>

                        <asp:Label Text="Email" CssClass="text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Email" runat="server" class="form-control mx-auto mb-1"/>

                        <asp:Label Text="Password" CssClass="text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Password" runat="server" class="form-control mx-auto mb-1"/>

                        <asp:Label Text="Indirizzo" CssClass="text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Indirizzo" runat="server" class="form-control  mx-auto mb-1"/>

                        <asp:Label Text="Città" CssClass="text-white mx-auto mb-1" runat="server" />
                        <asp:TextBox id="Citta" runat="server" class="form-control mx-auto mb-1"/>

                        <asp:Label Text="Cap" CssClass="text-white mx-auto mb-1" runat="server" />
                        <asp:TextBox id="Cap" runat="server" class="form-control mx-auto mb-4"/>
                        </div>
                      <asp:Button runat="server" ID="Modifica" OnClick="Modifica_Click" Text="Modifica" CssClass="btn title-up w-100 text-white btn2o p-2 rounded-1" />
                    </div>
                </div>

        <h2 class="mt-5 mb-4">Riepilogo Ordini</h2>

        <div class="row text-bg-secondary bg-opacity-10">

            <div class="col-2">
                <p class="text-warning small m-0">Id</p>
            </div>
            <div class="col-3">
                <p class="text-warning small m-0">Spedito a</p>
            </div>
            <div class="col-2">
                <p class="text-warning small m-0">N.Articoli</p>
            </div>
            <div class="col-3">
                <p class="text-warning small m-0">Totale</p>
            </div>
            <div class="col-2">
                <p class="text-warning small m-0"></p>
            </div>
        </div>




            <div class="col-12">
                <asp:Repeater runat="server" ID="RiepilodoOrdiniRep">
                    <ItemTemplate>
                      <div class="row border-bottom py-3">

                           <div class="col-2 text-secondary">
                                <asp:Label Text='<%# Eval("idOrdine") %>' runat="server" />
                           </div>

                           <div class="col-3 text-white">     
                               <asp:Label Text='<%# Eval("Indirizzo_Spedizione") %>' ID="indirizzoSpedizione" runat="server" />
                           </div>      
                               
                           <div class="col-2 text-white">
                               <asp:Label Text='<%# Eval("Quantita") %>' ID="Quantità" runat="server" />
                           </div>    
                               
                            <div class="col-3 text-white">
                               <asp:Label Text='<%# Eval("Totale") %>' ID="Totale" runat="server" />
                            </div>   
                               
                        <div class="col-2">
                               <a href='<%# "/DettagliOrdine.aspx?ordineId=" + Eval("idOrdine") %>' class="btn p-1 title-up btn2o text-white" id="DettagliOrdini" runat="server" >Dettagli</a>  
                            </div>

                        </div>
 
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
  

</asp:Content>
