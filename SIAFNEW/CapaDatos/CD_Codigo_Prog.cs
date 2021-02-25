using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Codigo_Prog
    {
        public void CodigoProgGrid(ref Codigo_Prog objCodProg, ref List<Codigo_Prog> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_centroContab", "p_ejercicio" };
                String[] Valores = { objCodProg.Centro_Contable, objCodProg.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Saf_Presup_Cod_Prog", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objCodProg = new Codigo_Prog();
                    objCodProg.Centro_Contable = Convert.ToString(dr.GetValue(0));
                    objCodProg.Codigo = Convert.ToString(dr.GetValue(1));                    
                    List.Add(objCodProg);
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
