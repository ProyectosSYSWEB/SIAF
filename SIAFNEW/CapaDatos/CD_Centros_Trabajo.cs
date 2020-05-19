using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Centros_Trabajo
    {
        public void ConsultarCentros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, string buscar, ref List<Centros_Trabajo> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_centro_contable", "p_status", "p_buscar" };
                Object[] Valores = { objCentros_Trabajo.centro_contable, objCentros_Trabajo.status, buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PATRIMONIO.Obt_Grid_Centros_Trabajo", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objCentros_Trabajo = new Centros_Trabajo();
                    objCentros_Trabajo.id = Convert.ToString(dr[0]);
                    objCentros_Trabajo.centro_contable = Convert.ToString(dr[1]);
                    objCentros_Trabajo.clave = Convert.ToString(dr[2]);
                    objCentros_Trabajo.descripcion = Convert.ToString(dr[3]);
                    objCentros_Trabajo.status = Convert.ToString(dr[4]);

                    List.Add(objCentros_Trabajo);

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


        public void ConsultarMax_id_dependencia(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_depend" };
                object[] Valores = { objCentros_Trabajo.dependencia };
                string[] ParametrosOut = { "P_max_id","p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_MAX_IDDEPENDENCIA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objCentros_Trabajo = new Centros_Trabajo();
                    objCentros_Trabajo.max_id = Convert.ToString(Cmd.Parameters["P_max_id"].Value);

                }
                else
                {
                    objCentros_Trabajo.max_id = "00000001";
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


        public void Consulta_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_id" };
                object[] Valores = { objCentros_Trabajo.id };
                string[] ParametrosOut = { "P_CENTRO_CONTABLE", "P_CLAVE", "P_DESCRIPCION", "P_STATUS", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CENTROS_TRABAJO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objCentros_Trabajo = new Centros_Trabajo();
                    objCentros_Trabajo.centro_contable = Convert.ToString(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    objCentros_Trabajo.clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objCentros_Trabajo.descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objCentros_Trabajo.status = Convert.ToString(Cmd.Parameters["P_STATUS"].Value);


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


        public void insertar_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CENTRO_CONTABLE", "P_CLAVE", "P_DESCRIPCION", "P_STATUS" };
                object[] Valores = { objCentros_Trabajo.centro_contable, objCentros_Trabajo.clave, objCentros_Trabajo.descripcion, objCentros_Trabajo.status };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_CENTROS_TRABAJOS", ref Verificador, Parametros, Valores, ParametrosOut);

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


        public void Editar_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_CENTRO_CONTABLE", "P_CLAVE", "P_DESCRIPCION", "P_STATUS" };
                object[] Valores = { objCentros_Trabajo.id, objCentros_Trabajo.centro_contable, objCentros_Trabajo.clave, objCentros_Trabajo.descripcion, objCentros_Trabajo.status };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CENTROS_TRABAJO", ref Verificador, Parametros, Valores, ParametrosOut);
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


        public void Eliminar_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objCentros_Trabajo.id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_CENTROS_TRABAJO", ref Verificador, Parametros, Valores, ParametrosOut);

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
