
// This set of functions are for processing the key press event
// Used to restrict input on numerics and pure textual fields

 function container_validation(CntNo) {
//alert(CntNo);
   var m_tot = 0;
	var	m_i= 1;
    var	m_ch ="";
	var	m_val= 0;
	var	m_Alpha = 0;
    var m_dgt = 0;

if( (ltrim(rtrim(CntNo))).length < 11)
{
   //alert('Less Than 11 Characters.');
    return ('Less Than 11 Characters.');
   }
   
   for( m_i =1 ;m_i<=10;m_i++)
  {
     m_ch = CntNo.substr( m_i-1, 1);
    
     if (m_i< 5 )
			{
			      if( m_ch == 'A')
			                  m_val = 10;
			      else if( m_ch == 'B')
			                  m_val = 12;
			      else if ( m_ch == 'C')
			                  m_val = 13;
			      else if (m_ch == 'D')
			                  m_val = 14;
			      else if ( m_ch == 'E' )
			                  m_val = 15;
			      else if ( m_ch == 'F' )
			                  m_val = 16;
			      else if ( m_ch == 'G' )
			                  m_val = 17;
			      else if ( m_ch == 'H' )
			                  m_val = 18;
			      else if ( m_ch == 'I' )
			                  m_val = 19;
			      else if ( m_ch == 'J' )
			                  m_val = 20;
			      else if ( m_ch == 'K' )
			                  m_val = 21;
			      else if ( m_ch == 'L' )
			                  m_val = 23;
			      else if ( m_ch == 'M' )
			                  m_val = 24;
			      else if ( m_ch == 'N' )
			                  m_val = 25;
			      else if ( m_ch == 'O' )
			                  m_val = 26;
			      else if ( m_ch == 'P' )
			                  m_val = 27;
			      else if ( m_ch == 'Q' )
			                  m_val = 28;
			      else if ( m_ch == 'R' )
			                  m_val = 29;
			      else if ( m_ch == 'S' )
			                  m_val = 30;
			      else if ( m_ch == 'T' )
			                  m_val = 31;
			      else if ( m_ch == 'U' )
			                  m_val = 32;
			      else if ( m_ch == 'V' )
			                  m_val = 34;
			      else if ( m_ch == 'W' )
			                  m_val = 35;
			      else if ( m_ch == 'X' )
			                  m_val = 36;
			      else if ( m_ch == 'Y' )
			                  m_val = 37;
			      else if ( m_ch == 'Z' )
			                  m_val = 38;
			      
		 }
		 else 
		 {     
		 if (m_ch != '1' && m_ch !=  '2' && m_ch != '4' && m_ch != '3'  && m_ch != '5'  && m_ch !='6'  && m_ch !='7' && m_ch != '8' && m_ch != '9' && m_ch !='0')
		 {
		 			//alert((m_i+1) + ' th letter ' + m_ch + ' is invalid' );
		 			return((m_i+1) + ' th letter ' + m_ch + ' is invalid');
		 			}
		 		m_val = parseInt(m_ch);
		 			//alert(m_ch + ":" +m_val);	
		 }            
             m_tot = m_tot + (m_val * (Math.pow(2 , (m_i - 1))));
             //alert(m_tot);
       }
  
          m_dgt = m_tot % 11;
          if (m_dgt == 10 )
             m_dgt = 0;
           
     
     if ((m_dgt).toString(16) != CntNo.substr( 10, 1))
     {
				//alert('Invalid Container Number');				
				return('Invalid Container Number');
	 }
     else
     { return('True');
       //alert('Valid Container Number'); 
       }
 // alert('loop completed');  
}
function trim(stringToTrim) {
	return stringToTrim.replace(/^\s+|\s+$/g,"");
}
function ltrim(stringToTrim) {
	return stringToTrim.replace(/^\s+/,"");
}
function rtrim(stringToTrim) {
	return stringToTrim.replace(/\s+$/,"");
}

 
