using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Baja
    {
        public void ConsultarDatos(ref Baja ObjBaja, ref string Verificador)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.ConsultarDatos(ref ObjBaja, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Obtener_Grid(ref Baja objBaja, String FechaInicial, String FechaFinal, String Buscar, ref List<Baja> List)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.Obtener_Grid(ref objBaja, FechaInicial, FechaFinal, Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar_Status(ref Baja ObjBaja, ref string Verificador)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.Editar_Status(ref ObjBaja, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar(Baja ObjBaja, ref string Verificador)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.Editar(ObjBaja, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar(ref Baja ObjBaja, ref string Verificador)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.Insertar(ref ObjBaja, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Baja ObjBaja, ref string Verificador)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.Eliminar(ObjBaja, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insertar_Detalle(List<Baja> List, Baja DatosBaja, ref string Verificador)
        {
            try
            {
                CD_Baja CDBaja_Detalle = new CD_Baja();
                CDBaja_Detalle.Insertar_Detalle(List, DatosBaja, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Obtener_Grid_Detalle(ref Baja ObjBaja, ref List<Baja> List)
        {
            try
            {
                CD_Baja CDBaja = new CD_Baja();
                CDBaja.Obtener_Grid_Detalle(ref ObjBaja, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
