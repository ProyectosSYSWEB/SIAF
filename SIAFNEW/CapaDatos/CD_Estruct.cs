using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Estruct
    {
        public void EstructGrid(ref Estruct objEstruct, ref List<Estruct> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"p_ejercicio", "p_ccontab"};
                String[] Valores = { objEstruct.Ejercicio, objEstruct.Centro_Contable};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_Estruct", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objEstruct = new Estruct();
                    objEstruct.Id = Convert.ToString(dr.GetValue(0));
                    objEstruct.Centro_Contable = Convert.ToString(dr.GetValue(1));
                    objEstruct.Programa = Convert.ToString(dr.GetValue(2));
                    objEstruct.SubPrograma = Convert.ToString(dr.GetValue(3));
                    objEstruct.Dependencia = Convert.ToString(dr.GetValue(4));
                    objEstruct.Proyecto = Convert.ToString(dr.GetValue(5));
                    objEstruct.Status = Convert.ToString(dr.GetValue(6));
                    objEstruct.Fecha_Captura = Convert.ToString(dr.GetValue(7));
                    objEstruct.Codigo = Convert.ToString(dr.GetValue(8));
                    List.Add(objEstruct);
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

