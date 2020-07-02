using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Pres_Plantilla
    {
        public void ConsultaGrid_New_Semestre(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_SEMESTRE", "P_DEPENDENCIA" };
                String[] Valores = { objPlantilla.Semestre, objPlantilla.Dependencia };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Pres.OBT_Grid_New_Semestre", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPlantilla = new Pres_Plantilla();
                    objPlantilla.Dependencia = Convert.ToString(dr.GetValue(0));
                    objPlantilla.Descripcion = Convert.ToString(dr.GetValue(1));
                    objPlantilla.Total = Convert.ToString(dr.GetValue(2));                   
                    List.Add(objPlantilla);
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
        public void ConsultaGrid_Otr(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_Id", "P_Plantilla","P_TIPO_P" };
                String[] Valores = { objPlantilla.Id, objPlantilla.Plantilla, objPlantilla.Tipo_p };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Pres.OBT_Grid_Otr", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPlantilla = new Pres_Plantilla();
                    objPlantilla.Id = Convert.ToString(dr.GetValue(0));
                    objPlantilla.Descripcion = Convert.ToString(dr.GetValue(1));
                    objPlantilla.Cantidad = Convert.ToString(dr.GetValue(2));
                    List.Add(objPlantilla);
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
        public void ConsultaGrid_Plantilla(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_SEMESTRE", "P_DEPENDENCIA", "P_BUSCAR" };
                String[] Valores = { objPlantilla.Semestre, objPlantilla.Dependencia, objPlantilla.Buscar};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Pres.OBT_Grid_Plantillas", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPlantilla = new Pres_Plantilla();                    
                    objPlantilla.Id_Empleado  = Convert.ToString(dr.GetValue(0));
                    objPlantilla.Plaza = Convert.ToString(dr.GetValue(1));
                    objPlantilla.Nombre = Convert.ToString(dr.GetValue(2));
                    objPlantilla.Dependencia = Convert.ToString(dr.GetValue(3));
                    objPlantilla.Id = Convert.ToString(dr.GetValue(4));
                    List.Add(objPlantilla);
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
        public void ConsultaGrid_Historico(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_RFC"};
                String[] Valores = { objPlantilla.RFC};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Pres.OBT_Grid_Mov_Personal", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPlantilla = new Pres_Plantilla();
                    objPlantilla.Id_Empleado = Convert.ToString(dr.GetValue(0));
                    objPlantilla.Nombre = Convert.ToString(dr.GetValue(1));
                    objPlantilla.Tipo_p = Convert.ToString(dr.GetValue(2));
                    objPlantilla.Plaza = Convert.ToString(dr.GetValue(3));
                    objPlantilla.Status = Convert.ToString(dr.GetValue(4));
                    objPlantilla.RFC= Convert.ToString(dr.GetValue(5));
                    objPlantilla.Dependencia = Convert.ToString(dr.GetValue(6));
                    objPlantilla.Categoria = Convert.ToString(dr.GetValue(7));
                    objPlantilla.Fecha_Fin= Convert.ToString(dr.GetValue(8));
                    List.Add(objPlantilla);
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
        public void Consultar_Plantilla(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_id", "P_Tip_P" };
                object[] Valores = { objPlantilla.Id, objPlantilla.Tipo_p};
                string[] ParametrosOut = { "P_Nombre", "P_PLaza", "P_Status", "P_Categoria", "P_Cga_teo", "P_Tot_int", "P_Tot_tem", "P_Tot_def","P_Tot_det", "P_Observacion", "P_Fecha_Mov","P_Fecha_ingreso", "P_Num_oficio", "P_Codigo",
                                           "P_CERRADA", "P_FECHA_INI","P_FECHA_FIN","P_RFC","P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_DPP_PLANTILLA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objPlantilla = new Pres_Plantilla();                    
                    objPlantilla.Nombre = Convert.ToString(Cmd.Parameters["P_Nombre"].Value);
                    objPlantilla.Plaza = Convert.ToString(Cmd.Parameters["P_PLaza"].Value);
                    objPlantilla.Status = Convert.ToString(Cmd.Parameters["P_Status"].Value);
                    objPlantilla.Categoria = Convert.ToString(Cmd.Parameters["P_Categoria"].Value);
                    objPlantilla.Cga_teo = Convert.ToString(Cmd.Parameters["P_Cga_teo"].Value);
                    objPlantilla.Tot_int = Convert.ToString(Cmd.Parameters["P_Tot_int"].Value);
                    objPlantilla.Tot_tem = Convert.ToString(Cmd.Parameters["P_Tot_tem"].Value);
                    objPlantilla.Tot_def = Convert.ToString(Cmd.Parameters["P_Tot_def"].Value);
                    objPlantilla.Tot_det = Convert.ToString(Cmd.Parameters["P_Tot_det"].Value);
                    objPlantilla.Obsevasiones = Convert.ToString(Cmd.Parameters["P_Observacion"].Value);
                    objPlantilla.Fecha_mov = Convert.ToString(Cmd.Parameters["P_Fecha_Mov"].Value);
                    objPlantilla.Fecha_Ingreso = Convert.ToString(Cmd.Parameters["P_Fecha_Ingreso"].Value);
                    objPlantilla.Oficio = Convert.ToString(Cmd.Parameters["P_Num_oficio"].Value);
                    objPlantilla.Codigo = Convert.ToString(Cmd.Parameters["P_Codigo"].Value);
                    objPlantilla.Cerrada= Convert.ToString(Cmd.Parameters["P_CERRADA"].Value);
                    objPlantilla.Fecha_Ini = Convert.ToString(Cmd.Parameters["P_Fecha_ini"].Value);
                    objPlantilla.Fecha_Fin= Convert.ToString(Cmd.Parameters["P_Fecha_fin"].Value);
                    objPlantilla.RFC = Convert.ToString(Cmd.Parameters["P_RFC"].Value);
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
        public void Delete_Plantilla(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objPlantilla.Id };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DELETE_DPP_Plantilla", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Delete_OTR(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { objPlantilla.Id };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DELETE_DPP_OTR", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ins_otro_posterior(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID","P_USUARIO" };
                object[] Valores = { objPlantilla.Id, objPlantilla.Usuario };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_OTRO_POSTERIOR", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Insertar_DPP_Otr(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_PLANTILLA", "P_Actividad", "P_CANTIDAD", "P_TIPO", "P_Usuario", "P_P_P" };
                object[] Valores =    { objplantilla.Id,objplantilla.Actividad, objplantilla.Cantidad, objplantilla.Plantilla, objplantilla.Usuario, objplantilla.id_p_p};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_DPP_OTR", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Sel_Valida_Cierre(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_Semestre", "P_dependencia" };
                object[] Valores = { objplantilla.Semestre, objplantilla.Dependencia};
                String[] ParametrosOut = { "P_Cerrada", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_VALIDA_CIERRE", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objplantilla = new Pres_Plantilla();
                    objplantilla.Cerrada = Convert.ToString(Cmd.Parameters["P_Cerrada"].Value);
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
        public void cerrar_plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_DEPENDENCIA", "P_SEMESTRE", "P_Usuario" };
                object[] Valores = { objplantilla.Dependencia, objplantilla.Semestre, objplantilla.Usuario };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("CERRAR_PLANTILLA", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Insertar_Plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_Dependencia", "P_plaza", "P_Semestre" , "P_Fecha_ini", "P_Fecha_fin", "P_RFC" , "P_Nombre", "P_Categoria",
                                        "P_Status", "P_Teorica", "P_Tot_Int", "P_Tot_Tem", "P_Tot_Def" , "P_Tot_Det", "P_observaciones", "P_Fecha_Mov", "P_oficio", "P_Codigo", "P_Fecha_Ingreso", "P_Usuario"};
                object[] Valores = { objplantilla.Dependencia,objplantilla.Plaza, objplantilla.Semestre, objplantilla.Fecha_Ini,
                                     objplantilla.Fecha_Fin,objplantilla.RFC, objplantilla.Nombre, objplantilla.Categoria, objplantilla.Status, objplantilla.Cga_teo, objplantilla.Tot_int,
                                     objplantilla.Tot_tem,objplantilla.Tot_def, objplantilla.Tot_det,objplantilla.Obsevasiones,objplantilla.Fecha_mov,objplantilla.Oficio,
                                     objplantilla.Codigo,objplantilla.Fecha_Ingreso, objplantilla.Usuario};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("ins_dpp_plantilla", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Update_Plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_Id","P_Dependencia", "P_plaza", "P_Fecha_ini", "P_Fecha_fin", "P_RFC" , "P_Nombre", "P_Categoria", "P_Status", "P_Teorica",
                                        "P_Tot_Int", "P_Tot_Tem", "P_Tot_Def" , "P_Tot_Det", "P_observaciones", "P_oficio", "P_Codigo", "P_Fecha_Ingreso", "P_Fec_Mov", "P_Usuario"};
                object[] Valores = { objplantilla.Id, objplantilla.Dependencia,objplantilla.Plaza, objplantilla.Fecha_Ini, objplantilla.Fecha_Fin,objplantilla.RFC,
                                     objplantilla.Nombre, objplantilla.Categoria, objplantilla.Status, objplantilla.Cga_teo, objplantilla.Tot_int,
                                     objplantilla.Tot_tem,objplantilla.Tot_def, objplantilla.Tot_det,objplantilla.Obsevasiones,objplantilla.Oficio,
                                     objplantilla.Codigo,objplantilla.Fecha_Ingreso,objplantilla.Fecha_mov, objplantilla.Usuario};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_DPP_PLANTILLA", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Insertar_New_Plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_DEPENDENCIA", "P_SEMESTRE", "P_FECHA_INI", "P_FECHA_FIN", "P_USUARIO" };
                object[] Valores = { objplantilla.Dependencia, objplantilla.Semestre, objplantilla.Fecha_Ini, objplantilla.Fecha_Fin, objplantilla.Usuario };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_NEW_DPP_PLANTILLA", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ConsultaGrid_cierre_dep(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_SEMESTRE" };
                String[] Valores = { objPlantilla.Semestre };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Pres.OBT_Grid_Cierre_Dependencia", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPlantilla = new Pres_Plantilla();
                    objPlantilla.Id = Convert.ToString(dr.GetValue(0));
                    objPlantilla.Dependencia = Convert.ToString(dr.GetValue(1));
                    objPlantilla.Descripcion = Convert.ToString(dr.GetValue(2));
                    objPlantilla.Status = Convert.ToString(dr.GetValue(3));                   
                    List.Add(objPlantilla);
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
        public void ConsultaGrid_Monitor(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            CD_Datos CDDatos = new CD_Datos("DPP");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_SEMESTRE","p_dependencia" };
                String[] Valores = { objPlantilla.Semestre,objPlantilla.Dependencia };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Pres.OBT_Grid_Monitor", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPlantilla = new Pres_Plantilla();
                    objPlantilla.Id = Convert.ToString(dr.GetValue(0));
                    objPlantilla.Semestre = Convert.ToString(dr.GetValue(1));
                    objPlantilla.Dependencia = Convert.ToString(dr.GetValue(2));
                    objPlantilla.Nombre = Convert.ToString(dr.GetValue(3));
                    objPlantilla.Descripcion = Convert.ToString(dr.GetValue(4));
                    List.Add(objPlantilla);
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
