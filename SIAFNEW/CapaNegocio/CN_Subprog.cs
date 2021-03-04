using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

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

        public void InsertarSubPrograma(ref Basicos objBasicos, ref string Verificador)
        {
            try
            {

                CD_Subprograma CD_Subprograma = new CD_Subprograma();
                CD_Subprograma.InsertarSubPrograma(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
