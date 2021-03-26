<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultas.aspx.cs" Inherits="SAF.Presupuesto.Form.frmConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
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
                                <td style="width: 10%">
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia"></asp:Label>
                                <%--</td>
                                <td>--%>
                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label1" runat="server" Text="Fuente"></asp:Label>
                                <%--</td>
                                <td>--%>
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label3" runat="server" Text="Código Programatico"></asp:Label>
                                <%--</td>
                                <td>--%>
                                    <asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="GRDCargarDatosCodProg">
                                    </asp:DropDownList>
                                </td>
                            </tr>


                            <tr>
                                <asp:GridView ID="grdCapitulo" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="chkcapitulo" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="ID" />
                                        <asp:BoundField DataField="Capitulo" HeaderText="CAPITULO" />
                                    </Columns>
                                    <FooterStyle CssClass="enc" />
                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                    <SelectedRowStyle CssClass="sel" />
                                    <HeaderStyle CssClass="enc" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                                <%--<asp:Button ID="btnChkCapitulos_v1" runat="server" OnClick="btnChkCapitulos_v1_Click"
                                    Text="Marcar todos" Width="15%" CssClass="btn" CausesValidation="False" />--%>
                                <asp:Button runat="server" ID="BTNBuscar" Text="Buscar" CssClass="btn" OnClick="BTNBuscar_Click" />
                            </tr>
                            




                            

                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate> 
                                            <h6>Movimientos</h6>
                                            <asp:GridView ID="GRDCodProg" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="MES" HeaderText="MES" />
                                                    <asp:BoundField DataField="AUTORIZADO" HeaderText="Autorizado" />
                                                    <asp:BoundField DataField="Modificado" HeaderText="Modificado" />
                                                    <asp:BoundField DataField="Ministrado" HeaderText="Ministrado" />
                                                    <asp:BoundField DataField="Comprometido" HeaderText="Comprometido" />
                                                    <asp:BoundField DataField="Devengado" HeaderText="Devengado" />
                                                    <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" />
                                                    <asp:BoundField DataField="Pagado" HeaderText="Pagado" />
                                                    <asp:BoundField DataField="Disminucion" HeaderText="Min - Comprometido" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<asp:LinkButton ID="LinkButton1" onclientclick="return confirm('Al cerrar la dependencia, la plantilla queda en bitacora y las modificaciones seran atendidas con su operador');" runat="server" OnClick="LinkButton1_Click">CERRAR</asp:LinkButton>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <h6>Cédulas</h6>
                                            <asp:GridView ID="GRDCedulas" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Cedula" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Importe_Mensual" HeaderText="Parcial" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />                                                    
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
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <h6>Aumentos</h6>
                                            <asp:GridView ID="GRDAumentos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                                    <asp:BoundField DataField="Importe_Origen" HeaderText="Importe Origen" />
                                                    <asp:BoundField DataField="Importe_Destino" HeaderText="Importe Destino" />
                                                    <asp:BoundField DataField="Mes_Inicial" HeaderText="I" />
                                                    <asp:BoundField DataField="Mes_Final" HeaderText="F" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />                                                    
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
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <h6>Ministraciones</h6>
                                            <asp:GridView ID="GRDMinistraciones" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                                    <asp:BoundField DataField="Importe_Mensual" HeaderText="Importe" />
                                                    <asp:BoundField DataField="Mes_Inicial" HeaderText="Mes" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
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
