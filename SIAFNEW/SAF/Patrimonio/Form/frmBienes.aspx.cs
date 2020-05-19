using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Patrimonio.Form
{
    public partial class frmBienes : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        Int32[] Celdas = new Int32[] { 0,1 };
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Bienes CNBienes = new CN_Bienes();
        Bienes ObjBienes = new Bienes();
        private static List<Comun> ListConceptos = new List<Comun>();
        private static List<Comun> Listcodigo = new List<Comun>();
        private static List<Comun> Subcuentas = new List<Comun>();
        int guar_continue;
       

        #endregion  



        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                inicializar();
            }
        }

        protected void inicializar()
        {
            MultiViewBienes.ActiveViewIndex = 0;
            cargarcombos();
            lblError.Text= string.Empty;
            CargarGrid();

        }

        protected void cargarcombos()
        {
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Basicos", ref ddlGrupo, "P_TIPO","PAT_CAT_GRUPOS");
            CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubGrupos", ref ddlSubgrupo, "p_id_grupo", ddlGrupo.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_Clases", ref ddlClase, "p_id_grupo", "p_id_subgrupo", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubClases", ref ddlSubclase, "p_id_grupo", "p_id_subgrupo", "p_id_clase", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue, ddlClase.SelectedValue);
            //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Cuentas", ref ddlCuenta, "p_ejercicio", SesionUsu.Usu_Ejercicio);
            //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_SubCuentas", ref ddlSubcuent,"p_cuenta", "p_ejercicio", ddlCuenta.SelectedValue, SesionUsu.Usu_Ejercicio);
            //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Nivel", ref ddlNive, "p_subcuenta","p_ejercicio", ddlSubcuent.SelectedValue, SesionUsu.Usu_Ejercicio);

      
        }

        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                grdBienes.DataSource = dt;
                grdBienes.DataSource = GetList();
                grdBienes.DataBind();
                CNComun.HideColumns(grdBienes, Celdas);
            }
            catch (Exception ex)
            {
                lblError.Text= "No se encontró ningún dato. Verifique su busqueda. " + ex.Message; 
            }
        }

        private List<Bienes> GetList()
        {
            try
            {
                List<Bienes> List = new List<Bienes>();

                ObjBienes.Partida = txtBuscar.Text;
                ObjBienes.Status = rbnStatus2.SelectedValue;
                CNBienes.Consultar_Bienes(ref ObjBienes, txtBuscar.Text, ref List);
                lblCount.Text="No. de claves encontradas: "+List.Count().ToString();
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // empieza para paginado del grid 
       
     
        private void CargarGrid(int indexCopia)
        {
            lblError.Text= string.Empty;
            grdBienes.DataSource = null;
            grdBienes.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdBienes.DataSource = dt;
                grdBienes.DataSource = GetList();
                grdBienes.DataBind();

                if (grdBienes.Rows.Count > 0)
                {
                    CNComun.HideColumns(grdBienes, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text= "No se encontró ningún dato. Verifique su busqueda. " + ex.Message;
            }
        }

        // termina paginado del grid

        protected void index_linbtn(object sender)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdBienes.SelectedIndex = row.RowIndex;
            ObjBienes.Id = grdBienes.SelectedRow.Cells[0].Text;

        }

        
        private void GuardarDatos()
        {

            lblError.Text= string.Empty;
            ObjBienes = new Bienes();

            ddlGrupo.Enabled = false;
            ddlSubgrupo.Enabled = false;
            ddlClase.Enabled = false;
            ddlSubclase.Enabled = false;
       
            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {

                    ObjBienes.Clave = txtClave.Text + txtConsecutivo.Text;
                    ObjBienes.Status = rbnStatus.SelectedValue;
                    ObjBienes.Descripcion = txtDescripcion.Text;
                    ObjBienes.Grupo = ddlGrupo.SelectedValue;
                    ObjBienes.Subgrupo = ddlSubgrupo.SelectedValue;
                    ObjBienes.Clase = ddlClase.SelectedValue;
                    ObjBienes.Subclase = ddlSubclase.SelectedValue;
                    ObjBienes.Consecutivo = txtConsecutivo.Text;
                    ObjBienes.Cuenta = ddlCuenta.SelectedValue;
                    ObjBienes.Subcuenta = ddlSubcuent.SelectedValue;
                    ObjBienes.Nivel =txtNivel.Text;
                    //ObjBienes.Nivel = ddlNive.SelectedValue;
                    ObjBienes.Partida = txtClave.Text;
                    ObjBienes.Por_lote = rblPorlote.SelectedValue;
                    ObjBienes.Conjunto = rblConjunto.SelectedValue;

                    CNBienes.Insertar_Bienes(ref ObjBienes, ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion();", true);

                }
                else
                {
                    ObjBienes.Id = grdBienes.Rows[grdBienes.SelectedIndex].Cells[0].Text;
                    ObjBienes.Status = rbnStatus.SelectedValue;
                    ObjBienes.Cuenta=ddlCuenta.SelectedValue;
                    ObjBienes.Subcuenta=ddlSubcuent.SelectedValue;
                    ObjBienes.Nivel = txtNivel.Text;
                    //ObjBienes.Nivel=ddlNive.SelectedValue;
                    ObjBienes.Por_lote=rblPorlote.SelectedValue;
                    ObjBienes.Conjunto = rblConjunto.SelectedValue;
                    ObjBienes.Descripcion = txtDescripcion.Text;

                    CNBienes.Editar_Bienes(ref ObjBienes, ref Verificador);
                    SesionUsu.Editar = 0;
                    CargarGrid();
                                  
                }
                if (Verificador != "0")
                {
                    lblError.Text= Verificador;
                }
                else
                {
                    if (guar_continue == 0)
                    {
                     CNComun.HideColumns(grdBienes, Celdas);
                   
                     SesionUsu.Editar = 0;
                     MultiViewBienes.ActiveViewIndex = 0;
                    }
                    else
                    {
                        
                       
                    }
                    CargarGrid();
                    lblError.Text= "Se guardó correctamente el registro.";

                }

            }
            catch (Exception ex)
            {
                lblError.Text= "No se pudo guardar el registro. Verifique datos y/o conexión a internet. " + ex.Message;
            }
        }
        
        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbnStatus.SelectedValue = "S";
           CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubGrupos", ref ddlSubgrupo, "p_id_grupo", ddlGrupo.SelectedValue);
        }

        protected void ddlSubgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_Clases", ref ddlClase, "p_id_grupo", "p_id_subgrupo",ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue);
            
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }


        protected void ddlClase_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubClases", ref ddlSubclase, "p_id_grupo", "p_id_subgrupo", "p_id_clase", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue, ddlClase.SelectedValue);
         
        }

        protected void grdBienes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lblError.Text= string.Empty;
                rbnStatus.Items[1].Enabled = true;
                txtDescrPart.Enabled = false;
                txtConsecutivo.Enabled = false;
                ddlGrupo.Enabled = false;
                ddlSubgrupo.Enabled = false;
                ddlClase.Enabled = false;
                ddlSubclase.Enabled = false;
                txtClave.Enabled = false;

                MultiViewBienes.ActiveViewIndex = 1;
                SesionUsu.Editar = 1;
                int v = grdBienes.SelectedIndex;

                ObjBienes.Id = grdBienes.Rows[v].Cells[0].Text;
                CNBienes.Consulta_Bien(ref ObjBienes, ref Verificador);

                if (Verificador == "0")
                {
                    txtClave.Text= ObjBienes.Partida;
                    rbnStatus.SelectedValue = ObjBienes.Status;
                    txtDescripcion.Text= ObjBienes.Descripcion; 
                    txtConsecutivo.Text=ObjBienes.Consecutivo;
                    ddlGrupo.SelectedValue=ObjBienes.Grupo;
                 
                     CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubGrupos", ref ddlSubgrupo, "p_id_grupo", ddlGrupo.SelectedValue);
                     ddlSubgrupo.SelectedValue=ObjBienes.Subgrupo;

                    CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_Clases", ref ddlClase, "p_id_grupo", "p_id_subgrupo", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue);
                    ddlClase.SelectedValue=ObjBienes.Clase;

                    CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubClases", ref ddlSubclase, "p_id_grupo", "p_id_subgrupo", "p_id_clase", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue, ddlClase.SelectedValue);
                    ddlSubclase.SelectedValue=ObjBienes.Subclase;

                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Cuentas_partida", ref ddlCuenta, "p_partida", "p_ejercicio", ObjBienes.Partida.Substring(0, 3), SesionUsu.Usu_Ejercicio);
                    ddlCuenta.SelectedValue=ObjBienes.Cuenta;

                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_SubCuentas", ref ddlSubcuent, "p_cuenta","p_ejercicio", ddlCuenta.SelectedValue, SesionUsu.Usu_Ejercicio);
                    ddlSubcuent.SelectedValue=ObjBienes.Subcuenta;
                    
                    rblPorlote.SelectedValue=ObjBienes.Por_lote;
                    rblConjunto.SelectedValue=ObjBienes.Conjunto;

                    ObjBienes.Partida = txtClave.Text;

                    //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Nivel", ref ddlNive, "p_subcuenta", "p_ejercicio", ddlSubcuent.SelectedValue, SesionUsu.Usu_Ejercicio);
                    
                    try
                    {
                        txtNivel.Text=ObjBienes.Nivel ;
                        //ddlNive.SelectedValue = ObjBienes.Nivel;
                    }

                    catch (Exception ex)
                    { lblError.Text= "No se pudo obtener la información deseada. Intente nuevamente. " + ex.Message;  }
       
                    CNBienes.Consulta_clave(ref ObjBienes, ref Verificador);
                    txtDescrPart.Text = ObjBienes.DesPartida;

                    ImageButton2.Visible = false;
                    MultiViewBienes.ActiveViewIndex = 1;
                    btnContinuar.Visible = false;

                }
                else
                {
                    lblError.Text= Verificador;
                }

            }
            catch (Exception ex)
            {

                lblError.Text= "No se pudo obtener la información deseada. Intente nuevamente. " + ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
                               
           GuardarDatos();
        }

       
         

        protected void lblEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text= string.Empty;
                index_linbtn(sender);
                ObjBienes.Id = grdBienes.SelectedRow.Cells[0].Text;
                Verificador = string.Empty;
                CNBienes.Eliminar_Bienes(ref ObjBienes, ref Verificador);

                if (Verificador != "0")
                {
                    lblError.Text= Verificador;

                }
                else
                {
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion('" + Verificador + "');", true);
                    CargarGrid();
                }

            }
            catch (Exception ex)
            {
                lblError.Text= "No se pudo eliminar el registro. " + ex.Message;
            }
        }


        protected void grdBienes_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdBienes.PageIndex = 0;
            grdBienes.PageIndex = e.NewPageIndex;
            CargarGrid(0);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblError.Text= string.Empty;
            SesionUsu.Editar = 0;

            txtDescrPart.Text = string.Empty;
            txtConsecutivo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlGrupo.Enabled = false;
            ddlSubgrupo.Enabled = false;
            ddlClase.Enabled = false;
            ddlSubclase.Enabled = false;
            MultiViewBienes.ActiveViewIndex = 0;
           
        }

        protected void ddlCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_SubCuentas", ref ddlSubcuent, "p_cuenta","p_ejercicio", ddlCuenta.SelectedValue, SesionUsu.Usu_Ejercicio);
                //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Nivel", ref ddlNive, "p_subcuenta", "p_ejercicio", ddlSubcuent.SelectedValue, SesionUsu.Usu_Ejercicio);
            }
            catch (Exception ex)
            {
                lblError.Text= "No se encontró ningún dato. Verifique su busqueda. " + ex.Message;
            }
       }

        protected void ddlSubclase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
         {
             ddlGrupo.Enabled = false;
             ddlSubgrupo.Enabled = false;
             ddlClase.Enabled = false;
             ddlSubclase.Enabled = false;
             txtDescrPart.Text = string.Empty; 
             txtDescrPart.Enabled = false;
             txtConsecutivo.Text = string.Empty;
             lblError.Text= string.Empty;
             try
             {
                     ObjBienes.Partida = txtClave.Text;
                     CNBienes.Consulta_clave(ref ObjBienes, ref Verificador);

                     if (Verificador == "0")
                     {
                         txtDescrPart.Text = ObjBienes.DesPartida;
                         txtConsecutivo.Text = ObjBienes.Consecutivo;
                         ddlGrupo.SelectedValue = ObjBienes.Grupo;
                         CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubGrupos", ref ddlSubgrupo, "p_id_grupo", ddlGrupo.SelectedValue);
                         ddlSubgrupo.SelectedValue = ObjBienes.Subgrupo;
                         CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_Clases", ref ddlClase, "p_id_grupo", "p_id_subgrupo", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue);
                         ddlClase.SelectedValue = ObjBienes.Clase;
                         CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_SubClases", ref ddlSubclase, "p_id_grupo", "p_id_subgrupo", "p_id_clase", ddlGrupo.SelectedValue, ddlSubgrupo.SelectedValue, ddlClase.SelectedValue);
                         ddlSubclase.SelectedValue = ObjBienes.Subclase;
                    
                        CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Cuentas_partida", ref ddlCuenta, "p_partida","p_ejercicio" ,ObjBienes.Partida.Substring(0,3),SesionUsu.Usu_Ejercicio,ref Subcuentas);
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_SubCuentas", ref ddlSubcuent, "p_cuenta", "p_ejercicio", ddlCuenta.SelectedValue, SesionUsu.Usu_Ejercicio);
                    ddlSubcuent.SelectedValue = Subcuentas[ddlCuenta.SelectedIndex].EtiquetaDos;
                    //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Nivel", ref ddlNive, "p_subcuenta","p_ejercicio", ddlSubcuent.SelectedValue, SesionUsu.Usu_Ejercicio);
                    txtNivel.Text = ObjBienes.Nivel;
                     }
                     else {

                    //lblError.Text= "Esta Partida aún no existe, por favor verifique con el área correspondiente";
                    lblError.Text = Verificador;


                    //txtDescrBien.Enabled = true;
                    //txtConsecutivo.Enabled = true;
                    //ddlGrupo.Enabled = true;
                    //ddlSubgrupo.Enabled = true;
                    //ddlClase.Enabled = true;
                    //ddlSubclase.Enabled = true;

                }
                 
             }
             catch (Exception ex)
             {
                 lblError.Text= lblError.Text= "No se encontró ningun dato. Verifique su busqueda. " + ex.Message;
             }
           
         }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text= string.Empty;

            try
            {

                        CargarGrid();

            }
            catch (Exception ex)
            {
                lblError.Text= "No se encontró ningún dato. Verifique su busqueda. "+ ex.Message;
            }
           

        }

        protected void ddlSubcuent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Nivel", ref ddlNive, "p_subcuenta", "p_ejercicio", ddlSubcuent.SelectedValue, SesionUsu.Usu_Ejercicio);
              // string resultado = ddlNive.SelectedItem.ToString();
            //txtDescripcion.Text = resultado.Substring(8);
            }
            catch (Exception ex)
            {
                lblError.Text= ex.Message;
            }
        }

        protected void ddlNive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string resultado = ddlNive.SelectedItem.ToString();
            //txtDescripcion.Text = resultado.Substring(8);
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            cargarcombos();
            txtDescripcion.Text = string.Empty;
            guar_continue = 1;
            GuardarDatos();
        }

        protected void BTNver_reporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Bienes&catalogo=" + txtBuscar.Text + "&status=" + rbnStatus2.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Bienes_xls&catalogo=" + txtBuscar.Text + "&status=" + rbnStatus2.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text= string.Empty;
            txtDescripcion.ReadOnly = false;
            rbnStatus.Items[1].Enabled = false;

            cargarcombos();

            txtClave.Text = string.Empty;
            txtConsecutivo.Text = string.Empty;
            txtDescrPart.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNivel.Text = string.Empty;
            btnContinuar.Visible = true;
            txtClave.Enabled = true;

            txtDescrPart.Enabled = false;
            ImageButton2.Visible = true;
            MultiViewBienes.ActiveViewIndex = 1;
        }
    }
}