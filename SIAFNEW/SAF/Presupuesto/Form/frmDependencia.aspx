<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDependencia.aspx.cs" Inherits="SAF.Presupuesto.Form.frmDependencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }

        .ColumnaOculta {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<div class="mensaje">
                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>

            <table class="tabla_contenido">
                <tr>
                    <td class="auto-style1">
                        <table style="width: 100%">
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>

                                        <asp:MultiView ID="Multiview1" runat="server">
                                            <asp:View ID="View_1" runat="server">
                                                <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" ValidationGroup="Agregar" />
                                                <br />
                                                <asp:Label ID="lblCentroContab" runat="server" Text="Centro contable"></asp:Label>
                                                <asp:DropDownList ID="DDLCentroContab" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCentroContab_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="LBLNumDepend" runat="server"></asp:Label>
                                                <br />

                                                <asp:GridView ID="GDRDependencias" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro." OnRowDeleting="GDRDependencias_RowDeleting" OnSelectedIndexChanged="GDRDependencias_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="C_Contab" HeaderText="Centro contable" />
                                                        <asp:BoundField DataField="Depend" HeaderText="Dependencia" />
                                                        <asp:BoundField DataField="Descrip" HeaderText="Descripcion" />
                                                        <asp:BoundField DataField="Titular" HeaderText="Titular" />
                                                        <asp:BoundField DataField="Administ" HeaderText="Administrador" />
                                                        <asp:BoundField DataField="Titular_Puesto" HeaderText="Puesto titular" />
                                                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnEditar" runat="server" CommandName="Select" Visible="true">Editar</asp:LinkButton>
                                                                <asp:Label ID="lblEditar" runat="server" ForeColor="#6B696B" Text="Editar" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" Visible="true">Eliminar</asp:LinkButton>
                                                                <asp:Label ID="lblEliminar" runat="server" ForeColor="#6B696B" Text="Eliminar" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                            </asp:View>
                                            <asp:View ID="View_2" runat="server">
                                                <table class="tabla_contenido">
                                                    <tr>
                                                        <td class="auto-style1">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="Label1" runat="server" Text="Centro contable"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DDLCentroContab2" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblClvDepend" runat="server" Text="Clave dependencia">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtClvDepend" Text="" runat="server" Width="500px" MaxLength="5">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblDependencia" runat="server" Text="Nombre dependencia">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtDependencia" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblTitular" runat="server" Text="Titular">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtTitular" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblNombramiento" runat="server" Text="Nombramiento del titular">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtNombramiento" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblAdministrador" runat="server" Text="Administrador">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtAdministrador" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblNombramientoAdmin" runat="server" Text="Nombramiento del administrador">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtNombAdmin" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtDomicilio" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DDLEstado" runat="server" Width="500px" AutoPostBack="True" Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblMunicipio" runat="server" Text="Municipio"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DDLMunicipio" runat="server" Width="500px" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblZonaEco" runat="server" Text="Zona economica">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtZonaEconomica" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblTelefonoTitular" runat="server" Text="Telefono titular">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtTelTitular" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblCelTitular" runat="server" Text="Telefono celular titular">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtCelTitular" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblTelAdmin" runat="server" Text="Telefono administrador">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtTelAdmin" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%">
                                                                        <asp:Label ID="lblCelAdmin" runat="server" Text="Telefono celular administrador">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 80%">
                                                                        <asp:TextBox ID="txtCelAdmin" Text="" runat="server" Width="500px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>




                                                                <tr>
                                                                    <td>
                                                                        <asp:Button runat="server" ID="BTNEditarDependencia" Text="Guardar" OnClick="BTNEditarDependencia_Click" />
                                                                    </td>
                                                                    <td></td>
                                                                    <td>
                                                                        <a href="frmDependencia.aspx">Regresar </a>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
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
