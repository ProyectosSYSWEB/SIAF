<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmInventario.aspx.cs" Inherits="SAF.Patrimonio.frmInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 29px;
        }

        .auto-style4 {
            height: 42px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" 
    Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 15%"></td>
                                <td style="width: 55%"></td>
                                <td style="width: 15%"></td>
                                <td style="width: 15%"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RFVDependencia" runat="server"
                                        ControlToValidate="DDLDependencia" ErrorMessage="*" Font-Bold="True"
                                        ValidationGroup="General"></asp:RequiredFieldValidator>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" CausesValidation="False" />
                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlFechas" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 15%"></td>
                                            <td style="width: 25%"></td>
                                            <td style="width: 45%"></td>
                                            <td style="width: 15%"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFecha_Ini" runat="server" Text="Período:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFecha_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecha_Ini" DaysModeTitleFormat="dd MMMM, yyyy"
                                                    Format="dd/MM/yyyy" PopupButtonID="imgCalendarioIni" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                <asp:Image ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />

                                            </td>
                                            <td >
                                                <asp:TextBox ID="txtFecha_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>
                                               <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"
                                                    TargetControlID="txtfecha_fin" DaysModeTitleFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" PopupButtonID="imgCalendarioFin" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                <asp:Image ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                    ControlToCompare="txtFecha_Ini" ControlToValidate="txtFecha_Fin"
                                                    ErrorMessage="*Período inválido" Font-Bold="True" Operator="GreaterThanEqual"
                                                    ValidationGroup="Buscar" Type="Date"></asp:CompareValidator>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEstatus" runat="server" Text="Status:" Width="80px"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="DDLStatus" runat="server" Width="75px">
                                                    <asp:ListItem Value="A">Alta</asp:ListItem>
                                                    <asp:ListItem Value="B">Baja</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtBuscar" runat="server" Width="95%" CssClass="textbuscar"
                                                            placeHolder="No. de inventario/Código contable/No. de serie/Descripción"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                    <ContentTemplate>
                                                        <asp:ImageButton ID="imgbtnBuscar" runat="server" Height="38px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png"
                                                            OnClick="imgbtnBuscar_Click" Width="39px" ValidationGroup="Buscar" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <table style="width: 100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 30%"></td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%"></td>
                            </tr>

                            <tr>
                                <td colspan="4" >
                                    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                                <ProgressTemplate>
                                    <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        Width="50px" AlternateText="Espere un momento, por favor.." ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                                    <%--<asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                <ProgressTemplate>
                                    <asp:Image ID="Image6" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        Width="50px" AlternateText="Espere un momento, por favor.." ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image4" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                Width="50px" AlternateText="Espere un momento, por favor.." ToolTip="Espere un momento, por favor.." />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:MultiView ID="MultiView1" runat="server">
                                    <asp:View ID="View1" runat="server">

                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvInventario" runat="server" EmptyDataText="No hay registros para mostrar" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderStyle="None" BorderWidth="1px" GridLines="Vertical" OnPageIndexChanging="grvInventario_PageIndexChanging"
                                                        Width="100%" OnSelectedIndexChanged="grvInventario_SelectedIndexChanged" OnRowDeleting="grvInventario_RowDeleting" CssClass="mGrid" PageSize="20">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id"></asp:BoundField>
                                                            <asp:BoundField DataField="Centro_Contable" HeaderText="CENTRO CONTABLE">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="No_Inventario" HeaderText="# INVENTARIO">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Clave" HeaderText="CLAVE">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN" />
                                                            <asp:BoundField DataField="Codigo_Contable" HeaderText="CÓDIGO CONTABLE">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Fecha_Alta_Str" HeaderText="FECHA ALTA">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Fecha_Baja_Str" HeaderText="FECHA BAJA">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Costo" HeaderText="COSTO" DataFormatString="{0:c}">
                                                                <ItemStyle HorizontalAlign="left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Formulario" />
                                                            <asp:BoundField DataField="Validado" />
                                                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                            <asp:CommandField DeleteText="Imprimir" ShowDeleteButton="True"></asp:CommandField>
                                                            <asp:TemplateField HeaderText="Validado">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk_validado" runat="server" AutoPostBack="True" Checked='<%# Bind("Validado") %>' OnCheckedChanged="chk_validado_CheckedChanged" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="linkBttnExcel" runat="server" OnClick="linkBttnEliminar_Click" OnClientClick="return confirm('¿Desea Eliminar este No. de Inventario?');">Eliminar</asp:LinkButton>
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
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center"></td>
                                            </tr>

                                            <tr>

                                                <td class="cuadro_botones">

                                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"
                                                        Width="49px" OnClick="imgBttnPdf" />
                                                    <asp:ImageButton ID="ImageButton3" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                        Width="49px" OnClick="imgBttnExcel" />

                                                </td>

                                            </tr>
                                        </table>

                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 20%"></td>
                                                <td style="width: 30%"></td>
                                                <td style="width: 20%"></td>
                                                <td style="width: 30%"></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblInventario" runat="server" Text="No. Inventario:"></asp:Label>
                                                </td>
                                                <td align="left" class="style8">
                                                    <asp:TextBox ID="txtInventario" runat="server" BorderStyle="None"
                                                        Enabled="False" Font-Underline="True" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenCentro_Contable" runat="server" />
                                                    <asp:HiddenField ID="HiddenFecha_Alta" runat="server" />
                                                    <asp:HiddenField ID="HiddenEjercicio" runat="server" />
                                                    <asp:HiddenField ID="HiddenFechaReclasificacion" runat="server" />
                                                    <asp:HiddenField ID="HiddenCedula" runat="server" />
                                                    <asp:HiddenField ID="HiddenClave_Bien" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFecha_Alta" runat="server" Text="Fecha Alta:"></asp:Label>
                                                </td>
                                                <td>
                                                    <%--  <asp:TextBox ID="txtFecha_Alta" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';"
                                                Width="95px" OnTextChanged="txtFecha_Alta_TextChanged"></asp:TextBox>--%>
                                                    <%--<img alt="Ver calendario" onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );"
                                                src="../../Adquisiciones/images/Calendar_scheduleHS.png" style="cursor: pointer" />--%>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtFecha_Alta" runat="server" AutoPostBack="True" CssClass="box" onkeyup="VerificaFechas();"
                                                                Width="100px" OnTextChanged="txtFecha_Alta_TextChanged"></asp:TextBox>

                                                            <ajaxToolkit:CalendarExtender ID="Calendario_FechaAlta" runat="server" TargetControlID="txtFecha_Alta" DaysModeTitleFormat="dd MMMM, yyyy"
                                                                Format="dd/MM/yyyy" PopupButtonID="Calendario_FecAlta" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                            <asp:Image ID="Calendario_FecAlta" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                            <asp:RequiredFieldValidator ID="RFVFecha_Alta" runat="server" ControlToValidate="txtFecha_Alta"
                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="General"
                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="style8">
                                                    <asp:Label ID="lblFechaContable" runat="server" Text="Fecha Contable:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFecha_Contable" runat="server" CssClass="box"
                                                        Width="100px" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label3" runat="server" Text="Tipo Alta:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLTipo_Alta" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLTipo_Alta_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:RequiredFieldValidator ID="RFVTipo_Alta" runat="server"
                                                        ControlToValidate="DDLTipo_Alta" ErrorMessage="*" Font-Bold="True"
                                                        ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>

                                                <td align="left" class="style8">
                                                    <asp:Label ID="Label52" runat="server" Text="Clasificación:"></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="DDLClasificacion" runat="server"  Width="300px" OnSelectedIndexChanged="DDLClasificacion_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label14" runat="server" Text="Póliza No.:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLPoliza" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DDLPoliza_SelectedIndexChanged" Width="300px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:RequiredFieldValidator ID="RFVPoliza" runat="server"
                                                        ControlToValidate="DDLPoliza" ErrorMessage="*" Font-Bold="True"
                                                        ValidationGroup="General" InitialValue="La opción no contiene datos"></asp:RequiredFieldValidator>

                                                </td>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label16" runat="server" Text="Código Contable:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLContab" runat="server" Width="300px" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DDLContab_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:RequiredFieldValidator ID="RFVContab" runat="server"
                                                        ControlToValidate="DDLContab" ErrorMessage="*" Font-Bold="True"
                                                        ValidationGroup="General" InitialValue="La opción no contiene datos"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblClave" runat="server" Text="Clave:"></asp:Label>
                                                </td>
                                                <td  colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLClave" runat="server" Width="800px"
                                                                AutoPostBack="True" OnSelectedIndexChanged="DDLClave_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RFVClave" runat="server"
                                                                ControlToValidate="DDLClave" ErrorMessage="*" Font-Bold="True"
                                                                ValidationGroup="General" InitialValue="La opción no contiene datos"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </td>
                                                </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label53" runat="server" Text="SubClase:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DDLSubClase" runat="server" Width="300px" Enabled="False"></asp:DropDownList>
                                                </td>
                                                   <td>
                                                        <asp:Label ID="lblCedula" runat="server" Text="Cédula No.:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLCedula" runat="server" Height="16px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLCedula_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFVCedula" runat="server" ControlToValidate="DDLCedula" ErrorMessage="*" InitialValue="La opción no contiene datos" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                       
                                        <asp:Panel ID="pnlTransferencia" Visible="true" runat="server">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label89" runat="server" Text="No. Inv. Anterior:"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtInv_Anterior" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFVInv_Anterior" runat="server" ControlToValidate="txtInv_Anterior" ErrorMessage="*" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="left">
                                                        <asp:Label ID="Label90" runat="server" Text="V.T.:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVolante_Transferencia" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFVVolante" runat="server" ControlToValidate="txtVolante_Transferencia" ErrorMessage="*" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label17" runat="server" Text="Fecha Alta Anterior:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAlta_Anterior" runat="server" CssClass="box"></asp:TextBox>
                                                        <asp:Image runat="server" ID="imgCalendarioAltaAnterior"
                                                            ImageUrl="../../Adquisiciones/images/Calendar_scheduleHS.png"></asp:Image>
                                                        <ajaxToolkit:CalendarExtender ID="imgCalendarioAnterior" runat="server"
                                                            TargetControlID="txtAlta_Anterior" DaysModeTitleFormat="dd MMMM, yyyy"
                                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioAltaAnterior"
                                                            TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RFVAlta_Anterior" runat="server" ControlToValidate="txtAlta_Anterior" ErrorMessage="*" ValidationGroup="General" Font-Bold="True"></asp:RequiredFieldValidator>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label91" runat="server" Text="Procedencia:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProcedencia" runat="server" Width="300px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFVProcedencia" runat="server" ControlToValidate="txtProcedencia" ErrorMessage="*" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                           
                                        </asp:Panel>
                                      
                                           
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblProyecto" runat="server" Text="Proyecto:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="DDLProyecto" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVProyecto" runat="server" ControlToValidate="DDLProyecto" ErrorMessage="*" InitialValue="La opción no contiene datos" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFuente" runat="server" Text="Fuente Financ.:"></asp:Label>
                                                </td>
                                                <td class="auto-style3">
                                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVFuenteF" runat="server" ControlToValidate="DDLFuente" ErrorMessage="*" InitialValue="La opción no contiene datos" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label1" runat="server" Text="Cantidad:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLCantidad" runat="server" Enabled="False" Width="50px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="lblCentroTrabajo" runat="server" Text="Centro Trabajo:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="DDLCentroTrabajo" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVCentro_Trabajo" runat="server" ControlToValidate="DDLCentroTrabajo" ErrorMessage="*" Font-Bold="True" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label8" runat="server" Text="Responsable:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="DDLResponsable" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVResponsable" runat="server" ControlToValidate="DDLResponsable" ErrorMessage="*" Font-Bold="True" InitialValue="0000" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label9" runat="server" Text="Corresponsable:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtCorresponsable" runat="server" Width="300px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style4" >
                                                    <asp:Label ID="Label10" runat="server" Text="Proveedor:"></asp:Label>
                                                </td>
                                                <td class="auto-style4" ><%--<asp:DropDownList ID="DDLProveedor" runat="server" Width="300px">
                                            </asp:DropDownList>--%>
                                                    <asp:TextBox ID="txtProveedor" runat="server" Width="300px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVProveedor" runat="server" ControlToValidate="txtProveedor" ErrorMessage="*" Font-Bold="True" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="auto-style4" >
                                                    <asp:Label ID="Label11" runat="server" Text="Folio Factura:"></asp:Label>
                                                </td>
                                                <td class="auto-style4" >
                                                    <asp:TextBox ID="txtFolio_Factura" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVFolio_Factura" runat="server" ControlToValidate="txtFolio_Factura" ErrorMessage="*" Font-Bold="True" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label12" runat="server" Text="Fecha Factura:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtFecha_Factura" runat="server" AutoPostBack="False" CssClass="box" Width="100px"></asp:TextBox>
                                                    <asp:Image ID="imgCalendario" runat="server" ImageUrl="../../Adquisiciones/images/Calendar_scheduleHS.png" />
                                                    <ajaxToolkit:CalendarExtender ID="Calendario" runat="server" DaysModeTitleFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" PopupButtonID="imgCalendario" TargetControlID="txtFecha_Factura" TodaysDateFormat="dd MMMM, yyyy" />
                                                    <asp:RequiredFieldValidator ID="RFVFecha_Factura" runat="server" ControlToValidate="txtFecha_Factura" ErrorMessage="*" Font-Bold="True" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label13" runat="server" Text="Costo:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtCosto" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVCosto" runat="server" ControlToValidate="txtCosto" ErrorMessage="*" Font-Bold="True" InitialValue="0.00" ValidationGroup="General"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="REVCsoto" runat="server" ControlToValidate="txtCosto" SetFocusOnError="True" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$" ValidationGroup="Detalle">*Formato (999,999,999.99)</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="linkBtnComponentes" runat="server" OnClick="linkBtnComponentes_Click" Visible="False">0 componente(s) agregado(s) en el conjunto</asp:LinkButton>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            </caption>
                                        </table>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:TabContainer ID="TabContBienes" runat="server" ActiveTabIndex="0" CssClass="ajax__myTab"
                                                        Width="100%">
                                                        <ajaxToolkit:TabPanel ID="TabMuebles" runat="server" HeaderText="TabPanel1">
                                                            <HeaderTemplate>
                                                                Muebles
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td align="left" width="25%"></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="lblCaracteristicas" runat="server" Text="Características:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtM_Caracteristicas" runat="server" Width="500px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVM_Caracteristicas" runat="server" ControlToValidate="txtM_Caracteristicas"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Muebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtM_Marca" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVM_Marca" runat="server" ControlToValidate="txtM_Marca"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Muebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtM_Modelo" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVM_Modelo" runat="server" ControlToValidate="txtM_Modelo"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Muebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label18" runat="server" Text="No. de Serie:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtM_Serie" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVM_Serie" runat="server"
                                                                                ControlToValidate="txtM_Serie" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Muebles"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label19" runat="server" Text="Color:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtM_Color" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVM_Color" runat="server"
                                                                                ControlToValidate="txtM_Color" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Muebles"></asp:RequiredFieldValidator>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabInmuebles" runat="server">
                                                            <HeaderTemplate>
                                                                Inmuebles
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td align="left" width="15%"></td>
                                                                        <td></td>
                                                                        <td width="10%"></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label21" runat="server" Text="Dirección:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_Direccion" runat="server" Width="400px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_Direccion" runat="server" ControlToValidate="txtINM_Direccion"
                                                                                ErrorMessage="*" ValidationGroup="Inmuebles"
                                                                                Font-Bold="True"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label26" runat="server" Text="Ciudad:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_Ciudad" runat="server" Width="350px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_Ciudad" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Inmuebles"
                                                                                ControlToValidate="txtINM_Ciudad"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center" class="style8">
                                                                            <asp:Label ID="Label27" runat="server" Text="Datos del Documento" BackColor="Silver" Font-Bold="True"></asp:Label>
                                                                        </td>
                                                                        <td colspan="2" align="center" class="style8">
                                                                            <asp:Label ID="Label32" runat="server" Text="Avalúo" BackColor="#CCCCCC" Font-Bold="True"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label22" runat="server" Text="Tipo:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_TipoDoc" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_TipoDoc" runat="server" ControlToValidate="txtINM_TipoDoc"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Inmuebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label30" runat="server" Text="Terreno:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtINM_Terreno" runat="server" Width="100px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVInm_Terreno" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Inmuebles"
                                                                                ControlToValidate="txtINM_Terreno"></asp:RequiredFieldValidator>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label23" runat="server" Text="Número:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_NumeroDoc" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_NumeroDoc" runat="server" ControlToValidate="txtINM_NumeroDoc"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Inmuebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label31" runat="server" Text="Edificio:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_Edificio" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_Edificio" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Inmuebles"
                                                                                ControlToValidate="txtINM_Edificio"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label24" runat="server" Text="Estatus:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_EstatusDoc" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_EstatusDoc" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Inmuebles"
                                                                                ControlToValidate="txtINM_EstatusDoc"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label33" runat="server" Text="Fecha:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_FechaAvaluo" runat="server"
                                                                                CssClass="box" Width="100px"></asp:TextBox>

                                                                            <asp:Image runat="server" ID="ImgINM_FechaAvaluo"
                                                                                ImageUrl="../../Adquisiciones/images/Calendar_scheduleHS.png"></asp:Image>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarINM_FechaAvaluo" runat="server"
                                                                                TargetControlID="txtINM_FechaAvaluo" DaysModeTitleFormat="dd MMMM, yyyy"
                                                                                Format="dd/MM/yyyy" PopupButtonID="ImgINM_FechaAvaluo"
                                                                                TodaysDateFormat="dd MMMM, yyyy" BehaviorID="_content_CalendarINM_FechaAvaluo"></ajaxToolkit:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_FechaAvaluo" runat="server" ControlToValidate="txtINM_FechaAvaluo"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Inmuebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label25" runat="server" Text="Fecha:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_FechaDoc" runat="server"
                                                                                CssClass="box" Width="100px"></asp:TextBox>

                                                                            <asp:Image runat="server" ID="ImgINM_FechaDoc"
                                                                                ImageUrl="../../Adquisiciones/images/Calendar_scheduleHS.png"></asp:Image>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarINM_FechaDoc" runat="server"
                                                                                TargetControlID="txtINM_FechaDoc" DaysModeTitleFormat="dd MMMM, yyyy"
                                                                                Format="dd/MM/yyyy" PopupButtonID="ImgINM_FechaDoc"
                                                                                TodaysDateFormat="dd MMMM, yyyy" BehaviorID="_content_CalendarINM_FechaDoc"></ajaxToolkit:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_FechaDoc" runat="server" ControlToValidate="txtINM_FechaDoc"
                                                                                ErrorMessage="*" ValidationGroup="Inmuebles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label28" runat="server" Text="Lugar de Expedición:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_LugarExpedicionDoc" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_Lugar" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Inmuebles"
                                                                                ControlToValidate="txtINM_LugarExpedicionDoc"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label29" runat="server" Text="Notaria Pública:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtINM_Notaria" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInm_Notaria" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Inmuebles"
                                                                                ControlToValidate="txtINM_Notaria"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabVehiculos" runat="server">
                                                            <HeaderTemplate>
                                                                Vehículos y Tractores
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td align="left" width="10%"></td>
                                                                        <td width="40%"></td>
                                                                        <td width="20%"></td>
                                                                        <td width="30%"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label34" runat="server" Text="Características:"></asp:Label>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="txtVEH_Caracteristicas" runat="server" Width="500px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Caracteristicas" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Vehiculos"
                                                                                Font-Bold="True" ControlToValidate="txtVEH_Caracteristicas">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label35" runat="server" Text="No. de Serie:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Serie" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Serie" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Vehiculos"
                                                                                ControlToValidate="txtVEH_Serie"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                         <td align="left" class="style8">
                                                                            <asp:Label ID="Label39" runat="server" Text="No. de Motor:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtVEH_Motor" runat="server" Width="200px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Motor" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Vehiculos"
                                                                                ControlToValidate="txtVEH_Motor"></asp:RequiredFieldValidator>

                                                                        </td>
                                                                       </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label38" runat="server" Text="Marca:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Marca" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Marca" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Vehiculos"
                                                                                Font-Bold="True" ControlToValidate="txtVEH_Marca">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label41" runat="server" Text="No. de Placas:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Placas" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Placas" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Vehiculos"
                                                                                ControlToValidate="txtVEH_Placas"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label40" runat="server" Text="Modelo:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Modelo" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Modelo" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Vehiculos"
                                                                                Font-Bold="True" ControlToValidate="txtVEH_Modelo">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                       <td align="left" style="margin-left: 40px" class="style8">
                                                                            <asp:Label ID="Label36" runat="server" Text="Pago de Tenencia:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Tenencia" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Tenencia" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Vehiculos"
                                                                                ControlToValidate="txtVEH_Tenencia"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label42" runat="server" Text="Año:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Año" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Año" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Vehiculos"
                                                                                ControlToValidate="txtVEH_Año"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label37" runat="server" Text="Póliza de Seguro:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Poliza" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Poliza" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Vehiculos"
                                                                                ControlToValidate="txtVEH_Poliza"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label44" runat="server" Text="Color:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtVEH_Color" runat="server" AutoPostBack="True" CssClass="box"
                                                                                Width="200px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Color" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Vehiculos"
                                                                                Font-Bold="True" ControlToValidate="txtVEH_Color">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                         <td align="left" class="style8">
                                                                            <asp:Label ID="Label43" runat="server" Text="Vencimiento del Seguro:"></asp:Label>
                                                                        </td>
                                                                         <td>
                                                                            <asp:TextBox ID="txtVEH_Seguro" runat="server"
                                                                                CssClass="box" onkeyup="javascript:this.value='';"
                                                                                Width="100px"></asp:TextBox>
                                                                            <img alt="Ver calendario" onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );"
                                                                                src="../../Adquisiciones/images/Calendar_scheduleHS.png" style="cursor: pointer" />
                                                                            <asp:RequiredFieldValidator ID="RFVVeh_Seguro" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Vehiculos"
                                                                                Font-Bold="True" ControlToValidate="txtVEH_Seguro"></asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td colspan="4"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabTic" runat="server">
                                                            <HeaderTemplate>
                                                                TIC
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td align="left" width="15%"></td>
                                                                        <td colspan="3"></td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label45" runat="server" Text="Características:"></asp:Label>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="txtTIC_Caracteristicas" runat="server" Width="600px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_Caracteristicas" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="TIC"
                                                                                Font-Bold="True" ControlToValidate="txtTIC_Caracteristicas">*</asp:RequiredFieldValidator>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label47" runat="server" Text="Marca:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTIC_Marca" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_Marca" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="TIC"
                                                                                Font-Bold="True" ControlToValidate="txtTIC_Marca">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label46" runat="server" Text="Procesador:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTIC_Procesador" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_Procesador" runat="server"
                                                                                ControlToValidate="txtTIC_Procesador" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="TIC"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label49" runat="server" Text="Modelo:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTIC_Modelo" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_Modelo" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="TIC"
                                                                                Font-Bold="True" ControlToValidate="txtTIC_Modelo">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label50" runat="server" Text="Disco Duro:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTIC_DiscoDuro" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_DiscoDuro" runat="server"
                                                                                ControlToValidate="txtTIC_DiscoDuro" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="TIC"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label51" runat="server" Text="No. de Serie:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTIC_Serie" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_Serie" runat="server"
                                                                                ControlToValidate="txtTIC_Serie" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="TIC"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label48" runat="server" Text="RAM:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtTIC_RAM" runat="server" Width="200px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVTic_Ram" runat="server"
                                                                                ControlToValidate="txtTIC_RAM" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="TIC"></asp:RequiredFieldValidator>

                                                                        </td>
                                                                        <%-- <td align="left"  class="style8" >
                                                                    <asp:Label ID="Label52" runat="server" Text="Unidad de Disquete:"></asp:Label>
                                                                </td>
                                                                <td >
                                                                    <asp:TextBox ID="txtTIC_Disquete" runat="server" Width="150px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVTic_Disquete" runat="server" 
                                                                        ControlToValidate="txtTIC_Disquete" ErrorMessage="*" Font-Bold="True" 
                                                                        ValidationGroup="TIC"></asp:RequiredFieldValidator>
                                                                </td>--%>
                                                                    </tr>
                                                                    <%--<tr>
                                                                <td align="left"  class="style8" >
                                                                    <asp:Label ID="Label53" runat="server" Text="Sistema Operativo:"></asp:Label>
                                                                </td>
                                                                <td >
                                                                    <asp:TextBox ID="txtTIC_SO" runat="server" CssClass="box" 
                                                Width="200px"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RFVTic_SO" runat="server"
                                                ErrorMessage="*" ValidationGroup="TIC" 
                                                Font-Bold="True" ControlToValidate="txtTIC_SO">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left"  class="style8" >
                                                                    <asp:Label ID="Label54" runat="server" Text="Unidad Óptica:"></asp:Label>
                                                                </td>
                                                                <td >
                                                                    <asp:TextBox ID="txtTIC_UnidadOptica" runat="server" Width="150px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVTic_UnidadOptica" runat="server" 
                                                                        ControlToValidate="txtTIC_UnidadOptica" ErrorMessage="*" Font-Bold="True" 
                                                                        ValidationGroup="TIC"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>--%>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label55" runat="server" Text="Accesorios:"></asp:Label>
                                                                        </td>

                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="txtTIC_Accesorios" runat="server" CssClass="box"
                                                                                Width="600px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVTic_Accesorios" runat="server"
                                                                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Poliza"
                                                                                Font-Bold="True" ControlToValidate="txtTIC_Accesorios">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabEquipos" runat="server" HeaderText="TabPanel1">
                                                            <HeaderTemplate>
                                                                Equipos y Aparatos
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td width="10%"></td>
                                                                        <td></td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label56" runat="server" Text="Características:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEquipo_Caracteristicas" runat="server" Width="500px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVEquipo_Caracteristicas" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Equipos"
                                                                                Font-Bold="True" ControlToValidate="txtEquipo_Caracteristicas">*</asp:RequiredFieldValidator>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label57" runat="server" Text="Marca:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEquipo_Marca" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVEquipo_Marca" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Equipos"
                                                                                Font-Bold="True" ControlToValidate="txtEquipo_Marca">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label58" runat="server" Text="Modelo:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEquipo_Modelo" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVEquipo_Modelo" runat="server" ControlToValidate="txtEquipo_Modelo"
                                                                                ErrorMessage="*" ValidationGroup="Equipos"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label59" runat="server" Text="No. de Serie:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEquipo_Serie" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVEquipo_Serie" runat="server"
                                                                                ControlToValidate="txtEquipo_Serie" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Equipos"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label60" runat="server" Text="Color:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEquipo_Color" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVEquipo_Color" runat="server"
                                                                                ControlToValidate="txtEquipo_Color" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Equipos"></asp:RequiredFieldValidator>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabBiologicos" runat="server">
                                                            <HeaderTemplate>
                                                                Activos Biológicos
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td align="left" width="15%"></td>
                                                                        <td></td>
                                                                        <td width="15%"></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label61" runat="server" Text="Raza:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Raza" runat="server" Width="250px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVSem_Raza" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Semovientes"
                                                                                Font-Bold="True" ControlToValidate="txtSem_Raza">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label62" runat="server" Text="Color:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Color" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVSem_Color" runat="server"
                                                                                ControlToValidate="txtSem_Color" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Semovientes"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label63" runat="server" Text="No. de Arete:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Arete" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVSem_Arete" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Semovientes"
                                                                                Font-Bold="True" ControlToValidate="txtSem_Arete">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label64" runat="server" Text="Peso:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtSem_Peso" runat="server" Width="200px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVSem_Peso" runat="server"
                                                                                ControlToValidate="txtSem_Peso" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Semovientes"></asp:RequiredFieldValidator>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label65" runat="server" Text="Edad:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Edad" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVSem_Edad" runat="server" ControlToValidate="txtSem_Edad"
                                                                                ErrorMessage="*" ValidationGroup="Semovientes"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label66" runat="server" Text="Costo Revalorizado:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Revalorizado" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVSem_Revalorizado" runat="server"
                                                                                ControlToValidate="txtSem_Revalorizado" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Semovientes"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label67" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Nac" runat="server" Width="100px"></asp:TextBox>
                                                                            <img alt="Ver calendario" onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );"
                                                                                src="../../Adquisiciones/images/Calendar_scheduleHS.png" style="cursor: pointer" />
                                                                            <asp:RequiredFieldValidator ID="RFVSem_Nacimiento" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Semovientes"
                                                                                Font-Bold="True" ControlToValidate="txtSem_Nac">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label71" runat="server" Text="Fecha Revalorizado:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSem_Fecha" runat="server"
                                                                                CssClass="box" onkeyup="javascript:this.value='';"
                                                                                Width="100px"></asp:TextBox>
                                                                            <img alt="Ver calendario" onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );"
                                                                                src="../../Adquisiciones/images/Calendar_scheduleHS.png" style="cursor: pointer" />
                                                                            &#160;<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtSem_Fecha"
                                                                                ErrorMessage="*" ValidationGroup="Semovientes"
                                                                                Font-Bold="True"></asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label69" runat="server" Text="Sexo:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:DropDownList ID="DDLSexo" runat="server" Width="100px">
                                                                                <asp:ListItem Value="HEMBRA">HEMBRA</asp:ListItem>
                                                                                <asp:ListItem Value="MACHO">MACHO</asp:ListItem>
                                                                                <asp:ListItem Value="NO">NO ESPECIFICADO</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                            <asp:RequiredFieldValidator ID="RFVSem_Sexo" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Semovientes"
                                                                                Font-Bold="True" ControlToValidate="DDLSexo"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8"></td>
                                                                        <td width="25%"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabIntangibles" runat="server">
                                                            <HeaderTemplate>
                                                                Intangibles
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td width="10%"></td>
                                                                        <td></td>
                                                                        <td width="10%"></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label68" runat="server" Text="Características:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Caracteristicas" runat="server" Width="450px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Caracteristicas" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Intangibles"
                                                                                Font-Bold="True" ControlToValidate="txtInt_Caracteristicas">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label70" runat="server" Text="Caducidad de Licencia:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Caducidad" runat="server" Width="150px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Caducidad" runat="server"
                                                                                ControlToValidate="txtInt_Caducidad" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Intangibles"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label72" runat="server" Text="Tipo de Software:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Software" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Software" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Intangibles"
                                                                                Font-Bold="True" ControlToValidate="txtInt_Software">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label73" runat="server" Text="Usuarios:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtInt_Usuarios" runat="server" Width="150px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVInt_Usuarios" runat="server"
                                                                                ControlToValidate="txtInt_Usuarios" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Intangibles"></asp:RequiredFieldValidator>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label74" runat="server" Text="Marca Registrada:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Marca" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Marca" runat="server" ControlToValidate="txtInt_Marca"
                                                                                ErrorMessage="*" ValidationGroup="Intangibles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label75" runat="server" Text="Capacidad en Disco:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Capacidad" runat="server" Width="150px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Capacidad" runat="server"
                                                                                ControlToValidate="txtInt_Capacidad" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Intangibles"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label76" runat="server" Text="Patente:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Patente" runat="server" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Patente" runat="server"
                                                                                ControlToValidate="txtInt_Patente" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Intangibles"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label77" runat="server" Text="Versión:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Version" runat="server" Width="150px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Version" runat="server"
                                                                                ControlToValidate="txtInt_Version" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Intangibles"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label78" runat="server" Text="Derecho de Autor:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInt_Derecho" runat="server" AutoPostBack="True" CssClass="box"
                                                                                Width="200px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVInt_Derecho" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Intangibles"
                                                                                Font-Bold="True" ControlToValidate="txtInt_Derecho">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" style="margin-left: 40px" class="style8" width="25%">
                                                                            <asp:Label ID="Label79" runat="server" Text="Idioma:"></asp:Label>
                                                                        </td>
                                                                        <td width="25%">
                                                                            <asp:TextBox ID="txtInt_Idioma" runat="server" Width="150px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_Idioma" runat="server"
                                                                                ControlToValidate="txtInt_Idioma" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Intangibles"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="margin-left: 40px" class="style8" width="25%"></td>

                                                                        <td width="25%"></td>
                                                                        <td align="left" style="margin-left: 40px" class="style8" width="25%">
                                                                            <asp:Label ID="Label80" runat="server" Text="Sistemas Operativos Soportados:"></asp:Label>
                                                                        </td>
                                                                        <td width="25%">
                                                                            <asp:TextBox ID="txtInt_SO" runat="server" AutoPostBack="True" CssClass="box"
                                                                                Width="250px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVInt_SO" runat="server" ControlToValidate="txtInt_SO"
                                                                                ErrorMessage="*" ValidationGroup="Intangibles"
                                                                                Font-Bold="True">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabColecciones" runat="server">
                                                            <HeaderTemplate>
                                                                Colecciones
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td align="left" width="10%"></td>
                                                                        <td></td>
                                                                        <td width="10%"></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label81" runat="server" Text="Descripción:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCol_Descripcion" runat="server" Width="500px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVCol_Descripcion" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Colecciones"
                                                                                Font-Bold="True" ControlToValidate="txtCol_Descripcion">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label82" runat="server" Text="Tomos:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCol_Tomos" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVCol_Tomos" runat="server" ErrorMessage="*"
                                                                                Font-Bold="True" ValidationGroup="Colecciones"
                                                                                ControlToValidate="txtCol_Tomos"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label83" runat="server" Text="Título:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCol_Titulo" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVCol_Titulo" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Colecciones"
                                                                                Font-Bold="True" ControlToValidate="txtCol_Titulo">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label84" runat="server" Text="Edición:"></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtCol_Edicion" runat="server" Width="300px"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RFVCol_Edicion" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Colecciones"
                                                                                ControlToValidate="txtCol_Edicion"></asp:RequiredFieldValidator>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label85" runat="server" Text="Autor:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCol_Autor" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVCol_Autor" runat="server"
                                                                                ErrorMessage="*" ValidationGroup="Colecciones"
                                                                                Font-Bold="True" ControlToValidate="txtCol_Autor">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label86" runat="server" Text="ISBN:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCol_ISBN" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVCol_ISBN" runat="server"
                                                                                ErrorMessage="*" Font-Bold="True" ValidationGroup="Colecciones"
                                                                                ControlToValidate="txtCol_ISBN"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style8">
                                                                            <asp:Label ID="Label87" runat="server" Text="Editorial:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCol_Editorial" runat="server" Width="300px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RFVCol_Editorial" runat="server"
                                                                                ControlToValidate="txtCol_Editorial" ErrorMessage="*" Font-Bold="True"
                                                                                ValidationGroup="Colecciones"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left" class="style8"></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4"></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                    </ajaxToolkit:TabContainer>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-left: 40px" class="style8" align="left" valign="top">
                                                    <asp:Label ID="Label20" runat="server" Text="Observaciones:"></asp:Label>
                                                    <asp:TextBox ID="txtObservaciones" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:CheckBox ID="chkValidado" runat="server" Text="Validado" Visible="False" />
                                                    <asp:CheckBox ID="chkResguardo" runat="server" Text="Resguardo impreso" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="cuadro_botones">
                                                    <asp:Button ID="btnCancelar" runat="server" Height="30px" OnClick="btnCancelar_Click"
                                                        Text="Cancelar" Width="80px" CausesValidation="False" CssClass="btn2" />
                                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" Height="30px" OnClick="btnGuardar_Click"
                                                        Text="Guardar" Width="80px" ValidationGroup="General" CssClass="btn" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server">

                                    </asp:View>
                                </asp:MultiView>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hddnComponentes" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="modalComponentes" runat="server"
        PopupControlID="pnlComponentes"
        TargetControlID="hddnComponentes" BackgroundCssClass="modalBackground_Proy">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlComponentes" runat="server" CssClass="TituloModalPopupMsg" Width="65%">
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
                            <asp:Label ID="Label4" runat="server" Text="Características:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComponenteCaracteristicas" runat="server" Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVComponenteCaracteristicas" runat="server" ControlToValidate="txtComponenteCaracteristicas" ErrorMessage="RequiredFieldValidator" Font-Bold="True" ValidationGroup="Componente">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style8">
                            <asp:Label ID="Label5" runat="server" Text="Marca:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComponenteMarca" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVComponenteMarca" runat="server" ControlToValidate="txtComponenteMarca" ErrorMessage="RequiredFieldValidator" Font-Bold="True" ValidationGroup="Componente">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style8">
                            <asp:Label ID="Label6" runat="server" Text="Modelo:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComponenteModelo" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVComponenteModelo" runat="server" ControlToValidate="txtComponenteModelo" ErrorMessage="RequiredFieldValidator" Font-Bold="True" ValidationGroup="Componente">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style8">
                            <asp:Label ID="Label7" runat="server" Text="No. de Serie:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComponenteSerie" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVComponenteSerie" runat="server" ControlToValidate="txtComponenteSerie" ErrorMessage="*" Font-Bold="True" ValidationGroup="Componente"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style8">
                            <asp:Label ID="Label15" runat="server" Text="Color:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComponenteColor" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVComponenteColor" runat="server" ControlToValidate="txtComponenteColor" ErrorMessage="*" Font-Bold="True" ValidationGroup="Componente"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button ID="btnComponente_Agregar" runat="server" CssClass="btn" OnClick="btnComponente_Agregar_Click" Text="Agregar Componente" ValidationGroup="Componente" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table style="width: 100%;">
            <tr>


                <td align="center">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grvComponentes" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False"
                                OnRowDeleting="grvComponentes_RowDeleting"
                                OnPageIndexChanging="grvComponentes_PageIndexChanging"
                                EmptyDataText="No hay registros para mostrar" Width="70%" CssClass="mGrid">
                                <Columns>
                                    <asp:BoundField DataField="No_Inventario" />
                                    <asp:BoundField DataField="Inventario_Auxiliar" />
                                    <asp:BoundField DataField="Caracteristicas" HeaderText="CARACTERISTICAS">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Marca" HeaderText="MARCA" />
                                    <asp:BoundField DataField="Modelo" HeaderText="MODELO" />
                                    <asp:BoundField DataField="No_serie" HeaderText="No. SERIE" />
                                    <asp:BoundField DataField="Color" HeaderText="COLOR" />
                                    <asp:CommandField ShowDeleteButton="True" />
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
                <td align="center">
                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnCerrar" runat="server" CausesValidation="False" CssClass="btn"
                                OnClick="btnCerrar_Click" Text="Cerrar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

        </table>
    </asp:Panel>

   
</asp:Content>
