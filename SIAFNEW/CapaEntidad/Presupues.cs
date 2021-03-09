using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Presupues
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Ejercicio;
        public int Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

        private int _Nivel;
        public int Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }

        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Padre;
        public string Padre
        {
            get { return _Padre; }
            set { _Padre = value; }
        }

        private double _Autorizado;
        public double Autorizado
        {
            get { return _Autorizado; }
            set { _Autorizado = value; }
        }

        private double _Modificado;
        public double Modificado
        {
            get { return _Modificado; }
            set { _Modificado = value; }
        }

        private double _Ejercido;
        public double Ejercido
        {
            get { return _Ejercido; }
            set { _Ejercido = value; }
        }

        private int _Avance;
        public int Avance
        {
            get { return _Avance; }
            set { _Avance = value; }
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



    }
}
