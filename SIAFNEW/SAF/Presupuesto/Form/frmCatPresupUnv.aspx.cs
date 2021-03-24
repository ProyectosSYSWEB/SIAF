using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmCatPresupUnv : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        PresupUnv PresupUnv = new PresupUnv();
        List<PresupUnv> ListPresUnv = new List<PresupUnv>();
        CN_Comun CNComun = new CN_Comun();
        CN_PresupUnv CN_PresupUnv = new CN_PresupUnv();
        CN_Consultas CNConsultas = new CN_Consultas();
        #endregion        
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        private void Inicializar()
        {
            CargarCombos();
            ObtenerConsecutivoTipoOperacion("A");
            ObtenerDatosCodigoProg();
        }


        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "P_EJERCICIO", SesionUsu.Usu_Ejercicio);
                DDLCentroContab.SelectedValue = "81101";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente, "P_EJERCICIO", SesionUsu.Usu_Ejercicio);
                DDLFuente.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Ctx_Dp01", ref DDLCodProg, "p_centro_contable", "p_funcion", DDLCentroContab.SelectedValue, DDLFuente.SelectedValue);                                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLFuente_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Ctx_Dp01", ref DDLCodProg, "p_centro_contable", "p_funcion", DDLCentroContab.SelectedValue, DDLFuente.SelectedValue);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLCodProg_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ObtenerDatosCodigoProg();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void ObtenerDatosCodigoProg()
        {
            try
            {
                string Verificador = string.Empty;
                PresupUnv.Codigo_Programatico = DDLCodProg.SelectedValue;
                CN_PresupUnv.ObtenerDatosCodProg(ref PresupUnv, ref Verificador);
                txtCentroContab.Text = PresupUnv.Centro_Contable;
                txtDependencia.Text = PresupUnv.Dependencia;
                txtPrograma.Text = PresupUnv.Programa;
                txtSubProg.Text = PresupUnv.Subprograma;
                txtPartida.Text = PresupUnv.Partida;
                txtFuente.Text = PresupUnv.Fuente;
                txtProyecto.Text = PresupUnv.Proyecto;
                //txtTipoGasto.Text = PresupUnv.Tipo_Gasto;
                //txtDigMinis.Text = PresupUnv.Dig_Ministrado;
                txtFuncion.Text = PresupUnv.Funcion;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void ObtenerConsecutivoTipoOperacion(string TipoOperacion)
        {
            try
            {
                string Verificador = string.Empty;
                PresupUnv.TipoOper = "AC";
                PresupUnv.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_PresupUnv.ObtenerConsecutivoTipoOperacion(ref PresupUnv, ref Verificador);
                txtConsecutivoOpe.Text =  Convert.ToString(PresupUnv.Id);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLTipoRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Verificador = string.Empty;
                PresupUnv.TipoOper = DDLTipoRec.SelectedValue;
                PresupUnv.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_PresupUnv.ObtenerConsecutivoTipoOperacion(ref PresupUnv, ref Verificador);
                txtConsecutivoOpe.Text = Convert.ToString(PresupUnv.Id);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNGuardarPres_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    string Verificador = string.Empty;
                    string Dependencia = txtDependencia.Text;
                    PresupUnv objPresUnv = new PresupUnv();
                    objPresUnv.TipoPres = DDLTipoRec.SelectedValue;
                    objPresUnv.DependOrig = "99999"; //Agregar
                    objPresUnv.Dep_Origen = txtNombDepOrigen.Text; // Agregar
                    objPresUnv.Ref_Docto = txtRefDocto.Text;
                    objPresUnv.Fecha_Doc = txtfechaDocumento.Text;
                    objPresUnv.Concepto = txtConcepto.Text;
                    objPresUnv.Autorizado = txtImporte.Text;
                    objPresUnv.Mes = txtMes.Text;
                    objPresUnv.TipoOper = DDLTipoOperacion.Text;
                    objPresUnv.C_Contab = DDLCentroContab.SelectedValue;
                    objPresUnv.Depend = Dependencia.Substring(0, 5);
                    objPresUnv.Cod_Programatico = DDLCodProg.SelectedValue;
                    objPresUnv.Fecha_Oper = txtfechaDocumento.Text;
                    objPresUnv.Fecha_Captura = txtfechaDocumento.Text;
                    objPresUnv.Fecha_Aplicacion = txtfechaDocumento.Text;
                    objPresUnv.Stat_Contab = "S";
                    objPresUnv.Estat_Reg = "A";
                    objPresUnv.Estat_Oper = "2";
                    CN_PresupUnv.Insertar_PresupUnv(ref objPresUnv, ref Verificador);
                    if (Verificador == "0")
                        lblError.Text = "Se guardo correctamente";
                    else if (Verificador == "1")
                        lblError.Text = "Este código ya existe";
                    else
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene los privilegios para realizar esta acción";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}