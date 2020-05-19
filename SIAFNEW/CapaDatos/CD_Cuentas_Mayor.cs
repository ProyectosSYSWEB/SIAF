using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Cuentas_Mayor
    {
        public void ConsultarCuentas_mayor(ref Cuentas_Mayor  Objcuentas_mayor, string buscar, ref List<Cuentas_Mayor > List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_tipo" };
                Object[] Valores = {Objcuentas_mayor.tipo };
                //String[] ParametrosOut = { "p_dependencia", "p_evento", "p_descripcion", "p_fecha_inicial", "p_fecha_final", "p_nivel" };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.obt_grid_cuentas_mayor", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objcuentas_mayor = new Cuentas_Mayor ();
                    Objcuentas_mayor.id = Convert.ToString(dr[0]);
                    Objcuentas_mayor.descripcion = Convert.ToString(dr[1]);
                    Objcuentas_mayor.clave = Convert.ToString(dr[2]);                    
                    Objcuentas_mayor.naturaleza = Convert.ToString(dr[3]);
                    Objcuentas_mayor.rubro = Convert.ToString(dr[4]);
                    Objcuentas_mayor.nivel = Convert.ToString(dr[5]);
                    Objcuentas_mayor.nivel_des  = Convert.ToString(dr[6]);
                  


                    List.Add(Objcuentas_mayor);

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


        public void Consultarmayor(ref Cuentas_Mayor Objcuentas_mayor, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_id" };
                object[] Valores = { Objcuentas_mayor.id };
                string[] ParametrosOut = { "p_id_padre", "p_tipo","p_clave", "p_descripcion", "p_id_naturaleza","p_id_rubro", "p_nivel", "p_estado_financiero", "p_status", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CUENTAS_MAYOR", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objcuentas_mayor = new Cuentas_Mayor();
                    Objcuentas_mayor.id_padre = Convert.ToString(Cmd.Parameters["p_id_padre"].Value);
                    Objcuentas_mayor.tipo = Convert.ToString(Cmd.Parameters["p_tipo"].Value);
                    Objcuentas_mayor.clave = Convert.ToString(Cmd.Parameters["p_clave"].Value);
                    Objcuentas_mayor.descripcion= Convert.ToString(Cmd.Parameters["p_descripcion"].Value);
                    Objcuentas_mayor.naturaleza = Convert.ToString(Cmd.Parameters["p_id_naturaleza"].Value);
                    Objcuentas_mayor.rubro = Convert.ToString(Cmd.Parameters["p_id_rubro"].Value);
                    Objcuentas_mayor.nivel = Convert.ToString(Cmd.Parameters["p_nivel"].Value);
                    Objcuentas_mayor.estado_financiero = Convert.ToString(Cmd.Parameters["p_estado_financiero"].Value);                   
                    Objcuentas_mayor.status = Convert.ToString(Cmd.Parameters["p_status"].Value);
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

        public void Editar_cuentas_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_id_padre", "p_tipo", "p_clave", "p_descripcion", "p_id_naturaleza", "p_id_rubro", "p_nivel", "p_estado_financiero", "p_status", "P_ID" };
                
                object[] Valores = { Convert.ToInt32(objcuentas_mayor.id_padre), objcuentas_mayor.tipo, objcuentas_mayor.clave , objcuentas_mayor.descripcion, Convert.ToInt32 (objcuentas_mayor.naturaleza), Convert.ToInt32(objcuentas_mayor.rubro), Convert.ToInt32(objcuentas_mayor.nivel), objcuentas_mayor.estado_financiero, objcuentas_mayor.status, Convert.ToInt32(objcuentas_mayor.id) };

                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CUENTAS_MAYOR", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void insertar_cuenta_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "p_id_padre", "p_tipo", "p_clave", "p_descripcion", "p_id_naturaleza", "p_id_rubro", "p_nivel", "p_estado_financiero", "p_status", "P_ALTA_USUARIO" };
                object[] Valores = { Convert.ToInt32(objcuentas_mayor.id_padre), objcuentas_mayor.tipo, objcuentas_mayor.clave, objcuentas_mayor.descripcion, Convert.ToInt32(objcuentas_mayor.naturaleza), Convert.ToInt32(objcuentas_mayor.rubro), Convert.ToInt32(objcuentas_mayor.nivel), objcuentas_mayor.estado_financiero, objcuentas_mayor.status, objcuentas_mayor.usuario };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_saf_cuentas_mayor", ref Verificador, Parametros, Valores, ParametrosOut);

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


        public void Eliminar_cuenta_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "p_id"};
                object[] Valores = { Convert.ToInt32(objcuentas_mayor.id)};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("del_saf_cuentas_mayor", ref Verificador, Parametros, Valores, ParametrosOut);

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
