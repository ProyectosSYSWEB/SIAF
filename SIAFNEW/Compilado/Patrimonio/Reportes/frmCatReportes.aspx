<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatReportes.aspx.cs" Inherits="SAF.Patrimonio.Reportes.frmCatReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">   
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
     </div>
        <table class="tabla_contenido">
            <tr>
                 <td>

               
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label1" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDLCentro_Contable" runat="server" 
                                        Width="100%">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                     
                    </tr>
                    <tr>
                        <td>


                            <asp:Label ID="lblIF07" runat="server" Text="Tipo IF07:"></asp:Label>


                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLTipo_IF07" runat="server" AutoPostBack="True" onselectedindexchanged="ddltipo_consulta_SelectedIndexChanged" Width="50%">
                                <asp:ListItem Value="G">GENERAL</asp:ListItem>
                                <asp:ListItem Value="C">POR CUENTA</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                                <td class="style13">
                                    <asp:Label ID="lblCuenta" runat="server">Cuenta:</asp:Label>
                                </td>
                                <td class="style7" colspan="5">
                                    <asp:DropDownList ID="DDLCuentas" runat="server" 
                                        onselectedindexchanged="ddlcuenta_mayor_SelectedIndexChanged" Width="50%">
                                        <asp:ListItem Value="1231">1231- TERRENOS</asp:ListItem>
                                        <asp:ListItem Value="1233">1233- EDIFICIOS NO HABITACIONALES</asp:ListItem>
                                        <asp:ListItem Value="1241">1241- MOBILIARIO Y EQUIPO DE ADMINISTRACIÓN</asp:ListItem>
                                        <asp:ListItem Value="1242">1242- MOBILIARIO Y EQUIPO EDUCACIONAL Y RECREATIVO</asp:ListItem>
                                        <asp:ListItem Value="1243">1243- EQUIPO E INSTRUMENTAL MEDICO Y DE LABORATORIO</asp:ListItem>
                                        <asp:ListItem Value="1244">1244- VEHICULOS Y EQUIPO DE TRANSPORTE</asp:ListItem>
                                        <asp:ListItem Value="1246">1246- MAQUINARIA, OTROS EQUIPOS Y HERRAMIENTAS</asp:ListItem>
                                        <asp:ListItem Value="1247">1247- COLECCIONES, OBRAS DE ARTE Y OBJETOS VALIOSOS</asp:ListItem>
                                        <asp:ListItem Value="1248">1248- ACTIVOS BILÓGICOS</asp:ListItem>
                                        <asp:ListItem Value="1251">1251- SOFTWARE</asp:ListItem>
                                        <asp:ListItem Value="1253">1253- CONCESIONES Y FRANQUICIAS</asp:ListItem>
                                        <asp:ListItem Value="1254">1254- LICENCIAS</asp:ListItem>
                                        <asp:ListItem Value="1293">1293- BIENES EN COMODATO</asp:ListItem>
                                        <asp:ListItem Value="0000">TODAS</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label2" runat="server" Text="Fecha Inicial:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:TextBox ID="txtMes_inicial" runat="server" 
                                CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>
                            

                                <ajaxToolkit:CalendarExtender ID="Calendario" runat="server" 
                                                TargetControlID="txtMes_inicial" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image1" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label3" runat="server" Text="Fecha Final:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtMes_final" runat="server" 
                                CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>
                           <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                TargetControlID="txtMes_final" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image2" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnAceptar" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnAceptar_Click" Width="51px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel3">
                                <progresstemplate>
                                    <asp:Image ID="Image1q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            </td>
                        <td>
                            </td>
                        <td>
                            </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td style="width:25%"></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td  >
                            <asp:Label ID="Label17" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDLCentroContable" runat="server" 
                                        Width="100%">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                      
                    </tr>
                    <tr>
                        <td style="width:25%">
                            <asp:Label ID="Label10" runat="server" Text="Status::"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltipo_consulta" runat="server" 
                                         Width="95px" AutoPostBack="True" 
                                        onselectedindexchanged="ddltipo_consulta_SelectedIndexChanged">
                                        <asp:ListItem Value="A">ALTA</asp:ListItem>
                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label9" runat="server" Text="Tipo:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltipo" runat="server" Width="100%">                                        
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label4" runat="server" Text="Fecha Inicial:"></asp:Label>
                        </td>
                        <td colspan="2" class="style5">
                            <asp:TextBox ID="txtMes_inicial0" runat="server" 
                                CssClass="box" onkeyup="ValidaFecha();" 
                                Width="95px"></asp:TextBox>
                            &nbsp;<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                TargetControlID="txtMes_inicial0" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image3" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                      
                            <asp:Image ID="Image3" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </td>
                      
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label5" runat="server" Text="Fecha Final:"></asp:Label>
                        </td>
                        <td class="style5" colspan="2">
                            <asp:TextBox ID="txtMes_final0" runat="server" 
                                CssClass="box" onkeyup="ValidaFecha();"  
                                Width="95px"></asp:TextBox>
                            &nbsp;<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
                                                TargetControlID="txtMes_final0" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image4" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                       
                            <asp:Image ID="Image4" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </td>
                       
                        
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnAceptar0" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"  Width="51px" onclick="btnAceptar0_Click" />
                                     <asp:ImageButton ID="ImgBtnTipoMovimiento" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="ImgBtnTipoMovimiento_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel5">
                                <progresstemplate>
                                    <asp:Image ID="Image1q0" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td style="width:25%">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddldependencia" runat="server" Width="100%" 
                                                onselectedindexchanged="ddldependencia_SelectedIndexChanged" 
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Responsable:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlresponsable" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                             
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlstatus" runat="server">
                                        <asp:ListItem Value="A">ALTA</asp:ListItem>
                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                               
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnAceptar1" runat="server" Height="53px" 
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" Width="51px" onclick="btnAceptar1_Click" />
                                            <asp:ImageButton ID="ImgBtnCedula" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnCedulaXLS_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel8">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q1" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td style="width:25%">
                                    &nbsp;</td>
                                <td class="style7" colspan="5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:Label ID="Label11" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td class="style7" colspan="5">
                                    <asp:DropDownList ID="DDLDependenciaX" runat="server" Width="100%" 
                                        AutoPostBack="True" OnSelectedIndexChanged="DDLDependenciaX_SelectedIndexChanged" 
                                        >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:Label ID="Label14" runat="server" Text="Centro de Trabajo:"></asp:Label>
                                </td>
                                <td class="style7" colspan="5">
                                    <asp:DropDownList ID="DDLcentro_trab" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:Label ID="Label15" runat="server">Cuenta:</asp:Label>
                                </td>
                                <td class="style7" colspan="5">
                                    <asp:DropDownList ID="DDLcuenta_mayor" runat="server" 
                                        onselectedindexchanged="ddlcuenta_mayor_SelectedIndexChanged" Width="300px">
                                        <asp:ListItem Value="1231">1231- TERRENOS</asp:ListItem>
                                        <asp:ListItem Value="1233">1233- EDIFICIOS NO HABITACIONALES</asp:ListItem>
                                        <asp:ListItem Value="1241">1241- MOBILIARIO Y EQUIPO DE ADMINISTRACIÓN</asp:ListItem>
                                        <asp:ListItem Value="1242">1242- MOBILIARIO Y EQUIPO EDUCACIONAL Y RECREATIVO</asp:ListItem>
                                        <asp:ListItem Value="1243">1243- EQUIPO E INSTRUMENTAL MEDICO Y DE LABORATORIO</asp:ListItem>
                                        <asp:ListItem Value="1244">1244- VEHICULOS Y EQUIPO DE TRANSPORTE</asp:ListItem>
                                        <asp:ListItem Value="1246">1246- MAQUINARIA, OTROS EQUIPOS Y HERRAMIENTAS</asp:ListItem>
                                        <asp:ListItem Value="1247">1247- COLECCIONES, OBRAS DE ARTE Y OBJETOS VALIOSOS</asp:ListItem>
                                        <asp:ListItem Value="1248">1248- ACTIVOS BILÓGICOS</asp:ListItem>
                                        <asp:ListItem Value="1251">1251- SOFTWARE</asp:ListItem>
                                        <asp:ListItem Value="1253">1253- CONCESIONES Y FRANQUICIAS</asp:ListItem>
                                        <asp:ListItem Value="1254">1254- LICENCIAS</asp:ListItem>
                                        <asp:ListItem Value="1293">1293- BIENES EN COMODATO</asp:ListItem>
                                        <asp:ListItem Value="0">TODAS</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                              <tr>
                         <td align="left" class="style8">
                                                    <asp:Label ID="Label35" runat="server" Text="Clasificación:"></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:DropDownList ID="DDLCategoriaCC" runat="server"  Width="300px">
                                                   
                                </asp:DropDownList>
                                                </td>
                    </tr>
                            <tr>
                                <td class="style13">
                                    <asp:Label ID="Label12" runat="server" Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td class="style8">
                                     <asp:TextBox ID="txtfecha_iniCC" runat="server" 
                                CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" 
                                                TargetControlID="txtfecha_iniCC" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image5" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                       <asp:Image ID="Image5" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" 
                                        style="margin-left: 0px" />
                                    </td>
                         
                            </tr>
                            <tr>
                                <td class="style10">
                                    <asp:Label ID="Label13" runat="server" Text="Fecha Final:"></asp:Label>
                            &nbsp;<ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" 
                                                TargetControlID="txt_fecha_finCC" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image6" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="txt_fecha_finCC" runat="server" 
                                        CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>
                                     <asp:Image ID="Image6" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" 
                                        style="margin-left: 0px" />
                                </td>

                            </tr>
                            <tr>
                                <td class="style6" colspan="7">
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnAceptar2" runat="server" Height="53px" 
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" Width="51px" OnClick="btnAceptar2_Click" />
                                            <asp:ImageButton ID="btnExcel" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="imgBttnExcel_click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="7">
                                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel12">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q2" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td style="width:25%">&nbsp;</td>
                        <td  colspan="2">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="Label16" runat="server" Text="Dependencia:"></asp:Label>
                        </td>
                        <td class="style7" colspan="5">
                            <asp:DropDownList ID="ddldependencia0" runat="server"  Width="100%" >
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="style13">
                            <asp:Label ID="Label20" runat="server" Text="Tipo Bien:"></asp:Label>
                        </td>
                        <td class="style7" colspan="5">
                            
                            <asp:DropDownList ID="DDLtipo_bien" runat="server" Width="100%">
                            </asp:DropDownList>
                                   
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label19" runat="server" Text="Fecha Corte:"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtfecha_periodo" runat="server" CssClass="box" onkeyup="ValidaFecha();" Width="95px"></asp:TextBox>
                             <asp:Image ID="Image7" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" DaysModeTitleFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" PopupButtonID="Image7" TargetControlID="txtfecha_periodo" TodaysDateFormat="dd MMMM, yyyy">
                            </ajaxToolkit:CalendarExtender>
                             
                        </td>                       
                    </tr>
                    <tr>
                        <td class="style6" colspan="7">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnAceptar3" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="btnAceptar3_Click" Width="51px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" colspan="7">
                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel14">
                                <progresstemplate>
                                    <asp:Image ID="Image1q3" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%">
                           
                        </td>
                        <td colspan="2">
                           
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label18" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td colspan="2">
                         
                                    <asp:DropDownList ID="DDLCContable" runat="server" 
                                        Width="100%">
                                    </asp:DropDownList>
                               
                        </td>
                      
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label23" runat="server" Text="Comparativo:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                            <asp:DropDownList ID="DDLComparativo" runat="server" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DDLComparativo_SelectedIndexChanged">
                                                                <asp:ListItem Value="01">Acumulado(incluye pólizas de apertura)</asp:ListItem>
                                                                <asp:ListItem Value="02">Altas del Ejercicio</asp:ListItem>
                                                                <asp:ListItem Value="03">Bajas del Ejercicio</asp:ListItem>
                            </asp:DropDownList>
                                            <asp:DropDownList ID="DDLComparativoTipo" runat="server" AutoPostBack="True"  Visible="False" Width="50%" OnSelectedIndexChanged="DDLComparativoTipo_SelectedIndexChanged">
                                                <asp:ListItem Value="01">Global</asp:ListItem>
                                                <asp:ListItem Value="02">Detalle</asp:ListItem>
                                                <asp:ListItem Value="03">Resumen</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                 </asp:UpdatePanel>
                            

                               
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label21" runat="server" Text="Mes Inicial:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMes_Inicial" runat="server" Width="50%">
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
                            <asp:Label ID="Label22" runat="server" Text="Mes Final:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLMes_Final" runat="server" Width="50%">
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
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>

                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnComparativo_Click" Width="51px" />
                                    <asp:ImageButton ID="btnComparaPresupuestoXLS" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnComparaPresupuestoXLS_Click" />
                                     <asp:ImageButton ID="btnComparaContaXLS" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnComparativoContaXLS_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress7" runat="server" 
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
            <asp:View ID="View7" runat="server">
                                                    <table style="width: 100%;">
                                                       <tr>
                                                           <td style="width: 25%;"></td>
                                                           <td></td>
                                                       </tr>
                                                        <tr>
                                                            <td >
                                                                <asp:Label ID="lblDepResguardos" runat="server" Text="Dependencia:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel108" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLDepResguardos" runat="server"  Width="450px" OnSelectedIndexChanged="DDLDepResguardos_SelectedIndexChanged" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RFVDepResguardos" runat="server" ControlToValidate="DDLDepResguardos" ErrorMessage="RequiredFieldValidator" InitialValue="--TODAS LAS DEPENDENCIAS--" ValidationGroup="Resguardos">*</asp:RequiredFieldValidator>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblGenerar" runat="server" Text="Generar por:"></asp:Label>
                                                            </td>
                                                         
                                                            <td>
                                                                <asp:DropDownList ID="DDLGenerar" runat="server"  Width="450px" AutoPostBack="True" OnSelectedIndexChanged="DDLGenerar_SelectedIndexChanged">
                                                                        <asp:ListItem Value="01">No. DE INVENTARIO</asp:ListItem>
                                                                        <asp:ListItem Value="02">CENTRO DE TRABAJO</asp:ListItem>
                                                                        <asp:ListItem Value="03">RESPONSABLE</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                           
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblInventario_Inicial" runat="server" Text="No. de Inventario Inicial:"></asp:Label>
                                                            </td>
                                                         
                                                            <td>
                                                                <asp:TextBox ID="txtInventario_Inicial" runat="server"  Width="100px" placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVInventario_Inicial" runat="server" ControlToValidate="txtInventario_Inicial" ErrorMessage="RequiredFieldValidator" ValidationGroup="Resguardos">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblInventario_Final" runat="server" Text="No. de Inventario Final:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtInventario_Final" runat="server" Width="100px" placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVInventario_Final" runat="server" ControlToValidate="txtInventario_Final" ErrorMessage="RequiredFieldValidator" ValidationGroup="Resguardos">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                                  <tr>
                                <td class="style13">
                                    <asp:Label ID="lblCT" runat="server" Text="Centro de Trabajo:"></asp:Label>
                                </td>
                                <td class="style7" colspan="5">
                                    <asp:DropDownList ID="DDLCentrosTrabajo" runat="server" Width="450px">
                                    </asp:DropDownList>
                                </td>
                            </tr>      
                                                        <tr>
                                <td>
                                    <asp:Label ID="lblResp" runat="server" Text="Responsable:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLResponsables" runat="server" Width="450px">
                                    </asp:DropDownList>
                                </td>
                                
                            </tr>
                                                        <tr>
                        <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnResguardo_Click" Width="51px" ValidationGroup="Resguardos" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel16">
                                <progresstemplate>
                                    <asp:Image ID="Image1q7" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                                                        
                                                    </table>
                                               
                                    </asp:View>
            <asp:View ID="View8" runat="server">
                                                    <table style="width: 100%;">
                                                       <tr>
                                                           <td style="width: 25%;"></td>
                                                           <td></td>
                                                       </tr>
                                                        
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="Label25" runat="server" Text="Generar por:"></asp:Label>
                                                            </td>
                                                         
                                                            <td>
                                                                <asp:DropDownList ID="DDLEtiquetas" runat="server"  Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DDLEtiquetas_SelectedIndexChanged">
                                                                        <asp:ListItem Value="01">No. DE INVENTARIO</asp:ListItem>
                                                                        <asp:ListItem Value="02">FECHA</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                           
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblEtiquetas_Inv_Ini" runat="server" Text="No. de Inventario Inicial:"></asp:Label>
                                                            </td>
                                                         
                                                            <td>
                                                                <asp:TextBox ID="txtInv_Ini" runat="server"  Width="100px" placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFV_Inv_Ini" runat="server" ControlToValidate="txtInv_Ini" ErrorMessage="RequiredFieldValidator" ValidationGroup="Etiquetas">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEtiquetas_Inv_Fin" runat="server" Text="No. de Inventario Final:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtInv_Fin" runat="server" Width="100px" placeHolder="XXX-XXXXXX"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFV_Inv_Fin" runat="server" ControlToValidate="txtInv_Fin" ErrorMessage="RequiredFieldValidator" ValidationGroup="Etiquetas">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                        <td >
                            <asp:Label ID="lblEtiquetas_Dependencia" runat="server" Text="Dependencia:"></asp:Label>
                        </td>
                        <td class="style7" colspan="5">
                            <asp:DropDownList ID="DDL_Etiquetas_Dependencia" runat="server"  Width="100%" >
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                                                            <tr>
                                <td class="style13">
                                    <asp:Label ID="lblEtiquetas_Fec_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td class="style8">
                                     <asp:TextBox ID="txtFecha_Ini" runat="server" 
                                CssClass="box"  Width="95px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" 
                                                TargetControlID="txtFecha_Ini" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image8" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image8" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" 
                                        style="margin-left: 0px" />
                                
                                       
                                    </td>
                         
                            </tr>
                            <tr>
                                <td class="style10">
                                    <asp:Label ID="lblEtiquetas_Fec_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                            &nbsp;<ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" 
                                                TargetControlID="txtFecha_Fin" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image9" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="txtFecha_Fin" runat="server" 
                                        CssClass="box"  Width="95px"></asp:TextBox>
                                     <asp:Image ID="Image9" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" 
                                        style="margin-left: 0px" />
                                </td>

                            </tr>
                                                        <tr>
                        <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="ImageButton8" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnEtiquetas_Click" Width="51px" ValidationGroup="Etiquetas"  />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress9" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel18">
                                <progresstemplate>
                                    <asp:Image ID="Image1q8" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                                                        
                                                    </table>
                                               
                                    </asp:View>
            <asp:View ID="View9" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%;">
                           
                        </td>
                        <td>
                           
                        </td>
                        
                    </tr>
                    <tr>
                        <td  >
                            <asp:Label ID="Label24" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td >
                          <%--  <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                <ContentTemplate>--%>
                                    <asp:DropDownList ID="DDLCentro_Contab" runat="server" 
                                        Width="100%">
                                    </asp:DropDownList>
                              <%--  </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                     
                    </tr>
                    <tr>
                         <td align="left" class="style8">
                                                    <asp:Label ID="Label52" runat="server" Text="Clasificación:"></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:DropDownList ID="DDLCategoria" runat="server"  Width="300px">
                                                   
                                </asp:DropDownList>
                                                </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label27" runat="server" Text="Fecha Inicial:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtFIInventario" runat="server" 
                                CssClass="box"  Width="95px"></asp:TextBox>
                            

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" 
                                                TargetControlID="txtFIInventario" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image10" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image10" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label28" runat="server" Text="Fecha Final:"></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="txtFFInventario" runat="server" 
                                CssClass="box"  Width="95px"></asp:TextBox>
                           <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" 
                                                TargetControlID="txtFFInventario" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image11" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image11" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="ImageButton3" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnInventario_Click" Width="51px" />
                                    <asp:ImageButton ID="ImageButtonInventarioXLS" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnInventarioXLS_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress10" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel19">
                                <progresstemplate>
                                    <asp:Image ID="Image1x" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            </td>
                        <td>
                            </td>
                       
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View10" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%;">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label26" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDLFormatosTransp" runat="server" 
                                        Width="100%">
                                        <asp:ListItem Value="XXXIVA">LTAIPECHFXXXIVA - Inventario de bienes muebles</asp:ListItem>
                                        <asp:ListItem Value="XXXIVB">LTAIPECHFXXXIVB - Inventario de altas practicadas a bienes muebles</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                     
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label29" runat="server" Text="Fecha Inicial:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:TextBox ID="txtFITransp" runat="server" 
                                CssClass="box"  Width="95px"></asp:TextBox>
                            

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" 
                                                TargetControlID="txtFITransp" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image12" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image12" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" style="margin-left: 0px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label30" runat="server" Text="Fecha Final:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtFFTransp" runat="server" 
                                CssClass="box"  Width="95px"></asp:TextBox>
                           <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" 
                                                TargetControlID="txtFFTransp" DaysModeTitleFormat="dd MMMM, yyyy" 
                                                Format="dd/MM/yyyy" PopupButtonID="Image13" 
                                                TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                            <asp:Image ID="Image13" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                <ContentTemplate>
                                    
                                    <asp:ImageButton ID="ImageButtonTransp" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnTranspXLS_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress11" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel21">
                                <progresstemplate>
                                    <asp:Image ID="ImageTransp" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            </td>
                        <td>
                            </td>
                        <td>
                            </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View11" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%">
                           
                        </td>
                        <td colspan="2">
                           
                        </td>
                       
                    </tr>
                    
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label32" runat="server" Text="Tipo Comparativo:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                        <ContentTemplate>
                            <asp:DropDownList ID="DDLTipoComparativo" runat="server" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoComparativo_SelectedIndexChanged" >
                                                                <asp:ListItem Value="01">Acumulado</asp:ListItem>
                                                                <asp:ListItem Value="02">Ejercicio actual</asp:ListItem>
                            </asp:DropDownList>
                                            
                                        </ContentTemplate>
                                 </asp:UpdatePanel>
                            

                               
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblMesInicial_ActivoFijo" runat="server" Text="Mes Inicial:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMesInicial_ActivoFijo" runat="server" Width="50%">
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
                            <asp:Label ID="lblMesFinal_ActivoFijo" runat="server" Text="Mes Final:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDLMesFinal_ActivoFijo" runat="server" Width="50%">
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
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnComparativo_ActivoFijo" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnComparativo_ActivoFijo_Click" Width="51px" />
                                    <asp:ImageButton ID="btnComparativo_ActivoFijoXLS" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnComparativo_ActivoFijoXLS_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress12" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel23">
                                <progresstemplate>
                                    <asp:Image ID="Image_ActivoFijo" runat="server" 
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
             <asp:View ID="View12" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style ="width:25%">
                           
                        </td>
                        <td colspan="2">
                           
                        </td>
                       
                    </tr>
                    
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label31" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLCentroContable_Gasto" runat="server" Width="95%" >
                            </asp:DropDownList>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label33" runat="server" Text="Ejercicio:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLEjercicio_Gasto" runat="server" Width="20%">
                            </asp:DropDownList>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label34" runat="server" Text="Formato:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLFormato_Gasto" runat="server" Width="50%">
                                <asp:ListItem Value="01">Detalle</asp:ListItem>
                                <asp:ListItem Value="02">Póliza</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnGasto" runat="server" Height="53px" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnGasto_Click" Width="51px" />
                                    <asp:ImageButton ID="btnGastoXLS" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                Width="49px" OnClick="btnGastoXLS_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress13" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel25">
                                <progresstemplate>
                                    <asp:Image ID="Image_Gasto" runat="server" 
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
        </asp:MultiView>
                       </td>
            </tr>           
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
