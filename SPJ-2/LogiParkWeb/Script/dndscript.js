// JScript File

function ob_OnNodeDropOutside(dst)
{
//alert(dst);
    var copy = 2;  
    // add client side code here    
    ob_t2_CopyToControl(dst, copy); // comment this line if you don't want to drop nodes into textboxes
} 
function ob_t2_CopyToControl(oDragableDiv, copy){  
	// copy = 0 : Copy only the moving node to textarea
	// copy = 1 : Copy moving node with child nodes to textarea
	// copy = 2 : Copy only the child nodes to textarea

    if(oDragableDiv == null) {
        return;
    }
  
    iMainTop = calcOffsetY(oDragableDiv);
    iMainLeft = calcOffsetX(oDragableDiv);       
   
	if (iMainTop == 0)
	{
		iMainTop = parseFloat(oDragableDiv.style.top); 
	}
	if (iMainLeft == 0)
	{
		iMainLeft = parseFloat( oDragableDiv.style.left); 
	}
	if(show_with_children == true)
    {
		sTextContainer = oDragableDiv.firstChild.firstChild.firstChild.childNodes[2];    
	}
	else
	{
		sTextContainer = oDragableDiv.firstChild.firstChild.childNodes[2];    		
	}
    
    if(sTextContainer.firstChild.firstChild) {
        sMainText = sTextContainer.firstChild.firstChild.nodeValue;
        sMainId=sTextContainer.id;        
    } else {
        sMainText = sTextContainer.firstChild.nodeValue;
        sMainId=sTextContainer.id;      
    }  
	 
    arrTextBoxes = document.getElementsByTagName('input');
    arrTextAreas = document.getElementsByTagName('textarea');
	arrListBoxes = document.getElementsByTagName('select');
	

    if(arrTextBoxes.length) {
   
        for(var i=0; i<arrTextBoxes.length; i++) {
            if(arrTextBoxes[i].type == 'text') {
                
                iElTop = calcOffsetY(arrTextBoxes[i]);
                iElLeft = calcOffsetX(arrTextBoxes[i]);
                iElBottom = iElTop + arrTextBoxes[i].offsetHeight;
                iElRight = iElLeft + arrTextBoxes[i].offsetWidth;
                
                if((iMainTop > iElTop && iMainTop < iElBottom) && (iMainLeft > iElLeft && iMainLeft < iElRight)) {
                    arrTextBoxes[i].value = sMainText;    
                       
                    return;
                }
            }
        }  
    }
    
    if(arrTextAreas.length) {
       
        for(var i=0; i<arrTextAreas.length; i++) {                           
            iElTop = calcOffsetY(arrTextAreas[i]);
            iElLeft = calcOffsetX(arrTextAreas[i]);
            iElBottom = iElTop + arrTextAreas[i].offsetHeight;
            iElRight = iElLeft + arrTextAreas[i].offsetWidth;
            
            if((iMainTop > iElTop && iMainTop < iElBottom) && (iMainLeft > iElLeft && iMainLeft < iElRight)) {
                var sSpacer = '';
                if(arrTextAreas[i].value != '') {
                    sSpacer = '\r\n';
                }
				try{
					if ( copy == null || copy == 0 )
					{
						// Copy only the moving node to textarea
						arrTextAreas[i].value += sSpacer + sMainText;
					}else{
						arrTextAreas[i].value += sSpacer + ob_t2_GetAllTextNode( sTextContainer, copy != null && copy == 1 );
					}
				}catch(ex){}
                return;
            }            
        }    
    } 
	
	if(arrListBoxes.length) {
        for(var i=0; i<arrListBoxes.length; i++) {
 			iElTop = calcOffsetY(arrListBoxes[i]);
			iElLeft = calcOffsetX(arrListBoxes[i]);
			iElBottom = iElTop + arrListBoxes[i].offsetHeight;
			iElRight = iElLeft + arrListBoxes[i].offsetWidth;
 //alert('arrListBoxes[i].'+i+arrListBoxes[i].options.getAttribute('value'));
//alert(copy);
			if((iMainTop > iElTop && iMainTop < iElBottom) && (iMainLeft > iElLeft && iMainLeft < iElRight)) {
				try{
					if ( copy == null || copy == 0 )
					{
				 // Copy only the moving node to listboxes.
						addOption( arrListBoxes[i], sMainText, sMainId);
					}else{
				 		var options = ob_t2_GetAllTextNode( sTextContainer, copy != null && copy == 1).split('\r\n');
						var options1 = ob_t2_GetAllValueNode( sTextContainer, copy != null && copy == 1).split('\r\n');
						 
						for(var j=0; options != null && j< options.length -1 ; j++){
			
							addOption( arrListBoxes[i], options[j],options1[j]);
						}
					}
					
				}catch(ex){}

				 
				return;
			}
        }  
    }
}
function addOption( listbox, text, value )
{

if (listbox.length >= 1){

   for(var i=0; i<listbox.length; i++) 
  {
  if (listbox.options[i].innerHTML==text )
  {
//alert( text+' is already Present');
text=null;
value =null;

//stop ;
  }
   
  }
  //----------------

	//ob_t2_Remove(value);
	}
if (value == null)
	{
		if ( text == null )
		{
			return;
		}
		value = text;
	}
//------------



	 var optn = document.createElement("OPTION");
	//----------------
	optn.text = text;
	// alert(optn.text);
	optn.value = value;
	listbox.options.add(optn);
	
}
function ob_t2_GetAllTextNode( oNode, withParent)
{  
	var ret = "";
	var sSpacer = '\r\n';
	   
	if ( oNode != null  )
	{
	//alert(ob_hasChildren(oNode) );
		if ( withParent == true )
		{
		if ( ob_hasChildren(oNode)==false )
		{
			if( oNode.firstChild.firstChild) {
				ret += oNode.firstChild.firstChild.nodeValue + sSpacer;
			} else {
				ret += oNode.firstChild.nodeValue + sSpacer;
			}  
			}
		}else{
			withParent = true;
		}

		var childNode = ob_getFirstChildOfNode ( oNode );

		if ( childNode  != null ){
			ret += ob_t2_GetAllTextNode( childNode, withParent );
		}
		var nextNode = ob_getNextSiblingOfNode( oNode ); 
		
		if ( nextNode != null ){
			ret +=ob_t2_GetAllTextNode( nextNode, withParent );
		}
	} 
       
  
return ret;
	 
}
function ob_t2_GetAllValueNode( oNode, withParent){  
	
	var ret1 = "";
	var sSpacer = '\r\n';

	
	if ( oNode != null  )
	{
		 if ( withParent == true )
		{if ( ob_hasChildren(oNode)==false )
		{
			if( oNode.firstChild.firstChild) {			
				ret1+=oNode.id + sSpacer;
			} else {				
				ret1+=oNode.id + sSpacer;
			} } 
		}else{
			withParent = true;
		}
 
		var childNode = ob_getFirstChildOfNode ( oNode );

		if ( childNode  != null ){
			ret1 += ob_t2_GetAllValueNode( childNode, withParent );
		}
		var nextNode = ob_getNextSiblingOfNode( oNode ); 
		
		if ( nextNode != null ){
			ret1 +=ob_t2_GetAllValueNode( nextNode, withParent );
		}
	}
	return ret1;
}