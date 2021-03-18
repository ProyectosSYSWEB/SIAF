using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace SAF.Presupuesto.Form
{
    public partial class frmConsultas : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Consultas CNConsultas = new CN_Consultas();
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
            CargarCombos();
        }

        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo",SesionUsu.Usu_Nombre ,SesionUsu.Usu_Ejercicio, "CAT");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuente_F", ref DDLFuente, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void GRDCargarDatosCodProg(object sender, EventArgs e)
        {
            try
            {                
                CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void CargarPolizaConsultaGrid(string CodigoProgramatico)
        {
            try
            {
                GRDCodProg.Enabled = false;
                Consultas objConsultas = new Consultas();
                List<Consultas> listConsultas = new List<Consultas>();
                objConsultas.Codigo_Programatico = CodigoProgramatico;
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.PolizaConsultaGrid(ref objConsultas, ref listConsultas);                
                if(listConsultas.Count > 0)
                {
                    GRDCodProg.Enabled = true;
                    GRDCodProg.DataSource = listConsultas;
                    GRDCodProg.DataBind();
                }
                else
                {
                    GRDCodProg.Enabled = false;
                    GRDCodProg.DataSource = null;
                    GRDCodProg.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        

        protected void CBCap_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBCap1.Checked)
                    ListaCaps.Add("1");
                //else
                //    ListaCaps.Remove("1000");
                if (CBCap2.Checked)
                    ListaCaps.Add("2");                
                if (CBCap3.Checked)
                    ListaCaps.Add("3");                
                if (CBCap4.Checked)
                    ListaCaps.Add("4");
                if (CBCap5.Checked)
                    ListaCaps.Add("5");
                if (CBCap6.Checked)
                    ListaCaps.Add("6");
                if (CBCap7.Checked)
                    ListaCaps.Add("7");
                if (CBCap8.Checked)
                    ListaCaps.Add("8");
                if (CBCap9.Checked)
                    ListaCaps.Add("9");
                //if (CBCapT.Checked)
                //{
                //    int cap = 1;
                //    for (int i = 1; i <= 8; i++)
                //    {
                //        ListaCaps.Add(Convert.ToString(cap));
                //        cap = cap + 1;
                //    }
                //}

                for (int i = 0; i < ListaCaps.Count; i++)
                {
                    capitulos = capitulos + ListaCaps[i] + ",";
                }
                capitulos = capitulos.TrimEnd(',');
                Session["Capitulos"] = capitulos;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = " ";
                DDLCodProg.Enabled = false;
                capitulos = (String)Session["Capitulos"];
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref DDLCodProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, capitulos, DDLFuente.SelectedValue);
                if (DDLCodProg.Items.Count > 1)
                {
                    DDLCodProg.Enabled = true;
                    CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                }

                else if (DDLCodProg.Items.Count == 1)
                {
                    DDLCodProg.Enabled = false;                    
                    CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}