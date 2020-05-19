using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Poliza_CFDI
    {
        public void PolizaCFDIInsertar(Poliza_CFDI objPolizaCFDI, List<Poliza_CFDI> lstPolizasCFDI, ref string Verificador)
        {
            try
            {
                CD_Poliza_CFDI CDPolizaCFDI = new CD_Poliza_CFDI();
                CDPolizaCFDI.PolizaCFDIInsertar(objPolizaCFDI, lstPolizasCFDI, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaCFDIEditar(Poliza_CFDI objPolizaCFDI, List<Poliza_CFDI> lstPolizasCFDI, ref string Verificador)
        {
            try
            {
                CD_Poliza_CFDI CDPolizaCFDI = new CD_Poliza_CFDI();
                CDPolizaCFDI.PolizaCFDIEditar(objPolizaCFDI, lstPolizasCFDI, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaCFDIConsultaDatos(Poliza_CFDI objPolizaCFDI, ref List<Poliza_CFDI> lstPolizasCFDI, ref string Verificador)
        {
            try
            {
                CD_Poliza_CFDI CDPolizaCFDI = new CD_Poliza_CFDI();
                CDPolizaCFDI.PolizaCFDIConsultaDatos(objPolizaCFDI, ref lstPolizasCFDI, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void PolizaCFDIConsultaDatosAdmin(Poliza_CFDI objPolizaCFDI, ref List<Poliza_CFDI> lstPolizasCFDI, string Buscar)
        {
            try
            {
                CD_Poliza_CFDI CDPolizaCFDI = new CD_Poliza_CFDI();
                CDPolizaCFDI.PolizaCFDIConsultaDatosAdmin(objPolizaCFDI, ref lstPolizasCFDI, Buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
