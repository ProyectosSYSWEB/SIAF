//Creado por: ISC. Melissa Alejandra Rodríguez González
//Correo: melissa.rodriguez@unach.mx"
function VerReporteExportarConceptos(Opc, UR, FInicial, FFinal, Conceptos, Ejercicio, Mes, ciclo, TipoDesc, Status) {
    //alert(TipoDesc);
    window.open('Reportes/VisualizadorCrystal.aspx?Tipo=' + Opc + '&CDet=' + UR + '&FInicial=' + FInicial + '&FFinal=' + FFinal + '&IdConcepto=' + Conceptos + '&Ejercicio=' + Ejercicio + '&Mes=' + Mes + '&ciclo=' + ciclo + '&TipoDesc=' + TipoDesc + '&Status=' + Status, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
  return false;
}

function OpenPage(url) {
    //window.open(url, 'Contenedor','width=100%,height=100%'); //return false;
    window.frames[0].location = url;
}

function Resaltar_On(GridView) {
    if (GridView != null) {
        GridView.originalBgColor = GridView.style.backgroundColor;
        GridView.style.backgroundColor = "#DBE7F6";
    }
}

function Resaltar_Off(GridView) {
    if (GridView != null) {
        GridView.style.backgroundColor = GridView.originalBgColor;
    }
}

function VerReporte(idFact) {
    window.open('Reportes/VisualizadorCrystal.aspx?idFact=' + idFact, 'miniContenedor', 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerReporteRecibo(idFact) {
    window.open('../Reportes/VisualizadorCrystal.aspx?idFact=' + idFact, 'miniContenedor', 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerReporteExportar(Opc, UR, FInicial, FFinal) {
    window.open('Reportes/VisualizadorCrystal.aspx?Tipo=' + Opc + '&CDet=' + UR + '&FInicial=' + FInicial + '&FFinal=' + FFinal, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
    return false;
}

function VerReporteEvento(Opc, Evento) {
    window.open('Reportes/VisualizadorCrystal.aspx?Tipo=' + Opc + '&Evento=' + Evento, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
    return false;
}
function VerReporteAlumnos(UR, Nivel) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=REPA01&CDet=' + UR + '&Nivel=' + Nivel, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
    return false;
}
function VerReporteAlumnosExcel(UR, Nivel) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=REPA02&CDet=' + UR + '&Nivel=' + Nivel, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
    return false;
}
function VerReporteExentos(ciclo, UR, status) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=REPA03&Ciclo=' + ciclo + '&CDet=' + UR + '&status=' + status, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
    return false;
}
function VerReporteExentos_Excel(ciclo, UR, status) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=REPA04&Ciclo=' + ciclo + '&CDet=' + UR + '&status=' + status, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=no');
    return false;
}
function LimpiarCampos() {
    return confirm('Hello!');
}

function VerReporteFactura(Ejercicio, Dependencia, Status) {
    //alert('PASA');
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=REP017&Ejercicio=' + Ejercicio + '&Dependencia=' + Dependencia + '&Status=' + Status, 'miniContenedor', 'toolbar=no', 'location=no', 'menubar=no');    
    return false;

}