using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Consultas
    {
        public void ConsultaCodProgGrid(ref Consultas objConsultas, ref List<Consultas> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;                
                String[] Parametros = { "p_cod_prog", "p_ejercicio" };
                String[] Valores = { objConsultas.Codigo_Programatico, objConsultas.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Presup_Dp01", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objConsultas = new Consultas();
                    objConsultas.Mes = Convert.ToString(dr.GetValue(0));
                    objConsultas.Autorizado = Convert.ToString(dr.GetValue(1));
                    objConsultas.Modificado = Convert.ToString(dr.GetValue(2));
                    objConsultas.Ministrado = Convert.ToString(dr.GetValue(3));
                    objConsultas.Comprometido = Convert.ToString(dr.GetValue(4));
                    objConsultas.Devengado = Convert.ToString(dr.GetValue(5));
                    objConsultas.Ejercido = Convert.ToString(dr.GetValue(6));
                    objConsultas.Pagado = Convert.ToString(dr.GetValue(7));
                    objConsultas.Disminucion = Convert.ToString(dr.GetValue(8));

                    List.Add(objConsultas);
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


        public void ConsultaDetalleDocumento(ref Consultas objConsultas, ref List<Consultas> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_depend", "p_supertipo", "p_codigo_prog", "p_ejercicio"};
                String[] Valores = { objConsultas.Dependencia, objConsultas.Supertipo, objConsultas.Codigo_Programatico, objConsultas.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_ACM_Presup_Documentos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objConsultas = new Consultas();
                    objConsultas.Id = Convert.ToString(dr.GetValue(0));
                    objConsultas.Dependencia = Convert.ToString(dr.GetValue(1));
                    objConsultas.Folio = Convert.ToString(dr.GetValue(2));
                    objConsultas.Supertipo = Convert.ToString(dr.GetValue(3));
                    objConsultas.Tipo = Convert.ToString(dr.GetValue(4));
                    objConsultas.Fecha = Convert.ToString(dr.GetValue(5));
                    objConsultas.Status = Convert.ToString(dr.GetValue(6));//Se salta del 6 a l 8 porque el 7 es el id del documento y ese no nos importa por el momento en la tabla
                    objConsultas.Importe_Origen = Convert.ToString(dr.GetValue(8));
                    objConsultas.Importe_Destino = Convert.ToString(dr.GetValue(9));
                    objConsultas.Importe_Mensual = Convert.ToString(dr.GetValue(10));
                    objConsultas.Mes_Inicial = Convert.ToString(dr.GetValue(11));
                    objConsultas.Mes_Final = Convert.ToString(dr.GetValue(12));
                    objConsultas.Tipo_Evento = Convert.ToString(dr.GetValue(13));

                    List.Add(objConsultas);
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
