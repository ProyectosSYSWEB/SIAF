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
    public partial class frmPresupUnv : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_PresupUnv CN_PresupUnv = new CN_PresupUnv();
        CN_Pres_Reportes CNReportes = new CN_Pres_Reportes();
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
            GRDCargarDatosPresUnv();
        }
        
        

        protected void GRDCargarDatosPresUnv()
        {
            try
            {
                PresupUnv objPresupUnv = new PresupUnv();
                List<PresupUnv> listPresUnv = new List<PresupUnv>();
                CN_PresupUnv.PresUnvGrid(ref objPresupUnv, ref listPresUnv);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCodProg.DataSource = listPresUnv;
                GRDCodProg.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }        
    }
}