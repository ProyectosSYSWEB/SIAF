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
                String[] Parametros = {};
                String[] Valores = { };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_TipoFinan", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objFuentes = new FuentesFin();
                    objFuentes.Fuente = Convert.ToString(dr.GetValue(0));
                    objFuentes.Descrip = Convert.ToString(dr.GetValue(1));                    
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
    }
}
