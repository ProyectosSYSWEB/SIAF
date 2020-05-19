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
    public partial class FRMTransferencias : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        String Verificador_Eliminar = string.Empty;
        Int32[] Celdas = new Int32[] { 0,4,8,13,15 };
        Sesion SesionUsu = new Sesion();     
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
        Transferencia_Detalle ObjTransferenciaDet = new Transferencia_Detalle();
        Transferencia ObjTransferencia = new Transferencia();
        CN_Transferencia CNTransferencia = new CN_Transferencia();
        CN_Transferencia_Det CNTransferenciaDet = new CN_Transferencia_Det();
        private static List<Comun> DependenciaOrigen = new List<Comun>();
        private static List<Comun> ListInventario = new List<Comun>();        
        List<Transferencia_Detalle> ListTransferenciaDet = new List<Transferencia_Detalle>();
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
            string FechaIni = "01/01/" + System.DateTime.Today.Year;
            string FechaFin = System.DateTime.Today.ToString("dd/MM/yyyy");
            SesionUsu.Editar = -1;            
            MultiView1.ActiveViewIndex = 0;
            MultiView2.ActiveViewIndex = 0;
            Cargarcombos();
            SesionUsu.Columna = 0;
            txtFechaIni.Text = FechaIni;
            txtFechaFin.Text = FechaFin;
            CargarGrid();
            //lblInventario1.Visible = false;
            //pnlLstInventario.Visible = false;
            //bttnAgregar.Visible = false;  

        }
        private void CargarCheckBoxList(string SP, ref CheckBoxList Combo, string Parametro1, string Parametro2, string Parametro3, string Valor1, string Valor2, string Valor3)
        {
            try
            {
                string[] Parametros = { Parametro1, Parametro2, Parametro3};
                string[] Valores = { Valor1, Valor2, Valor3 };
                CNComun.LlenaCheckBoxList(SP, ref Combo, Parametros, Valores, ref ListInventario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarCheckBoxList(string SP, ref CheckBoxList Combo, string Parametro1, string Parametro2, string Parametro3, string Parametro4, string Valor1, string Valor2, string Valor3, string Valor4)
        {
            try
            {
                string[] Parametros = { Parametro1, Parametro2, Parametro3, Parametro4 };
                string[] Valores = { Valor1, Valor2, Valor3, Valor4 };
                CNComun.LlenaCheckBoxList(SP, ref Combo, Parametros, Valores, ref ListInventario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        private void Cargarcombos()
        {
            lblError.Text = string.Empty;
            try
            {                
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepOrigen, "p_usuario", SesionUsu.Usu_Nombre);
                //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepDestino, "p_usuario", SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepDestino, "p_usuario", "OMAR");
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepOrigen1, "p_usuario", SesionUsu.Usu_Nombre, ref DependenciaOrigen);
                //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepDestino1, "p_usuario", SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepDestino1, "p_usuario", "OMAR");
                DDLDepDestino.Items.Insert(0, "--TODAS LAS DEPENDENCIAS--");
                //CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_Ejercicios", ref DDLEjercicio);
                //DDLEjercicio_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {
            lblError.Text = string.Empty;
            grvTransferencia.DataSource = null;
            grvTransferencia.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvTransferencia.DataSource = dt;
                grvTransferencia.DataSource = GetList();
                grvTransferencia.DataBind();

                if (grvTransferencia.Rows.Count > 0)
                {
                    CNComun.HideColumns(grvTransferencia, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Transferencia> GetList()
        {            
            Session["DatosGridTransferencias"] = null;
            try
            {
                List<Transferencia> List = new List<Transferencia>();
                List.Clear();
                ObjTransferencia.Origen_Dependencia = DDLDepOrigen.SelectedValue;
                ObjTransferencia.Destino_Dependencia = (DDLDepDestino.SelectedValue == "--TODAS LAS DEPENDENCIAS--") ? "T" : DDLDepDestino.SelectedValue;
                ObjTransferencia.Status = DDLStatus.SelectedValue;
                CNTransferencia.TransferenciaConsultaGrid(ref ObjTransferencia, txtFechaIni.Text, txtFechaFin.Text, txtBuscar.Text, ref List);
                Session["DatosGridTransferencias"] = List;
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGridDetalle(List<Transferencia_Detalle> ListTransferenciaDet)
        {
            lblError.Text = string.Empty;
            grvTransferenciaDet.DataSource = null;
            grvTransferenciaDet.DataBind();
            try
            {
                ListTransferenciaDet.Sort((x, y) => string.Compare(x.Inventario_Numero, y.Inventario_Numero));

                grvTransferenciaDet.DataSource = ListTransferenciaDet;
                grvTransferenciaDet.DataBind();


                if(SesionUsu.Editar==2)
                    Celdas = new Int32[] { 0, 7 };
                else
                    Celdas = new Int32[] { 0 };

                if (grvTransferenciaDet.Rows.Count > 0)
                    CNComun.HideColumns(grvTransferenciaDet, Celdas);                            
                
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CambiarStatus()
        {
            try
            {
                Verificador = string.Empty;
                if (Convert.ToString(grvTransferencia.SelectedRow.Cells[8].Text) == "Ver")
                {
                    string Status = (SesionUsu.Columna == 1) ? "R" : (SesionUsu.Columna == 2) ? "C" : null;
                    ObjTransferencia.Status = Status;
                    ObjTransferencia.Usuario_Movimiento = SesionUsu.Usu_Nombre;
                    ObjTransferencia.Observaciones = txtMsjTransfObs.Text;
                    ObjTransferencia.IdTransferencia = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text);
                    CNTransferencia.TransferenciaEditarStatus(ref ObjTransferencia, ref Verificador);
                    if (Verificador == "0")
                    {
                        btnCancelar_Click(null, null);
                        CargarGrid();
                    }

                    else
                    {
                        CargarGrid();
                        lblError.Text = Verificador;
                    }

                    //CargarGrid();
                }
                modalTransf.Hide();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void EliminarRegistro()
        {
            lblError.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                ObjTransferencia.IdTransferencia = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text);
                CNTransferencia.TransferenciaEliminar(ObjTransferencia, ref Verificador);
                if (Verificador == "0")
                {
                    btnCancelar_Click(null, null);
                    CargarGrid();
                }
                else
                    lblError.Text = Verificador;
                    
                modalTransf.Hide();
            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void Inhabilita_Habilita_controles(bool estado)
        {
            txtFecha_Transferencia.Enabled = estado;
            DDLDepOrigen1.Enabled = estado;
            DDLDepDestino1.Enabled = estado;
            txtObservaciones.Enabled = estado;
            bttnAgregar.Visible = estado;
            btnGuardar.Visible = estado;

            //DDLPoliza.Enabled = estado;
            //DDLCuentas_Contables.Enabled = estado;
            //DDLInventario.Enabled = estado;
        }
        private void Inicializa_controles()
        {
            txtFecha_Transferencia.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtInventario_Inicial.Text = string.Empty;
            txtInventario_Final.Text = string.Empty;
            MultiView1.ActiveViewIndex = 1;
            Session["TransferenciaDet"] = null;
            grvTransferenciaDet.DataSource = null;
            grvTransferenciaDet.DataBind();
            ListTransferenciaDet.Clear();
            lblInventario1.Visible = false;
            pnlLstInventario.Visible = false;
            bttnAgregar.Visible = false;
        }
        protected void ValidateInvIni(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Length >= 10);
        }
        private void LimpiarGrid()
        {
            lblError.Text = string.Empty;
            try
            {
                grvTransferencia.DataSource = null;
                grvTransferencia.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void VerificaFechas(TextBox txt)
        {
            lblError.Text = string.Empty;
            DateTime fecha ;

            if (txt.Text != string.Empty)
                fecha = Convert.ToDateTime(txt.Text);
            else
            {
                txt.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
                fecha = Convert.ToDateTime(txt.Text);
            }

            string Anio = fecha.ToString("yyyy");
            if (Anio != SesionUsu.Usu_Ejercicio)
            {
                txt.Text = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + SesionUsu.Usu_Ejercicio;
               
            }
        }
        #endregion

       
         

    





protected void btnCancelar_Click(object sender, EventArgs e)
        {                      
            Inhabilita_Habilita_controles(true);
            MultiView1.ActiveViewIndex = 0;
        }



        
        protected void linBttnSiguiente_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            try
            {               
                MultiView2.ActiveViewIndex = 1;
                btnGuardar.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void linkBttnPolizaBaja_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvTransferencia.SelectedIndex = row.RowIndex;

            string urlReporte = string.Empty;
            urlReporte = "../../Contabilidad/Reportes/VisualizadorCrystal.aspx?Tipo=RP-005&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Id=" + grvTransferencia.SelectedRow.Cells[13].Text;
            string _open = "window.open('" + urlReporte + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void linkBttnPolizaAlta_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvTransferencia.SelectedIndex = row.RowIndex;

            string urlReporte = string.Empty;
            urlReporte = "../../Contabilidad/Reportes/VisualizadorCrystal.aspx?Tipo=RP-005&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Id=" + grvTransferencia.SelectedRow.Cells[15].Text;
            string _open = "window.open('" + urlReporte + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void linkBttnRegresar_Click(object sender, EventArgs e)
        {
            //Session["TransferenciaDet"] = null;
            //grvTransferenciaDet.DataSource = null;
            //grvTransferenciaDet.DataBind();
            //ListTransferenciaDet.Clear();           
            MultiView2.ActiveViewIndex = 0;
            btnGuardar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            Verificador = string.Empty;
            Verificador_Eliminar = string.Empty;
            //int idTrans=0;
            try
            {
                ObjTransferencia.Fecha_Transferencia = txtFecha_Transferencia.Text;
                ObjTransferencia.Origen_Dependencia = DDLDepOrigen1.SelectedValue;
                ObjTransferencia.Destino_Dependencia = DDLDepDestino1.SelectedValue;
                ObjTransferencia.Observaciones = txtObservaciones.Text.ToUpper();
                ListTransferenciaDet = (List<Transferencia_Detalle>)Session["TransferenciaDet"];

                if (ListTransferenciaDet.Count() > 0)
                {
                    if (SesionUsu.Editar == 0)
                    {
                        ObjTransferencia.Usuario_Transferencia = SesionUsu.Usu_Nombre;
                        CNTransferencia.TransferenciaInsertar(ref ObjTransferencia, ref Verificador);
                        if (Verificador == "0")
                        {
                            int idTrans = ObjTransferencia.IdTransferencia;
                            //ListTransferenciaDet = (List<Transferencia_Detalle>)Session["TransferenciaDet"];
                            CNTransferenciaDet.TransferenciaDetInsertar(ListTransferenciaDet, idTrans, ref Verificador);
                            if (Verificador == "0")
                            {
                                DDLDepOrigen.SelectedValue = DDLDepOrigen1.SelectedValue;
                                DDLDepDestino.SelectedValue = DDLDepDestino1.SelectedValue;
                                btnCancelar_Click(null, null);
                                CargarGrid();
                            }
                            else
                            {                                
                                CNTransferencia.TransferenciaEliminar(ObjTransferencia, ref Verificador_Eliminar);
                                if (Verificador_Eliminar != "0")
                                    lblError.Text = Verificador + Verificador_Eliminar;
                                else
                                    lblError.Text = Verificador;
                            }
                        }
                        else
                            lblError.Text = Verificador;
                    }

                    else if(SesionUsu.Editar==1)
                    {
                        ObjTransferencia.IdTransferencia = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text);
                        int idTrans = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text);
                        CNTransferencia.TransferenciaEditar(ObjTransferencia, ref Verificador);
                        if (Verificador == "0")
                        {
                            //ListTransferenciaDet = (List<Transferencia_Detalle>)Session["TransferenciaDet"];
                            CNTransferenciaDet.TransferenciaDetInsertar(ListTransferenciaDet, idTrans, ref Verificador);
                            if (Verificador == "0")
                            {                                
                                btnCancelar_Click(null, null);
                                CargarGrid();
                            }
                            else
                                lblError.Text = Verificador;
                        }
                        else
                            lblError.Text = Verificador;


                    }

                }
                else
                {
                    lblError.Text = "Agregar Inventario";
                }
            }
            catch (Exception ex)
            {
                lblError.Text=ex.Message;
            }
        }

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void grvTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            int idTransferencia = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text); 
            
            try
            {
               
                //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Ver_Volante_Transferencia('RP-VOLANTE','" + idTransferencia + "');", true);
                string urlReporte = string.Empty;
                urlReporte = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-VOLANTE&Id=" + idTransferencia ;
                string _open = "window.open('" + urlReporte + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvTransferencia.SelectedIndex = row.RowIndex;
            Inicializa_controles();
            imgBttnBusca_Click(null, null);
            lblError.Text = string.Empty;            
            try
            {
                if (Convert.ToString(grvTransferencia.SelectedRow.Cells[8].Text) == "Ver")
                {                    
                    Inhabilita_Habilita_controles(false);                   
                    SesionUsu.Editar = 2;
                    MultiView2.ActiveViewIndex = 0;
                }

                else
                {                    
                    Inhabilita_Habilita_controles(true);                    
                    btnGuardar.Visible =false;
                    SesionUsu.Editar = 1;
                    MultiView2.ActiveViewIndex = 0;
                }


                ObjTransferencia.IdTransferencia = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text);
                CNTransferencia.TransferenciaConsultaDatos(ref ObjTransferencia, ref Verificador);
                txtFecha_Transferencia.Text = ObjTransferencia.Fecha_Transferencia;                
                DDLDepOrigen1.SelectedValue = ObjTransferencia.Origen_Dependencia;
                DDLDepDestino1.SelectedValue = ObjTransferencia.Destino_Dependencia;
                txtObservaciones.Text = ObjTransferencia.Observaciones;
                //DDLEjercicio.SelectedValue = Convert.ToString(System.DateTime.Today.Year);
                //DDLEjercicio_SelectedIndexChanged(null, null);
                ObjTransferenciaDet.IdTransferencia = Convert.ToInt32(grvTransferencia.SelectedRow.Cells[0].Text);
                CNTransferenciaDet.TransferenciaDetConsultaGrid(ref ObjTransferenciaDet, ref ListTransferenciaDet);
                Session["TransferenciaDet"] = ListTransferenciaDet;

                if (ListTransferenciaDet.Count() >= 1)                      
                    CargarGridDetalle(ListTransferenciaDet);
                

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }



        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //LimpiarGrid();
            //imgbtnBuscar.Focus();
        }

        protected void imgBttnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvTransferencia.SelectedIndex = row.RowIndex;       
            if (Convert.ToString(grvTransferencia.SelectedRow.Cells[8].Text) == "Ver")
            {
                lblMsjTransf.Text = "¿Esta seguro de recibir la transferencia, con folio " + Convert.ToString(grvTransferencia.SelectedRow.Cells[1].Text);
                txtMsjTransfObs.Visible = false;
                SesionUsu.Columna = 1;
                modalTransf.Show();
            }
        }
               

        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvTransferencia.SelectedIndex = row.RowIndex;
            SesionUsu.Columna = 2;
            try
            {
                if (Convert.ToString(grvTransferencia.SelectedRow.Cells[8].Text) == "Ver")
                {
                    lblMsjTransf.Text = "Motivo del Rechazo de la transferencia con folio " + Convert.ToString(grvTransferencia.SelectedRow.Cells[1].Text);
                    txtMsjTransfObs.Visible = true;
                    modalTransf.Show();
                }
                else
                {
                    lblMsjTransf.Text = "¿Esta seguro de eliminar el registro?";
                    txtMsjTransfObs.Visible = false;
                    modalTransf.Show();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(grvTransferencia.SelectedRow.Cells[8].Text) == "Ver")
                CambiarStatus();
            else
                EliminarRegistro();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            modalTransf.Hide();
        }

        protected void grvTransferenciaDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grvTransferenciaDet.PageSize * grvTransferenciaDet.PageIndex;
                fila = pagina + fila;
                List<Transferencia_Detalle> ListTransferenciaDet = new List<Transferencia_Detalle>();
                ListTransferenciaDet = (List<Transferencia_Detalle>)Session["TransferenciaDet"];
                ListTransferenciaDet.RemoveAt(fila);
                Session["TransferenciaDet"] = ListTransferenciaDet;
                CargarGridDetalle(ListTransferenciaDet);    
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //protected void DDLEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //CargarCheckBoxList("pkg_patrimonio.OBT_Combo_Inventarios", ref chkLstInventario, "P_Dependencia", "P_Ejercicio", DDLDepOrigen1.SelectedValue, DDLEjercicio.SelectedValue);
        //    lblError.Text = string.Empty;
        //    try
        //    {
        //        txtInventario_Inicial.Text = DDLDepOrigen1.SelectedValue.Substring(0, 3) + '-' + DDLEjercicio.SelectedValue.Substring(2)+"0001";
        //        txtInventario_Inicial_TextChanged(null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }
        //}
       
        

        protected void txtInventario_Inicial_TextChanged(object sender, EventArgs e)
        {
            txtInventario_Final.Text = txtInventario_Inicial.Text;
        }

        protected void imgBttnBusca_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                //CargarCheckBoxList("pkg_patrimonio.OBT_Combo_Inventarios", ref chkLstInventario, "P_Dependencia", "P_Ejercicio", "P_Inventario_Ini", "P_Inventario_Fin", DDLDepOrigen1.SelectedValue, DDLEjercicio.SelectedValue, txtInventario_Inicial.Text, txtInventario_Final.Text);
                CargarCheckBoxList("pkg_patrimonio.OBT_Combo_Inventarios", ref chkLstInventario, "P_Dependencia", "P_Inventario_Ini", "P_Inventario_Fin", DDLDepOrigen1.SelectedValue, txtInventario_Inicial.Text, txtInventario_Final.Text);
                (from i in chkLstInventario.Items.Cast<ListItem>() select i).ToList().ForEach(i => i.Selected = true);
                if ((chkLstInventario.Items.Count >= 1) && (chkLstInventario.SelectedValue!="La opción no contiene datos.")) //.Items.ToString()!=""))
                {
                    lblInventario1.Visible = true;
                    pnlLstInventario.Visible = true;
                    bttnAgregar.Visible = true;
                }
                else
                {
                    lblInventario1.Visible = false;
                    pnlLstInventario.Visible = false;
                    bttnAgregar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void grvTransferencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTransferencia.PageIndex = 0;
            grvTransferencia.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void grvTransferenciaDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblError.Text = String.Empty;
            try
            {
                grvTransferenciaDet.PageIndex = 0;
                grvTransferenciaDet.PageIndex = e.NewPageIndex;

                List<Transferencia_Detalle> ListTransferenciaDet = new List<Transferencia_Detalle>();
                ListTransferenciaDet = (List<Transferencia_Detalle>)Session["TransferenciaDet"];
                
                Session["TransferenciaDet"] = ListTransferenciaDet;
                CargarGridDetalle(ListTransferenciaDet);    
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void txtFechaFin_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                LimpiarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        //protected void DDLDepOrigen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LimpiarGrid();
        //}

        //protected void DDLDepDestino_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LimpiarGrid();
        //}

        protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarGrid();
        }

        protected void txtFechaIni_TextChanged(object sender, EventArgs e)
        {
            LimpiarGrid();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Inicializa_controles();
                imgBttnBusca_Click(null, null);
                DDLDepOrigen1.SelectedValue = DDLDepOrigen.SelectedValue;
                DDLDepDestino1.SelectedValue = DDLDepOrigen.SelectedValue;
                SesionUsu.Editar = 0;
                SesionUsu.Columna = 0;
                MultiView2.ActiveViewIndex = 0;
                bttnAgregar.Visible = true;
                btnGuardar.Visible = false;
                //string Fecha = System.DateTime.Today.ToString("dd/MM/yyyy");
                string Fecha = System.DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
                txtFecha_Transferencia.Text = Fecha;
                //DDLEjercicio.SelectedValue = Convert.ToString(System.DateTime.Today.Year);
                //DDLEjercicio_SelectedIndexChanged(null, null);
                lblInventario1.Visible = false;
                pnlLstInventario.Visible = false;
                bttnAgregar.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void bttnAgregar_Click(object sender, ImageClickEventArgs e)
        {

            lblError.Text = string.Empty;
            try
            {
                var allChecked = (from ListItem item in chkLstInventario.Items
                                  where item.Selected
                                  select int.Parse(item.Value)).ToList();



                if (allChecked.Count() >= 1)
                {
                    for (int i = 0; i < allChecked.Count(); i++)
                    {


                        Transferencia_Detalle ObjTransferenciaDet = new Transferencia_Detalle();
                        chkLstInventario.SelectedValue = allChecked[i].ToString();
                        ObjTransferenciaDet.IdInventario = Convert.ToInt32(chkLstInventario.SelectedValue);
                        ObjTransferenciaDet.Inventario_Numero = Convert.ToString(chkLstInventario.Items[chkLstInventario.SelectedIndex].Text);
                        ObjTransferenciaDet.bien_det.Cantidad = Convert.ToInt32(ListInventario[chkLstInventario.SelectedIndex].EtiquetaDos);
                        ObjTransferenciaDet.bien_det.Marca = Convert.ToString(ListInventario[chkLstInventario.SelectedIndex].EtiquetaTres);
                        ObjTransferenciaDet.bien_det.Modelo = Convert.ToString(ListInventario[chkLstInventario.SelectedIndex].EtiquetaCuatro);
                        ObjTransferenciaDet.bien_det.No_Serie = Convert.ToString(ListInventario[chkLstInventario.SelectedIndex].EtiquetaCinco);
                        ObjTransferenciaDet.bien_det.Costo = Convert.ToDouble(ListInventario[chkLstInventario.SelectedIndex].EtiquetaSeis);
                        if (Session["TransferenciaDet"] == null)
                        {
                            ListTransferenciaDet = new List<Transferencia_Detalle>();
                            ListTransferenciaDet.Add(ObjTransferenciaDet);
                        }
                        else
                        {
                            ListTransferenciaDet = (List<Transferencia_Detalle>)Session["TransferenciaDet"];
                            if (!ListTransferenciaDet.Any(x => x.IdInventario == Convert.ToInt32(chkLstInventario.SelectedValue)))
                                ListTransferenciaDet.Add(ObjTransferenciaDet);
                        }
                        Session["TransferenciaDet"] = ListTransferenciaDet;
                    }
                    (from A in chkLstInventario.Items.Cast<ListItem>() select A).ToList().ForEach(A => A.Selected = false);
                    CargarGridDetalle(ListTransferenciaDet);
                    lblInventario1.Visible = false;
                    pnlLstInventario.Visible = false;
                    bttnAgregar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void txtFecha_Transferencia_TextChanged(object sender, EventArgs e)
        {

            VerificaFechas(txtFecha_Transferencia);
    }

        
    }
}