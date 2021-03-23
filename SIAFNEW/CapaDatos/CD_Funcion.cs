using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Funcion
    {
        public void FuncionGrid(ref Funcion objFuncion, ref List<Funcion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { };
                String[] Valores = { };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_Funcion", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objFuncion = new Funcion();
                    objFuncion.funcion = Convert.ToString(dr.GetValue(0));
                    objFuncion.Descripcion = Convert.ToString(dr.GetValue(1));                    
                    List.Add(objFuncion);
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

        public void InsertarFuncion(ref Funcion objFuncion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_TIPO", "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_VALOR", "P_ORDEN" };
                object[] Valores = { objFuncion.Tipo, objFuncion.Clave, objFuncion.Status, objFuncion.Descripcion, objFuncion.Valor, objFuncion.Orden };
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



        public void ObtenerDatosFuncion(ref Funcion objFuncion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_CLAVE" };
                object[] Valores = { objFuncion.Clave };
                string[] ParametrosOut = { "P_CLAVE", "P_DESCRIPCION", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_CAT_FUNCION", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objFuncion = new Funcion();
                    objFuncion.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objFuncion.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objFuncion.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
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
        public void EditarFuncion(ref Funcion objFuncion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_CLAVE", "P_DESCRIPCION" };
                object[] Valores = { objFuncion.Id, objFuncion.Clave, objFuncion.Descripcion};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CAT_FUNCION", ref Verificador, Parametros, Valores, ParametrosOut);

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
