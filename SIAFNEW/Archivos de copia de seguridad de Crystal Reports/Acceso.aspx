<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="SAF.Contabilidad.Acceso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="https://sysweb.unach.mx/resources/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="https://sysweb.unach.mx/resources/bootstrap/css/mdb.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://sysweb.unach.mx/resources/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous" />
    <script>


</script>
    <title>Sistema | Sysweb</title>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
            </Scripts>
        </asp:ScriptManager>
        <div class="page-header" style="background-color: #18386b">
            <div class="row">
                <div class="col-md-4">
                    <img id="imgSYSWEB" src="https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png" class="img-fluid d-none d-sm-none d-md-block" alt="Responsive image" style="cursor: pointer" />
                </div>
                <div class="col-md-4">
                    <%--                    <h1><small style="color: #FFFFFF">Recaudación de Pagos </small></h1>--%>
                    <h5 class="logo text-center" style="color: #FFFFFF">Sistema Integral de Administración y Finanzas</h5>
                    <h1 class="logo text-center" style="color: #FFFFFF">SIAF</h1>
                </div>
                <div class="col-md-4">
                    <img src="https://sysweb.unach.mx/resources/imagenes/unach.jpg" class="img-fluid d-none d-sm-none d-md-block" alt="Responsive image" style="cursor: pointer" />
                </div>
            </div>
        </div>
        <div class="bg-light">
            <article class="card-body mx-auto" style="max-width: 450px;">
                <div class="card">
                    <div class="card-header">
                        <h3>Iniciar Sesión</h3>
                        <div class="d-flex justify-content-end social_icon">
                            <span>
                                <button id="imgFacebook" type="button" class="btn btn-primary btn-lg">
                                    <i class="fab fa-facebook-square"></i>
                                </button>
                                &nbsp;
                                        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#exampleModal">
                                            <i class="fas fa-phone-square"></i>
                                        </button>
                            </span>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group input-group">
                            <div id="listUser" class="input-group-prepend">
                                <span class="input-group-text"><i class="fa fa-at"></i></span>
                            </div>
                            <asp:TextBox ID="txtUsario" placeholder="Correo UNACH" runat="server" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Tooltip on top"></asp:TextBox><br />
                        </div>
                        <div class="form-group input-group">
                            <div id="divPassword" class="input-group-prepend">
                                <span class="input-group-text"><i class="fa fa-lock"></i></span>
                            </div>
                            <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Contraseña" runat="server" CssClass="form-control"></asp:TextBox><br />
                        </div>
                        <div class="form-group input-group">
                            <div id="divEjercicio" class="input-group-prepend">
                                <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                            </div>
                            <asp:DropDownList ID="ddlEjercicio" runat="server" CssClass="form-control">
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updProLogin" runat="server"
                                    AssociatedUpdatePanelID="updPnlLogin">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image2q" runat="server"
                                            AlternateText="Espere un momento, por favor.." Height="30px"
                                            ImageUrl="~/images/ajax_loader_gray_512.gif"
                                            ToolTip="Espere un momento, por favor.." Width="30px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                                <asp:UpdatePanel ID="updPnlLogin" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-mdb-color" OnClick="btnLogin_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="alert alert-danger">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblError" runat="server" Font-Bold="True"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div id="divMsjUsuDep" class="alert alert-warning" role="alert">
                                    <strong>El acceso al sistema es con la cta. y la contraseña del correo unach,</strong> &nbsp; si no actualizaste tu información dar click en el siguiente enlace.
                                    <button id="bttnModalActualizar" type="button" class="btn btn-link">Actualizar datos</button>
                                    <br />
                                    <a href="https://ldapauthmaster.unach.mx/pssform_resetaccount.php" target="_blank">¿Olvidó  la contraseña del correo institucional?</a>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </article>
        </div>
        <div class="piePagina" style="width: 100%">
            <footer class="page-footer font-small pt-4" style="background-color: #d2af47; color: #7b6420">
                <div class="container-fluid text-center text-md-left">
                    <div class="row">
                        <hr class="clearfix w-100 d-md-none pb-3">
                        <div class="col-md-6 mb-md-0 mb-3">
                            <h6 class="text-uppercase mb-4 font-weight-bold">Contacto</h6>
                            <p>
                                <i class="fas fa-home mr-3"></i>2da. Poniente Sur No. 108, Edificio Maciel, 3er. Piso Tuxtla Gutiérrez, Chiapas.
                            </p>
                            <p><i class="fas fa-envelope mr-3"></i>depfin@unach.mx, sysweb@unach.mx</p>
                            <p><i class="fas fa-phone mr-3"></i>(961) 61 7 80 00, extensiones: 5108 Y 5501</p>
                        </div>
                        <div class="col-md-6 mb-md-0 mb-3">
                            <div class="text-xl-center">
                            </div>

                        </div>
                    </div>
                </div>
                <div class="footer-copyright text-center py-3">Universidad Autónoma de Chiapas</div>
            </footer>
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
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Teléfonos</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-info" role="alert">
                            Para cualquier duda ó aclaración te puedes comunicar con nosotros al siguiente teléfono:
                        </div>
                        (961) 61 7 80 00
          <br />
                        <h4>CONTRALORIA INTERNA: ext. 5089</h4>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal Actualiza Datos-->
        <div class="modal fade" id="modalActualizaDatos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Usuario</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-info" role="alert">
                            Usuario y password anterior.
                        </div>
                        <div class="container">
                            <div class="row">
                                <div class="col-md-3">
                                    Usuario:
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtUsuarioAnt" runat="server" CssClass="form-control" TabIndex="100"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                            <asp:UpdateProgress ID="updPrgActualizarDatos" runat="server" AssociatedUpdatePanelID="updPnlActualizarDatos">
                                <ProgressTemplate>
                                    <asp:Image ID="Image7" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        Width="50px" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="updPnlActualizarDatos" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="bttnActualizarDatos" class="btn btn-info" runat="server" Text="Actualizar" OnClick="bttnActualizarDatos_Click" TabIndex="102" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <button type="button" class="btn btn-mdb-color" data-dismiss="modal" tabindex="103">Cerrar</button>
                            <br />


                        </div>
                        <div class="content">
                            <div class="row">
                                <div class="col">
                                    <div id="divErrorUsuario" class="alert-danger">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblErrorUsuario" runat="server" Text=""></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <script>
            //$(document).ready(function () {
            //    var hasToolTip = false;
            //    $('#txtUsario').on({
            //        "click": function () {
            //            hasToolTip = true;
            //            $(this).tooltip({ items: "#txtUsario", content: "Displaying on click" });
            //            $(this).tooltip("open");
            //        },
            //        "mouseout": function () {
            //            if (hasToolTip) {
            //                $(this).tooltip("disable");
            //                hasToolTip = false;
            //            }
            //        }
            //    });
            //});

            $("#bttnModalActualizar").click(function () {
                window.location = "https://sysweb.unach.mx/actualiza_correo/frmactualiza_datos.aspx?sistema=15830";


            });



        </script>
    </form>
</body>
</html>
