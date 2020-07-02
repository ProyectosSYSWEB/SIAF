using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
   public  class Pres_Costeo
    {
        public string _Ejercicio;
        public string _Dependencia;
        public string _Tipo_personal;
        public string _Prima_Vacacional;
        public string _Aguinaldo;
        public string _Ajuste_Calendario;
        public string _Issste;
        public string _Fovissste;
        public string _Sar;


        public string Sar
        {
            get { return _Sar; }
            set { _Sar = value; }
        }


        public string Fovissste
        {
            get { return _Fovissste; }
            set { _Fovissste = value; }
        }

        public string Issste
        {
            get { return _Issste; }
            set { _Issste = value; }
        }

        public string Ajuste_Calendario
        {
            get { return _Ajuste_Calendario; }
            set { _Ajuste_Calendario = value; }
        }

        public string Aguinaldo
        {
            get { return _Aguinaldo; }
            set { _Aguinaldo = value; }
        }

        public string Prima_Vacacional
        {
            get { return _Prima_Vacacional; }
            set { _Prima_Vacacional = value; }
        }

        public string Tipo_personal
        {
            get { return _Tipo_personal; }
            set { _Tipo_personal = value; }
        }


        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }
    }
}
