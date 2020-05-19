using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public  class CN_Adquisiciones
    {
        public void Insertar_Solicitud_Compra(ref Adquisicion objadquisiciones, ref string Verificador)
        {
            try
            {
                CD_Adquisiciones  CDEmpleado = new CD_Adquisiciones ();
                CDEmpleado.Insertar_Solicitud_Compra(ref objadquisiciones, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Tabla_Informativa(ref Adquisicion  objadquisiciones, ref List<Adquisicion > List)
        {
            try
            {
                CD_Adquisiciones  CDadquisiciones = new CD_Adquisiciones ();
                CDadquisiciones.Tabla_informativa(ref objadquisiciones, ref List);
               
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Grid_Solicitudes_X_Dependencias(ref Adquisicion objadquisiciones, ref List<Adquisicion> List)
        {
            try
            {
                CD_Adquisiciones CDadquisiciones = new CD_Adquisiciones();
                CDadquisiciones.Grid_Solicitudes_X_Dependencias(ref objadquisiciones, ref List);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Grid_Solicitudes_X_UR(ref Adquisicion objadquisiciones, ref List<Adquisicion> List)
        {
            try
            {
                CD_Adquisiciones CDadquisiciones = new CD_Adquisiciones();
                CDadquisiciones.Grid_Solicitudes_X_UR(ref objadquisiciones, ref List);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Grid_codigo(ref Adquisicion objadquisiciones, ref List<Adquisicion> List)
        {
            try
            {
                CD_Adquisiciones CDadquisiciones = new CD_Adquisiciones();
                CDadquisiciones.Grid_codigo(ref objadquisiciones, ref List);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
