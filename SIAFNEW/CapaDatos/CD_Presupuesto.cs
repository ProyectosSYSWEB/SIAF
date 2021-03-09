﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
using System.Web.UI.WebControls;
using System.IO;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Presupuesto
    {
        public void PresupuestoConsultaGrid(ref Presupues ObjPresupuesto, ref List<Presupues> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_id"};
                String[] Valores = { ObjPresupuesto.Id };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Presupuesto", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjPresupuesto = new Presupues();
                    ObjPresupuesto.Descripcion = Convert.ToString(dr.GetValue(4));
                    ObjPresupuesto.Autorizado = Convert.ToDouble(dr.GetValue(7));
                    ObjPresupuesto.Modificado = Convert.ToDouble(dr.GetValue(8));
                    ObjPresupuesto.Ejercido = Convert.ToDouble(dr.GetValue(9));
                    ObjPresupuesto.Avance = Convert.ToInt32(dr.GetValue(10));
                    List.Add(ObjPresupuesto);
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

        public void InsertarEstructuraProgramatica(Presupues objEstruct, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CENTRO_CONTABLE", "P_PROGRAMA", "P_SUBPROGRAMA", "P_DEPENDENCIA", "P_PROYECTO", "P_STATUS", "P_EJERCICIO" };
                object[] Valores = { objEstruct.Centro_Contable, objEstruct.Programa, objEstruct.SubPrograma, objEstruct.Dependencia, objEstruct.Proyecto, objEstruct.Status, objEstruct.Ejercicio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_CAT_ESTRUCT", ref Verificador, Parametros, Valores, ParametrosOut);

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
