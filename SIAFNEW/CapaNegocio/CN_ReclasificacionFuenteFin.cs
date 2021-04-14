using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_ReclasificacionFuenteFin
    {
        public void CodigosReclasificacion(Consultas objConsulta, ref List<Consultas> List)
        {
            try
            {
                CD_ReclasifiacionFuenteFin CD_Reclasificaciones = new CD_ReclasifiacionFuenteFin();
                CD_Reclasificaciones.CodigosReclasificacion(objConsulta, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
