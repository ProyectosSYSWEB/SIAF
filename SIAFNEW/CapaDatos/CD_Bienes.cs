using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;



namespace CapaDatos
{
   public class CD_Bienes
    {

       public void Consultar_Bienes(ref Bienes ObjBienes, string buscar, ref List<Bienes> List)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand cmm = null;
           try
           {

               OracleDataReader dr = null;
               String[] Parametros = { "P_Clave", "P_Status", "P_Busca" };
               Object[] Valores = { ObjBienes.Partida,ObjBienes.Status,buscar };

               cmm = CDDatos.GenerarOracleCommandCursor("PKG_PATRIMONIO.Obt_Grid_Cat_Bienes", ref dr, Parametros, Valores);

               while (dr.Read())
               {
                   ObjBienes = new Bienes();
                   ObjBienes.Id = Convert.ToString(dr[0]);
                   ObjBienes.Subclase = Convert.ToString(dr[1]);
                   ObjBienes.Clave = Convert.ToString(dr[2]);
                   ObjBienes.Descripcion = Convert.ToString(dr[3]);
                   ObjBienes.Por_lote = Convert.ToString(dr[4]);
                   ObjBienes.Conjunto = Convert.ToString(dr[5]);
                    ObjBienes.Subcuenta = Convert.ToString(dr[6]);
                    ObjBienes.Nivel = Convert.ToString(dr[7]);

                    List.Add(ObjBienes);

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


       public void Consulta_clave(ref Bienes ObjBienes, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {


               string[] ParametrosIn = { "P_PARTIDA"};
               object[] Valores = {ObjBienes.Partida};
               string[] ParametrosOut ={"P_ID_GRUPO", "P_ID_SUBGRUPO", "P_ID_CLASE", "P_SUBCLASE","P_NIVEL", "P_CONSECUTIVO","P_DESPARTIDA","P_BANDERA"};

               Cmd = CDDatos.GenerarOracleCommand("OBT_CVE_BIEN", ref Verificador, ParametrosIn, Valores, ParametrosOut);
               if (Verificador == "0")
               {
                   //ObjBienes = new Bienes();
                   ObjBienes.Grupo = Convert.ToString(Cmd.Parameters["P_ID_GRUPO"].Value);
                   ObjBienes.Subgrupo = Convert.ToString(Cmd.Parameters["P_ID_SUBGRUPO"].Value);
                   ObjBienes.Clase = Convert.ToString(Cmd.Parameters["P_ID_CLASE"].Value);
                   ObjBienes.Subclase = Convert.ToString(Cmd.Parameters["P_SUBCLASE"].Value);
                   ObjBienes.Consecutivo = Convert.ToString(Cmd.Parameters["P_CONSECUTIVO"].Value);
                    ObjBienes.Nivel = Convert.ToString(Cmd.Parameters["P_NIVEL"].Value);
                    ObjBienes.DesPartida = Convert.ToString(Cmd.Parameters["P_DESPARTIDA"].Value);
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


       public void Insertar_Bienes(ref Bienes objBienes, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               String[] Parametros = { "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_ID_GRUPO", "P_ID_SUBGRUPO", "P_ID_CLASE", "P_ID_SUBCLASE", "P_CONSECUTIVO", "P_CUENTA", "P_SUBCUENTA", "P_NIVEL", "P_PARTIDA", "P_POR_LOTE", "P_CONJUNTO" };
               object[] Valores = { objBienes.Clave, objBienes.Status, objBienes.Descripcion, objBienes.Grupo, objBienes.Subgrupo, objBienes.Clase, objBienes.Subclase, objBienes.Consecutivo, objBienes.Cuenta, objBienes.Subcuenta, objBienes.Nivel, objBienes.Partida, objBienes.Por_lote, objBienes.Conjunto }; 
               String[] ParametrosOut = { "p_Bandera" };

               Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_BIENES", ref Verificador, Parametros, Valores, ParametrosOut);

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


       public void Consulta_Bien(ref Bienes ObjBienes, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               string[] ParametrosIn = { "P_ID_BIEN" };
               object[] Valores = { ObjBienes.Id };
               string[] ParametrosOut = { "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_ID_GRUPO", "P_ID_SUBGRUPO", "P_ID_CLASE","P_ID_SUBCLASE","P_CONSECUTIVO","P_CUENTA","P_SUBCUENTA","P_NIVEL","P_PARTIDA","P_POR_LOTE","P_CONJUNTO", "p_bandera" };

               Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_PAT_BIENES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
               if (Verificador == "0")
               {
                   ObjBienes = new Bienes();
                   ObjBienes.Status = Convert.ToString(Cmd.Parameters["P_STATUS"].Value);
                   ObjBienes.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                   ObjBienes.Grupo = Convert.ToString(Cmd.Parameters["P_ID_GRUPO"].Value);
                   ObjBienes.Subgrupo = Convert.ToString(Cmd.Parameters["P_ID_SUBGRUPO"].Value);
                   ObjBienes.Clase = Convert.ToString(Cmd.Parameters["P_ID_CLASE"].Value);
                   ObjBienes.Subclase = Convert.ToString(Cmd.Parameters["P_ID_SUBCLASE"].Value);
                   ObjBienes.Consecutivo = Convert.ToString(Cmd.Parameters["P_CONSECUTIVO"].Value);
                   ObjBienes.Cuenta = Convert.ToString(Cmd.Parameters["P_CUENTA"].Value);
                   ObjBienes.Subcuenta = Convert.ToString(Cmd.Parameters["P_SUBCUENTA"].Value);
                   ObjBienes.Nivel = Convert.ToString(Cmd.Parameters["P_NIVEL"].Value);
                   ObjBienes.Partida = Convert.ToString(Cmd.Parameters["P_PARTIDA"].Value);
                   ObjBienes.Por_lote = Convert.ToString(Cmd.Parameters["P_POR_LOTE"].Value);
                   ObjBienes.Conjunto = Convert.ToString(Cmd.Parameters["P_CONJUNTO"].Value);

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


       public void Eliminar_Bienes(ref Bienes objBienes, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               String[] Parametros = { "P_Id_Bien" };
               object[] Valores = { objBienes.Id };
               String[] ParametrosOut = { "p_BANDERA" };

               Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_PAT_BIENES", ref Verificador, Parametros, Valores, ParametrosOut);

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

       public void Editar_Bienes(ref Bienes ObjBienes, ref string Verificador)
       {
           CD_Datos CDDatos = new CD_Datos();
           OracleCommand Cmd = null;
           try
           {
               String[] Parametros = { "P_ID_BIEN", "P_STATUS", "P_CUENTA", "P_SUBCUENTA", "P_NIVEL", "P_POR_LOTE", "P_CONJUNTO","P_DESCRIPCION" };
               object[] Valores = { ObjBienes.Id,ObjBienes.Status, ObjBienes.Cuenta, ObjBienes.Subcuenta,ObjBienes.Nivel, ObjBienes.Por_lote, ObjBienes.Conjunto, ObjBienes.Descripcion };
               String[] ParametrosOut = { "p_Bandera" };

               Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_BIENES", ref Verificador, Parametros, Valores, ParametrosOut);
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
