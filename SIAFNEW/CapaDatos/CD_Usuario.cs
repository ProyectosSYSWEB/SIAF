﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
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
                string[] Valores = { Usuario.CUsuario, Usuario.Password,"1"};

                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmm = CDDatos.GenerarOracleCommandCursor("PKG_CONTRATOS.Verifica_Usuario", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Usuario = new Usuario();
                    Usuario.CUsuario = Convert.ToString(dr.GetValue(0));
                    Usuario.Nombre = Convert.ToString(dr.GetValue(1));
                    Usuario.TipoUsu = Convert.ToString(dr.GetValue(5)); //=="X")?"A":Convert.ToString(dr.GetValue(5));
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

    }
}
