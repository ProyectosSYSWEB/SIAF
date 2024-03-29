﻿using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmCatalogoDependencias : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Dependencias CN_DEPENDENCIAS = new CN_Dependencias();
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


        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                DDLCentroContab.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Estados", ref DDLEstado, "p_pais", "parametro2", "1", "");
                DDLEstado.SelectedValue = "8";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Municipios", ref DDLMunicipio, "p_edo", "parametro2", "8", "");
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }            
        }  

        protected void BTNGuardarDepend_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Dependencias objDependencias = new Dependencias();
                    objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                    objDependencias.Clave = txtClvDepend.Text;
                    objDependencias.Descrip = txtDependencia.Text;
                    objDependencias.Titular = txtTitular.Text;
                    objDependencias.Administ = txtAdministrador.Text;
                    objDependencias.Domicilio = txtDomicilio.Text;
                    objDependencias.Id_Estado = DDLEstado.SelectedValue;
                    objDependencias.Id_Municipio = DDLMunicipio.SelectedValue;
                    objDependencias.Zona_Economica = txtZonaEconomica.Text;
                    objDependencias.Tel_Titular = txtTelTitular.Text;
                    objDependencias.Cel_Titular = txtCelTitular.Text;
                    objDependencias.Tel_Admin = txtTelAdmin.Text;
                    objDependencias.Cel_Admin = txtCelAdmin.Text;
                    objDependencias.Nombramiento = txtNombramiento.Text;
                    objDependencias.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                    string Verificador = string.Empty;
                    CN_DEPENDENCIAS.InsertarDependencia(ref objDependencias, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Se guardo correctamente.')", true);
                        txtClvDepend.Text = "";
                        txtDependencia.Text = "";
                        txtTitular.Text = "";
                        txtAdministrador.Text = "";
                        txtDomicilio.Text = "";
                        txtZonaEconomica.Text = "";
                        txtTelTitular.Text = "";
                        txtCelTitular.Text = "";
                        txtTelAdmin.Text = "";
                        txtCelAdmin.Text = "";
                        txtNombramiento.Text = "";
                        DDLCentroContab.SelectedIndex = 0;
                        DDLMunicipio.SelectedIndex = 0;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '"+Verificador+".')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'No tiene los privilegios para realizar esta acción.')", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '"+ ex.Message+".')", true);                
            }
            
        }

        protected void DDLEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Municipios", ref DDLMunicipio, "p_edo", "parametro2", "8", "");
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }            
        }
    }
}