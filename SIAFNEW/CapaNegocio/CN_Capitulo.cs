using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Capitulo
    {
        public void CapitulosGrid(ref Basicos objBasicos, ref List<Basicos> List)
        {
            try
            {
                CD_Capitulos CD_Capitulos = new CD_Capitulos();
                CD_Capitulos.CapitulosGrid(ref objBasicos, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
