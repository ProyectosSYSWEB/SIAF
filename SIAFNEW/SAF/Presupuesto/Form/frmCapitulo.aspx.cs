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
    public partial class frmCapitulo : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Capitulo CN_Capitulo = new CN_Capitulo();        
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
            GRDCargarDatosDepend();
        }

        protected void GRDCargarDatosDepend()
        {
            try
            {
                Basicos objBasicos = new Basicos();
                List<Basicos> list = new List<Basicos>();
                objBasicos.tipo = "CAT_CAPITULO";
                objBasicos.valor = "1";
                CN_Capitulo.CapitulosGrid(ref objBasicos, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCapitulos.DataSource = list;
                GRDCapitulos.DataBind();
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
                GridViewRow row = GRDCapitulos.Rows[rowIndex];
                
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
    }
}