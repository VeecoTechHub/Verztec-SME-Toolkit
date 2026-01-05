<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administration_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>ABS : The Association of Banks in Singapore</title>
    <link href="<%= Page.ResolveUrl("~/css/LoginStyle.css") %>" rel="stylesheet" type="text/css" />
    

</head>
<body>
    <form id="form1" runat="server">
   <table width="1002" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="16" class="left_bg"></td>
    <td width="970" valign="top"><table width="970" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="10" class="blue_bg"></td>
      </tr>
      <tr>
        <td height="100" class="topbg"><table width="930" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="101">
            <img  src="../images/logo2.png" width="411" height="99" alt="" />
            <%--<asp:HyperLink ID="hypHomelink" runat="server" NavigateUrl="~/Default.aspx" Width="411" Height="99" ImageUrl="~/images/logo2.png" BorderWidth="0" BorderStyle="None"></asp:HyperLink>--%>
            </td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td><table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="1"></td>
          </tr>
          <tr>
            <td height="498" valign="top" class="login_content_bg"><table width="401" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td height="54" valign="bottom"><table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td><img src="../images/AdminLogin_Images/MemberLogin.png" width="148" height="22" alt="" /></td>
                    </tr>
                  </table></td>
                </tr>
              <tr>
                <td height="290" valign="top" class="new_loginbg">
                
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="50" valign="bottom" style="padding-left:80px">&nbsp;
                 <asp:Label ID="Lblerror" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <td><table width="231" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr>
                        <td height="20">User name :</td>
                      </tr>
                      <tr>
                        <td align="center" class="New_login_txtfiled_bg">
                          <asp:TextBox ID="txtUserId" CssClass="New_login_txtfiled_bg_1" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvuserid" runat="server" ControlToValidate="txtUserId"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                      </tr>
                      <tr>
                        <td height="10"></td>
                      </tr>
                      <tr>
                        <td height="20">Password :</td>
                      </tr>
                      <tr>
                        <td align="center" class="New_login_txtfiled_bg">
                         <asp:TextBox ID="txtPwd" runat="server" CssClass="New_login_txtfiled_bg_1" TextMode="Password"
                                                           ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPwd"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                       </td>
                      </tr>
                      <tr>
                        <td height="15" align="center"></td>
                      </tr>
                      <tr>
                        <td><%--<a href="#">
                        
                        <img src="../images/AdminLogin_Images/login.jpg" alt="" width="80" height="30" border="0" /></a>--%>
                          <asp:ImageButton ID="btnSubmit" runat="server" 
                                ImageUrl="~/images/AdminLogin_Images/login.jpg" onclick="btnSubmit_Click" 
                                                                        />
                        
                        </td>
                      </tr>
                    </table></td>
                  </tr>
                </table>
                    
              
                </td>
                </tr>
           
              </table></td>
          </tr>
            <tr>
            <td height="1">
          
            </td>
          </tr>
          </table></td>
      </tr>
    </table></td>
    <td width="16" class="right_bg"></td>
  </tr>
</table>

    </form>
</body>
</html>
