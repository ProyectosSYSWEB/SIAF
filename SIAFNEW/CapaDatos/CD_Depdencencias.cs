using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Depdencencias
    {
        public void DependenciasGrid(ref Dependencias objDependencia, ref List<Dependencias> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_CENTRO_CONTAB", "P_EJERCICIO" };
                String[] Valores = { objDependencia.C_Contab, Convert.ToString( objDependencia.Ejercicio) };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Saf_Presup_Depcias", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objDependencia = new Dependencias();
                    objDependencia.C_Contab = Convert.ToString(dr.GetValue(0));
                    objDependencia.Depend = Convert.ToString(dr.GetValue(1));
                    objDependencia.Descrip = Convert.ToString(dr.GetValue(2));
                    objDependencia.Administ = Convert.ToString(dr.GetValue(3));
                    objDependencia.Titular = Convert.ToString(dr.GetValue(4));
                    objDependencia.Titular_Puesto = Convert.ToString(dr.GetValue(5));
                    objDependencia.Id = Convert.ToString(dr.GetValue(6));
                    List.Add(objDependencia);
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

        public void InsertarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_C_CONTAB", "P_CLAVE", "P_DESCRIPCION", "P_TITULAR", "P_ADMINISTRADOR", "P_DOMICILIO", "P_ID_ESTADO", "P_ID_MUNICIPIO", "P_ZONA_ECONOMICA", "P_TEL_TITULAR", "P_CEL_TITULAR", "P_TEL_ADMIN", "P_CEL_ADMIN", "P_NOMBRAMIENTO", "P_EJERCICIO" };
                object[] Valores = { objDependencias.C_Contab, objDependencias.Clave, objDependencias.Descrip, objDependencias.Titular, objDependencias.Administ, objDependencias.Domicilio, objDependencias.Id_Estado, objDependencias.Id_Municipio, objDependencias.Zona_Economica, objDependencias.Tel_Titular, objDependencias.Cel_Titular, objDependencias.Tel_Admin, objDependencias.Cel_Admin, objDependencias.Nombramiento, objDependencias.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRES_CAT_DEPEN", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void EliminarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID","P_EJERCICIO" };
                object[] Valores = { objDependencias.Id, objDependencias.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_CAT_SAF_PRESUP_DEPEND", ref Verificador, Parametros, Valores, ParametrosOut);

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


        public void ObtenerDatosDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID", "P_EJERCICIO" };
                object[] Valores = { objDependencias.Id, objDependencias.Ejercicio };
                string[] ParametrosOut = { "P_C_CONTAB", "P_CLAVE", "P_DESCRIPCION", "P_TITULAR", "P_ADMINISTRADOR", "P_DOMICILIO", "P_ID_ESTADO", "P_ID_MUNICIPIO", 
                    "P_ZONA_ECONOMICA", "P_TEL_TITULAR", "P_CEL_TITULAR", "P_CEL_ADMIN", "P_TEL_ADMIN", "P_NOMBRAMIENTO", "P_ADMINIST_PUESTO", "P_TITULAR_PUESTO", "P_BANDERA"};

                Cmd = CDDatos.GenerarOracleCommand("OBT_CAT_DEPEND", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objDependencias = new Dependencias();
                    objDependencias.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objDependencias.C_Contab = Convert.ToString(Cmd.Parameters["P_C_CONTAB"].Value);
                    objDependencias.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objDependencias.Descrip = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objDependencias.Titular = Convert.ToString(Cmd.Parameters["P_TITULAR"].Value);
                    objDependencias.Administ = Convert.ToString(Cmd.Parameters["P_ADMINISTRADOR"].Value);
                    objDependencias.Domicilio = Convert.ToString(Cmd.Parameters["P_DOMICILIO"].Value);
                    objDependencias.Id_Estado = Convert.ToString(Cmd.Parameters["P_ID_ESTADO"].Value);
                    objDependencias.Id_Municipio = Convert.ToString(Cmd.Parameters["P_ID_MUNICIPIO"].Value);
                    objDependencias.Zona_Economica = Convert.ToString(Cmd.Parameters["P_ZONA_ECONOMICA"].Value);
                    objDependencias.Tel_Titular = Convert.ToString(Cmd.Parameters["P_TEL_TITULAR"].Value);
                    objDependencias.Cel_Titular = Convert.ToString(Cmd.Parameters["P_CEL_TITULAR"].Value);
                    objDependencias.Cel_Admin = Convert.ToString(Cmd.Parameters["P_CEL_ADMIN"].Value);
                    objDependencias.Tel_Admin = Convert.ToString(Cmd.Parameters["P_TEL_ADMIN"].Value);
                    objDependencias.Nombramiento = Convert.ToString(Cmd.Parameters["P_NOMBRAMIENTO"].Value);
                    objDependencias.Admin_Puesto = Convert.ToString(Cmd.Parameters["P_ADMINIST_PUESTO"].Value);
                    objDependencias.Titular_Puesto = Convert.ToString(Cmd.Parameters["P_TITULAR_PUESTO"].Value);
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
        public void EditarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_EJERCICIO", "P_C_CONTAB", "P_CLAVE", "P_DESCRIPCION", "P_TITULAR", "P_ADMINISTRADOR", "P_DOMICILIO", "P_ID_ESTADO", "P_ID_MUNICIPIO", "P_ZONA_ECONOMICA", "P_TEL_TITULAR", "P_CEL_TITULAR", "P_TEL_ADMIN", "P_CEL_ADMIN", "P_NOMBRAMIENTO", "P_ADMINIST_PUESTO", "P_TITULAR_PUESTO" };
                object[] Valores = { objDependencias.Id, objDependencias.Ejercicio, objDependencias.C_Contab, objDependencias.Clave, objDependencias.Descrip, objDependencias.Titular, objDependencias.Administ, objDependencias.Domicilio, objDependencias.Id_Estado, objDependencias.Id_Municipio, objDependencias.Zona_Economica, objDependencias.Tel_Titular, objDependencias.Cel_Titular, objDependencias.Tel_Admin, objDependencias.Cel_Admin, objDependencias.Nombramiento, objDependencias.Admin_Puesto, objDependencias.Titular_Puesto };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CAT_DEPEND", ref Verificador, Parametros, Valores, ParametrosOut);

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
