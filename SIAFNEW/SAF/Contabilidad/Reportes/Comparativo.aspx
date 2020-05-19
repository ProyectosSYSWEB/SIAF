<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comparativo.aspx.cs" Inherits="SAF.Contabilidad.Reportes.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 138px;
        }
        .auto-style1 {
            width: 40%;
            text-align: center;
        }
        .auto-style2 {
            width: 8%;
        }
        .auto-style4 {
            width: 156px;
        }
        .auto-style5 {
            width: 740px;
        }
        .auto-style7 {
            width: 134px;
        }
        .auto-style8 {
            width: 239px;
            text-align: right;
        }
        .auto-style9 {
            width: 740px;
            text-align: right;
        }
        </style>
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


        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="izquierda">
                            <asp:Label ID="Label3" runat="server" Text="Cuenta Contable:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddl_cuentas" runat="server" 
                                        onselectedindexchanged="ddl_cuentas_SelectedIndexChanged" Width="296px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="izquierda">
                            <asp:Label ID="lbl_f_ini" runat="server" style="text-align: right" 
                                Text="Mes Inicial:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="txtmes_inicial" runat="server" 
                                onselectedindexchanged="txtmes_inicial_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"  class="cuadro_botones">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnAceptar" runat="server" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnAceptar_Click" Width="51px" />
                                    <asp:ImageButton ID="xls" runat="server" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" 
                                        style="text-align: center" Width="49px" onclick="xls_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel3">
                                <progresstemplate>
                                    <asp:Image ID="Image1q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%;">
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
                                <td class="cuadro_botones">
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" 
                                                style="text-align: center" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: center">
                                    &nbsp;
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel6">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q0" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="30px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="30px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="center" colspan="5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel8">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q1" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="30px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="30px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>                                
                                <td valign="top" class="auto-style2">
                                    <asp:Label ID="lblmes_inicial0" runat="server" style="text-align: right" 
                                        Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td valign="top" width="10%">
                                    <asp:DropDownList ID="ddlMes_inicial" runat="server" 
                                        onselectedindexchanged="txtmes_inicial_SelectedIndexChanged">
                                        <asp:ListItem Value="00">APERTURA</asp:ListItem>
                                        <asp:ListItem Value="01">ENERO</asp:ListItem>
                                        <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                                        <asp:ListItem Value="03">MARZO</asp:ListItem>
                                        <asp:ListItem Value="04">ABRIL</asp:ListItem>
                                        <asp:ListItem Value="05">MAYO</asp:ListItem>
                                        <asp:ListItem Value="06">JUNIO</asp:ListItem>
                                        <asp:ListItem Value="07">JULIO</asp:ListItem>
                                        <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                                        <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                        <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="13">CIERRE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" valign="top" width="20%">
                                    <asp:Label ID="lblmes_final" runat="server" style="text-align: right" 
                                        Text="Fecha Final:"></asp:Label>
                                </td>
                                <td valign="top" width="10%">
                                    <asp:DropDownList ID="ddlMes_final" runat="server" 
                                        onselectedindexchanged="txtmes_inicial_SelectedIndexChanged">
                                        <asp:ListItem Value="00">APERTURA</asp:ListItem>
                                        <asp:ListItem Value="01">ENERO</asp:ListItem>
                                        <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                                        <asp:ListItem Value="03">MARZO</asp:ListItem>
                                        <asp:ListItem Value="04">ABRIL</asp:ListItem>
                                        <asp:ListItem Value="05">MAYO</asp:ListItem>
                                        <asp:ListItem Value="06">JUNIO</asp:ListItem>
                                        <asp:ListItem Value="07">JULIO</asp:ListItem>
                                        <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                                        <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                        <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="13">CIERRE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                               
                            </tr>
                            <tr>                               
                                <td >
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCentro_Contable" runat="server" Text="Centro Contable:" 
                                                Visible="False"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="left" colspan="3" style="width: 20%">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLCentro_Contable" runat="server" Visible="False" 
                                                Width="100%" AutoPostBack="True" 
                                                onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>                               
                            </tr>
                            <tr>
                                <td class="auto-style1" colspan="5" width="20%">
                                    <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel10">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q6" runat="server" AlternateText="Espere un momento, por favor.." Height="30px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="30px" />
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>                                
                                <td >
                                    <asp:Label ID="lblcuenta1" runat="server" Text="Cuenta Contable:" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td align="left" colspan="3" style="width: 20%">
                                    <asp:DropDownList ID="ddlcuenta1" runat="server" Visible="False" Width="100%">
                                    </asp:DropDownList>
                                </td>                               
                            </tr>
                            <tr>
                                <td style="text-align: right" width="20%" colspan="4">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnAceptar0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnAceptar0_Click" />
                                            <asp:ImageButton ID="btn_excel" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="btn_excel_Click" style="text-align: center" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                           
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label4" runat="server" Text="Centro Contable:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDLCentro_Contable_v" runat="server" 
                                        onselectedindexchanged="DDLCentro_Contable_v_SelectedIndexChanged" 
                                        Width="100%" AutoPostBack="True">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;
                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel12">
                                <progresstemplate>
                                    <asp:Image ID="Image1q3" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label1" runat="server" Text="Mes:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlmes" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="txtmes_inicial_SelectedIndexChanged" Width="200px">
                                        <asp:ListItem Value="01">ENERO</asp:ListItem>
                                        <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                                        <asp:ListItem Value="03">MARZO</asp:ListItem>
                                        <asp:ListItem Value="04">ABRIL</asp:ListItem>
                                        <asp:ListItem Value="05">MAYO</asp:ListItem>
                                        <asp:ListItem Value="06">JUNIO</asp:ListItem>
                                        <asp:ListItem Value="07">JULIO</asp:ListItem>
                                        <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                                        <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                        <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                        <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdateProgress ID="UpdateProgress7" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel13">
                                <progresstemplate>
                                    <asp:Image ID="Image1q4" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label2" runat="server" Text="Tipo:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltipo" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddltipo_SelectedIndexChanged" Width="200px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel14">
                                <progresstemplate>
                                    <asp:Image ID="Image1q5" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label5" runat="server" Text="# Poliza:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlnumero_poliza" runat="server" Width="100%" 
                                onselectedindexchanged="ddlnumero_poliza_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cuadro_botones">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnAceptar_v" runat="server" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="btnAceptar_v_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel11">
                                <progresstemplate>
                                    <asp:Image ID="Image1q2" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="lblmes_inicial1" runat="server" style="text-align: right" Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="auto-style4">
                                                <asp:DropDownList ID="ddlMes_inicial1" runat="server" onselectedindexchanged="txtmes_inicial_SelectedIndexChanged">
                                                    <asp:ListItem Value="00">APERTURA</asp:ListItem>
                                                    <asp:ListItem Value="01">ENERO</asp:ListItem>
                                                    <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                                                    <asp:ListItem Value="03">MARZO</asp:ListItem>
                                                    <asp:ListItem Value="04">ABRIL</asp:ListItem>
                                                    <asp:ListItem Value="05">MAYO</asp:ListItem>
                                                    <asp:ListItem Value="06">JUNIO</asp:ListItem>
                                                    <asp:ListItem Value="07">JULIO</asp:ListItem>
                                                    <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                                                    <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="13">CIERRE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblmes_final1" runat="server" style="text-align: right" Text="Fecha Final:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMes_final1" runat="server" onselectedindexchanged="txtmes_inicial_SelectedIndexChanged">
                                                    <asp:ListItem Value="00">APERTURA</asp:ListItem>
                                                    <asp:ListItem Value="01">ENERO</asp:ListItem>
                                                    <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                                                    <asp:ListItem Value="03">MARZO</asp:ListItem>
                                                    <asp:ListItem Value="04">ABRIL</asp:ListItem>
                                                    <asp:ListItem Value="05">MAYO</asp:ListItem>
                                                    <asp:ListItem Value="06">JUNIO</asp:ListItem>
                                                    <asp:ListItem Value="07">JULIO</asp:ListItem>
                                                    <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                                                    <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="13">CIERRE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="auto-style7">
                                    <asp:Label ID="lbltipo" runat="server" Text="Tipo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_Tipo_D" runat="server" Width="100%">
                                        <asp:ListItem Value="0">Seleccione..</asp:ListItem>
                                        <asp:ListItem Value="1">Adeudos SAT</asp:ListItem>
                                        <asp:ListItem Value="2">Adeudos FOVISSSTE</asp:ListItem>
                                        <asp:ListItem Value="3">Adeudos ISSSTE</asp:ListItem>
                                        <asp:ListItem Value="4">Impuestos sobre Nómina</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_Tipo_D" ErrorMessage="*Requerido" InitialValue="0">*Requerido</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="auto-style7">
                                    <asp:Label ID="lblsubtipo" runat="server" Text="Adeudo:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:DropDownList ID="ddl_subtipo" runat="server" Width="100%">
                                        <asp:ListItem Value="1">Corto Plazo</asp:ListItem>
                                        <asp:ListItem Value="2">Diferido</asp:ListItem>
                                        <asp:ListItem Value="3">Conciliado</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td class="auto-style7">
                                    <asp:Label ID="lblNotas" runat="server" Text="Notas:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtNotas" runat="server" Height="150px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="btnAceptar_D" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="btnAceptar_D_Click" />
                                            &nbsp;<asp:ImageButton ID="btn_excel_D" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel_D" style="text-align: center" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:UpdateProgress ID="UpdateProgress10" runat="server" AssociatedUpdatePanelID="UpdatePanel103">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q7" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
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
                <td>&nbsp;</td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
