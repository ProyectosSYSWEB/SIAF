<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmEditor.aspx.cs" Inherits="SAF.Patrimonio.frmEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 29px;
        }

        .auto-style4 {
            height: 34px;
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
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%" >
                                            </asp:DropDownList>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlFechas" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 15%"></td>
                                            <td style="width: 55%"></td>
                                            <td style="width: 15%" valign="center"></td>
                                            <td style="width: 15%"></td>
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
                                <td colspan="4">
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
                                                            <asp:GridView ID="grvInventario" runat="server" EmptyDataText="No hay registros para mostrar" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderStyle="None" BorderWidth="1px" GridLines="Vertical" OnPageIndexChanging="grvInventario_PageIndexChanging"
                                                        Width="100%" OnSelectedIndexChanged="grvInventario_SelectedIndexChanged"  CssClass="mGrid" PageSize="20">
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
                                                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
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
                                                <td align="center"></td>
                                            </tr>

                                            
                                        </table>

                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 17%"></td>
                                                <td style="width: 33%"></td>
                                                <td style="width: 17%"></td>
                                                <td style="width: 33%"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">
                                                    <asp:Label ID="Label1" runat="server" Text="Centro Contable:"></asp:Label></td>
                                                <td class="auto-style4">
                                                    <asp:TextBox ID="txtCentroContable" runat="server" Width="100px"></asp:TextBox></td>
                                        <td> <asp:Label ID="Label2" runat="server" Text="Dependencia:"></asp:Label></td>
                                                <td><asp:TextBox ID="txtDependencia" runat="server" Width="100px"></asp:TextBox> </td>
                                               
                                                
                                            </tr>
                                            <tr>
                                               <td> <asp:Label ID="Label4" runat="server" Text="Sub-Dependencia:"></asp:Label></td>
                                                <td> <asp:TextBox ID="txtSubDependencia" runat="server" Width="100px"></asp:TextBox></td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lblInventario" runat="server" Text="No. Inventario:"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style4">
                                                    <asp:TextBox ID="txtInventario" runat="server" Font-Underline="False" Font-Bold="False" Width="100px"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblClave" runat="server" Text="Clave:"></asp:Label>
                                                </td>
                                                <td  colspan="3" valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLClave" runat="server" Width="98%" >
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                     <td align="left" class="style8" >
                                                    <asp:Label ID="Label3" runat="server" Text="Tipo Alta:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLTipo_Alta" runat="server" Width="200px" >
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                    <td>
                                                        <asp:Label ID="lblCedula" runat="server" Text="Cédula No.:"></asp:Label>
                                                    </td>
                                                    <td align="left" >
                                                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtCedula" runat="server" Width="100px"></asp:TextBox>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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
                                                            <asp:TextBox ID="txtFecha_Alta" runat="server" CssClass="box" 
                                                                Width="100px" ></asp:TextBox>

                                                            <ajaxToolkit:CalendarExtender ID="Calendario_FechaAlta" runat="server" TargetControlID="txtFecha_Alta" DaysModeTitleFormat="dd MMMM, yyyy"
                                                                Format="dd/MM/yyyy" PopupButtonID="Calendario_FecAlta" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                            <asp:Image ID="Calendario_FecAlta" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="style8">
                                                    <asp:Label ID="lblFechaContable" runat="server" Text="Fecha Contable:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFecha_Contable" runat="server" CssClass="box"
                                                        Width="100px"></asp:TextBox>
                                                     <ajaxToolkit:CalendarExtender ID="Calendario_FechaContable" runat="server" TargetControlID="txtFecha_Contable" DaysModeTitleFormat="dd MMMM, yyyy"
                                                                Format="dd/MM/yyyy" PopupButtonID="Calendario_FecContable" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                    <asp:Image ID="Calendario_FecContable" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label14" runat="server" Text="Póliza No.:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtPoliza" runat="server" Width="100px"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </td>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label16" runat="server" Text="Código Contable:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtContab" runat="server" Width="200px"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label89" runat="server" Text="No. Inv. Anterior:"></asp:Label>
                                                    </td>
                                                    <td >
                                                        <asp:TextBox ID="txtInv_Anterior" runat="server" Width="100px"></asp:TextBox>
                                                        
                                                    </td>

                                                    <td align="left">
                                                        <asp:Label ID="Label90" runat="server" Text="Volante Transferencia:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVolante_Transferencia" runat="server" Width="100px"></asp:TextBox>
                                                        
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label17" runat="server" Text="Fecha Alta Anterior:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAlta_Anterior" runat="server" CssClass="box" Width="100px"></asp:TextBox>
                                                        <asp:Image runat="server" ID="imgCalendarioAltaAnterior"
                                                            ImageUrl="../../Adquisiciones/images/Calendar_scheduleHS.png"></asp:Image>
                                                        <ajaxToolkit:CalendarExtender ID="imgCalendarioAnterior" runat="server"
                                                            TargetControlID="txtAlta_Anterior" DaysModeTitleFormat="dd MMMM, yyyy"
                                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioAltaAnterior"
                                                            TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                        
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label91" runat="server" Text="Procedencia:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProcedencia" runat="server" Width="200px"></asp:TextBox>
                                                        
                                                    </td>

                                                </tr>
                                           
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblProyecto" runat="server" Text="Proyecto:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtProyecto" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                           
                                                <td align="left">
                                                    <asp:Label ID="lblFuente" runat="server" Text="Fuente Financ.:"></asp:Label>
                                                </td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtFuente" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="lblCentroTrabajo" runat="server" Text="Centro Trabajo:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtCentroTrabajo" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                                 <td align="left" class="style8" >
                                                    <asp:Label ID="lblPartida" runat="server" Text="Partida:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtPartida" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label94" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="DDLEstatus" runat="server">
                                                         <asp:ListItem Value="A">Alta</asp:ListItem>
                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" class="style8" >
                                                    <asp:Label ID="Label95" runat="server" Text="Reclasificado:"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="DDLReclasificado" runat="server">
                                                        <asp:ListItem Value="S">Si</asp:ListItem>
                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td><asp:Label ID="Label5" runat="server" Text="Fecha reclasificación:"></asp:Label></td>
                                                <td><asp:TextBox ID="txtFecha_Reclasificacion" runat="server" CssClass="box" Width="100px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="Calendario_FechaReclasifica" runat="server" TargetControlID="txtFecha_Reclasificacion" DaysModeTitleFormat="dd MMMM, yyyy"
                                                                Format="dd/MM/yyyy" PopupButtonID="Calendario_FechaReclasificacion" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                                    <asp:Image ID="Calendario_FechaReclasificacion" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                </td>
                                            </tr>
                                           <tr>
                                                <td colspan="4" align="center" class="cuadro_botones">
                                                    <asp:Button ID="btnCancelar" runat="server" Height="30px" OnClick="btnCancelar_Click"
                                                        Text="Cancelar" Width="80px" CausesValidation="False" CssClass="btn2" />
                                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" Height="30px" OnClick="btnGuardar_Click"
                                                        Text="Guardar" Width="80px" ValidationGroup="General" CssClass="btn" />
                                                </td>
                                            </tr>
                                            </caption>
                                        </table>
                                        
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

       
</asp:Content>
