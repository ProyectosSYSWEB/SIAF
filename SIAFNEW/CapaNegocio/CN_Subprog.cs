using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Subprog
    {
        public void SubprogramasGrid(ref Subprograma objSubprog, ref List<Subprograma> List)
        {
            try
            {
                CD_Subprograma CD_Subprograma = new CD_Subprograma();
                CD_Subprograma.SubprogramasGrid(ref objSubprog, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
