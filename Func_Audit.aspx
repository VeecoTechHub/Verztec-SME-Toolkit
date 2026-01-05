<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Func_Audit.aspx.cs" Inherits="Func_Audit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Function Audit</title>
     <script language="javascript" type="text/javascript">

         function postForEditMenu1(url, fid, token) {
             document.frm2.action = url;
             document.frm2.fid.value = fid;
             document.frm2.token.value = token;
             document.frm2.submit();
         }
    </script>
</head>
<body>
 <div style="visibility: hidden; position: absolute; height: 0px">
        <form name="frm2" method="post">
        <input type="hidden" value='<%=Request["fid"]%>' name="fid">
        <input type="hidden" value='<%=Request["token"]%>' name="token">
        </form>
    </div>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
