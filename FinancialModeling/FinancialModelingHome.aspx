<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="FinancialModelingHome.aspx.cs" Inherits="FinancialModeling_FinancialModelingHome"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="http://jqueryjs.googlecode.com/files/jquery-1.3.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('input[type="text"]').addClass("idleField");
            $('input[type="text"]').focus(function() {
                $(this).removeClass("idleField").addClass("focusField");
                if (this.value == this.defaultValue) {
                    this.value = '';
                }
                if (this.value != this.defaultValue) {
                    this.select();
                }
            });
            $('input[type="text"]').blur(function() {
                $(this).removeClass("focusField").addClass("idleField");
                if ($.trim(this.value) == '') {
                    this.value = (this.defaultValue ? this.defaultValue : '');
                }
            });
        });			
    </script>

    <script language="JavaScript">
<!--
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }


        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }
//-->
    </script>

    <script type="text/javascript">

        //
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
                //              document.body.scroll = "no" 
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
                //              document.body.scroll = "yes" 
            }
        }
    </script>

    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="34" valign="top" class="sme_title">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="FINANCIAL MANAGEMENT TOOLKIT HOME PAGE"
                                meta:resourcekey="lblHeadingResource1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellspacing="0" cellpadding="0" width="898">
                            <tr>
                                <td width="898" align="center">
                                    <table width="898">
                                        <tr>
                                            <td class="Reportsbg">
                                                <table align="center" align="center">
                                                    <tr>
                                                        <td width="60px">
                                                            &nbsp;
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgbtnStatements" ToolTip="Statements" ImageUrl="~/images/icon-statements.png" 
                                                                runat="server" OnClick="imgbtnStatements_Click" meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                            <asp:Label ID="lblStatements" runat="server" Text="Statements" meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                runat="server" OnClick="imgbtnHome_Click" meta:resourcekey="imgbtnHomeResource1" />
                                                            <br />
                                                            <asp:Label ID="lblHome" runat="server" Text="Home" meta:resourcekey="lblHomeResource1"></asp:Label>
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" OnClientClick="return reportalert();"
                                                                ImageUrl="~/images/icon-report.png" runat="server" OnClick="imgBtnGenerateReport_Click"
                                                                meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                            <asp:Label ID="lblReport" runat="server" Text="Report" meta:resourcekey="lblReportResource1"></asp:Label>
                                                        </td>
                                                        <td style="width: 90px" align="center">
                                                            <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                runat="server" PostBackUrl="~/FinancialModeling/Help.aspx" meta:resourcekey="imgBtnHelpResource1" /><br />
                                                            <asp:Label ID="lblHelp" runat="server" Text="Help" meta:resourcekey="lblHelpResource1"></asp:Label>
                                                        </td>
                                                        <td style="width: 60px">
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
                <tr>
                    <td valign="top">
                        <table width="840" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="14">
                                    <asp:Label ID="lblImgURL1" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL1Resource1"></asp:Label>
                                    <asp:Label ID="lblImgURL2" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL2Resource1"></asp:Label>
                                    <asp:Label ID="lblImgURL3" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL3Resource1"></asp:Label>
                                    <asp:Label ID="lblImgURL4" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL4Resource1"></asp:Label>
                                    <asp:Label ID="lblImgURL5" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL5Resource1"></asp:Label>
                                          <asp:Label ID="lblImgURL6" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL6Resource1" ></asp:Label>
                                          <asp:Label ID="lblImgURL7" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL7Resource1" ></asp:Label>
                                             <asp:Label ID="lblImgURL8" runat="server" Visible="False" 
                                        meta:resourcekey="lblImgURL8Resource1" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Localize ID="locPara1" runat="server" Text="The diagram below shows the flow of funds between your business and various parties.
                                    Prior to any analysis, you need to enter the financial information of your business.
                                    Click on the numbers on the diagram below to start, and we suggest that you move
                                    in sequence."
                                        meta:resourcekey="locPara1Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="lblContinue" runat="server" Text="Click on the numbers to continue."
                                                        meta:resourcekey="lblContinueResource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td align="right" style="padding-right: 20px;">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="dynamicTxt">
                                        <asp:Label ID="lblCompanyName" runat="server" meta:resourcekey="lblCompanyNameResource1"></asp:Label>
                                    </div>
                                    <table width="605" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="605" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="291">
                                                            <img src="../images/stocks.jpg" width="291" height="211" border="0" 
                                                                usemap="#Map2" runat="server"
                                                                id="imgStocks" />
                                                                
                                                        </td>
                                                        <td width="313">
                                                            <img src="../images/2.jpg" alt="" width="313" height="211" border="0" usemap="#Map3"  runat="server" id="imgtwo" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="605" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="388">
                                                            <img src="../images/3.jpg" alt="" width="388" height="315" border="0" usemap="#Map" runat="server" id="imgthree" />
                                                        </td>
                                                        <td valign="top">
                                                            <table width="216" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../images/Capital.jpg" width="216" height="99" id="imgCapital" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <img src="../images/Loan.jpg" width="216" height="216" border="0" usemap="#Map4"
                                                                            id="imgLoan" runat="server" />
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
                            <tr style="display: none">
                                <td align="center">
                                    &nbsp;
                                    <asp:Label ID="lblConfirm" runat="server" Text="Generate report takes few seconds. If you want to continue, click Ok. Other wise click Cancel."
                                        meta:resourcekey="lblConfirmResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <map name="Map2" id="Map2">
                <area shape="circle" coords="118,115,16" href="Sec_CostOfSales.aspx" />
            </map>
            <map name="Map" id="Map">
                <area shape="circle" coords="26, 38, 16" href="Sec_Sales.aspx" />
                <area shape="circle" coords="344, 288, 16" href="CapitalExpenditure.aspx" />
                <area shape="circle" coords="57, 254, 16" href="Taxation.aspx" />
            </map>
            <map name="Map3" id="Map3">
                <area shape="circle" coords="128,96,16" href="OperatingExpenses.aspx" />
            </map>
            <map name="Map4" id="Map4">
                <area shape="circle" coords="182,18,17" href="FundingMain.aspx" />
            </map>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="UpdateProgress">
        <ProgressTemplate>
            <div>
                <asp:Image ID="Image1" ImageUrl="~/images/progressbar.gif" AlternateText="Processing"
                    runat="server" meta:resourcekey="Image1Resource1" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" DynamicServicePath=""
        Enabled="True" />

    <script type="text/javascript">
        function reportalert() {
            var lblConfirm = document.getElementById('<%=lblConfirm.ClientID%>').innerHTML
            return confirm(lblConfirm);
        }
    </script>



</asp:Content>
