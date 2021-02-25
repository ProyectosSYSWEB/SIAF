using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmFuncion : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();        
        CN_Funcion CN_Funcion = new CN_Funcion();        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        private void Inicializar()
        {
            GRDCargarDatosFuncion();
        }
        protected void GRDCargarDatosFuncion()
        {
            try
            {
                Funcion objFuncion = new Funcion();
                List<Funcion> listFuncion = new List<Funcion>();
                CN_Funcion.FuncionGrid(ref objFuncion, ref listFuncion);                
                GRDFunciones.DataSource = listFuncion;
                GRDFunciones.DataBind();
                if (SesionUsu.Usu_TipoUsu != "SA")
                {
                    GRDFunciones.Columns.RemoveAt(3);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }        
    }
}