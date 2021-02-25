                        <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCedula.aspx.cs" Inherits="SAF.Presupuesto.frmCedula"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script src="../../Scripts/jquery/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/select2/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
    <link href="https://sysweb.unach.mx/ingresos/Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />
    <%--MODIFICADO POR CARLOS EL 16ENERO2021--%>
    <style type="text/css">
              
        .auto-style4 {
            width: 188px;
        }
        .auto-style9 {
            width: 245px;
        }
        .auto-style21 {
            width: 202px;
        }
        .auto-style63 {
            width: 15%;
        }
        .auto-style70 {
            width: 330px;
        }
        .auto-style71 {
            width: 22%;
        }
        .col1 {
            width: 20%;
        }
        .auto-style72 {
        }
        .auto-style73 {
            width: 15%;
            height: 102px;
        }
        .auto-style74 {
            height: 102px;
        }
        .auto-style75 {
            width: 157px;
        }
        </style>
    <script type="text/javascript">
        function Autocomplete() {
            $(".select2").select2();
        }
        function jFechaIni(Ini) {
            $("#ctl00_MainContent_ddlMesFin").val(Ini);
        }
        function jFechaIniDet(Ini) {
            $("#ctl00_MainContent_TabContainer1_TabPanel2_ddlMesInicialDet").val(Ini);
        }
        function mascara(e, tipo) {
            if (tipo = "O") {
                var Valor = document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtImporteOrigen").value.toString().replace(/,/g, "");
                Valor = Valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtImporteOrigen").value = Valor;
            }

            if (tipo = "D") {
                var Valor = document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtImporteDestino").value.toString().replace(/,/g, "");
                Valor = Valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_txtImporteDestino").value = Valor;
            }
        }
         function MascaraNumPoliza(e,txtfechaDocumento) {
            var Valor = e.value;
            var Valor2 = e.value;

            document.getElementById(e.id).value = "";
            if (txtfechaDocumento == "1") {
                var Mes = document.getElementById('ctl00_MainContent_txtfechaDocumento').value;
            }
            else {
                var Mes = document.getElementById('ctl00_MainContent_txtfechaDocumento_Copia').value;
            }
            Mes = Mes.substr(3, 2);

            if (Valor.length > 2) {
                Valor = Valor.substr(2);
            }
            else {
                Valor = "";
            }
            var NumPoliza = Mes + Valor;
            if (NumPoliza.length <= 7) {
                document.getElementById(e.id).value = NumPoliza;
            }
            else {
                document.getElementById(e.id).value = Valor2.substr(0, 7);
            }

        }

    </script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div class="mensaje"> 
                                           <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                                               <ContentTemplate>
                                                   <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
        </div>    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">          
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblDocumento" runat="server" Font-Bold="True" Font-Size="15pt" Text="Cédula"></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table style="width:100%;">
                        <tr>
                            <td class="col1">
                                <asp:Label ID="lblDependencia0" runat="server" Text="Centro Contable"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:UpdatePanel ID="UpdatePanel126" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCentroContable" runat="server" AutoPostBack="True"  Width="100%" OnSelectedIndexChanged="DDLCentroContable_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                         </tr>
                        </table>                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td valign="top">
                                                <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                                                    <ContentTemplate>
                                                        <asp:MultiView ID="MultiView1" runat="server">
                                                            <asp:View ID="View1" runat="server">
                                                                <table style="width:100%;">                                                                    
                                                                    <tr>
                                                                        <td class="col1">
                                                                            <asp:Label ID="lblTipo0" runat="server" Text="Tipo"></asp:Label>
                                                                        </td>
                                                                        <td class="col1">
                                                                            <asp:DropDownList ID="ddlTipo" runat="server"  Width="150px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="col1">&nbsp;</td>                                                                        
                                                                        <td class="col1">
                                                                            <asp:Label ID="lblStatus0" runat="server" Text="Estatus"></asp:Label>
                                                                        </td>
                                                                        <td class="col1">
                                                                            <asp:DropDownList ID="ddlStatus" runat="server" Width="150px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="col1">
                                                                            <asp:Label ID="lblMesIni" runat="server" Text="Mes inicial" Width="160px"></asp:Label>
                                                                        </td>
                                                                        <td class="col1">
                                                                            <asp:DropDownList ID="ddlMesIni" runat="server" onChange="jFechaIni(this.value);" Width="150px">
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
                                                                        </td>
                                                                        <td class="col1">&nbsp;</td>                                                                        
                                                                        <td class="col1">
                                                                            <asp:Label ID="lblMesFin" runat="server" Text="Mes final"></asp:Label>
                                                                        </td>
                                                                        <td class="col1">
                                                                            <asp:DropDownList ID="ddlMesFin" runat="server" Width="150px">
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
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="col1" valign="top">
                                                                            <asp:Label ID="lblbuscar0" runat="server" Text="#Folio/Concepto" Width="160px"></asp:Label>
                                                                        </td>
                                                                        <td colspan="4" valign="top">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td width="80%">
                                                                                        <asp:TextBox ID="txtbuscar" runat="server" CssClass="textbuscar" placeholder="#Documento/Concepto" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:UpdatePanel ID="updBtns" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:ImageButton ID="BTNbuscar" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="btnBuscar_Click" />
                                                                                                &nbsp; &nbsp;
                                                                                                <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png"  ValidationGroup="Agregar" OnClick="btnNuevo_Click" />
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" colspan="2">
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLCentroContable" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="Agregar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="5">
                                                                            <asp:UpdateProgress ID="updPrBtns" runat="server" AssociatedUpdatePanelID="updBtns">
                                                                                <progresstemplate>
                                                                                            <asp:Image ID="imgBtns" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                                                        </progresstemplate>
                                                                            </asp:UpdateProgress>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="centro" colspan="5"><%--<asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel103">
                                                                                        <progresstemplate>
                                                                                            <asp:Image ID="Image1q1" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                                                        </progresstemplate>
                                                                                    </asp:UpdateProgress>--%>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div align="center">
                                                                                <asp:UpdateProgress ID="UpdProDocumentos" runat="server" AssociatedUpdatePanelID="UpdDocumentos">
                                                                                    <progresstemplate>
                                                                                                <asp:Image ID="imgDocumentos" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                                                            </progresstemplate>
                                                                                </asp:UpdateProgress>
                                                                            </div>
                                                                            <asp:UpdatePanel ID="UpdDocumentos" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:GridView ID="grdDocumentos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." OnPageIndexChanging="grdDocumentos_PageIndexChanging" OnSelectedIndexChanged="grdDocumentos_SelectedIndexChanged" PageSize="20" Width="100%" OnRowDeleting="grdDocumentos_RowDeleting">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                                            <asp:BoundField DataField="Dependencia" HeaderText="DEPENDENCIA" />
                                                                                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                                                                                            <asp:BoundField DataField="No_Documento" HeaderText="CÉDULA" />
                                                                                            <asp:BoundField DataField="Fecha" HeaderText="FECHA" />
                                                                                            <asp:BoundField DataField="Status" HeaderText="ESTATUS" />
                                                                                            <asp:BoundField DataField="Concepto" HeaderText="CONCEPTO" />
                                                                                            <asp:BoundField DataField="Origen" DataFormatString="{0:c}" HeaderText="IMPORTE" />
                                                                                            <asp:BoundField DataField="Destino" DataFormatString="{0:c}" HeaderText="DESTINO" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="linkBttnEditar" runat="server" CommandName="Select" Visible='<%# Bind("Opcion_Modificar") %>' OnClick="linkBttnEditar_Click" >Editar</asp:LinkButton>
                                                                                                    <asp:Label ID="lblEditar" runat="server" ForeColor="#6B696B" Text="Editar" Visible='<%# Bind("Opcion_Modificar2") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" onclientclick="return confirm('¿Desea eliminar el Documento?');" Visible='<%# Bind("Opcion_Eliminar") %>'>Eliminar</asp:LinkButton>
                                                                                                            <asp:Label ID="lblEliminar" runat="server" ForeColor="#6B696B" Text="Eliminar" Visible='<%# Bind("Opcion_Eliminar2") %>'></asp:Label>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
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
                                                                        <td class="cuadro_botones" colspan="5">
                                                                            <asp:ImageButton ID="imgBttnPDF" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnPDF_Click" title="Reporte PDF" />
                                                                            <asp:ImageButton ID="imgBttnPDF_Lotes" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf2.png" OnClick="imgBttnPDF_Lotes_Click" title="Reporte/Lote" ValidationGroup="Agregar" />
                                                                            <asp:ImageButton ID="imgBttnXLS" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="imgBttnXLS_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:View>
                                                            <asp:View ID="View2" runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel106" runat="server">
                                                                    <ContentTemplate>
                                                                        <table style="width:100%;">
                                                                            
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <table style="width:100%;">
                                                                                        <tr>
                                                                                            <td class="col1" valign="top">
                                                                                                <asp:Label ID="lblTipoEnc" runat="server" Text="Tipo"></asp:Label>
                                                                                            </td>
                                                                                            <td valign="top" class="col1">
                                                                                                <asp:DropDownList ID="ddlTipoEnc" runat="server" OnSelectedIndexChanged="ddlTipoEnc_SelectedIndexChanged" Width="150px" AutoPostBack="True">
                                                                                                </asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTipoEnc" ErrorMessage="*Tipo requerido" InitialValue="0" ValidationGroup="GpoCodProg"></asp:RequiredFieldValidator>
                                                                                            </td>                                                                                            
                                                                                            <td class="col1" valign="top">&nbsp;</td>
                                                                                            <td class="col1" valign="top" >
                                                                                                <asp:Label ID="lblStatusEncLey" runat="server" Text="Estatus"></asp:Label>
                                                                                            </td>
                                                                                            <td class="col1" valign="top">
                                                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:DropDownList ID="ddlStatusEnc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatusEnc_SelectedIndexChanged" Width="200px">
                                                                                                        </asp:DropDownList>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                                <%--<asp:Label ID="lblStatusEnc" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label>--%>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="validadorStatus" runat="server" ControlToValidate="ddlStatusEnc" ErrorMessage="*Estatus requerido" InitialValue="X" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" CssClass="ajax__myTab" Width="100%" AutoPostBack="True" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Datos Grales.">
                                                                                                    <HeaderTemplate>
                                                                                                        Encabezado
                                                                                                    
