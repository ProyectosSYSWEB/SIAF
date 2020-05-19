using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Transferencia_Det
    {
        public void TransferenciaDetInsertar(List<Transferencia_Detalle> List, Int32 IdTransferencia, ref string Verificador)
        {
            try
            {
                CD_Transferencia_Det CDTransferenciaDet = new CD_Transferencia_Det();
                CDTransferenciaDet.TransferenciaDetInsertar(List, IdTransferencia, /*grv,*/ ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void TransferenciaDetConsultaGrid(ref Transferencia_Detalle ObjTransferenciaDet, ref List<Transferencia_Detalle> List)
        {
            try
            {
                CD_Transferencia_Det CDTransDet = new CD_Transferencia_Det();
                CDTransDet.TransferenciaDetConsultaGrid(ref ObjTransferenciaDet, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
