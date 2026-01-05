<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="faq.aspx.cs" Inherits="Public_faq" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="middle_bg">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="33" valign="top" class="faq_title">
                                        <div>
                                            <asp:Label ID="lblHeading" runat="server" Text="FAQs & Online Help" 
                                                meta:resourcekey="lblHeadingResource1"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="300" valign="top">
                                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="203">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="faq">
                                                        <ul>
                                                            <li><a href="#one">
                                                                <asp:Label ID="lblq1" runat="server" 
                                                                    Text="How can I benefit from the SME Financial Management Toolkit?" 
                                                                    meta:resourcekey="lblq1Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#two">
                                                                <asp:Label ID="lblq2" runat="server" Text="How can I get help if I need guidance on the SME Financial Management
                                                                Toolkit?" meta:resourcekey="lblq2Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#three">
                                                                <asp:Label ID="lblq3" runat="server" Text=" How can I use the report generated from the Financial Modeling
                                                                in my Business Plan?" meta:resourcekey="lblq3Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#four">
                                                                <asp:Label ID="lblq4" runat="server" 
                                                                    Text="How do I save the information before I logout?" 
                                                                    meta:resourcekey="lblq4Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#five">
                                                                <asp:Label ID="lblq5" runat="server" Text=" Can I generate and save more than 1 set of report with different
                                                                scenarios using the Financial Modeling tool?" 
                                                                    meta:resourcekey="lblq5Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#six">
                                                                <asp:Label ID="lblq6" runat="server" 
                                                                    Text="Will the data of my business in the Financial Modeling be kept confidential?" 
                                                                    meta:resourcekey="lblq6Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#seven">
                                                                <asp:Label ID="lblq7" runat="server" 
                                                                    Text="Can I create more than one user account with the same email address?" 
                                                                    meta:resourcekey="lblq7Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#eight">
                                                                <asp:Label ID="lblq8" runat="server" Text="How do I report a bug?" 
                                                                    meta:resourcekey="lblq8Resource1"></asp:Label>
                                                            </a></li>
                                                            <li><a href="#nine">
                                                                <asp:Label ID="lblq9" runat="server" 
                                                                    Text="How I can provide my feedback on the SME Financial Management Toolkit?" 
                                                                    meta:resourcekey="lblq9Resource1"></asp:Label>
                                                            </a></li>
                                                        </ul>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="4%" align="center">
                                                                <strong>1</strong>
                                                            </td>
                                                            <td width="96%">
                                                                <a name="one" id="one"></a><strong>
                                                                  <asp:Label ID="lblaq1" runat="server" Text=" How can I benefit from the SME Financial Management
                                                                    Toolkit?" meta:resourcekey="lblaq1Resource1"></asp:Label>
                                                               </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                           <asp:Localize ID="locPara1" runat="server" Text="
                                                                The SME Financial Management Toolkit will provide you with a platform to enhance
                                                                your knowledge and capabilities in financial management. It comes with basic tools
                                                                for you to conduct self-assessment on the financial well-being of your business
                                                                and a financial modeling tool to help you ascertain the funding requirements for
                                                                your business growth. There are templates and guides to help you in drawing up your
                                                                business plan and implement systems and controls." 
                                                                    meta:resourcekey="locPara1Resource1"></asp:Localize>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <strong>2</strong>
                                                            </td>
                                                            <td>
                                                                <a name="two" id="two"></a><strong>
                                                                  <asp:Label ID="lblaq2" runat="server" Text=" How can I get help if I need guidance on the SME
                                                                    Financial Management Toolkit?" meta:resourcekey="lblaq2Resource1"></asp:Label>

                                                               </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                            <asp:Label ID="lblLink" runat="server" meta:resourcekey="lblLinkResource1"></asp:Label>

                                                              <%--  You are encouraged to sign up the one-to-one advisory session for a one hour free
                                                                consultation or click on "Learn More" to register yourself for the upcoming workshops
                                                                and seminars. If you need guidance on the use of the toolkit, you can call our Financial
                                                                Management Advisor, Mr Lin Zhi Xun at 6513 8375 or email him at <a style="text-decoration: underline;"
                                                                    href="mailto:zhixun.lin@creditbureau.com.sg">zhixun.lin@creditbureau.com.sg</a>.
                                                                You can also approach any one of the Enterprise Development Centres for help.--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <strong>3</strong>
                                                            </td>
                                                            <td>
                                                                <a name="three" id="three"></a><strong>
                                                                  <asp:Label ID="lblaq3" runat="server" Text="How can I use the report generated from the Financial
                                                                    Modeling in my Business Plan?" meta:resourcekey="lblaq3Resource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                            <asp:Localize ID="locPara2" runat="server" Text="
                                                                Your business plan is not complete if there is no financial forecast to show how
                                                                your business will fare if you deliver the results as planned. The financial modeling
                                                                Tool helps you in converting your business plan into financial forecast. You will
                                                                be able to ascertain the working capital required to fund your business growth.
                                                                Information extracted from the report, (income statement and cash flow projections)
                                                                can be incorporated into the business plan. The plan can then be presented to the
                                                                Banks or Financial Institutions for loan applications; or to your investors to obtain
                                                                equity funding." meta:resourcekey="locPara2Resource1"></asp:Localize>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" valign="top">
                                                                <strong>4</strong>
                                                            </td>
                                                            <td>
                                                                <a name="four" id="four"></a><strong>
                                                                  <asp:Label ID="lblaq4" runat="server" 
                                                                    Text="How do I save the information before I logout?" 
                                                                    meta:resourcekey="lblaq4Resource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                               <asp:Label ID="lblQuote" runat="server" meta:resourcekey="lblQuoteResource1"></asp:Label>

                                                              <%--  All data in the Business Profiling and Capabilities Profiling will be saved automatically
                                                                once you enter the "Processed This" button. For the Financial Modeling, you have
                                                                to click the "Save and Next" button after you have entered the data in each section.--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" valign="top">
                                                                <strong>5</strong>
                                                            </td>
                                                            <td>
                                                                <a name="five" id="five"></a><strong>
                                                                  <asp:Label ID="lblaq5" runat="server" Text="Can I generate and save more than 1 set of report
                                                                    with different scenarios using the Financial Modeling tool?" 
                                                                    meta:resourcekey="lblaq5Resource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                                <asp:Label ID="lblQuote1" runat="server" meta:resourcekey="lblQuote1Resource1"></asp:Label>
                                                          <%--      For every registered user, only one set of data can be saved at any point in time.
                                                                You can complete the 6 sections of the Financial Modeling, generate, download and
                                                                save the Financial Diagnostic and Key Analysis Report (the "Report") on your own
                                                                hard drive. After you have confirmed that the report is properly saved, you can
                                                                go back to the respective sections of the Financial Modeling to vary the assumptions
                                                                by overwriting the data. You can generate another set of report based on the new
                                                                set of data. This can be repeated as many times as you wish.--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <strong>6</strong>
                                                            </td>
                                                            <td>
                                                                <a name="six" id="six"></a><strong>
                                                                  <asp:Label ID="lblaq6" runat="server" Text="Will the data of my business in the Financial Modeling
                                                                    be kept confidential?" meta:resourcekey="lblaq6Resource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                             <asp:Label ID="lblText" runat="server" Text="Only the registered users have access to the SME Financial Management Toolkit and
                                                                their own data. The information is NOT shared with any other 3rd party." 
                                                                    meta:resourcekey="lblTextResource1"></asp:Label>
                                                               
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <strong>7</strong>
                                                            </td>
                                                            <td>
                                                                <a name="seven" id="seven"></a><strong>
                                                                  <asp:Label ID="lblaq7" runat="server" Text="Can I create more than one user account with
                                                                    the same email address?" meta:resourcekey="lblaq7Resource1"></asp:Label>

                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: justify">
                                                             <asp:Label ID="lblText2" runat="server" 
                                                                    Text="
                                                                The email address is the login ID. Each email address is one unique user account
                                                                and you will not be able to create more than one user account with the same email
                                                                address. However, you can create multiple logins with different email addresses." 
                                                                    meta:resourcekey="lblText2Resource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <strong>8</strong>
                                                            </td>
                                                            <td>
                                                                <a name="eight" id="eight"></a><strong>
                                                                    <asp:Label ID="lblaq8" runat="server" Text="How do I report a bug?" 
                                                                    meta:resourcekey="lblaq8Resource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                              <asp:Label ID="lblLink2" runat="server" meta:resourcekey="lblLink2Resource1"></asp:Label>
                                                           <%--     If you encounter a bug, please report by sending an e-mail to <a href='mailto:enquiries@abs.org.sg'>
                                                                    enquiries@abs.org.sg</a>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <strong>9</strong>
                                                            </td>
                                                            <td>
                                                                <a name="nine" id="nine"></a><strong>
                                                                 <asp:Label ID="lblaq9" runat="server" Text="How I can provide my feedback on the SME Financial
                                                                    Management Toolkit?" meta:resourcekey="lblaq9Resource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                              <asp:Label ID="lblLink3" runat="server" meta:resourcekey="lblLink3Resource1"></asp:Label>
                                                            <%--    If you have any suggestion that you would like to share with us to improve the toolkit,
                                                                you can email to us at <a href='mailto:FMtoolkit@stoneforest.com.sg'>FMtoolkit@stoneforest.com.sg</a>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <a href="#top">
                                                        <img src="../images/top.png" alt="" width="24" height="21" border="0" /></a>
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
</asp:Content>
