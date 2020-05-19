function Vermovtos_cuentas(Reporte, Ejercicio, centro_contable, cuenta_contable) {
    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_contable=' + cuenta_contable, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerCatalogo_Cuentas(Reporte, Ejercicio, centro_contable, cuenta_mayor) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_mayor=' + cuenta_mayor, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function Verdiario_general(Reporte, centro_contable, mes_inicial, mes_final, tipo_p, status) {
    //     alert("pasaaaaa");
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&centro_contable=' + centro_contable + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&tipo_p=' + tipo_p + '&status=' + status, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function VerPoliza(Reporte, Ejercicio, id) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&id=' + id, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerBalanza_de_Comprobacion(Reporte, Ejercicio, centro_contable, mes_inicial, sistema, mes_final, descripcion) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&mes_inicial=' + mes_inicial + '&sistema=' + sistema + '&mes_final=' + mes_final + '&descripcion=' + descripcion, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerSituacion_financiera_o_resultado(Reporte, Ejercicio, nivel, mes_inicial) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&nivel=' + nivel + '&mes_inicial=' + mes_inicial, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerEstado_analitico(Reporte, Ejercicio, cierre, nivel, mayor) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&cierre=' + cierre + '&nivel=' + nivel + '&mayor=' + mayor, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function VerEstado_flujo_efectivo(Reporte, Ejercicio, cierre, nivel) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&cierre=' + cierre + '&nivel=' + nivel, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}