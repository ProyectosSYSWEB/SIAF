<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPresupuesto.aspx.cs" Inherits="SAF.Presupuesto.frmPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <table style="width: 100%;">
        <tr>
            <td width="30%" valign="top" colspan="2" style="width: 100%" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="25%" valign="top">                
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="30px" ImageUrl="~/images/ajax_loader_gray_512.gif"
                                Width="30px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server"  ScrollBars="Vertical" Height="500px" Width="280px">
                            <asp:TreeView ID="trvPresupuesto" runat="server" ImageSet="XPFileExplorer" 
                                NodeIndent="15" 
                                CssClass="arbol" ExpandDepth="1">
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="75%" valign="top" align="center">
                
            </td>
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td width="70%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td width="70%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td width="70%">
                &nbsp;</td>
        </tr>
    </table></asp:Content>
