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

namespace SAF.Patrimonio.Form
{
    public partial class frmTitulares : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Comun Comun = new Comun();
        Mnu mnu = new Mnu();
        CN_Comun CNComun = new CN_Comun();
        CN_Titulares CNtitulares = new CN_Titulares();
        Titulares ObjTitulares = new Titulares();
        Int32[] Celdas = new Int32[] { 0 };
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
        protected void inicializar()
        {            
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref ddlDependencia, "P_USUARIO", SesionUsu.Usu_Nombre);
            CargarGrid();
            MultiView1.ActiveViewIndex = 0;
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                grvTitular.DataSource = dt;
                grvTitular.DataSource = GetList();
                grvTitular.DataBind();
                Celdas = new Int32[] { 0,1,2,3,4 };
                if (grvTitular.Rows.Count > 0)
                {
                    CNComun.HideColumns(grvTitular, Celdas);
                }
                    
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Titulares> GetList()
        {
            try
            {
                List<Titulares> List = new List<Titulares>();
                ObjTitulares.Dependencia = ddlDependencia.SelectedValue;         
                CNtitulares.ConsultarTitulares(ref ObjTitulares, txtbusca.Text, ref List);


                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void GuardarDatos()
        {
            try
            {
                lblError.Text = string.Empty;
                ObjTitulares = new Titulares();
                //Objinformativa.centro_contable = DDLCentro_Contable.SelectedValue;
                //Objinformativa.descripcion = txtobservacion.Text;
                //Objinformativa.fecha_inicial = txtFecha_inicial.Text;
                //Objinformativa.fecha_final = txtFecha_final.Text;
                //Objinformativa.status = ddl_status.SelectedValue;
                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {
                 //   CNinformativa.insertar_observaciones(ref Objinformativa, ref Verificador);
                    inicializar();
                }
                else
                {
                    //int v = grdinformativa.SelectedIndex;
                    //Objinformativa.id = grdinformativa.Rows[v].Cells[0].Text;
                   // CNinformativa.update_observaciones(ref Objinformativa, ref Verificador);
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
        //******** CREAR CADENAS******************************************************************
        //private string md5(string sPassword)
        //{
        //    System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //    byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPassword);
        //    bs = x.ComputeHash(bs);
        //    System.Text.StringBuilder s = new System.Text.StringBuilder();
        //    foreach (byte b in bs)
        //    {
        //        s.Append(b.ToString("x2").ToLower());
        //    }
        //    return s.ToString();
        //}
        //******** LLAMAR PROCEDIMIENTO CREAR CADENAS******************************************************************
        //lb1.Text = md5(lb3.Text);
        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {            
            try
            {
                
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grvTitular_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlDependencia.Enabled = false;
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref ddlResponsable, "p_dependencia","p_tipo", ddlDependencia.SelectedValue,"4");
                ddladministrador.Items.Insert(0, new ListItem ("No Tiene","NA"));
                // CNComun.LlenaCombo("Obt_Combo_Responsable", ref ddlResponsable , "p_dependencia", "P_TIPO_PERSONAL", ddlDependencia.SelectedValue,"T");
                //CNComun.LlenaCombo("Obt_Combo_Responsable", ref ddladministrador, "p_dependencia", ddlDependencia.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref ddladministrador, "p_dependencia", "p_tipo", ddlDependencia.SelectedValue, "4");
                ddlResponsable.Items.Insert(0, new ListItem("No Tiene", "NA"));
                lblError.Text = string.Empty;
                MultiView1.ActiveViewIndex = 1;
                SesionUsu.Editar = 1;
                int v = grvTitular.SelectedIndex;
                ObjTitulares.Id= grvTitular.Rows[v].Cells[0].Text;
                txtPuesto_res.Text = grvTitular.Rows[v].Cells[3].Text;
                txtPuesto_adm.Text = grvTitular.Rows[v].Cells[4].Text;
                if (grvTitular.Rows[v].Cells[1].Text == "1")
                {
                    ddlResponsable.SelectedValue = "NA";
                }
                else
                {
                    ddlResponsable.SelectedValue = grvTitular.Rows[v].Cells[1].Text;
                }
                if (grvTitular.Rows[v].Cells[1].Text == "1")
                {
                    ddladministrador.SelectedValue = "NA";
                }
                else
                {
                    ddladministrador.SelectedValue = grvTitular.Rows[v].Cells[2].Text;
                }
                
                
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                int v = grvTitular.SelectedIndex;
                ObjTitulares.Id = grvTitular.Rows[v].Cells[0].Text;
                ObjTitulares.Responsable = ddlResponsable.SelectedItem.ToString();
                ObjTitulares.Administrador = ddladministrador.SelectedItem.ToString();
                ObjTitulares.Puesto_Resp = txtPuesto_res.Text;
                ObjTitulares.Puesto_Admin = txtPuesto_adm.Text;
                ObjTitulares.Id_Responsable = ddlResponsable.SelectedValue;
                ObjTitulares.Id_Administrador = ddladministrador.SelectedValue;
                CNtitulares.update_Titulares(ref ObjTitulares, ref Verificador);
                MultiView1.ActiveViewIndex = 0;
                ddlDependencia.Enabled = true;
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            ddlDependencia.Enabled = true;
        }
    }
}