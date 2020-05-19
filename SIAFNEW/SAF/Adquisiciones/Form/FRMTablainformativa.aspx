<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMTablainformativa.aspx.cs" Inherits="SAF.Adquisiciones.Form.FRMTablainformativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:GridView ID="GrdTablaInformativa" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" EmptyDataText="NO HAY DATOS PARA MOSTRAR" 
                                            GridLines="Vertical" OnPageIndexChanging="GridTablaInformativa_PageIndexChanging" 
                                            OnRowDataBound="GridTablaInformativa_RowDataBound"                                    
                                            onselectedindexchanged="GrdTablaInformativa_SelectedIndexChanged" CssClass="mGrid">
                                            <Columns>
                                                <asp:BoundField DataField="ID_UR" HeaderText="CLAVE" />
                                                <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCIÓN">
                                                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="registrada" HeaderText="REGISTRADA" />
                                                <asp:BoundField DataField="solicitada" HeaderText="SOLICITADA" />
                                                <asp:BoundField DataField="denegada" HeaderText="DENEGADA" />
                                                <asp:BoundField DataField="autorizada" HeaderText="AUTORIZADA" />
                                                <asp:BoundField DataField="cotizacion" HeaderText="COTIZACIÓN" />
                                                <asp:BoundField DataField="visto_bueno" HeaderText="VISTO BUENO" />
                                                <asp:BoundField DataField="concluida" HeaderText="CONCLUIDA" />
                                                <asp:BoundField DataField="cancelada" HeaderText="CANCELADA" />
                                                <asp:BoundField DataField="total" HeaderText="TOTAL" />
                                                <asp:BoundField DataField="avance" HeaderText="AVANCE %" />
                                            </Columns>
                                             <FooterStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                                <HeaderStyle CssClass="enc" />                                                
                                                                <AlternatingRowStyle CssClass="alt" /> 
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td style="text-align: center">
                                        &nbsp;
                                        </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
</asp:Content>
