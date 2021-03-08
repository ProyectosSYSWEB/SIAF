using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto.Reportes
{
    public partial class frmReportes : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Reportes CNReportes = new CN_Pres_Reportes();      
        Pres_Reportes objReportes = new Pres_Reportes();
        string tipo_plantilla="";
        private static List<Pres_Reportes> ListCodigo = new List<Pres_Reportes>();
        private static List<Comun> ListDependencia = new List<Comun>();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();

            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "PRUEBA", "Autocomplete();", true);
        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
                switch (SesionUsu.Usu_Rep)
                {
                    case "RP-001":
                        MultiView1.ActiveViewIndex = 0;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "REPORTES", ref ListDependencia);
                        btnChkCapitulos_v1.Visible = false;
                        btnChkFuentes_v1.Visible = false;
                        btnChkProyectos_v1.Visible = false;
                        grdProyectos_v1.Visible = false;
                        ddlDependencia_SelectedIndexChanged(null, null);
                        break;
                    case "RP-004":
                        MultiView1.ActiveViewIndex = 2;
                        break;
                    case "RP-005":
                        MultiView1.ActiveViewIndex = 4;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia0, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                        CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");

                        break;
                    case "RP-006":
                        MultiView1.ActiveViewIndex = 4;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia0, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                        DDLSemestre.Visible = false;
                        Label20.Visible = false;
                        break;
                    case "RP-007":
                        MultiView1.ActiveViewIndex = 1;
                        DDL_Tipo.SelectedValue = "D";
                        DDL_Tipo.Enabled = false;
                        cargarcombos();
                        break;
                    case "RP-008":
                        MultiView1.ActiveViewIndex = 1;
                        cargarcombos();
                        break;
                    case "RP-008-A":
                        MultiView1.ActiveViewIndex = 1;
                        excel_temporal.Visible = false;
                        DDL_Tipo.SelectedValue = "D";
                        DDL_Tipo.Enabled = false;
                        cargarcombos();
                        break;
                    case "RP-008-CAL":
                        MultiView1.ActiveViewIndex = 1;
                        excel_temporal.Visible = false;
                        DDL_Nomina.Visible = false;
                        Label10.Visible = false;
                        DDL_Quincena.Visible = false;
                        Label9.Visible = false;
                        DDL_Tipo.SelectedValue = "D";
                        DDL_Tipo.Enabled = false;
                        cargarcombos();
                        break;
                    case "RP-009":
                        MultiView1.ActiveViewIndex = 2;
                        Label22.Visible = true;
                        ddlSemestre9.Visible = true;
                        DDL_Tipo0.Visible = false;
                        Label14.Visible = false;
                        Label21.Visible = false;
                        DDL_Status1.Visible = false;                        
                        cargarcombos();
                        break;
                    case "RP-012":                        
                        MultiView1.ActiveViewIndex = 5;
                        break;
                    case "RP-013":
                        MultiView1.ActiveViewIndex = 2;
                        Label21.Visible = false;
                        DDL_Status1.Visible = false;                        
                        break;
                    case "RP-015":
                        MultiView1.ActiveViewIndex = 4;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia0, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                        CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
                        break;
                    case "RP-016":
                        MultiView1.ActiveViewIndex = 4;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia0, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                        CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
                        break;
                    case "RP-017":
                        MultiView1.ActiveViewIndex = 4;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia0, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                        CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
                        break;
                    case "RP-Comparativo-PC":
                        MultiView1.ActiveViewIndex = 6;
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Centro_Contable", ref DDLCentro_Contable_v7, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Mayor_Comparativo", ref DDLCuentas_v7, "p_reporte",DDLTipoReporte_v7.SelectedValue);
                        break;
                    case "RP-Listado_Cedulas":
                        MultiView1.ActiveViewIndex = 7;
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Centro_Contable", ref DDLCentro_Contable_v8, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Tipo_Documento", ref DDLTipoCedula_v8,"p_supertipo","C");
                        DDLTipoCedula_v8.SelectedValue = "T";
                        DDLTipoCedula_v8.Items.RemoveAt(DDLTipoCedula_v8.SelectedIndex);
                        break;
                   
                    case "RP-PRESUP_RP003":
                        MultiView1.ActiveViewIndex = 13;
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Dependencias", ref DDLDependencia_v14, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "REPORTES");
                        btnChkCapitulos_v14.Visible = false;
                        btnChkSubprogramas_v14.Visible = false;
                        DDLDependencia_v14_SelectedIndexChanged(null, null);
                        break;
                    case "RP-PRESUP_RP005":
                        MultiView1.ActiveViewIndex = 8;
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Dependencias", ref DDLDependencia_v9, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "REPORTES");
                        DDLMes_v9.SelectedValue = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
                        grdProyecto_v9.Visible = false;
                        btnchkCapitulos.Visible = false;
                        btnchkProyectos.Visible = false;
                        btnchkFuentes.Visible = false;
                        DDLDependencia_v9_SelectedIndexChanged(null, null);
                        break;
                  
                    case "RP-PRESUP_RP008":
                        MultiView1.ActiveViewIndex = 8;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia_v9, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "REPORTES");
                        DDLMes_v9.SelectedValue = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
                        btnchkCapitulos.Visible = false;
                        btnchkProyectos.Visible = false;
                        btnchkFuentes.Visible = false;
                        DDLDependencia_v9_SelectedIndexChanged(null, null);
                        break;
                    case "RP-PRESUP_RP009":
                        MultiView1.ActiveViewIndex = 10;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependenciaInicial_v11, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "REPORTES");
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependenciaFinal_v11, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "REPORTES");
                        btnChkFuentes_v11.Visible = false;
                        btnChkCapitulos_v11.Visible = false;
                        break;
                    case "RP-PRESUP_RP017":
                        MultiView1.ActiveViewIndex = 11;
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Centro_Contable", ref DDLCentroContable_v12, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        DDLCentroContable_v12_SelectedIndexChanged(null, null);
                        DDLMes_v12.SelectedValue = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
                        btnChkFuentes_v12.Visible = false;
                        break;
                    case "RP-PRESUP_RP019":
                        MultiView1.ActiveViewIndex = 9;
                        CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Centro_Contable", ref DDLCentroContable_v10, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        DDLMes_v10.SelectedValue = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
                        break;
                    case "RP-PRESUP_SP00":
                        MultiView1.ActiveViewIndex = 12;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia_v13, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio,"REPORTES" );
                        DDLMesFin_Modificado.SelectedValue = "12";
                        DDLMesFin_Ejercido.SelectedValue = "12";
                        grdCapitulo_v13.Visible = false;
                        btnChkCapitulos_v13.Visible = false;
                        grdFuentes_v13.Visible = false;
                        btnChkFuentes_v13.Visible = false;
                        txtFechaEntrega.Text = System.DateTime.Now.ToString("dd/MMMM/yyyy");
                        break;
                   
                }
                        if (Request.QueryString["P_REP"]== "RP-TEMPORAL")
                    {
                      MultiView1.ActiveViewIndex = 1;
                      cargarcombos();
                    }                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void cargarcombos()
        {
            try
            {             
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "A");
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Quincenas", ref DDL_Quincena, "p_ejercicio", SesionUsu.Usu_Ejercicio,   "DPP");
                CNComun.LlenaCombo("PKG_PRES.Obt_Combo_Nomina", ref DDL_Nomina, "p_ejercicio", "P_Quincena", "P_Tipo", SesionUsu.Usu_Ejercicio, DDL_Quincena.SelectedValue, DDL_Tipo.SelectedValue, "DPP");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void imgBttnPdf(object sender, ImageClickEventArgs e)
        {
            try
            {
                rowFuente();
                rowCapitulo();
                rowProyecto();
                string ruta1 = string.Empty;
                if (DDLReporte_v1.SelectedValue == "RP001")
                {
                    switch (ddltipo.SelectedValue)
                    {
                        case "EJERCIDO":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-EJERCIDO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "AUMENTO":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-AUMENTO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "AUTORIZADO":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-AUTORIZADO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "MODIFICADO":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-MODIFICADO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "DISMINUCION":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-DISMINUCION&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "COMPROMETIDO":
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-COMPROMETIDO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "XMINISTRAR":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-XMINISTRAR&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "MINISTRADO":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-MINISTRADO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;
                        case "XEJERCER":
                                ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-XEJERCER&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                            break;

                    }
                }
                else if (DDLReporte_v1.SelectedValue == "RP002")
                    ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP002&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + ddltipo.SelectedValue;
                else if (DDLReporte_v1.SelectedValue == "RP004")
                    ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP004&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Proyecto=" + objReportes.Proyecto + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + ddltipo.SelectedValue;

                else
                    ruta1 = string.Empty;
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }           
        }

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {

        }
        protected void DDLDependenciaInicial_v11_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdFuente_v11.Visible = false;
            btnChkFuentes_v11.Visible = false;
            grdCapitulo_v11.Visible = false;
            btnChkCapitulos_v11.Visible = false;
        }

        protected void DDLDependenciaFinal_v11_SelectedIndexChanged1(object sender, EventArgs e)
        {
            grdFuente_v11.Visible = false;
            btnChkFuentes_v11.Visible = false;
            grdCapitulo_v11.Visible = false;
            btnChkCapitulos_v11.Visible = false;
        }
        protected void DDLDependencia_v9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string formulario = Request.QueryString["P_REP"];
               
                CargarGrid(ref grdCapitulo_v9, 2);
                CargarGrid(ref grdFuente_v9, 3);
                if (formulario == "RP-PRESUP_RP008")
                    CargarGrid(ref grdProyecto_v9, 4);
                else
                    grdProyecto_v9.Visible = false;

                if (grdCapitulo_v9.Rows.Count > 0)
                {
                    btnchkCapitulos.Text = "Marcar todos";
                    btnchkCapitulos.Visible = true;
                }
                else
                    btnchkCapitulos.Visible = false;

                if (grdFuente_v9.Rows.Count > 0)
                {
                    btnchkFuentes.Text = "Marcar todos";
                    btnchkFuentes.Visible = true;
                }
                else
                    btnchkFuentes.Visible = false;

                if (grdProyecto_v9.Rows.Count > 0)
                {
                    btnchkProyectos.Text = "Marcar todos";
                    btnchkProyectos.Visible = true;
                }
                else
                {
                    grdProyecto_v9.Visible = false;
                    btnchkProyectos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void DDLDependenciaFinal_v11_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                CargarGrid(ref grdCapitulo, 1);
                CargarGrid(ref grdFuente, 0);
                CargarGrid(ref grdProyectos_v1,5);

               

                if (DDLReporte_v1.SelectedValue == "RP004")
                {
                    grdFuente.Visible = false;
                    btnChkFuentes_v1.Visible = false;

                    grdProyectos_v1.Visible = true;

                    if (grdProyectos_v1.Rows.Count > 0)
                    {
                        btnChkProyectos_v1.Text = "Marcar todos";
                        btnChkProyectos_v1.Visible = true;
                    }
                    else
                        btnChkProyectos_v1.Visible = false;
                }
                else
                {
                    grdProyectos_v1.Visible = false;
                    btnChkProyectos_v1.Visible = false;

                    if (grdFuente.Rows.Count > 0)
                    {
                        grdFuente.Visible = true;
                        btnChkFuentes_v1.Text = "Marcar todos";
                        btnChkFuentes_v1.Visible = true;
                    }
                    else
                        btnChkFuentes_v1.Visible = false;
                }

                if (grdCapitulo.Rows.Count > 0)
                {
                    btnChkCapitulos_v1.Text = "Marcar todos";
                    btnChkCapitulos_v1.Visible = true;
                }
                else
                    btnChkCapitulos_v1.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void DDLReporte_v1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLReporte_v1.SelectedValue == "RP004")
            {
               
                grdFuente.Visible = false;
                btnChkFuentes_v1.Visible = false;

                grdProyectos_v1.Visible = true;

                if (grdProyectos_v1.Rows.Count > 0)
                {
                    btnChkProyectos_v1.Text = "Marcar todos";
                    btnChkProyectos_v1.Visible = true;
                }
                else
                    btnChkProyectos_v1.Visible = false;
            }
            else
            {
               
                grdProyectos_v1.Visible = false;
                btnChkProyectos_v1.Visible = false;

                if (grdFuente.Rows.Count > 0)
                {
                    grdFuente.Visible = true;
                    btnChkFuentes_v1.Text = "Marcar todos";
                    btnChkFuentes_v1.Visible = true;
                }
                else
                    btnChkFuentes_v1.Visible = false;
            }
           
        }
        protected void DDLDependencia_v13_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid(ref grdCapitulo_v13, 14);
            CargarGrid(ref grdFuentes_v13, 13);
            grdCapitulo_v13.Visible = true;
            grdFuentes_v13.Visible = true;

            if (grdCapitulo_v13.Rows.Count > 0)
            {
                btnChkCapitulos_v13.Text = "Marcar todos";
                btnChkCapitulos_v13.Visible = true;
            }
            else
                btnChkCapitulos_v13.Visible = false;

            if (grdFuentes_v13.Rows.Count > 0)
            {
                btnChkFuentes_v13.Text = "Marcar todos";
                btnChkFuentes_v13.Visible = true;
            }
            else
                btnChkFuentes_v13.Visible = false;
        }
        protected void DDLDependencia_v14_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid(ref grdCapitulos_v14, 15);
            CargarGrid(ref grdSubprogramas_v14, 16);
            grdCapitulos_v14.Visible = true;
            grdSubprogramas_v14.Visible = true;

            if (grdCapitulos_v14.Rows.Count > 0)
            {
                btnChkCapitulos_v14.Text = "Marcar todos";
                btnChkCapitulos_v14.Visible = true;
            }
            else
                btnChkCapitulos_v14.Visible = false;

            if (grdSubprogramas_v14.Rows.Count > 0)
            {
                btnChkSubprogramas_v14.Text = "Marcar todos";
                btnChkSubprogramas_v14.Visible = true;
            }
            else
                btnChkSubprogramas_v14.Visible = false;
        }
       
        private void CargarGrid(ref GridView grid, int idGrid)
        {
            lblError.Text = string.Empty;
            grid.DataSource = null;
            grid.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;
                grid.DataSource = GetList(idGrid);
                grid.DataBind();
                Celdas = new Int32[] { 1};
                if (grid.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
       
        public void rowFuente()
        {
            try
            {
                objReportes.Fuente = "0";
            foreach (GridViewRow row in grdFuente.Rows)
            {
                CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl("chkfuente");
                if (chkUrs_Disponibles.Checked == true)
                {
                        objReportes.Fuente  = objReportes.Fuente +","+ Convert.ToString(grdFuente.Rows[row.RowIndex].Cells[1].Text);

                    }
                }           

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
         }
        public void rowCapitulo()
        {
            try
            {
                objReportes.Capitulo = "0";
                foreach (GridViewRow row in grdCapitulo .Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl("chkcapitulo");
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        objReportes.Capitulo  = objReportes.Capitulo + "," + Convert.ToString(grdCapitulo.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowCapitulo(GridView Nombre_Grid, string Nombre_Checkbox)
        {
            try
            {
                
                objReportes.Capitulo = "0";
                foreach (GridViewRow row in Nombre_Grid.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl(Nombre_Checkbox);
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        objReportes.Capitulo = objReportes.Capitulo + "," + Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowFuente(GridView Nombre_Grid, string Nombre_Checkbox)
        {
            try
            {

                objReportes.Fuente = String.Empty;
                foreach (GridViewRow row in Nombre_Grid.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl(Nombre_Checkbox);
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        if (objReportes.Fuente == String.Empty)
                            objReportes.Fuente = Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                        else
                            objReportes.Fuente = objReportes.Fuente + "," + Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

                }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowPartida(GridView Nombre_Grid, string Nombre_Checkbox)
        {
            try
            {

                objReportes.Partida = string.Empty;
                foreach (GridViewRow row in Nombre_Grid.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl(Nombre_Checkbox);
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        if (objReportes.Partida == string.Empty)
                            objReportes.Partida = Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                        else
                            objReportes.Partida = objReportes.Partida + "," + Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowSubprograma(GridView Nombre_Grid, string Nombre_Checkbox)
        {
            try
            {

                objReportes.SubPrograma = "0";
                foreach (GridViewRow row in Nombre_Grid.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl(Nombre_Checkbox);
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        objReportes.SubPrograma = objReportes.SubPrograma + "," + Convert.ToString(Nombre_Grid.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowProyecto()
        {
            try
            {
                objReportes.Proyecto = "0";
                foreach (GridViewRow row in grdProyectos_v1.Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl("chkproyecto");
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        objReportes.Proyecto = objReportes.Proyecto + "," + Convert.ToString(grdProyectos_v1.Rows[row.RowIndex].Cells[1].Text);
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowParametros( ref string pCapitulo,ref string pFuente,ref string pProyecto)
        {
            try
            {
                pCapitulo = string.Empty;
                pFuente = string.Empty;
                pProyecto = string.Empty;
                List<string> Lista = new List<string>();
                Lista.Add("0");
                foreach (GridViewRow row in grdCapitulo_v9.Rows)
                {
                    CheckBox chkDisponible = (CheckBox)row.FindControl("chkCapitulo");
                    if (chkDisponible.Checked == true)
                    {
                        Lista.Add(Convert.ToString(grdCapitulo_v9.Rows[row.RowIndex].Cells[1].Text));
                    }
                }
                pCapitulo = string.Join(",", Lista);
                Lista.Clear();
                Lista.Add("0");
                foreach (GridViewRow row in grdProyecto_v9.Rows)
                {
                    CheckBox chkDisponible = (CheckBox)row.FindControl("chkProyecto");
                    if (chkDisponible.Checked == true)
                    {
                        Lista.Add(Convert.ToString(grdProyecto_v9.Rows[row.RowIndex].Cells[1].Text));
                    }
                }
                pProyecto = string.Join(",", Lista);
                Lista.Clear();
                Lista.Add("0");
                foreach (GridViewRow row in grdFuente_v9.Rows)
                {
                    CheckBox chkDisponible = (CheckBox)row.FindControl("chkFuente");
                    if (chkDisponible.Checked == true)
                    {
                        Lista.Add(Convert.ToString(grdFuente_v9.Rows[row.RowIndex].Cells[1].Text));
                    }
                }
                pFuente = string.Join(",", Lista);
                Lista.Clear();
                

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Pres_Reportes> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Reportes> List = new List<Pres_Reportes>();  
                objReportes.Dependencia = ddlDependencia.SelectedValue;
                objReportes.DependenciaF = ddlDependencia.SelectedValue;
                objReportes.Ejercicio = SesionUsu.Usu_Ejercicio;
                
                if (IdGrid == 0)
                    CNReportes.ConsultaGrid_Fuente_F(ref objReportes, ref List);
                else if (IdGrid == 1)
                    CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                else if (IdGrid == 5)
                    CNReportes.ConsultarGrid_RP008(ref objReportes, ref List, IdGrid);
                else if (IdGrid == 11)
                {
                    objReportes.Dependencia = DDLDependenciaInicial_v11.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependenciaFinal_v11.SelectedValue;
                    CNReportes.ConsultaGrid_Fuente_F(ref objReportes, ref List);
                }
                else if (IdGrid == 12)
                {
                    objReportes.Dependencia = DDLDependenciaInicial_v11.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependenciaFinal_v11.SelectedValue;
                    CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                }
                else if (IdGrid == 13)
                {
                    objReportes.Dependencia = DDLDependencia_v13.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependencia_v13.SelectedValue;
                    CNReportes.ConsultaGrid_Fuente_F(ref objReportes, ref List);
                }
                else if (IdGrid == 14)
                {
                    objReportes.Dependencia = DDLDependencia_v13.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependencia_v13.SelectedValue;
                    CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                }
                else if (IdGrid == 15)
                {
                    objReportes.Dependencia = DDLDependencia_v14.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependencia_v14.SelectedValue;
                    CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                }
                else if (IdGrid == 16)
                {
                    objReportes.Dependencia = DDLDependencia_v14.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependencia_v14.SelectedValue;
                    CNReportes.ConsultaGrid_Subprograma(ref objReportes, ref List);
                }
                else if (IdGrid == 18)
                {
                    objReportes.Dependencia = DDLDependenciaInicial_v12.SelectedValue; ;
                    objReportes.DependenciaF = DDLDependenciaFinal_v12.SelectedValue;
                    CNReportes.ConsultaGrid_Fuente_F(ref objReportes, ref List);
                }
                else if (IdGrid == 19)
                {
                    objReportes.Dependencia = DDLCentro_Contable_v8.SelectedValue; 
                    objReportes.DependenciaF = DDLCentro_Contable_v8.SelectedValue;
                    objReportes.Tipo = DDLTipoCedula_v8.SelectedValue;
                    objReportes.Mes_anio =DDLMes_v8.SelectedValue+objReportes.Ejercicio.Substring(2,2);
                    objReportes.Estatus =DDLStatus_v8.SelectedValue;
                    CNReportes.ConsultaGrid_Fuente_x_Centro(ref objReportes, ref List);
                }
                else if (IdGrid == 20)
                {
                    objReportes.Dependencia = DDLCentro_Contable_v8.SelectedValue;
                    objReportes.DependenciaF = DDLCentro_Contable_v8.SelectedValue;
                    objReportes.Tipo = DDLTipoCedula_v8.SelectedValue;
                    objReportes.Mes_anio = DDLMes_v8.SelectedValue + objReportes.Ejercicio.Substring(2, 2);
                    objReportes.Estatus = DDLStatus_v8.SelectedValue;
                    CNReportes.ConsultaGrid_Partida_x_Centro(ref objReportes, ref List);
                }
                else
                {
                    objReportes.Dependencia = DDLDependencia_v9.SelectedValue;
                    CNReportes.ConsultarGrid_RP008(ref objReportes, ref List, IdGrid);
                }

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void excel_temporal_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-TEMPORAL":
                    string ruta1 = string.Empty;
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-007XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
                    break;
                case "RP-PLA-01":
                    string ruta11 = string.Empty;
                    ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-008XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open11 = "window.open('" + ruta11 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open11, true);
                    break;
                case "RP-008":
                    string ruta12 = string.Empty;
                    ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-008XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open12 = "window.open('" + ruta11 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open12, true);
                    break;
            }
            }

        protected void pdf_tempo_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-007":
                    string ruta1 = string.Empty;
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-007&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
                    break;
                case "RP-008":
                    string ruta11 = string.Empty;
                    ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-008&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open11 = "window.open('" + ruta11 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open11, true);
                    break;
                case "RP-008-A":
                    string ruta3 = string.Empty;
                    ruta3 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-008-A&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open3 = "window.open('" + ruta3 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open3, true);
                    break;
                case "RP-008-CAL":
                    string ruta2 = string.Empty;
                    ruta2 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-008-CAL&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Nomina=" + DDL_Nomina.SelectedValue + "&Tipo_p=" + DDL_Tipo.SelectedValue + "&Status=" + DDL_Status.SelectedValue;
                    string _open2 = "window.open('" + ruta2 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open2, true);
                    break;
            }            
        }
        protected void DDL_Quincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PRES.Obt_Combo_Nomina", ref DDL_Nomina, "p_ejercicio", "P_Quincena", "P_Tipo", SesionUsu.Usu_Ejercicio, DDL_Quincena.SelectedValue, DDL_Tipo.SelectedValue, "DPP");
        }
        protected void DDL_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PRES.Obt_Combo_Nomina", ref DDL_Nomina, "p_ejercicio", "P_Quincena","P_Tipo", SesionUsu.Usu_Ejercicio, DDL_Quincena.SelectedValue, DDL_Tipo.SelectedValue, "DPP");
        }
        protected void DDL_Nomina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DDLTipoReporte_v7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Mayor_Comparativo", ref DDLCuentas_v7, "p_reporte", DDLTipoReporte_v7.SelectedValue);
        }
        protected void DDLFiltro_v8_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdDatos_v8.Visible = false;
            btnChkDatos_v8.Visible = false;
            if (DDLFiltro_v8.SelectedValue!="T")
            {
                if(DDLFiltro_v8.SelectedValue == "F")
                    CargarGrid(ref grdDatos_v8, 19 );
                else
                    CargarGrid(ref grdDatos_v8, 20);

                if (grdDatos_v8.Rows.Count > 0)
                {
                    grdDatos_v8.Visible = true;
                    btnChkDatos_v8.Text = "Marcar todos";
                    btnChkDatos_v8.Visible = true;
                }
                
                    
               
            }
           
        }

        protected void excel_temporal0_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-009":
                    if(ddlSemestre9.SelectedValue=="1")
                    {
                        string ruta11 = string.Empty;
                        ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-009-1&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                        string _open11 = "window.open('" + ruta11 + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open11, true);
                    }
                    else
                    {
                        string ruta11 = string.Empty;
                        ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-009-2&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                        string _open11 = "window.open('" + ruta11 + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open11, true);
                    }                   
                    break;
                case "RP-004":
                    string ruta = string.Empty;                   
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-004XLS&Ejercicio=" + ddlEjercicio.SelectedValue + "&tipo_p=" + DDL_Tipo0.SelectedValue + "&Status=" + DDL_Status1.SelectedValue;
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "RP-005":
                    string ruta12 = string.Empty;
                    ruta12 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-005XLS&Ejercicio=" + ddlEjercicio.SelectedValue;
                    string _open12 = "window.open('" + ruta12 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open12, true);
                    break;
            }        
        }
        protected void pdf_tempo0_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-004":
                    string ruta = string.Empty;
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-004&Ejercicio=" + ddlEjercicio.SelectedValue + "&tipo_p=" + DDL_Tipo0.SelectedValue + "&Status=" + DDL_Status1.SelectedValue;
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "RP-009":
                    if (ddlSemestre9.SelectedValue == "1")
                    {
                        string ruta11 = string.Empty;
                        ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-009-1&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                        string _open11 = "window.open('" + ruta11 + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open11, true);
                    }
                    else
                    {
                        string ruta11 = string.Empty;
                        ruta11 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-009-2&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                        string _open11 = "window.open('" + ruta11 + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open11, true);
                    }
                    break;
                case "RP-013":
                    string ruta2 = string.Empty;
                    ruta2 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-013&Ejercicio=" + ddlEjercicio.SelectedValue + "&tipo_p=" + DDL_Tipo0.SelectedValue;
                    string _open2 = "window.open('" + ruta2 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open2, true);
                    break;
            }
        }
        protected void excel_temporal1_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void pdf_tempo1_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void pdf_tempo2_Click(object sender, ImageClickEventArgs e)
        {           
            string caseSwitch = SesionUsu.Usu_Rep;
            if (ddltipo_plantilla.SelectedValue=="P")            
            { tipo_plantilla = "P"; }
            else
            { tipo_plantilla = ""; }           
            switch (caseSwitch)
            {
                case "RP-005":
                    string ruta12 = string.Empty;
                    ruta12 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-005&SEMESTRE=" + DDLSemestre.SelectedValue + "&DEPENDENCIA=" + DDLDependencia0.SelectedItem.Text;
                    string _open12 = "window.open('" + ruta12 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open12, true);
                    break;
                case "RP-006":
                    string ruta1 = string.Empty;
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-006&DEPENDENCIA=" + DDLDependencia0.SelectedItem.Text;
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
                    break;
                case "RP-015":
                    string ruta15 = string.Empty;
                    ruta15 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-015"+ tipo_plantilla + "&SEMESTRE=" + DDLSemestre.SelectedItem.Text + "&DEPENDENCIA=" + DDLDependencia0.SelectedItem.Text;
                    string _open15 = "window.open('" + ruta15 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open15, true);
                    break;
                case "RP-016":
                    string ruta13 = string.Empty;
                    ruta13 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-016" + tipo_plantilla + "&SEMESTRE=" + DDLSemestre.SelectedItem.Text + "&DEPENDENCIA=" + DDLDependencia0.SelectedItem.Text;
                    string _open13 = "window.open('" + ruta13 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open13, true);
                    break;
                case "RP-017":
                    string ruta14 = string.Empty;
                    ruta14 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-017" + tipo_plantilla + "&SEMESTRE=" + DDLSemestre.SelectedItem.Text + "&DEPENDENCIA=" + DDLDependencia0.SelectedItem.Text;
                    string _open14 = "window.open('" + ruta14 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open14, true);
                    break;
            }
        }
        protected void pdf_tempo3_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-012":
                    string ruta1 = string.Empty;
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012&TIPO_P=" + DDL_Tipo2.SelectedValue;
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
                    break;
            }
        }
        protected void excel_temporal2_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-012":
                    string ruta1 = string.Empty;
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012XLS&TIPO_P=" + DDL_Tipo2.SelectedValue;
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
                    break;
            }
        }
        protected void Grafica_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-012":
                    string ruta1 = string.Empty;
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012GRAF";
                    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
                    break;
            }
        }

        protected void btnPDF_v7_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;
            switch (DDLTipoReporte_v7.SelectedValue)
            {
                case "CC":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_COMPARATIVO_CUENTA&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v7.SelectedValue + "&MesIni=" + DDLMes_Inicial_v7.SelectedValue+SesionUsu.Usu_Ejercicio.Substring(2,2) + "&MesFin=" + DDLMes_Final_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Mayor=" + DDLCuentas_v7.SelectedValue;
                    break;
                case "GC":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_COMPARATIVO_CAPITULO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v7.SelectedValue + "&MesIni=" + DDLMes_Inicial_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + DDLMes_Final_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Mayor=" + DDLCuentas_v7.SelectedValue;
                    break;
                    
            }
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void btnXLS_v7_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;
            switch (DDLTipoReporte_v7.SelectedValue)
            {
                case "CC":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_COMPARATIVO_CUENTA_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v7.SelectedValue + "&MesIni=" + DDLMes_Inicial_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + DDLMes_Final_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Mayor=" + DDLCuentas_v7.SelectedValue;
                    break;
                case "GC":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_COMPARATIVO_CAPITULO_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v7.SelectedValue + "&MesIni=" + DDLMes_Inicial_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + DDLMes_Final_v7.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Mayor=" + DDLCuentas_v7.SelectedValue;
                    break;

            }
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void btnPDF_v8_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;
            if (DDLStatus_v8.SelectedValue == "DF")
            {

            }
            else
            {
                
                switch (DDLFiltro_v8.SelectedValue)
                {
                    case "T":
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LISTADO_CEDULAS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v8.SelectedValue + "&MesIni=" + DDLMes_v8.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&TipoDoc=" + DDLTipoCedula_v8.SelectedValue + "&Status=" + DDLStatus_v8.SelectedValue;
                        break;
                    case "F":
                        rowFuente(grdDatos_v8, "chkDatos_v8");
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LISTADO_CEDULAS_F&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v8.SelectedValue + "&MesIni=" + DDLMes_v8.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&TipoDoc=" + DDLTipoCedula_v8.SelectedValue + "&Status=" + DDLStatus_v8.SelectedValue + "&Fuente=" + objReportes.Fuente;
                        break;
                    case "P":
                        rowPartida(grdDatos_v8, "chkDatos_v8");
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LISTADO_CEDULAS_P&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v8.SelectedValue + "&MesIni=" + DDLMes_v8.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&TipoDoc=" + DDLTipoCedula_v8.SelectedValue + "&Status=" + DDLStatus_v8.SelectedValue + "&Partida=" + objReportes.Partida;
                        break;
                }
            }
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void btnXLS_v8_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;
            if (DDLStatus_v8.SelectedValue == "DF")
            {

            }
            else
            {
                switch (DDLFiltro_v8.SelectedValue)
                {
                    case "T":
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LISTADO_CEDULAS_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v8.SelectedValue + "&MesIni=" + DDLMes_v8.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&TipoDoc=" + DDLTipoCedula_v8.SelectedValue + "&Status=" + DDLStatus_v8.SelectedValue;
                        break;
                    case "F":
                        rowFuente(grdDatos_v8, "chkDatos_v8");
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LISTADO_CEDULAS_F_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v8.SelectedValue + "&MesIni=" + DDLMes_v8.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&TipoDoc=" + DDLTipoCedula_v8.SelectedValue + "&Status=" + DDLStatus_v8.SelectedValue + "&Fuente=" + objReportes.Fuente;
                        break;
                    case "P":
                        rowPartida(grdDatos_v8, "chkDatos_v8");
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LISTADO_CEDULAS_P_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentro_Contable_v8.SelectedValue + "&MesIni=" + DDLMes_v8.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&TipoDoc=" + DDLTipoCedula_v8.SelectedValue + "&Status=" + DDLStatus_v8.SelectedValue + "&Partida=" + objReportes.Partida;
                        break;
                }
            }
            string _open1 = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }

        protected void imgBttnPdf_v9_click(object sender, ImageClickEventArgs e)
        {
            //try
            //{
            //    string parametroCapitulo = string.Empty; 
            //    string parametroFuente = string.Empty; 
            //    string parametroProyecto = string.Empty; 
            //    rowParametros(ref parametroCapitulo, ref parametroFuente, ref parametroProyecto);
            //    string ruta1 = string.Empty;
            //   if(DDLPeriodo_v9.SelectedValue=="M")
            //    ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008M&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
            //   else
            //     ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008A&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
            //    string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message;
            //}
            try
            {
                string reporte = Request.QueryString["P_REP"];
                string parametroCapitulo = string.Empty;
                string parametroFuente = string.Empty;
                string parametroProyecto = string.Empty;
                string ruta1 = string.Empty;
                rowParametros(ref parametroCapitulo, ref parametroFuente, ref parametroProyecto);

                if (reporte == "RP-PRESUP_RP008")
                {


                    if (DDLPeriodo_v9.SelectedValue == "M")
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008MD&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008MR&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                    else
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008AD&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008AR&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }

                }
                else if (reporte == "RP-PRESUP_RP005")
                {
                    if (DDLPeriodo_v9.SelectedValue == "M")
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005MD&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005MR&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                    else
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005AD&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005AR&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                }
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void imgBttnExcel_v9_click(object sender, ImageClickEventArgs e)
        {
            try
            {
               string reporte = Request.QueryString["P_REP"];
                string parametroCapitulo = string.Empty;
                string parametroFuente = string.Empty;
                string parametroProyecto = string.Empty;
                string ruta1 = string.Empty;
                rowParametros(ref parametroCapitulo, ref parametroFuente, ref parametroProyecto);

                if (reporte== "RP-PRESUP_RP008")
                {
                    
                    
                    if (DDLPeriodo_v9.SelectedValue == "M")
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008MD_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008MR_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                    else
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008AD_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP008AR_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Proyecto=" + parametroProyecto + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                   
                }
                else if (reporte == "RP-PRESUP_RP005")
                {
                    if (DDLPeriodo_v9.SelectedValue == "M")
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005MD_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005MR_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                    else
                    {
                        if (DDLReporte_v9.SelectedValue == "DET")
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005AD_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                        else
                            ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP005AR_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + parametroFuente + "&Capitulo=" + parametroCapitulo + "&Ministrable=" + DDLMinistrable_v9.SelectedValue + "&Dependencia=" + DDLDependencia_v9.SelectedValue + "&MesIni=" + DDLMes_v9.SelectedValue;
                    }
                }
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void imgBttnPDF_v10_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (DDLReporte_v10.SelectedValue == "RP019B")
                ruta="";
            else if (DDLReporte_v10.SelectedValue == "RP019A")
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP019&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentroContable_v10.SelectedValue + "&MesIni=" + DDLMes_v10.SelectedValue  + "&TipoDoc=C" ;
            else
                    ruta = "";
                

            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnXLS_v10_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (DDLReporte_v10.SelectedValue == "RP019B")
                ruta = "";
            else if (DDLReporte_v10.SelectedValue == "RP019A")
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP019_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&CentroContable=" + DDLCentroContable_v10.SelectedValue + "&MesIni=" + DDLMes_v10.SelectedValue + "&TipoDoc=C";
            else
                ruta = "";


            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPdf_v11(object sender, ImageClickEventArgs e)
        {
            rowCapitulo(grdCapitulo_v11, "chkCapitulo_v11");
            rowFuente(grdFuente_v11, "chkFuente_v11");
            string ruta = string.Empty;

            if (DDLReporte_v11.SelectedValue == "RP009A")
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP009A&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependenciaInicial_v11.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v11.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente; 
            else 
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP009B&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependenciaInicial_v11.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v11.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente;

            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnExcel_v11(object sender, ImageClickEventArgs e)
        {
            rowCapitulo(grdCapitulo_v11, "chkCapitulo_v11");
            rowFuente(grdFuente_v11, "chkFuente_v11");
            string ruta = string.Empty;

            if (DDLReporte_v11.SelectedValue == "RP009A")
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP009A_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependenciaInicial_v11.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v11.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente; 
            else 
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP009B_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependenciaInicial_v11.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v11.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente;

            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        
        protected void btnBuscar_v11_Click(object sender, EventArgs e)
        {
            CargarGrid(ref grdCapitulo_v11,12);
            CargarGrid(ref grdFuente_v11, 11);
            grdCapitulo_v11.Visible = true;
            grdFuente_v11.Visible = true;

            if (grdCapitulo_v11.Rows.Count > 0)
            {
                btnChkCapitulos_v11.Text = "Marcar todos";
                btnChkCapitulos_v11.Visible = true;
            }
            else
                btnChkCapitulos_v11.Visible = false;

            if (grdFuente_v11.Rows.Count > 0)
            {
                btnChkFuentes_v11.Text = "Marcar todos";
                btnChkFuentes_v11.Visible = true;
            }
            else
                btnChkFuentes_v11.Visible = false;
        }
        protected void btnBuscar_v12_Click(object sender, EventArgs e)
        {
           
            CargarGrid(ref grdFuente_v12, 18);
           
            grdFuente_v12.Visible = true;

            if (grdFuente_v12.Rows.Count > 0)
            {
                btnChkFuentes_v12.Text = "Marcar todos";
                btnChkFuentes_v12.Visible = true;
            }
            else
                btnChkFuentes_v12.Visible = false;
        }

        protected void imgBttnPDF_v12_Click(object sender, ImageClickEventArgs e)
        {
            
            rowFuente(grdFuente_v12, "chkFuente_v12");
            string ruta = string.Empty;

            if (DDLTipo_v12.SelectedValue == "A")
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP017A&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&MesIni=" + DDLMes_v12.SelectedValue + "&CentroContable=" + DDLCentroContable_v12.SelectedValue + "&Dependencia=" + DDLDependenciaInicial_v12.SelectedValue+ "&Dependencia_F=" + DDLDependenciaFinal_v12.SelectedValue+ "&Fuente=" + objReportes.Fuente; 
            else
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP017M&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&MesIni=" + DDLMes_v12.SelectedValue + "&CentroContable=" + DDLCentroContable_v12.SelectedValue + "&Dependencia=" + DDLDependenciaInicial_v12.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v12.SelectedValue + "&Fuente=" + objReportes.Fuente;

            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnXLS_v12_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (DDLTipo_v12.SelectedValue == "A")
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP017A_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&MesIni=" + DDLMes_v12.SelectedValue + "&CentroContable=" + DDLCentroContable_v12.SelectedValue + "&Dependencia=" + DDLDependenciaInicial_v12.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v12.SelectedValue + "&Fuente=" + objReportes.Fuente;
            else
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP017M_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&MesIni=" + DDLMes_v12.SelectedValue + "&CentroContable=" + DDLCentroContable_v12.SelectedValue + "&Dependencia=" + DDLDependenciaInicial_v12.SelectedValue + "&Dependencia_F=" + DDLDependenciaFinal_v12.SelectedValue + "&Fuente=" + objReportes.Fuente;

            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }


        protected void imgBttnPdf_v13(object sender, ImageClickEventArgs e)
        {
            rowCapitulo(grdCapitulo_v13, "chkCapitulo_v13");
            rowFuente(grdFuentes_v13, "chkFuente_v13");
            string ruta = string.Empty;

            switch (DDLReporte_v13.SelectedValue)
            {
                case "SP01":
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP01&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                        + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;
                case "SP02":
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP02&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                        + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;
                case "SP03":
                    break;
                case "SP04":
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP04&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                        + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;
                case "SP05":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP05&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                       + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;

            }
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnExcel_v13(object sender, ImageClickEventArgs e)
        {
            rowCapitulo(grdCapitulo_v13, "chkCapitulo_v13");
            rowFuente(grdFuentes_v13, "chkFuente_v13");
            string ruta = string.Empty;

            switch (DDLReporte_v13.SelectedValue)
            {
                case "SP01":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP01_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                    + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;
                case "SP02":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP02_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                    + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;
                case "SP03":
                    break;
                case "SP04":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP04_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                    + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;
                case "SP05":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_SP05_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v13.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Fuente=" + objReportes.Fuente
                       + "&MesIni=" + DDLMesIni_Modificado.SelectedValue + DDLMesIni_Ejercido.SelectedValue + "&MesFin=" + DDLMesFin_Modificado.SelectedValue + DDLMesFin_Ejercido.SelectedValue + "&Meses=" + txtFechaEntrega.Text;
                    break;

            }
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPdf_v14(object sender, ImageClickEventArgs e)
        {
            rowCapitulo(grdCapitulos_v14, "chkCapitulo_v14");
            rowSubprograma(grdSubprogramas_v14, "chkSubprograma_v14");
            string ruta = string.Empty;
                        
            ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP003&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v14.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Subprograma=" + objReportes.SubPrograma + "&TipoDoc=" + DDLTipo_v14.SelectedValue;
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnExcel_v14(object sender, ImageClickEventArgs e)
        {
            rowCapitulo(grdCapitulos_v14, "chkCapitulo_v14");
            rowSubprograma(grdSubprogramas_v14, "chkSubprograma_v14");
            string ruta = string.Empty;

            ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_RP003_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Dependencia=" + DDLDependencia_v14.SelectedValue + "&Capitulo=" + objReportes.Capitulo + "&Subprograma=" + objReportes.SubPrograma + "&TipoDoc=" + DDLTipo_v14.SelectedValue;
            string _open1 = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void btnChkCapitulos_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnchkCapitulos.Text == "Marcar todos")
            {
                btnchkCapitulos.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnchkCapitulos.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdCapitulo_v9.Rows)
            {
                CheckBox check_box = row.FindControl("chkCapitulo") as CheckBox;
                check_box.Checked = check;
            }
        }
        protected void btnChkCapitulos_v1_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkCapitulos_v1.Text == "Marcar todos")
            {
                btnChkCapitulos_v1.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkCapitulos_v1.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdCapitulo.Rows)
            {
                CheckBox check_box = row.FindControl("chkcapitulo") as CheckBox;
                check_box.Checked = check;
            }
        }
        protected void btnChkProyectos_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnchkProyectos.Text == "Marcar todos")
            {
                btnchkProyectos.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnchkProyectos.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdProyecto_v9.Rows)
            {
                CheckBox check_box = row.FindControl("chkProyecto") as CheckBox;
                check_box.Checked = check;
            }
        }

        protected void btnChkFuentes_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnchkFuentes.Text == "Marcar todos")
            {
                btnchkFuentes.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnchkFuentes.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdFuente_v9.Rows)
            {
                CheckBox check_box = row.FindControl("chkFuente") as CheckBox;
                check_box.Checked = check;
            }
        }

        protected void btnChkFuentes_v1_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkFuentes_v1.Text == "Marcar todos")
            {
                btnChkFuentes_v1.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkFuentes_v1.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdFuente.Rows)
            {
                CheckBox check_box = row.FindControl("chkfuente") as CheckBox;
                check_box.Checked = check;
            }
        }

        protected void btnChkProyectos_v1_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkProyectos_v1.Text == "Marcar todos")
            {
                btnChkProyectos_v1.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkProyectos_v1.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdProyectos_v1.Rows)
            {
                CheckBox check_box = row.FindControl("chkproyecto") as CheckBox;
                check_box.Checked = check;
            }
        }
        protected void btnChkDatos_v8_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkDatos_v8.Text == "Marcar todos")
            {
                btnChkDatos_v8.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkDatos_v8.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdDatos_v8.Rows)
            {
                CheckBox check_box = row.FindControl("chkDatos_v8") as CheckBox;
                check_box.Checked = check;
            }
        }
        protected void btnChkFuentes_v11_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkFuentes_v11.Text == "Marcar todos")
            {
                btnChkFuentes_v11.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkFuentes_v11.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdFuente_v11.Rows)
            {
                CheckBox check_box = row.FindControl("chkFuente_v11") as CheckBox;
                check_box.Checked = check;
            }
        }

        protected void btnChkCapitulos_v11_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkCapitulos_v11.Text == "Marcar todos")
            {
                btnChkCapitulos_v11.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkCapitulos_v11.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdCapitulo_v11.Rows)
            {
                CheckBox check_box = row.FindControl("chkCapitulo_v11") as CheckBox;
                check_box.Checked = check;
            }
        }
        protected void DDLCentroContable_v12_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Dependencia_x_Centro", ref DDLDependenciaInicial_v12, "p_centro_contable", "p_usuario", DDLCentroContable_v12.SelectedValue, SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("pkg_presupuesto.Obt_Combo_Dependencia_x_Centro", ref DDLDependenciaFinal_v12, "p_centro_contable", "p_usuario", DDLCentroContable_v12.SelectedValue, SesionUsu.Usu_Nombre);
            grdFuente_v12.Visible = false;
            btnChkFuentes_v12.Visible = false;
        }
        protected void btnChkFuentes_v12_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkFuentes_v12.Text == "Marcar todos")
            {
                btnChkFuentes_v12.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkFuentes_v12.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdFuente_v12.Rows)
            {
                CheckBox check_box = row.FindControl("chkFuente_v12") as CheckBox;
                check_box.Checked = check;
            }
        }
        protected void btnChkCapitulos_v13_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkCapitulos_v13.Text == "Marcar todos")
            {
                btnChkCapitulos_v13.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkCapitulos_v13.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdCapitulo_v13.Rows)
            {
                CheckBox check_box = row.FindControl("chkCapitulo_v13") as CheckBox;
                check_box.Checked = check;
            }
        }

        protected void btnChkFuentes_v13_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkFuentes_v13.Text == "Marcar todos")
            {
                btnChkFuentes_v13.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkFuentes_v13.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdFuentes_v13.Rows)
            {
                CheckBox check_box = row.FindControl("chkFuente_v13") as CheckBox;
                check_box.Checked = check;
            }
        }

       
        protected void btnChkCapitulos_v14_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkCapitulos_v14.Text == "Marcar todos")
            {
                btnChkCapitulos_v14.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkCapitulos_v14.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdCapitulos_v14.Rows)
            {
                CheckBox check_box = row.FindControl("chkCapitulo_v14") as CheckBox;
                check_box.Checked = check;
            }
        }

        protected void btnChkSubprogramas_v14_Click(object sender, EventArgs e)
        {
            bool check;
            if (btnChkSubprogramas_v14.Text == "Marcar todos")
            {
                btnChkSubprogramas_v14.Text = "Quitar todos";
                check = true;
            }
            else
            {
                btnChkSubprogramas_v14.Text = "Marcar todos";
                check = false;
            }
            foreach (GridViewRow row in grdSubprogramas_v14.Rows)
            {
                CheckBox check_box = row.FindControl("chkSubprograma_v14") as CheckBox;
                check_box.Checked = check;
            }
        }

       
    }
}