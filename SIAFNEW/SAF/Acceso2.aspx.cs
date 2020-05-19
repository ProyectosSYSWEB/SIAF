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
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Ejemplo
{
    public partial class Acceso2 : System.Web.UI.Page
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
            
                if (!IsPostBack)
                {

                    Token = Convert.ToString(Request.QueryString["Token"]);

                    //if (!IsPostBack)
                    //{
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
                    //}
                }
           
        }     
    protected void btnLogin2_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                bool Valido=ValidarUsuario(ref Verificador);
                if (Valido==true)
                {
                    Usuario.CUsuario = txtUsario.Text.ToUpper();
                    CNUsuario.Verificar_Correo_UNACH(ref Usuario, ref Verificador);
                    if (Verificador == "0")
                    {
                        //Verificador = string.Empty;
                        if (Usuario.Status == "S")
                        {

                            Response.Redirect("Default.aspx", false);
                        }
                        else
                        {
                            Guid Token = Guid.NewGuid();
                            Verificador = String.Empty;
                            Usuario.Token = Convert.ToString(Token);
                            Usuario.CUsuario = SesionUsu.Usu_Nombre;
                            CNUsuario.Inserta_Token(ref Usuario, ref Verificador);
                            Response.Redirect("https://sysweb.unach.mx/actualiza_correo/frmactualiza_datos.aspx?token=" + Token + "&sistema=15830", true);
                        }
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
                lblError.Text ="Error de Usuario o Contraseña." + ex.Message;
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
                ObjSesion.id_sistema = "15830";
                CNSesison.insertar_datos_sesion(ref ObjSesion, ref Verificador);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

       public bool ValidarUsuario(ref string Verificador)
        {
            try
            {
                Usuario.Correo_UNACH = txtUsario.Text.ToUpper();
                Usuario.Password = txtPassword.Text.ToUpper();
                //CNUsuario.ValidarUsuario(ref Usuario, ref Verificador);
                CNUsuario.ObtenerUsuario(ref Usuario, ref Verificador);
                if (Verificador == "0")
                {

                    SesionUsu.CUsuario = Usuario.CUsuario;
                    SesionUsu.Usu_Nombre = Usuario.CUsuario;
                    SesionUsu.Usu_Ejercicio = ddlEjercicio.SelectedValue;
                    SesionUsu.Usu_TipoUsu = Usuario.TipoUsu;
                    SesionUsu.Correo_UNACH = txtUsario.Text;
                    Session["Usuario"] = SesionUsu;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                return false;
            }
        }

       

     

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://ldapm.unach.mx/authldap.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Username", "ldapru");
            request.AddHeader("Password", "01#lDhyr983wry");
            request.AddHeader("Authorization", "Basic bGRhcHJ1OjAxI2xEaHlyOTgzd3J5");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("ldapuser", txtUsario.Text);
            request.AddParameter("ldappasswd", txtPassword.Text);
            IRestResponse response = client.Execute(request);
            //lblError.Text = response.Content;
            var jObject = JObject.Parse(response.Content);

            //Extracting Node element using Getvalue method
            string Autorizado = jObject.GetValue("valido").ToString();
            if (Autorizado == "0")
            {
                bool Valido = ValidarUsuario(ref Verificador);
                if (Valido == true)               
                    Response.Redirect("Default.aspx", false);
                else
                    lblError.Text = Verificador;
            }
            else
                lblError.Text = "No fue posible realizar la autenticación, correo o contraseña no validos.";
        }
    }
}