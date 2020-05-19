using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Data;
using System.Web.UI;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Poliza_Det
    {
        public void PolizaDetConsultaGrid(ref Poliza_Detalle ObjPolizaDet, ref List<Poliza_Detalle> List)
        {
            try
            {
                CD_Poliza_Det CDPolizaDet = new CD_Poliza_Det();
                CDPolizaDet.PolizaDetConsultaGrid(ref ObjPolizaDet, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaDetInsertar(List<Poliza_Detalle> List, Int32 IdPoliza, /*GridView grv,*/ ref string Verificador)
        {
            try
            {
                CD_Poliza_Det CDPolizaDet = new CD_Poliza_Det();
                CDPolizaDet.PolizaDetInsertar(List, IdPoliza, /*grv,*/ ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PolizaDetInsertar_GC(Poliza objPoliza, int idCtaCont, int Ejercicio,int Mes, ref string Verificador)
        {
            try
            {
                CD_Poliza_Det CDPolizaDet = new CD_Poliza_Det();
                CDPolizaDet.PolizaDetInsertar_GC(objPoliza, idCtaCont, Ejercicio, Mes, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
