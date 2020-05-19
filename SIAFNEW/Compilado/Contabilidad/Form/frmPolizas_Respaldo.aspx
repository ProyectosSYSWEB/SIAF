<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPolizas_Respaldo.aspx.cs" Inherits="SAF.Form.frmPolizas_Respaldo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css"> 
                        
        .style14
        {
        }                

        .style16
        {
            width: 12%;
        }                 
                          
        .style17
        {
            width: 236px;
        }
        .style19
        {
            width: 18%;
            text-align: left;
        }
                          
        .style20
        {
            width: 23%;
        }
                          
        .auto-style1 {
            width: 60%;
            height: 17px;
        }
                          
        .auto-style2 {
            width: 100%;
        }
                          
        .auto-style3 {
        width: 12%;
        text-align: right;
    }
                          
        .auto-style4 {
            width: 16%;
            text-align: left;
        }
                          
        .auto-style5 {
            width: 19%;
        }
        .auto-style6 {
            width: 33%;
        }
        .auto-style7 {
            width: 16%;
        }
                          
        </style>
   
   
<script type="text/javascript">
    
    function enter_cargo(e) {
    
        if (typeof e == 'undefined' && window.event) { e = window.event; }
        if (e.keyCode == 13) {

            document.getElementById('ctl00_MainContent_TabContainer1_TabPanel2_txtCargo').focus();
            return true;
        }
        else {
            return false;
        }
    }

    function enter_abono(e) {     
        if (typeof e == 'undefined' && window.event) { e = window.event; }
        if (e.keyCode == 13) {
            document.getElementById('ctl00_MainContent_TabContainer1_TabPanel2_txtAbono').focus();
            return true;
        }
    }


    function enter_boton(e) {
        if (typeof e == 'undefined' && window.event) { e = window.event; }
        if (e.keyCode == 13) {
            document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_btnAgregar").focus();
            return true;
        }
    }



        function Ejercicio_Usuario() {
            var MyDate = new Date();
            var MyDateString;

            MyDate.setDate(MyDate.getDate() + 20);

            MyDateString = '01' + '/'
             + ('0' + (MyDate.getMonth() + 1)).slice(-2) + '/'
             + document.getElementById('ctl00_txtEjercicio').value;
            document.getElementById('ctl00_MainContent_txtFecha_Ini').value = MyDateString;
            document.getElementById('ctl00_MainContent_lblRFecha_Ini').innerHTML = "Para cambiar la fecha click en botón";
            
        }


        function Ejercicio_Usuario_Final() {
            var MyDate = new Date();
            var MyDateString;

            MyDate.setDate(MyDate.getDate() + 20);

            MyDateString = ('0' + MyDate.getDate()).slice(-2) + '/'
             + ('0' + (MyDate.getMonth() + 1)).slice(-2) + '/'
             + document.getElementById('ctl00_txtEjercicio').value;
            document.getElementById('ctl00_MainContent_txtFecha_Fin').value = MyDateString;
            document.getElementById('ctl00_MainContent_lblRFecha_Fin').innerHTML = "Para cambiar la fecha click en botón";
        }


        function ValidaFecha() {
            var MyDate = new Date();
            var MyDateString;

            MyDate.setDate(MyDate.getDate() + 20);

            MyDateString = '01' + '/'
             + ('0' + (MyDate.getMonth() + 1)).slice(-2) + '/'
             + document.getElementById("ctl00_txtEjercicio").value;

            document.getElementById("ctl00_MainContent_txtFecha").value = MyDateString;
            document.getElementById("ctl00_MainContent_lblRFecha").innerHTML = "Para cambiar la fecha click en botón";
        }

        function ValidaFechaPolizaCopia() {
            var MyDate = new Date();
            var MyDateString;

            MyDate.setDate(MyDate.getDate() + 20);

            MyDateString = '01' + '/'
             + ('0' + (MyDate.getMonth() + 1)).slice(-2) + '/'
             + document.getElementById("ctl00_txtEjercicio").value;

            document.getElementById("ctl00_MainContent_txtFecha_Copia").value = MyDateString;
            document.getElementById("ctl00_MainContent_lblRFecha_Copia").innerHTML = "Para cambiar la fecha click en botón";
        }

        

        function Calendario() {
            $("#ctl00_MainContent_txtFecha").datepicker();
        }

        function mascara(e, tipo) {            
            if (tipo = "C") {
                var Valor = document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtCargo").value.toString().replace(/,/g, "");
                Valor = Valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtCargo").value = Valor;
            }

            if (tipo = "A") {                
                var Valor = document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtAbono").value.toString().replace(/,/g, "");
                Valor = Valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtAbono").value = Valor;
            }

        }

        function ClientValidate(source, arguments) {
            var Valor
            Valor = arguments.Value;
            Valor = Valor.substr(2);
            if (Valor.length = 4) {
                if (Valor > "4999") {
                    arguments.IsValid = false;
                } else {
                    arguments.IsValid = true;
                }
            }
        }

        function VerificarLongitud(sender, args) {
            var Valor = args.Value.toUpperCase();
            var n = Valor.search("CANCELADO");            
            if (n == -1) {
                if (Valor.length < 100) {
                    args.IsValid = false;
                }
            }
            else {
                args.IsValid = true;
            }
        }
       

        function MascaraNumPoliza(e,textFecha) {
            var Valor = e.value;
            var Valor2 = e.value;

            document.getElementById(e.id).value = "";
            if (textFecha == "1") {
                var Mes = document.getElementById('ctl00_MainContent_txtFecha').value;
            }
            else {
                var Mes = document.getElementById('ctl00_MainContent_txtFecha_Copia').value;
            }
            Mes = Mes.substr(3, 2);

            if (Valor.length > 2) {
                Valor = Valor.substr(2);
            }
            else {
                Valor = "";
            }
            var NumPoliza = Mes + Valor;
            if (NumPoliza.length <= 6) {
                document.getElementById(e.id).value = NumPoliza;
            }
            else {
                document.getElementById(e.id).value = Valor2.substr(0, 6);
            }

        }


        
