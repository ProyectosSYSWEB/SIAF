using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Pres_Reportes
    {
        public void ConsultaGrid_Fuente_F(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = {"p_ejercicio", "p_dependencia","p_dependencia_f" };
                String[] Valores = {objReportes.Ejercicio, objReportes.Dependencia, objReportes.DependenciaF };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Fuente_F", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Fuente  = Convert.ToString (dr.GetValue(0));
                    objReportes.Descripcion  = Convert.ToString(dr.GetValue(1));                                   
                    List.Add(objReportes );
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
        public void ConsultarGrid_GrupoFuente(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_dependencia", "p_dependencia_f" };
                String[] Valores = { objReportes.Ejercicio, objReportes.Dependencia, objReportes.DependenciaF };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_GrupoFuente", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Fuente = Convert.ToString(dr.GetValue(0));
                    objReportes.Descripcion = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
        public void ConsultaGrid_Fuente_x_Centro(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_centro_contable_ini", "p_centro_contable_fin",
                                        "p_tipo","p_mes","p_estatus"};
                String[] Valores = { objReportes.Ejercicio, objReportes.Dependencia, objReportes.DependenciaF,
                                    objReportes.Tipo,objReportes.Mes_anio,objReportes.Estatus};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Fuente_x_Centro", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Id = Convert.ToString(dr.GetValue(0));
                    objReportes.Descripcion = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
        public void ConsultaGrid_Partida_x_Centro(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_centro_contable_ini", "p_centro_contable_fin",
                                        "p_tipo","p_mes","p_estatus"};
                String[] Valores = { objReportes.Ejercicio, objReportes.Dependencia, objReportes.DependenciaF,
                                    objReportes.Tipo,objReportes.Mes_anio,objReportes.Estatus};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Partida_x_Centro", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Id = Convert.ToString(dr.GetValue(0));
                    objReportes.Descripcion = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
        public void ConsultaGrid_Capitulo(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio","p_dependencia", "p_dependencia_f" };
                String[] Valores = { objReportes.Ejercicio,objReportes.Dependencia, objReportes.DependenciaF };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Capitulo", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Id  = Convert.ToString(dr.GetValue(0));
                    objReportes.Capitulo = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
        public void ConsultaGrid_Subprograma(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio", "p_dependencia", "p_dependencia_f" };
                String[] Valores = { objReportes.Ejercicio, objReportes.Dependencia, objReportes.DependenciaF };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Subprograma", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Id = Convert.ToString(dr.GetValue(0));
                    objReportes.SubPrograma = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
        public void ConsultarGrid_RP008(ref Pres_Reportes objReportes, ref List<Pres_Reportes> List,int idGrid)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string Grid;
                if (idGrid == 2)
                    Grid = "CAPITULO";
                else if (idGrid == 3)
                    Grid = "FUENTE";
                else
                    Grid = "PROYECTO";

                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio","p_dependencia","p_grid" };
                String[] Valores = { objReportes.Ejercicio,objReportes.Dependencia,Grid };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_RP008", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objReportes = new Pres_Reportes();
                    objReportes.Id = Convert.ToString(dr.GetValue(0));
                    objReportes.Descripcion = Convert.ToString(dr.GetValue(1));
                    //if (idGrid == 2)
                    //    objReportes.Capitulo = Convert.ToString(dr.GetValue(1));
                    //else if (idGrid == 3)
                    //    objReportes.Fuente = Convert.ToString(dr.GetValue(1));
                    //else
                    //    objReportes.Proyecto = Convert.ToString(dr.GetValue(1));
                    List.Add(objReportes);
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
