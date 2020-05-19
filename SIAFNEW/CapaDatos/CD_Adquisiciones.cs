using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;


namespace CapaDatos
{
    public  class CD_Adquisiciones
    {
        public void Insertar_Solicitud_Compra(ref Adquisicion objadquisiciones, ref string Verificador)
        {
            CD_Datos CapaDatos = new CD_Datos("ADQUISICIONES");
            try
            {

                CapaDatos.StartTrans();
                string[] ParametrosIn ={

                                            "P_ID_RESPONSABLE",
                                            "P_FECHA_SOLICITUD",
                                            "P_USUARIO",
                                            "P_LUGAR_ENTREGA",
                                            "P_ID",
                                            "P_OBJ_PARTICULAR",
                                            "P_JUSTIFICACION",
                                            "P_ID_UR"         ,  
                                            "P_ID_TIPO_COMPRA" , 
                                            "P_COMENTARIOS" 
                                           
                                       };
                Object[] Valores ={
                                    objadquisiciones.Responsable,
                                    objadquisiciones.Fecha_Solicitud ,
                                    objadquisiciones.Usu_nombre ,
                                    objadquisiciones.Lugar_Entrega,
                                    objadquisiciones.ID,
                                    objadquisiciones.Obj_Particular,
                                    objadquisiciones.Justificacion ,
                                    objadquisiciones.ID_UR,
                                    objadquisiciones.Tipo_Compra,
                                    objadquisiciones.Comentario 
                                  };

                string[] ParametrosOut ={
                                        "p_bandera", "p_num_solicitud", "P_ID_SOLICITUD"
                                       
                };

                OracleCommand OracleCmd = CapaDatos.GenerarOracleCommand("ins_adq_solicitud_compra", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                objadquisiciones.Num_Solicitud = Convert.ToString(OracleCmd.Parameters["p_num_solicitud"].Value);
                objadquisiciones.Id_Solicitud  = Convert.ToString(OracleCmd.Parameters["p_id_solicitud"].Value);
                if (Verificador == "0")
                {

                    CapaDatos.CommitTrans();
                }
                else
                    CapaDatos.RollBackTrans();
                    CapaDatos.LimpiarOracleCommand(ref OracleCmd);

            }
            catch (Exception ex)
            {
                CapaDatos.RollBackTrans();
                throw new Exception(ex.Message);
            }
        }

        public void Tabla_informativa(ref Adquisicion  objadquisiciones, ref List<Adquisicion > List)
        {
            CD_Datos CDDatos = new CD_Datos("ADQUISICIONES");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_usuario" };
                Object[] Valores = { Convert.ToInt32(objadquisiciones.ejercicio), objadquisiciones.Usu_nombre    };
               
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_spada.obt_grid_resumen_status", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objadquisiciones = new Adquisicion();
                    objadquisiciones.ID_UR  = Convert.ToString(dr[1]);
                    objadquisiciones.Descripcion  = Convert.ToString(dr[2]);
                    objadquisiciones.Registrada  = Convert.ToString(dr[3]);
                    objadquisiciones.Solicitada  = Convert.ToString(dr[4]);
                    objadquisiciones.Denegada = Convert.ToString(dr[5]);
                    objadquisiciones.Autorizada  = Convert.ToString(dr[6]);
                    objadquisiciones.Cotizacion  = Convert.ToString(dr[7]);
                    objadquisiciones.Visto_Bueno  = Convert.ToString(dr[8]);
                    objadquisiciones.Concluida  = Convert.ToString(dr[9]);
                    objadquisiciones.Cancelada  = Convert.ToString(dr[10]);
                    objadquisiciones.Total  = Convert.ToString(dr[11]);
                    objadquisiciones.Avance  = Convert.ToString(dr[12]);
                  
                    List.Add(objadquisiciones );

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
        public void Grid_Solicitudes_X_Dependencias(ref Adquisicion objadquisiciones, ref List<Adquisicion> List)
        {
            CD_Datos CDDatos = new CD_Datos("ADQUISICIONES");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_usuario" };
                Object[] Valores = { objadquisiciones.ejercicio, objadquisiciones.Usu_nombre };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_SPADA_SAF.Obt_grid_solicitud_usuario", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objadquisiciones = new Adquisicion();
                    objadquisiciones.ID_UR = Convert.ToString(dr[1]);
                    objadquisiciones.Descripcion = Convert.ToString(dr[2]);
                    objadquisiciones.Registrada = Convert.ToString(dr[3]);
                    objadquisiciones.Solicitada = Convert.ToString(dr[4]);
                    objadquisiciones.Denegada = Convert.ToString(dr[5]);
                    objadquisiciones.Autorizada = Convert.ToString(dr[6]);
                    objadquisiciones.Cotizacion = Convert.ToString(dr[7]);
                    objadquisiciones.Visto_Bueno = Convert.ToString(dr[8]);
                    objadquisiciones.Cancelada = Convert.ToString(dr[9]);
                    objadquisiciones.Concluida = Convert.ToString(dr[10]);
                   
                    List.Add(objadquisiciones);

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

        public void Grid_Solicitudes_X_UR(ref Adquisicion objadquisiciones, ref List<Adquisicion> List)
        {
            CD_Datos CDDatos = new CD_Datos("ADQUISICIONES");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_fecha_ini" , "p_fecha_fin" , "p_id_ur", "p_status" };
                Object[] Valores = { objadquisiciones.fecha_ini , objadquisiciones .fecha_fin , objadquisiciones.Dependencia  , objadquisiciones.status };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_SPADA_SAF.Obt_grid_solicitud_ur", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objadquisiciones = new Adquisicion();
                    objadquisiciones.Obj_Particular  = Convert.ToString(dr[0]);
                    objadquisiciones.Num_Solicitud  = Convert.ToString(dr[1]);
                    objadquisiciones.Fecha_Solicitud  = Convert.ToString(dr[2]);
                    objadquisiciones.Responsable  = Convert.ToString(dr[3]);

                    List.Add(objadquisiciones);

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
        public void Grid_codigo(ref Adquisicion objadquisiciones, ref List<Adquisicion> List)
        {
            CD_Datos CDDatos = new CD_Datos("ADQUISICIONES");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_funcion_programa", "p_subprograma", "p_proyecto", "p_partida", "p_fuente" };
                Object[] Valores = { objadquisiciones.Dependencia, objadquisiciones.Funcion_programa, objadquisiciones.Subprograma, objadquisiciones.Proyecto, objadquisiciones.Partida, objadquisiciones.Fuente };        
                
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_spada.obt_grid_saldo_cod_program", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objadquisiciones = new Adquisicion();
                    objadquisiciones.Dependencia  = Convert.ToString(dr[0]);
                    objadquisiciones.Funcion_programa  = Convert.ToString(dr[1]);
                    objadquisiciones.Subprograma   = Convert.ToString(dr[2]);
                    objadquisiciones.Proyecto  = Convert.ToString(dr[3]);
                    objadquisiciones.Partida  = Convert.ToString(dr[4]);
                    objadquisiciones.Fuente  = Convert.ToString(dr[5]);
                    objadquisiciones.Codigo_programativo  = Convert.ToString(dr[6]);
                    objadquisiciones.Autorizacion  = Convert.ToString(dr[7]);
                    objadquisiciones.Disponible  = Convert.ToString(dr[8]);
                    
                    List.Add(objadquisiciones);

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

    }
}
