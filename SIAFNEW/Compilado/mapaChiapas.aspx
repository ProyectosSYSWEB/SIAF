<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mapaChiapas.aspx.cs" Inherits="SAF.mapaChiapas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function showModal(index) {
        alert("sss");
        var modal = $find("behaviorIDOfModal");
        modal.show();
    }
</script>
    <style type="text/css">
        .style2
        {
            width: 403px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                    TargetControlID="HiddenField1" PopupControlID="Panel1" 
                    BackgroundCssClass="modalBackground_Proy">
                </ajaxToolkit:ModalPopupExtender>
                </td>
        </tr>
        <tr>
            <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/images/chiapas.png" 
                    onclick="ImageMap1_Click" HotSpotMode="PostBack">
    <%--<asp:RectangleHotSpot NavigateUrl="" Top="510" Left="60" Bottom="650" Right="400" />--%>
    
                        <asp:CircleHotSpot X="230" Y="280" Radius="20" HotSpotMode="PostBack" PostBackValue="TUXTLA" AlternateText="SEDE TUXTLA" />    
                        <asp:CircleHotSpot X="340" Y="260" Radius="20" HotSpotMode="PostBack" PostBackValue="SAN CRISTOBAL" AlternateText="SEDE SAN CRISTOBAL" />
                        <asp:CircleHotSpot X="430" Y="380" Radius="20" HotSpotMode="PostBack" PostBackValue="COMITAN" AlternateText="SEDE COMITAN" />
                        <asp:CircleHotSpot X="370" Y="630" Radius="20" HotSpotMode="PostBack" PostBackValue="TAPACHULA" AlternateText="SEDE TAPACHULA" />
                    </asp:ImageMap>   
                </ContentTemplate>
            </asp:UpdatePanel>    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" CssClass="TituloModalPopupMsg" 
                    Width="550px">
                    <table style="width:100%;">
                        <tr>
                            <td align="right" class="style2" width="20%">
                                &nbsp;</td>
                            <td align="left" width="50%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" class="style2" width="20%">
                                <asp:Label ID="lblLeySede" runat="server" Font-Bold="True" Text="SEDE:"></asp:Label>
                            </td>
                            <td align="left" width="50%">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSede" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2" width="20%">
                                &nbsp;</td>
                            <td width="50%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2" width="20%">
                                &nbsp;</td>
                            <td width="50%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2" width="20%">
                                &nbsp;</td>
                            <td align="center" width="50%">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSalir" runat="server" Text="Regresar" 
                                            onclick="btnSalir_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2" width="20%">
                                &nbsp;</td>
                            <td width="50%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2" width="20%">
                                &nbsp;</td>
                            <td width="50%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
