using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public  class Pres_Reportes
    {
        private string  _Id;
        public string _Dependencia;
        public string _Fuente;
        public string _Descripcion;
        public string _Tipo;
        public string _Capitulo;
        public string _Ejercicio;
        private string _Proyecto;
        private string _DependenciaF;
        private string _Subprograma;


        public string SubPrograma
        {
            get { return _Subprograma; }
            set { _Subprograma = value; }
        }
        public string DependenciaF
        {
            get { return _DependenciaF; }
            set { _DependenciaF = value; }
        }

        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }
        public string Capitulo
        {
            get { return _Capitulo; }
            set { _Capitulo = value; }
        }
        public string Tipo
        {
            get { return _Tipo; }
            set { _Descripcion = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public  string Fuente
        {
            get { return _Fuente; }
            set { _Fuente = value; }
        }


        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
    }
}
