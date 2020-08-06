using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;
using System.Xml;
using CapaEntidad;


namespace CapaDatos
{
    public class CD_Mnu
    {
        public void LlenarMenus(ref Menu MenuT, ref Mnu mnu)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { 
                                        "p_usuario",
                                        "p_grupo", 
                                      };
                object[] Valores = { 
                                        mnu.UsuarioNombre  ,   
                                        mnu.Grupo,  
                                   };
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref dr, Parametros, Valores);

                MenuItem m1 = new MenuItem("Inicio", "0", "", "index.aspx");
                MenuT.Items.Add(m1);

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        MenuItem mnuMenuItem = new MenuItem();

                        if (dr["padre"].ToString() == string.Empty)
                        {
                            mnuMenuItem.Value = dr["id"].ToString();
                            mnuMenuItem.Text = dr["descripcion"].ToString();
                            mnuMenuItem.NavigateUrl = dr["clave"].ToString();
                            MenuT.Items.Add(mnuMenuItem);
                            AddMenuItem(mnuMenuItem, ref mnu);
                        }
                    }
                    m1 = new MenuItem("Salir", "0", "", "Acceso.aspx");
                    MenuT.Items.Add(m1);
                    dr.Close();
                }


            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        protected void AddMenuItem(MenuItem mnuItem, ref Mnu mnu)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader reader = null;


                string[] Parametros = { 
                                        "p_usuario",
                                        "p_grupo", 
                                      };
                object[] Valores = { 
                                        mnu.UsuarioNombre,   
                                        mnu.Grupo,  
                                   };
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref reader, Parametros, Valores);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuItem mnuNewMenuItem = new MenuItem();
                        if (reader["id_padre"].ToString().Equals(mnuItem.Value))
                        {
                            mnuNewMenuItem.Value = reader["id"].ToString();
                            mnuNewMenuItem.Text = reader["descripcion"].ToString();
                            mnuNewMenuItem.NavigateUrl = reader["clave"].ToString();
                            mnuItem.ChildItems.Add(mnuNewMenuItem);
                            AddMenuItem(mnuNewMenuItem, ref mnu);
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void LlenarTree(ref TreeView Arbolito, Presupues objPresupuesto, List<Presupues> List)
        {

            try
            {
                #region <Variables>
                string valor = string.Empty;
                string descripcion = string.Empty;
                #endregion

                OracleDataReader dr = null;
                CD_Datos CDDatos = new CD_Datos();

                string[] Parametros = {                                         
                                        "p_Ejercicio", 
                                      };
                object[] Valores = {objPresupuesto.Ejercicio,  
                                   };
                OracleCommand Cmd = CDDatos.GenerarOracleCommandCursor("PKG_CONTABILIDAD.Obt_Tree_Presupuesto", ref dr, Parametros, Valores);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objPresupuesto = new Presupues();
                        objPresupuesto.Id = Convert.ToString(dr["id"].ToString());
                        if (Convert.ToString(dr["nivel"].ToString()) != "1")
                            objPresupuesto.Padre = Convert.ToString(dr["padre"].ToString());
                        else
                            objPresupuesto.Padre = "0";

                        objPresupuesto.Descripcion = dr["descripcion"].ToString();
                        objPresupuesto.Nivel = Convert.ToInt32(dr["nivel"].ToString());
                        List.Add(objPresupuesto);
                        //TreeNode nodoPadre = new TreeNode();
                        //nodoPadre.Collapse();
                        //valor = dr["id"].ToString();
                        //descripcion = dr["TIPO"].ToString() + " - " + dr["descripcion"].ToString();
                        //importes = dr["IMPORTES"].ToString();                        
                    }
                    BindTree(List, null, Arbolito);
                    dr.Close();
                }

                CDDatos.LimpiarOracleCommand(ref Cmd);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenarTree2(ref TreeView Arbolito, Mnu mnu, List<Mnu> List)
        {

            try
            {
                #region <Variables>
                string valor = string.Empty;
                string descripcion = string.Empty;
                #endregion

                OracleDataReader dr = null;
                CD_Datos CDDatos = new CD_Datos();
                string[] Parametros = { "p_usuario", "p_grupo", "p_id_padre" };
                object[] Valores = { mnu.UsuarioNombre, mnu.Grupo, mnu.IdPadre };

                OracleCommand Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref dr, Parametros, Valores);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mnu = new Mnu();
                        mnu.Id = Convert.ToInt32(dr["id"].ToString());
                        mnu.Padre = Convert.ToString(dr["id_padre"].ToString());
                        mnu.Descripcion = dr["descripcion"].ToString();
                        mnu.Clave = dr["clave"].ToString();
                        List.Add(mnu);

                    }
                    //BindTreeDef(List, null, Arbolito);
                    dr.Close();
                }

                CDDatos.LimpiarOracleCommand(ref Cmd);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LlenarTreeDef(Mnu mnu, List<Mnu> List)
        {

            try
            {
                #region <Variables>
                string valor = string.Empty;
                string descripcion = string.Empty;
                #endregion

                OracleDataReader dr = null;
                CD_Datos CDDatos = new CD_Datos();

                string[] Parametros = { "p_usuario", "p_grupo", "p_id_padre" };
                object[] Valores = { mnu.UsuarioNombre, mnu.Grupo, mnu.IdPadre };

                OracleCommand Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref dr, Parametros, Valores);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mnu = new Mnu();
                        mnu.Id = Convert.ToInt32(dr["id"].ToString());
                        mnu.Padre = Convert.ToString(dr["id_padre"].ToString());
                        mnu.Descripcion = dr["descripcion"].ToString();
                        mnu.Clave = dr["clave"].ToString();
                        List.Add(mnu);
                                    
                    }
                    //BindTreeDef(List, null, Arbolito);
                    dr.Close();
                }

                CDDatos.LimpiarOracleCommand(ref Cmd);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void BindTreeDef(IEnumerable<Mnu> list, TreeNode parentNode, TreeView tree)
        {
            var nodes = list.Where(x => parentNode == null ? x.Padre == "0" : x.Padre == parentNode.Value);
            //    products.Where(p => categories
            //.Any(cat => p.Categories.Any(pcat => pcat.Id == cat.Id)).ToList();
            foreach (var node in nodes)
            {
                TreeNode newNode = new TreeNode(node.Descripcion, node.Id.ToString());
                if (parentNode == null)
                {
                    tree.Nodes.Add(newNode);
                    newNode.Selected = true;
                    //tree.ExpandAll();
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                    parentNode.Collapse();
                }
                BindTreeDef(list, newNode, tree);
            }
        }

        private void BindTree(IEnumerable<Presupues> list, TreeNode parentNode, TreeView tree)
        {
            var nodes = list.Where(x => parentNode == null ? x.Padre == "0" : x.Padre == parentNode.Value);
            //    products.Where(p => categories
            //.Any(cat => p.Categories.Any(pcat => pcat.Id == cat.Id)).ToList();
            foreach (var node in nodes)
            {
                TreeNode newNode = new TreeNode(node.Descripcion, node.Id.ToString());
                if (parentNode == null)
                {
                    tree.Nodes.Add(newNode);
                    newNode.Selected = true;
                    //tree.ExpandAll();
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                    parentNode.Collapse();
                }
                BindTree(list, newNode, tree);
            }
        }

        public void GenerateXMLFile(Mnu mnu, string fullPath)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            //Create XML
            Encoding enc = Encoding.UTF8;
            XmlTextWriter objXMLTW = new XmlTextWriter(fullPath, enc);
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_usuario", "p_grupo" };
                object[] Valores = { mnu.UsuarioNombre, mnu.Grupo };
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref dr, Parametros, Valores);
                if (dr.HasRows)
                {

                    objXMLTW.WriteStartDocument();//xml document open
                    //'Top level (Parent element)
                    //root node open
                    objXMLTW.WriteStartElement("siteMap");
                    //first Node of the Menu open
                    objXMLTW.WriteStartElement("siteMapNode");
                    //Title attribute set
                    objXMLTW.WriteAttributeString("title", "INICIO");
                    objXMLTW.WriteAttributeString("description", "INICIO");//Description attribute set
                    objXMLTW.WriteAttributeString("url", "Default.aspx");//URL attribu

                    while (dr.Read())
                    {
                        if (dr["padre"].ToString() == string.Empty)
                        {
                            int MasterID = Convert.ToInt32(dr["id"].ToString());
                            objXMLTW.WriteStartElement("siteMapNode");
                            objXMLTW.WriteAttributeString("title", dr["descripcion"].ToString().ToUpper());
                            objXMLTW.WriteAttributeString("description", dr["descripcion"].ToString().ToUpper());
                            if (dr["clave"].ToString().Contains(".aspx"))
                                objXMLTW.WriteAttributeString("url", dr["clave"].ToString());
                            else                                
                                objXMLTW.WriteAttributeString("url", "Default.aspx?cve=" + dr["id"].ToString());

                            

                            //objXMLTW.WriteAttributeString("url", dr["clave"].ToString());
                            ChildMaster(objXMLTW, mnu, MasterID);
                            objXMLTW.WriteEndElement();
                        }
                    }
                    dr.Close();

                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "CAMBIO DE CONTRASEÑA");
                    objXMLTW.WriteAttributeString("description", "PASSWORD");
                    objXMLTW.WriteAttributeString("url", "https://ldapauthmaster.unach.mx/pssform_resetaccount.php");
                    objXMLTW.WriteEndElement();

                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "AYUDA");
                    objXMLTW.WriteAttributeString("description", "AYUDA");
                    objXMLTW.WriteAttributeString("url", "http://sysweb.unach.mx/saf/Manual_Usuario.pdf");
                    objXMLTW.WriteEndElement();

                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "SALIR");
                    objXMLTW.WriteAttributeString("description", "SALIR");
                    objXMLTW.WriteAttributeString("url", "Acceso.aspx");
                    objXMLTW.WriteEndElement();

                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteEndDocument();
                }

                //Close the siteMapNode        
                //objXMLTW.WriteEndElement();//Close the first siteMapNode
                //objXMLTW.WriteEndDocument();//xml document closed
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objXMLTW.Flush();
                objXMLTW.Close();
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        protected void ChildMaster(XmlTextWriter objXMLTW, Mnu mnu, Int32 Id)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            string url;
            try
            {
                OracleDataReader reader = null;
                string[] Parametros = { "p_usuario","p_grupo"};
                object[] Valores = {mnu.UsuarioNombre,mnu.Grupo};
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref reader, Parametros, Valores);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ChildMasterID = Convert.ToInt32(reader["id"].ToString());
                        if (Convert.ToInt32(reader["id_padre"].ToString())== Id)
                        {
                            objXMLTW.WriteStartElement("siteMapNode");
                            objXMLTW.WriteAttributeString("title", reader["descripcion"].ToString());
                            objXMLTW.WriteAttributeString("description", reader["descripcion"].ToString());
                            if (reader["clave"].ToString().Contains(".aspx"))
                                objXMLTW.WriteAttributeString("url", reader["clave"].ToString());
                            else                                
                                objXMLTW.WriteAttributeString("url", "Default.aspx?cve=" + reader["id"].ToString());

                            //if (reader["clave"].ToString().Contains("Monitor"))
                            //    objXMLTW.WriteAttributeString("url", reader["clave"].ToString()+"?mnt=001");

                            //ddMenuItem(mnuNewMenuItem, ref mnu);
                            ChildMaster(objXMLTW, mnu, ChildMasterID);
                            objXMLTW.WriteEndElement();
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
    }
}

