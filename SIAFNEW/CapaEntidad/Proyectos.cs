﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Proyectos
    {
        private string _Tipo_Proy;

        public string Tipo_Proy
        {
            get { return _Tipo_Proy; }
            set { _Tipo_Proy = value; }
        }

        private string _Proyecto;

        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }

        private string _Proy_Poa;

        public string Proy_Poa
        {
            get { return _Proy_Poa; }
            set { _Proy_Poa = value; }
        }

        private string _Descrip;

        public string Descrip
        {
            get { return _Descrip; }
            set { _Descrip = value; }
        }

        private string _Importe;

        public string Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }


    }
}
