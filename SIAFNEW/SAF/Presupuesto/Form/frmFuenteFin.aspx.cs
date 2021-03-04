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
    public partial class frmFuenteFin : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_FuenteFin CN_FuenteFin = new CN_FuenteFin();
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
            GRDFuenteFinan();
        }

        protected void GRDFuenteFinan()
        {
            try
            {
                FuentesFin objFuenteFin = new FuentesFin();
                List<FuentesFin> list = new List<FuentesFin>();
                CN_FuenteFin.FuentesGrid(ref objFuenteFin, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDFuenteFin.DataSource = list;
                GRDFuenteFin.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

    }
}