using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Estruct
    {
        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Centro_Contable;

        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }

        private string _Programa;

        public string Programa
        {
            get { return _Programa; }
            set { _Programa = value; }
        }

        private string _SubPrograma;

        public string SubPrograma
        {
            get { return _SubPrograma; }
            set { _SubPrograma = value; }
        }

        private string _Dependencia;

        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Proyecto;

        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Fecha_Captura;

        public string Fecha_Captura
        {
            get { return _Fecha_Captura; }
            set { _Fecha_Captura = value; }
        }

        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _Ejercicio;

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }


    }
}