</script>  

    

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <table class="tabla_contenido">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                <ContentTemplate>
                <asp:Panel ID="pnlPrincipal" runat="server">                                        
                    <table style="width: 100%;">

        <tr>
            <td align="right" class="auto-style4" valign="top">
                    </td>
            <td width="60%" class="style14" valign="top" align="center">
             
            </td>
            <td class="style16" valign="top">
                &nbsp;</td>
        </tr>
                        <tr>
                            <td align="right" class="auto-style4" valign="top">&nbsp;</td>
                            <td align="center" class="style14" valign="top" width="60%">&nbsp;</td>
                            <td class="style16" valign="top">&nbsp;</td>
                        </tr>
        <tr>
            <td align="right" class="auto-style4" valign="top">
                                        <asp:Label ID="lblCentro_Contable" runat="server" Text="Centro Contable:"></asp:Label>
                                        
            </td>
            <td width="60%" class="style14" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLCentro_Contable" runat="server" Width="100%" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="DDLCentro_Contable" ErrorMessage="*Requerido" 
                            InitialValue="00000" ValidationGroup="Poliza"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>
            <td class="auto-style3" valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" title="Nuevo"/>
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlFechas0" runat="server" Visible="False">
                            <table width="100%">
                                <tr>
                                    <td align="right" valign="top" class="style19">
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                                    </td>
                                    <td class="style17" valign="top">                                        
                                        <%--<asp:TextBox ID="txtFecha" runat="server" onFocus="Calendario();"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtFecha" runat="server" AutoPostBack="True" 
                                                        CssClass="box" Width="95px" ontextchanged="txtFecha_TextChanged" ></asp:TextBox>
                                                    <img alt="Ver calendario" 
                                onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                src="http://sysweb.unach.mx/resources/imagenes/calendario.gif" style="cursor: pointer" />
                                        <asp:Label ID="lblRFecha" runat="server" ForeColor="Red"></asp:Label>
                                        <br />
                                    </td>
                                    <td class="style9" align="right" valign="top">
                                        <asp:Label ID="lblTipo0" runat="server" Text="Tipo:"></asp:Label>
                                    </td>
                                    <td class="style9" valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlTipo0" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlTipo0_SelectedIndexChanged">
                                                    <asp:ListItem Value="E">Egreso</asp:ListItem>
                                                    <asp:ListItem Value="I">Ingreso</asp:ListItem>
                                                    <asp:ListItem Value="D">Diario</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="style9" align="right" valign="top">
                                        <asp:Label ID="lblStatus0" runat="server" Text="Status:" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style9" valign="top">
                                        <asp:DropDownList ID="ddlStatus0" runat="server" Visible="False">
                                            <asp:ListItem Value="A">Aplicado</asp:ListItem>
                                            <asp:ListItem Value="N">No Aplicado</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style9" valign="top">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td align="left" width="22%" style="margin-left: 40px; " 
                valign="top" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlFechas" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="right" valign="top" class="style19">
                                        <asp:Label ID="lblFecha_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                        <br />
                                    </td>
                                    <td width="100%">
                                        <table style="width:88%;">
                                            <tr>
                                                <td valign="top" class="style19">
                                                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlFecha_Ini" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlFecha_Ini_SelectedIndexChanged">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem Value="01">Enero</asp:ListItem>
                                                                <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                                <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                                                <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                                <asp:ListItem Value="06">Junio</asp:ListItem>
                                                                <asp:ListItem Value="07">Julio</asp:ListItem>
                                                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                                <asp:ListItem></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:Label ID="lblRFecha_Ini" runat="server" ForeColor="Red"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="right" valign="top" class="style20">
                                                    <asp:Label ID="lblFecha_Final" runat="server" Text="Fecha Final:"></asp:Label>
                                                </td>
                                                <td valign="top" class="style19">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlFecha_Fin" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlFecha_Fin_SelectedIndexChanged1">
                                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                        <br />
                                                        <asp:Label ID="lblRFecha_Fin" runat="server" ForeColor="Red"></asp:Label>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>                                                    
                                                </td>
                                                <td valign="top" width="14%" align="right">
                                                    <asp:Label ID="lblTipo1" runat="server" Text="Tipo:"></asp:Label>
                                                    <br />
                                                </td>
                                                <td valign="top" width="14%" align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlTipo2" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlTipo2_SelectedIndexChanged">
                                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                                                <asp:ListItem Value="E">Egreso</asp:ListItem>
                                                                <asp:ListItem Value="I">Ingreso</asp:ListItem>
                                                                <asp:ListItem Value="D">Diario</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlTipo2" ErrorMessage="*Requerido" InitialValue="T" ValidationGroup="RepLotes"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="right" valign="top" width="14%">
                                                    <asp:Label ID="lblStatus2" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td align="left" valign="top" width="14%">
                                                    <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlStatus2" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlStatus2_SelectedIndexChanged">
                                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                                                <asp:ListItem Value="A">Aplicado</asp:ListItem>
                                                                <asp:ListItem Value="N">No Aplicado</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlStatus2" ErrorMessage="*Requerido" InitialValue="T" ValidationGroup="RepLotes"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

                
                </td>
        </tr>

        <tr>
            <td align="right"  class="auto-style4">
               <asp:Label ID="lblBuscar" runat="server" Text="# de Póliza/Concepto:"></asp:Label>
            </td>
            <td  class="style14" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="True" CssClass="textbuscar" Width="90%"></asp:TextBox>
                        <asp:ImageButton ID="imgbtnBuscar" runat="server" CausesValidation="False" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" style="text-align: right" title="Buscar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" class="style8" colspan="3" width="100%">
                <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Image ID="Image7" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                Width="50px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                    <ProgressTemplate>
                        <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                Width="50px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel10">
                    <ProgressTemplate>
                        <asp:Image ID="Image4" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                Width="50px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image6" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                Width="50px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>                
                </td>
        </tr>
        </table>
                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">                            
                            <asp:View ID="View1" runat="server">
                                <table   class="auto-style2">
                                    <tr>
                                        <td> 
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvPolizas" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="mGrid" EmptyDataText="No hay registros para mostrar" GridLines="Vertical" onpageindexchanging="grvPolizas_PageIndexChanging" onrowdeleting="grvPolizas_RowDeleting" onselectedindexchanged="grvPolizas_SelectedIndexChanged" PageSize="25" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="IdPoliza" />
                                                            <asp:BoundField DataField="CENTRO_CONTABLE" HeaderText="CENTRO CONTABLE" />
                                                            <asp:BoundField DataField="NUMERO_POLIZA" HeaderText="# PÓLIZA" />
                                                            <asp:BoundField DataField="Cedula_numero" HeaderText="# CEDULA" />
                                                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                                                            <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" />
                                                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                                            <asp:BoundField DataField="CONCEPTO" HeaderText="CONCEPTO" />
                                                            <asp:BoundField DataField="TOT_CARGO" DataFormatString="{0:c}" HeaderText="CARGO">
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOT_ABONO" DataFormatString="{0:c}" HeaderText="ABONO">
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnEditar" runat="server" CommandName="Select" OnClick="linkBttnEditar_Click" Visible='<%# Bind("Opcion_Modificar") %>'>Editar</asp:LinkButton>
                                                                    <asp:Label ID="lblEditar" runat="server" ForeColor="#6B696B" Text="Editar" Visible='<%# Bind("Opcion_Modificar2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" onclick="linkBttnEliminar_Click" onclientclick="return confirm('¿Desea eliminar la Póliza ?');" Visible='<%# Bind("Opcion_Eliminar") %>'>Eliminar</asp:LinkButton>
                                                                    <asp:Label ID="lblEliminar" runat="server" ForeColor="#6B696B" Text="Eliminar" Visible='<%# Bind("Opcion_Eliminar2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnImprimir" runat="server" onclick="linkBttnImprimir_Click">Imprimir</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnCopiar" runat="server" onclick="linkBttnCopiar_Click" ToolTip="Permite clonar una Póliza" Visible='<%# Bind("Opcion_Copiar") %>'>Copiar</asp:LinkButton>
                                                                    <asp:Label ID="lblCopiar" runat="server" ForeColor="#6B696B" Text="Copiar" Visible='<%# Bind("Opcion_Copiar2") %>'></asp:Label>
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
                                        <td align="center">
