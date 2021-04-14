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
                String[] Parametros = { "p_ejercicio", "p_tipo_proy" };
                String[] Valores = { objProyectos.Ejercicio,objProyectos.Tipo_Proy};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_Proy", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objProyectos = new Proyectos();
                    objProyectos.Tipo_Proy = Convert.ToString(dr.GetValue(0));
                    objProyectos.Proyecto = Convert.ToString(dr.GetValue(1));
                    objProyectos.Descrip = Convert.ToString(dr.GetValue(2));
                    objProyectos.Id = Convert.ToString(dr.GetValue(3));
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
        public void ObtenerDatosProyecto(ref Proyectos objProyecto, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_EJERCICIO", "P_ID" };
                object[] Valores = {objProyecto.Ejercicio, objProyecto.Id };
                string[] ParametrosOut = {"P_ID_TIPO_PROYECTO","P_CLAVE", "P_DESCRIPCION", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_SAF_PRESUP_PROYECTOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objProyecto = new Proyectos();
                    objProyecto.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objProyecto.Id_Tipo_Proyecto = Convert.ToString(Cmd.Parameters["P_ID_TIPO_PROYECTO"].Value);
                    objProyecto.Clave_Proy = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objProyecto.Descrip = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);                    
                }
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
        public void EditarProyecto(ref Proyectos objProyecto, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_CLAVE", "P_DESCRIPCION", "P_ID_TIPO_PROYECTO", "P_EJERCICIO"};
                object[] Valores = { objProyecto.Id, objProyecto.Clave_Proy, objProyecto.Descrip, objProyecto.Id_Tipo_Proyecto, objProyecto.Ejercicio};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PRESUP_PROY", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarProyecto(Proyectos objProyecto, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objProyecto.Id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("", ref Verificador, Parametros, Valores, ParametrosOut);

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
