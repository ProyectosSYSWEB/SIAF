using System;
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


        public void InsertarDependencia(ref Dependencias objDependencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_C_CONTAB", "P_CLAVE", "P_DESCRIPCION", "P_TITULAR", "P_ADMINISTRADOR", "P_DOMICILIO", "P_ID_ESTADO", "P_ID_MUNICIPIO", "P_ZONA_ECONOMICA", "P_TEL_TITULAR", "P_CEL_TITULAR", "P_TEL_ADMIN", "P_CEL_ADMIN", "P_NOMBRAMIENTO", "P_EJERCICIO" };
                object[] Valores = { objDependencias.C_Contab, objDependencias.Clave, objDependencias.Descrip, objDependencias.Titular, objDependencias.Administ, objDependencias.Domicilio, objDependencias.Id_Estado, objDependencias.Id_Municipio, objDependencias.Zona_Economica, objDependencias.Tel_Titular, objDependencias.Cel_Titular, objDependencias.Tel_Admin, objDependencias.Cel_Admin, objDependencias.Nombramiento, objDependencias.Ejercicio };            
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRES_CAT_DEPEN", ref Verificador, Parametros, Valores, ParametrosOut);

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
