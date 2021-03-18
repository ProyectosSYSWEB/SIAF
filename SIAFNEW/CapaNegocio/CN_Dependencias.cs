using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Dependencias
    {
        public void DependenciasGrid(ref Dependencias objDependencias, ref List<Dependencias> List)
        {
            try
            {
                CD_Depdencencias CD_Depdencencias = new CD_Depdencencias();
                CD_Depdencencias.DependenciasGrid(ref objDependencias, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            try
            {
                CD_Depdencencias CD_Depdencencias = new CD_Depdencencias();
                CD_Depdencencias.InsertarDependencia(ref objDependencias, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            try
            {
                CD_Depdencencias CD_Depdencencias = new CD_Depdencencias();
                CD_Depdencencias.EliminarDependencia(ref objDependencias, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
