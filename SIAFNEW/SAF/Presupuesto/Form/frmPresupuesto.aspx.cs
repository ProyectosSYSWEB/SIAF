using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto
{
    public partial class frmPresupuesto : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Mnu mnu = new Mnu();
        Presupues objPresupuesto = new Presupues();
        CN_Mnu CN_mnu = new CN_Mnu();
        CN_Presupuesto CNPresupuesto = new CN_Presupuesto();
        List<Presupues> listPresupuesto = new List<Presupues>();

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
            objPresupuesto.Ejercicio =Convert.ToInt32(SesionUsu.Usu_Ejercicio);
            CN_mnu.LlenarTree(ref trvPresupuesto, objPresupuesto, listPresupuesto);
           
        }
       
     

    }

}