using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_CentrosContab
    {
        public void CContabGrid(ref CentrosContab objCentrosContab, ref List<CentrosContab> List)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.CContabGrid(ref objCentrosContab, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarCentroContable(ref CentrosContab objCentrosContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.InsertarCentroContable(ref objCentrosContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ObtenerDatosCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.ObtenerDatosCContab(ref objCContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.EditarCContab(ref objCContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
