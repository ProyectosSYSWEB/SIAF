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
    public partial class FRMAyuda_Busqueda_Codigo : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        string USERBD = "ADQUISICIONES";
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
               // inicializar();
                cargarcombos();

            }
           
        }
        protected void cargarcombos()
        {
            string   usuario = SesionUsu.Usu_Nombre;
            string  ejercicio = SesionUsu.Usu_Ejercicio;
             CNComun.LlenaCombo("pkg_spada_saf.OBT_COMBO_DEPENDENCIAS",USERBD , "p_usuario", SesionUsu.Usu_Nombre , ref DDLDependencia);
             CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Funcion_Programas", USERBD, ref DDLPrograma);
             CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_SubProgramas", USERBD, ref DDLSubPrograma);
             CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Proyectos", USERBD, ref DDLProyecto);
             CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Partidas", USERBD, ref DDLPartida);
             CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Fuentes", USERBD, ref DDLFuente);


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

                GridCodigo.DataSource = dt;
                GridCodigo.DataSource = GetList();
                GridCodigo.DataBind();

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

                objadquisiciones.Dependencia  = DDLDependencia.SelectedValue   ;
                objadquisiciones.Funcion_programa  = DDLPrograma.SelectedValue ;
                objadquisiciones.Subprograma = DDLSubPrograma.SelectedValue;
                objadquisiciones.Proyecto = DDLProyecto.SelectedValue;
                objadquisiciones.Partida = DDLPartida.SelectedValue;
                objadquisiciones.Fuente = DDLFuente.SelectedValue;

                CNadquisiciones.Grid_codigo(ref objadquisiciones, ref   List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void GridCodigo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridCodigo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLSubPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLPartida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrid();

        }
    }
}