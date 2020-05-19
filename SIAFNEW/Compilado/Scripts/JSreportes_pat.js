
//Reportes Mario

            function VerBasicos(Reporte, tipo_p, status, descripcion, catalogo) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&tipo_p=' + tipo_p + '&status=' + status + '&descripcion=' + descripcion + '&catalogo=' + catalogo, 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }
            function VerCentros_Trabajo(Reporte, centro_contable, status, descripcion, catalogo) {
                //alert("hola");
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&centro_contable=' + centro_contable + '&status=' + status + '&descripcion=' + descripcion + '&catalogo=' + catalogo, 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }
//Reportes rubicel

            function Verdiario_analitico_bienes(Reporte, centro_contable, mes_inicial, mes_final) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&centro_contable=' + centro_contable + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final , 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }
            function Veracumulado_de_activos_bajas(Reporte, mes_inicial, mes_final, clave, status) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&mes_inicial=' + mes_inicial + '&mes_final=' + mes_final +'&clave='+ clave +'&status='+status, 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }

            function ver_reporte_bienes_con_sin_responsable(Reporte, responsable, status, dependencia) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&responsable=' + responsable + '&status=' + status + '&dependencia=' + dependencia, 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }
            function ver_reporte_para_inventario(Reporte, tipo_v, dependencia, fecha_periodo) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&tipo_v=' + tipo_v + '&dependencia=' + dependencia + '&fecha_periodo=' + fecha_periodo , 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }
            function VERBURO(Reporte) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte , 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }
            //Reportes Carlos
            function Ver_Baja(Reporte, Id) {
                window.open('../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=' + Reporte + '&Id=' + Id, 'toolbar=no', 'location=no', 'menubar=no');
                return false;
            }