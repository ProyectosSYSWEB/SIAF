<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMInformativa.aspx.cs" Inherits="SAF.Contabilidad.Form.FRMInformativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 166px;
            height: 26px;
        }
        .style3
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="tabla_contenido">
            <tr>
                <td>
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
                <td colspan="2">
                    &nbsp;
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Centro Contable:"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DDLCentro_Contable" runat="server" 
                                onselectedindexchanged="ddlcentro_contable_SelectedIndexChanged" 
                                AutoPostBack="True" >
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;<asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                        AssociatedUpdatePanelID="UpdatePanel7">
                        <progresstemplate>
                            <asp:Image ID="Image1q0" runat="server" 
                                AlternateText="Espere un momento, por favor.." Height="50px" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                ToolTip="Espere un momento, por favor.." Width="50px" />
                        </progresstemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    &nbsp; &nbsp; </td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table class="tabla_contenido">
                            <tr>
                                <td width="50%">
                                    <asp:TextBox ID="txtbusca" runat="server" Width="500px"></asp:TextBox>
                                </td>
                                <td width="20%">
                                    
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="BTNbuscar" runat="server" class="" Height="38px" 
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="BTNbuscar_Click" Width="39px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </td>
                                <td style="text-align: right; width: 0%;" width="20%">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel6">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                 </td>
                                <td style="text-align: right; width: 10%;" width="20%">
                                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" />
                                </td>
                            </tr>                          
                            <tr>
                                <td colspan="4">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdinformativa" runat="server" AutoGenerateColumns="False" 
                                                BorderStyle="None" BorderWidth="1px" 
                                                CellPadding="4"  GridLines="Vertical" Width="100%" 
                                                onselectedindexchanged="grdinformativa_SelectedIndexChanged" CssClass="mGrid" EmptyDataText="No hay registros para mostrar">                                               
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="centro_contable" HeaderText="CENTRO CONTABLE" />
                                                    <asp:BoundField DataField="observaciones" HeaderText="DESCRIPCIÓN" />
                                                    <asp:BoundField DataField="status" HeaderText="STATUS" />
                                                    <asp:BoundField DataField="fecha_inicial" HeaderText="FECHA INICIO" />
                                                    <asp:BoundField DataField="fecha_final" HeaderText="FECHA TERMINO" />
                                                    <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                                OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');">Eliminar</asp:LinkButton>
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
                                <td colspan="2">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <table class="tabla_contenido">
                            <tr>
                                <td class="style1" width="25%">
                                    <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtobservacion" runat="server" Height="118px" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" width="25%">
                                    <asp:Label ID="Label5" runat="server" Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtFecha_inicial" runat="server" AutoPostBack="True" 
                                        CssClass="box" onkeyup="ValidaFecha();" 
                                        Width="95px"></asp:TextBox>
                                    <img alt="Ver calendario" 
                                        onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                        src="../../images/Calendario.gif" style="cursor: pointer" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" width="25%">
                                    <asp:Label ID="Label6" runat="server" Text="Fecha Termino:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFecha_final" runat="server" AutoPostBack="True" 
                                        CssClass="box" onkeyup="ValidaFecha();"   
                                        Width="95px"></asp:TextBox>
                                    <img alt="Ver calendario" 
                                        onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                        src="../../images/Calendario.gif" style="cursor: pointer" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" width="25%">
                                    <asp:Label ID="Label4" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_status" runat="server">
                                        <asp:ListItem Value="A">ACTIVA</asp:ListItem>
                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="cuadro_botones" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="BTN_Guardar" runat="server" CssClass="btn" onclick="BTN_Guardar_Click" Text="Guardar" />
                                            &nbsp;
                                            <asp:Button ID="BTN_Cancelar" runat="server" CssClass="btn2" onclick="BTN_Cancelar_Click" Text="Cancelar" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" width="25%">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
