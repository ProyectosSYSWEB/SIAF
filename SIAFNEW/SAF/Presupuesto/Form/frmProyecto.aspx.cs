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
    public partial class frmProyecto : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Proyecto CN_Proyecto = new CN_Proyecto();
        Pres_Reportes objReportes = new Pres_Reportes();
        string capitulos = "";
        List<string> ListaCaps = new List<string>();
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
            GRDCargarDatosProyectos();
        }



        protected void GRDCargarDatosProyectos()
        {
            try
            {
                Proyectos objProyectos = new Proyectos();
                objProyectos.Ejercicio = SesionUsu.Usu_Ejercicio;
                List<Proyectos> listPresUnv = new List<Proyectos>();
                CN_Proyecto.ProyectoGrid(ref objProyectos, ref listPresUnv);                
                GRDProyectos.DataSource = listPresUnv;
                GRDProyectos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}