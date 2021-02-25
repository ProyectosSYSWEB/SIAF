﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Capitulos
    {
        public void CapitulosGrid(ref Basicos objBasicos, ref List<Basicos> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_tipo", "p_status" };
                String[] Valores = { objBasicos.tipo, objBasicos.status };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Catalogos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objBasicos = new Basicos();
                    objBasicos.clave = Convert.ToString(dr.GetValue(0));
                    objBasicos.descripcion = Convert.ToString(dr.GetValue(1));
                    objBasicos.valor = Convert.ToString(dr.GetValue(2));
                    objBasicos.tipo = Convert.ToString(dr.GetValue(3));
                    objBasicos.status = Convert.ToString(dr.GetValue(4));                    
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
    }
}
