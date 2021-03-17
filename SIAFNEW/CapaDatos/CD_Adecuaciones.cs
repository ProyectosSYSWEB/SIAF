using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Adecuaciones
    {
        public void AdecuacionesGrid(Adecuaciones objAdecuacion, ref List<Adecuaciones> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_partida", "p_fuente", "p_mes_inicial", "p_mes_final" };
                String[] Valores = { objAdecuacion.Partida, objAdecuacion.Fuente, Convert.ToString(objAdecuacion.MesIni), Convert.ToString(objAdecuacion.MesFin)};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Adecuaciones", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objAdecuacion = new Adecuaciones();
                    objAdecuacion.Mes = Convert.ToString(dr.GetValue(0));
                    objAdecuacion.TipoOperacion = Convert.ToString(dr.GetValue(1));
                    objAdecuacion.Centro_Contab = Convert.ToString(dr.GetValue(2));
                    objAdecuacion.Codigo_Programatico = Convert.ToString(dr.GetValue(3));
                    objAdecuacion.Destino = Convert.ToString(dr.GetValue(4));                    
                    objAdecuacion.Suma_Destino = Convert.ToString(dr.GetValue(5));
                    objAdecuacion.Origen = Convert.ToString(dr.GetValue(6));
                    List.Add(objAdecuacion);
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


        public void ObtenerDatosCogidoAdecuaciones(ref Adecuaciones objAdecuaciones, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = {"P_CODIGO"};
                object[] Valores = { objAdecuaciones.Codigo_Programatico };
                string[] ParametrosOut = {"P_MES","P_TIPO_OPE","P_C_CONTAB", "P_ORIGEN", "p_bandera"};

                Cmd = CDDatos.GenerarOracleCommand("OBT_COD_PROG_ADECUACIONES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objAdecuaciones = new Adecuaciones();
                    objAdecuaciones.Mes = Convert.ToString(Cmd.Parameters["P_MES"].Value);
                    objAdecuaciones.TipoOperacion = Convert.ToString(Cmd.Parameters["P_TIPO_OPE"].Value);
                    objAdecuaciones.Centro_Contab = Convert.ToString(Cmd.Parameters["P_C_CONTAB"].Value);
                    objAdecuaciones.Origen = Convert.ToString(Cmd.Parameters["P_ORIGEN"].Value);
                    objAdecuaciones.Codigo_Programatico = Convert.ToString(Cmd.Parameters["P_CODIGO"].Value);
                    objAdecuaciones.Destino = "0";
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



        public void InsertarDocumentoAdecuacion(ref List<Adecuaciones> List, Adecuaciones objAdecuacion, ref string Verificador)
        {
            string Id_Documento = "";
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {
                    "P_CENTRO_CONTABLE", "P_DEPENDENCIA", "P_SUPERTIPO", "P_TIPO", "P_FECHA", "P_MES_ANIO", "P_TIPO_CAPTURA", "P_STATUS", "P_DESCRIPCION", "P_USUARIO", "P_FECHA_CAPTURA", "P_FECHA_APLICACION",
                    "P_CLAVE_EVENTO", "P_EJERCICIO"};
                object[] Valores = { objAdecuacion.Centro_Contab, objAdecuacion.Dependencia, objAdecuacion.SuperTipo, objAdecuacion.TipoOperacion, objAdecuacion.Fecha, objAdecuacion.MesAnio, objAdecuacion.Tipo_Captura,
                objAdecuacion.Status, objAdecuacion.Descripcion, objAdecuacion.Usuario, objAdecuacion.FechaAplicacion, objAdecuacion.ClaveEvento, objAdecuacion.Ejercicio};
                String[] ParametrosOut = { "P_ID_DOCUMENTO","P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRES_CAT_DEPEN", ref Verificador, ref Id_Documento, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    string Verificador2 = string.Empty;
                    InsertarDocumentoDetalleAdecuacion(List, Id_Documento, ref Verificador2);                    
                    Verificador = Verificador2;
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

        public void InsertarDocumentoDetalleAdecuacion(List<Adecuaciones> List, string Id_Documento, ref string Verificador)
        {            
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                for (int i = 1; i <= List.Count; i++)
                {
                    for(int x = 1;  )
                    {

                    }
                    String[] Parametros = {
                    "P_ID_DOCUMENTO", "P_CONSECUTIVO", "P_UR_CLAVE", "P_TIPO", "P_IMPORTE_ORIGEN", "P_IMPORTE_DESTINO"
                    , "P_IMPORTE_MENSUAL", "P_MES_INICIAL", "P_MES_FINAL"};
                    object[] Valores = { Id_Documento, };
                    String[] ParametrosOut = { "P_ID_DOCUMENTO" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_ADECUACION_NOMINA_DET", ref Verificador, Parametros, Valores, ParametrosOut);
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
