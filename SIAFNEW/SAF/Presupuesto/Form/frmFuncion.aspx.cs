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
    public partial class frmFuncion : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Funcion CN_Funcion = new CN_Funcion();
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
            GRDCargarDatosFuncion();
        }
        protected void GRDCargarDatosFuncion()
        {
            try
            {
                Funcion objFuncion = new Funcion();
                List<Funcion> listFuncion = new List<Funcion>();
                CN_Funcion.FuncionGrid(ref objFuncion, ref listFuncion);
                GRDFunciones.DataSource = listFuncion;
                GRDFunciones.DataBind();
                if (SesionUsu.Usu_TipoUsu != "SA")
                {
                    GRDFunciones.Columns.RemoveAt(3);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void GRDCapitulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GRDFunciones.Rows[rowIndex];

                //Fetch value of Name.
                string capEditar = (row.FindControl("clave") as Label).Text;

                Basicos objCap = new Basicos();
                objCap.clave = capEditar;
                Session["SessionCapituloEdit"] = objCap;
                Response.Redirect("frmCatalogoCapitulos.aspx", true);

                //(row.FindControl("clave") as TextBox).Text = "New" + name;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BtnEliminarRegistro(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GRDFunciones.Rows[rowIndex];
                string capEditar = (row.FindControl("clave") as Label).Text;

            }
            catch(Exception ex)
            {

            }
        }


    }
}