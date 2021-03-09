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
    public partial class frmSubprograma : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Subprog CN_Subprog = new CN_Subprog();
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
                Subprograma objSubprogramaa = new Subprograma();
                List<Subprograma> list = new List<Subprograma>();
                objSubprogramaa.DependenciaI = "11101";
                objSubprogramaa.DependenciaF = "81101";
                objSubprogramaa.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_Subprog.SubprogramasGrid(ref objSubprogramaa, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDProgramas.DataSource = list;
                GRDProgramas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}