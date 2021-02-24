using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class PresupUnv
    {
        private string _Codigo_Programatico;

        public string Codigo_Programatico
        {
            get { return _Codigo_Programatico; }
            set { _Codigo_Programatico = value; }
        }

        private string _Centro_Contable;

        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }

        private string _Dependencia;

        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Programa;
                
        public string Programa
        {
            get { return _Programa; }
            set { _Programa = value; }
        }

        private string _Subprograma;

        public string Subprograma
        {
            get { return _Subprograma; }
            set { _Subprograma = value; }
        }

        private string _Partida;

        public string Partida
        {
            get { return _Partida; }
            set { _Partida = value; }
        }

        private string _Fuente;

        public string Fuente
        {
            get { return _Fuente; }
            set { _Fuente = value; }
        }

        private string _Proyecto;

        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }

        private string _Tipo_Gasto;

        public string Tipo_Gasto
        {
            get { return _Tipo_Gasto; }
            set { _Tipo_Gasto = value; }
        }

        private string _Dig_Ministrado;

        public string Dig_Ministrado
        {
            get { return _Dig_Ministrado; }
            set { _Dig_Ministrado = value; }
        }

        private string _Funcion;

        public string Funcion
        {
            get { return _Funcion; }
            set { _Funcion = value; }
        }

        private string _Referencia_Documento;

        public string Referencia_Documento
        {
            get { return _Referencia_Documento; }
            set { _Referencia_Documento = value; }
        }

        private string _Concepto;

        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }
}
