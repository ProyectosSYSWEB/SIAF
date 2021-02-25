using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Proyecto
    {
        public void ProyectoGrid(ref Proyectos objProyectos, ref List<Proyectos> List)
        {
            try
            {
                CD_Proyecto CD_Proyecto = new CD_Proyecto();
                CD_Proyecto.ProyectoGrid(ref objProyectos, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
