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
    public partial class frmPartida : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Partida CN_Partida = new CN_Partida();
        CN_Comun CNComun = new CN_Comun();
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
            GRDCargarDatosCentrosContab();
            CargarCombo();
        }

        private void CargarCombo ()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubCapitulo", ref DDLClave, "p_capitulo", "p_nivel", "X", "2");
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }



        protected void GRDCargarDatosCentrosContab()
        {
            try
            {
                Partidas objPartidas = new Partidas();
                objPartidas.Ejercicio = SesionUsu.Usu_Ejercicio;
                List<Partidas> list = new List<Partidas>();
                objPartidas.SubCapt = "0";
                CN_Partida.PartidasGrid(ref objPartidas, ref list);                
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDPartidas.DataSource = list;
                GRDPartidas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Partidas objPartidas = new Partidas();
                objPartidas.Ejercicio = SesionUsu.Usu_Ejercicio;
                List<Partidas> list = new List<Partidas>();
                objPartidas.SubCapt = DDLClave.SelectedValue.Substring(0, 2);
                CN_Partida.PartidasGrid(ref objPartidas, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDPartidas.DataSource = list;
                GRDPartidas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}