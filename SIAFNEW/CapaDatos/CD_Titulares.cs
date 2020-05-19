using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Titulares
    {
        public void ConsultarTitulares(ref Titulares ObjTitulares, string buscar, ref List<Titulares> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "P_Dependencia", "P_Buscar" };
                Object[] Valores = { ObjTitulares.Dependencia, buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PATRIMONIO.Obt_Grid_titulares", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjTitulares = new Titulares();
                    ObjTitulares.Id = Convert.ToString(dr[0]);
                    ObjTitulares.Id_Responsable = Convert.ToString(dr[1]);
                    ObjTitulares.Id_Administrador = Convert.ToString(dr[2]);
                    ObjTitulares.Puesto_Resp = Convert.ToString(dr[3]);
                    ObjTitulares.Puesto_Admin = Convert.ToString(dr[4]);
                    ObjTitulares.Dependencia = Convert.ToString(dr[5]);
                    ObjTitulares.Responsable = Convert.ToString(dr[6]);
                    ObjTitulares.Administrador = Convert.ToString(dr[7]);
                    List.Add(ObjTitulares);

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
        public void update_Titulares(ref Titulares objTitular, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "p_responsable", "p_administrador", "p_puesto_resp", "p_puesto_admin", "p_id_resp", "p_id_admi" };
                object[] Valores = { objTitular.Id, objTitular.Responsable, objTitular.Administrador, objTitular.Puesto_Resp, objTitular.Puesto_Admin, objTitular.Id_Responsable, objTitular.Id_Administrador};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SIGA09_TITULARES", ref Verificador, Parametros, Valores, ParametrosOut);

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
