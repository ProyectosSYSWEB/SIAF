using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Transferencia
    {
        private int _IdTransferencia;
        private int _Dias_Transcurridos;
        private string _Folio;
        private string _Fecha_Transferencia;
        private string _Fecha_Movimiento;
        private string _Origen_Dependencia;
        private string _Destino_Dependencia;
        private string _Status;
        private string _Usuario_Transferencia;
        private string _Usuario_Movimiento;
        private string _Observaciones;
        private bool _ImgVerde;
        private bool _ImgRojo;
        private string _StatusMovto;
        private bool _Editable;
        private string _ColorLink;
        private int _Poliza_Baja;
        private int _Poliza_Alta;
        private Boolean _Imprimir_Poliza_Baja;
        private bool _Imprimir_Poliza_Alta;

        public bool Imprimir_Poliza_Alta
        {
            get { return _Imprimir_Poliza_Alta; }
            set { _Imprimir_Poliza_Alta = value; }
        }


        public int Poliza_Alta
        {
            get { return _Poliza_Alta; }
            set { _Poliza_Alta = value; }
        }

       


        public Boolean Imprimir_Poliza_Baja
        {
            get { return _Imprimir_Poliza_Baja; }
            set { _Imprimir_Poliza_Baja = value; }
        }

        public int Poliza_Baja
        {
            get { return _Poliza_Baja; }
            set { _Poliza_Baja = value; }
        }

        public string ColorLink
        {
            get { return _ColorLink; }
            set { _ColorLink = value; }
        }

        public bool Editable
        {
            get { return _Editable; }
            set { _Editable = value; }
        }

        public int IdTransferencia
        {
            get { return _IdTransferencia; }
            set { _IdTransferencia = value; }
        }

        public int Dias_Transcurridos
        {
            get { return _Dias_Transcurridos; }
            set { _Dias_Transcurridos = value; }
        }

        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        public string Fecha_Transferencia
        {
            get { return _Fecha_Transferencia; }
            set { _Fecha_Transferencia = value; }
        }

        public string Fecha_Movimiento
        {
            get { return _Fecha_Movimiento; }
            set { _Fecha_Movimiento = value; }
        }

        public string Origen_Dependencia
        {
            get { return _Origen_Dependencia; }
            set { _Origen_Dependencia = value; }
        }

        public string Destino_Dependencia
        {
            get { return _Destino_Dependencia; }
            set { _Destino_Dependencia = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string Usuario_Transferencia
        {
            get { return _Usuario_Transferencia; }
            set { _Usuario_Transferencia = value; }
        }

        public string Usuario_Movimiento
        {
            get { return _Usuario_Movimiento; }
            set { _Usuario_Movimiento = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public bool ImgVerde
        {
            get { return _ImgVerde; }
            set { _ImgVerde = value; }
        }

        public bool ImgRojo
        {
            get { return _ImgRojo; }
            set { _ImgRojo = value; }
        }

        public string StatusMovto
        {
            get { return _StatusMovto; }
            set { _StatusMovto = value; }
        }
        
    }
}
