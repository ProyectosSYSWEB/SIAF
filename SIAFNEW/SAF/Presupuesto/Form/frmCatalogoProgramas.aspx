<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogoProgramas.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogoProgramas" %>

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
                                <td style="width: 30%">
                                    <asp:Label ID="lblFuncion" runat="server" Text="Función"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLFuncion" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblFunFed" runat="server" Text="Función Federal"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLFuenteFed" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                            </tr>


                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblProg" runat="server" Text="Programa">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtPrograma" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblDescrip" runat="server" Text="Descripción">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDescripcion" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" Text="Guardar" ID="BTNGuardar" OnClick="BTNGuardar_Click" />                                    
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
