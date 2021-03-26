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
        CN_Pres_Reportes CNReportes = new CN_Pres_Reportes();
        CN_Consultas CNConsultas = new CN_Consultas();        
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
            CargarCapitulos();
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
                CargarGridAumentos();
                CargarGridCedulas();
                CargarGridMinistraciones();
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

        protected void CargarCapitulos()
        {
            try
            {
                List<Pres_Reportes> List = new List<Pres_Reportes>();
                objReportes.Ejercicio = SesionUsu.Usu_Ejercicio;
                objReportes.Dependencia = "00000";
                objReportes.DependenciaF = "00000";
                CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                grdCapitulo.DataSource = List;
                grdCapitulo.DataBind();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        //protected void btnChkCapitulos_v1_Click(object sender, EventArgs e)
        //{
        //    bool check;
        //    if (btnChkCapitulos_v1.Text == "Marcar todos")
        //    {
        //        btnChkCapitulos_v1.Text = "Quitar todos";
        //        check = true;
        //    }
        //    else
        //    {
        //        btnChkCapitulos_v1.Text = "Marcar todos";
        //        check = false;
        //    }
        //    foreach (GridViewRow row in grdCapitulo.Rows)
        //    {
        //        CheckBox check_box = row.FindControl("chkcapitulo") as CheckBox;
        //        check_box.Checked = check;
        //    }
        //}

        protected void rowCapitulo(GridView Nombre_Grid, string Nombre_Checkbox)
        {
            try
            {

                objReportes.Capitulo = "0";
                foreach (GridViewRow row in Nombre_Grid.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl(Nombre_Checkbox);
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        //objReportes.Capitulo = objReportes.Capitulo + "," + Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                        objReportes.Capitulo = Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

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
                rowCapitulo(grdCapitulo, "chkcapitulo");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Saf_Presup_Cod_Prog", ref DDLCodProg, "p_ejercicio", "p_dependencia", "p_fuente", "p_capitulos",  SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLFuente.SelectedValue, objReportes.Capitulo);
                if (DDLCodProg.Items.Count > 1)
                {
                    DDLCodProg.Enabled = true;
                    CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                    CargarCapitulos();
                    CargarGridAumentos();
                    CargarGridMinistraciones();
                }

                else if (DDLCodProg.Items.Count == 1)
                {
                    DDLCodProg.Enabled = false;                    
                    CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                    CargarCapitulos();
                    CargarGridAumentos();
                    CargarGridMinistraciones();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }



        protected void CargarGridCedulas()
        {
            try
            {
                GRDCodProg.Enabled = false;
                Consultas objConsultas = new Consultas();
                List<Consultas> listConsultas = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Dependencia = DDLDependencia.SelectedValue;
                objConsultas.Supertipo = "C";
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.ConsultaDetalleDocumento(ref objConsultas, ref listConsultas);
                if (listConsultas.Count > 0)
                {
                    GRDCedulas.Enabled = true;
                    GRDCedulas.DataSource = listConsultas;
                    GRDCedulas.DataBind();
                }
                else
                {
                    GRDCedulas.Enabled = false;
                    GRDCedulas.DataSource = null;
                    GRDCedulas.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void CargarGridMinistraciones()
        {
            try
            {
                GRDCodProg.Enabled = false;
                Consultas objConsultas = new Consultas();
                List<Consultas> listConsultas = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Dependencia = DDLDependencia.SelectedValue;
                objConsultas.Supertipo = "M";
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.ConsultaDetalleDocumento(ref objConsultas, ref listConsultas);
                if (listConsultas.Count > 0)
                {
                    GRDMinistraciones.Enabled = true;
                    GRDMinistraciones.DataSource = listConsultas;
                    GRDMinistraciones.DataBind();
                }
                else
                {
                    GRDMinistraciones.Enabled = false;
                    GRDMinistraciones.DataSource = null;
                    GRDMinistraciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void CargarGridAumentos()
        {
            try
            {
                GRDCodProg.Enabled = false;
                Consultas objConsultas = new Consultas();
                List<Consultas> listConsultas = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Dependencia = DDLDependencia.SelectedValue;
                objConsultas.Supertipo = "A";                
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.ConsultaDetalleDocumento(ref objConsultas, ref listConsultas);
                if (listConsultas.Count > 0)
                {
                    GRDAumentos.Enabled = true;
                    GRDAumentos.DataSource = listConsultas;
                    GRDAumentos.DataBind();
                }
                else
                {
                    GRDAumentos.Enabled = false;
                    GRDAumentos.DataSource = null;
                    GRDAumentos.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }



    }
}