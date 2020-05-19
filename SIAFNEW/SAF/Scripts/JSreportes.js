function Vermovtos_cuentas(Reporte, Ejercicio, centro_contable, cuenta_contable) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_contable=' + cuenta_contable, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerCatalogo_Cuentas(Reporte, Ejercicio, centro_contable, cuenta_mayor) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_mayor=' + cuenta_mayor, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function VerCatalogo_Cuentas_Exel(Reporte, Ejercicio, centro_contable, cuenta_mayor) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_mayor=' + cuenta_mayor, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function Ver_Volante_Transferencia(Reporte, id) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&id=' + id, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function Verdiario_general(Reporte, centro_contable, mes_inicial, mes_final, tipo_p, status, filtro_busca) {
    //     alert("pasaaaaa");
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&centro_contable=' + centro_contable + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&tipo_p=' + tipo_p + '&status=' + status + '&filtro_busca=' + filtro_busca, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function VerPoliza(Reporte, Ejercicio, id) {
    //    alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&id=' + id, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function VerBalanza_de_Comprobacion(Reporte, Ejercicio, centro_contable, mes_inicial, sistema, mes_final, descripcion,desc_mes) {
   // alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&mes_inicial=' + mes_inicial + '&sistema=' + sistema + '&mes_final=' + mes_final + '&descripcion=' + descripcion + '&desc_mes=' + desc_mes, 'toolbar=no', 'location=no', 'menubar=no');
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
function Veranexo_cuentas_balance(Reporte, Ejercicio, centro_contable, cuenta_mayor, mes_inicial, mes_final, nivel) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_mayor=' + cuenta_mayor + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&nivel='+ nivel, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function Vermayor_auxiliar(Reporte, Ejercicio, centro_contable, cuenta_contable, mes_inicial, mes_final) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_contable=' + cuenta_contable + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function Veranexo_cuentas_balance_Exel(Reporte, Ejercicio, centro_contable, cuenta_mayor, mes_inicial, mes_final, nivel) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_mayor=' + cuenta_mayor + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&nivel=' + nivel, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function ver_Ctas_Cmp_Ing_vs_Fond(Reporte, Ejercicio, cuenta_contable, mes_inicial) {    
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&cuenta_contable=' + cuenta_contable + '&mes_inicial=' + mes_inicial, 'toolbar=no', 'location=no', 'menubar=no');
   return false;
}
function Descargar_Cuentas_Por_Revisar(Reporte) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte , 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function ver_concentrado_ingresos(Reporte, Ejercicio, mes_inicial, mes_final) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&Ejercicio=' + Ejercicio, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function ver_concentrado_ingresos_por_centro(Reporte, Ejercicio, mes_inicial, mes_final, centro_contable) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}




function Ver_Volante_Transferencia(Reporte, Ejercicio, centro_contable, Numero_Poliza, Tipo_V) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&Numero_Poliza=' + Numero_Poliza + '&Tipo_V=' + Tipo_V, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}



function Verdiario_polizas_x_lote(Reporte,ejercicio, centro_contable, mes_inicial, mes_final, tipo_p, status) {
    //     alert("pasaaaaa");
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&ejercicio='+ ejercicio +'&centro_contable=' + centro_contable + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&tipo_p=' + tipo_p + '&status=' + status, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}


function ver_diario_general(Reporte, mes_inicial, mes_final, Ejercicio, centro_contable) {
   // alert("pasaaaaa");
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}


function ver_mayor_general(Reporte, Ejercicio, centro_contable) {
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}

function ver_resumen_de_cuetas(Reporte, Ejercicio, centro_contable, cuenta_contable, mes_inicial, mes_final) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_contable=' + cuenta_contable + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function ver_Adecuaciones(Reporte, centro_contable) {
    //alert(centro_contable);
    window.open('Contabilidad/Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&centro_contable=' + centro_contable, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}
function Veranexo_tabular_Exel(Reporte, Ejercicio, centro_contable, cuenta_mayor, mes_inicial, mes_final, nivel) {
    //alert(Ejercicio);
    window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=' + Reporte + '&Ejercicio=' + Ejercicio + '&centro_contable=' + centro_contable + '&cuenta_mayor=' + cuenta_mayor + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final + '&nivel=' + nivel, 'toolbar=no', 'location=no', 'menubar=no');
    return false;
}