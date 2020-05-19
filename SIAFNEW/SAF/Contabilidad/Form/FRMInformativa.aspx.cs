using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Contabilidad.Form
{
    public partial class FRMInformativa : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Comun Comun = new Comun();
        Mnu mnu = new Mnu();
        CN_Comun CNComun = new CN_Comun();
        CN_Informativa  CNinformativa = new CN_Informativa();
        cuentas_contables Objinformativa = new cuentas_contables();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                MultiView1.ActiveViewIndex = 0;
                inicializar();
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                grdinformativa.DataSource = dt;
                grdinformativa.DataSource = GetList();
                grdinformativa.DataBind();

            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }
        private List<cuentas_contables> GetList()
        {
            try
            {
                List<cuentas_contables> List = new List<cuentas_contables>();
                Objinformativa.centro_contable = DDLCentro_Contable.SelectedValue ;
                Objinformativa.usuario  = SesionUsu.Usu_Nombre;                
                CNinformativa.ConsultarInformativa(ref Objinformativa, txtbusca.Text, ref List);
                

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void limpiar()
        {
            txtbusca.Text = string.Empty;
            txtobservacion.Text = string.Empty;
            txtFecha_final.Text = string.Empty;
            txtFecha_inicial.Text = string.Empty;

        }

        protected void inicializar()
        {
            limpiar();
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "P_USUARIO", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
            CargarGrid();
            MultiView1.ActiveViewIndex = 0;
        }
        
        protected void ddlcentro_contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }    

        protected void BTN_Guardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        protected void lbtnagregar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
               lblError.Text = string.Empty; 
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grdinformativa.SelectedIndex = row.RowIndex;
                Objinformativa.id   = grdinformativa.SelectedRow.Cells[0].Text;
                
                CNinformativa.Delete_Observaciones_edit(ref Objinformativa, ref Verificador);

                if (Verificador == "0")
                {
                    inicializar();
                }
                else
                {
                   lblError.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }

        protected void grdinformativa_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
               lblError.Text = string.Empty;
                MultiView1.ActiveViewIndex = 1;
                SesionUsu.Editar = 1;
                int v = grdinformativa.SelectedIndex;
                Objinformativa.id = grdinformativa.Rows[v].Cells[0].Text;               
                CNinformativa.Consultar_Observaciones_edit(ref Objinformativa , ref Verificador);

                if (Verificador == "0")
                {

                    DDLCentro_Contable.SelectedValue = Objinformativa.centro_contable;
                    txtobservacion.Text = Objinformativa.observaciones;
                    txtFecha_inicial.Text = Objinformativa.fecha_inicial;
                    txtFecha_final.Text = Objinformativa.fecha_final;
                    ddl_status.SelectedValue = Objinformativa.status;
                }
                else
                {
                   lblError.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }

        protected void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            MultiView1.ActiveViewIndex = 0;
        }
        private void GuardarDatos()
        {
            try
            {
               lblError.Text = string.Empty;
                Objinformativa = new cuentas_contables();
                Objinformativa.centro_contable = DDLCentro_Contable.SelectedValue;
                Objinformativa.descripcion = txtobservacion.Text;
                Objinformativa.fecha_inicial = txtFecha_inicial.Text;
                Objinformativa.fecha_final = txtFecha_final.Text;
                Objinformativa.status = ddl_status.SelectedValue;    
                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {
                    CNinformativa.insertar_observaciones(ref Objinformativa, ref Verificador);
                    inicializar();
                }
                else
                {
                    int v = grdinformativa.SelectedIndex;
                    Objinformativa.id = grdinformativa.Rows[v].Cells[0].Text;      
                    CNinformativa.update_observaciones(ref Objinformativa, ref Verificador);
                    if (Verificador == "0")
                    {
                        inicializar();
                    }
                }
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            limpiar();
            MultiView1.ActiveViewIndex = 1;
            SesionUsu.Editar = 0;
        }
    }
}