using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public  class CN_Pres_Nomina
    {
        public void ConsultaGrid_Trabajador(ref Pres_Nomina objNomina, ref List<Pres_Nomina> List)
        {
            try
            {
                CD_Pres_Nomina CDDocumento = new CD_Pres_Nomina();
                CDDocumento.ConsultaGrid_Trabajador(ref objNomina, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaMovimiento_Nomina(ref Pres_Nomina objNomina, ref List<Pres_Nomina> List)
        {
            try
            {
                CD_Pres_Nomina CDDocumento = new CD_Pres_Nomina();
                CDDocumento.ConsultaMovimiento_Nomina(ref objNomina, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
