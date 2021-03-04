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
    public partial class frmCatalogoCapitulos : System.Web.UI.Page
    {

        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Capitulo CN_Capitulo = new CN_Capitulo();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
        }

        protected void BTNGuardarCap_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Basicos objBasicos = new Basicos();
                    string Verificador = string.Empty;
                    objBasicos.clave = txtCap.Text;
                    objBasicos.descripcion = txtDescrip.Text;
                    objBasicos.valor = txtNvl.Text;
                    objBasicos.tipo = "CAT_CAPITULO";
                    objBasicos.status = "A";
                    CN_Capitulo.InsertarCapitulo(ref objBasicos, ref Verificador);
                }
                else
                {
                    lblError.Text = lblError.Text = "No tiene los privilegios para realizar esta acción";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}