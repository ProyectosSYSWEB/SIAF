using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public  class CN_Cuentas_contables
    {
        public void PolizaConsultaGrid(ref cuentas_contables Objcuentas_contables, ref List<cuentas_contables> List)
        {
            try
            {
                CD_Cuentas_contables CDcuenta_contable = new CD_Cuentas_contables();
                CDcuenta_contable.PolizaConsultaGrid(ref Objcuentas_contables,  ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarCuentas_contables(ref cuentas_contables Objcuentas_contables, string buscar, ref List<cuentas_contables> List)
        {
            try
            {

                CD_Cuentas_contables CDcuentas_contables = new CD_Cuentas_contables();
                CDcuentas_contables.ConsultarCuentas_Contables(ref Objcuentas_contables, buscar, ref List);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Consultarcuenta_contable(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            try
            {
                CD_Cuentas_contables CDcuenta = new CD_Cuentas_contables();
                CDcuenta.Consultarcuenta(ref  objcuentas_contables, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public  void insertar_cuenta_contable(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            try
            {

                CD_Cuentas_contables CDcuenta = new CD_Cuentas_contables();
                CDcuenta.insertar_cuenta_contable(ref objcuentas_contables, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar_cuentas_contables(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            try
            {
                CD_Cuentas_contables cdcuenta = new CD_Cuentas_contables();
                cdcuenta.Editar_cuentas_contables(ref objcuentas_contables, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_cuenta_contable(ref cuentas_contables objcuentas_contables, ref string Verificador)
        {
            try
            {

                CD_Cuentas_contables CDcuenta = new CD_Cuentas_contables();
                CDcuenta.Eliminar_cuenta_contable(ref objcuentas_contables, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

