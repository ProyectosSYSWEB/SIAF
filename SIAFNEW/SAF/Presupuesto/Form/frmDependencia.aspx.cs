using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmDependencia : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Dependencias CN_Dependencias = new CN_Dependencias();        
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
            GRDCargarDatosDepend();
            Multiview1.ActiveViewIndex = 0;
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "p_ejercicio", SesionUsu.Usu_Ejercicio);
            }
            catch(Exception ex)
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true); }
        }
        protected void GRDCargarDatosDepend()
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                List<Dependencias> list = new List<Dependencias>();
                objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                objDependencias.Ejercicio = Convert.ToInt32( SesionUsu.Usu_Ejercicio);
                CN_Dependencias.DependenciasGrid(ref objDependencias, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GDRDependencias.DataSource = list;
                GDRDependencias.DataBind();
                LBLNumDepend.Text = "Total de dependencias: " + list.Count;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void DDLCentroContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                List<Dependencias> list = new List<Dependencias>();
                objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                objDependencias.Ejercicio = Convert.ToInt32( SesionUsu.Usu_Ejercicio);
                CN_Dependencias.DependenciasGrid(ref objDependencias, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GDRDependencias.DataSource = list;
                GDRDependencias.DataBind();
                LBLNumDepend.Text = "Total de dependencias: " + list.Count;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GDRDependencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                objDependencias.Id = Convert.ToString(GDRDependencias.Rows[fila].Cells[6].Text);
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CN_Dependencias.EliminarDependencia(ref objDependencias, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha eliminado correctamente.')", true);
                        GRDCargarDatosDepend();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GDRDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CargarCombosEditar();
                    string Verificador = string.Empty;
                    Dependencias objDependencias = new Dependencias();
                    objDependencias.Id = Convert.ToString(GDRDependencias.SelectedRow.Cells[6].Text);
                    objDependencias.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);

                    CN_Dependencias.ObtenerDatosDependencia(ref objDependencias, ref Verificador);
                    Session["SessionIdDependencia"] = objDependencias.Id;
                    txtClvDepend.Text = objDependencias.Clave;
                    txtDependencia.Text = objDependencias.Descrip;
                    txtTitular.Text = objDependencias.Titular;
                    txtNombAdmin.Text = objDependencias.Admin_Puesto;
                    txtAdministrador.Text = objDependencias.Administ;
                    txtNombramiento.Text = objDependencias.Titular_Puesto;
                    txtDomicilio.Text = objDependencias.Domicilio;
                    txtZonaEconomica.Text = objDependencias.Zona_Economica;
                    txtTelTitular.Text = objDependencias.Tel_Titular;
                    txtCelTitular.Text = objDependencias.Cel_Titular;
                    txtTelAdmin.Text = objDependencias.Tel_Admin;
                    txtCelAdmin.Text = objDependencias.Cel_Admin;
                    txtZonaEconomica.Text = objDependencias.Zona_Economica;
                    DDLCentroContab2.SelectedValue = objDependencias.C_Contab;
                    DDLEstado.SelectedValue = objDependencias.Id_Estado;
                    DDLMunicipio.SelectedValue = objDependencias.Id_Municipio;

                    Multiview1.ActiveViewIndex = 1;
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene los privilegios para realizar esta acción.')", true);                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("frmCatalogoDependencias.aspx", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void BTNEditarDependencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Dependencias objDependencias = new Dependencias();
                    objDependencias.Id = (String)Session["SessionIdDependencia"];
                    objDependencias.C_Contab = DDLCentroContab2.SelectedValue;
                    objDependencias.Clave = txtClvDepend.Text;
                    objDependencias.Descrip = txtDependencia.Text;
                    objDependencias.Titular = txtTitular.Text;
                    objDependencias.Administ = txtAdministrador.Text;
                    objDependencias.Admin_Puesto = txtNombAdmin.Text;
                    objDependencias.Titular_Puesto = txtNombramiento.Text;
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
                    CN_Dependencias.EditarDependencia(ref objDependencias, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha editado correctamente.')", true);                    
                    else if (Verificador == "1")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No se puede cambiar por una clave que ya existe.')", true);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene los privilegios para realizar esta acción.')", true);                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarCombosEditar()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab2, "p_ejercicio", SesionUsu.Usu_Ejercicio);                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Estados", ref DDLEstado, "p_pais", "parametro2", "1", "");                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Municipios", ref DDLMunicipio, "p_edo", "parametro2", "8", "");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void btnObtnerReporte(object sender, ImageClickEventArgs e)
        {
            try
            {
                string ruta1 = "";
                ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RPT-PRESUP_DEPENDENCIAS&Ejercicio=" + SesionUsu.Usu_Ejercicio;
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