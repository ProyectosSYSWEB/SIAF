using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CapaEntidad;
using CapaNegocio;

namespace SAF
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();

        Mnu mnu = new Mnu();
        Comun comun = new Comun();
        CN_Mnu CNMnu = new CN_Mnu();
        CN_Comun CNComun = new CN_Comun();
        List<Comun> Listsistema = new List<Comun>();
        Usuario ObjUsuario = new Usuario();
        CN_Usuario CNUsuario = new CN_Usuario();

        string Verificador = string.Empty;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            bttnCorreoUnach.Text = SesionUsu.Correo_UNACH;
            //if (!IsPostBack)
            //{
            //BusyBoxButton1.Attributes.Add("onClick", BusyBox1.ShowFunctionCall);
            Inicializar();
            //}
                
            

        }        
        #region <Funciones y Sub>
        private void Inicializar()
        {
            try
            {
                SesionUsu = (Sesion)Session["Usuario"];                
                lblUsuario.Text = SesionUsu.Usu_Nombre;
                ddlUsu_Ejercicio.SelectedValue = SesionUsu.Usu_Ejercicio;                
                mnu.NombreMenu = "MenuTop";
                mnu.UsuarioNombre = SesionUsu.Usu_Nombre;
                mnu.Grupo = 1;

                string siteMap = "ArchivosMenu/Web" + SesionUsu.Usu_Nombre + ".sitemap";
                string fullPath = Path.Combine(Server.MapPath("~"), siteMap);
                if (!File.Exists(fullPath))
                {
                    CNMnu.GenerateXMLFile(mnu, fullPath);
                }

                XmlSiteMapProvider testXmlProvider = new XmlSiteMapProvider();
                NameValueCollection providerAttributes = new NameValueCollection(1);
                providerAttributes.Add("siteMapFile", siteMap);
                testXmlProvider.Initialize("MyXmlSiteMapProvider", providerAttributes);
                testXmlProvider.BuildSiteMap();
                SiteMapDataSource smd = new SiteMapDataSource();
                smd.ShowStartingNode = false;
                smd.Provider = testXmlProvider;
                SiteMapPath1.Provider = testXmlProvider;
                MenuTop.DataSource = smd;
                MenuTop.DataBind();                
                CNComun.LlenaCombo("pkg_contratos.Obt_Combo_sistemas", ref ddlSistemas, "p_usuario", SesionUsu.Usu_Nombre, ref Listsistema);


            }
            catch (Exception ex)
            {
                
                //lblMsj.Text = ex.Message;
            }
        }
        #endregion

        protected void MenuTop_MenuItemClick(object sender, MenuEventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "f04", "CerrarPopUp()", true); 
        }

        protected void btnIr_Click(object sender, EventArgs e)
        {
            if (ddlSistemas.SelectedValue != "X")
            {
                GenerarToken("btnIr");
            }
        }

        protected void lnkMiCuenta_Click(object sender, EventArgs e)
        {
            GenerarToken("lnkMiCuenta");

        }

        private void GenerarToken(string solicitud)
        {
            Guid Token = Guid.NewGuid();
            Verificador = String.Empty;
            ObjUsuario = new Usuario();


            ObjUsuario.Token = Convert.ToString(Token);
            ObjUsuario.CUsuario = SesionUsu.CUsuario;

            CNUsuario.Inserta_Token(ref ObjUsuario, ref Verificador);

            switch (solicitud)
            {
                case "btnIr": Response.Redirect(ddlSistemas.SelectedValue + "?token=" + Token, true); break;
                case "lnkMiCuenta": Response.Redirect("http://sysweb.unach.mx/administrator?token=" + Token, true); break;
            }
        }



        protected void BusyBoxButton1_Click1(object sender, EventArgs e)
        {
            SesionUsu.Usu_Ejercicio = ddlUsu_Ejercicio.SelectedValue;
        }

        protected void linkBttnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
    }
}
