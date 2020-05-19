using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Form
{
    public partial class frmVentaSemovientes : System.Web.UI.Page
    {
        #region <Variables>
        
        string Verificador = string.Empty;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
        CN_Usuario CNUsuario = new CN_Usuario();
        Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
        List<Bien_Detalle> ListSemPreAutorizados = new List<Bien_Detalle>();
        List<Comun> ListSemCandidatos = new List<Comun>();
        private static List<Comun> ListCentroContable = new List<Comun>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {               
                Inicializar();
            }
        }


        #region <Funciones y Sub>
        private void Inicializar()
        {
            SesionUsu.Editar = -1;
            MultiView1.ActiveViewIndex = 0;
            Cargarcombos();
            }
        

        private void Cargarcombos()
        {
           lblError.Text = string.Empty;
           CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDependencia, "p_usuario",  SesionUsu.Usu_Nombre, ref ListCentroContable);
        }
        private void CargarGrid()
        {
           lblError.Text = string.Empty;
            grvSemovientesAV.DataSource = null;
            grvSemovientesAV.DataBind();
            Int32[] Celdas = new Int32[] { 0, 8 };
            try
            {
                DataTable dt = new DataTable();
                grvSemovientesAV.DataSource = dt;
                grvSemovientesAV.DataSource = GetList();
                grvSemovientesAV.DataBind();               

                if (grvSemovientesAV.Rows.Count > 0)
                {
                    OcultaColumna(grvSemovientesAV, Celdas);
                }
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }


        public void OcultaColumna(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                }
            }
        }

        private void CargarGridDetalle(List<Bien_Detalle> ListAutorizados)
        {
           lblError.Text = string.Empty;           
            try
            {
                grvSemPreAutorizados.DataSource = ListAutorizados;
                grvSemPreAutorizados.DataBind();
                Int32[] Celdas = new Int32[] { 0 };
                if (grvSemPreAutorizados.Rows.Count > 0)
                    CNComun.HideColumns(grvSemPreAutorizados, Celdas); 
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }
         
        private List<Bien_Detalle> GetList()
        {
            try
            {
                List<Bien_Detalle> List = new List<Bien_Detalle>();
                Bien Parametros = new Bien();
                Parametros.Dependencia = DDLDependencia.SelectedValue;
                Parametros.Estatus = DDLStatus.SelectedValue;
                
                CNBien.ConsultarGridSemovientesVenta(Parametros, txtBuscar.Text.ToUpper(),  ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        private void Guardar()
        {
            lblError.Text = string.Empty;
            Verificador = string.Empty;
            
            try
            {
                Bien_Detalle SemovienteAutorizado = new Bien_Detalle();
                ListSemPreAutorizados = (List<Bien_Detalle>)Session["ListSemPreAutorizados"];
                          
                            CNBien.InsertarSemoviente_AutorizadoVenta(ListSemPreAutorizados, ref Verificador);
                if (Verificador == "0")
                {
                    DDLDependencia_SelectedIndexChanged(null, null);
                    btnCancelar_Click(null, null);
                }
                else
                {
                    DDLDependencia_SelectedIndexChanged(null, null);
                    lblError.Text = "Ocurrió un error al insertar uno o más semovientes:" + Verificador;
                }

                            
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        #endregion

        #region <Botones y Eventos>
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
                CargarGrid();
           
        }      
   
       
        protected void grvSemovientesAV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSemovientesAV.PageIndex = 0;
            grvSemovientesAV.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        
        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
           lblError.Text = string.Empty;
            
                Session["ListSemCandidatos"] = null;
                CNComun.LlenaCombo("pkg_patrimonio.Obt_List_Semovientes_Venta", ref DDLSemovientes, "p_dependencia", DDLDependencia.SelectedValue, ref ListSemCandidatos);
                Session["ListSemCandidatos"] = ListSemCandidatos;
           
        }
        protected void grvSemPreAutorizados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grvSemPreAutorizados.PageSize * grvSemPreAutorizados.PageIndex;
                fila = pagina + fila;
                ListSemPreAutorizados = (List<Bien_Detalle>)Session["ListSemPreAutorizados"];
                ListSemPreAutorizados.RemoveAt(fila);
                Session["ListSemPreAutorizados"] = ListSemPreAutorizados;
                CargarGridDetalle(ListSemPreAutorizados);
                if (ListSemPreAutorizados.Count > 0)
                    btnGuardar.Visible = true;
                else
                    btnGuardar.Visible = false;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        protected void grvSemPreAutorizados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSemPreAutorizados.PageIndex = 0;
            grvSemPreAutorizados.PageIndex = e.NewPageIndex;
            ListSemPreAutorizados = (List<Bien_Detalle>)Session["ListSemPreAutorizados"];
            Session["ListSemPreAutorizados"] = ListSemPreAutorizados;
  
            CargarGridDetalle(ListSemPreAutorizados);
        }
        
        #endregion

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DDLSemovientes.DataSource = null;
            DDLSemovientes.DataBind();
            ListSemCandidatos = (List<Comun>)Session["ListSemCandidatos"];
            var filteredSemovientes = from c in ListSemCandidatos
                                  where c.Descripcion.Contains(txtSearch.Text.ToUpper()) //txtSearch.Text
                                  select c;

            var content = filteredSemovientes.ToList<Comun>();
            
            DDLSemovientes.DataSource = content;
            DDLSemovientes.DataValueField = "IdStr";
            DDLSemovientes.DataTextField = "Descripcion";
            DDLSemovientes.DataBind();
            if (content.Count() >= 1)
            {
                DDLSemovientes.SelectedIndex = 0;
            }
        }
       
        
        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 0;
                lblBuscar.Visible = true;
                txtBuscar.Visible = true;
                imgbtnBuscar.Visible = true;
                btnNuevo.Visible = true;
                lblStatus.Visible = true;
                DDLStatus.Visible = true;
                DDLDependencia.Enabled = true;

            ListSemCandidatos=null;
            ListSemPreAutorizados = null;
                btnNuevo.Enabled = true;

                CargarGridDetalle(ListSemPreAutorizados);
                CargarGrid();
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
                lblBuscar.Visible = false;
                txtBuscar.Visible = false;
                imgbtnBuscar.Visible = false;
                btnNuevo.Visible = false;
                lblStatus.Visible = false;
                DDLStatus.Visible = false;
                DDLDependencia.Enabled = false;
                txtSearch.Text = string.Empty;
                lblDependenciaDes.Text = DDLDependencia.SelectedItem.Text;

                Session["ListSemPreAutorizados"] = null;
                Session["ListSemCandidatos"] = null;
                CNComun.LlenaCombo("pkg_patrimonio.Obt_List_Semovientes_Venta", ref DDLSemovientes, "p_dependencia", DDLDependencia.SelectedValue, ref ListSemCandidatos);
                Session["ListSemCandidatos"] = ListSemCandidatos;
                
                btnGuardar.Visible = false;
                MultiView1.ActiveViewIndex = 1;
        }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
}

        protected void linkBttnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvSemovientesAV.SelectedIndex = row.RowIndex;
               
                    Bien Semoviente = new Bien();
                    Semoviente.Id = Convert.ToInt32(grvSemovientesAV.SelectedRow.Cells[0].Text);
                    Verificador = string.Empty;
                    CNBien.Eliminar_SemovienteVenta(Semoviente, ref Verificador);

                if (Verificador != "0")
                    lblError.Text = Verificador;
                else
                    CargarGrid();
                
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;

            try
            {
                Bien_Detalle Semoviente = new Bien_Detalle();
                ListSemCandidatos = (List<Comun>)Session["ListSemCandidatos"];
                Page.Validate("Detalle");
                if (Page.IsValid)
                {
                    Semoviente.Id = Convert.ToInt32(DDLSemovientes.SelectedValue);
                    Semoviente.Dependencia = DDLDependencia.SelectedValue;
                    Semoviente.No_Inventario = DDLSemovientes.SelectedItem.Text.Substring(0, 10);
                    Semoviente.Descripcion = DDLSemovientes.SelectedItem.Text.Substring(10);
                    Semoviente.Sem_Arete = ListSemCandidatos[DDLSemovientes.SelectedIndex].EtiquetaDos;
                    Semoviente.Poliza = ListSemCandidatos[DDLSemovientes.SelectedIndex].EtiquetaTres;
                    Semoviente.Sem_Etapa = ListSemCandidatos[DDLSemovientes.SelectedIndex].EtiquetaCuatro;
                    Semoviente.Sem_Especie = ListSemCandidatos[DDLSemovientes.SelectedIndex].EtiquetaCinco;
                    Semoviente.Sem_Peso = txtPeso.Text;
                    Semoviente.Costo = Convert.ToDouble(txtCosto.Text);
                    Semoviente.Captura_Usuario = SesionUsu.Usu_Nombre;
                }

                if (Session["ListSemPreAutorizados"] == null)
                {
                    ListSemPreAutorizados = new List<Bien_Detalle>();
                    ListSemPreAutorizados.Add(Semoviente);
                }
                else
                {
                    ListSemPreAutorizados = (List<Bien_Detalle>)Session["ListSemPreAutorizados"];
                    ListSemPreAutorizados.Add(Semoviente);
                }
                Session["ListSemPreAutorizados"] = ListSemPreAutorizados;

                if (ListSemPreAutorizados.Count > 0)
                {
                    btnGuardar.Visible = true;
                    btnGuardar.Enabled = true;
                }
                else
                {
                    btnGuardar.Visible = false;
                    btnGuardar.Enabled = false;
                }
                CargarGridDetalle(ListSemPreAutorizados);
                    txtSearch.Focus();
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLSemovientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}