<%--<ajaxToolkit:ModalPopupExtender ID="modalCopiaPoliza" runat="server" TargetControlID="hddnCopiaPoliza" 
                                                BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlCopiaPoliza"></ajaxToolkit:ModalPopupExtender>
                                           
                                            <asp:HiddenField ID="hddnCopiaPoliza" runat="server" />--%>
                                           
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones">
                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf" title="Reporte PDF" />
                                            &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" 
                                                ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf2.png" onclick="ImageButton4_Click" title="Reporte/Lote" ValidationGroup="RepLotes"  />
                                            &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" 
                                                ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" title="Reporte Excel" />
                                            &nbsp;<asp:ImageButton ID="imgBttnExcelLotes" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/EXCEL2.png" onclick="imgBttnExcelLotes_Click" title="Reporte Excel" ValidationGroup="RepLotes" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                                                                                            CssClass="ajax__myTab" Width="100%">
                                                                                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        Información Gral.
                                                    
</HeaderTemplate>
                                                    









































































































































































































































































































































































































































































<ContentTemplate>
                                                        <table style="width:100%;">
                                                            <tr><td align="center">
                                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                                                    AssociatedUpdatePanelID="UpdatePanel43"><progresstemplate>
                                                                                                            <asp:Image ID="Image1" runat="server" 
                                                                        AlternateText="Espere un momento, por favor.." Height="50px" 
                                                                        ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                                                        ToolTip="Espere un momento, por favor.." Width="50px" ImageAlign="Baseline" />
                                                                                                        
