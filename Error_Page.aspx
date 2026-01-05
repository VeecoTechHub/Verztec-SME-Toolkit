<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error_Page.aspx.cs" Inherits="Error_Page" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
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
    <script src="https://jqueryjs.googlecode.com/files/jquery-1.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/scripts/BannerJS.js") %>"></script>
     <script type="text/javascript">
         function mypopup(url) {
             params = 'width=830';
             params += ', height=420, ';
             params += 'status=no, location=no,directories=no,toolbar=no,menubar=no,scrollbars=yes ,minimize=no,copyhistory=no,status=no,titlebar=no, left=90, top=70, titlebar=no, menubar=no, resizable=no';


             newwin = window.open(url, 'windowname4', params);
             if (window.focus) { newwin.focus() }
             return false;
         }
</script>
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
                                        <asp:HyperLink ID="hypHomelink" runat="server" NavigateUrl="~/Default.aspx" 
                                            Width="411px" Height="99px" ImageUrl="~/images/logo2.png" BorderWidth="0px" 
                                            BorderStyle="None" meta:resourcekey="hypHomelinkResource1"></asp:HyperLink>
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
                                                                <b>
                                                                    <asp:Label ID="lblPage" runat="server" Text="Page Is Not Available" 
                                                                    meta:resourcekey="lblPageResource1"></asp:Label>
                                                                </b>
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
                                                                              <asp:Label ID="lblSorry" runat="server" 
                                                                                    Text="Sorry, the page is not available at this moment." 
                                                                                    meta:resourcekey="lblSorryResource1"></asp:Label>
                                                                                
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
                                                                              <asp:Label ID="lblWeApologise" runat="server" Text=" We apologise for the inconvenience caused, and look forward to having you try again
                                                                                at a later time." meta:resourcekey="lblWeApologiseResource1"></asp:Label>
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="height: 60px">
                                                                                <a href="Default.aspx"><span class="style1" style="color: Red;"><strong>
                                                                                     <asp:Label ID="lblClickHere" runat="server" Text="Click Here" 
                                                                                    meta:resourcekey="lblClickHereResource1"></asp:Label>
                                                                                </strong></span></a><span
                                                                                    class="style1">
                                                                                      <asp:Label ID="lblTogo" runat="server" Text="to go to Home Page." 
                                                                                    meta:resourcekey="lblTogoResource1"></asp:Label>
                                                                                     </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Label ID="lbl_error_log" runat="server" Style="color: #FF0000" 
                                                                                    meta:resourcekey="lbl_error_logResource1"></asp:Label>
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
                                                <td style="height:180px">
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
            <td height="85" valign="bottom" width="874">
                <table width="874" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td  style="width:50%;">&nbsp;</td>
                        <td align="left" class="style1">
                          <asp:Label ID="lblAProject" runat="server" Text="A Project by:" 
                                meta:resourcekey="lblAProjectResource1"></asp:Label>
                            
                        </td>
                        <td style="width: 60px; text-align: center;">&nbsp;
                        </td>
                        <td align="left" colspan="4">
                            &nbsp;&nbsp;
                               <asp:Label ID="lblSupport" runat="server" Text="Supported by:" 
                                meta:resourcekey="lblSupportResource1"></asp:Label>
                           
                        </td>
                         <td align="left" style="width:20px">
                          <asp:Label ID="lblContent" runat="server" Text="Content Partner:" 
                                 meta:resourcekey="lblContentResource1"></asp:Label>
                            
                        </td>
                          <td  style="width:50%;">&nbsp;</td>
                    </tr>
                    <tr>
                         <td  style="width:50%;">&nbsp;</td>
                        <td align="center" valign="bottom" class="style2">
                            <a href="https://www.abs.org.sg/cms/index.php" target="_blank">

                                <img src="<%= Page.ResolveUrl("~/images/logo-ABS.jpg") %>" alt="" border="0" width="140px"
                                    height="53px" align="bottom" />

                              
                            </a>
                        </td>
                        <td style="width: 30px; text-align: center;">
                        </td>
                        <td width="123" align="left" valign="bottom">
                            <a href="https://www.spring.gov.sg/Pages/Homepage.aspx" target="_blank">
                                <img src="<%= Page.ResolveUrl("~/images/logo-spring.jpg") %>" alt="" width="130px"
                                    height="53px" border="0" align="bottom" />
                            </a>
                        </td>
                        <td style="width: 50px; text-align: center;">
                            and&nbsp;&nbsp;&nbsp;
                        </td>
                         <td width="123" align="left" valign="bottom">
                            <a href="https://www.creditbureau.com.sg/" target="_blank">
                                <img src="<%= Page.ResolveUrl("~/images/cbslogo.gif") %>" alt="" width="102px"
                                    height="53px" border="0" align="bottom" />
                            </a>
                        </td>
                      <td style="width: 50px; text-align: center;">
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="left" valign="middle">
                            <a href="https://www.rsmchiolim.com.sg/" target="_blank">
                                <img src="<%= Page.ResolveUrl("~/images/logo-rsm.jpg") %>" alt="" width="199px" height="53px"
                                    border="0" align="bottom" />
                            </a>
                        </td>
                          <td  style="width:50%;">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="40" align="center">
             <asp:Label ID="lblCopy" runat="server" Text="Copyright © 2012." 
                    meta:resourcekey="lblCopyResource1"></asp:Label>
                <a href="https://www.abs.org.sg/cms/index.php" target="_blank" class="footer_link">
                   <asp:Label ID="lblThe" runat="server" 
                    Text="The Association of Banks in Singapore" meta:resourcekey="lblTheResource1"></asp:Label>
                </a>.
                  <asp:Label ID="lblAllRights" runat="server" Text="All rights reserved." 
                    meta:resourcekey="lblAllRightsResource1"></asp:Label>
                 
                <a href="#" class="footer_link" onclick="javascript:return mypopup('<%= Page.ResolveUrl("~/TermsConditions.aspx") %>');">
                 <asp:Label ID="lblTerms" runat="server" 
                    Text="Terms of Use and Privacy Notice." meta:resourcekey="lblTermsResource1"></asp:Label>
                </a>
             
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
