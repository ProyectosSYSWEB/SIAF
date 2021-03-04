<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogoCtrlPres.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogoCtrlPres" %>

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
                                    <asp:Label ID="lblCentroContab" runat="server" Text="Centro contable"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCentroContab" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCentroContab_SelectedIndexChanged"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTipofondo" runat="server" Text="Programa"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLPrograma" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblSubprog" runat="server" Text="Subprograma"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLSubprog" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblDepen" runat="server" Text="Dependencia"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLDepend" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblProy" runat="server" Text="Proyecto"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLProy" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>--%>
                                </td>
                            </tr>
                            
                            

                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="BTNGuardarCatPres" Text="Guardar" OnClick="BTNGuardarCatPres_Click" />
                                </td>
                                <td>                                    
                                </td>
                                <td>
                                    <a href="frmControlPresupuestal.aspx">Regresar</a>
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
