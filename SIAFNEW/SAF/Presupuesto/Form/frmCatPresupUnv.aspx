<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatPresupUnv.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatPresupUnv" %>

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
                                <td style="width: 10%">
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label1" runat="server" Text="Fuente"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList runat="server" Width="300px" AutoPostBack="True" ></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DropDownList1" runat="server" Width="300px" AutoPostBack="True" ></asp:DropDownList>--%>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap1" runat="server" Text="Capitulo 1000"/>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap2" runat="server" Text="Capitulo 2000"/>
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap3" runat="server" Text="Capitulo 3000"/>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap4" runat="server" Text="Capitulo 4000"/>
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap5" runat="server" Text="Capitulo 5000"/>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap6" runat="server" Text="Capitulo 6000"/>
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap7" runat="server" Text="Capitulo 7000"/>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap8" runat="server" Text="Capitulo 8000"/>
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCapT" runat="server" Text="Todos"/>
                                </td>
                            </tr>



                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate> <%--ID="GRDcierre"--%>
                                            <asp:GridView  runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<asp:LinkButton ID="LinkButton1" onclientclick="return confirm('Al cerrar la dependencia, la plantilla queda en bitacora y las modificaciones seran atendidas con su operador');" runat="server" OnClick="LinkButton1_Click">CERRAR</asp:LinkButton>--%>
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
