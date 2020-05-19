using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
using AjaxControlToolkit;

namespace SAF.Patrimonio
{
    public partial class frmControlSemovientes : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        int[] Columnas;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Bien ObjBien = new Bien();
        CN_Comun CNComun = new CN_Comun();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Bien CNBien = new CN_Bien();
        Comun ObjCC = new Comun();
        Int32[] Celdas = new Int32[] { 0, 0, 0};
        private static List<Comun> Etapas=new List<Comun>();
        private static List<Comun> Dependencias = new List<Comun>();
  

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
         
            MultiView1.ActiveViewIndex = 0;
            lblInventario.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            txtNacimiento.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtAnios.Text = string.Empty;
            lblError.Text = string.Empty;
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDependencia, "p_usuario", SesionUsu.CUsuario, ref Dependencias);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Especies", ref DDLEspecie);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Etapa_Productiva", ref DDLEtapa, "p_especie", DDLEspecie.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Calidad_Vellon", ref DDLCalidadVellon);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Epoca_Productiva", ref DDLEpoca);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Grupo_Productivo", ref DDLGrupo);


        }
       
        private void CargarGrid()
        {
           lblError.Text = string.Empty;
            grvSemovientes.DataSource = null;
            grvSemovientes.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvSemovientes.DataSource = dt;
                grvSemovientes.DataSource = GetList();
                grvSemovientes.DataBind();
                if (grvSemovientes.Rows.Count > 0)
                {
                    Columnas = new int[3];
                    Columnas[0] = 0;
                    Columnas[1] = 3;
                    Columnas[2] = 0;

                    

                    CNComun.HideColumns(grvSemovientes, Columnas);
                }
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }
        private void CargarGridHistorico(String Id)
        {
            lblError.Text = string.Empty;
            grvHistorico.DataSource = null;
            grvHistorico.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvHistorico.DataSource = dt;
                grvHistorico.DataSource = GetListHistorico(Id);
                grvHistorico.DataBind();
                if (grvHistorico.Rows.Count > 0)
                {
                    Columnas = new int[3];
                    Columnas[0] = 0;
                    Columnas[1] = 1;
                    Columnas[2] = 0;



                    CNComun.HideColumns(grvHistorico, Columnas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGridProduccion(String Id)
        {
            lblError.Text = string.Empty;
            grvProduccion.DataSource = null;
            grvProduccion.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvProduccion.DataSource = dt;
                grvProduccion.DataSource = GetListProduccion(Id);
                grvProduccion.DataBind();
                if (grvProduccion.Rows.Count > 0)
                {
                    Columnas = new int[3];
                    Columnas[0] = 0;
                    Columnas[1] = 0;
                    Columnas[2] = 0;



                    CNComun.HideColumns(grvProduccion, Columnas);
                }
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
                CNBien.ConsultarGrid(DDLDependencia.SelectedValue, DDLStatus.SelectedValue, DDLEspecie.SelectedValue, DDLEtapa.SelectedValue, txtBuscar.Text.ToUpper(), ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Bien_Detalle> GetListHistorico(String Id_inventario)
        {
            try
            {
                List<Bien_Detalle> List = new List<Bien_Detalle>();
                CNBien.ConsultarGridHistorico(Id_inventario, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Bien_Detalle> GetListProduccion(String Id_inventario)
        {
            try
            {
                List<Bien_Detalle> List = new List<Bien_Detalle>();
                CNBien.ConsultarGridProduccion(Id_inventario, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Limpiar()
        {
            lblError.Text= string.Empty;
            lblInventario.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            txtNacimiento.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtAnios.Text = string.Empty;
        }
        private void LimpiarHistorico()
        {
            lblError.Text = string.Empty;
            lblInventario_E.Text = string.Empty;
            txtDescripcion_E.Text = string.Empty;
            txtEspecie_E.Text = string.Empty;
            txtFechaNac_E.Text = string.Empty;
            txtEdad_E.Text = string.Empty;
            txtAnio_E.Text = string.Empty;
        }
        private void LimpiarProduccion()
        {
            lblError.Text = string.Empty;
            txtProduccionFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblProduccionInventario.Text = string.Empty;
            txtProduccionPeso.Text = string.Empty;
            txtProduccionEdad.Text = string.Empty;
            txtPesoVellon.Text = string.Empty;
            txtFechaTrasquila.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void LimpiarPaneles()
        {
            txtFechaEtapa_C.Text = string.Empty;
            txtPeso.Text= string.Empty;
            txtCosto.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtFechaParto.Text = string.Empty;
            txtCriasM.Text = string.Empty;
            txtCriasH.Text = string.Empty;
        }

        private void LimpiarSemoviente()
        {
            lblSem_Inventario.Text = string.Empty;
            txtSem_Raza.Text = string.Empty;
            txtSem_Arete.Text = string.Empty;
            //txtSem_Edad.Text = string.Empty;
            //txtSem_Nac.Text = string.Empty;
            txtSem_Color.Text = string.Empty;
            //txtSem_Peso.Text = string.Empty;
            txtSem_Procedencia.Text = string.Empty;
        }

        private void ActivaPanel(string Valor,string Modo)
        {
            //PANEL INICIAL
            txtPeso.Text =string.Empty;
            txtCosto.Text = string.Empty;
            txtEdadMeses.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            //PANEL HEMBRA GESTANTE
            txtFechaParto.Text = string.Empty;
            rdbtnListMetodo.SelectedValue = "0";
                  
            //PANEL HEMBRA EN LACTANCIA
            txtCriasM.Text = string.Empty;
            txtCriasH.Text = string.Empty;
            txtCriasT.Text = string.Empty;


            pnlGestante.Visible = false;
            pnlHembraG.Visible = false;
            pnlHembraL.Visible = false;
            pnlCriaL.Visible = false;

            DDLEspecie_C.Enabled = false;
            bool desbloqueado = false;
            if (Modo == "CAPTURA")
                desbloqueado = true;

            DDLEspecie_C.Enabled = desbloqueado;
            DDLEtapa_C.Enabled = desbloqueado;
            txtFechaEtapa_C.Enabled = desbloqueado;
            imgCalendarioEtapa.Visible = desbloqueado;
            imgCalendarioParto.Visible = desbloqueado;
            lnkbtnGuardar.Visible = desbloqueado;
            txtObservaciones.Enabled = desbloqueado;

            int Etapa;
            if(Valor!=null && Valor!=string.Empty)
                Etapa= Convert.ToInt32(Valor);
            else
                Etapa = -1;
            switch (Etapa)
            {
                case 0:
                    pnlGestante.Visible = true;
                    pnlGestante.Enabled = desbloqueado;
                    break;

                case 1:
                    pnlHembraG.Visible = true;
                    pnlHembraG.Enabled = desbloqueado;
                    break;

                case 2:
                    pnlHembraL.Visible = true;
                    pnlHembraL.Enabled = desbloqueado;
                    break;

                case 3:
                    pnlCriaL.Visible = true;
                    pnlCriaL.Enabled = desbloqueado;
                    break;

                case 9:
                    pnlGestante.Visible = false;
                    pnlHembraG.Visible = false;
                    pnlHembraL.Visible = false;
                    pnlCriaL.Visible = false;
                    break;
            }

            

        }

        private void LlenaEncabezado(string Seccion,Bien_Detalle Semoviente)
        {
            if (Seccion == "Principal")
            {
                lblInventario.Text = Semoviente.No_Inventario;
                txtDescripcion.Text = Semoviente.Descripcion;
                txtEspecie.Text = Semoviente.Sem_Especie;
                txtNacimiento.Text = Semoviente.Sem_FechaNac_Str;
                txtEdad.Text = Semoviente.Sem_Edad;
                txtAnios.Text = Semoviente.Sem_Edad_Anios;
                txtSexo.Text = Semoviente.Sem_Sexo;
            }
            else
            {
                lblInventario_E.Text = Semoviente.No_Inventario;
                txtDescripcion_E.Text = Semoviente.Descripcion;
                txtEspecie_E.Text = Semoviente.Sem_Especie;
                txtFechaNac_E.Text = Semoviente.Sem_FechaNac_Str;
                txtEdad_E.Text = Semoviente.Sem_Edad;
                txtAnio_E.Text = Semoviente.Sem_Edad_Anios;
                txtSexo_E.Text = Semoviente.Sem_Sexo;
            }
        }

        #endregion

        #region <Botones y Eventos>
        protected void DDLEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Etapa_Productiva", ref DDLEtapa, "p_especie", DDLEspecie.SelectedValue);
        }
       
        protected void grvHistorico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvHistorico.PageIndex = 0;
            grvHistorico.PageIndex = e.NewPageIndex;
            CargarGridHistorico(grvSemovientes.SelectedRow.Cells[0].Text);
        }
        protected void grvHistorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
            Verificador = string.Empty;
            lblError.Text = string.Empty;
            Etapas.Clear();
            hdnFieldEditar.Value = "0";
            try
            {
                
                ObjBien_Detalle.Id = Convert.ToInt32(grvSemovientes.SelectedRow.Cells[0].Text);
                ObjBien_Detalle.No_Inventario = Convert.ToString(grvSemovientes.SelectedRow.Cells[2].Text);
                ObjBien_Detalle.Sem_Id_Etapa = Convert.ToString(grvHistorico.SelectedRow.Cells[0].Text);
               
                CNBien.ConsultarBien_SemovienteEtapa(ref ObjBien_Detalle, ref Verificador);
                if (Verificador == "0")
                {
                    MultiView1.ActiveViewIndex = 2;

                    lblInventario_E.Text = lblInventario.Text;
                    txtDescripcion_E.Text = txtDescripcion.Text;
                    txtEspecie_E.Text = txtEspecie.Text;
                    txtFechaNac_E.Text = txtNacimiento.Text;
                    txtEdadMeses.Text = txtEdad.Text;
                    txtAnio_E.Text=txtAnios.Text;
                    txtSexo_E.Text =txtSexo.Text;

                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Especies_Captura", ref DDLEspecie_C, "p_id_inventario", Convert.ToString(ObjBien_Detalle.Id));
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Etapa_Productiva", ref DDLEtapa_C, "p_especie", DDLEspecie_C.SelectedValue, ref Etapas);
                    DDLEtapa_C.SelectedValue = grvHistorico.SelectedRow.Cells[1].Text;
                    ActivaPanel(Etapas[DDLEtapa_C.SelectedIndex].EtiquetaDos, "");
                    txtFechaEtapa_C.Text = ObjBien_Detalle.Sem_FechaEtapa_Str;

                    //PANEL INICIAL
                    txtPeso.Text = ObjBien_Detalle.Sem_Peso;
                    txtCosto.Text = Convert.ToString(ObjBien_Detalle.Costo);
                    txtEdadMeses.Text = ObjBien_Detalle.Sem_Edad;
                    txtObservaciones.Text = ObjBien_Detalle.Observaciones;
                    //PANEL HEMBRA GESTANTE
                    txtFechaParto.Text = ObjBien_Detalle.Sem_FechaParto_Str;
                    DDLEmpadre.SelectedValue = ObjBien_Detalle.Sem_Id_Semental;
                    switch(ObjBien_Detalle.Sem_Metodo)
                        {
                        case "TRADICIONAL":
                            rdbtnListMetodo.SelectedValue = "0";
                            break;
                        case "INSEMINACION":
                            rdbtnListMetodo.SelectedValue = "1";
                            break;
                        case "EMBRIONES":
                            rdbtnListMetodo.SelectedValue = "2";
                            break;
                    }

                    //PANEL HEMBRA EN LACTANCIA
                    txtCriasM.Text = ObjBien_Detalle.Sem_CriasM;
                    txtCriasH.Text = ObjBien_Detalle.Sem_CriasH;
                    txtCriasT.Text=  Convert.ToString(Convert.ToInt32(ObjBien_Detalle.Sem_CriasM) + Convert.ToInt32(ObjBien_Detalle.Sem_CriasH));

                    //PANEL CRIA EN LACTANCIA
                    DDLPadre.SelectedValue = ObjBien_Detalle.Sem_Id_Padre;
                    DDLMadre.SelectedValue = ObjBien_Detalle.Sem_Id_Madre;

                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al recuperar el registro: " + Verificador + "');", true);
                }

               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void DDLEspecie_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            Etapas.Clear();
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Etapa_Productiva", ref DDLEtapa_C, "p_especie", DDLEspecie_C.SelectedValue, ref Etapas);
        }
        protected void DDLEtapa_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivaPanel(Etapas[DDLEtapa_C.SelectedIndex].EtiquetaDos,"CAPTURA");
        }
        protected void grvSemovientes_SelectedIndexChanged(object sender, EventArgs e)
        {
                Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
                lblError.Text = string.Empty;
      
                try
                {
                    ObjBien_Detalle.Id = Convert.ToInt32(grvSemovientes.SelectedRow.Cells[0].Text);
                    Verificador = string.Empty;
                    CNBien.ConsultarBien_Semoviente(ref ObjBien_Detalle, ref Verificador);
                    if (Verificador == "0")
                    {
                        MultiView1.ActiveViewIndex = 1;
                        ObjBien_Detalle.No_Inventario= Convert.ToString(grvSemovientes.SelectedRow.Cells[2].Text);
                        LlenaEncabezado("Principal", ObjBien_Detalle);
                        CargarGridHistorico(grvSemovientes.SelectedRow.Cells[0].Text);
                    }
                    else
                    {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al recuperar el registro: " + Verificador + "');", true);
                }
                }
                catch (Exception ex)
                {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }
            
        }
        protected void grvSemovientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fila = e.RowIndex;
            hdnFieldFila.Value = Convert.ToString(fila);
            Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
            lblError.Text = string.Empty;
            Verificador = string.Empty;
            Etapas.Clear();
            hdnFieldEditar.Value = "1";
            try
            {
                ObjBien_Detalle.Id = Convert.ToInt32(grvSemovientes.Rows[fila].Cells[0].Text);
                
                CNBien.ConsultarBien_Semoviente(ref ObjBien_Detalle, ref Verificador);
                if (Verificador == "0")
                {
                    MultiView1.ActiveViewIndex = 2;
                    ObjBien_Detalle.No_Inventario=Convert.ToString(grvSemovientes.Rows[fila].Cells[2].Text);
                    LlenaEncabezado("",ObjBien_Detalle);

                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Especies_Captura", ref DDLEspecie_C, "p_id_inventario", Convert.ToString(ObjBien_Detalle.Id));
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Etapa_Productiva", ref DDLEtapa_C, "p_especie", DDLEspecie_C.SelectedValue, ref Etapas);
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Sementales", ref DDLMadre, "p_centro_contable", "p_tipo",DDLDependencia.SelectedValue,"MADRE");
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Sementales", ref DDLPadre, "p_centro_contable", "p_tipo", DDLDependencia.SelectedValue, "PADRE");
                    CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Sementales", ref DDLEmpadre, "p_centro_contable", "p_tipo", DDLDependencia.SelectedValue, "PADRE");
                    //DDLEmpadre = DDLPadre;
                    //DDLEtapa_C.SelectedValue = grvHistorico.SelectedRow.Cells[1].Text;
                    DDLEtapa_C.Enabled = true;
                    txtFechaEtapa_C.Text = System.DateTime.Now.ToString("dd/MM/yyyy"); 
                    if(Etapas.Count>0)
                        ActivaPanel(Etapas[DDLEtapa_C.SelectedIndex].EtiquetaDos,"CAPTURA");
                    else
                        ActivaPanel("9", "CAPTURA");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al recuperar el registro: " + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }
    }
        protected void grvSemovientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSemovientes.PageIndex = 0;
            grvSemovientes.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grvProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProduccion.PageIndex = 0;
            grvProduccion.PageIndex = e.NewPageIndex;
            CargarGridProduccion(grvSemovientes.SelectedRow.Cells[0].Text);
        }
        protected void grvProduccion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try

            { 
            int fila = e.RowIndex;
            Bien Obj_Bien = new Bien();
            Obj_Bien.Id = Convert.ToInt32(grvProduccion.Rows[fila].Cells[0].Text);
            lblError.Text = string.Empty;
            Verificador = string.Empty;

            CNBien.EliminarProduccion(Obj_Bien, ref Verificador);

            if (Verificador != "0")
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al intentar eliminar el registro: " + Verificador + "');", true);
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion('" + Verificador + "');", true);
                CargarGridProduccion(grvSemovientes.SelectedRow.Cells[0].Text);
            }

        }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
}
        protected void imgBttnPdf(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Semoviente&dependencia=" + DDLDependencia.SelectedValue + "&status=" + DDLStatus.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-SemovientesXLS&dependencia=" + DDLDependencia.SelectedValue + "&status=" + DDLStatus.SelectedValue + "&buscar=" + txtBuscar.Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_centro_trabajo", ref DDLSem_CentroTrabajo, "p_dependencia", DDLDependencia.SelectedValue);
            CargarGrid();
        }
        protected void btnProduccion_Agregar_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
            LimpiarProduccion();
            lblProduccionInventario.Text = lblProd_Inventario.Text;
            if (grvSemovientes.SelectedRow.Cells[3].Text == "1176")
                PanelOvinos.Visible = true;
            else
                PanelOvinos.Visible = false;
        }

        protected void linkBttnRegresar_Click(object sender, EventArgs e)
        {
            Limpiar();
            MultiView1.ActiveViewIndex = 0;
        }
        protected void linkBttnSalir_Click(object sender, EventArgs e)
        {
                LimpiarSemoviente();
                MultiView1.ActiveViewIndex = 0;
            
        }
        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvSemovientes.SelectedIndex = row.RowIndex;
            hdnFieldFila.Value = Convert.ToString(row.RowIndex);
            LimpiarSemoviente();
            MultiView1.ActiveViewIndex = 3;
            Bien_Detalle Semoviente = new Bien_Detalle();
            
            try
            {
                Semoviente.Id = Convert.ToInt32(grvSemovientes.SelectedRow.Cells[0].Text);
                Verificador = string.Empty;
                CNBien.ConsultarBien(ref Semoviente, ref Verificador);
                if (Verificador == "0")
                {
                    lblSem_Inventario.Text = grvSemovientes.SelectedRow.Cells[2].Text;
                    txtSem_Raza.Text = Semoviente.Sem_Raza;
                    txtSem_Arete.Text = Semoviente.Sem_Arete;
                    //txtSem_Edad.Text = Semoviente.Sem_Edad;
                    txtSem_Nac.Text = Semoviente.Sem_FechaNac_Str;
                    txtSem_Color.Text = Semoviente.Color;
                    //txtSem_Peso.Text = Semoviente.Sem_Peso;
                    if(Semoviente.Sem_Sexo=="H" || Semoviente.Sem_Sexo == "M" || Semoviente.Sem_Sexo == null )
                        DDLSem_Sexo.SelectedValue = "NO";
                    else
                            DDLSem_Sexo.SelectedValue = Semoviente.Sem_Sexo;
                    txtSem_Procedencia.Text = Semoviente.Procedencia.ToUpper();
                    DDLSem_CentroTrabajo.SelectedValue = Semoviente.Centro_Trabajo;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al recuperar el registro: " + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void linkBttnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Bien_Detalle Semoviente = new Bien_Detalle();

                int fila = Convert.ToInt32(hdnFieldFila.Value);
                Semoviente.Id = Convert.ToInt32(grvSemovientes.Rows[fila].Cells[0].Text);
                Semoviente.Sem_Raza=txtSem_Raza.Text  ;
                Semoviente.Sem_Arete=txtSem_Arete.Text ;
                //Semoviente.Sem_Edad=txtSem_Edad.Text  ;
                Semoviente.Procedencia = txtSem_Procedencia.Text;
                Semoviente.Color=txtSem_Color.Text ;
                //Semoviente.Sem_Peso=txtSem_Peso.Text ;
                Semoviente.Centro_Trabajo = DDLSem_CentroTrabajo.SelectedValue;
                Semoviente.Sem_Sexo=DDLSem_Sexo.SelectedValue ;
                Semoviente.Sem_FechaNac_Str = txtSem_Nac.Text;
                Semoviente.Captura_Usuario = SesionUsu.Usu_Nombre;
                Verificador = string.Empty;
                CNBien.ActualizarSemoviente(ref Semoviente, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos del semoviente se actualizaron satisfactoriamente." + "');", true);
                    LimpiarSemoviente();
                    hdnFieldEditar.Value = "0";
                    MultiView1.ActiveViewIndex = 0;
                    CargarGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al intentar actualizar los datos del semoviente: " + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void linkBttnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvHistorico.SelectedIndex = row.RowIndex;

                Bien Obj_Bien = new Bien();
                Obj_Bien.Id = Convert.ToInt32(grvHistorico.SelectedRow.Cells[0].Text);
                lblError.Text = string.Empty;
                Verificador = string.Empty;

                CNBien.EliminarEtapa(Obj_Bien, ref Verificador);

                if (Verificador != "0")
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al intentar eliminar la etapa: " + Verificador + "');", true);
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion('" + Verificador + "');", true);
                    CargarGridHistorico(grvSemovientes.SelectedRow.Cells[0].Text);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void linkBttnProduccion_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvSemovientes.SelectedIndex = row.RowIndex;
            lblError.Text = string.Empty;

            try
            {
                
                Verificador = string.Empty;
                MultiView1.ActiveViewIndex = 4;
                lblProd_Inventario.Text = grvSemovientes.SelectedRow.Cells[2].Text;
                CargarGridProduccion(grvSemovientes.SelectedRow.Cells[0].Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }
            
        }
        protected void linkBttnCancelar_Click(object sender, EventArgs e)
        {
            if (hdnFieldEditar.Value == "0")
            {
                LimpiarHistorico();
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                Limpiar();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        protected void linkBttnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Bien_Detalle Semoviente = new Bien_Detalle();

                int fila = Convert.ToInt32(hdnFieldFila.Value);
                Semoviente.Id = Convert.ToInt32(grvSemovientes.Rows[fila].Cells[0].Text);
                Semoviente.Sem_Id_Etapa = DDLEtapa_C.SelectedValue;
                Semoviente.Sem_FechaEtapa_Str = txtFechaEtapa_C.Text;
                Semoviente.Sem_Peso = txtPeso.Text;
                if(txtCosto.Text!=String.Empty)
                Semoviente.Costo = Convert.ToDouble(txtCosto.Text);
                Semoviente.Sem_FechaParto_Str = txtFechaParto.Text;
               
                if (rdbtnListMetodo.SelectedValue=="0")
                    Semoviente.Sem_Metodo = "TRADICIONAL";
                else if (rdbtnListMetodo.SelectedValue == "1")
                    Semoviente.Sem_Metodo = "INSEMINACION";
                else if (rdbtnListMetodo.SelectedValue == "2")
                    Semoviente.Sem_Metodo = "EMBRIONES";
                else
                    Semoviente.Sem_Metodo = string.Empty;
                Semoviente.Sem_CriasH = txtCriasH.Text;
                Semoviente.Sem_CriasM = txtCriasM.Text;
                Semoviente.Sem_Id_Semental = string.Empty;
                Semoviente.Sem_Id_Padre = string.Empty;
                Semoviente.Sem_Id_Madre = string.Empty;

                if (Etapas[DDLEtapa_C.SelectedIndex].EtiquetaDos=="3")
                {
                    Semoviente.Sem_Peso =  string.Empty;
                    Semoviente.Costo =  0;
                    Semoviente.Sem_Id_Padre = DDLPadre.SelectedValue;
                    Semoviente.Sem_Id_Madre = DDLMadre.SelectedValue;
                }
                if (Etapas[DDLEtapa_C.SelectedIndex].EtiquetaDos == "1")
                {
                    Semoviente.Sem_Peso = string.Empty;
                    Semoviente.Costo = 0;
                    Semoviente.Sem_Id_Semental = DDLEmpadre.SelectedValue;
                }

                Semoviente.Observaciones = txtObservaciones.Text.ToUpper();
                Semoviente.Captura_Usuario = SesionUsu.CUsuario;
                Semoviente.Sem_Edad = txtEdadMeses.Text;
                Verificador = string.Empty;
                CNBien.InsertarSemoviente(ref Semoviente, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'El registro se guardó satisfactoriamente." + "');", true);
                    LimpiarPaneles();
                    Limpiar();
                    hdnFieldEditar.Value = "0";
                    MultiView1.ActiveViewIndex = 0;
                    CargarGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al intentar guardar el registro: " + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }

    }
        protected void linkBttnCancelarProduccion_Click(object sender, EventArgs e)
        {
            
                LimpiarProduccion();
                MultiView1.ActiveViewIndex = 4;
               CargarGridProduccion(grvSemovientes.SelectedRow.Cells[0].Text);
           
        }
        protected void linkBttnGuardarProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                Bien_Detalle Semoviente = new Bien_Detalle();
                
                Semoviente.Id = Convert.ToInt32(grvSemovientes.SelectedRow.Cells[0].Text);
                Semoviente.Sem_Id_Especie = grvSemovientes.SelectedRow.Cells[3].Text;
                Semoviente.Sem_FechaNac_Str = txtProduccionFecha.Text;
                Semoviente.Sem_Peso = txtProduccionPeso.Text;
                Semoviente.Sem_Edad = txtProduccionEdad.Text;
                Semoviente.Sem_Vellon = txtPesoVellon.Text;
                Semoviente.Sem_Calidad = DDLCalidadVellon.SelectedValue;
                Semoviente.Sem_FechaTrasquila_Str = txtFechaTrasquila.Text;
                Semoviente.Sem_Epoca = DDLEpoca.SelectedValue;
                Semoviente.Sem_Grupo = DDLGrupo.SelectedValue;
              
                Semoviente.Captura_Usuario = SesionUsu.CUsuario;
                
                Verificador = string.Empty;
                CNBien.InsertarSemoviente_Produccion(ref Semoviente, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'El registro se guardó satisfactoriamente." + "');", true);
                    LimpiarProduccion();
                    MultiView1.ActiveViewIndex = 4;
                    CargarGridProduccion(grvSemovientes.SelectedRow.Cells[0].Text);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un error al intentar guardar el registro: " + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
            }

        }

        
    }


    #endregion



}