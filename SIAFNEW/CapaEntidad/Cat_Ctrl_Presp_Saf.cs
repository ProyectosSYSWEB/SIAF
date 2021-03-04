using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Cat_Ctrl_Presp_Saf
    {        

        private string _Centro_Contable;
        private string _Dependencia;
        private string _Programa;
        private string _SubPrograma;
        private string _Partida; 
        private string _Fuente;
        private string _Proyecto;
        private string _TipoGasto;
        private string _Dig_Ministrado;
        private string _Funcion;

        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }       
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        public string Programa
        {
            get { return _Programa; }
            set { _Programa = value; }
        }
        public string SubPrograma
        {
            get { return _SubPrograma; }
            set { _SubPrograma = value; }
        }
        public string Partida
        {
            get { return _Partida; }
            set { _Partida = value; }
        }
        public string Fuente
        {
            get { return _Fuente; }
            set { _Fuente = value; }
        }
        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }
        public string TipoGasto
        {
            get { return _TipoGasto; }
            set { _TipoGasto = value; }
        }
        public string Dig_Ministrado
        {
            get { return _Dig_Ministrado; }
            set { _Dig_Ministrado = value; }
        }
        public string Funcion
        {
            get { return _Funcion; }
            set { _Funcion = value; }
        }

        private string _Ejercicio;

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }





    }
}
