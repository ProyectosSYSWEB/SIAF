<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultas.aspx.cs" Inherits="SAF.Presupuesto.Form.frmConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mensaje">
                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text="1-Seleccionar dependencia <br/> 2-Seleccionar capitulo <br/> 3-Seleccionar fuente <br/> 4-Seleccionar Código programático"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <table class="tabla_contenido">
                <tr>
                    <td class="auto-style1">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 10%">
                                    <asp:Label ID="Label4" runat="server" Text="Dependencia"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td style="width: 10%">
                                    <asp:Label ID="Label1" runat="server" Text="Fuente"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_SelectedIndexChanged"></asp:DropDownList>                                    
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="width:30%"">
                                    <asp:Label ID="Label2" runat="server" Text="Seleccionar un capitulo"></asp:Label>
                                </td>                                
                            </tr>
                            <tr>                                
                                <td>
                                    <asp:CheckBox ID="CBCap1" runat="server" AutoPostBack="true" Text="Capitulo 1000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap5" runat="server" AutoPostBack="true" Text="Capitulo 5000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap2" runat="server" AutoPostBack="true" Text="Capitulo 2000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                    
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap6" runat="server" AutoPostBack="true" Text="Capitulo 6000" OnCheckedChanged="CBCap_OnCheckedChanged"/>                                    
                                    
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap3" runat="server" AutoPostBack="true" Text="Capitulo 3000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                    
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap7" runat="server" AutoPostBack="true" Text="Capitulo 7000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                </td>                                
                            </tr>
                            <tr>          
                                <td>
                                    <asp:CheckBox ID="CBCap4" runat="server" AutoPostBack="true" Text="Capitulo 4000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CBCap8" runat="server" AutoPostBack="true" Text="Capitulo 8000" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                </td>                                
                            </tr>
                            <%--<tr>          
                                <td>
                                    <asp:CheckBox ID="CBCapT" runat="server" AutoPostBack="true" Text="Todos" OnCheckedChanged="CBCap_OnCheckedChanged"/>
                                </td>
                            </tr>--%>
                            
                            <tr>                                
                                <td style="width:10%">
                                    <asp:Label ID="Label3" runat="server" Text="Código Programatico"></asp:Label>
                                </td>
                                <td>                                     
                                    <asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="GRDCargarDatosCodProg">
                                        
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>                          

                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GRDCodProg" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontró ningún registro.">
                                                <Columns>
                                                    <asp:BoundField DataField="MES" HeaderText="MES" />
                                                    <asp:BoundField DataField="AUTORIZADO" HeaderText="Autorizado" />
                                                    <asp:BoundField DataField="Modificado" HeaderText="Modificado" />
                                                    <asp:BoundField DataField="Ministrado" HeaderText="Ministrado" />
                                                    <asp:BoundField DataField="Comprometido" HeaderText="Comprometido" />
                                                    <asp:BoundField DataField="Devengado" HeaderText="Devengado" />
                                                    <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" />
                                                    <asp:BoundField DataField="Pagado" HeaderText="Pagado" />
                                                    <asp:BoundField DataField="Disminucion" HeaderText="Disminucion" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<asp:LinkButton ID="LinkButton1" onclientclick="return confirm('Al cerrar la dependencia, la plantilla queda en bitacora y las modificaciones seran atendidas con su operador');" runat="server" OnClick="LinkButton1_Click">CERRAR</asp:LinkButton>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" Width="100%" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
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
