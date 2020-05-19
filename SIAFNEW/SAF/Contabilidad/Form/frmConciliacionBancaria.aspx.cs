using AjaxControlToolkit;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Contabilidad.Form
{
    public partial class frmConciliacionBancaria : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;

        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Poliza_Conciliacion CNConciliacion = new CN_Poliza_Conciliacion();
        Poliza_Conciliacion objConciliacion = new Poliza_Conciliacion();
        Poliza_Conciliacion objAdjunto = new Poliza_Conciliacion();
        Poliza_Detalle objPolizaDet = new Poliza_Detalle();
        List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();

        private static List<Comun> ListTipo = new List<Comun>();
        private static List<Comun> ListCentroContable = new List<Comun>();

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
            else
            {
                if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null))
                {
                    if (Request.Params["__EVENTTARGET"] == this.txtNumPoliza.UniqueID)
                    {
                        if (ListTipo[ddlTipo.SelectedIndex].EtiquetaTres == "ANEXO_4")                        
                            this.txtNumCheque.Focus();
                        else
                            this.txtFecha.Focus();
                    }
                    else if (Request.Params["__EVENTTARGET"] == this.txtNumCheque.UniqueID)
                        this.txtFecha.Focus();
                    else if (Request.Params["__EVENTTARGET"] == this.txtFecha.UniqueID)
                        this.txtImporte.Focus();
                    else if (Request.Params["__EVENTTARGET"] == this.txtImporte.UniqueID)
                        this.txtConcepto.Focus();
                    else if (Request.Params["__EVENTTARGET"] == this.txtConcepto.UniqueID)
                        this.txtDescripcion.Focus();
                    //else if (Request.Params["__EVENTTARGET"] == this.txtDescripcion.UniqueID)
                    //    this.bttnAgregar.Focus();
                    else if (Request.Params["__EVENTTARGET"] == this.bttnAgregar.UniqueID)
                        this.ddlTipo.Focus();

                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Cuentas_Contables", "Autocomplete();", true);

        }
        #region <Funciones y Sub>
        private void Inicializar()
        {
            MultiView1.ActiveViewIndex = 0;
            Cargarcombos();
            CargarGrid();
            //ScriptManager.RegisterStartupScript(this, GetType(), "Materias", "FiltMat();", true);
        }
        private void Cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable1, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ref ListCentroContable);
                Session["CentrosContab"] = ListCentroContable;
                //CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Conciliacion", ref ddlTipo1, ref ListTipo);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Conciliacion", ref ddlTipo, ref ListTipo);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }
        private void CargarGrid()
        {
            Verificador = string.Empty;
            Int32[] Celdas = new Int32[] { 10, 11 };
            grdConciliacion.DataSource = null;
            grdConciliacion.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdConciliacion.DataSource = dt;
                grdConciliacion.DataSource = GetList();
                grdConciliacion.DataBind();

                if (grdConciliacion.Rows.Count > 0)
                    CNComun.HideColumns(grdConciliacion, Celdas);



            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private List<Poliza_Conciliacion> GetList()
        {
            try
            {
                List<Poliza_Conciliacion> List = new List<Poliza_Conciliacion>();
                objConciliacion.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                objConciliacion.Centro_contable = Convert.ToInt32(DDLCentro_Contable1.SelectedValue);
                objConciliacion.Fecha_inicial = txtFechaInicial1.Text;
                objConciliacion.Fecha_final = txtFechaFinal1.Text;
                //objConciliacion.Tipo = ddlTipo1.SelectedValue;
                CNConciliacion.ConciliacionConsultaGrid(objConciliacion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Copiar_a_AdjuntosTemp(List<Poliza_Conciliacion> lstPolizasAdj)
        {
            string OrigenArchivo = string.Empty;
            string DestinoArchivo = string.Empty;

            try
            {
                for (int i = 0; i < lstPolizasAdj.Count; i++)
                {
                    OrigenArchivo = Path.Combine(Server.MapPath("~/Adjuntos"), lstPolizasAdj[i].NombreArchivoPDF);
                    DestinoArchivo = Path.Combine(Server.MapPath("~/AdjuntosTemp"), lstPolizasAdj[i].NombreArchivoPDF);
                    System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);                    
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void Copiar_a_Adjuntos(List<Poliza_Conciliacion> lstPolizasAdj)
        {
            string OrigenArchivo = string.Empty;
            string DestinoArchivo = string.Empty;

            try
            {
                for (int i = 0; i < lstPolizasAdj.Count; i++)
                {
                    OrigenArchivo = Path.Combine(Server.MapPath("~/AdjuntosTemp"), lstPolizasAdj[i].NombreArchivoPDF); //System.IO.Path.Combine(Origen, fileName);
                    DestinoArchivo = Path.Combine(Server.MapPath("~/Adjuntos"), lstPolizasAdj[i].NombreArchivoPDF);  //System.IO.Path.Combine(Destino, fileName);
                    System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                    //System.IO.File.Delete(OrigenArchivo); MODIFICADO DIA 26 / 03
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private string VerificaMes()
        {
            try
            {
                ListCentroContable = (List<Comun>)Session["CentrosContab"];
                string MesCC = ListCentroContable[DDLCentro_Contable.SelectedIndex].EtiquetaCuatro;
                MesCC = MesCC.PadLeft(2, '0');
                return MesCC;
            }
            catch (Exception ex)
            {
                return "function(VerificaMes) " + ex.Message;
            }
        }

        //private List<Poliza_Detalle> GetListPolizasDet()
        //{
        //    try
        //    {
        //        List<Poliza_Detalle> List = new List<Poliza_Detalle>();
        //        objPolizaDet.Numero_poliza = txtBuscaPoliza.Text;
        //        DateTime Fecha = DateTime.Parse(txtFecha.Text);
        //        int year = Fecha.Year;

        //        objPolizaDet.Ejercicio = year;  //Convert.ToInt32(SesionUsu.Usu_Ejercicio);
        //        objPolizaDet.Cheque_cuenta = ddlCtaCheques.SelectedValue;                
        //        CNConciliacion.Polizas_ConciliacionConsultaGrid(objPolizaDet, ref List);
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        private void CargarGridAdjuntos(List<Poliza_Conciliacion> lstAdjuntos)
        {
            grdDoctos.DataSource = null;
            grdDoctos.DataBind();
            //Int32[] Celdas = new Int32[] { 5, 6 };
            try
            {
                DataTable dt = new DataTable();
                grdDoctos.DataSource = dt;
                grdDoctos.DataSource = lstAdjuntos;
                grdDoctos.DataBind();                

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void CargarGridConcDet(List<Poliza_Conciliacion> lstPolizasDet)
        {
            grdDetalle.DataSource = null;
            grdDetalle.DataBind();
            Int32[] Celdas = new Int32[] { 0,2 };
            try
            {
                DataTable dt = new DataTable();
                grdDetalle.DataSource = lstPolizasDet;
                grdDetalle.DataBind();

                CNComun.HideColumns(grdDetalle, Celdas);
                //CNComun.HideColumns()
                //for (int i = 0; i < grdDetalle.Rows.Count; i++)
                //{
                    
                //    foreach (GridViewRow row in grdDetalle.Rows)
                //    {
                //        //if(row.Cells[2].Text== "1192")
                //        //    row.BackColor = System.Drawing.Color.LightGray;
                //        row.ForeColor = System.Drawing.Color.Black; ;
                //        if (row.Cells[1].Text == "1189")
                //        {
                //            row.BackColor = System.Drawing.Color.LightSlateGray; //SALDO DE BALANZA (ANEXO 1)
                //            row.ForeColor = System.Drawing.Color.White;
                //        }
                //        else if (row.Cells[1].Text == "1191")
                //            row.BackColor = System.Drawing.Color.LightGray; //SALDO SEGÚN EDO DE CTA. (ANEXO 2)
                //        else if (row.Cells[1].Text == "1192")
                //            row.BackColor = System.Drawing.Color.LightBlue; //CARGA UNACH - NO ABONA BANCOS (ANEXO 3)
                //        else if (row.Cells[1].Text == "1190")
                //            row.BackColor = System.Drawing.Color.LightSteelBlue; //ABONA UNACH - NO CARGA BANCOS (ANEXO 4)
                //        else if (row.Cells[1].Text == "1193")
                //            row.BackColor = System.Drawing.Color.Beige; //CARGA BANCOS - NO ABONA UNACH (ANEXO 5)
                //        else if (row.Cells[1].Text == "1194")
                //            row.BackColor = System.Drawing.Color.LightYellow; //ABONA BANCOS - NO CARGA UNACH (ANEXO 6)



                //    }
                //}

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void LimpiarCampos()
        {
            Verificador = string.Empty;
            try
            {
                txtFechaInicial.Text = string.Empty;
                txtFechaFinal.Text = string.Empty;
                txtElaboroNombre.Text = string.Empty;
                txtElaboroPuesto.Text = string.Empty;
                txtVB_Nombre.Text = string.Empty;
                txtVB_Puesto.Text = string.Empty;
                if (SesionUsu.Editar == 0)
                {
                    DDLCentro_Contable.SelectedValue = DDLCentro_Contable1.SelectedValue;
                    DDLCentro_Contable_SelectedIndexChanged(null, null);
                }
                txtFecha.Text = string.Empty;
                ddlTipo.SelectedIndex = 0;
                ddlTipo_SelectedIndexChanged(null, null);
                txtNumPoliza.Text = string.Empty;
                txtImporte.Text = string.Empty;
                txtConcepto.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void LimpiarCamposDet()
        {
            txtFecha.Text=string.Empty;
            txtNumPoliza.Text = string.Empty;
            txtNumCheque.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlTipo.Focus();
        }
        private string GuardarDatos()
        {
            Verificador = string.Empty;
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            try
            {
                objConciliacion.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                objConciliacion.Centro_contable = Convert.ToInt32(DDLCentro_Contable.SelectedValue);
                objConciliacion.Cuenta_contable = Convert.ToInt32(DDLCuenta_Contable.SelectedValue);
                objConciliacion.Fecha_inicial = txtFechaInicial.Text;
                objConciliacion.Fecha_final = txtFechaFinal.Text;
                objConciliacion.Elaboro_nombre = txtElaboroNombre.Text.ToUpper();
                objConciliacion.Elaboro_puesto = txtElaboroPuesto.Text.ToUpper();
                objConciliacion.Vb_nombre = txtVB_Nombre.Text.ToUpper();
                objConciliacion.Vb_puesto = txtVB_Puesto.Text.ToUpper();
                objConciliacion.Nombre_archivo = string.Empty;
                ListPDet = (List<Poliza_Conciliacion>)Session["ConciliacionDet"];
                if (SesionUsu.Editar == 0)
                    CNConciliacion.ConciliacionInsertarEnc(ref objConciliacion, ListPDet, ref Verificador);
                else
                {
                    objConciliacion.IdEnc=Convert.ToInt32(grdConciliacion.SelectedRow.Cells[11].Text);
                    CNConciliacion.ConciliacionEditarEnc(ref objConciliacion, ListPDet, ref Verificador);
                }
                return Verificador;
                

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                return Verificador;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        #endregion
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            LimpiarCampos();
            Session["ConciliacionDet"] = null;
            grdDetalle.DataSource = null;
            grdDetalle.DataBind();
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
            TabContainer2.ActiveTabIndex = 0;
            //TabContainer2.Tabs[1].Enabled = false;
            //TabContainer2.Tabs[1].Enabled = true;

        }
        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Ctas_Bancos", ref DDLCuenta_Contable, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));


                
                DateTime fechaIni = new DateTime();
                DateTime fechaFin = new DateTime();
                string MesCC = VerificaMes();

                if (Convert.ToInt32(MesCC) > 12)
                {
                    fechaIni = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                    fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                    txtFechaInicial.Enabled = false;
                    txtFechaFinal.Enabled = false;
                }

                else
                {

                    DateTime fecha = Convert.ToDateTime("01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio);
                    fechaIni = new DateTime(fecha.Year, fecha.Month, 1);
                    fechaFin = fechaIni.AddMonths(1).AddDays(-1);
                    txtFechaInicial.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
                    txtFechaFinal.Text = fechaFin.ToString("dd/MM/yyyy");  // "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;

                }

                CalendarExtenderFechaIni.StartDate = fechaIni;
                CalendarExtenderFechaIni.EndDate = fechaFin;
                CalendarExtenderFecha1.StartDate = fechaIni;
                CalendarExtenderFecha1.EndDate = fechaFin;

                //txtFechaInicial.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
                //txtFechaFinal.Text = fechaFin.ToString("dd/MM/yyyy");  // "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
                //if (SesionUsu.Editar == 0)
                //{
                //    txtFecha.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
                //    string Validado = ValidaMes(txtFecha);
                //    if (Validado != "Z")
                //    {
                //        Verificador = Validado;
                //        CNComun.VerificaTextoMensajeError(ref Verificador);
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                //    }
                //}



            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string conErrores = GuardarDatos();
            if (conErrores=="0")
            {
                CargarGrid();
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(1, 'Registro guardado correctamente.');", true);                
            }
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }
        protected void grdConciliacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            SesionUsu.Editar = 1;
            LimpiarCampos();
            TabContainer2.ActiveTabIndex = 0;
            try
            {
                //objConciliacion.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                //objConciliacion.Centro_contable = Convert.ToInt32(grdConciliacion.SelectedRow.Cells[0].Text);
                //objConciliacion.Cuenta_contable = Convert.ToInt32(grdConciliacion.SelectedRow.Cells[10].Text);
                //objConciliacion.Fecha_inicial = Convert.ToString(grdConciliacion.SelectedRow.Cells[2].Text);
                //objConciliacion.Fecha_final = Convert.ToString(grdConciliacion.SelectedRow.Cells[3].Text);
                //objConciliacion.Elaboro_nombre = Convert.ToString(grdConciliacion.SelectedRow.Cells[4].Text);
                //objConciliacion.Vb_nombre = Convert.ToString(grdConciliacion.SelectedRow.Cells[5].Text);
                //Poliza_Conciliacion objConciliacionResp = new Poliza_Conciliacion();
                objConciliacion.IdEnc = Convert.ToInt32(grdConciliacion.SelectedRow.Cells[11].Text);
                CNConciliacion.ConsultarConciliacionEncSel(ref objConciliacion, ref Verificador);
                if(Verificador=="0")
                {
                    DDLCentro_Contable.SelectedValue = Convert.ToString(objConciliacion.Centro_contable);
                    DDLCentro_Contable_SelectedIndexChanged(null, null);
                    txtFechaInicial.Text = Convert.ToString(objConciliacion.Fecha_inicial);
                    txtFechaFinal.Text = Convert.ToString(objConciliacion.Fecha_final);

                    DDLCuenta_Contable.SelectedValue = Convert.ToString(objConciliacion.Cuenta_contable);
                    txtElaboroNombre.Text = objConciliacion.Elaboro_nombre;
                    txtVB_Nombre.Text = objConciliacion.Vb_nombre;
                    txtElaboroPuesto.Text = objConciliacion.Elaboro_puesto;
                    txtVB_Puesto.Text = objConciliacion.Vb_puesto;
                    ddlTipo.SelectedIndex = 0;
                    ddlTipo_SelectedIndexChanged(null, null);
                    objConciliacion.IdEnc = Convert.ToInt32(grdConciliacion.SelectedRow.Cells[11].Text);
                    List<Poliza_Conciliacion> lstConciliacionDet = new List<Poliza_Conciliacion>();
                    CNConciliacion.ConciliacionDetConsultaGrid(objConciliacion, ref lstConciliacionDet);
                    if(lstConciliacionDet.Count>0)
                        Session["ConciliacionDet"] = lstConciliacionDet;
                    else
                        Session["ConciliacionDet"] = null;

                    CargarGridConcDet(lstConciliacionDet);
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        protected void grdConciliacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                int fila = e.RowIndex;
                //objConciliacion.Id = Convert.ToInt32(grdConciliacion.Rows[fila].Cells[0].Text);

                objConciliacion.IdEnc = Convert.ToInt32(grdConciliacion.Rows[fila].Cells[11].Text);
                CNConciliacion.ConciliacionEliminar(objConciliacion, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                {                    
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        
        protected void imgbtnBuscar1_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        //protected void grdPolizas_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();

        //    if (Session["PolizasDet"] != null)
        //        ListPDet = (List<Poliza_Detalle>)Session["PolizasDet"];

        //    objPolizaDet.Centro_contable = DDLCentro_Contable.SelectedValue;
        //    objPolizaDet.Cheque_cuenta = ddlCtaCheques.SelectedValue;
        //    objPolizaDet.Tipo = ddlTipo.SelectedValue;
        //    objPolizaDet.Numero_poliza = grdPolizas.SelectedRow.Cells[1].Text;
        //    objPolizaDet.Fecha = grdPolizas.SelectedRow.Cells[2].Text;
        //    objPolizaDet.Tot_Abono = Convert.ToDouble(grdPolizas.SelectedRow.Cells[3].Text);
        //    objPolizaDet.IdPoliza = Convert.ToInt32(grdPolizas.SelectedRow.Cells[5].Text);
        //    ListPDet.Add(objPolizaDet);

        //    Session["PolizasDet"] = ListPDet;
        //    CargarGridPolizasAgregadas(ListPDet);
        //}

        protected void grdPolizasAgregadas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        //protected void grdPolizasAgregadas_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    grdPolizasAgregadas.EditIndex = e.NewEditIndex;
        //    List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
        //    ListPDet = (List<Poliza_Detalle>)Session["PolizasDet"];
        //    //Session["PolizasDet"] = ListPDet;
        //    CargarGridPolizasAgregadas(ListPDet);
        //}

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConcepto.Text = string.Empty;
            lblConcepto.Text = "Concepto:";
            trowCheque.Visible = false;
            if (ListTipo[ddlTipo.SelectedIndex].EtiquetaTres == "ANEXO_3")
            {
                trowFecha.Visible = true;
                trowPoliza.Visible = true;
                //lblNumPoliza.Text = "# de Póliza";
                lblObservaciones.Visible = true;
                txtDescripcion.Visible = true;

            }
            else if (ListTipo[ddlTipo.SelectedIndex].EtiquetaTres == "ANEXO_4")
            {
                trowFecha.Visible = true;
                trowPoliza.Visible = true;
                trowCheque.Visible = true;
                //lblNumPoliza.Text = "# de Cheque";
                lblObservaciones.Visible = true;
                txtDescripcion.Visible = true;
                lblConcepto.Text = "Beneficiario:";

            }
            else if (ListTipo[ddlTipo.SelectedIndex].EtiquetaTres == "ANEXO_1" || ListTipo[ddlTipo.SelectedIndex].EtiquetaTres == "ANEXO_2")
            {
                trowPoliza.Visible = false;
                trowFecha.Visible = false;
                lblObservaciones.Visible = false;
                txtDescripcion.Visible = false;
                txtConcepto.Text = ddlTipo.SelectedItem.Text+" AL "+txtFechaFinal.Text;

            }
            else
            {
                trowFecha.Visible = true;
                trowPoliza.Visible = false;
                //trowPolizaPnl.Visible = false;
                lblObservaciones.Visible = true;
                txtDescripcion.Visible = true;

            }
        }        
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //modalPoliza.Hide();
        }
        protected void bttnAgregarPoliza_Click(object sender, EventArgs e)
        {
            //modalPoliza.Show();
        }
        protected void btnGuardar_Continuar_Click(object sender, EventArgs e)
        {
            string conErrores = GuardarDatos();
            if (conErrores == "0")
            {
                txtFecha.Text = string.Empty;
                //txtFecha_Final.Text = string.Empty;
                txtNumPoliza.Text = string.Empty;
                txtImporte.Text = string.Empty;
                //hddnIdPolizaDet.Value = "0";
                MultiView1.ActiveViewIndex = 0;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(1, 'Registro guardado correctamente.');", true);
            }
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        protected void bttnAgregar_Click(object sender, EventArgs e)
        {
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            try
            {
                //if (ddlCtaCheques.SelectedValue=="La opción no contiene datos")
                //    objConciliacion.Cuenta_Cheques = "0";
                //else
                //    objConciliacion.Cuenta_Cheques = ddlCtaCheques.SelectedValue;

                objConciliacion.Fecha = txtFecha.Text;
                if(txtNumPoliza.Text==string.Empty)
                    objConciliacion.Numero_Poliza = "0";
                else
                    objConciliacion.Numero_Poliza = txtNumPoliza.Text;

                if (txtNumCheque.Text == string.Empty)
                    objConciliacion.Numero_Cheque = "0";
                else
                    objConciliacion.Numero_Cheque = txtNumCheque.Text;

                objConciliacion.Importe = Convert.ToDouble(txtImporte.Text);
                objConciliacion.Concepto = txtConcepto.Text.ToUpper();
                objConciliacion.Observaciones = txtDescripcion.Text.ToUpper();
                objConciliacion.Tipo = ddlTipo.SelectedValue;
                objConciliacion.DescTipo = ddlTipo.SelectedItem.Text;
                objConciliacion.CveTipo = ListTipo[ddlTipo.SelectedIndex].EtiquetaTres;

                if (Session["ConciliacionDet"] != null)
                    ListPDet = (List<Poliza_Conciliacion>)Session["ConciliacionDet"];


                ListPDet.Add(objConciliacion);
                ListPDet = ListPDet.OrderBy(x => x.CveTipo).ToList();
                Session["ConciliacionDet"] = ListPDet;
                CargarGridConcDet(ListPDet);
                LimpiarCamposDet();
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        protected void grdDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            ListPDet = (List<Poliza_Conciliacion>)Session["ConciliacionDet"];
            try
            {
                int fila = e.RowIndex;
                int pagina = grdDetalle.PageSize * grdDetalle.PageIndex;
                fila = pagina + fila;
                //ListPDet = ListPDet.OrderBy(x => x.CveTipo).ToList();
                ListPDet.RemoveAt(fila);                            
                Session["ConciliacionDet"] = ListPDet;
                CargarGridConcDet(ListPDet);
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

       
      

        protected void grdDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            ListPDet = (List<Poliza_Conciliacion>)Session["ConciliacionDet"];

            int fila = e.RowIndex;
            int pagina = grdDetalle.PageSize * grdDetalle.PageIndex;
            fila = pagina + fila;
            GridViewRow row = grdDetalle.Rows[e.RowIndex];

            

            TextBox txt = (TextBox)(row.Cells[6].FindControl("txtImporteAgr"));



            ListPDet[fila].Importe = Convert.ToDouble(txt.Text);  //Convert.ToDouble(((TextBox)(row.Cells[6].Controls[0])).Text);
            ListPDet[fila].Concepto = Convert.ToString(((TextBox)(row.Cells[7].Controls[0])).Text);

            grdDetalle.EditIndex = -1;
            Session["ConciliacionDet"] = ListPDet;
            CargarGridConcDet(ListPDet);
        }

        protected void grdDetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdDetalle.EditIndex = e.NewEditIndex;
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            ListPDet = (List<Poliza_Conciliacion>)Session["ConciliacionDet"];
            CargarGridConcDet(ListPDet);
        }

        protected void TabContainer2_ActiveTabChanged(object sender, EventArgs e)
        {
            TabPanel activeTab = TabContainer2.ActiveTab;
            // use the activeTab
            if (activeTab == TabPanel100)
            {
                if (txtFechaInicial.Text == string.Empty && txtFechaFinal.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, 'Debe ingresar el periodo inicial y final para activar esta pestaña.');", true);
                    TabContainer2.ActiveTabIndex = 0;
                }
            }

            
           
        }

       

        protected void linkReporteEnc_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdConciliacion.SelectedIndex = row.RowIndex;
            int IdConciliacion =Convert.ToInt32(grdConciliacion.SelectedRow.Cells[11].Text);
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP_Conciliacion&id=" + grdConciliacion.SelectedRow.Cells[11].Text;
            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void linkReporteDet_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdConciliacion.SelectedIndex = row.RowIndex;
            string centro_contable = grdConciliacion.SelectedRow.Cells[0].Text;
            string cta_contable = grdConciliacion.SelectedRow.Cells[9].Text;
            string elaboro_nombre = grdConciliacion.SelectedRow.Cells[4].Text;
            string vb_nombre = grdConciliacion.SelectedRow.Cells[5].Text;
            string fecha_final = grdConciliacion.SelectedRow.Cells[3].Text;
            string fecha_inicial = grdConciliacion.SelectedRow.Cells[2].Text;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP_Conciliacion&id=" + grdConciliacion.SelectedRow.Cells[11].Text;
            //string ruta = "//sysweb.unach.mx/sysreportes/home/ReporteConciliacionAnexos?p1=" + centro_contable + "&p2=" + cta_contable + "&p3=" + SesionUsu.Usu_Ejercicio + "&p4=" + elaboro_nombre + "&p5=" + fecha_final + "&p6=" + fecha_inicial + "&p7=" + vb_nombre;
            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void txtFechaFinal_TextChanged(object sender, EventArgs e)
        {
            //TabContainer2.Tabs[1].Enabled = true;
            ddlTipo_SelectedIndexChanged(null, null);
        }

        protected void grdDetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<Poliza_Conciliacion> ListPDet = new List<Poliza_Conciliacion>();
            ListPDet = (List<Poliza_Conciliacion>)Session["ConciliacionDet"];
            grdDetalle.EditIndex = -1;
            CargarGridConcDet(ListPDet);
        }

        
        protected void bttnAdjuntar_Click(object sender, EventArgs e)
        {
            modalAdj.Show();
            List<Poliza_Conciliacion> ListAdj = new List<Poliza_Conciliacion>();
            string NombreArchivo = string.Empty;


            if (FileUpload1.HasFile)
            {
                try
                {
                    string Nombre = "EDO_CTA_" + SesionUsu.Usu_Ejercicio + "-" + grdConciliacion.SelectedRow.Cells[0].Text + "-" + FileUpload1.FileName.ToUpper();
                    string Ruta = Path.Combine(Server.MapPath("~/AdjuntosTemp"), Nombre);
                    FileUpload1.SaveAs(Ruta);
                    //NombreArchivo= FileUpload1.FileName.ToUpper();
                    objAdjunto.NombreArchivoPDF = Nombre;
                    objAdjunto.Ruta_PDF = "~/AdjuntosTemp/" + Nombre;

                    if (Session["DoctosAdj"] != null)
                        ListAdj = (List<Poliza_Conciliacion>)Session["DoctosAdj"];


                    int count = (from dato in ListAdj
                                 where dato.NombreArchivoPDF == Nombre
                                 select dato).Count();

                    if (count == 0)
                    {
                        ListAdj.Add(objAdjunto);
                        Session["DoctosAdj"] = ListAdj;
                        CargarGridAdjuntos(ListAdj);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, 'Ya existe un archivo con ese nombre, verificar.');", true);
                }
                catch (Exception ex)
                {
                    Verificador = ex.Message;
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
        }

        protected void btnCancelarAdj_Click(object sender, EventArgs e)
        {
            modalAdj.Hide();
        }

        protected void btnGuardarAdj_Click(object sender, EventArgs e)
        {
            modalAdj.Show();
            Verificador = string.Empty;

            try
            {
                List<Poliza_Conciliacion> ListAdj = new List<Poliza_Conciliacion>();
                objConciliacion.IdEnc = Convert.ToInt32(grdConciliacion.SelectedRow.Cells[11].Text);
                ListAdj = (List<Poliza_Conciliacion>)Session["DoctosAdj"];
                CNConciliacion.PolizaAdjInsertar(objConciliacion, ListAdj, ref Verificador);
                if (Verificador == "0")
                {
                    Copiar_a_Adjuntos(ListAdj);
                    modalAdj.Hide();
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(1, 'Doctos. guardados correctamente.');", true);
                    
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                }


            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void grdDoctos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Poliza_Conciliacion> ListAdj = new List<Poliza_Conciliacion>();
            ListAdj = (List<Poliza_Conciliacion>)Session["DoctosAdj"];
            try
            {
                int fila = e.RowIndex;
                int pagina = grdDoctos.PageSize * grdDoctos.PageIndex;
                fila = pagina + fila;
                ListAdj.RemoveAt(fila);
                Session["DoctosAdj"] = ListAdj;
                CargarGridAdjuntos(ListAdj);
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

       
        protected void linkBttnAdj_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            List<Poliza_Conciliacion> ListAdj = new List<Poliza_Conciliacion>();
            Verificador = string.Empty;
            grdConciliacion.SelectedIndex = row.RowIndex;
            Session["DoctosAdj"] = null;
            grdDoctos.DataSource = null;
            grdDoctos.DataBind();
            try
            {
                objConciliacion.IdEnc = Convert.ToInt32(grdConciliacion.SelectedRow.Cells[11].Text);
                CNConciliacion.ConciliacionAdjConsultaGrid(objConciliacion, ref ListAdj);
                Session["DoctosAdj"] = ListAdj;
                CargarGridAdjuntos(ListAdj);
                //Copiar_a_AdjuntosTemp(ListAdj);  MODIFICADO DIA 26/03


                modalAdj.Show();
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }

        }

        protected void linkBttnEliminarAdj_Click(object sender, EventArgs e)
        {

        }

        protected void grdConciliacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdConciliacion.PageIndex = 0;
            grdConciliacion.PageIndex = e.NewPageIndex;
            CargarGrid();
        }






        //protected void grdPolizasAgregadas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
        //    ListPDet = (List<Poliza_Detalle>)Session["PolizasDet"];

        //    int fila = e.RowIndex;
        //    int pagina = grdPolizasAgregadas.PageSize * grdPolizasAgregadas.PageIndex;
        //    fila = pagina + fila;
        //    GridViewRow row = grdPolizasAgregadas.Rows[e.RowIndex];
        //    TextBox txtImporte = (TextBox)(row.Cells[5].FindControl("txtImporte"));
        //    ListPDet[fila].Tot_Abono =Convert.ToDouble(txtImporte.Text);
        //    grdPolizasAgregadas.EditIndex = -1;
        //    Session["PolizasDet"] = ListPDet;
        //    CargarGridPolizasAgregadas(ListPDet);

        //}

        //protected void grdPolizasAgregadas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
        //    ListPDet = (List<Poliza_Detalle>)Session["PolizasDet"];
        //    grdPolizasAgregadas.EditIndex = -1;
        //    CargarGridPolizasAgregadas(ListPDet);
        //}
    }
}