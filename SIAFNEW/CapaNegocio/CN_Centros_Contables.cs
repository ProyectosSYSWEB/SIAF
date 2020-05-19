using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Centros_Contables
    {
        public void Control_CierreConsultaGrid(ref Centros_Contables ObjControl_Cierre, ref List<Centros_Contables> List)
        {
            try
            {

                CD_Centros_Contables CDCentros_Contables = new CD_Centros_Contables();
                CDCentros_Contables.Control_CierreConsultaGrid(ref ObjControl_Cierre, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Control_CierreEditar(ref Centros_Contables ObjCentros_Contables, ref string Verificador)
        {
            CD_Centros_Contables CDCentros_Contables = new CD_Centros_Contables();
            CDCentros_Contables.Control_CierreEditar(ref ObjCentros_Contables, ref Verificador);
        }
        public void Control_CierreGral(ref Centros_Contables ObjControl_Cierre, string Tipo, ref string Verificador)
        {
            CD_Centros_Contables CDControl_Cierre = new CD_Centros_Contables();
            CDControl_Cierre.Control_CierreGral(ref ObjControl_Cierre, Tipo, ref Verificador);
        }
    }
}
