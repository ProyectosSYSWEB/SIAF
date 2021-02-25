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
    }
}
