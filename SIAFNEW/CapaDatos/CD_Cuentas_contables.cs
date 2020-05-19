using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Cuentas_contables
    {
        public void PolizaConsultaGrid(ref cuentas_contables Objcuentas_contables, ref List<cuentas_contables> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                string Centro_Contable = Objcuentas_contables.centro_contable;
                String[] Parametros = { "p_ejercicio","p_centro_contable", "p_tipo", "p_cuenta_contable", "p_nivel", "p_buscar" };
                String[] Valores = { Objcuentas_contables.ejercicio, Objcuentas_contables.centro_contable, Objcuentas_contables.tipo, Objcuentas_contables.cuenta_contable, Objcuentas_contables.nivel, Objcuentas_contables.buscar  };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Polizas_CC", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objcuentas_contables = new cuentas_contables();
                    Objcuentas_contables.IdPoliza = Convert.ToInt32(dr.GetValue(0));
                    Objcuentas_contables.centro_contable = Convert.ToString(dr.GetValue(3));
                    Objcuentas_contables.numero_poliza = Convert.ToString(dr.GetValue(2));
                    Objcuentas_contables.tipo = Convert.ToString(dr.GetValue(4));
                    Objcuentas_contables.fecha = Convert.ToString(dr.GetValue(7));
                    Objcuentas_contables.status = Convert.ToString(dr.GetValue(9));
                    Objcuentas_contables.concepto = Convert.ToString(dr.GetValue(6));
                    Objcuentas_contables.Tot_Cargo = Convert.ToDouble(dr.GetValue(19));
                    Objcuentas_contables.Tot_Abono = Convert.ToDouble(dr.GetValue(20));
                    
                    List.Add(Objcuentas_contables);
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
        public void ConsultarCuentas_Contables(ref cuentas_contables Objcuentas_contables, string buscar, ref List<cuentas_contables> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_centro_contable", "p_cuenta_mayor", "p_buscar"};
                Object[] Valores = { Objcuentas_contables.ejercicio, Objcuentas_contables.centro_contable, Objcuentas_contables.cuenta_mayor, buscar };
                //String[] ParametrosOut = { "p_dependencia", "p_evento", "p_descripcion", "p_fecha_inicial", "p_fecha_final", "p_nivel" };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.obt_grid_cuentas_contables", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objcuentas_contables = new cuentas_contables();
                    Objcuentas_contables.id = Convert.ToString(dr[0]);
                    Objcuentas_contables.descripcion = Convert.ToString(dr[1]);
                    Objcuentas_contables.natura = Convert.ToString(dr[4]);
                    Objcuentas_contables.nivel = Convert.ToString(dr[2]);
                    if (Convert.ToString(dr[2]) == "4") { Objcuentas_contables.bandera = true; } else { Objcuentas_contables.bandera = false; }
                    Objcuentas_contables.cuenta_contable  = Convert.ToString(dr[5]);
                    
                    List.Add(Objcuentas_contables);

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


        public void Consultarcuenta(ref cuentas_contables Objcuentas_contables, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_id" };
                object[] Valores = { Objcuentas_contables.id };
                string[] ParametrosOut = { "P_CENTRO_CONTABLE", "P_CUENTA", "P_DESCRIPCION", "P_TIPO", "P_CLASIFICACION", "P_NIVEL", "P_STATUS", "P_ID_CUENTA_MAYOR", "p_bandera"};

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CUENTAS_CONTABLES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objcuentas_contables = new cuentas_contables();
                    Objcuentas_contables.centro_contable = Convert.ToString(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    Objcuentas_contables.cuenta_contable = Convert.ToString(Cmd.Parameters["p_cuenta"].Value);
                    Objcuentas_contables.descripcion = Convert.ToString(Cmd.Parameters["p_descripcion"].Value);
                    Objcuentas_contables.tipo = Convert.ToString(Cmd.Parameters["p_tipo"].Value);
                    Objcuentas_contables.clasificacion = Convert.ToString(Cmd.Parameters["p_clasificacion"].Value);
                    Objcuentas_contables.nivel = Convert.ToString(Cmd.Parameters["p_nivel"].Value);
                    Objcuentas_contables.status = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    Objcuentas_contables.cuenta_mayor = Convert.ToString(Cmd.Parameters["p_id_cuenta_mayor"].Value);                    
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


        public void insertar_cuenta_contable(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_EJERCICIO", "P_CENTRO_CONTABLE", "P_CUENTA", "P_DESCRIPCION", "P_TIPO", "P_CLASIFICACION", "P_NIVEL", "P_STATUS", "P_ID_CUENTA_MAYOR", "P_ALTA_USUARIO" };
                object[] Valores = { Convert.ToInt32( objcuentas_contables.ejercicio), objcuentas_contables.centro_contable, objcuentas_contables.cuenta_contable, objcuentas_contables.descripcion, objcuentas_contables.tipo, objcuentas_contables.clasificacion, Convert.ToInt32( objcuentas_contables.nivel), objcuentas_contables.status, Convert.ToInt32( objcuentas_contables.cuenta_mayor),objcuentas_contables.usuario };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_saf_cuentas_contables", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Eliminar_cuenta_contable(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objcuentas_contables.id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_CUENTAS_CONTABLES", ref Verificador, Parametros, Valores, ParametrosOut);

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



        public void Editar_cuentas_contables(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CENTRO_CONTABLE", "P_CUENTA", "P_DESCRIPCION", "P_TIPO", "P_CLASIFICACION", "P_NIVEL", "P_STATUS", "P_ID_CUENTA_MAYOR", "P_ID" };

                object[] Valores = { objcuentas_contables.centro_contable, objcuentas_contables.cuenta_contable, objcuentas_contables.descripcion, objcuentas_contables.tipo, objcuentas_contables.clasificacion, Convert.ToInt32( objcuentas_contables.nivel), objcuentas_contables.status,Convert.ToInt32( objcuentas_contables.cuenta_mayor),Convert.ToInt32( objcuentas_contables.id )};

                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CUENTAS_CONTABLES", ref Verificador, Parametros, Valores, ParametrosOut);
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
