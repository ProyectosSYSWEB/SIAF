<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultas.aspx.cs" Inherits="SAF.Presupuesto.Form.frmConsultas" %>

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
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia"></asp:Label>
                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label1" runat="server" Text="Fuente"></asp:Label>
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:UpdatePanel ID="updBtns" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label3" runat="server" Text="Código Programatico"></asp:Label>
                                            <asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="GRDCargarDatosCodProg">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" colspan="5">
                                    <asp:UpdateProgress ID="updPrBtns" runat="server" AssociatedUpdatePanelID="updBtns">
                                        <progresstemplate>
                                            <asp:Image ID="imgBtns" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
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
                                                    <asp:BoundField DataField="MES" HeaderText="MES" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="AUTORIZADO" HeaderText="Autorizado" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Modificado" HeaderText="Modificado" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Ministrado" HeaderText="Ministrado" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Comprometido" HeaderText="Comprometido" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Devengado" HeaderText="Devengado" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Pagado" HeaderText="Pagado" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Disminucion" HeaderText="Min - Comprometido" ItemStyle-HorizontalAlign="Right"/>
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
                                            <asp:GridView ID="GRDCedulas" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro." OnSelectedIndexChanged="GRDCedulas_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Cedula" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Tipo_Evento" HeaderText="Evento"/>
                                                    <asp:BoundField DataField="Importe_Mensual" HeaderText="Parcial" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" /> 
                                                    <asp:BoundField DataField="Mes_Inicial" HeaderText="Mes_Inicial"  ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" />
                                                    <asp:BoundField DataField="Mes_Final" HeaderText="Mes_Final" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta"  />                                                    
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="LinkBImprimir" runat="server" OnClick="LinkBImprimir_Click">Imprimir</asp:LinkButton>
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
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <h6>Adecuaciones</h6>
                                            <asp:GridView ID="GRDAumentos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Tipo_Evento" HeaderText="Nombre Docto"/>
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                                    <asp:BoundField DataField="Importe_Origen" HeaderText="Importe Origen" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Importe_Destino" HeaderText="Importe Destino" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Mes_Inicial" HeaderText="I" />
                                                    <asp:BoundField DataField="Mes_Final" HeaderText="F" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <%--<asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkBtnMovAumentos" runat="server" CommandName="Delete" Visible="true">Movimientos</asp:LinkButton>
                                                            <asp:Label ID="lblMovAumentos" runat="server" ForeColor="#6B696B" Text="Movimientos" Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                     </asp:TemplateField>--%>
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
                                                    <asp:BoundField DataField="Tipo_Evento" HeaderText="Nombre Docto"/>
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                                    <asp:BoundField DataField="Importe_Mensual" HeaderText="Importe" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Mes_Inicial" HeaderText="Mes" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <%--<asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkBtnMovMinist" runat="server" CommandName="Delete" Visible="true">Movimientos</asp:LinkButton>
                                                            <asp:Label ID="lblMovMinist" runat="server" ForeColor="#6B696B" Text="Movimientos" Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                     </asp:TemplateField>--%>
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