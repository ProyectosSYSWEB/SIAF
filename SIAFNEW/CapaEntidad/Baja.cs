using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Baja: Transferencia_Detalle
    {
        private string _Tipo_Baja_Str;
        private int _Tipo_Baja;

        public int Tipo_Baja
        {
            get { return _Tipo_Baja; }
            set { _Tipo_Baja = value; }
        }
        

        public string Tipo_Baja_Str
        {
            get { return _Tipo_Baja_Str; }
            set { _Tipo_Baja_Str = value; }
        }
        

    }
}
