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
                String[] Parametros = { "p_partida", "p_fuente", "p_mes_inicial", "p_mes_final", "p_ejercicio" };
                String[] Valores = { objAdecuacion.Partida, objAdecuacion.Fuente, Convert.ToString(objAdecuacion.MesIni), Convert.ToString(objAdecuacion.MesFin), objAdecuacion.Ejercicio};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Adecuaciones", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objAdecuacion = new Adecuaciones();
                    objAdecuacion.Mes = Convert.ToString(dr.GetValue(0));
                    objAdecuacion.TipoOperacion = Convert.ToString(dr.GetValue(1));                    
                    objAdecuacion.Codigo_Programatico = Convert.ToString(dr.GetValue(2));
                    objAdecuacion.Destino = Convert.ToString(dr.GetValue(3));                    
                    objAdecuacion.Suma_Destino = Convert.ToString(dr.GetValue(4));
                    objAdecuacion.Origen = Convert.ToString(dr.GetValue(5));
                    objAdecuacion.Centro_Contab = Convert.ToString(dr.GetValue(6));
                    objAdecuacion.Dependencia = Convert.ToString(dr.GetValue(7));
                    objAdecuacion.Ejercicio = Convert.ToString(dr.GetValue(8));
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
                string[] ParametrosOut = {"P_MES","P_TIPO_OPE","P_C_CONTAB", "P_ORIGEN", "P_DEPENDENCIA", "P_CENTRO_CONTABLE", "P_EJERCICIO", "p_bandera"};

                Cmd = CDDatos.GenerarOracleCommand("OBT_COD_PROG_ADECUACIONES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objAdecuaciones = new Adecuaciones();
                    objAdecuaciones.Mes = Convert.ToString(Cmd.Parameters["P_MES"].Value);
                    objAdecuaciones.TipoOperacion = Convert.ToString(Cmd.Parameters["P_TIPO_OPE"].Value);
                    objAdecuaciones.Centro_Contab = Convert.ToString(Cmd.Parameters["P_C_CONTAB"].Value);
                    objAdecuaciones.Origen = Convert.ToString(Cmd.Parameters["P_ORIGEN"].Value);
                    objAdecuaciones.Codigo_Programatico = Convert.ToString(Cmd.Parameters["P_CODIGO"].Value);
                    objAdecuaciones.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    objAdecuaciones.Centro_Contab = Convert.ToString(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    objAdecuaciones.Ejercicio = Convert.ToString(Cmd.Parameters["P_EJERCICIO"].Value);
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



        public void InsertarDocumentoAdecuacion(List<Adecuaciones> List, Adecuaciones objAdecuaciones, ref string Verificador)
        {
            string Id_Documento = "";
            string C_Contab = "";
            string Dependencia = "";
            int z = 0;
            try
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    double importeOperacion = 0;
                    int consecutivo = 1;
                    if (C_Contab != List[i].Centro_Contab && Dependencia != List[i].Dependencia)
                    {
                        C_Contab = List[i].Centro_Contab;
                        Dependencia = List[i].Dependencia;
                        for (int y = i; y < List.Count; y ++)
                        {
                            if (C_Contab == List[y].Centro_Contab && Dependencia == List[i].Dependencia)
                                importeOperacion = importeOperacion + Convert.ToDouble(List[y].Destino);
                            else                            
                                y = List.Count;
                        }
                        CD_Datos CDDatos = new CD_Datos();
                        OracleCommand Cmd = null;
                        String[] Parametros = { "P_CENTRO_CONTABLE", "P_DEPENDENCIA", "P_FECHA", "P_MES_ANIO", "P_DESCRIPCION", "P_USUARIO","P_EJERCICIO", "P_IMPORTE_OPERACION" };
                        object[] Valores = { List[i].Centro_Contab, List[i].Dependencia, objAdecuaciones.Fecha, objAdecuaciones.MesAnio, objAdecuaciones.Descripcion , objAdecuaciones.Usuario, objAdecuaciones.Ejercicio, importeOperacion };
                        String[] ParametrosOut = { "P_EXTRA", "P_BANDERA" };

                        Cmd = CDDatos.GenerarOracleCommand("INS_ADECUCION_NOMINA", ref Verificador, ref Id_Documento, Parametros, Valores, ParametrosOut);
                        CDDatos.LimpiarOracleCommand(ref Cmd);
                    }
                   
                    for (int x = z; x <= List.Count; x++)
                    {
                        z = x;
                        if (List[x].Centro_Contab == C_Contab && Dependencia == List[x].Dependencia && List[x].Centro_Contab != "81101")
                        {                                                   
                            CD_Datos CDDatos = new CD_Datos();
                            OracleCommand Cmd = null;
                            String[] Parametros = { "P_ID_DOCUMENTO", "P_CONSECUTIVO", "P_UR_CLAVE", "P_TIPO", "P_IMPORTE_ORIGEN", "P_IMPORTE_DESTINO", "P_IMPORTE_MENSUAL", "P_MES_INICIAL", "P_MES_FINAL", "P_CODIGO_PROG", "P_EJERCICIO" };
                            object[] Valores = { Id_Documento, consecutivo, List[x].Dependencia, "D", "0", List[x].Destino, List[x].Destino, objAdecuaciones.MesIni, objAdecuaciones.MesFin, List[x].Codigo_Programatico, List[x].Ejercicio };
                            String[] ParametrosOut = { "P_BANDERA" };
                            Cmd = CDDatos.GenerarOracleCommand("INS_ADECUACION_NOMINA_DET", ref Verificador, Parametros, Valores, ParametrosOut);
                            CDDatos.LimpiarOracleCommand(ref Cmd);
                            consecutivo = consecutivo + 1;
                            i = x;
                        }
                        else if (z < List.Count) //se inserta el codigo origen y se asigna la nueva dependencia
                        {
                            int ubicacionOrigen = List.Count - 1;                            
                            CD_Datos CDDatos = new CD_Datos();
                            OracleCommand Cmd = null;
                            String[] Parametros = { "P_ID_DOCUMENTO", "P_CONSECUTIVO", "P_UR_CLAVE", "P_TIPO", "P_IMPORTE_ORIGEN", "P_IMPORTE_DESTINO", "P_IMPORTE_MENSUAL", "P_MES_INICIAL", "P_MES_FINAL", "P_CODIGO_PROG", "P_EJERCICIO" };
                            object[] Valores = { Id_Documento, consecutivo, "81101", "O", importeOperacion, "0", importeOperacion, "12", "12", List[ubicacionOrigen].Codigo_Programatico, List[ubicacionOrigen].Ejercicio };
                            String[] ParametrosOut = { "P_BANDERA" };
                            Cmd = CDDatos.GenerarOracleCommand("INS_ADECUACION_NOMINA_DET", ref Verificador, Parametros, Valores, ParametrosOut);
                            CDDatos.LimpiarOracleCommand(ref Cmd);
                            C_Contab = "";
                            Dependencia = "";
                            x = List.Count;
                        }                                                    
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                
            }
        }     


    }
}
