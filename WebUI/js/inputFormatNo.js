function dispDot(str) {
	var isi_obj = str;
	var pjg = (isi_obj).length;
	if (pjg>3) {
		var str_awl = new Array();
		var c = 0;
		while (pjg>3) {
			var sisa=pjg%3;
			if (sisa==0) { sisa=3 };
			var isi_arr=isi_obj.substr(0,sisa)
			str_awl[c]=isi_arr;
			isi_obj=isi_obj.substr((str_awl[c]).length);
			pjg=isi_obj.length;
			c++;
			}
		var nilai='';
		for (var i=0;i<c;i++) {
			if (nilai=='') {
				nilai=str_awl[i]
			}
			else {
				nilai=nilai+'.'+str_awl[i]
				}
			}
		}
//	nilai=nilai+'.000';
	return (nilai);
	}

function inputFormatNo(szFormName,ss) {
	with (szFormName) {
		var obj = ss.value;
		var pjg = obj.length;
		if (obj.indexOf(".")>0) {
			for (var i=0;i<pjg;i++) {
				obj = obj.replace('.',''); 
				}
			}	
		var jml = parseFloat(obj)*1000;
		ss.value=dispDot(jml.toString());
		if ( (obj.length==0)||(isNaN(obj))||(obj==0)||(obj=='undefined') ) {ss.value='';}
		}
	}


function formatCurrency(num) {
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
		num = "0";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
		cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+'.'+
	num.substring(num.length-(4*i+3));
	//return (((sign)?'':'-') + '$' + num + '.' + cents);
	return (((sign)?'':'-') + num + ',' + cents);
}

function CalcKeyCode(aChar) {
  var character = aChar.substring(0,1);
  var code = aChar.charCodeAt(0);
  return code;
}

function checkNumber(val) {
  var strPass = val.value;
  var strLength = strPass.length;
  var lchar = val.value.charAt((strLength) - 1);
  var cCode = CalcKeyCode(lchar);

  /* Check if the keyed in character is a number
     do you want alphabetic UPPERCASE only ?
     or lower case only just check their respective
     codes and replace the 48 and 57 */

  if (cCode < 48 || cCode > 57 ) {
    var myNumber = val.value.substring(0, (strLength) - 1);
    val.value = myNumber;
  }
  return false;
}






//--------------------------

  function CheckYear(control)
  {var year=control.value;if(year!='' && (year<1900 || year>2099)){alert('Range Nilai Tahun : 1900-2099');control.select()}}
  
  function CheckHour(control)
  {var hour=control.value;if(hour!='' && (hour<0 || hour>23)){alert('Range Nilai Jam : 00-23');control.select()}}
  
  function CheckMinute(control)
  {var minute=control.value;if(minute!='' && (minute<0 || minute>59)){alert('Range Nilai Jam : 00-59');control.select()}}
  
  function FormatAsDecimal(control)
  {control.value=CurrencyToDecimal(control.value);control.style.color="black";control.select();}

  function CurrencyToDecimal(currency)
  {if (currency.match(/\(/)!=null) {currency='\x2D'+currency;}currency=currency.replace(/[^\d\x2D\x2C]/g,'');return currency;}

  function FormatAsNumber(control)
  {control.style.color=(control.value.match(/\x2D/)==null?control.getAttribute("positiveColor"):control.getAttribute("negativeColor"));control.value=DecimalToNumber(control.value);}

  function DecimalToNumber(amount)
  {var isPositive=(amount.match(/\x2D/)==null?true:false);amount=amount.replace(/\x2D/g,'');var dollars=amount.match(/\d+/);dollars=(dollars==null?'':dollars[0]);var size=3;var position=dollars.length-size;while(position>0){dollars=dollars.substr(0,position)+'\x2E'+dollars.substr(position);position-=size;}var cents=amount.match(/\x2C\d+/);cents=(cents==null?'':cents[0].substr(1));cents=cents.replace(/\x2C/g,'');if (cents !=0){dollars=dollars+'\x2C'+cents; }return (isPositive?dollars:'\x2D'+dollars);}

  function CheckInteger()
  {var keyCode=window.event.keyCode;if(!((keyCode>47&&keyCode<58))){window.event.returnValue=false;}}

  function CheckIntegerWNegatif()
  {var keyCode=window.event.keyCode;if(!((keyCode>47&&keyCode<58)||keyCode==45)){window.event.returnValue=false;}}

  function CheckNumeric()
  {var keyCode=window.event.keyCode;if(!((keyCode>47&&keyCode<58)||keyCode==44)){window.event.returnValue=false;}}

  function CheckNumericWNegatif()
  {var keyCode=window.event.keyCode;if(!((keyCode>47&&keyCode<58)||keyCode==44||keyCode==45)){window.event.returnValue=false;}}

  function CheckAlphabet()
  {var keyCode=window.event.keyCode;if(!((keyCode>64&&keyCode<91)|| (keyCode>96&&keyCode<123) )){window.event.returnValue=false;}}
