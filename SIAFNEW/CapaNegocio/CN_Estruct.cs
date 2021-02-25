using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Estruct
    {
        public void EstructGrid(ref Estruct objEstruct, ref List<Estruct> List)
        {
            try
            {
                CD_Estruct CD_Estruct = new CD_Estruct();
                CD_Estruct.EstructGrid(ref objEstruct, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
