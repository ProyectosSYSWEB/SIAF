using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class CentrosContab
    {
        private string _C_Contab;

        public string C_Contab
        {
            get { return _C_Contab; }
            set { _C_Contab = value; }
        }

        private string _Descrip;

        public string Descrip
        {
            get { return _Descrip; }
            set { _Descrip = value; }
        }

        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