</progresstemplate>
</asp:UpdateProgress>










































































































































































































































































































































































































































































                                                                </td>
                                                                <tr>
                                                                    <td align="ce" valign="top">
                                                                        <asp:UpdatePanel ID="UpdatePanel43" runat="server"><ContentTemplate>
                                                                                <asp:Panel ID="pnlEgreso" runat="server" Width="100%">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td class="auto-style5">
                                                                                                <asp:Label ID="lblCheque_Cuenta0" runat="server" Text="# de Cta. de Cheques:" Visible="False"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" colspan="3" width="75%">
                                                                                                <asp:DropDownList ID="ddlCheque_Cuenta" runat="server" Visible="False">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="top" class="auto-style5">
                                                                                                <asp:Label ID="lblCheque_Numero0" runat="server" Text="# de Cheque:"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" valign="top" class="auto-style6">
                                                                                                <asp:TextBox ID="txtCheque_Numero" runat="server"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RFVCheque_Numero" runat="server" 
                                                                                                    ControlToValidate="txtCheque_Numero" ErrorMessage="*Número de Cheque">*Requerido</asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                            <td valign="top" class="auto-style7">
                                                                                                <asp:Label ID="lblCheque_Importe0" runat="server" Text="Importe del Cheque:"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="25%">
                                                                                                <asp:TextBox ID="txtCheque_Importe" runat="server" Width="100px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator102" 
                                                                                                    runat="server" ControlToValidate="txtCheque_Importe" CssClass="MsjError" 
                                                                                                    ErrorMessage="*Solo Números" SetFocusOnError="True" 
                                                                                                    ValidationExpression="^(-?\d{0,13}\.\d{0,2}|\d{0,13})$" 
                                                                                                    ValidationGroup="Poliza"></asp:RegularExpressionValidator>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RFVCheque_Importe" runat="server" 
                                                                                                    ControlToValidate="txtCheque_Importe" ErrorMessage="*Importe del Cheque">*Requerido</asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="top" class="auto-style5">
                                                                                                <asp:Label ID="lblBeneficiario" runat="server" Text="Beneficiario:"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" colspan="3" valign="top" width="75%">
                                                                                                <asp:TextBox ID="txtBeneficiario" runat="server" Width="350px"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RFVBeneficiario" runat="server" 
                                                                                                    ControlToValidate="txtBeneficiario" ErrorMessage="*Requerido"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                            
