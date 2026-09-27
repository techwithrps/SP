
// This set of functions are for processing the key press event
// Used to restrict input on numerics and pure textual fields
function getDDMMYYYYHHMI(obj)
  {
      var objParts=obj.split(" ");
      var objDateParts=objParts[0].split("/");
      if(objParts[1]!=null)
      {
        var objTimeParts=objParts[1].split(":");
      }
      
      var newObj=new Date();
      newObj.setDate(objDateParts[0]);
      newObj.setMonth(Number(objDateParts[1])-1);
      newObj.setYear(objDateParts[2]);
      if(objParts[1]!=null)
      {
        newObj.setHours(objTimeParts[0]);
        newObj.setMinutes(objTimeParts[1]);
      }
      return newObj;
  }
function disableDataEntry(obj)
  {
     obj.setAttribute("onkeydown","kp_val_tb();"); 
     obj.setAttribute('disabled',true);
  }
  function enableDataEntry(obj)
  {
     obj.setAttribute("onkeydown",""); 
     obj.setAttribute('disabled',false);
  }
function LPad(ContentToSize,PadLength,PadChar)
  {
     var PaddedString=ContentToSize.toString();
     for(i=ContentToSize.length+1;i<=PadLength;i++)
     {
         PaddedString=PadChar+PaddedString;
     }
     return PaddedString;
  }
function validateEmailID(obj,lbl)
{
       var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
       var address = obj.getAttribute('value').trim();            
       if(reg.test(address) == false) {          
          alert('Invalid '+lbl+': '+address);
          obj.focus();
          return false;
       }  
       return true;
}
function validatePhoneNo(obj,lbl)
{
       return true;
       var phoneNo = obj.getAttribute('value').trim();            
       
        for(i=0;i<phoneNo.length;i++)
        {       
               if ((phoneNo.charAt(i) != 45) && (phoneNo.charAt(i) != 43) && (phoneNo.charAt(i) < 48 || phoneNo.charAt(i) > 57))
                      {
                          alert('Invalid '+lbl+': '+phoneNo);
                          obj.focus();
                          return false;
                       }
              if (phoneNo.charAt(i) == 43) {
               if (phoneNo.charAt(i).indexOf("+") > -1)
                  {
                          alert('Invalid '+lbl+': '+phoneNo);
                          obj.focus();
                          return false;
                  }
              }
        }
      return true;       
}


function validateWebsite(obj,lbl)
{       
       var reg = /^([a-z0-9_-]+\.)*[a-z0-9_-]+(\.[a-z]{2,6}){1,2}$/;
       var address = obj.getAttribute('value').trim();            
       if(reg.test(address) == false) {          
          alert('Invalid '+lbl+': '+address);
          obj.focus();
          return false;
       }  
       return true;
}
function validateData(obj,lbl)
{
       obj.setAttribute('value',obj.getAttribute('value').trim());
       if (obj.getAttribute('value').trim() == "")
       {
            alert('Please fill '+lbl+'.');
            obj.focus();
            return false;
       }
       return true;
}
function validateDropDown(obj,lbl)
{      
       if (obj.options[obj.selectedIndex].text.trim() == "" )
       {
            alert('Please Select '+lbl+'.');
            obj.focus();
            return false;
       }
       return true;
}
function validateDropDownIndex(obj,lbl)
{      
       if ( obj.selectedIndex == 0)
       {
            alert('Please Select '+lbl+'.');
            obj.focus();
            return false;
       }
       return true;
}
String.prototype.trim = function() {
	return this.replace(/^\s+|\s+$/g,"");
}
String.prototype.ltrim = function() {
	return this.replace(/^\s+/,"");
}
String.prototype.rtrim = function() {
	return this.replace(/\s+$/,"");
}

function kp_date() {
     if ((event.keyCode < 47 || event.keyCode > 57))
         event.returnValue = false;
 }
 function kp_val_tb() {
            if (event.keyCode != 9)
            event.returnValue = false;  
            else
            event.returnValue = true;        
 }
