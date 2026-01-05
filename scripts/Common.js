//This method returns output with commas and if its a -ve no, displays with brackets eg (122)
//commaLoc means, after howmany digits need to display comma
function includeComma(val, commaLoc) {

    val = removeSplCharacters(val);
    var inc = 0;
    var temp = '';
    var limit = 0;
    var len = val.length;

    //If its -ve no. reduce len by 1. Other wise, comma formatting will not be proper. eg:-,222,222
    if (val < 0) {
        limit = 1;
    }

    for (j = len - 1; j >= limit; j--) {

        if (temp == '') {
            temp = val.charAt(j);
        }
        else {
            if (inc == commaLoc) {
                temp = temp + ',' + val.charAt(j);
                inc = 0;
            }
            else {
                temp = temp + val.charAt(j);
            }
        }
        inc = inc + 1;
    }

    //If limit=1, indicates its a -ve no. So, add a -ve sign
    if (limit == 1) {
        temp = ')' + temp + '(';
    }
    temp = reverse(temp);

    return temp;

}


function reverse(s) {

    return s.split("").reverse().join("");
}

function removeSplCharacters(txtValue) {
    var temp = txtValue.replace(/[^a-zA-Z 0-9-]+/g, '');
    return temp;
}

//Replaces braces to a -ve value
function replaceBracketsWithNegativeSign(val) {

    var returnVal;

    if (val.charAt(0) == '(' && val.charAt(val.length-1) == ')') {
        returnVal = removeSplCharacters(val);
        returnVal = "-" + returnVal;
        return returnVal;
    }
    else {
        return val;
    
    }
 }


 //For Textbox value validaiton
 function checkFormat(val) {
     var i;
//     val=document.getElementById(txtboxval).value;
     val = val.toString();
     var char = val.charAt(0);
     if (char == "-") {

         var char_2 = val.charAt(1);
         if (char_2 == "(") {
             if (val.charAt(val.length - 1) != ")") {
                 return false;
             }
             else {
                 var chars = val.substring(2, val.length - 1);
                 for (i = 0; i < chars.length; i++) {
                     var c = chars.charAt(i);
                     if (c == ",") {
                     }
                     else if (isNaN(c)) {
                         return false;
                     }
                 }

             }
         }
         else if (!isNaN(char_2)) {
             for (i = 1; i < val.length; i++) {
                 var c = val.charAt(i);
                 if (c == ",") {
                 }
                 else if (isNaN(c)) {
                     return false;
                 }
             }

         }
         else {
             return false;
         }
     }
     else if (char == "(") {
         if (val.charAt(val.length - 1) != ")") {
             return false;
         }
         else {
             var chars = val.substring(1, val.length - 1);
             for (i = 0; i < chars.length; i++) {
                 var c = chars.charAt(i);
                 if (c == ",") {
                 }
                 else if (isNaN(c)) {
                     return false;
                 }
             }

         }

     }
     else if (!isNaN(char)) {

         for (i = 0; i < val.length; i++) {
             var c = val.charAt(i);
             if (c == ",") {
             }
             else if (isNaN(c)) {
                 return false;
             }
         }

     }
     else {
         return false;
     }
     return true;
 }
 
