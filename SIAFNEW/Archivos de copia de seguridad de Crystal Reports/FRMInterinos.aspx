<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMInterinos.aspx.cs" Inherits="SAF.Presupuesto.Form.FRMInterinos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="mensaje">
                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;
            </div>
            <table class="tabla_contenido">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width:15%">DEPENDENCIA:</td>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="True" CssClass="auto-style17" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged" Width="80%">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">SEMESTRE:</td>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDLSemestre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSemestre_SelectedIndexChanged" Width="37%">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel115" runat="server">
                                    <ContentTemplate>
                                        <table style="width:100%">
                                            <tr>
                                                <td class="auto-style20" colspan="4">
                                                    <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblMsjCP" runat="server" Font-Size="Medium" ForeColor="Red" Style="text-align: center"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18">BUSCAR :</td>
                                                <td class="auto-style15" colspan="2">
                                                    <asp:TextBox ID="TXTBuscar" runat="server" CssClass="textbuscar" Width="406px"></asp:TextBox>
                                                </td>
                                                <td class="auto-style34">
                                                    <asp:UpdatePanel ID="updBtns" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="BTNbuscar" runat="server" class="" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="BTNbuscar_Click" Width="45px" />
                                                            &nbsp; &nbsp;
                                                            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnNuevo_Click" ValidationGroup="Agregar" />
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="Agregar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style20" colspan="4">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updBtns">
                                                        <progresstemplate>
                                                            <asp:Image ID="Image30" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Width="50px" />
                                                        </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="GRDEmpledo" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró ningún registro." OnPageIndexChanging="GRDEmpledo_PageIndexChanging" OnSelectedIndexChanged="GRDEmpledo_SelectedIndexChanged" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="ID" />
                                                            <asp:BoundField DataField="Id_Empleado" HeaderText="ID_EMPLEADO" />
                                                            <asp:BoundField DataField="PLAZA" HeaderText="PLAZA" />
                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                            <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                            <asp:CommandField SelectText="Plantilla" ShowSelectButton="True" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#006600" OnClick="LinkButton1_Click">PosPlantilla</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Comparar</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel114" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lbt_otr" runat="server" ForeColor="#006600" OnClick="lbt_otr_Click" OnClientClick="return confirm('¿Desea agregar otro movimiento posterior ?');">Nuevo Posterior</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                                <td class="cuadro_botones" colspan="4">
                                                    <asp:ImageButton ID="imgBttnPDF" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnPDF_Click" title="Reporte PDF" />
                                                    <asp:ImageButton ID="imgBttnExcel" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExcel_Click" title="Reporte Excel" />
                                                </td>
                                            </tr>
                                        </table>
                                        </caption>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
