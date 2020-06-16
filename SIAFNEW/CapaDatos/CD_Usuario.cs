using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Globalization;
using CapaEntidad;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Usuario
    {
        public void ValidarUsuario(ref Usuario Usuario, ref string Verificador)
        {
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_usuario", "p_password", "p_sistema" };
                string[] Valores = { Usuario.CUsuario, Usuario.Password, "15830" };

                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmm = CDDatos.GenerarOracleCommandCursor("PKG_CONTRATOS.Verifica_Usuario", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Usuario = new Usuario();
                    Usuario.CUsuario = Convert.ToString(dr.GetValue(0));
                    Usuario.Nombre = Convert.ToString(dr.GetValue(1));
                    Usuario.TipoUsu = Convert.ToString(dr.GetValue(5)); //=="X")?"A":Convert.ToString(dr.GetValue(5));
                    Usuario.Correo_UNACH = Convert.ToString(dr.GetValue(6));
                    Verificador = "0";
                    //Usuario.TipoUsu = (Convert.ToString(dr.GetValue(5)) == "X") ? "A" : Convert.ToString(dr.GetValue(5));
                    //Usuario.TipoUsu = Convert.ToString(dr.GetValue(3));
                    //Usuario.Dependencia = Convert.ToString(dr.GetValue(4));
                }

                CDDatos.LimpiarOracleCommand(ref Cmm);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }

        public void ObtenerUsuario(ref Usuario ObjUsuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_CORREO", "P_ID_SISTEMA" };
                object[] Valores = { ObjUsuario.Correo_UNACH, 15830 };
                string[] ParametrosOut = { "P_USUARIO", "P_TIPO_USU", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("VAL_USUARIO_SISTEMA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjUsuario = new Usuario();
                    ObjUsuario.CUsuario = Convert.ToString(Cmd.Parameters["P_USUARIO"].Value);
                    ObjUsuario.TipoUsu = Convert.ToString(Cmd.Parameters["P_TIPO_USU"].Value);

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


        public void ValidarToken(ref Usuario ObjUsuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("siga");
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_token" };
                object[] Valores = { ObjUsuario.Token };
                string[] ParametrosOut = { "p_usuario", "p_contrasena", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SISTEMAS_TOKEN", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjUsuario = new Usuario();
                    ObjUsuario.CUsuario = Convert.ToString(Cmd.Parameters["p_usuario"].Value);
                    ObjUsuario.Password = Convert.ToString(Cmd.Parameters["p_contrasena"].Value);

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

        public void Inserta_Token(ref Usuario Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("siga");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_token", "p_usuario" };
                object[] Valores = { Usuario.Token, Usuario.CUsuario };
                String[] ParametrosOut = { "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("ins_sistemas_token", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void Verificar_Correo_UNACH(ref Usuario objUsuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_USUARIO" };
                Object[] Valores = { objUsuario.CUsuario };
                String[] ParametrosOut = { "P_RESULTADO", "p_bandera" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_STATUS_MAIL_TEL_USER", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objUsuario.Status = Convert.ToString(Cmd.Parameters["P_RESULTADO"].Value);
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
