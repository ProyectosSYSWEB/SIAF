using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Partida
    {
        public void PartidasGrid(ref Partidas objPartida, ref List<Partidas> List)
        {
            try
            {
                CD_Partidas CD_Partidas = new CD_Partidas();
                CD_Partidas.PartidasGrid(ref objPartida, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarPartida(ref Partidas objPartida, ref string Verificador)
        {
            try
            {
                CD_Partidas CD_Partidas = new CD_Partidas();
                CD_Partidas.InsertarPartida(ref objPartida, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerDatosPartida(ref Partidas objPartida, ref string Verificador)
        {
            try
            {
                CD_Partidas CD_Partidas = new CD_Partidas();
                CD_Partidas.ObtenerDatosPartida(ref objPartida, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarPartida(ref Partidas objPartida, ref string Verificador)
        {
            try
            {
                CD_Partidas CD_Partidas = new CD_Partidas();
                CD_Partidas.EditarPartida(ref objPartida, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarPartida(Partidas objPartida, ref string Verificador)
        {
            try
            {
                CD_Partidas CD_Partidas = new CD_Partidas();
                CD_Partidas.EliminarPartida(objPartida, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