</ContentTemplate>
</asp:UpdatePanel>










































































































































































































































































































































































































































































                                                                    </td>
                                                                </tr>
                                                                    <tr>
                                                                        <td align="ce" valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="auto-style5">
                                                                                        <asp:Label ID="lblCedula_Numero0" runat="server" Text="# de Cédula/Adecuación:"></asp:Label>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                    <td class="auto-style6">
                                                                                        <asp:TextBox ID="txtCedula_Numero" runat="server"></asp:TextBox>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                    <td class="auto-style7">
                                                                                        <asp:Label ID="lbprograma" runat="server" Text="Programa:" Visible="False"></asp:Label>
                                                                                    </td>
                                                                                    <td width="25%">
                                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:DropDownList ID="ddlprograma" runat="server" AutoPostBack="True"  Visible="False">
                                                                                                    <asp:ListItem Value="0">Seleccione Un Programa.....</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">No Aplica</asp:ListItem>
                                                                                                    <asp:ListItem>12104_SANEAMIENTO_FINANCIERO_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12106_RECONOCIMIENTO_PLANTILLA_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12109_FAM_2014</asp:ListItem>
                                                                                                    <asp:ListItem>12109_FAM_2015</asp:ListItem>
                                                                                                    <asp:ListItem>12109_FAM_2016</asp:ListItem>
                                                                                                    <asp:ListItem>12109_FAM_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12111_CARRERA_DOCENTE_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12118_PROEXOEES_2014</asp:ListItem>
                                                                                                    <asp:ListItem>12118_PROEXOEES_2015</asp:ListItem>
                                                                                                    <asp:ListItem>12118_PROEXOEES_2016</asp:ListItem>
                                                                                                    <asp:ListItem>12118_PROEXOEES_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12119_FONSUR_2016</asp:ListItem>
                                                                                                    <asp:ListItem>12122_FORTALECIMIENTO_FINANCIERO_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12123_INCLUSION_Y_EQUIDAD_2016</asp:ListItem>
                                                                                                    <asp:ListItem>13103_PROFOCIE_2014</asp:ListItem>
                                                                                                    <asp:ListItem>13103_PROFOCIE_2015</asp:ListItem>
                                                                                                    <asp:ListItem>13103_PROFOCIE_2016</asp:ListItem>
                                                                                                    <asp:ListItem>13103_PFCE_2017</asp:ListItem>
                                                                                                    <asp:ListItem>13104_PRODEP_2014</asp:ListItem>
                                                                                                    <asp:ListItem>13104_PRODEP_2015</asp:ListItem>
                                                                                                    <asp:ListItem>13104_PRODEP_2016</asp:ListItem>
                                                                                                    <asp:ListItem>13104_PRODEP_2017</asp:ListItem>
                                                                                                    <asp:ListItem>12107_FECES_2014</asp:ListItem>
                                                                                                    <asp:ListItem>12112_FAFEF_2013</asp:ListItem>
                                                                                                    <asp:ListItem>12112_FAFEF_2013</asp:ListItem>
                                                                                                    <asp:ListItem>13104_PRODEP_2018</asp:ListItem>
                                                                                                    <asp:ListItem>12109_FAM_2018</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="val_programa" runat="server" ControlToValidate="ddlprograma" ErrorMessage="*Programa" InitialValue="0">*Requerido</asp:RequiredFieldValidator>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" class="auto-style5">
                                                                                        <asp:Label ID="lblTipo_Captura" runat="server" Text="Tipo de Captura:"></asp:Label>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                    <td valign="top" class="auto-style6">
                                                                                        <asp:DropDownList ID="ddlTipo_Captura" runat="server" Enabled="False"><asp:ListItem Value="MG">Manual Generada</asp:ListItem>
<asp:ListItem Value="AC">Automática de Cédula</asp:ListItem>
<asp:ListItem Value="MC">Manual Capturada</asp:ListItem>
<asp:ListItem Value="AN">Automática de Nómina</asp:ListItem>
<asp:ListItem Value="AP">Automática de Presupuesto</asp:ListItem>
<asp:ListItem Value="AA">Automática de Adecuación</asp:ListItem>
<asp:ListItem Value="AI">Automática de CHIP</asp:ListItem>
</asp:DropDownList>










































































































































































































































































































































































































































































                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                                            ControlToValidate="ddlTipo_Captura" ErrorMessage="*Tipo de Captura" 
                                                                                            ValidationGroup="Poliza">*Requerido</asp:RequiredFieldValidator>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                    <td valign="top" class="auto-style4">
                                                                                        <asp:Label ID="lblNumero_Poliza0" runat="server" Text="# de Póliza:"></asp:Label>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                    <td valign="top" width="25%">
                                                                                        <asp:TextBox ID="txtNumero_Poliza" runat="server" 
                                                                                            onkeyup="MascaraNumPoliza(this,1);" Width="80px"></asp:TextBox>










































































































































































































































































































































































































































































                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator101" 
                                                                                            runat="server" ControlToValidate="txtNumero_Poliza" ErrorMessage="*6 Digitos" 
                                                                                            ValidationExpression="^[\s\S]{6,6}$" ValidationGroup="Poliza"></asp:RegularExpressionValidator>










































































































































































































































































































































































































































































                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                                            ControlToValidate="txtNumero_Poliza" ErrorMessage="*Número de Poliza" 
                                                                                            ValidationGroup="Poliza">*Requerido</asp:RequiredFieldValidator>










































































































































































































































































































































































































































































                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator103" 
                                                                                            runat="server" ControlToValidate="txtNumero_Poliza" CssClass="MsjError" 
                                                                                            ErrorMessage="*Solo Números" SetFocusOnError="True" ValidationExpression="\d+" 
                                                                                            ValidationGroup="Poliza"></asp:RegularExpressionValidator>










































































































































































































































































































































































































































































                                                                                        <asp:CustomValidator ID="ValidatorNumPoliza" runat="server" 
                                                                                            ControlToValidate="txtNumero_Poliza" ErrorMessage="*Número Reservado" 
                                                                                            ClientValidationFunction="ClientValidate" ValidationGroup="Poliza"></asp:CustomValidator>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" class="auto-style5">
                                                                                        <asp:Label ID="lblConcepto1" runat="server" Text="Concepto:"></asp:Label>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                    <td colspan="3" style="width: 75%" valign="top">
                                                                                        <asp:TextBox ID="txtConcepto" runat="server" Height="94px" TextMode="MultiLine" 
                                                                                            Width="500px"></asp:TextBox>










































































































































































































































































































































































































































































                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                                            ControlToValidate="txtConcepto" ErrorMessage="*Concepto" 
                                                                                            ValidationGroup="Poliza">*Requerido</asp:RequiredFieldValidator>










































































































































































































































































































































































































































































                                                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarLongitud" ControlToValidate="txtConcepto" ErrorMessage="*Longitud minima de 100 caracteres" ValidationGroup="Poliza"></asp:CustomValidator>










































































































































































































































































































































































































































































                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                </tr>
                                                                
                                                            </tr>
                                                            </tr>
                                                            </tr>
                                                        </table>
                                                    <br />
                                                    
