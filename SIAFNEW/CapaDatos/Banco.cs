using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class BancoBitacora
    {
        public string Id { get; set; }
        public string Banco_nombre { get; set; }
        public string Archivo_nombre { get; set; }
        public string Fecha_pago { get; set; }
        public string Fecha_registro { get; set; }
        public byte[] Archivo_contenido { get; set; }
        public int Total_registros { get; set; }
    }
    public class Banco
    {
        private string nombre;
        private string referencia;
        private Int32 dependencia;
        private string ficha;
        private string folio;

        private string sucursal;
        private string cajero;
        private float pago_importe;
        private string pago_fecha;
        private string pago_hora;

        private string bnt_formato_fecha = "yyyyMMdd";
        private string bnt_formato_hora = "HHmmss";
        private string std_formato_fecha = "ddMMyyyy";
        private string std_formato_hora = "HHmm";
        private string bnx_formato_fecha = "yyMMdd";
        private string bcm_formato_fecha = "yyyy-MM-dd";
        private string bcmm_formato_fecha = "yyyy-MM-dd";
        private string bcmm_formato_hora = "HH:mm:ss";
        private string hsbc_formato_fecha = "yyyyMMdd";
        private string hsbc_formato_hora = "HHmmss";

        private static UInt16 bnt_longitud = 336;
        private static UInt16 std_longitud = 149;
        private static UInt16 bnx_longitud = 120;
        private static UInt16 bcm_longitud = 141;
        private static UInt16 bcmm1_longitud = 185;
        private static UInt16 bcmm2_longitud = 186;
        private static UInt16 hsbc_longitud = 125;

        /*Variables para archivos de caja*/
        private string cuenta;
        private string fechac;
        private string hora;
        private string sucursalc;
        private string descripcion;
        private string signo;
        private string importe;
        private string saldo;
        private string folioc;
        private string concepto;
        private string cargo;
        private string abono;

        public string Cargo
        {
            get { return cargo; }
        }

        public string Abono
        {
            get { return abono; }
        }



        public string Concepto
        {
            get { return concepto; }
        }

        public string Saldo
        {
            get { return saldo; }
        }


        public string Signo
        {
            get { return signo; }
        }

        public string Descripcion
        {
            get { return descripcion; }
        }

        public string Fechac
        {
            get { return fechac; }
        }

        public string Sucursalc
        {
            get { return sucursalc; }
        }

        public string Referencia
        {
            get { return referencia; }
        }

        public string Cuenta
        {
            get { return cuenta; }
        }

        public string Hora
        {
            get { return hora; }
        }

        public Int32 Dependencia
        {
            get { return dependencia; }
        }

        public string Ficha
        {
            get { return ficha; }
        }

        public string Folio
        {
            get { return folio; }
        }

        public string Sucursal
        {
            get { return sucursal == null ? "-" : sucursal; }
        }

        public string Cajero
        {
            get { return cajero == null ? "-" : cajero; }
        }

        public string Importe
        {
            get
            {
                return pago_importe.ToString("0.00");
            }
        }

        public string Fecha
        {
            get
            {
                if (nombre == "BT")
                {
                    if (pago_fecha != null && pago_hora != null)
                    {
                        try { return DateTime.ParseExact($"{pago_fecha} {pago_hora}", $"{bnt_formato_fecha} {bnt_formato_hora}", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm"); }
                        catch { return null; }
                    }
                }
                else if (nombre == "SF")
                {
                    if (pago_fecha != null && pago_hora != null)
                    {
                        try { return DateTime.ParseExact($"{pago_fecha} {pago_hora}", $"{std_formato_fecha} {std_formato_hora}", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm"); }
                        catch { return null; }
                    }
                }
                else if (nombre == "BX")
                {
                    if (pago_fecha != null)
                    {
                        try { return DateTime.ParseExact(pago_fecha, bnx_formato_fecha, System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm"); }
                        catch { return null; }
                    }

                }
                else if (nombre == "BC")
                {
                    if (pago_fecha != null)
                    {
                        try { return DateTime.ParseExact(pago_fecha, bcm_formato_fecha, System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm"); }
                        catch { return null; }
                    }
                }
                else if (nombre == "BC")
                {
                    if (pago_fecha != null && pago_hora != null)
                    {
                        try { return DateTime.ParseExact($"{pago_fecha} {pago_hora}", $"{bcmm_formato_fecha} {bcmm_formato_hora}", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm"); }
                        catch { return null; }
                    }
                }
                else if (nombre == "HS")
                {
                    if (pago_fecha != null && pago_hora != null)
                    {
                        try { return DateTime.ParseExact($"{pago_fecha} {pago_hora}", $"{hsbc_formato_fecha} {hsbc_formato_hora}", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm"); }
                        catch { return null; }
                    }
                }

                return null;
            }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public Byte AgregarDatos(string dato)
        {
            if (bnt_longitud == dato.Length)
            {
                Byte bnt_cabecera = Byte.Parse(dato.Substring(0, 1));

                if (bnt_cabecera == 2)
                {
                    nombre = "BT";
                    referencia = dato.Substring(83, 26).Trim() + nombre;

                    if (referencia.Length == 28)
                    {
                        dependencia = Int32.Parse(referencia.Substring(0, 5));
                        ficha = referencia.Substring(5, 8).TrimStart('0');
                        folio = dato.Substring(1, 21).Trim();
                        sucursal = dato.Substring(237, 4);
                        cajero = "";
                        pago_importe = float.Parse(dato.Substring(26, 14) + "." + dato.Substring(40, 2));
                        pago_fecha = dato.Substring(251, 8);
                        pago_hora = dato.Substring(241, 6);

                        if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                            return 0;

                        return 1;
                    }

                    return 2;
                }

            }
            else if (std_longitud == dato.Length)
            {
                String std_cabecera1 = dato.Substring(32, 3);
                String std_cabecera2 = dato.Substring(32, 12);

                if ((std_cabecera1 == "ABO" || std_cabecera1 == "DEP" || std_cabecera1 == "AB ") && std_cabecera2 != "AB INTERESES")
                {
                    nombre = "SF";
                    referencia = dato.Substring(109, 26).Trim() + nombre;

                    if (referencia.Length == 28)
                    {
                        dependencia = Int32.Parse(referencia.Substring(0, 5));
                        ficha = referencia.Substring(5, 8).TrimStart('0');
                        folio = dato.Substring(98, 11).Trim();
                        sucursal = dato.Substring(28, 4);
                        cajero = "";
                        pago_importe = float.Parse(dato.Substring(73, 12) + "." + dato.Substring(85, 2));
                        pago_fecha = dato.Substring(16, 8);
                        pago_hora = dato.Substring(87, 4);

                        if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                            return 0;

                        return 1;
                    }

                    return 2;
                }
            }
            else if (bnx_longitud == dato.Length)
            {
                Byte bnx_cabecera = Byte.Parse(dato.Substring(0, 1));

                if (bnx_cabecera == 1)
                {
                    nombre = "BX";
                    referencia = dato.Substring(47, 26).Trim() + nombre;

                    if (referencia.Length == 28)
                    {
                        dependencia = Int32.Parse(referencia.Substring(0, 5));
                        ficha = referencia.Substring(5, 8).TrimStart('0');
                        folio = dato.Substring(40, 7).Trim();
                        sucursal = dato.Substring(33, 4);
                        cajero = dato.Substring(37, 2);
                        pago_importe = float.Parse(dato.Substring(7, 13) + "." + dato.Substring(20, 2));
                        pago_fecha = dato.Substring(1, 6);
                        pago_hora = "";

                        if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                            return 0;

                        return 1;
                    }

                    return 2;
                }
            }
            else if (bcm_longitud == dato.Length)
            {
                Char bcm_cabecera1 = Char.Parse(dato.Substring(0, 1));
                String bcm_cabecera2 = dato.Substring(138, 3);

                if (bcm_cabecera1 == '0' && (bcm_cabecera2 == "EFE" || bcm_cabecera2 == "CIS" || bcm_cabecera2 == "CCT" || bcm_cabecera2 == "CBM"))
                {
                    nombre = "BC";
                    referencia = dato.Substring(7, 26).Trim() + nombre;


                    if (referencia.Length == 28)
                    {
                        dependencia = Int32.Parse(referencia.Substring(0, 5));
                        ficha = referencia.Substring(5, 8).TrimStart('0');
                        folio = dato.Substring(108, 6).Trim();
                        sucursal = "";
                        cajero = "";
                        pago_importe = float.Parse(dato.Substring(89, 13) + "." + dato.Substring(93, 2)); ;
                        pago_fecha = dato.Substring(114, 10);
                        pago_hora = "";

                        if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                            return 0;

                        return 1;
                    }

                    return 2;
                }
            }
            else if (bcmm1_longitud == dato.Length)
            {
                nombre = "BC";
                referencia = dato.Substring(66, 26).Trim() + nombre;

                if (referencia.Length == 28)
                {
                    dependencia = Int32.Parse(referencia.Substring(0, 5));
                    ficha = referencia.Substring(5, 8).TrimStart('0');
                    folio = dato.Substring(92, 20).Trim();
                    sucursal = "";
                    cajero = "";
                    pago_importe = float.Parse(dato.Substring(150, 19) + "." + dato.Substring(170, 2));
                    pago_fecha = dato.Substring(172, 10);

                    if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                        return 0;

                    return 1;
                }

                return 2;
            }
            else if (bcmm2_longitud == dato.Length)
            {
                nombre = "BC";
                referencia = dato.Substring(67, 26).Trim() + nombre;

                if (referencia.Length == 28)
                {
                    dependencia = Int32.Parse(referencia.Substring(0, 5));
                    ficha = referencia.Substring(5, 8).TrimStart('0');
                    folio = dato.Substring(93, 20).Trim();
                    sucursal = "";
                    cajero = "";
                    pago_importe = float.Parse(dato.Substring(151, 19) + "." + dato.Substring(171, 2));
                    pago_fecha = dato.Substring(173, 10);
                    //pago_fecha = dato.Substring(172, 10);

                    if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                        return 0;

                    return 1;
                }

                return 2;
            }
            else if (hsbc_longitud == dato.Length)
            {
                nombre = "HS";
                referencia = dato.Substring(70, 26).Trim() + nombre;

                if (referencia.Length == 28)
                {
                    dependencia = Int32.Parse(referencia.Substring(0, 5));
                    ficha = referencia.Substring(5, 8).TrimStart('0');
                    //folio = dato.Substring(60, 5).Trim();
                    folio = dato.Substring(18, 6).Trim();
                    sucursal = dato.Substring(24, 5).Trim();
                    cajero = "";
                    pago_importe = float.Parse(dato.Substring(29, 11) + "." + dato.Substring(40, 2));
                    pago_fecha = dato.Substring(10, 8);
                    pago_hora = dato.Substring(18, 6);

                    if (String.IsNullOrEmpty(referencia + dependencia + ficha + folio + pago_fecha))
                        return 0;

                    return 1;
                }

                return 2;
            }

            return 0;
        }
        public Byte AgregarDatosCaja(string dato)
        {


            String std_cabecera1 = dato.Substring(32, 3);
            String std_cabecera2 = dato.Substring(32, 12);


            //nombre = "SF";
            cuenta = dato.Substring(0, 15);
            fechac = dato.Substring(16, 2) + "/" + dato.Substring(18, 2) + "/" + dato.Substring(20, 4); //dato.Substring(16, 8);
            hora = dato.Substring(24, 2) + ":" + dato.Substring(26, 2); //dato.Substring(24, 4);
            sucursalc = dato.Substring(27, 3);
            descripcion = dato.Substring(32, 40);


            signo = dato.Substring(72, 1);
            if (signo == "+")
            {
                abono = dato.Substring(73, 12) + "." + dato.Substring(85, 2); //dato.Substring(73, 14);
                cargo = "0";
            }
            else
            {
                cargo = dato.Substring(73, 14) + "." + dato.Substring(85, 2); //dato.Substring(73, 14);
                abono = "0";
            }
            referencia = dato.Substring(101, 8); //dato.Substring(99, 8); //quitar ceros a la izquierda
                                                 //referencia = referencia;
            saldo = dato.Substring(87, 14); //quitar ceros a la izquierda
            concepto = dato.Substring(109, 40); //dato.Substring(107, 40);

            if (String.IsNullOrEmpty(cuenta + fechac))
                return 0;

            else
                return 1;



        }

    }
}
