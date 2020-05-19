<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBienes.aspx.cs" Inherits="SAF.Patrimonio.Form.frmBienes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <style type="text/css">
        .style8
        {
        }
        .style9
        {
            height: 21px;
        }
    </style>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent"  Runat="Server">
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
<table style="width: 100%;">
    <tr>
        <td>

    <asp:MultiView ID="MultiViewBienes" runat="server">
    <asp:View ID="View1" runat="server">
        <br />
    <table style="width: 100%;">
        <tr>
                        <td align="left" class="style8">
                        </td>
                        <td align="center" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            </asp:UpdatePanel>
                        </td>
                    </tr>
    <tr>
        <td  align="left" >
            <asp:Label ID="lblBuscar" runat="server" 
                style="text-align: right" Text="Buscar:"></asp:Label>
        </td>
        <td valign="top" colspan="2">
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate> 
                    <asp:TextBox ID="txtBuscar" runat="server" 
                        style="margin-left: 7px; text-align: left;" Width="400px" placeHolder="Clave del Bien/Descripción"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" class="" Height="38px" 
                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png"  Width="39px" 
                        onclick="ImageButton1_Click" />
                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click"  />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
  </tr>

    <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" style="text-align: right" Text="Status:" 
                                        CssClass="style6"></asp:Label>
                    </td>
                    <td class="style2" colspan="2">
                                <asp:RadioButtonList ID="rbnStatus2" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="A" Selected="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="B">Inactivo</asp:ListItem>
                                </asp:RadioButtonList>
                               
                     </td>
                    
                 
                 </tr>
    <tr>
                    

                    
                
        <td colspan="3" style="text-align:center;">
            <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                AssociatedUpdatePanelID="UpdatePanel10">
                <progresstemplate>
                                <asp:Image ID="Image4" runat="server" 
                    AlternateText="Espere un momento por favor.." Height="50px" 
                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
            </asp:UpdateProgress>

            <asp:UpdateProgress ID="UpdateProgress8" runat="server" 
                AssociatedUpdatePanelID="UpdatePanel6">
                <progresstemplate>
                                <asp:Image ID="Image5" runat="server" 
                    AlternateText="Espere un momento por favor.." Height="50px" 
                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
            </asp:UpdateProgress>

        </td>
                    

                    
                
  </tr>
        <tr> <td></td> <td></td> 
            <td style="text-align:right;">
            <asp:Label ID="lblCount" runat="server" CssClass="style6" style="text-align: right" Text=""></asp:Label>
            </td></tr>
  <tr>
      <td colspan="3">
           <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
          <asp:GridView ID="grdBienes" runat="server" AllowPaging="True" 
              AutoGenerateColumns="False" BorderStyle="None" 
              EmptyDataText="No hay registros para mostrar" BorderWidth="1px"  GridLines="Vertical" 
               onselectedindexchanged="grdBienes_SelectedIndexChanged" 
              Width="100%" onpageindexchanging="grdBienes_PageIndexChanging1" CssClass="mGrid" PageSize="20">            
              <Columns>
                  <asp:BoundField DataField="Id" HeaderText="ID" />
                  <asp:BoundField DataField="Subclase" HeaderText="SUBCLASE" />
                  <asp:BoundField DataField="Clave" HeaderText="CLAVE" >
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" Width="75px" />
</asp:BoundField>
                  <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN" >
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
                  <asp:BoundField DataField="Subcuenta" HeaderText="SUBCUENTA" >
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" Width="75px" />
</asp:BoundField>
                  <asp:BoundField DataField="Nivel" HeaderText="NIVEL" >
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" Width="75px" />
</asp:BoundField>
                  <asp:BoundField DataField="Por_lote" HeaderText="POR LOTE">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" Width="75px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Conjunto" HeaderText="CONJUNTO">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" Width="75px" />
                  </asp:BoundField>
                  <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                  <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblEliminar" runat="server" onclick="lblEliminar_Click" OnClientClick="return confirm('¿Está seguro de eliminar el registro?');">Eliminar</asp:LinkButton>
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
            <td class="cuadro_botones" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="BTNver_reporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="BTNver_reporte_Click" />
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExcel" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
  </table>
  
  </asp:View>


    <asp:View ID="View2" runat="server">
        <br />  
    <table style="width: 100%;">

        <tr>
        <td>   
        <asp:Label ID="lblClave" runat="server" Text="Partida:"></asp:Label>
                        &nbsp;  </td>
        <td>

          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
            <asp:TextBox ID="txtClave" runat="server" 
                Width="30%" MaxLength="5"></asp:TextBox>
             <asp:ImageButton ID="ImageButton2" runat="server" class="" Height="38px" 
                  ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png"  Width="39px" 
                  onclick="ImageButton2_Click" />
       
              <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo:"></asp:Label>
             <asp:TextBox ID="txtConsecutivo" runat="server" ReadOnly="True" 
                  Width="30%" Enabled="False"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>            
         </td>
        <td>
           <asp:UpdateProgress ID="UpdateProgress7" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel2">
                            <progresstemplate>
                                <asp:Image ID="Image32" runat="server" 
                                    AlternateText="Espere un momento por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress></td>
        </tr>       

        <tr>
        <td>
            <asp:Label ID="lblDescbien" runat="server" Text="Descripción de la Partida:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txtDescrPart" runat="server" Enabled="False" Width="100%"></asp:TextBox>
            </td>
        <td></td>
        </tr>
     

                <tr>
                    <td style="width: 182px">
                        <asp:Label ID="lblGrupo" runat="server" Text="Grupo:"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width: 690px">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="True" 
                                    Width="100%" 
                                    style="margin-bottom: 0px" 
                                    onselectedindexchanged="ddlGrupo_SelectedIndexChanged" Enabled="False">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        &nbsp;<asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel5">
                            <progresstemplate>
                                <asp:Image ID="Image1" runat="server" 
                                    AlternateText="Espere un momento por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress>
                        </td>
                </tr>
                <tr>
                    <td style="width: 182px">
                        <asp:Label ID="ldlSubgrupo" runat="server" Text="Subgrupo:"></asp:Label>
                    </td>
                    <td style="width: 690px">
                         <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubgrupo" runat="server" AutoPostBack="True" 
                                                                       Width="100%" 
                                    onselectedindexchanged="ddlSubgrupo_SelectedIndexChanged" Enabled="False" >
                                   
                                    <asp:ListItem></asp:ListItem>
                                   
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
   
                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel12">
                            <progresstemplate>
                                <asp:Image ID="Image2" runat="server" 
                                    AlternateText="Espere un momento por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td style="width: 182px">
                        <asp:Label ID="lblClase" runat="server" Text="Clase:"></asp:Label>
                    </td>
                    <td style="width: 690px">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                        <ContentTemplate>
                     <asp:DropDownList ID="ddlClase" runat="server" Width="100%" 
                            AutoPostBack="True" onselectedindexchanged="ddlClase_SelectedIndexChanged" Enabled="False" 
                           >
                         <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel13">
                            <progresstemplate>
                                <asp:Image ID="Image3" runat="server" 
                                    AlternateText="Espere un momento por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    </td>
                 </tr>

                 <tr>
                    <td class="style3">
                        <asp:Label ID="Subclase" runat="server" Text="Subclase:"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style4">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubclase" runat="server" AutoPostBack="True" 
                                    Width="100%" 
                                    style="margin-bottom: 0px" 
                                    onselectedindexchanged="ddlSubclase_SelectedIndexChanged" Enabled="False">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style5">
                        &nbsp;<asp:UpdateProgress ID="UpdateProgress6" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel5">
                            <progresstemplate>
                                <asp:Image ID="Image7" runat="server" 
                                    AlternateText="Espere un momento por favor.." Height="50px" 
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" 
                                    ToolTip="Espere un momento por favor.." Width="50px" />
                            </progresstemplate>
                        </asp:UpdateProgress>
                        </td>
                </tr>

                 <tr>
                 <td style="width: 182px">
                                    <asp:Label ID="lblStatus" runat="server" style="text-align: right" Text="Status:" 
                                        CssClass="style6"></asp:Label>
                    </td>
                    <td class="style2">
                                <asp:RadioButtonList ID="rbnStatus" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="A" Selected="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="B">Desactivado</asp:ListItem>
                                </asp:RadioButtonList>
                               
                     </td>
                    <td> &nbsp;</td>
                 
                 </tr>

                 <tr>
                    <td style="width: 182px">
                        <asp:Label ID="lblCuenta" runat="server" Text="Cuenta:"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width: 690px">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCuenta" runat="server" AutoPostBack="True" 
                                    Width="100%" 
                                    style="margin-bottom: 0px" 
                                    onselectedindexchanged="ddlCuenta_SelectedIndexChanged" Enabled="False">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td></td>
                  </tr>

                   <tr>
                    <td style="width: 182px">
                        <asp:Label ID="lblSubcuenta" runat="server" Text="Subcuenta:"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width: 690px">
                        <asp:UpdatePanel ID="UpdatePane35" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubcuent" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlSubcuent_SelectedIndexChanged" 
                                    style="margin-bottom: 0px" Width="100%" Enabled="False">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td></td>
                  </tr>

                   <tr>
                    <td style="width: 182px">
                        <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width: 690px">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                               <%-- <asp:DropDownList ID="ddlNive" runat="server"  
                                    style="margin-bottom: 0px" Width="100%" 
                                    onselectedindexchanged="ddlNive_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtNivel" runat="server" Enabled="False" Width="30%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td></td>
                  </tr>
        <tr>
                        <td style="width: 182px">
                            <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 690px">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDescripcion" runat="server" Width="100%" 
                                        ValidationGroup="Guardo"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtDescripcion" ErrorMessage="*Requerido" 
                                ValidationGroup="Guardo"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 182px">
                            <asp:Label ID="lblPor_lote" runat="server" Text="Por Lote:"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 690px">
                            <asp:RadioButtonList ID="rblPorlote" runat="server" AutoPostBack="True" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="S">SI</asp:ListItem>
                                <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td> </td>
                    </tr>
                    <tr>
                        <td style="width: 182px">
                            <asp:Label ID="lblConjunto" runat="server" Text="Conjunto:"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 690px">
                            <asp:RadioButtonList ID="rblConjunto" runat="server" AutoPostBack="True" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="S">SI</asp:ListItem>
                                <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="width: 182px">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 690px">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDescripcion" runat="server" Width="100%" 
                                        ValidationGroup="Guardo"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtDescripcion" ErrorMessage="*Requerido" 
                                ValidationGroup="Guardo"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 182px">
                            &nbsp;</td>
                        <td style="width: 690px">
                            &nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="cuadro_botones" colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn2" onclick="btnCancelar_Click" Text="Cancelar" />
                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn" onclick="btnGuardar_Click" Text="Guardar" ValidationGroup="Guardo" />
                                    &nbsp;
                                    <asp:Button ID="btnContinuar" runat="server" CssClass="btn" onclick="btnContinuar_Click" Text="Guardar y Continuar" ValidationGroup="Guardo" Width="133px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
    </asp:View> 
    </asp:MultiView>    
  
        </td>      
    </tr>
</table>          
       </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>


