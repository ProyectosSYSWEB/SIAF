using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Configuracion_forms
    {
        public void Consultar_Configuraciones(ref Configuracion_forms ObjConfiguracion_forms, string buscar, ref List<Configuracion_forms> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "P_Sistema", "P_Buscar" };
                Object[] Valores = { ObjConfiguracion_forms.Sistema, buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PATRIMONIO.Obt_Grid_Configuracion_Form", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjConfiguracion_forms = new Configuracion_forms();
                    ObjConfiguracion_forms.Id = Convert.ToString(dr[0]);
                    ObjConfiguracion_forms.Sistema = Convert.ToString(dr[1]);
                    ObjConfiguracion_forms.Formato = Convert.ToString(dr[2]);
                    ObjConfiguracion_forms.Posicion= Convert.ToString(dr[3]);
                    ObjConfiguracion_forms.Nombre= Convert.ToString(dr[4]);
                    ObjConfiguracion_forms.Puesto = Convert.ToString(dr[5]);

                    List.Add(ObjConfiguracion_forms);

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


        public void Insertar_Configuracion_forms(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_SISTEMA", "P_FORMATO", "P_POSICION", "P_NOMBRE", "P_PUESTO"};
                object[] Valores = { objConfiguracion_forms.Sistema, objConfiguracion_forms.Formato, objConfiguracion_forms.Posicion, objConfiguracion_forms.Nombre, objConfiguracion_forms.Puesto };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_CONFIGURACION_FORM", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void Editar_Configuracion_forms(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID","P_SISTEMA", "P_FORMATO", "P_POSICION", "P_NOMBRE", "P_PUESTO" };
                object[] Valores = { objConfiguracion_forms.Id, objConfiguracion_forms.Sistema, objConfiguracion_forms.Formato, objConfiguracion_forms.Posicion, objConfiguracion_forms.Nombre, objConfiguracion_forms.Puesto };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONFIGURACION_FORM", ref Verificador, Parametros, Valores, ParametrosOut);

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


        public void Consulta_ConfiguracionForm(ref Configuracion_forms ObjConfiguracion_forms, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { ObjConfiguracion_forms.Id };
                string[] ParametrosOut = { "P_SISTEMA", "P_FORMATO", "P_POSICION", "P_NOMBRE", "P_PUESTO", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CONFIGURACION_FORM", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjConfiguracion_forms = new Configuracion_forms();
                    ObjConfiguracion_forms.Sistema = Convert.ToString(Cmd.Parameters["P_Sistema"].Value);
                    ObjConfiguracion_forms.Formato = Convert.ToString(Cmd.Parameters["P_Formato"].Value);
                    ObjConfiguracion_forms.Posicion = Convert.ToString(Cmd.Parameters["P_Posicion"].Value);
                    ObjConfiguracion_forms.Nombre = Convert.ToString(Cmd.Parameters["P_Nombre"].Value);
                    ObjConfiguracion_forms.Puesto = Convert.ToString(Cmd.Parameters["P_Puesto"].Value);

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


        public void Eliminar_Configuracion_forms(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objConfiguracion_forms.Id };
                String[] ParametrosOut = { "p_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_CONFIGURACION_FORM", ref Verificador, Parametros, Valores, ParametrosOut);

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
