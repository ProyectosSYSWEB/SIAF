<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAF.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <div class="mensaje"> <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></div>
    <asp:Label ID="lbltitulo_form" runat="server" Text="Nuestros Sistemas." CssClass="lbltitulo_form"></asp:Label>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <div class="divisor">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table style="width:100%;">
                            <tr>
                                <td width="35%">&nbsp;</td>
                                <td width="30%">
                                    <asp:TreeView ID="trvMenu" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                        <ParentNodeStyle Font-Bold="True" Font-Size="14px" ImageUrl="~/images/SubMnuSAF3.png" />
                                        <RootNodeStyle Font-Bold="True" Font-Size="16px" ImageUrl="~/images/MenuSAF.png" />
                                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                                    </asp:TreeView>
                                </td>
                                <td width="35%">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
            <br />
            <br />
            <br />
                        <center>
                            <asp:Label ID="Label1" runat="server" CssClass="gris_20px" Text="Website Sysweb"></asp:Label>
                <br />
                <br />
                            <asp:Label ID="Label2" runat="server" CssClass="gris_11px" Text="El conjunto de sistemas que permite al usuario crear, modificar y gestionar elementos de nuestra base de datos."></asp:Label>
                        </center>
                    </td>
                </tr>
                <tr>
                <td align="center">
            



                     <asp:HiddenField ID="HiddenField1" runat="server" />

     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy">
       </ajaxToolkit:ModalPopupExtender>

    <%-- Inicia PopUP --%>


     <asp:Panel ID="Panel3" runat="server" CssClass="TituloModalPopupMsg"  Width="400px">

                 <asp:ImageButton ID="imgCerrar" ImageUrl="http://sysweb.unach.mx/resources/imagenes/cerrar.png" runat="server" Width="10px" CssClass="cerrar_pop"/>
      
             <div class="titulo_pop">
                 AVISO
             </div>
            <center>
                <br />
         <img src="http://sysweb.unach.mx/resources/imagenes/informacion.png"/>
             </center>
      
         <div class="info_pop gris_11px izquierda">
          <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblMsg_Observaciones" runat="server" Text="Una mentalidad positiva te ayuda a triunfar. Piensa bien, para vivir mejor" 
                                                ></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

         </div>

             <div class="esp_botones">                            
                 <asp:Button ID="btnCancelar" runat="server" Text="Continuar" CssClass="btn2" OnClick="btnCancelar_Click"/> 
             </div>

                  
     </asp:Panel>






                </td>
                
            </tr>
            
            <tr>
                <td>
                  </td>
                
            </tr>
            
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
