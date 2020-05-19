using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Configuracion_forms
    {
        public void Consultar_Configuraciones(ref Configuracion_forms ObjConfiguracion_forms, string buscar, ref List<Configuracion_forms> List)
        {
            try
            {
                CD_Configuracion_forms CDConfiguracion_forms = new CD_Configuracion_forms();
                CDConfiguracion_forms.Consultar_Configuraciones(ref ObjConfiguracion_forms, buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insertar_Configuracion_forms(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            try
            {

                CD_Configuracion_forms CDConfiguracion_forms = new CD_Configuracion_forms();
                CDConfiguracion_forms.Insertar_Configuracion_forms(ref objConfiguracion_forms, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar_Configuracion_forms(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            try
            {

                CD_Configuracion_forms CDConfiguracion_forms = new CD_Configuracion_forms();
                CDConfiguracion_forms.Editar_Configuracion_forms(ref objConfiguracion_forms, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Consulta_ConfiguracionForm(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            try
            {

                CD_Configuracion_forms CDConfiguracion_forms = new CD_Configuracion_forms();
                CDConfiguracion_forms.Consulta_ConfiguracionForm(ref objConfiguracion_forms, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Eliminar_Configuracion_forms(ref Configuracion_forms objConfiguracion_forms, ref string Verificador)
        {
            try
            {

                CD_Configuracion_forms CDConfiguracion_forms = new CD_Configuracion_forms();
                CDConfiguracion_forms.Eliminar_Configuracion_forms(ref objConfiguracion_forms, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
