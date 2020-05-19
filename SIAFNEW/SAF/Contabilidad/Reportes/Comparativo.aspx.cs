using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Contabilidad.Reportes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        string _open;
        string ruta;
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables

        #endregion      
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                inicializar();
            }
        }
        protected void inicializar()

        {
            if (Request.QueryString["P_REP"] != null)
                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];


            if (SesionUsu.Usu_Rep == "RP-14" || SesionUsu.Usu_Rep == "RP-15" || SesionUsu.Usu_Rep == "RP-19" || SesionUsu.Usu_Rep == "RP-20" || SesionUsu.Usu_Rep == "RP-16" || SesionUsu.Usu_Rep == "RP-17" || SesionUsu.Usu_Rep == "RP-Diario-General" || SesionUsu.Usu_Rep == "RP-Resumen-de-cuentas")
            {
                MultiView1.ActiveViewIndex=2;
                if (SesionUsu.Usu_Rep == "RP-17" || SesionUsu.Usu_Rep == "RP-Diario-General" || SesionUsu.Usu_Rep == "RP-Resumen-de-cuentas")
                {
                    CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio",SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                    if (SesionUsu.Usu_Rep == "RP-Resumen-de-cuentas")
                    {
                        ddlcuenta1.Visible = true;
                        lblcuenta1.Visible = true;
                        if (DDLCentro_Contable.SelectedItem.ToString()== "00000 - UNACH")
                        {
                            DDLCentro_Contable.Items.RemoveAt(0);
                        }                        
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Contables", ref  ddlcuenta1, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
                        
                    }        

                    lblCentro_Contable.Visible = true;
                    DDLCentro_Contable.Visible = true;
                }
               
            }
            else
            {
                if (SesionUsu.Usu_Rep == "RP-Compara-01" || SesionUsu.Usu_Rep == "RP-Compara-01-Cja")
                {
                    MultiView1.ActiveViewIndex = 0;
                    CNComun.LlenaCombo("pkg_contabilidad. Obt_Combo_Ctas_Cmp_Ing_vs_Fond", ref  ddl_cuentas, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                    CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_meses", ref txtmes_inicial);
                }
                if (SesionUsu.Usu_Rep == "RP-Volante")
                {
                    MultiView1.ActiveViewIndex = 3;
                    CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref  DDLCentro_Contable_v, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre , SesionUsu.Usu_Ejercicio);
                    CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Volante", ref ddltipo);
                    CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Poliza_Volante", ref ddlnumero_poliza, "p_ejercicio", "p_mes", "p_tipo_volante", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlmes.SelectedValue, ddltipo.SelectedValue, DDLCentro_Contable_v.SelectedValue);
                }
                if (SesionUsu.Usu_Rep == "RP-Revisar")
                {
                    MultiView1.ActiveViewIndex = 1;
                }
                if (SesionUsu.Usu_Rep == "RP-Mayor-General")
                {
                    MultiView1.ActiveViewIndex = 0;
                    lbl_f_ini.Visible = false;
                    txtmes_inicial.Visible = false;
                    btnAceptar.Visible = false;
                    CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref  ddl_cuentas, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);               
                }
                if (SesionUsu.Usu_Rep == "RP-ADEUDO")
                {
                    MultiView1.ActiveViewIndex = 4;                     
                }
            }
        }
       
        protected void ddl_cuentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtmes_inicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Poliza_Volante", ref ddlnumero_poliza, "p_ejercicio", "p_mes", "p_tipo_volante", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlmes.SelectedValue, ddltipo.SelectedValue, DDLCentro_Contable_v.SelectedValue);
          
        }

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
        {
            string anio = SesionUsu.Usu_Ejercicio.Substring(2, 2);
            if (ddl_cuentas.SelectedValue.Substring(0, 10) == "3261.90001" || ddl_cuentas.SelectedValue.Substring(0, 10) == "3261.90002" || ddl_cuentas.SelectedValue.Substring(0, 10) == "3262.10001" || ddl_cuentas.SelectedValue.Substring(0, 10) == "3262.20001" || ddl_cuentas.SelectedValue.Substring(0, 10) == "3262.50005")
            {
                if (SesionUsu.Usu_Rep == "RP-Compara-01-Cja")
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-021','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                else
                {
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-compara-06&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&cuenta_contable=" + ddl_cuentas.SelectedValue + "&mes_inicial=" + txtmes_inicial.SelectedValue + anio;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
            }
            else
            {

                if (ddl_cuentas.SelectedValue.Substring(0, 4) == "3262")
                {

                    if (ddl_cuentas.SelectedValue.Substring(0, 10) == "3262.70001")
                    {
                        if (SesionUsu.Usu_Rep == "RP-Compara-01-Cja")
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-021','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-compara-05','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-compara-04','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                    }
                }
                else
                {
                    if (ddl_cuentas.SelectedValue.Substring(0, 10) == "3261.10001")
                    {
                        if (SesionUsu.Usu_Rep == "RP-Compara-01-Cja")
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-021','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-compara-01','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                    }
                    else
                    {
                        if (SesionUsu.Usu_Rep == "RP-Compara-01-Cja")
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-021','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Ctas_Cmp_Ing_vs_Fond('RP-compara-02','" + SesionUsu.Usu_Ejercicio + "','" + ddl_cuentas.SelectedItem.Text + "', '" + txtmes_inicial.SelectedValue + anio + "');", true);
                    }
                }
            }
        }

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Descargar_Cuentas_Por_Revisar('RP-revisar-exc');", true);           
        }

        protected void btnAceptar0_Click(object sender, ImageClickEventArgs e)
        {

            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-14":                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos('RP-014','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
            
                    break;
                case "RP-15":                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos('RP-015','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
           
                    break;
                case "RP-16":                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos('RP-016','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
           
                    break;
                case "RP-17":                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos_por_centro('RP-017','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "', '" + DDLCentro_Contable.SelectedValue + "');", true);
          
                    break;
                case "RP-Diario-General":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-Diario-General&mes_inicial=" + ddlMes_inicial.SelectedValue + "&mes_final=" + ddlMes_final.SelectedValue + "&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCentro_Contable.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "RP-Resumen-de-cuentas":                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_resumen_de_cuetas('RP-Resumen-de-cuentas','" + SesionUsu.Usu_Ejercicio + "','" + DDLCentro_Contable.SelectedValue + "','" + ddlcuenta1.SelectedValue + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
                    break;                
                case "RP-19":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-019&mes_inicial=" + ddlMes_inicial.SelectedValue  + "&mes_final=" + ddlMes_final.SelectedValue  + "&Ejercicio=" + SesionUsu.Usu_Ejercicio ;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "RP-20":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-020&mes_inicial=" + ddlMes_inicial.SelectedValue + "&mes_final=" + ddlMes_final.SelectedValue + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
            }          
        }

        protected void btn_excel_Click(object sender, ImageClickEventArgs e)
        {

            string caseSwitch = SesionUsu.Usu_Rep;
            switch (caseSwitch)
            {
                case "RP-14":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos('RP-014exc','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
                    break;
                case "RP-15":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos('RP-015exc','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
                    break;
                case "RP-Diario-General":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-Diario-Generalxls&mes_inicial=" + ddlMes_inicial.SelectedValue + "&mes_final=" + ddlMes_final.SelectedValue + "&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCentro_Contable.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;    
                case "RP-Resumen-de-cuentas":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_resumen_de_cuetas('RP-Resumen-de-cuentasxls','" + SesionUsu.Usu_Ejercicio + "','" + DDLCentro_Contable.SelectedValue + "','" + ddlcuenta1.SelectedValue + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);
                    break;
                case "RP-19":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-019xls&mes_inicial=" + ddlMes_inicial.SelectedValue + "&mes_final=" + ddlMes_final.SelectedValue + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;                
                case "RP-16":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos('RP-016xls','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "');", true);

                    break;
                case "RP-17":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_concentrado_ingresos_por_centro('RP-017xls','" + SesionUsu.Usu_Ejercicio + "','" + ddlMes_inicial.SelectedValue + "', '" + ddlMes_final.SelectedValue + "', '" + DDLCentro_Contable.SelectedValue + "');", true);

                    break;
                
                case "RP-20":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-020xls&mes_inicial=" + ddlMes_inicial.SelectedValue + "&mes_final=" + ddlMes_final.SelectedValue + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                default:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Mensaje-Error('RP-Diario-Generalxls');", true);
                    break;

            }

        }

        protected void btnAceptar_v_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Ver_Volante_Transferencia('RP-Volante_T','" + SesionUsu.Usu_Ejercicio + ddlmes.SelectedValue + "','" + DDLCentro_Contable_v.SelectedItem + "','" + ddlnumero_poliza.SelectedValue + "', '" + ddltipo.SelectedValue + "');", true);
              
        }

        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Poliza_Volante", ref ddlnumero_poliza, "p_ejercicio", "p_mes", "p_tipo_volante", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlmes.SelectedValue, ddltipo.SelectedValue, DDLCentro_Contable_v.SelectedValue);
          
        }

        protected void ddlnumero_poliza_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLCentro_Contable_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Poliza_Volante", ref ddlnumero_poliza, "p_ejercicio", "p_mes", "p_tipo_volante", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlmes.SelectedValue, ddltipo.SelectedValue, DDLCentro_Contable_v.SelectedValue);
          
        }

        protected void xls_Click(object sender, ImageClickEventArgs e)
        {
            ruta = "VisualizadorCrystal.aspx?Tipo=RP-Mayor-General&Ejercicio=" + SesionUsu.Usu_Ejercicio ;
            _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);           
        }

        protected void DDLCentro_Contable_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Contables", ref  ddlcuenta1, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
                
        }
        protected void btnAceptar_D_Click(object sender, ImageClickEventArgs e)
        {
            string Notas = txtNotas.Text.Replace("\r", "%20%20%20%20%20");
            Notas = txtNotas.Text.Replace("\n", "%20%20%20%20%20");
            string caseSwitch = ddl_Tipo_D.SelectedValue;
            string TipoAdeudoIni = string.Empty;
            string TipoAdeudoFin = string.Empty;
            switch (ddl_subtipo.SelectedValue)
            {
                case "1":
                    TipoAdeudoIni = "2117";
                    TipoAdeudoFin = "2117";
                    break;
                case "2":
                    TipoAdeudoIni = "2249";
                    TipoAdeudoFin = "2249";
                    break;
                case "3":
                    TipoAdeudoIni = "2117";
                    TipoAdeudoFin = "2249";
                    break;
            }

            switch (caseSwitch)
            {
                case "1":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-SAT&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "2":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-FOVISSSTE&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "3":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-ISSSTE&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "4":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-Impuestos&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;

            }
        }

        protected void imgBttnExcel_D(object sender, ImageClickEventArgs e)
        {
            string Notas = txtNotas.Text.Replace("\r\n", "%20%20%20%20%20");
            string caseSwitch = ddl_Tipo_D.SelectedValue;
            string TipoAdeudoIni = string.Empty;
            string TipoAdeudoFin = string.Empty;
            switch (ddl_subtipo.SelectedValue)
            {
                case "1":
                    TipoAdeudoIni = "2117";
                    TipoAdeudoFin = "2117";
                    break;
                case "2":
                    TipoAdeudoIni = "2249";
                    TipoAdeudoFin = "2249";
                    break;
                case "3":
                    TipoAdeudoIni = "2117";
                    TipoAdeudoFin = "2249";
                    break;
            }
            switch (caseSwitch)
            {
                case "1":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-SATxls&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "2":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-FOVISSSTExls&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    break;
                case "3":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-ISSSTExls&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "4":
                    ruta = "VisualizadorCrystal.aspx?Tipo=RP-Impuestosxls&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&mes_inicial=" + ddlMes_inicial1.SelectedValue + "&mes_final=" + ddlMes_final1.SelectedValue + "&notas=" + Notas + "&tipo_adeudo_ini=" + TipoAdeudoIni + "&tipo_adeudo_fin=" + TipoAdeudoFin;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
            }

        }
    }
}