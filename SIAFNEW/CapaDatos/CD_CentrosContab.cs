using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_CentrosContab
    {
        public void CContabGrid(ref CentrosContab objCentrosContab, ref List<CentrosContab> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"p_ejercicio" };
                String[] Valores = { objCentrosContab.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Centros_Contab", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objCentrosContab = new CentrosContab();
                    objCentrosContab.C_Contab = Convert.ToString(dr.GetValue(0));
                    objCentrosContab.Descrip = Convert.ToString(dr.GetValue(1));
                    objCentrosContab.Id = Convert.ToString(dr.GetValue(2));
                    List.Add(objCentrosContab);
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
        public void InsertarCentroContable(ref CentrosContab objCentrosContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CLAVE", "P_DESCRIPCION", "P_DIRECTOR", "P_ADMINISTRADOR", "P_SALIENTE", "P_ENTRANTE", "P_EJERCICIO" };
                object[] Valores = { objCentrosContab.C_Contab, objCentrosContab.Descrip, objCentrosContab.Director, objCentrosContab.Administrador, objCentrosContab.Saliente, objCentrosContab.Entrante, objCentrosContab.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_CAT_C_CONTAB", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ObtenerDatosCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID", "P_EJERCICIO" };
                object[] Valores = { objCContab.Id, objCContab.Ejercicio };
                string[] ParametrosOut = { "P_CLAVE", "P_DESCRIPCION", "P_DIRECTOR", "P_ADMINISTRADOR", "P_SALIENTE", "P_ENTRANTE", "P_BANDERA"};

                Cmd = CDDatos.GenerarOracleCommand("OBT_CAT_C_CONTAB", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objCContab = new CentrosContab();
                    objCContab.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objCContab.C_Contab = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objCContab.Descrip = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objCContab.Director = Convert.ToString(Cmd.Parameters["P_DIRECTOR"].Value);
                    objCContab.Administrador = Convert.ToString(Cmd.Parameters["P_ADMINISTRADOR"].Value);
                    objCContab.Saliente = Convert.ToString(Cmd.Parameters["P_SALIENTE"].Value);
                    objCContab.Entrante = Convert.ToString(Cmd.Parameters["P_ENTRANTE"].Value);                    
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
        public void EditarCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_EJERCICIO", "P_CLAVE", "P_DESCRIPCION", "P_DIRECTOR", "P_ADMINISTRADOR", "P_SALIENTE", "P_ENTRANTE"};
                object[] Valores = { objCContab.Id, objCContab.Ejercicio, objCContab.C_Contab, objCContab.Descrip, objCContab.Director, objCContab.Administrador, objCContab.Saliente, objCContab.Entrante };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_CAT_C_CONTAB", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarCContab(CentrosContab objCContab, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objCContab.Id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("", ref Verificador, Parametros, Valores, ParametrosOut);

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


        //=========================CONTROL CIERRE DE LOS CENTROS CONTABLES=====================
        public void Control_CierreConsultaGrid(ref CentrosContab ObjControl_Cierre, ref List<CentrosContab> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_ejercicio", "p_sistema" };
                object[] Valores = { ObjControl_Cierre.Ejercicio, ObjControl_Cierre.sistema };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_presupuesto.Obt_Grid_Control_Cierre", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjControl_Cierre = new CentrosContab();
                    ObjControl_Cierre.Id_Control_Cierre = Convert.ToInt32(dr.GetValue(0));
                    ObjControl_Cierre.C_Contab = Convert.ToString(dr.GetValue(1));
                    ObjControl_Cierre.Mes_anio = Convert.ToString(dr.GetValue(2));
                    ObjControl_Cierre.Cierre_Definitivo = Convert.ToString(dr.GetValue(8));
                    //ObjControl_Cierre.Status = "../../images/" + Convert.ToString(dr.GetValue(5)) + ".PNG";
                    List.Add(ObjControl_Cierre);
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
        public void Control_CierreEditar(ref CentrosContab ObjCentros_Contables, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_ID_CONTROL_CIERRE", "P_MES_ANIO", "P_CIERRE_DEFINITIVO" };
                object[] Valores = { ObjCentros_Contables.Id_Control_Cierre, ObjCentros_Contables.Mes_anio, ObjCentros_Contables.Cierre_Definitivo };
                string[] ParametrosOut ={
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONTROL_CIERRE", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Control_CierreGral(ref CentrosContab ObjControl_Cierre, string Tipo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_MES_ANIO", "P_SISTEMA", "P_EJERCICIO", "P_TIPO" };
                object[] Valores = { ObjControl_Cierre.Mes_anio, "PRESUPUESTO", ObjControl_Cierre.Ejercicio, Tipo };
                string[] ParametrosOut ={
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONTROL_CIERRE_GRAL", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
