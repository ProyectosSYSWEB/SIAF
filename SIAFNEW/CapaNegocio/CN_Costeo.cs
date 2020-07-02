using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Costeo
    {
        public void Sel_tabulador(ref Pres_Costeo objcosteo, ref string Verificador)
        {
            try
            {
                CD_Costeo CDCosteo = new CD_Costeo();
                CDCosteo.Sel_tabulador(ref objcosteo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