</ContentTemplate>
                                                









































































































































































































































































































































































































































































</ajaxToolkit:TabPanel>
                                                                                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalle">
                                                                                                <HeaderTemplate>
                                                                                                    Detalle
                                                                                                
</HeaderTemplate>
                                                                                    









































































































































































































































































































































































































































































<ContentTemplate>
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td class="style5" valign="top" width="15%">
                                                                                                    <asp:Label ID="lblCuenta_Contable" runat="server" Text="Cuenta Contable:"></asp:Label>
                                                                                                </td>
                                                                                                <td colspan="2" style="width: 60%" valign="top">
                                                                                                                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" 
                                                                                                                            onkeyup ="RefreshUpdatePanel();"
                                                                                                                            OnTextChanged="txtSearch_TextChanged" Width="98%"></asp:TextBox>
                                                                                                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                                                                            <ContentTemplate>
                                                                                                                                <asp:ListBox ID="ddlCuentas_Contables" runat="server" 
                                                                                                                                    OnSelectedIndexChanged="ddlCuentas_Contables_SelectedIndexChanged1" 
                                                                                                                                    Width="98%"></asp:ListBox>
                                                                                                                            </ContentTemplate>
                                                                                                                            <triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="txtSearch" >
                                                                            </asp:AsyncPostBackTrigger>
                                                                        </triggers>
                                                                                                        </asp:UpdatePanel>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                                                        ControlToValidate="ddlCuentas_Contables" ErrorMessage="*Cuenta Contable" 
                                                                                                        ValidationGroup="Detalle">*Requerido</asp:RequiredFieldValidator>                                                                                                                                                                                                                              
                                                                                                </td>
                                                                                                <tr>
                                                                                                    <td class="style5" valign="top" width="15%">
                                                                                                        &#160;</td>
                                                                                                    <td colspan="2" style="width: 60%" valign="top" width="45%">
                                                                                                        <table style="width:100%;" width="80%">
                                                                                                            <tr>
                                                                                                                <td class="style7" valign="top">
                                                                                                                    <asp:Label ID="lblCargo" runat="server" Text="Cargo:"></asp:Label>
                                                                                                                    <asp:TextBox ID="txtCargo" runat="server" 
                                                                                                                        onKeyDown="return enter_abono(event);" onkeyup="mascara(this,'C');">0</asp:TextBox>

                                                                                                                                                                                                                                          
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                                                                        ControlToValidate="txtCargo" ErrorMessage="*Cargo" 
                                                                                                                        ValidationGroup="Detalle">*Requerido</asp:RequiredFieldValidator>
                                                                                                                    <br />
                                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator104" 
                                                                                                                        runat="server" ControlToValidate="txtCargo" SetFocusOnError="True" 
                                                                                                                        ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$" 
                                                                                                                        ValidationGroup="Detalle">*Formato (999,999,999.99)</asp:RegularExpressionValidator>
                                                                                                                </td>
                                                                                                                <td align="right" class="style6" valign="top">
                                                                                                                    <asp:Label ID="lblAbono" runat="server" Text="Abono:"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" class="style2" valign="top">
                                                                                                                    <asp:TextBox ID="txtAbono" runat="server" 
                                                                                                                        onKeyDown="return enter_boton(event);" onkeyup="mascara(this,'A');">0</asp:TextBox>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                                                        ControlToValidate="txtAbono" ErrorMessage="*Abono" 
                                                                                                                        ValidationGroup="Detalle">*Requerido</asp:RequiredFieldValidator>
                                                                                                                    <br />
                                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                                                                                        ControlToValidate="txtAbono" SetFocusOnError="True" 
                                                                                                                        
                                                                                                                        ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$" 
                                                                                                                        ValidationGroup="Detalle">*Formato (999,999,999.99) 
                                                                                                                    Números</asp:RegularExpressionValidator>
                                                                                                                </td>
                                                                                                                <td valign="top" width="25%" class="derecha">
                                                                                                                    <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnAgregar_Click" ValidationGroup="Detalle" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="style5" width="15%">
                                                                                                        <asp:Label ID="lblNumero_Movimiento" runat="server" Text="# de Movto:" 
                                                                                                            Visible="False"></asp:Label>
                                                                                                    </td>
                                                                                                    <td width="45%">
                                                                                                        <asp:TextBox ID="txtNumero_Movimiento" runat="server" Visible="False"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td width="45%">
                                                                                                        &#160;</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="center" colspan="3" style="width: 100%">
                                                                                                        <table width="70%">
                                                                                                            <tr>
                                                                                                                <td align="right" width="45%">
                                                                                                                    <asp:Label ID="lblLeyTotal_Cargos" runat="server" Font-Bold="True" 
                                                                                                                        Text="TOTAL CARGOS:"></asp:Label>
                                                                                                                    <asp:Label ID="lblFormatoTotal_Cargos" runat="server" Font-Bold="True" 
                                                                                                                        Font-Size="Large" Text="0"></asp:Label>
                                                                                                                    <br />
                                                                                                                    <asp:Label ID="lblTotal_Cargos" runat="server" Visible="False"></asp:Label>
                                                                                                                </td>
                                                                                                                <td width="10%">
                                                                                                                    &#160;</td>
                                                                                                                <td align="left" width="45%">
                                                                                                                    <asp:Label ID="lblLeyTotal_Abonos" runat="server" Font-Bold="True" 
                                                                                                                        Text="TOTAL ABONOS:"></asp:Label>
                                                                                                                    <asp:Label ID="lblFormatoTotal_Abonos" runat="server" Font-Bold="True" 
                                                                                                                        Font-Size="Large" Text="0"></asp:Label>
                                                                                                                    <br />
                                                                                                                    <asp:Label ID="lblTotal_Abonos" runat="server" Visible="False"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <tr>
                                                                                                        <td align="center" colspan="3" valign="top" width="100%">
                                                                                                            <div class="scroll">
                                                                                                                <asp:Panel ID="pnlMnuArbol" runat="server">
                                                                                                                    <asp:GridView ID="grvPolizas_Detalle" runat="server" 
                                                                                                                        AutoGenerateColumns="False"  
                                                                                                                        OnRowDeleting="grvPolizas_Detalle_RowDeleting" 
                                                                                                                        Width="90%" onrowcancelingedit="grvPolizas_Detalle_RowCancelingEdit" 
                                                                                                                        onRowEditing="grvPolizas_Detalle_RowEditing"
                                                                                                                        OnRowUpdating="EditaRegistro" OnSelectedIndexChanged="grvPolizas_Detalle_SelectedIndexChanged" CssClass="mGrid" 
                                                                                                                        >                                                                                                                       
                                                                                                                        <Columns>
                                                                                                                            <asp:BoundField DataField="IdCuenta_Contable" HeaderText="IdCuenta_Contable" 
                                                                                                                                ReadOnly="True">
                                                                                    </asp:BoundField>
                                                                                                                            <asp:TemplateField HeaderText="# Movto">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblNumero_Movimiento_Aut" runat="server" 
                                                                                                Text="<%# (grvPolizas_Detalle.PageSize * grvPolizas_Detalle.PageIndex) + Container.DisplayIndex + 1 %>"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                                                            <asp:BoundField DataField="DescCuenta_Contable" HeaderText="Cuenta Contable" 
                                                                                                                                ReadOnly="True">
                                                                                    </asp:BoundField>
                                                                                                                            <asp:BoundField DataField="Cargo" ReadOnly="True">
                                                                                    </asp:BoundField>
                                                                                                                            <asp:BoundField DataField="Abono" ReadOnly="True">
                                                                                    </asp:BoundField>
                                                                                                                            <asp:BoundField DataField="Cargo" DataFormatString="{0:c}" HeaderText="Cargo" 
                                                                                                                                >
                                                                                    </asp:BoundField>
                                                                                                                            <asp:BoundField DataField="Abono" DataFormatString="{0:c}" HeaderText="Abono" 
                                                                                                                                >
                                                                                    </asp:BoundField>
                                                                                                                            <asp:CommandField ShowDeleteButton="True">
                                                                                    </asp:CommandField>
                                                                                                                            <asp:CommandField ShowEditButton="True">
                                                                                    </asp:CommandField>
                                                                                                                        </Columns>
                                                                                                                         <FooterStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                            <HeaderStyle CssClass="enc" />                                                
                                                                                            <AlternatingRowStyle CssClass="alt" />                                              
                                                                                                                    </asp:GridView>
                                                                                                                </asp:Panel>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                        <tr>
                                                                                                            <td align="center" colspan="3" style="width: 60%">
                                                                                                                &#160;</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="center" colspan="3" class="auto-style1">
                                                                                                                </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="center" colspan="3" style="width: 60%">
                                                                                                                &#160;</td>
                                                                                                        </tr>
                                                                                                    </tr>
                                                                                                </tr>
                                                                                            </tr>                                                                                            
                                                                                            </tr>
                                                                                        </table>                                                                                    
