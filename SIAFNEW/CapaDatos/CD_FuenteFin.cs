using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_FuenteFin
    {
        public void FuentesGrid(ref FuentesFin objFuentes, ref List<FuentesFin> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio" };
                String[] Valores = { objFuentes.Ejercicio};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_TipoFinan", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objFuentes = new FuentesFin();
                    objFuentes.Fuente = Convert.ToString(dr.GetValue(0));
                    objFuentes.Descrip = Convert.ToString(dr.GetValue(1));
                    objFuentes.Id = Convert.ToString(dr.GetValue(2));
                    List.Add(objFuentes);
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



        public void InsertarFuente(ref FuentesFin objFuentes, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_FUENTE", "P_ID_TIPO_FINANCIAMIENTO", "P_ID_TIPO_FONDO", "P_DESCRIPCION" };
                object[] Valores = { objFuentes.Fuente, objFuentes.TipoFinan, objFuentes.TipoFondo, objFuentes.Descrip};
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
    }
}
