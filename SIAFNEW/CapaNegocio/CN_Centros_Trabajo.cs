using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Centros_Trabajo
    {
       public void ConsultarCentros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, string buscar, ref List<Centros_Trabajo> List)
       {
           try
           {

               CD_Centros_Trabajo CDCentros_Trabajo = new CD_Centros_Trabajo();
               CDCentros_Trabajo.ConsultarCentros_Trabajo(ref objCentros_Trabajo, buscar, ref List);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public void ConsultarMax_id_dependencia(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
       {
           try
           {

               CD_Centros_Trabajo CDCentros_Trabajo = new CD_Centros_Trabajo();
               CDCentros_Trabajo.ConsultarMax_id_dependencia(ref  objCentros_Trabajo, ref Verificador);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public void Consulta_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
       {
           try
           {
               CD_Centros_Trabajo CDCentros_Trabajo = new CD_Centros_Trabajo();
               CDCentros_Trabajo.Consulta_Centros_Trabajo(ref  objCentros_Trabajo, ref Verificador);

           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }


       public void insertar_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
       {
           try
           {

               CD_Centros_Trabajo CDCentros_Trabajo = new CD_Centros_Trabajo();
               CDCentros_Trabajo.insertar_Centros_Trabajo(ref objCentros_Trabajo, ref Verificador);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public void Editar_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
       {
           try
           {
               CD_Centros_Trabajo cdCentros_Trabajo = new CD_Centros_Trabajo();
               cdCentros_Trabajo.Editar_Centros_Trabajo(ref objCentros_Trabajo, ref Verificador);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public void Eliminar_Centros_Trabajo(ref Centros_Trabajo objCentros_Trabajo, ref string Verificador)
       {
           try
           {

               CD_Centros_Trabajo CDCentros_Trabajo = new CD_Centros_Trabajo();
               CDCentros_Trabajo.Eliminar_Centros_Trabajo(ref objCentros_Trabajo, ref Verificador);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }


    }
}
