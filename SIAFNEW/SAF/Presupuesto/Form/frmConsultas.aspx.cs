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
        CN_Pres_Documento CNDocumentos = new CN_Pres_Documento();
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuente_F", ref DDLFuente, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuente_F", ref DDLFuente, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue);
                CargarCapitulos();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarCapitulos();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDCargarDatosCodProg(object sender, EventArgs e)
        {
            try
            {
                //CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                CargarGridConsultas();
                //CargarGridAumentos();
                //CargarGridCedulas();
                //CargarGridMinistraciones();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void DDLCodProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                CargarGridConsultas();
                CargarGridAumentos();
                CargarGridCedulas();
                CargarGridMinistraciones();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarPolizaConsultaGrid(string CodigoProgramatico)
        {
            try
            {
                //GRDCodProg.Enabled = false;
                //Consultas objConsultas = new Consultas();
                //List<Consultas> listConsultas = new List<Consultas>();
                //objConsultas.Codigo_Programatico = CodigoProgramatico;
                //objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                //CNConsultas.PolizaConsultaGrid(ref objConsultas, ref listConsultas);                
                //if(listConsultas.Count > 0)
                //{
                //    GRDCodProg.Enabled = true;
                //    GRDCodProg.DataSource = listConsultas;
                //    GRDCodProg.DataBind();
                //}
                //else
                //{
                //    GRDCodProg.Enabled = false;
                //    GRDCodProg.DataSource = null;
                //    GRDCodProg.DataBind();
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        private void CargarGridConsultas()
        {
           
            grdCodProg.DataSource = null;
            grdCodProg.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdCodProg.DataSource = dt;
                grdCodProg.DataSource = GetList();
                grdCodProg.DataBind();
               

            }
            catch (Exception ex)
            {
               
            }
        }
        private List<Consultas> GetList()
        {
            try
            {
                Pres_Documento objDocumento = new Pres_Documento();
                Consultas objConsultas = new Consultas();
                List<Consultas> listConsultas = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.PolizaConsultaGrid( objConsultas, ref listConsultas);


                return listConsultas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void CargarCapitulos()
        {
            try
            {
                List<Pres_Reportes> List = new List<Pres_Reportes>();
                objReportes.Ejercicio = SesionUsu.Usu_Ejercicio;
                objReportes.Dependencia = DDLDependencia.SelectedValue;
                objReportes.DependenciaF = DDLDependencia.SelectedValue;
                objReportes.Fuente = DDLFuente.SelectedValue;
                CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                grdCapitulo.DataSource = List;
                grdCapitulo.DataBind();
                Int32[] Celdas = new Int32[] { 1 };
                if (grdCapitulo.Rows.Count > 0)
                {
                    CNComun.HideColumns(grdCapitulo, Celdas);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        
        protected void rowCapitulo(GridView Nombre_Grid, string Nombre_Checkbox)
        {
            try
            {
                objReportes.Capitulo = string.Empty;
                foreach (GridViewRow row in Nombre_Grid.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl(Nombre_Checkbox);
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        if(objReportes.Capitulo ==string.Empty)
                            objReportes.Capitulo =  Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                        else
                            objReportes.Capitulo = objReportes.Capitulo + "," + Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                rowCapitulo(grdCapitulo, "chkcapitulo");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Saf_Presup_Cod_Prog", ref DDLCodProg, "p_ejercicio", "p_dependencia", "p_fuente", "p_capitulos",  SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLFuente.SelectedValue, objReportes.Capitulo);
                //if (DDLCodProg.Items.Count >1)
                //{
                //    DDLCodProg.Enabled = true;
                //CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);

                //    CargarGridCedulas();
                //    CargarGridAumentos();
                //    CargarGridMinistraciones();
                //}

                //else if (DDLCodProg.Items.Count == 1 && DDLCodProg.DataSource != null)
                //{
                //    DDLCodProg.Enabled = false;
                //    CargarPolizaConsultaGrid(DDLCodProg.SelectedValue);
                //    //CargarCapitulos();
                //    CargarGridCedulas();
                //    CargarGridAumentos();
                //    CargarGridMinistraciones();
                //}
                //else
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Sin códigos programaticos.')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarGridCedulas()
        {
            try
            {
                Consultas objConsultas = new Consultas();
                List<Consultas> listCedulas = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Dependencia = DDLDependencia.SelectedValue;
                objConsultas.Supertipo = "C";
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.ConsultaDetalleDocumento(ref objConsultas, ref listCedulas);
                if (listCedulas.Count > 0)
                {
                    GRDCedulas.Enabled = true;
                    GRDCedulas.DataSource = listCedulas;
                    GRDCedulas.DataBind();
                }
                else
                {
                    GRDCedulas.Enabled = true;
                    GRDCedulas.DataSource = null;
                    GRDCedulas.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }        
        protected void CargarGridAumentos()
        {
            try
            {
                Consultas objConsultas = new Consultas();
                List<Consultas> listAumentos = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Dependencia = DDLDependencia.SelectedValue;
                objConsultas.Supertipo = "A";                
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.ConsultaDetalleDocumento(ref objConsultas, ref listAumentos);
                if (listAumentos.Count > 0)
                {
                    GRDAumentos.Enabled = true;
                    GRDAumentos.DataSource = listAumentos;
                    GRDAumentos.DataBind();
                }
                else
                {
                    GRDAumentos.Enabled = true;
                    GRDAumentos.DataSource = null;
                    GRDAumentos.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarGridMinistraciones()
        {
            try
            {
                Consultas objConsultas = new Consultas();
                List<Consultas> listMinistraciones = new List<Consultas>();
                objConsultas.Codigo_Programatico = DDLCodProg.SelectedValue;
                objConsultas.Dependencia = DDLDependencia.SelectedValue;
                objConsultas.Supertipo = "M";
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CNConsultas.ConsultaDetalleDocumento(ref objConsultas, ref listMinistraciones);
                if (listMinistraciones.Count > 0)
                {
                    GRDMinistraciones.Enabled = true;
                    GRDMinistraciones.DataSource = listMinistraciones;
                    GRDMinistraciones.DataBind();
                }
                else{
                    GRDMinistraciones.Enabled = true;
                    GRDMinistraciones.DataSource = null;
                    GRDMinistraciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDCedulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    string Verificador = string.Empty;
                    Pres_Documento objDocumento = new Pres_Documento();
                    List<Pres_Documento> List = new List<Pres_Documento>();                    
                    objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                    objDocumento.Dependencia = Convert.ToString(GRDCedulas.SelectedRow.Cells[0].Text);                    
                    objDocumento.Tipo = Convert.ToString(GRDCedulas.SelectedRow.Cells[2].Text);
                    objDocumento.SuperTipo = "C";
                    objDocumento.Status = Convert.ToString(GRDCedulas.SelectedRow.Cells[5].Text);
                    objDocumento.Fecha_Inicial = Convert.ToString(GRDCedulas.SelectedRow.Cells[6].Text);
                    objDocumento.Fecha_Final = Convert.ToString(GRDCedulas.SelectedRow.Cells[7].Text);
                    objDocumento.P_Buscar ="";
                    objDocumento.Editor = "";
                    CNDocumentos.ConsultaGrid_Documentos(ref objDocumento, ref List);
                    if (Verificador == "0")
                    {
                        string a = "1";
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene permisos para realizar esta acción')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }

        protected void LinkBImprimir_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            GRDCedulas.SelectedIndex = row.RowIndex;
            string ruta1 = string.Empty;

            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-002&id=" + GRDCedulas.SelectedRow.Cells[0].Text;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta1 = "";
                ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RPT-Generales_Cedulas&P_Depend="+ DDLDependencia.SelectedValue + "&P_Ejercicio=" + SesionUsu.Usu_Ejercicio+ "&P_ID_COD_PROG=" + DDLCodProg.SelectedValue;
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

    }
}