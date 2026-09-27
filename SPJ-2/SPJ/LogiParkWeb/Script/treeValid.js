// JScript File
/********************************************
The function t_btnpressed(id,hValue,hText) is used to copy the copied contents from the listbox to hiddenfields
so that they can be available at server side for updation in database.

id-----> is ListBox object
hValue---> is Hiddenfield 
************************************************/

function t_btnpressed(id,hValue,hText)
    {  
       // alert('submitButton:'+id);   
        var cnt=id.options.length;
       // alert(cnt);
        var opt=id.options;
        var existingValue=hValue.getAttribute('value');
       // alert("existingValue:"+existingValue);
        var existingText=hText.getAttribute('value');
       // alert("existingText:"+existingText);
        var str = existingValue;
        var str1 = existingText;
        //alert(cnt);
        for(i=0;i<cnt;i++)
        {
            if (existingValue.indexOf(opt[i].value) == -1)
            {
                if(str == "")
                    str=opt[i].value+"";
                else
                    str += "," + opt[i].value;
             } 
             if (existingText.indexOf(opt[i].text) == -1)
            {     
               if(str1 == "")
                    str1=opt[i].text+"";
                else
                    str1 += "," + opt[i].text;
            }
        }
        hValue.setAttribute('value',str);
        hText.setAttribute('value',str1);
        //alert('end submitButton'); 
    }
function t_setup() {  
    this.val=t_btnpressed;
     return this;
 }

 var treeValid = new Object;
 treeValid = t_setup();