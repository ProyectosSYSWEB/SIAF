using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Programa
    {
        private string _Funcion;

        public string Funcion
        {
            get { return _Funcion; }
            set { _Funcion = value; }
        }

        private string _Funfed;

        public string Funfed
        {
            get { return _Funfed; }
            set { _Funfed = value; }
        }

        private string _F_Prog;

        public string F_Prog
        {
            get { return _F_Prog; }
            set { _F_Prog = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


    }
}
