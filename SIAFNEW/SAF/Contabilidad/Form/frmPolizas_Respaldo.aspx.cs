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
    public partial class frmPolizas_Respaldo : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Poliza CNPoliza = new CN_Poliza();
        CN_Poliza_Det CNPolizaDet = new CN_Poliza_Det();
        CN_Usuario CNUsuario = new CN_Usuario();
        Comun ObjCC = new Comun();
        Poliza ObjPoliza = new Poliza();
        Poliza_Detalle ObjPolizaDet = new Poliza_Detalle();
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
                else if ((Request.Params["__EVENTTARGET"] == this.btnAgregar.ClientID))
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
           lblError.Text = string.Empty;
            Session["CentrosContab"] = null;
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ref ListCentroContable);
                Session["CentrosContab"] = ListCentroContable;                
              }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }
        private void CargarGrid(int indexCopia)
        {
           lblError.Text = string.Empty;
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
               lblError.Text = ex.Message;
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
           lblError.Text = string.Empty;           
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
               lblError.Text = ex.Message;
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
            pnlFechas.Visible = true;
            pnlFechas0.Visible = false;
            lblBuscar.Visible = true;
            txtBuscar.Visible = true;
            imgbtnBuscar.Visible = true;
            btnNuevo.Visible = true;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            //string Ini = fecha.ToString("MM");
            ddlFecha_Ini.SelectedValue = fecha.ToString("MM");
            ddlFecha_Fin.SelectedValue = fecha.ToString("MM");
        }
        private void VerificaFechas(TextBox txt)
        {
           lblError.Text = string.Empty;
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
               lblError.Text = "function(VerificaFechas) " + ex.Message;
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
           lblError.Text = string.Empty;
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
                
                return lblError.Text = band + "-" + Mes + "-" + NumMesCC + "function(ValidaMes) " + ex.Message;
            }

        }
        private void ValidateNumPoliza(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Contains("4999"));
        }
        private void Guardar()
        {
            string Validado = ValidaMes(txtFecha);
            //if (grvPolizas_Detalle.Rows.Count > 0)
            //{
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
                    //ObjPoliza.Status = (Convert.ToDouble(lblTotal_Cargos.Text) != Convert.ToDouble(lblTotal_Abonos.Text)) ? "N" : "A"; //ddlStatus0.SelectedValue;
                    //ObjPoliza.Status = (lblFormatoTotal_Cargos.Text != lblFormatoTotal_Abonos.Text) ? "N" : "A"; //ddlStatus0.SelectedValue;
                    ObjPoliza.Tipo_captura = ddlTipo_Captura.SelectedValue;
                    ObjPoliza.Alta_usuario = SesionUsu.Usu_Nombre;
                    ObjPoliza.Modificacion_usuario = SesionUsu.Usu_Nombre;
                    ObjPoliza.Cheque_cuenta = "00000"; //ddlCheque_Cuenta.SelectedValue;
                    ObjPoliza.Cheque_numero = txtCheque_Numero.Text;
                    ObjPoliza.Cheque_importe = (txtCheque_Importe.Text.Length > 0) ? Convert.ToDouble(txtCheque_Importe.Text) : Convert.ToDouble("0");
                    ObjPoliza.Cedula_numero = txtCedula_Numero.Text;
                    ObjPoliza.Beneficiario = txtBeneficiario.Text;
                    if (DDLCentro_Contable.SelectedValue == "72103")
                    {
                        if (ddlTipo0.SelectedValue != "I")
                        {                         
                                ObjPoliza.Concepto = ddlprograma.SelectedValue + "»" + txtConcepto.Text;                                 
                        }
                        else
                        {
                            ObjPoliza.Concepto = txtConcepto.Text;
                        }
                        
                    }
                    else
                    {
                        ObjPoliza.Concepto = txtConcepto.Text;
                    }                    
                    if (SesionUsu.Editar == 0)
                    {
                       
                        CNPoliza.PolizaInsertar(ref ObjPoliza, ref Verificador);
                        if (Verificador == "0")
                        {
                            ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
                            CNPolizaDet.PolizaDetInsertar(ListPDet, ObjPoliza.IdPoliza, /*grvPolizas_Detalle,*/ ref Verificador);
                            if (Verificador == "0")
                            {
                               lblError.Text = "Los datos han sido agregados correctamente";
                                SesionUsu.Editar = -1;
                                MultiView1.ActiveViewIndex = 0;
                                InicializaCamposGuardar();
                                CargarGrid(0);
                            }
                            else
                            {
                               lblError.Text = Verificador;
                            }
                        }
                        else
                        {
                           lblError.Text = Verificador;
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
                               lblError.Text = "Los datos han sido modificados correctamente";
                                SesionUsu.Editar = -1;
                                MultiView1.ActiveViewIndex = 0;
                                InicializaCamposGuardar();
                                CargarGrid(0);
                            }
                            else
                            {
                               lblError.Text = Verificador;
                            }
                        }
                        else
                        {
                           lblError.Text = Verificador;
                        }
                    }
                }
                else
                {
                   lblError.Text = Validado;
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
            if (SesionUsu.Editar == -1)
            {
                CargarGrid(0);
            }
        }      
   
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblBuscar.Visible = true;
            txtBuscar.Visible = true;
            imgbtnBuscar.Visible = true;
            btnNuevo.Visible = true;
            pnlFechas0.Visible = false;
            pnlFechas.Visible = true;
            lblTotal_Cargos.Text = string.Empty;
            lblTotal_Abonos.Text = string.Empty;
            lblFormatoTotal_Cargos.Text = string.Empty;
            lblFormatoTotal_Abonos.Text = string.Empty;
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
           lblError.Text = string.Empty;
            if (SesionUsu.Editar == 0 || SesionUsu.Editar == 1)
            {
                Session["Cuentas"] = null;
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cheque_Cuenta", ref ddlCheque_Cuenta, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, DDLCentro_Contable.SelectedValue);
                CNComun.LlenaCombo("pkg_contabilidad.Obt_List_Cuentas_Contables_Id", ref ddlCuentas_Contables, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue), ref ListCuentas);
                Session["Cuentas"] = ListCuentas;


                string MesCC = VerificaMes();
                txtFecha.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;


                string Validado = ValidaMes(txtFecha);
                if (Validado != "Z")
                   lblError.Text = Validado;
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
           lblError.Text = string.Empty;
            btnNuevo_Click(null, null);
            try
            {
                ObjPoliza.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);   // Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());
                CNPoliza.ConsultarPolizaSel(ref ObjPoliza, ref Verificador);
                if (Verificador == "0")
                {                    
                    ddlTipo0.SelectedValue = ObjPoliza.Tipo;
                    ddlTipo0_SelectedIndexChanged(null, null);
                    ddlTipo_Captura.SelectedValue = ObjPoliza.Tipo_captura;                    
                    ddlStatus0.SelectedValue = ObjPoliza.Status;
                    txtNumero_Poliza.Text = ObjPoliza.Numero_poliza;
                    txtConcepto.Text = ObjPoliza.Concepto;
                    DDLCentro_Contable.SelectedValue = ObjPoliza.Centro_contable;
                    DDLCentro_Contable_SelectedIndexChanged(null, null);
                    ddlCheque_Cuenta.SelectedValue = ObjPoliza.Cheque_cuenta;
                    txtCheque_Numero.Text = ObjPoliza.Cheque_numero;
                    txtCheque_Importe.Text = Convert.ToString(ObjPoliza.Cheque_importe);
                    txtCedula_Numero.Text = ObjPoliza.Cedula_numero;
                    txtBeneficiario.Text = ObjPoliza.Beneficiario;
                    txtFecha.Text = ObjPoliza.Fecha;
                    ObjPolizaDet.IdPoliza = Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                    List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
                    CNPolizaDet.PolizaDetConsultaGrid(ref ObjPolizaDet, ref ListPDet);
                    DataTable dt = new DataTable();    
                    Session["PolizaDet"] = ListPDet;                    
                    CargarGridDetalle(ListPDet);
                    ValidatorNumPoliza.ValidationGroup = string.Empty;
                    SesionUsu.Editar = 1;
                }
                else
                {
                   lblError.Text = Verificador;
                }

                if (DDLCentro_Contable.SelectedValue == "72103")
                {
                    if (ddlTipo0.SelectedValue != "I")
                    {
                        string[] resultado;
                        char[] delimiter = { '»' };
                        resultado = txtConcepto.Text.Split(delimiter);
                        txtConcepto.Text = resultado[1];
                        ddlprograma.SelectedValue = resultado[0];
                    }
                    
                }                
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }




    protected void grvPolizas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           lblError.Text = string.Empty;
            try
            {
                int fila = e.RowIndex;
                ObjPoliza.IdPoliza = Convert.ToInt32(grvPolizas.Rows[fila].Cells[0].Text);
                CNPoliza.PolizaEliminar(ObjPoliza, ref Verificador);
                if (Verificador == "0")
                    CargarGrid(0);
                else
                   lblError.Text = Verificador;
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
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
           lblError.Text = string.Empty;
            VerificaFechas(txtFecha);
            string Validado = ValidaMes(txtFecha);
            if (Validado != "Z")
            {
               lblError.Text = Validado;
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
            if (Convert.ToInt32(ddlFecha_Ini.SelectedValue) > Convert.ToInt32(ddlFecha_Fin.SelectedValue))
            {
                ddlFecha_Fin.SelectedValue = ddlFecha_Ini.SelectedValue;
            }
            LimpiaGrid();
        }
        protected void ddlTipo0_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_Programa();
            if (ddlTipo0.SelectedValue == "E")
            {
                pnlEgreso.Visible = true;
                //RFVCheque_Numero.ValidationGroup = "Poliza";
                //RFVCheque_Importe.ValidationGroup = "Poliza";
                //RFVBeneficiario.ValidationGroup = "Poliza";
                //RFVCheque_Cuenta.ValidationGroup = "Poliza";
            }

            else
            {
                pnlEgreso.Visible = false;
                RFVCheque_Numero.ValidationGroup = string.Empty;
                RFVCheque_Importe.ValidationGroup = string.Empty;
                RFVBeneficiario.ValidationGroup = string.Empty;
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
                ObjPoliza.IdPoliza =Convert.ToInt32(grvPolizas.SelectedRow.Cells[0].Text);
                ObjPoliza.Numero_poliza = txtNumero_Poliza_Copia.Text;
                ObjPoliza.Fecha = txtFecha_Copia.Text;
                CNPoliza.PolizaCopiar(ref ObjPoliza, ref Verificador);
                if (Verificador == "0")
                {
                    pnlPrincipal.Visible = true;
                    int newIdPoliza=Convert.ToInt32(ObjPoliza.IdPoliza);
                    CargarGrid(newIdPoliza);
                    //grvPolizas.SelectedRow.Cells[0].Text = newIdPoliza;

                    //int idx=Convert.ToInt32(grvPolizas.SelectedRow.RowIndex.ToString());
 
                    
                    //int index = grvPolizas.SelectedIndex;
                    grvPolizas_SelectedIndexChanged(null,null);


                    
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

        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {

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
                lblError.Text = "Se deben agregar cargos y abonos";           
        }

        protected void grvPolizas_Detalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblBuscar.Visible = false;
            txtBuscar.Visible = false;
            imgbtnBuscar.Visible = false;
            btnNuevo.Visible = false;
            pnlFechas0.Visible = true;
            pnlFechas.Visible = false;
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


            SesionUsu.Editar = 0;
            string MesCC = VerificaMes();
            txtFecha.Text = "01/" + MesCC + "/" + SesionUsu.Usu_Ejercicio;
            DDLCentro_Contable_SelectedIndexChanged(null, null);


            Session["PolizaDet"] = null;
            grvPolizas_Detalle.DataSource = null;
            grvPolizas_Detalle.DataBind();
            //SesionUsu.Editar = 0;


            MultiView1.ActiveViewIndex = 1;
            ValidatorNumPoliza.ValidationGroup = "Poliza";
            Select_Programa();          
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
                        RFVCheque_Importe.ValidationGroup = string.Empty;
                        RFVCheque_Numero.ValidationGroup = string.Empty;
                        RFVBeneficiario.ValidationGroup = string.Empty;                       
                    }
                    else
                    {
                        ddlprograma.Visible = true;
                        lbprograma.Visible = true;
                        ddlprograma.SelectedIndex = 0;
                        val_programa.ValidationGroup = "Poliza";
                        RFVCheque_Importe.ValidationGroup = "Poliza";
                        RFVCheque_Numero.ValidationGroup = "Poliza";
                        RFVBeneficiario.ValidationGroup = "Poliza";
                    }
                }
                else
                {
                    val_programa.ValidationGroup = string.Empty;
                    ddlprograma.Visible = false ;
                    lbprograma.Visible = false ;
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
            lblError.Text = string.Empty;
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
                lblError.Text = ex.Message;
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
    }
}