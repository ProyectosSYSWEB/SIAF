﻿using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF
{
    public partial class Default : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Comun Comun = new Comun();
        Mnu mnu = new Mnu();
        CN_Mnu CNMnu = new CN_Mnu();
        CN_Comun CNMonitor = new CN_Comun();
        CN_Comun CNComun = new CN_Comun();
        CN_Informativa CNInformativa = new CN_Informativa();
        cuentas_contables Objinformativa = new cuentas_contables();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //busca_informativa();
                Inicializar();
                if (Request.QueryString["mnu"] != null)
                {
                    SesionUsu.Usu_Rep = Request.QueryString["mnu"];
                    Mnu objMenu = new Mnu();
                    objMenu.UsuarioNombre = SesionUsu.Usu_Nombre;
                    objMenu.Grupo = 15939;
                    objMenu.Padre = SesionUsu.Usu_Rep;
                    List<Mnu> List = new List<Mnu>();
                    CNMnu.LlenarTree(ref trvMenu, objMenu, ref List);
                    trvMenu.ExpandAll();
                    //imgTipoMenu.ImageUrl = "~/images/"+ SesionUsu.Usu_Rep + ".png";
                    if (SesionUsu.Usu_Rep == "REP")
                    {
                        divEspecificaciones.Visible = true;
                        lblEncEspecificaciones.Text = "Reportes";
                        lblEspecificaciones.Text = "Para que puedas usar adecuadamente los reportes, necesitas tener habilitadas las ventanas emergentes.";
                    }
                    else if(SesionUsu.Usu_Rep == "MOV")
                    {
                        divEspecificaciones.Visible = true;
                        lblEncEspecificaciones.Text = "Movimientos";
                        lblEspecificaciones.Text = "Registro y seguimiento del gasto realizado de acuerdo con el presupuesto de egresos asignado.";
                    }
                    else
                        divEspecificaciones.Visible = false;
                }

                else
                {
                    MenuArbol();
                    divEspecificaciones.Visible = false;

                }
            }
        }
        private void Inicializar()
        {
            //MenuArbol();
            //MonitorConsultaGrid(grvAvances1, 1);
            //MonitorConsultaGrid(grvAvances2, 2);
            //MonitorConsultaGrid(grvAvances3, 3);
            //MonitorConsultaGrid(grvAvances4, 4);
            //MonitorConsultaGrid(grvAvances5, 5);
            //MonitorConsultaGrid(grvAvances6, 6);
            //MultiView1.ActiveViewIndex = 1;
            //ConsultaChart();
            // MultiView1.ActiveViewIndex = 0;
            //ConsultaGrid();
        }
        private void busca_informativa()
        {
            try
            {
                lblMensaje.Text = string.Empty;
                Objinformativa.usuario = SesionUsu.Usu_Nombre;
                Objinformativa.ejercicio = SesionUsu.Usu_Ejercicio;
                CNInformativa.Consultar_Observaciones(ref Objinformativa, ref Verificador);

                if (Verificador == "0")
                {
                    if (Objinformativa.observaciones.Length > 1)
                    {
                        lblMsg_Observaciones.Text = Objinformativa.observaciones;
                        ModalPopupExtender.Show();
                    }
                }
                else
                {
                    lblMensaje.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }
        private void MenuArbol()
        {
            lblMensaje.Text = string.Empty;
            try
            {
                mnu.NombreMenu = "MenuTop";
                mnu.UsuarioNombre = SesionUsu.Usu_Nombre;
                mnu.Grupo = 15939;
                string siteMap = "ArchivosMenu/Web" + SesionUsu.Usu_Nombre + ".sitemap";
                string fullPath = Path.Combine(Server.MapPath("~"), siteMap);
                if (!File.Exists(fullPath))
                {
                    CNMnu.GenerateXMLFile(mnu, fullPath);
                }

                XmlSiteMapProvider testXmlProvider = new XmlSiteMapProvider();
                NameValueCollection providerAttributes = new NameValueCollection(1);
                providerAttributes.Add("siteMapFile", siteMap);
                testXmlProvider.Initialize("MyXmlSiteMapProvider", providerAttributes);
                testXmlProvider.BuildSiteMap();
                SiteMapDataSource smd = new SiteMapDataSource();
                smd.Provider = testXmlProvider;
                trvMenu.DataSource = smd;
                trvMenu.DataBind();
                trvMenu.CollapseAll();
                trvMenu.Nodes[0].Expanded = true;



                //trvMenu.Nodes[1].Expanded = true;                
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            ModalPopupExtender.Hide();
        }
    }
}