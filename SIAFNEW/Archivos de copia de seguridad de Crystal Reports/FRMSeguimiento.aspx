<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMSeguimiento.aspx.cs" Inherits="SAF.Adquisiciones.FRMSeguimiento" %>
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table class="tabla_contenido">
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="DEPENDENCIA:"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelDependencia" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="true" 
                                            CssClass="txtCls" 
                                            OnSelectedIndexChanged="DDLDependencia_OnSelectedIndexChanged" Width="550px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdateProgress ID="UpdateProgressDep" runat="server" 
                                    AssociatedUpdatePanelID="UpdatePanelDependencia">
                                    <progresstemplate>
                                        <asp:Image ID="Image1" runat="server" AlternateText="Cargando" 
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                                    </progresstemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="STATUS:"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                    OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal" Width="100%">
                                    <asp:ListItem Value="SSL001">REGISTRADA</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="SSL002">SOLICITADA</asp:ListItem>
                                    <asp:ListItem Value="SSL003">DENEGADA</asp:ListItem>
                                    <asp:ListItem Value="SSL004">AUTORIZADA</asp:ListItem>
                                    <asp:ListItem Value="SSL005">COTIZACIÓN</asp:ListItem>
                                    <asp:ListItem Value="SSL006">VISTO BUENO</asp:ListItem>
                                    <asp:ListItem Value="SSL007">CANCELADA</asp:ListItem>
                                    <asp:ListItem Value="SSL008">CONCLUIDA</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="right">
                                <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" 
                                    Text="Consutar" CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table>
                                    <tr>
                                        <td class="td">
                                            <asp:Label ID="Label3" runat="server" CssClass="header1" Font-Size="Small" 
                                                Text="Ordenar por" Width="95px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSolicitud" runat="server" CssClass="btn" 
                                                OnClick="btnSolicitud_Click" Text="Solicitud" Width="90px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnFecha" runat="server" CssClass="btn" 
                                                OnClick="btnFecha_Click" Text="Fecha" Width="90px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDiasT" runat="server" CssClass="btn" 
                                                OnClick="btnDiasT_Click" Text="Dias Tramite" Width="131px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDescripcion" runat="server" CssClass="btn" 
                                                OnClick="btnDescripcion_Click" Text="Descripción" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="5">
                                            <br/>
                                            <center>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridSolicitudGeneradas" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" CssClass="mGrid" 
                                                            EmptyDataText="NO HAY DATOS PARA MOSTRAR" GridLines="Vertical" 
                                                            OnPageIndexChanging="GridSolicitudGeneradas_PageIndexChanging" 
                                                            OnRowDataBound="GridSolicitudGeneradas_RowDataBound" 
                                                            OnRowDeleting="GridSolicitudGeneradas_RowDeleting" 
                                                            OnRowEditing="GridSolicitudGeneradas_RowEditing" 
                                                            OnSelectedIndexChanging="GridSolicitudGeneradas_OnSelectedIndexChanging">
                                                            <Columns>
                                                                <asp:BoundField DataField="id_solicitud_compra" />
                                                                <asp:BoundField DataField="NUM_SOLICITUD" HeaderText="SOLICITUD">
                                                                <ItemStyle Width="110px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FECHA_SOLICITUD" HeaderText="FECHA" />
                                                                <asp:BoundField DataField="dias_tramite" HeaderText="DIAS DE TRAMITE">
                                                                <FooterStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PROYECTO" HeaderText="DEPENDENCIA">
                                                                <ItemStyle HorizontalAlign="Left" Width="650px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="responsable" HeaderText="RESPONSABLE">
                                                                <ItemStyle HorizontalAlign="Left" Width="600px" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ButtonType="Image" DeleteText="Editar" 
                                                                    EditImageUrl="~/images/mail_replylist.png" EditText="Ver Datos" 
                                                                    HeaderText="Ver" ShowEditButton="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:CommandField>
                                                                <asp:CommandField HeaderText="Editar" SelectText="Editar" 
                                                                    ShowSelectButton="True" />
                                                                <asp:CommandField ButtonType="Image" 
                                                                    DeleteImageUrl="~/images/collapse_blue.png" DeleteText="Histórico" 
                                                                    EditText="Ver" HeaderText="Histórico" ShowDeleteButton="True" />
                                                                <%--<asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                
                                                                <asp:HyperLink ID="hplVer" runat="server" Target="Contenedor"
                                         Text='Click aquí' NavigateUrl='<%# Makefodas1(Eval("id_solicitud_compra")) %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                       </asp:TemplateField> --%>
                                                            </Columns>
                                                           <FooterStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                                <HeaderStyle CssClass="enc" />                                                
                                                                <AlternatingRowStyle CssClass="alt" /> 
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </center>
                                            <asp:Button ID="btnInvisible" runat="server" CssClass="invisible" Height="0px" 
                                                Text="Button" Width="0px" />
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnlModal" runat="server" CssClass="TablaContenido" 
                                                        Height="500px" style="display:none; height:500px; width:770px; background-color:White;
                                            border-width:2px; border-color:#D5DDE6; border-style:solid;">
                                                        <asp:Panel ID="pnlEncabezado" runat="server" CssClass="TablaContenido">
                                                            <table style="width:730px; vertical-align:top">
                                                                <tr class="TDTituloMensaje">
                                                                    <td align="left">
                                                                        <asp:Label ID="lblModalTitulo" runat="server" CssClass="TDTituloMensaje" 
                                                                            Text="Histórico"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="LabelNumSol" runat="server" CssClass="TDTituloMensaje"></asp:Label>
                                                                    </td>
                                                                    <td align="right" style="width:400px;">
                                                                        <asp:ImageButton ID="imgbtnX" runat="server" AlternateText="Cerrar" 
                                                                            Height="16px" ImageAlign="Right" ImageUrl="~/images/expand_blue.png" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <br/>
                                                        <center>
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:GridView ID="GridHistorico" runat="server" AllowPaging="True" 
                                                                        AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                                                        BorderWidth="1px" CellPadding="2" EmptyDataText="NO HAY DATOS PARA MOSTRAR" 
                                                                        ForeColor="Black" GridLines="Vertical" 
                                                                        OnPageIndexChanging="GridHistorico_PageIndexChanging" 
                                                                        OnRowDataBound="GridHistorico_RowDataBound">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="num_solicitud" HeaderText="Numero de solicitud">
                                                                            <ItemStyle Width="110px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="status" HeaderText="STATUS">
                                                                            <ItemStyle Width="110px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="FECHA_MOVIMIENTO" HeaderText="FECHA DE MOVIMIENTO" />
                                                                            <asp:BoundField DataField="USUARIO" HeaderText="USUARIO">
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="OBSERVACIONES" HeaderText="OBSERVACIONES">
                                                                            <ItemStyle HorizontalAlign="Left" Width="500px" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                                                            HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="Tan" CssClass="header1" Font-Bold="True" />
                                                                        <AlternatingRowStyle BackColor="PaleGoldenrod" CssClass="onlybg" />
                                                                        <FooterStyle BackColor="Tan" />
                                                                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </center>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="td" colspan="5">
                                            <asp:UpdatePanel ID="UpdatePanelCancelar" runat="server" RenderMode="Inline">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" 
                                                        Text="Salir" Width="60px" CssClass="btn2" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                <table class="tabla_contenido">
                                        <tr>
                                                <td>
                                                    <asp:Label ID="lblstatus1" runat="server" Text="STATUS:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                         
                                                        <asp:ListItem Selected="False" Value="SSL003">DENEGADA</asp:ListItem>
                                                        <asp:ListItem Selected="False" Value="SSL004">AUTORIZADA</asp:ListItem>
                                                        <asp:ListItem Selected="False" Value="SSL005">COTIZACI&#211;N</asp:ListItem>
                                                        <asp:ListItem Selected="False" Value="SSL006">VISTO BUENO</asp:ListItem>
                                                        <asp:ListItem Selected="False" Value="SSL007">CANCELADA</asp:ListItem>
                                                        <asp:ListItem Selected="False" Value="SSL008">CONCLUIDA</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnCambios" runat="server" Text="Aplicar Cambios" OnClick="btnCambios_Click" CssClass="btn"/>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="lblObs" runat="server" Text="OBSERVACIONES:"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtObs" runat="server" Height="100px" TextMode="MultiLine" Width="500px" MaxLength="1000"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                   <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn2"/>
                                           </td>
                                        </tr>
                                        <tr>
                                            <td  colspan="3" style="text-align: center; width:85%;">
                                               
                                                    <iframe id="miniContenedor" name="miniContenedor" marginheight="0" marginwidth="0" frameborder="0" src="..\blanco.htm"></iframe>
                                                
                                            </td>                                       
                                        </tr>
                                </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
