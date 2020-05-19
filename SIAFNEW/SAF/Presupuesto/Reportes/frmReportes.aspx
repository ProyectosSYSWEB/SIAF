<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="SAF.Presupuesto.Reportes.frmReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress><asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Dependencia:"></asp:Label>
                                        </td>
                                        <td colspan="4">
                                            <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2">
                                            <asp:Label ID="Label5" runat="server" Text="Capitulo:"></asp:Label>
                                        </td>
                                        <td colspan="2" rowspan="2">
                                            <asp:GridView ID="grdCapitulo" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkcapitulo" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                                    <asp:BoundField DataField="capitulo" HeaderText="CAPITULO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />                                                
                                                    <AlternatingRowStyle CssClass="alt" /> 
                                            </asp:GridView>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Tipo:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddltipo" runat="server" Width="100%">
                                                <asp:ListItem>AUMENTO</asp:ListItem>
                                                <asp:ListItem>AUTORIZADO</asp:ListItem>
                                                <asp:ListItem>MODIFICADO</asp:ListItem>
                                                <asp:ListItem Value="DISMINUCION">DISMINUCIÓN</asp:ListItem>
                                                <asp:ListItem>COMPROMETIDO</asp:ListItem>
                                                <asp:ListItem Value="XMINISTRAR">X MINISTRAR</asp:ListItem>
                                                <asp:ListItem>MINISTRADO</asp:ListItem>
                                                <asp:ListItem>EJERCIDO</asp:ListItem>
                                                <asp:ListItem Value="XEJERCER">X EJERCER</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Ministrable:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlministrable" runat="server" Width="100%">
                                                <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                <asp:ListItem Value="1">MINISTRABLE</asp:ListItem>
                                                <asp:ListItem Value="2">NO MINISTRABLE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:25%">
                                            &nbsp;</td>
                                        <td style="width: 25%">
                                            &nbsp;</td>
                                        <td style="width: 25%" colspan="2">
                                            &nbsp;</td>
                                        <td style="width: 25%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Fuente de financiamiento:"></asp:Label>
                                        </td>
                                        <td colspan="4">
                                            <asp:GridView ID="grdFuente" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="OK">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkfuente" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FUENTE" HeaderText="FUENTE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCIÓN" />
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
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="cuadro_botones" colspan="5">
                                            <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnPdf" title="Reporte PDF" />
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" title="Reporte Excel" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                        </asp:UpdatePanel>
                    </asp:View>
                </asp:MultiView>                
            </td>
        </tr>
     </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
