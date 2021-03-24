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
    public partial class frmFuenteFin : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_FuenteFin CN_FuenteFin = new CN_FuenteFin();
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
            GRDFuenteFinan();
        }

        protected void GRDFuenteFinan()
        {
            try
            {
                Multiview1.ActiveViewIndex = 0;
                FuentesFin objFuenteFin = new FuentesFin();
                List<FuentesFin> list = new List<FuentesFin>();
                objFuenteFin.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_FuenteFin.FuentesGrid(ref objFuenteFin, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDFuenteFin.DataSource = list;
                GRDFuenteFin.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDFuenteFin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDFuenteFin.Rows[fila].Cells[2].Text);
            //    if (SesionUsu.Usu_TipoUsu == "SU")
            //    {
            //        CN_Dependencias.EliminarDependencia(ref objDependencias, ref Verificador);
            //        if (Verificador == "0")
            //            lblError.Text = "Se ha eliminado correctamente";
            //        else
            //            lblError.Text = Verificador;
            //    }
            //    else
            //    {
            //        lblError.Text = Verificador;
            //    }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDFuenteFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FuentesFin objFuenteFin = new FuentesFin();
                string Verificador = string.Empty;
                objFuenteFin.Id = Convert.ToString(GRDFuenteFin.SelectedRow.Cells[2].Text);
                Session["SessionIdFuenteFin"] = objFuenteFin;
                objFuenteFin.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_FuenteFin.ObtenerDatosFuenteFin(ref objFuenteFin, ref Verificador);
                if (Verificador == "0")
                {
                    txtFuente.Text = objFuenteFin.Fuente;
                    txtDescrip.Text = objFuenteFin.Descrip;
                    Multiview1.ActiveViewIndex = 1;
                }
                else
                    lblError.Text = Verificador;
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
                Response.Redirect("frmCatFuenteFin.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNEditarFuenteFin_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    FuentesFin objFuenteFin = new FuentesFin();
                    string Verificador = string.Empty;
                    objFuenteFin = (FuentesFin)Session["SessionIdFuenteFin"];
                    //objFuenteFin.Ejercicio = SesionUsu.Usu_Ejercicio;
                    objFuenteFin.Fuente = txtFuente.Text;
                    objFuenteFin.Descrip = txtDescrip.Text;
                    CN_FuenteFin.EditarFuenteFin(ref objFuenteFin, ref Verificador);
                    if(Verificador == "0")
                    {
                        lblError.Text = "Se han realizado los cambios correctamente";
                    }
                    else
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene los privilegios para realizar esta acción";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}