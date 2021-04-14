<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPresupUnv.aspx.cs" Inherits="SAF.Presupuesto.Form.frmPresupUnv" %>

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
                            <tr>                            
                                <td colspan="3">                            
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" ValidationGroup="Agregar" />
                                            <asp:GridView ID="GRDCodProg" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro." OnSelectedIndexChanged="GRDCodProg_SelectedIndexChanged1">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Consecutivo"/>
                                                    <asp:BoundField DataField="Tipo_Gasto" HeaderText="Tipo " />
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Referencia_Documento" HeaderText="Referencia Documento" />
                                                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                                                    <asp:BoundField DataField="Codigo_Programatico" HeaderText="Codigo Programatico" />     
                                                    <asp:BoundField DataField="Autorizado" HeaderText="Autorizado" ItemStyle-HorizontalAlign="Right" />    
                                                    <asp:BoundField DataField="Tipo_Gasto_Param" HeaderText="Tipo_Gasto_Param" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" />
                                                    <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnReporte" runat="server" CommandName="Select" Visible="true">Reporte</asp:LinkButton>
                                                                    <asp:Label ID="lblReporte" runat="server" ForeColor="#6B696B" Text="Reporte" Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                </Columns>

                                                <FooterStyle CssClass="enc" />
                                                <%--<PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />--%>
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
