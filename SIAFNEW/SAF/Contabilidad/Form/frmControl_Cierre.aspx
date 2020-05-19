<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControl_Cierre.aspx.cs" Inherits="SAF.Contabilidad.Form.frmControl_Cierre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" 
    Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <table style="width:100%;">
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="70%" align="center">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <progresstemplate>
                        <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <td width="15%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="70%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                   <%-- <div class="scroll">--%>
                        <asp:GridView ID="grvControl_Cierre" runat="server" AutoGenerateColumns="False" 
                            BorderStyle="None" 
                            CellPadding="4" GridLines="Vertical" Width="100%" 
                            onselectedindexchanging="grvControl_Cierre_SelectedIndexChanging" 
                            PageSize="15" onpageindexchanging="grvControl_Cierre_PageIndexChanging" AllowPaging="True" CssClass="mGrid" OnSelectedIndexChanged="grvControl_Cierre_SelectedIndexChanged"
                            >                            
                            <Columns>
                                <asp:BoundField DataField="Id_Control_Cierre" HeaderText="ID" >
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CENTRO_CONTABLE" HeaderText="CENTRO CONTABLE" >
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="CIERRE">
                                    <HeaderTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMesGral" ErrorMessage="*Requerido" Font-Size="Smaller" InitialValue="0" ValidationGroup="vMesGral"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMesGral" runat="server" SelectedValue='<%# Bind("Mes_anio") %>' ValidationGroup="vMesGral">
                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="bttnCierreGeneral" runat="server" CssClass="btn2" Font-Size="X-Small" OnClick="bttnCierreGeneral_Click" Text="CERRAR" ValidationGroup="vMesGral" OnClientClick="return confirm('¿Desea cerrar todos los centros contables?');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMes" runat="server" 
                                            SelectedValue='<%# Bind("Mes_anio") %>' Enabled="False">
                                            <asp:ListItem Value="00">Apertura</asp:ListItem>
                                            <asp:ListItem Value="01">Enero</asp:ListItem>
                                            <asp:ListItem Value="02">Febrero</asp:ListItem>
                                            <asp:ListItem Value="03">Marzo</asp:ListItem>
                                            <asp:ListItem Value="04">Abril</asp:ListItem>
                                            <asp:ListItem Value="05">Mayo</asp:ListItem>
                                            <asp:ListItem Value="06">Junio</asp:ListItem>
                                            <asp:ListItem Value="07">Julio</asp:ListItem>
                                            <asp:ListItem Value="08">Agosto</asp:ListItem>
                                            <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                            <asp:ListItem Value="13">Cierre</asp:ListItem>
                                            <asp:ListItem Value="14">Bloqueado</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CIERRE DEFINITIVO">
                                    <HeaderTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMesGralD" ErrorMessage="*Requerido" Font-Size="Smaller" InitialValue="0" ValidationGroup="vMesGralD"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMesGralD" runat="server" SelectedValue='<%# Bind("Mes_anio") %>' ValidationGroup="vMesGral">
                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="bttnCierreGeneralD" runat="server" CssClass="btn2" Font-Size="X-Small" OnClick="bttnCierreGeneralD_Click" Text="CERRAR" ValidationGroup="vMesGralD" OnClientClick="return confirm('¿Desea cerrar todos los centros contables?');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMes2" runat="server" Enabled="False" 
                                            SelectedValue='<%# Bind("Cierre_Definitivo") %>'>
                                            <asp:ListItem Value="00">Apertura</asp:ListItem>
                                            <asp:ListItem Value="01">Enero</asp:ListItem>
                                            <asp:ListItem Value="02">Febrero</asp:ListItem>
                                            <asp:ListItem Value="03">Marzo</asp:ListItem>
                                            <asp:ListItem Value="04">Abril</asp:ListItem>
                                            <asp:ListItem Value="05">Mayo</asp:ListItem>
                                            <asp:ListItem Value="06">Junio</asp:ListItem>
                                            <asp:ListItem Value="07">Julio</asp:ListItem>
                                            <asp:ListItem Value="08">Agosto</asp:ListItem>
                                            <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                            <asp:ListItem Value="13">Cierre</asp:ListItem>
                                            <asp:ListItem Value="14">Bloqueado</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBttnEditar" runat="server" CommandName="Select">Editar</asp:LinkButton>
                                        <asp:LinkButton ID="linkBttnGuardar" runat="server" CommandName="Update" 
                                            onclick="linkBttnGuardar_Click" 
                                            onclientclick="return confirm('¿Desea modificar el registro?');" 
                                            Visible="False">Guardar</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBttnCancelar" runat="server" CommandName="Cancel" 
                                            onclick="linkBttnCancelar_Click" Visible="False">Cancelar</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle CssClass="enc" />
                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="sel" />
                            <HeaderStyle CssClass="enc" />                                                
                            <AlternatingRowStyle CssClass="alt" /> 
                        </asp:GridView>
                       <%-- </div>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="15%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="70%">
                &nbsp;</td>
            <td width="15%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="70%">
                &nbsp;</td>
            <td width="15%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
