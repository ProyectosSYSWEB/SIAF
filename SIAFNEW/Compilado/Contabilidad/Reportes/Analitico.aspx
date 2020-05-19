<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Analitico.aspx.cs" Inherits="SAF.Form.Analitico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style10
    {
    }
    .style12
    {
        text-align: center;
        }
    .style13
    {
        width: 343px;
        height: 29px;
    }
    .style14
    {
        height: 29px;
    }
        #Select1
        {
            width: 262px;
        }
        .custom-combobox {
    position: relative;
    display: inline-block;
  }
  .custom-combobox-toggle {
    position: absolute;
    top: 0;
    bottom: 0;
    margin-left: -1px;
    padding: 0;
  }
  .custom-combobox-input {
    margin: 0;
    padding: 5px 10px;
  }
        .auto-style8 {
            height: 26px;
        }
        .auto-style10 {
            width: 137px;
        }
    </style>
   <head>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/modernizr/2.7.1/modernizr.min.js"></script> 
    <link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="https://google-code-prettify.googlecode.com/svn/loader/prettify.css">
    </head>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width:100%;"  align="center">
            <tr>
                <td colspan="2">
                    &nbsp; &nbsp; &nbsp;
                    </td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label9" runat="server" Text="Mayor:" Visible="False"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="ddlMayor" runat="server" Visible="False" style="height: 22px">
                        <asp:ListItem Value="1 ACTIVO">1 ACTIVO</asp:ListItem>
                        <asp:ListItem>2 PASIVO</asp:ListItem>
                        <asp:ListItem>3 PATRIMONIO</asp:ListItem>
                        <asp:ListItem>4 INGRESOS</asp:ListItem>
                        <asp:ListItem>5 GASTOS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label2" runat="server" Text="Centro Contable:"></asp:Label>
                 </td>
                <td>
                  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="DDLCentro_Contable" runat="server" AutoPostBack="True" 
                                 onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" Width="98%">
                             </asp:DropDownList>
                              </ContentTemplate>
                     </asp:UpdatePanel>
    
                </td>
                 </tr>
                 <tr>
                <td  style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label10" runat="server" EnableViewState="true" Text="A Centro Contable:" Visible="False"></asp:Label>
                  </td>
                <td>
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                         <ContentTemplate>
                             <asp:RequiredFieldValidator ID="valCtaCont" runat="server" ControlToValidate="DDLCentro_Contable" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="Reporte">*Requerido</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DDLCentro_Contable0" runat="server" Width="98%" Visible="False">
                             </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="valCtaCont0" runat="server" ControlToValidate="DDLCentro_Contable0" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="Reporte">*Requerido</asp:RequiredFieldValidator>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                </td>
             </tr>
                 <tr>
                  <td  style="text-align: right" class="auto-style10">
                    <asp:Label ID="lblNivel" runat="server" Text="Nivel:" Visible="False"></asp:Label>
                  </td>
                <td>
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                         <ContentTemplate>
                     <asp:DropDownList ID="ddlnivel" runat="server" Visible="False" Width="169px" >
                                 <asp:ListItem Value="1">NIVEL 1</asp:ListItem>
                                 <asp:ListItem Selected="True" Value="2">NIVEL 2</asp:ListItem>
                                 <asp:ListItem Value="3">NIVEL 3</asp:ListItem>
                                 <asp:ListItem Value="4">NIVEL 4</asp:ListItem>
                             </asp:DropDownList>
                              </ContentTemplate>
                     </asp:UpdatePanel>
                 </td>
                 </tr>
               <tr>
                  <td colspan="2">
                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel4">
                            <progresstemplate>
                                <asp:Image ID="Image2q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="~/images/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                            </progresstemplate>
                        </asp:UpdateProgress>              
                </td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style10" valign="top">
                    <asp:Label ID="Label3" runat="server" Text="Cuenta Contable:"></asp:Label>
                  </td>
                <td class="auto-style8" valign="top"> 
                      <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddl_cuentas" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddl_cuentas_SelectedIndexChanged" Width="98%">
                                </asp:DropDownList>
                         </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
                </tr>
            <tr>
                <td style="text-align: right" class="auto-style10" valign="top">
                    <asp:Label ID="Label12" runat="server" Text="A Cuenta Contable:"></asp:Label>
                </td>
                    <td valign="top">
                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                        <asp:DropDownList ID="ddl_cuentas0" runat="server" AutoPostBack="True" Width="98%">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label4" runat="server" Text="Cuenta de Mayor:" Visible="False"></asp:Label>
                  </td>
                <td>
                       <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>                             
                                <asp:DropDownList ID="ddlCuenta_Mayor" runat="server" AutoPostBack="True" 
                                    Height="22px" 
                                     onselectedindexchanged="ddlCuenta_Mayor_SelectedIndexChanged" Width="98%" Visible="False">
                                    <asp:ListItem Value="0">0000--UNACH</asp:ListItem>
                                </asp:DropDownList>
                                  </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
                </tr>
                <tr>
                <td  style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label11" runat="server" Text="A Cuenta de Mayor:" Visible="False"></asp:Label>
                    </td>
                <td>
                      <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate> 
                     <asp:DropDownList ID="ddlCuenta_Mayor0" runat="server" Height="21px" Visible="False" Width="98%">
                                    <asp:ListItem Value="0">0000--UNACH</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            
            </tr>
            <tr>
                <td  style="text-align: right" class="auto-style10">
                 
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblTipo" runat="server" Text="Reporte:" Visible="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>                   
                     
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" Visible="False">
                                <asp:ListItem Value="3262.0">Transferencias 3262</asp:ListItem>
                                <asp:ListItem Value="3220.5">Transferencias 3220 (5000)</asp:ListItem>
                                <asp:ListItem Value="3220.6">Transferencias 3220 (6000)</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="text-align: right">
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblNivelReporte" runat="server" Text="Tipo de Reporte:" Visible="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlNivelReporte" runat="server" AutoPostBack="True" Visible="False">
                                <asp:ListItem Value="1">Detalle</asp:ListItem>
                                <asp:ListItem Value="G">Resumen</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="text-align: right">
                    <asp:Label ID="lbl_f_ini" runat="server" Text="Mes Inicial:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="txtmes_inicial" runat="server" onselectedindexchanged="txtmes_inicial_SelectedIndexChanged" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                 <td style="text-align: right" class="auto-style10">
                    <asp:Label ID="lbl_f_fin" runat="server" Text="Mes Final:" Visible="False"></asp:Label>
                    </td>
                <td>
                       <asp:DropDownList ID="txtmes_final" runat="server" Visible="False">
                    </asp:DropDownList>
                </td>
                    </tr>
 
            <tr>
                <td class="auto-style10" style="text-align: right">
                    <asp:Label ID="Label6" runat="server" Text="Numero de poliza:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpoliza" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
 
            <tr>
                <td  style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label7" runat="server" Text="Subsistema:" Visible="False"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="ddlsistemas" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" 
                        Visible="False" Width="300px">
                        <asp:ListItem Value="T">TODO</asp:ListItem>
                        <asp:ListItem Value="E">EGRESOS</asp:ListItem>
                        <asp:ListItem Value="I">INGRESOS</asp:ListItem>
                        <asp:ListItem Value="F">FONDOS</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td  style="text-align: right" class="auto-style10">
                    <asp:Label ID="Label5" runat="server" Text="Tipo:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="txttipo" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" 
                        Visible="False" Width="300px">
                        <asp:ListItem Value="D">DIARIO</asp:ListItem>
                        <asp:ListItem Value="I">INGRESO</asp:ListItem>
                        <asp:ListItem Value="E">EGRESO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                    </tr>

            <tr>
                <td colspan="2">

                       <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel6">
                            <progresstemplate>
                                <asp:Image ID="Image3q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="~/images/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                            </progresstemplate>
                        </asp:UpdateProgress>  

                       <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel5">
                            <progresstemplate>
                                <asp:Image ID="Image4q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="30px" 
                                    ImageUrl="~/images/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                            </progresstemplate>
                        </asp:UpdateProgress>  

                </td>
            </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                                 &nbsp;</td>
                </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <br />
                    <br />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:ImageButton ID="btnAceptar" runat="server" Height="53px" ImageUrl="~/images/pdf.jpg" onclick="btnAceptar_Click" ValidationGroup="Reporte" Width="49px" />
                            &nbsp;
                            <asp:ImageButton ID="ImageButton3" runat="server" Height="53px" ImageUrl="../../images/excel2.jpg" onclick="imgBttnExcel" Visible="False" Width="49px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                        <progresstemplate>
                            <asp:Image ID="Image1q" runat="server" AlternateText="Espere un momento, por favor.." Height="30px" ImageUrl="~/images/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="30px" />
                        </progresstemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
          </table>
    </ContentTemplate>
      
    </asp:UpdatePanel>
</asp:Content>
