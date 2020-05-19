<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCentros_Trabajo.aspx.cs" Inherits="SAF.Patrimonio.Form.frmCentros_Trabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            height: 21px;
            text-align: left;
        }
        .style4
        {
            height: 21px;
        }
        .style5
        {
            text-align: left;
        }
        .auto-style1 {
            width: 85%;
        }
        .auto-style3 {
            height: 21px;
            text-align: left;
            width: 85%;
        }
        .auto-style4 {
            height: 21px;
            width: 85%;
        }
        .auto-style5 {
            text-align: left;
            width: 85%;
        }
        .auto-style6 {
            width: 25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="tabla_contenido">
            <tr>
                <td width="15%">
                    &nbsp;
                </td>
                <td width="75%">
                    &nbsp;</td>
                <td width="10%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 25%;" colspan="3">
                    <asp:MultiView ID="MultiViewCentros_Trabajo" runat="server">

                     <asp:View ID="View1" runat="server">
                     <table style="width: 100%;">
                     
                     <tr>
                <td style="text-align: right" width="15%">
                    &nbsp; Centro Contable:</td>
                <td style="text-align: left" width="75%" class="auto-style1" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCentrosB" runat="server" Width="535px" 
                                onselectedindexchanged="ddlCentrosB_SelectedIndexChanged" 
                                AutoPostBack="True" Height="22px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="15%" style="text-align: right">
                    &nbsp; Status:</td>
                <td width="75%" style="text-align: left" class="auto-style1" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlStatusB" runat="server" Width="249px" 
                                onselectedindexchanged="ddlStatusB_SelectedIndexChanged" 
                                AutoPostBack="True" Height="22px">
                                <asp:ListItem Value="T">TODOS</asp:ListItem>
                                <asp:ListItem Value="A">ALTA</asp:ListItem>
                                <asp:ListItem Value="B">BAJA</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                   
                    &nbsp;
                   
                </td>
            </tr>
            <tr>
                <td width="15%" style="text-align: right">
                Buscar:
                </td>
                <td width="75%" style="text-align: left" class="auto-style1" colspan="2">

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtBuscar" runat="server" 
                        style="text-align: left;" Width="527px" Height="22px"></asp:TextBox>

                    <asp:ImageButton ID="BTNbuscar" runat="server" class="" Height="38px" 
                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="BTNbuscar_Click" Width="39px" />
                        <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>

                    
                </td>
            </tr>
                         <tr>
                             <td style="text-align: right" width="15%">
                                 &nbsp;</td>
                             <td style="text-align: center" width="75%">
                              <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel5">
                                        <progresstemplate>
                                            <asp:Image ID="Image1q1" runat="server" 
                                            AlternateText="Espere un momento, por favor.." Height="50px" 
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                            ToolTip="Espere un momento, por favor.." Width="50px" 
                                            />
                                        </progresstemplate>
                                    </asp:UpdateProgress>  
                              </td>
                         </tr>
                         <tr>
                             <td colspan="3" style="text-align: left; width: 25%;">
                                
                                  <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                 <asp:GridView ID="grdCentros_Trabajo" runat="server" AutoGenerateColumns="False" 
                                     CellPadding="4"  GridLines="Vertical" Width="100%" 
                                     AllowPaging="True" EmptyDataText="No hay registros para mostrar" 
                                     onselectedindexchanged="grdCentros_Trabajo_SelectedIndexChanged" 
                                        onpageindexchanging="grdCentros_Trabajo_PageIndexChanging" CssClass="mGrid">
                                     
                                     <Columns>
                                         <asp:BoundField DataField="ID" HeaderText="ID" />
                                         <asp:BoundField DataField="Centro_Contable" HeaderText="CENTRO CONTABLE" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                         <asp:BoundField HeaderText="CLAVE" DataField="CLAVE"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                         <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" />
                                         <asp:BoundField DataField="Status" HeaderText="STATUS" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                         <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <asp:LinkButton ID="lbtnEliminar" runat="server" 
                                                     onclientclick="return confirm ('¿Realmente desea eliminar el registro?');" 
                                                     onclick="lbtnEliminar_Click1">Eliminar</asp:LinkButton>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                     <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />                                                
                                                <AlternatingRowStyle CssClass="alt" /> 
                                 </asp:GridView>
                                 </ContentTemplate>
                              </asp:UpdatePanel>
                             </td>
                         </tr>
                         <tr>
                             <td style="text-align: right" width="15%">
                                 &nbsp;</td>
                             <td style="text-align: left" width="75%">
                                 &nbsp;</td>
                             <td width="10%">
                                 &nbsp;</td>
                         </tr>
            
                         <tr>
                             <td class="cuadro_botones" colspan="3">
                                 <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="BTNver_reporte_Click" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                         </tr>
                     
                         <tr>
                             <td style="text-align: left" width="15%">
                                 &nbsp;</td>
                             <td style="text-align: left" width="75%">
                                 &nbsp;</td>
                             <td width="10%">
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td style="text-align: left" width="15%">
                                 &nbsp;</td>
                             <td style="text-align: left" width="75%">
                                 &nbsp;</td>
                             <td width="10%">
                                 &nbsp;</td>
                         </tr>
                     
                     </table>
                     </asp:View>

            <asp:View ID="View2" runat="server">
             <table style="width: 100%;">
                    <tr>
                    <td width="15%"></td>
                     <td width="75%" class="style5"></td>
                      <td width="10%"></td>
                    </tr>
                    <tr>
                    <td class="style3" width="15%" >Centro Contable:</td>
                     <td class="auto-style3" width="75%" style="text-align: left" colspan="2" >
                  
                         <asp:UpdatePanel ID="UpdatePanel6" runat="server">   
                          <ContentTemplate>
                          <asp:DropDownList ID="ddlCentros1" runat="server" Width="560px" Height="20px" 
                                  onselectedindexchanged="ddlCentros1_SelectedIndexChanged" 
                                  AutoPostBack="True">
                         </asp:DropDownList>
                         </ContentTemplate>
                         </asp:UpdatePanel>
                        </td>
                    </tr>

                    <tr>
                        <td width="15%" class="style3" >Status:</td>
                        <td style="text-align: left" width="75%" class="auto-style4" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                              <asp:DropDownList ID="ddlStatus" runat="server" Width="300px" Height="20px" 
                                    AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                  <asp:ListItem>TODOS</asp:ListItem>
                                  <asp:ListItem Value="A">ALTA</asp:ListItem>
                                  <asp:ListItem Value="B">BAJA</asp:ListItem>
                            </asp:DropDownList>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="izquierda">
                            Dependencia:</td>
                        <td width="75%" class="auto-style5" colspan="2">
                          
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDependencia" runat="server" Height="20px" 
                                    Width="300px" onselectedindexchanged="ddlDependencia_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                         
                              <label>Centro de trabajo:</label>
                                <asp:TextBox ID="txtConsecutivo" runat="server" Width="170px" Height="20px"></asp:TextBox> 
                            </ContentTemplate>
                         </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="izquierda">
                            Descripción:</td>
                        <td width="75%" class="auto-style5" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                              <asp:TextBox ID="txtDescripcion" runat="server" Width="553px" Height="20px"></asp:TextBox>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" colspan="3">
                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn" onclick="btnGuardar_Click1" Text="Guardar" ValidationGroup="Guardo" />
                            <asp:Button ID="btnContinuar" runat="server" CssClass="btn" onclick="BTN_continuar_Click" Text="Guardar y Continuar" ValidationGroup="Guardo" Width="133px" />
                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn2" onclick="btnCancelar_Click1" Text="Cancelar" />
                        </td>
                    </tr>

                    </table>

            </asp:View>
                    </asp:MultiView>
                    
                </td>
            </tr>
            </tr>
            <tr>
                <td width="15%" class="style3">
                    </td>
                <td width="75%" class="style3">
                    </td>
                <td width="10%" class="style3">
                    </td>
         
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
