<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMMonitor.aspx.cs" Inherits="SAF.Presupuesto.Form.FRMMonitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            color: #0066FF;
            font-size: 20px;
        }
    </style>
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
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="Label4" runat="server" CssClass="auto-style1" Text="MONITOR DE EVENTOS "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="width:15%">
                                            <asp:Label ID="Label6" runat="server" Text="Dependencia:"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label5" runat="server" Text="Semestre:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSemestre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSemestre_SelectedIndexChanged" Width="350px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="updBtns" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="BTNbuscar" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png"  Width="45px" OnClick="BTNbuscar_Click" />
                                                    &nbsp; &nbsp;
                                                    <br />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updBtns">
                                                <progresstemplate>
                                                    <asp:Image ID="Image30" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GRDMonitor" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                            <asp:BoundField DataField="SEMESTRE" HeaderText="SEMESTRE" />
                                                            <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
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
                                        <td colspan="2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>                   
                </tr>               
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
