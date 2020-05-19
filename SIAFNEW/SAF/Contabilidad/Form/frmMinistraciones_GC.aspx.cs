using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace SAF.Contabilidad.Form
{
    public partial class frmMinistraciones_GC : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        CN_Ministracion CNMinistracion = new CN_Ministracion();
        CN_Poliza CNPoliza = new CN_Poliza();
        CN_Poliza_Det CNPolizaDet = new CN_Poliza_Det();
        Sesion SesionUsu = new Sesion();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                Session["Ministracion"] = null;
                CargarGrid();
                Cargarcombos();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Cuentas_Contables", "Autocomplete();", true);

        }

        private void Cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
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
            Int32[] Celdas = new Int32[] { 9 };
            grvMinistracion.DataSource = null;
            grvMinistracion.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvMinistracion.DataSource = dt;
                grvMinistracion.DataSource = GetList();
                grvMinistracion.DataBind();
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        private List<Ministracion> GetList()
        {
            try
            {
                List<Ministracion> List = new List<Ministracion>();
                Ministracion objMinistracion = new Ministracion();
                CNMinistracion.MinistracionConsultaGrid(objMinistracion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void Enviar_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            CN_Ministracion CNMinistracion = new CN_Ministracion();
            Session["Ministracion"] = null;
            //Ministracion objMinistracion = new Ministracion();

            try
            {
                if (FileUpload1.HasFile)
                {
                    HttpPostedFile archivo = FileUpload1.PostedFile;
                    //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:/Users/lis_g/Downloads/Prueba.xlsx");


                    string filename = Path.GetFileName(FileUpload1.FileName);
                    //string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/") + filename);

                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Server.MapPath("~/") + filename);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    List<Ministracion> lstMinistracionResp = new List<Ministracion>();

                    for (int i = 2; i <= rowCount; i++)
                    {
                        List<Ministracion> lstMinistracion = new List<Ministracion>();
                        Ministracion objMinistracion = new Ministracion();
                        objMinistracion.Ejercicio = "0";
                        objMinistracion.Mes = "0";
                        objMinistracion.Centro_Contable = "0";
                        objMinistracion.Descripcion = "0";
                        objMinistracion.Banco = "0";
                        objMinistracion.Cuenta = "0";
                        objMinistracion.SubTotal = "0";
                        objMinistracion.Vigilancia = "0";
                        objMinistracion.Limpieza = "0";
                        objMinistracion.Anticipo = "0";
                        objMinistracion.Total = "0";
                        objMinistracion.Energia_Electrica = "0";
                        objMinistracion.Telefono = "0";
                        objMinistracion.TotalFederal = "0";
                        objMinistracion.TotalEstatal = "0";

                        for (int j = 1; j <= 17; j++)
                        {
                            //new line
                            //if (i > 1)
                            //{
                                if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            objMinistracion.Ejercicio = xlRange.Cells[i, j].Value2.ToString(); 
                                            break;
                                        case 2:
                                            objMinistracion.Mes = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 3:
                                            objMinistracion.Centro_Contable = xlRange.Cells[i, j].Value2.ToString();
                                            break;                                        
                                        case 4:
                                            objMinistracion.Descripcion = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 5:
                                            objMinistracion.Banco = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 6:
                                            objMinistracion.Cuenta = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 7:
                                            objMinistracion.SubTotal = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 8:                                            
                                            objMinistracion.Vigilancia = xlRange.Cells[i, j].Value2.ToString();   
                                            break;
                                        case 9:
                                            objMinistracion.Limpieza = xlRange.Cells[i, j].Value2.ToString(); 
                                            break;
                                        case 10:
                                            objMinistracion.Anticipo = xlRange.Cells[i, j].Value2.ToString(); 
                                            break;
                                        case 11:
                                            objMinistracion.Total = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 12:
                                            objMinistracion.Energia_Electrica = xlRange.Cells[i, j].Value2.ToString();                                                                                      
                                            break;
                                        case 13:
                                            objMinistracion.Telefono = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 14:
                                            objMinistracion.Suma_Desc_Serv = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 15:
                                            objMinistracion.Monto_Transferir = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 16:
                                            objMinistracion.TotalFederal = xlRange.Cells[i, j].Value2.ToString();
                                            break;
                                        case 17:
                                            objMinistracion.TotalEstatal = xlRange.Cells[i, j].Value2.ToString();
                                            break;

                                    }
                                }
                            //}
                        }
                        if (Session["Ministracion"] != null)
                            lstMinistracion = (List<Ministracion>)Session["Ministracion"];

                        lstMinistracion.Add(objMinistracion);
                        Session["Ministracion"] = lstMinistracion;

                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);

                    //close and release
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                    lstMinistracionResp = (List<Ministracion>)Session["Ministracion"];
                    CNMinistracion.EliminarArchivoCaja(lstMinistracionResp, ref Verificador);
                    if (Verificador == "0")
                    {
                        Verificador = string.Empty;
                        CNMinistracion.InsertarArchivoCaja(lstMinistracionResp, ref Verificador);
                        //if (Verificador == "0")
                            CargarGrid();
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

        protected void grvMinistracion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMinistracion.PageIndex = 0;
            grvMinistracion.PageIndex = e.NewPageIndex;
            CargarGrid();

        }

        protected void bttnGnrPolizas_Click(object sender, EventArgs e)
        {
            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvMinistracion.SelectedIndex = row.RowIndex;
            modal.Show();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            int Mes=0;
            Poliza objPoliza = new Poliza();
            try
            {
                Mes = Convert.ToInt32(grvMinistracion.SelectedRow.Cells[1].Text);
                objPoliza.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                objPoliza.Numero_poliza = txtNumPoliza.Text;
                objPoliza.Centro_contable = DDLCentro_Contable.SelectedValue;
                objPoliza.Tipo = "E";
                objPoliza.Concepto = txtConcepto.Text.ToUpper();
                objPoliza.Fecha = txtFecha.Text;
                objPoliza.Status = "A";
                objPoliza.Tipo_captura = "MC";
                objPoliza.Alta_usuario = SesionUsu.Usu_Nombre;
                objPoliza.Cheque_cuenta = string.Empty;
                objPoliza.Cheque_numero = string.Empty;
                objPoliza.Beneficiario = string.Empty;
                objPoliza.Cedula_numero = string.Empty;
                objPoliza.CFDI = "N";

                CNPoliza.PolizaInsertar(ref objPoliza, ref Verificador);
                if (Verificador == "0")
                    CNPolizaDet.PolizaDetInsertar_GC(objPoliza, Convert.ToInt32(DDLCuenta_Contable.SelectedValue), Convert.ToInt32(SesionUsu.Usu_Ejercicio), Mes,  ref Verificador);
                //if(Verificador=="0")
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

        }

        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            modal.Show();
            try
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Ctas_Bancos", ref DDLCuenta_Contable, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
                //CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Cheques", ref ddlCtaCheques, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, Convert.ToString(DDLCentro_Contable.SelectedValue));
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