</HeaderTemplate>
                                                                                                    



<ContentTemplate>
                                                                                                        &#160;<asp:UpdatePanel ID="UpdatePanel107" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <table style="width:100%;">
                                                                                                                    
                                                                                                                    <tr>
                                                                                                                         <td class="auto-style75">
                                                                                                                            <asp:Label ID="lblevento" runat="server" Text="Evento"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel127" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:DropDownList ID="ddlevento" runat="server" OnSelectedIndexChanged="ddlevento_SelectedIndexChanged" Width="250px" AutoPostBack="True">
                                                                                                                                    </asp:DropDownList>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                        <td><asp:Label ID="lblCedula" runat="server" Text="Cédula"></asp:Label></td>
                                                                                                                        <td><asp:TextBox ID="txtCedula" runat="server" Width="95px" Enabled="False" ></asp:TextBox></td>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblPoliza" runat="server" Text="Póliza"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtPoliza" runat="server"  Width="95px" MaxLength="7"></asp:TextBox>
                                                                                                                            <asp:RequiredFieldValidator ID="RFVPoliza" runat="server" ErrorMessage="*" ControlToValidate="txtPoliza" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                        </tr>
                                                                                                                        
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style63" valign="top">
                                                                                                                            <asp:Label ID="lblcuenta" runat="server" Text="Cuenta de banco" Visible="False"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td colspan="5" valign="top">
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:DropDownList ID="DDLCuenta_Banco" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCuenta_Banco_SelectedIndexChanged" Visible="False" Width="100%">
                                                                                                                                    </asp:DropDownList>
                                                                                                                                    <br />
                                                                                                                                    <asp:TextBox ID="txtcuenta" runat="server" Width="100%"></asp:TextBox>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style63">
                                                                                                                            &#160;</td>
                                                                                                                        <td>
                                                                                                                            
                                                                                                                        </td>
                                                                                                                       
                                                                                                                        <td class="auto-style75">
                                                                                                                            <asp:Label ID="lbldoc_simultaneo" runat="server" Text="Doctos. simultáneos"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel125" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:RadioButtonList ID="rbtdoc_simultaneo" runat="server" RepeatDirection="Horizontal" Width="95px">
                                                                                                                                       <asp:ListItem Selected="True" Value="S">Si</asp:ListItem>
                                                                                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                                                                                    </asp:RadioButtonList>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                        <td></td>
                                                                                                                        <td></td>
                                                                                                                    </tr>
                                                                                                                    
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style63">
                                                                                                                            <asp:Label ID="lblNumero_Cheque" runat="server" Text="Número cheque"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtNumero_Cheque" runat="server" Width="95px"></asp:TextBox>
                                                                                                                            <asp:RequiredFieldValidator ID="RFVNumCheque" runat="server" ControlToValidate="txtNumero_Cheque" ErrorMessage="*" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblfechaDocumento" runat="server" Text="Fecha"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtfechaDocumento" runat="server" CssClass="box" Enabled="false" Width="95px" AutoPostBack="True" OnTextChanged="txtfechaDocumento_TextChanged"></asp:TextBox>
                                                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtfechaDocumento" />
                                                                                                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif"  />
                                                                                                                            <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtfechaDocumento" ErrorMessage="*" InitialValue="T" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblImporteOperacion" runat="server" Text="Importe operación"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:UpdatePanel ID="UpdPnlImporteOperacion" runat="server">
                                                                                                                        <ContentTemplate>
                                                                                                                            <%--<asp:TextBox ID="txtImporteOperacion" runat="server" Width="95px" AutoPostBack="True"  OnTextChanged="txtImporteOperacion_TextChanged" Enabled="False">0</asp:TextBox>--%>
                                                                                                                            <asp:Label ID="lblImporte_Operacion" runat="server" Text="0.00"></asp:Label>
                                                                                                                            </ContentTemplate>
                                                                                                                                </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                       
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblImporteCheque" runat="server" Text="Importe cheque"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            
                                                                                                                            <asp:TextBox ID="txtImporteCheque" runat="server" Width="95px"  >0.00</asp:TextBox>
                                                                                                                        
                                                                                                                            <asp:RequiredFieldValidator ID="RFVImporteCheque" runat="server" ErrorMessage="*" ControlToValidate="txtImporteCheque" ValidationGroup="Guardar" InitialValue="0.00"></asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                        
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblImporteISR" runat="server" Text="Importe ISR" Visible="False"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtImporteISR" runat="server" Width="95px"   Visible="False">0.00</asp:TextBox>
                                                                                                                        
                                                                                                                            <asp:RequiredFieldValidator ID="RFVImporteISR" runat="server" ErrorMessage="*" ControlToValidate="txtImporteISR" ValidationGroup="Guardar" InitialValue="0.00"></asp:RequiredFieldValidator>
                                                                                                                            </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style73" valign="top">
                                                                                                                            <asp:Label ID="lblConcepto" runat="server" Text="Concepto"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td colspan="5" valign="top" class="auto-style74">
                                                                                                                            <asp:TextBox ID="txtConcepto" runat="server" Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                                                                                            <br />
                                                                                                                            <asp:RequiredFieldValidator ID="RFVConcepto" runat="server" ControlToValidate="txtConcepto" ErrorMessage="*Concepto Requerido" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style63" valign="top">
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel119" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:Label ID="lblAutorizacion" runat="server" Text="Autorización" Visible="False"></asp:Label>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                        <td colspan="5" valign="top">
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel120" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:TextBox ID="txtAutorizacion" runat="server" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style63" valign="top">
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:Label ID="lblCancelacion" runat="server" Text="Cancelación" Visible="False"></asp:Label>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                        <td colspan="5" valign="top">
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:TextBox ID="txtCancelacion" runat="server" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="6">&#160;</td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="cuadro_botones" colspan="5"></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    
</ContentTemplate>
                                                                                                



