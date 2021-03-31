<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatFuenteFin.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatFuenteFin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<div class="mensaje">
                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
            <table class="tabla_contenido">
                <tr>
                    <td class="auto-style1">
                        <table style="width: 100%;">                           



                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTipofuente" runat="server" Text="Tipo Fuente"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLTipofuente" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLTipofuente_SelectedIndexChanged"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTipofondo" runat="server" Text="Tipo Fondo"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLTipofondo" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label1" runat="server" Text="Tipo Fuente"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDDLTipoSubFondo" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>

                            
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblfuente" runat="server" Text="Fuente">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtFuente" Text="" runat="server" Width="500px">
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
                                    <asp:Button runat="server" ID="BTNGuardarFuenteFin" Text="Guardar" OnClick="BTNGuardarFuenteFin_Click" />
                                </td>       
                                <td>

                                </td>
                                <td>
                                    <a href="frmFuenteFin.aspx">Regresar</a>
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
