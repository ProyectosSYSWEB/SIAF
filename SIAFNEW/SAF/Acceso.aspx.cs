using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CapaEntidad;
using CapaNegocio;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Ejemplo
{
    public partial class Acceso : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Sesion ObjSesion = new Sesion();
        CN_Comun CNSesison = new CN_Comun();
        CN_Comun CNComun = new CN_Comun();
        List<Comun> Listsistema = new List<Comun>();

        protected string Token = null;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    Token = Convert.ToString(Request.QueryString["Token"]);

                    if (!IsPostBack)
                    {
                        if (Token != null)
                        {

                            try
                            {
                                Verificador = "-1";

                                Usuario = new Usuario();
                                Usuario.Token = Token;
                                CNUsuario.ValidarToken(ref Usuario, ref Verificador);

                                if (Verificador == "0")
                                {
                                    txtUsario.Text = Usuario.CUsuario;
                                    txtPassword.Text = Usuario.Password;

                                    btnLogin_Click(null, null);
                                }
                                else lblError.Text = "El Token no es válido";
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message + ".-ValidarToken");
                            }

                        }
                        else
                        {

                            if ((Request.QueryString["Usuario"] != null) && (Request.QueryString["Ejercicio"] != null))
                            {
                                txtUsario.Text = Request.QueryString["Usuario"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarUsuario();
                if (Usuario.Nombre != "")
                {
                    IniciarSesion();
                    string siteMap = "ArchivosMenu/Web" + SesionUsu.Usu_Nombre + ".sitemap";
                    string fullPath = Path.Combine(Server.MapPath("~"), siteMap);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }

                }
                else
                {

                    lblError.Text = Verificador;
                    txtUsario.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUsario.Focus();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error de Usuario o Contraseña "+ex.Message;
            }
        }
        public void IniciarSesion()
        {
            try
            {

                SesionUsu.CUsuario = Usuario.CUsuario;
                SesionUsu.Usu_Nombre = Usuario.CUsuario;
                SesionUsu.Usu_Ejercicio = ddlEjercicio.SelectedValue;
                SesionUsu.Usu_TipoUsu = Usuario.TipoUsu;
                Session["Usuario"] = SesionUsu;
                Session.Timeout = 120;
                GUARDAR_SESION();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GUARDAR_SESION()
        {
            try
            {

                string strHostName = string.Empty;
                // Getting Ip address of local machine…
                // First get the host name of local machine.
                strHostName = Dns.GetHostName();
                // Then using host name, get the IP address list..
                IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
                lblError.Text = string.Empty;
                ObjSesion = new Sesion();
                ObjSesion.ip = hostIPs[1].ToString();
                ObjSesion.mac_address = hostIPs[0].ToString();
                ObjSesion.Usu_Nombre = Usuario.CUsuario;
                ObjSesion.id_sistema = "15361";
                CNSesison.insertar_datos_sesion(ref ObjSesion, ref Verificador);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        public void ValidarUsuario()
        {
            try
            {
                Usuario.CUsuario = txtUsario.Text.ToUpper();
                Usuario.Password = txtPassword.Text.ToUpper();
                CNUsuario.ValidarUsuario(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message + ".-ValidarUsuario";
            }
        }





        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}