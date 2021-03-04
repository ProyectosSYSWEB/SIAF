<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogoDependencias.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatalogoDependencias" %>

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
                    <td class="auto-style1">
                        <table style="width: 100%;">                            

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblCentroContab" runat="server" Text="Centro contable"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCentroContab" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblClvDepend" runat="server" Text="Clave dependencia">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtClvDepend" Text="" runat="server" Width="500px" MaxLength="5">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Nombre dependencia">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDependencia" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblTitular" runat="server" Text="Titular">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtTitular" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblAdministrador" runat="server" Text="Administrador">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtAdministrador" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDomicilio" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLEstado" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLEstado_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblMunicipio" runat="server" Text="Municipio"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLMunicipio" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblZonaEco" runat="server" Text="Zona economica">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtZonaEconomica" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblTelefonoTitular" runat="server" Text="Telefono titular">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtTelTitular" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblCelTitular" runat="server" Text="Telefono celular titular">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtCelTitular" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblTelAdmin" runat="server" Text="Telefono administrador">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtTelAdmin" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblCelAdmin" runat="server" Text="Telefono celular administrador">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtCelAdmin" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblNombramiento" runat="server" Text="Nombramiento">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtNombramiento" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="BTNGuardarDepend"  Text="Guardar" OnClick="BTNGuardarDepend_Click" />
                                </td>                    
                                <td>

                                </td>
                                <td>
                                    <a href="frmDependencia.aspx"> Regresar </a>
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