</ContentTemplate>                                                                                
</ajaxToolkit:TabPanel>
                                                                                        </ajaxToolkit:TabContainer>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="cuadro_botones">
                                                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="Poliza" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="cuadro_botones">
                                                                                        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn2" Height="30px" onclick="btnCancelar_Click" Text="Cancelar" Width="80px" />
                                                                                        &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn" OnClick="Button1_Click1" Text="Guardar" ValidationGroup="Poliza" />
                                                                                        <asp:HiddenField ID="hhdnGuardar" runat="server" />
                                                                                        <ajaxToolkit:ModalPopupExtender ID="modalGuardar" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlGuardar" TargetControlID="hhdnGuardar">
                                                                                        </ajaxToolkit:ModalPopupExtender>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">

                                                                                        <asp:Panel ID="pnlGuardar" runat="server" CssClass="TituloModalPopupMsg" 
                                                                                            Width="25%">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td align="center" colspan="2">
                                                                                                        &nbsp;</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="center" colspan="2">
                                                                                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" 
                                                                                                            AssociatedUpdatePanelID="UpdatePanel7">
                                                                                                            <progresstemplate>
                                                                                                                <asp:Image ID="Image8" runat="server" 
                                                                                                                AlternateText="Espere un momento, por favor.." Height="50px" 
                                                                                                                ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                                                                                                ToolTip="Espere un momento, por favor.." Width="50px" />
                                                                                                            </progresstemplate>
                                                                                                        </asp:UpdateProgress>
                                                                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:Button ID="btnSi" runat="server" CausesValidation="False" CssClass="btn" 
                                                                                                                    onclick="btnSi_Click" Text="SI" />
                                                                                                                &nbsp;<asp:Button ID="btnNo" runat="server" CausesValidation="False" CssClass="btn2" 
                                                                                                                    onclick="btnNo_Click" Text="NO" />
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                        <br />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <br />
                                                                                                        &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/images/Simbolo_Msg.png" />
                                                                                                        <br />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:Label ID="lblMsg_Confirmacion" runat="server" Font-Bold="True" 
                                                                                                                    Text="La poliza no esta cuadrada ¿desea guardar?"></asp:Label>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                            </asp:View>
