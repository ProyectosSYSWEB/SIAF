<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBajas.aspx.cs" Inherits="SAF.Patrimonio.Form.frmBajas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
            width: 157px;
            text-align: right;
            margin-left: 40px;
        }
    .style2
    {
    }
    .style3
    {
    }
    .style4
    {
            width: 157px;
            text-align: right;
            margin-left: 80px;
        }
        .style5
        {
            width: 127px;
        }
        .style9
        {
            width: 85%;
        }
        .style11
        {
            width: 99px;
        }
        .style12
        {
            width: 97px;
        }
        .style24
        {
        }
        .style27
        {
            
        }
        
        
        .style31
        {
            
        }
        
        
        .style32
        {
            
        }
        
        
        .style41
        {
            width: 174px;
        }
        
        
        .style42
        {
            width: 35%;
        }
        .style43
        {
            width: 34%;
        }
        .style45
        {
            width: 27%;
        }
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:HiddenField ID="hddnTransferencia" runat="server" />
<ajaxToolkit:ModalPopupExtender ID="modalTransf" runat="server" 
                                                    PopupControlID="pnlMsjTransf" 
        TargetControlID="hddnTransferencia" BackgroundCssClass="modalBackground_Proy">
                                                </ajaxToolkit:ModalPopupExtender>
     <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
                                                <table  class="tabla_contenido">
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                Width="50px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="style4" align="left">
                                                <asp:Label ID="lblDepOrigen" runat="server" Text="Dependencia:"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="5">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td class="style9" align="left">
                                                            <asp:DropDownList ID="DDLDepOrigen" runat="server" Width="98%">
                                                            </asp:DropDownList>
                                                             <br />
                                                            <asp:RequiredFieldValidator ID="RFVDepOrigen" runat="server" 
                                                                ControlToValidate="DDLDepOrigen" ErrorMessage="RequiredFieldValidator" 
                                                                InitialValue="--TODAS LAS DEPENDENCIAS--" ValidationGroup="Nuevo">*Elegir &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; una Dependencia</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left">
                                                            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                &nbsp;</td>
                                            <td class="style2" colspan="5">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td class="style9" align="left">
                                                           
                                                            
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4" valign="top">
                                                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                            </td>
                                            <td class="style5" valign="top" align="left">
                                                <asp:DropDownList ID="DDLStatus" runat="server">
                                                    <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                    <asp:ListItem Value="R">APLICADA</asp:ListItem>
                                                    <asp:ListItem Value="E">SOLICITADA</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style12" style="text-align: right" valign="top">
                                                <asp:Label ID="lblFechaIni" runat="server" style="text-align: right" 
                                                    Text="Fecha Inicial:"></asp:Label>
                                            </td>
                                            <td class="style32" valign="top">
                                               <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>--%>
                                                        <asp:TextBox ID="txtFechaIni" runat="server" AutoPostBack="True" CssClass="box" 
                                                             Width="95px"></asp:TextBox>
                                                       <%-- <img alt="Ver calendario" 
                                onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                src="../../images/Calendario.gif" style="cursor: pointer" />--%>
                                                <ajaxToolkit:CalendarExtender ID="Calendario1" runat="server" TargetControlID="txtFechaIni" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="imgCalendario1" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                         <asp:Image ID="imgCalendario1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="txtFechaIni" ErrorMessage="RequiredFieldValidator" 
                                                            ValidationGroup="Buscar">*Requerido</asp:RequiredFieldValidator>
                                                        &nbsp;
                                                   <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                                            <td class="style12" style="text-align: right" valign="top">
                                                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final:"></asp:Label>
                                            </td>
                                            <td valign="top">
                                               <%-- <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                    <ContentTemplate>--%>
                                                        <asp:TextBox ID="txtFechaFin" runat="server" AutoPostBack="True" CssClass="box" 
                                                             Width="95px"></asp:TextBox>
                                                       <ajaxToolkit:CalendarExtender ID="Calendario2" runat="server" TargetControlID="txtFechaFin" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="imgCalendario2" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                         <asp:Image ID="imgCalendario2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="txtFechaFin" ErrorMessage="RequiredFieldValidator" 
                                                            ValidationGroup="Buscar">*Requerido</asp:RequiredFieldValidator>
                                                    <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4" valign="top">
                                                <asp:Label ID="lblBuscar" runat="server" Text="# de Folio:"></asp:Label>
                                            </td>
                                            <td class="style5" valign="top">
                                                <asp:TextBox ID="txtBuscar" runat="server" Width="100%" 
                                                    ></asp:TextBox>
                                            </td>
                                            <td class="style11" style="text-align: left" valign="top">                                              
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:ImageButton ID="imgbtnBuscar" runat="server" CausesValidation="False" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgbtnBuscar_Click" ValidationGroup="Buscar" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                            </td>
                                            <td class="style32">
                                                &nbsp;</td>
                                            <td class="style12" style="text-align: right">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style1">
                                                &nbsp;</td>
                                            <td class="style3" colspan="5">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                &nbsp;</td>
                                            <td class="style5">
                                                &nbsp;</td>
                                            <td class="style11">
                                                &nbsp;</td>
                                            <td class="style32">
                                                &nbsp;</td>
                                            <td class="style12">
                                                &nbsp;</td>
                                            <td>
                                                
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                  
                                            <asp:GridView ID="grvBajas" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" 
                                                BorderStyle="None"  CellPadding="4" 
                                                EmptyDataText="No hay registros para mostrar" 
                                                GridLines="Vertical" PageSize="15" Width="100%" 
                                                onselectedindexchanged="grvBajas_SelectedIndexChanged" CssClass="mGrid" OnRowDeleting="grvBajas_RowDeleting" OnPageIndexChanging="grvBajas_PageIndexChanging">                                                
                                                <Columns>
                                                    <asp:BoundField DataField="IdTransferencia" HeaderText="ID" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" >
                                                       </asp:BoundField>
                                                    <asp:BoundField DataField="Fecha_Transferencia" 
                                                        HeaderText="Fecha de Baja" />
                                                    <asp:BoundField DataField="Origen_Dependencia" 
                                                        HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Tipo_Baja_Str" 
                                                        HeaderText="Motivo de Baja" />
                                                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                     <asp:BoundField DataField="StatusMovto" />
                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBttnEditar" runat="server" 
                                                                        onclick="linkBttnEditar_Click"><%# DataBinder.Eval(Container.DataItem, "StatusMovto")%></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                                    <asp:CommandField SelectText="Solicitud" ShowSelectButton="True"><ItemStyle HorizontalAlign="Center" /></asp:CommandField>
                                                    <asp:CommandField DeleteText="Dictamen" ShowDeleteButton="True"></asp:CommandField>
                                                    
                                                    <asp:BoundField DataField="Poliza_Baja" />
                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBttnPoliza" runat="server" 
                                                                        onclick="linkBttnPoliza_Click" Text="Poliza" Enabled='<%# Bind("Imprimir_Poliza_Baja") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                                    <asp:TemplateField><ItemTemplate><asp:ImageButton ID="imgBttnEnviar" runat="server" 
                                                                ImageUrl="~/images/Activo.PNG" Visible='<%# Bind("ImgVerde") %>' 
                                                                 OnClientClick="$(this).confirm();" onclick="imgBttnEnviar_Click"/></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                    <asp:TemplateField><ItemTemplate><asp:ImageButton ID="imgBttnCancelar" runat="server" 
                                                                ImageUrl="~/images/Suspendido.PNG" onclick="imgBttnCancelar_Click" 
                                                                Visible='<%# Bind("ImgRojo") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                  
                                                    <asp:TemplateField><ItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="linkBttnExcel" runat="server" onclick="linkBttnExcel_Click">Excel</asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        </ItemTemplate></asp:TemplateField>
                                               <asp:BoundField DataField="Tipo_Baja" HeaderText="TIPO BAJA" />
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
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table style="border-style: 0; border-color: 0; border-width: 0px; width:100%;">
                            <tr>
                                <td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:MultiView ID="MultiView2" runat="server">
                                                    <asp:View ID="View3" runat="server">
                                                        <fieldset>
                                                            <legend>Información Gral.</legend><%--<asp:Panel ID="pnlEnc" runat="server">--%>
                                                            <table style="width: 100%;">
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        &nbsp;</td>
                                                                    <td class="style25">
                                                                        &nbsp;</td>
                                                                    <td class="style27">
                                                                        &nbsp;</td>
                                                                    <td class="style18">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        <asp:Label ID="lblFecha_Movimiento" runat="server" Text="Fecha de Solicitud:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" align="left">
                                                                        <asp:TextBox ID="txtFecha_Baja" runat="server" AutoPostBack="True" 
                                                                            CssClass="box" onkeyup="javascript:this.value='';" 
                                                                             Width="95px" ontextchanged="txtFecha_Baja_TextChanged"></asp:TextBox>
                                                                        <img alt="Ver calendario" 
                                                                    onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                                                    src="../../images/Calendario.gif" style="cursor: pointer" />
                                                                        <asp:RequiredFieldValidator ID="RFVFecha_Baja" runat="server" 
                                                                            ControlToValidate="txtFecha_Baja" 
                                                                            ErrorMessage="RequiredFieldValidator" ValidationGroup="encabezado">*Requerido</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="style27">
                                                                        &nbsp;</td>
                                                                    <td class="style18">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        <asp:Label ID="lblDepOrigen1" runat="server" Text="Dependencia:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" colspan="3" align="left">
                                                                        <asp:DropDownList ID="DDLDependencia" runat="server" 
                                                                             Width="98%" onselectedindexchanged="DDLDependencia_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RFVDependencia" runat="server" 
                                                                            ControlToValidate="DDLDependencia" ErrorMessage="RequiredFieldValidator" 
                                                                            ValidationGroup="encabezado">*Requerido</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        <asp:Label ID="lblDepDestino1" runat="server" Text="Tipo de Baja:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" colspan="3" align="left">
                                                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                            <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLTipo_Baja" runat="server" Width="200px" AutoPostBack="True" 
                                                                            >
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RFVTipo_Baja" runat="server" 
                                                                            ControlToValidate="DDLTipo_Baja" ErrorMessage="RequiredFieldValidator" 
                                                                            ValidationGroup="encabezado">*Requerido</asp:RequiredFieldValidator>
                                                                                 </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" colspan="3" align="left">
                                                                        <asp:TextBox ID="txtObservaciones" runat="server" Height="50px" 
                                                                            TextMode="MultiLine" Width="98%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style24" colspan="4">
                                                                        <asp:LinkButton ID="linBttnSiguiente" runat="server" 
                                                                            OnClick="linBttnSiguiente_Click" ValidationGroup="encabezado" 
                                                                            CssClass="liga">SIGUIENTE&gt;</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style24" colspan="4">
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                            <%-- </asp:Panel>--%>
                                                        </fieldset>
                                                    </asp:View>
                                                    <asp:View ID="View4" runat="server">
                                                    <fieldset>
                                                        <legend>Detalle</legend>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td align="right" class="style31" valign="top">
                                                                   <%-- <asp:Label ID="lblEjercicio" runat="server" Text="Año de Alta:" Visible="False"></asp:Label>--%>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <%--<asp:DropDownList ID="DDLEjercicio" runat="server" 
                                                                        onselectedindexchanged="DDLEjercicio_SelectedIndexChanged" Width="150px" 
                                                                        AutoPostBack="True" Visible="False">
                                                                    </asp:DropDownList>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="style41" valign="top">
                                                                    <asp:Label ID="lblInventario_Inicial" runat="server" 
                                                                        Text="No. de Inventario Inicial:"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <table style="padding: 0px; margin: 0px; width: 80%;">
                                                                        <tr>
                                                                            <td valign="top" class="style42">
                                                                                <asp:TextBox ID="txtInventario_Inicial" runat="server" AutoPostBack="True" 
                                                                                    Width="100px" ontextchanged="txtInventario_Inicial_TextChanged"
                                                                                    placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                                    ControlToValidate="txtInventario_Inicial" ErrorMessage="RequiredFieldValidator" 
                                                                                    ValidationGroup="Agrega_Inventario">*Requerido</asp:RequiredFieldValidator>
                                                                                <br />
                                                                            </td>
                                                                            <td valign="top" align="right" class="style43">
                                                                                <asp:Label ID="lblInventario_Final" runat="server" 
                                                                                    Text="No. de Inventario Final:"></asp:Label>
                                                                            </td>
                                                                            <td class="style45" valign="top">
                                                                                <asp:TextBox ID="txtInventario_Final" runat="server" Width="100px"
                                                                                     placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                                    ControlToValidate="txtInventario_Final" ErrorMessage="RequiredFieldValidator" 
                                                                                    ValidationGroup="Agrega_Inventario">*Requerido</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td valign="top" width="8%">
                                                                                <asp:ImageButton ID="imgBttnBusca" runat="server" 
                                                                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBusca_Click" 
                                                                                    ValidationGroup="Agrega_Inventario" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="style41" valign="top">
                                                                    <asp:Label ID="lblInventario1" runat="server" Text="No. de Inventario:"></asp:Label>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td valign="top" width="85%">
                                                                              <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Panel ID="pnlLstInventario" runat="server" ScrollBars="Both" 
                                                                                    Visible="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                                                                    Height="150px">  
                                                                                <asp:CheckBoxList ID="chkLstInventario" runat="server">
                                                                                </asp:CheckBoxList>
                                                                            </asp:Panel>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                            </td>
                                                                            <td valign="top">
                                                                                &nbsp;
                                                                                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnAgregar_Click"  />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:GridView ID="grvBajasDet" runat="server" AllowPaging="True" 
                                                                        AutoGenerateColumns="False" 
                                                                        BorderStyle="None" CellPadding="4"
                                                                        GridLines="Vertical" onrowdeleting="grvBajasDet_RowDeleting"
                                                                        OnPageIndexChanging="grvBajasDet_PageIndexChanging" 
                                                                        EmptyDataText="No hay registros para mostrar" CssClass="mGrid">                                                                        
                                                                        <Columns>
                                                                            
                                                                            <asp:BoundField DataField="IdInventario" />
                                                                            <asp:BoundField DataField="bien_det.Cantidad" HeaderText="CANTIDAD" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                                                            <asp:BoundField DataField="Inventario_Numero" HeaderText="No. DE INVENTARIO" />
                                                                            <asp:BoundField DataField="bien_det.marca" HeaderText="MARCA" />
                                                                            <asp:BoundField DataField="bien_det.modelo" HeaderText="MODELO" />
                                                                            <asp:BoundField DataField="bien_det.No_Serie" HeaderText="No. DE SERIE" />
                                                                            <asp:BoundField DataField="bien_det.costo" HeaderText="COSTO" DataFormatString="{0:c}" >
                                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                                <ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                                                                            <asp:CommandField ShowDeleteButton="True" />
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
                                                                <td align="left" colspan="2">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <asp:LinkButton ID="linkBttnRegresar" runat="server" CssClass="liga" 
                                                                        OnClick="linkBttnRegresar_Click">&lt;REGRESAR</asp:LinkButton>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    </asp:View>
                                                </asp:MultiView>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="cuadro_botones">
                                                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" 
                                                    Text="Guardar" ValidationGroup="General" Width="80px" CssClass="btn" />
                                                &nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                                                    Text="Cancelar" CssClass="btn2" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                                                                                        <asp:Panel ID="pnlMsjTransf" runat="server" CssClass="TituloModalPopupMsg" 
                                                                                            
                    Width="40%">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td align="center" colspan="2">
                                                                                                        <br />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="center" rowspan="4" valign="top">
                                                                                                        &nbsp;<asp:Image ID="Image2" runat="server" 
                                                                                                            ImageUrl="~/images/Simbolo_Msg.png" />
                                                                                                        <br />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:Label ID="lblMsjTransf" runat="server" Font-Bold="True" 
                                                                                                                    Text="Motivo del Rechazo:"></asp:Label>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:TextBox ID="txtMsjTransfObs" runat="server" Height="86px" 
                                                                                                                    TextMode="MultiLine" Width="95%"></asp:TextBox>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        &nbsp;</td>
                                                                                                </tr>
                                                                                                <tr>
 <td align="left">
                                                                                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                   
                                                                                                        <asp:Label ID="lblFechaBaja" runat="server" Text="Fecha Baja:" Font-Bold="True" ></asp:Label>
                                                                                                        <asp:TextBox ID="txtFechaBaja" runat="server" Width="95px"></asp:TextBox>
                                                                                                    
                                                                                                                </ContentTemplate>
                                                                                                         </asp:UpdatePanel>
  </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" 
                                                                                                            AssociatedUpdatePanelID="UpdatePanel42">
                                                                                                            <progresstemplate>
                                                                                                                <asp:Image ID="Image8" runat="server" 
                                                                                                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                                                                                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                                                                                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                                                                                            </progresstemplate>
                                                                                                        </asp:UpdateProgress>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" align="center" class="cuadro_botones">
                                                                                                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:Button ID="btnSi" runat="server" CausesValidation="False" CssClass="btn" onclick="btnSi_Click" Text="Aceptar" />
                                                                                                                &nbsp;<asp:Button ID="btnNo" runat="server" CausesValidation="False" CssClass="btn2" onclick="btnNo_Click" Text="Cancelar" />
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        &nbsp;</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        &nbsp;</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    <table style="width: 100%;">
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                            <td>
                                                                                                &nbsp;</td>
                                                                                        </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
