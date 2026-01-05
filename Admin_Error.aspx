<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Error.aspx.cs" Inherits="Admin_Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABS : The Association of Banks in Singapore</title>
    <link href="<%= Page.ResolveUrl("~/css/mainstyles.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl("~/css/SlideShow.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl("~/css/RatingStyles.css") %>" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            
        }
    </style>
    <script src="http://jqueryjs.googlecode.com/files/jquery-1.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/scripts/BannerJS.js") %>"></script>
</head>

<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="mainbg">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="12">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table width="874" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="46" height="99">
                                <%--        <asp:HyperLink ID="hypHomelink" runat="server" NavigateUrl="~/Default.aspx" Width="147"
                                            Height="99" ImageUrl="~/images/Logo.png" BorderWidth="0" BorderStyle="None"></asp:HyperLink>--%>

                                            <a  href="Administration/Default.aspx"><img  src="images/Logo.png" Width="147" BorderWidth="0" BorderStyle="None" alt="The Association of Banks in Singapore"
                                            Height="99"/></a>
                                    </td>
                                    <td width="741" align="right" valign="bottom">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" class="middle_bg">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="300" valign="top">
                                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: top;">
                                                    <table cellspacing="1" cellpadding="1" width="100%" border="0">
                                                        <tr valign="top">
                                                            <td align="left" colspan="2" style="height:20px;">
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="left" colspan="2" class="style1">
                                                                <b>Page Is Not Available</b>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="left" colspan="2" height="20">
                                                            </td>
                                                        </tr>
                                                        <tr valign="top" align="left">
                                                            <td valign="top" class="style1">
                                                                <table cellspacing="1" cellpadding="1" width="100%" border="0" id="Table2">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                Sorry, the page is not available at this moment.
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="height: 16px">
                                                                                <%--Our System Administrator has just been informed and will rectify the problem as
                                                                                quickly as possible.--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                We apologise for the inconvenience caused, and look forward to having you try again
                                                                                at a later time.
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="height: 60px">
                                                                                <a href="Administration/Default.aspx"><span class="style1" style="color: Red;"><strong>Click Here</strong></span></a><span
                                                                                    class="style1"> to go to Home Page.</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Label ID="lbl_error_log" runat="server" Style="color: #FF0000"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40">
                © 2011 ABS. All Rights Reserved. <a href="#" class="footer_link">banks@abs.org.sg</a>
            </td>
        </tr>
    </table>
    </form>
</body>

</html>
