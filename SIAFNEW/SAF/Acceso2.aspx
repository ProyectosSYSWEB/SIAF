<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso2.aspx.cs" Inherits="Ejemplo.Acceso2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="icon" />
    <link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="https://sysweb.unach.mx/resources/css/Style2018.css">
    <script>


    </script>
    <title>Sistema | Sysweb</title>


</head>
<body>
    <form id="form1" runat="server">
        <header>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                </Scripts>
            </asp:ScriptManager>

            <div class="encabezado">


                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%">
                                <a href="https://sysweb.unach.mx/">
                                    <asp:Image ID="Image1" ImageUrl="https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png" runat="server" /></a>
                         
                        </td>
                        <td style="width: 50%" class="centro">
                            <asp:Label ID="Label2" runat="server" Text="Sistema Integral de Administración y Finanzas" CssClass="titulo_sistema"></asp:Label><br />
                            <asp:Label ID="Label3" runat="server" Text="SIAF" CssClass="subtitulo_sistema"></asp:Label>
                        </td>
                        <td style="width: 25%">
                            <a href="https://unach.mx/">
                                <asp:Image ID="Image2" ImageUrl="https://sysweb.unach.mx/resources/imagenes/unach.jpg" runat="server" Height="80px" /></a>

                        </td>
                    </tr>
                </table>
            </div>



            <div class="p_menu">
                <div class="c_menu">
                </div>
            </div>

        </header>





        <div class="contenido">





            <div class="cuadro_login centro">

                <asp:Label ID="Label1" runat="server" Text="Iniciar Sesión" CssClass="gris_20px"> </asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtUsario" placeholder="Usuario" runat="server" Width="95%" CssClass="textbox2"></asp:TextBox><br />
                <br />
                <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Contraseña" runat="server" Width="95%" CssClass="textbox2"></asp:TextBox><br />
                <br />
                <asp:DropDownList ID="ddlEjercicio" runat="server" Width="100%">
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn" Width="100%" OnClick="btnLogin_Click" />

                <br />
                <br />

                <div class="gris_12px">
                    <a href="https://sysweb.unach.mx/administrator">Mi cuenta Sysweb</a><br />
                    <br />

                    ¿No tiene una cuenta? <a href="frmNewusu.aspx?1133187993=8">Cree una.</a>
                    <br />
                    <br />

                    <a href="https://sysweb.unach.mx/administrator/frmresetpassword.aspx">He olvidado mi contraseña</a><br />
                    <br />
                    <a href="https://sysweb.unach.mx/resources/help.aspx">¿Necesitas ayuda?</a>
                    <br />
                    <br />

                    <div class="mensaje">
                        <div class="mensaje">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>

        </div>



        <asp:HiddenField ID="HiddenField1" runat="server" />

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy">
        </ajaxToolkit:ModalPopupExtender>

        <%-- Inicia PopUP --%>


        <asp:Panel ID="Panel3" runat="server" CssClass="TituloModalPopupMsg" Width="300px">

            <asp:ImageButton ID="imgCerrar" ImageUrl="https://sysweb.unach.mx/resources/imagenes/cerrar.png" runat="server" Width="10px" CssClass="cerrar_pop" />

            <div class="titulo_pop">
                AVISO
            </div>
            <center>
                <br />
         <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png"/>
             </center>

            <div class="info_pop gris_12px">
                Estimado usuario de Sysweb:<br />
                <br />
                Por seguridad, todos los usuarios deberán de completar cierta información de su cuenta Sysweb, ya que en determinado momento solo los usuarios actualizados podrán acceder a nuestros sistemas. Para modificar los datos de su cuenta, de click en el botón <a>'Actualizar mis datos'</a>.
             <br />
                Si ya actualizó los datos de su usuario solo de click en el boton <a>'Continuar'</a>
                <br />
                <br />
                Esta medida es meramente preventiva. Lamentamos el inconveniente.
             <br />
                <br />

                <label class="f11px">
                    Para obtener más información acerca de por qué adoptamos esta medida de precaución, no dudes en comunicarte con nosotros:<br />
                    <br />
                    Teléfono:<a>(961) 617 80 00 ext.: 1302, 5519, 5520 y 5087</a>
                </label>
                <br />
                <br />
                Gracias.<br />
                El equipo de Sysweb
              <br />
                <br />
            </div>

            <div class="esp_botones">
                <asp:Button ID="btnAceptar" runat="server" Text="Actualizar mis datos" CssClass="btn" PostBackUrl="https://www.sysweb.unach.mx/administrator/" OnClick="btnAceptar_Click" />
                &nbsp;  
                 <asp:Button ID="btnCancelar" runat="server" Text="Continuar" CssClass="btn2" />
            </div>


        </asp:Panel>

        <footer>
            <img src="https://sysweb.unach.mx/resources/imagenes/imgfooter2018.png" style="min-width: 900px; height: auto;" />
        </footer>

    </form>
</body>
</html>