</ajaxToolkit:TabPanel>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalles">
                                                                                                    <HeaderTemplate>
                                                                                                        Detalle
                                                                                                    
</HeaderTemplate>
                                                                                                    



<ContentTemplate>
                                                                                                        <table style="width:100%;">
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top" style="width:10%">
                                                                                                                    <asp:UpdatePanel ID="UpdatePanel124" runat="server"><ContentTemplate>
                                                                                                                            <asp:RadioButtonList ID="rbtOrigen_Destino" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtOrigen_Destino_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                                                                                <asp:ListItem Value="O">Origen</asp:ListItem>
                                                                                                                                <asp:ListItem Value="D">Destino</asp:ListItem>
                                                                                                                            </asp:RadioButtonList>
                                                                                                                            <asp:RequiredFieldValidator ID="validadorTipo" runat="server" ControlToValidate="rbtOrigen_Destino" ErrorMessage="*Tipo Requerido" ValidationGroup="GpoCodProg"></asp:RequiredFieldValidator>
                                                                                                                        
</ContentTemplate>
</asp:UpdatePanel>




                                                                                                                </td>
                                                                                                                <td valign="top">
                                                                                                                    <asp:UpdatePanel ID="updPnlDepen" runat="server"><ContentTemplate>
                                                                                                                            <asp:DropDownList ID="ddlDepen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepen_SelectedIndexChanged" Width="100%">
                                                                                                                            </asp:DropDownList>
                                                                                                                        
