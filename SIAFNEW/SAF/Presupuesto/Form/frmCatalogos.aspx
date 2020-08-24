<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogos.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <iframe id="frmCapitulos" src="https://sysweb.unach.mx/presupuesto_mvc/Presupuesto/Capitulos" style="width: 100%; height: 1200px" frameborder="NO" name="frmPosgrado"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
