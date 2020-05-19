<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMinistraciones_GC.aspx.cs" Inherits="SAF.Contabilidad.Form.frmMinistraciones_GC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="../../Scripts/select2/js/select2.min.js"></script>
    <link href="../../Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>


    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }

        .auto-style2 {
            width: 156px;
        }

        .auto-style4 {
            width: 136px;
            text-align: right;
        }

        .auto-style5 {
            width: 136px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                <asp:UpdateProgress ID="updProgInicio" runat="server"
                    AssociatedUpdatePanelID="updPnlInicio">
                    <ProgressTemplate>
                        <asp:Image ID="Image86" runat="server"
                            AlternateText="Espere un momento, por favor.." Height="50px"
                            ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="updPnlInicio" runat="server">
                    <ContentTemplate>
                        <table class="tabla_contenido">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">XLS</span>
                                        </div>
                                        <div class="custom-file">
                                            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" Height="40px" Width="100%" />
                                        </div>
                                        <div class="input-group-append">
                                            <asp:Button ID="bttnArchivo" runat="server" Text="Cargar Archivo" OnClick="Enviar_Click" CssClass="btn btn-secondary" OnClientClick="mostrar_spinner( )" ValidationGroup="XLS" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Archivo incorrecto, debe ser un XLS" ValidationExpression="(.*?)\.(xls|XLS|xlsx|XLSX)$" ValidationGroup="XLS"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Archivo XML" ControlToValidate="FileUpload1" Text="*" ValidationGroup="XLS"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>




                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                                            AssociatedUpdatePanelID="UpdatePanel1">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgProg2" runat="server"
                                                    AlternateText="Espere un momento, por favor.." Height="50px"
                                                    ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                    ToolTip="Espere un momento, por favor.." />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grvMinistracion" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" CssClass="mGrid" OnPageIndexChanging="grvMinistracion_PageIndexChanging" PageSize="20">
                                                    <Columns>
                                                        <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Mes" HeaderText="Mes">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Total" HeaderText="Total Registros">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="bttnGnrPolizas" runat="server" CssClass="btn btn-info" OnClick="bttnGnrPolizas_Click" Text="Generar Pólizas" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hddnGnrPolizas" runat="server" />
                                    <ajaxToolkit:ModalPopupExtender ID="modal" runat="server" PopupControlID="pnlGnrPolizas" TargetControlID="hddnGnrPolizas" BackgroundCssClass="modalBackground_Proy">
                                    </ajaxToolkit:ModalPopupExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlGnrPolizas" runat="server" CssClass="TituloModalPopupMsg">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style2">&nbsp;</td>
                                                <td class="auto-style4">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Centro Contable:</td>
                                                <td colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLCentro_Contable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCentro_Contable_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Cuenta Contable:</td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="DDLCuenta_Contable" runat="server" CssClass="select2" Font-Size="XX-Small" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1"># de Póliza:</td>
                                                <td class="auto-style2">
                                                    <asp:TextBox ID="txtNumPoliza" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="auto-style4">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Concepto:</td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtConcepto" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Fecha de Pago:</td>
                                                <td class="auto-style2">
                                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="box" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" BehaviorID="_content_CalendarExtenderFecha" PopupButtonID="imgCalendario" TargetControlID="txtFecha" />
                                                    <asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFecha" ErrorMessage="* Periodo Inicial" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="auto-style4">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
                                                <td class="auto-style5">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style2">&nbsp;</td>
                                                <td class="auto-style5">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="derecha" colspan="4">
                                                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Text="Cancelar" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnGenerar" runat="server" CssClass="btn btn-primary" OnClick="btnGenerar_Click" Text="Generar" ValidationGroup="Guardar" />
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style2">&nbsp;</td>
                                                <td class="auto-style5">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="bttnArchivo" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function Autocomplete() {
            $(".select2").select2();
        };
        </script>

</asp:Content>