</ContentTemplate>
</asp:UpdatePanel>




                                                                                                                    <asp:UpdateProgress ID="updProDepen" runat="server" AssociatedUpdatePanelID="updPnlDepen"><progresstemplate>
                                                                                                                            <asp:Image ID="imgDepen" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                        
</progresstemplate>
</asp:UpdateProgress>




                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top">
                                                                                                                    <asp:Label ID="lblCapitulo" runat="server" Text="Capitulo"></asp:Label>




                                                                                                                </td>
                                                                                                                <td valign="top">
                                                                                                                    <asp:UpdatePanel ID="updPnlCapitulo" runat="server"><ContentTemplate>
                                                                                                                    <asp:DropDownList ID="ddlCapitulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCapitulo_SelectedIndexChanged" Width="350px"></asp:DropDownList>
                                                                                                                         </ContentTemplate></asp:UpdatePanel>
            



                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top">
                                                                                                                    <asp:Label ID="lblFuenteF" runat="server" Text="Fuente"></asp:Label>




                                                                                                                </td>
                                                                                                                <td valign="top">
                                                                                                                     <asp:UpdatePanel ID="updPnlFuenteF" runat="server"><ContentTemplate>
                                                                                                                    <asp:DropDownList ID="ddlFuente_F" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_F_SelectedIndexChanged" Width="100%"></asp:DropDownList>

                                                                                                                    
