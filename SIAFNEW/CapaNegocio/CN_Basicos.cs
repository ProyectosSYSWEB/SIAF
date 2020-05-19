using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Basicos
    {
        public void ConsultarBasicos(ref Basicos objBasicos, string buscar, ref List<Basicos> List)
        {
            try
            {

                CD_Basicos CDBasicos = new CD_Basicos();
                CDBasicos.ConsultarBasicos(ref objBasicos, buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void insertar_Basicos(ref Basicos objBasicos, ref string Verificador)
        {
            try
            {

                CD_Basicos CDBasicos = new CD_Basicos();
                CDBasicos.insertar_Basicos(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar_Basicos(ref Basicos objBasicos, ref string Verificador)
        {
            try
            {
                CD_Basicos cdBasicos = new CD_Basicos();
                cdBasicos.Editar_Basicos(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Consulta_Basico(ref Basicos objBasicos, ref string Verificador)
        {
            try
            {
                CD_Basicos CDBasicos = new CD_Basicos();
                CDBasicos.Consulta_Basico(ref  objBasicos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar_Basico(ref Basicos objBasicos, ref string Verificador)
        {
            try
            {

                CD_Basicos CDBasicos = new CD_Basicos();
                CDBasicos.Eliminar_Basico(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
