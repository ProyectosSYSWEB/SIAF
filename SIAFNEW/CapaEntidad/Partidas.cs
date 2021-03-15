using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Partidas
    {
        private string _Tipo_Eje;

        public string Tipo_Eje
        {
            get { return _Tipo_Eje; }
            set { _Tipo_Eje = value; }
        }

        private string _Tipo_Cal;

        public string Tipo_Cal
        {
            get { return _Tipo_Cal; }
            set { _Tipo_Cal = value; }
        }

        private string _Partida;

        public string Partida
        {
            get { return _Partida; }
            set { _Partida = value; }
        }

        private string _FF;

        public string FF
        {
            get { return _FF; }
            set { _FF = value; }
        }

        private string _Estatus;

        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private string _Descrip;

        public string Descrip
        {
            get { return _Descrip; }
            set { _Descrip = value; }
        }

        private int _Descrip2;

        public int Descrip2
        {
            get { return _Descrip2; }
            set { _Descrip2 = value; }
        }

        private string _Ejercicio;

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }


        private string _Concepto;

        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private string _SubCapt;

        public string SubCapt
        {
            get { return _SubCapt; }
            set { _SubCapt = value; }
        }

    }
}
