<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMCosteo.aspx.cs" Inherits="SAF.Presupuesto.Form.FRMCosteo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
        .auto-style2 {
            font-size: 15pt;
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
                    <td class="centro" colspan="3">
                        <strong>
                        <asp:Label ID="Label11" runat="server" Text="Prestaciones Ligadas al Salario" CssClass="auto-style2"></asp:Label>
                        </strong>
                    </td>   
                </tr>     
                 <tr>
                     <td colspan="3"><strong>
                         <asp:Label ID="Label14" runat="server" Text="Prestaciones de CCT"></asp:Label>
                         </strong></td>
                </tr>
                 <tr>
                    <td style="width:30%">
                        <asp:Label ID="Label12" runat="server" Text="Ejercicio:"></asp:Label>
                    </td>   
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlEjercicio" runat="server" OnSelectedIndexChanged="ddlEjercicio_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="2014">Ejercicio 2014</asp:ListItem>
                                    <asp:ListItem Value="2015">Ejercicio 2015</asp:ListItem>
                                    <asp:ListItem Value="2016">Ejercicio 2016</asp:ListItem>
                                    <asp:ListItem Value="2017">Ejercicio 2017</asp:ListItem>
                                    <asp:ListItem Value="2018">Ejercicio 2018</asp:ListItem>
                                    <asp:ListItem Value="2019">Ejercicio 2019</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>  
                    <td>
                        &nbsp;</td>                   
                </tr>  
                 <tr>
                     <td>
                         <asp:Label ID="Label24" runat="server" Text="Semestre:"></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="DDLSemestre" runat="server" AutoPostBack="True" Width="37%">
                         </asp:DropDownList>
                     </td>
                     <td>&nbsp;</td>
                </tr>
                 <tr>
                     <td>
                         <asp:Label ID="Label4" runat="server" Text="Dependencia:"></asp:Label>
                     </td>
                     <td>
                         <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                             <ContentTemplate>
                                 <asp:DropDownList ID="DDLDependencia" runat="server" Width="75%">
                                 </asp:DropDownList>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                     </td>
                     <td></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Tipo Personal:"></asp:Label>
                    </td>   
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDL_Tipo0" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="DDL_Tipo0_SelectedIndexChanged">
                                    <asp:ListItem Value="T">TODOS</asp:ListItem>
                                    <asp:ListItem Value="A">ADMINISTRATIVO DE BASE</asp:ListItem>
                                    <asp:ListItem Value="C">CONFIANZA</asp:ListItem>
                                    <asp:ListItem Value="D">DOCENTE</asp:ListItem>
                                    <asp:ListItem Value="M">PEMEX</asp:ListItem>
                                    <asp:ListItem Value="U">TURNEROS</asp:ListItem>
                                    <asp:ListItem Value="H">HONORARIOS</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>  
                    <td>
                        &nbsp;</td>                   
                </tr>             
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="Rango de Meses:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMeses" runat="server" Width="100px">
                            <asp:ListItem Value="7">07-Semestre Enero-Julio</asp:ListItem>
                            <asp:ListItem Value="5">05-Semestre Aagosto-Diciembre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Prima Vacacional:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtprima" runat="server" Width="100px"></asp:TextBox>
                        <asp:Label ID="Label16" runat="server" Text="%"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Aguinaldo:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtaguinaldo" runat="server" Width="100px"></asp:TextBox>
                        <asp:Label ID="Label17" runat="server" Text="Dias"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Ajuste de Calendario:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtajuste_c" runat="server" Width="100px"></asp:TextBox>
                        <asp:Label ID="Label22" runat="server" Text="Dias"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <strong>
                        <asp:Label ID="Label15" runat="server" Text="Cuotas de Seguridad Social"></asp:Label>
                        </strong>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="ISSSTE:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtissste" runat="server" Width="100px"></asp:TextBox>
                        <asp:Label ID="Label19" runat="server" Text="%"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="FOVISSSTE:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfovissste" runat="server" CssClass="auto-style1" Width="100px"></asp:TextBox>
                        <asp:Label ID="Label20" runat="server" Text="%"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="SAR:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsar" runat="server" Width="100px"></asp:TextBox>
                        <asp:Label ID="Label21" runat="server" Text="%"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="TIPO PLANTILLA:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddltipo_plantilla" runat="server" OnSelectedIndexChanged="ddltipo_plantilla_SelectedIndexChanged">
                            <asp:ListItem Value="S">Actual</asp:ListItem>
                            <asp:ListItem Value="P">Historico</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" class="cuadro_botones">
                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgBttnPDF" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png"  title="Reporte PDF" OnClick="imgBttnPDF_Click" />
                                <asp:ImageButton ID="imgBttnExcel" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf2.png" title="Reporte Excel" OnClick="imgBttnExcel_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
