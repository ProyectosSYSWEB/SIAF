﻿using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmCatalogoPartidas : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Partida CN_Partida = new CN_Partida();
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
        }


        protected void CargarCombos()
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref DDLCapt, "p_nivel", "1");
            DDLCapt.SelectedValue = "1";
            string Capitulo = DDLCapt.SelectedValue;
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubCapitulo", ref DDLSubcap, "p_capitulo", "p_nivel", Capitulo.Substring(0, 1), "2");
            DDLSubcap.SelectedValue = "1";
            string SubCapitulo = DDLSubcap.SelectedValue;
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubSubCapitulo", ref DDLSubsubcap, "p_Subcapitulo", "p_nivel", SubCapitulo.Substring(0, 2), "3");            
        }
        protected void BTNGuardarPartida_Click(object sender, EventArgs e)
        {
            try
            {
                Partidas objPartidas = new Partidas();
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    objPartidas.Partida = txtPartida.Text;
                    objPartidas.Descrip = txtPartida.Text;
                    objPartidas.Estatus = "A";
                    string Verificador = string.Empty;
                    CN_Partida.InsertarPartida(ref objPartidas, ref Verificador);
                }
                else
                    lblError.Text = lblError.Text = "No tiene los privilegios para realizar esta acción";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLCapt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Capitulo = DDLCapt.SelectedValue;
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubCapitulo", ref DDLSubcap, "p_capitulo", "p_nivel", Capitulo.Substring(0, 1), "2");
        }

        protected void DDLSubcap_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SubCapitulo = DDLSubcap.SelectedValue;
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubSubCapitulo", ref DDLSubsubcap, "p_Subcapitulo", "p_nivel", SubCapitulo.Substring(0, 2), "3");            
        }

        protected void DDLSubsubcap_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Partida = DDLSubsubcap.SelectedValue;
            txtPartida.Text = Partida.Substring(0, 3);
        }
    }
}