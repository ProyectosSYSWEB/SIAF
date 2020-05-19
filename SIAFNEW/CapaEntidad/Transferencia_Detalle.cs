using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{

    
    public class Transferencia_Detalle: Transferencia
    {
        
        private int _IdTransDet;
        private int _IdInventario;
        private string _Inventario_Numero;        
        //private Poliza_Detalle _poliza_origen = new Poliza_Detalle();
        //private Poliza_Detalle _poliza_destino = new Poliza_Detalle();
        private Bien _bien = new Bien();
        private Bien_Detalle _bien_det = new Bien_Detalle();
        
        public int IdTransDet
        {
            get { return _IdTransDet; }
            set { _IdTransDet = value; }
        }

        public int IdInventario
        {
            get { return _IdInventario; }
            set { _IdInventario = value; }
        }

        public string Inventario_Numero
        {
            get { return _Inventario_Numero; }
            set { _Inventario_Numero = value; }
        }

        //public Poliza_Detalle poliza_origen
        //{

        //    get { return _poliza_origen; }
        //    set { _poliza_origen = value; }
        //}

        //public Poliza_Detalle poliza_destino
        //{

        //    get { return _poliza_destino; }
        //    set { _poliza_destino = value; }
        //}

        public Bien bien
        {

            get { return _bien; }
            set { _bien = value; }
        }

        public Bien_Detalle bien_det
        {

            get { return _bien_det; }
            set { _bien_det = value; }
        }
        
    }
}
