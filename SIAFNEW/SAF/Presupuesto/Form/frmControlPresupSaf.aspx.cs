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
    public partial class frmControlPresupSaf : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Codigo_Prog CN_Codigo_Prog = new CN_Codigo_Prog();
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
            CargarCombos();
            GRDCargarDatosDepend();
        }


        protected void CargarCombos()
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab);
        }


        protected void GRDCargarDatosDepend()
        {
            try
            {
                Codigo_Prog objCodProg = new Codigo_Prog();
                List<Codigo_Prog> list = new List<Codigo_Prog>();
                objCodProg.Centro_Contable = DDLCentroContab.SelectedValue;
                objCodProg.Ejercicio = "2021";
                CN_Codigo_Prog.CodigoProgGrid(ref objCodProg, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCodProg.DataSource = list;
                GRDCodProg.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLCentroContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo_Prog objCodProg = new Codigo_Prog();
                List<Codigo_Prog> list = new List<Codigo_Prog>();
                objCodProg.Centro_Contable = DDLCentroContab.SelectedValue;
                objCodProg.Ejercicio = "2021";
                CN_Codigo_Prog.CodigoProgGrid(ref objCodProg, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCodProg.DataSource = list;
                GRDCodProg.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}