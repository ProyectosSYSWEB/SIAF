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
        }



        protected void GRDCargarDatosCentrosContab()
        {
            try
            {
                Partidas objPartidas = new Partidas();
                objPartidas.Ejercicio = SesionUsu.Usu_Ejercicio;
                List<Partidas> list = new List<Partidas>();
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