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
    }
}
