var isIE = document.all?true:false;
var isNS = document.layers?true:false;

openWins = new Array();
function CierraVentana() 
{
	for(i=0; i<openWins.length; i++)
		if (openWins[i] && !openWins[i].closed) 
			openWins[i].close();
	openWins=new Array();
}

/*function closeAll(MyWindow) 
{
	try
	{
		if(MyWindow.opener==null)
			MyWindow.CierraVentana();
		else
			closeAll(MyWindow.opener);
	}
	catch(e)
	{
		MyWindow.CierraVentana();
	}
}*/
function AgregarArreglo(MyWindow,MyOpenWins)
{	
    MyOpenWins.focus();
	MyWindow.openWins[MyWindow.openWins.length]=MyOpenWins;
	/*try
	{
		if(MyWindow.opener==null)
			MyWindow.openWins[MyWindow.openWins.length]=MyOpenWins;
		else
			AgregarArreglo(MyWindow.opener,MyOpenWins);
	}
	catch(e)
	{
		MyWindow.openWins[MyWindow.openWins.length]=MyOpenWins;
	}*/	
}

function AgregarRefrescado(MyWindow,MyOpenWins)
{	
	try
	{
		if(MyWindow.opener==null)
		{
		    MyOpenWins.focus();
			MyWindow.openWins[MyWindow.openWins.length]=MyOpenWins;
	    }
		else
			AgregarArreglo(MyWindow.opener,MyOpenWins);
	}
	catch(e)
	{
	    MyOpenWins.focus();
		MyWindow.openWins[MyWindow.openWins.length]=MyOpenWins;
	}	
}

function CerrarVentana()
{
	window.close();
}
function VerificaValoresSistema()
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{		
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItem|')!=-1)
		{		
			var arr = document.getElementsByTagName("input").item(i).name.split("|"); 
			if(arr[2].length<36)
				document.getElementsByTagName("input").item(i).disabled=true;
		}
	}
}
function SeleccionaUnCheck(chkItemSel)
{
	if(chkItemSel.checked==true)
	{
		for(i=0;i<document.getElementsByTagName("input").length;i++)
		{		
			if(document.getElementsByTagName("input").item(i).name.indexOf('chkItem|')!=-1)
			{		
				if(document.getElementsByTagName("input").item(i).id!=chkItemSel.id)
					document.getElementsByTagName("input").item(i).checked=false;
			}
		}
	}
}

