<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultas.aspx.cs" Inherits="SAF.Presupuesto.Form.frmConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
        .ColumnaOculta {
            display: none;
        }

         .overlay {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }

        .overlayContent {
            z-index: 99;
            margin: 250px auto;
            width: 80px;
            height: 80px;
        }

            .overlayContent h2 {
                font-size: 18px;
                font-weight: bold;
                color: #000;
            }

            .overlayContent img {
                width: 30px;
                height: 30px;
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
                                <td style="width:20%">
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia"></asp:Label>
                                    </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged" ></asp:DropDownList>
                                </td>
                                </tr>
                            <tr>
                                <td style="width:20%">
                                    <asp:Label ID="Label1" runat="server" Text="Fuente"></asp:Label>
                                    </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%">
                                    </td>
                                <td colspan="2">
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
                                    </td>
                                <%--<asp:Button ID="btnChkCapitulos_v1" runat="server" OnClick="btnChkCapitulos_v1_Click"
                                    Text="Marcar todos" Width="15%" CssClass="btn" CausesValidation="False" />--%>
                            </tr>
                            <tr>
                                <td style="width:20%"></td>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                                        <ContentTemplate>
                                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label ID="Label3" runat="server" Text="Código programático"></asp:Label>
                                </td>

                                 <td colspan="2">
                                    <asp:UpdatePanel ID="updPnlCodProg" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLCodProg" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="cuadro_botones" colspan="5">
                                    <asp:ImageButton ID="imgBttnPDF" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnPDF_Click" title="Reporte PDF" />
                                </td>
                            </tr>


                            

                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate> 
                                            <h6>Movimientos</h6>
                                            <asp:GridView ID="grdCodProg" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="MES" HeaderText="MES" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="AUTORIZADO" HeaderText="Autorizado" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Modificado" HeaderText="Modificado" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Ministrado" HeaderText="Ministrado" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Comprometido" HeaderText="Comprometido" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Devengado" HeaderText="Devengado" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Ejercido" HeaderText="Ejercido" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Pagado" HeaderText="Pagado" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Disminucion" HeaderText="Min - Comprometido"  DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"/>
                                                    
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
                <tr>
                                                                                <td class="centro">
                                                                                    <asp:UpdateProgress ID="updProCodProg" runat="server" AssociatedUpdatePanelID="updPnlCodProg">
                                                                                        <ProgressTemplate>
                                                                                            <div class="overlay">
                                                                                                <div class="overlayContent">
                                                                                                    <asp:Image ID="img1" runat="server" Height="100px" ImageUrl="~/images/loader2.gif" Width="100px" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </ProgressTemplate>
                                                                                    </asp:UpdateProgress>
                                                                                    <asp:UpdateProgress ID="updProBtnBuscar" runat="server" AssociatedUpdatePanelID="updPnlBuscar">
                                                                                        <ProgressTemplate>
                                                                                            <div class="overlay">
                                                                                                <div class="overlayContent">
                                                                                                    <asp:Image ID="img2" runat="server" Height="100px" ImageUrl="~/images/loader2.gif" Width="100px" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </ProgressTemplate>
                                                                                    </asp:UpdateProgress>
                                                                                </td>
                                                                            </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>