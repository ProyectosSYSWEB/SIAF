using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Bienes
    {

        public void Consultar_Bienes(ref Bienes ObjBienes, string buscar, ref List<Bienes> List)
        {
            try
            {

                CD_Bienes CDBienes = new CD_Bienes();
                CDBienes.Consultar_Bienes(ref ObjBienes, buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Consulta_clave(ref Bienes ObjBienes, ref string Verificador)
        {
            try
            {
                CD_Bienes CDBienes = new CD_Bienes();
                CDBienes.Consulta_clave(ref ObjBienes, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insertar_Bienes(ref Bienes objBienes, ref string Verificador)
        {
            try
            {

                CD_Bienes CDBienes = new CD_Bienes();
                CDBienes.Insertar_Bienes(ref objBienes, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Consulta_Bien(ref Bienes objBienes, ref string Verificador)
        {
            try
            {
                CD_Bienes CDBienes = new CD_Bienes();
                CDBienes.Consulta_Bien(ref  objBienes, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Eliminar_Bienes(ref Bienes objBienes, ref string Verificador)
        {
            try
            {

                CD_Bienes CDBienes = new CD_Bienes();
                CDBienes.Eliminar_Bienes(ref objBienes, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar_Bienes(ref Bienes objBienes, ref string Verificador)
        {
            try
            {
                CD_Bienes CDBienes = new CD_Bienes();
                CDBienes.Editar_Bienes(ref objBienes, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
