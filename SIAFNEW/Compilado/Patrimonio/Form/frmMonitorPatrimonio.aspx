<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMonitorPatrimonio.aspx.cs" Inherits="SAF.Contabilidad.Form.frmMonitorPatrimonio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
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
    <table class="tabla_contenido">       
       
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                </asp:UpdatePanel>
            </td>
            
        </tr>
        
        <tr>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
                    <ProgressTemplate>
                        <asp:Image ID="Image7" runat="server" Height="30px" ImageUrl="~/images/ajax_loader_gray_512.gif"
                                Width="30px" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            
        </tr>
        
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                        <tr>
            <td with="30%" class="izquierda">
                                        <asp:Label ID="lblCentro_Contable" runat="server" Text="Centro Contable:"></asp:Label>
            </td>
            <td width="70%" align="left">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLCentro_Contable" runat="server" Width="80%" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DDLCentro_Contable_SelectedIndexChanged" CssClass="auto-style1">
                        </asp:DropDownList>                        
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>
        </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            
        </tr>
        
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="scroll">
                            <asp:GridView ID="grvMonitorCont" runat="server" 
                               BorderStyle="None"  CellPadding="4"  Width="75%" 
                               GridLines="Vertical" AutoGenerateColumns="False" onpageindexchanging="grvMonitorCont_PageIndexChanging" 
                                PageSize="15" CssClass="mGrid" EmptyDataText="No hay registros para mostrar">                                
                                <Columns>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
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
            <td align="left">
                &nbsp;</td>
            
        </tr>
        
        <tr>
            <td>
                &nbsp;</td>
            
        </tr>
        
    </table>
</asp:Content>
