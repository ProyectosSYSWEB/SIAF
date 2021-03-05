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
    public partial class frmDependencia : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Dependencias CN_Dependencias = new CN_Dependencias();
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
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "p_ejercicio", SesionUsu.Usu_Ejercicio);
        }


        protected void GRDCargarDatosDepend()
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                List<Dependencias> list = new List<Dependencias>();
                objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                objDependencias.Ejercicio = Convert.ToInt32( SesionUsu.Usu_Ejercicio);
                CN_Dependencias.DependenciasGrid(ref objDependencias, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GDRDependencias.DataSource = list;
                GDRDependencias.DataBind();
                LBLNumDepend.Text = "Total de dependencias: " + list.Count;
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
                Dependencias objDependencias = new Dependencias();
                List<Dependencias> list = new List<Dependencias>();
                objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                objDependencias.Ejercicio = Convert.ToInt32( SesionUsu.Usu_Ejercicio);
                CN_Dependencias.DependenciasGrid(ref objDependencias, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GDRDependencias.DataSource = list;
                GDRDependencias.DataBind();
                LBLNumDepend.Text = "Total de dependencias: " + list.Count;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}