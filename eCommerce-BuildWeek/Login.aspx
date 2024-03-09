<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eCommerce_BuildWeek.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12 text-center">
                <p class="title-up fs-3 text-center">
                    Accedi
                </p>
                <p>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </p>
                
                <div class="center-form justify-content-center">
                <div class="form-group mb-3 ">
                    <asp:TextBox ID="TextEmail" runat="server" CssClass="mx-auto form-control" placeholder="E-mail" />
                    </div>
                <div class="form-group mb-3">
                    <asp:TextBox ID="TextPassword" runat="server" CssClass="mb-2 mx-auto form-control" TextMode="Password" placeholder="Password" />
                    </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn2o title-up mb-2 px-4 py-2 text-white w-100" OnClick="btnLogin_Click"/>
                    <br />
                    <asp:Label ID="lblRegistrati1" runat="server" Text="Username o password non validi. Se non hai un account, " Visible="false" CssClass="text-danger mt-2 fw-bold"></asp:Label>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/SignUp.aspx" Visible="false" CssClass="mt-2 fw-bold text-white">Registrati</asp:LinkButton>
                    <asp:Label ID="pwError" runat="server" Text="Password obbligatoria." CssClass="text-center text-danger fw-bold" Visible="false"></asp:Label>
                </div>
                </div>
                <p>Non hai un account? Registrati
                <asp:LinkButton runat="server" PostBackUrl="~/SignUp.aspx" CssClass="mt-2 fw-bold text-white">QUI</asp:LinkButton>
                </p>
                </div>
            </div>
        </div>

</asp:Content>
