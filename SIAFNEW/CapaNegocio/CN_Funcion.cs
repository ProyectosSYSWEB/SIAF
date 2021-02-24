using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Funcion
    {
        public void FuncionGrid(ref Funcion objFuncion, ref List<Funcion> List)
        {
            try
            {
                CD_Funcion CD_Funcion = new CD_Funcion();
                CD_Funcion.FuncionGrid(ref objFuncion, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
