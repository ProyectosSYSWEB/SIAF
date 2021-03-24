using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Programa
    {
        public void ProgramasGrid(ref Programa objPrograma, ref List<Programa> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_funcion" };
                String[] Valores = { objPrograma.Funcion };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_F_Prog", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPrograma = new Programa();
                    objPrograma.Id = Convert.ToString(dr.GetValue(0));
                    objPrograma.Funcion = Convert.ToString(dr.GetValue(1));                    
                    objPrograma.F_Prog = Convert.ToString(dr.GetValue(2));
                    objPrograma.Descripcion = Convert.ToString(dr.GetValue(3));
                    List.Add(objPrograma);
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


        public void InsertarPrograma(ref Programa objPrograma, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_FUNCION", "P_F_PROG", "P_DESCRIP", "P_FUNFED" }; // No se inserta ningun dato en el parametor FFUNFED
                object[] Valores = { objPrograma.Funcion, objPrograma.F_Prog, objPrograma.Descripcion, objPrograma.Funfed  };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_CAT_F_PROG", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void ObtenerDatosPrograma(ref Programa objPrograma, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { objPrograma.Id };
                string[] ParametrosOut = { "P_ID_FUNCION", "P_CLAVE", "P_DESCRIPCION", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_SAF_FUNCION_PROG", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objPrograma = new Programa();
                    objPrograma.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objPrograma.Id_FuncionProg = Convert.ToString(Cmd.Parameters["P_ID_FUNCION"].Value);
                    objPrograma.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objPrograma.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);                    
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
        public void EditarPrograma(ref Programa objPrograma, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_ID_FUNCION_PROG", "P_CLAVE", "P_DESCRIPCION"};
                object[] Valores = { objPrograma.Id, objPrograma.Id_FuncionProg, objPrograma.Clave, objPrograma.Descripcion};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_FUNCION_PROG", ref Verificador, Parametros, Valores, ParametrosOut);

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
