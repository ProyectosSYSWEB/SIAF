using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Programa
    {
        public void ProgramasGrid(ref Programa objPrograma, ref List<Programa> List)
        {
            try
            {
                CD_Programa CD_Programa = new CD_Programa();
                CD_Programa.ProgramasGrid(ref objPrograma, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarPrograma(ref Programa objPrograma, ref string Verificador)
        {
            try
            {

                CD_Programa CD_Programa = new CD_Programa();
                CD_Programa.InsertarPrograma(ref objPrograma, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerDatosPrograma(ref Programa objPrograma, ref string Verificador)
        {
            try
            {
                CD_Programa CD_Programa = new CD_Programa();
                CD_Programa.ObtenerDatosPrograma(ref objPrograma, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarPrograma(ref Programa objPrograma, ref string Verificador)
        {
            try
            {
                CD_Programa CD_Programa = new CD_Programa();
                CD_Programa.EditarPrograma(ref objPrograma, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarPrograma(Programa objPrograma, ref string Verificador)
        {
            try
            {
                CD_Programa CD_Programa = new CD_Programa();
                CD_Programa.EliminarPrograma(objPrograma, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
