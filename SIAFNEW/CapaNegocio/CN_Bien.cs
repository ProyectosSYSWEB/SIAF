using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Bien
    {
        public void Obtener_Grid_Componentes(ref Bien_Detalle ObjBien, ref List<Bien_Detalle> ListComponentes)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.Obtener_Grid_Componentes(ref ObjBien, ref ListComponentes);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGrid(Bien Parametros, String Buscar, String Fecha_Ini, String Fecha_Fin, ref List<Bien> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGrid(Parametros,Buscar,  Fecha_Ini,Fecha_Fin,ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGrid(String Dependencia, String Estatus,String Especie, String Etapa,String Buscar,  ref List<Bien_Detalle> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGrid(Dependencia, Estatus,Especie,Etapa,Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGrid( String Buscar, ref List<Bien> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGrid(Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGridSemovientesVenta(Bien Parametros, String Buscar, ref List<Bien_Detalle> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGridSemovientesVenta(Parametros, Buscar,  ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGridHistorico(String Buscar, ref List<Bien_Detalle> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGridHistorico(Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGridProduccion(String Buscar, ref List<Bien_Detalle> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGridProduccion(Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Consultar_Bien_Responsable(ref Bien Objbien, ref List<Bien> List)
        {
            try
            {

                CD_Bien CDBien = new CD_Bien();
                CDBien.Consultar_Bien_Responsable(ref Objbien , ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarBien(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ConsultarBien(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarBien_Semoviente(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ConsultarSemoviente(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarBien_SemovienteEtapa(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ConsultarSemovienteEtapa(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarBien(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.InsertarBien(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarSemoviente(ref Bien_Detalle ObjBien_Sem, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.InsertarSemoviente(ref ObjBien_Sem, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarSemoviente_Produccion(ref Bien_Detalle ObjBien_Sem, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.InsertarSemoviente_Produccion(ref ObjBien_Sem, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarSemoviente_AutorizadoVenta(List<Bien_Detalle> Semovientes, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.InsertarSemoviente_AutorizadoVenta(Semovientes, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_Componente(List<Bien_Detalle> List, Bien_Detalle Padre, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien_Detalle = new CD_Bien();
                CDBien_Detalle.Insertar_Componente(List, Padre, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarBien(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ActualizarBien(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarBien_SuperEditor(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ActualizarBien_SuperEditor(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarEtapa(Bien ObjBien, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EliminarEtapa_Semoviente(ObjBien, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarProduccion(Bien ObjBien, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EliminarProduccion(ObjBien, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarSemoviente(ref Bien_Detalle ObjBien_Det, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ActualizarSemoviente(ref ObjBien_Det, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarResponsable(ref String Verificador, string valor1, string valor2, string valor3, string valor4, string valor5, string valor6)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ActualizarResponsable(ref Verificador, valor1,valor2, valor3, valor4, valor5, valor6);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarStatusValidado(ref String Verificador, int Id_Inventario, bool Estatus)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ActualizarStatusValidado(ref Verificador, Id_Inventario,Estatus );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarBien( Bien ObjBien, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EliminarBien( ObjBien, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_SemovienteVenta(Bien ObjBien, ref String Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.Eliminar_SemovienteVenta(ObjBien, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
