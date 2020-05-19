<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConciliacionBancaria.aspx.cs" Inherits="SAF.Contabilidad.Form.frmConciliacionBancaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="../../Scripts/select2/js/select2.min.js"></script>
    <link href="../../Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
    <style type="text/css">
        .auto-style8 {
            width: 138px;
        }

        .auto-style11 {
            width: 178px;
        }

        .auto-style12 {
            width: 65px;
        }

        .auto-style15 {
            width: 469px;
        }

        .auto-style32 {
            width: 162px;
        }

        .auto-style33 {
            width: 524px;
        }

        .auto-style34 {
            width: 178px;
            height: 45px;
        }

        .auto-style35 {
            height: 45px;
        }

        .auto-style37 {
            width: 118px;
        }

        .auto-style39 {
            width: 161px;
        }

        .auto-style40 {
            width: 183px;
        }

        .auto-style45 {
            width: 111px;
        }

        .auto-style46 {
            width: 231px;
        }
    </style>
    <%-- <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                        <ContentTemplate>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <%-- <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                    <ContentTemplate>--%>

                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style34">Centro Contable:</td>
                                <td colspan="4" class="auto-style35">
                                    <asp:DropDownList ID="DDLCentro_Contable1" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style35">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDLCentro_Contable1" ErrorMessage="*Centro Contable" InitialValue="00000" ValidationGroup="Nuevo">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style35">
                                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" title="Nuevo" ValidationGroup="Nuevo" />
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="auto-style11" valign="top">Periodo Inicial:</td>
                                <td class="auto-style8" valign="top">

                                    <asp:TextBox ID="txtFechaInicial1" runat="server" CssClass="box" Width="95px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="txtFechaInicial1_CalendarExtender" runat="server" BehaviorID="_content_CalendarExtenderFechaIni" PopupButtonID="imgPeriodoInicial" TargetControlID="txtFechaInicial1" />
                                    <asp:ImageButton ID="imgPeriodoInicial" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFechaInicial1" ErrorMessage="* Periodo Inicial" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>

                                </td>
                                <td class="auto-style12">&nbsp;</td>
                                <td colspan="4">
                                    <table style="width: 100%;">
                                        <tr valign="top">
                                            <td class="auto-style37">Periodo Final:</td>
                                            <td class="auto-style39">
                                                <asp:TextBox ID="txtFechaFinal1" runat="server" CssClass="box" Width="95px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="txtFechaFinal1_CalendarExtender" runat="server" BehaviorID="_content_CalendarExtenderFechaFin" PopupButtonID="imgPeriodoFinal" TargetControlID="txtFechaFinal1" />
                                                <asp:ImageButton ID="imgPeriodoFinal" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFechaFinal1" ErrorMessage="* Periodo Final" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="imgbtnBuscar1" runat="server" CausesValidation="False" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar1_Click" Style="text-align: right" title="Buscar" ValidationGroup="Buscar" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11" valign="top">&nbsp;</td>
                                <td valign="top" colspan="6">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Campos Requeridos:" ValidationGroup="Nuevo" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:GridView ID="grdConciliacion" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontraron datos." Width="100%" OnRowDeleting="grdConciliacion_RowDeleting" OnSelectedIndexChanged="grdConciliacion_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="grdConciliacion_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="Centro_contable" HeaderText="CENTRO CONTABLE" />
                                            <asp:BoundField DataField="Desc_Cuenta_Contable" HeaderText="CTA. CONT." />
                                            <asp:BoundField DataField="Fecha_inicial" HeaderText="PERIODO INICIAL" />
                                            <asp:BoundField DataField="Fecha_final" HeaderText="PERIODO FINAL" />
                                            <asp:BoundField DataField="Elaboro_nombre" HeaderText="ELABORO" />
                                            <asp:BoundField DataField="Vb_nombre" HeaderText="VB" />
                                            <asp:TemplateField HeaderText="REPORTE">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkReporteEnc" runat="server" OnClick="linkReporteEnc_Click">Conciliación</asp:LinkButton>
                                                    &nbsp;
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ADJUNTAR">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkBttnAdj" runat="server" OnClick="linkBttnAdj_Click">Edo. de Cuenta</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowSelectButton="True" SelectText="Editar" />
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Desea eliminar el registro?');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Cuenta_Contable" />
                                            <asp:BoundField DataField="IdEnc" />
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <%--                                                
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%></td>
                            </tr>
                            <tr>
                                <td class="auto-style11">
                                    <asp:HiddenField ID="hddnEdoCta" runat="server" />
                                    <ajaxToolkit:ModalPopupExtender ID="modalAdj" runat="server" TargetControlID="hddnEdoCta" PopupControlID="pnlDoctos" BackgroundCssClass="modalBackground_Proy">
                                    </ajaxToolkit:ModalPopupExtender>
                                </td>
                                <td class="auto-style8">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                                <td class="auto-style15">&nbsp;</td>
                                <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:Panel ID="pnlDoctos" runat="server" CssClass="TituloModalPopupMsg">
                                        <table class="tabla_contenido">
                                            <tr>
                                                <td><div class="alert alert-primary" role="alert">ESTADOS DE CUENTA</div></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <div class="input-group mb-3">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">PDF</span>
                                                                </div>
                                                                <div class="custom-file">
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" Height="40px" Width="100%" />
                                                                </div>
                                                                <div class="input-group-append">
                                                                    <asp:Button ID="bttnAdjuntar" runat="server" Text="Agregar" OnClick="bttnAdjuntar_Click" CssClass="btn btn-secondary" OnClientClick="mostrar_spinner( )" ValidationGroup="XLS" Style="left: 0px; top: 0px" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Archivo incorrecto, debe ser un PDF" ValidationExpression="(.*?)\.(pdf|PDF)$" ValidationGroup="PDF"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Archivo XML" ControlToValidate="FileUpload1" Text="*" ValidationGroup="XLS"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="bttnAdjuntar" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                        <ContentTemplate>
                                                            <div class="izquierda">
                                                                <asp:GridView ID="grdDoctos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnRowDeleting="grdDoctos_RowDeleting">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="NombreArchivoPDF" HeaderText="Archivo" />
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="linkArchivoPDF" runat="server" NavigateUrl='<%# Bind("Ruta_PDF") %>' Target="_blank">Ver</asp:HyperLink>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkBttnEliminarAdj" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Desea eliminar el registro?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle CssClass="enc" />
                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle CssClass="sel" />
                                                                    <HeaderStyle CssClass="enc" />
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                </asp:GridView>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="derecha">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="derecha">
                                                    <asp:Button ID="btnCancelarAdj" runat="server" CausesValidation="False" CssClass="btn btn-secondary" OnClick="btnCancelarAdj_Click" Text="Cancelar" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnGuardarAdj" runat="server" CssClass="btn btn-primary" OnClick="btnGuardarAdj_Click" Text="Guardar" ValidationGroup="Guardar" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style8">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                                <td class="auto-style15">&nbsp;</td>
                                <td colspan="3">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" CssClass="ajax__myTab" Width="100%" ScrollBars="Vertical" OnActiveTabChanged="TabContainer2_ActiveTabChanged" AutoPostBack="True">
                                        <ajaxToolkit:TabPanel ID="TabPanel111" runat="server" HeaderText="TabPanel1">
                                            <HeaderTemplate>
                                                Encabezado
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>Periodo Inicial:</td>
                                                                <td class="auto-style40">
                                                                    <asp:TextBox ID="txtFechaInicial" runat="server" AutoPostBack="True" CssClass="box" Width="95px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaIni" runat="server" BehaviorID="_content_CalendarExtenderFechaIni" PopupButtonID="imgCalendarioIni" TargetControlID="txtFechaInicial" />
                                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFechaInicial" ErrorMessage="* Periodo Inicial" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Periodo Final:</td>
                                                                <td>

                                                                    <asp:TextBox ID="txtFechaFinal" runat="server" AutoPostBack="True" CssClass="box" Width="95px" OnTextChanged="txtFechaFinal_TextChanged"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha1" runat="server" BehaviorID="_content_CalendarExtenderFechaFin" PopupButtonID="imgCalendarioFin" TargetControlID="txtFechaFinal" />
                                                                    <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFechaFinal" ErrorMessage="* Fecha Final" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Centro Contable:</td>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="DDLCentro_Contable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCentro_Contable_SelectedIndexChanged" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDLCentro_Contable" ErrorMessage="* Centro Contable" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Cuenta Contable:</td>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="DDLCuenta_Contable" runat="server" AutoPostBack="True" CssClass="select2" Font-Size="XX-Small" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLCuenta_Contable" ErrorMessage="* Cuenta Contable" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&#160;</td>
                                                                <td colspan="3">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">


                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td>
                                                                                <div class="panel panel-primary" style="width: 100%">
                                                                                    <div class="panel-heading">
                                                                                        <h3 class="panel-title">Quien Elaboró</h3>
                                                                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                                                    </div>
                                                                                    <div class="panel-body">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td class="auto-style45">Nombre:</td>
                                                                                                <td class="auto-style46">
                                                                                                    <asp:TextBox ID="txtElaboroNombre" runat="server" Width="100%" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtElaboroNombre" ErrorMessage="*Elaboro Nombre" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="auto-style45">Puesto:</td>
                                                                                                <td class="auto-style46">
                                                                                                    <asp:TextBox ID="txtElaboroPuesto" runat="server" Width="100%" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtElaboroPuesto" ErrorMessage="*Puesto Elaboro" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <div class="panel panel-primary" style="width: 100%;">
                                                                                    <div class="panel-heading">
                                                                                        <h3 class="panel-title">Visto Bueno</h3>
                                                                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                                                    </div>
                                                                                    <div class="panel-body">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td class="auto-style45">Nombre:</td>
                                                                                                <td class="auto-style46">
                                                                                                    <asp:TextBox ID="txtVB_Nombre" runat="server" Width="100%" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVB_Nombre" ErrorMessage="*Elaboro Nombre" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="auto-style45">Puesto:</td>
                                                                                                <td class="auto-style46">
                                                                                                    <asp:TextBox ID="txtVB_Puesto" runat="server" Width="100%" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtVB_Puesto" ErrorMessage="*Puesto Elaboro" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2"></td>
                                                                <td colspan="2">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel100" runat="server" HeaderText="TabPanel1">
                                            <HeaderTemplate>
                                                Detalle
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="auto-style32">&#160;</td>
                                                                <td class="auto-style33" colspan="3">
                                                                    <asp:DropDownList ID="ddlCtaCheques" runat="server" Visible="False" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">Tipo:</td>
                                                                <td class="auto-style33" colspan="3">
                                                                    <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" TabIndex="1">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTipo" ErrorMessage="* Tipo" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trowPoliza" runat="server" valign="top">
                                                                <td class="auto-style32" runat="server"># de Póliza:</td>
                                                                <td class="auto-style33" runat="server">
                                                                    <asp:TextBox ID="txtNumPoliza" runat="server" TabIndex="2" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style33" runat="server"></td>
                                                                <td colspan="2" runat="server">&#160;</td>
                                                            </tr>
                                                            <tr id="trowCheque" runat="server">
                                                                <td class="auto-style32" runat="server"># de Cheque:</td>
                                                                <td class="auto-style33" colspan="3" runat="server">
                                                                    <asp:TextBox ID="txtNumCheque" runat="server" TabIndex="3" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                </td>
                                                                <td runat="server">&nbsp;</td>
                                                            </tr>
                                                            <tr id="trowFecha" runat="server">
                                                                <td class="auto-style32" runat="server">Fecha:</td>
                                                                <td class="auto-style33" colspan="3" runat="server">
                                                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="box" Width="95px" TabIndex="4" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" BehaviorID="_content_CalendarExtenderFecha" PopupButtonID="imgCalendario" TargetControlID="txtFecha" />
                                                                    <asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFecha" ErrorMessage="* Fecha Inicial" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>

                                                                </td>
                                                                <td runat="server">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">Importe:</td>
                                                                <td class="auto-style33" colspan="3">
                                                                    <asp:TextBox ID="txtImporte" runat="server" TabIndex="5" onkeyup="mascara(this,'C');" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>

                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtImporte" ErrorMessage="* Importe" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">
                                                                    <asp:Label ID="lblConcepto" runat="server" Text="Concepto:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style33" colspan="3">
                                                                    <asp:TextBox ID="txtConcepto" runat="server" Width="100%" TabIndex="6" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">
                                                                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style33" colspan="3">
                                                                    <asp:TextBox ID="txtDescripcion" runat="server" Height="58px" TextMode="MultiLine" TabIndex="7" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:Button ID="bttnAgregar" runat="server" CssClass="btn btn-info" OnClick="bttnAgregar_Click" Text="Agregar" Font-Size="X-Small" ValidationGroup="Agregar" TabIndex="7" Style="height: 33px" SkinID="8" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:GridView ID="grdDetalle" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnRowDeleting="grdDetalle_RowDeleting" Width="100%" OnRowEditing="grdDetalle_RowEditing" OnRowUpdating="grdDetalle_RowUpdating" AllowPaging="True" OnRowCancelingEdit="grdDetalle_RowCancelingEdit">
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="CveTipo" ReadOnly="True">
                                                                                <ItemStyle Font-Bold="True" ForeColor="#3366CC" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="DescTipo" HeaderText="Descripción" ReadOnly="True">
                                                                                <ItemStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="True" />
                                                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" />
                                                                            <asp:BoundField DataField="Numero_Poliza" HeaderText="# Póliza" ReadOnly="True" />
                                                                            <asp:BoundField DataField="Numero_Cheque" HeaderText="# Cheque" ReadOnly="True" />
                                                                            <asp:TemplateField HeaderText="Importe">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtImporteAgr" runat="server" Text='<%# Bind("Importe") %>' onkeyup="mascara(this,'C2');"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblImporteAgr" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                                                                            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" ReadOnly="True" />
                                                                            <asp:CommandField ShowEditButton="True" />
                                                                            <asp:TemplateField ShowHeader="False">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar el registro?');" Text="Eliminar"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle CssClass="enc" />
                                                                        <HeaderStyle CssClass="enc" />
                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle CssClass="sel" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">&nbsp;</td>
                                                                <td class="auto-style33" colspan="3">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                    </ajaxToolkit:TabContainer>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="CAMPOS REQUERIDOS:" ValidationGroup="Guardar" Width="302px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="derecha">
                                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Text="Cancelar" />
                                    &nbsp;&nbsp;<asp:Button ID="btnGuardar_Continuar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Continuar_Click" Text="Guardar" ValidationGroup="Guardar" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </asp:View>
                </asp:MultiView>

                <%-- </ContentTemplate>

                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <script type="text/javascript">
        function Autocomplete() {
            $(".select2").select2();
        };
        function mascara(e, campo) {
            var Valor;
            if (campo == "C") {
                Valor = document.getElementById("ctl00_MainContent_TabContainer2_TabPanel100_txtImporte").value.toString().replace(/,/g, "");
                Valor = Valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                document.getElementById("ctl00_MainContent_TabContainer2_TabPanel100_txtImporte").value = Valor;
            }
            else {
                Valor = e.value.toString().replace(/,/g, "");
                Valor = Valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                e.value = Valor;
            }
        }
    </script>
</asp:Content>
