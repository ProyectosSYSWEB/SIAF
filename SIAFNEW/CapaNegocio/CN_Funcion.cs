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
        public void InsertarFuncion(ref Funcion objFuncion, ref string Verificador)
        {
            try
            {

                CD_Funcion CDFuncion = new CD_Funcion();
                CDFuncion.InsertarFuncion(ref objFuncion, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerDatosFuncion(ref Funcion objFuncion, ref string Verificador)
        {
            try
            {
                CD_Funcion CDFuncion = new CD_Funcion();
                CDFuncion.ObtenerDatosFuncion(ref objFuncion, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarFuncion(ref Funcion objFuncion, ref string Verificador)
        {
            try
            {
                CD_Funcion CDFuncion = new CD_Funcion();
                CDFuncion.EditarFuncion(ref objFuncion, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Funcion objFuncion, ref string Verificador)
        {
            try
            {
                CD_Funcion CDFuncion = new CD_Funcion();
                CDFuncion.EliminarFuncion(objFuncion, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
