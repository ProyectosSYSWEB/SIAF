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
        double sumaDestino = 0;
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
                //CargarDatosAdecuacion();
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
                for (int i = 0; i < List.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(List[i].Destino);
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Adecuaciones", ref DDLCodOrigen, "p_partida", "p_fuente", DDLPartida.SelectedValue, DDLFuente.SelectedValue);
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
                lblError.Text = ex.Message;
            }
        }        

        protected void BTNSumarDestinos_Click(object sender, EventArgs e)
        {
            try
            {                
                for (int i = 0; i < GRDAdecuaciones.Rows.Count - 1; i++)
                {
                    TextBox destino = GRDAdecuaciones.Rows[i].FindControl("txtEditDestino") as TextBox;
                    sumaDestino = sumaDestino + Convert.ToDouble(destino.Text);
                }
                SumaDestinoMod.Text =  Convert.ToString(sumaDestino);
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
                int registro = GRDAdecuaciones.Rows.Count;
                TextBox origen = GRDAdecuaciones.Rows[registro].FindControl("txtEditDestino") as TextBox;
                double cantidadOrigen = Convert.ToDouble(origen.Text);
                double cantidadDestino = 0;
                if (SumaDestinoMod.Text != "")
                    cantidadDestino = Convert.ToDouble(SumaDestinoMod.Text);
                else
                    cantidadDestino = Convert.ToDouble(SumaDestino.Text);
                if (cantidadDestino > cantidadOrigen)
                    lblError.Text = "No se puede realizar una adecuación con el destino mayor al origen";
                else
                {

                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}