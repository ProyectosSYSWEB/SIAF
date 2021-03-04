using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Proyecto
    {
        public void ProyectoGrid(ref Proyectos objProyectos, ref List<Proyectos> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio" };
                String[] Valores = { objProyectos.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_Proy", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objProyectos = new Proyectos();
                    objProyectos.Tipo_Proy = Convert.ToString(dr.GetValue(0));
                    objProyectos.Proyecto = Convert.ToString(dr.GetValue(1));
                    objProyectos.Descrip = Convert.ToString(dr.GetValue(2));
                    List.Add(objProyectos);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }


        public void InsertarProyecto(ref Proyectos objProyectos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CLAVE", "P_DESCRIPCION", "P_STATUS", "P_ID_TIPO_PROYECTO", "P_EJERCICIO" };
                object[] Valores = { objProyectos.Clave_Proy, objProyectos.Descrip, objProyectos.Status, objProyectos.Id_Tipo_Proyecto, objProyectos.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRESUP_PROYECTOS", ref Verificador, Parametros, Valores, ParametrosOut);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
    }
}
