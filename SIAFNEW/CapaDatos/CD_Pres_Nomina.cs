using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Pres_Nomina
    {
        public void ConsultaGrid_Trabajador(ref Pres_Nomina objNomina, ref List<Pres_Nomina> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_buscar" };
                String[] Valores = {objNomina.Buscar};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRES.OBT_Grid_Trabajador_Unach", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objNomina = new Pres_Nomina();
                    objNomina.Nombre = Convert.ToString(dr.GetValue(0));
                    objNomina.RFC = Convert.ToString(dr.GetValue(1));                   

                    List.Add(objNomina);
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
        public void ConsultaMovimiento_Nomina(ref Pres_Nomina objNomina, ref List<Pres_Nomina> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"P_RFC" };
                String[] Valores = { objNomina.RFC};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRES.OBT_Grid_Movimientos_Nomina", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objNomina = new Pres_Nomina();                    
                    objNomina.Categoria = Convert.ToString(dr.GetValue(0));
                    objNomina.Plaza = Convert.ToString(dr.GetValue(1));
                    objNomina.Tipo_Personal = Convert.ToString(dr.GetValue(2));
                    objNomina.Periodo = Convert.ToString(dr.GetValue(3))+" - "+Convert.ToString(dr.GetValue(4));
                    List.Add(objNomina);
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
