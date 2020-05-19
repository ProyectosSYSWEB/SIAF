using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Cuentas_Bancarias
    {
        public void Cuentas_BancariasConsultaGrid(ref Cuentas_Bancarias ObjCuentas_Bancarias, ref List<Cuentas_Bancarias> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_ejercicio","p_centro_contable" };
                object[] Valores = { ObjCuentas_Bancarias.Ejercicio, ObjCuentas_Bancarias.Centro_Contable };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Cuentas_Bancarias", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCuentas_Bancarias = new Cuentas_Bancarias();
                    ObjCuentas_Bancarias.IdCuenta_Bancaria = Convert.ToInt32(dr.GetValue(0));
                    ObjCuentas_Bancarias.Ejercicio = Convert.ToInt32(dr.GetValue(1));
                    ObjCuentas_Bancarias.Clave = Convert.ToString(dr.GetValue(2));
                    ObjCuentas_Bancarias.Centro_Contable = Convert.ToString(dr.GetValue(3));
                    ObjCuentas_Bancarias.Dependencia = Convert.ToString(dr.GetValue(4));
                    ObjCuentas_Bancarias.Banco = Convert.ToString(dr.GetValue(5));
                    ObjCuentas_Bancarias.Cuenta_Bancaria = Convert.ToString(dr.GetValue(6));
                    ObjCuentas_Bancarias.Cuenta_Contable = Convert.ToString(dr.GetValue(7));
                    ObjCuentas_Bancarias.Descripcion = Convert.ToString(dr.GetValue(8));
                    ObjCuentas_Bancarias.Fecha_Apertura = Convert.ToString(dr.GetValue(9));
                    ObjCuentas_Bancarias.Localidad = Convert.ToString(dr.GetValue(10));
                    ObjCuentas_Bancarias.Status = Convert.ToChar(dr.GetValue(11));
                    ObjCuentas_Bancarias.Alta_Usuario = Convert.ToString(dr.GetValue(12));
                    ObjCuentas_Bancarias.Alta_Fecha = Convert.ToString(dr.GetValue(13));
                    List.Add(ObjCuentas_Bancarias);
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
        public void Cuentas_BancariasInsertar(Cuentas_Bancarias ObjCuentas_Bancarias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_EJERCICIO", "P_CLAVE", "P_CENTRO_CONTABLE", "P_BANCO", "P_CUENTA_BANCARIA", "P_CUENTA_CONTABLE",
                                        "P_DESCRIPCION","P_FECHA_APERTURA","P_LOCALIDAD","P_STATUS","P_ALTA_USUARIO"};
                object[] Valores = {    ObjCuentas_Bancarias.Ejercicio, 
                                        ObjCuentas_Bancarias.Clave,
                                        ObjCuentas_Bancarias.Centro_Contable,                                        
                                        ObjCuentas_Bancarias.Banco,
                                        ObjCuentas_Bancarias.Cuenta_Bancaria,
                                        ObjCuentas_Bancarias.Cuenta_Contable,
                                        ObjCuentas_Bancarias.Descripcion,
                                        ObjCuentas_Bancarias.Fecha_Apertura,
                                        ObjCuentas_Bancarias.Localidad,
                                        ObjCuentas_Bancarias.Status,
                                        ObjCuentas_Bancarias.Alta_Usuario
                                   
                                   };
                String[] ParametrosOut = { "p_Bandera"};
                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_CUENTAS_BANCARIAS", ref Verificador, Parametros, Valores, ParametrosOut);
               
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
        public void Cuentas_BancariasEditar(Cuentas_Bancarias ObjCuentas_Bancarias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_CUENTA_BANCARIA", "P_CLAVE", "P_CENTRO_CONTABLE", "P_BANCO", "P_CUENTA_BANCARIA", 
                                        "P_CUENTA_CONTABLE", "P_DESCRIPCION", "P_FECHA_APERTURA",  "P_LOCALIDAD", "P_STATUS"};
                object[] Valores = { ObjCuentas_Bancarias.IdCuenta_Bancaria, ObjCuentas_Bancarias.Clave, ObjCuentas_Bancarias.Centro_Contable, ObjCuentas_Bancarias.Banco, ObjCuentas_Bancarias.Cuenta_Bancaria,
                                     ObjCuentas_Bancarias.Cuenta_Contable, ObjCuentas_Bancarias.Descripcion, ObjCuentas_Bancarias.Fecha_Apertura, ObjCuentas_Bancarias.Localidad, ObjCuentas_Bancarias.Status};
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CUENTAS_BANCARIAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Cuentas_BancariasSelect(ref Cuentas_Bancarias ObjCuentas_Bancarias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID_CUENTA_BANCARIA" };
                object[] Valores = { ObjCuentas_Bancarias.IdCuenta_Bancaria
            };
                string[] ParametrosOut ={                                          
                                          "P_CLAVE",
                                          "P_CENTRO_CONTABLE",
                                          "P_DEPENDENCIA",
                                          "P_BANCO",
                                          "P_CUENTA_BANCARIA",
                                          "P_CUENTA_CONTABLE",
                                          "P_DESCRIPCION",
                                          "P_FECHA_APERTURA",
                                          "P_LOCALIDAD",
                                          "P_STATUS",
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CUENTAS_BANCARIAS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjCuentas_Bancarias = new Cuentas_Bancarias();
                    ObjCuentas_Bancarias.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    ObjCuentas_Bancarias.Centro_Contable = Convert.ToString(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    ObjCuentas_Bancarias.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    ObjCuentas_Bancarias.Banco = Convert.ToString(Cmd.Parameters["P_BANCO"].Value);
                    ObjCuentas_Bancarias.Cuenta_Bancaria = Convert.ToString(Cmd.Parameters["P_CUENTA_BANCARIA"].Value);
                    ObjCuentas_Bancarias.Cuenta_Contable = Convert.ToString(Cmd.Parameters["P_CUENTA_CONTABLE"].Value);
                    ObjCuentas_Bancarias.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    ObjCuentas_Bancarias.Fecha_Apertura = Convert.ToString(Cmd.Parameters["P_FECHA_APERTURA"].Value);
                    ObjCuentas_Bancarias.Localidad = Convert.ToString(Cmd.Parameters["P_LOCALIDAD"].Value);
                    ObjCuentas_Bancarias.Status = Convert.ToChar(Cmd.Parameters["P_STATUS"].Value);
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
