using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;


namespace CapaDatos
{
   public  class CD_Costeo
    {
        public void Sel_tabulador(ref Pres_Costeo objcosteo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_Ejercicio", "P_Tipo_personal" };
                object[] Valores = { objcosteo.Ejercicio, objcosteo.Tipo_personal };
                String[] ParametrosOut = { "P_PRIMA_VACACIONAL","P_AGUINALDO","P_AJUSTE_CALENDARIO","P_ISSSTE","P_FOVISSSTE","P_SAR","p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_TABULADOR_PRES", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objcosteo = new Pres_Costeo();
                    objcosteo.Prima_Vacacional = Convert.ToString(Cmd.Parameters["P_PRIMA_VACACIONAL"].Value);
                    objcosteo.Aguinaldo = Convert.ToString(Cmd.Parameters["P_AGUINALDO"].Value);
                    objcosteo.Ajuste_Calendario = Convert.ToString(Cmd.Parameters["P_AJUSTE_CALENDARIO"].Value);
                    objcosteo.Issste = Convert.ToString(Cmd.Parameters["P_ISSSTE"].Value);
                    objcosteo.Fovissste = Convert.ToString(Cmd.Parameters["P_FOVISSSTE"].Value);
                    objcosteo.Sar = Convert.ToString(Cmd.Parameters["P_SAR"].Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
    }
}
