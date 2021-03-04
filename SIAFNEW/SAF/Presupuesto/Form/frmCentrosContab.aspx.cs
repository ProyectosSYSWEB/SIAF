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
    public partial class frmCentrosContab : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_CentrosContab CN_CentrosContab = new CN_CentrosContab();
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
            GRDCargarDatosCentrosContab();
        }



        protected void GRDCargarDatosCentrosContab()
        {
            try
            {
                CentrosContab objCentroContab = new CentrosContab();
                objCentroContab.Ejercicio = SesionUsu.Usu_Ejercicio;
                List<CentrosContab> list = new List<CentrosContab>();
                CN_CentrosContab.CContabGrid(ref objCentroContab, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCentrosContab.DataSource = list;
                GRDCentrosContab.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}