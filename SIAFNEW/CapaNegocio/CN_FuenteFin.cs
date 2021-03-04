using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_FuenteFin
    {
        public void FuentesGrid(ref FuentesFin objFuentesFin, ref List<FuentesFin> List)
        {
            try
            {
                CD_FuenteFin CD_FuenteFin = new CD_FuenteFin();
                CD_FuenteFin.FuentesGrid(ref objFuentesFin, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void InsertarFuente(ref FuentesFin objFuentesFin, ref string Verificador)
        {
            try
            {
                CD_FuenteFin CD_FuenteFin = new CD_FuenteFin();
                CD_FuenteFin.InsertarFuente(ref objFuentesFin, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