</ContentTemplate>
</asp:UpdatePanel>
                                                                                                                   <asp:UpdateProgress ID="updProFuenteF" runat="server" AssociatedUpdatePanelID="updPnlCapitulo">
                                                                                                                        <ProgressTemplate>
                                                                                                                            <asp:Image ID="imgFuenteF" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                        </ProgressTemplate>
                                                                                                                    </asp:UpdateProgress>


                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            </table>
    
    <asp:Panel ID="penel_detalle" runat="server" Visible="False">

        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top">
                                                                                                                    <asp:Label ID="lblCodigoProg" runat="server" Text="Código Programático"></asp:Label>


                                                                                                                </td>
                                                                                                                <td colspan="5" valign="top">
                                                                                                                     <asp:UpdatePanel ID="updPnlCodProg" runat="server"><ContentTemplate>
                                                                                                                    <asp:DropDownList ID="ddlCodigoProg" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="LstCodigoProg_SelectedIndexChanged" Width="100%">
                                                                                                                    </asp:DropDownList>
                                                                                                                            
</ContentTemplate>
</asp:UpdatePanel>


                                                                                                                    <asp:UpdateProgress ID="updProCodProg" runat="server" AssociatedUpdatePanelID="updPnlFuenteF"><ProgressTemplate>
                                                                                                                            <asp:Image ID="imgCodProg" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                        
