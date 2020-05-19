<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCuentas_Bancarias.aspx.cs" Inherits="SAF.Contabilidad.Form.frmCuentas_Bancarias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 150px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" 
    Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <table class="tabla_contenido">
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width:100%;">                           
                            <tr>
                                <td align="center">
                                    <table style="width:100%;">                                        
                                        <tr>
                                            <td align="right" class="style1" valign="top">
                                                <asp:Label ID="lblCentros_Contables0" runat="server" Text="Centro Contable:"></asp:Label>
                                            </td>
                                            <td align="left" >
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlCentros_Contables0" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlCentros_Contables0_SelectedIndexChanged" Width="95%">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="ddlCentros_Contables0" ErrorMessage="*Requerido" 
                                                            InitialValue="00000" ValidationGroup="CuentaBancaria"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="derecha" >
                                                <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel1">
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
                                <td align="center">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvCuentas_Bancarias" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False"  BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                GridLines="Vertical" 
                                                onpageindexchanging="grvCuentas_Bancarias_PageIndexChanging" 
                                                onselectedindexchanged="grvCuentas_Bancarias_SelectedIndexChanged" CssClass="mGrid">                                                
                                                <Columns>
                                                    <asp:BoundField DataField="IdCuenta_Bancaria" HeaderText="Id" />
                                                    <asp:BoundField DataField="CLAVE" HeaderText="Clave" />
                                                    <asp:BoundField DataField="CENTRO_CONTABLE" HeaderText="Centro Contable" />
                                                    <asp:BoundField DataField="BANCO" HeaderText="Banco" />
                                                    <asp:BoundField DataField="CUENTA_BANCARIA" HeaderText="Cuenta Bancaria" />
                                                    <asp:BoundField DataField="CUENTA_CONTABLE" HeaderText="Cuenta Contable" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
                                                    <asp:BoundField DataField="FECHA_APERTURA" HeaderText="Fecha Apertura" />
                                                    <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                    <asp:CommandField ShowDeleteButton="True" />
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
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblCentros_Contables" runat="server" Text="Centro Contable:"></asp:Label>
                                </td>
                                <td width="55%" align="left" colspan="2" style="width: 70%">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel5">
                                        <progresstemplate>
                                            <asp:Image ID="Image7" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlCentros_Contables" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="ddlCentros_Contables_SelectedIndexChanged" Width="95%">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblCuenta_Contable" runat="server" Text="Cuenta Contable:"></asp:Label>
                                </td>
                                <td align="left" colspan="2" style="width: 70%" width="55%">
                                    <asp:DropDownList ID="ddlCuentas_Contables" runat="server" Width="95%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblClave" runat="server" Text="Clave:"></asp:Label>
                                </td>
                                <td width="55%" align="left">
                                    <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                        ControlToValidate="txtClave" ErrorMessage="RequiredFieldValidator" 
                                        ValidationGroup="GuardaCuentaBancaria">*Requerido</asp:RequiredFieldValidator>
                                </td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblBanco" runat="server" Text="Banco:"></asp:Label>
                                </td>
                                <td align="left" width="55%">
                                    <asp:DropDownList ID="ddlBancos" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblCuenta_Bancaria" runat="server" Text="Cuenta Bancaria:"></asp:Label>
                                </td>
                                <td width="55%" align="left">
                                    <asp:TextBox ID="txtCuenta_Bancaria" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="txtCuenta_Bancaria" ErrorMessage="RequiredFieldValidator" 
                                        ValidationGroup="GuardaCuentaBancaria">*Requerido</asp:RequiredFieldValidator>
                                </td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                                </td>
                                <td width="55%" align="left">
                                    <asp:TextBox ID="txtDescripcion" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td width="15%" align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                        ControlToValidate="txtDescripcion" ErrorMessage="RequiredFieldValidator" 
                                        ValidationGroup="GuardaCuentaBancaria">*Requerido</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="Label7" runat="server" Text="Fecha Apertura:"></asp:Label>
                                </td>
                                <td width="55%" align="left">
                                    <asp:TextBox ID="txtFecha_Apertura" runat="server" AutoPostBack="True" 
                                        CssClass="box"
                                        Width="95px"></asp:TextBox>
                                    <img alt="Ver calendario" 
                                onclick="new CalendarDateSelect( $(this).previous(), {year_range:0} );" 
                                src="../../images/Calendario.gif" style="cursor: pointer" />
                                </td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                                </td>
                                <td width="55%" align="left">
                                    <asp:TextBox ID="txtLocalidad" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td width="15%" align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                        ControlToValidate="txtLocalidad" ErrorMessage="RequiredFieldValidator" 
                                        ValidationGroup="GuardaCuentaBancaria">*Requerido</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td width="55%" align="left">
                                    <asp:RadioButtonList ID="rdoBttnStatus" runat="server" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="B">Baja</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="15%" class="izquierda">
                                    &nbsp;</td>
                                <td width="55%">
                                    &nbsp;</td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="cuadro_botones" colspan="3" style="width: 30%">
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn2" Height="30px" onclick="btnCancelar_Click" Text="Cancelar" Width="80px" />
                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn" Height="30px" onclick="btnGuardar_Click" Text="Guardar" ValidationGroup="GuardaCuentaBancaria" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">
                                    &nbsp;</td>
                                <td width="55%">
                                    &nbsp;</td>
                                <td width="15%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            
        </tr>
       
    </table>
</asp:Content>
