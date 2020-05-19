<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMCuentas_Mayor.aspx.cs" Inherits="SAF.CATS.FRMCuentas_Moyor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style20
        {
            text-align: right;
            width: 137px;
        }
        .style7
        {
            width: 799px;
            text-align: left;
        }
        .style5
        {
            text-align: right;
            height: 26px;
            width: 137px;
        }
        .style6
        {
            height: 26px;
            width: 799px;
        }
        .style8
        {
            height: 20px;
            width: 799px;
        }
        .style11
        {
            height: 20px;
            text-align: center;
            }
        .style22
        {
            text-align: right;
            width: 149px;
        }
        .style16
        {
            text-align: left;
            }
        .style19
        {
            height: 20px;
            text-align: right;
            width: 149px;
        }
        .style23
        {
            height: 20px;
        }
        .style24
        {
            text-align: center;
            height: 21px;
        }
        .style25
        {
            width: 799px;
            text-align: justify;
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
                     <td style="text-align: right">
                      <asp:Label ID="Label5" runat="server" Text="Tipo:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLtipo" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLtipo_SelectedIndexChanged" Width="96px">
                            <asp:ListItem Value="1">GENERO</asp:ListItem>
                            <asp:ListItem Value="2">GRUPO</asp:ListItem>
                            <asp:ListItem Value="3">CLASE</asp:ListItem>
                            <asp:ListItem Value="4">CUENTA</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;</td>
                    <td style="text-align: right">
                        <asp:ImageButton ID="BTNNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="BTNNuevo_Click" />
                    </td>
                </tr>
            </table>
            <asp:MultiView ID="MultiViewcuentas_contables" runat="server">
                <asp:View ID="View1" runat="server">
                          
                <table class="tabla_contenido">                             
                <tr>
                    <td class="style5">
                        <asp:Label ID="Label2" runat="server" style="text-align: right" 
                            Text="Id_Padre:"></asp:Label>
                    </td>
                    <td class="style25" colspan="3">
                        <asp:TextBox ID="txtid_padre" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td class="style20">
                            <asp:Label ID="Label3" runat="server" Text="Clave:"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="txtclave" runat="server" Width="250px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtclave" ErrorMessage="Requerido" ValidationGroup="Guarda"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="text-align: right">
                            <asp:Label ID="Label12" runat="server" Text="Naturaleza:"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:DropDownList ID="ddlnaturaleza" runat="server" AutoPostBack="True" 
                                style="text-align: left" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="Label11" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td class="style6" colspan="3">
                        <asp:TextBox ID="txtdescripcion" runat="server" Width="695px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtdescripcion" ErrorMessage="Requerido" 
                            ValidationGroup="Guarda"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        <asp:Label ID="Label14" runat="server" Text="Rubro:"></asp:Label>
                    </td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlrubro" runat="server" 
                            Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="Label13" runat="server" Text="Nivel:"></asp:Label>
                    </td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlnivel" runat="server" AutoPostBack="True" 
                            Enabled="False" Width="250px">
                            <asp:ListItem Value="1">NIVEL 1</asp:ListItem>
                            <asp:ListItem Value="2">NIVEL 2</asp:ListItem>
                            <asp:ListItem Value="3">NIVEL 3</asp:ListItem>
                            <asp:ListItem Value="4">NIVEL 4</asp:ListItem>
                            <asp:ListItem Value="5">NIVEL 5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">
                        <asp:Label ID="Label9" runat="server" Text="Estado Financiero:"></asp:Label>
                    </td>
                    <td class="style8">
                        <asp:DropDownList ID="ddlestado_financiero" runat="server"  Width="250px">
                            <asp:ListItem>S</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    <td style="text-align: right">
                        <asp:Label ID="Label16" runat="server" Text="Status:"></asp:Label>
                    </td>
                    <td class="style8">
                        <asp:RadioButtonList ID="ddlstatus" runat="server" Height="23px" 
                            onselectedindexchanged="ddlstatus_SelectedIndexChanged" 
                            RepeatDirection="Horizontal" Width="134px">
                            <asp:ListItem Value="A">Activo</asp:ListItem>
                            <asp:ListItem Value="B">Baja</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                    <tr>
                        <td class="cuadro_botones" colspan="4">
                            <br />
                            <asp:Button ID="BTN_Cancelar" runat="server" onclick="BTN_Cancelar_Click" 
                                Text="Cancelar" Height="30px" Width="80px" CssClass="btn2" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BTN_Guardar" runat="server" onclick="BTN_Guardar_Click" 
                                Text="Guardar" Height="30px" Width="80px" ValidationGroup="Guarda" CssClass="btn" />
                        </td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                <table class="tabla_contenido">               
                <tr>
                    <td class="style22">
                        <asp:Label ID="Label10" runat="server" Text="Buscar:" Visible="False"></asp:Label>
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="TXTbuscar" runat="server" Width="441px" 
                            style="margin-left: 7px" Visible="False"></asp:TextBox>
                        &nbsp;<br />
                    </td>
                    <td style="text-align: right">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        </asp:UpdatePanel>
                    </td>
                    <td class="style16">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center" >
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <div class="scroll">
                                <asp:GridView ID="grdcuentas_de_mayor" runat="server" Width="100%" 
                                    AutoGenerateColumns="False"  BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                    GridLines="Vertical" 
                                    onpageindexchanging="grdcuentas_de_mayor_PageIndexChanging" 
                                    onselectedindexchanged="grdcuentas_de_mayor_SelectedIndexChanged" CssClass="mGrid" EmptyDataText="No hay registros para mostrar">                                    
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                                        <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="CLAVE" HeaderText="CLAVE" ReadOnly="True" />
                                        <asp:BoundField DataField="naturaleza" HeaderText="NATURALEZA" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="rubro" HeaderText="RUBRO" ReadOnly="True" />
                                        <asp:BoundField DataField="nivel" HeaderText="NIVEL" ReadOnly="True" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Agregar <%# DataBinder.Eval(Container.DataItem, "nivel_des")%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbagregar" runat="server"
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' 
                                                    CommandName='<%# DataBinder.Eval(Container.DataItem, "clave") %>' 
                                                    onclick="lbagregar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">Eliminar</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                   <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />                                                
                                                <AlternatingRowStyle CssClass="alt" /> 
                                </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                        </td>
                    <td class="style8" colspan="3">
                        </td>
                </tr>
                
                <tr>
                    <td class="cuadro_botones" colspan="4">
                        <asp:ImageButton ID="BTNver_reporte" runat="server" Height="53px" 
                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" Width="49px" onclick="BTNver_reporte_Click" />
                        &nbsp;</td>
                </tr>
            </table>
                </asp:View>
            </asp:MultiView>
                
        </ContentTemplate>
    </asp:UpdatePanel>

    </asp:Content>
