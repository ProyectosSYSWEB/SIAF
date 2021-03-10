<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogoAdecuaciones.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogoAdecuaciones" %>

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
                                    <asp:Label ID="lblTipoAdecuacion" runat="server" Text="Tipo de adecuación"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLTipoAdecuacion" runat="server" Width="500px" AutoPostBack="True" Enabled="false">
                                    <asp:ListItem Value="N">Nomina</asp:ListItem>
                                    </asp:DropDownList>                                    
                                </td>
                            </tr>

                             
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblMesAnio" runat="server" Text="Mes y año">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtMesAnio" Text="" runat="server" Width="500px" maxlength="4" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style63">
                                    <asp:Label ID="lblfechaDocumento" runat="server" Text="Fecha"></asp:Label>
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtfechaDocumento" runat="server" CssClass="box" Enabled="False" Width="95px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtfechaDocumento" />
                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtfechaDocumento" ErrorMessage="*Fecha Requerida" InitialValue="T" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblStatusOpe" runat="server" Text="Estatus operación">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtStatusOperacion" Text="" runat="server" Width="500px" maxlength="4" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblConcepto" runat="server" Text="Concepto">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">
                                    <asp:TextBox ID="txtConcepto" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lbl" runat="server" Text="Mes inicial"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLMesInicial" runat="server" Width="500px" AutoPostBack="True">
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
                                <td style="width: 30%">
                                    <asp:Label ID="Label1" runat="server" Text="Mes final"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLMesFin" runat="server" Width="500px" AutoPostBack="True">
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
                                <td style="width: 30%">
                                    <asp:Label ID="lblPartida" runat="server" Text="Partida"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLPartida" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblFuente" runat="server" Text="Fuente"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblCodigoOrigen" runat="server" Text="Origen"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCodOrigen" runat="server" Width="500px" AutoPostBack="True"  OnSelectedIndexChanged="DDLCodOrigen_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>


                            <td colspan="3">                            
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GRDAdecuaciones" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="Mes" HeaderText="Mes" />
                                                    <asp:BoundField DataField="TipoOperacion" HeaderText="Tipo operación " />
                                                    <asp:BoundField DataField="Centro_Contab" HeaderText="C. Contab" />
                                                    <asp:BoundField DataField="Codigo_Programatico" HeaderText="Código programático" />
                                                    <asp:BoundField DataField="Destino" HeaderText="Destino" />                                                                                                 
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" onclientclick="return confirm('¿Desea eliminar el Documento?');" Visible='<%# Bind("Opcion_Eliminar") %>'>Eliminar</asp:LinkButton>
                                                                    <asp:Label ID="lblEliminar" runat="server" ForeColor="#6B696B" Text="Eliminar" Visible='<%# Bind("Opcion_Eliminar2") %>'></asp:Label>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                                <FooterStyle CssClass="enc" />
                                                <%--<PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />--%>
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>

                            <tr>
                                <td>
                                    
                                </td>  
                                <td>

                                </td>
                                <td>
                                    <a href="frmCapitulo.aspx">Regresar</a>
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