</ProgressTemplate>
</asp:UpdateProgress>


                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top">&#160;</td>
                                                                                                                <td class="auto-style70" valign="top">
                                                                                                                    &#160;</td>
                                                                                                                <td class="auto-style71" valign="top">&#160;</td>
                                                                                                                <td class="auto-style4" valign="top">
                                                                                                                    <asp:Label ID="lblLeyDisponible" runat="server" Font-Bold="True" Font-Size="18px" Text="Disponible"></asp:Label>




                                                                                                                </td>
                                                                                                                <td class="auto-style21" valign="top">
                                                                                                                    <asp:UpdatePanel ID="updPnlDisponible1" runat="server"><ContentTemplate>
                                                                                                                            <asp:Label ID="lblFormatoDisponible" runat="server" Font-Bold="True" Font-Size="18px" Text="0"></asp:Label>
                                                                                                                            <asp:Label ID="lblDisponible" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                                                        
</ContentTemplate>
</asp:UpdatePanel>




                                                                                                                </td>
                                                                                                                <td class="auto-style9" valign="top">

                                                                                                                    <asp:UpdateProgress ID="updProDisponible" runat="server" AssociatedUpdatePanelID="updPnlCodProg">
                                                                                                                        <ProgressTemplate>
                                                                                                                            <asp:Image ID="imgDisponible" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                        </ProgressTemplate>
                                                                                                                    </asp:UpdateProgress>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblPartida" runat="server" Text="Concepto del Gasto"></asp:Label>




                                                                                                                </td>
                                                                                                                <td colspan="2">
                                                                                                                    <asp:TextBox ID="txtDesPartida" runat="server" Width="100%"></asp:TextBox>




                                                                                                                </td>
                                                                                                                <td></td>
                                                                                                                <td></td>
                                                                                                                <td></td>
                                                                                                            </tr>
                                                                                                            
                                                                                                           
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblReferencia" runat="server" Text="Doc. referencia"></asp:Label>




                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtReferencia" runat="server" Width="100px"></asp:TextBox>




                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblTipoBeneficiario" runat="server" Text="Tipo beneficiario"></asp:Label>




                                                                                                                </td>
                                                                                                                <td colspan="2">
                                                                                                                    <asp:DropDownList ID="DDLTipoBeneficiario" runat="server" Width="100%" OnSelectedIndexChanged="DDLTipoBeneficiario_SelectedIndexChanged"><asp:ListItem>PROVEEDOR</asp:ListItem>
<asp:ListItem>EMPLEADO</asp:ListItem>
<asp:ListItem>OTROS.</asp:ListItem>
<asp:ListItem Value="X">INSTITUCION</asp:ListItem>
</asp:DropDownList>



                                                                                                                </td>
                                                                                                                
                                                                                                                <td>
                                                                                                                    


                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblClaveBeneficiario" runat="server" Text="Clave beneficiario"></asp:Label>


                                                                                                                </td>
                                                                                                                
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_clave_beneficiario" runat="server"></asp:TextBox>


                                                                                                                </td>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblBeneficiario" runat="server" Text="Nombre/Descripcion"></asp:Label>




                                                                                                                </td>
                                                                                                                <td colspan="2">
                                                                                                                    <asp:TextBox ID="txtBeneficiario" runat="server" Width="100%"></asp:TextBox>




                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top">
                                                                                                                    <asp:UpdatePanel ID="UpdatePanel115" runat="server"><ContentTemplate>
                                                                                                                            <asp:Label ID="lblImporteOrigen" runat="server" Text="Importe"></asp:Label>
                                                                                                                        
