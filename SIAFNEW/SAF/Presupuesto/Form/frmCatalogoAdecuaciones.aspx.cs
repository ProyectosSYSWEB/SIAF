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
                lblError.Text = ex.Message;
            }
        }
        protected void CargarDatosAdecuacion()
        {
            try
            {
                lblError.Text = string.Empty;
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
                lblError.Text = ex.Message;
            }
        }
        protected void CargarComboCodProg()
        {
            try
            {
                DDLCodOrigen.Enabled = false;
                lblError.Text = string.Empty;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Adecuaciones", ref DDLCodOrigen, "p_partida", "p_fuente", DDLPartida.SelectedValue, DDLFuente.SelectedValue);
                //ObtenerDatosCodigoOrigen(DDLCodOrigen.SelectedValue);
                DDLCodOrigen.Enabled = true;
            }
            catch (Exception ex)
            {
                DDLCodOrigen.Enabled = true;
                lblError.Text = ex.Message;
            }
        }
        protected void ObtenerDatosCodigoOrigen(string CodigoOrigen)
        {
            try
            {
                lblError.Text = string.Empty;
                string Verificador = string.Empty;
                decimal suma = 0;
                objAdecuacion.Codigo_Programatico = CodigoOrigen;
                CN_Adecuaciones.ObtenerDatosCogidoAdecuaciones(ref objAdecuacion, ref Verificador);
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
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
       

        protected void CargarConceptoDocto()
        {
            try
            {
                lblError.Text = string.Empty;
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
                lblError.Text = ex.Message;
            }
        }        

        protected void BTNSumarDestinos_Click(object sender, EventArgs e)
        {
            try
            {
                
                lblError.Text = string.Empty;
                for (int i = 0; i < GRDAdecuaciones.Rows.Count - 1; i++)
                {
                    TextBox destino = GRDAdecuaciones.Rows[i].FindControl("txtEditDestino") as TextBox;                    
                    sumaInternaDestino = sumaInternaDestino + Convert.ToDouble(Regex.Replace(destino.Text, @"[\s@$]", ""));
                }
                SumaDestinoMod.Text =  Convert.ToString(sumaInternaDestino);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNBuscarAdecuacion_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                CargarDatosAdecuacion();
                CargarConceptoDocto();                
                ObtenerDatosCodigoOrigen(DDLCodOrigen.SelectedValue);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                CargarComboCodProg();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                CargarComboCodProg();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNGuardarAdecuacion_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                string Verificador = string.Empty;                
                List<Adecuaciones> ListaAdecuaciones = new List<Adecuaciones>();
                Adecuaciones objAdecuaciones = new Adecuaciones();
                ListaAdecuaciones = (List<Adecuaciones>)Session["ListaAdecunacion"];
                for (int i = 0; i < GRDAdecuaciones.Rows.Count - 1; i++)
                {
                    TextBox destino = GRDAdecuaciones.Rows[i].FindControl("txtEditDestino") as TextBox;
                    sumaInternaDestino = sumaInternaDestino + Convert.ToDouble(Regex.Replace(destino.Text, @"[\s@$]", ""));
                    ListaAdecuaciones[i].Destino = Regex.Replace(destino.Text, @"[\s@$]", "");
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
                        lblError.Text = Verificador;
                    else
                        lblError.Text = "Se ha guardado correctamente";
                }
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;

            }
        }
    }
}