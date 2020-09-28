<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMHis_Nomina.aspx.cs" Inherits="SAF.Presupuesto.FRMHis_Nomina" %>
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
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        
                                        <table style="width:100%;">
                                            <tr>
                                                <td style="width:25%">&nbsp;</td>
                                                <td style="width:50%">&nbsp;</td>
                                                <td style="width:25%">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width:25%">
                                                    <asp:Label ID="lblUr" runat="server" Text="Dependencia:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged" ValidationGroup="GRPTodas" Width="60%">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUr1" runat="server" Text="Tipo Personal:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLTipoEmpleado" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="DDLTipoEmpleado_SelectedIndexChanged" Width="200px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUr0" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="False" CssClass="textbox" OnSelectedIndexChanged="DDLStatus_SelectedIndexChanged" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="(Paterno-Materno-Nombres) "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="True" CssClass="textbuscar" OnTextChanged="txtBuscar_TextChanged" Width="100%"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="btnBuscar_Click" title="Buscar" />
                                                            <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgNuevo_Click" title="Nuevo" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                                        <progresstemplate>
                                                            <asp:Image ID="Image31" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                        <progresstemplate>
                                                            <asp:Image ID="Image30" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel116" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GridEmpleados" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="GridEmpleados_PageIndexChanging" OnSelectedIndexChanged="GridEmpleados_SelectedIndexChanged" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="idEmpleado" HeaderText="ID" />
                                                                    <asp:BoundField DataField="Id_Empleado2" HeaderText="Id_Empleado2" SortExpression="Id_Empleado2" />
                                                                    <asp:BoundField DataField="PlazaMS2" HeaderText="PlazaMS2" SortExpression="PlazaMS2" />
                                                                    <asp:BoundField DataField="rfc" HeaderText="RFC" />
                                                                    <asp:BoundField DataField="paterno" HeaderText="PATERNO" />
                                                                    <asp:BoundField DataField="materno" HeaderText="MATERNO" />
                                                                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE" />
                                                                    <asp:BoundField DataField="genero" HeaderText="GENERO" />
                                                                    <asp:BoundField DataField="fechaNac" HeaderText="FECHA_NAC" />
                                                                    <asp:BoundField DataField="TipoEmpleado" HeaderText="TipoEmpleado" />
                                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                    <asp:CommandField HeaderText="" SelectText="Seleccionar" ShowSelectButton="True">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:CommandField>
                                                                    <%--  <asp:CommandField ButtonType="Image" HeaderText="Modificar" 
                                                                                    SelectImageUrl="~/Imagenes/editar.png" 
                                                                                    ShowSelectButton="True">
                                                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                </asp:CommandField>--%>
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
                                                <td>
                                                    <asp:Label ID="lbletiqueta0" runat="server" Text="Total Registros:      "></asp:Label>
                                                    <a>
                                                    <asp:Label ID="lblTotalDts" runat="server" Text="0"></asp:Label>
                                                    </a></td>
                                            </tr>
                                        </table>
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <table style="width:100%;">
                                            <caption>                                               
                                                <tr>
                                                    <td style="width: 25%"><strong>
                                                        <asp:Label ID="Label4" runat="server" CssClass=" linkFiltrar derecha" Text="Nombre:"></asp:Label>
                                                        </strong></td>
                                                    <td style="width: 50%"><strong>
                                                        <asp:Label ID="lblNombre0" runat="server" CssClass="linkFiltrar derecha"></asp:Label>
                                                        </strong></td>
                                                    <td style="width: 25%">&nbsp;</td>
                                                    <caption>
                                                        <br></br>
                                                    </caption>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:GridView ID="grdNominas_pag" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnSelectedIndexChanged="grdNominas_pag_SelectedIndexChanged" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />
                                                                <asp:BoundField DataField="PLAZA" HeaderText="PLAZA" />
                                                                <asp:BoundField DataField="TIPO_PERSONAL" HeaderText="TIPO PERSONAL" />
                                                                <asp:BoundField DataField="PERIODO" HeaderText="PERIODO" />
                                                                <asp:CommandField ShowSelectButton="True" />
                                                                <asp:TemplateField></asp:TemplateField>
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
                                                    <td class="cuadro_botones" colspan="3">
                                                        <asp:Button ID="Button1" runat="server" CssClass="btn2" OnClick="Button1_Click1" Text="Regresar" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <br>
                                                </br>
                                            </caption>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel113" runat="server">
                                    <ContentTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td style="width: 25%">
                                                    <asp:Label ID="Label6" runat="server" Text="Nombre:"></asp:Label>
                                                </td>
                                                <td style="width: 50%">
                                                    &nbsp;</td>
                                                <td style="width: 25%">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Ejercicio"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel114" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlEjercicio0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEjercicio0_SelectedIndexChanged" Width="100%">
                                                                <asp:ListItem Value="T">Todos....</asp:ListItem>
                                                                <asp:ListItem>2017</asp:ListItem>
                                                                <asp:ListItem>2016</asp:ListItem>
                                                                <asp:ListItem>2015</asp:ListItem>
                                                                <asp:ListItem>2014</asp:ListItem>
                                                                <asp:ListItem>2013</asp:ListItem>
                                                                <asp:ListItem>2012</asp:ListItem>
                                                                <asp:ListItem>2011</asp:ListItem>
                                                                <asp:ListItem>2010</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:UpdateProgress ID="UpdProDocumentos2" runat="server" AssociatedUpdatePanelID="UpdatePanel14">
                                                        <progresstemplate>
                                                            <asp:Image ID="imgDocumentos2" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="text-align: center" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="grdNominas_pag0" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="NOMINA" HeaderText="NOMINA" />
                                                            <asp:BoundField DataField="PLAZA" HeaderText="# PLAZA" />
                                                            <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />
                                                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                                            <asp:BoundField DataField="CONCEPTO" HeaderText="CONCEPTO" />
                                                            <asp:BoundField DataField="PERIODO" HeaderText="PERIODO" />
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
                                                <td class="cuadro_botones" colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel115" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnRegresar0" runat="server" CssClass="btn"  Text="Regresar" ValidationGroup="Guardar" />
                                                            &nbsp;
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
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