<asp:View ID="View3" runat="server">
                            <asp:Panel ID="pnlCopiaPoliza" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="center" colspan="2" style="width: 100%" width="50%">
                                            <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblMsjPolizaCopia" runat="server" Font-Bold="True" 
                                                        ForeColor="#003399"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblMsjErrPolizaCopia" runat="server" ForeColor="Red"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%">
                                            <asp:Label ID="lblFecha_Copia" runat="server" Text="Nueva Fecha:"></asp:Label>
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtFecha_Copia" runat="server"
                                                        CssClass="box" Width="95px" ontextchanged="txtFecha_Copia_TextChanged" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                     
                                                    <img alt="Ver calendario" 
                                onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                src="http://sysweb.unach.mx/resources/imagenes/calendario.gif" style="cursor: pointer" />
                                                    <asp:Label ID="lblRFecha_Copia" runat="server" ForeColor="Red"></asp:Label>
                                                     
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" width="50%">
                                            <asp:Label ID="lblNumero_Poliza_Copia" runat="server" Text="Nuevo # de Póliza:"></asp:Label>
                                        </td>
                                        <td align="left" valign="top" width="50%">
                                            <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtNumero_Poliza_Copia" runat="server" 
                                                        onkeyup="MascaraNumPoliza(this,2);" Width="80px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator105" 
                                                        runat="server" ControlToValidate="txtNumero_Poliza_Copia" 
                                                        ErrorMessage="*6 Digitos" ValidationExpression="^[\s\S]{6,6}$" 
                                                        ValidationGroup="PolizaCopia"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                        ControlToValidate="txtNumero_Poliza_Copia" 
                                                        ErrorMessage="*Requerido" ValidationGroup="PolizaCopia"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator106" 
                                                        runat="server" ControlToValidate="txtNumero_Poliza_Copia" CssClass="MsjError" 
                                                        ErrorMessage="*Solo Números" SetFocusOnError="True" ValidationExpression="\d+" 
                                                        ValidationGroup="PolizaCopia"></asp:RegularExpressionValidator>
                                                    <asp:CustomValidator ID="ValidatorNumPolizaCopia" runat="server" 
                                                        ClientValidationFunction="ClientValidate" 
                                                        ControlToValidate="txtNumero_Poliza_Copia" ErrorMessage="*Número Reservado" 
                                                        ValidationGroup="PolizaCopia"></asp:CustomValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%">
                                            &nbsp;</td>
                                        <td width="50%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="cuadro_botones">
                                            <asp:UpdateProgress ID="UpdateProgress7" runat="server" 
                                                AssociatedUpdatePanelID="UpdatePanel48">
                                                <progresstemplate>
                                                    <asp:Image ID="Image9" runat="server" 
                                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                                    ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnCancelarCopia" runat="server" 
                                                        onclick="btnCancelarCopia_Click" Text="Cancelar" CssClass="btn2" />
                                                    &nbsp;<asp:Button ID="btnCopiar" runat="server" onclick="btnCopiar_Click" 
                                                        Text="Copiar" ValidationGroup="PolizaCopia" CssClass="btn" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" class="auto-style2" colspan="2">
                                         
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
 <div class="mensaje"> 
                                           <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                                               <ContentTemplate>
                                                   <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                         </div>              
            </td>
        </tr>
    </table>  
</asp:Content>
