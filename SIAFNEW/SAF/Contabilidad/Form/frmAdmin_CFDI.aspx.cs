using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Contabilidad.Form
{
    public partial class frmAdmin_CFDI : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string MsjError = string.Empty;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Poliza CNPoliza = new CN_Poliza();
        CN_Poliza_CFDI CNPolizaCFDI = new CN_Poliza_CFDI();
        CN_Usuario CNUsuario = new CN_Usuario();
        List<Poliza_CFDI> ListPolizaCFDI = new List<Poliza_CFDI>();

        Comun ObjCC = new Comun();
        Poliza ObjPoliza = new Poliza();
        Poliza_CFDI ObjPolizaCFDI = new Poliza_CFDI();
        #endregion
        private void Inicializar()
        {
            Cargarcombos();
        }

        private void Cargarcombos()
        {
            Verificador = string.Empty;
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Beneficiario", ref ddlTipo_Beneficiario);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Gasto", ref ddlTipo_Gasto);
                ddlTipo_Beneficiario.Items.RemoveAt(0);
                ddlTipo_Beneficiario.Items.Insert(0, new ListItem("-- TODOS --", "T"));

                ddlTipo_Gasto.Items.RemoveAt(0);
                ddlTipo_Gasto.Items.Insert(0, new ListItem("-- TODOS --", "T"));



                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        private void CargarGridPolizaCFDI()
        {
            grvPolizaCFDI.DataSource = null;
            grvPolizaCFDI.DataBind();
            //Int32[] Celdas = new Int32[] { 0, 2 };
            try
            {
                DataTable dt = new DataTable();
                grvPolizaCFDI.DataSource = GetList();
                grvPolizaCFDI.DataBind();

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        private List<Poliza_CFDI> GetList()
        {
            try
            {
                List<Poliza_CFDI> List = new List<Poliza_CFDI>();
                ObjPolizaCFDI.Tipo_Gasto = ddlTipo_Gasto.SelectedValue;
                ObjPolizaCFDI.Beneficiario_Tipo = ddlTipo_Beneficiario.SelectedValue;
                CNPolizaCFDI.PolizaCFDIConsultaDatosAdmin(ObjPolizaCFDI, ref List, txtBuscar.Text);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridPolizaCFDI();
        }

        protected void grvPolizaCFDI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPolizaCFDI.PageIndex = 0;
            grvPolizaCFDI.PageIndex = e.NewPageIndex;
            CargarGridPolizaCFDI();

        }

        protected void imgBttnPDF_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP_CFDIS&parametro1=" + ddlTipo_Gasto.SelectedValue+ "&parametro2=" + ddlTipo_Beneficiario.SelectedValue + "&parametro3=" + txtBuscar.Text;
            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void imgBttnExcel_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP_CFDISxls&parametro1=" + ddlTipo_Gasto.SelectedValue + "&parametro2=" + ddlTipo_Beneficiario.SelectedValue + "&parametro3=" + txtBuscar.Text;
            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}