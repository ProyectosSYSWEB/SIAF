using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
namespace SAF.Form
{
    public partial class Analitico : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
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

            //SesionUsu.Usu_Rep = Request.QueryString["P_REP"];

            btnAceptar.ValidationGroup = string.Empty;
            if (SesionUsu.Usu_Rep == "RP-002" || SesionUsu.Usu_Rep == "RP-004" || SesionUsu.Usu_Rep == "RP-012" || SesionUsu.Usu_Rep == "RP-012-2" || SesionUsu.Usu_Rep == "RP-013" || SesionUsu.Usu_Rep == "RP-023")
            {
                lbl_f_fin.Visible = true;
                lbl_f_ini.Visible = true;
                txtmes_final.Visible = true;
                txtmes_inicial.Visible = true;

                if (SesionUsu.Usu_Rep == "RP-012" || SesionUsu.Usu_Rep == "RP-012-2" || SesionUsu.Usu_Rep == "RP-013" || SesionUsu.Usu_Rep == "RP-023")
                {
                    if (SesionUsu.Usu_Rep == "RP-013")
                    {
                        Label4.Visible = false;
                        Label3.Visible = true;
                        ddl_cuentas.Visible = true;
                        ImageButton3.Visible = true;
                        ddlCuenta_Mayor.Visible = false;

                    }
                    else if (SesionUsu.Usu_Rep == "RP-023")
                    {
                        lbl_f_ini.Visible = false;
                        txtmes_inicial.Visible = false;
                        lbl_f_fin.Visible = false;
                        txtmes_final.Visible = false;

                        ImageButton3.Visible = true;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor, ref Listcodigo);
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor0, ref Listcodigo);
                        Label4.Visible = true;
                        ddlCuenta_Mayor.Visible = true;
                        ddlCuenta_Mayor0.Visible = true;
                        DDLCentro_Contable0.Visible = true;
                        ddl_cuentas.Visible = false;
                        ddl_cuentas0.Visible = false;
                        Label3.Visible = false;
                        Label12.Visible = false;
                        Label10.Visible = true;
                        lblNivel.Visible = true;
                        ddlnivel.Visible = true;
                        Label11.Visible = true;
                        ddlCuenta_Mayor0.Visible = true;

                    }

