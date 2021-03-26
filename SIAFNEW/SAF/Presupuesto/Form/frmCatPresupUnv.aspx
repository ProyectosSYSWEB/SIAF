<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatPresupUnv.aspx.cs" Inherits="SAF.Presupuesto.Form.frmCatPresupUnv" %>

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
                                    <asp:Label ID="lblTipoOpe" runat="server" Text="Tipo de operación">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLTipoOperacion" runat="server" Width="500px" AutoPostBack="True">
                                        <asp:ListItem Value="A">Aumento</asp:ListItem>
                                        <asp:ListItem Value="D">Disminución</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:Button runat="server" ID="BTNGuardarPres" OnClick="BTNGuardarPres_Click" Text="Guardar" />
                                </td>
                            </tr>                           

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTiporRec" runat="server" Text="Tipo de recurso">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLTipoRec" runat="server" Width="500px" OnSelectedIndexChanged="DDLTipoRec_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="AC">Año en curso</asp:ListItem>
                                        <asp:ListItem Value="RM">Remanente</asp:ListItem>
                                    </asp:DropDownList>
                                </td> 
                            </tr>                            

                            <tr >
                                <td style="width:30%">
                                    <asp:Label ID="lblTipoOperacion" runat="server" Text="Consecutivo Tipo Operación">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">
                                    <asp:TextBox ID="txtConsecutivoOpe" Text="" runat="server" ReadOnly="true" Width="200px" Enabled="false">
                                    </asp:TextBox>                                    
                                </td>
                            </tr>

                            <tr >
                                <td style="width:30%">
                                    <asp:Label ID="lblDepOrg" runat="server" Text="Dependencia origen">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">
                                    <asp:TextBox ID="txtDepOrigen" Text="99999" runat="server" ReadOnly="true" Width="50px" Enabled="false">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtNombDepOrigen"  runat="server" Width="450px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblRefDoc" runat="server" Text="Referencia documento">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtRefDocto" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style63">
                                    <asp:Label ID="lblfechaDocumento" runat="server" Text="Fecha"></asp:Label>
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtfechaDocumento" runat="server" CssClass="box" Enabled="False" Width="95px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtfechaDocumento" />
                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtfechaDocumento" ErrorMessage="*Fecha Requerida" InitialValue="T" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblConcepto" runat="server" Text="Concepto">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtConcepto" Text="" runat="server" Width="500px" OnTextChanged="txtConcepto_TextChanged">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblImporte" runat="server" Text="Importe">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtImporte" Text="" runat="server" Width="500px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="lblMes" runat="server" Text="Mes">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtMes" Text="12" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:30%">
                                    <h5>Código presupuestal destino</h5>
                                </td>                                
                            </tr>                            

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblCentroContab" runat="server" Text="Centro contable">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLCentroContab" runat="server" Width="500px" AutoPostBack="True" Enabled="false" >                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblFuncion" runat="server" Text="Fuentes">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLFuente" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLFuente_OnSelectedIndexChanged"></asp:DropDownList>                                    
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblCodProg" runat="server" Text="Código programático">
                                    </asp:Label>
                                </td>
                                <td>                                    
                                    <asp:DropDownList ID="DDLCodProg" runat="server" Width="500px" AutoPostBack="True" OnSelectedIndexChanged="DDLCodProg_OnSelectedIndexChanged">                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblCentroContab_1" runat="server" Text="Centro contable">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtCentroContab" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblFuncion_1" runat="server" Text="Función">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtFuncion" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblPrograma" runat="server" Text="Programa">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtPrograma" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblSubPrograma" runat="server" Text="Sub-Programa" > 
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtSubProg" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDependencia" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblProyecto" runat="server" Text="Proyecto">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtProyecto" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblPartida" runat="server" Text="Partida">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtPartida" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblFuente" runat="server" Text="Fuente">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtFuente" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <%--<tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblTipoGasto" runat="server" Text="Tipo gasto">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtTipoGasto" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="lblDigitoMinist" runat="server" Text="Dig-ministrado">
                                    </asp:Label>
                                </td>
                                <td style="width:80%">                                    
                                    <asp:TextBox ID="txtDigMinis" Text="" runat="server" Width="500px" ReadOnly="true" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <%--<asp:Button runat="server" ID="BTNGuardarPres" OnClick="BTNGuardarPres_Click" Text="Guardar" />--%>
                                </td>
                                <td>                                    
                                </td>
                                <td>
                                    <a href="frmPresupUnv.aspx">Regresar</a>
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
