using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Bien
    {

        private int _Id;
        private string _Centro_Contable;
        private string _Dependencia;
        private string _SubDependencia;
        
        private string _Estatus;
        private string _No_Inventario;
        private string _Clave;
        private string _Clave_Anterior;

        private string _Descripcion;
        private string _Codigo_Contable;
        private string _Fecha_Alta_Str;
        private string _Fecha_Alta_Ant_Str;
        private string _Fecha_Contable_Str;
        private string _Fecha_Baja_Str;
        private string _Fecha_Reclasificacion_Str;
        private string _No_Inventario_fin;
        private string _Reclasificado;
        private string _Responsable;
        private bool _Validado;
        private string _Resguardo;
        private string _Clasificacion;

        public string Clasificacion
        {
            get { return _Clasificacion; }
            set { _Clasificacion = value; }
        }

        public string Resguardo
        {
            get { return _Resguardo; }
            set { _Resguardo = value; }
        }

        public bool Validado
        {
            get { return _Validado; }
            set { _Validado = value; }
        }
        public string Responsable
        {
            get { return _Responsable; }
            set { _Responsable = value; }
        }
        public string No_Inventario_fin
        {
            get { return _No_Inventario_fin; }
            set { _No_Inventario_fin = value; }
        }
        public string Reclasificado
        {
            get { return _Reclasificado; }
            set { _Reclasificado = value; }
        }
        
       
        private int _Formulario;
        private Double _Costo;
        private int _Ejercicio;
        private string _Captura_Usuario;

        public string Captura_Usuario
        {
            get { return _Captura_Usuario; }
            set { _Captura_Usuario = value; }
        }
        public int Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }
        public Double Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }
        public int Formulario
        {
            get { return _Formulario; }
            set { _Formulario = value; }
        }
        public string Fecha_Reclasificacion_Str
        {
            get { return _Fecha_Reclasificacion_Str; }
            set { _Fecha_Reclasificacion_Str = value; }
        }
        public string Fecha_Baja_Str
        {
            get { return _Fecha_Baja_Str; }
            set { _Fecha_Baja_Str = value; }
        }
        public string Fecha_Alta_Str
        {
            get { return _Fecha_Alta_Str; }
            set { _Fecha_Alta_Str = value; }
        }
        public string Fecha_Alta_Ant_Str
        {
            get { return _Fecha_Alta_Ant_Str; }
            set { _Fecha_Alta_Ant_Str = value; }
        }
        public string Fecha_Contable_Str
        {
            get { return _Fecha_Contable_Str; }
            set { _Fecha_Contable_Str = value; }
        }
        
        public string Codigo_Contable
        {
            get { return _Codigo_Contable; }
            set { _Codigo_Contable = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        public string Clave_Anterior
        {
            get { return _Clave_Anterior; }
            set { _Clave_Anterior = value; }
        }
        public string No_Inventario
        {
            get { return _No_Inventario; }
            set { _No_Inventario = value; }
        }
        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        public string SubDependencia
        {
            get { return _SubDependencia; }
            set { _SubDependencia = value; }
        }
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Bien()
        {
            Id = 0;
            Centro_Contable = string.Empty;
            Dependencia = string.Empty;
            Estatus = string.Empty;
            No_Inventario = string.Empty;
            Clave = string.Empty;
            Descripcion = string.Empty;
            Codigo_Contable = string.Empty;
            Fecha_Alta_Str = string.Empty;
            Fecha_Baja_Str = string.Empty;
            Formulario =0;
            Costo = 0.0;
        }
    }
    public class Bien_Detalle : Bien
    {
        private int _IdTipo_Alta;
        private string _Inventario_Anterior;
        private string _Inventario_Auxiliar;


        private string _Volante;
        private string _Procedencia;
        private string _Poliza;
        private string _Cedula;
        private string _Partida;
        private string _Centro_Trabajo;
        private int _Cantidad;
        
        private string _Responsable_Nombre;
        private string _Corresponsable;
        private string _Proveedor;
        private string _Factura_Numero;
        private string _Factura_Fecha_Str;
        private string _Observaciones;
        private string _Proyecto;
        private string _Fuente_Financiamiento;
      

        private string  _Caracteristicas;
        private string _Marca;
        private string _Modelo;
        private string _Color;
        private string _No_Serie;

        private string _Inm_Direccion;
        private string _Inm_Ciudad;
        private string _Inm_TipoDoc;
        private string _Inm_NumeroDoc;
        private string _Inm_EstatusDoc;
        private string _Inm_FechaDoc_Str;
        private string _Inm_ExpedicionDoc;
        private string _Inm_NotariaPublica;
        private double  _Inm_AvaluoTerreno;
        private double _Inm_AvaluoEdificio;
        private string _Inm_FechaAvaluo_Str;
        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }


        public double Inm_AvaluoEdificio
	    {
		    get { return _Inm_AvaluoEdificio;}
		    set { _Inm_AvaluoEdificio = value;}
	    }
        public double Inm_AvaluoTerreno
        {
            get { return _Inm_AvaluoTerreno; }
            set { _Inm_AvaluoTerreno = value; }
        }
        public string Inm_NotariaPublica
        {
            get { return _Inm_NotariaPublica; }
            set { _Inm_NotariaPublica = value; }
        }
        public string Inm_ExpedicionDoc
        {
            get { return _Inm_ExpedicionDoc; }
            set { _Inm_ExpedicionDoc = value; }
        }
        public string Inm_FechaDoc_Str
        {
            get { return _Inm_FechaDoc_Str; }
            set { _Inm_FechaDoc_Str = value; }
        }
        public string Inm_EstatusDoc
        {
            get { return _Inm_EstatusDoc; }
            set { _Inm_EstatusDoc = value; }
        }
        public string Inm_NumeroDoc
        {
            get { return _Inm_NumeroDoc; }
            set { _Inm_NumeroDoc = value; }
        }
        public string Inm_TipoDoc
        {
            get { return _Inm_TipoDoc; }
            set { _Inm_TipoDoc = value; }
        }
        public string Inm_Ciudad
        {
            get { return _Inm_Ciudad; }
            set { _Inm_Ciudad = value; }
        }
        public string Inm_Direccion
        {
            get { return _Inm_Direccion; }
            set { _Inm_Direccion = value; }
        }
        public string Inm_FechaAvaluo_Str
        {
            get { return _Inm_FechaAvaluo_Str; }
            set { _Inm_FechaAvaluo_Str = value; }
        }

        
        private string _Veh_Año;
        private string _Veh_NumeroMotor;
        private string _Veh_NumeroPlacas;
        private string _Veh_Tenencia;
        private string _Veh_PolizaSeguro;
        private string _Veh_FechaVencimiento_Str;
        
        private string _Tic_SO;
        private string _Tic_Accesorios;
        private string _Tic_Procesador;
        private string _Tic_RAM;
        private string _Tic_DiscoDuro;
        private string _Tic_Disquete;
        private string _Tic_UnidadOptica;

        private string _Sem_Id_Etapa;
        private string _Sem_Id_Especie;
        private string _Sem_Etapa;
        private string _Sem_Especie;
        private string _Sem_FechaEtapa_Str;
        private string  _Sem_FechaParto_Str;
        private string _Sem_Id_Semental;
        private string _Sem_Metodo;
        private string _Sem_CriasH;
        private string _Sem_CriasM;
        private string _Sem_Id_Padre;
        private string  _Sem_Id_Madre;
        private string _Sem_Vellon;
        private string _Sem_Calidad;
        private string _Sem_FechaTrasquila_Str;
        private string _Sem_Epoca;
        private string _Sem_Grupo;

        private string _Sem_Raza;
        private string _Sem_Arete;
        private string _Sem_Edad;
        private string _Sem_Edad_Anios;
        private string _Sem_FechaNac_Str;
        private string _Sem_Sexo;
        private string _Sem_Peso;
        private string _Sem_FechaRevalorizado_Str;
        private double _Sem_CostoRevalorizado;
        
        private string _Int_TipoSoftware;
        private string _Int_Patente;
        private string _Int_DerechoAutor;
        private string _Int_CaducidadLicencia;
        private string _Int_Usuarios;
        private string _Int_Version;
        private string _Int_Idioma;

        
        private string _Col_Titulo;
        private string _Col_Autor;
        private string _Col_Editorial;
        private string _Col_Edicion;
        private string _Col_Tomos;
        private string _Col_ISBN;

        public string Col_ISBN
        {
            get { return _Col_ISBN; }
            set { _Col_ISBN = value; }
        }
        public string Col_Tomos
        {
            get { return _Col_Tomos; }
            set { _Col_Tomos = value; }
        }
        public string Col_Edicion
        {
            get { return _Col_Edicion; }
            set { _Col_Edicion = value; }
        }
        public string Col_Editorial
        {
            get { return _Col_Editorial; }
            set { _Col_Editorial = value; }
        }
        public string Col_Autor
        {
            get { return _Col_Autor; }
            set { _Col_Autor = value; }
        }
        public string  Col_Titulo
        {
            get { return _Col_Titulo; }
            set { _Col_Titulo = value; }
        }
        
        
        public string Int_Idioma
        {
            get { return _Int_Idioma; }
            set { _Int_Idioma = value; }
        }
        public string Int_Version
        {
            get { return _Int_Version; }
            set { _Int_Version = value; }
        }
        public string Int_Usuarios
        {
            get { return _Int_Usuarios; }
            set { _Int_Usuarios = value; }
        }
        public string Int_CaducidadLicencia
        {
            get { return _Int_CaducidadLicencia; }
            set { _Int_CaducidadLicencia = value; }
        }
        public string Int_DerechoAutor
        {
            get { return _Int_DerechoAutor; }
            set { _Int_DerechoAutor = value; }
        }
        public string Int_Patente
        {
            get { return _Int_Patente; }
            set { _Int_Patente = value; }
        }
        public string Int_TipoSoftware
        {
            get { return _Int_TipoSoftware; }
            set { _Int_TipoSoftware = value; }
        }
        
        public double Sem_CostoRevalorizado
        {
            get { return _Sem_CostoRevalorizado; }
            set { _Sem_CostoRevalorizado = value; }
        }
        public string Sem_FechaRevalorizado_Str
        {
            get { return _Sem_FechaRevalorizado_Str; }
            set { _Sem_FechaRevalorizado_Str = value; }
        }
        public string Sem_Arete
        {
            get { return _Sem_Arete; }
            set { _Sem_Arete = value; }
        }
        public string Sem_Edad
        {
            get { return _Sem_Edad; }
            set { _Sem_Edad = value; }
        }
        public string Sem_Edad_Anios
        {
            get { return _Sem_Edad_Anios; }
            set { _Sem_Edad_Anios = value; }
        }
        public string Sem_Peso
        {
            get { return _Sem_Peso; }
            set { _Sem_Peso = value; }
        }
        public string Sem_Sexo
        {
            get { return _Sem_Sexo; }
            set { _Sem_Sexo = value; }
        }
        public string Sem_FechaNac_Str
        {
            get { return _Sem_FechaNac_Str; }
            set { _Sem_FechaNac_Str = value; }
        }
        public string Sem_Raza
        {
            get { return _Sem_Raza; }
            set { _Sem_Raza = value; }
        }
        public string Sem_Especie
        {
            get { return _Sem_Especie; }
            set { _Sem_Especie = value; }
        }
        public string Sem_Etapa
        {
            get { return _Sem_Etapa; }
            set { _Sem_Etapa = value; }
        }
        public string Sem_Id_Especie
        {
            get { return _Sem_Id_Especie; }
            set { _Sem_Id_Especie = value; }
        }
        public string Sem_Id_Etapa
        {
            get { return _Sem_Id_Etapa; }
            set { _Sem_Id_Etapa = value; }
        }
        public string Sem_Id_Madre
        {
            get { return _Sem_Id_Madre; }
            set { _Sem_Id_Madre = value; }
        }
        public string Sem_Id_Padre
        {
            get { return _Sem_Id_Padre; }
            set { _Sem_Id_Padre = value; }
        }
        public string Sem_CriasM
        {
            get { return _Sem_CriasM; }
            set { _Sem_CriasM = value; }
        }
        public string Sem_CriasH
        {
            get { return _Sem_CriasH; }
            set { _Sem_CriasH = value; }
        }
        public string Sem_Metodo
        {
            get { return _Sem_Metodo; }
            set { _Sem_Metodo = value; }
        }
        public string Sem_Id_Semental
        {
            get { return _Sem_Id_Semental; }
            set { _Sem_Id_Semental = value; }
        }
        public string Sem_FechaParto_Str
        {
            get { return _Sem_FechaParto_Str; }
            set { _Sem_FechaParto_Str = value; }
        }
        public string Sem_FechaEtapa_Str
        {
            get { return _Sem_FechaEtapa_Str; }
            set { _Sem_FechaEtapa_Str = value; }
        }
                public string Sem_Grupo
        {
            get { return _Sem_Grupo; }
            set { _Sem_Grupo = value; }
        }
        public string Sem_Epoca
        {
            get { return _Sem_Epoca; }
            set { _Sem_Epoca = value; }
        }
        public string Sem_FechaTrasquila_Str
        {
            get { return _Sem_FechaTrasquila_Str; }
            set { _Sem_FechaTrasquila_Str = value; }
        }
        public string Sem_Calidad
        {
            get { return _Sem_Calidad; }
            set { _Sem_Calidad = value; }
        }
        public string Sem_Vellon
        {
            get { return _Sem_Vellon; }
            set { _Sem_Vellon = value; }
        }
        public string Tic_UnidadOptica
        {
            get { return _Tic_UnidadOptica; }
            set { _Tic_UnidadOptica = value; }
        }
        public string Tic_Disquete
        {
            get { return _Tic_Disquete; }
            set { _Tic_Disquete = value; }
        }
        public string Tic_DiscoDuro
        {
            get { return _Tic_DiscoDuro; }
            set { _Tic_DiscoDuro = value; }
        }
        public string Tic_RAM
        {
            get { return _Tic_RAM; }
            set { _Tic_RAM = value; }
        }
        public string Tic_Procesador
        {
            get { return _Tic_Procesador; }
            set { _Tic_Procesador = value; }
        }
        public string Tic_Accesorios
        {
            get { return _Tic_Accesorios; }
            set { _Tic_Accesorios = value; }
        }
        public string Tic_SO
        {
            get { return _Tic_SO; }
            set { _Tic_SO = value; }
        }

        public string Veh_FechaVencimiento_Str
        {
            get { return _Veh_FechaVencimiento_Str; }
            set { _Veh_FechaVencimiento_Str = value; }
        }
        public string Veh_PolizaSeguro
        {
            get { return _Veh_PolizaSeguro; }
            set { _Veh_PolizaSeguro = value; }
        }
        public string  Veh_Tenencia
        {
            get { return _Veh_Tenencia; }
            set { _Veh_Tenencia = value; }
        }
        public string Veh_NumeroPlacas
        {
            get { return _Veh_NumeroPlacas; }
            set { _Veh_NumeroPlacas = value; }
        }
        public string Veh_NumeroMotor
        {
            get { return _Veh_NumeroMotor; }
            set { _Veh_NumeroMotor = value; }
        }
        public string Veh_Año
        {
            get { return _Veh_Año; }
            set { _Veh_Año = value; }
        }
        
        public string No_Serie
        {
            get { return _No_Serie; }
            set { _No_Serie = value; }
        }
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public string  Caracteristicas
        {
            get { return _Caracteristicas; }
            set { _Caracteristicas = value; }
        }


        public string Fuente_Financiamiento
        {
            get { return _Fuente_Financiamiento; }
            set { _Fuente_Financiamiento = value; }
        }

        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        public string Factura_Fecha_Str
        {
            get { return _Factura_Fecha_Str; }
            set { _Factura_Fecha_Str = value; }
        }
        public string Factura_Numero
        {
            get { return _Factura_Numero; }
            set { _Factura_Numero = value; }
        }
        public string Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }
        public string Corresponsable
        {
            get { return _Corresponsable; }
            set { _Corresponsable = value; }
        }

        public string Responsable_Nombre
        {
            get { return _Responsable_Nombre; }
            set { _Responsable_Nombre = value; }
        }
        
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public string Partida
        {
            get { return _Partida; }
            set { _Partida = value; }
        }
        public string Centro_Trabajo
        {
            get { return _Centro_Trabajo; }
            set { _Centro_Trabajo = value; }
        }
        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }
        public string Poliza
        {
            get { return _Poliza; }
            set { _Poliza = value; }
        }
        public string Procedencia
        {
            get { return _Procedencia; }
            set { _Procedencia = value; }
        }
        public string Volante
        {
            get { return _Volante; }
            set { _Volante = value; }
        }
        public string Inventario_Auxiliar
        {
            get { return _Inventario_Auxiliar; }
            set { _Inventario_Auxiliar = value; }
        }

        public string Inventario_Anterior
        {
            get { return _Inventario_Anterior; }
            set { _Inventario_Anterior = value; }
        }
        public int IdTipo_Alta
        {
            get { return _IdTipo_Alta; }
            set { _IdTipo_Alta = value; }
        }

        //Constructor
        //public Bien_Detalle()
        //{
        //    IdTipo_Alta = 0;
        //    Inventario_Anterior = string.Empty;
        //    Volante = string.Empty;
        //    Procedencia = string.Empty;
        //    Poliza = string.Empty;
        //    Cedula = string.Empty;
        //    Centro_Trabajo = string.Empty;
        //    Cantidad = 0;
        //    Responsable = string.Empty;
        //    Corresponsable = string.Empty;
        //    Proveedor = string.Empty;
        //    Factura_Numero = string.Empty;
        //    Factura_Fecha_Str = string.Empty;
        //    Observaciones = string.Empty;


        //    Caracteristicas = string.Empty;
        //    Marca = string.Empty;
        //    Modelo = string.Empty;
        //    Color = string.Empty;
        //    No_Serie = string.Empty;

        //    Inm_Direccion = string.Empty;
        //    Inm_Ciudad = string.Empty;
        //    Inm_TipoDoc = string.Empty;
        //    Inm_NumeroDoc = string.Empty;
        //    Inm_EstatusDoc = string.Empty;
        //    Inm_FechaDoc_Str = string.Empty;
        //    Inm_ExpedicionDoc = string.Empty;
        //    Inm_NotariaPublica = string.Empty;
        //    Inm_AvaluoTerreno=0.0;
        //    Inm_AvaluoEdificio=0.0;
        //    Inm_FechaAvaluo_Str = string.Empty;


        //}
    }

}
