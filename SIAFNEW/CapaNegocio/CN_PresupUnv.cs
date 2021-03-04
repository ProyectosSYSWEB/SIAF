using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_PresupUnv
    {
        public void ObtenerDatosCodProg(ref PresupUnv objPresupUnv, ref string Verificador)
        {
            try
            {
                CD_PresupUnv CD_PresupUnv = new CD_PresupUnv();
                CD_PresupUnv.ObtenerDatosCodProg(ref objPresupUnv, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void PresUnvGrid(ref PresupUnv objConsultas, ref List<PresupUnv> List)
        {
            try
            {
                CD_PresupUnv CD_Presupunv = new CD_PresupUnv();
                CD_Presupunv.PresUnvGrid(ref objConsultas, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insertar_PresupUnv(ref PresupUnv objPresUnv, ref string Verificador)
        {
            try
            {
                CD_PresupUnv CD_Presupunv = new CD_PresupUnv();
                CD_Presupunv.Insertar_PresupUnv(ref objPresUnv, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ObtenerConsecutivoTipoOperacion(ref PresupUnv objPresupUnv, ref string Verificador)
        {
            try
            {
                CD_PresupUnv CD_PresupUnv = new CD_PresupUnv();
                CD_PresupUnv.ObtenerConsecutivoTipoOperacion(ref objPresupUnv, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
