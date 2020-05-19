using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Pres_Documento_Det
    {
        public void DocumentoDetInsertar(List<Pres_Documento_Detalle> List, Int32 IdDoc, ref string Verificador)
        {
            try
            {
                CD_Pres_Documento_Det CDDocDet= new CD_Pres_Documento_Det();
                CDDocDet.DocumentoDetInsertar(List, IdDoc, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtDisponibleCodigoProg(Pres_Documento_Detalle objDocDet, ref string Verificador)
        {
            try
            {
                CD_Pres_Documento_Det CDDocDet = new CD_Pres_Documento_Det();
                CDDocDet.ObtDisponibleCodigoProg(objDocDet, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DocumentoDetConsultaGrid(ref Pres_Documento_Detalle objDocDet, ref List<Pres_Documento_Detalle> List)
        {
            try
            {
                CD_Pres_Documento_Det CDDocDet = new CD_Pres_Documento_Det();
                CDDocDet.DocumentoDetConsultaGrid(ref objDocDet, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
