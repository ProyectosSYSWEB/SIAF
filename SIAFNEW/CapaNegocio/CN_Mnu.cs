using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_Mnu
    {
        public void GenerateXMLFile(Mnu mnu, string fullPath)
        {
            try
            {
                CD_Mnu CDMnu = new CD_Mnu();
                CDMnu.GenerateXMLFile(mnu, fullPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenarMenus(ref Menu MenuT, ref Mnu mnu)
        {
            try
            {
                CD_Mnu CDMnu = new CD_Mnu();
                CDMnu.LlenarMenus(ref  MenuT, ref mnu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenarTree(ref TreeView Arbol, Presupues objPresupuesto, List<Presupues> List)
        {
            try
            {
                CD_Mnu CDMnu = new CD_Mnu();
                CDMnu.LlenarTree(ref  Arbol, objPresupuesto, List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
