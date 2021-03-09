<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCapitulo.aspx.cs" EnableEventValidation="false" Inherits="SAF.Presupuesto.Form.frmCapitulo" %>

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
                                <a href="frmCatalogoCapitulos.aspx">Nuevo capitulo</a>
                             <tr>                                
                            </tr>
                                <td colspan="3">                            
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GRDCapitulos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro." OnRowCommand="GRDCapitulos_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150" Visible="true">
                                                        <ItemTemplate>                                                            
                                                            <asp:Label ID="clave" runat="server" Text='<%# Eval("clave") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="clave" HeaderText="Clave" />                                                                                                        --%>
                                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />                                                    
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button Text="Editar" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button Text="Eliminar" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" OnClick="BtnEliminarRegistro" />
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
