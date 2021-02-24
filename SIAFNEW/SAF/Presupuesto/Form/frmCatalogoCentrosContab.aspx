<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogoCentrosContab.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogoCentrosContab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mensaje">
                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <table class="tabla_contenido">
                <tr>
                    <td class="auto-style1">
                        <table style="width: 100%;">                            

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblCentroContab" runat="server" Text="Clave centro contable">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtCentroContab" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Nombre dependencia">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDependencia" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <button class="" >Guardar</button>
                                </td>                                
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
