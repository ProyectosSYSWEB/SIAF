using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
using System.Xml;
using System.IO;

namespace SAF.Form
{
    public partial class frmPolizas : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string Verificador2 = string.Empty;
        string MsjError = string.Empty;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Poliza CNPoliza = new CN_Poliza();
        CN_Poliza_Det CNPolizaDet = new CN_Poliza_Det();
        CN_Poliza_CFDI CNPolizaCFDI = new CN_Poliza_CFDI();
        CN_Usuario CNUsuario = new CN_Usuario();
        Comun ObjCC = new Comun();
        Poliza ObjPoliza = new Poliza();
        Poliza_Detalle ObjPolizaDet = new Poliza_Detalle();
        Poliza_CFDI ObjPolizaCFDI = new Poliza_CFDI();
        List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
        List<cuentas_contables> ListCC = new List<cuentas_contables>();
        List<Comun> ListCuentas = new List<Comun>();
        private static List<Comun> ListCentroContable = new List<Comun>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];



            if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null))
            {
                if ((Request.Params["__EVENTTARGET"] == this.txtSearch.UniqueID) /*+&& (Request.Params["__EVENTARGUMENT"] == "actualizar_label")*/)
                {
                    this.txtCargo.Focus();
                }
                else if ((Request.Params["__EVENTTARGET"] == this.bttnAgregar.ClientID))
                {
                    Request.Params.Clear();
                }
                else if ((Request.Params["__EVENTTARGET"] == this.txtBuscar.UniqueID))
                {
                    this.imgbtnBuscar.Focus();
                }
            }

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
            TabContainer1.ActiveTabIndex = 0;
            ddlFecha_Ini.SelectedValue = "01"; // System.DateTime.Now.ToString("MM");
            ddlFecha_Fin.SelectedValue = System.DateTime.Now.ToString("MM");
            txtFecha.Text = string.Empty;
            Cargarcombos();
            //CargarGrid(0);
        }


        private void Cargarcombos()
        {
            //lblError.Text = string.Empty;
            Session["CentrosContab"] = null;
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ref ListCentroContable);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Beneficiario", ref ddlTipo_Beneficiario);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Tipo_Gasto", ref ddlTipo_Gasto);
                Session["CentrosContab"] = ListCentroContable;
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }
        private void CargarGrid(int indexCopia)
        {
            //lblError.Text = string.Empty;
            grvPolizas.DataSource = null;
            grvPolizas.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvPolizas.DataSource = dt;
                grvPolizas.DataSource = GetList();
                grvPolizas.DataBind();

                if (grvPolizas.Rows.Count > 0)
                {
                    OcultaColumna(grvPolizas, Celdas, indexCopia);
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        public void OcultaColumna(GridView grdView, Int32[] Columnas, int indexCopia)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                    if (indexCopia != 0)
                    {
                        if (row.Cells[0].Text == Convert.ToString(indexCopia))
                        {
                            grdView.SelectedIndex = row.RowIndex;
                        }
                    }

                }
            }
        }

        private void CargarGridDetalle(List<Poliza_Detalle> ListPDet)
        {
            //lblError.Text = string.Empty;
            try
            {
                grvPolizas_Detalle.DataSource = ListPDet;
                grvPolizas_Detalle.DataBind();
                Sumatoria(grvPolizas_Detalle);
                grvPolizas_Detalle.DataBind();
                Celdas = new Int32[] { 0, 3, 4 };
                if (grvPolizas_Detalle.Rows.Count > 0)
                    CNComun.HideColumns(grvPolizas_Detalle, Celdas);
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        private void CargarGridPolizaCFDI(List<Poliza_CFDI> ListPolizaCFDI)
        {
            grvPolizaCFDI.DataSource = null;
            grvPolizaCFDI.DataBind();
            Int32[] Celdas = new Int32[] { 11, 12 };
            try
            {
                double TotalPagos;
                DataTable dt = new DataTable();
                grvPolizaCFDI.DataSource = ListPolizaCFDI;
                grvPolizaCFDI.DataBind();
                if (ListPolizaCFDI.Count() > 0)
                {
                    TotalPagos = ListPolizaCFDI.Sum(item => Convert.ToDouble(item.CFDI_Total));

                    Label lblTot = (Label)grvPolizaCFDI.FooterRow.FindControl("lblGranTotal");
                    lblTot.Text = TotalPagos.ToString("C");
                    CNComun.HideColumns(grvPolizaCFDI, Celdas);

                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        private void LimpiaGrid()
        {
            grvPolizas.DataSource = null;
            grvPolizas.DataBind();
        }
        private List<Poliza> GetList()
        {
            try
            {
                List<Poliza> List = new List<Poliza>();
                ObjPoliza.Centro_contable = DDLCentro_Contable.SelectedValue;
                ObjPoliza.Tipo = ddlTipo2.SelectedValue;
                ObjPoliza.Status = ddlStatus2.SelectedValue;
                ObjPoliza.Tipo_captura = ddlTipo_CapturaInicio.SelectedValue;
                string FechaInicial = "01/" + ddlFecha_Ini.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
                int DiaFinal = System.DateTime.DaysInMonth(Convert.ToInt32(SesionUsu.Usu_Ejercicio), Convert.ToInt32(ddlFecha_Fin.SelectedValue));
                string FechaFinal = DiaFinal + "/" + ddlFecha_Fin.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
                CNPoliza.PolizaConsultaGrid(ref ObjPoliza, FechaInicial, FechaFinal, txtBuscar.Text.ToUpper(), SesionUsu.Usu_TipoUsu, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Sumatoria(GridView grdView)
        {
            //grdView.AllowPaging = false;
            lblTotal_Cargos.Text = string.Empty;
            lblTotal_Abonos.Text = string.Empty;
            //double cargos = 0;
            //double abonos = 0;
            decimal cargos = 0;
            decimal abonos = 0;
            cargos = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[3].Text));
            abonos = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Text));
            lblTotal_Cargos.Text = Convert.ToString(cargos); // String.Format("{0:c}", Convert.ToDouble(cargos));
            lblTotal_Abonos.Text = Convert.ToString(abonos); //String.Format("{0:c}", Convert.ToDouble(abonos));
            lblFormatoTotal_Cargos.Text = String.Format("{0:C}", Convert.ToDouble(cargos));
            lblFormatoTotal_Abonos.Text = String.Format("{0:C}", Convert.ToDouble(abonos));
            //grdView.AllowPaging = true;

        }

        private void InicializaCamposGuardar()
        {
            //pnlFechas.Visible = true;
            filaFechasBusqueda.Visible = true;
            filaFechas.Visible = false;
            //pnlFechas0.Visible = false;
            filaBusqueda.Visible = true;
            //lblBuscar.Visible = true;
            //txtBuscar.Visible = true;
            //imgbtnBuscar.Visible = true;
            btnNuevo.Visible = true;
            DDLCentro_Contable.Enabled = true;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            //string Ini = fecha.ToString("MM");
            ddlFecha_Ini.SelectedValue = fecha.ToString("MM");
            ddlFecha_Fin.SelectedValue = fecha.ToString("MM");
        }
        private void VerificaFechas(TextBox txt)
        {
            //lblError.Text = string.Empty;
            try
            {
                DateTime fecha = Convert.ToDateTime(txt.Text);
                string Anio = fecha.ToString("yyyy");
                if (Anio != SesionUsu.Usu_Ejercicio)
                {
                    //txt.Text = string.Empty;
                    //lblMsj.Text = "Ejercicio incorrecto";
                    string MesCC = VerificaMes();
                    txt.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = "function(VerificaFechas) " + ex.Message;
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
        private string ValidaMes(TextBox txt)
        {
            //lblError.Text = string.Empty;
            int band = 0;
            int Mes = 0;
            int NumMesCC = 0;
            try
            {
                string MesCC = VerificaMes();
                band = band + 1;
                DateTime fecha = Convert.ToDateTime(txt.Text);
                string MesFecha = fecha.ToString("MM");
                band = band + 1;
                Mes = Convert.ToInt32(MesFecha);
                band = band + 1;
                NumMesCC = Convert.ToInt32(MesCC);
                band = band + 1;
                if (Mes >= NumMesCC)
                    return "Z";
                else
                    return "Unicamente se puede capturar hasta el mes " + MesCC + ", verificar";

            }
            catch (Exception ex)
            {
                //return lblError.Text = band + "-" + Mes + "-" + NumMesCC + "function(ValidaMes) " + ex.Message;
                return band + "-" + Mes + "-" + NumMesCC + "function(ValidaMes) " + ex.Message;

            }

        }
        private void ValidateNumPoliza(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Contains("4999"));
        }
        private void Copiar_a_AdjuntosTemp
            (List<Poliza_CFDI> lstPolizasCFDI)
        {
            string OrigenArchivo = string.Empty;
            string DestinoArchivo = string.Empty;
            string OrigenArchivo2 = string.Empty;
            string DestinoArchivo2 = string.Empty;

            try
            {
                for (int i = 0; i < lstPolizasCFDI.Count; i++)
                {
                    OrigenArchivo = Path.Combine(Server.MapPath("~/Adjuntos"), lstPolizasCFDI[0].NombreArchivoXML);
                    DestinoArchivo = Path.Combine(Server.MapPath("~/AdjuntosTemp"), lstPolizasCFDI[0].NombreArchivoXML);
                    System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);


                    if (lstPolizasCFDI[0].NombreArchivoPDF != string.Empty)
                    {
                        OrigenArchivo2 = Path.Combine(Server.MapPath("~/Adjuntos"), lstPolizasCFDI[0].NombreArchivoPDF);
                        DestinoArchivo2 = Path.Combine(Server.MapPath("~/AdjuntosTemp"), lstPolizasCFDI[0].NombreArchivoPDF);
                        System.IO.File.Copy(OrigenArchivo2, DestinoArchivo2, true);
                    }
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void Copiar_a_Adjuntos(List<Poliza_CFDI> lstPolizasCFDI)
        {
            string OrigenArchivo = string.Empty;
            string DestinoArchivo = string.Empty;
            string OrigenArchivo2 = string.Empty;
            string DestinoArchivo2 = string.Empty;

            try
            {
                for (int i = 0; i < lstPolizasCFDI.Count; i++)
                {
                    OrigenArchivo = Path.Combine(Server.MapPath("~/AdjuntosTemp"), lstPolizasCFDI[0].NombreArchivoXML); //System.IO.Path.Combine(Origen, fileName);
                    DestinoArchivo = Path.Combine(Server.MapPath("~/Adjuntos"), lstPolizasCFDI[0].NombreArchivoXML);  //System.IO.Path.Combine(Destino, fileName);
                    System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                    //System.IO.File.Delete(OrigenArchivo); //MODIFICADO DIA 26/03

                    OrigenArchivo2 = Path.Combine(Server.MapPath("~/AdjuntosTemp"), lstPolizasCFDI[0].NombreArchivoPDF); //System.IO.Path.Combine(Origen, fileName);
                    DestinoArchivo2 = Path.Combine(Server.MapPath("~/Adjuntos"), lstPolizasCFDI[0].NombreArchivoPDF);  //System.IO.Path.Combine(Destino, fileName);
                    System.IO.File.Copy(OrigenArchivo2, DestinoArchivo2, true);
                    //System.IO.File.Delete(OrigenArchivo2); //MODIFICADO DIA 26/03

                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void Guardar()
        {
            string Validado = ValidaMes(txtFecha);
            string Verificador = string.Empty;
            string Verificador2 = string.Empty;

            try
            {

                if (Validado == "Z")
                {
                    ObjPoliza.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                    ObjPoliza.Numero_poliza = txtNumero_Poliza.Text;
                    ObjPoliza.Centro_contable = DDLCentro_Contable.SelectedValue;
                    ObjPoliza.Tipo = ddlTipo0.SelectedValue;
                    ObjPoliza.Fecha = txtFecha.Text;
                    ObjPoliza.Status = (Math.Abs(Convert.ToDouble(lblTotal_Cargos.Text)) != Math.Abs(Convert.ToDouble(lblTotal_Abonos.Text))) ? "N" : "A"; //ddlStatus0.SelectedValue;
                    ObjPoliza.Tipo_captura = ddlTipo_Captura.SelectedValue;
                    ObjPoliza.Alta_usuario = SesionUsu.Usu_Nombre;
                    ObjPoliza.Modificacion_usuario = SesionUsu.Usu_Nombre;
                    ObjPoliza.Cheque_cuenta = "00000"; //ddlCheque_Cuenta.SelectedValue;
                    ObjPoliza.Cheque_numero = txtCheque_Numero.Text;
                    ObjPoliza.Cheque_importe = (txtCheque_Importe.Text.Length > 0) ? Convert.ToDouble(txtCheque_Importe.Text) : Convert.ToDouble("0");
                    ObjPoliza.Cedula_numero = txtCedula_Numero.Text;
                    ObjPoliza.Beneficiario = txtBeneficiario.Text;
                    ObjPoliza.CFDI = chkIncluyeCFDI.Checked == true ? "S" : "N";
                    if (DDLCentro_Contable.SelectedValue == "72103")
                    {
                        if (ddlTipo0.SelectedValue != "I")
                            ObjPoliza.Concepto = ddlprograma.SelectedValue + "»" + txtConcepto.Text;
                        else
                            ObjPoliza.Concepto = txtConcepto.Text;
                    }
                    else
                        ObjPoliza.Concepto = txtConcepto.Text;




                    if (SesionUsu.Editar == 0)
                    {

                        CNPoliza.PolizaInsertar(ref ObjPoliza, ref Verificador);
                        if (Verificador == "0")
                        {
                            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
                            CNPolizaDet.PolizaDetInsertar(ListPDet, ObjPoliza.IdPoliza, /*grvPolizas_Detalle,*/ ref Verificador);
                            if (Verificador == "0")
                            {
                                    SesionUsu.Editar = -1;
                                    MultiView1.ActiveViewIndex = 0;
                                    InicializaCamposGuardar();
                                    CargarGrid(0);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(1, 'Los datos han sido agregados correctamente.');", true);
                            }
                            else
                            {
                                CNComun.VerificaTextoMensajeError(ref Verificador);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                                //lblError.Text = Verificador;
                            }
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerPoliza('RP-005'," + SesionUsu.Usu_Ejercicio + ", '" + grvPolizas.SelectedRow.Cells[0].Text + "');", true);

                            //lblError.Text = Verificador;

                        }
                    }




                    else if (SesionUsu.Editar == 1)
                    {
                        ObjPoliza.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                        CNPoliza.PolizaEditar(ref ObjPoliza, ref Verificador);
                        if (Verificador == "0")
                        {
                            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
                            CNPolizaDet.PolizaDetInsertar(ListPDet, ObjPoliza.IdPoliza, /*grvPolizas_Detalle,*/ ref Verificador);
                            if (Verificador == "0")
                            {
                                SesionUsu.Editar = -1;
                                MultiView1.ActiveViewIndex = 0;
                                InicializaCamposGuardar();
                                CargarGrid(0);                                
                                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true);
                            }
                            else
                            {
                                CNComun.VerificaTextoMensajeError(ref Verificador);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                            }
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                            //lblError.Text = Verificador;
                        }
                    }
                }
                else                
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Validado + "');", true);
                
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                //lblError.Text = ex.Message;
            }

        }
        #endregion

        #region <Botones y Eventos>
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (SesionUsu.Editar == -1)
            {
                CargarGrid(0);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //lblBuscar.Visible = true;
            txtBuscar.Visible = true;
            imgbtnBuscar.Visible = true;
            btnNuevo.Visible = true;            
            filaFechas.Visible = false;
            //pnlFechas.Visible = true;
            filaFechasBusqueda.Visible = true;
            filaBusqueda.Visible = true;
            lblTotal_Cargos.Text = string.Empty;
            lblTotal_Abonos.Text = string.Empty;
            lblFormatoTotal_Cargos.Text = string.Empty;
            lblFormatoTotal_Abonos.Text = string.Empty;
            DDLCentro_Contable.Enabled = true;
            SesionUsu.Editar = -1;
            MultiView1.ActiveViewIndex = 0;
            CargarGrid(0);
        }
        protected void grvPolizas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPolizas.PageIndex = 0;
            grvPolizas.PageIndex = e.NewPageIndex;
            CargarGrid(0);
        }

        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_Programa();
            //lblError.Text = string.Empty;
            if (SesionUsu.Editar == 0 || SesionUsu.Editar == 1)
            {
                Session["Cuentas"] = null;
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cheque_Cuenta", ref ddlCheque_Cuenta, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, DDLCentro_Contable.SelectedValue);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_List_Cuentas_Contables_Id", ref ddlCuentas_Contables, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue), ref ListCuentas);
                Session["Cuentas"] = ListCuentas;
                DateTime fechaIni =new DateTime();
                DateTime fechaFin = new DateTime();
                string MesCC = VerificaMes();
                if (Convert.ToInt32(MesCC) > 12)
                {
                    fechaIni = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                    fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                }
                else
                {

                    DateTime fecha = Convert.ToDateTime("01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio);
                    fechaIni = new DateTime(fecha.Year, fecha.Month, 1); // iniciar el primer día de mes
                                                                         // Establecer esta variable al Calendar
                    fechaFin = fechaIni.AddMonths(1).AddDays(-1); // este es el último día del mes en curso. 
                }                
                
                CalendarExtenderFecha.StartDate = fechaIni;
                CalendarExtenderFecha.EndDate = fechaFin;

                if (SesionUsu.Editar == 0)
                {
                    txtFecha.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
                    string Validado = ValidaMes(txtFecha);
                    if (Validado != "Z")
                    {
                        Verificador = Validado;
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                    }
                }
                //}
            }
            else
            {
                LimpiaGrid();
            }
        }
        protected void grvPolizas_Detalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grvPolizas_Detalle.PageSize * grvPolizas_Detalle.PageIndex;
                fila = pagina + fila;
                List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
                ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
                ListPDet.RemoveAt(fila);
                Session["PolizaDet"] = ListPDet;
                CargarGridDetalle(ListPDet);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void grvPolizas_Detalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPolizas_Detalle.PageIndex = 0;
            grvPolizas_Detalle.PageIndex = e.NewPageIndex;
            //CargarGridDet(Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text));                    
            List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
            Session["PolizaDet"] = ListPDet;
            grvPolizas_Detalle.DataSource = ListPDet;
            grvPolizas_Detalle.DataBind();
        }
        protected void grvPolizas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblError.Text = string.Empty;
            DDLCentro_Contable.Enabled = false;
            LimpiaCampos(); // btnNuevo_Click(null, null);
            try
            {
                ObjPoliza.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);   // Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());
                CNPoliza.ConsultarPolizaSel(ref ObjPoliza, ref Verificador);
                if (Verificador == "0")
                {
                    SesionUsu.Editar = 1;
                    ddlTipo0.SelectedValue = ObjPoliza.Tipo;
                    ddlTipo0_SelectedIndexChanged(null, null);
                    ddlTipo_Captura.SelectedValue = ObjPoliza.Tipo_captura;
                    ddlStatus0.SelectedValue = ObjPoliza.Status;
                    txtNumero_Poliza.Text = ObjPoliza.Numero_poliza;
                    txtConcepto.Text = ObjPoliza.Concepto;
                    txtFecha.Text = ObjPoliza.Fecha;
                    DDLCentro_Contable.SelectedValue = ObjPoliza.Centro_contable;
                    DDLCentro_Contable_SelectedIndexChanged(null, null);
                    ddlCheque_Cuenta.SelectedValue = ObjPoliza.Cheque_cuenta;
                    txtCheque_Numero.Text = ObjPoliza.Cheque_numero;
                    txtCheque_Importe.Text = Convert.ToString(ObjPoliza.Cheque_importe);
                    txtCedula_Numero.Text = ObjPoliza.Cedula_numero;
                    txtBeneficiario.Text = ObjPoliza.Beneficiario;
                    chkIncluyeCFDI.Checked = ObjPoliza.CFDI == "S" ? true : false;
                    //txtFecha.Text = ObjPoliza.Fecha;
                    ObjPolizaDet.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                    List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
                    CNPolizaDet.PolizaDetConsultaGrid(ref ObjPolizaDet, ref ListPDet);
                    DataTable dt = new DataTable();
                    Session["PolizaDet"] = ListPDet;
                    CargarGridDetalle(ListPDet);



                    ValidatorNumPoliza.ValidationGroup = string.Empty;
                    //SesionUsu.Editar = 1;
                }
                else
                {
                    //lblError.Text = Verificador;                    
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                }

                if (DDLCentro_Contable.SelectedValue == "72103")
                {
                    if (ddlTipo0.SelectedValue != "I")
                    {
                        string[] resultado;
                        char[] delimiter = { '»' };
                        resultado = txtConcepto.Text.Split(delimiter);
                        if (resultado.Length > 1)
                        {
                            txtConcepto.Text = resultado[1];
                            ddlprograma.SelectedValue = resultado[0];
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }




        protected void grvPolizas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //lblError.Text = string.Empty;
            try
            {
                int fila = e.RowIndex;
                ObjPoliza.IdPoliza = Convert.ToInt32(grvPolizas.Rows[fila].Cells[0].Text);
                CNPoliza.PolizaEliminar(ObjPoliza, ref Verificador);
                if (Verificador == "0")
                    CargarGrid(0);
                else
                {
                    //lblError.Text = Verificador;                    
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        protected void imgBttnPdf(object sender, ImageClickEventArgs e)
        {
            string FechaInicial = "01/" + ddlFecha_Ini.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
            int DiaFinal = System.DateTime.DaysInMonth(Convert.ToInt32(SesionUsu.Usu_Ejercicio), Convert.ToInt32(ddlFecha_Fin.SelectedValue));
            string FechaFinal = DiaFinal + "/" + ddlFecha_Fin.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;

            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Verdiario_general('RP-004','" + DDLCentro_Contable.SelectedValue + "','" + FechaInicial + "','" + FechaFinal + "', '" + ddlTipo2.SelectedValue + "', '" + ddlStatus2.SelectedValue + "','" + txtBuscar.Text + "');", true);
        }
        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {
            string FechaInicial = "01/" + ddlFecha_Ini.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
            int DiaFinal = System.DateTime.DaysInMonth(Convert.ToInt32(SesionUsu.Usu_Ejercicio), Convert.ToInt32(ddlFecha_Fin.SelectedValue));
            string FechaFinal = DiaFinal + "/" + ddlFecha_Fin.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-004exc&centro_contable=" + DDLCentro_Contable.SelectedValue + "&mes_inicial=" + FechaInicial + "&mes_final=" + FechaFinal + "&tipo_p=" + ddlTipo2.SelectedValue + "&status=" + ddlStatus2.SelectedValue + "&filtro_busca=" + txtBuscar.Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        #endregion

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            //lblError.Text = string.Empty;
            VerificaFechas(txtFecha);
            string Validado = ValidaMes(txtFecha);
            if (Validado != "Z")
            {
                //lblError.Text = Validado;
                Verificador = Validado;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void ddlCuentas_Contables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //ListCuentas.Find(TextBox2.Text);           

            //List<Comun> resultFindAll = ListCuentas.FindAll(
            //    delegate(string current)
            //    {
            //        return current.Contains(TextBox2.Text);
            //    }
            //);


            //string Busca = TextBox2.Text;
            //ListCuentas.Contains(Busca);


            //ListCuentas.Contains()

        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //txtSearch.Focus();
            ddlCuentas_Contables.DataSource = null;
            ddlCuentas_Contables.DataBind();
            ListCuentas = (List<Comun>)Session["Cuentas"];
            var filteredCuentas = from c in ListCuentas
                                  where c.Descripcion.Contains(txtSearch.Text.ToUpper()) //txtSearch.Text
                                  select c;

            var content = filteredCuentas.ToList<Comun>();

            //List<Comun> Lista = new List<Comun>();
            //Lista = filteredCuentas.ToList<Comun>();
            //ddlCuentas_Contables.DataSource = Lista;

            ddlCuentas_Contables.DataSource = content;
            ddlCuentas_Contables.DataValueField = "IdStr";
            ddlCuentas_Contables.DataTextField = "Descripcion";
            ddlCuentas_Contables.DataBind();
            if (content.Count() >= 1)
            {
                ddlCuentas_Contables.SelectedIndex = 0;
            }
            //ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "Mensaje();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Mensaje();", true);

            //txtCargo.Focus();
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + txtName.Text + "');", true);
        }
        protected void ddlCuentas_Contables_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //txtSearch.Text = ddlCuentas_Contables.SelectedItem.Text;
            //txtSearch_TextChanged(null, null);
            //txtCargo.Focus();
        }
        protected void linkBttnImprimir_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvPolizas.SelectedIndex = row.RowIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerPoliza('RP-005'," + SesionUsu.Usu_Ejercicio + ", '" + grvPolizas.SelectedRow.Cells[0].Text + "');", true);

        }
        protected void linkBttnEliminar_Click(object sender, EventArgs e)
        {

        }
        protected void ddlFecha_Fin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlFecha_Ini_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlFecha_Ini.SelectedValue) > Convert.ToInt32(ddlFecha_Fin.SelectedValue))
                {
                    ddlFecha_Fin.SelectedValue = ddlFecha_Ini.SelectedValue;
                }
                LimpiaGrid();
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        protected void ddlTipo0_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_Programa();
            rowCFDI.Visible = true;
            chkIncluyeCFDI.Checked = false;
            if (ddlTipo0.SelectedValue == "E")
            {
                //pnlEgreso.Visible = true;
                rowEgreso.Visible = true;
                rowEgreso2.Visible = true;
                rowEgreso3.Visible = true;
            }
            else
            {
                if (ddlTipo0.SelectedValue == "I")
                    rowCFDI.Visible = false;

                rowEgreso.Visible = false;
                rowEgreso2.Visible = false;
                rowEgreso3.Visible = false;
                ddlCheque_Cuenta.SelectedValue = "00000";
                txtCheque_Numero.Text = string.Empty;
                txtCheque_Importe.Text = string.Empty;
                txtCedula_Numero.Text = string.Empty;
                txtBeneficiario.Text = string.Empty;

            }
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            modalGuardar.Hide();
        }

        protected void ddlFecha_Fin_SelectedIndexChanged1(object sender, EventArgs e)
        {
            LimpiaGrid();
        }

        protected void ddlTipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiaGrid();
        }

        protected void ddlStatus2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiaGrid();
        }

        protected void ddl_server(object sender, ServerValidateEventArgs e)
        {
            if (ddlTipo0.SelectedValue == "E")
            {
                string d = e.Value;
            }

        }


        protected void linkBttnCopiar_Click(object sender, EventArgs e)
        {
            txtNumero_Poliza_Copia.Text = string.Empty;
            txtFecha_Copia.Text = string.Empty;

            //modalCopiaPoliza.Show();            
            MultiView1.ActiveViewIndex = 2;

            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvPolizas.SelectedIndex = row.RowIndex;
            pnlPrincipal.Visible = false;
            string MesCC = VerificaMes();
            txtFecha_Copia.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
            lblMsjPolizaCopia.Text = "ESTAS COPIANDO LA PÓLIZA NÚMERO " + grvPolizas.SelectedRow.Cells[2].Text + " DEL CENTRO CONTABLE " + grvPolizas.SelectedRow.Cells[1].Text;

        }

        protected void btnCancelarCopia_Click(object sender, EventArgs e)
        {
            //modalCopiaPoliza.Hide();
            pnlPrincipal.Visible = true;
            MultiView1.ActiveViewIndex = 0;
        }

        //protected void txtFecha_Copia_TextChanged(object sender, EventArgs e)
        //{
        //   lblError.Text = string.Empty;
        //    VerificaFechas(txtFecha_Copia);
        //    string Validado = ValidaMes(txtFecha_Copia);
        //    if (Validado != "Z")
        //       lblError.Text = Validado;

        //}

        protected void btnCopiar_Click(object sender, EventArgs e)
        {
            lblMsjErrPolizaCopia.Text = string.Empty;
            Verificador = string.Empty;

            try
            {
                ObjPoliza.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                ObjPoliza.Numero_poliza = txtNumero_Poliza_Copia.Text;
                ObjPoliza.Fecha = txtFecha_Copia.Text;
                CNPoliza.PolizaCopiar(ref ObjPoliza, ref Verificador);
                if (Verificador == "0")
                {
                    pnlPrincipal.Visible = true;
                    int newIdPoliza = Convert.ToInt32(ObjPoliza.IdPoliza);
                    CargarGrid(newIdPoliza);
                    //grvPolizas.SelectedRow.Cells[0].Text = newIdPoliza;

                    //int idx=Convert.ToInt32(grvPolizas.SelectedRow.RowIndex.ToString());


                    //int index = grvPolizas.SelectedIndex;
                    grvPolizas_SelectedIndexChanged(null, null);



                    //LinkButton cbi = (LinkButton)(sender);
                    //GridViewRow row = (GridViewRow)cbi.NamingContainer;
                    //grvPolizas.SelectedIndex = row.RowIndex;



                }
                else
                    lblMsjErrPolizaCopia.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMsjErrPolizaCopia.Text = ex.Message;
            }
        }

        protected void txtFecha_Copia_TextChanged(object sender, EventArgs e)
        {
            lblMsjErrPolizaCopia.Text = string.Empty;
            VerificaFechas(txtFecha_Copia);
            string Validado = ValidaMes(txtFecha_Copia);
            if (Validado != "Z")
            {
                lblMsjErrPolizaCopia.Text = Validado;
            }
            //txtNumero_Poliza_Copia.Text=string.Empty;
        }

        protected void grvPolizas_Detalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //int indice=e.NewEditIndex;
            grvPolizas_Detalle.EditIndex = e.NewEditIndex;
            List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
            Session["PolizaDet"] = ListPDet;
            CargarGridDetalle(ListPDet);
            //CargarGridDetalle();            
        }

        protected void grvPolizas_Detalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
            grvPolizas_Detalle.EditIndex = -1;
            CargarGridDetalle(ListPDet);
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            string FechaInicial = "01/" + ddlFecha_Ini.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
            int DiaFinal = System.DateTime.DaysInMonth(Convert.ToInt32(SesionUsu.Usu_Ejercicio), Convert.ToInt32(ddlFecha_Fin.SelectedValue));
            string FechaFinal = DiaFinal + "/" + ddlFecha_Fin.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;

            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Verdiario_polizas_x_lote('RP-005-lote','" + SesionUsu.Usu_Ejercicio + "','" + DDLCentro_Contable.SelectedValue + "','" + FechaInicial + "','" + FechaFinal + "', '" + ddlTipo2.SelectedValue + "', '" + ddlStatus2.SelectedValue + "');", true);
        }

       

        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {
            List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
            GridViewRow row = grvPolizas_Detalle.Rows[e.RowIndex];
            ListPDet[e.RowIndex].Cargo = Convert.ToDouble(((TextBox)(row.Cells[5].Controls[0])).Text);
            ListPDet[e.RowIndex].Abono = Convert.ToDouble(((TextBox)(row.Cells[6].Controls[0])).Text);
            grvPolizas_Detalle.EditIndex = -1;
            Session["PolizaDet"] = ListPDet;
            CargarGridDetalle(ListPDet);
        }

        protected void grvPolizas_Detalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (grvPolizas_Detalle.Rows.Count > 0)
                if (Math.Abs(Convert.ToDouble(lblTotal_Cargos.Text)) != Math.Abs(Convert.ToDouble(lblTotal_Abonos.Text)))
                    modalGuardar.Show();
                else
                    Guardar();
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, 'Se deben agregar cargos y abonos.');", true);

            //lblError.Text = "Se deben agregar cargos y abonos";           
        }

        protected void grvPolizas_Detalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            string MesCC = VerificaMes();
            if (Convert.ToInt32(MesCC) > 12)
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, 'Ejercicio Cerrado.');", true);
            else
            {
                LimpiaCampos();
                DDLCentro_Contable.Enabled = false;
                DDLCentro_Contable_SelectedIndexChanged(null, null);
            }
        }

        protected void LimpiaCampos()
        {
            //lblBuscar.Visible = false;
            //txtBuscar.Visible = false;
            //imgbtnBuscar.Visible = false;
            btnNuevo.Visible = false;
            filaFechas.Visible = true;
            //pnlFechas0.Visible = true;
            //pnlFechas.Visible = false;
            filaFechasBusqueda.Visible = false;
            filaBusqueda.Visible = false;
            ddlTipo0_SelectedIndexChanged(null, null);
            txtNumero_Poliza.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            ddlTipo_Captura.SelectedValue = "MC";
            txtCargo.Text = string.Empty;
            txtAbono.Text = string.Empty;
            ddlCheque_Cuenta.SelectedValue = "00000";
            txtCheque_Numero.Text = string.Empty;
            txtCheque_Importe.Text = string.Empty;
            txtCedula_Numero.Text = string.Empty;
            txtBeneficiario.Text = string.Empty;
            lblTotal_Cargos.Text = string.Empty;
            lblTotal_Abonos.Text = string.Empty;
            lblFormatoTotal_Cargos.Text = string.Empty;
            lblFormatoTotal_Abonos.Text = string.Empty;
            chkIncluyeCFDI.Checked = false;

            //LimpiaCamposFiscales();
            
            SesionUsu.Editar = 0;
            Session["PolizaDet"] = null;
            Session["PolizasCFDI"] = null;
            lblNumPolizaCFDI.Text = string.Empty;
            //lblTotAbonoPol.Text = string.Empty;
            grvPolizas_Detalle.DataSource = null;
            grvPolizas_Detalle.DataBind();

            TabContainer1.ActiveTabIndex = 0;
            MultiView1.ActiveViewIndex = 1;
            ValidatorNumPoliza.ValidationGroup = "Poliza";

        }
        protected void LimpiaCamposFiscales()
        {
            /*Datos Fiscales*/
            ddlTipo_Beneficiario.SelectedValue = "0";
            ddlTipo_Gasto.SelectedValue = "0";
            
            /*Fin Datos Fiscales*/
        }
        protected void Select_Programa()
        {
            if (DDLCentro_Contable.SelectedValue == "72103")
            {
                if (ddlTipo0.SelectedValue == "E" || ddlTipo0.SelectedValue == "D")
                {
                    if (ddlTipo0.SelectedValue == "E")
                    {
                        ddlprograma.Visible = true;
                        lbprograma.Visible = true;
                        ddlprograma.SelectedIndex = 0;
                        val_programa.ValidationGroup = "Poliza";
                        //RFVCheque_Importe.ValidationGroup = string.Empty;
                        //RFVCheque_Numero.ValidationGroup = string.Empty;
                        //RFVBeneficiario.ValidationGroup = string.Empty;
                    }
                    else
                    {
                        ddlprograma.Visible = true;
                        lbprograma.Visible = true;
                        ddlprograma.SelectedIndex = 0;
                        val_programa.ValidationGroup = "Poliza";
                        //RFVCheque_Importe.ValidationGroup = "Poliza";
                        //RFVCheque_Numero.ValidationGroup = "Poliza";
                        //RFVBeneficiario.ValidationGroup = "Poliza";
                    }
                }
                else
                {
                    val_programa.ValidationGroup = string.Empty;
                    ddlprograma.Visible = false;
                    lbprograma.Visible = false;
                    ddlprograma.SelectedIndex = 1;
                }
            }
            else
            {
                val_programa.ValidationGroup = string.Empty;
                ddlprograma.Visible = false;
                lbprograma.Visible = false;
                ddlprograma.SelectedIndex = 1;
                RFVCheque_Importe.ValidationGroup = "Poliza";
                RFVCheque_Numero.ValidationGroup = "Poliza";
                RFVBeneficiario.ValidationGroup = "Poliza";
            }
        }
        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            //lblError.Text = string.Empty;
            string Cargo = txtCargo.Text.Replace(",", "");
            double TotCargo = Convert.ToDouble(Cargo);
            string Abono = txtAbono.Text.Replace(",", "");
            double TotAbono = Convert.ToDouble(Abono);
            try
            {
                ObjPolizaDet.IdCuenta_Contable = Convert.ToInt32(ddlCuentas_Contables.SelectedValue);
                ObjPolizaDet.DescCuenta_Contable = ddlCuentas_Contables.SelectedItem.Text;
                ObjPolizaDet.Cargo = TotCargo; // Convert.ToDouble(txtCargo.Text);
                ObjPolizaDet.Abono = TotAbono; // Convert.ToDouble(txtAbono.Text);
                //ObjPolizaDet.Numero_Movimiento=((Label)grvPolizas_Detalle.Rows[0].FindControl("lblNumero_Movimiento_Aut")).
                //_Detalle.PageSize * grvPolizas_Detalle.PageIndex) + Container.DisplayIndex + 1 


                if (Session["PolizaDet"] == null)
                {
                    ListPDet = new List<Poliza_Detalle>();
                    ListPDet.Add(ObjPolizaDet);
                }
                else
                {
                    ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
                    ListPDet.Add(ObjPolizaDet);
                }

                Session["PolizaDet"] = ListPDet;
                CargarGridDetalle(ListPDet);
                txtCargo.Text = string.Empty;
                txtAbono.Text = string.Empty;
                txtSearch.Focus();
            }

            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void imgBttnExcelLotes_Click(object sender, ImageClickEventArgs e)
        {
            string FechaInicial = "01/" + ddlFecha_Ini.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
            int DiaFinal = System.DateTime.DaysInMonth(Convert.ToInt32(SesionUsu.Usu_Ejercicio), Convert.ToInt32(ddlFecha_Fin.SelectedValue));
            string FechaFinal = DiaFinal + "/" + ddlFecha_Fin.SelectedValue + "/" + SesionUsu.Usu_Ejercicio;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Verdiario_polizas_x_lote_exc('RP-005-lote-exc','" + SesionUsu.Usu_Ejercicio + "','" + DDLCentro_Contable.SelectedValue + "','" + FechaInicial + "','" + FechaFinal + "', '" + ddlTipo2.SelectedValue + "', '" + ddlStatus2.SelectedValue + "');", true);
            //string ruta = "Reportes/VisualizadorCrystal.aspx?idFact=" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-005-lote-exc&ejercicio=" + SesionUsu.Usu_Ejercicio + "&centro_contable=" + DDLCentro_Contable.SelectedValue + "&mes_inicial=" + FechaInicial + "&mes_final=" + FechaFinal + "&tipo_p=" + ddlTipo2.SelectedValue + "&status=" + ddlStatus2.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void bttnAgregaFactura_Click(object sender, EventArgs e)
        {
            string Ruta;
            string NombreArchivo;
            List<Poliza_CFDI> lstPolizasCFDI = new List<Poliza_CFDI>();

            try
            {
                if (FileFactura.HasFile)
                {
                    NombreArchivo = FileFactura.FileName.ToUpper();
                    if (NombreArchivo.Contains(".XML"))
                    {
                        DateTime FechaActual = DateTime.Today;

                        XmlDocument xDoc = new XmlDocument();
                        Ruta = Path.Combine(Server.MapPath("~/AdjuntosTemp"), DDLCentro_Contable.SelectedValue + "-" + NombreArchivo);
                        FileFactura.SaveAs(Ruta);

                        ObjPolizaCFDI.Beneficiario_Tipo = ddlTipo_Beneficiario.SelectedValue;
                        ObjPolizaCFDI.Tipo_Gasto = ddlTipo_Gasto.SelectedValue;
                        ObjPolizaCFDI.NombreArchivoXML = DDLCentro_Contable.SelectedValue + "-" + NombreArchivo;
                        ObjPolizaCFDI.Fecha_Captura = FechaActual.ToString("dd/MM/yyyy");
                        ObjPolizaCFDI.Usuario_Captura = SesionUsu.Usu_Nombre;
                        ObjPolizaCFDI.Ruta_XML = "~/AdjuntosTemp/" + ObjPolizaCFDI.NombreArchivoXML;

                        xDoc.Load(Ruta);
                        XmlNodeList datos = xDoc.GetElementsByTagName("cfdi:Comprobante");

                        foreach (XmlElement nodo in datos)
                        {
                            try
                            {
                                ObjPolizaCFDI.CFDI_Folio = string.Empty;

                                if (nodo.Attributes["Folio"] != null)
                                    ObjPolizaCFDI.CFDI_Folio = nodo.Attributes["Folio"].InnerText;

                                if (nodo.Attributes["folio"] != null)
                                    ObjPolizaCFDI.CFDI_Folio = nodo.Attributes["folio"].InnerText;

                                if (nodo.Attributes["FOLIO"] != null)
                                    ObjPolizaCFDI.CFDI_Folio = nodo.Attributes["FOLIO"].InnerText;


                            }
                            catch (Exception)
                            {
                                ObjPolizaCFDI.CFDI_Folio = string.Empty;
                            }

                            /*BUSCA CAMPO FECHA*/
                            if (nodo.Attributes["Fecha"] != null)
                                ObjPolizaCFDI.CFDI_Fecha = nodo.Attributes["Fecha"].InnerText;

                            if (nodo.Attributes["fecha"] != null)
                                ObjPolizaCFDI.CFDI_Fecha = nodo.Attributes["fecha"].InnerText;

                            if (nodo.Attributes["FECHA"] != null)
                                ObjPolizaCFDI.CFDI_Fecha = nodo.Attributes["FECHA"].InnerText;
                            /*FIN CAMPO FECHA*/

                            /*BUSCA CAMPO TOTAL*/
                            if (nodo.Attributes["Total"] != null)
                                ObjPolizaCFDI.CFDI_Total = Convert.ToDouble(nodo.Attributes["Total"].InnerText);

                            if (nodo.Attributes["total"] != null)
                                ObjPolizaCFDI.CFDI_Total = Convert.ToDouble(nodo.Attributes["total"].InnerText);

                            if (nodo.Attributes["TOTAL"] != null)
                                ObjPolizaCFDI.CFDI_Total = Convert.ToDouble(nodo.Attributes["TOTAL"].InnerText);
                            /*FIN CAMPO TOTAL*/


                            XmlNodeList listEmisor = nodo.GetElementsByTagName("cfdi:Emisor");
                            XmlNodeList listReceptor = nodo.GetElementsByTagName("cfdi:Receptor");
                            XmlNodeList listConcepto = nodo.GetElementsByTagName("cfdi:Conceptos");
                            XmlNodeList listImpuesto = nodo.GetElementsByTagName("cfdi:Impuestos");
                            XmlNodeList listComplemento = nodo.GetElementsByTagName("cfdi:Complemento");

                            if (listEmisor.Count >= 1)
                            {
                                /*BUSCA CAMPO NOMBRE*/
                                if (listEmisor[0].Attributes["Nombre"] != null)
                                    ObjPolizaCFDI.CFDI_Nombre = listEmisor[0].Attributes["Nombre"].InnerText;

                                if (listEmisor[0].Attributes["nombre"] != null)
                                    ObjPolizaCFDI.CFDI_Nombre = listEmisor[0].Attributes["nombre"].InnerText;

                                if (listEmisor[0].Attributes["NOMBRE"] != null)
                                    ObjPolizaCFDI.CFDI_Nombre = listEmisor[0].Attributes["NOMBRE"].InnerText;
                                /*FIN CAMPO NOMBRE*/

                                /*BUSCA CAMPO RFC*/
                                if (listEmisor[0].Attributes["Rfc"] != null)
                                    ObjPolizaCFDI.CFDI_RFC = listEmisor[0].Attributes["Rfc"].InnerText;

                                if (listEmisor[0].Attributes["rfc"] != null)
                                    ObjPolizaCFDI.CFDI_RFC = listEmisor[0].Attributes["rfc"].InnerText;

                                if (listEmisor[0].Attributes["RFC"] != null)
                                    ObjPolizaCFDI.CFDI_RFC = listEmisor[0].Attributes["RFC"].InnerText;
                                /*FIN CAMPO RFC*/


                                //ObjPolizaCFDI.CFDI_Nombre = listEmisor[0].Attributes["Nombre"].InnerText;
                                //ObjPolizaCFDI.CFDI_RFC = listEmisor[0].Attributes["Rfc"].InnerText;

                            }
                            if (listComplemento.Count >= 1)
                            {
                                XmlNodeList listTimbreDigital =
                                ((XmlElement)listComplemento[0]).GetElementsByTagName("tfd:TimbreFiscalDigital");
                                ObjPolizaCFDI.CFDI_UUID = listTimbreDigital[0].Attributes["UUID"].InnerText;
                            }
                        }

                    }
                }

                /*Archivo PDF*/
                if (FileFacturaPDF.HasFile)
                {
                    NombreArchivo = FileFacturaPDF.FileName.ToUpper();
                    if (NombreArchivo.Contains(".PDF"))
                    {

                        Ruta = Path.Combine(Server.MapPath("~/AdjuntosTemp"), DDLCentro_Contable.SelectedValue + "-" + NombreArchivo);
                        FileFacturaPDF.SaveAs(Ruta);
                        ObjPolizaCFDI.NombreArchivoPDF = DDLCentro_Contable.SelectedValue + "-" + NombreArchivo;
                        ObjPolizaCFDI.Ruta_PDF = "~/AdjuntosTemp/" + ObjPolizaCFDI.NombreArchivoPDF;
                    }
                    else
                    {
                        Verificador = "Documento invalido, deber ser un PDF.";
                    }
                }
                /*Fin Archivo PDF*/


                if (Session["PolizasCFDI"] != null)
                    lstPolizasCFDI = (List<Poliza_CFDI>)Session["PolizasCFDI"];

                lstPolizasCFDI.Add(ObjPolizaCFDI);
                Session["PolizasCFDI"] = lstPolizasCFDI;
                CargarGridPolizaCFDI(lstPolizasCFDI);
                LimpiaCamposFiscales();

            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);


            }
        }

        protected void bttnAgregaFacturaPDF_Click(object sender, EventArgs e)
        {
            string Ruta;
            string NombreArchivo;
            try
            {
                
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void imgBttnEliminarXML_Click(object sender, ImageClickEventArgs e)
        {
            LimpiaCamposFiscales();
        }

       
        protected void bttnAgregar_Click(object sender, EventArgs e)
        {
           
            try
            {

                string Cargo = txtCargo.Text.Replace(",", "");
                double TotCargo = Convert.ToDouble(Cargo);
                string Abono = txtAbono.Text.Replace(",", "");
                double TotAbono = Convert.ToDouble(Abono);


                ObjPolizaDet.IdCuenta_Contable = Convert.ToInt32(ddlCuentas_Contables.SelectedValue);
                ObjPolizaDet.DescCuenta_Contable = ddlCuentas_Contables.SelectedItem.Text;
                ObjPolizaDet.Cargo = TotCargo; // Convert.ToDouble(txtCargo.Text);
                ObjPolizaDet.Abono = TotAbono; // Convert.ToDouble(txtAbono.Text);
                //ObjPolizaDet.Numero_Movimiento=((Label)grvPolizas_Detalle.Rows[0].FindControl("lblNumero_Movimiento_Aut")).
                //_Detalle.PageSize * grvPolizas_Detalle.PageIndex) + Container.DisplayIndex + 1 


                if (Session["PolizaDet"] == null)
                {
                    ListPDet = new List<Poliza_Detalle>();
                    ListPDet.Add(ObjPolizaDet);
                }
                else
                {
                    ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
                    ListPDet.Add(ObjPolizaDet);
                }

                Session["PolizaDet"] = ListPDet;
                CargarGridDetalle(ListPDet);
                txtCargo.Text = string.Empty;
                txtAbono.Text = string.Empty;
                txtSearch.Focus();
            }

            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }


        protected void btnGuardarCFDI_Click(object sender, EventArgs e)
        {
            /*DATOS CFDI XML*/
            Verificador = string.Empty;
            List<Poliza_CFDI> lstPolizasCFDI = new List<Poliza_CFDI>();
            try
            {

                if (Session["PolizasCFDI"] != null)
                    lstPolizasCFDI = (List<Poliza_CFDI>)Session["PolizasCFDI"];
                

                ObjPolizaCFDI.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                CNPolizaCFDI.PolizaCFDIEditar(ObjPolizaCFDI, lstPolizasCFDI, ref Verificador);
                //CNPolizaCFDI.PolizaCFDIInsertar(ObjPolizaCFDI, lstPolizasCFDI, ref Verificador);

                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(1, 'Los datos han sido agregados correctamente.');", true);
                    Copiar_a_Adjuntos(lstPolizasCFDI);
                    SesionUsu.Editar = -1;
                    MultiView1.ActiveViewIndex = 0;
                    CargarGrid(0);
                    filaCentroContable.Visible = true;
                    filaFechasBusqueda.Visible = true;
                    filaBusqueda.Visible = true;
                }
                else
                {
                    //SesionUsu.Editar = -1;
                    //MultiView1.ActiveViewIndex = 0;
                    //CargarGrid(0);
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);

                }

                /*FIN DATOS CFDI XML*/
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

        protected void linkBttnCFDI_Click(object sender, EventArgs e)
        {
            lblNumPolizaCFDI.Text = string.Empty;
            //lblTotAbonoPol.Text = string.Empty;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvPolizas.SelectedIndex = row.RowIndex;
            List<Poliza_CFDI> lstPolizasCFDI = new List<Poliza_CFDI>();
            Session["PolizasCFDI"] = null;
            grvPolizaCFDI.DataSource = null;
            grvPolizaCFDI.DataBind();
            try
            {
                lblNumPolizaCFDI.Text ="# DE PÓLIZA: "+ grvPolizas.SelectedRow.Cells[2].Text;
                //lblTotAbonoPol.Text = "TOTAL ABONO:"+ grvPolizas.SelectedRow.Cells[9].Text;
                ObjPolizaCFDI.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                CNPolizaCFDI.PolizaCFDIConsultaDatos(ObjPolizaCFDI, ref lstPolizasCFDI, ref Verificador);
                if (lstPolizasCFDI.Count > 0)
                {
                    Session["PolizasCFDI"] = lstPolizasCFDI;
                    //Copiar_a_AdjuntosTemp(lstPolizasCFDI); //MODIFICADO DIA 26/03
                    CargarGridPolizaCFDI(lstPolizasCFDI);
                }
                else
                    Session["PolizasCFDI"] = null;


                MultiView1.ActiveViewIndex = 3;
                filaCentroContable.Visible = false;
                //pnlFechas.Visible = false;
                filaFechasBusqueda.Visible = false;
                filaBusqueda.Visible = false;


            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void btnCancelarCFDI_Click(object sender, EventArgs e)
        {
            LimpiaCamposFiscales();
            MultiView1.ActiveViewIndex = 0;
            filaCentroContable.Visible = true;
            //pnlFechas.Visible = true;
            filaFechasBusqueda.Visible = true;
            filaBusqueda.Visible = true;

            SesionUsu.Editar = -1;
            //MultiView1.ActiveViewIndex = 0;
            //CargarGrid(0);


        }

        protected void grvPolizaCFDI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Poliza_CFDI> lstPolizasCFDI = new List<Poliza_CFDI>();
            lstPolizasCFDI = (List<Poliza_CFDI>)Session["PolizasCFDI"];
            try
            {
                int fila = e.RowIndex;
                int pagina = grvPolizaCFDI.PageSize * grvPolizaCFDI.PageIndex;
                fila = pagina + fila;
                lstPolizasCFDI.RemoveAt(fila);
                Session["PolizasCFDI"] = lstPolizasCFDI;
                CargarGridPolizaCFDI(lstPolizasCFDI);
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }


        }

        protected void grvPolizaCFDI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<Poliza_CFDI> lstPolizasCFDI = new List<Poliza_CFDI>();
            lstPolizasCFDI = (List<Poliza_CFDI>)Session["PolizasCFDI"];
            try
            {

                grvPolizaCFDI.PageIndex = 0;
                grvPolizaCFDI.PageIndex = e.NewPageIndex;
                CargarGridPolizaCFDI(lstPolizasCFDI);
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }
    }
}