using System;
using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmCatalogoAdecuaciones : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        Adecuaciones objAdecuacion = new Adecuaciones();
        CN_Adecuaciones CN_Adecuaciones = new CN_Adecuaciones();
        List<Adecuaciones> List = new List<Adecuaciones>();
        List<Adecuaciones> ListOrigen = new List<Adecuaciones>();
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Partidas", ref DDLPartida);
                DDLPartida.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                DDLPartida.SelectedValue = "1";
                CargarDatosAdecuacion();
                CargarComboCodProg();
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
                int mesIni = Convert.ToInt32(DDLMesInicial.SelectedValue);
                int mesFin = Convert.ToInt32(DDLMesFin.SelectedValue);
                decimal suma = 0;
                objAdecuacion.Partida = DDLPartida.SelectedValue;
                objAdecuacion.Fuente = DDLFuente.SelectedValue;
                objAdecuacion.MesIni = mesIni;
                objAdecuacion.MesFin = mesFin;
                CN_Adecuaciones.CapitulosGrid(objAdecuacion, ref List);
                GRDAdecuaciones.DataSource = List;
                GRDAdecuaciones.DataBind();
                for(int i = 0; i< List.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(List[i].Destino);
                }
                SumaDestino.Text =  Convert.ToString(suma);
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Adecuaciones", ref DDLCodOrigen, "p_partida", "p_fuente", objAdecuacion.Partida, objAdecuacion.Fuente);
                ObtenerDatosCodigoOrigen(DDLCodOrigen.SelectedValue);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
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
                for (int i = 0; i < List.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(List[i].Destino);
                }
                SumaDestino.Text = Convert.ToString(suma);
                List.Add(objAdecuacion);
                GRDAdecuaciones.DataSource = List;
                GRDAdecuaciones.DataBind();
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatosAdecuacion();
                CargarConceptoDocto();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void DDLCodOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatosAdecuacion();
                ObtenerDatosCodigoOrigen(DDLCodOrigen.SelectedValue);                
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
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
                string Descripcion = DDLPartida.SelectedItem.Text.Substring(8, DDLPartida.SelectedItem.Text.Length);

                txtConcepto.Text = "AMPLIACIÓN RP = " + Descripcion + " ** MES = " + Mes+ Anio;
                txtMesAnio.Text = Mes + Anio;
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}