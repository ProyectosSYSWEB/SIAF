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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente);//agregar el ejercicio al metodo y al sp
                DDLPartida.SelectedValue = "1";
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
                List<Adecuaciones> ListMod = new List<Adecuaciones>();
                Adecuaciones objAdecuacionMod = new Adecuaciones();
                int mesIni = Convert.ToInt32(DDLMesInicial.SelectedValue);
                int mesFin = Convert.ToInt32(DDLMesFin.SelectedValue);
                objAdecuacion.Partida = DDLPartida.SelectedValue;
                objAdecuacion.Fuente = DDLFuente.SelectedValue;
                objAdecuacion.MesIni = mesIni;
                objAdecuacion.MesFin = mesFin;
                CN_Adecuaciones.CapitulosGrid(objAdecuacion, ref List);
                GRDAdecuaciones.DataSource = List;
                GRDAdecuaciones.DataBind();
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
                CargarDatosAdecuacion();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}