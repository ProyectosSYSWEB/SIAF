using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
using System.Web.UI.WebControls;
using System.IO;
#region Hecho por

#endregion
namespace CapaDatos
{
    public class CD_Comun
    {
        public void insertar_datos_sesion(ref Sesion objsesion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null; 
            try
            {
                String[] Parametros = { "P_USUARIO", "P_IP", "P_MAC_ADDRESS", "P_ID_SISTEMA" };
                object[] Valores = { objsesion.Usu_Nombre, objsesion.ip, objsesion.mac_address, objsesion.id_sistema };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SIGA09.INS_GRL_CONTROL_SESION", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void LlenaCombo(string SP, ref List<Comun> list)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string Valor1)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string Valor1, string Valor2)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2 };
                object[] Valores = { Valor1, Valor2 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string Valor1, string Valor2, string Valor3)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3 };
                object[] Valores = { Valor1, Valor2, Valor3 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    else if (dr.FieldCount == 7)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                        Comun.EtiquetaSeis = Convert.ToString(dr.GetValue(6));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string Valor1, string Valor2, string Valor3, string Valor4, string Valor5)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4, parametro5 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4, Valor5 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string parametro6, string Valor1, string Valor2, string Valor3, string Valor4, string Valor5, string valor6)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4, parametro5, parametro6 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4, Valor5, valor6 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }       
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string Valor1, string Valor2, string Valor3, string Valor4)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    else if (dr.FieldCount == 7)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                        Comun.EtiquetaSeis = Convert.ToString(dr.GetValue(6));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string Valor1, string Valor2, string USERBD)
        {
            CD_Datos CDDatos = new CD_Datos(USERBD );
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2 };
                object[] Valores = { Valor1, Valor2 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string Valor1, string USERBD)
        {
            CD_Datos CDDatos = new CD_Datos(USERBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string USERBD)
        {
            CD_Datos CDDatos = new CD_Datos(USERBD );
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }        
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string Valor1, string Valor2, string valor3, string USERBD)
        {
            CD_Datos CDDatos = new CD_Datos(USERBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3 };
                object[] Valores = { Valor1, Valor2, valor3 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string Valor1, string Valor2, string valor3, string valor4, string USERBD)
        {
            CD_Datos CDDatos = new CD_Datos(USERBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4 };
                object[] Valores = { Valor1, Valor2, valor3, valor4 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string Valor1, string Valor2, string valor3, string valor4, string valor5, string USERBD)
        {
            CD_Datos CDDatos = new CD_Datos(USERBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4, parametro5 };
                object[] Valores = { Valor1, Valor2, valor3, valor4, valor5 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void Monitor(string Usuario, string Sistema, string Centro_Contable, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_usuario", "p_id_sistema", "p_centro_contable" };
                String[] Valores = { Usuario, Sistema, Centro_Contable};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Monitor", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    Comun objMonitor = new Comun();
                    objMonitor.Descripcion = Convert.ToString(dr.GetValue(1));
                    List.Add(objMonitor);
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
        public void Monitor_Patrimonio(string Centro_Contable, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_centro_contable" };
                String[] Valores = { Centro_Contable };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Monitor_Patrimonio", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    Comun objMonitor = new Comun();
                    objMonitor.Descripcion = Convert.ToString(dr.GetValue(1));
                    List.Add(objMonitor);
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
        public void Monitor_Estadistica(int Rango, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_rango" };
                String[] Valores = { Convert.ToString(Rango) };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Monitor_Estadisticas", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    Comun objMonitor = new Comun();
                    objMonitor.Descripcion = Convert.ToString(dr.GetValue(1));
                    objMonitor.Etiqueta = Convert.ToString(dr.GetValue(3));
                    objMonitor.EtiquetaTres = Convert.ToString(dr.GetValue(2));
                    objMonitor.EtiquetaDos = "images/" + Convert.ToString(dr.GetValue(4)) + ".png";
                    List.Add(objMonitor);
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
        public void Monitor_EstadisticaPP(string Color, int Rango, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_color", "p_rango" };
                String[] Valores = { Convert.ToString(Color), Convert.ToString(Rango)};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_presupuesto.Obt_Grid_Monitor_Estadisticas", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    Comun objMonitor = new Comun();
                    objMonitor.Descripcion = Convert.ToString(dr.GetValue(1));
                    objMonitor.Etiqueta = Convert.ToString(dr.GetValue(3));
                    objMonitor.EtiquetaTres = Convert.ToString(dr.GetValue(2));
                    objMonitor.EtiquetaDos = "images/" + Convert.ToString(dr.GetValue(4)) + ".png";
                    List.Add(objMonitor);
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
        public void Estadisticas(string tipo, ref string[] datosX, ref int[] datosY)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            int i = 0;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_tipo" };
                String[] Valores = { Convert.ToString(tipo) };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Graficas", ref dr, Parametros, Valores);
                
                while (dr.Read())
                {
                    //string s = Convert.ToString(dr.GetValue(1));

                    Array.Resize(ref datosX, datosX.Length+1);
                    Array.Resize(ref datosY, datosY.Length + 1);

                    datosX[i] = Convert.ToString(dr.GetValue(0));
                    datosY[i] = Convert.ToInt32(dr.GetValue(1));                    
                    i++;
                }

                //Array.Resize(ref datosX, i);

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
        public void Estadisticas_Presupuesto(string tipo, ref string[] datosX, ref int[] datosY)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            int i = 0;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_tipo" };
                String[] Valores = { Convert.ToString(tipo) };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Graficas", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    //string s = Convert.ToString(dr.GetValue(1));

                    Array.Resize(ref datosX, datosX.Length + 1);
                    Array.Resize(ref datosY, datosY.Length + 1);

                    datosX[i] = Convert.ToString(dr.GetValue(0));
                    datosY[i] = Convert.ToInt32(dr.GetValue(1));
                    i++;
                }

                //Array.Resize(ref datosX, i);

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
        public void Estadisticas(int Rango, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            int i = 0;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_tipo" };
                String[] Valores = { "1" };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Graficas", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    //string s = Convert.ToString(dr.GetValue(1));
                    //datosX[i] = Convert.ToString(dr.GetValue(0));
                    //datosY[i] = Convert.ToInt32(dr.GetValue(1));
                    //i++;

                    Comun objGrafica = new Comun();
                    objGrafica.EtiquetaDos = Convert.ToString(dr.GetValue(0));
                    objGrafica.EtiquetaTres = Convert.ToString(dr.GetValue(1));
                    List.Add(objGrafica);
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
        public void LlenaCombo(string SP, ref List<Comun> list, string[] Parametros, string[] Valores)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    else if (dr.FieldCount == 7)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                        Comun.EtiquetaSeis = Convert.ToString(dr.GetValue(6));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }

    }
}
