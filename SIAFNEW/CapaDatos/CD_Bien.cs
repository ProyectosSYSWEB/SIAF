using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.OracleClient;

namespace CapaDatos
{
    public class CD_Bien
    {
        public void Consultar_Bien_Responsable(ref Bien  objbien, ref List<Bien > List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_tipo", "p_inventario_ini", "p_inventario_fin", "p_responsable" };
                Object[] Valores = { objbien.Dependencia, objbien.Clave,objbien.No_Inventario, objbien.No_Inventario_fin, objbien.Responsable };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PATRIMONIO.Obt_Grid_Bienes_de_Responsable", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objbien = new Bien();
                    objbien.No_Inventario= Convert.ToString(dr.GetValue(0));
                    objbien.Descripcion = Convert.ToString(dr.GetValue(1));
                    List.Add(objbien);

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
        public void ConsultarGrid(Bien Parametro, String Buscar, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_dependencia", "p_estatus", "p_buscar" };
                String[] Valores = { Parametro.Dependencia, Parametro.Estatus, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Bienes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    ObjBien.Id = Convert.ToInt32(dr.GetValue(0));
                    ObjBien.Centro_Contable = Convert.ToString(dr.GetValue(1));
                    ObjBien.No_Inventario = Convert.ToString(dr.GetValue(2));
                    ObjBien.Clave = Convert.ToString(dr.GetValue(3));
                    ObjBien.Descripcion = Convert.ToString(dr.GetValue(4));
                    ObjBien.Codigo_Contable = Convert.ToString(dr.GetValue(5));
                    ObjBien.Fecha_Alta_Str = Convert.ToString(dr.GetValue(6)).Substring(0, 10);
                    ObjBien.Costo = Convert.ToInt32(dr.GetValue(7));
                    ObjBien.Formulario = Convert.ToInt32(dr.GetValue(8));
                    List.Add(ObjBien);
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
        public void ConsultarGrid(Bien Parametro, String Buscar, String Fecha_Inicial, String Fecha_Final, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_dependencia", "p_estatus", "p_buscar", "p_fecha_inicial", "p_fecha_final" };
                String[] Valores = { Parametro.Dependencia, Parametro.Estatus, Buscar, Fecha_Inicial, Fecha_Final };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Bienes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    ObjBien.Id = Convert.ToInt32(dr.GetValue(0));
                    ObjBien.Centro_Contable = Convert.ToString(dr.GetValue(1));
                    ObjBien.No_Inventario = Convert.ToString(dr.GetValue(2));
                    ObjBien.Clave = Convert.ToString(dr.GetValue(3));
                    ObjBien.Descripcion = Convert.ToString(dr.GetValue(4));
                    ObjBien.Codigo_Contable = Convert.ToString(dr.GetValue(5));
                    ObjBien.Fecha_Alta_Str = Convert.ToString(dr.GetValue(6)).Substring(0, 10);

                    if ( Convert.ToString(dr.GetValue(7)) != string.Empty && dr.GetValue(7) != null)
                        ObjBien.Fecha_Baja_Str = Convert.ToString(dr.GetValue(7)).Substring(0, 10);
                    else  ObjBien.Fecha_Baja_Str ="";

                    ObjBien.Costo = Convert.ToDouble(dr.GetValue(8));
                    ObjBien.Formulario = Convert.ToInt32(dr.GetValue(9));
                    if(Convert.ToString(dr.GetValue(10))=="S")
                        ObjBien.Validado = true;
                    else
                        ObjBien.Validado =false ;

                    List.Add(ObjBien);
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
        public void ConsultarGrid(String Dependencia, String Status, String Especie, String Etapa, String Buscar, ref List<Bien_Detalle> List)
        {
            Bien_Detalle ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_dependencia", "p_status", "p_especie","p_etapa", "p_buscar"};
                String[] Valores = {Dependencia, Status, Especie,Etapa, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Semovientes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien_Detalle();
                    ObjBien.Id = Convert.ToInt32(dr.GetValue(0));
                    ObjBien.Centro_Contable = Convert.ToString(dr.GetValue(1));
                    ObjBien.No_Inventario = Convert.ToString(dr.GetValue(3));
                    ObjBien.Sem_Especie = Convert.ToString(dr.GetValue(4));
                    ObjBien.Sem_Sexo = Convert.ToString(dr.GetValue(5));
                    ObjBien.Sem_Etapa = Convert.ToString(dr.GetValue(6));
                    ObjBien.Sem_Raza = Convert.ToString(dr.GetValue(7));
                    ObjBien.Fecha_Alta_Str = Convert.ToString(dr.GetValue(8));
                    ObjBien.Sem_Edad = Convert.ToString(dr.GetValue(9));
                    ObjBien.Sem_Peso = Convert.ToString(dr.GetValue(10));
                    ObjBien.Sem_Id_Especie = Convert.ToString(dr.GetValue(11));

                    List.Add(ObjBien);
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
        public void ConsultarGrid(String Buscar, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_buscar" };
                String[] Valores = { Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Bienes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    //ObjBien.IdPoliza = Convert.ToInt32(dr.GetValue(0));
                    //ObjBien.Centro_contable = Convert.ToString(dr.GetValue(3));
                    //ObjBien.Numero_poliza = Convert.ToString(dr.GetValue(2));
                    //ObjBien.Tipo = Convert.ToString(dr.GetValue(4));
                    //ObjBien.Fecha = Convert.ToString(dr.GetValue(7));
                    //ObjBien.Status = Convert.ToString(dr.GetValue(9));
                    //ObjBien.Concepto = Convert.ToString(dr.GetValue(6));
                    List.Add(ObjBien);
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
        public void ConsultarGridHistorico(String Buscar, ref List<Bien_Detalle> List)
        {
            Bien_Detalle ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_ID_INVENTARIO" };
                String[] Valores = { Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Historico_Semoviente", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien_Detalle();
                    ObjBien.Id = Convert.ToInt32(dr.GetValue(0));
                    
                    ObjBien.Sem_Etapa = Convert.ToString(dr.GetValue(1));
                    ObjBien.Sem_FechaNac_Str = Convert.ToString(dr.GetValue(2));
                    ObjBien.Sem_Edad = Convert.ToString(dr.GetValue(3));
                    ObjBien.Sem_Peso = Convert.ToString(dr.GetValue(4));
                    ObjBien.Costo = Convert.ToInt32(dr.GetValue(5));
                    ObjBien.Observaciones = Convert.ToString(dr.GetValue(6));
                    ObjBien.Sem_Id_Etapa= Convert.ToString(dr.GetValue(7));
                    List.Add(ObjBien);
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
        public void ConsultarGridProduccion(String Buscar, ref List<Bien_Detalle> List)
        {
            Bien_Detalle ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_ID_INVENTARIO" };
                String[] Valores = { Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Produccion", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien_Detalle();
                    ObjBien.Id = Convert.ToInt32(dr.GetValue(0));
                    ObjBien.Sem_FechaNac_Str = Convert.ToString(dr.GetValue(1));
                    ObjBien.Sem_Peso = Convert.ToString(dr.GetValue(2));
                    ObjBien.Sem_Vellon = Convert.ToString(dr.GetValue(3));
                    ObjBien.Sem_Calidad = Convert.ToString(dr.GetValue(4));
                    ObjBien.Sem_FechaTrasquila_Str = Convert.ToString(dr.GetValue(5));
                    List.Add(ObjBien);
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
        public void ConsultarGridSemovientesVenta(Bien Parametro, String Buscar, ref List<Bien_Detalle> List)
        {
            Bien_Detalle ObjBien;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_dependencia", "p_status", "p_buscar" };
                String[] Valores = { Parametro.Dependencia, Parametro.Estatus, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Semovientes_Venta", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien_Detalle();
                    ObjBien.Id = Convert.ToInt32(dr.GetValue(0));
                    ObjBien.No_Inventario = Convert.ToString(dr.GetValue(1));
                    ObjBien.Descripcion = Convert.ToString(dr.GetValue(2));
                    ObjBien.Sem_Peso = Convert.ToString(dr.GetValue(3));
                    ObjBien.Costo = Convert.ToInt32(dr.GetValue(4));
                    ObjBien.Estatus= Convert.ToString(dr.GetValue(5));
                    ObjBien.Sem_FechaNac_Str= Convert.ToString(dr.GetValue(6));
                    ObjBien.Sem_FechaRevalorizado_Str = Convert.ToString(dr.GetValue(7));
                    ObjBien.Validado = Convert.ToString(dr.GetValue(8)) == "0" ? false : true;
                    List.Add(ObjBien);
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
        public void ConsultarBien(ref Bien_Detalle ObjBien, ref String Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID_BIEN" };
                object[] Valores = { ObjBien.Id };
                string[] ParametrosOut ={
                                            "P_CENTRO_CONTABLE",
                                            "P_DEPENDENCIA",
                                            "P_SUB_DEPENDENCIA",
                                            "P_CENTRO_TRABAJO",
                                            "P_INVENTARIO_NUMERO",
                                            "P_INVENTARIO_ANTERIOR",
                                            "P_EJERCICIO",
                                            "P_CLAVE",
                                            "P_TIPO",
                                            "P_INVENTARIO_AUXILIAR",
                                            "P_ID_TIPO_ALTA",
                                            "P_FORMULARIO",
                                            "P_CANTIDAD",
                                            "P_FECHA_ALTA",
                                            "P_FECHA_CONTABLE",
                                            "p_FECHA_ALTA_ANT",
                                            "P_RESPONSABLE",
                                            "P_NOMBRE",
                                            "P_CORRESPONSABLE",
                                            "P_COMPARATIVO",
                                            "P_FACTURA_NUMERO",
                                            "P_FACTURA_FECHA",
                                            "P_COSTO",
                                            "P_PROVEEDOR",
                                            "P_POLIZA",
                                            "P_CEDULA",
                                            "P_PROYECTO",
                                            "P_FUENTE",
                                            "P_VOLANTE",
                                            "P_PROCEDENCIA",
                                            "P_DESCRIPCION",
                                            "P_CARACTERISTICA",
                                            "P_COLOR",
                                            "P_MARCA",
                                            "P_MODELO",
                                            "P_NUMERO_SERIE",
                                            "P_ESTATUS",
                                            "P_INM_NOMBRE",
                                            "P_INM_DIRECCION",
                                            "P_INM_CIUDAD",
                                            "P_INM_DOC_TIPO",
                                            "P_INM_DOC_NUMERO",
                                            "P_INM_DOC_STATUS",
                                            "P_INM_FECHA_DOCUMENTO",
                                            "P_INM_LUGAR_EXPEDICION",
                                            "P_INM_NUMERO_NOTARIA",
                                            "P_INM_AVALUO_TERRENO",
                                            "P_INM_AVALUO_EDIFICIO",
                                            "P_INM_AVALUO_FECHA",
                                            "P_VH_ANIO_MODELO",
                                            "P_VH_PLACAS",
                                            "P_VH_MOTOR",
                                            "P_VH_TENENCIA",
                                            "P_VH_POLIZA_SEGURO",
                                            "P_VH_FECHAV_SEGURO",
                                            "P_TIC_PROCESADOR",
                                            "P_TIC_SISTEMA_OPERATIVO",
                                            "P_TIC_RAM",
                                            "P_TIC_DISCO_DURO",
                                            "P_TIC_DISKETTE",
                                            "P_TIC_CD",
                                            "P_TIC_ACCESORIOS",
                                            "P_SEM_SEXO",
                                            "P_SEM_RAZA",
                                            "P_SEM_ARETE",
                                            "P_SEM_EDAD",
                                            "P_SEM_FECHA_NAC",
                                            "P_SEM_PESO",
                                            "P_SEM_COSTO_REVALOR",
                                            "P_SEM_FECHA_REVALOR",
                                            "P_OBSERVACIONES",
                                            "p_INT_SOFT",
                                            "p_INT_PATENTE",
                                            "p_INT_AUTOR",
                                            "p_INT_CADUCIDAD",
                                            "p_INT_USUARIOS",
                                            "p_INT_VERSION",
                                            "p_INT_IDIOMA",
                                            "p_CLA_TITULO",
                                            "p_CLA_AUTOR",
                                            "p_CLA_EDITORIAL",
                                            "p_CLA_TOMOS",
                                            "p_CLA_EDICION",
                                            "p_CLA_ISBN",
                                            "P_RECLASIFICADO",
                                            "p_RECLASIFICACION_FECHA",
                                            "P_RESGUARDO",
                                            "P_VALIDADO",
                                            "P_PARTIDA",
                                            "P_CATEGORIA",
                                            "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_BIEN", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {

                    ObjBien.Centro_Contable = Convert.ToString(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    ObjBien.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    ObjBien.SubDependencia = Convert.ToString(Cmd.Parameters["P_SUB_DEPENDENCIA"].Value);
                    ObjBien.Fecha_Alta_Str = Convert.ToString(Cmd.Parameters["P_FECHA_ALTA"].Value);
                    ObjBien.Fecha_Alta_Ant_Str = Convert.ToString(Cmd.Parameters["P_FECHA_ALTA_ANT"].Value);
                    ObjBien.Fecha_Contable_Str = Convert.ToString(Cmd.Parameters["P_FECHA_CONTABLE"].Value);
                    ObjBien.No_Inventario = Convert.ToString(Cmd.Parameters["P_INVENTARIO_NUMERO"].Value);
                    ObjBien.IdTipo_Alta = Convert.ToInt32(Cmd.Parameters["P_ID_TIPO_ALTA"].Value);
                    ObjBien.Tipo = Convert.ToString(Cmd.Parameters["P_TIPO"].Value);
                    ObjBien.Estatus = Convert.ToString(Cmd.Parameters["P_ESTATUS"].Value);

                    if (Convert.ToString(Cmd.Parameters["P_VOLANTE"].Value) != null)
                        ObjBien.Volante = Convert.ToString(Cmd.Parameters["P_VOLANTE"].Value);
                    else
                        ObjBien.Volante = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INVENTARIO_ANTERIOR"].Value) != null)
                        ObjBien.Inventario_Anterior = Convert.ToString(Cmd.Parameters["P_INVENTARIO_ANTERIOR"].Value);
                    else
                        ObjBien.Inventario_Anterior = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_PROCEDENCIA"].Value) != null)
                        ObjBien.Procedencia = Convert.ToString(Cmd.Parameters["P_PROCEDENCIA"].Value);
                    else
                        ObjBien.Procedencia = string.Empty;
                    ObjBien.Poliza = Convert.ToString(Cmd.Parameters["P_POLIZA"].Value);
                    if (Convert.ToString(Cmd.Parameters["P_CEDULA"].Value) != null)
                        ObjBien.Cedula = Convert.ToString(Cmd.Parameters["P_CEDULA"].Value).Trim();
                    else
                        ObjBien.Cedula = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_PROYECTO"].Value) != null)
                        ObjBien.Proyecto = Convert.ToString(Cmd.Parameters["P_PROYECTO"].Value);
                    else
                        ObjBien.Proyecto = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_FUENTE"].Value) != null)
                        ObjBien.Fuente_Financiamiento = Convert.ToString(Cmd.Parameters["P_FUENTE"].Value);
                    else
                        ObjBien.Fuente_Financiamiento = string.Empty;

                    ObjBien.Centro_Trabajo = Convert.ToString(Cmd.Parameters["P_CENTRO_TRABAJO"].Value);
                    ObjBien.Ejercicio = Convert.ToInt32(Cmd.Parameters["P_EJERCICIO"].Value);
                    ObjBien.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    ObjBien.Codigo_Contable = Convert.ToString(Cmd.Parameters["P_COMPARATIVO"].Value);
                    ObjBien.Cantidad = Convert.ToInt32(Cmd.Parameters["P_CANTIDAD"].Value);
                    if (Convert.ToString(Cmd.Parameters["P_RESPONSABLE"].Value) != null && Convert.ToString(Cmd.Parameters["P_RESPONSABLE"].Value) != string.Empty)
                        ObjBien.Responsable = Convert.ToString(Cmd.Parameters["P_RESPONSABLE"].Value);
                    else
                        ObjBien.Responsable = "0000";
                    if (Convert.ToString(Cmd.Parameters["P_NOMBRE"].Value) != null && Convert.ToString(Cmd.Parameters["P_NOMBRE"].Value) != string.Empty)
                        ObjBien.Responsable_Nombre = Convert.ToString(Cmd.Parameters["P_NOMBRE"].Value);
                    else
                        ObjBien.Responsable_Nombre = "RESPONSABLE NO ASIGNADO";

                    if (Convert.ToString(Cmd.Parameters["P_CORRESPONSABLE"].Value) != null)
                        ObjBien.Corresponsable = Convert.ToString(Cmd.Parameters["P_CORRESPONSABLE"].Value);
                    else
                        ObjBien.Corresponsable = string.Empty;
                    ObjBien.Proveedor = Convert.ToString(Cmd.Parameters["P_PROVEEDOR"].Value);
                    if (Convert.ToString(Cmd.Parameters["P_FACTURA_NUMERO"].Value) != null)
                        ObjBien.Factura_Numero = Convert.ToString(Cmd.Parameters["P_FACTURA_NUMERO"].Value);
                    else
                        ObjBien.Factura_Numero = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_FACTURA_FECHA"].Value) != null)
                        ObjBien.Factura_Fecha_Str = Convert.ToString(Cmd.Parameters["P_FACTURA_FECHA"].Value);
                    else
                        ObjBien.Factura_Fecha_Str = string.Empty;


                    ObjBien.Reclasificado = Convert.ToString(Cmd.Parameters["P_RECLASIFICADO"].Value);
                    if (Convert.ToString(Cmd.Parameters["P_RECLASIFICACION_FECHA"].Value) != null)
                        ObjBien.Fecha_Reclasificacion_Str = Convert.ToString(Cmd.Parameters["P_RECLASIFICACION_FECHA"].Value);
                    else
                        ObjBien.Fecha_Reclasificacion_Str = string.Empty;
                    ObjBien.Costo = Convert.ToDouble(Cmd.Parameters["P_COSTO"].Value);
                    if (Convert.ToString(Cmd.Parameters["P_OBSERVACIONES"].Value) != null)
                        ObjBien.Observaciones = Convert.ToString(Cmd.Parameters["P_OBSERVACIONES"].Value);
                    else
                        ObjBien.Observaciones = string.Empty;
                    ObjBien.Formulario = Convert.ToInt32(Cmd.Parameters["P_FORMULARIO"].Value);

                    if (Convert.ToString(Cmd.Parameters["P_VALIDADO"].Value)=="S")
                        ObjBien.Validado =true;
                    else
                            ObjBien.Validado =false;
                    ObjBien.Resguardo = Convert.ToString(Cmd.Parameters["P_RESGUARDO"].Value);

                    if (Convert.ToString(Cmd.Parameters["P_PARTIDA"].Value) != null)
                        ObjBien.Partida = Convert.ToString(Cmd.Parameters["P_PARTIDA"].Value);
                    else
                        ObjBien.Partida = string.Empty;

                        ObjBien.Clasificacion = Convert.ToString(Cmd.Parameters["P_CATEGORIA"].Value);
                    
                    //*****************************************MUEBLES**********************************************
                    if (Convert.ToString(Cmd.Parameters["P_CARACTERISTICA"].Value) != null)
                        ObjBien.Caracteristicas = Convert.ToString(Cmd.Parameters["P_CARACTERISTICA"].Value);
                    else
                        ObjBien.Caracteristicas = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_MARCA"].Value) != null)
                        ObjBien.Marca = Convert.ToString(Cmd.Parameters["P_MARCA"].Value);
                    else
                        ObjBien.Marca = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_MODELO"].Value) != null)
                        ObjBien.Modelo = Convert.ToString(Cmd.Parameters["P_MODELO"].Value);
                    else
                        ObjBien.Modelo = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_NUMERO_SERIE"].Value) != null)
                        ObjBien.No_Serie = Convert.ToString(Cmd.Parameters["P_NUMERO_SERIE"].Value);
                    else
                        ObjBien.No_Serie = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_COLOR"].Value) != null)
                        ObjBien.Color = Convert.ToString(Cmd.Parameters["P_COLOR"].Value);
                    else
                        ObjBien.Color = string.Empty;


                    //***************************************INMUEBLES**********************************************
                    if (Convert.ToString(Cmd.Parameters["P_INM_DIRECCION"].Value) != null)
                        ObjBien.Inm_Direccion = Convert.ToString(Cmd.Parameters["P_INM_DIRECCION"].Value);
                    else
                        ObjBien.Inm_Direccion = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_CIUDAD"].Value) != null)
                        ObjBien.Inm_Ciudad = Convert.ToString(Cmd.Parameters["P_INM_CIUDAD"].Value);
                    else
                        ObjBien.Inm_Ciudad = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_DOC_TIPO"].Value) != null)
                        ObjBien.Inm_TipoDoc = Convert.ToString(Cmd.Parameters["P_INM_DOC_TIPO"].Value);
                    else
                        ObjBien.Inm_TipoDoc = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_DOC_NUMERO"].Value) != null)
                        ObjBien.Inm_NumeroDoc = Convert.ToString(Cmd.Parameters["P_INM_DOC_NUMERO"].Value);
                    else
                        ObjBien.Inm_NumeroDoc = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_DOC_STATUS"].Value) != null)
                        ObjBien.Inm_EstatusDoc = Convert.ToString(Cmd.Parameters["P_INM_DOC_STATUS"].Value);
                    else
                        ObjBien.Inm_EstatusDoc = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_FECHA_DOCUMENTO"].Value) != null)
                        ObjBien.Inm_FechaDoc_Str = Convert.ToString(Cmd.Parameters["P_INM_FECHA_DOCUMENTO"].Value);
                    else
                        ObjBien.Inm_FechaDoc_Str = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_LUGAR_EXPEDICION"].Value) != null)
                        ObjBien.Inm_ExpedicionDoc = Convert.ToString(Cmd.Parameters["P_INM_LUGAR_EXPEDICION"].Value);
                    else
                        ObjBien.Inm_ExpedicionDoc = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_INM_NUMERO_NOTARIA"].Value) != null)
                        ObjBien.Inm_NotariaPublica = Convert.ToString(Cmd.Parameters["P_INM_NUMERO_NOTARIA"].Value);
                    else
                        ObjBien.Inm_NotariaPublica = string.Empty;
                    if (Cmd.Parameters["P_INM_AVALUO_TERRENO"].Value != null && Convert.ToString(Cmd.Parameters["P_INM_AVALUO_TERRENO"].Value) != string.Empty)
                        ObjBien.Inm_AvaluoTerreno = Convert.ToDouble(Cmd.Parameters["P_INM_AVALUO_TERRENO"].Value);
                    else
                        ObjBien.Inm_AvaluoTerreno = 0.0;
                    if (Cmd.Parameters["P_INM_AVALUO_EDIFICIO"].Value != null && Convert.ToString(Cmd.Parameters["P_INM_AVALUO_EDIFICIO"].Value) != string.Empty)
                        ObjBien.Inm_AvaluoEdificio = Convert.ToDouble(Cmd.Parameters["P_INM_AVALUO_EDIFICIO"].Value);
                    else
                        ObjBien.Inm_AvaluoEdificio = 0.0;
                    if (Convert.ToString(Cmd.Parameters["P_INM_AVALUO_FECHA"].Value) != null)
                        ObjBien.Inm_FechaAvaluo_Str = Convert.ToString(Cmd.Parameters["P_INM_AVALUO_FECHA"].Value);
                    else
                        ObjBien.Inm_FechaAvaluo_Str = string.Empty;


                    //***************************************VEHICULOS**********************************************
                    if (Convert.ToString(Cmd.Parameters["P_VH_ANIO_MODELO"].Value) != null)
                        ObjBien.Veh_Año = Convert.ToString(Cmd.Parameters["P_VH_ANIO_MODELO"].Value);
                    else
                        ObjBien.Veh_Año = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_VH_MOTOR"].Value) != null)
                        ObjBien.Veh_NumeroMotor = Convert.ToString(Cmd.Parameters["P_VH_MOTOR"].Value);
                    else
                        ObjBien.Veh_NumeroMotor = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_VH_PLACAS"].Value) != null)
                        ObjBien.Veh_NumeroPlacas = Convert.ToString(Cmd.Parameters["P_VH_PLACAS"].Value);
                    else
                        ObjBien.Veh_NumeroPlacas = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_VH_TENENCIA"].Value) != null)
                        ObjBien.Veh_Tenencia = Convert.ToString(Cmd.Parameters["P_VH_TENENCIA"].Value);
                    else
                        ObjBien.Veh_Tenencia = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_VH_POLIZA_SEGURO"].Value) != null)
                        ObjBien.Veh_PolizaSeguro = Convert.ToString(Cmd.Parameters["P_VH_POLIZA_SEGURO"].Value);
                    else
                        ObjBien.Veh_PolizaSeguro = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_VH_FECHAV_SEGURO"].Value) != null)
                        ObjBien.Veh_FechaVencimiento_Str = Convert.ToString(Cmd.Parameters["P_VH_FECHAV_SEGURO"].Value);
                    else
                        ObjBien.Veh_FechaVencimiento_Str = string.Empty;


                    //********************************************TIC**********************************************
                    if (Convert.ToString(Cmd.Parameters["P_TIC_SISTEMA_OPERATIVO"].Value) != null)
                        ObjBien.Tic_SO = Convert.ToString(Cmd.Parameters["P_TIC_SISTEMA_OPERATIVO"].Value);
                    else
                        ObjBien.Tic_SO = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_TIC_ACCESORIOS"].Value) != null)
                        ObjBien.Tic_Accesorios = Convert.ToString(Cmd.Parameters["P_TIC_ACCESORIOS"].Value);
                    else
                        ObjBien.Tic_Accesorios = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_TIC_PROCESADOR"].Value) != null)
                        ObjBien.Tic_Procesador = Convert.ToString(Cmd.Parameters["P_TIC_PROCESADOR"].Value);
                    else
                        ObjBien.Tic_Procesador = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_TIC_RAM"].Value) != null)
                        ObjBien.Tic_RAM = Convert.ToString(Cmd.Parameters["P_TIC_RAM"].Value);
                    else
                        ObjBien.Tic_RAM = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_TIC_DISCO_DURO"].Value) != null)
                        ObjBien.Tic_DiscoDuro = Convert.ToString(Cmd.Parameters["P_TIC_DISCO_DURO"].Value);
                    else
                        ObjBien.Tic_DiscoDuro = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_TIC_DISKETTE"].Value) != null)
                        ObjBien.Tic_Disquete = Convert.ToString(Cmd.Parameters["P_TIC_DISKETTE"].Value);
                    else
                        ObjBien.Tic_Disquete = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_TIC_CD"].Value) != null)
                        ObjBien.Tic_UnidadOptica = Convert.ToString(Cmd.Parameters["P_TIC_CD"].Value);
                    else
                        ObjBien.Tic_UnidadOptica = string.Empty;


                    //*****************************************ACTIVOS BIOLOGICOS**********************************************
                    if (Convert.ToString(Cmd.Parameters["P_SEM_RAZA"].Value) != null)
                        ObjBien.Sem_Raza = Convert.ToString(Cmd.Parameters["P_SEM_RAZA"].Value);
                    else
                        ObjBien.Sem_Raza = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_SEM_ARETE"].Value) != null)
                        ObjBien.Sem_Arete = Convert.ToString(Cmd.Parameters["P_SEM_ARETE"].Value);
                    else
                        ObjBien.Sem_Arete = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_SEM_EDAD"].Value) != null)
                        ObjBien.Sem_Edad = Convert.ToString(Cmd.Parameters["P_SEM_EDAD"].Value);
                    else
                        ObjBien.Sem_Edad = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_SEM_FECHA_NAC"].Value) != null)
                        ObjBien.Sem_FechaNac_Str = Convert.ToString(Cmd.Parameters["P_SEM_FECHA_NAC"].Value);
                    else
                        ObjBien.Sem_FechaNac_Str = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_SEM_SEXO"].Value) != null)
                        ObjBien.Sem_Sexo = Convert.ToString(Cmd.Parameters["P_SEM_SEXO"].Value);
                    else
                        ObjBien.Sem_Sexo = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["P_SEM_PESO"].Value) != null)
                        ObjBien.Sem_Peso = Convert.ToString(Cmd.Parameters["P_SEM_PESO"].Value);
                    else
                        ObjBien.Sem_Peso = string.Empty;
                    if (Cmd.Parameters["P_SEM_COSTO_REVALOR"].Value != null && Convert.ToString(Cmd.Parameters["P_SEM_COSTO_REVALOR"].Value) != string.Empty)
                        ObjBien.Sem_CostoRevalorizado = Convert.ToDouble(Cmd.Parameters["P_SEM_COSTO_REVALOR"].Value);
                    else
                        ObjBien.Sem_CostoRevalorizado = 0.00;
                    if (Convert.ToString(Cmd.Parameters["P_SEM_FECHA_REVALOR"].Value) != null)
                        ObjBien.Sem_FechaRevalorizado_Str = Convert.ToString(Cmd.Parameters["P_SEM_FECHA_REVALOR"].Value);
                    else
                        ObjBien.Sem_FechaRevalorizado_Str = string.Empty; ;

                    //*****************************************ACTIVOS INTANGIBLES**********************************************
                    if (Convert.ToString(Cmd.Parameters["p_INT_SOFT"].Value) != null)
                        ObjBien.Int_TipoSoftware = Convert.ToString(Cmd.Parameters["p_INT_SOFT"].Value);
                    else
                        ObjBien.Int_TipoSoftware = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_INT_PATENTE"].Value) != null)
                        ObjBien.Int_Patente = Convert.ToString(Cmd.Parameters["p_INT_PATENTE"].Value);
                    else
                        ObjBien.Int_Patente = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_INT_AUTOR"].Value) != null)
                        ObjBien.Int_DerechoAutor = Convert.ToString(Cmd.Parameters["p_INT_AUTOR"].Value);
                    else
                        ObjBien.Int_DerechoAutor = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_INT_CADUCIDAD"].Value) != null)
                        ObjBien.Int_CaducidadLicencia = Convert.ToString(Cmd.Parameters["p_INT_CADUCIDAD"].Value);
                    else
                        ObjBien.Int_CaducidadLicencia = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_INT_USUARIOS"].Value) != null)
                        ObjBien.Int_Usuarios = Convert.ToString(Cmd.Parameters["p_INT_USUARIOS"].Value);
                    else
                        ObjBien.Int_Usuarios = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_INT_VERSION"].Value) != null)
                        ObjBien.Int_Version = Convert.ToString(Cmd.Parameters["p_INT_VERSION"].Value);
                    else
                        ObjBien.Int_Version = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_INT_IDIOMA"].Value) != null)
                        ObjBien.Int_Idioma = Convert.ToString(Cmd.Parameters["p_INT_IDIOMA"].Value);
                    else
                        ObjBien.Int_Idioma = string.Empty;


                    //***************************************** COLECCIONES **********************************************

                    if (Convert.ToString(Cmd.Parameters["p_CLA_AUTOR"].Value) != null)
                        ObjBien.Col_Autor = Convert.ToString(Cmd.Parameters["p_CLA_AUTOR"].Value);
                    else
                        ObjBien.Col_Autor = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_CLA_TITULO"].Value) != null)
                        ObjBien.Col_Titulo = Convert.ToString(Cmd.Parameters["p_CLA_TITULO"].Value);
                    else
                        ObjBien.Col_Titulo = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_CLA_EDITORIAL"].Value) != null)
                        ObjBien.Col_Editorial = Convert.ToString(Cmd.Parameters["p_CLA_EDITORIAL"].Value);
                    else
                        ObjBien.Col_Editorial = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_CLA_TOMOS"].Value) != null)
                        ObjBien.Col_Tomos = Convert.ToString(Cmd.Parameters["p_CLA_TOMOS"].Value);
                    else
                        ObjBien.Col_Tomos = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_CLA_EDICION"].Value) != null)
                        ObjBien.Col_Edicion = Convert.ToString(Cmd.Parameters["p_CLA_EDICION"].Value);
                    else
                        ObjBien.Col_Edicion = string.Empty;
                    if (Convert.ToString(Cmd.Parameters["p_CLA_ISBN"].Value) != null)
                        ObjBien.Col_ISBN = Convert.ToString(Cmd.Parameters["p_CLA_ISBN"].Value);
                    else
                        ObjBien.Col_ISBN = string.Empty;

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
        public void ConsultarSemoviente(ref Bien_Detalle ObjBien, ref String Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID_PATRIMONIO" };
                object[] Valores = { ObjBien.Id };
                string[] ParametrosOut ={
                                            "P_DESCRIPCION",
                                            "P_ESPECIE",
                                            "P_FECHA_NACIMIENTO",
                                            "P_EDAD_MESES",
                                            "P_EDAD_ANIOS",
                                            "P_SEXO",
                                            "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_HISTORICO_SEMOVIENTE", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjBien.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    ObjBien.Sem_Especie = Convert.ToString(Cmd.Parameters["P_ESPECIE"].Value);
                    ObjBien.Sem_FechaNac_Str = Convert.ToString(Cmd.Parameters["P_FECHA_NACIMIENTO"].Value);
                    ObjBien.Sem_Edad = Convert.ToString(Cmd.Parameters["P_EDAD_MESES"].Value);
                    ObjBien.Sem_Edad_Anios = Convert.ToString(Cmd.Parameters["P_EDAD_ANIOS"].Value);
                    ObjBien.Sem_Sexo = Convert.ToString(Cmd.Parameters["P_SEXO"].Value);
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
        public void ConsultarSemovienteEtapa(ref Bien_Detalle ObjBien, ref String Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID_ETAPA" };
                object[] Valores = { ObjBien.Sem_Id_Etapa };
                string[] ParametrosOut ={
                                            "P_ESPECIE",
                                            "P_ETAPA",
                                            "P_FECHA",
                                            "P_PESO",
                                            "P_COSTO",
                                            "P_EDAD",
                                            "P_OBSERVACIONES",
                                            "P_FECHA_PARTO",
                                            "P_ID_PADRE",
                                            "P_PADRE",
                                            "P_ID_MADRE",
                                            "P_MADRE",
                                            "P_METODO",
                                            "P_CRIAS_MACHO",
                                            "P_CRIAS_HEMBRA",
                                            "P_TOTAL_CRIAS",
                                            "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_ETAPA_PRODUCTIVA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjBien.Sem_Especie = Convert.ToString(Cmd.Parameters["P_ESPECIE"].Value);
                    ObjBien.Sem_Etapa = Convert.ToString(Cmd.Parameters["P_ETAPA"].Value);
                    ObjBien.Sem_FechaEtapa_Str = Convert.ToString(Cmd.Parameters["P_FECHA"].Value); 
                    ObjBien.Sem_Peso = Convert.ToString(Cmd.Parameters["P_PESO"].Value);
                    ObjBien.Costo = Convert.ToDouble(Cmd.Parameters["P_COSTO"].Value);
                    ObjBien.Sem_Edad = Convert.ToString(Cmd.Parameters["P_EDAD"].Value);
                    ObjBien.Observaciones = Convert.ToString(Cmd.Parameters["P_OBSERVACIONES"].Value);
                    ObjBien.Sem_FechaParto_Str = Convert.ToString(Cmd.Parameters["P_FECHA_PARTO"].Value);
                    ObjBien.Sem_Id_Semental = Convert.ToString(Cmd.Parameters["P_ID_PADRE"].Value);
                    ObjBien.Sem_Id_Padre= Convert.ToString(Cmd.Parameters["P_ID_PADRE"].Value);
                    ObjBien.Sem_Metodo= Convert.ToString(Cmd.Parameters["P_METODO"].Value);
                    ObjBien.Sem_Id_Madre = Convert.ToString(Cmd.Parameters["P_ID_MADRE"].Value);
                    ObjBien.Sem_CriasM= Convert.ToString(Cmd.Parameters["P_CRIAS_MACHO"].Value);
                    ObjBien.Sem_CriasH = Convert.ToString(Cmd.Parameters["P_CRIAS_HEMBRA"].Value);

                    
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
        public void InsertarBien(ref Bien_Detalle ObjBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string Validado = string.Empty;
                if (ObjBien.Validado)
                    Validado = "S";
                else
                    Validado = "N";
                String[] Parametros = {
                                        "p_CENTRO_CONTABLE",
                                        "p_DEPENDENCIA",
                                        "p_SUB_DEPENDENCIA",
                                        "p_CENTRO_TRABAJO",
                                        "p_EJERCICIO",
                                        "P_TIPO",
                                        "p_ID_BIEN",
                                        "p_ID_TIPO_ALTA",
                                        "p_FORMULARIO",
                                        "p_CANTIDAD",
                                        "p_FECHA_ALTA",
                                        "p_FECHA_CONTABLE",
                                        "p_FECHA_ALTA_ANT",
                                        "p_RESPONSABLE",
                                        "p_RESPONSABLE_NOMBRE",
                                        "p_CORRESPONSABLE",
                                        "p_COMPARATIVO",
                                        "p_FACTURA_NUMERO",
                                        "p_FACTURA_FECHA",
                                        "p_COSTO",
                                        "p_PROVEEDOR",
                                        "p_POLIZA",
                                        "p_CEDULA",
                                        "P_PROYECTO",
                                        "P_FUENTE",
                                        "P_PROCEDENCIA",
                                        "P_VOLANTE",
                                        "P_INV_ANTERIOR",
                                        "p_PARTIDA",
                                        "P_VALIDADO",
                                        "P_RESGUARDO",
                                        "p_DESCRIPCION",
                                        "p_CARACTERISTICA",
                                        "p_COLOR",
                                        "p_MARCA",
                                        "p_MODELO",
                                        "p_NUMERO_SERIE",
                                        "p_INM_DIRECCION",
                                        "p_INM_CIUDAD",
                                        "p_INM_DOC_TIPO",
                                        "p_INM_DOC_NUMERO",
                                        "p_INM_DOC_STATUS",
                                        "p_INM_FECHA_DOCUMENTO",
                                        "p_INM_LUGAR_EXPEDICION",
                                        "p_INM_NUMERO_NOTARIA",
                                        "p_INM_AVALUO_TERRENO",
                                        "p_INM_AVALUO_EDIFICIO",
                                        "p_INM_AVALUO_FECHA",
                                        "p_VH_ANIO_MODELO",
                                        "p_VH_PLACAS",
                                        "p_VH_MOTOR",
                                        "p_VH_TENENCIA",
                                        "p_VH_POLIZA_SEGURO",
                                        "p_VH_FECHAV_SEGURO",
                                        "p_TIC_PROCESADOR",
                                        "p_TIC_SISTEMA_OPERATIVO",
                                        "p_TIC_RAM",
                                        "p_TIC_DISCO_DURO",
                                        "p_TIC_DISKETTE",
                                        "p_TIC_CD",
                                        "p_TIC_ACCESORIOS",
                                        "p_SEM_SEXO",
                                        "p_SEM_RAZA",
                                        "p_SEM_ARETE",
                                        "p_SEM_EDAD",
                                        "p_SEM_FECHA_NAC",
                                        "p_SEM_PESO",
                                        "p_SEM_COSTO_REVALOR",
                                        "p_SEM_FECHA_REVALOR",
                                        "p_OBSERVACIONES",
                                        "p_CAPTURA_USUARIO",
                                        "p_INT_SOFT",
                                        "p_INT_PATENTE",
                                        "p_INT_AUTOR",
                                        "p_INT_CADUCIDAD",
                                        "p_INT_USUARIOS",
                                        "p_INT_VERSION",
                                        "p_INT_IDIOMA",
                                        "p_CLA_TITULO",
                                        "p_CLA_AUTOR",
                                        "p_CLA_EDITORIAL",
                                        "p_CLA_TOMOS",
                                        "p_CLA_EDICION",
                                        "p_CLA_ISBN"
                                      };
                object[] Valores = {
                                       ObjBien.Centro_Contable,
                                        ObjBien.Dependencia,
                                        ObjBien.SubDependencia,
                                        ObjBien.Centro_Trabajo,
                                        ObjBien.Ejercicio,
                                        ObjBien.Tipo,
                                        Convert.ToInt32( ObjBien.Clave),
                                        ObjBien.IdTipo_Alta,
                                        ObjBien.Formulario,
                                        ObjBien.Cantidad,
                                        ObjBien.Fecha_Alta_Str,
                                        ObjBien.Fecha_Contable_Str,
                                        ObjBien.Fecha_Alta_Ant_Str,
                                        ObjBien.Responsable,
                                        ObjBien.Responsable_Nombre,
                                        ObjBien.Corresponsable,
                                        ObjBien.Codigo_Contable,
                                        ObjBien.Factura_Numero,
                                        ObjBien.Factura_Fecha_Str,
                                        ObjBien.Costo,
                                        ObjBien.Proveedor,
                                        ObjBien.Poliza,
                                        ObjBien.Cedula,
                                        ObjBien.Proyecto,
                                        ObjBien.Fuente_Financiamiento,
                                        ObjBien.Procedencia,
                                        ObjBien.Volante,
                                        ObjBien.Inventario_Anterior,
                                        ObjBien.Partida,
                                        Validado,
                                        ObjBien.Resguardo,
                                        ObjBien.Descripcion,
                                        
                                        
                                        //MUEBLES Y EQUIPOS
                                        ObjBien.Caracteristicas.ToUpper(),
                                        ObjBien.Color.ToUpper(),
                                        ObjBien.Marca.ToUpper(),
                                        ObjBien.Modelo.ToUpper(),
                                        ObjBien.No_Serie.ToUpper(),
                                         
                                        
                                        //INMUEBLES
                                        ObjBien.Inm_Direccion.ToUpper(),
                                        ObjBien.Inm_Ciudad.ToUpper(),
                                        ObjBien.Inm_TipoDoc.ToUpper(),
                                        ObjBien.Inm_NumeroDoc.ToUpper(),
                                        ObjBien.Inm_EstatusDoc.ToUpper(),
                                        ObjBien.Inm_FechaDoc_Str,
                                        ObjBien.Inm_ExpedicionDoc.ToUpper(),
                                        ObjBien.Inm_NotariaPublica.ToUpper(),
                                        ObjBien.Inm_AvaluoTerreno,
                                        ObjBien.Inm_AvaluoEdificio,
                                        ObjBien.Inm_FechaAvaluo_Str,
                                       

                                        //VEHICULOS Y TRACTORES
                                        ObjBien.Veh_Año.ToUpper(),
                                        ObjBien.Veh_NumeroPlacas.ToUpper(),
                                        ObjBien.Veh_NumeroMotor.ToUpper(),
                                        ObjBien.Veh_Tenencia.ToUpper(),
                                        ObjBien.Veh_PolizaSeguro.ToUpper(),
                                        ObjBien.Veh_FechaVencimiento_Str,
                                       
                                        
                                        //TIC
                                        ObjBien.Tic_Procesador.ToUpper(),
                                        ObjBien.Tic_SO.ToUpper(),
                                        ObjBien.Tic_RAM.ToUpper(),
                                        ObjBien.Tic_DiscoDuro.ToUpper(),
                                        ObjBien.Tic_Disquete.ToUpper(),
                                        ObjBien.Tic_UnidadOptica.ToUpper(),
                                        ObjBien.Tic_Accesorios.ToUpper(),
                                        
                                        
                                        //ACTIVOS BIOLOGICOS
                                        ObjBien.Sem_Sexo.ToUpper(),
                                        ObjBien.Sem_Raza.ToUpper(),
                                        ObjBien.Sem_Arete.ToUpper(),
                                        ObjBien.Sem_Edad.ToUpper(),
                                        ObjBien.Sem_FechaNac_Str,
                                        ObjBien.Sem_Peso.ToUpper(),
                                        ObjBien.Sem_CostoRevalorizado,
                                        ObjBien.Sem_FechaRevalorizado_Str,

                                        ObjBien.Observaciones.ToUpper(),
                                        ObjBien.Captura_Usuario,

                                         //ACTIVOS INTANGIBLES
                                        ObjBien.Int_TipoSoftware.ToUpper(),
                                        ObjBien.Int_Patente.ToUpper(),
                                        ObjBien.Int_DerechoAutor.ToUpper(),
                                        ObjBien.Int_CaducidadLicencia.ToUpper(),
                                        ObjBien.Int_Usuarios.ToUpper(),
                                        ObjBien.Int_Version.ToUpper(),
                                        ObjBien.Int_Idioma.ToUpper(),

                                       
                                        //COLECCIONES
                                        ObjBien.Col_Titulo.ToUpper(),
                                        ObjBien.Col_Autor.ToUpper(),
                                        ObjBien.Col_Editorial.ToUpper(),
                                        ObjBien.Col_Tomos.ToUpper(),
                                        ObjBien.Col_Edicion.ToUpper(),
                                        ObjBien.Col_ISBN.ToUpper()


                                   };
                String[] ParametrosOut = { "p_BANDERA", "P_No_INVENTARIO" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_BIEN", ref Verificador, Parametros, Valores, ParametrosOut);

                ObjBien.No_Inventario = Convert.ToString(Cmd.Parameters["P_No_INVENTARIO"].Value);
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
        public void InsertarSemoviente(ref Bien_Detalle Semoviente, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {
                                        "p_id_patrimonio" ,
                                       "p_id_etapa" ,
                                       "p_fecha_inicio",
                                       "p_peso",
                                       "p_costo",
                                       "p_fecha_parto",
                                       "p_id_semental",
                                       "p_metodo",
                                       "p_crias_hembra",
                                       "p_crias_macho",
                                       "p_id_padre",
                                       "p_id_madre",
                                       "p_observaciones",
                                       "p_usuario",
                                       "p_edad"
                                      };
                object[] Valores = {
                                        Semoviente.Id ,
                                        Semoviente.Sem_Id_Etapa ,
                                        Semoviente.Sem_FechaEtapa_Str,
                                        Semoviente.Sem_Peso,
                                        Semoviente.Costo ,
                                        Semoviente.Sem_FechaParto_Str,
                                        Semoviente.Sem_Id_Semental ,
                                        Semoviente.Sem_Metodo ,
                                        Semoviente.Sem_CriasH ,
                                        Semoviente.Sem_CriasM,
                                        Semoviente.Sem_Id_Padre,
                                        Semoviente.Sem_Id_Madre ,
                                        Semoviente.Observaciones,
                                        Semoviente.Captura_Usuario,
                                        Semoviente.Sem_Edad,
            };
                String[] ParametrosOut = { "p_BANDERA"};

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_SEMOVIENTES", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void InsertarSemoviente_Produccion(ref Bien_Detalle Semoviente, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {
                                        "p_id_patrimonio" ,
                                       "p_id_especie" ,
                                       "p_fecha",
                                       "p_peso",
                                       "p_edad",
                                       "p_ovino_vellon",
                                       "p_ovino_calidad",
                                       "p_ovino_trasquila",
                                       "p_ovino_epoca",
                                       "p_ovino_grupo",
                                       "p_alta_usuario"
                                      
                                      };
                object[] Valores = {
                                          Semoviente.Id ,
                                            Semoviente.Sem_Id_Especie,
                                            Semoviente.Sem_FechaNac_Str,
                                            Semoviente.Sem_Peso ,
                                            Semoviente.Sem_Edad,
                                            Semoviente.Sem_Vellon,
                                            Semoviente.Sem_Calidad,
                                            Semoviente.Sem_FechaTrasquila_Str ,
                                            Semoviente.Sem_Epoca,
                                            Semoviente.Sem_Grupo ,
                                            Semoviente.Captura_Usuario ,
            };
                String[] ParametrosOut = { "p_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_PRODUCCION", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void InsertarSemoviente_AutorizadoVenta(List<Bien_Detalle> Semovientes, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < Semovientes.Count; i++)
                {
                    String[] Parametros = {
                                              "p_ID_INVENTARIO"  ,
                                              "P_INVENTARIO_NUMERO" ,
                                              "p_DEPENDENCIA"  ,
                                              "p_DESCRIPCION" ,
                                              "p_SEM_ARETE" ,
                                              "p_ETAPA" ,
                                              "p_ESPECIE" ,
                                              "p_POLIZA" ,
                                              "p_COSTO" ,
                                              "p_PESO" ,
                                              "p_USUARIO_AUTORIZA"
                                          };

                    object[] Valores = {
                                        Semovientes[i].Id,
                                        Semovientes[i].No_Inventario,
                                        Semovientes[i].Dependencia,
                                        Semovientes[i].Descripcion,
                                        Semovientes[i].Sem_Arete,
                                        Semovientes[i].Sem_Etapa,
                                        Semovientes[i].Sem_Especie,
                                        Semovientes[i].Poliza,
                                        Semovientes[i].Costo,
                                        Convert.ToInt32(Semovientes[i].Sem_Peso),
                                        Semovientes[i].Captura_Usuario
                };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_SEMOVIENTES_VENTA", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Insertar_Componente(List<Bien_Detalle> Componentes, Bien_Detalle Padre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < Componentes.Count; i++)
                {
                    String[] Parametros = { "p_CENTRO_CONTABLE",
                                            "p_DEPENDENCIA",
                                            "p_SUB_DEPENDENCIA",
                                            "p_CENTRO_TRABAJO",
                                            "P_INVENTARIO",
                                            "p_EJERCICIO",
                                            "P_INVENTARIO_AUX",
                                            "p_ID_BIEN",
                                            "p_ID_TIPO_ALTA",
                                            "p_FORMULARIO",
                                            "p_FECHA_ALTA",
                                            "p_RESPONSABLE",
                                            "p_RESPONSABLE_NOMBRE",
                                            "p_CORRESPONSABLE",
                                            "p_COMPARATIVO",
                                            "p_FACTURA_NUMERO",
                                            "p_FACTURA_FECHA",
                                            "p_COSTO",
                                            "p_PROVEEDOR",
                                            "p_POLIZA",
                                            "p_CEDULA",
                                            "P_PROYECTO",
                                            "P_FUENTE",
                                            "p_PARTIDA",
                                            "p_CARACTERISTICA",
                                            "p_COLOR",
                                            "p_MARCA",
                                            "p_MODELO",
                                            "p_NUMERO_SERIE",
                                            "p_DESCRIPCION",
                                            "p_TIC_PROCESADOR",
                                            "p_TIC_SISTEMA_OPERATIVO",
                                            "p_TIC_RAM",
                                            "p_TIC_DISCO_DURO",
                                            "p_TIC_DISKETTE",
                                            "p_TIC_CD",
                                            "p_TIC_ACCESORIOS",
                                            "p_OBSERVACIONES",
                                            "p_CAPTURA_USUARIO",
                                            "p_INT_SOFT",
                                            "p_INT_PATENTE",
                                            "p_INT_AUTOR",
                                            "p_INT_CADUCIDAD",
                                            "p_INT_USUARIOS",
                                            "p_INT_VERSION",
                                            "p_INT_IDIOMA"
                                          };

                    object[] Valores = {
                                        Padre.Centro_Contable,
                                        Padre.Dependencia,
                                        Padre.SubDependencia,
                                        Padre.Centro_Trabajo,
                                        Padre.No_Inventario,
                                        Padre.Ejercicio,
                                        Convert.ToString(i + 1),
                                        Convert.ToInt32(Padre.Clave),
                                        Padre.IdTipo_Alta,
                                        Padre.Formulario,
                                        Padre.Fecha_Alta_Str,
                                        Padre.Responsable,
                                        Padre.Responsable_Nombre,
                                        Padre.Corresponsable,
                                        Padre.Codigo_Contable,
                                        Padre.Factura_Numero,
                                        Padre.Factura_Fecha_Str,
                                        0.00,
                                        Padre.Proveedor,
                                        Padre.Poliza,
                                        Padre.Cedula,
                                         Padre.Proyecto,
                                        Padre.Fuente_Financiamiento,
                                        Padre.Partida,
                                        Componentes[i].Caracteristicas,
                                        Componentes[i].Color,
                                        Componentes[i].Marca,
                                        Componentes[i].Modelo,
                                        Componentes[i].No_Serie,
                                        Padre.Descripcion,
                                        Padre.Tic_Procesador,
                                        Padre.Tic_SO,
                                        Padre.Tic_RAM,
                                        Padre.Tic_DiscoDuro,
                                        Padre.Tic_Disquete,
                                        Padre.Tic_UnidadOptica,
                                        Padre.Tic_Accesorios,
                                        Padre.Observaciones,
                                        Padre.Captura_Usuario,
                                        Padre.Int_TipoSoftware,
                                        Padre.Int_Patente,
                                        Padre.Int_DerechoAutor,
                                        Padre.Int_CaducidadLicencia,
                                        Padre.Int_Usuarios,
                                        Padre.Int_Version,
                                        Padre.Int_Idioma
                };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_BIEN_COMPONENTES", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ActualizarBien(ref Bien_Detalle ObjBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string Validado = string.Empty;
                if (ObjBien.Validado)
                    Validado = "S";
                else
                    Validado = "N";
                String[] Parametros = {
                                        "P_ID",
                                        "P_INVENTARIO",
                                        "p_SUB_DEPENDENCIA",
                                        "p_CENTRO_TRABAJO",
                                        "p_ID_BIEN",
                                        "p_ID_TIPO_ALTA",
                                        "p_FORMULARIO",
                                        "p_FECHA_ALTA",
                                        "p_FECHA_CONTABLE",
                                        "p_FECHA_ALTA_ANT",
                                        "p_RESPONSABLE",
                                        "p_RESPONSABLE_NOMBRE",
                                        "p_CORRESPONSABLE",
                                        "p_COMPARATIVO",
                                        "p_FACTURA_NUMERO",
                                        "p_FACTURA_FECHA",
                                        "p_COSTO",
                                        "p_PROVEEDOR",
                                        "p_POLIZA",
                                        "p_CEDULA",
                                        "P_PROYECTO",
                                        "P_FUENTE",
                                        "P_PROCEDENCIA",
                                        "P_VOLANTE",
                                        "P_INV_ANTERIOR",
                                        "p_PARTIDA",
                                        "P_VALIDADO",
                                        "P_RESGUARDO",
                                        "p_DESCRIPCION",
                                        "p_CARACTERISTICA",
                                        "p_COLOR",
                                        "p_MARCA",
                                        "p_MODELO",
                                        "p_NUMERO_SERIE",
                                        "p_INM_DIRECCION",
                                        "p_INM_CIUDAD",
                                        "p_INM_DOC_TIPO",
                                        "p_INM_DOC_NUMERO",
                                        "p_INM_DOC_STATUS",
                                        "p_INM_FECHA_DOCUMENTO",
                                        "p_INM_LUGAR_EXPEDICION",
                                        "p_INM_NUMERO_NOTARIA",
                                        "p_INM_AVALUO_TERRENO",
                                        "p_INM_AVALUO_EDIFICIO",
                                        "p_INM_AVALUO_FECHA",
                                        "p_VH_ANIO_MODELO",
                                        "p_VH_PLACAS",
                                        "p_VH_MOTOR",
                                        "p_VH_TENENCIA",
                                        "p_VH_POLIZA_SEGURO",
                                        "p_VH_FECHAV_SEGURO",
                                        "p_TIC_PROCESADOR",
                                        "p_TIC_SISTEMA_OPERATIVO",
                                        "p_TIC_RAM",
                                        "p_TIC_DISCO_DURO",
                                        "p_TIC_DISKETTE",
                                        "p_TIC_CD",
                                        "p_TIC_ACCESORIOS",
                                        "p_SEM_SEXO",
                                        "p_SEM_RAZA",
                                        "p_SEM_ARETE",
                                        "p_SEM_EDAD",
                                        "p_SEM_FECHA_NAC",
                                        "p_SEM_PESO",
                                        "p_SEM_COSTO_REVALOR",
                                        "p_SEM_FECHA_REVALOR",
                                        "p_OBSERVACIONES",
                                        "p_MOVIMIENTO_USUARIO",
                                        "p_INT_SOFT",
                                        "p_INT_PATENTE",
                                        "p_INT_AUTOR",
                                        "p_INT_CADUCIDAD",
                                        "p_INT_USUARIOS",
                                        "p_INT_VERSION",
                                        "p_INT_IDIOMA",
                                        "p_CLA_TITULO",
                                        "p_CLA_AUTOR",
                                        "p_CLA_EDITORIAL",
                                        "p_CLA_TOMOS",
                                        "p_CLA_EDICION",
                                        "p_CLA_ISBN",
                                        "p_RECLASIFICACION_FECHA",
                                        "p_RECLASIFICACION_CLAVE",
                                        "P_RECLASIFICADO"
                                      };
                object[] Valores = {
                                        ObjBien.Id,
                                        ObjBien.No_Inventario,
                                        ObjBien.SubDependencia,
                                        ObjBien.Centro_Trabajo,
                                        Convert.ToInt32( ObjBien.Clave),
                                        ObjBien.IdTipo_Alta,
                                        ObjBien.Formulario,
                                        ObjBien.Fecha_Alta_Str,
                                        ObjBien.Fecha_Contable_Str,
                                        ObjBien.Fecha_Alta_Ant_Str,
                                        ObjBien.Responsable,
                                        ObjBien.Responsable_Nombre,
                                        ObjBien.Corresponsable,
                                        ObjBien.Codigo_Contable,
                                        ObjBien.Factura_Numero,
                                        ObjBien.Factura_Fecha_Str,
                                        ObjBien.Costo,
                                        ObjBien.Proveedor,
                                        ObjBien.Poliza,
                                        ObjBien.Cedula,
                                        ObjBien.Proyecto,
                                        ObjBien.Fuente_Financiamiento,
                                        ObjBien.Procedencia,
                                        ObjBien.Volante,
                                        ObjBien.Inventario_Anterior,
                                        ObjBien.Partida,
                                        Validado,
                                        ObjBien.Resguardo,
                                        ObjBien.Descripcion,

                                        
                                        
                                        //MUEBLES Y EQUIPOS
                                        ObjBien.Caracteristicas.ToUpper(),
                                        ObjBien.Color.ToUpper(),
                                        ObjBien.Marca.ToUpper(),
                                        ObjBien.Modelo.ToUpper(),
                                        ObjBien.No_Serie.ToUpper(),
                                         
                                        
                                        //INMUEBLES
                                        ObjBien.Inm_Direccion.ToUpper(),
                                        ObjBien.Inm_Ciudad.ToUpper(),
                                        ObjBien.Inm_TipoDoc.ToUpper(),
                                        ObjBien.Inm_NumeroDoc.ToUpper(),
                                        ObjBien.Inm_EstatusDoc.ToUpper(),
                                        ObjBien.Inm_FechaDoc_Str,
                                        ObjBien.Inm_ExpedicionDoc.ToUpper(),
                                        ObjBien.Inm_NotariaPublica.ToUpper(),
                                        ObjBien.Inm_AvaluoTerreno,
                                        ObjBien.Inm_AvaluoEdificio,
                                        ObjBien.Inm_FechaAvaluo_Str,
                                       

                                        //VEHICULOS Y TRACTORES
                                        ObjBien.Veh_Año.ToUpper(),
                                        ObjBien.Veh_NumeroPlacas.ToUpper(),
                                        ObjBien.Veh_NumeroMotor.ToUpper(),
                                        ObjBien.Veh_Tenencia.ToUpper(),
                                        ObjBien.Veh_PolizaSeguro.ToUpper(),
                                        ObjBien.Veh_FechaVencimiento_Str,
                                       
                                        
                                        //TIC
                                        ObjBien.Tic_Procesador.ToUpper(),
                                        ObjBien.Tic_SO.ToUpper(),
                                        ObjBien.Tic_RAM.ToUpper(),
                                        ObjBien.Tic_DiscoDuro.ToUpper(),
                                        ObjBien.Tic_Disquete.ToUpper(),
                                        ObjBien.Tic_UnidadOptica.ToUpper(),
                                        ObjBien.Tic_Accesorios.ToUpper(),
                                        
                                        
                                        //ACTIVOS BIOLOGICOS
                                        ObjBien.Sem_Sexo.ToUpper(),
                                        ObjBien.Sem_Raza.ToUpper(),
                                        ObjBien.Sem_Arete.ToUpper(),
                                        ObjBien.Sem_Edad.ToUpper(),
                                        ObjBien.Sem_FechaNac_Str,
                                        ObjBien.Sem_Peso.ToUpper(),
                                        ObjBien.Sem_CostoRevalorizado,
                                        ObjBien.Sem_FechaRevalorizado_Str,

                                        ObjBien.Observaciones.ToUpper(),
                                        ObjBien.Captura_Usuario,


                                         //ACTIVOS INTANGIBLES
                                        ObjBien.Int_TipoSoftware.ToUpper(),
                                        ObjBien.Int_Patente.ToUpper(),
                                        ObjBien.Int_DerechoAutor.ToUpper(),
                                        ObjBien.Int_CaducidadLicencia.ToUpper(),
                                        ObjBien.Int_Usuarios.ToUpper(),
                                        ObjBien.Int_Version.ToUpper(),
                                        ObjBien.Int_Idioma.ToUpper(),

                                       
                                        //COLECCIONES
                                        ObjBien.Col_Titulo.ToUpper(),
                                        ObjBien.Col_Autor.ToUpper(),
                                        ObjBien.Col_Editorial.ToUpper(),
                                        ObjBien.Col_Tomos.ToUpper(),
                                        ObjBien.Col_Edicion.ToUpper(),
                                        ObjBien.Col_ISBN.ToUpper(),

                                        ObjBien.Fecha_Reclasificacion_Str,
                                        ObjBien.Clave_Anterior,
                                        ObjBien.Reclasificado
                                   };
                String[] ParametrosOut = { "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_BIEN", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ActualizarBien_SuperEditor(ref Bien_Detalle ObjBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {
                                        "P_ID",
                                        "P_CENTRO_CONTABLE",
                                        "P_DEPENDENCIA",
                                        "P_SubDependencia",
                                        "P_INVENTARIO",
                                        "P_FECHA_ALTA",
                                        "P_FECHA_CONTABLE",
                                        "P_ID_TIPO_ALTA",
                                        "p_POLIZA",
                                        "p_COMPARATIVO",
                                        "P_ID_BIEN",
                                        "p_CEDULA",
                                        "P_INV_ANTERIOR",
                                        "P_VOLANTE",
                                        "P_FECHA_ALTA_ANT",
                                        "P_PROCEDENCIA",
                                        "P_PROYECTO",
                                        "P_FUENTE",
                                       "P_CENTRO_TRABAJO",
                                       "p_PARTIDA",
                                       "P_STATUS",
                                       "P_RECLASIFICADO",
                                       "P_FECHA_RECLASIFICACION",
                                       "p_MOVIMIENTO_USUARIO"
                                      };
                object[] Valores = {
                                        ObjBien.Id,
                                         ObjBien.Centro_Contable ,
                                         ObjBien.Dependencia,
                                         ObjBien.SubDependencia,
                                        ObjBien.No_Inventario,
                                        ObjBien.Fecha_Alta_Str,
                                        ObjBien.Fecha_Contable_Str,
                                        ObjBien.IdTipo_Alta,
                                        ObjBien.Poliza,
                                        ObjBien.Codigo_Contable,
                                        ObjBien.Clave,
                                        ObjBien.Cedula,
                                        ObjBien.Inventario_Anterior,
                                        ObjBien.Volante,
                                        ObjBien.Fecha_Alta_Ant_Str,
                                        ObjBien.Procedencia,
                                        ObjBien.Proyecto,
                                        ObjBien.Fuente_Financiamiento,
                                        ObjBien.Centro_Trabajo,
                                        ObjBien.Partida,
                                        ObjBien.Estatus,
                                        ObjBien.Reclasificado,
                                        ObjBien.Fecha_Reclasificacion_Str,
                                        ObjBien.Captura_Usuario 
                                   };
                String[] ParametrosOut = { "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_BIEN_EDITOR", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EliminarEtapa_Semoviente(Bien objBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", };
                object[] Valores = { objBien.Id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_ETAPA_SEMOVIENTE", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarProduccion(Bien objBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", };
                object[] Valores = { objBien.Id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_PAT_PRODUCCION", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ActualizarSemoviente(ref Bien_Detalle ObjBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                
                String[] Parametros = {
                                        "P_ID",
                                        "p_COLOR",
                                        "p_SEM_SEXO",
                                        "p_SEM_RAZA",
                                        "p_SEM_ARETE",
                                        //"p_SEM_EDAD",
                                        "p_SEM_FECHA_NAC",
                                        //"p_SEM_PESO",
                                        "P_PROCEDENCIA",
                                        "P_CENTRO_TRABAJO",
                                        "p_MOVIMIENTO_USUARIO"
                                      };
                object[] Valores = {
                                        ObjBien.Id,
                                         ObjBien.Color.ToUpper(),
                                        ObjBien.Sem_Sexo.ToUpper(),
                                        ObjBien.Sem_Raza.ToUpper(),
                                        ObjBien.Sem_Arete.ToUpper(),
                                        //ObjBien.Sem_Edad.ToUpper(),
                                        ObjBien.Sem_FechaNac_Str,
                                        //ObjBien.Sem_Peso.ToUpper(),
                                        ObjBien.Procedencia.ToUpper(),
                                        ObjBien.Centro_Trabajo,
                                        ObjBien.Captura_Usuario

            };
                String[] ParametrosOut = { "p_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_SEMOVIENTE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ActualizarResponsable(ref String Verificador, string valor1, string valor2, string valor3, string valor4, string valor5, string valor6)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                if (valor6 == "R")
                {
                    String[] Parametros = {
                                            "p_DEPENDENCIA",
                                            "p_RESPONSABLE",
                                            "p_RESPONSABLE_NUEVO",
                                            "p_RESPONSABLE_NOMBRE_NUEVO",
                                            "P_USUARIO_MODIFICA"
                                      };
                    object[] Valores = {
                                        valor1,
                                        valor2,
                                        valor3,
                                        valor4,
                                        valor5,
                                        valor6
                                  };
                    String[] ParametrosOut = { "p_BANDERA" };
                    Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_RESPONSABLE", ref Verificador, Parametros, Valores, ParametrosOut);
                }
                else
                {
                    String[] Parametros = {
                                            "p_DEPENDENCIA",
                                            "p_INV_INI",
                                            "p_INV_FIN",
                                            "P_RESPONSABLE_NUEVO",
                                            "p_RESPONSABLE_NOMBRE_NUEVO",
                                            "P_USUARIO_MODIFICA"
                                      };
                    object[] Valores = {
                                        valor1,
                                        valor2,
                                        valor3,
                                        valor4,
                                        valor5,
                                        valor6

                                   };
                    String[] ParametrosOut = { "p_BANDERA" };
                    Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_RESPONSABLE_LOTE", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ActualizarStatusValidado( ref string Verificador,int ID, bool Status)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string Validado = string.Empty;
                if (Status)
                    Validado = "S";
                else
                    Validado = "N";

                String[] Parametros = {
                                            "P_ID_INVENTARIO",
                                            "P_STATUS"
                                      };
                    object[] Valores = {
                                        ID,
                                        Validado
                                  };
                    String[] ParametrosOut = { "p_BANDERA" };
                    Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_BIEN_VALIDACION", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void EliminarBien(Bien objBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID","P_INVENTARIO" };
                object[] Valores = { objBien.Id, objBien.No_Inventario};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_INVENTARIO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Eliminar_SemovienteVenta(Bien objBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_INVENTARIO" };
                object[] Valores = { objBien.Id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_SEMOVIENTE_VENTA", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void Obtener_Grid_Componentes(ref Bien_Detalle ObjBien, ref List<Bien_Detalle> Componentes)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "P_INVENTARIO" };
                object[] Valores = { ObjBien.No_Inventario };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Componentes", ref dr, Parametros, Valores);
                Bien_Detalle MiBien;
                while (dr.Read())
                {
                    MiBien = new Bien_Detalle();

                    MiBien.No_Inventario = Convert.ToString(dr.GetValue(0));
                    MiBien.Inventario_Auxiliar = Convert.ToString(dr.GetValue(1));
                    MiBien.Caracteristicas = Convert.ToString(dr.GetValue(2));
                    MiBien.Marca = Convert.ToString(dr.GetValue(3));
                    MiBien.Modelo = Convert.ToString(dr.GetValue(4));
                    MiBien.No_Serie = Convert.ToString(dr.GetValue(5));
                    MiBien.Color = Convert.ToString(dr.GetValue(6));
                    Componentes.Add(MiBien);
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
