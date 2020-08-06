<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultReportes.aspx.cs" Inherits="SAF.DefaultReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 232px;
            height: 225px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col alert alert-warning">
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="alert alert-primary" role="alert">
        Modulo de registro y seguimiento de solicitudes de transferencias y ampliaciones presupuestales autorizadas por la Secretaría Administrativa.
</div>
        <div class="row">
            <div class="col-md-6">
                <img src="images/pres8.png" class="auto-style3" />
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                            <%--<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" Font-Bold="True" Font-Size="18px" ForeColor="#333333">
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <Nodes>
                                    <asp:TreeNode Text="Movimientos" Value="Movimientos">
                                        <asp:TreeNode NavigateUrl="~/Presupuesto/Form/FRMDocumento.aspx?P_REP=C" Text="Cédulas" Value="Cédulas"></asp:TreeNode>
                                        <asp:TreeNode NavigateUrl="~/Presupuesto/Form/FRMDocumento.aspx?P_REP=A" Text="Adecuaciones" Value="2"></asp:TreeNode>
                                        <asp:TreeNode NavigateUrl="~/Presupuesto/Form/FRMDocumento.aspx?P_REP=M" Text="Ministraciones" Value="3"></asp:TreeNode>
                                    </asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="True" Font-Size="14px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/SubMnuSAF3.png" />
                                <RootNodeStyle Font-Bold="True" Font-Size="16px" ImageUrl="https://sysweb.unach.mx/resources/imagenes//MenuSAF.png" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                            </asp:TreeView>--%>

                        <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Font-Size="Medium">
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="Clave" DataTextField="Descripcion" HeaderText="REPORTES" />
                            </Columns>
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <RowStyle Font-Size="14px" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                     
    </div>
</asp:Content>
