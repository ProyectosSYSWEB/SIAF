using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using CapaEntidad;
using CapaNegocio;

namespace SAF
{
    public partial class Inicio : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Comun Comun = new Comun();
        Mnu mnu = new Mnu();
        CN_Mnu CNMnu = new CN_Mnu();
        CN_Comun CNMonitor = new CN_Comun();
        CN_Comun CNComun = new CN_Comun();
        CN_Informativa CNInformativa = new CN_Informativa();
        cuentas_contables Objinformativa = new cuentas_contables();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //SesionUsu = (Sesion)Session["Usuario"];
            //if (!IsPostBack)
            //{
            //    busca_informativa();               
            //    MenuArbol();
            //}
        }
        
        protected void btnSi_Click(object sender, EventArgs e)
        {
            ModalPopupExtender.Hide();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}