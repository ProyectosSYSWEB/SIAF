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
        public void InsertarProyecto(ref Proyectos objProyectos, ref string Verificador)
        {
            try
            {
                CD_Proyecto CD_Proyecto = new CD_Proyecto();
                CD_Proyecto.InsertarProyecto(ref objProyectos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerDatosProyecto(ref Proyectos objProyectos, ref string Verificador)
        {
            try
            {
                CD_Proyecto CD_Proyecto = new CD_Proyecto();
                CD_Proyecto.ObtenerDatosProyecto(ref objProyectos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarProyecto(ref Proyectos objProyectos, ref string Verificador)
        {
            try
            {
                CD_Proyecto CD_Proyecto = new CD_Proyecto();
                CD_Proyecto.EditarProyecto(ref objProyectos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarProyecto(Proyectos objProyectos, ref string Verificador)
        {
            try
            {
                CD_Proyecto CD_Proyecto = new CD_Proyecto();
                CD_Proyecto.EliminarProyecto(objProyectos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
