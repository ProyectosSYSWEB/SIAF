using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Depdencencias
    {
        public void DependenciasGrid(ref Dependencias objDependencia, ref List<Dependencias> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_CENTRO_CONTAB", "P_EJERCICIO" };
                String[] Valores = { objDependencia.C_Contab, Convert.ToString( objDependencia.Ejercicio) };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Saf_Presup_Depcias", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objDependencia = new Dependencias();
                    objDependencia.C_Contab = Convert.ToString(dr.GetValue(0));
                    objDependencia.Depend = Convert.ToString(dr.GetValue(1));
                    objDependencia.Descrip = Convert.ToString(dr.GetValue(2));
                    objDependencia.Administ = Convert.ToString(dr.GetValue(3));
                    objDependencia.Titular = Convert.ToString(dr.GetValue(4));
                    objDependencia.Titular_Puesto = Convert.ToString(dr.GetValue(5));                    
                    List.Add(objDependencia);
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

        public void InsertarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_C_CONTAB", "P_CLAVE", "P_DESCRIPCION", "P_TITULAR", "P_ADMINISTRADOR", "P_DOMICILIO", "P_ID_ESTADO", "P_ID_MUNICIPIO", "P_ZONA_ECONOMICA", "P_TEL_TITULAR", "P_CEL_TITULAR", "P_TEL_ADMIN", "P_CEL_ADMIN", "P_NOMBRAMIENTO", "P_EJERCICIO" };
                object[] Valores = { objDependencias.C_Contab, objDependencias.Clave, objDependencias.Descrip, objDependencias.Titular, objDependencias.Administ, objDependencias.Domicilio, objDependencias.Id_Estado, objDependencias.Id_Municipio, objDependencias.Zona_Economica, objDependencias.Tel_Titular, objDependencias.Cel_Titular, objDependencias.Tel_Admin, objDependencias.Cel_Admin, objDependencias.Nombramiento, objDependencias.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRES_CAT_DEPEN", ref Verificador, Parametros, Valores, ParametrosOut);

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
