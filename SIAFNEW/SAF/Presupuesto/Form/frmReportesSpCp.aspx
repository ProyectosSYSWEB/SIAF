<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportesSpCp.aspx.cs" Inherits="SAF.Presupuesto.Form.frmReportesSpCp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td class="auto-style1">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <tr>
                                                <td class="col1">
                                                <asp:Label ID="Label1" runat="server" Text="Reporte" Width="160px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DDLReporte" runat="server" Width="500px" AutoPostBack="True" >
                                                <asp:ListItem Value="RPT-CP01_ADMIN.rpt">RPT CP01 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CP07_ADMIN.rpt">RPT CP07 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CP08_ADMIN.rpt">RPT CP08 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CP09_ADMIN.rpt">RPT CP09 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CP09nv2_ADMIN.rpt">RPT CP09nv2 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CP09nv3_ADMIN.rpt">RPT CP09nv3 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CP09nv5_ADMIN.rpt">RPT CP09nv5 ADMIN</asp:ListItem>
                                                <asp:ListItem Value="RPT-CPO2_ADMIN.rpt">RPT CPO2 ADMIN</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td class="col1">
                                                    <asp:Label ID="lblMesIni" runat="server" Text="Mes inicial" Width="160px"></asp:Label>
                                                </td>
                                                <td class="col1">
                                                    <asp:DropDownList ID="ddlMesIni" runat="server" Width="150px">
                                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td class="col1">
                                                    <asp:Label ID="lblMesFin" runat="server" Text="Mes final"></asp:Label>
                                                </td>
                                                <td class="col1">
                                                    <asp:DropDownList ID="ddlMesFin" runat="server" Width="150px">
                                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button runat="server" id="btnGenerarReporte" class="btn btn-success" onclick="btn_generar_reporte"  imageurl="http://sysweb.unach.mx/resources/imagenes/pdf.png" title="Reporte PDF" Text="Generar Reporte"/>
                                                </td>
                                            </tr>
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
