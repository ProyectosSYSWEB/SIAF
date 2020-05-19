using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{

    public class Basicos
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

                private string _tipo;
        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _clave;
        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _valor;
        public string valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private string _orden;
        public string orden
        {
            get { return _orden; }
            set { _orden = value; }
        }

    }
}
