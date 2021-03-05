<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProyecto.aspx.cs" Inherits="SAF.Presupuesto.Form.frmProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
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
                        <table style="width: 100%">
                            <tr>
                                <a href="frmCatalogoProyecto.aspx">Nuevo proyecto</a>


                                <td style="width: 30%">
                                    <asp:Label ID="lblTipoProy" runat="server" Text="Tipo proyecto"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLTipoProy" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoProy_SelectedIndexChanged"></asp:DropDownList>
                                </td>

                             <tr>
                             
                            </tr>
                                <td colspan="3">                            
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GRDProyectos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <%--<asp:BoundField DataField="Tipo_Proy" HeaderText="Tipo proyecto" />--%>
                                                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" />
                                                    <asp:BoundField DataField="Descrip" HeaderText="Descripcion" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" onclientclick="return confirm('¿Desea eliminar el Documento?');" Visible='<%# Bind("Opcion_Eliminar") %>'>Eliminar</asp:LinkButton>
                                                                    <asp:Label ID="lblEliminar" runat="server" ForeColor="#6B696B" Text="Eliminar" Visible='<%# Bind("Opcion_Eliminar2") %>'></asp:Label>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
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
                                <td>&nbsp;</td>
                            </tr>
                        </table>                        
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
