using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Subprograma
    {
        public void SubprogramasGrid(ref Subprograma objSubprograma, ref List<Subprograma> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"p_nivel_acad", "p_ejercicio", "p_dependencia", "p_dependencia_f" };
                String[] Valores = {objSubprograma.NivAcad, objSubprograma.Ejercicio, objSubprograma.DependenciaI, objSubprograma.DependenciaF };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_SubPrograma_Cat", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objSubprograma = new Subprograma();
                    objSubprograma.Id = Convert.ToString(dr.GetValue(0));
                    objSubprograma.Subprog = Convert.ToString(dr.GetValue(1));
                    objSubprograma.Descripcion = Convert.ToString(dr.GetValue(2));
                    List.Add(objSubprograma);
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


        public void InsertarSubPrograma(ref Basicos objBasicos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_TIPO", "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_VALOR", "P_ORDEN" };
                object[] Valores = { objBasicos.tipo, objBasicos.clave, objBasicos.status, objBasicos.descripcion, objBasicos.valor, objBasicos.orden };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_BASICOS", ref Verificador, Parametros, Valores, ParametrosOut);

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


        public void ObtenerDatosSubprograma(ref Subprograma objSubprograma, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { objSubprograma.Id };
                string[] ParametrosOut = { "P_CLAVE", "P_DESCRIPCION", "P_VALOR", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_SAF_BASICOS_SUB_PROG", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objSubprograma = new Subprograma();
                    objSubprograma.Id= Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objSubprograma.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objSubprograma.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objSubprograma.NivAcad = Convert.ToString(Cmd.Parameters["P_VALOR"].Value);
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

        public void EditarSubProg(ref Subprograma objSubProg, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_CLAVE", "P_DESCRIPCION", "P_VALOR" };
                object[] Valores = { objSubProg.Id, objSubProg.Clave, objSubProg.Descripcion, objSubProg.NivAcad };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_SUB_PROGRAMAS", ref Verificador, Parametros, Valores, ParametrosOut);

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