function kp_val() {

            event.returnValue = false;
 }

 function kp_integer() {
     if ((event.keyCode < 48 || event.keyCode > 57))
         event.returnValue = false;
 }
 function kp_numeric() {
     if ((event.keyCode != 45) && (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode != 46))
         event.returnValue = false;
         
      if (event.keyCode == 46) {
       if (event.srcElement.value.indexOf(".") > -1)
            event.returnValue = false;
      }
             
       if (event.keyCode == 45) {
       if (event.srcElement.value.indexOf("-") > -1)
            event.returnValue = false;
             }
 }
 function kp_numeric_Wo_hyphen() {
     if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode != 46))
         event.returnValue = false;
         
      if (event.keyCode == 46) {
       if (event.srcElement.value.indexOf(".") > -1)
            event.returnValue = false;
      }
 }
 function kp_phonenumber() {
		//	this checks for numeric characters and allows - (hyphen) + (Plus once)
     if ((event.keyCode != 45) && (event.keyCode != 43) && (event.keyCode < 48 || event.keyCode > 57))
         event.returnValue = false;
         
      if (event.keyCode == 43) {
       if (event.srcElement.value.indexOf("+") > -1)
            event.returnValue = false;
      }
 }
 
 function kp_SizeValidation(MaxSize,FieldName) {
		//	this checks for Maximum length of the data
		alert(length(event.data));
     if (length(event.data) > MaxSize)
     {
         alert('Size exceeded of ' + MaxSize + ' for ' + FieldName);
         event.returnValue = false;
      }   
      else 
       {  event.returnValue = true;            
       }
 }

 function kp_zipcode() {
		//	this checks for alphabets, numeric characters and allows - (hyphen)
     if ((event.keyCode != 45) && (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 65 || event.keyCode > 90) && (event.keyCode < 97 || event.keyCode > 122))
         event.returnValue = false;
 }
 function kp_character() {
     if ((event.keyCode < 65 || event.keyCode > 90) && (event.keyCode < 97 ||
                                                        event.keyCode > 122))
         event.returnValue = false;
 }


 function kp_character_numeric() {
     if ((event.keyCode < 65 || event.keyCode > 90) && (event.keyCode < 97 ||
                                                        event.keyCode > 122) && (event.keyCode < 48 ||
                                                        event.keyCode > 57))
         event.returnValue = false;
 }

 function kp_upper_character() {
     if ((event.keyCode < 65 || event.keyCode > 90) && (event.keyCode < 97 ||
                                                        event.keyCode > 122))
         event.returnValue = false;
     else
     {
        if ((event.keyCode >= 97 && event.keyCode <= 122))
         event.keyCode -= 32;        
     }
 }
 
 function kp_upper_characterWithSpace() {
     if ((event.keyCode < 65 || event.keyCode > 90) && (event.keyCode < 97 ||
                                                        event.keyCode > 122) && event.keyCode != 32)
         event.returnValue = false;
     else
     {
        if ((event.keyCode >= 97 && event.keyCode <= 122))
         event.keyCode -= 32;        
     }
 }


 function kp_convert_upper() {
     if ((event.keyCode >= 97 && event.keyCode <= 122))
         event.keyCode -= 32;
 }
 
 function kp_convert_lower() {
     if ((event.keyCode >= 65 && event.keyCode <= 90))
         event.keyCode += 32;
 }
function valMinuts(obj,objlblerr)
    {
   
        var returnValue = false;
            var msg = objlblerr;
        var Minute =obj.getAttribute("value");
            if (Minute >= 0 && Minute <= 59)
                {
                    returnValue=true;
                    msg.innerText="";
                }
              else
              {
                msg.innerText="Minute should be 0 to 59";
                alert('Minute should be 0 to 59');
                objlblerr.color="Red";
                obj.focus();
                returnValue=false;
                }         
    }
    function Hours(obj,objlblerr)
    {
        var returnValue = false;
             var msg = objlblerr;
        var Hour = obj.getAttribute("value");
            if (Hour >= 0 && Hour <= 23)
              {
                    returnValue=true;
                    msg.innerText="";
                }
          else
              {
               msg.innerText="Hour should be 0 to 23";
                alert('Hour should be 0 to 23');
                objlblerr.color="Red";
                obj.focus();
                returnValue=false;
                }         
    }

 function kp_setup() {
     this.date=kp_date;
     this.integer = kp_integer;
     this.numeric = kp_numeric;
     this.character = kp_character;
     this.convertUpper = kp_convert_upper;
     this.convertLower = kp_convert_lower;
     this.phonenumber = kp_phonenumber;
     this.zipcode = kp_zipcode;
     this.val=kp_val;
    
     return this;
 }
 function validateContainer(control) {
     if (control.value != '') {
         if (!control.value.match(/^([a-zA-Z]{4})(\d{7})$/)) {
             alert('Invalid Container No.');
             control.focus();
             return false;
         }
     }
 }
 function validatePAN(control) {
     if (control.value != '') {
         if (!control.value.match(/^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/)) {
             alert('Invalid PAN No.');
             control.focus();
             return false;
         }
     }
 }

 function validateTAN(control) {
     if (control.value != '') {
         if (!control.value.match(/^([a-zA-Z]{4})(\d{5})([a-zA-Z]{1})$/)) {
             alert('Invalid TAN No.');
             control.focus();
             return false;
         }
     }
 }

 function validateSTRN(control) {
     if (control.value != '') {
         if (!control.value.match(/^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})([a-zA-Z]{2})(\d{3})$/)) {
             alert('Invalid Service Tax Reg. No.');
             control.focus();
             return false;
         }
     }
 }

 function validateEmailForMultiple(field) {
     var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,5}$/;
     return (regex.test(field)) ? true : false;
 }

 function validateMultipleEmailsCommaSeparated(emailcntl, seperator) {
     var value = emailcntl.value;
     if (value != '') {
         var result = value.split(seperator);
         for (var i = 0; i < result.length; i++) {
             if (result[i] != '') {
                 if (!validateEmailForMultiple(result[i])) {
                     emailcntl.focus();
                     alert('Please check, `' + result[i] + '` email addresses not valid!');
                     return false;
                 }
             }
         }
     }
     return true;
 }
 function validateIP(control) {
     if (control.value != '') {
         if (!control.value.match(/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/)) {
             alert('Invalid IP Address.');
             control.focus();
             return false;
         }
     }
 }

 var keyPressInput = new Object;
 keyPressInput = kp_setup();
