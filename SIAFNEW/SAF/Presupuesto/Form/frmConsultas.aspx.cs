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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo",SesionUsu.Usu_Nombre ,SesionUsu.Usu_Ejercicio, "");                
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Centro_Contable", ref ddlCentroContable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ref ListDependencia);
                //DDLCentroContable_SelectedIndexChanged(null, null);
                //ddlDepen_SelectedIndexChanged(null, null);
                //CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Ctas_Bancos", ref DDLCuenta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Todos", ref ddlStatus);
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "C");
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", SesionUsu.Usu_Rep);
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", SesionUsu.Usu_Rep);
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep);
                //ddlTipoEnc.Items.RemoveAt(0);
                //ddlTipoEnc.Items.Insert(0, new ListItem("--ELEGIR TIPO--", "0"));
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
        protected void DDLCodProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                capitulos = (String)Session["Capitulos"];
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref DDLCodProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", "2020", DDLDependencia.SelectedValue, capitulos, DDLFuente.SelectedValue);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDCargarDatosCodProg(object sender, EventArgs e)
        {
            try
            {
                Consultas objConsultas = new Consultas();
                List<Consultas> listConsultas = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                CNConsultas.PolizaConsultaGrid(ref objConsultas, ref listConsultas);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCodProg.DataSource = listConsultas;
                GRDCodProg.DataBind();
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
    }
}