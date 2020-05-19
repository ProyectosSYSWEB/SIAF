<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBasicos.aspx.cs" Inherits="SAF.Patrimonio.Form.frmBasicos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
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
            <td>      
    <asp:MultiView ID="MultiViewBasicos" runat="server">
    <asp:View ID="View1" runat="server">

        <table>
                              <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="Catálogo:"></asp:Label>
                </td>
                <td class="style1" width="75%">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" 
                        ViewStateMode="Enabled">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlTipoB" runat="server" AutoPostBack="True" Height="22px" 
                                onselectedindexchanged="ddlTipoB_SelectedIndexChanged" Width="300px"> 
                                    </asp:DropDownList> 
                              
                             </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style1" width="10%">
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Status:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlStatusB" runat="server" AutoPostBack="True" 
                                Height="22px" onselectedindexchanged="ddlStatusB_SelectedIndexChanged" 
                                Width="300px">
                                <asp:ListItem Value="T">TODOS</asp:ListItem>
                                <asp:ListItem Value="A">ALTA</asp:ListItem>
                                <asp:ListItem Value="B">BAJA</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td width="10%">
                    &nbsp;</td>
            </tr>
      

                            <tr>
                                <td class="auto-style3" xml:lang="15%">
                                    <asp:Label ID="Label2" runat="server" style="text-align: right" Text="Buscar:" 
                                        CssClass="style6"></asp:Label>
                                </td>
                                <td style="text-align: left" width="75%">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtBuscar" runat="server" style="margin-left: 7px; text-align: left;" 
                                                Width="441px" Height="22px"></asp:TextBox>
                                            <asp:ImageButton ID="BTNbuscar" runat="server" class="" Height="38px" 
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="BTNbuscar_Click" Width="39px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="text-align: right" width="10%">
                                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style14" xml:lang="15%">
                                    &nbsp;</td>
                                <td style="text-align: center" width="75%">
                                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel10">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q1" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" width="15%" style="text-align: left">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdBasicos"  runat="server" Width="100%" 
                                    AutoGenerateColumns="False"  BorderStyle="None" GridLines="Vertical" 
                                                onselectedindexchanged="grdBasicos_SelectedIndexChanged" AllowPaging="True" 
                                                EmptyDataText="No hay registros para mostrar" 
                                                onpageindexchanging="grdBasicos_PageIndexChanging" CssClass="mGrid">                                                
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                                                    <asp:BoundField DataField="status" HeaderText="ESTATUS" />
                                                    <asp:BoundField DataField="clave" HeaderText="CLAVE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                                                    <asp:BoundField DataField="VALOR" HeaderText="VALOR" />
                                                    <asp:BoundField DataField="ORDEN" HeaderText="ORDEN" />
                                                    <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnEliminar" runat="server" onclick="lbtnEliminar_Click" OnClientClick="return confirm ('¿Realmente desea eliminar el registro?');" >Eliminar</asp:LinkButton>
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
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                            </tr>
                            <tr>
                                <td class="cuadro_botones" colspan="3">
                                    <asp:ImageButton ID="BTNver_reporte" runat="server" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="BTNver_reporte_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="ImageButton3" runat="server" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
       </table>
                
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td class="style2" width="15%">
                                    &nbsp;</td>
                                <td width="75%">
                                    &nbsp;</td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="izquierda" width="15%">
                                    &nbsp;</td>
                                <td width="75%">
                                    &nbsp;</td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="izquierda" width="15%">
                                    <asp:Label ID="Label4" runat="server" Text="Catálogo:"></asp:Label>
                                </td>
                                <td width="75%">
                                    <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" 
                                        Height="20px" 
                                        Width="300px" ValidationGroup="Guardo">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="ddlTipo" ErrorMessage="*Seleccione otra opción" InitialValue="00000" 
                                        ValidationGroup="Guardo"></asp:RequiredFieldValidator>
                                </td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="izquierda" width="15%">
                                    <asp:Label ID="Label5" runat="server" Text="Estatus:"></asp:Label>
                                </td>
                                <td width="75%">
                                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                                        Height="20px" 
                                        Width="300px">
                                        <asp:ListItem>TODOS</asp:ListItem>
                                        <asp:ListItem Value="A">ALTA</asp:ListItem>
                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3" width="15%">
                                    Clave:</td>
                                <td class="style1" width="75%">
                                    <asp:TextBox ID="txtClave" runat="server" Height="20px" Width="300px" 
                                        ValidationGroup="Guardo"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtClave" ErrorMessage="*Requerido" ValidationGroup="Guardo"></asp:RequiredFieldValidator>
                                </td>
                                <td class="style1" width="10%">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="izquierda" width="15%">
                                    Descripción:</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtDescripcion" runat="server" Height="20px" Width="540px" 
                                        ValidationGroup="Guardo"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtDescripcion" ErrorMessage="*Requerido" 
                                        ValidationGroup="Guardo"></asp:RequiredFieldValidator>
                                </td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style4" width="15%">
                                    Valor:</td>
                                <td class="style5" width="75%">
                                    <asp:TextBox ID="txtvalor" runat="server" Height="20px" Width="300px"></asp:TextBox>
                                </td>
                                <td class="style5" width="10%">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="izquierda" width="15%">
                                    Orden:</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtOrden" runat="server" Height="20px" Width="300px"></asp:TextBox>
                                </td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="style2" width="15%">
                                    &nbsp;</td>
                                <td width="75%">
                                    &nbsp;</td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="cuadro_botones" colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn2" onclick="btnCancelar_Click1" Text="Cancelar" />
                                            &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn" onclick="btnGuardar_Click1" Text="Guardar" ValidationGroup="Guardo" />
                                            &nbsp;<asp:Button ID="btnContinuar" runat="server" CssClass="btn" onclick="BTN_continuar_Click" Text="Guardar y Continuar" ValidationGroup="Guardo" Width="133px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" width="15%">
                                    &nbsp;</td>
                                <td style="text-align: center" width="75%">
                                    &nbsp;</td>
                                <td width="10%">
                                    &nbsp;</td>
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            height: 21px;
            width: 96px;
        }
        .style4
        {
            width: 96px;
            height: 26px;
        }
        .style5
        {
            height: 26px;
        }
        .style6
        {
            height: 21px;
            width: 112px;
            text-align: right;
        }
        .style13
        {
            height: 21px;
            width: 111px;
            text-align: right;
        }
        .style14
        {
        }
        .style15
        {
            width: 121px;
        }
        .auto-style1 {
            width: 111px;
            height: 17px;
        }
        .auto-style2 {
            height: 17px;
        }
        .auto-style3 {
            height: 21px;
            width: 111px;
            text-align: left;
        }
    </style>

</asp:Content>

