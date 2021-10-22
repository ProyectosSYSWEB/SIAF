<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="SAF.Presupuesto.Reportes.frmReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 591px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress><asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
              <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <table class="tabla_contenido">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label4" runat="server" Text="Dependencia inicial"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlDependenciaInicial" runat="server" Width="100%" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label56" runat="server" Text="Dependencia final"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlDependenciaFinal" runat="server" Width="100%"  >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Reporte"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLReporte_v1" runat="server" Width="75%" >
                                                 <asp:ListItem Value="RP001">RP001 - Analítico anual por etapa y fuente de financiamiento</asp:ListItem>
                                                <asp:ListItem Value="RP002">RP002 - Analítico por subprograma</asp:ListItem>
                                                <asp:ListItem Value="RP004">RP004 - Analítico anual por etapa y proyecto</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                         <td style="width:20%">
                                            <asp:Label ID="Label7" runat="server" Text="Etapa"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="ddltipo" runat="server" Width="85%">
                                                <asp:ListItem Value="AUMENTO">Aumento</asp:ListItem>
                                                <asp:ListItem Value="AUTORIZADO">Autorizado</asp:ListItem>
                                                <asp:ListItem Value="MODIFICADO">Modificado</asp:ListItem>
                                                <asp:ListItem Value="DISMINUCION">Disminución</asp:ListItem>
                                                <asp:ListItem Value="COMPROMETIDO">Comprometido</asp:ListItem>
                                                <asp:ListItem Value="XMINISTRAR">Por ministrar</asp:ListItem>
                                                <asp:ListItem Value="MINISTRADO">Ministrado</asp:ListItem>
                                                <asp:ListItem Value="EJERCIDO">Ejercido</asp:ListItem>
                                                <asp:ListItem Value="XEJERCER">Por ejercer</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                         <td style="width:20%">
                                            <asp:Label ID="Label8" runat="server" Text="Dígito ministrador"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="ddlministrable" runat="server" Width="85%">
                                                <asp:ListItem Value="1">Ministrable</asp:ListItem>
                                                <asp:ListItem Value="2">No ministrable</asp:ListItem>
                                                <asp:ListItem Value="3">Todos</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:UpdatePanel ID="updPnlBuscar_v1" runat="server">
                                                <ContentTemplate>
                                            <asp:Button ID="btnBuscar_v1" runat="server"  OnClick="btnBuscar_v1_Click"
                                                        Text="Buscar"   CssClass="btn" CausesValidation="False" />
                                                     </ContentTemplate>
                                                </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdateProgress ID="updProBuscar_v1" runat="server" AssociatedUpdatePanelID="updPnlBuscar_v1">
                                                <progresstemplate>
                                                    <asp:Image ID="Image_v1" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdCapitulo" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkcapitulo" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkCapitulos_v1" runat="server"  OnClick="btnChkCapitulos_v1_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdFuente" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkfuente" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FUENTE" HeaderText="FUENTE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="FUENTE DE FINANCIAMIENTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkFuentes_v1" runat="server"  OnClick="btnChkFuentes_v1_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdProyectos_v1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkproyecto" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="PROYECTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkProyectos_v1" runat="server"  OnClick="btnChkProyectos_v1_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="updPnlBotones_v1" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf" title="Reporte PDF" />
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" AssociatedUpdatePanelID="updPnlBotones_v1">
                                                <progresstemplate>
                                                    <asp:Image ID="Image_Botones_v1" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel106" runat="server">
                            <ContentTemplate>
                                <table style="width:100%">
                                    <tr>
                                        <td style="width:25%">
                                            <asp:Label ID="Label9" runat="server" Text="Quincena"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel107" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDL_Quincena" runat="server" OnSelectedIndexChanged="DDL_Quincena_SelectedIndexChanged" AutoPostBack="True" Width="200px">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="UpdatePanel107">
                                                <progresstemplate>
                                                    <asp:Image ID="Image1q3" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="Tipo empleado"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel109" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDL_Tipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Tipo_SelectedIndexChanged" Width="200px">
                                                        <asp:ListItem Value="T">Todos</asp:ListItem>
                                                        <asp:ListItem Value="A">Administrativo de base</asp:ListItem>
                                                        <asp:ListItem Value="C">Confianza</asp:ListItem>
                                                        <asp:ListItem Value="D">Docente</asp:ListItem>
                                                        <asp:ListItem Value="M">PEMEX</asp:ListItem>
                                                        <asp:ListItem Value="U">Turneros</asp:ListItem>
                                                        <asp:ListItem Value="H">Honorarios</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label10" runat="server" Text="Nómina"></asp:Label>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:DropDownList ID="DDL_Nomina" runat="server" Width="400px" OnSelectedIndexChanged="DDL_Nomina_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style2"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="Estatus"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Status" runat="server" Width="200px">
                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                                <asp:ListItem Value="A">Activo</asp:ListItem>
                                                <asp:ListItem Value="P">Permiso sin goce de sueldo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel108" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="pdf_tempo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF" OnClick="pdf_tempo_Click" />
                                                    <asp:ImageButton ID="excel_temporal" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="excel_temporal_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>                                   
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel108">
                                                <progresstemplate>
                                                    <asp:Image ID="Image1q2" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:25%">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text="Ejercicio"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEjercicio" runat="server">
                                                <asp:ListItem Value="2014">Ejercicio 2014</asp:ListItem>
                                                <asp:ListItem Value="2015">Ejercicio 2015</asp:ListItem>
                                                <asp:ListItem Value="2016">Ejercicio 2016</asp:ListItem>
                                                <asp:ListItem Value="2017">Ejercicio 2017</asp:ListItem>
                                                <asp:ListItem Value="2018">Ejercicio 2018</asp:ListItem>
                                                <asp:ListItem Value="2019">Ejercicio 2019</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Text="Semestre" Visible="False"></asp:Label>
                                            <asp:DropDownList ID="ddlSemestre9" runat="server" Visible="False">
                                                <asp:ListItem Value="2">Agosto/Diciembre</asp:ListItem>
                                                <asp:ListItem Value="1">Enero/Junio</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Text="Tipo empleado"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Tipo0" runat="server" AutoPostBack="True" Width="200px">
                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                                <asp:ListItem Value="A">Adminitrativo de base</asp:ListItem>
                                                <asp:ListItem Value="C">Confianza</asp:ListItem>
                                                <asp:ListItem Value="D">Docente</asp:ListItem>
                                                <asp:ListItem Value="P">PROMEP</asp:ListItem>
                                                <asp:ListItem Value="M">PEMEX</asp:ListItem>
                                                <asp:ListItem Value="U">Turneros</asp:ListItem>
                                                <asp:ListItem Value="H">Honorarios</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td >
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label21" runat="server" Text="Estatus"></asp:Label>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:DropDownList ID="DDL_Status1" runat="server" Width="200px">
                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                                <asp:ListItem Value="A">Activo</asp:ListItem>
                                                <asp:ListItem Value="P">Permiso sin goce de sueldo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style2">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="cuadro_botones">
                                            <asp:UpdatePanel ID="UpdatePanel110" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="pdf_tempo0" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="pdf_tempo0_Click" title="Reporte PDF" />
                                                    <asp:ImageButton ID="excel_temporal0" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="excel_temporal0_Click" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel111" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="Label15" runat="server" Text="Tipo empleado"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel113" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDL_Tipo1" runat="server" AutoPostBack="True" Width="200px">
                                                        <asp:ListItem Value="S">Seleccione</asp:ListItem>
                                                        <asp:ListItem Value="A">Administrativo de base</asp:ListItem>
                                                        <asp:ListItem Value="C">Confianza</asp:ListItem>
                                                        <asp:ListItem Value="D">Docente</asp:ListItem>
                                                        <asp:ListItem Value="M">PEMEX</asp:ListItem>
                                                        <asp:ListItem Value="U">Turneros</asp:ListItem>
                                                        <asp:ListItem Value="H">Honorarios</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequireTipo" runat="server" ControlToValidate="DDL_Tipo1" ErrorMessage="*Requerido" InitialValue="S" ValidationGroup="grupo"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" Text="Nómina"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Nomina0" runat="server"  Width="400px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Text="Estatus"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Status0" runat="server" Width="200px">
                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                                <asp:ListItem Value="A">Activo</asp:ListItem>
                                                <asp:ListItem Value="P">Permiso sin goce de sueldo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel112" runat="server">
                                                <ContentTemplate>
                                                    &nbsp;<asp:ImageButton ID="pdf_tempo1" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF" OnClick="pdf_tempo1_Click" ValidationGroup="grupo" />
                                                    <asp:ImageButton ID="excel_temporal1" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="excel_temporal1_Click" ValidationGroup="grupo" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View5" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel114" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="Label20" runat="server" Text="Semestre"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="DDLSemestre" runat="server" Width="25%">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="DDLDependencia0" runat="server" CssClass="auto-style17"  Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label25" runat="server" Text="Tipo"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddltipo_plantilla" runat="server">
                                                <asp:ListItem Value="S">Plantilla</asp:ListItem>
                                                <asp:ListItem Value="P">Posteriores</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="cuadro_botones">
                                            <asp:UpdatePanel ID="UpdatePanel115" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="pdf_tempo2" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF" ValidationGroup="grupo" OnClick="pdf_tempo2_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View6" runat="server">

                        <asp:UpdatePanel ID="UpdatePanel117" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="Label24" runat="server" Text="Tipo empleado"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="DDL_Tipo2" runat="server" AutoPostBack="True" Width="200px">
                                                <asp:ListItem Value="S">Seleccione</asp:ListItem>
                                                <asp:ListItem Value="A">Administrativo de base</asp:ListItem>
                                                <asp:ListItem Value="C">Confianza</asp:ListItem>
                                                <asp:ListItem Value="D">Docente</asp:ListItem>
                                                <asp:ListItem Value="M">PEMEX</asp:ListItem>
                                                <asp:ListItem Value="U">Turneros</asp:ListItem>
                                                <asp:ListItem Value="H">Honorarios</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel118" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="pdf_tempo4" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" title="Reporte PDF" ValidationGroup="grupo" OnClick="pdf_tempo3_Click" />
                                                    <asp:ImageButton ID="excel_temporal2" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" ValidationGroup="grupo" OnClick="excel_temporal2_Click" />
                                                    <asp:ImageButton ID="Grafica" runat="server" ImageUrl="~/images/GRAFICA.png" title="Reporte PDF" ValidationGroup="grupo" OnClick="Grafica_Click" Width="50px"/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </asp:View>
                    <asp:View ID="View7" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%">
                           
                        </td>
                        <td colspan="2">
                           
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label1" runat="server" Text="Centro contable"></asp:Label>
                        </td>
                        <td colspan="2">
                         
                                    <asp:DropDownList ID="DDLCentro_Contable_v7" runat="server" 
                                        Width="90%">
                                    </asp:DropDownList>
                               
                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label27" runat="server" Text="Tipo"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLTipoReporte_v7" runat="server" Width="25%" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoReporte_v7_SelectedIndexChanged">
                                <asp:ListItem Value="CC">Por cuenta contable</asp:ListItem>
                                 <asp:ListItem Value="GG">Por grupo</asp:ListItem>
                                <%--<asp:ListItem Value="GC">Por capítulo</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label2" runat="server" Text="Mes inicial"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMes_Inicial_v7" runat="server" Width="25%">
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
                        <td class="style1">
                            <asp:Label ID="Label3" runat="server" Text="Mes final"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLMes_Final_v7" runat="server" Width="25%">
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
                        <td>
                            <asp:Label ID="lblCuentas_v7" runat="server" Text="Cuenta"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLCuentas_v7" runat="server" Width="90%">
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                      <tr>
                                        <td colspan="3" class="cuadro_botones">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="btnPDF_v7" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF"  OnClick="btnPDF_v7_Click" />
                                                    <asp:ImageButton ID="btnXLS_v7" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="btnXLS_v7_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel15">
                                <progresstemplate>
                                    <asp:Image ID="Image1q6" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
                    <asp:View ID="View8" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%">
                           
                        </td>
                        <td colspan="2">
                           
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label23" runat="server" Text="Centro contable"></asp:Label>
                        </td>
                        <td colspan="2">
                         
                                    <asp:DropDownList ID="DDLCentro_Contable_v8" runat="server" 
                                        Width="90%">
                                    </asp:DropDownList>
                               
                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text="Tipo de cédula"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLTipoCedula_v8" runat="server" Width="25%"  >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label28" runat="server" Text="Mes"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMes_v8" runat="server" Width="25%">
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
                        <td>
                            <asp:Label ID="Label30" runat="server" Text="Estatus cédula"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLStatus_v8" runat="server" Width="25%">
                                <asp:ListItem Value="A">Autorizada</asp:ListItem>
                                <asp:ListItem Value="I">Inicial</asp:ListItem>
                                <%--<asp:ListItem Value="DF">Con Diferencia</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblListado" runat="server" Text="Listado por"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLFiltro_v8" runat="server" Width="25%" AutoPostBack="True" OnSelectedIndexChanged="DDLFiltro_v8_SelectedIndexChanged">
                                <asp:ListItem Value="T">Todas</asp:ListItem>
                                <asp:ListItem Value="F">Fuente financiamiento</asp:ListItem>
                                <asp:ListItem Value="P">Partida</asp:ListItem>
                                <asp:ListItem Value="Y">Proyecto</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdDatos_v8" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." >
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkDatos_v8" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCIÓN" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkDatos_v8" runat="server"  OnClick="btnChkDatos_v8_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                      <tr>
                                        <td colspan="3" class="cuadro_botones">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgbtnPDF" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF"  OnClick="btnPDF_v8_Click" />
                                                    <asp:ImageButton ID="imgbtnExcel" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="btnXLS_v8_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel15">
                                <progresstemplate>
                                    <asp:Image ID="Image16" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
                    <asp:View ID="View9" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label29" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLDependencia_v9" runat="server" Width="100%" OnSelectedIndexChanged="DDLDependencia_v9_SelectedIndexChanged" AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label35" runat="server" Text="Período"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLPeriodo_v9" runat="server" Width="85%">
                                                <asp:ListItem Value="M">Mensual</asp:ListItem>
                                                <asp:ListItem Value="A">Acumulado</asp:ListItem>
                                                <asp:ListItem Value="T">Trimestral</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:20%">
                                            <asp:Label ID="Label32" runat="server" Text="Mes"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLMes_v9" runat="server" Width="85%">
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
                                        <td>
                                            <asp:Label ID="Label33" runat="server" Text="Dígito ministrador"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDLMinistrable_v9" runat="server" Width="85%">
                                                <asp:ListItem Value="1">Ministrable</asp:ListItem>
                                                <asp:ListItem Value="2">No ministrable</asp:ListItem>
                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                         <td style="width:20%">
                                            <asp:Label ID="Label37" runat="server" Text="Reporte"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLReporte_v9" runat="server" Width="85%">
                                                <asp:ListItem Value="DET">Detalle</asp:ListItem>
                                                <asp:ListItem Value="RES">Resumen</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr> <td colspan="4"></td></tr>
                                    <tr>
                                        <td>
                                            
                                        </td>

                                        <td colspan="3">
                                            
                                            <asp:GridView ID="grdCapitulo_v9" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="50%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkCapitulo" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Capítulo" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                            <asp:Button ID="btnchkCapitulos" runat="server"  OnClick="btnChkCapitulos_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdProyecto_v9" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkProyecto" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Proyecto" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                            <asp:Button ID="btnchkProyectos" runat="server"  OnClick="btnChkProyectos_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="4">
                                            <asp:GridView ID="grdFuente_v9" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkFuente" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Fuente de financiamiento" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                            <asp:Button ID="btnchkFuentes" runat="server"  OnClick="btnChkFuentes_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                             
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBtnPDF_v9" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf_v9_click" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBtnExcel_v9" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v9_click" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View10" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:20%">
                           
                        </td>
                        <td colspan="3">
                           
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label6" runat="server" Text="Centro contable"></asp:Label>
                        </td>
                        <td colspan="2">
                         
                                    <asp:DropDownList ID="DDLCentroContable_v10" runat="server" 
                                        Width="90%">
                                    </asp:DropDownList>
                               
                        </td>
                      
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label34" runat="server" Text="Mes"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMes_v10" runat="server" Width="25%">
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
                        <td>
                            <asp:Label ID="Label36" runat="server" Text="Reporte"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLReporte_v10" runat="server" Width="50%">
                                <asp:ListItem Value="RP019A">RP019A - Relación general institucional</asp:ListItem>
                                <asp:ListItem Value="RP019B">RP019B - Relación general sin aplicar</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                      <tr>
                                        <td colspan="3" class="cuadro_botones">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgbtnPDF_v10" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF"  OnClick="imgBttnPDF_v10_Click" />
                                                    <asp:ImageButton ID="imgbtnXLS_v10" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="imgBttnXLS_v10_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel15">
                                <progresstemplate>
                                    <asp:Image ID="Image17" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
                    <asp:View ID="View11" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label31" runat="server" Text="Dependencia inicial"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLDependenciaInicial_v11" runat="server"  Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependenciaInicial_v11_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label41" runat="server" Text="Dependencia final"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLDependenciaFinal_v11" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependenciaFinal_v11_SelectedIndexChanged1" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnBuscar_v11" runat="server"  OnClick="btnBuscar_v11_Click"
                                                        Text="Buscar" Width="10%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Text="Reporte"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLReporte_v11" runat="server" Width="100%">
                                                 <asp:ListItem Value="RP009A">RP009A - Por fuente de financiamiento, dependencia, proyecto y capítulo</asp:ListItem>
                                                <asp:ListItem Value="RP009B">RP009B - Por dependencia, fuente de financiamiento, proyecto y capítulo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="2">
                                            <asp:GridView ID="grdCapitulo_v11" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkCapitulo_v11" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkCapitulos_v11" runat="server"  OnClick="btnChkCapitulos_v11_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="3">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="2">
                                            <asp:GridView ID="grdFuente_v11" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkFuente_v11" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FUENTE" HeaderText="FUENTE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="FUENTE DE FINANCIAMIENTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkFuentes_v11" runat="server"  OnClick="btnChkFuentes_v11_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="3">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBttnPDF_v11" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf_v11" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBttnXLS_v11" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v11" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                     <asp:View ID="View12" runat="server">

                <table style="width: 100%;">
                    <tr>
                        <td style ="width:20%">
                           
                        </td>
                        <td colspan="2">
                           
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label39" runat="server" Text="Centro contable"></asp:Label>
                        </td>
                        <td colspan="2">
                         
                                    <asp:DropDownList ID="DDLCentroContable_v12" runat="server" 
                                        Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLCentroContable_v12_SelectedIndexChanged">
                                    </asp:DropDownList>
                               
                        </td>
                      
                    </tr>
                      <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label48" runat="server" Text="Dependencia inicial"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLDependenciaInicial_v12" runat="server"  Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependenciaInicial_v11_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label51" runat="server" Text="Dependencia final"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLDependenciaFinal_v12" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependenciaFinal_v11_SelectedIndexChanged1" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnBuscar_v12" runat="server"  OnClick="btnBuscar_v12_Click"
                                                        Text="Buscar" Width="10%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label40" runat="server" Text="Mes"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMes_v12" runat="server" Width="25%">
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
                        <td>
                            <asp:Label ID="Label42" runat="server" Text="Reporte"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLTipo_v12" runat="server" Width="25%">
                                <asp:ListItem Value="A">Acumulado</asp:ListItem>
                                <asp:ListItem Value="M">Mensual</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                                        <td colspan="3">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="2">
                                            <asp:GridView ID="grdFuente_v12" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkFuente_v12" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FUENTE" HeaderText="FUENTE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="FUENTE DE FINANCIAMIENTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkFuentes_v12" runat="server"  OnClick="btnChkFuentes_v12_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="3">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                      <tr>
                                        <td colspan="3" class="cuadro_botones">
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBttnPDF_v12" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF"  OnClick="imgBttnPDF_v12_Click" />
                                                    <asp:ImageButton ID="imgBttnXLS_v12" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"  title="Reporte Excel" OnClick="imgBttnXLS_v12_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel15">
                                <progresstemplate>
                                    <asp:Image ID="Image99" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
                     <asp:View ID="View13" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label43" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLDependencia_v13" runat="server"  Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_v13_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label47" runat="server" Text="Modificado"></asp:Label>
                                        </td>
                                        <td style="width:20%">
                                            <asp:DropDownList ID="DDLMesIni_Modificado" runat="server" Width="60%">
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
                                       
                                        <td style="width:20%">
                                            <asp:DropDownList ID="DDLMesFin_Modificado" runat="server" Width="60%">
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
                                         <td style="width:40%">
                                             &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label49" runat="server" Text="Ejercido"></asp:Label>
                                        </td>
                                        <td style="width:20%">
                                            <asp:DropDownList ID="DDLMesIni_Ejercido" runat="server" Width="60%">
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
                                       
                                        <td style="width:20%">
                                            <asp:DropDownList ID="DDLMesFin_Ejercido" runat="server" Width="60%">
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
                                         <td style="width:40%">
                                             &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" Text="Fecha de entrega"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFechaEntrega" runat="server" 
                                CssClass="box"  Width="95px"></asp:TextBox>
                           <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                TargetControlID="txtFechaEntrega" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MMMM/yyyy" PopupButtonID="imgFE" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="imgFE" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label45" runat="server" Text="Reporte"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLReporte_v13" AutoPostBack="true" runat="server" Width="50%" OnSelectedIndexChanged="DDLReporte_v13SelectedIndex">
                                                <asp:ListItem Value="SP01">ER01 - Por dependencia, capítulo y partida</asp:ListItem>
                                                <asp:ListItem Value="SP02">ER02 - Por dependencia y capítulo</asp:ListItem>
                                                <asp:ListItem Value="SP03">ER03 - Por clasificación administrativa</asp:ListItem>
                                                <asp:ListItem Value="SP04">ER04 - Por capítulo y subcapítulo</asp:ListItem>
                                                <asp:ListItem Value="SP05">ER05 - Por fuente de financiamiento</asp:ListItem>
                                                <asp:ListItem Value="SP06">ER06 - Por capítulo y dependencia</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdCapitulo_v13" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkCapitulo_v13" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkCapitulos_v13" runat="server"  OnClick="btnChkCapitulos_v13_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdFuentes_v13" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkFuente_v13" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FUENTE" HeaderText="FUENTE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="FUENTE DE FINANCIAMIENTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkFuentes_v13" runat="server"  OnClick="btnChkFuentes_v13_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBtnPDF_v13" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf_v13" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBtnXLS_v13" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v13" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View14" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label46" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLDependencia_v14" runat="server" Width="100%"  AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_v14_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                          <td style="width:20%">
                                            <asp:Label ID="Label50" runat="server" Text="Tipo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDLTipo_v14" runat="server" Width="85%">
                                                <asp:ListItem Value="AUMENTO">Aumento</asp:ListItem>
                                                <asp:ListItem Value="AUTORIZADO">Autorizado</asp:ListItem>
                                                <asp:ListItem Value="MODIFICADO">Modificado</asp:ListItem>
                                                <asp:ListItem Value="DISMINUCION">Disminución</asp:ListItem>
                                                <asp:ListItem Value="COMPROMETIDO">Comprometido</asp:ListItem>
                                                <asp:ListItem Value="XMINISTRAR">Por ministrar</asp:ListItem>
                                                <asp:ListItem Value="MINISTRADO">Ministrado</asp:ListItem>
                                                <asp:ListItem Value="EJERCIDO">Ejercido</asp:ListItem>
                                                <asp:ListItem Value="XEJERCER">Por ejercer</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                          <td style="width:20%">
                                            <asp:Label ID="Label57" runat="server" Text="Dígito ministrador"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLMinistrable_v14" runat="server" Width="85%">
                                                <asp:ListItem Value="1">Ministrable</asp:ListItem>
                                                <asp:ListItem Value="2">No ministrable</asp:ListItem>
                                                <asp:ListItem Value="3">Todos</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdCapitulos_v14" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkCapitulo_v14" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkCapitulos_v14" runat="server"  OnClick="btnChkCapitulos_v14_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdSubprogramas_v14" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSubprograma_v14" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="" />
                                                    <asp:BoundField DataField="SUBPROGRAMA" HeaderText="SUBPROGRAMA" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkSubprogramas_v14" runat="server"  OnClick="btnChkSubprogramas_v14_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgbtnPDF_v14" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf_v14" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgbtnXLS_v14" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v14" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View15" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label52" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLDependencia_v15" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_v15_SelectedIndexChanged"  >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label53" runat="server" Text="Período"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLPeriodo_v15" runat="server" Width="85%">
                                                <asp:ListItem Value="M">Mensual</asp:ListItem>
                                                <asp:ListItem Value="A">Acumulado</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:20%">
                                            <asp:Label ID="Label54" runat="server" Text="Mes"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLMes_v15" runat="server" Width="85%">
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
                                        <td>
                                            <asp:Label ID="Label55" runat="server" Text="Reporte"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLReporte_v15" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLReporte_v15_SelectedIndexChanged">
                                                <asp:ListItem Value="RP012">RP012 - Estado presupuestal por dependencia y fuente de financiamiento</asp:ListItem>
                                                <asp:ListItem Value="RP012G">RP012G - Estado presupuestal general por fuente de financiamiento</asp:ListItem>
                                            </asp:DropDownList>
                                        </td></tr>
                                     <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdCapitulo_v15" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkcapitulo_v15" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkCapitulos_v15" runat="server"  OnClick="btnChkCapitulos_v15_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdGrupoFuente_v15" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkfuente_v15" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FUENTE" HeaderText="FUENTE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="GRUPO FINANCIAMIENTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkFuentes_v15" runat="server"  OnClick="btnChkFuentes_v15_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                             
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBttnPdf_v15" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf_v15_click" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBttnExcel_v15" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v15_click" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                      <asp:View ID="View16" runat="server">
                           <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label58" runat="server" Text="Reporte"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlBD_v16" runat="server" Width="100%" >
                                                 <asp:ListItem Value="GENERAL">Base de datos - DP01</asp:ListItem>
                                                <asp:ListItem Value="DETALLE">Detalle de cédulas</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                               <tr>
                                        <td colspan="4"></td>
                                    </tr>
                             
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBttnExcel_v16" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v16_click" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                            </table>
                    </asp:View>
                    <asp:View ID="View17" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:20%">
                                            <asp:Label ID="Label59" runat="server" Text="Dependencia"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="DDLDependencia_v17" runat="server" Width="100%"  AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_v17_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:Label ID="Label60" runat="server" Text="Período"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLPeriodo_v17" runat="server" Width="85%">
                                                <asp:ListItem Value="M">Mensual</asp:ListItem>
                                                <asp:ListItem Value="A">Acumulado</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:20%">
                                            <asp:Label ID="Label61" runat="server" Text="Mes"></asp:Label>
                                        </td>
                                        <td style="width:30%">
                                            <asp:DropDownList ID="DDLMes_v17" runat="server" Width="85%">
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
                                        <td>
                                            <asp:Label ID="Label62" runat="server" Text="Dígito ministrador"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDLMinistrable_v17" runat="server" Width="85%">
                                                <asp:ListItem Value="1">Ministrable</asp:ListItem>
                                                <asp:ListItem Value="2">No ministrable</asp:ListItem>
                                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                         <td style="width:20%">
                                            <%--<asp:Label ID="Label63" runat="server" Text="Reporte"></asp:Label>--%>
                                        </td>
                                        <td style="width:30%">
                                           <%-- <asp:DropDownList ID="DropDownList5" runat="server" Width="85%">
                                                <asp:ListItem Value="DET">Detalle</asp:ListItem>
                                                <asp:ListItem Value="RES">Resumen</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdCapitulo_v17" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." Width="50%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkCapitulo_v17" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkCapitulos_v17" runat="server"  OnClick="btnChkCapitulos_v17_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td colspan="3">
                                            <asp:GridView ID="grdSubprogramas_v17" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSubprograma_v17" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="" />
                                                    <asp:BoundField DataField="SUBPROGRAMA" HeaderText="SUBPROGRAMA" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                             <asp:Button ID="btnChkSubprogramas_v17" runat="server"  OnClick="btnChkSubprogramas_v17_Click"
                                                        Text="Marcar todos" Width="15%"  CssClass="btn" CausesValidation="False" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="4">
                                           </td>
                                        
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBttnPdf_v17" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf_v17_Click" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBttnExcel_v17" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_v17_Click" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                </asp:MultiView>                
            </td>
        </tr>
     </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>