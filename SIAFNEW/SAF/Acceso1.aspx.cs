using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using MailBee;
using MailBee.ImapMail;
using MailBee.SmtpMail;

using CapaEntidad;
using CapaNegocio;


namespace Ejemplo
{
    public partial class Acceso1 : System.Web.UI.Page
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
                string serviceAccountEmail = "SomeID@developer.gserviceaccount.com";
                string userEmail = "user@some-googleapps-domain.com";

                X509Certificate2 certificate = new X509Certificate2(@"C:\Temp\a...0-privatekey.p12",
                    "notasecret", X509KeyStorageFlags.Exportable);

                ServiceAccountCredential credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(serviceAccountEmail)
                   {
                       User = userEmail,
                       Scopes = new string[] { "https://mail.google.com/" }
                   }.FromCertificate(certificate));

                if (credential.RequestAccessTokenAsync(CancellationToken.None).Result)
                {
                    string xoAuthKey = OAuth2.GetXOAuthKeyStatic(userEmail, credential.Token.AccessToken);

                    // Uncomment and set your key if you haven't specified it in app.config or Windows registry.
                    // MailBee.Global.LicenseKey = "Your MNXXX-XXXX-XXXX key here";

                    bool useImap = true; // Set to false to use SMTP (send e-mail) instead of IMAP (check Inbox).

                    if (useImap)
                    {
                        Imap imp = new Imap();

                        // Logging is not necessary but useful for debugging.
                        imp.Log.Enabled = true;
                        imp.Log.Filename = @"C:\Temp\log.txt";
                        imp.Log.HidePasswords = false;
                        imp.Log.Clear();

                        imp.Connect("imap.gmail.com");
                        imp.Login(userEmail, xoAuthKey, AuthenticationMethods.SaslOAuth2,
                            MailBee.AuthenticationOptions.None, null);
                        imp.SelectFolder("Inbox");
                        ViewBag.Message = imp.MessageCount.ToString() + " message(s) in INBOX";
                        imp.Disconnect();
                    }
                    else
                    {
                        Smtp mailer = new Smtp();
                        mailer.SmtpServers.Add("smtp.gmail.com", null, xoAuthKey, AuthenticationMethods.SaslOAuth2);

                        // Logging is not necessary but useful for debugging.
                        mailer.Log.Enabled = true;
                        mailer.Log.Filename = @"C:\Temp\log.txt";
                        mailer.Log.HidePasswords = false;
                        mailer.Log.Clear();

                        mailer.From.Email = userEmail;
                        mailer.To.Add(userEmail);
                        mailer.Subject = "empty email to myself";
                        mailer.Send();
                        ViewBag.Message = "E-mail sent";
                    }
                }
                else
                {
                    ViewBag.Message = "Can't get the access token";
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
                lblError.Text= ex.Message + ".-ValidarUsuario";
            }
        }

       

     

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}