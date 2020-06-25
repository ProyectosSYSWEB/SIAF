<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAF.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbltitulo_form" runat="server" Text="" CssClass="lbltitulo_form"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                </div>
            <div class="col-md-3 text-center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TreeView ID="trvMenu" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                            <ParentNodeStyle Font-Bold="True" Font-Size="14px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/SubMnuSAF3.png" />
                            <RootNodeStyle Font-Bold="True" Font-Size="16px" ImageUrl="https://sysweb.unach.mx/resources/imagenes//MenuSAF.png" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-3">
                </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel3" runat="server" CssClass="TituloModalPopupMsg" Width="400px">

                            <asp:ImageButton ID="imgCerrar" ImageUrl="https://sysweb.unach.mx/resources/imagenes/cerrar.png" runat="server" Width="10px" CssClass="cerrar_pop" />

                            <div class="titulo_pop">
                                AVISO
                            </div>
                            <center>
                <br />
         <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png"/>
             </center>

                            <div class="info_pop gris_11px izquierda">
                                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMsg_Observaciones" runat="server" Text="Una mentalidad positiva te ayuda a triunfar. Piensa bien, para vivir mejor"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                            <div class="esp_botones">
                                <asp:Button ID="btnCancelar" runat="server" Text="Continuar" CssClass="btn2" />
                            </div>
                        </asp:Panel>

    <%-- Inicia PopUP --%>
</asp:Content>
