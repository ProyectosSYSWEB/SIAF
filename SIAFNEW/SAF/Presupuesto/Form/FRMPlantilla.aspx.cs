using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;


namespace SAF.Presupuesto.Form
{
    public partial class FRMPlantilla : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Plantilla CNPlantilla = new CN_Pres_Plantilla();
        CN_Pres_Documento_Det CNDocDet = new CN_Pres_Documento_Det();
        Pres_Plantilla objPlantilla = new Pres_Plantilla();
        private static List<Comun> ListDependencia = new List<Comun>();
        int guar_continue;
        int bar_interino = 0;
        int v=0;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();
            }
        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = "A";
                MultiView1.ActiveViewIndex = 0;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia0, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref ddlOtr, "P_Clave", ddlcarga_academica.SelectedValue, "DPP");
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Categoria", ref txtCategoria, "P_EJERCICIO","2018", "DPP");
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Categoria", ref txtCategoria01, "P_EJERCICIO", "2018", "DPP");
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref DDLEstatus, "P_Clave", "22", "DPP");
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref DDLEstatus01, "P_Clave", "22", "DPP");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void CargarGrid(ref GridView grid, int idGrid)
        {
            lblError.Text = string.Empty;
            grid.DataSource = null;
            grid.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;                
                grid.DataSource = GetList(idGrid);
                grid.DataBind();
                if (grid == GRDEmpledo)
                {
                    if (SesionUsu.Cerrada == "N")
                    { Celdas = new Int32[] { }; }
                    else { Celdas = new Int32[] { 6,7,8}; }
                }
                else { Celdas = new Int32[] { }; }             
                if (grid.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid, Celdas);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }

        private List<Pres_Plantilla> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Plantilla> List = new List<Pres_Plantilla>();
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                objPlantilla.Dependencia = DDLDependencia.SelectedValue;
                if (bar_interino==1)
                {
                    objPlantilla.Dependencia = DDLDependencia0.SelectedValue;
                    objPlantilla.Buscar = TXTBuscar0.Text;
                }
                else
                {
                    objPlantilla.Buscar = TXTBuscar.Text;
                }                
                objPlantilla.RFC = txtRFC.Text;

                if (IdGrid == 0)
                {
                    CNPlantilla.ConsultaGrid_Plantilla(ref objPlantilla, ref List);
                }
                else
                {
                    CNPlantilla.ConsultaGrid_Historico(ref objPlantilla, ref List);
                }

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {              
                valida_cierre();
                CargarGrid(ref GRDEmpledo, 0);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        //--------------------------
        protected void valida_cierre()
        {
            try
            {
                lblError.Text = string.Empty;
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                objPlantilla.Dependencia = DDLDependencia.SelectedValue;
                Verificador = string.Empty;
                CNPlantilla.Sel_Valida_Cierre(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    SesionUsu.Cerrada = objPlantilla.Cerrada;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        public void Limpiador_controles(Control control)
        {
            var textbox = control as TextBox;
            if (textbox != null)
            {
                textbox.Text = string.Empty;
            }           
            foreach (Control childControl in control.Controls)
            {
                Limpiador_controles(childControl);
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;           
            Session["DocDet"] = null;
            Panel1.Visible = true;
            Panel2.Visible = false;
            CNComun.Limpiador_controles(Panel1);
            CNComun.Limpiador_controles(Panel2);
            CNComun.Habilitar_controles(Panel1);
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = true;
            txtPlaza.Text = string.Empty;
            txtPlaza.Enabled = true;
            DDLEstatus.Enabled = true;
            txtRFC.Enabled = true;
            txtRFC.Text = String.Empty;
            txtfecha_ingreso.Text = DateTime.Now.Day.ToString() +"/" + DateTime.Now.Month.ToString() +"/"+ DateTime.Now.Year.ToString();
            SesionUsu.Editar = 0;
            Button1.Enabled = false;
            Button3.Enabled = false;
            btnGuardar_continuar.Visible = false;
            DDLDependencia.Enabled = false;
        }
        protected void grdBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void imgBttnPDF_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string ruta = string.Empty;
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-014&Semestre=" + DDLSemestre.SelectedItem.ToString() + "&Dependencia=" + DDLDependencia.SelectedItem.ToString();
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Button5.Visible = false;
            btnGuardar.Enabled = true;
            btnGuardar_continuar.Enabled = true;
            adelante.Enabled = true;
            atras.Enabled = true;
            CNComun.Limpiador_controles(Panel2);
            MultiView1.ActiveViewIndex = 0;
            DDLDependencia.Enabled = true;
        }
        
        private void consulta_plantilla(string plantilla)
        {
            try
            {
                lblError.Text = string.Empty;
                MultiView1.ActiveViewIndex = 1;
                SesionUsu.Editar = 1;
                int v = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[v].Cells[0].Text;
                //Label4.Text= GRDEmpledo.Rows[v].Cells[0].Text;
                objPlantilla.Tipo_p = plantilla;
                CNPlantilla.Consultar_Plantilla(ref objPlantilla, ref Verificador);

                if (Verificador == "0")
                {
                    txtNombre.Text = objPlantilla.Nombre;
                    txtPlaza.Text = objPlantilla.Plaza;
                    DDLEstatus.SelectedValue = objPlantilla.Status;
                    txtCategoria.SelectedValue  = objPlantilla.Categoria;
                    txtCarga.Text = objPlantilla.Cga_teo;                   
                    txtInt.Text = objPlantilla.Tot_int;
                    txtTem.Text = objPlantilla.Tot_tem;
                    txtDef.Text = objPlantilla.Tot_def;
                    txtDet.Text = objPlantilla.Tot_det;
                    txtObservacion.Text = objPlantilla.Obsevasiones;
                    txtfecha_ingreso.Text = objPlantilla.Fecha_Ingreso;
                    txtOficio.Text = objPlantilla.Oficio;
                    txtCodigo.Text = objPlantilla.Codigo;                    
                    txtFec_mov.Text = objPlantilla.Fecha_mov;
                    txtfecha_ini.Text = objPlantilla.Fecha_Ini;
                    txtfecha_fin.Text = objPlantilla.Fecha_Fin;
                    txtRFC.Text = objPlantilla.RFC;                    
                    SesionUsu.Cerrada = objPlantilla.Cerrada;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'NO SE PUDO CARGAR LOS DATOS');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void Consulta_PosPlantilla(string plantilla)
        {
            try
            {
                lblError.Text = string.Empty;
                MultiView1.ActiveViewIndex = 1;
                SesionUsu.Editar = 1;
                int v = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[v].Cells[0].Text;
                objPlantilla.Tipo_p = plantilla;                
                CNPlantilla.Consultar_Plantilla(ref objPlantilla, ref Verificador);

                if (Verificador == "0")
                {
                    txtNombre.Text = objPlantilla.Nombre;
                    txtPlaza.Text = objPlantilla.Plaza;
                    DDLEstatus01.SelectedValue = objPlantilla.Status;
                    txtCategoria01.SelectedValue = objPlantilla.Categoria;
                    txtCarga01.Text = objPlantilla.Cga_teo;                    
                    txtInt01.Text = objPlantilla.Tot_int;
                    txtTem01.Text = objPlantilla.Tot_tem;
                    txtDef01.Text = objPlantilla.Tot_def;
                    txtDet01.Text = objPlantilla.Tot_det;
                    txtObservacion01.Text = objPlantilla.Obsevasiones;
                    txtfecha_ingreso.Text = objPlantilla.Fecha_Ingreso;
                    txtFec_mov01.Text = objPlantilla.Fecha_mov;
                    txtOficio01.Text = objPlantilla.Oficio;                   
                    txtfecha_ini.Text = objPlantilla.Fecha_Ini;
                    txtfecha_fin.Text = objPlantilla.Fecha_Fin;
                    txtRFC.Text = objPlantilla.RFC;
                    txtCodigo01.Text = objPlantilla.Codigo;
                }
                else
                {                    
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void GRDEmpledo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Button5.Visible = true;
                DDLDependencia.Enabled = false;
                consulta_plantilla("1");
                Panel2.Visible = false;
                Panel1.Visible = true;
                SesionUsu.Cerrada= objPlantilla.Cerrada;
                SesionUsu.Plantilla = "PLANTILLA";                
                if (SesionUsu.Cerrada == "N")
                {
                    CNComun.Inhabilitar_controles(Panel1);                   
                    DDLEstatus.Enabled = true;
                    CargarGrid(ref GRDOtr,"21");
                    CargarGrid(ref GRDOtr2, "22");
                    CargarGrid(ref GRDOtr3, "23");
                }
                else
                {
                    CNComun.Habilitar_controles(Panel1);
                    //DDLEstatus01.Enabled = false;
                    DDLEstatus.Enabled = true;
                    CargarGrid(ref GRDOtr,"11");
                    CargarGrid(ref GRDOtr2, "12");
                    CargarGrid(ref GRDOtr3, "13");                    
                    SesionUsu.Editar = 1;
                }                 
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void CargarGrid(ref GridView grid, String TIPO_P)
        {
            lblError.Text = string.Empty;           
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;
                grid.DataSource = GetList(TIPO_P);
                grid.DataBind();
                Celdas = new Int32[] { };
                if (GRDOtr.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid, Celdas);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private List<Pres_Plantilla> GetList(String TIPO_P)
        {
            try
            {
                List<Pres_Plantilla> List = new List<Pres_Plantilla>();
                int e = GRDEmpledo.SelectedIndex;
                objPlantilla.Plantilla = SesionUsu.Plantilla;
                objPlantilla.Id = GRDEmpledo.Rows[e].Cells[0].Text;
                objPlantilla.Tipo_p = TIPO_P;
                CNPlantilla.ConsultaGrid_Otr(ref objPlantilla, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DDLDependencia0.SelectedValue = DDLDependencia.SelectedValue;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDEmpledo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRDEmpledo.PageIndex = 0;
            GRDEmpledo.PageIndex = e.NewPageIndex;
            valida_cierre();
            CargarGrid(ref GRDEmpledo, 0);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Button5.Visible = false;
                if (SesionUsu.Editar == 0)
                {
                    GuardaR_Plantilla();
                    TXTBuscar.Text = txtNombre.Text;
                    MultiView1.ActiveViewIndex = 0;
                    BTNbuscar_Click(null, null);
                    Button1.Enabled = true;
                    Button3.Enabled = true;
                    btnGuardar_continuar.Visible = true;
                }
                else
                {
                    if (SesionUsu.Editar == 1)
                    {
                        if (SesionUsu.Cerrada == "S")
                        {
                            Update_Plantilla();
                            DDLDependencia.Enabled = true;
                            TXTBuscar.Text = txtNombre.Text;
                            MultiView1.ActiveViewIndex = 0;
                            BTNbuscar_Click(null, null);
                        }
                    }
                    else
                    {
                        Update_Plantilla01();
                        DDLDependencia.Enabled = true;
                        TXTBuscar.Text = txtNombre.Text;
                        MultiView1.ActiveViewIndex = 0;
                        BTNbuscar_Click(null, null);
                    }                    
                }                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void index_linbtn(object sender, Control grid)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            
            if (grid == GRDEmpledo)
            {
                GRDEmpledo.SelectedIndex = row.RowIndex;
            }
            if (grid == GRDOtr)
            {
                GRDOtr.SelectedIndex= row.RowIndex;
            }
            if (grid == GRDOtr2)
            {
                GRDOtr2.SelectedIndex = row.RowIndex;
            }
            if (grid == GRDOtr3)
            {
                GRDOtr3.SelectedIndex = row.RowIndex;
            }
            if (grid == GRDOtr01)
            {
                GRDOtr01.SelectedIndex = row.RowIndex;
            }
            if (grid == GRDOtr02)
            {
                GRDOtr02.SelectedIndex = row.RowIndex;
            }
            if (grid == GRDOtr03)
            {
                GRDOtr03.SelectedIndex = row.RowIndex;
            }

            //GRDEmpledo.ID = GRDEmpledo.SelectedRow.Cells[0].Text;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Button5.Visible = true;
            DDLDependencia.Enabled = false;
            index_linbtn(sender, GRDEmpledo);
            Panel2.Visible = true;
            Panel1.Visible = false;            
            Consulta_PosPlantilla("2");            
            CNComun.Habilitar_controles(Panel2);
            DDLEstatus01.Enabled = true;
            SesionUsu.Plantilla = "POSPLANTILLA";          
            CargarGrid(ref GRDOtr01, "11");
            CargarGrid(ref GRDOtr02, "12");
            CargarGrid(ref GRDOtr03, "13");
            SesionUsu.Editar = 2;

        }

        
        protected void adelante_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GRDEmpledo.SelectedIndex = GRDEmpledo.SelectedIndex + 1;
                consulta_plantilla("1");
                Panel2.Visible = false;
                Panel1.Visible = true;
                SesionUsu.Cerrada = objPlantilla.Cerrada;
                SesionUsu.Plantilla = "PLANTILLA";
                if (SesionUsu.Cerrada == "N")
                {
                    CNComun.Inhabilitar_controles(Panel1);
                    DDLEstatus.Enabled = true;
                    CargarGrid(ref GRDOtr, "21");
                    CargarGrid(ref GRDOtr2, "22");
                    CargarGrid(ref GRDOtr3, "23");
                }
                else
                {
                    CNComun.Habilitar_controles(Panel1);
                    //DDLEstatus01.Enabled = false;
                    DDLEstatus.Enabled = true;
                    CargarGrid(ref GRDOtr, "11");
                    CargarGrid(ref GRDOtr2, "12");
                    CargarGrid(ref GRDOtr3, "13");
                    SesionUsu.Editar = 1;
                }              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Tu busqueda a Finalizado');", true);
            }
        }
        protected void atras_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GRDEmpledo.SelectedIndex = GRDEmpledo.SelectedIndex - 1;
                consulta_plantilla("1");
                Panel2.Visible = false;
                Panel1.Visible = true;
                SesionUsu.Cerrada = objPlantilla.Cerrada;
                SesionUsu.Plantilla = "PLANTILLA";
                if (SesionUsu.Cerrada == "N")
                {
                    CNComun.Inhabilitar_controles(Panel1);
                    DDLEstatus.Enabled = true;
                    CargarGrid(ref GRDOtr, "21");
                    CargarGrid(ref GRDOtr2, "22");
                    CargarGrid(ref GRDOtr3, "23");
                }
                else
                {
                    CNComun.Habilitar_controles(Panel1);
                    //DDLEstatus01.Enabled = false;
                    DDLEstatus.Enabled = true;
                    CargarGrid(ref GRDOtr, "11");
                    CargarGrid(ref GRDOtr2, "12");
                    CargarGrid(ref GRDOtr3, "13");
                    SesionUsu.Editar = 1;
                }                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Tu busqueda a Finalizado');", true);
            }
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Cerrada=="S")
                {
                    if ( Convert.ToDouble( txtInt.Text) == 0)
                    { Panel5.Visible = false; ddlLigar_Docente.Visible = false; Label49.Visible = false; }
                    else
                    {
                    Panel5.Visible = true; ddlLigar_Docente.Visible = true; Label49.Visible = true; }
                    ddlcarga_academica.SelectedValue = "17";
                    CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref ddlOtr, "P_Clave", ddlcarga_academica.SelectedValue, "DPP");
                    MultiView1.ActiveViewIndex = 3;                   
                    SesionUsu.Plantilla = "PLANTILLA";
                    GRDOtr.Enabled = true;
                }
                else
                {
                    GRDOtr.Enabled = false;
                }                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void Update_Plantilla01()
        {
            try
            {
                lblError.Text = string.Empty;
                int e = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[e].Cells[0].Text;
                objPlantilla.Dependencia = DDLDependencia.SelectedValue;
                objPlantilla.Plaza = txtPlaza.Text;
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                objPlantilla.Fecha_Ini = txtfecha_ini.Text;
                objPlantilla.Fecha_Fin = txtfecha_fin.Text;
                objPlantilla.RFC = txtRFC.Text; ;
                objPlantilla.Nombre = txtNombre.Text;
                objPlantilla.Categoria = txtCategoria01.SelectedValue;
                objPlantilla.Status = DDLEstatus01.SelectedValue;
                objPlantilla.Cga_teo = txtCarga01.Text;               
                objPlantilla.Tot_int = txtInt01.Text;
                objPlantilla.Tot_tem = txtTem01.Text;
                objPlantilla.Tot_def = txtDef01.Text;
                objPlantilla.Tot_det = txtDet01.Text;
                objPlantilla.Obsevasiones = txtObservacion01.Text;
                objPlantilla.Fecha_mov = txtFec_mov01.Text;
                objPlantilla.Oficio = txtOficio01.Text;
                objPlantilla.Codigo = txtCodigo01.Text;
                objPlantilla.Fecha_Ingreso = txtfecha_ingreso.Text;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;
                Verificador = string.Empty;
                CNPlantilla.Update_Plantilla(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Proceso exitoso');", true);                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void Update_Plantilla()
        {
            try
            {
                lblError.Text = string.Empty;
                int e = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[e].Cells[0].Text;
                objPlantilla.Dependencia =DDLDependencia.SelectedValue;
                objPlantilla.Plaza = txtPlaza.Text;
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                objPlantilla.Fecha_Ini = txtfecha_ini.Text;
                objPlantilla.Fecha_Fin = txtfecha_fin.Text;
                objPlantilla.RFC = txtRFC.Text; ;
                objPlantilla.Nombre = txtNombre.Text;
                objPlantilla.Categoria = txtCategoria.SelectedValue;
                objPlantilla.Status = DDLEstatus.SelectedValue;
                objPlantilla._Cga_teo = txtCarga.Text;                
                objPlantilla.Tot_int = txtInt.Text;
                objPlantilla.Tot_tem = txtTem.Text;
                objPlantilla.Tot_def = txtDef.Text;
                objPlantilla.Tot_det = txtDet.Text;
                objPlantilla.Obsevasiones = txtObservacion.Text;
                objPlantilla.Fecha_mov = txtFec_mov.Text;
                objPlantilla.Oficio = txtOficio.Text;
                objPlantilla.Codigo = txtCodigo.Text;
                objPlantilla.Fecha_Ingreso = txtfecha_ingreso.Text;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;
                Verificador = string.Empty;
                CNPlantilla.Update_Plantilla(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Proceso exitoso');", true);
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void GuardaR_Plantilla()
        {
            try
            {
                lblError.Text = string.Empty;
                objPlantilla.Id_Empleado = "";
                objPlantilla.Dependencia = DDLDependencia.SelectedValue;
                objPlantilla.Plaza = txtPlaza.Text;
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                objPlantilla.Fecha_Ini= txtfecha_ini.Text;
                objPlantilla.Fecha_Fin = txtfecha_fin.Text ;
                objPlantilla.RFC = txtRFC.Text; ;
                objPlantilla.Nombre = txtNombre.Text;
                objPlantilla.Categoria = txtCategoria.SelectedValue;
                objPlantilla.Status = DDLEstatus.SelectedValue;
                objPlantilla.Cga_teo = txtCarga.Text;
                objPlantilla.Tot_int = txtInt.Text;          
                objPlantilla.Tot_tem = txtTem.Text;
                objPlantilla.Tot_def = txtDef.Text;
                objPlantilla.Tot_det = txtDet.Text;
                objPlantilla.Obsevasiones = txtObservacion.Text;
                objPlantilla.Fecha_mov = txtFec_mov.Text;
                objPlantilla.Oficio = txtOficio.Text;
                objPlantilla.Codigo = txtCodigo.Text;
                objPlantilla.Fecha_Ingreso = txtfecha_ingreso.Text;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;
                Verificador = string.Empty;
                CNPlantilla.Insertar_Plantilla(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'El docente se agrego con exito, a continuacion agregue otras actividades');", true);
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private void GuardarOtr()
        {
            try
            {
                lblError.Text = string.Empty;         
                int e = GRDEmpledo.SelectedIndex;
                if (ddlcarga_academica.SelectedValue == "1")
                {
                    objPlantilla.id_p_p = "0";
                }
                else
                {
                    if (ddlLigar_Docente.SelectedValue == "0")
                    {
                        if (SesionUsu.Cerrada == "S")
                        {
                            if (Convert.ToDouble(txtInt.Text) == 0)
                            {
                                objPlantilla.id_p_p = "0";
                            }
                            else
                            {
                                v = GRDEmpledo0.SelectedIndex;
                                objPlantilla.id_p_p = GRDEmpledo0.Rows[v].Cells[0].Text;
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(txtInt01.Text) == 0)
                            {
                                objPlantilla.id_p_p = "0";
                            }
                            else
                            {
                                v = GRDEmpledo0.SelectedIndex;
                                objPlantilla.id_p_p = GRDEmpledo0.Rows[v].Cells[0].Text;
                            }
                        }
                    }
                    else
                    {
                        objPlantilla.id_p_p = "0";
                    }
                }                  
                objPlantilla.Id = GRDEmpledo.Rows[e].Cells[0].Text;
                objPlantilla.Plantilla = SesionUsu.Plantilla;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;
                objPlantilla.Actividad = ddlOtr.SelectedValue;
                objPlantilla.Cantidad = txtCantidad.Text;                  
                Verificador = string.Empty;                
                CNPlantilla.Insertar_DPP_Otr(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'La  actividad se realizo con exito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
            catch (Exception ex)
            {                
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: "+ ex.Message+ "');", true);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtInt01.Text) == 0)
            {Panel5.Visible = false; ddlLigar_Docente.Visible = false; Label49.Visible = false; }
            else
            { Panel5.Visible = true; ddlLigar_Docente.Visible = true; Label49.Visible = true; }
            ddlcarga_academica.SelectedValue = "17";
            CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref ddlOtr, "P_Clave", ddlcarga_academica.SelectedValue, "DPP");
            MultiView1.ActiveViewIndex = 3;
            SesionUsu.Plantilla = "POSPLANTILLA";
        }
        protected void cancelar_act_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            GRDEmpledo0.DataBind();
            TXTBuscar0.Text = String.Empty;
        }
        protected void Agrega_act_Click(object sender, EventArgs e)
        {           
            GuardarOtr();
            if (SesionUsu.Cerrada=="S")
            {
                CargarGrid(ref GRDOtr, "11");
                CargarGrid(ref GRDOtr2, "12");
                CargarGrid(ref GRDOtr3, "13");
            }
            else
            {
                if (SesionUsu.Plantilla == "PLANTILLA")
                {
                    CargarGrid(ref GRDOtr, "21");
                    CargarGrid(ref GRDOtr2, "22");
                    CargarGrid(ref GRDOtr3, "23");
                }
                else
                {
                    CargarGrid(ref GRDOtr01, "11");
                    CargarGrid(ref GRDOtr02, "12");
                    CargarGrid(ref GRDOtr03, "13");
                }
            }
            
            txtCantidad.Text = string.Empty;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            index_linbtn(sender, GRDEmpledo);
            Panel2.Visible = true;
            Panel1.Visible = true;
            SesionUsu.Plantilla = "PLANTILLA";
            consulta_plantilla("1");
            CargarGrid(ref GRDOtr, "21");
            CargarGrid(ref GRDOtr2, "22");
            CargarGrid(ref GRDOtr3, "23");
            GRDOtr.Enabled = false;
            SesionUsu.Plantilla = "POSPLANTILLA";
            Consulta_PosPlantilla("2");
            CargarGrid(ref GRDOtr01,"11");
            CargarGrid(ref GRDOtr02, "12");
            CargarGrid(ref GRDOtr03, "13");
            GRDOtr01.Enabled = false;
            CNComun.Inhabilitar_controles(Panel1);
            CNComun.Inhabilitar_controles(Panel2);
            btnGuardar.Enabled = false;
            btnGuardar_continuar.Enabled = false;
            adelante.Enabled = false;
            atras.Enabled = false;
        }

        protected void LbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, GRDOtr);
                lblError.Text = string.Empty;
                int v = GRDOtr.SelectedIndex;
                objPlantilla.Id = GRDOtr.Rows[v].Cells[0].Text;
                CNPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {                   
                    if (SesionUsu.Plantilla == "PLANTILLA")
                    {
                        CargarGrid(ref GRDOtr,"11");
                        CargarGrid(ref GRDOtr2, "12");
                        CargarGrid(ref GRDOtr3, "13");
                    }
                    else
                    {
                        CargarGrid(ref GRDOtr01,"21");
                        CargarGrid(ref GRDOtr02, "22");
                        CargarGrid(ref GRDOtr03, "23");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'la eliminación se realizo con éxito');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void LBEliminar01_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, GRDOtr01);
                lblError.Text = string.Empty;
                int v = GRDOtr01.SelectedIndex;
                objPlantilla.Id = GRDOtr01.Rows[v].Cells[0].Text;
                CNPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    if (SesionUsu.Plantilla == "PLANTILLA")
                    {
                        CargarGrid(ref GRDOtr,"21");
                        CargarGrid(ref GRDOtr2, "22");
                        CargarGrid(ref GRDOtr3, "23");
                    }
                    else
                    {
                        CargarGrid(ref GRDOtr01,"11");
                        CargarGrid(ref GRDOtr02, "12");
                        CargarGrid(ref GRDOtr03, "13");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'la eliminación se realizo con éxito');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }  

        protected void ddlOtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Focus();            
        }

        protected void btnGuardar_continuar_Click(object sender, EventArgs e)
        {
            try
            {
                Button5.Visible = false;
                if (SesionUsu.Editar == 0)
                {
                    GuardaR_Plantilla();                   
                }
                else
                {
                    if (SesionUsu.Editar == 1)
                    {
                        if (SesionUsu.Cerrada == "S")
                        {
                            Update_Plantilla();                            
                        }
                    }
                    else
                    {
                        Update_Plantilla01();                        
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Cerrada == "S")
                {
                    Panel5.Visible = false;
                    ddlcarga_academica.SelectedValue = "1";
                    CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref ddlOtr, "P_Clave", ddlcarga_academica.SelectedValue, "DPP");
                    MultiView1.ActiveViewIndex = 3;
                    SesionUsu.Plantilla = "PLANTILLA";
                    GRDOtr.Enabled = true;
                    ddlLigar_Docente.Visible = false;
                }
                else
                {
                    GRDOtr.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
            ddlcarga_academica.SelectedValue = "1";
            CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_basicos", ref ddlOtr, "P_Clave", ddlcarga_academica.SelectedValue, "DPP");
            MultiView1.ActiveViewIndex = 3;
            SesionUsu.Plantilla = "POSPLANTILLA";
        }

        protected void lbt_otr_Click(object sender, EventArgs e)
        {
            try
            {
                Button5.Visible = true;
                DDLDependencia.Enabled = false;
                index_linbtn(sender, GRDEmpledo);
                int v = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[v].Cells[0].Text;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;
                CNPlantilla.ins_otro_posterior(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {                                        
                    Panel2.Visible = true;
                    Panel1.Visible = false;
                    Consulta_PosPlantilla("2");
                    CNComun.Habilitar_controles(Panel2);
                    DDLEstatus01.Enabled = true;
                    SesionUsu.Plantilla = "POSPLANTILLA";
                    CargarGrid(ref GRDOtr01, "11");
                    CargarGrid(ref GRDOtr02, "12");
                    CargarGrid(ref GRDOtr03, "13");
                    SesionUsu.Editar = 2;                   
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se guardo en bitacora Exitosamente');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }

        protected void imgBttnExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string ruta = string.Empty;
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-014XLSX&Semestre=" + DDLSemestre.SelectedItem.ToString() + "&Dependencia=" + DDLDependencia.SelectedItem.ToString();
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDOtr01_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                valida_cierre();
                CargarGrid(ref GRDEmpledo, 0);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddlcarga_academica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LbEliminar2_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, GRDOtr2);
                lblError.Text = string.Empty;
                int v = GRDOtr2.SelectedIndex;
                objPlantilla.Id = GRDOtr2.Rows[v].Cells[0].Text;
                CNPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    if (SesionUsu.Plantilla == "PLANTILLA")
                    {
                        CargarGrid(ref GRDOtr, "11");
                        CargarGrid(ref GRDOtr2, "12");
                        CargarGrid(ref GRDOtr3, "13");
                    }
                    else
                    {
                        CargarGrid(ref GRDOtr01, "21");
                        CargarGrid(ref GRDOtr02, "22");
                        CargarGrid(ref GRDOtr03, "23");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'la eliminación se realizo con éxito');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void LbEliminar3_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, GRDOtr3);
                lblError.Text = string.Empty;
                int v = GRDOtr3.SelectedIndex;
                objPlantilla.Id = GRDOtr3.Rows[v].Cells[0].Text;
                CNPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    if (SesionUsu.Plantilla == "PLANTILLA")
                    {
                        CargarGrid(ref GRDOtr, "11");
                        CargarGrid(ref GRDOtr2, "12");
                        CargarGrid(ref GRDOtr3, "13");
                    }
                    else
                    {
                        CargarGrid(ref GRDOtr01, "21");
                        CargarGrid(ref GRDOtr02, "22");
                        CargarGrid(ref GRDOtr03, "23");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'la eliminación se realizo con éxito');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

       

        protected void LBEliminar4_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, GRDOtr02);
                lblError.Text = string.Empty;
                int v = GRDOtr02.SelectedIndex;
                objPlantilla.Id = GRDOtr02.Rows[v].Cells[0].Text;
                CNPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    if (SesionUsu.Plantilla == "PLANTILLA")
                    {
                        CargarGrid(ref GRDOtr, "21");
                        CargarGrid(ref GRDOtr2, "22");
                        CargarGrid(ref GRDOtr3, "23");
                    }
                    else
                    {
                        CargarGrid(ref GRDOtr01, "11");
                        CargarGrid(ref GRDOtr02, "12");
                        CargarGrid(ref GRDOtr03, "13");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'la eliminación se realizo con éxito');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void LBEliminar5_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, GRDOtr03);
                lblError.Text = string.Empty;
                int v = GRDOtr03.SelectedIndex;
                objPlantilla.Id = GRDOtr03.Rows[v].Cells[0].Text;
                CNPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    if (SesionUsu.Plantilla == "PLANTILLA")
                    {
                        CargarGrid(ref GRDOtr, "21");
                        CargarGrid(ref GRDOtr2, "22");
                        CargarGrid(ref GRDOtr3, "23");
                    }
                    else
                    {
                        CargarGrid(ref GRDOtr01, "11");
                        CargarGrid(ref GRDOtr02, "12");
                        CargarGrid(ref GRDOtr03, "13");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'la eliminación se realizo con éxito');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DDLDependencia.Enabled = true;
        }

        protected void btnverD_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 2;
                CargarGrid(ref grdHistorico, 1);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTNbuscar0_Click(object sender, ImageClickEventArgs e)
        {
            try
            {                
                bar_interino = 1;
                CargarGrid(ref GRDEmpledo0, 0);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDEmpledo0_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GRDEmpledo0_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GRDOtr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLigar_Docente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLigar_Docente.SelectedValue == "0")
                {
                    Panel5.Visible = true;
                }
                else
                {
                    Panel5.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }

        protected void btnMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                int v = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[v].Cells[0].Text;
                string ruta = string.Empty;
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-MOVIMIENTOS&ID=" + objPlantilla.Id;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
 }