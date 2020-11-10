<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMPlantilla.aspx.cs" Inherits="SAF.Presupuesto.Form.FRMPlantilla" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 123px;
        }

        .auto-style5 {
            width: 100%;
        }

        .auto-style15 {
            width: 248px;
            hC: \Users\unach\Documents\Visual Studio 2015\Projects\DPP\SAF\Presupuesto\Form\FRMPlantilla.aspxeight: 66px;
        }

        .auto-style17 {
            margin-left: 0px;
        }

        .auto-style18 {
            width: 123px;
            height: 26px;
        }

        .auto-style19 {
            height: 26px;
        }

        .auto-style20 {
            height: 18px;
        }

        .auto-style34 {
            height: 66px;
        }
        .auto-style35 {
            text-align: center;
            height: 26px;
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
                &nbsp;
            </div>
            <table class="tabla_contenido">
                <tr>
                    <td>
                        <table class="auto-style5">
                            <tr>
                                <td class="auto-style18">DEPENDENCIA</td>
                                <td class="auto-style19">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="True" CssClass="auto-style17" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged" Width="80%">
                                            </asp:DropDownList>
                                            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Mover DPCIA" CssClass="btn" Visible="False" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">SEMESTRE</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLSemestre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSemestre_SelectedIndexChanged" Width="37%">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <table class="auto-style5">
                                            <tr>
                                                <td class="auto-style18">BUSCAR </td>
                                                <td class="auto-style15" colspan="2">
                                                    <asp:TextBox ID="TXTBuscar" runat="server" Width="406px" CssClass="textbuscar"></asp:TextBox>
                                                </td>
                                                <td class="auto-style34">
                                                    <asp:UpdatePanel ID="updBtns" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="BTNbuscar" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="BTNbuscar_Click" Width="45px" />
                                                            &nbsp; &nbsp;
                                                            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" ValidationGroup="Agregar" />
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="Agregar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style20" colspan="4">
                                                    <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblMsjCP" runat="server" Font-Size="Medium" Style="text-align: center" ForeColor="Red"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style20" colspan="4">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updBtns">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image30" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="GRDEmpledo" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="GRDEmpledo_PageIndexChanging" OnSelectedIndexChanged="GRDEmpledo_SelectedIndexChanged" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="ID" />
                                                            <asp:BoundField DataField="Id_Empleado" HeaderText="ID_EMPLEADO" />
                                                            <asp:BoundField DataField="PLAZA" HeaderText="PLAZA" />
                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                            <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                            <asp:CommandField SelectText="Plantilla" ShowSelectButton="True" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ForeColor="#006600">PostPlantilla</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Comparar</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel114" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lbt_otr" runat="server" OnClick="lbt_otr_Click" OnClientClick="return confirm('¿Desea agregar otro movimiento posterior ?');" ForeColor="#006600">Nuevo Posterior</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle CssClass="enc" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cuadro_botones" colspan="4">
                                                    <asp:ImageButton ID="imgBttnPDF" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnPDF_Click" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBttnExcel" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" title="Reporte Excel" OnClick="imgBttnExcel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        </caption>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;" class="TablaM">
                                            <tr>
                                                <td colspan="2">

                                                    <asp:ImageButton ID="atras" runat="server" ImageUrl="~/images/atras.png" title="Anterior" OnClick="atras_Click" Width="50px" />

                                                </td>
                                                <td class="derecha" colspan="2">
                                                    <asp:ImageButton ID="adelante" runat="server" ImageUrl="~/images/siguiente.png" title="Siguiente" OnClick="adelante_Click" Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label13" runat="server" Text="Nombre"></asp:Label>
                                                </td>
                                                <td style="width: 50%">
                                                    <asp:TextBox ID="txtNombre" runat="server" Width="80%" ValidationGroup="Guardar"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" ErrorMessage="Requerido" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label14" runat="server" Text="Plaza"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtPlaza" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>

                                                    <asp:Label ID="Label17" runat="server" Text="Fecha Ingreso"></asp:Label>

                                                </td>
                                                <td>&nbsp;<asp:TextBox ID="txtfecha_ingreso" runat="server" CssClass="box" Width="75px" onkeyup="javascript:this.value='';"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="txtfecha_ingreso_CalendarExtender" runat="server" PopupButtonID="imgCalendarioingreso" TargetControlID="txtfecha_ingreso" />
                                                    <asp:ImageButton ID="imgCalendarioingreso" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                                                </td>
                                                <td>
                                                    <asp:Label ID="Label47" runat="server" Text="RFC"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel119" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtRFC" runat="server" Width="100px"></asp:TextBox>
                                                            <asp:ImageButton ID="btnverD" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" Width="45px" OnClick="btnverD_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label45" runat="server" Text="Fecha inicio"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfecha_ini" runat="server" CssClass="box" onkeyup="javascript:this.value='';" Width="75px" ValidationGroup="Guardar"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderSol" runat="server" PopupButtonID="imgCalendarioini" TargetControlID="txtfecha_ini" />
                                                    <asp:ImageButton ID="imgCalendarioini" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfecha_ini" ErrorMessage="Requerido" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label46" runat="server" Text="Fecha Fin"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfecha_fin" runat="server" CssClass="box" onkeyup="javascript:this.value='';" Width="75px" ValidationGroup="Guardar"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="txtfecha_ini0_CalendarExtender" runat="server" PopupButtonID="imgCalendariofin" TargetControlID="txtfecha_fin" />
                                                    <asp:ImageButton ID="imgCalendariofin" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtfecha_fin" ErrorMessage="Requerido" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel1" runat="server">

                                                        <table style="width: 100%;" class="TablaM">
                                                            <tr>
                                                                <td class="centro" colspan="4"><strong>
                                                                    <asp:Label ID="Label4" runat="server" Text="PLANTILLA"></asp:Label>
                                                                </strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 25%">
                                                                    <asp:Label ID="Label6" runat="server" Text="Estatus:"></asp:Label>
                                                                </td>
                                                                <td style="width: 25%">
                                                                    <asp:DropDownList ID="DDLEstatus" runat="server" Enabled="False" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 25%">
                                                                    <asp:UpdatePanel ID="UpdatePanel106" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click1" Text="Cargas" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td style="width: 25%">
                                                                    <asp:UpdatePanel ID="UpdatePanel112" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="Button3" runat="server" CssClass="btn" Text="Descarga" OnClick="Button3_Click" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Categoría</td>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="txtCategoria" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label8" runat="server" Text="Frente a grupo"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCarga" type="number" step="any" runat="server" Width="107px">0</asp:TextBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style35" colspan="4"><strong>
                                                                    <asp:Label ID="Label12" runat="server" Text="Tipo de plaza"></asp:Label>
                                                                </strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server" Text="Interino"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInt" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label27" runat="server" Text="Temporal"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTem" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label26" runat="server" Text="Determinado"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDet" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label28" runat="server" Text="Definitivo"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDef" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Panel ID="Panel3" runat="server">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td>&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:GridView ID="GRDOtr" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnSelectedIndexChanged="GRDOtr_SelectedIndexChanged">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="CARGA ACADÉMICA" />
                                                                                                    <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:UpdatePanel ID="UpdatePanel109" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:LinkButton ID="LbEliminar" runat="server" OnClick="LbEliminar_Click">Eliminar</asp:LinkButton>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <FooterStyle CssClass="enc" />
                                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                                                                <SelectedRowStyle CssClass="sel" />
                                                                                                <HeaderStyle CssClass="enc" />
                                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                            </asp:GridView>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">

                                                                    <asp:GridView ID="GRDOtr2" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCARGA ACADÉMICA" />
                                                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:UpdatePanel ID="UpdatePanel115" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:LinkButton ID="LbEliminar2" runat="server" OnClick="LbEliminar2_Click">Eliminar</asp:LinkButton>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle CssClass="enc" />
                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                                        <SelectedRowStyle CssClass="sel" />
                                                                        <HeaderStyle CssClass="enc" />
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                    </asp:GridView>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">

                                                                    <asp:GridView ID="GRDOtr3" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="HORAS SIN CARG. NOMINA" />
                                                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:UpdatePanel ID="UpdatePanel116" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:LinkButton ID="LbEliminar3" runat="server" OnClick="LbEliminar3_Click">Eliminar</asp:LinkButton>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle CssClass="enc" />
                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                                        <SelectedRowStyle CssClass="sel" />
                                                                        <HeaderStyle CssClass="enc" />
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                    </asp:GridView>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Label ID="Label29" runat="server" Text="Codigo Prográmatico:"></asp:Label>
                                                                    <asp:TextBox ID="txtCodigo" runat="server" Width="250px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="Label30" runat="server" Text="Observaciones:"></asp:Label>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:TextBox ID="txtObservacion" runat="server" Height="58px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="Label31" runat="server" Text="Movimiento"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFec_mov" runat="server">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnMovimiento" runat="server" CssClass="btn" OnClick="btnMovimiento_Click" Text="Movimientos" ValidationGroup="Guardar" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="Label32" runat="server" Text="Oficio"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtOficio" runat="server">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                                <td>
                                                    <asp:Panel ID="Panel2" runat="server">
                                                        <table style="width: 100%;" class="TablaM">
                                                            <tr>
                                                                <td class="centro" colspan="4"><strong>
                                                                    <asp:Label ID="Label1" runat="server" Text="POSTPLANTILLA"></asp:Label>
                                                                </strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 25%">
                                                                    <asp:Label ID="Label2" runat="server" Text="Estatus"></asp:Label>
                                                                </td>
                                                                <td style="width: 25%">
                                                                    <asp:DropDownList ID="DDLEstatus01" runat="server" Enabled="False" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 25%">
                                                                    <asp:UpdatePanel ID="UpdatePanel107" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Cargas" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td style="width: 25%">
                                                                    <asp:UpdatePanel ID="UpdatePanel113" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="Button4" runat="server" CssClass="btn" Text="Descarga" OnClick="Button4_Click" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Categoría</td>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="txtCategoria01" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Frente a frupo"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCarga01" type="number" step="any" runat="server" Width="107px">0</asp:TextBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="centro" colspan="4"><strong>
                                                                    <asp:Label ID="Label7" runat="server" Text="Tipo de plaza"></asp:Label>
                                                                </strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label11" runat="server" Text="Interino"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInt01" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label33" runat="server" Text="Temporal"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTem01" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label16" runat="server" Text="Determinado"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDet01" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label35" runat="server" Text="Definitivo"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDef01" runat="server" type="number" step="any" Width="107px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Panel ID="Panel4" runat="server">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td>&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:GridView ID="GRDOtr01" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnSelectedIndexChanged="GRDOtr01_SelectedIndexChanged">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="CARGA ACADÉMICA" />
                                                                                                    <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:UpdatePanel ID="UpdatePanel110" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:LinkButton ID="LBEliminar01" runat="server" OnClick="LBEliminar01_Click">Eliminar</asp:LinkButton>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <FooterStyle CssClass="enc" />
                                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                                                                <SelectedRowStyle CssClass="sel" />
                                                                                                <HeaderStyle CssClass="enc" />
                                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                            </asp:GridView>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">

                                                                                    <asp:GridView ID="GRDOtr02" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnSelectedIndexChanged="GRDOtr01_SelectedIndexChanged" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCARGAACADÉMICA" />
                                                                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:UpdatePanel ID="UpdatePanel117" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:LinkButton ID="LBEliminar4" runat="server" OnClick="LBEliminar4_Click">Eliminar</asp:LinkButton>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <FooterStyle CssClass="enc" />
                                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                        <HeaderStyle CssClass="enc" />
                                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                                    </asp:GridView>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">

                                                                                    <asp:GridView ID="GRDOtr03" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnSelectedIndexChanged="GRDOtr01_SelectedIndexChanged" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="HORAS SIN CARG. NOMINA" />
                                                                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:UpdatePanel ID="UpdatePanel118" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:LinkButton ID="LBEliminar5" runat="server" OnClick="LBEliminar5_Click">Eliminar</asp:LinkButton>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <FooterStyle CssClass="enc" />
                                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                        <HeaderStyle CssClass="enc" />
                                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                                    </asp:GridView>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="Label38" runat="server" Text="Codigo Prográmatico"></asp:Label>
                                                                                    <asp:TextBox ID="txtCodigo01" runat="server" Width="250px">0</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="Label39" runat="server" Text="Observaciones"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:TextBox ID="txtObservacion01" runat="server" Height="58px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="Label40" runat="server" Text="Movimiento"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFec_mov01" runat="server">0</asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnMovimiento0" runat="server" CssClass="btn" OnClick="btnMovimiento_Click" Text="Movimientos" ValidationGroup="Guardar" />
                                                                </td>
                                                                <tr>
                                                                    <td colspan="2" class="auto-style19">
                                                                        <asp:Label ID="Label41" runat="server" Text="Oficio"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2" class="auto-style19">
                                                                        <asp:TextBox ID="txtOficio01" runat="server">0</asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>

                                                </td>
                                            </tr>

                                        </table>

                                        <table class="TablaM" style="width: 100%;">
                                            <tr>
                                                <td class="cuadro_botones" style="width: 100%">
                                                    <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnGuardar_continuar" runat="server" CssClass="btn" OnClick="btnGuardar_continuar_Click" Text="Guardar y Continuar" ValidationGroup="Guardar" />
                                                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="Guardar" />
                                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn2" OnClick="btnCancelar_Click" Text="Salir" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                &nbsp;
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel120" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="grdHistorico" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID_EMPLEADO" HeaderText="ID" />
                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                            <asp:BoundField DataField="TIPO_P" HeaderText="PERSONAL" />
                                                            <asp:BoundField DataField="PLAZA" HeaderText="PLAZA" />
                                                            <asp:BoundField DataField="STATUS" HeaderText="ESTATUS" />
                                                            <asp:BoundField DataField="RFC" HeaderText="RFC" />
                                                            <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                            <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />
                                                            <asp:BoundField DataField="FECHA_FIN" HeaderText="ULTIMO PAGO" />
                                                        </Columns>
                                                        <FooterStyle CssClass="enc" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" class="cuadro_botones">
                                                    <asp:Button ID="btnRegresar" runat="server" CssClass="btn2"  Text="Salir" OnClick="btnRegresar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View4" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%;">&nbsp;</td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel111" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlcarga_academica" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlcarga_academica_SelectedIndexChanged" Width="100%">
                                                                <asp:ListItem Value="17">Horas frente a grupo</asp:ListItem>
                                                                <asp:ListItem Value="1">Descarga academica</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label43" runat="server" Text="Concepto"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlOtr" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOtr_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label44" runat="server" Text="Horas"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCantidad" runat="server" step="any" type="number" Width="59px"></asp:TextBox>
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label49" runat="server" Text="Ligar a Un Docente" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel124" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlLigar_Docente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLigar_Docente_SelectedIndexChanged" Visible="False">
                                                                <asp:ListItem Value="0">Ligar a un Docente</asp:ListItem>
                                                                <asp:ListItem Value="1">No Aplica</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="Panel5" runat="server">
                                                        <asp:UpdatePanel ID="UpdatePanel121" runat="server">
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td style="width:20%;">
                                                                            <asp:Label ID="Label50" runat="server" Text="Dependencia"></asp:Label>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:DropDownList ID="DDLDependencia0" runat="server" AutoPostBack="True" CssClass="auto-style17"  Width="80%">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width:20%;">
                                                                            <asp:Label ID="Label48" runat="server" Text="Buscar"></asp:Label>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:UpdatePanel ID="UpdatePanel122" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="TXTBuscar0" runat="server" CssClass="textbuscar" Width="406px"></asp:TextBox>
                                                                                    <asp:ImageButton ID="BTNbuscar0" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="BTNbuscar0_Click" Width="45px" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:UpdatePanel ID="UpdatePanel123" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:GridView ID="GRDEmpledo0" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro."   Width="100%" OnPageIndexChanging="GRDEmpledo0_PageIndexChanging" OnSelectedIndexChanged="GRDEmpledo0_SelectedIndexChanged">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="Id" HeaderText="ID" />
                                                                                            <asp:BoundField DataField="Id_Empleado" HeaderText="ID_EMPLEADO" />
                                                                                            <asp:BoundField DataField="PLAZA" HeaderText="PLAZA" />
                                                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                                                            <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                                                            <asp:CommandField SelectText="Select" ShowSelectButton="True" />
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
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cuadro_botones" colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel108" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="Agrega_act" runat="server" CssClass="btn" OnClick="Agrega_act_Click" Text="Agregar" />
                                                            <asp:Button ID="cancelar_act" runat="server" CssClass="btn" OnClick="cancelar_act_Click" Text="Terminar" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel108">
                                                        <progresstemplate>
                                                            <asp:Image ID="Image31" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
                <tr>
                    <td>

                        <%-- Inicia PopUP --%>


                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
