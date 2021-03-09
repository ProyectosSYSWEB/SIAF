using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Consultas
    {
        private string _Centro_Contable;
        private string _Dependencia;
        private string _Partida;
        private string _Fuente;
        private string _Proyecto;
        private string _Codigo_Programatico;
        private string _Capitulo;
        private string _Subcapitulo;
        private string _Mes;
        private string _Autorizado;
        private string _Aumento;
        private string _Disminucion;
        private string _Ejercido;
        private string _Modificado;
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
        public string Codigo_Programatico
        {
            get { return _Codigo_Programatico; }
            set { _Codigo_Programatico = value; }
        }      
        public string Capitulo
        {
            get { return _Capitulo; }
            set { _Capitulo = value; }
        }
        public string Subcapitulo
        {
            get { return _Subcapitulo; }
            set { _Subcapitulo = value; }
        }
        public string Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }      
        public string Autorizado
        {
            get { return _Autorizado; }
            set { _Autorizado = value; }
        }
        public string Aumento
        {
            get { return _Aumento; }
            set { _Aumento = value; }
        }
        public string Disminucion
        {
            get { return _Disminucion; }
            set { _Disminucion = value; }
        }
        public string Ejercido
        {
            get { return _Ejercido; }
            set { _Ejercido = value; }
        }
        public string Modificado
        {
            get { return _Modificado; }
            set { _Modificado = value; }
        }

        private string _Ejercicio;

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

        private string _Ministrado;

        public string Ministrado
        {
            get { return _Ministrado; }
            set { _Ministrado = value; }
        }

        private string _Comprometido;

        public string Comprometido
        {
            get { return _Comprometido; }
            set { _Comprometido = value; }
        }

        private string _Devengado;

        public string Devengado
        {
            get { return _Devengado; }
            set { _Devengado = value; }
        }

        private string _Pagado;

        public string Pagado
        {
            get { return _Pagado; }
            set { _Pagado = value; }
        }




    }
}
