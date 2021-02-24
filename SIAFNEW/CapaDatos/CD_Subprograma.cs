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
                String[] Parametros = { "p_ejercicio", "p_dependencia", "p_dependencia_f" };
                String[] Valores = { "2020", "11101", "81101" };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_SubPrograma_Cat", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objSubprograma = new Subprograma();
                    objSubprograma.Subprog = Convert.ToString(dr.GetValue(0));
                    objSubprograma.Descripcion = Convert.ToString(dr.GetValue(1));                    
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
    }
}
