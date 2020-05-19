using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Adquisiciones.Form
{
    public partial class FRMTablainformativa : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Adquisiciones CNadquisiciones = new CN_Adquisiciones();
        Adquisicion objadquisiciones = new Adquisicion();


        private static List<Comun> ListConceptos = new List<Comun>();

        #endregion     
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();
                cargarcombos();

            }
           
       
        }
     protected void cargarcombos()
        {
            //CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable);
            //CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor);
            
                
        }
     protected void inicializar()
     {
         CargarGrid();



     }
     private void CargarGrid()
     {
         try
         {
             DataTable dt = new DataTable();

             GrdTablaInformativa.DataSource = dt;
             GrdTablaInformativa.DataSource = GetList();
             GrdTablaInformativa.DataBind();

         }
         catch (Exception ex)
         {
             
         }
     }
     private List<Adquisicion> GetList()
     {
         try
         {
             List<Adquisicion> List = new List<Adquisicion>();

             objadquisiciones.ejercicio = SesionUsu.Usu_Ejercicio;
             objadquisiciones.Usu_nombre  = SesionUsu.Usu_Nombre;
             CNadquisiciones.Tabla_Informativa(ref objadquisiciones, ref   List);

             return List;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message);
         }
     }

     protected void GridTablaInformativa_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {

     }

     protected void GridTablaInformativa_RowDataBound(object sender, GridViewRowEventArgs e)
     {

     }

     protected void GrdTablaInformativa_SelectedIndexChanged(object sender, EventArgs e)
     {

     }
    }
}