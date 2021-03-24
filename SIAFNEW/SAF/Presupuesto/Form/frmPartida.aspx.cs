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
                Multiview1.ActiveViewIndex = 0;
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

        protected void GRDPartidas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDPartidas.Rows[fila].Cells[3].Text);
                //if (SesionUsu.Usu_TipoUsu == "SU")
                //{
                //    CN_Dependencias.EliminarDependencia(ref objDependencias, ref Verificador);
                //    if (Verificador == "0")
                //        lblError.Text = "Se ha eliminado correctamente";
                //    else
                //        lblError.Text = Verificador;
                //}
                //else
                //{
                //    lblError.Text = Verificador;
                //}
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(SesionUsu.Usu_TipoUsu == "SA")
                {
                    Partidas objPartida = new Partidas();
                    string Verificador = string.Empty;
                    objPartida.Id = Convert.ToString(GRDPartidas.SelectedRow.Cells[4].Text);
                    objPartida.Ejercicio = Convert.ToString(GRDPartidas.SelectedRow.Cells[3].Text);
                    Session["SessionIdPartida"] = objPartida.Id;
                    CN_Partida.ObtenerDatosPartida(ref objPartida, ref Verificador);
                    txtPartida.Text = objPartida.Clave;
                    txtDescrip.Text = objPartida.Descrip;
                    txtConcepto.Text = objPartida.Concepto;
                    txtEjercicio.Text = objPartida.Ejercicio;
                    Multiview1.ActiveViewIndex = 1;
                }
                else
                    lblError.Text = "No tiene los privilegios para realizar esta acción";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("frmCatalogoPartidas.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNEditarPartida_Click(object sender, EventArgs e)
        {
            try
            {
                if(SesionUsu.Usu_TipoUsu == "SA")
                {
                    Partidas objPartida = new Partidas();
                    string Verificador = string.Empty;
                    objPartida.Id = (String)Session["SessionIdPartida"];
                    objPartida.Clave = txtPartida.Text;
                    objPartida.Descrip = txtDescrip.Text;
                    objPartida.Concepto = txtConcepto.Text;
                    objPartida.Ejercicio = txtEjercicio.Text;
                    CN_Partida.EditarPartida(ref objPartida, ref Verificador);
                    if (Verificador == "0")
                        lblError.Text = "Se han realizado los cambios correctamente";
                    else
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene los privilegios para realizar esta acción";
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}