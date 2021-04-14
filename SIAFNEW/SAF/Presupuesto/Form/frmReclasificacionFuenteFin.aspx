<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReclasificacionFuenteFin.aspx.cs" Inherits="SAF.Presupuesto.Form.frmReclasificacionFuenteFin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
        .ColumnaOculta {
            display: none;
        }
    </style>
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
                                <td style="width: 10%">
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia Inicial"></asp:Label>
                                    <asp:DropDownList ID="DDLDependenciaI" runat="server" Width="400px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label2" runat="server" Text="Partida"></asp:Label>
                                    <asp:DropDownList ID="DDLPartida" runat="server" Width="400px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label5" runat="server" Text="Mes Inicial"></asp:Label>
                                    <asp:DropDownList ID="DDLMesI" runat="server" Width="400px" AutoPostBack="True">
                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                </tr>
                            <tr>
                                <td style="width: 10%">
                                    <asp:Label ID="Label1" runat="server" Text="Dependencia Final"></asp:Label>
                                    <asp:DropDownList ID="DDLDependenciaF" runat="server" Width="400px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label3" runat="server" Text="Fuente Origen"></asp:Label>
                                    <asp:DropDownList ID="DDLFuenteOrigen" runat="server" Width="400px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label6" runat="server" Text="Mes Final"></asp:Label>
                                    <asp:DropDownList ID="DDLMesF" runat="server" Width="400px" AutoPostBack="True">
                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                                                                
                            </tr>
                            <tr>
                                <td>
                                <asp:UpdatePanel ID="updBtns" runat="server">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="BTNBuscarCodigo" Text="Buscar" CssClass="btn" OnClick="BTNBuscar_Click"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="center" colspan="5">
                                <asp:UpdateProgress ID="updPrBtns" runat="server" AssociatedUpdatePanelID="updBtns">
                                    <progresstemplate>
                                        <asp:Image ID="imgBtns" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />                                       </progresstemplate>
                                    </asp:UpdateProgress>
                            </td>
                            </tr>                            
                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate> 
                                            <h6>Reclasificación de Fuentes de Financiamiento</h6>
                                            <asp:GridView ID="GRDCodigosRecla" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="Codigo_Programatico" HeaderText="Código Presupuestal" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="EjercidoSuma" HeaderText="Ejercido" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" ItemStyle-HorizontalAlign="Center"/>
                                                </Columns>
                                                <PagerStyle HorizontalAlign="Left" />
                                                <FooterStyle CssClass="enc" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />

                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                             </tr>
                            <tr>
                                 <td style="width:30%">
                                    <asp:Label ID="lblPorcentaje" runat="server" Text="Porcentaje %">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtProcentaje" Text="" runat="server" Width="500px" MaxLength="5">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblFuenteDest1" runat="server" Text="Fuente Destino 1">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:DropDownList ID="DDLFuenteDest1" runat="server" Width="500px" AutoPostBack="True" ></asp:DropDownList>                                    
                                </td>                                
                            </tr>
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblFuenteDest2" runat="server" Text="Fuente Destino 2">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:DropDownList ID="DDLFuenteDest2" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>                                    
                                </td>                                
                            </tr>
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblAplicar" runat="server" Text="Aplicar en">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:DropDownList ID="DDLAplicar" runat="server" Width="400px" AutoPostBack="True">
                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    </asp:DropDownList>                                  
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