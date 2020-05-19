<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportesSem.aspx.cs" Inherits="SAF.Patrimonio.Reportes.frmReportesSem" %>
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
                 <td>

               
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td style="width:15%">
                                    <asp:Label ID="Label29" runat="server" Text="Reporte:"></asp:Label></td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                    <asp:DropDownList ID="DDLReportes" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DDLReportes_SelectedIndexChanged">
                                                                        <asp:ListItem Value="RP-SemovienteEspecie">INVENTARIO POR ESPECIE</asp:ListItem>
                                                                        <asp:ListItem Value="RP-SemovienteSexo">INVENTARIO POR SEXO</asp:ListItem>
                                                                        <asp:ListItem Value="RP-SemovienteEtapaDetalle">INVENTARIO POR ETAPA</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                   </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEspecie" runat="server" Text="Especie:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLEspecie" runat="server" Width="250px"></asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLStatus" runat="server" Width="100px">
                                        <asp:ListItem Value="A">ALTA</asp:ListItem>
                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="80%">
                                    </asp:DropDownList>
                                </td>
                               
                            </tr>
                             <tr>
                        <td class="style1">
                            <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                        </td>
                        <td class="style3" colspan="2">
                            <asp:DropDownList ID="DDLMes" runat="server" Width="15%">
                                                                <asp:ListItem Value="0001">Enero</asp:ListItem>
                                                                <asp:ListItem Value="0102">Febrero</asp:ListItem>
                                                                <asp:ListItem Value="0203">Marzo</asp:ListItem>
                                                                <asp:ListItem Value="0304">Abril</asp:ListItem>
                                                                <asp:ListItem Value="0405">Mayo</asp:ListItem>
                                                                <asp:ListItem Value="0506">Junio</asp:ListItem>
                                                                <asp:ListItem Value="0607">Julio</asp:ListItem>
                                                                <asp:ListItem Value="0708">Agosto</asp:ListItem>
                                                                <asp:ListItem Value="0809">Septiembre</asp:ListItem>
                                                                <asp:ListItem Value="0910">Octubre</asp:ListItem>
                                                                <asp:ListItem Value="1011">Noviembre</asp:ListItem>
                                                                <asp:ListItem Value="1112">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                       
                    </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnAceptar" runat="server" Height="53px" 
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" Width="51px" onclick="btnAceptar_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel8">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q1" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>
                       </td>
            </tr>           
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
