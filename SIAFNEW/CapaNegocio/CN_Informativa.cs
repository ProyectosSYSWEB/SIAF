using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public  class CN_Informativa
    {
        public void Consultar_Observaciones(ref cuentas_contables Objinformativa, ref string Verificador)
        {
            try
            {
                CD_Informativa  CDcuenta = new CD_Informativa ();
                CDcuenta.Consultar_Observaciones(ref  Objinformativa, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Consultar_Observaciones_edit(ref cuentas_contables Objinformativa, ref string Verificador)
        {
            try
            {
                CD_Informativa CDcuenta = new CD_Informativa();
                CDcuenta.Consultar_Observaciones_edit(ref  Objinformativa, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete_Observaciones_edit(ref cuentas_contables Objinformativa, ref string Verificador)
        {
            try
            {
                CD_Informativa CDcuenta = new CD_Informativa();
                CDcuenta.Delete_Observaciones_edit(ref  Objinformativa, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insertar_observaciones(ref cuentas_contables objinformativa, ref string Verificador)
        {
            try
            {

                CD_Informativa CDinformativa = new CD_Informativa();
                CDinformativa.insertar_observaciones(ref objinformativa, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void update_observaciones(ref cuentas_contables objinformativa, ref string Verificador)
        {
            try
            {

                CD_Informativa CDinformativa = new CD_Informativa();
                CDinformativa.update_observaciones(ref objinformativa, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarInformativa(ref cuentas_contables Objinformativa, string buscar, ref List<cuentas_contables> List)
        {
            try
            {
                CD_Informativa CDinformativa = new CD_Informativa();
                CDinformativa.ConsultarInformativa(ref Objinformativa, buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
