<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCambiarResponsable.aspx.cs" Inherits="SAF.Patrimonio.Form.frmCambiarResponsable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 157px;
            text-align: right;
            margin-left: 40px;
        }

        .style2 {
        }

        .style3 {
        }

        .style4 {
            width: 157px;
            text-align: right;
            margin-left: 80px;
        }

        .style5 {
            width: 127px;
        }

        .style9 {
            width: 85%;
        }

        .style12 {
            width: 97px;
        }

        .style27 {
        }


        .style31 {
        }


        .style32 {
        }


        .style41 {
            width: 174px;
        }


        .style42 {
            width: 35%;
        }

        .style43 {
            width: 34%;
        }

        .style45 {
            width: 27%;
        }


        .style46 {
            height: 21px;
        }


        .style47 {
            height: 20px;
        }


        .auto-style4 {
            width: 129px;
        }


        .auto-style5 {
            padding: 5px 10px 10px 20px;
            border: 1px solid #f2f2f2;
            width: 97%;
            text-align: right;
            height: 78px;
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td colspan="2">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel105">
                            <ProgressTemplate>
                                <asp:Image ID="Image5" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%">
                        <asp:Label ID="lblDepOrigen" runat="server" Text="Dependencia:"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel106" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDLDepOrigen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDepOrigen_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVDepOrigen" runat="server" ControlToValidate="DDLDepOrigen" ErrorMessage="RequiredFieldValidator" InitialValue="--TODAS LAS DEPENDENCIAS--" ValidationGroup="Nuevo">*</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblMovimiento" runat="server" Text="Cambio por:"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDLMovimiento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLMovimiento_SelectedIndexChanged" Width="350px">
                                    <asp:ListItem Value="S">-- SELECCIONE UNA OPCIÓN --</asp:ListItem>
                                    <asp:ListItem Value="I">No. DE INVENTARIO</asp:ListItem>
                                    <asp:ListItem Value="R">NOMBRE DEL RESPONSABLE</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                            <ContentTemplate>
                                <asp:MultiView ID="MultiView1" runat="server">
                                    <asp:View ID="View1" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                                            <ContentTemplate>
                                                <div class="cuadro_azul">
                                                    <table style="width: 100%;">
                                                        <tr valign="top">
                                                            <td class="izquierda" colspan="2">
                                                                <strong>
                                                                    <h3>
                                                                        <asp:Label ID="Label4" runat="server" Text="Nombre del responsable" Width="100%"></asp:Label>
                                                                    </h3>

                                                                </strong></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblNombre" runat="server" Text="Responsable actual:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DDLResponsableActual" runat="server" Width="350px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblDepOrigen0" runat="server" Text="Dependencia:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel107" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLDepOrigen0" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="DDLDepOrigen0_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblNombre2" runat="server" Text="Responsable nuevo:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DDLResponsableNuevo" runat="server" Width="350px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                                            <ContentTemplate>
                                                <div class="cuadro_azul">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td class="izquierda" colspan="2">
                                                                <strong><strong>
                                                                    <h3>
                                                                        <asp:Label ID="Label5" runat="server" Text="Numero de Inventario" Width="100%"></asp:Label>
                                                                    </h3>
                                                                </strong></strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblInventario_Inicial" runat="server" Text="No. de Inventario Inicial:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtInventario_Inicial" runat="server"  Width="100px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtInventario_Inicial" ErrorMessage="RequiredFieldValidator" ValidationGroup="Inventario">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblInventario_Final" runat="server" Text="No. de Inventario Final:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtInventario_Final" runat="server" Width="100px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtInventario_Final" ErrorMessage="RequiredFieldValidator" ValidationGroup="Inventario">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDepOrigen1" runat="server" Text="Dependencia (Adscripción):"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel108" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLDepOrigen1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDepOrigen1_SelectedIndexChanged" Width="100%">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblResponsable" runat="server" Text="Responsable nuevo:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DDLResponsable" runat="server" Width="350px">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFVResponsable" runat="server" ControlToValidate="DDLResponsable" ErrorMessage="RequiredFieldValidator" InitialValue="0000" ValidationGroup="Inventario">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server"></asp:View>
                                </asp:MultiView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <tr>
                        <td class="auto-style5" colspan="2">


                            <asp:HiddenField ID="hddnMensaje" runat="server" />

                            <ajaxToolkit:ModalPopupExtender ID="modalMensaje" runat="server"
                                PopupControlID="pnlMensaje"
                                TargetControlID="hddnMensaje" BackgroundCssClass="modalBackground_Proy">
                            </ajaxToolkit:ModalPopupExtender>


                            <asp:Button ID="btnAplicar" runat="server" CssClass="btn" AutoPostBack="True" OnClick="btnAplicar_Click" Text="Aplicar" Width="80px" />
                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn2" OnClick="btnCancelar_Click" Text="Cancelar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">

                            <asp:Panel ID="pnlMensaje" runat="server" CssClass="TituloModalPopupMsg" Width="450px">

                                <asp:ImageButton ID="imgCerrar" ImageUrl="https://sysweb.unach.mx/resources/imagenes/cerrar.png" runat="server" Width="10px" CssClass="cerrar_pop" />

                                <div class="titulo_pop">
                                    AVISO
                                </div>
                               
                                <div class="info_pop gris_12px">
                                    <table width="100%">
                                     
                                        <tr>
                                            <td align="center" rowspan="3" valign="top">&nbsp;<%--<asp:Image ID="Image2" runat="server" 
                                                                                                            ImageUrl="~/images/Simbolo_Msg.png" />
                                                                                                        <br />--%></td>
                                            <td align="center">
                                                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" Text="¿Desea aplicar los cambios?"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style47">
                                                <asp:UpdatePanel ID="UpdatePanel109" runat="server">
                                                    <ContentTemplate>
                                                        <div class="izquierda">
                                                            <asp:GridView ID="GrvBienes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" PageSize="10">
                                                                <Columns>
                                                                    <asp:BoundField DataField="NO_INVENTARIO" HeaderText="# INVENTARIO" />
                                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCIÓN" />
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
                                            <td>
                                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel40">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="Image8" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="cuadro_botones" colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnSi" runat="server" CausesValidation="False" CssClass="btn" OnClick="btnSi_Click" Text="Si" />
                                                        <asp:Button ID="btnNo" runat="server" CausesValidation="False" CssClass="btn" OnClick="btnNo_Click" Text="No" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
