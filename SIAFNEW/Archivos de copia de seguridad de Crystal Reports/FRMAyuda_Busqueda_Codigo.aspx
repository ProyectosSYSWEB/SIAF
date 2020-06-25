<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FRMAyuda_Busqueda_Codigo.aspx.cs" Inherits="SAF.Adquisiciones.Form.FRMAyuda_Busqueda_Codigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    &nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="mensaje"> 
       <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
     </div>
    <table class="tabla_contenido">
            <tr>
                <td class="td">
                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia" Width="130px"></asp:Label>
                </td>
                <td class="td">
                    <asp:UpdatePanel ID="UpdatePanelDependencia" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="true" CssClass="txtCls"
                                Width="550px" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td" colspan="2">
                    <asp:UpdateProgress ID="UpdateProgressDep" runat="server" AssociatedUpdatePanelID="UpdatePanelDependencia">
                        <ProgressTemplate>
                            <asp:Image ID="Image1" runat="server" AlternateText="Cargando" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td class="td">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="td">
                    <asp:Label ID="lblPrograma" runat="server" Text="Función-Programa"></asp:Label>
                </td>
                <td class="td">
                    <asp:UpdatePanel ID="UpdatePanelPrograma" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="true" CssClass="txtCls"
                                Width="550px" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td" colspan="2">
                    <asp:UpdateProgress ID="UpdateProgressPro" runat="server" AssociatedUpdatePanelID="UpdatePanelPrograma">
                        <ProgressTemplate>
                            <asp:Image ID="Image2" runat="server" AlternateText="Cargando" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="td">
                    <asp:Label ID="lblsubprograma" runat="server" Text="SubPrograma"></asp:Label>
                </td>
                <td class="td">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLSubPrograma" runat="server" AutoPostBack="true" CssClass="txtCls"
                                 Width="550px" OnSelectedIndexChanged="DDLSubPrograma_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td" colspan="2">
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <asp:Image ID="Imagex" runat="server" AlternateText="Cargando" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="td">
                    <asp:Label ID="lblProyecto" runat="server" Text="Proyecto" Width="130px"></asp:Label>
                </td>
                <td class="td">
                    <asp:UpdatePanel ID="UpdatePanelProyecto" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLProyecto" runat="server" AutoPostBack="true" CssClass="txtCls"
                                Width="550px" OnSelectedIndexChanged="DDLProyecto_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td" colspan="2">
                    <asp:UpdateProgress ID="UpdateProgressProy" runat="server" AssociatedUpdatePanelID="UpdatePanelProyecto">
                        <ProgressTemplate>
                            <asp:Image ID="Image3" runat="server" AlternateText="Cargando" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td class="td">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="td">
                    <asp:Label ID="lblPartida" runat="server" Text="Partida" Width="130px"></asp:Label>
                </td>
                <td class="td">
                    <asp:UpdatePanel ID="UpdatePanelPartida" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLPartida" runat="server" AutoPostBack="true" CssClass="txtCls"
                                 Width="550px" OnSelectedIndexChanged="DDLPartida_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td" colspan="2">
                    <asp:UpdateProgress ID="UpdateProgressPar" runat="server" AssociatedUpdatePanelID="UpdatePanelPartida">
                        <ProgressTemplate>
                            <asp:Image ID="Image4" runat="server" AlternateText="Cargando" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td class="td">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="td">
                    <asp:Label ID="Label1" runat="server" Text="Fuente de Financiamiento" Width="130px"></asp:Label>
                </td>
                <td class="td">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLFuente" runat="server" AutoPostBack="true" CssClass="txtCls"
                            Width="550px" OnSelectedIndexChanged="DDLFuente_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td" colspan="2">
                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                        <ProgressTemplate>
                            <asp:Image ID="Imagez" runat="server" AlternateText="Cargando" 
                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" Height="50px" Width="50px" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td class="td">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="td">
                </td>
                <td class="td">
                    <asp:Label ID="lblMensaje" runat="server" Text="Si el Código Programático que busca, no aparece, favor de comunicarse a la Dirección de Programación y Presupuesto de la Unach" Font-Bold="True" ForeColor="#C00000"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanelGuardadSol" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnConsultar" runat="server" 
                                Text="Consultar" onclick="btnConsultar_Click" CssClass="btn"  />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td">
                </td>
                <td class="td">
                    &nbsp;</td>
            </tr>
           
            <tr align="center">
                
                <td colspan="5" align="center">
                <center>
                    <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridCodigo" Width="720px" runat="server" AllowPaging="True"
                                EmptyDataText="NO HAY DATOS PARA MOSTRAR" GridLines="Vertical"
                                OnPageIndexChanging="GridCodigo_PageIndexChanging" OnRowDataBound="GridCodigo_RowDataBound" AutoGenerateColumns="False" CssClass="mGrid"  >
                               
                                <Columns>
                                    
                                    <asp:BoundField DataField="Dependencia" ItemStyle-HorizontalAlign="Center" 
                                        HeaderText="Dependencia" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="funcion_programa" ItemStyle-HorizontalAlign="Center" 
                                        HeaderText="Funcion Programa" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="subprograma" ItemStyle-HorizontalAlign="Center" 
                                        HeaderText="Sub Programa" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="proyecto" ItemStyle-HorizontalAlign="Center" 
                                        HeaderText="Proyecto" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="partida" ItemStyle-HorizontalAlign="Center" 
                                        HeaderText="Partida" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fuente" ItemStyle-HorizontalAlign="Center" 
                                        HeaderText="Fuente" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Codigo_programativo" 
                                        HeaderText="C&#243;digo Program&#225;tico" />
                                    <asp:BoundField DataField="Autorizacion" ItemStyle-HorizontalAlign="Right" 
                                        HeaderText="Autorizado" >
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Disponible" ItemStyle-HorizontalAlign="Right" 
                                        HeaderText="Disponible" >
                                   
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                   
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
                </td>
            </tr>
           
           
        </table>

    </ContentTemplate>
    </asp:UpdatePanel>
   
    <br />
   
</asp:Content>
