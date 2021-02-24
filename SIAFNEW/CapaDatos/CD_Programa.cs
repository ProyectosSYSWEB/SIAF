using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Programa
    {
        public void ProgramasGrid(ref Programa objPrograma, ref List<Programa> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { };
                String[] Valores = { };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_F_Prog", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPrograma = new Programa();
                    objPrograma.Funcion = Convert.ToString(dr.GetValue(0));
                    objPrograma.Funfed = Convert.ToString(dr.GetValue(1));
                    objPrograma.F_Prog = Convert.ToString(dr.GetValue(2));
                    objPrograma.Descripcion = Convert.ToString(dr.GetValue(3));
                    List.Add(objPrograma);
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
