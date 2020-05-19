using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Transferencia
    {
        public void TransferenciaConsultaGrid(ref Transferencia ObjTransferencia, String FechaInicial, String FechaFinal, String Buscar, ref List<Transferencia> List)
        {
            try
            {
                CD_Transferencia CDTransferencia = new CD_Transferencia();
                CDTransferencia.TransferenciaConsultaGrid(ref ObjTransferencia, FechaInicial, FechaFinal, Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void TransferenciaInsertar(ref Transferencia ObjTransferencia, ref string Verificador)
        {
            try
            {
                CD_Transferencia CDTransferencia = new CD_Transferencia();
                CDTransferencia.TransferenciaInsertar(ref ObjTransferencia, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void TransferenciaEditar(Transferencia ObjTransferencia, ref string Verificador)
        {
            try
            {
                CD_Transferencia CDTransferencia = new CD_Transferencia();
                CDTransferencia.TransferenciaEditar(ObjTransferencia, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void TransferenciaEditarStatus(ref Transferencia ObjTransferencia, ref string Verificador)
        {
            try
            {
                CD_Transferencia CDTransferencia = new CD_Transferencia();
                CDTransferencia.TransferenciaEditarStatus(ref ObjTransferencia, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void TransferenciaConsultaDatos(ref Transferencia ObjTransferencia, ref string Verificador)
        {
            try
            {
                CD_Transferencia CDTransferencia = new CD_Transferencia();
                CDTransferencia.TransferenciaConsultaDatos(ref ObjTransferencia, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void TransferenciaEliminar(Transferencia ObjTransferencia, ref string Verificador)
        {
            try
            {
                CD_Transferencia CDTransferencia = new CD_Transferencia();
                CDTransferencia.TransferenciaEliminar(ObjTransferencia, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