                    else if (SesionUsu.Usu_Rep == "RP-012-2")
                    {
                        ImageButton3.Visible = true;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor, ref Listcodigo);
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor0, ref Listcodigo);
                        Label4.Visible = false;
                        Label11.Visible = false;
                        ddlCuenta_Mayor.Visible = false;
                        ddlCuenta_Mayor0.Visible = false;
                        DDLCentro_Contable0.Visible = true;
                        ddl_cuentas.Visible = false;
                        ddl_cuentas0.Visible = false;
                        Label3.Visible = false;
                        Label12.Visible = false;
                        Label10.Visible = true;
                        lblNivel.Visible = true;
                        ddlnivel.Visible = true;
                        lblTipo.Visible = true;
                        ddlTipo.Visible = true;
                        lblNivel.Visible = false;
                        ddlnivel.Visible = false;
                        lblNivelReporte.Visible = true;
                        ddlNivelReporte.Visible = true;
                        btnAceptar.ValidationGroup = "Reporte";
                        txtmes_inicial.Visible = false;
                        lbl_f_ini.Visible = false;
                        lbl_f_fin.Text = "Mes:";
                        //valCtaCont.ValidationGroup = "Reporte";
                        //valCtaCont0.ValidationGroup = "Reporte";
                    }

                    else
                    {
                        ImageButton3.Visible = true;
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor, ref Listcodigo);
                        CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor0, ref Listcodigo);
                        Label4.Visible = true;
                        ddlCuenta_Mayor.Visible = true;
                        ddlCuenta_Mayor0.Visible = true;
                        DDLCentro_Contable0.Visible = true;
                        ddl_cuentas.Visible = false;
                        ddl_cuentas0.Visible = false;
                        Label3.Visible = false;
                        Label12.Visible = false;
                        Label10.Visible = true;
                        lblNivel.Visible = true;
                        ddlnivel.Visible = true;
                        Label11.Visible = true;
                        ddlCuenta_Mayor0.Visible = true;
                    }
                }

                

            }
            if (SesionUsu.Usu_Rep == "RP-003")
            {
                ddlCuenta_Mayor0.Visible = false;
                Label12.Visible = false;
                ImageButton3.Visible = true;
                txtmes_final.Visible = false;
                txtmes_inicial.Visible = false;
                Label3.Visible = false;
                ddl_cuentas.Visible = false;
                Label4.Visible = true;
                ddlCuenta_Mayor.Visible = true;
                ddlCuenta_Mayor.Visible = true;
                ddl_cuentas0.Visible = false;
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Contables", ref ddl_cuentas, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor, "p_todas", "S");

            }

            if (SesionUsu.Usu_Rep == "RP-005")
            {

                Label3.Visible = false;
                ddl_cuentas.Visible = false;
                Label6.Visible = true;
                txtpoliza.Visible = true;
                Label5.Visible = true;
                txttipo.Visible = true;
            }
            if (SesionUsu.Usu_Rep == "RP-006")
            {

                Label3.Visible = false;
                Label12.Visible = false;
                ddl_cuentas.Visible = false;
                ddl_cuentas0.Visible = false;
                ddlCuenta_Mayor.Visible = false;
                

                lbl_f_fin.Visible = true;
                lbl_f_ini.Visible = true;
                txtmes_final.Visible = true;
                txtmes_inicial.Visible = true;
                Label7.Visible = true;
                ddlsistemas.Visible = true;
                ImageButton3.Visible = true;



            }
            if (SesionUsu.Usu_Rep == "RP-009")
            {

                Label9.Visible = true;
                ddlMayor.Visible = true;
                Label2.Visible = false;
                txtmes_final.Visible = false;
                DDLCentro_Contable.Visible = false;
                Label3.Visible = false;
                ddl_cuentas.Visible = false;
                lbl_f_ini.Text = "Mes de Cierre:";
                lbl_f_ini.Visible = true;
                txtmes_inicial.Visible = true;
                lblNivel.Visible = true;
                ddlnivel.Visible = true;
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_meses", ref txtmes_inicial);

            }
            if (SesionUsu.Usu_Rep == "RP-007" || SesionUsu.Usu_Rep == "RP-008")
            {

                Label2.Visible = false;
                txtmes_final.Visible = false;
                DDLCentro_Contable.Visible = false;
                Label3.Visible = false;
                ddl_cuentas.Visible = false;
                lbl_f_ini.Visible = true;
                txtmes_inicial.Visible = true;
                lblNivel.Visible = true;
                ddlnivel.Visible = true;
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_meses", ref txtmes_inicial);


            }


            if (SesionUsu.Usu_Rep == "RP-010")
            {

                Label2.Visible = false;
                txtmes_final.Visible = false;
                DDLCentro_Contable.Visible = false;
                Label3.Visible = false;
                ddl_cuentas.Visible = false;
                lbl_f_ini.Text = "Mes:";
                lbl_f_ini.Visible = true;
                txtmes_inicial.Visible = true;
                lblNivel.Visible = true;
                ddlnivel.Visible = true;
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_meses", ref txtmes_inicial);

            }
            if (SesionUsu.Usu_Rep == "RP-001")
            {
                ddl_cuentas.Visible = true;
                ddlCuenta_Mayor.Visible = false;



            }

            if (SesionUsu.Usu_Rep == "RP-003-1")
                ImageButton3.Visible = true;

            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "P_USUARIO", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable0, "P_USUARIO", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_meses", ref txtmes_inicial);
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_meses", ref txtmes_final);
            if (SesionUsu.Usu_Rep == "RP-012-2")
                txtmes_final.Items.RemoveAt(0);

            //t(3, new ListItem("03-TRANSFERENCIA", "1057"));

            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Contables", ref ddl_cuentas, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Contables", ref ddl_cuentas0, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));



        }
        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_contables", ref ddl_cuentas, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_contables", ref ddl_cuentas0, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
            DDLCentro_Contable0.SelectedValue = DDLCentro_Contable.SelectedValue;
        }
        protected void ddl_cuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_cuentas0.SelectedValue = ddl_cuentas.SelectedValue;
        }

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
        {
            string anio = SesionUsu.Usu_Ejercicio.Substring(2, 2);
            if (SesionUsu.Usu_Rep == "RP-001")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Vermovtos_cuentas('RP-001'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + Convert.ToString(ddl_cuentas.SelectedValue) + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-002")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Verdiario_general('RP-002'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + txtmes_inicial.Text + anio + "', '" + txtmes_final.Text + anio + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-003-1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerCatalogo_Cuentas('RP-003'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + ddlCuenta_Mayor.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-004")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Verdiario_general('RP-004'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "', '" + txtmes_inicial.Text + anio + "','" + txtmes_final.Text + anio + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-005")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerPoliza('RP-005'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "', '" + txtpoliza.Text + "','" + txttipo.SelectedValue + "');", true);
            }

            if (SesionUsu.Usu_Rep == "RP-006")
            {


                if (txtmes_final.SelectedValue.Substring(0, 2) == txtmes_inicial.SelectedValue.Substring(0, 2))
                {
                    string mes_inic;
                    int mes_In = Convert.ToInt32(txtmes_inicial.SelectedValue) - 1;
                    if (mes_In < 10) { mes_inic = "0" + mes_In; } else { mes_inic = Convert.ToString(mes_In); }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerBalanza_de_Comprobacion('RP-006'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "' ,'" + mes_inic + anio + "','" + ddlsistemas.SelectedValue + "', '" + txtmes_final.Text + anio + txtmes_final.Text + anio + "', '" + DDLCentro_Contable.SelectedItem + "','" + txtmes_inicial.SelectedItem.Text + "');", true);

                }
                else
                {

                    if (txtmes_inicial.SelectedValue.Substring(0, 2) == "00")
                    {
                        string mes_inic;
                        int mes_In = Convert.ToInt32(txtmes_inicial.SelectedValue) + 1;
                        if (mes_In < 10) { mes_inic = "0" + mes_In; } else { mes_inic = Convert.ToString(mes_In); }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerBalanza_de_Comprobacion('RP-006'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "' ,'" + txtmes_inicial.Text + anio + "','" + ddlsistemas.SelectedValue + "', '" + txtmes_final.Text + anio + mes_inic + anio + "', '" + DDLCentro_Contable.SelectedItem + "','" + txtmes_inicial.SelectedItem.Text + "');", true);
                    }
                    else
                    {
                        string mes_inic;
                        int mes_In = Convert.ToInt32(txtmes_inicial.SelectedValue) - 1;
                        if (mes_In < 10) { mes_inic = "0" + mes_In; } else { mes_inic = Convert.ToString(mes_In); }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerBalanza_de_Comprobacion('RP-006'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "' ,'" + mes_inic + anio + "','" + ddlsistemas.SelectedValue + "', '" + txtmes_final.Text + anio + txtmes_inicial.Text + anio + "', '" + DDLCentro_Contable.SelectedItem + "','" + txtmes_inicial.SelectedItem.Text + "');", true);

                    }

                }
            }
            if (SesionUsu.Usu_Rep == "RP-007")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerSituacion_financiera_o_resultado('RP-007'," + SesionUsu.Usu_Ejercicio + ",'" + ddlnivel.SelectedValue + "','" + txtmes_inicial.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-008")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerSituacion_financiera_o_resultado('RP-008'," + SesionUsu.Usu_Ejercicio + ",'" + ddlnivel.SelectedValue + "','" + txtmes_inicial.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-009")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerEstado_analitico('RP-009'," + SesionUsu.Usu_Ejercicio + ",'" + txtmes_inicial.SelectedValue + "','" + ddlnivel.SelectedValue + "', '" + ddlMayor.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-010")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerEstado_flujo_efectivo('RP-010'," + SesionUsu.Usu_Ejercicio + ",'" + txtmes_inicial.SelectedValue + "','" + ddlnivel.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-012")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Veranexo_cuentas_balance('RP-012'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "','" + Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaDos + Listcodigo[ddlCuenta_Mayor0.SelectedIndex].EtiquetaDos + "','" + txtmes_inicial.Text + anio + "','" + txtmes_final.Text + anio + "','" + ddlnivel.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-012-2")
            {
                string ruta;
                if (ddlNivelReporte.SelectedValue == "1")
                    if (ddlTipo.SelectedValue == "3220.5" || ddlTipo.SelectedValue == "3220.6")
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=00&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                    else
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=" + txtmes_final.Text + "&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                else
                {
                    if (ddlTipo.SelectedValue == "3220.5" || ddlTipo.SelectedValue == "3220.6")
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2-Grupo&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=00&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                    else
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2-Grupo&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=" + txtmes_final.Text + "&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                }
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }

            if (SesionUsu.Usu_Rep == "RP-023")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Veranexo_tabular('RP-023'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "','" + Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaDos + Listcodigo[ddlCuenta_Mayor0.SelectedIndex].EtiquetaDos + "','" + "00" + anio + "','" + "13" + anio + "','" + ddlnivel.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-013")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Vermayor_auxiliar('RP-013'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + ddl_cuentas.SelectedValue + ddl_cuentas0.SelectedValue + "','" + txtmes_inicial.Text + anio + "','" + txtmes_final.Text + anio + "');", true);
            }
        }

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {
            string anio = SesionUsu.Usu_Ejercicio.Substring(2, 2);
            if (SesionUsu.Usu_Rep == "RP-001")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Vermovtos_cuentas_Exel('RP-001'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + Convert.ToString(ddl_cuentas.SelectedValue) + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-012")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Veranexo_cuentas_balance_Exel('RP-012exc'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "','" + Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaDos + Listcodigo[ddlCuenta_Mayor0.SelectedIndex].EtiquetaDos + "','" + txtmes_inicial.Text + anio + "','" + txtmes_final.Text + anio + "','4');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-012-2")
            {
                string ruta;
                if (ddlNivelReporte.SelectedValue == "1")
                    if (ddlTipo.SelectedValue == "3220.5" || ddlTipo.SelectedValue == "3220.6")
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2exc&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=00&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                    else
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2exc&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=" + txtmes_final.Text + "&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                else
                {
                    if (ddlTipo.SelectedValue == "3220.5" || ddlTipo.SelectedValue == "3220.6")
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2-Grupoexc&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=00&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                    else
                        ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2-Grupoexc&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=" + txtmes_final.Text + "&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                }
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                //string ruta;
                //if (ddlNivelReporte.SelectedValue == "1")
                //    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2exc&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=" + txtmes_inicial.Text + "&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;
                //else
                //    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-012-2-Grupoexc&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "&mes_inicial=" + txtmes_inicial.Text + "&mes_final=" + txtmes_final.Text + "&tipo_rep=" + ddlTipo.SelectedValue;

                //string _open = "window.open('" + ruta + "', '_newtab');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            if (SesionUsu.Usu_Rep == "RP-023")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Veranexo_tabular_Exel('RP-023exc'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + Convert.ToString(DDLCentro_Contable0.SelectedValue) + "','" + Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaDos + Listcodigo[ddlCuenta_Mayor0.SelectedIndex].EtiquetaDos + "','" + "00" + anio + "','" + "13" + anio + "','4');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-003")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerCatalogo_Cuentas_Exel('RP-003exc'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + ddlCuenta_Mayor.SelectedValue + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-013")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Vermayor_auxiliar('RP-013xls'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + ddl_cuentas.SelectedValue + ddl_cuentas0.SelectedValue + "','" + txtmes_inicial.Text + anio + "','" + txtmes_final.Text + anio + "');", true);
            }
            if (SesionUsu.Usu_Rep == "RP-006")
            {
                if (txtmes_final.SelectedValue.Substring(0, 2) == txtmes_inicial.SelectedValue.Substring(0, 2))
                {
                    string mes_inic;
                    int mes_In = Convert.ToInt32(txtmes_inicial.SelectedValue) - 1;
                    if (mes_In < 10) { mes_inic = "0" + mes_In; } else { mes_inic = Convert.ToString(mes_In); }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerBalanza_de_Comprobacion('RP-006exc'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "' ,'" + mes_inic + anio + "','" + ddlsistemas.SelectedValue + "', '" + txtmes_final.Text + anio + txtmes_final.Text + anio + "', '" + DDLCentro_Contable.SelectedItem + "','" + txtmes_inicial.SelectedItem.Text + "');", true);
                }
                else
                {

                    if (txtmes_inicial.SelectedValue.Substring(0, 2) == "00")
                    {
                        string mes_inic;
                        int mes_In = Convert.ToInt32(txtmes_inicial.SelectedValue) + 1;
                        if (mes_In < 10) { mes_inic = "0" + mes_In; } else { mes_inic = Convert.ToString(mes_In); }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerBalanza_de_Comprobacion('RP-006exc'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "' ,'" + txtmes_inicial.Text + anio + "','" + ddlsistemas.SelectedValue + "', '" + txtmes_final.Text + anio + mes_inic + anio + "', '" + DDLCentro_Contable.SelectedItem + "','" + txtmes_inicial.SelectedItem.Text + "');", true);
                    }
                    else
                    {
                        string mes_inic;
                        int mes_In = Convert.ToInt32(txtmes_inicial.SelectedValue) - 1;
                        if (mes_In < 10) { mes_inic = "0" + mes_In; } else { mes_inic = Convert.ToString(mes_In); }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerBalanza_de_Comprobacion('RP-006exc'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "' ,'" + mes_inic + anio + "','" + ddlsistemas.SelectedValue + "', '" + txtmes_final.Text + anio + txtmes_inicial.Text + anio + "', '" + DDLCentro_Contable.SelectedItem + "','" + txtmes_inicial.SelectedItem.Text + "');", true);

                    }

                }


                //}


            }
        }

        protected void txtmes_inicial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCuenta_Mayor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Usu_Rep != "RP-003")
            {
                ddlCuenta_Mayor0.SelectedValue = ddlCuenta_Mayor.SelectedValue;
            }

        }
    }
}




