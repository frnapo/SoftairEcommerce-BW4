<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  EnableEventValidation="false" CodeBehind="SignUp.aspx.cs" Inherits="eCommerce_BuildWeek.SignUp" %>
<asp:Content ID="BodyContent3" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h2 class="text-center title-up fs-4 mb-4">Registrazione su BlackMarket</h2>
    <div class="d-flex flex-column">
        <p class="alert alert-danger" runat="server" id="alert"></p>
        <asp:TextBox ID="TextName" runat="server" placeholder="Nome" cssClass="mb-2 form-control mx-auto"/>
        <asp:TextBox ID="TextCognome" runat="server" placeholder="Cognome" cssClass="mb-2 form-control mx-auto"/>
        <asp:TextBox ID="TextEmail" runat="server" placeholder="Email" TextMode="Email" cssClass="mb-2 form-control mx-auto"/>
        <asp:TextBox ID="TextPassword" runat="server" placeholder="Password" TextMode="Password" cssClass="mb-2 form-control mx-auto"/>
        <asp:TextBox ID="TextInirizzo" runat="server" placeholder="Indirizzo" cssClass="mb-2 form-control mx-auto"/>
        <asp:TextBox ID="TextCap" runat="server" placeholder="Cap" cssClass="mb-2 form-control mx-auto"/>
        <asp:TextBox ID="TextCittà" runat="server" placeholder="Città" cssClass="mb-2 form-control mx-auto"/>
        <div class="mx-auto">
            <asp:Button ID="Registrati" runat="server" Text="Registrati" CssClass="btn btn2o px-5 py-2 title-up text-white mt-3" OnClick="Registrati_Click" />
        </div>
    </div>
</body>
</html>
</asp:Content>

