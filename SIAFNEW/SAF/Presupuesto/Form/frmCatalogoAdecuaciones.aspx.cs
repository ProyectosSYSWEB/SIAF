using System;
using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SAF.Presupuesto.Form
{
    public partial class frmCatalogoAdecuaciones : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        Adecuaciones objAdecuacion = new Adecuaciones();
        CN_Adecuaciones CN_Adecuaciones = new CN_Adecuaciones();
        List<Adecuaciones> Lista = new List<Adecuaciones>();
        List<Adecuaciones> ListOrigen = new List<Adecuaciones>();
        double sumaInternaDestino = 0;
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
                lblError.Text = string.Empty;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Partidas", ref DDLPartida);
                DDLPartida.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                DDLPartida.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Adecuaciones", ref DDLCodOrigen, "p_partida", "p_fuente", DDLPartida.SelectedValue, DDLFuente.SelectedValue);
                //CargarDatosAdecuacion();
                //CargarComboCodProg();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarDatosAdecuacion()
        {
            try
            {                
                int mesIni = Convert.ToInt32(DDLMesInicial.SelectedValue);
                int mesFin = Convert.ToInt32(DDLMesFin.SelectedValue);
                decimal suma = 0;
                objAdecuacion.Partida = DDLPartida.SelectedValue;
                objAdecuacion.Fuente = DDLFuente.SelectedValue;
                objAdecuacion.MesIni = mesIni;
                objAdecuacion.MesFin = mesFin;
                objAdecuacion.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_Adecuaciones.CapitulosGrid(objAdecuacion, ref Lista);
                GRDAdecuaciones.DataSource = Lista;
                GRDAdecuaciones.DataBind();
                for (int i = 0; i < Lista.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(Lista[i].Destino);
                }
                SumaDestino.Text = Convert.ToString(suma);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarComboCodProg()
        {
            try
            {
                DDLCodOrigen.Enabled = false;                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Adecuaciones", ref DDLCodOrigen, "p_partida", "p_fuente", DDLPartida.SelectedValue, DDLFuente.SelectedValue);
                //ObtenerDatosCodigoOrigen(DDLCodOrigen.SelectedValue);
                DDLCodOrigen.Enabled = true;
            }
            catch (Exception ex)
            {
                DDLCodOrigen.Enabled = true;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void ObtenerDatosCodigoOrigen(string CodigoOrigen)
        {
            try
            {                
                string Verificador = string.Empty;
                decimal suma = 0;
                objAdecuacion.Codigo_Programatico = CodigoOrigen;
                CN_Adecuaciones.ObtenerDatosCogidoAdecuaciones(ref objAdecuacion, ref Verificador);
                if (Verificador == "0")
                {
                    for (int i = 0; i < Lista.Count; i++)
                    {
                        suma = suma + Convert.ToDecimal(Lista[i].Suma_Destino);
                    }
                    SumaDestino.Text = Convert.ToString(suma);
                    Session["ListaAdecunacion"] = Lista;
                    Lista.Add(objAdecuacion);
                    GRDAdecuaciones.DataSource = Lista;
                    GRDAdecuaciones.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
       

        protected void CargarConceptoDocto()
        {
            try
            {                
                string Mes = txtfechaDocumento.Text;
                Mes = Mes.Replace("/", "");
                string Anio = Mes;
                Mes = Mes.Substring(2, 2);
                Anio = Anio.Substring(6, 2);
                int tamañoCadena = DDLPartida.SelectedItem.Text.Length;
                string Descripcion = DDLPartida.SelectedItem.Text;
                tamañoCadena = tamañoCadena - 8;
                Descripcion = Descripcion.Substring(8, tamañoCadena);
                txtConcepto.Text = "AMPLIACIÓN RP = " + Descripcion + " ** MES = " + Mes + Anio;
                txtMesAnio.Text = Mes + Anio;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }        

        protected void BTNSumarDestinos_Click(object sender, EventArgs e)
        {
            try
            {                
                for (int i = 0; i < GRDAdecuaciones.Rows.Count - 1; i++)
                {
                    TextBox destino = GRDAdecuaciones.Rows[i].FindControl("txtEditDestino") as TextBox;                    
                    sumaInternaDestino = sumaInternaDestino + Convert.ToDouble(Regex.Replace(destino.Text, @"[\s@$]", ""));
                }
                SumaDestinoMod.Text =  Convert.ToString(sumaInternaDestino);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void BTNBuscarAdecuacion_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Buscando.')", true);
                CargarDatosAdecuacion();
                CargarConceptoDocto();                
                ObtenerDatosCodigoOrigen(DDLCodOrigen.SelectedValue);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '.')", false);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                CargarComboCodProg();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void DDLPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                CargarComboCodProg();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void BTNGuardarAdecuacion_Click(object sender, EventArgs e)
        {
            try
            {                
                string Verificador = string.Empty;                
                List<Adecuaciones> ListaAdecuaciones = new List<Adecuaciones>();
                Adecuaciones objAdecuaciones = new Adecuaciones();
                ListaAdecuaciones = (List<Adecuaciones>)Session["ListaAdecunacion"];
                for (int i = 0; i < GRDAdecuaciones.Rows.Count - 1; i++)
                {
                    TextBox destino = GRDAdecuaciones.Rows[i].FindControl("txtEditDestino") as TextBox;
                    TextBox origenTxt = GRDAdecuaciones.Rows[i].FindControl("txtEditOrigen") as TextBox;
                    sumaInternaDestino = sumaInternaDestino + Convert.ToDouble(Regex.Replace(destino.Text, @"[\s@$]", ""));
                    ListaAdecuaciones[i].Destino = Regex.Replace(destino.Text, @"[\s@$@,]", "");
                    ListaAdecuaciones[i].Origen = Regex.Replace(origenTxt.Text, @"[\s@$@,]", "");
                }
                int registro = GRDAdecuaciones.Rows.Count;
                TextBox origen = GRDAdecuaciones.Rows[registro - 1].FindControl("txtEditOrigen") as TextBox;
                string cantOrigen = Regex.Replace(origen.Text, @"[\s@$]", "");
                double cantidadOrigen = Convert.ToDouble(cantOrigen);
                double cantidadDestino = 0;
                if (SumaDestinoMod.Text != "")
                    cantidadDestino = Convert.ToDouble(SumaDestinoMod.Text);
                else
                    cantidadDestino = Convert.ToDouble(SumaDestino.Text);
                if (cantidadDestino > cantidadOrigen || cantidadOrigen < cantidadDestino)
                    lblError.Text = "No se puede realizar una adecuación con el destino mayor al origen";
                else
                {                    
                    objAdecuaciones.Fecha = txtfechaDocumento.Text;
                    objAdecuaciones.MesAnio = txtMesAnio.Text;
                    objAdecuaciones.Descripcion = txtConcepto.Text;
                    objAdecuaciones.Ejercicio = SesionUsu.Usu_Ejercicio;
                    objAdecuaciones.Usuario = SesionUsu.Usu_Nombre;
                    objAdecuaciones.MesIni = Convert.ToInt32(DDLMesInicial.SelectedValue);
                    objAdecuaciones.MesFin = Convert.ToInt32(DDLMesFin.SelectedValue);
                    CN_Adecuaciones CN_Adecuaciones = new CN_Adecuaciones();
                    CN_Adecuaciones.InsertarDocumentoAdecuacion(ListaAdecuaciones, objAdecuaciones, ref Verificador);
                    if (Verificador != "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" +Verificador + ".')", true);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha guardado correctamente.')", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
    }
}