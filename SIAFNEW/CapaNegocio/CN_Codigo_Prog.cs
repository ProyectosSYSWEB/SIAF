using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Codigo_Prog
    {        
        public void CodigoProgGrid(ref Codigo_Prog objCodProg, ref List<Codigo_Prog> List)
        {
            try
            {
                CD_Codigo_Prog CD_Codigo_Prog = new CD_Codigo_Prog();
                CD_Codigo_Prog.CodigoProgGrid(ref objCodProg, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
