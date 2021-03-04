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
    }
}
