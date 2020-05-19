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

    public partial class frmCambiarResponsable : System.Web.UI.Page
    {

        #region <Variables>
        String Verificador = string.Empty;
        string inv_inicial = string.Empty;
        string inv_final = string.Empty;
        string responsable = string.Empty;
        string responsable_nuevo = string.Empty;
        string responsable_actual = string.Empty;
        string responsable_nombre = string.Empty;
        Sesion SesionUsu = new Sesion();       
        Bien  Objbien = new Bien();
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
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
            btnCancelar.Visible = false;
            btnAplicar.Visible = false;
            DDLMovimiento.SelectedValue = "S";
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepOrigen, "p_usuario", SesionUsu.Usu_Nombre);
            Cargarcombos();
        }
        private void Cargarcombos()
        {
            lblError.Text = string.Empty;
            try
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia", DDLDepOrigen.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsableActual, "p_dependencia", DDLDepOrigen.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsableNuevo, "p_dependencia", DDLDepOrigen.SelectedValue);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        #endregion

        #region <Botones y Eventos>
        protected void DDLMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLMovimiento.SelectedValue == "I")
            {
                MultiView1.ActiveViewIndex = 1;
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepOrigen1, "p_usuario", "00000");
                DDLDepOrigen1.SelectedValue = DDLDepOrigen.SelectedValue;
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia", DDLDepOrigen.SelectedValue);
            }
            else if (DDLMovimiento.SelectedValue == "R")
            {
                MultiView1.ActiveViewIndex = 0;
                CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDepOrigen0, "p_usuario", "00000");
                DDLDepOrigen0.SelectedValue = DDLDepOrigen.SelectedValue;
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsableNuevo, "p_dependencia", DDLDepOrigen.SelectedValue);
               
            }
            btnCancelar.Visible = true;
            btnAplicar.Visible = true;
            btnAplicar.Enabled = true;
        }
        
        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            if (DDLMovimiento.SelectedValue == "I")
                Page.Validate("Inventario");
            else if (DDLMovimiento.SelectedValue == "R")
                Page.Validate("Responsable");

            if (Page.IsValid)
            {

                lblError.Text = string.Empty;
                Verificador = string.Empty;
                //int idTrans=0;
                try
                {
                   
                    if (DDLMovimiento.SelectedValue == "I")
                    {
                        lblMsj.Text = "¿DESEA ASIGNAR LOS SIGUIENTES BIENES A: " + DDLResponsable.SelectedItem.ToString()+"?";
                    }
                    else
                    {
                        lblMsj.Text = "¿DESEA ASIGNAR LOS SIGUIENTES BIENES A: " + DDLResponsableNuevo.SelectedItem.ToString()+"?";
                    }
                    modalMensaje.Show();
                    CargarGrid();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                GrvBienes.DataSource = dt;
                GrvBienes.DataSource = GetList();
                GrvBienes.DataBind(); 
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Bien > GetList()
        {
            try
            {
                List<Bien> List = new List<Bien >();
                Objbien.Dependencia = DDLDepOrigen.SelectedValue;
                Objbien.Clave = DDLMovimiento.SelectedValue;
                Objbien.No_Inventario = txtInventario_Inicial.Text;
                Objbien.No_Inventario_fin = txtInventario_Final.Text;
                if (DDLMovimiento.SelectedValue=="I") { Objbien.Responsable = DDLResponsable.SelectedValue; } else { Objbien.Responsable = DDLResponsableActual.SelectedValue; }
               
                CNBien.Consultar_Bien_Responsable(ref Objbien, ref List);


                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            inv_inicial = txtInventario_Inicial.Text;
            inv_final = txtInventario_Final.Text;
            responsable = DDLResponsable.SelectedValue;
            responsable_actual = DDLResponsableActual.SelectedValue;
            responsable_nuevo = DDLResponsableNuevo.SelectedValue;
            lblError.Text = string.Empty;
            if (DDLMovimiento.SelectedValue == "R")
            {
                responsable_nombre = DDLResponsableNuevo.SelectedItem.ToString();
                CNBien.ActualizarResponsable(ref Verificador, DDLDepOrigen.SelectedValue, responsable_actual, responsable_nuevo, responsable_nombre, SesionUsu.Usu_Nombre, "R");
            }
            else
            {
                responsable_nombre = DDLResponsable.SelectedItem.ToString();
                CNBien.ActualizarResponsable(ref Verificador, DDLDepOrigen.SelectedValue, inv_inicial, inv_final, responsable, responsable_nombre, SesionUsu.Usu_Nombre);
            }
            if (Verificador == "0")
            {
                lblError.Text = "Los cambios se aplicaron satisfactoriamente";
               
            }
            else
                lblError.Text = Verificador;
                modalMensaje.Hide();

           
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            modalMensaje.Hide();
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {            
            DDLMovimiento.SelectedValue = "S";
            MultiView1.ActiveViewIndex = 2;
            txtInventario_Inicial.Text = string.Empty;
            txtInventario_Final.Text = string.Empty;
            btnCancelar.Visible = false;
            btnAplicar.Visible = false;
        }

        protected void DDLDepOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia", DDLDepOrigen.SelectedValue);
            DDLDepOrigen1.SelectedValue = DDLDepOrigen.SelectedValue;
            DDLDepOrigen0.SelectedValue = DDLDepOrigen.SelectedValue;
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsableNuevo, "p_dependencia", DDLDepOrigen.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsableActual, "p_dependencia", DDLDepOrigen.SelectedValue);
        }






        #endregion

        protected void DDLDepOrigen0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsableNuevo, "p_dependencia", DDLDepOrigen0.SelectedValue);
        }

        protected void DDLDepOrigen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia", DDLDepOrigen1.SelectedValue);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvBienes.PageIndex = 0;
            GrvBienes.PageIndex = e.NewPageIndex;
            CargarGrid();
            modalMensaje.Show();
        }
    }
}