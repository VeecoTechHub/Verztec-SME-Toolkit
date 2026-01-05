<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportsHome.ascx.cs" Inherits="UserControls_ReportsHome"
    EnableViewState="true" %>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
    <tr>
        <td width="750" valign="bottom" class="timesheet_bg">
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
                <tr>
                    <td height="250px">
                        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 220px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/images/logo2.png" 
                                        meta:resourcekey="Image9Resource1" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="blue_36_font">
                        <asp:Label ID="lblCompanyName" runat="server" 
                            meta:resourcekey="lblCompanyNameResource1" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" class="black_22_font">
                        <asp:Label ID="lblFinancial" runat="server" 
                            Text="Financial Diagnostic and Key Analysis Report" 
                            meta:resourcekey="lblFinancialResource1"></asp:Label>
                        <br>
                        <asp:Label ID="lblForThe" runat="server" Text="For the 3 Years ending" 
                            meta:resourcekey="lblForTheResource1"></asp:Label>
                        <asp:Label ID="lblFinancialYr" runat="server" 
                            meta:resourcekey="lblFinancialYrResource1" /><br />
                        <asp:Label ID="lblDated" runat="server" Text="Dated :" 
                            meta:resourcekey="lblDatedResource1"></asp:Label>
                        <asp:Label ID="lblTodayDate" runat="server" 
                            meta:resourcekey="lblTodayDateResource1" />
                        <%--1 Jan 2011 to 31 Dec 2013--%><br />
                    </td>
                </tr>
                <tr>
                    <td height="170">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; color: #394c8c;">
                        <strong style="color: Red;">
                            <asp:Label ID="lblDisclaimer" runat="server" Text="Disclaimer" 
                            meta:resourcekey="lblDisclaimerResource1"></asp:Label>
                        </strong>
                        <br />
                        <asp:Localize ID="locPara1" runat="server" Text="
                      This report is generated based on information entered and is for indicative purposes only.
                       ABS, SPRING Singapore, CBS and Stone Forest Corporate Advisory make no representations or
                        warranties of any kind, whether implied, expressed or statutory, in relation to the content
                         of this report and accept no responsibility or liability whatsoever with regard to the 
                         completeness, accuracy and reliability of this report. Please seek professional advice
                          before making any business decision based on this report." 
                            meta:resourcekey="locPara1Resource1"></asp:Localize>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td height="85">
                        <table style="width: 90%;" align="center" border="0" cellspacing="1" cellpadding="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblAProjectby" runat="server" Text="A Project by:" 
                                        meta:resourcekey="lblAProjectbyResource1"></asp:Label>
                                   
                                </td>
                                <td style="width: 60px; text-align: center;">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="4">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lblSupportedby" runat="server" Text="Supported by:" 
                                        meta:resourcekey="lblSupportedbyResource1"></asp:Label>
                                    
                                </td>
                                <td align="left">
                                <asp:Label ID="lblContentPartner" runat="server" Text="Content Partner:" 
                                        meta:resourcekey="lblContentPartnerResource1"></asp:Label>
                                    
                                </td>
                                <td style="width: 50%;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%;">
                                    &nbsp;
                                </td>
                                <td align="center" valign="bottom" class="style2">
                                    <a href="http://www.abs.org.sg/cms/index.php" target="_blank">
                                        <img src="<%= Page.ResolveUrl("~/images/AdminLogin_Images/ABS_logo.png") %>" alt=""
                                            border="0" width="142px" height="59px" align="bottom" />
                                    </a>
                                    
                                </td>
                                <td style="width: 30px; text-align: center;">
                                </td>
                                <td width="123" align="left" valign="bottom">
                                    <a href="http://www.spring.gov.sg/Pages/Homepage.aspx" target="_blank">
                                        <img src="<%= Page.ResolveUrl("~/images/logo-spring.png") %>" alt="" width="130px"
                                            height="53px" border="0" align="bottom" />
                                    </a>
                                </td>
                                <td style="width: 50px; text-align: center;">
                                <asp:Label ID="lbland" runat="server" Text="and" meta:resourcekey="lblandResource1"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td width="123" align="left" valign="bottom">
                                    <a href="http://www.creditbureau.com.sg/" target="_blank">
                                        <img src="<%= Page.ResolveUrl("~/images/cbslogo.gif") %>" alt="" width="102px" height="53px"
                                            border="0" align="bottom" />
                                    </a>
                                </td>
                                <td style="width: 50px; text-align: center;">
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="left" valign="middle">
                                    <a href="http://www.rsmchiolim.com.sg/" target="_blank">
                                        <img src="<%= Page.ResolveUrl("~/images/logo-rsm.png") %>" alt="" width="199px" height="53px"
                                            border="0" align="bottom" />
                                    </a>
                                </td>
                                <td style="width: 50%;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="center" style="padding-top: 5px; font-size: 9pt;">
                    <asp:Label ID="lblCopyright" runat="server" Text="Copyright © 2012." 
                            meta:resourcekey="lblCopyrightResource1"></asp:Label>
                            
                         <a href="http://www.abs.org.sg/cms/index.php" target="_blank" class="footer_link">
                             <asp:Label ID="lblABS" runat="server" 
                            Text="The Association of Banks in Singapore" meta:resourcekey="lblABSResource1"></asp:Label>
                            </a>.
                            
                            <asp:Label ID="lblAllrightsreserved" runat="server" 
                            Text="All rights reserved." meta:resourcekey="lblAllrightsreservedResource1"></asp:Label>
                              <a href="#" class="footer_link" 
                                onclick="javascript:return mypopup('<%= Page.ResolveUrl("~/TermsConditions.aspx") %>');">
                                <asp:Label ID="lblTerms" runat="server" 
                            Text="Terms of Use and Privacy Notice." meta:resourcekey="lblTermsResource1"></asp:Label>
                                </a>
                    </td>
                </tr>
                <%--<tr>
                    <td height="80px">
                        &nbsp;
                    </td>
                </tr>--%>
            </table>
        </td>
    </tr>
</table>
