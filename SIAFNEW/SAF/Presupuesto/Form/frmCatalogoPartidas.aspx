<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogoPartidas.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogoPartidas" %>

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
                                    <asp:Label ID="lblCap" runat="server" Text="Capitulo"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCapt" runat="server" Width="500px" AutoPostBack="True"  OnSelectedIndexChanged="DDLCapt_SelectedIndexChanged"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblSubcap" runat="server" Text="Subcapitulo"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLSubcap" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLSubcap_SelectedIndexChanged"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblsubsubcap" runat="server" Text="Sub-subcapitulo"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLSubsubcap" runat="server" Width="500px" AutoPostBack="True" OnTextChanged="DDLSubsubcap_SelectedIndexChanged"  ></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblPartida" runat="server" Text="Partida">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtPartida" Text="" runat="server" Width="500px" MaxLength="5">
                                    </asp:TextBox>
                                </td>
                            </tr>                            

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblDescrip" runat="server" Text="Descripción">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDescrip" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>                           

                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="BTNGuardarPartida" Text="Guardar" OnClick="BTNGuardarPartida_Click" />
                                </td>
                                <td>                                    
                                </td>
                                <td>
                                    <a href="frmPartida.aspx">Regresar</a>
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
