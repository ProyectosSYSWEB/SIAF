using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF
{
    public partial class DefaultMovtos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Comun Comun = new Comun();
        Presupues objPresupuesto =new Presupues();
        Mnu mnu = new Mnu();
        List<Mnu> lstMenu = new List<Mnu>();
        List<Presupues> lstPres = new List<Presupues>();

        CN_Mnu CNMnu = new CN_Mnu();
        CN_Comun CNMonitor = new CN_Comun();
        CN_Comun CNComun = new CN_Comun();
        CN_Informativa CNInformativa = new CN_Informativa();
        cuentas_contables Objinformativa = new cuentas_contables();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                mnu.UsuarioNombre = SesionUsu.Usu_Nombre;
                mnu.Grupo = 1;
                mnu.IdPadre = 15648;
                CNMnu.LlenarTreeDef(mnu, ref lstMenu);
                grdMenu.DataSource = lstMenu;
                grdMenu.DataBind();

                //objPresupuesto.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                //CNMnu.LlenarTree2(ref trvMenu, mnu, lstMenu);



                //}
            }
        }

        private void MenuArbol()
        {
           
        }

        //private void CargarTree(List<Menu> List)
        //{
        //    lblMensaje.Text = string.Empty;
        //    try
        //    {
        //        grdDetalles.DataSource = ListDocDet;
        //        grdDetalles.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }
        //}
        private List<Menu> GetList()
        {
            try
            {
                List<Menu> List = new List<Menu>();
                mnu.NombreMenu = "Movimientos";
                //CNMnu.LlenarTreeDef();
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}