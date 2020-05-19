<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConfiguracionForms.aspx.cs" Inherits="SAF.Patrimonio.Form.frmConfiguracionForms" %>
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
         <asp:MultiView ID="MultiViewConfiguracion" runat="server">
    <asp:View ID="View1" runat="server">
           
    <table style="width: 100%;">
    <tr>
        <td style="width:10%">
            <asp:Label ID="lblSistema" runat="server" style="text-align: right" Text="Sistema:"></asp:Label>
        </td>
        <td style="width:75%">
            <asp:DropDownList ID="ddlSistemasb" runat="server" AutoPostBack="True"  style="margin-bottom: 0px" Width="40%">
                <asp:ListItem>ADQUISICIONES</asp:ListItem>
                <asp:ListItem>CONTABILIDAD</asp:ListItem>
                <asp:ListItem>PATRIMONIO</asp:ListItem>
                <asp:ListItem>PRESUPUESTO</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td></td>
     </tr>
     <tr>
        <td>
            <asp:Label ID="lblBusqueda" runat="server" style="text-align: right" Text="Nombre/Puesto:"></asp:Label>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtBuscar" runat="server" 
                        style="margin-left: 7px; text-align: left;" Width="75%" CssClass="textbox"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" class="" Height="50px" 
                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png"  Width="50px" 
                        onclick="ImageButton1_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </td>
        <td>
            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png"  ValidationGroup="Detalle" OnClick="btnNuevo_Click1" />
         </td>
     </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>

         <tr>
            <td colspan="3"> 

                <asp:GridView ID="grdConfiguraciones" runat="server" AllowPaging="True" 
              AutoGenerateColumns="False" 
              EmptyDataText="No se encontró ningún registro"
              GridLines="Vertical" onselectedindexchanged="grdConfiguraciones_SelectedIndexChanged" 
              Width="100%" CssClass="mGrid mGrid11px">              
              <Columns>
                  <asp:BoundField DataField="Id" HeaderText="ID" />
                  <asp:BoundField DataField="Sistema" HeaderText="SISTEMA" />
                  <asp:BoundField DataField="Formato" HeaderText="FORMATO" />
                  <asp:BoundField DataField="Posicion" HeaderText="POSICIÓN" />
                  <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />
                  <asp:BoundField DataField="Puesto" HeaderText="PUESTO" />
                  <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                  <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblEliminar" runat="server" onclick="lblEliminar_Click" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');">Eliminar</asp:LinkButton>
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
            <td colspan="3">&nbsp;</td>
        </tr>
            <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
      </table>

          </asp:View> <!--termina el primer view -->

   <asp:View ID="View2" runat="server">

         <table style="width: 100%;">
              
            <tr>
            <td colspan="3">
                <asp:TextBox ID="txtID" runat="server" Height="21px" Visible="False" Width="20%"></asp:TextBox>
                </td>
        </tr>
 
    <tr>
        <td style="width:10%">
            <asp:Label ID="Label1" runat="server" style="text-align: right" Text="Sistemas:"></asp:Label>
        </td>
        <td style="width:75%">
            <asp:DropDownList ID="ddlSistemas" runat="server" AutoPostBack="True" Enabled="False" style="margin-bottom: 0px" Width="40%">
                <asp:ListItem Selected="True">ADQUISICIONES</asp:ListItem>
                <asp:ListItem>CONTABILIDAD</asp:ListItem>
                <asp:ListItem>PATRIMONIO</asp:ListItem>
                <asp:ListItem>PRESUPUESTO</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td></td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" style="text-align: right" Text="Formatos:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlFormatos" runat="server" AutoPostBack="True" Enabled="False" style="margin-bottom: 0px" Width="40%">
            </asp:DropDownList>
        </td>
        <td></td>
    </tr>
       
     <tr>
        <td>
            <asp:Label ID="Label3" runat="server" style="text-align: right" Text="Posición:"></asp:Label>
        </td>
        <td>
               <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                   <ContentTemplate>
            <asp:TextBox ID="txtPosicion" runat="server" Width="40%" ValidationGroup="Guardo" CssClass="textbox"></asp:TextBox> 

                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPosicion" ErrorMessage="*Requerido" InitialValue="" ValidationGroup="Guardo"></asp:RequiredFieldValidator>

                   </ContentTemplate>
            </asp:UpdatePanel>
            
         </td>
        <td>
            &nbsp;</td>
     </tr>

    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" style="text-align: right" Text="Nombre:"></asp:Label>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                   <ContentTemplate>
            <asp:TextBox ID="txtNombre" runat="server"  Width="75%" ValidationGroup="Guardo" CssClass="textbox"></asp:TextBox>   

                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="*Requerido" InitialValue="" ValidationGroup="Guardo"></asp:RequiredFieldValidator>

                   </ContentTemplate>
                </asp:UpdatePanel>
              
                    
        </td>
        <td>
            &nbsp;</td>
     </tr>

      <tr>
        <td>
            <asp:Label ID="Label5" runat="server" style="text-align: right" Text="Puesto:"></asp:Label>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                   <ContentTemplate>
            <asp:TextBox ID="txtPuesto" runat="server"  Width="75%" ValidationGroup="Guardo" CssClass="textbox"></asp:TextBox>  

                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPuesto" ErrorMessage="*Requerido" InitialValue="" ValidationGroup="Guardo"></asp:RequiredFieldValidator>

                   </ContentTemplate>
                </asp:UpdatePanel>
            
                     
          </td>
        <td>
              &nbsp;</td>
     </tr>

        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>

             
      <tr>
        <td>
    
        </td>
        <td>
            
            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                                        Text="Cancelar" CssClass="btn2" />
                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                                        Text="Guardar" ValidationGroup="Guardo" CssClass="btn" />
                                    &nbsp;
                                    <asp:Button ID="btnContinuar" runat="server" Text="Guardar y Continuar" 
                                        ValidationGroup="Guardo" Width="133px" onclick="btnContinuar_Click" CssClass="btn" />
                                </ContentTemplate>
            </asp:UpdatePanel>

        </td>
        <td></td>
     </tr>


     </table>

   </asp:View> <!--termina el segundo view -->

    </asp:MultiView> <!--termina multiview -->
         </td>
       </tr>
   </table>

     </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
