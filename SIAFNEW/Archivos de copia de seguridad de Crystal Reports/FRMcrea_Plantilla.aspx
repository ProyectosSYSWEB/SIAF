<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMcrea_Plantilla.aspx.cs" Inherits="SAF.Presupuesto.Form.FRMcrea_Plantilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            padding: 5px 10px 10px 20px;
            border: 1px solid #f2f2f2;
            text-align: right;
            z-index: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
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
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label ID="Label3" runat="server" Text="Semestre:"></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    <asp:DropDownList ID="ddlSemestre" runat="server" Width="280px" OnSelectedIndexChanged="ddlSemestre_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="auto-style17" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="updBtns" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="BTNbuscar" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" Width="45px" OnClick="BTNbuscar_Click" />
                                            &nbsp; &nbsp;
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 20%">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GRDDependencia" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnSelectedIndexChanged="GRDDependencia_SelectedIndexChanged" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                                                                    <asp:BoundField DataField="TOTAL" HeaderText="# DOCENTES" />
                                                                    <asp:CommandField SelectText="CREAR PLANTILLA" ShowSelectButton="True" />
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
                                                <td>&nbsp;</td>
                                                <td colspan="2">
                                                     <asp:UpdateProgress ID="UpdateProgress01" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image31" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="GRDEmpledo" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnPageIndexChanging="GRDEmpledo_PageIndexChanging" OnSelectedIndexChanged="GRDEmpledo_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="ID" />
                                                            <asp:BoundField DataField="Id_Empleado" HeaderText="ID_EMPLEADO" />
                                                            <asp:BoundField DataField="PLAZA" HeaderText="PLAZA" />
                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
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
                                                <td colspan="3" class="cuadro_botones">
                                                    <asp:UpdatePanel ID="UpdatePanel107" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnAceptar" runat="server" CssClass="btn" Text="Aceptar" ValidationGroup="Guardar" OnClick="btnAceptar_Click" />
                                                            &nbsp;
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel110" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 20%">
                                                    <asp:Label ID="Label17" runat="server" Text="Fecha Inicio:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:UpdatePanel ID="UpdatePanel109" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtfecha_ini" runat="server" CssClass="box" onkeyup="javascript:this.value='';" Width="75px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderSol" runat="server" TargetControlID="txtfecha_ini" PopupButtonID="imgCalendarioini" />
                                                            <asp:ImageButton ID="imgCalendarioini" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfecha_ini" ErrorMessage="*Requerido" ValidationGroup="plantilla"></asp:RequiredFieldValidator>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label18" runat="server" Text="Fecha Fin:"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtfecha_fin" runat="server" AutoPostBack="True" CssClass="box" Width="100px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfecha_fin" PopupButtonID="imgCalendariofin" />
                                                            <asp:ImageButton ID="imgCalendariofin" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfecha_fin" ErrorMessage="*Requerido" ValidationGroup="plantilla"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td style="width: 25%">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%">&nbsp;</td>
                                                <td style="width: 20%">&nbsp;</td>
                                                <td style="width: 20%">&nbsp;</td>
                                                <td class="auto-style1" colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel108" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnguardar" runat="server" CssClass="btn" OnClick="btnguardar_Click" Text="Guardar" ValidationGroup="plantilla" />
                                                            <asp:Button ID="cancelar_act" runat="server" CssClass="btn" OnClick="cancelar_act_Click" Text="Cancelar" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel108">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image32" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
