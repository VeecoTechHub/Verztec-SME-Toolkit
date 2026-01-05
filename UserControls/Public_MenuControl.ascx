<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Public_MenuControl.ascx.cs"
    Inherits="UserControls_Public_MenuControl" %>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<%--<link type="text/css" rel="stylesheet" href="../style.css" />--%>
<%--<link type="text/css" rel="stylesheet" href="../css/TEAC_stylesheet_inn.css" />--%>
<link type="text/css" rel="stylesheet" href="../css/TEAC_stylesheet_inn.css" />
<asp:HiddenField ID="hdnParent" runat="server" />

<script language="JavaScript1.2">

//window.document.title="# RMS #";

function showit(which){
//alert(which);
//alert(submenu[0]);
clear_delayhide()
thecontent=(which==-1)? "" : submenu[which]

//alert(thecontent);
if (document.getElementById||document.all)
menuobj.innerHTML=thecontent
else if (document.layers){
menuobj.document.write(thecontent)
menuobj.document.close()
}
}

function resetit(e){
if (document.all&&!menuobj.contains(e.toElement))
delayhide=setTimeout("showit(-1)",delay_hide)
else if (document.getElementById&&e.currentTarget!= e.relatedTarget&& !contains_ns6(e.currentTarget, e.relatedTarget))
delayhide=setTimeout("showit(-1)",delay_hide)
}

function clear_delayhide(){
if (window.delayhide)
clearTimeout(delayhide)
}

function contains_ns6(a, b) {
while (b.parentNode)
if ((b = b.parentNode) == a)
return true;
return false;
}
// Added Date on 27Aug08 //
function formURL(url,menuid,parentid,mid)
{   

var myRegExp = 'Content.aspx';
var matchPos1 = url.search(myRegExp);
if(matchPos1 != -1)
	url="Content.aspx";
       var  formString = "<form method='post' id='nextpage' name='nextpage' action='"+url+"'>";
            formString = formString + "<input name='menuid' type='hidden' value='" + menuid + "' />";
            formString = formString + "<input name='parentid' type='hidden' value='" + parentid + "' />";
            formString = formString + "<input name='mid' type='hidden' value='" + mid + "' />";
            formString=url + "?parentid=" + parentid + "&menuid=" + menuid + "&mid=" + mid;
            document.write(formString);
            document.nextpage.submit();  
            //http://202.172.218.202/prusg/Content.aspx?parentid=0&menuid=smenuBasics%20of%20investments&mid=318 
            //window.location=formString;  
            

}

function assignCss(link)
{
//alert(link);
//alert(document.getElementById(link).innerHTML);
if(document.getElementById(link)!=null)
document.getElementById(link).className="dropsty-over";
}

//function NavigateSearch(keyword,strProducts,strIds)
//{
//    var strKey=document.getElementById(keyword).value;
//    var splitStrPro=strProducts.split(',');
//    var splitStrIds=strIds.split(',');
//    var Temp='N';
//    for(k=0;k<splitStrPro.length;k++)
//	{
//        if(strKey==splitStrPro[k])
//	    {
//	        Temp='Y';
//	        window.location="ProductDetails.aspx?ProductId="+splitStrIds[k];
//        }
//    }
//    if(Temp=='N')
//	{
//	    alert('No product found With this Model Number.');
//	}

//}
function NavigateSearch(keyword)
{
// if ((event.which == 13) || (event.keyCode == 13)) 
//  {
   
    var strKey=document.getElementById(keyword).value;
    if(strKey=='' || strKey=='Search')
    {
        alert('Please enter search key.');
    }
    else
    {
        window.location.href = 'TopSearch.aspx?SearchText='+strKey;
        
    }
//  }
}
function changeFocus()
{
    if(event.which || event.keyCode)
    {
        if ((event.which == 13) || (event.keyCode == 13)) 
        {
        
            document.getElementById('aSearch').click();
            return true;
        }
     } 
     else {return true}; 
}
function removeText(txtObj)
{
    document.getElementById(txtObj).value='';
}

function goSearch(keyword)
{
     
        if ((event.which == 13) || (event.keyCode == 13)) 
        {
            var strKey=document.getElementById(keyword).value;
            NavigateSearch(keyword);
        } 
       
       
}
//function goSearch(keyword)
//{
// 
////    alert(event.keyCode);
//    
//        if ((event.which == 13) || (event.keyCode == 13)) 
//        {
//            var strKey=document.getElementById(keyword).value;
//            alert(strKey);
////            window.open("TopSearch.aspx?SearchText="+strKey);
//            this.window.location.href="TopSearch.aspx?SearchText="+strKey;
//            return true;
////            if(strKey=='' || strKey=='Search')
////            {
////                alert('Please enter search key.');
////            }
////            else
////            {
////                window.location.href="TopSearch.aspx?SearchText="+strKey;
////            }
//        } 
//        else
//         return false;
//       
//}
</script>

