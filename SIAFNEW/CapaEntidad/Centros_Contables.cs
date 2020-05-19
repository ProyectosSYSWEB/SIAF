using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Centros_Contables
    {
        private int _Id_Control_Cierre;
        public int Id_Control_Cierre
        {
            get { return _Id_Control_Cierre; }
            set { _Id_Control_Cierre = value; }
        }

        private string _Centro_Contable;
        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }

        private string _Mes_anio;
        public string Mes_anio
        {
            get { return _Mes_anio.Trim(); }
            set { _Mes_anio = value.Trim(); }
        }

        private string _Cierre_Definitivo;
        public string Cierre_Definitivo
        {
            get { return _Cierre_Definitivo.Trim(); }
            set { _Cierre_Definitivo = value.Trim(); }
        }
        
        private int _Ejercicio;
        public int Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

        private string _sistema;
        public string sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status.Trim(); }
            set { _Status = value.Trim(); }
        }

    }
}
