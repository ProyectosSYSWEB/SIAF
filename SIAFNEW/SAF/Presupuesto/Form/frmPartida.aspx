﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPartida.aspx.cs" Inherits="SAF.Presupuesto.Form.frmPartida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }

        .ColumnaOculta {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<div class="mensaje">
                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
            <table class="tabla_contenido">
                <tr>
                    <td class="auto-style1">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>


                                            <asp:MultiView ID="Multiview1" runat="server">



                                                <asp:View ID="View_1" runat="server">
                                                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" ValidationGroup="Agregar" />
                                                    <br />
                                                    <asp:Label ID="lblCap" runat="server" Text="Sub-Capitulo"></asp:Label>
                                                    <asp:DropDownList ID="DDLClave" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLClave_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:GridView ID="GRDPartidas" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro." OnRowDeleting="GRDPartidas_RowDeleting" OnSelectedIndexChanged="GRDPartidas_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="Partida" HeaderText="Partida" />
                                                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                                                            <asp:BoundField DataField="Descrip" HeaderText="Descripcion" />
                                                            <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" />
                                                            <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnEditar" runat="server" CommandName="Select" Visible="true">Editar</asp:LinkButton>
                                                                    <asp:Label ID="lblEditar" runat="server" ForeColor="#6B696B" Text="Editar" Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" Visible="true">Eliminar</asp:LinkButton>
                                                                    <asp:Label ID="lblEliminar" runat="server" ForeColor="#6B696B" Text="Eliminar" Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>

                                                        <FooterStyle CssClass="enc" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </asp:View>

                                                <asp:View ID="View_2" runat="server">

                                                    <table style="width: 100%;">

                                                        <tr>
                                                            <td style="width: 30%">
                                                                <asp:Label ID="lblPartida" runat="server" Text="Partida">
                                                                </asp:Label>
                                                            </td>
                                                            <td style="width: 80%">
                                                                <asp:TextBox ID="txtPartida" Text="" runat="server" Width="500px" MaxLength="5">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">
                                                                <asp:Label ID="lblDescrip" runat="server" Text="Descripción">
                                                                </asp:Label>
                                                            </td>
                                                            <td style="width: 80%">
                                                                <asp:TextBox ID="txtDescrip" Text="" runat="server" Width="500px">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">
                                                                <asp:Label ID="lblConcepto" runat="server" Text="Concepto">
                                                                </asp:Label>
                                                            </td>
                                                            <td style="width: 80%">
                                                                <asp:TextBox ID="txtConcepto" Text="" runat="server" Width="500px">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">
                                                                <asp:Label ID="lblEjercicio" runat="server" Text="Ejercicio">
                                                                </asp:Label>
                                                            </td>
                                                            <td style="width: 80%">
                                                                <asp:TextBox ID="txtEjercicio" Text="" runat="server" Width="500px">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td>
                                                                <asp:Button runat="server" ID="BTNEditarPartida" Text="Guardar" OnClick="BTNEditarPartida_Click" />
                                                            </td>
                                                            <td></td>
                                                            <td>
                                                                <a href="frmPartida.aspx">Regresar</a>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>

                                                </asp:View>

                                            </asp:MultiView>



                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
