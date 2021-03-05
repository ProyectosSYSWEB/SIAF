<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatCtrlPresupSaf.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatCtrlPresupSaf" %>

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
                    <td class="auto-style1">
                        <table style="width: 100%;">


                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label3" runat="server" Text="Dependencia">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged" ></asp:DropDownList>
                                </td> 
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTipoOpe" runat="server" Text="Código programático"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>

                            <%--<tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTiporRec" runat="server" Text="Centro contable"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLCContab" runat="server" Width="500px" AutoPostBack="True" Enabled="false"></asp:DropDownList>
                                </td> 
                            </tr>--%>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label1" runat="server" Text="Programa">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLPrograma" runat="server" Width="500px" AutoPostBack="True" Enabled="false"></asp:DropDownList>
                                </td> 
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label2" runat="server" Text="Subprograma">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLSubprog" runat="server" Width="500px" AutoPostBack="True" Enabled="false"></asp:DropDownList>
                                </td> 
                            </tr>

                            

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label4" runat="server" Text="Proyecto">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLProyecto" runat="server" Width="500px" AutoPostBack="True" Enabled="false"></asp:DropDownList>
                                </td> 
                            </tr>


                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label5" runat="server" Text="Partida">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLPartida" runat="server" Width="500px" AutoPostBack="True"></asp:DropDownList>
                                </td> 
                            </tr>


                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label6" runat="server" Text="Fuente">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged"></asp:DropDownList>
                                </td> 
                            </tr>


                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblTipoGasto" runat="server" Text="Tipo gasto">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtTipoGasto" Text="" runat="server" Width="500px" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblDigMinistrado" runat="server" Text="Dig-Ministrado">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDigiMinistrado" Text="" runat="server" Width="500px" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="Label7" runat="server" Text="Construcción del código programático">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtCodProg" Text="" runat="server" Width="500px" Enabled="false" ForeColor="Black">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="BTNGuardarCodigo" Text="Guardar" OnClick="BTNGuardarCodigo_Click" />
                                </td>
                                <td></td>
                                <td><a href="frmControlPresupSaf.aspx">Regresar</a></td>
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
