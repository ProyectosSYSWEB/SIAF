<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmControlSemovientes.aspx.cs" Inherits="SAF.Patrimonio.frmControlSemovientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
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
    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
        <ContentTemplate>
            <table class="tabla_contenido">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:MultiView ID="MultiView1" runat="server">
                                    <asp:View ID="View1" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 15%">&nbsp;</td>
                                                <td style="width: 70%" colspan="2">&nbsp;</td>
                                                <td style="width: 15%">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Dependencia:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="DDLDependencia" runat="server" Width="95%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEspecie" runat="server" Text="Especie:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLEspecie" runat="server" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DDLEspecie_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEtapa" runat="server" Text="Etapa:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="DDLEtapa" runat="server" Width="50%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEstatus" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="DDLStatus" runat="server" Width="25%">
                                                        <asp:ListItem Value="A">ALTA</asp:ListItem>
                                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
                                                </td>
                                                <td colspan="2">

                                                    <asp:TextBox ID="txtBuscar" runat="server" Width="95%" CssClass="textbuscar"
                                                        placeHolder="No. de inventario"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="imgbtnBuscar" runat="server" Height="38px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png"
                                                                OnClick="imgbtnBuscar_Click" Width="39px" ValidationGroup="Buscar" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%">
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image4" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                                Width="50px" AlternateText="Espere un momento, por favor.." ToolTip="Espere un momento, por favor.." />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                        </table>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvSemovientes" runat="server" EmptyDataText="No hay registros para mostrar" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderStyle="None" BorderWidth="1px" GridLines="Vertical" OnPageIndexChanging="grvSemovientes_PageIndexChanging"
                                                        Width="100%" OnSelectedIndexChanged="grvSemovientes_SelectedIndexChanged" OnRowDeleting="grvSemovientes_RowDeleting" CssClass="mGrid" PageSize="20">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id">
                                                            <HeaderStyle Wrap="True" />
                                                            <ItemStyle Wrap="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Centro_Contable" HeaderText="CENTRO CONTABLE">
                                                                <HeaderStyle Wrap="True" />
                                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="No_Inventario" HeaderText="# INVENTARIO [# ARETE]">
                                                                <HeaderStyle Wrap="True" />
                                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="Sem_Id_Especie" HeaderText="ID_ESPECIE">
                                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Especie" HeaderText="ESPECIE">
                                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Sexo" HeaderText="SEXO" />
                                                            <asp:BoundField DataField="Sem_Etapa" HeaderText="ETAPA PRODUCTIVA">
                                                                <HeaderStyle Wrap="True" />
                                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Raza" HeaderText="RAZA">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Fecha_Alta_Str" HeaderText="FECHA INICIO">
                                                                <HeaderStyle Wrap="True" />
                                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Edad" HeaderText="EDAD (MESES)">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Peso" HeaderText="PESO (KG)">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <%-- <asp:BoundField DataField="Costo" HeaderText="COSTO" DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:BoundField>--%>
                                                            <%--<asp:BoundField DataField="Formulario" />
                                                    <asp:BoundField DataField="Validado" />--%>
                                                            <asp:CommandField SelectText="HISTORICO" ShowSelectButton="True" ></asp:CommandField>
                                                            <asp:CommandField DeleteText="ETAPA" ShowDeleteButton="True"></asp:CommandField>
                                                             <asp:TemplateField> 
                                                            <ItemTemplate>
                                                 <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="linkBtnProduccion" runat="server" onclick="linkBttnProduccion_Click" >PRODUCCION</asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                            </ItemTemplate>
                                                                    </asp:TemplateField>
                                                              <asp:TemplateField> 
                                                            <ItemTemplate>
                                                 <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="linkBtnEditar" runat="server" onclick="linkBttnEditar_Click" >EDITAR</asp:LinkButton>
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
                                                <td align="center"></td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:HiddenField ID="hdnFieldFila" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>

                                                <td class="cuadro_botones">

                                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"
                                                        Width="49px" OnClick="imgBttnPdf" />
                                                    <asp:ImageButton ID="ImageButton3" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png"
                                                        Width="49px" OnClick="imgBttnExcel" />

                                                </td>

                                            </tr>
                                        </table>

                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 15%">&nbsp;</td>
                                                <td style="width: 85%" colspan="5">&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="No. Inventario:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInventario" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                                                </td>
                                                <td colspan="5">
                                                    <asp:TextBox ID="txtDescripcion" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Especie:"></asp:Label>
                                                </td>
                                                <td colspan="5">

                                                    <asp:TextBox ID="txtEspecie" runat="server" Enabled="False" Width="99%"></asp:TextBox>

                                                </td>

                                            </tr>

                                        </table>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label4" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtNacimiento" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" align="right" > 
                                                    <asp:Label ID="Label5" runat="server" Text="Edad [Meses]:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtEdad" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" align="right" >
                                                    <asp:Label ID="Label6" runat="server" Text="Años:" Style="text-align: right"></asp:Label>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:TextBox ID="txtAnios" runat="server" Enabled="False" Width="95%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>

                                        <table style="width: 100%;">

                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                                                </td>
                                                <td style="width: 85%" colspan="5">
                                                    <asp:TextBox ID="txtSexo" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="5"></td>

                                            </tr>

                                        </table>

                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" Text="H i s t ó r i c o"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvHistorico" runat="server" EmptyDataText="No hay registros para mostrar" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderStyle="None" BorderWidth="1px" GridLines="Vertical" OnPageIndexChanging="grvHistorico_PageIndexChanging"
                                                        Width="100%" CssClass="mGrid" PageSize="20" OnSelectedIndexChanged="grvHistorico_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                                                              <asp:BoundField DataField="Sem_Id_Etapa" HeaderText="ID_ETAPA"></asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Etapa" HeaderText="ETAPA">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_FechaNac_Str" HeaderText="FECHA">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Edad" HeaderText="EDAD [Meses]">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Peso" HeaderText="PESO [Kg]" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Costo" HeaderText="COSTO">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:CommandField SelectText="VER" ShowSelectButton="True" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                           <%-- <asp:CommandField DeleteText="ELIMINAR" ShowDeleteButton="True">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:CommandField>--%>
                                                             <asp:TemplateField>
                                            <ItemTemplate>
                                                 <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="linkBttnExcel" runat="server" onclick="linkBttnEliminar_Click"   OnClientClick="return confirm('¿Desea eliminar esta etapa?');">Eliminar</asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right" class="style24" colspan="4">
                                                    <asp:LinkButton ID="linBttnRegresar" runat="server"
                                                        OnClick="linkBttnRegresar_Click"
                                                        CssClass="btn2">&lt;REGRESAR</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td class="cuadro_botones">

                                                    <asp:ImageButton ID="ImageButton4" runat="server" Height="53px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png"
                                                        Width="49px" OnClick="imgBttnPdf" />
                                                </td>

                                            </tr>
                                        </table>

                                    </asp:View>
                                    <asp:View ID="View3" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 15%">&nbsp;</td>
                                                <td style="width: 85%" colspan="5">&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="No. Inventario:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:label ID="lblInventario_E" runat="server" Font-Bold="True" Font-Size="Medium"></asp:label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Descripción:"></asp:Label>
                                                </td>
                                                <td colspan="5">
                                                    <asp:TextBox ID="txtDescripcion_E" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Especie:"></asp:Label>
                                                </td>
                                                <td colspan="5">

                                                    <asp:TextBox ID="txtEspecie_E" runat="server" Enabled="False" Width="99%"></asp:TextBox>

                                                </td>

                                            </tr>

                                        </table>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label12" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtFechaNac_E" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" align="right" >
                                                    <asp:Label ID="Label13" runat="server" Text="Edad [Meses]:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtEdad_E" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                                                </td>
                                                <td style="width: 15%" align="right" >
                                                    <asp:Label ID="Label14" runat="server" Text="Años:" Style="text-align: right"></asp:Label>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:TextBox ID="txtAnio_E" runat="server" Enabled="False" Width="95%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                                                                

                                        <table style="width: 100%;">

                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label15" runat="server" Text="Sexo:"></asp:Label>
                                                </td>
                                                <td style="width: 85%" colspan="5">
                                                    <asp:TextBox ID="txtSexo_E" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                
                                                <td colspan="6">
                                                       <fieldset>
                                            <legend> </legend>
                                        </fieldset>
                                                </td>

                                            </tr>

                                        </table>
                                     

                                        <table style="width: 100%;">
                                            
                                            <tr>
                                             <td style="width: 15%">
                                                 <asp:Label ID="Label16" runat="server" Text="Especie:"></asp:Label>
                                                </td>
                                                <td style="width: 30%">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="DDLEspecie_C" runat="server" Width="250px" OnSelectedIndexChanged="DDLEspecie_C_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                </td>
                                                <td style="width: 25%"></td>
                                             <td style="width: 30%"></td>
                                          </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Etapa:"></asp:Label></td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="DDLEtapa_C" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DDLEtapa_C_SelectedIndexChanged"></asp:DropDownList></td>
                                                            </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <td align="right" >
                                                    <asp:Label ID="Label17" runat="server" Text="Fecha de Inicio de la Etapa:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaEtapa_C" runat="server" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaEtapa_C" DaysModeTitleFormat="dd MMMM, yyyy"
                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioEtapa" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                        <asp:Image ID="imgCalendarioEtapa" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="pnlGestante" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label18" runat="server" Text="Peso Actual [Kg]:"></asp:Label>
                                                </td>
                                                <td style="width: 30%">
                                                    <asp:TextBox ID="txtPeso" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="width: 25%" align="right" >
                                                    <asp:Label ID="Label19" runat="server" Text="Costo Aproximado [Pesos]:"></asp:Label>
                                                </td>
                                                <td style="width: 30%">
                                                    <asp:TextBox ID="txtCosto" runat="server" Width="95px"></asp:TextBox>
                                                </td>
                                                        </tr>
                                                        <tr>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text="Edad en Meses:"></asp:Label>
                                                 </td>
                                                <td>
                                                    <asp:TextBox ID="txtEdadMeses" runat="server" Width="150px"></asp:TextBox>
                                                 </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                             
                                                        </table>
                                                        </asp:Panel>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="pnlHembraG" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr><td colspan="4">
                                                            <asp:Label ID="Label34" runat="server" Text="Hembra Gestante" Font-Bold="True"></asp:Label></td></tr>
                                                        <tr>
                                                <td style="width: 20%">
                                                    <asp:Label ID="Label22" runat="server" Text="Fecha Posible Parto:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtFechaParto" runat="server" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaParto" DaysModeTitleFormat="dd MMMM, yyyy"
                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioParto" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                        <asp:Image ID="imgCalendarioParto" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                </td>
                                                <td style="width: 20%">
                                                    
                                                </td>
                                                <td style="width: 40%">
                                                    
                                                </td>
                                                        </tr>
                                                        <tr>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="Semental de Empadre:"></asp:Label>
                                                 </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="DDLEmpadre" runat="server" Width="350px">
                                                    </asp:DropDownList>
                                                 </td>
                                                
                                            </tr>
                                                        <tr>
                                                           <%-- <td>
                                                                <asp:Label ID="Label23" runat="server" Text="Método de Empadre:"></asp:Label></td>
                                                            <td align="right">
                                                                <asp:RadioButton ID="rdbtnTradicional" runat="server" Text="Tradicional" />
                                                            </td>
                                                            <td align="center">
                                                                <asp:RadioButton ID="rdbtnArtificial" runat="server" Text="Inseminación Artificial" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButton ID="rdbtnEmbriones" runat="server" Text="Transferencia de Embriones" />
                                                            </td>--%>
                                                             <td>
                                                                <asp:Label ID="Label23" runat="server" Text="Método de Empadre:"></asp:Label></td>
                                                            <td colspan="3">
                                                            
                                                                <asp:RadioButtonList ID="rdbtnListMetodo" runat="server" RepeatDirection="Horizontal" Width="481px">
                                                                    <asp:ListItem Value="0">Tradicional</asp:ListItem>
                                                                    <asp:ListItem Value="1">Inseminación Artificial</asp:ListItem>
                                                                    <asp:ListItem Value="2">Transferencia de Embriones</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            
                                                               </td>
                                                        </tr>
                                             
                                                        </table>
                                                        </asp:Panel>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="pnlHembraL" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr><td colspan="4">
                                                            <asp:Label ID="Label35" runat="server" Text="Hembra en Lactancia" Font-Bold="True"></asp:Label></td></tr>
                                                        <tr>
                                                <td style="width: 25%">
                                                    <asp:Label ID="Label26" runat="server" Text="Número de Crías [MACHO]:"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:TextBox ID="txtCriasM" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                                 <td style="width: 25%" >
                                                     </td>
                                                <td style="width: 30%">
                                                   
                                                </td>
                                                        </tr>
                                                        <tr>
                                                <td class="auto-style1">
                                                    <asp:Label ID="Label28" runat="server" Text="Número de Crías [HEMBRA]:"></asp:Label>
                                                 </td>
                                                <td class="auto-style1">
                                                    <asp:TextBox ID="txtCriasH" runat="server" Width="150px"></asp:TextBox>
                                                 </td>
                                                            <td align="right" class="auto-style1">
                                                    <asp:Label ID="Label27" runat="server" Text="Total de Crías :"></asp:Label>
                                                </td>
                                                            <td class="auto-style1"> 
                                                                <asp:TextBox ID="txtCriasT" runat="server" Width="95px" Enabled="False"></asp:TextBox>
                                                            </td>
                                              
                                            </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                             
                                                        </table>
                                                        </asp:Panel>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="pnlCriaL" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr><td colspan="4">
                                                            <asp:Label ID="Label36" runat="server" Text="Cría en Lactancia" Font-Bold="True"></asp:Label></td></tr>
                                                        
                                                        <tr>
                                                <td style="width: 25%">
                                                    <asp:Label ID="Label25" runat="server" Text="No. de Inventario MADRE:"></asp:Label>
                                                 </td>
                                                <td style="width: 75%" colspan="3">
                                                    <asp:DropDownList ID="DDLMadre" runat="server" Width="350px">
                                                    </asp:DropDownList>
                                                 </td>

                                            </tr>
                                                        <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="Label32" runat="server" Text="No. de Inventario PADRE:"></asp:Label>
                                                 </td>
                                                <td >
                                                    <asp:DropDownList ID="DDLPadre" runat="server" Width="350px">
                                                    </asp:DropDownList>
                                                 </td>
                                                
                                            </tr>
                                             
                                                        </table>
                                                        </asp:Panel>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text="Observaciones:"></asp:Label>
                                                 </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtObservaciones" runat="server" Width="100%"></asp:TextBox>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:HiddenField ID="hdnFieldEditar" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right" class="style24" colspan="4">
                                                    <asp:LinkButton ID="lnkbtnCancelar" runat="server"
                                                        OnClick="linkBttnCancelar_Click"
                                                        CssClass="btn2">CANCELAR</asp:LinkButton>

                                                     <asp:LinkButton ID="lnkbtnGuardar" runat="server"
                                                        OnClick="linkBttnGuardar_Click"
                                                        CssClass="btn2" CausesValidation="False">GUARDAR</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>

                                    </asp:View>
                                     <asp:View ID="View4" runat="server">
                                         <table style="width: 100%;">
                                                            <tr>
                                                                <td align="left" width="20%"></td>
                                                                <td width="30%"></td>
                                                                <td width="15%"></td>
                                                                <td width="35%"></td>
                                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" Text="No. Inventario:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:label ID="lblSem_Inventario" runat="server" Font-Bold="True" Font-Size="Medium"></asp:label>
                                                </td>
                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style8">
                                                                    <asp:Label ID="Label61" runat="server" Text="Raza:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSem_Raza" runat="server" Width="250px"></asp:TextBox>
                                                                </td>
                                                                <td align="right" class="style8">
                                                                    <asp:Label ID="Label62" runat="server" Text="Color:"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSem_Color" runat="server" Width="250px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style8">
                                                                    <asp:Label ID="Label63" runat="server" Text="No. de Arete:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSem_Arete" runat="server" Width="250px"></asp:TextBox>
                                                                </td>
                                                              <%--  <td align="right" class="style8">
                                                                    <asp:Label ID="Label64" runat="server" Text="Peso:"></asp:Label>
                                                                </td>
                                                                <td>

                                                                    <asp:TextBox ID="txtSem_Peso" runat="server" Width="250px"></asp:TextBox>

                                                                </td>--%>
                                                                <td align="right" class="style8">
                                                                    <asp:Label ID="Label29" runat="server" Text="Sexo:"></asp:Label>
                                                                </td>
                                                                <td>

                                                                    <asp:DropDownList ID="DDLSem_Sexo" runat="server" Width="150px">
                                                                        <asp:ListItem Value="HEMBRA">HEMBRA</asp:ListItem>
                                                                        <asp:ListItem Value="MACHO">MACHO</asp:ListItem>
                                                                         <asp:ListItem Value="NO">NO CAPTURADO</asp:ListItem>
                                                                    </asp:DropDownList>

                                                                </td>

                                                            </tr>
                                                           <%-- <tr>
                                                                <td align="left" class="style8">
                                                                    <asp:Label ID="Label65" runat="server" Text="Edad:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSem_Edad" runat="server" Width="250px"></asp:TextBox>
                                                                </td>
                                                               
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left" class="style8">
                                                                    <asp:Label ID="Label67" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSem_Nac" runat="server" Width="100px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSem_Nac" DaysModeTitleFormat="dd MMMM, yyyy"
                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioNacimiento" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                        <asp:Image ID="imgCalendarioNacimiento" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                                </td>
                                                                <td align="left" class="style8">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblProcedencia" runat="server" Text="Procedencia:"></asp:Label>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtSem_Procedencia" runat="server" Width="400px"></asp:TextBox>
                                                                </td>
                                                                </tr>
                                             <tr>
                                                                <td>
                                                                    <asp:Label ID="lblCentroTrabajo" runat="server" Text="Centro de Trabajo:"></asp:Label>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="DDLSem_CentroTrabajo" runat="server" Width="420px"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">&nbsp;&nbsp;</td>
                                                            </tr>
                                             <tr valign="top">
                                                <td align="right" class="style24" colspan="4">
                                                    <asp:LinkButton ID="lnkBtnSalir" runat="server"
                                                        OnClick="linkBttnSalir_Click"
                                                        CssClass="btn2">CANCELAR</asp:LinkButton>

                                                     <asp:LinkButton ID="lnkBtnActualizar" runat="server"
                                                        OnClick="linkBttnActualizar_Click"
                                                        CssClass="btn2" CausesValidation="False">ACTUALIZAR</asp:LinkButton>
                                                </td>
                                            </tr>
                                                        </table>
                                         </asp:View>
                                    <asp:View ID="View5" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 17%">&nbsp;</td>
                                                <td style="width: 83%" colspan="5">&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Text="No. Inventario:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblProd_Inventario" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>
                                                    <asp:Label ID="Label37" runat="server" Text="Descripción:"></asp:Label>
                                                </td>
                                                <td colspan="5">
                                                    <asp:TextBox ID="txtProd_Descripcion" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                                                </td>

                                            </tr>--%>
                                            <tr>
                                                <td colspan="2">

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Size="Medium" Text="P r o d u c c i ó n"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate> 
                                                            <asp:ImageButton ID="btnProduccion_Agregar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btnProduccion_Agregar_Click"  />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%;">
                                            
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvProduccion" runat="server" EmptyDataText="No hay registros para mostrar" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderStyle="None" BorderWidth="1px" GridLines="Vertical" OnPageIndexChanging="grvProduccion_PageIndexChanging"
                                                        Width="100%" CssClass="mGrid" PageSize="20" OnRowDeleting="grvProduccion_RowDeleting">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                                                              <asp:BoundField DataField="Sem_FechaNac_Str" HeaderText="FECHA">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Peso" HeaderText="PESO [Kg]" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sem_Vellon" HeaderText="VELLÓN" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="Sem_Calidad" HeaderText="CALIDAD" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="Sem_FechaTrasquila_Str" HeaderText="TRASQUILA" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <%--<asp:CommandField SelectText="VER" ShowSelectButton="True" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:CommandField>--%>
                                                            <asp:CommandField DeleteText="ELIMINAR" ShowDeleteButton="True">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:CommandField>

                                                        </Columns>
                                                        <FooterStyle CssClass="enc" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right" class="style24" colspan="4">
                                                    <asp:LinkButton ID="lnkBtnProd_Regresar" runat="server"
                                                        OnClick="linkBttnRegresar_Click"
                                                        CssClass="btn2">&lt;REGRESAR</asp:LinkButton>
                                                </td>
                                            </tr>
                                            
                                        </table>

                                    </asp:View>
                                    <asp:View ID="View6" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 15%">&nbsp;</td>
                                                <td style="width: 85%" colspan="5">&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label33" runat="server" Text="No. Inventario:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:label ID="lblProduccionInventario" runat="server" Font-Bold="True" Font-Size="Medium"></asp:label>
                                                </td>
                                            </tr>
                                            

                                        </table>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 12%">
                                                    <asp:Label ID="Label40" runat="server" Text="Fecha:"></asp:Label>
                                                </td>
                                                <td style="width: 18%">
                                                    <asp:TextBox ID="txtProduccionFecha" runat="server" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtProduccionFecha" DaysModeTitleFormat="dd MMMM, yyyy"
                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioProduccion" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                        <asp:Image ID="imgCalendarioProduccion" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                
                                                </td>
                                                <td style="width: 13%" align="right" >
                                                    <asp:Label ID="Label41" runat="server" Text="Peso [Kg]:"></asp:Label>
                                                </td>
                                                <td style="width: 17%">
                                                    <asp:TextBox ID="txtProduccionPeso" runat="server" Width="95px"></asp:TextBox>
                                                </td>
                                                <td style="width: 13%" align="right" >
                                                    <asp:Label ID="Label42" runat="server" Text="Edad:" Style="text-align: right"></asp:Label>
                                                </td>
                                                <td style="width: 17%">
                                                    <asp:TextBox ID="txtProduccionEdad" runat="server" Width="95px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                             <td >
                                                 <asp:Label ID="Label45" runat="server" Text="Especie:"></asp:Label>
                                                </td>
                                                <td colspan="5">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="DDLEspecie_Produccion" runat="server" Width="200px" OnSelectedIndexChanged="DDLEspecie_C_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                </td>
                                              
                                          </tr>--%>
                                        </table>

                                        <table style="width: 100%;">
                                            
                                            
                                            
                                            
                                            
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Panel ID="PanelOvinos" runat="server">
                                                    <table style="width: 100%;">
                                                        

                                                        <tr>
                                                               <td style="width: 12%">
                                                    
                                                                   <asp:Label ID="lblVellon" runat="server" Text="Peso [Vellón]:"></asp:Label>
                                                    
                                                </td>
                                                <td style="width: 18%">
                                                    <asp:TextBox ID="txtPesoVellon" runat="server" Width="95px"></asp:TextBox>
                                                </td>
                                                             <td style="width: 13%" align="right">
                                                    
                                                                 <asp:Label ID="Label69" runat="server" Text="Calidad [Vellón]"></asp:Label>
                                                    
                                                </td>
                                                <td style="width: 17%">
                                                    <asp:DropDownList ID="DDLCalidadVellon" runat="server" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 13%" align="right">
                                                    <asp:Label ID="Label52" runat="server" Text="Fecha Trasquila:"></asp:Label>
                                                </td>
                                                <td style="width: 17%">
                                                    <asp:TextBox ID="txtFechaTrasquila" runat="server" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtFechaTrasquila" DaysModeTitleFormat="dd MMMM, yyyy"
                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendarioTrasquila" TodaysDateFormat="dd MMMM, yyyy"></ajaxToolkit:CalendarExtender>
                                        <asp:Image ID="imgCalendarioTrasquila" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" Style="margin-left: 0px" />
                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label38" runat="server" Text="Época:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DDLEpoca" runat="server" Width="150px"></asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="Label39" runat="server" Text="Grupo:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DDLGrupo" runat="server" Width="150px"></asp:DropDownList>
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                             
                                                        </table>
                                                        </asp:Panel>
                                            </tr>

                                            <tr>
                                                <td colspan="4">&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right" class="style24" colspan="4">
                                                    <asp:LinkButton ID="lnkBtnCancelarProduccion" runat="server"
                                                        OnClick="linkBttnCancelarProduccion_Click"
                                                        CssClass="btn2">CANCELAR</asp:LinkButton>

                                                     <asp:LinkButton ID="lnkBtnGuardarProduccion" runat="server"
                                                        OnClick="linkBttnGuardarProduccion_Click"
                                                        CssClass="btn2" CausesValidation="False">GUARDAR</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>

                                    </asp:View>
                                </asp:MultiView>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
