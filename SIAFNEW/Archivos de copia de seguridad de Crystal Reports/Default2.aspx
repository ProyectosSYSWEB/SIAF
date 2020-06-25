<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="SAF.Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Font-Names="Times New Roman" 
                        Font-Size="X-Large" ForeColor="#B7A46C" Text="UNIVERSIDAD AUTÓNOMA DE CHIAPAS"></asp:Label>
&nbsp;&nbsp; </td>
                
            </tr>
            
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td width="33%">
                                &nbsp;</td>
                            <td width="33%" align="left" valign="top">
                                &nbsp;</td>
                            <td width="33%">
                                &nbsp;</td>
                            <td width="33%">
                                &nbsp;</td>
                            <td width="33%">
                                &nbsp;</td>
                            <td width="33%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">                                                                 
                                                                 <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                                    
                                    <asp:View ID="View1" runat="server">
                                    <table width="100%">
                                    <tr>
                            <td width="15%" align="center" valign="top">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAvances1" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CVE">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkBttnDetalle" runat="server"  
                                                            ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="Polizas" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                            <sortedascendingcellstyle backcolor="#FBFBF2" />
                                            <sortedascendingheaderstyle backcolor="#848384" />
                                            <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                            <sorteddescendingheaderstyle backcolor="#575357" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="15%" align="center" valign="top">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAvances2" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image18" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CVE">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkBttnDetalle1" runat="server" 
                                                            onmouseout="hideTooltip(this)" onmouseover="showTooltip(this)" 
                                                            ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="Polizas" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                            <sortedascendingcellstyle backcolor="#FBFBF2" />
                                            <sortedascendingheaderstyle backcolor="#848384" />
                                            <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                            <sorteddescendingheaderstyle backcolor="#575357" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="15%" align="center" valign="top" style="margin-left: 80px">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAvances3" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image19" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CVE">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkBttnDetalle2" runat="server" 
                                                            onmouseout="hideTooltip(this)" onmouseover="showTooltip(this)" 
                                                            ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="Polizas" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                            <sortedascendingcellstyle backcolor="#FBFBF2" />
                                            <sortedascendingheaderstyle backcolor="#848384" />
                                            <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                            <sorteddescendingheaderstyle backcolor="#575357" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="15%" align="center" valign="top">
                                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAvances4" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image20" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CVE">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkBttnDetalle3" runat="server" 
                                                            onmouseout="hideTooltip(this)" onmouseover="showTooltip(this)" 
                                                            ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="Polizas" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                            <sortedascendingcellstyle backcolor="#FBFBF2" />
                                            <sortedascendingheaderstyle backcolor="#848384" />
                                            <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                            <sorteddescendingheaderstyle backcolor="#575357" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="15%" align="center" valign="top">
                                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAvances5" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image21" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CVE">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkBttnDetalle4" runat="server" 
                                                            onmouseout="hideTooltip(this)" onmouseover="showTooltip(this)" 
                                                            ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="Polizas" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                            <sortedascendingcellstyle backcolor="#FBFBF2" />
                                            <sortedascendingheaderstyle backcolor="#848384" />
                                            <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                            <sorteddescendingheaderstyle backcolor="#575357" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="15%" align="center" valign="top">
                                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAvances6" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image22" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CVE">
                                                    <ItemTemplate>                                                       
                                                        <asp:LinkButton ID="lnkBttnDetalle5" runat="server" 
                                                            onmouseout="hideTooltip(this)" onmouseover="showTooltip(this)" 
                                                            ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="Polizas" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                            <sortedascendingcellstyle backcolor="#FBFBF2" />
                                            <sortedascendingheaderstyle backcolor="#848384" />
                                            <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                            <sorteddescendingheaderstyle backcolor="#575357" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                                        <tr>
                                            <td align="center" valign="top" width="15%">
                                                &nbsp;</td>
                                            <td align="center" valign="top" width="15%">
                                                &nbsp;</td>
                                            <td align="center" style="margin-left: 80px" valign="top" width="15%">
                                                &nbsp;</td>
                                            <td align="center" valign="top" width="15%">
                                                &nbsp;</td>
                                            <td align="center" valign="top" width="15%">
                                                &nbsp;</td>
                                            <td align="right" valign="top" width="15%">
                                                <asp:Button ID="btnIrGraficas" runat="server" BackColor="#296C94" 
                                                    BorderColor="#53B6E5" Height="30px" onclick="btnIrGraficas_Click" 
                                                    Text="Gráficas" Width="100px" />
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table style="width:100%;" width="100%">
                                            <tr>
                                                <td style="width: 66%">                                                                                                                                                            
                                                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                                                        Width="100%">
                                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                            <HeaderTemplate>
                                                                CONTABILIDAD
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="33%">
                                                                            <br />
                                                                            <asp:Chart ID="Chart1" runat="server">
                                                                                <Series>
                                                                                    <asp:Series Name="Series1">
                                                                                    </asp:Series>
                                                                                </Series>
                                                                                <ChartAreas>
                                                                                    <asp:ChartArea Name="ChartArea1">
                                                                                    </asp:ChartArea>
                                                                                </ChartAreas>
                                                                            </asp:Chart>
                                                                        </td>
                                                                        <td width="33%">
                                                                            <ajaxToolkit:BarChart ID="BarChart1" runat="server">
                                                                            </ajaxToolkit:BarChart>
                                                                        </td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            <asp:Button ID="btnIrSemaforos" runat="server" BackColor="#296C94" 
                                                                                BorderColor="#53B6E5" Height="30px" onclick="btnIrSemaforos_Click" 
                                                                                Text="Indicadores de Pólizas Capturadas" Width="218px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                            <HeaderTemplate>
                                                                PRESUPUESTO
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="33%">
                                                                            <%--<asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                                                <ContentTemplate>--%>
                                                                        </td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="33%" align="center">
                                                                            PASAR MOUSE SOBRE BARRA</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                        <td width="33%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                    </ajaxToolkit:TabContainer>
                                                <br />
                                                    </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td align="center" valign="top" colspan="6">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="ADECUACIONES" 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" width="15%">
                                                    <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvAvances_PP1" runat="server" AutoGenerateColumns="False" 
                                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image23" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CVE">
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkBttnDetalle6" runat="server" 
                                                                                onclick="lnkBttnDetalle6_Click" onmouseout="hideTooltip(this)" 
                                                                                onmouseover="showTooltip(this)" ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Font-Size="10px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Etiqueta" HeaderText="Total">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" />
                                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                <RowStyle BackColor="#F7F7DE" />
                                                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                                                <sortedascendingcellstyle backcolor="#FBFBF2" />
                                                                <sortedascendingheaderstyle backcolor="#848384" />
                                                                <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                                                <sorteddescendingheaderstyle backcolor="#575357" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" valign="top" width="15%">
                                                    <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvAvances_PP2" runat="server" AutoGenerateColumns="False" 
                                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image24" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CVE">
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkBttnDetalle7" runat="server" 
                                                                                onclick="lnkBttnDetalle7_Click" onmouseout="hideTooltip(this)" 
                                                                                onmouseover="showTooltip(this)" ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Font-Size="10px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Etiqueta" HeaderText="Total">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" />
                                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                <RowStyle BackColor="#F7F7DE" />
                                                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                                                <sortedascendingcellstyle backcolor="#FBFBF2" />
                                                                <sortedascendingheaderstyle backcolor="#848384" />
                                                                <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                                                <sorteddescendingheaderstyle backcolor="#575357" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" valign="top" width="15%">
                                                    <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvAvances_PP3" runat="server" AutoGenerateColumns="False" 
                                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image25" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CVE">
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkBttnDetalle8" runat="server" 
                                                                                onclick="lnkBttnDetalle8_Click" onmouseout="hideTooltip(this)" 
                                                                                onmouseover="showTooltip(this)" ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Font-Size="10px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Etiqueta" HeaderText="Total">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" />
                                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                <RowStyle BackColor="#F7F7DE" />
                                                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                                                <sortedascendingcellstyle backcolor="#FBFBF2" />
                                                                <sortedascendingheaderstyle backcolor="#848384" />
                                                                <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                                                <sorteddescendingheaderstyle backcolor="#575357" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" valign="top" width="15%">
                                                    <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvAvances_PP4" runat="server" AutoGenerateColumns="False" 
                                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image26" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CVE">
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkBttnDetalle9" runat="server" 
                                                                                onclick="lnkBttnDetalle9_Click" onmouseout="hideTooltip(this)" 
                                                                                onmouseover="showTooltip(this)" ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Font-Size="10px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Etiqueta" HeaderText="Total">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" />
                                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                <RowStyle BackColor="#F7F7DE" />
                                                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                                                <sortedascendingcellstyle backcolor="#FBFBF2" />
                                                                <sortedascendingheaderstyle backcolor="#848384" />
                                                                <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                                                <sorteddescendingheaderstyle backcolor="#575357" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" valign="top" width="15%">
                                                    <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvAvances_PP5" runat="server" AutoGenerateColumns="False" 
                                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image27" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CVE">
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkBttnDetalle10" runat="server" 
                                                                                onclick="lnkBttnDetalle10_Click" onmouseout="hideTooltip(this)" 
                                                                                onmouseover="showTooltip(this)" ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Font-Size="10px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Etiqueta" HeaderText="Total">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" />
                                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                <RowStyle BackColor="#F7F7DE" />
                                                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                                                <sortedascendingcellstyle backcolor="#FBFBF2" />
                                                                <sortedascendingheaderstyle backcolor="#848384" />
                                                                <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                                                <sorteddescendingheaderstyle backcolor="#575357" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="center" valign="top" width="15%">
                                                    <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvAvances_PP6" runat="server" AutoGenerateColumns="False" 
                                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                                                CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="95%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image28" runat="server" ImageUrl='<%# Bind("EtiquetaDos") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CVE">
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblCC" runat="server" Text='<%# Bind("Descripcion") %>' ToolTip='<%# Bind("EtiquetaTres") %>' onmouseover="showTooltip(this)"
          onmouseout="hideTooltip(this)"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkBttnDetalle11" runat="server" 
                                                                                onclick="lnkBttnDetalle11_Click" onmouseout="hideTooltip(this)" 
                                                                                onmouseover="showTooltip(this)" ToolTip='<%# Bind("EtiquetaTres") %>'><%# DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Font-Size="10px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Etiqueta" HeaderText="Total">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" />
                                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                <RowStyle BackColor="#F7F7DE" />
                                                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                                                <sortedascendingcellstyle backcolor="#FBFBF2" />
                                                                <sortedascendingheaderstyle backcolor="#848384" />
                                                                <sorteddescendingcellstyle backcolor="#EAEAD3" />
                                                                <sorteddescendingheaderstyle backcolor="#575357" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" width="15%">
                                                    &nbsp;</td>
                                                <td align="center" valign="top" width="15%">
                                                    &nbsp;</td>
                                                <td align="center" valign="top" width="15%">
                                                    &nbsp;</td>
                                                <td align="right" valign="top" width="15%">
                                                    &nbsp;</td>
                                                <td align="right" valign="top" width="15%">
                                                    &nbsp;</td>
                                                <td align="right" valign="top" width="15%">
                                                    <asp:Button ID="btnIrGraficasPP" runat="server" BackColor="#296C94" 
                                                        BorderColor="#53B6E5" Height="30px" onclick="btnIrGraficasPP_Click" 
                                                        Text="Gráficas" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>

                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="6">
                                &nbsp;</td>
                        </tr>
                        </table>
                </td>
                
            </tr>
            
            <tr>
                <td align="right">
                    &nbsp;</td>
                
            </tr>
            
            <tr>
                <td>
                    &nbsp;</td>
                
            </tr>
            
            <tr>
                <td align="center">
                    <asp:Panel ID="Panel1" runat="server" CssClass="TituloModalPopupMsg" 
                        Width="35%">
                        <table width="100%" align="center">
                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: center">
                                    <asp:Image ID="Image2" runat="server" 
                                        ImageUrl="~/images/admiracion.jpg" Height="60px" Width="60px" />
                                    <br />
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblMsg_Observaciones" runat="server" Font-Bold="True" 
                                                                                                                    
                                                
                                                
                                                Text="Una mentalidad positiva te ayuda a triunfar. Piensa bien, para vivir mejor" 
                                                Width="80%"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: center">
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" 
                                        NavigateUrl="https://sysweb.unach.mx/saf/Contabilidad/Formatos/FORMATO_APERTURA_DE_CUENTAS_2015.docx">Apertura de Cuentas</asp:HyperLink>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSi" runat="server" CssClass="MsjG" onclick="btnSi_Click" 
                                                Text="OK" Width="107px" />
                                            &nbsp;
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                
            </tr>
            
            <tr>
                <td>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                        PopupControlID="Panel1" TargetControlID="HiddenField1" 
                        BackgroundCssClass="modalBackground_Proy">
                    </ajaxToolkit:ModalPopupExtender>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    &nbsp;</td>
                
            </tr>
            
            <tr>
                <td>
                    &nbsp;</td>
                
            </tr>
            
            </table>
</asp:Content>
