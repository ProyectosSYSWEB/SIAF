<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMCuentas_contables.aspx.cs" Inherits="SAF.Rep.FRMCuentas_contables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            text-align: right;
            height: 26px;
            width: 137px;
        }
        .style6
        {
            height: 26px;
            width: 799px;
        }
        .style7
        {
            width: 799px;
            text-align: left;
        }
        .style8
        {
            height: 20px;
            width: 799px;
        }
        .style11
        {
            height: 20px;
            text-align: center;
            }
        .style13
        {
            text-align: center;
        }
        .style16
        {
            text-align: right;
            }
        .style19
        {
            height: 20px;
            text-align: right;
            width: 119px;
        }
        .style20
        {
            text-align: right;
            }
        .style21
        {
            text-align: center;
        }
        .style22
        {
            width: 125px;
            text-align: right;
        }
        .pdf 
        {
		position:absolute;
		top: 445px;
		left: 1020px;
	    }
        .style23
        {
            width: 799px;
            text-align: left;
        }
        .style24
        {
            text-align: left;
            width: 129px;
        }
        .auto-style1 {
            width: 316px;
        }
        .auto-style2 {
            text-align: left;
            width: 129px;
        }
        .auto-style3 {
            width: 125px;
            text-align: left;
        }
        .auto-style4 {
            text-align: left;
            height: 26px;
            width: 137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>   
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class=" tabla_contenido">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" style="text-align: right" 
                            Text="Centro Contable:"></asp:Label>
                    </td>
                    <td>                       
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                           <asp:DropDownList ID="DDLCentro_Contable" runat="server" AutoPostBack="True" 
                            Width="300px" 
                            onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged1">
                           </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;
                        <asp:Label ID="Label14" runat="server" Text="Cuenta Mayor:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCuenta_Mayor" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" Width="300px">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>              
                <tr>
                    <td class="style13" colspan="2">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel3">
                            <progresstemplate>
                                <asp:Image ID="Image1q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td class="style13" colspan="2">
                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel9">
                            <progresstemplate>
                                <asp:Image ID="Image1q0" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>  
            <asp:MultiView ID="MultiViewcuentas_contables" runat="server">
                <asp:View ID="View1" runat="server">
                          
                <table class=" tabla_contenido">                             
                <tr>
                    <td class="izquierda">
                        <asp:Label ID="Label15" runat="server" Text="Subdependencia:"></asp:Label>
                    </td>
                    <td class="style7">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDLSubdependencia" runat="server" AutoPostBack="True" onselectedindexchanged="DDLSubdependencia_SelectedIndexChanged" 
                                    Width="420px">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                    <tr>
                        <td class="izquierda">
                            <asp:Label ID="Label3" runat="server" Text="Cuenta Contable"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="txtcuenta_contable" runat="server" MaxLength="22" 
                                Width="420px" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20" colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                          <ContentTemplate>
                               <table style="width: 100%;"> 
                                   <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label16" runat="server" Text="Nivel1"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:TextBox ID="txt1" runat="server" Enabled="False" MaxLength="4" 
                                ontextchanged="txt1_TextChanged">0000</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label17" runat="server" Text="Nivel2"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:TextBox ID="txt2" runat="server" Enabled="False" MaxLength="5" 
                                ontextchanged="txt2_TextChanged">00000</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label18" runat="server" Text="Nivel3"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:TextBox ID="txt3" runat="server" ontextchanged="TextBox3_TextChanged" 
                                Enabled="False" MaxLength="5">00000</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label19" runat="server" Text="Nivel4"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:TextBox ID="txt4" runat="server" Enabled="False" MaxLength="5" 
                                ontextchanged="txt4_TextChanged" AutoPostBack="True">00000</asp:TextBox>
                        </td>
                    </tr>
                              </table>
                          </ContentTemplate>
                      </asp:UpdatePanel>
                            &nbsp;</td>
                    </tr>
                    
                   
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label11" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtdescripcion" runat="server" Width="742px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="izquierda">
                        <asp:Label ID="Label5" runat="server" Text="Tipo:"></asp:Label>
                    </td>
                    <td class="style7">
                        <asp:DropDownList ID="txttipo" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" 
                            Width="301px" Enabled="False">
                            <asp:ListItem Value="AF">AFECTABLE</asp:ListItem>
                            <asp:ListItem Value="AC">ACUMULABLE</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Status:"></asp:Label>
                        <asp:DropDownList ID="ddlstatus" runat="server" 
                            onselectedindexchanged="ddlMayor_SelectedIndexChanged" Enabled="False">
                            <asp:ListItem Value="A">ALTA</asp:ListItem>
                            <asp:ListItem Value="B">BAJA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Clasificación:"></asp:Label>
                        </td>
                    <td class="style8">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlclasificacion" runat="server" AutoPostBack="True"  Width="301px">
                                    <asp:ListItem Value="DET">DETALLE</asp:ListItem>
                                    <asp:ListItem Value="ESP">ESPECIFICA</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label13" runat="server" Text="Nivel:"></asp:Label>
                                <asp:DropDownList ID="ddlnivel" runat="server" AutoPostBack="True" 
                                    Enabled="False" 
                                    onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" Width="301px">
                                    <asp:ListItem Value="1">NIVEL 1</asp:ListItem>
                                    <asp:ListItem Value="2">NIVEL 2</asp:ListItem>
                                    <asp:ListItem Value="3">NIVEL 3</asp:ListItem>
                                    <asp:ListItem Value="4">NIVEL 4</asp:ListItem>
                                    <asp:ListItem Value="5">NIVEL 5</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                </tr>
                    <tr>
                        <td class="cuadro_botones" colspan="2">
                            &nbsp; &nbsp;<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="BTN_Guardar" runat="server" onclick="BTN_Guardar_Click" 
                                        Text="Guardar" CssClass="btn" />
&nbsp;
                                    <asp:Button ID="BTN_continuar" runat="server" onclick="BTN_continuar_Click" 
                                        Text="Guardar y Continuar" Width="133px" Visible="False" CssClass="btn" />
                                    &nbsp;
                                    <asp:Button ID="BTN_Cancelar" runat="server" onclick="BTN_Cancelar_Click" 
                                        Text="Cancelar" CssClass="btn2" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11" colspan="2">
                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel8">
                                <progresstemplate>
                                    <asp:Image ID="Image2q" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                <table class="tabla_contenido">               
                <tr>
                    <td class="style21">
                        <asp:Label ID="Label10" runat="server" Text="Buscar:"></asp:Label>
                    </td>
                    <td class="style7">
                        &nbsp;<asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TXTbuscar" runat="server" style="margin-left: 7px" 
                                    Width="441px" CssClass="textbuscar"></asp:TextBox>
                                <asp:ImageButton ID="BTNbuscar" runat="server" class="" Height="38px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="BTNbuscar_Click" Width="39px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                    </td>
                    <td style="text-align: right" class="auto-style1">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style16">
                        &nbsp;</td>
                </tr>
                    <tr>
                        <td class="style21" colspan="4">
                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                                AssociatedUpdatePanelID="UpdatePanel10">
                                <progresstemplate>
                                    <asp:Image ID="Image1q1" runat="server" 
                                    AlternateText="Espere un momento, por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento, por favor.." Width="50px" style="text-align: center" />
                                </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                <tr>
                    <td colspan="4" align="center" >
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <div class="scroll">
                                <asp:GridView ID="grdcuentas_contables" runat="server" Width="100%" 
                                    AutoGenerateColumns="False" 
                                    BorderStyle="None"  CellPadding="4" 
                                    GridLines="Vertical" 
                                   
                                    onpageindexchanging="grdcuentas_contables_PageIndexChanging" CssClass="mGrid" EmptyDataText="No hay registros para mostrar">                                    
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" />
                                        <asp:BoundField DataField="cuenta_contable" HeaderText="CUENTA" />
                                        <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" />
                                        <asp:BoundField DataField="natura" HeaderText="NATURALEZA" />
                                        <asp:BoundField DataField="nivel" HeaderText="NIVEL" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Editar</asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnagregar" runat="server"   onclick="lbtnagregar_Click">Agregar</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"   OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');">Eliminar</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"  Visible='<%# Bind("bandera") %>'>Ver Polizas</asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />                                                
                                                <AlternatingRowStyle CssClass="alt" /> 
                                </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                        </td>
                    <td class="style8" colspan="3">
                        </td>
                </tr>
                
                <tr>
                    <td colspan="4" class="cuadro_botones">
                        <asp:ImageButton ID="BTNver_reporte" runat="server" Height="53px" 
                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" Width="49px" onclick="BTNver_reporte_Click" />
                        &nbsp;</td>
                </tr>
            </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <table class="tabla_contenido">
                                <tr>
                                    <td width="15%" class="style24">
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="15%" class="style24">
                                        <asp:Label ID="lblBuscar" runat="server" Text="# de Póliza/Concepto:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBuscar0" runat="server" AutoPostBack="True" OnTextChanged="txtBuscar0_TextChanged" Width="100%" CssClass="textbuscar"></asp:TextBox>
                                    </td>
                                    <td width="15%">
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgbtnBuscar" runat="server" CausesValidation="False" Height="38px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" Width="39px" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">&nbsp;</td>
                                    <td style="text-align: center">
                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                                            <progresstemplate>
                                                <asp:Image ID="Image2q0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                            </progresstemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td width="15%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:GridView ID="grvPolizas" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Font-Size="11px" ForeColor="Black" GridLines="Vertical" PageSize="25" Width="100%" OnPageIndexChanging="grvPolizas_PageIndexChanging" CssClass="mGrid">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="IdPoliza" />
                                                <asp:BoundField DataField="CENTRO_CONTABLE" HeaderText="CENTRO CONTABLE" />
                                                <asp:BoundField DataField="NUMERO_POLIZA" HeaderText="# PÓLIZA" />
                                                <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                                                <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" />
                                                <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                                <asp:BoundField DataField="CONCEPTO" HeaderText="CONCEPTO" />
                                                <asp:BoundField DataField="TOT_CARGO" DataFormatString="{0:c}" HeaderText="CARGO">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TOT_ABONO" DataFormatString="{0:c}" HeaderText="ABONO">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="linkBttnImprimir" runat="server" onclick="linkBttnImprimir_Click">Imprimir</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                                    <td>&nbsp;</td>
                                    <td style="text-align: right">
                                        <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" CssClass="btn" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:View>
            </asp:MultiView>
                
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
