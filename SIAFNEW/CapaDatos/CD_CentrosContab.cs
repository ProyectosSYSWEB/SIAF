using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_CentrosContab
    {
        public void CContabGrid(ref CentrosContab objCentrosContab, ref List<CentrosContab> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"p_ejercicio" };
                String[] Valores = { objCentrosContab.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Centros_Contab", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objCentrosContab = new CentrosContab();
                    objCentrosContab.C_Contab = Convert.ToString(dr.GetValue(0));
                    objCentrosContab.Descrip = Convert.ToString(dr.GetValue(1));
                    objCentrosContab.Id = Convert.ToString(dr.GetValue(2));
                    List.Add(objCentrosContab);
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
        public void InsertarCentroContable(ref CentrosContab objCentrosContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CLAVE", "P_DESCRIPCION", "P_DIRECTOR", "P_ADMINISTRADOR", "P_SALIENTE", "P_ENTRANTE", "P_EJERCICIO" };
                object[] Valores = { objCentrosContab.C_Contab, objCentrosContab.Descrip, objCentrosContab.Director, objCentrosContab.Administrador, objCentrosContab.Saliente, objCentrosContab.Entrante, objCentrosContab.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_CAT_C_CONTAB", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ObtenerDatosCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID", "P_EJERCICIO" };
                object[] Valores = { objCContab.Id, objCContab.Ejercicio };
                string[] ParametrosOut = { "P_CLAVE", "P_DESCRIPCION", "P_DIRECTOR", "P_ADMINISTRADOR", "P_SALIENTE", "P_ENTRANTE", "P_BANDERA"};

                Cmd = CDDatos.GenerarOracleCommand("OBT_CAT_C_CONTAB", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objCContab = new CentrosContab();
                    objCContab.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objCContab.C_Contab = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objCContab.Descrip = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objCContab.Director = Convert.ToString(Cmd.Parameters["P_DIRECTOR"].Value);
                    objCContab.Administrador = Convert.ToString(Cmd.Parameters["P_ADMINISTRADOR"].Value);
                    objCContab.Saliente = Convert.ToString(Cmd.Parameters["P_SALIENTE"].Value);
                    objCContab.Entrante = Convert.ToString(Cmd.Parameters["P_ENTRANTE"].Value);                    
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
        public void EditarCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_EJERCICIO", "P_CLAVE", "P_DESCRIPCION", "P_DIRECTOR", "P_ADMINISTRADOR", "P_SALIENTE", "P_ENTRANTE"};
                object[] Valores = { objCContab.Id, objCContab.Ejercicio, objCContab.C_Contab, objCContab.Descrip, objCContab.Director, objCContab.Administrador, objCContab.Saliente, objCContab.Entrante };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_CAT_C_CONTAB", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarCContab(CentrosContab objCContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objCContab.Id };
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
