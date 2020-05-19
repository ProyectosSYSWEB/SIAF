using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Patrimonio.Reportes
{
    public partial class frmCatReportes : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        string ruta, _open;
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables

        #endregion      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SesionUsu = (Sesion)Session["Usuario"];
                if (!IsPostBack)
                {
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Basicos", ref ddltipo, "p_tipo", "PAT_CAT_ALTAS", ref Listcodigo);
                    ddltipo.Items.Insert(0,new ListItem("TODOS","T"));
                    CNComun.LlenaCombo("PKG_PATRIMONIO.OBT_Combo_Tipo_bien", ref DDLtipo_bien);
                    inicializar();
                }
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                lblError.Text = ex.Message;
            }
        }
        protected void inicializar()
        {
            try
            {

                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
                string caseSwitch = SesionUsu.Usu_Rep;
                switch (caseSwitch)
                {
                    case "RP-101":
                        MultiView1.ActiveViewIndex = 0;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        lblIF07.Visible = false;
                        DDLTipo_IF07.Visible = false;
                        lblCuenta.Visible = true;
                        DDLCuentas.Visible = true;
                        DDLCuentas.SelectedValue = "0000";
                        txtMes_inicial.Text = "31/12/1995";
                        txtMes_final.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                        break;

                    case "RP-IF07":
                        MultiView1.ActiveViewIndex = 0;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        txtMes_inicial.Text = "31/12/1995";
                        txtMes_final.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                        lblIF07.Visible = true;
                        DDLTipo_IF07.Visible = true;
                        lblCuenta.Visible = false;
                        DDLCuentas.Visible = false;
                        break;

                    case "RP-102":
                        MultiView1.ActiveViewIndex = 1;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentroContable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        break;
                    case "RP-103":
                        MultiView1.ActiveViewIndex = 2;
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref ddldependencia, "p_usuario", SesionUsu.Usu_Nombre);
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Responsable", ref ddlresponsable, "p_dependencia", "p_tipo", ddldependencia.SelectedValue, "2");
                        break;
                    case "RP-103T":
                        MultiView1.ActiveViewIndex = 2;
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref ddldependencia, "p_usuario", SesionUsu.Usu_Nombre);
                        Label7.Visible = false;
                        ddlresponsable.Visible = false;
                        break;
                    case "RP-109A":
                        MultiView1.ActiveViewIndex = 8;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contab, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        CNComun.LlenaCombo("pkg_patrimonio.obt_combo_categoria", ref DDLCategoria);
                        DDLCategoria.Items.Insert(2,new ListItem("TODOS","T"));
                        txtFIInventario.Text = "31/12/1995";
                        txtFFInventario.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                        break;
                    case "RP-110A":
                        MultiView1.ActiveViewIndex = 3;
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref DDLDependenciaX, "p_usuario", SesionUsu.Usu_Nombre);
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Centro_trabajo", ref DDLcentro_trab, "p_dependencia", "p_ocupados", DDLDependenciaX.SelectedValue, "SI");
                        CNComun.LlenaCombo("pkg_patrimonio.obt_combo_categoria", ref DDLCategoriaCC);
                        DDLCategoriaCC.Items.Insert(2, new ListItem("TODOS", "T"));
                        DDLcuenta_mayor.SelectedValue = "0";
                        DDLcentro_trab.SelectedValue = "000";
                        txtfecha_iniCC.Text = "31/12/1995";
                        txt_fecha_finCC.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                        break;
                    case "RP-110":
                        MultiView1.ActiveViewIndex = 4;
                        Label16.Text = "Dependencia:";
                        Label19.Text = "Fecha de Corte:";
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref ddldependencia0, "p_usuario", SesionUsu.Usu_Nombre);
                        break;
                    case "RP-Comparativo":
                        MultiView1.ActiveViewIndex = 5;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCContable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        DDLMes_Inicial.SelectedValue = "01";
                        DDLMes_Inicial.Enabled = false;
                        DDLMes_Final.SelectedValue = "01";
                        DDLComparativo.SelectedValue = "01";
                        btnComparaPresupuestoXLS.Visible = false;
                        btnComparaContaXLS.Visible = true;
                        break;

                    case "RP-Comparativo-Pres":
                        MultiView1.ActiveViewIndex = 5;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCContable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        DDLComparativo.Visible = false;
                        DDLComparativoTipo.Visible = true;
                        btnComparaPresupuestoXLS.Visible = true;
                        btnComparaContaXLS.Visible = false;
                        break;

                    case "RP-Resguardos":
                        MultiView1.ActiveViewIndex = 6;
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref DDLDepResguardos, "p_usuario", SesionUsu.Usu_Nombre);
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Centro_trabajo", ref DDLCentrosTrabajo, "p_dependencia", "p_ocupados", DDLDepResguardos.SelectedValue, "SI");
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Responsable", ref DDLResponsables, "p_dependencia", "p_tipo", DDLDepResguardos.SelectedValue, "2");
                        lblCT.Visible = false;
                        DDLCentrosTrabajo.Visible = false;
                        lblResp.Visible = false;
                        DDLResponsables.Visible = false;
                        break;

                    case "RP-Etiquetas":
                        MultiView1.ActiveViewIndex = 7;
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref DDL_Etiquetas_Dependencia, "p_usuario", SesionUsu.Usu_Nombre);
                        lblEtiquetas_Dependencia.Visible = false;
                        DDL_Etiquetas_Dependencia.Visible = false;
                        lblEtiquetas_Fec_Ini.Visible = false;
                        txtFecha_Ini.Visible = false;
                        lblEtiquetas_Fec_Fin.Visible = false;
                        txtFecha_Fin.Visible = false;
                        Image8.Visible = false;
                        Image9.Visible = false;
                        txtFecha_Ini.Text = "31/12/1995";
                        txtFecha_Fin.Text= System.DateTime.Now.ToString("dd/MM/yyyy");
                        break;

                    case "RP-Comparativo_AF":
                        MultiView1.ActiveViewIndex = 10;
                        lblMesInicial_ActivoFijo.Visible = false;
                        DDLMesInicial_ActivoFijo.Visible = false;
                        break;
                    case "RP-UMAS":
                        MultiView1.ActiveViewIndex = 11;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentroContable_Gasto, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_EjercicioUMA", ref DDLEjercicio_Gasto);
                        break;
                    case "RP-EntregaRecepcion":
                        MultiView1.ActiveViewIndex = 4;
                        Label16.Text = "Centro Contable:";
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref ddldependencia0, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                        DDLtipo_bien.Items.Insert(8, new ListItem("RESUMEN DE BIENES MUEBLES E INTANGIBLES", "10"));
                        break;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
                string caseSwitch = SesionUsu.Usu_Rep;               
                switch (caseSwitch)
                {

                    case "RP-101":
                        
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-101&centro_contable=" + DDLCentro_Contable.SelectedValue +"&cuenta_mayor=" + DDLCuentas.SelectedValue+"&mes_inicial=" + txtMes_inicial.Text + "&mes_final=" + txtMes_final.Text;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                       // ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Verdiario_analitico_bienes('RP-101','" + DDLCentro_Contable.SelectedValue + "','" + txtMes_inicial.Text + "', '" + txtMes_final.Text + "');", true);

                        break;

                    case "RP-IF07":
                        if(DDLTipo_IF07.SelectedValue=="G")
                            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-IF07&centro_contable=" + DDLCentro_Contable.SelectedValue + "&Ejercicio=" +SesionUsu.Usu_Ejercicio + "&mes_final=" + txtMes_final.Text + "&mes_inicial=" + txtMes_inicial.Text;
                        else
                            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-IF07Cuenta&centro_contable=" + DDLCentro_Contable.SelectedValue + "&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_final=" + txtMes_final.Text + "&mes_inicial=" + txtMes_inicial.Text;

                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                        break;

                }

                        }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        protected void btnInventario_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
                string caseSwitch = SesionUsu.Usu_Rep;
               
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-109A&centro_contable=" + DDLCentro_Contab.SelectedValue + "&mes_inicial=" + txtFIInventario.Text + "&mes_final=" + txtFFInventario.Text + "&categoria=" + DDLCategoria.SelectedValue;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        protected void btnInventarioXLS_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
                string caseSwitch = SesionUsu.Usu_Rep;

                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-109AXLS&centro_contable=" + DDLCentro_Contab.SelectedValue + "&mes_inicial=" + txtFIInventario.Text + "&mes_final=" + txtFFInventario.Text + "&categoria=" + DDLCategoria.SelectedValue;
                _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        protected void btnTranspXLS_Click(object sender, ImageClickEventArgs e)
        {
            

        }

        protected void txtmes_inicial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btnAceptar0_Click(object sender, ImageClickEventArgs e)
        {
           // string clave = Listcodigo[ddltipo.SelectedIndex].EtiquetaDos;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Veracumulado_de_activos_bajas('RP-102','" + txtMes_inicial0.Text + "', '" + txtMes_final0.Text + "', '" + clave + "', '" + ddltipo_consulta.SelectedValue + "', '" + DDLCentroContable.SelectedValue + "');", true);
            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-102&mes_inicial=" + txtMes_inicial0.Text + "&mes_final=" + txtMes_final0.Text + "&clave=" + ddltipo.SelectedValue + "&status=" + ddltipo_consulta.SelectedValue + "&centro_contable=" + DDLCentroContable.SelectedValue;
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void ddldependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Responsable", ref ddlresponsable, "p_dependencia", "p_tipo", ddldependencia.SelectedValue, "2");
        }

        protected void btnAceptar1_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-103":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-103&responsable=" + ddlresponsable.SelectedValue + "&status=" + ddlstatus.SelectedValue + "&dependencia=" + ddldependencia.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "RP-103T":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-103T&status=" + ddlstatus.SelectedValue + "&dependencia=" + ddldependencia.SelectedItem.ToString();
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
            }


            }

        protected void ddltipo_consulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string STAT;
            if (Convert.ToString(ddltipo_consulta.SelectedValue) == "A")
            {
                STAT = "PAT_CAT_ALTAS";
            }
            else
            {
                STAT = "PAT_CAT_BAJAS";
            }

            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Basicos", ref ddltipo, "p_tipo", STAT, ref Listcodigo);
            ddltipo.Items.Insert(0, new ListItem("TODOS", "T"));
        }
        protected void ddlcuenta_mayor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnComparativo_Click(object sender, ImageClickEventArgs e)
        {
            string anio = SesionUsu.Usu_Ejercicio.Substring(2, 2);
            if (Request.QueryString["P_REP"] == "RP-Comparativo-Pres")
            {             
                string caseSwitch = DDLComparativoTipo.SelectedValue;
                switch (caseSwitch)
                {
                    case "01":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara-PresupuestoG&ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + anio + "&mes_final=" + DDLMes_Final.SelectedValue + anio;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                        break;
                    case "02":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara-PresupuestoD&ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + anio + "&mes_final=" + DDLMes_Final.SelectedValue + anio;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                        break;
                    case "03":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara-PresupuestoR&ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + anio + "&mes_final=" + DDLMes_Final.SelectedValue + anio;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                        break;
                }
            }
            else
            {
                string caseSwitch = DDLComparativo.SelectedValue;
                switch (caseSwitch)
                {
                    case "01":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ComparativoAcumulado&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                        break;
                    case "02":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ComparativoAltas&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                        break;
                    case "03":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ComparativoBajas&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                        break;
                }
            }          
        }
        protected void btnComparativoContaXLS_Click(object sender, ImageClickEventArgs e)
        {
            string anio = SesionUsu.Usu_Ejercicio.Substring(2, 2);
            string caseSwitch = DDLComparativo.SelectedValue;
            switch (caseSwitch)
            {
                case "01":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ComparativoAcumuladoXLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "02":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ComparativoAltasXLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "03":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ComparativoBajasXLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCContable.SelectedValue + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
            }
        }
        protected void btnComparaPresupuestoXLS_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["P_REP"] == "RP-Comparativo-Pres")
            {
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara_PresupuestoXLS&ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + DDLMes_Inicial.SelectedValue + "&mes_final=" + DDLMes_Final.SelectedValue ;
                        _open = "window.open('" + ruta + "', '_newtab');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
           
        }
        protected void DDLComparativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLComparativo.SelectedValue == "01")
            {
                DDLMes_Inicial.SelectedValue = "01";
                DDLMes_Inicial.Enabled = false;
            }
            else
            {
                DDLMes_Inicial.SelectedValue = DDLMes_Final.SelectedValue; ;
                DDLMes_Inicial.Enabled = true;
            }
        }
        protected void DDLDependenciaX_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Centro_trabajo", ref DDLcentro_trab, "p_dependencia", "p_ocupados", DDLDependenciaX.SelectedValue, "SI");
        }

        protected void btnAceptar2_Click(object sender, ImageClickEventArgs e)
        {
            if(DDLcuenta_mayor.SelectedValue=="1248")
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-110S&dependencia=" + DDLDependenciaX.SelectedValue + "&centro_trabajo=" + DDLcentro_trab.SelectedValue +  "&mes_inicial=" + txtfecha_iniCC.Text + "&mes_final=" + txt_fecha_finCC.Text;
            else
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-110A&dependencia=" + DDLDependenciaX.SelectedValue + "&centro_trabajo=" + DDLcentro_trab.SelectedValue+ "&cuenta_mayor=" + DDLcuenta_mayor.SelectedValue + "&mes_inicial=" + txtfecha_iniCC.Text + "&mes_final=" + txt_fecha_finCC.Text + "&categoria=" + DDLCategoriaCC.SelectedValue;

            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void imgBttnExcel_click(object sender, ImageClickEventArgs e)
        {
            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-110A_xls&dependencia=" + DDLDependenciaX.SelectedValue + "&centro_trabajo=" + DDLcentro_trab.SelectedValue + "&cuenta_mayor=" + DDLcuenta_mayor.SelectedValue + "&mes_inicial=" + txtfecha_iniCC.Text + "&mes_final=" + txt_fecha_finCC.Text + "&categoria=" + DDLCategoriaCC.SelectedValue;
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void btnResguardo_Click(object sender, ImageClickEventArgs e)
        {
            string Generar = DDLGenerar.SelectedValue;
            switch (Generar)
                {

                case "01": //Por No. de Inventario
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Resguardos&inv_final=" + txtInventario_Final.Text.Trim() + "&inv_inicial=" + txtInventario_Inicial.Text.Trim() + "&dependencia=" + DDLDepResguardos.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;

                case "02": //Por Centro de Trabajo
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ResguardosCT&centro_trabajo=" + DDLCentrosTrabajo.SelectedValue + "&dependencia=" + DDLDepResguardos.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;

                case "03": //Por Responsable
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-ResguardosR&responsable=" + DDLResponsables.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
            }
            
        }
        
       
        protected void DDLDepResguardos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Centro_trabajo", ref DDLCentrosTrabajo, "p_dependencia", "p_ocupados", DDLDepResguardos.SelectedValue, "SI");
            CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Responsable", ref DDLResponsables, "p_dependencia", "p_tipo", DDLDepResguardos.SelectedValue, "2");
        }
        protected void DDLGenerar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Generar = DDLGenerar.SelectedValue;
            switch (Generar)
            {

                case "01": //Por No. de Inventario
                    lblInventario_Inicial.Visible = true;
                    txtInventario_Inicial.Visible = true;
                    lblInventario_Final.Visible = true;
                    txtInventario_Final.Visible = true;
                    RFVInventario_Inicial.Visible = true;
                    RFVInventario_Final.Visible = true;
                    lblCT.Visible = false;
                    DDLCentrosTrabajo.Visible = false;
                    lblResp.Visible = false;
                    DDLResponsables.Visible = false;
                    break;

                case "02": //Por Centro de Trabajo
                    lblInventario_Inicial.Visible = false;
                    txtInventario_Inicial.Visible = false;
                    lblInventario_Final.Visible = false;
                    txtInventario_Final.Visible = false;
                    RFVInventario_Inicial.Visible = false;
                    RFVInventario_Final.Visible = false;
                    lblCT.Visible = true;
                    DDLCentrosTrabajo.Visible = true;
                    lblResp.Visible = false;
                    DDLResponsables.Visible = false;
                    break;

                case "03": //Por Responsable
                    lblInventario_Inicial.Visible = false;
                    txtInventario_Inicial.Visible = false;
                    lblInventario_Final.Visible = false;
                    txtInventario_Final.Visible = false;
                    RFVInventario_Inicial.Visible = false;
                    RFVInventario_Final.Visible = false;
                    lblCT.Visible = false;
                    DDLCentrosTrabajo.Visible = false;
                    lblResp.Visible = true;
                    DDLResponsables.Visible = true;
                    break;
            }
        }
        protected void DDLEtiquetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Generar = DDLEtiquetas.SelectedValue;
            switch (Generar)
            {

                case "01": //Por No. de Inventario
                    lblEtiquetas_Inv_Ini.Visible = true;
                    txtInv_Ini.Visible = true;
                    lblEtiquetas_Inv_Fin.Visible = true;
                    txtInv_Fin.Visible = true;
                    RFV_Inv_Ini.Visible = true;
                    RFV_Inv_Fin.Visible = true;
                    lblEtiquetas_Dependencia.Visible = false;
                    DDL_Etiquetas_Dependencia.Visible = false;
                    lblEtiquetas_Fec_Ini.Visible = false;
                    txtFecha_Ini.Visible = false;
                    lblEtiquetas_Fec_Fin.Visible = false;
                    txtFecha_Fin.Visible = false;
                    Image8.Visible = false;
                    Image9.Visible = false;
                    break;

                case "02": //Por Fecha
                    lblEtiquetas_Inv_Ini.Visible = false;
                    txtInv_Ini.Visible = false;
                    lblEtiquetas_Inv_Fin.Visible = false;
                    txtInv_Fin.Visible = false;
                    RFV_Inv_Ini.Visible = false;
                    RFV_Inv_Fin.Visible = false;
                    lblEtiquetas_Dependencia.Visible = true;
                    DDL_Etiquetas_Dependencia.Visible = true;
                    lblEtiquetas_Fec_Ini.Visible = true;
                    txtFecha_Ini.Visible = true;
                    lblEtiquetas_Fec_Fin.Visible = true;
                    txtFecha_Fin.Visible = true;
                    Image8.Visible = true;
                    Image9.Visible = true;
                    break;

            }
        }

        protected void btnEtiquetas_Click(object sender, ImageClickEventArgs e)
        {
            string Generar = DDLEtiquetas.SelectedValue;
            switch (Generar)
            {

                case "01": //Por No. de Inventario
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Etiquetas&inv_inicial=" + txtInv_Ini.Text.Trim() + "&inv_final=" + txtInv_Fin.Text.Trim();
                  
                    break;

                case "02": //Por Fecha
                   
                    break;
            }
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }


        protected void DDLTipoComparativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipoComparativo.SelectedValue == "01")
            {
                lblMesInicial_ActivoFijo.Visible = false;
                DDLMesInicial_ActivoFijo.Visible = false;
            }
            else
            {
                lblMesInicial_ActivoFijo.Visible = true;
                DDLMesInicial_ActivoFijo.Visible = true;
            }
        }
        protected void btnComparativo_ActivoFijo_Click(object sender, ImageClickEventArgs e)
        {
            if (DDLTipoComparativo.SelectedValue == "01")
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara_ActivoFijo_AC&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + DDLMesFinal_ActivoFijo.SelectedValue + "&mes_final=" + DDLMesFinal_ActivoFijo.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            else
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara_ActivoFijo_Ejercicio&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + DDLMesInicial_ActivoFijo.SelectedValue+ SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&mes_final=" + DDLMesFinal_ActivoFijo.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);

            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void btnComparativo_ActivoFijoXLS_Click(object sender, ImageClickEventArgs e)
        {
            if (DDLTipoComparativo.SelectedValue == "01")
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara_ActivoFijo_AC_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + DDLMesFinal_ActivoFijo.SelectedValue;
            else
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Compara_ActivoFijo_Ejercicio_XLS&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + DDLMesInicial_ActivoFijo.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&mes_final=" + DDLMesFinal_ActivoFijo.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);

            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void DDLComparativoTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGasto_Click(object sender, ImageClickEventArgs e)
        {
            if (DDLFormato_Gasto.SelectedValue == "01")
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Reclasifica_AF-G_Detalle&centro_contable=" + DDLCentroContable_Gasto.SelectedValue + "&Ejercicio=" + DDLEjercicio_Gasto.SelectedValue;
            else
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Reclasifica_AF-G_Poliza&centro_contable=" + DDLCentroContable_Gasto.SelectedValue + "&Ejercicio=" + DDLEjercicio_Gasto.SelectedValue;

            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void btnGastoXLS_Click(object sender, ImageClickEventArgs e)
        {
            if (DDLFormato_Gasto.SelectedValue == "01")
            {
                ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Reclasifica_AF-G_DetalleXLS&centro_contable=" + DDLCentroContable_Gasto.SelectedValue + "&Ejercicio=" + DDLEjercicio_Gasto.SelectedValue;
                _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }
        protected void btnCedulaXLS_Click(object sender, ImageClickEventArgs e)
        {
            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-103XLS&responsable=" + ddlresponsable.SelectedValue + "&status=" + ddlstatus.SelectedValue + "&dependencia=" + ddldependencia.SelectedValue;
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void ImgBtnTipoMovimiento_Click(object sender, ImageClickEventArgs e)
        {
            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-102XLS&mes_inicial=" + txtMes_inicial0.Text + "&mes_final=" + txtMes_final0.Text + "&clave=" + ddltipo.SelectedValue + "&status=" + ddltipo_consulta.SelectedValue + "&centro_contable=" + DDLCentroContable.SelectedValue;
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        

        protected void btnAceptar3_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
            string TipoFormato = SesionUsu.Usu_Rep;
            string caseSwitch = DDLtipo_bien.SelectedValue;


            if (TipoFormato == "RP-EntregaRecepcion")
            {
                switch (caseSwitch)
                {
                    case "1":
                    case "2":
                    case "3":
                        {
                            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP01&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                            break;
                        }
                    case "4":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP04&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "5":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP05&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "6":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP06&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "7":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP08&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "8":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP07&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "10":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-BP10&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                }
            }
            else
            {

                switch (caseSwitch)
                {
                    case "1":
                    case "2":
                    case "3":
                        {
                            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108A&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                            break;
                        }
                    case "4":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108D&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "5":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108E&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "6":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108F&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "7":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108H&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "8":
                        ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108G&Tipo_V=" + DDLtipo_bien.SelectedValue + "&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                        break;
                    case "9":
                        {
                            ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-108I&dependencia=" + ddldependencia0.SelectedValue + "&fecha_periodo=" + txtfecha_periodo.Text;
                            break;
                        }
                }
            }
           
           
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }




    }
}
