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
                                NodeIndent="15" onselectednodechanged="trvPresupuesto_SelectedNodeChanged" 
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
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="500px"                     
                    BorderColor="#c8c8c8'" BorderStyle="Solid" 
                    BorderWidth="1px">                              
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Image ID="Image5" runat="server" Height="30px" ImageUrl="~/images/ajax_loader_gray_512.gif"
                                Width="30px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <br />
                            <table Width="580px" 
                                style="border-style: none; border-color: 0; border-width: 0px; padding: 1px; margin: 1px; color: #FFFFFF;"><tr>
                                    <td Width="240px" align="center" 
                                        style="color: #000000; font-weight: bold; font-size: 11px;">TOTALES</td>
                                     <td Width="85px" style="background-color: #6B696B" align="right">
                                         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                             <ContentTemplate>
                                                 <asp:Label ID="lblAutorizado" runat="server" Text="0" Width="85px" 
                                                     Font-Size="11px"></asp:Label>
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </td>
                                     <td Width="85px" style="background-color: #6B696B" align="right">
                                         <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                             <ContentTemplate>
                                                 <asp:Label ID="lblModificado" runat="server" Text="0" Width="85px" 
                                                     Font-Size="11px"></asp:Label>
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </td>
                                     <td Width="85px" style="background-color: #6B696B" align="right">
                                         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                             <ContentTemplate>
                                                 <asp:Label ID="lblEjercido" runat="server" Text="0" Width="85px" 
                                                     Font-Size="11px"></asp:Label>
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </td>
                                     <td Width="85px" style="background-color: #6B696B" align="right">
                                         <asp:Label ID="lblAvance" runat="server" Text="0" Width="85px" Font-Size="11px"></asp:Label>
                                    </td>
                                 </tr>
                            </table>
                            <asp:GridView ID="grvPresupuesto" runat="server"                                
                                AllowPaging="True" 
                                AutoGenerateColumns="False" PageSize="15" Width="580px" 
                               EmptyDataText="No existen datos" 
                                onpageindexchanging="grvPresupuesto_PageIndexChanging" CssClass="mGrid">                              
                                <Columns>
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" >
                                        <ItemStyle Width="240px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="autorizado" HeaderText="Autorizado" 
                                        DataFormatString="{0:N}" >
                                        <ItemStyle Width="85px" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="modificado" HeaderText="Modificado" 
                                        DataFormatString="{0:N}" >
                                        <ItemStyle Width="85px" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Ejercido" HeaderText="Ejercido" 
                                        DataFormatString="{0:N}" >
                                        <ItemStyle Width="85px" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="avance" HeaderText="Avance" >
                                        <ItemStyle Width="85px" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                </Columns>
                               <FooterStyle CssClass="enc" />
                                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                        <HeaderStyle CssClass="enc" />
                                                                                        <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    
                </div>
                </asp:Panel>
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
