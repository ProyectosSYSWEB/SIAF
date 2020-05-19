using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Pres_Reportes
    {
        public void ConsultaGrid_Fuente_F(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"p_ejercicio", "p_dependencia" };
                String[] Valores = {objReportes.Ejercicio, objReportes.Dependencia };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Fuente_F", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Fuente  = Convert.ToString (dr.GetValue(0));
                    objReportes.Descripcion  = Convert.ToString(dr.GetValue(1));                                   
                    List.Add(objReportes );
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
        public void ConsultaGrid_Capitulo(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia" };
                String[] Valores = { objReportes.Dependencia };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Capitulo", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Id  = Convert.ToString(dr.GetValue(0));
                    objReportes.Capitulo = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