</ContentTemplate>
</asp:UpdatePanel>




                                                                                                                </td>
                                                                                                                <td class="auto-style70" valign="top">
                                                                                                                    <asp:UpdatePanel ID="updPnlImpOrigen" runat="server"><ContentTemplate>
                                                                                                                            <asp:TextBox ID="txtImporteOrigen" runat="server" AutoPostBack="True"  OnTextChanged="txtImporteOrigen_TextChanged" Width="100px">0</asp:TextBox>
                                                                                                                        
</ContentTemplate>
</asp:UpdatePanel>




                                                                                                                    <asp:UpdateProgress ID="updPrgImpMen0" runat="server" AssociatedUpdatePanelID="updPnlImpOrigen"><progresstemplate>
                                                                                                                            <asp:Image ID="imgImpMen0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                        
</progresstemplate>
</asp:UpdateProgress>




                                                                                                                    <br />
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtImporteOrigen" ErrorMessage="RequiredFieldValidator" ValidationGroup="GpoCodProg">*Requerido</asp:RequiredFieldValidator>




                                                                                                                    <br />
                                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator104" runat="server" ControlToValidate="txtImporteOrigen" SetFocusOnError="True" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$" ValidationGroup="GpoCodProg">*Formato (999,999,999.99)</asp:RegularExpressionValidator>




                                                                                                                </td>
                                                                                                                <td class="auto-style71" valign="top">
                                                                                                                    <asp:Button ID="btnAgregarDet" runat="server" CssClass="btn" OnClick="btnAgregarDet_Click" Text="AGREGAR" ValidationGroup="GpoCodProg" />




                                                                                                                </td>
                                                                                                                <td class="auto-style4" valign="top">
                                                                                                                    &#160;</td>
                                                                                                                <td class="auto-style21" valign="top">
                                                                                                                    &#160;</td>
                                                                                                                <td class="auto-style9" valign="top">
                                                                                                                    &#160;</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="auto-style72" valign="top">&#160;</td>
                                                                                                                <td class="auto-style70" valign="top">
                                                                                                                    &#160;</td>
                                                                                                                <td class="auto-style71" valign="top">&#160;</td>
                                                                                                                <td class="auto-style4" valign="top">&#160;</td>
                                                                                                                <td class="auto-style21" valign="top">&#160;</td>
                                                                                                                <td class="auto-style9" valign="top">&#160;</td>
                                                                                                            </tr>
        
                                                                                        
                                                                     </table>

    </asp:Panel>


    <table width="100%">
    <tr>
        <td align="center">
            <table width="70%">
                <tr>
                    <td align="right" width="45%">
                        <br />
                    </td>
                    <td width="10%">&#160;</td>
                    <td align="left" width="45%">
                        <asp:Label ID="lblLeyTotal_Origen" runat="server" Font-Bold="True" Text="TOTAL ORIGEN"></asp:Label>


                        <asp:Label ID="lblFormatoTotal_Origen" runat="server" Font-Bold="True" Font-Size="Large" Text="0"></asp:Label>


                        <br />
                        <asp:Label ID="lblTotal_Origen" runat="server" Visible="False"></asp:Label>


                    </td>
                </tr>
            </table>
      </td>
    </tr>

<tr>
    <td align="center">
        <asp:UpdatePanel ID="UpdatePanel122" runat="server"><ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel123" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsjCP" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </tr>                                                                                                
</ContentTemplate>
</asp:UpdatePanel>




                                                                                                               
       
                                                                                                            <tr>
                                                                                                                <td align="center">
                                                                                                                    <asp:UpdateProgress ID="updPrgDetalles" runat="server" AssociatedUpdatePanelID="updPnlDetalles"><progresstemplate>
                                                                                                                            <asp:Image ID="imgDetalles" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                        </td>
                                                                                                            </tr>
