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
    public partial class frmBajas : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Int32[] Celdas = new Int32[] { 0, 7, 11, 0 };
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
        Baja ObjBajaDet = new Baja();
        Baja ObjBaja = new Baja();
        CN_Baja CNBaja = new CN_Baja();
        CN_Transferencia_Det CNTransferenciaDet = new CN_Transferencia_Det();
        private static List<Comun> DependenciaOrigen = new List<Comun>();
        private static List<Comun> ListInventario = new List<Comun>();
        List<Baja> ListBajaDet = new List<Baja>();
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
        }
        private void CargarCheckBoxList(string SP, ref CheckBoxList Combo, string Parametro1, string Parametro2, string Parametro3, string Valor1, string Valor2, string Valor3)
        {
            try
            {
                string[] Parametros = { Parametro1, Parametro2, Parametro3 };
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
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDependencia, "p_usuario", SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_basicos", ref DDLTipo_Baja, "p_tipo", "PAT_CAT_BAJAS");
                //CNComun.LlenaCombo("pkg_patrimonio.OBT_Combo_Ejercicios", ref DDLEjercicio);
                DDLEjercicio_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {
            lblError.Text = string.Empty;
            grvBajas.DataSource = null;
            grvBajas.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvBajas.DataSource = dt;
                grvBajas.DataSource = GetList();
                grvBajas.DataBind();

                if (grvBajas.Rows.Count > 0)
                {
                    //if (SesionUsu.Usu_TipoUsu!="1")
                    //    CNComun.HideColumns(grvBajas, Celdas);
                    //else
                    //{
                    //    Celdas[2]= 11;
                    //    CNComun.HideColumns(grvBajas, Celdas);
                    //}
                    string Code;
                    Code = Convert.ToString(Request.QueryString["Code"]);
                    Celdas[0] = 0;
                    Celdas[1] = 16;
                    if (Code != "02721")
                        Celdas[3] = 13;
                    CNComun.HideColumns(grvBajas, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Baja> GetList()
        {
            Session["DatosGridBajas"] = null;
            try
            {
                List<Baja> List = new List<Baja>();
                List.Clear();
                ObjBaja.Origen_Dependencia = DDLDepOrigen.SelectedValue;
                //DDLDepOrigen.SelectedValue = ObjBaja.Origen_Dependencia;
                ObjBaja.Status = DDLStatus.SelectedValue;
                CNBaja.Obtener_Grid(ref ObjBaja, txtFechaIni.Text, txtFechaFin.Text, txtBuscar.Text, ref List);
                Session["DatosGridBajas"] = List;
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGridDetalle(List<Baja> ListBajaDet)
        {
            lblError.Text = string.Empty;
            grvBajasDet.DataSource = null;
            grvBajasDet.DataBind();
            try
            {
                grvBajasDet.DataSource = ListBajaDet;
                grvBajasDet.DataBind();


                if (SesionUsu.Editar == 2)
                    Celdas = new Int32[] { 0, 0 };
                else
                    Celdas = new Int32[] { 0 };

                if (grvBajasDet.Rows.Count > 0)
                    CNComun.HideColumns(grvBajasDet, Celdas);


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CambiarStatus(string Fecha)
        {
            try
            {
                Verificador = string.Empty;
                if (Convert.ToString(grvBajas.SelectedRow.Cells[7].Text) == "Editar")
                {
                    string Status = (SesionUsu.Columna == 1) ? "R" : (SesionUsu.Columna == 2) ? "C" : null;
                    ObjBaja.Status = Status;
                    ObjBaja.Usuario_Movimiento = SesionUsu.Usu_Nombre;

                    ObjBaja.IdTransferencia = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
                    ObjBaja.Fecha_Transferencia = Convert.ToString(grvBajas.SelectedRow.Cells[2].Text);
                    ObjBaja.Fecha_Movimiento = Fecha;
                    ObjBaja.Origen_Dependencia = Convert.ToString(grvBajas.SelectedRow.Cells[3].Text);
                    ObjBaja.bien.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                    ObjBaja.Tipo_Baja = Convert.ToInt32(grvBajas.SelectedRow.Cells[16].Text);
                    //ObjBaja.Observaciones = Convert.ToString(grvBajas.SelectedRow.Cells[5].Text) + " / " + txtMsjTransfObs.Text;
                    ObjBaja.Observaciones = txtMsjTransfObs.Text.ToUpper();
                    CNBaja.Editar_Status(ref ObjBaja, ref Verificador);
                    if (Verificador == "0")
                    {
                        btnCancelar_Click(null, null);
                        CargarGrid();
                    }
                    else
                        lblError.Text = Verificador;

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
                ObjBaja.IdTransferencia = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
                CNBaja.Eliminar(ObjBaja, ref Verificador);
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
            txtFecha_Baja.Enabled = estado;
            DDLDependencia.Enabled = estado;
            DDLTipo_Baja.Enabled = estado;
            txtObservaciones.Enabled = estado;
            //DDLEjercicio.Enabled = estado;
            txtInventario_Inicial.Enabled = estado;
            txtInventario_Final.Enabled = estado;
            chkLstInventario.Enabled = estado;
            btnAgregar.Enabled = estado;
            grvBajasDet.Enabled = estado;
            imgBttnBusca.Enabled = estado;
            btnGuardar.Enabled = estado;
            //DDLPoliza.Enabled = estado;
            //DDLCuentas_Contables.Enabled = estado;
            //DDLInventario.Enabled = estado;
        }
        private void Inicializa_controles()
        {
            txtFecha_Baja.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtInventario_Inicial.Text = string.Empty;
            txtInventario_Final.Text = string.Empty;
            MultiView1.ActiveViewIndex = 1;
            Session["BajasDet"] = null;
            grvBajasDet.DataSource = null;
            grvBajasDet.DataBind();
            ListBajaDet.Clear();
        }
        protected void ValidateInvIni(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Length >= 10);
        }
        private void VerificaFechas(TextBox txt)
        {
            lblError.Text = string.Empty;
            DateTime fecha;
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
                //lblError.Text = "Ejercicio incorrecto";
            }


        }
        #endregion

        #region <Botones y Eventos>

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //CNComun.Habilitar_controles(this);
            lblError.Text = string.Empty;
            Inhabilita_Habilita_controles(true);
            MultiView1.ActiveViewIndex = 0;
        }
        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtInventario_Inicial.Text = DDLDependencia.SelectedItem.ToString().Substring(0,3)+"-"+DDLEjercicio.SelectedItem.ToString().Substring(2) + "0001";
            //txtInventario_Final.Text = DDLDependencia.SelectedItem.ToString().Substring(0, 3) + "-" + DDLEjercicio.SelectedItem.ToString().Substring(2) + "0001";
        }
        protected void txtFecha_Movimiento_TextChanged(object sender, EventArgs e)
        {
            //DDLDependencia_SelectedIndexChanged(null, null);
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
        protected void linkBttnRegresar_Click(object sender, EventArgs e)
        {
            //Session["TransferenciaDet"] = null;
            //grvBajasDet.DataSource = null;
            //grvBajasDet.DataBind();
            //ListTransferenciaDet.Clear();           
            MultiView2.ActiveViewIndex = 0;
            btnGuardar.Visible = false;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            Verificador = string.Empty;
            //int idTrans=0;
            try
            {
                ObjBaja.Fecha_Transferencia = txtFecha_Baja.Text;
                ObjBaja.Origen_Dependencia = DDLDependencia.SelectedValue;
                ObjBaja.Tipo_Baja = Convert.ToInt32(DDLTipo_Baja.SelectedValue);
                ObjBaja.Tipo_Baja_Str = DDLTipo_Baja.SelectedItem.ToString();
                ObjBaja.Observaciones = txtObservaciones.Text.ToUpper();

                if (SesionUsu.Editar == 0)
                {
                    ObjBaja.Usuario_Transferencia = SesionUsu.Usu_Nombre;
                    ListBajaDet = (List<Baja>)Session["BajasDet"];
                    if (ListBajaDet != null && ListBajaDet.Count > 0)
                    {
                        CNBaja.Insertar(ref ObjBaja, ref Verificador);
                        if (Verificador == "0")
                        {
                            int idBaja = ObjBaja.IdTransferencia;

                            CNBaja.Insertar_Detalle(ListBajaDet, ObjBaja, ref Verificador);
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
                    else
                        lblError.Text = "Agregue los bienes que desea incluir en la solicitud de baja.";
                }

                else if (SesionUsu.Editar == 1)
                {
                    ObjBaja.IdTransferencia = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
                    int idBaja = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
                    ListBajaDet = (List<Baja>)Session["BajasDet"];
                    if (ListBajaDet != null && ListBajaDet.Count > 0)
                    {
                        CNBaja.Editar(ObjBaja, ref Verificador);
                        if (Verificador == "0")
                        {
                            CNBaja.Insertar_Detalle(ListBajaDet, ObjBaja, ref Verificador);
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
                    else
                        lblError.Text = "Agregue los bienes que desea incluir en la solicitud de baja.";

                }


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }
        protected void grvBajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTransferencia = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
            string urlReporte = string.Empty;
            urlReporte = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-SolicitudBaja&Id=" + idTransferencia;
            string _open = "window.open('" + urlReporte + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void grvBajas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fila = e.RowIndex;


            string urlReporte = string.Empty;
            urlReporte = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-DictamenBaja&Id=" + grvBajas.Rows[fila].Cells[0].Text;
            string _open = "window.open('" + urlReporte + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void grvBajas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvBajas.PageIndex = 0;
            grvBajas.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {

            lblError.Text = string.Empty;
            try
            {
                Inicializa_controles();
                //MultiView1.ActiveViewIndex = 1;
                //Session["TransferenciaDet"] = null;
                //grvBajasDet.DataSource = null;
                //grvBajasDet.DataBind();
                //ListTransferenciaDet.Clear();                 
                imgBttnBusca_Click(null, null);
                txtFecha_Baja.Text = System.DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
                DDLDependencia.SelectedValue = DDLDepOrigen.SelectedValue;
                DDLEjercicio_SelectedIndexChanged(null, null);
                SesionUsu.Editar = 0;
                SesionUsu.Columna = 0;
                MultiView2.ActiveViewIndex = 0;
                btnAgregar.Enabled = true;
                btnGuardar.Visible = false;


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
                var allChecked = (from ListItem item in chkLstInventario.Items
                                  where item.Selected
                                  select int.Parse(item.Value)).ToList();


                //ListTransferenciaDet = new List<Transferencia_Detalle>();

                for (int i = 0; i < allChecked.Count(); i++)
                {
                    Baja ObjBajaDet = new Baja();
                    chkLstInventario.SelectedValue = allChecked[i].ToString();
                    ObjBajaDet.IdInventario = Convert.ToInt32(chkLstInventario.SelectedValue);
                    ObjBajaDet.Inventario_Numero = Convert.ToString(chkLstInventario.Items[chkLstInventario.SelectedIndex].Text);
                    ObjBajaDet.bien_det.Cantidad = Convert.ToInt32(ListInventario[chkLstInventario.SelectedIndex].EtiquetaDos);
                    ObjBajaDet.bien_det.Marca = Convert.ToString(ListInventario[chkLstInventario.SelectedIndex].EtiquetaTres);
                    ObjBajaDet.bien_det.Modelo = Convert.ToString(ListInventario[chkLstInventario.SelectedIndex].EtiquetaCuatro);
                    ObjBajaDet.bien_det.No_Serie = Convert.ToString(ListInventario[chkLstInventario.SelectedIndex].EtiquetaCinco);
                    ObjBajaDet.bien_det.Costo = Convert.ToDouble(ListInventario[chkLstInventario.SelectedIndex].EtiquetaSeis);
                    if (Session["BajasDet"] == null)
                    {
                        ListBajaDet = new List<Baja>();
                        ListBajaDet.Add(ObjBajaDet);
                    }
                    else
                    {
                        ListBajaDet = (List<Baja>)Session["BajasDet"];
                        if (ListBajaDet.Exists(Bien => Bien.IdInventario == ObjBajaDet.IdInventario))
                        { }
                        else
                            ListBajaDet.Add(ObjBajaDet);
                    }
                    Session["BajasDet"] = ListBajaDet;
                    //ListTransferenciaDet.Add(ObjTransferenciaDet);                   

                }
                //Session["TransferenciaDet"] = ListTransferenciaDet;
                CargarGridDetalle(ListBajaDet);
                txtInventario_Inicial.Focus();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void linkBttnPoliza_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvBajas.SelectedIndex = row.RowIndex;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerPoliza('RP-005'," + SesionUsu.Usu_Ejercicio + ", '" + grvBajas.SelectedRow.Cells[11].Text + "');", true);
            string urlReporte = string.Empty;
            urlReporte = "../../Contabilidad/Reportes/VisualizadorCrystal.aspx?Tipo=RP-005&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Id=" + grvBajas.SelectedRow.Cells[11].Text;
            string _open = "window.open('" + urlReporte + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvBajas.SelectedIndex = row.RowIndex;
            Inicializa_controles();
            imgBttnBusca_Click(null, null);
            lblError.Text = string.Empty;
            try
            {
                if (Convert.ToString(grvBajas.SelectedRow.Cells[7].Text) == "Ver")
                {
                    Inhabilita_Habilita_controles(false);
                    //txtObservaciones.Enabled = true;
                    btnAgregar.Enabled = false;
                    SesionUsu.Editar = 2;
                    MultiView2.ActiveViewIndex = 0;
                }

                else
                {
                    Inhabilita_Habilita_controles(true);
                    btnAgregar.Enabled = true;
                    SesionUsu.Editar = 1;
                    MultiView2.ActiveViewIndex = 0;
                }


                ObjBaja.IdTransferencia = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
                CNBaja.ConsultarDatos(ref ObjBaja, ref Verificador);
                txtFecha_Baja.Text = ObjBaja.Fecha_Transferencia;
                DDLDependencia.SelectedValue = ObjBaja.Origen_Dependencia;
                DDLTipo_Baja.SelectedItem.Text = ObjBaja.Tipo_Baja_Str;
                txtObservaciones.Text = ObjBaja.Observaciones;
                ObjBajaDet.IdTransferencia = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
                CNBaja.Obtener_Grid_Detalle(ref ObjBajaDet, ref ListBajaDet);
                Session["BajasDet"] = ListBajaDet;

                if (ListBajaDet.Count() >= 1)
                    CargarGridDetalle(ListBajaDet);


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void linkBttnExcel_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvBajas.SelectedIndex = row.RowIndex;

            int Id_Sol_Baja = Convert.ToInt32(grvBajas.SelectedRow.Cells[0].Text);
            string urlReporte = string.Empty;
            urlReporte = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-SolicitudBajaXLS&Id=" + Id_Sol_Baja;
            string _open = "window.open('" + urlReporte + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void imgBttnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvBajas.SelectedIndex = row.RowIndex;
            if (Convert.ToString(grvBajas.SelectedRow.Cells[7].Text) == "Editar")
            {
                lblMsjTransf.Text = "¿Desea aplicar la baja con folio " + Convert.ToString(grvBajas.SelectedRow.Cells[1].Text) + "?";
                lblFechaBaja.Visible = true;
                txtFechaBaja.Visible = true;
                txtMsjTransfObs.Visible = true;
                txtMsjTransfObs.Text = "Ingrese el No. de Dictamen aquí...";
                txtFechaBaja.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
                SesionUsu.Columna = 1;
                modalTransf.Show();
            }
        }
        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvBajas.SelectedIndex = row.RowIndex;

            try
            {
                SesionUsu.Columna = 2;
                //if (Convert.ToString(grvBajas.SelectedRow.Cells[7].Text) == "Editar")
                //{
                //    lblMsjTransf.Text = "Motivo del Rechazo del bien con folio " + Convert.ToString(grvBajas.SelectedRow.Cells[1].Text);
                //    txtMsjTransfObs.Visible = true;
                //    modalTransf.Show();
                //}
                //else
                //{
                lblMsjTransf.Text = "¿Desea eliminar la captura con folio " + Convert.ToString(grvBajas.SelectedRow.Cells[1].Text) + "?";
                txtMsjTransfObs.Visible = false;
                lblFechaBaja.Visible = false;
                txtFechaBaja.Visible = false;
                modalTransf.Show();
                //}
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            if ((Convert.ToString(grvBajas.SelectedRow.Cells[7].Text) == "Editar") && SesionUsu.Columna == 1)
                CambiarStatus(txtFechaBaja.Text);
            else
                EliminarRegistro();
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            lblFechaBaja.Visible = false;
            txtFechaBaja.Visible = false;
            modalTransf.Hide();
        }
        protected void grvBajasDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grvBajasDet.PageSize * grvBajasDet.PageIndex;
                fila = pagina + fila;
                List<Baja> ListBajaDet = new List<Baja>();
                ListBajaDet = (List<Baja>)Session["BajasDet"];
                ListBajaDet.RemoveAt(fila);
                Session["BajasDet"] = ListBajaDet;
                CargarGridDetalle(ListBajaDet);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void grvBajasDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvBajasDet.PageIndex = 0;
            grvBajasDet.PageIndex = e.NewPageIndex;
            ListBajaDet = (List<Baja>)Session["BajasDet"];
            CargarGridDetalle(ListBajaDet);
        }
        protected void DDLEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarCheckBoxList("pkg_patrimonio.OBT_Combo_Inventarios", ref chkLstInventario, "P_Dependencia", "P_Ejercicio", DDLDepOrigen1.SelectedValue, DDLEjercicio.SelectedValue);
            //txtInventario_Inicial.Text = DDLDependencia.SelectedItem.ToString().Substring(0,3)+"-"+DDLEjercicio.SelectedItem.ToString().Substring(2) + "0001";
            //txtInventario_Final.Text = DDLDependencia.SelectedItem.ToString().Substring(0, 3) + "-" + DDLEjercicio.SelectedItem.ToString().Substring(2) + "0001";
        }
        protected void txtInventario_Inicial_TextChanged(object sender, EventArgs e)
        {
            txtInventario_Final.Text = txtInventario_Inicial.Text;
        }
        protected void imgBttnBusca_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                lblError.Text = string.Empty;
                //CargarCheckBoxList("pkg_patrimonio.Obt_Combo_Inventario", ref chkLstInventario, "P_Dependencia", "P_Ejercicio", "P_Inventario_Ini", "P_Inventario_Fin", DDLDependencia.SelectedValue, DDLEjercicio.SelectedValue, txtInventario_Inicial.Text, txtInventario_Final.Text);
                CargarCheckBoxList("pkg_patrimonio.Obt_Combo_Inventario", ref chkLstInventario, "P_Dependencia", "P_Inventario_Ini", "P_Inventario_Fin", DDLDependencia.SelectedValue, txtInventario_Inicial.Text, txtInventario_Final.Text);
                (from i in chkLstInventario.Items.Cast<ListItem>() select i).ToList().ForEach(i => i.Selected = true);
                if ((chkLstInventario.Items.Count >= 1) && (chkLstInventario.SelectedValue != "La opción no contiene datos.")) //.Items.ToString()!=""))
                {
                    lblInventario1.Visible = true;
                    pnlLstInventario.Visible = true;
                    btnAgregar.Visible = true;
                }
                else
                {
                    lblInventario1.Visible = false;
                    pnlLstInventario.Visible = false;
                    btnAgregar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void txtFecha_Baja_TextChanged(object sender, EventArgs e)
        {
            VerificaFechas(txtFecha_Baja);
        }


        #endregion

    }    
}