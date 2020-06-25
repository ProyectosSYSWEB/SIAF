using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
   public class CD_Basicos
    {
       public void ConsultarBasicos(ref Basicos objBasicos, string buscar, ref List<Basicos> List)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand cmm = null;
           try
           {

               OracleDataReader dr = null;
               String[] Parametros = { "p_tipo", "p_status", "p_buscar" };
               Object[] Valores = { objBasicos.tipo, objBasicos.status, buscar };

               cmm = CDDatos.GenerarOracleCommandCursor("PKG_PATRIMONIO.Obt_Grid_Basicos", ref dr, Parametros, Valores);

               while (dr.Read())
               {
                   objBasicos = new Basicos();
                   objBasicos.id = Convert.ToString(dr[0]);
                   objBasicos.tipo = Convert.ToString(dr[1]);
                   objBasicos.clave = Convert.ToString(dr[2]);
                   objBasicos.status= Convert.ToString(dr[3]);
                   objBasicos.descripcion = Convert.ToString(dr[4]);
                   objBasicos.valor = Convert.ToString(dr[5]);
                   objBasicos.orden= Convert.ToString(dr[6]);

                   List.Add(objBasicos);

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


       public void insertar_Basicos(ref Basicos objBasicos, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               String[] Parametros = { "P_TIPO", "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_VALOR", "P_ORDEN"};
               object[] Valores = {  objBasicos.tipo, objBasicos.clave, objBasicos.status, objBasicos.descripcion, objBasicos.valor, objBasicos.orden };
               String[] ParametrosOut = { "p_Bandera" };

               Cmd = CDDatos.GenerarOracleCommand("INS_SAF_BASICOS", ref Verificador, Parametros, Valores, ParametrosOut);

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


       public void Editar_Basicos(ref Basicos objBasicos, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               String[] Parametros = { "P_ID", "P_TIPO", "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_VALOR", "P_ORDEN" };
               object[] Valores = { objBasicos.id, objBasicos.tipo, objBasicos.clave, objBasicos.status, objBasicos.descripcion, objBasicos.valor, objBasicos.orden };
               String[] ParametrosOut = { "p_Bandera" };

               Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_BASICOS", ref Verificador, Parametros, Valores, ParametrosOut);
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



       public void Consulta_Basico(ref Basicos ObjBasicos, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               string[] ParametrosIn = { "p_id" };
               object[] Valores = { ObjBasicos.id };
               string[] ParametrosOut = { "P_TIPO", "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_VALOR", "P_ORDEN", "p_bandera" };

               Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_BASICOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
               if (Verificador == "0")
               {
                   ObjBasicos = new Basicos();
                   ObjBasicos.tipo = Convert.ToString(Cmd.Parameters["P_tipo"].Value);
                   ObjBasicos.clave = Convert.ToString(Cmd.Parameters["p_clave"].Value);
                   ObjBasicos.status = Convert.ToString(Cmd.Parameters["p_status"].Value);
                   ObjBasicos.descripcion = Convert.ToString(Cmd.Parameters["p_descripcion"].Value);
                   ObjBasicos.valor = Convert.ToString(Cmd.Parameters["p_valor"].Value);
                   ObjBasicos.orden = Convert.ToString(Cmd.Parameters["p_orden"].Value);
           
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

       public void Eliminar_Basico(ref Basicos objBasicos, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               String[] Parametros = { "P_ID" };
               object[] Valores = { objBasicos.id };
               String[] ParametrosOut = { "p_Bandera" };

               Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_BASICOS", ref Verificador, Parametros, Valores, ParametrosOut);

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
