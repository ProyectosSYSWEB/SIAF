using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Funcion
    {
        private string _Funcion;

        public string funcion
        {
            get { return _Funcion; }
            set { _Funcion = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
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

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Valor;

        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        private string _Orden;

        public string Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }




    }
}
