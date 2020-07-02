<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMEditar_solicitud.aspx.cs" Inherits="SAF.Adquisiciones.Form.FRMEditar_solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            height: 21px;
        }
        .txtCls
        {}
        .box
        {}
        .style3
        {
            width: 268435184px;
        }
        .style4
        {
            width: 244px;
        }
        .style6
        {
            height: 21px;
            width: 245px;
        }
        .style7
        {
            width: 245px;
        }
        .auto-style1 {
            height: 28px;
        }
        .auto-style2 {
            height: 18px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
             <ContentTemplate>
              <asp:Panel ID="panelprincipal" runat="server">
                 <table class="tabla_contenido">
                     
                     <tr>
                         <td class="auto-style1">
                             <asp:Label ID="Label4" runat="server" Text="Fecha Inicial:"></asp:Label>
                         </td>
                         <td class="auto-style1">
                         <asp:TextBox ID="txtfecha_inicial" runat="server" AutoPostBack="True" 
                                                        CssClass="box" 
                                 Width="200px" ontextchanged="txtfecha_inicial_TextChanged" 
                                                        ></asp:TextBox>
                                                    <img alt="Ver calendario" 
                                        onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );" 
                                        src="../../images/Calendario.gif" style="cursor: pointer" />
                         </td>
                         <td class="auto-style1">
                             </td>
                     </tr>
                     <tr>
                         <td>
                             <asp:Label ID="Label5" runat="server" Text="Fecha final:"></asp:Label>
                         </td>
                         <td>
                            <asp:TextBox ID="txtfecha_final" runat="server" AutoPostBack="True" 
                                                        CssClass="box"  
                                 Width="200px" ontextchanged="txtFSolicitud_TextChanged" 
                                                        ></asp:TextBox>
                                                    <img alt="Ver calendario" 
                                        onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );" 
                                        src="../../images/Calendario.gif" style="cursor: pointer" /></td>
                         <td style="text-align: right">
                             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="ImageButton1_Click" />
                         </td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="3">
                             <asp:Panel ID="Panel1" runat="server">
                             <asp:UpdatePanel ID="panel_general" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GRDsolicitudes" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" CssClass="mGrid" 
                                                            EmptyDataText="NO HAY DATOS PARA MOSTRAR" GridLines="Vertical"                                                            
                                                             Width="100%" >
                                                            <Columns>
                                                                <%--<asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                
                                                                <asp:HyperLink ID="hplVer" runat="server" Target="Contenedor"
                                         Text='Click aquí' NavigateUrl='<%# Makefodas1(Eval("id_solicitud_compra")) %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                       </asp:TemplateField> --%>
                                                                <asp:BoundField DataField="ID_UR" HeaderText="DEPENDENCIA">
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN" >
                                                                    <ItemStyle Width="110px" Font-Size="10px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="REGISTRADA">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtnresgistrada" runat="server" 
                                                                            onclick="linbtnresgistrada_Click"><%# DataBinder.Eval(Container.DataItem, "Registrada")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SOLICITADA">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Linbtnsolicitada" runat="server" 
                                                                            onclick="Linbtnsolicitada_Click"><%# DataBinder.Eval(Container.DataItem, "Solicitada")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DENEGADA">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtndenaga" runat="server" onclick="linbtndenaga_Click"><%# DataBinder.Eval(Container.DataItem, "Denegada")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="AUTORIZADA">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtnautorizada" runat="server" 
                                                                            onclick="linbtnautorizada_Click"><%# DataBinder.Eval(Container.DataItem, "Autorizada")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="COTIZACIÓN">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtncotizacion" runat="server" 
                                                                            onclick="linbtncotizacion_Click"><%# DataBinder.Eval(Container.DataItem, "Cotizacion")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="VISTO BUENO">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtnvisto" runat="server" onclick="linbtnvisto_Click"><%# DataBinder.Eval(Container.DataItem, "Visto_Bueno")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CANCELADA">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtncancelada" runat="server" 
                                                                            onclick="linbtncancelada_Click"><%# DataBinder.Eval(Container.DataItem, "Cancelada")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CONCLUIDA">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linbtnconcluida" runat="server" 
                                                                            onclick="linbtnconcluida_Click"><%# DataBinder.Eval(Container.DataItem, "Concluida")%></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                                <HeaderStyle CssClass="enc" />                                                
                                                                <AlternatingRowStyle CssClass="alt" /> 
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                             </asp:Panel>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                      </table>
                

                 </asp:Panel>
                 <asp:Panel ID="panel_detalle" runat="server" Visible="False">
                     <table class="tabla_contenido">
                         <tr>
                             <td>
                                 <asp:Label ID="Label2" runat="server" Text="Dependencia:"></asp:Label>
                             </td>
                             <td>
                                 <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                     <ContentTemplate>
                                         <asp:DropDownList ID="ddldependencia_inicial" runat="server" 
                                             AutoPostBack="true" CssClass="txtCls" 
                                             onselectedindexchanged="ddldependencia_inicial_SelectedIndexChanged" 
                                             Width="550px" Enabled="False">
                                         </asp:DropDownList>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                             </td>
                             <td>
                                 <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                     Text="Regresar" CssClass="btn" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label3" runat="server" Text="Estatus:"></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" 
                                     CssClass="txtCls" Width="550px" Enabled="False">
                                 </asp:DropDownList>
                             </td>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td colspan="3">
                                 <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                     <ContentTemplate>
                                         <asp:GridView ID="GridSolicitudGeneradas" runat="server" AllowPaging="True" 
                                             AutoGenerateColumns="False"                                            
                                             EmptyDataText="NO HAY DATOS PARA MOSTRAR" 
                                             GridLines="Vertical" 
                                             onselectedindexchanged="GridSolicitudGeneradas_SelectedIndexChanged" 
                                             Width="100%" CssClass="mGrid">
                                             <Columns>
                                                 <%--<asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                
                                                                <asp:HyperLink ID="hplVer" runat="server" Target="Contenedor"
                                         Text='Click aquí' NavigateUrl='<%# Makefodas1(Eval("id_solicitud_compra")) %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                       </asp:TemplateField> --%>
                                                 <asp:BoundField DataField="Num_Solicitud" HeaderText="SOLICITUD">
                                                     <ItemStyle Width="110px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Fecha_Solicitud" HeaderText="FECHA" />
                                                 <asp:BoundField DataField="Obj_Particular" HeaderText="OBJETIVO PARTICULAR" />
                                                 <asp:BoundField DataField="Responsable" HeaderText="RESPONSABLE">
                                                 </asp:BoundField>
                                                 <asp:CommandField ButtonType="Image" DeleteText="Editar" 
                                                     EditImageUrl="~/Adquisiciones/images/mail_replylist.png" EditText="Ver Datos" 
                                                     HeaderText="VER" ShowEditButton="True">
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                 </asp:CommandField>
                                                 <asp:CommandField HeaderText="EDITAR" SelectText="Editar" 
                                                     ShowSelectButton="True" />
                                                 <asp:CommandField ButtonType="Image" 
                                                     DeleteImageUrl="~/Adquisiciones/images/collapse_blue.png" DeleteText="Histórico" 
                                                     EditText="Ver" HeaderText="HISTÓRICO" ShowDeleteButton="True" />
                                             </Columns>
                                            <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />                                                
                                                <AlternatingRowStyle CssClass="alt" /> 
                                         </asp:GridView>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                             </td>
                         </tr>
                     </table>
                 </asp:Panel>
                
                
             </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel ID="panel_final" runat="server" Visible="False">
            <table style="width: 100%;" >               
                <tr>
                    <td colspan="3" style="text-align: right">
                        <asp:UpdatePanel ID="UpdatePanelbtnCancelarLote" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btncancelar0" runat="server" onclick="btncancelar_Click" OnClientClick="return confirm('¿En realidad desea salir?');"
                                    Text="Salir" CssClass="btn2" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <ajaxToolkit:TabContainer ID="Tab_Solicitud" runat="server" ActiveTabIndex="1" 
                            style="text-align: left" Width="100%">
                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                <HeaderTemplate>
                                   PASO 1
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <table width="100%" class="tabla_contenido">
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblNumSolicitud" runat="server" Width="130px" Font-Bold="True" 
                                                            ForeColor="Red"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right" colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                                                    Text="Siguiente" ValidationGroup="g_solicitud" CssClass="btn" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblNumSolicitud0" runat="server" Text="Tipo Compra:" 
                                                            Width="130px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddltipo" runat="server" Width="250px">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                        <asp:UpdateProgress ID="UpdateProgressDep0" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanel16">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image7" runat="server" AlternateText="Cargando" 
                                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Width="50px" Height="50px" />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblFSolicitud" runat="server" Text="Fecha solicitud:" 
                                                            Width="140px"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtFSolicitud" runat="server" AutoPostBack="True" 
                                                                    CssClass="box" onkeyup="javascript:this.value='';" 
                                                                    ontextchanged="txtFSolicitud_TextChanged" Width="95px"></asp:TextBox>
                                                                <img alt="Ver calendario" 
                                                                    onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );" 
                                                                    src="../../images/Calendario.gif" style="cursor: pointer" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:" Width="130px"></asp:Label>
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
                                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Width="50px" Height="50px" />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblPrograma" runat="server" Text="Programa:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanelPrograma" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="true" 
                                                                    CssClass="txtCls" OnSelectedIndexChanged="DDLPrograma_OnSelectedIndexChanged" 
                                                                    Width="550px">
                                                                </asp:DropDownList>
                                                                
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ControlToValidate="DDLPrograma" ErrorMessage="*Requerido" InitialValue="000" 
                                                                    ValidationGroup="g_solicitud"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:UpdateProgress ID="UpdateProgressPro" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanelPrograma">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image2" runat="server" AlternateText="Cargando" 
                                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblProyecto" runat="server" Text="Proyecto:" Width="130px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanelProyecto" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLProyecto" runat="server" AutoPostBack="true" 
                                                                    CssClass="txtCls" OnSelectedIndexChanged="DDLProyecto_OnSelectedIndexChanged" 
                                                                    Width="550px">
                                                                </asp:DropDownList>
                                                                
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                    ControlToValidate="DDLProyecto" ErrorMessage="*Requerido" InitialValue="0000" 
                                                                    ValidationGroup="g_solicitud"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:UpdateProgress ID="UpdateProgressProy" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanelProyecto">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image3" runat="server" AlternateText="Cargando" 
                                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblPartida" runat="server" Text="Partida:" Width="130px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanelPartida" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLPartida" runat="server" AutoPostBack="true" 
                                                                    CssClass="txtCls" OnSelectedIndexChanged="DDLPartida_OnSelectedIndexChanged" 
                                                                    Width="550px">
                                                                </asp:DropDownList>
                                                                
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                        <asp:UpdateProgress ID="UpdateProgressPar" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanelPartida">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image4" runat="server" AlternateText="Cargando" 
                                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        &#160;</td>
                                                    <td>
                                                        &#160;</td>
                                                    <td>
                                                        &#160;</td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td class="style7">
                                                        &#160;</td>
                                                    <td>
                                                        &#160;</td>
                                                    <td>
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                    </td>
                                                    <td class="style2">
                                                    </td>
                                                    <td class="style2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        <asp:Label ID="lblObjProyecto" runat="server" Text="Objetivo del proyecto:" 
                                                            Width="130px"></asp:Label>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:TextBox ID="txtObjProyecto" runat="server" CssClass="txtCls" 
                                                            MaxLength="1000" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                                    </td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        <asp:Label ID="lblJustificacion" runat="server" Text="Justificación:" 
                                                            Width="130px"></asp:Label>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:TextBox ID="txtJustificacion" runat="server" CssClass="txtCls" 
                                                            MaxLength="1000" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                                    </td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        <asp:Label ID="lblLugarEntrega" runat="server" Text="Lugar de entrega:" 
                                                            Width="130px"></asp:Label>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:TextBox ID="txtLugarEntrega" runat="server" CssClass="txtCls" 
                                                            MaxLength="1000" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                                    </td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        <asp:Label ID="lblResponsable" runat="server" Text="Responsable del proyecto:" 
                                                            Width="130px"></asp:Label>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:UpdatePanel ID="UpdatePanelResponsable" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLResponsable" runat="server" CssClass="txtCls" 
                                                                    onselectedindexchanged="DDLResponsable_SelectedIndexChanged" Width="550px">
                                                                </asp:DropDownList>
                                                                
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                    ControlToValidate="DDLResponsable" ErrorMessage="*Requerido" 
                                                                    InitialValue="0000" ValidationGroup="g_solicitud"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:UpdateProgress ID="UpdateProgressResp" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanelResponsable">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image6" runat="server" AlternateText="Cargando Datos" 
                                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="txtCls" 
                                                            MaxLength="1000" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                                    </td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        &#160;</td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        &#160;</td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                    <td class="style2">
                                                        &#160;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style7">
                                                        &#160;</td>
                                                    <td>
                                                        &#160;</td>
                                                    <td>
                                                        &#160;</td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Detalle">
                                <HeaderTemplate>
                                    PASO 2
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:MultiView ID="MultiView1" runat="server">
                                                <asp:View ID="View1" runat="server">
                                                    <table class="tabla_contenido">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                                                    Text="Regresar" CssClass="btn2" />
                                                            </td>                                                            
                                                            <td style="text-align: right">
                                                                <asp:Button ID="btnCancelarLote0" runat="server" 
                                                                    OnClick="btnCancelarLote_Click" Text="NUEVO" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:UpdatePanel ID="UpdatePanelGrid0" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="GridModificar0" runat="server" AllowPaging="True" 
                                                                            AutoGenerateColumns="False" CssClass="mGrid" 
                                                                            EmptyDataText="NO HAY DATOS PARA MOSTRAR" GridLines="Vertical" 
                                                                            OnPageIndexChanging="GridModificar_PageIndexChanging" 
                                                                            OnRowDataBound="GridModificar_RowDataBound" 
                                                                            OnRowDeleting="GridModificar_RowDeleting" 
                                                                            OnRowEditing="GridModificar_RowEditing" PageSize="5" Width="100%"                                                                            
                                                                            onselectedindexchanged="GridModificar0_SelectedIndexChanged">
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ID" />
                                                                                <asp:BoundField DataField="LOTE" HeaderText="LOTE" />
                                                                                <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" />
                                                                                <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" />
                                                                                <asp:BoundField DataField="PRODUCTO" HeaderText="PRODUCTO" 
                                                                                    ItemStyle-HorizontalAlign="Left">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField ControlStyle-Width="110px" DataField="DESCRIPCION" 
                                                                                    HeaderText="DESCRIPCION" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200">
                                                                                <controlstyle width="110px" />
                                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="IMPORTE" HeaderText="SUBTOTAL" />
                                                                                <asp:BoundField DataField="IVA" HeaderText="IVA" />
                                                                                <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
                                                                                <asp:CommandField ButtonType="Image" 
                                                                                    DeleteImageUrl="~/Adquisiciones/images/delete.png" HeaderText="Eliminar" 
                                                                                    ShowDeleteButton="True" />
                                                                            </Columns>
                                                                           <FooterStyle CssClass="enc" />
                                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                        <HeaderStyle CssClass="enc" />                                                
                                                                                        <AlternatingRowStyle CssClass="alt" /> 
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &#160;</td>
                                                            <td>
                                                                &#160;</td>
                                                            <td>
                                                                &#160;</td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="View2" runat="server">
                                                    <table class="tabla_contenido">
                                                        <tr>
                                                            <td>
                                                                &#160;</td>
                                                            <td align="center" colspan="7" style="text-align: right">
                                                                <asp:Button ID="btnagregar_lote" runat="server" Text="Agregar" 
                                                                    onclick="btnagregar_lote_Click1" CssClass="btn" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblLote0" runat="server" Text="Codigo Programatico:"></asp:Label>
                                                            </td>
                                                            <td align="center" colspan="7" style="text-align: left">
                                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlcodigo_programatico" runat="server" 
                                                                            AutoPostBack="True" 
                                                                            onselectedindexchanged="ddlcodigo_programatico_SelectedIndexChanged" 
                                                                            Width="802px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &#160;</td>
                                                            <td align="center" colspan="7" style="text-align: left">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblMAutorizado" runat="server" Text="Monto Autorizado"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblAutorizado" runat="server" Text="0" 
                                                                                        Font-Bold="True" Font-Size="20px" ForeColor="Red"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblMDisponible" runat="server" Text="Monto Disponible" 
                                                                                Width="164px" Height="16px"></asp:Label>
                                                                            &#160;
                                                                        </td>
                                                                        <td>
                                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblDisponible" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lblDisponibleRed" runat="server" Font-Bold="True" 
                                                                                        Font-Size="20px" ForeColor="Red" Text="0" Height="23px"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblLote" runat="server" Text="Lote"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtLote" runat="server" AutoPostBack="true" 
                                                                            Width="130px"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtCantidad" runat="server" MaxLength="50" Width="130px"></asp:TextBox>
                                                            </td>
                                                            <td class="style3">
                                                                <asp:Label ID="lblUnidad" runat="server" Text="Unidad"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanelUnidad" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLUnidad" runat="server" AutoPostBack="true" 
                                                                            CssClass="txtCls" Width="130px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                <asp:Label ID="estimado" runat="server" Text="Precio Estimado"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblImporte" runat="server" Text="Subtotal:$"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtImporte" runat="server" AutoPostBack="false" MaxLength="50" 
                                                                    onblur="GenerarPrecioEstimado('1');" Width="130px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblIVA" runat="server" Text="IVA:$"></asp:Label>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtIVA" runat="server" AutoPostBack="True" MaxLength="50" 
                                                                            onblur="GenerarPrecioEstimado('2');" ontextchanged="txtIVA_TextChanged" 
                                                                            Width="130px"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td class="style3">
                                                                <asp:Label ID="lblTotal" runat="server" Text="Total:$"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTotal" runat="server" MaxLength="50" Width="130px" 
                                                                    Visible="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:UpdatePanel ID="UpdatePanelProducto" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLProducto" runat="server" AutoPostBack="true" 
                                                                            CssClass="txtCls" OnSelectedIndexChanged="DDLProducto_SelectedIndexChanged" 
                                                                            Width="361px">
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtProducto" runat="server" CssClass="txtCls" MaxLength="50" 
                                                                            Visible="false" Width="361px"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblDictamen" runat="server" Text="No. de Dictamen"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDictamen" runat="server" CssClass="txtCls" MaxLength="50" 
                                                                    Width="130px"></asp:TextBox>
                                                                &#160;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &#160;<asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                                                            </td>
                                                            <td colspan="7">
                                                                &#160;<asp:TextBox ID="txtDescripcion" runat="server" CssClass="txtCls" 
                                                                    Height="100px" MaxLength="1000" TextMode="MultiLine" Width="652px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%-- <td>
                                            <asp:Label ID="lblCategoria" runat="server" Text="Categoría"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:UpdatePanel ID="UpdatePanelCategoria" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLCategoria" CssClass="txtCls" AutoPostBack="true" runat="server" Width="300px" OnSelectedIndexChanged="DDLCategoria_OnSelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td colspan="4">
                                            <asp:Label ID="lblCatCTI" runat="server" Text="Características mínimas requeridas por CTI" Width="250px" Height="30px"></asp:Label>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                            <asp:TextBox ID="txtCategoria" runat="server" TextMode="MultiLine" ReadOnly="true" Width="350px" Height="160px"></asp:TextBox>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </td>--%>
                                                            <td colspan="8">
                                                                <asp:Panel ID="PnlCTI" runat="server" Visible="false">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblCategoria" runat="server" Text="Categoría"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:UpdatePanel ID="UpdatePanelCategoria" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:DropDownList ID="DDLCategoria" runat="server" AutoPostBack="true" 
                                                                                            CssClass="txtCls" ondatabinding="DDLCategoria_DataBinding" 
                                                                                            OnSelectedIndexChanged="DDLCategoria_OnSelectedIndexChanged" Width="300px">
                                                                                        </asp:DropDownList>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblCatCTI" runat="server" Height="30px" 
                                                                                    Text="Características mínimas requeridas por CTI" Width="250px"></asp:Label>
                                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:TextBox ID="txtCategoria" runat="server" Height="160px" ReadOnly="true" 
                                                                                            TextMode="MultiLine" Width="350px"></asp:TextBox>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                &#160;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                <asp:CheckBoxList ID="CBLInformacion" runat="server" TextAlign="Right">
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Label ID="lblCategoria0" runat="server" style="font-weight: 700" 
                                                                    Text="Documentos Requeridos"></asp:Label>
                                                            </td>
                                                            <td colspan="4">
                                                                <asp:Label ID="lblCategoria1" runat="server" style="font-weight: 700" 
                                                                    Text="Información Requerida"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                                                                    <asp:ListItem Value="REQ001">DICTAMEN PARA ADQ DE EQUIPOS 
                                                                DE COMUNICACIONES, TELECOMUNICACIONES E INFORMATICOS</asp:ListItem>
                                                                    <asp:ListItem Value="REQ002">DICTAMEN PARA ADQUISICIONES 
                                                                DE EQUIPOS DE AIRES ACONDICIONADOS</asp:ListItem>
                                                                    <asp:ListItem Value="REQ003">EN TODOS LOS CASOS OFICIO DE 
                                                                AUTORIZACIÓN DE RECURSO</asp:ListItem>
                                                                    <asp:ListItem Value="REQ004">ANEXAR IMPRESIÓN A COLOR Y 
                                                                LA ESCALA, EN CASO DE REQUERIR LOGOTIPOS O SIMILARES</asp:ListItem>
                                                                    <asp:ListItem Value="REQ005">DICTAMEN PARA ADQUISICIÓN DE 
                                                                VEHICULOS Y MAQUINARIA PESADA</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td colspan="4">
                                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                                                    <asp:ListItem Value="INF001">PRESENTACIÓN DE MUESTRAS</asp:ListItem>
                                                                    <asp:ListItem Value="INF002">CATALOGOS</asp:ListItem>
                                                                    <asp:ListItem Value="INF003">GARANTIAS</asp:ListItem>
                                                                    <asp:ListItem Value="INF004">DISEÑOS Y LOGOTIPOS</asp:ListItem>
                                                                    <asp:ListItem Value="INF005">SE REQUIERE DE INSTALACIÓN, 
                                                                MANTENIMIENTO, ASISTENCIA TÉCNICA</asp:ListItem>
                                                                    <asp:ListItem Value="INF006">SE REQUIERE DE NORMAS 
                                                                OFICIALES</asp:ListItem>
                                                                    <asp:ListItem Value="INF007">ENTREGA LIBRE A BORDO EN 
                                                                ESTABLECIMIENTO DEL PROVEEDOR</asp:ListItem>
                                                                    <asp:ListItem Value="INF008">CALENDARIO DE ENTREGA</asp:ListItem>
                                                                    <asp:ListItem Value="INF009">SE REQUIERE DE VISITAS 
                                                                FISICAS</asp:ListItem>
                                                                    <asp:ListItem Value="INF010">CRITERIOS DE ASIGNACION 
                                                                PROPUESTO</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                &#160;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                &#160;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7" style="text-align: right">
                                                                <%--<asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>--%>
                                                            </td>
                                                            <td>
                                                                &#160;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                            </asp:MultiView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
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
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
