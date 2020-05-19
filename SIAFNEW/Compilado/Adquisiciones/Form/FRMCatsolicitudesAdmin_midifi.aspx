<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMCatsolicitudesAdmin_midifi.aspx.cs" Inherits="SAF.Adquisiciones.FRMCatsolicitudesAdmin_midifi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            font-family: "Trebuchet Ms", Arial, Verdana;
            font-weight: normal;
            font-size: 12px;
            color: #404040;
            width: 85%;
            height: 95%;
            border-collapse: collapse;
            border: 1px solid #d49475;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            padding-left: 0px;
            padding-right: 0px;
            background-color: #e8c2ae;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="STATUS:"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="SSL003">DENEGADA</asp:ListItem>
                            <asp:ListItem Value="SSL004">AUTORIZADA</asp:ListItem>
                            <asp:ListItem Value="SSL005">COTIZACI&#211;N</asp:ListItem>
                            <asp:ListItem Value="SSL006">VISTO BUENO</asp:ListItem>
                            <asp:ListItem Value="SSL007">CANCELADA</asp:ListItem>
                            <asp:ListItem Value="SSL008">CONCLUIDA</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="Label2" runat="server" Text="OBSERVACIONES:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="100px" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
                </tr>
                
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
