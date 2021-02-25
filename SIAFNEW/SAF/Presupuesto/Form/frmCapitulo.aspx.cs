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
    public partial class frmCapitulo : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Capitulo CN_Capitulo = new CN_Capitulo();        
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
            GRDCargarDatosDepend();
        }

        protected void GRDCargarDatosDepend()
        {
            try
            {
                Basicos objBasicos = new Basicos();
                List<Basicos> list = new List<Basicos>();
                objBasicos.tipo = "CAT_EVENTO";
                objBasicos.status = "A";
                CN_Capitulo.CapitulosGrid(ref objBasicos, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCapitulos.DataSource = list;
                GRDCapitulos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}