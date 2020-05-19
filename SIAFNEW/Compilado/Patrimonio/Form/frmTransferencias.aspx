<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTransferencias.aspx.cs" Inherits="SAF.Adquisiciones.Form.FRMTransferencias" %>

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
    .style4
    {
            width: 157px;
            text-align: right;
            margin-left: 80px;
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
        
        
        .style52
        {
            width: 154px;
        }
        .style53
        {
            width: 152px;
        }
        
        
        .style54
        {
            width: 15%;
        }
        
        
        .style58
        {
            width: 151px;
        }
        .style59
        {
        }
        .style60
        {
            width: 120px;
        }
        .style61
        {
            width: 256px;
        }
        
        
        .style62
        {
            height: 4px;
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
                                                
    <table class="tabla_contenido">
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="style4" valign="top" align="left">
                                                <asp:Label ID="lblDepOrigen" runat="server" Text="Dependencia Origen:"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="5">
                                                <table style="width:100%;">
                                                    <tr valign="top">
                                                        <td class="style9" align="left">
                                                            <asp:DropDownList ID="DDLDepOrigen" runat="server" Width="98%"  TabIndex="1">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" title="Nuevo" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4" valign="top" align="left">
                                                <asp:Label ID="lblDepDestino" runat="server" Text="Dependencia Destino:"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="5">
                                                <table style="width:100%;">
                                                    <tr valign="top">
                                                        <td class="style9" align="left">
                                                            <asp:DropDownList ID="DDLDepDestino" runat="server" Width="98%" 
                                                                TabIndex="2">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                ControlToValidate="DDLDepDestino" ErrorMessage="RequiredFieldValidator" 
                                                                InitialValue="--TODAS LAS DEPENDENCIAS--" ValidationGroup="Nuevo">*Elegir 
                                                            una Dependencia</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                       
                                        
                                        <tr>
                                            <td class="style4" valign="top" align="left">
                                                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="5">
                                                <table style="width:100%;">
                                                    <tr valign="top">
                                                        <td align="left" class="style9">
                                                            <table style="border-width: 0px; width: 100%;">
                                                                <tr>
                                                                    <td valign="top" width="15%">
                                                                        <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" 
                                                                            onselectedindexchanged="DDLStatus_SelectedIndexChanged" TabIndex="3">
                                                                            <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                                            <asp:ListItem Value="E">ENVIADA</asp:ListItem>
                                                                            <asp:ListItem Value="R">RECIBIDA</asp:ListItem>
                                                                            <asp:ListItem Value="C">RECHAZADA</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td valign="top" width="15%" class="style54" align="right">
                                                                        <asp:Label ID="lblFechaIni" runat="server" style="text-align: right" 
                                                                            Text="Fecha Inicial:"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                    <td valign="top" width="20%">
                                                                        <asp:TextBox ID="txtFechaIni" runat="server" AutoPostBack="True" CssClass="box" 
                                                                           ontextchanged="txtFechaIni_TextChanged" 
                                                                            TabIndex="4" Width="85px"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="Calendario1" runat="server" TargetControlID="txtFechaIni" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="imgCalendario1" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                         <asp:Image ID="imgCalendario1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                                                                     
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                            ControlToValidate="txtFechaIni" ErrorMessage="RequiredFieldValidator" 
                                                                            ValidationGroup="Buscar">*Requerido</asp:RequiredFieldValidator>
                                                                       </td>
                                                                    <td valign="top" width="15%" align="right">
                                                                        <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final:"></asp:Label>
                                                                    </td>
                                                                    <td valign="top" width="20%">
                                                                        <asp:TextBox ID="txtFechaFin" runat="server" AutoPostBack="True" CssClass="box" 
                                                                          ontextchanged="txtFechaFin_TextChanged" 
                                                                            TabIndex="6" Width="85px"></asp:TextBox>

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
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="style4" valign="top">
                                                <asp:Label ID="lblBuscar" runat="server" Text="No. de Folio:"></asp:Label>
                                             </td>
                                            <td class="style2" colspan="5" align="left">
                                                <table style="width:100%;">
                                                    <tr valign="top">
                                                        <td class="style9" align="left">
                                                            <asp:TextBox ID="txtBuscar" runat="server" 
                                                                ontextchanged="txtBuscar_TextChanged" TabIndex="8" Width="98%"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgbtnBuscar" runat="server" CausesValidation="False" 
                                                                Height="38px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgbtnBuscar_Click" 
                                                                TabIndex="9" ValidationGroup="Buscar" Width="39px"  title="Buscar"/>
                                                        </td>
                                                    </tr>
                                                </table></td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                &nbsp;</td>
                                            <td class="style53">
                                                &nbsp;</td>
                                            <td class="style11">
                                                &nbsp;</td>
                                            <td class="style52">
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
                                  
                                            <asp:GridView ID="grvTransferencia" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False"  EmptyDataText="No hay registros para mostrar" 
                                                GridLines="Vertical" PageSize="15" Width="100%" 
                                                onselectedindexchanged="grvTransferencia_SelectedIndexChanged" CssClass="mGrid" OnPageIndexChanging="grvTransferencia_PageIndexChanging">                                               
                                                <Columns>
                                                    <asp:BoundField DataField="IdTransferencia" HeaderText="ID" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" >
                                                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    <asp:BoundField DataField="Fecha_Transferencia" 
                                                        HeaderText="Fecha de Transferencia" >
                                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                        </asp:BoundField>
                                                    <asp:BoundField DataField="Fecha_Movimiento" HeaderText="Fecha de Recibido" >
                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                         </asp:BoundField>
                                                    <asp:BoundField DataField="Dias_Transcurridos" HeaderText="Dias" />
                                                    <asp:BoundField DataField="Origen_Dependencia" 
                                                        HeaderText="Origen Dependencia" >
                                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                        </asp:BoundField>
                                                    <asp:BoundField DataField="Destino_Dependencia" 
                                                        HeaderText="Destino Dependencia" >
                                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                        </asp:BoundField>
                                                    <asp:BoundField DataField="Status" HeaderText="Status" >
                                                        <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                                    <asp:BoundField DataField="StatusMovto" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>                                                           
                                                                    <asp:LinkButton ID="linkBttnEditar" runat="server" 
                                                                        onclick="linkBttnEditar_Click" Enabled='<%# Bind("Editable") %>'><%# DataBinder.Eval(Container.DataItem, "StatusMovto")%></asp:LinkButton>                                                               
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:CommandField SelectText="Volante" ShowSelectButton="True" ItemStyle-ForeColor="#0066CC">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                    
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnEnviar" runat="server" 
                                                                ImageUrl="~/images/Activo.PNG" Visible='<%# Bind("ImgVerde") %>' 
                                                                OnClientClick="$(this).confirm();" onclick="imgBttnEnviar_Click"/>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnCancelar" runat="server" 
                                                                ImageUrl="~/images/Suspendido.PNG" onclick="imgBttnCancelar_Click" 
                                                                Visible='<%# Bind("ImgRojo") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Poliza_Baja" />
                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBttnPolizaBaja" runat="server" 
                                                                        onclick="linkBttnPolizaBaja_Click" Text="Poliza Baja" Enabled='<%# Bind("Imprimir_Poliza_Baja") %>'></asp:LinkButton></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Poliza_Alta" />
                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBttnPolizaAlta" runat="server" 
                                                                        onclick="linkBttnPolizaAlta_Click" Text="Poliza Alta" Enabled='<%# Bind("Imprimir_Poliza_Alta") %>'></asp:LinkButton></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
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
                                <td>
                                    </td>
                                <td>
                                    </td>
                                <td>
                                   </td>
                            </tr>
                            <tr>
                                <td>
                                   </td>
                                <td>
                                    </td>
                                <td></td>
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
                                                            <legend>Información General</legend><%--<asp:Panel ID="pnlEnc" runat="server">--%>
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
                                                                        <asp:Label ID="lblFecha_Movimiento" runat="server" Text="Fecha:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" align="left">
                                                                       <%-- <asp:TextBox ID="txtFecha_Transferencia" runat="server" AutoPostBack="True" 
                                                                            CssClass="box" onkeyup="ValidaFecha();" 
                                                                             Width="95px"></asp:TextBox>--%>
                                                                        <%--<asp:Image ID="imgCalendario3" runat="server" 
                                                    ImageUrl="../../Adquisiciones/images/Calendar_scheduleHS.png" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
                                                    DaysModeTitleFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" 
                                                    PopupButtonID="imgCalendario3" TargetControlID="txtFecha_Transferencia" 
                                                    TodaysDateFormat="dd MMMM, yyyy">
                                                </ajaxToolkit:CalendarExtender>--%>
                                                                        <asp:TextBox ID="txtFecha_Transferencia" runat="server" AutoPostBack="True" 
                                                                            CssClass="box" onkeyup="javascript:this.value='';" 
                                                                             Width="95px" ontextchanged="txtFecha_Transferencia_TextChanged"></asp:TextBox>
                                                                        <img alt="Ver calendario" 
                                                                    onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                                                    src="../../images/Calendario.gif" style="cursor: pointer" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                            ControlToValidate="txtFecha_Transferencia" 
                                                                            ErrorMessage="RequiredFieldValidator" ValidationGroup="encabezado">*Requerido</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="style27">
                                                                        &nbsp;</td>
                                                                    <td class="style18">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        <asp:Label ID="lblDepOrigen1" runat="server" Text="Dependencia Origen:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" colspan="3" align="left">
                                                                        <asp:DropDownList ID="DDLDepOrigen1" runat="server" 
                                                                            Width="98%" >
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                            ControlToValidate="DDLDepOrigen1" ErrorMessage="RequiredFieldValidator" 
                                                                            ValidationGroup="encabezado">*Requerido</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td align="right" class="style31">
                                                                        <asp:Label ID="lblDepDestino1" runat="server" Text="Dependencia Destino:"></asp:Label>
                                                                    </td>
                                                                    <td class="style25" colspan="3" align="left">
                                                                        <asp:DropDownList ID="DDLDepDestino1" runat="server" Width="98%" 
                                                                            >
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                            ControlToValidate="DDLDepDestino1" ErrorMessage="RequiredFieldValidator" 
                                                                            ValidationGroup="encabezado">*Requerido</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="DDLDepOrigen1" ControlToValidate="DDLDepDestino1" ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="encabezado">*Las dependencias no pueden ser iguales.</asp:CompareValidator>
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
                                                            <%--<tr>
                                                                <td align="right" class="style61" valign="top">
                                                                    <asp:Label ID="lblEjercicio" runat="server" Text="Ejercicio:"></asp:Label>
                                                                </td>
                                                                <td valign="top" align="left" colspan="4">
                                                                    <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="DDLEjercicio" runat="server" AutoPostBack="True" 
                                                                                onselectedindexchanged="DDLEjercicio_SelectedIndexChanged" Width="150px">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td colspan="5"></td>
                                                               
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="right" class="style61" valign="top">
                                                                    <asp:Label ID="lblInventario_Inicial" runat="server" 
                                                                        Text="No. de Inventario Inicial:"></asp:Label>
                                                                </td>
                                                                <td align="left" class="style59" valign="top">
                                                                    <asp:TextBox ID="txtInventario_Inicial" runat="server" AutoPostBack="True" 
                                                                        ontextchanged="txtInventario_Inicial_TextChanged" TabIndex="1" Width="100px"
                                                                        placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                        ControlToValidate="txtInventario_Inicial" ErrorMessage="RequiredFieldValidator" 
                                                                        ValidationGroup="Agrega_Inventario">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" class="style58" valign="top">
                                                                    <asp:Label ID="lblInventario_Final" runat="server" 
                                                                        Text="No. de Inventario Final:"></asp:Label>
                                                                </td>
                                                                <td align="left" class="style60" valign="top">
                                                                    <asp:TextBox ID="txtInventario_Final" runat="server" TabIndex="2" Width="100px"
                                                                        placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                        ControlToValidate="txtInventario_Final" ErrorMessage="RequiredFieldValidator" 
                                                                        ValidationGroup="Agrega_Inventario">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:ImageButton ID="imgBttnBusca" runat="server" 
                                                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBusca_Click" TabIndex="3" 
                                                                        ValidationGroup="Agrega_Inventario" title="Buscar" />
                                                                </td>
                                                            </tr>
                                                           
                                                                    <tr>
                                                                        <td align="right" class="style61" valign="top">
                                                                            <asp:Label ID="lblInventario1" runat="server" Text="No. de Inventario:" 
                                                                                Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td align="left" class="style59" colspan="3" valign="top">
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
                                                                        <td align="left" valign="top">
                                                                            <asp:ImageButton ID="bttnAgregar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="bttnAgregar_Click" title="Agregar" />
                                                                        </td>
                                                            </tr>
                                                                
                                                                    
                                                                <tr>
                                                                    <td align="center" colspan="5">
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="5">
                                                                        <asp:GridView ID="grvTransferenciaDet" runat="server" AllowPaging="True" 
                                                                            AutoGenerateColumns="False" EmptyDataText="No hay registros para mostrar."
                                                                            GridLines="Vertical" 
                                                                            onpageindexchanging="grvTransferenciaDet_PageIndexChanging" 
                                                                            onrowdeleting="grvTransferenciaDet_RowDeleting" Width="95%" CssClass="mGrid">                                                                            
                                                                            <Columns>
                                                                                <asp:BoundField DataField="IdInventario" >
                                                                                    <ItemStyle Width="70px" /></asp:BoundField>
                                                                                <asp:BoundField DataField="bien_det.Cantidad" HeaderText="CANTIDAD">
                                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Inventario_Numero" HeaderText="NO. DE INVENTARIO" >
                                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" /></asp:BoundField>
                                                                                <asp:BoundField DataField="bien_det.marca" HeaderText="MARCA" >
                                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" /></asp:BoundField>
                                                                                <asp:BoundField DataField="bien_det.modelo" HeaderText="MODELO" >
                                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" /></asp:BoundField>
                                                                                <asp:BoundField DataField="bien_det.No_Serie" HeaderText="NO. DE SERIE" >
                                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" /></asp:BoundField>
                                                                                <asp:BoundField DataField="bien_det.costo" HeaderText="COSTO"  DataFormatString="{0:c}">
                                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                                                </asp:BoundField>
                                                                                <asp:CommandField ShowDeleteButton="True" >
                                                                                    <ItemStyle Width="50px" /></asp:CommandField>
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
                                                                    <td align="left" colspan="5">
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="5">
                                                                        <asp:LinkButton ID="linkBttnRegresar" runat="server" CssClass="liga" 
                                                                            OnClick="linkBttnRegresar_Click">&lt;REGRESAR</asp:LinkButton>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="5">
                                                                        </td>
                                                                </tr>
                                                            </caption>
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
                                                    Text="Enviar" ValidationGroup="General" Width="80px" CssClass="btn" />
                                                &nbsp;<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                                                    Text="Cancelar" CssClass="btn2" CausesValidation="False" />
                                                &nbsp;</td>
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
                                                                                                    <td align="center" rowspan="3" valign="top">
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
                                                                                                    <td colspan="2">
                                                                                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" 
                                                                                                            AssociatedUpdatePanelID="UpdatePanel40">
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
                                                                                                                <asp:Button ID="btnSi" runat="server" CausesValidation="False" CssClass="btn" onclick="btnSi_Click" Text="Si" />
                                                                                                                &nbsp;<asp:Button ID="btnNo" runat="server" CausesValidation="False" CssClass="btn2" onclick="btnNo_Click" Text="No" />
                                                                                                                &nbsp;
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
