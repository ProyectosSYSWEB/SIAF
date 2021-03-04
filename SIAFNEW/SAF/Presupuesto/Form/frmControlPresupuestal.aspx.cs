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
    public partial class frmControlPresupuestal : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Estruct CN_Estruct = new CN_Estruct();
        CN_Comun CNComun = new CN_Comun();
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
            GRDCargarDatosEstructuraProg();            
        }

        protected void CargarCombos()
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "p_ejercicio", SesionUsu.Usu_Ejercicio);
            DDLCentroContab.SelectedValue = "1";
        }

        protected void GRDCargarDatosEstructuraProg()
        {
            try
            {
                Estruct objEstruct = new Estruct();
                objEstruct.Ejercicio = SesionUsu.Usu_Ejercicio;
                objEstruct.Centro_Contable = DDLCentroContab.SelectedValue;
                List<Estruct> list = new List<Estruct>();
                CN_Estruct.EstructGrid(ref objEstruct, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDEstrucProg.DataSource = list;
                GRDEstrucProg.DataBind();
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
                Estruct objEstruct = new Estruct();
                objEstruct.Ejercicio = SesionUsu.Usu_Ejercicio;
                objEstruct.Centro_Contable = DDLCentroContab.SelectedValue;
                List<Estruct> list = new List<Estruct>();
                CN_Estruct.EstructGrid(ref objEstruct, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDEstrucProg.DataSource = list;
                GRDEstrucProg.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}