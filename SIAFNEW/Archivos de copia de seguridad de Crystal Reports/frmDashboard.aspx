<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="SAF.Presupuesto.Form.frmDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/construccion.PNG" />
            </div>
            <div class="col-md-3">
                <h2>En construcción...</h2>
                </div>
        </div>
    </div>
</asp:Content>
