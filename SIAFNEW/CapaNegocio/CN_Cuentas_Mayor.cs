using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public  class CN_Cuentas_Mayor
    {
        public void ConsultarCuentas_mayor(ref Cuentas_Mayor Objcuentas_mayor, string buscar, ref List<Cuentas_Mayor > List)
        {
            try
            {

                CD_Cuentas_Mayor CDcuentas_mayor = new CD_Cuentas_Mayor ();
                CDcuentas_mayor.ConsultarCuentas_mayor(ref Objcuentas_mayor, buscar, ref List);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Consultarcuenta_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            try
            {
                CD_Cuentas_Mayor CDcuenta = new CD_Cuentas_Mayor();
                CDcuenta.Consultarmayor(ref  objcuentas_mayor, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar_cuentas_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            try
            {
              CD_Cuentas_Mayor cdcuenta = new CD_Cuentas_Mayor();
                cdcuenta.Editar_cuentas_mayor(ref objcuentas_mayor, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void insertar_cuenta_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            try
            {

                CD_Cuentas_Mayor  CDcuenta = new CD_Cuentas_Mayor();
                CDcuenta.insertar_cuenta_mayor(ref objcuentas_mayor, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_cuenta_mayor(ref Cuentas_Mayor objcuentas_mayor, ref string Verificador)
        {
            try
            {

                CD_Cuentas_Mayor CDcuenta = new CD_Cuentas_Mayor();
                CDcuenta.Eliminar_cuenta_mayor(ref objcuentas_mayor, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