function CheckItemTodos(chkTodos,GUIDModulo)
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItem|'+GUIDModulo)!=-1)
			if(document.getElementsByTagName("input").item(i).disabled==false)
				document.getElementsByTagName("input").item(i).checked=chkTodos.checked;
}
function CheckItemTodosDif(chkTodos,GUIDModulo)
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItemDif|'+GUIDModulo)!=-1)
			if(document.getElementsByTagName("input").item(i).disabled==false)
				document.getElementsByTagName("input").item(i).checked=chkTodos.checked;
}
function CheckItemTodosDif2(chkTodos,GUIDModulo)
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItemDif2|'+GUIDModulo)!=-1)
			if(document.getElementsByTagName("input").item(i).disabled==false)
				document.getElementsByTagName("input").item(i).checked=chkTodos.checked;
}
function Colores(ControlRegreso,Color)
{
	var hexa=0;
	
	if(Color.indexOf('#')!=-1)
	{	
		Color=Color.substring(1,Color.length);
		hexa=1;
	}
	var Ruta="Functions/Colores.aspx?strControl="+ControlRegreso+"&Color="+Color+"&Hexa="+hexa;
	var size = new SizeWindow('145','310');
		AgregarArreglo(window, window.open(Ruta, windowName="", 'width=145, height=310, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function Calendario(Control,Fecha)
{		var date = new Date();
	if (Fecha==''){
		if(document.getElementById(Control).value==''){
			Fecha = date.getDate()+'/'+(date.getMonth()+1)+'/'+date.getYear();
			document.getElementById(Control).value	= Fecha;
		}else{
			Fecha = document.getElementById(Control).value;
		}
	}
	var size = new SizeWindow('250','250');	
	AgregarArreglo(window, window.open("Functions/Calendario.aspx?strControl="+Control+"&strFecha="+Fecha, windowName='', 'width=250, height=250, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function CalendarioHora(Control,Fecha)
{	
	var size = new SizeWindow('250','250');	
	AgregarArreglo(window, window.open("Functions/CalendarioHora.aspx?strControl="+Control+"&strFecha="+Fecha, windowName='', 'width=250, height=250, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function CalendarioRango(Control,Fecha,Formato,FechaInicial,FechaFinal)
{
	var size = new SizeWindow('250','250');	
	AgregarArreglo(window, window.open("Functions/Calendario.aspx?strControl="+Control+"&strFecha="+Fecha+"&strFormato="+Formato+"&strInicial="+FechaInicial+"&strFinal="+FechaFinal, windowName='', 'width=250, height=250, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function CalendarioHoraRango(Control,Fecha,Formato,FechaInicial,FechaFinal)
{
	var size = new SizeWindow('250','250');	
	AgregarArreglo(window, window.open("Functions/CalendarioHora.aspx?strControl="+Control+"&strFecha="+Fecha+"&strFormato="+Formato+"&strInicial="+FechaInicial+"&strFinal="+FechaFinal, windowName='', 'width=250, height=250, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function Departamento(strControl,strGUIDControl,strDepartamentos,intOpcion)
{
    var size = new SizeWindow('300','350');	
	var Ruta="Functions/VerDepartamento.aspx?strControl="+strControl+"&strGUIDControl="+strGUIDControl+"&strDepartamentos="+strDepartamentos+"&intOpcion="+intOpcion;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=300, height=350, location=no, menubar=no, status=no, toolbar=no, scrollbars=yes, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function Modulo(strControl,strGUIDControl,strModulos,intOpcion,strNombreEtiqueta)
{
    var size = new SizeWindow('300','350');	
	var Ruta="Functions/VerModulo.aspx?strControl="+strControl+"&strGUIDControl="+strGUIDControl+"&strModulos="+strModulos+"&intOpcion="+intOpcion+"&strNombreEtiqueta="+strNombreEtiqueta;
    AgregarArreglo(window, window.open(Ruta, windowName="", 'width=300, height=350, location=no, menubar=no, status=no, toolbar=no, scrollbars=yes, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function AbreVentana(strURL,width,height,location,menubar,status,toolbar,scrollbars,resizable)
{
	var size = new SizeWindow(width,height);	
	AgregarArreglo(window, window.open(strURL, windowName="", 'width='+width+', height='+height+', location='+location+', menubar='+menubar+', status='+status+', toolbar='+toolbar+', scrollbars='+scrollbars+', resizable='+scrollbars+',top=' + size.topPos + ',left=' + size.leftPos));
}
function DepartamentoCampo(strControl,strGUIDControl,strDepartamentos,intOpcion,strGUIDInicio)
{
    var size = new SizeWindow('300','350');	
	var Ruta="Functions/VerDepartamento.aspx?strControl="+strControl+"&strGUIDControl="+strGUIDControl+"&strDepartamentos="+strDepartamentos+"&intOpcion="+intOpcion+"&strGUIDInicio="+strGUIDInicio;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=300, height=350, location=no, menubar=no, status=no, toolbar=no, scrollbars=yes, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
	
	/*
	if (isIE){ //IE
      var w=showModelessDialog(Ruta, "", "...");
    }
    else { //other browsers
      var w=window.open(Ruta, "newWin", "modal=1, width=500, height=400");
      w.focus();
    }
    */
    
}
function DepartamentoCampoLista(strControl,strGUIDControl,strDepartamentos,intOpcion,strGUIDModuloElemento,strGUIDCampo)
{
    var size = new SizeWindow('300','350');	
	var Ruta="Functions/VerDepartamento.aspx?strControl="+strControl+"&strGUIDControl="+strGUIDControl+"&strDepartamentos="+strDepartamentos+"&intOpcion="+intOpcion+"&strGUIDModuloElemento="+strGUIDModuloElemento+"&strGUIDCampo="+strGUIDCampo;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=300, height=350, location=no, menubar=no, status=no, toolbar=no, scrollbars=yes, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));

	/*
	if (isIE){ //IE
      var w=showModelessDialog(Ruta, "", "...");
    }
    else { //other browsers
      var w=window.open(Ruta, "newWin", "modal=1, width=500, height=400");
      w.focus();
    }
    */
}
function Buscar(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarCP(RutaBusqueda,RutaPadre,IDPais,ctrIDEstado,ctrEstado,ctrIDMunicipio,ctrMunicipio,ctrColonia,ctrCP,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&ctrIDEstado="+ctrIDEstado+"&IDPais="+IDPais+"&ctrEstado="+ctrEstado+"&ctrIDMunicipio="+ctrIDMunicipio+"&ctrMunicipio="+ctrMunicipio+"&ctrColonia="+ctrColonia+"&ctrCP="+ctrCP+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarCPFiltroEntidad(RutaBusqueda,RutaPadre,IDPais,ctrIDEstado,ctrEstado,ctrIDMunicipio,ctrMunicipio,ctrColonia,ctrCP,GUIDModulo,GUIDIdioma, sEntidad)
{
	var width = "500";
	var height = "300";
	var size = new SizeWindow(width, height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&ctrIDEstado="+ctrIDEstado+"&IDPais="+IDPais+"&ctrEstado="+ctrEstado+"&ctrIDMunicipio="+ctrIDMunicipio+"&ctrMunicipio="+ctrMunicipio+"&ctrColonia="+ctrColonia+"&ctrCP="+ctrCP+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+ GUIDIdioma + "&sEntidad=" + sEntidad;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarConDependencia(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,Dependencia)
{
	if(Dependencia!="")
	{
		var size = new SizeWindow(width,height);	
		var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&Dependencia="+Dependencia;
		AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
	}
}
function Buscar(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarConRecarga(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,Evento)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&Recarga="+Evento;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarProveedorFactura(RutaBusqueda,RutaPadre,GUIDControlProvFac,ControlDep,ControlFecha,ControlMonto,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,strIncluir,strNoIncluir)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControlProvFac="+GUIDControlProvFac+"&strControlDep="+ControlDep+"&strControlFecha="+ControlFecha+"&strControlMonto="+ControlMonto+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&strIncluir="+strIncluir+"&strNoIncluir="+strNoIncluir;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarCampo(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,NoIncluir)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&NoIncluir="+NoIncluir;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarCampo(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,NoIncluir,GUIDTipoDato)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&NoIncluir="+NoIncluir+"&GUIDTipoDato="+GUIDTipoDato;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarCampoCondicion(RutaPadre,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,GUIDConexion,Tabla,Campo)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda=~/Sistema/Campo/CampoCatalogoCondicion.ascx&RutaPadre="+RutaPadre+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&GUIDConexion="+GUIDConexion+"&Tabla="+Tabla+"&Campo="+Campo;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarCampoProcesoTipo(RutaBusqueda,RutaPadre,GUIDControl,Control,CtrlExcluir,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,NoIncluir,GUIDTipoDato,strGUIDElemento)
{
	/*if(Document.GetElementByID(CtrlExcluir)!=null)
		Document.GetElementByID(CtrlExcluir).value*/
	NoIncluir=document.getElementById(CtrlExcluir).value;
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&NoIncluir="+NoIncluir+"&GUIDTipoDato="+GUIDTipoDato+"&strGUIDElemento="+strGUIDElemento+"&strCtrlExcluir="+CtrlExcluir;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BusquedaUsuario(RutaBusqueda,RutaPadre,GUIDControl,Control,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,intTipo,strUsuariosAExcluir, strGUIDElemento)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDControl="+GUIDControl+"&strControl="+Control+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&intTipo="+intTipo+"&strUsuariosAExcluir="+strUsuariosAExcluir+"&strGUIDElemento="+strGUIDElemento;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function BusquedaUsuarioCampo(RutaBusqueda,RutaPadre,GUIDCampo,GUIDModulo,GUIDIdioma,width,height,scrollbars,intOpcion,intTipo,strUsuariosAExcluir, strGUIDElemento)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBusqueda+"&RutaPadre="+RutaPadre+"&strGUIDCampo="+GUIDCampo+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&intTipo="+intTipo+"&strUsuariosAExcluir="+strUsuariosAExcluir+"&strGUIDElemento="+strGUIDElemento;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function LimpiaControles(Controles)
{
	var arr = Controles.split("|"); 
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		for(j=0;j<arr.length;j++)
		{
			if(document.getElementsByTagName("input").item(i).id==arr[j]||
				document.getElementsByTagName("input").item(i).id.toString().indexOf("_"+arr[j])>0)
			{
				document.getElementsByTagName("input").item(i).value='';
			}
		}		
	}	
}
function LimpiaChecks(strControl)
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		if(document.getElementsByTagName("input").item(i).id==strControl)
		{
			document.getElementsByTagName("input").item(i).checked=false;
		}
	}	
}
function ActivaCheck(strCheck,strText)
{
	if(document.getElementById(strText)!=null && document.getElementById(strCheck)!=null)
	{
		if(document.getElementById(strText).value=="")
			document.getElementById(strCheck).checked=false;
	}
}
function EliminarDeExcluir(strExcluir, GUIDControl)
{
	var arr = document.getElementById(strExcluir).value.split(",");
	var strTemp="";
	for(j=0;j<arr.length;j++)
	{
		if(document.getElementById(GUIDControl).value!=arr[j])
			strTemp += arr[j] + ",";
	}
	if(strTemp!="")
		document.getElementById(strExcluir).value = strTemp.substring(0,strTemp.length-1);
	else
		document.getElementById(strExcluir).value="";
}
function Estilo(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Estilo.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=no, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function EditarReasigna(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars,statusbar,sGUIDProcesoPadre)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&GUIDprocesoPadre="+sGUIDProcesoPadre;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status='+statusbar+', toolbar=no, scrollbars='+scrollbars+', resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function Editar(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function Editar(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=no, toolbar=no, scrollbars='+scrollbars+', resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function Editar(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars,statusbar)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status='+statusbar+', toolbar=no, scrollbars='+scrollbars+', resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}

function Editar(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars,statusbar, Title)
{
	var size = new SizeWindow(width,height);	

	if (Title == null || Title == '')
	    Title = 'INFOMEX';

	var Ruta="Editar.aspx?Title=" + Title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status='+statusbar+', toolbar=no, scrollbars='+scrollbars+', resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}

function EditarCampo(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars,NoIncluir)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&NoIncluir="+NoIncluir;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=no, toolbar=no, scrollbars='+scrollbars+', resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function EditarCatalogo(RutaEditar,RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma,width,height,scrollbars,Condicion)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+RutaEditar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&Condicion="+Condicion;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=no, toolbar=no, scrollbars='+scrollbars+', resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function BuscarRolesUsuarios(RutaBuscar,RutaPadre,Tipo,Excluir,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBuscar+"&RutaPadre="+RutaPadre+"&Tipo="+Tipo+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&Excluir="+Excluir;
	window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos);
}
function BuscarDepartamentos(RutaBuscar,RutaPadre,intOpcion,Excluir,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
	var size = new SizeWindow(width,height);	
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBuscar+"&RutaPadre="+RutaPadre+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&DeptosExcluir="+Excluir;
	window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos);
}
function BuscarDepartamentos(RutaBuscar,RutaPadre,intOpcion,strGUIDPadre,Excluir,GUIDModulo,GUIDIdioma,width,height,scrollbars)
{
    var size = new SizeWindow(width,height);
	var Ruta="Buscar.aspx?Title=" + document.title +"&RutaBusqueda="+RutaBuscar+"&RutaPadre="+RutaPadre+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma+"&intOpcion="+intOpcion+"&DeptosExcluir="+Excluir+"&strGUIDPadre="+strGUIDPadre;
	window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=yes, toolbar=no, scrollbars='+scrollbars+', resizable=no,top=' + size.topPos + ',left=' + size.leftPos);
}
function Seguridad(RutaPadre,GUIDModulo,GUIDIdioma)
{	
	var size = new SizeWindow('250','200');	
	var Ruta="Seguridad.aspx?Title=" + document.title +"&RutaSeguridad=~/Core/General/Permisos.ascx&RutaPadre="+RutaPadre+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=250, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=yes, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function Titulo(RutaPadre,GUIDModulo,GUIDIdioma)
{	
	var size = new SizeWindow('500','200');	
	var Ruta="TituloModulo.aspx?Title=" + document.title +"&RutaTitulo=~/Core/General/TituloEditar.ascx&RutaPadre="+RutaPadre+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=500, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function Eliminar(RutaEliminar,RutaPadre,GUIDModulo,GUIDIdioma)
{
	Cadena="";
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItem|'+GUIDModulo)!=-1)
		{
			if(document.getElementsByTagName("input").item(i).checked==true)
			{
				var arr = document.getElementsByTagName("input").item(i).name.split("|"); 
				Cadena=Cadena+arr[2]+",";
			}
		}
	}	
	if(Cadena!="")
	{	
		Cadena=Cadena.substring(0,Cadena.length-1);
		var size = new SizeWindow('250','200');	
		var Ruta="Eliminar.aspx?Title=" + document.title +"&RutaEliminar="+RutaEliminar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+Cadena+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
		AgregarArreglo(window, window.open(Ruta, windowName="", 'width=250, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
	}
}
function EliminarDif(RutaEliminar,RutaPadre,GUIDModulo,GUIDIdioma)
{
	Cadena="";
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItemDif|'+GUIDModulo)!=-1)
		{
			if(document.getElementsByTagName("input").item(i).checked==true)
			{
				var arr = document.getElementsByTagName("input").item(i).name.split("|"); 
				Cadena=Cadena+arr[2]+",";
			}
		}
	}	
	if(Cadena!="")
	{	
		Cadena=Cadena.substring(0,Cadena.length-1);
		var size = new SizeWindow('250','200');	
		var Ruta="Eliminar.aspx?Title=" + document.title +"&RutaEliminar="+RutaEliminar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+Cadena+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
		AgregarArreglo(window, window.open(Ruta, windowName="", 'width=250, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
	}
}
function EliminarDif2(RutaEliminar,RutaPadre,GUIDModulo,GUIDIdioma)
{
	Cadena="";
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkItemDif2|'+GUIDModulo)!=-1)
		{
			if(document.getElementsByTagName("input").item(i).checked==true)
			{
				var arr = document.getElementsByTagName("input").item(i).name.split("|"); 
				Cadena=Cadena+arr[2]+",";
			}
		}
	}	
	if(Cadena!="")
	{	
		Cadena=Cadena.substring(0,Cadena.length-1);
		var size = new SizeWindow('250','200');	
		var Ruta="Eliminar.aspx?Title=" + document.title +"&RutaEliminar="+RutaEliminar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+Cadena+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
		AgregarArreglo(window, window.open(Ruta, windowName="", 'width=250, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
	}
}
function EliminarElemento(RutaEliminar, RutaPadre, GUIDElemento, GUIDModulo, GUIDIdioma)
{
	var Ruta="Eliminar.aspx?Title=" + document.title +"&RutaEliminar="+RutaEliminar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	var size = new SizeWindow('250','200');	
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=250, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function Mensaje(Mensaje,Aceptar)
{	
	var width='250';
	var height='200';
	var size = new SizeWindow(width,height);	
	var Ruta="Titulo.aspx?Title=" + document.title +"&RutaTitulo=~/Core/General/TituloEditar.ascx&RutaPadre="+RutaPadre+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width='+width+', height='+height+', location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
}
function MostrarRecibo(RutaPadre,GUIDElemento,GUIDModulo,GUIDIdioma)
{
	var size = new SizeWindow('400','350');	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar=~/IFAI/Recibo/ReciboGral.ascx&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=400, height=350, location=no, menubar=yes, status=no, toolbar=no, scrollbars=no, resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function MostrarReciboInfomex(RutaPadre,Ruta,GUIDElemento,GUIDModulo,GUIDIdioma)
{
	var size = new SizeWindow('400','350');	
	var Ruta="Editar.aspx?Title=" + document.title +"&RutaEditar="+Ruta+"&RutaPadre="+RutaPadre+"&GUIDElemento="+GUIDElemento+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
	AgregarArreglo(window, window.open(Ruta, windowName="", 'width=400, height=350, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=yes,top=' + size.topPos + ',left=' + size.leftPos));
}
function SelectItemEstructura(strName)
{
	if(strName.checked==true)
	{		
		var i;	
		
		var txtElementoSel,strNombre;
		for(i=0;i<document.getElementsByTagName("input").length-1;i++)
		{
			if(document.getElementsByTagName("input").item(i).name.indexOf('chkModuloEstructura')!=-1)
			{
				document.getElementsByTagName("input").item(i).checked=false;
			}
			strName.checked = true;						
			if(document.getElementsByTagName("input").item(i).name.indexOf('txtElementoSel')!=-1)
				document.getElementsByTagName("input").item(i).value=strName.name;
		}	
	}
	else
	{
		for(i=0;i<document.getElementsByTagName("input").length-1;i++)
		{
			if(document.getElementsByTagName("input").item(i).name.indexOf('txtElementoSel')!=-1)
			{
				document.getElementsByTagName("input").item(i).value="";
				break;
			}
		}	
	}
}
function EliminarEstructura(RutaEliminar,RutaPadre,GUIDModulo,GUIDIdioma)
{
	Cadena="";
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{		
		if(document.getElementsByTagName("input").item(i).name.indexOf('chkModuloEstructura|'+GUIDModulo)!=-1)
		{	
			if(document.getElementsByTagName("input").item(i).checked==true)
			{
				var arr = document.getElementsByTagName("input").item(i).name.split("|"); 
				Cadena=Cadena+arr[2]+",";
			}
		}
	}	
	if(Cadena!="")
	{	
		Cadena=Cadena.substring(0,Cadena.length-1);
		var Ruta="Eliminar.aspx?Title=" + document.title +"&RutaEliminar="+RutaEliminar+"&RutaPadre="+RutaPadre+"&GUIDElemento="+Cadena+"&GUIDModulo="+GUIDModulo+"&GUIDIdioma="+GUIDIdioma;
		var size = new SizeWindow('250','200');	
		AgregarArreglo(window, window.open(Ruta, windowName="", 'width=250, height=200, location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no,top=' + size.topPos + ',left=' + size.leftPos));
	}
}
function SoloNumeros(e,decReq,NumDec)
{		
	var key = (isIE) ? window.event.keyCode : e.which;
	var obj = (isIE) ? event.srcElement : e.target;
	var isNum = (key > 47 && key < 58) ? true:false;
	//if(key==48 && obj.value.length==0)
	//	isNum=false;	
	var dotOK = (key==46 && decReq=='decOK' && (obj.value.indexOf(".")<0 || obj.value.length==0)) ? true:false;
	var strValCadena;
	var strValText;

	strValText = obj.value;

	if (decReq=='decOK') 
		{
			strValCadena = strValText.split(".");
			if (strValCadena.length == 2)
				{
					var longitud = strValCadena[1];						
					if (longitud.length >=NumDec)
						{
							isNum = false;
						}
				}
		}

	if(isIE)
		window.event.keyCode = (!isNum && !dotOK) ? 0:key;
	else if(isNS)
		e.which = (!isNum && !dotOK) ? 0:key;

	if(key==0 || key==8)
		return true;
	else
		return (isNum || dotOK);
}

function SoloNumerosyPunto(e,decReq,NumDec)
{	
	var key = (isIE) ? window.event.keyCode : e.which;
	var obj = (isIE) ? event.srcElement : e.target;
	var isNum = (key > 45 && key < 58) ? true:false;
	var dotOK = (key==45 && decReq=='decOK' && (obj.value.indexOf(".")<0 || obj.value.length==0)) ? true:false;
	var strValCadena;
	var strValText;
				
	strValText = obj.value;

	if (decReq=='decOK') 
		{
			strValCadena = strValText.split(".");
			if (strValCadena.length == 2)
				{
					var longitud = strValCadena[1];						
					if (longitud.length >=NumDec)
						{
							isNum = false;
						}
				}
		}
	
	window.event.keyCode = (!isNum && !dotOK && isIE) ? 0:key;
	e.which = (!isNum && !dotOK && isNS) ? 0:key;

	if(key==0 || key==8)
		return true;
	else
		return (isNum || dotOK);	
}

function cmdVerArchivo(pstrPath)
{
	var size = new SizeWindow('600','500');	
	AgregarArreglo(window, window.open(pstrPath,"_blank","toolbar=no,menubar=no,directories=no,status=no,resizable=yes,location=no,scrollbars=yes,height=500,width=600,top=" + size.topPos + ",left=" + size.leftPos));
}

function cmdDowArchivo(pstrPath)
{
	if(window.navigator.appName=="Netscape"){
		var size = new SizeWindow('600','500');	
		AgregarArreglo(window, window.open(pstrPath,"_blank","toolbar=no,menubar=no,directories=no,status=no,resizable=yes,location=no,scrollbars=yes,height=500,width=600,top=" + size.topPos + ",left=" + size.leftPos));
	}else{
		window.navigate(pstrPath);
	}
}

function FormatoHora(e,decReq,NumDec)
{
	var key = (isIE) ? window.event.keyCode : e.which;
	var obj = (isIE) ? event.srcElement : e.target;
	var isNum = (key > 47 && key < 58) ? true:false;
	var isDPunt = (key == 58) ? true:false;
	var dotOK = (key==46 && decReq=='decOK' && (obj.value.indexOf(".")<0 || obj.value.length==0)) ? true:false;
	var strValCadena;
	var strValText;

	strValText = obj.value;

	if (decReq=='decOK') 
		{
			strValCadena = strValText.split(".");
			if (strValCadena.length == 2)
				{
					var longitud = strValCadena[1];						
					if (longitud.length >=NumDec)
						{
							isNum = false;
						}
				}
		}

	if(isIE)
		window.event.keyCode = (!isNum && !dotOK) ? 0:key;
	else if(isNS)
		e.which = (!isNum && !dotOK) ? 0:key;

	return (isNum || dotOK);
}

function CatalogoCheck(Elemento,NombreGeneral)
{	
	if(Elemento.checked==true)
	{
		for(i=0;i<document.getElementsByTagName("input").length;i++)
		{		
			if(document.getElementsByTagName("input").item(i).id.indexOf(NombreGeneral)!=-1)
			{	
				if(document.getElementsByTagName("input").item(i).id!=Elemento.id)
					document.getElementsByTagName("input").item(i).checked=false;
			}
		}	
	}
}
function CatalogoText(Elemento,NombreGeneral)
{
	if(Elemento.value!="")
	{
		for(i=0;i<document.getElementsByTagName("input").length;i++)
		{		
			if(document.getElementsByTagName("input").item(i).id.indexOf(NombreGeneral)!=-1)
			{					
				if(document.getElementsByTagName("input").item(i).id!=Elemento.id)
					document.getElementsByTagName("input").item(i).value="";
			}
		}	
	}
}
function MostrarExpediente(Tabla)
{
	if(Tabla.style.display=="none")
	{
		Tabla.style.display="block";
	}
	else
	{
		Tabla.style.display="none";
	}	
}
function EstableceValor(control,valor,intOpcion)
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		if(document.getElementsByTagName("input").item(i).name.indexOf(control)!=-1)
		{
			if(intOpcion=="1")
			{
				document.getElementsByTagName("input").item(i).value=valor;
				break;
			}
			else if(intOpcion=="2")
			{
				document.getElementsByTagName("input").item(i).checked=valor;
				break;
			}
		}
	}
}
function EstableceValorCombo(control,valor)
{
	for(i=0;i<document.getElementsByTagName("select").length;i++)
	{
		if(document.getElementsByTagName("select").item(i).name.indexOf(control)!=-1)
		{
			document.getElementsByTagName("select").item(i).options[valor].selected=true;
			break;
		}
	}
}
function ObtenIDCampoINPUT(control)
{	
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{
		if(document.getElementsByTagName("input").item(i).name.indexOf(control)!=-1)
		{
			return(document.getElementsByTagName("input").item(i).id);
		}
	}
}
function ObtenCampoSELECT(control)
{	
	Cadena="";
	for(i=0;i<document.getElementsByTagName("select").length;i++)
	{
		if(document.getElementsByTagName("select").item(i).name.indexOf(control)!=-1)
		{						
			for(j=0;j<document.getElementsByTagName("select").item(i).options.length;j++)
			{															
				if(document.getElementsByTagName("select").item(i).options[j].selected==true)
				{						
					Cadena+="apos"+document.getElementsByTagName("select").item(i).options[j].value+"apos,";			
				}
			}			
			if(Cadena!="")
			{				
				Cadena=Cadena.substring(0,Cadena.length-1);				
			}
			else
				Cadena="aposapos";
			return(Cadena);
		}
	}
}
function EstableceEstado(objControl,blnEstado)
{	
  if(blnEstado==true)
    objControl.style.visibility="visible";
  else
    objControl.style.visibility="hidden";
}
function SeleccionaDia(txtOpcion,strCssSel,strCssNoSel,spnItem,intDia)
{
	if(txtOpcion.value==intDia)
	{
		txtOpcion.value="";
		spnItem.style.backgroundColor=strCssNoSel;
	}
	else
	{
		txtOpcion.value=intDia;
		spnItem.style.backgroundColor=strCssSel;
	}			
}
function ObtenOpcion(nombre)
{
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{		
		if(document.getElementsByTagName("input").item(i).name.indexOf('rblOpcion')!=-1)
		{		
			if(document.getElementsByTagName("input").item(i).checked==true)
				return document.getElementsByTagName("input").item(i).value;
		}
	}
}
function MaximaLongitud(e,intMaximo)
{		
	//var key = (isIE) ? window.event.keyCode : e.which;
	var obj = (isIE) ? event.srcElement : e.target;
	if(obj.value.length > intMaximo)
		return false;
	else
		return true;
}
function FechaCombo(cboAnio,cboMes,cboDia,txtFecha)
{	
	var vartxtFecha;	
	for(i=0;i<document.getElementsByTagName("input").length;i++)
	{		
		if(document.getElementsByTagName("input").item(i).name.indexOf(txtFecha)!=-1)
		{			
			vartxtFecha = document.getElementsByTagName("input").item(i); 			
			break;
		}
	}
	for(i=0;i<document.getElementsByTagName("select").length;i++)
	{
		if(document.getElementsByTagName("select").item(i).name.indexOf(cboAnio)!=-1)
		{
			vartxtFecha.value=document.getElementsByTagName("select").item(i).value+',';
			break;
		}
	}
	for(i=0;i<document.getElementsByTagName("select").length;i++)
	{
		if(document.getElementsByTagName("select").item(i).name.indexOf(cboMes)!=-1)
		{
			vartxtFecha.value=vartxtFecha.value+document.getElementsByTagName("select").item(i).value+',';
			break;
		}
	}
	for(i=0;i<document.getElementsByTagName("select").length;i++)
	{
		if(document.getElementsByTagName("select").item(i).name.indexOf(cboDia)!=-1)
		{
			vartxtFecha.value=vartxtFecha.value+document.getElementsByTagName("select").item(i).value;
			break;
		}
	}
}

/**
 * Funcion que en base a un ancho y alto determinado en las variables w y h provee el tamaño exacto para
 * centrar unaventana nueva
 */
function SizeWindow(w,h){
	var popW = w;
	var popH = h;
	if (document.all || document.getElementById) {
	   w = screen.width;
	   h = screen.height;
	}else{
		popW = 300;
		popH = 200;
	}
	this.pW = popW;
	this.pH = popH;
	this.leftPos = (w-popW)/2;
	this.topPos = (h-popH)/2;
	var leftPos = (w-popW)/2;
	var topPos = (h-popH)/2;
}

/*
Funcion para mostrar y ocultar varias secciones a la vez
*/
function showHideSomeBranches(branchesToShow,branchesToHide){
	var arregloToShow = branchesToShow.split(",");
	for (i=0; i<arregloToShow.length;i++){
		var branchToShow = arregloToShow[i];
		if (document.getElementById(branchToShow) != null)
		{
			var objBranchToShow = document.getElementById(branchToShow).style;
			objBranchToShow.display="block";
		}
	}

	var arregloToHide = branchesToHide.split(",");
	for (i=0; i<arregloToHide.length;i++){
		var branch = arregloToHide[i];
		if (document.getElementById(branch) != null)
		{
			var objBranch = document.getElementById(branch).style;
			objBranch.display="none";
		}
	}

}

function clearListaNoQuestion(objList)
{
	if (objList.options.length <= 0)
	{
		return;
	}
	for (var i = objList.options.length; i >= 0; i--)
	{
		objList.options[i] = null;
	}
}

function changeIFrame(the_iframe)//iframeWindow)
{
  //find the height of the internal page
  /*var the_height=
    document.getElementById(the_iframe).contentWindow.
      document.body.scrollHeight;
  */
  //var the_height=the_iframe.contentWindow.document.body.scrollHeight;
//  var the_width=the_iframe.contentWindow.document.body.scrollWidth;

  //change the height of the iframe
  /*
  document.getElementById(the_iframe).height=
      the_height;
  */
  the_iframe.height=the_height;
//  the_iframe.width=the_width;
/*
    if (iframeWindow.document.height) {
        var iframeElement = document.getElementById
        (iframeWindow.name);
        iframeElement.style.height = iframeWindow.document.height + 'px';
        iframeElement.style.width = iframeWindow.document.width + 'px';
    }
    else if (document.all) {
        var iframeElement = document.all[iframeWindow.name];
        if (iframeWindow.document.compatMode &&
            iframeWindow.document.compatMode != 'BackCompat') 
            {
                  iframeElement.style.height = 
            iframeWindow.contentWindow.document.body.scrollHeight + 5 + 'px';
                  iframeElement.style.width = 
            iframeWindow.document.documentElement.scrollWidth + 5 + 'px';
            }
        else {
                  iframeElement.style.height = 
            iframeWindow.document.body.scrollHeight + 5 + 'px';
                  iframeElement.style.width = 
            iframeWindow.document.body.scrollWidth + 5 + 'px';
            }
      }
*/
}


function ValidaCaracteres()
{
    for(i=0;i<document.getElementsByTagName("input").length;i++)
    {
        if(document.getElementsByTagName("input").item(i).type=="text")
        { 
            if(document.getElementsByTagName("input").item(i).value.indexOf("'")!=-1)
            {
                document.getElementsByTagName("input").item(i).value=document.getElementsByTagName("input").item(i).value.replace("'","");
            }
            if(document.getElementsByTagName("input").item(i).value.indexOf("|")!=-1)
                document.getElementsByTagName("input").item(i).value=document.getElementsByTagName("input").item(i).value.replace("|","");
        } 
    } 
}

 
function autoIframe(frameID){
    try{
        frame = document.getElementById(frameID);
        innerDoc = (frame.contentDocument) ? frame.contentDocument : frame.contentWindow.document;
        //objToResize = (frame.style) ? frame.style : frame;
        objToResize = frame;
        
        
        var x,y; 
        var test1 = innerDoc.body.scrollHeight;
        var test2 = innerDoc.body.offsetHeight;
        if (test1 > test2) // all but Explorer Mac 
        { x = innerDoc.body.scrollWidth; 
          y = innerDoc.body.scrollHeight; 
        } 
        else // Explorer Mac; //would also work in Explorer 6 Strict, Mozilla and Safari 
        { x = innerDoc.body.offsetWidth; 
          y = innerDoc.body.offsetHeight; } 
        
        if (frameID == 'menu')
        {
            if (document.getElementById('Contenido').height < 410)
                document.getElementById(frameID).height = 410;
            else
                 document.getElementById(frameID).height = document.getElementById('Contenido').height;
        }
        else
        {
            if ((y + 16) > 410)
                objToResize.height = y + 16;
            else
                objToResize.height = 410;
        }
    }
    catch(err){
        window.status = err.message;
    }
}

function autoIframeContenido(){
    if (window.parent && window.parent.autoIframe)
                {window.parent.autoIframe('Contenido'); window.parent.autoIframe('menu');}
}

// Se utiliza para elmanejo peticiones o eventos sin 
// permitirle al cliente presionar el boton mas de una vez al mismo tiempo.
function disableControl(ctrls)
{
    var ctrl = ctrls.split("&");
    if (typeof(Page_ClientValidate) == 'function')
    {
      if (Page_ClientValidate() == false)
      { 
       return false; 
      }
    }
    
    for(var i=0;i<ctrl.length;i++)
    {
        if ($get(ctrl[i]) != null)
        $get(ctrl[i]).disabled = true;
    }
    __doPostBack(ctrl[0],'');
}