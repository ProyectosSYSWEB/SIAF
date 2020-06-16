﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_Datos
    {

        #region Variable

        private OracleConnection Cnn;
        private OracleTransaction trans = null;
        OracleCommand functionReturnValue = default(OracleCommand);
        OracleCommand cmd = default(OracleCommand);

        #endregion
        #region Constructor
        public CD_Datos()
        {
            string conexion = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=148.222.11.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=SAF1)));User Id=secadmin;Password=DSIA2014;Enlist=false;Pooling=true";
            this.Cnn = new OracleConnection(conexion);
        }
        public CD_Datos(string userBD)
        {
            string StrConexion = string.Empty;
            if (userBD == "ADQUISICIONES") StrConexion = "Data Source=dsia;User ID=adquisiciones; Password=UNACH09; Unicode=True";
            else if (userBD == "siga") StrConexion = "Data Source=dsia;User ID=siga09; Password=m3f1st0; Unicode=True";
            else
                StrConexion = "Data Source=dsia;User ID=SAF; Password=dsia2014; Unicode=True";

            this.Cnn = new OracleConnection(StrConexion);
        }
        #endregion
        #region Métodos Transacción

        public void StartTrans()
        {
            if (Cnn.State == ConnectionState.Closed) Cnn.Open();
            if (trans == null) trans = Cnn.BeginTransaction();
        }
        public void CommitTrans()
        {
            trans.Commit();
            trans.Dispose();
            Cnn.Close();
        }
        public void RollBackTrans()
        {
            trans.Rollback();
            trans.Dispose();
            Cnn.Close();
        }
        #endregion
        #region Métodos
        #region ExecuteReader
        public OracleCommand GenerarOracleCommand(string SP, ref OracleDataReader dr)
        {

            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();
                StartTrans();
                dr = functionReturnValue.ExecuteReader(CommandBehavior.CloseConnection);
                CommitTrans();
            }
            catch (Exception ex)
            {
                RollBackTrans();
                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, string tableName, ref DataTable dt)
        {

            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null)
                {
                    Cnn.Open();
                }
                OracleDataAdapter da = new OracleDataAdapter(functionReturnValue);
                dt = new DataTable(tableName);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, string tableName, ref DataTable dt, string[] Parametros, object[] Valores)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];


                OracleDataAdapter da = new OracleDataAdapter(functionReturnValue);
                dt = new DataTable(tableName);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];
                dr = functionReturnValue.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #region Cursor
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                functionReturnValue.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dr = functionReturnValue.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            string nombre = SP;
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (trans != null) cmd.Transaction = trans;
                if (trans == null)
                {
                    Cnn.Open();
                }
                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];

                cmd.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                dr = cmd.ExecuteReader();
                return cmd;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores, string[] ParametrosOut)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                    {
                        functionReturnValue.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];
                    }
                for (int i = 0; i < ParametrosOut.Length; i++)
                {
                    functionReturnValue.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
                }

                functionReturnValue.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dr = functionReturnValue.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #endregion
        #endregion
        #region ExecuteScalar
        public OracleCommand GenerarOracleCommand(string SP, ref string verificador)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                verificador = Convert.ToString(functionReturnValue.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, ref string verificador, string[] Parametros, object[] Valores)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];
                object res = functionReturnValue.ExecuteScalar();
                verificador = Convert.ToString(res);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, object resultado, string[] Parametros, object[] Valores)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];
                resultado = functionReturnValue.ExecuteScalar();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #endregion
        #region ExecuteNonQuery

        public OracleCommand GenerarOracleCommand(string SP, ref string Verificador, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            OracleCommand cmd = new OracleCommand(SP, Cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string valor = "";
            //byte[] blob;


            for (int i = 0; i < ParametrosIn.Length; i++)
            {
                valor = Valores[i].GetType().Name;
                //string tipo = valor.GetType().Name;
                if (valor == "Int32")
                {
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Int32).Value = Valores[i];
                }
                else if (valor == "Double")
                {
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Double).Value = Valores[i];
                }
                else if (valor == "Byte[]")
                {
                    //blob = (byte[])Valores[i];
                    byte[] blob_img = (byte[])Valores[i];
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Blob).Value = blob_img;
                }
                else
                {
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = Valores[i];
                }

            }

            for (int i = 0; i < ParametrosOut.Length; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
            }


            try
            {
                if (trans != null) cmd.Transaction = trans;
                if (trans == null) Cnn.Open();
                cmd.ExecuteNonQuery();
                Verificador = cmd.Parameters["P_Bandera"].Value.ToString();
                return cmd;
            }


            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public OracleCommand GenerarOracleCommand(string SP, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            OracleCommand cmd = new OracleCommand(SP, Cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            for (int i = 0; i < ParametrosIn.Length; i++)
            {
                cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = Valores[i];
            }

            for (int i = 0; i < ParametrosOut.Length; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
            }


            try
            {
                if (trans != null) cmd.Transaction = trans;
                if (trans == null) Cnn.Open();
                cmd.ExecuteNonQuery();

                return cmd;
            }


            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public OracleCommand GenerarOracleCommand_NonQuery(string SP, string[] Parametros, object[] Valores)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];
                functionReturnValue.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            return functionReturnValue;
        }
        #endregion
        #region ExecuteAdapter
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataAdapter da, string[] Parametros, object[] Valores)
        {
            try
            {
                cmd = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];
                functionReturnValue.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #endregion
        #region Limpiar
        public void LimpiarOracleCommand(ref OracleCommand Cmm)
        {
            try
            {
                if (Cmm != null)
                {
                    Cmm.Connection.Close();
                    Cmm.Connection.Dispose();
                    Cmm.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                if (Cnn.State != System.Data.ConnectionState.Closed)
                {
                    Cnn.Close();
                }
            }
        }
        #endregion
        #endregion
    }
}
