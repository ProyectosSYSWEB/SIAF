<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentaSemovientes.aspx.cs" Inherits="SAF.Form.frmVentaSemovientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style14 {
        }

        .style16 {
            width: 12%;
        }

        .style17 {
            width: 236px;
        }

        .style19 {
            width: 18%;
            text-align: left;
        }

        .style20 {
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


    <%--<script type="text/javascript">
    
    function enter_boton(e) {
        if (typeof e == 'undefined' && window.event) { e = window.event; }
        if (e.keyCode == 13) {
            document.getElementById("ctl00_MainContent_TabContainer1_TabPanel2_btnAgregar").focus();
            return true;
        }
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

       
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table class="auto-style2">

                                    <tr>
                                        <td colspan="3"></td>

                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>

                                    </tr>

                                    <tr>
                                        <td class="auto-style4" valign="top">
                                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>

                                        </td>
                                        <td class="style14" valign="top">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="DDLDependencia" ErrorMessage="*Requerido" 
                            InitialValue="00000" ValidationGroup="Encabezado"></asp:RequiredFieldValidator>--%>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" title="Nuevo" CausesValidation="False" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                        </td>
                                        <td class="style9" valign="top">
                                            <asp:DropDownList ID="DDLStatus" runat="server">
                                                <asp:ListItem Value="A">AUTORIZADOS</asp:ListItem>
                                                <asp:ListItem Value="V">VENDIDOS</asp:ListItem>
                                                <asp:ListItem Value="T">TODOS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <td></td>
                                    </tr>


                                    <tr>
                                        <td align="right" class="auto-style4">
                                            <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
                                        </td>
                                        <td class="style14">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="True" CssClass="textbuscar"
                                                        placeHolder="No. de inventario/Descripción/No. de arete" Width="98%"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left">
                                            <asp:ImageButton ID="imgbtnBuscar" runat="server" CausesValidation="False" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" Style="text-align: right" title="Buscar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top" class="style8" colspan="3" width="100%">
                                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image7" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                        Width="50px" AlternateText="Espere un momento, por favor.."
                                                        ToolTip="Espere un momento, por favor.." />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                        Width="50px" AlternateText="Espere un momento, por favor.."
                                                        ToolTip="Espere un momento, por favor.." />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvSemovientesAV" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="mGrid" EmptyDataText="No hay registros para mostrar" GridLines="Vertical" OnPageIndexChanging="grvSemovientesAV_PageIndexChanging" PageSize="25" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" />
                                                            <asp:BoundField DataField="No_inventario" HeaderText="No. INVENTARIO">

                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN" />
                                                            <asp:BoundField DataField="Sem_Peso" HeaderText="PESO (Kg)">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="COSTO" DataFormatString="{0:c}" HeaderText="COSTO">
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Estatus" HeaderText="STATUS">


                                                                <ItemStyle HorizontalAlign="Center" />

                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_FechaNac_Str" HeaderText="FECHA AUTORIZACIÓN">


                                                                <ItemStyle HorizontalAlign="Center" />

                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_FechaRevalorizado_Str" HeaderText="FECHA VENTA">

                                                                <ItemStyle HorizontalAlign="Center" />

                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Validado" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" OnClick="linkBttnEliminar_Click" OnClientClick="return confirm('¿Desea cancelar la autorización de venta?');" Visible='<%# Bind("Validado") %>'>Eliminar</asp:LinkButton>

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
                                        <td colspan="3"></td>
                                    </tr>

                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td colspan="5"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="center">
                                            <asp:Label ID="lblDependenciaDes" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style5" valign="top">
                                            <asp:Label ID="lblSemovientes" runat="server" Text="Semovientes:"></asp:Label>
                                        </td>
                                        <td colspan="4" valign="top">
                                            <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True"
                                                onkeyup="RefreshUpdatePanel();"
                                                OnTextChanged="txtSearch_TextChanged" Width="98%"></asp:TextBox>
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="DDLSemovientes" runat="server"
                                                        Width="98%"></asp:ListBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtSearch"></asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="DDLSemovientes" ErrorMessage="*Requerido"
                                                ValidationGroup="Detalle"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td class="style7" valign="top">
                                            <asp:Label ID="lblPeso" runat="server" Text="Peso(Kg):"></asp:Label>
                                            <asp:TextBox ID="txtPeso" runat="server">0</asp:TextBox>
                                            <%-- onKeyDown="return enter_abono(event);" onkeyup="mascara(this,'C');"--%>


                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtPeso" ErrorMessage="*Requerido"
                                                ValidationGroup="Detalle"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator104"
                                                runat="server" ControlToValidate="txtPeso" SetFocusOnError="True"
                                                ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$"
                                                ValidationGroup="Detalle">*Formato (999,999,999.99)</asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right" class="style6" valign="top">
                                            <asp:Label ID="lblCosto" runat="server" Text="Costo:"></asp:Label>
                                        </td>
                                        <td align="left" class="style2" valign="top">
                                            <asp:TextBox ID="txtCosto" runat="server">0</asp:TextBox>
                                            <%--onKeyDown="return enter_boton(event);" onkeyup="mascara(this,'A');"--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="txtCosto" ErrorMessage="*Requerido"
                                                ValidationGroup="Detalle"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                ControlToValidate="txtCosto" SetFocusOnError="True"
                                                ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$"
                                                ValidationGroup="Detalle">*Formato (999,999,999.99) 
                                                                                                                    Números</asp:RegularExpressionValidator>
                                        </td>
                                        <td valign="top" width="25%" class="izquierda">
                                            <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnAgregar_Click" ValidationGroup="Detalle" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="5" valign="top" width="100%">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvSemPreAutorizados" runat="server"
                                                        AutoGenerateColumns="False"
                                                        OnRowDeleting="grvSemPreAutorizados_RowDeleting"
                                                        Width="90%" CssClass="mGrid" OnPageIndexChanging="grvSemPreAutorizados_PageIndexChanging" AllowPaging="True">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="Id"
                                                                ReadOnly="True"></asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Arete" HeaderText="No. Arete"
                                                                ReadOnly="True">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="No_Inventario" HeaderText="No. Inventario"
                                                                ReadOnly="True">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción"
                                                                ReadOnly="True"></asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Etapa" HeaderText="Etapa"
                                                                ReadOnly="True">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Especie" HeaderText="Especie"
                                                                ReadOnly="True">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Peso" DataFormatString="{0:c}" HeaderText="Peso (Kg)">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Costo" DataFormatString="{0:c}" HeaderText="Costo">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
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
                                        <td align="center" colspan="5" style="width: 60%" class="cuadro_botones">
                                            <asp:Button ID="btnCancelar" runat="server" Height="30px" OnClick="btnCancelar_Click"
                                                Text="Cancelar" Width="80px" CausesValidation="False" CssClass="btn2" />
                                            &nbsp;<asp:Button ID="btnGuardar" runat="server" Height="30px" OnClick="btnGuardar_Click"
                                                Text="Autorizar" Width="80px" ValidationGroup="General" CssClass="btn" Enabled="False" />
                                        </td>
                                    </tr>
                                    </tr>                                                                                            
                                                                                            </tr>
                                </table>
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