</progresstemplate>
</asp:UpdateProgress>




                                                                                                                
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:UpdatePanel ID="updPnlDetalles" runat="server"><ContentTemplate>
                                                                                                                            <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se han agregado Códigos Programáticos." OnRowCancelingEdit="grdDetalles_RowCancelingEdit" OnRowDeleting="grdDetalles_RowDeleting" OnRowEditing="grdDetalles_RowEditing" OnRowUpdating="EditaRegistro" Width="100%" OnSelectedIndexChanged="grdDetalles_SelectedIndexChanged">
                                                                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                                                                <Columns>
                                                                                                                                    <asp:TemplateField HeaderText="# Movto">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lblNumero_Movimiento_Aut" runat="server" Text="<%# (grdDetalles.PageSize * grdDetalles.PageIndex) + Container.DisplayIndex + 1 %>"></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:BoundField DataField="Tipo" HeaderText="TIPO" ReadOnly="True">
                                                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Ur_clave" HeaderText="RADIC." ReadOnly="True" />
                                                                                                                                    <asp:BoundField DataField="Id_Codigo_Prog" ReadOnly="True" />
                                                                                                                                    <asp:BoundField DataField="Desc_Codigo_Prog" HeaderText="CP" ReadOnly="True" />
                                                                                                                                    <asp:TemplateField HeaderText="CÓDIGO PROGRAMATICO">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lblCodigoProg" runat="server" Text='<%# Bind("Desc_Codigo_Prog") %>' ToolTip='<%# Bind("Desc_Partida") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:BoundField DataField="Mes_inicial" HeaderText="INICIAL" ReadOnly="True">
                                                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Mes_final" HeaderText="FINAL" ReadOnly="True">
                                                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Cuenta_banco" HeaderText="CTA." />
                                                                                                                                    <asp:BoundField DataField="Importe_origen" />
                                                                                                                                    <asp:BoundField DataField="Importe_destino" />
                                                                                                                                    <asp:BoundField DataField="Importe_origen" DataFormatString="{0:c}" HeaderText="IMPORTE ORIGEN" ReadOnly="True">
                                                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Importe_destino" DataFormatString="{0:c}" HeaderText="IMPORTE DESTINO" ReadOnly="True">
                                                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Importe_mensual" DataFormatString="{0:c}" HeaderText="IMPORTE MENSUAL" ReadOnly="True">
                                                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <%--<asp:CommandField ShowEditButton="True" />--%>
                                                                                                                                    <asp:CommandField ShowDeleteButton="True" />
                                                                                                                                </Columns>
                                                                                                                                <FooterStyle CssClass="enc" />
                                                                                                                                <HeaderStyle CssClass="enc" />
                                                                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                                                                <SelectedRowStyle CssClass="sel" />
                                                                                                                            </asp:GridView>   
                                                                                                                        </td>
                                                                                                            </tr>                                                                                                           
                                                                                                        </table>

</ContentTemplate>
</asp:UpdatePanel>




                                                                                                        <br />
                                                                                                        <br />
                                                                                                    
</ContentTemplate>
                                                                                                



</ajaxToolkit:TabPanel>
                                                                                            </ajaxToolkit:TabContainer>
                                                                                </td>
                                                                            </tr>                                                                            
                                                                            <tr>
                                                                                <td class="cuadro_botones">
                                                                                    <asp:UpdatePanel ID="UpdatePanel112" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="Guardar" />
                                                                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn2" OnClick="btnCancelar_Click" Text="Cancelar" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <div class="mensaje">
                                                                                        <asp:UpdatePanel ID="updPnlError" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:Label ID="lblErrorDet" runat="server" Text=""></asp:Label>
<%--                                                                                                <br />
                                                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="DATOS REQUERIDOS:" ValidationGroup="Guardar" />--%>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="centro">
                                                                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel112">
                                                                                        <progresstemplate>
                                                                                                    <asp:Image ID="Image1q2" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                                                                </progresstemplate>
                                                                                    </asp:UpdateProgress>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </asp:View>
                                                            <asp:View ID="View3" runat="server">
                                                            </asp:View>
                                                            <asp:View ID="View4" runat="server">
                                                            </asp:View>
                                                        </asp:MultiView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        
                                    </table>
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
                
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
