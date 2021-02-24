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
    }
}
