<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdmin_CFDI.aspx.cs" Inherits="SAF.Contabilidad.Form.frmAdmin_CFDI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 154px;
        }

        .auto-style2 {
            width: 158px;
        }

        .auto-style3 {
            text-align: right;
            width: 111px;
        }

        .auto-style4 {
            width: 243px;
        }

        .auto-style5 {
            width: 121px;
        }
        .auto-style6 {
            width: 824px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table class="tabla_contenido">
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Centro Contable:</td>

                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDLCentro_Contable" runat="server" Width="100%"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="auto-style5">Tipo Beneficiario:</td>
                        <td>
                            <table style="width: 100%;">
                                <tr valign="top">
                                    <td class="auto-style2">
                                        <asp:DropDownList ID="ddlTipo_Beneficiario" runat="server" Width="100%">
                                        </asp:DropDownList>

                                    </td>
                                    <td class="auto-style3">Tipo Gasto:</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlTipo_Gasto" runat="server" Width="100%">
                                        </asp:DropDownList>

                                    </td>
                                    <td class="auto-style4"></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="auto-style5">Buscar:
                        </td>
                        <td>
                            <table style="width: 100%">
                                <tr  valign="top">
                                    <td class="auto-style6">
                                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="textbuscar" Width="100%" PlaceHolder="Folio/Nombre/UUID"></asp:TextBox>


                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgbtnBuscar" runat="server" CausesValidation="False" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" Style="text-align: right" title="Buscar" />

                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image7" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                    Width="50px" AlternateText="Espere un momento, por favor.."
                                                    ToolTip="Espere un momento, por favor.." />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grvPolizaCFDI" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" ShowFooter="True" Width="100%" OnPageIndexChanging="grvPolizaCFDI_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="Centro_Contable" HeaderText="Centro Contable" />
                                            <asp:BoundField DataField="Beneficiario_Tipo" HeaderText="Tipo Beneficiario" />
                                            <asp:BoundField DataField="CFDI_Folio" HeaderText="Folio" />
                                            <asp:BoundField DataField="CFDI_Fecha" HeaderText="Fecha" />
                                            <asp:BoundField DataField="CFDI_Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="CFDI_UUID" HeaderText="UUID" />
                                            <asp:BoundField HeaderText="Fecha Registro" DataField="Fecha_Captura" />
                                            <asp:BoundField HeaderText="Usuario Registra" DataField="Usuario_Captura" />
                                            <asp:TemplateField HeaderText="Archivos">
                                                <FooterTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="imgBttnPDF" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" title="Reporte PDF" OnClick="imgBttnPDF_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imgBttnExcel" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" title="Reporte Excel" OnClick="imgBttnExcel_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="linkArchivoXML" runat="server" NavigateUrl='<%# Bind("Ruta_XML") %>' Target="_blank">XML</asp:HyperLink>
                                                    &nbsp;<asp:HyperLink ID="linkArchivoPDF" runat="server" NavigateUrl='<%# Bind("Ruta_PDF") %>' Target="_blank">PDF</asp:HyperLink>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
