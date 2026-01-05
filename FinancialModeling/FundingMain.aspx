<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="FundingMain.aspx.cs" Inherits="FinancialModeling_FundingMain"
    MaintainScrollPositionOnPostback="true" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="33" valign="top" class="sme_title">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="FINANCIAL MANAGEMENT TOOLKIT" 
                                meta:resourcekey="lblHeadingResource1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="300" valign="top">
                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="160" class="titleBar">
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td width="100%" align="center" colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="Reportsbg">
                                                            <table align="center" align="center">
                                                                <tr>
                                                                    <td width="60px">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgbtnStatements" ToolTip="Statements" ImageUrl="~/images/icon-statements.png"
                                                                            runat="server" OnClick="imgbtnStatements_Click" 
                                                                            OnClientClick="return SaveData();" 
                                                                            meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                                        <asp:Label ID="lblStatements" runat="server" Text="Statements" 
                                                                            meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                            runat="server" OnClick="imgbtnHome_Click" 
                                                                            OnClientClick="return SaveData();" meta:resourcekey="imgbtnHomeResource1" />
                                                                        <br />
                                                                        <asp:Label ID="lblHome" runat="server" Text="Home" 
                                                                            meta:resourcekey="lblHomeResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" OnClientClick="return SaveData();"
                                                                            ImageUrl="~/images/icon-report.png" runat="server" 
                                                                            OnClick="imgBtnGenerateReport_Click" 
                                                                            meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                                        <asp:Label ID="lblReport" runat="server" Text="Report" 
                                                                            meta:resourcekey="lblReportResource1"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 90px" align="center">
                                                                        <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                            runat="server" OnClientClick="return SaveData();" 
                                                                            OnClick="imgBtnHelp_Click" meta:resourcekey="imgBtnHelpResource1" /><br />
                                                                        <asp:Label ID="lblHelp" runat="server" Text="Help" 
                                                                            meta:resourcekey="lblHelpResource1"></asp:Label>
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
                                        <tr>
                                            <td width="90" align="center">
                                                <img src="../images/icon06.png" width="48" height="47" alt="" />
                                            </td>
                                            <td valign="top" style="padding-top: 5px;" width="784px">
                                                <asp:Label ID="lblFunding" runat="server" Text="4. Funding" 
                                                    meta:resourcekey="lblFundingResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Localize ID="locPara1" runat="server" Text="
                                    Every business requires cash to funds the various business activities. Funds may
                                    be contributed by the shareholders, loan from shareholders or directors, or via
                                    financial instruments from banks. Funds are used not only in meeting the day-to-day
                                    operational requirements, but often the purchase of equipment and assets. This section
                                    seeks to understand your business’ funding." 
                                        meta:resourcekey="locPara1Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="lblFundingFrom" runat="server" Text="Funding from Owners" 
                                        meta:resourcekey="lblFundingFromResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Localize ID="locPara2" runat="server" Text="
                                    If you have plans to increase the owners' capital or advances to the business, please
                                    enter the incremental amount below; leave blank if not applicable." 
                                        meta:resourcekey="locPara2Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="875" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" width="143" class="border">
                                                <asp:Label ID="lbl1Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl1EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear1" runat="server" Text="Label" 
                                                    meta:resourcekey="lblProjYear1Resource1"></asp:Label>($)
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" width="143" class="border">
                                                <asp:Label ID="lbl2Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl2EstimatesResource1"></asp:Label><br />
                                                <asp:Label ID="lblProjYear2" runat="server" Text="Label" 
                                                    meta:resourcekey="lblProjYear2Resource1"></asp:Label>($)
                                            </td>
                                            <td align="center" width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" width="143" class="border">
                                                <asp:Label ID="lbl3Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl3EstimatesResource1"></asp:Label><br />
                                                <asp:Label ID="lblProjYear3" runat="server" Text="Label" 
                                                    meta:resourcekey="lblProjYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td class="border">
                                                <asp:Label ID="lblIncremental" runat="server" 
                                                    Text="Incremental capital injection (from existing or new stake owners)" 
                                                    meta:resourcekey="lblIncrementalResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCapitalP1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" 
                                                    onblur="FormatCells(this);" meta:resourcekey="txtCapitalP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCapitalP2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtCapitalP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCapitalP3" runat="server" class="txtfieldNew" Style="width: 100px;"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtCapitalP3Resource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td class="borderBLR">
                                                <asp:Label ID="lbl1Incremental" runat="server" 
                                                    Text="Incremental loans/advances made to the business by the owner/(s)" 
                                                    meta:resourcekey="lbl1IncrementalResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtloansP1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtloansP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtloansP2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtloansP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtloansP3" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtloansP3Resource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_WCL_1">
                                <td>
                                    <strong>
                                        <asp:Label ID="lblExistingWorking" runat="server" 
                                        Text="Existing Working Capital Loan" 
                                        meta:resourcekey="lblExistingWorkingResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr id="tr_WCL_2">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_WCL_3">
                                <td>
                                    <asp:Localize ID="locPara3" runat="server" Text="
                                    Working capital loans include overdrafts, trust receipts,factoring loans,short term
                                    advances, revolving credit, etc., Working capital loan is obtained to meet your
                                    day-to-day operational cash requirements of your trade prior to collections from
                                    your customers." meta:resourcekey="locPara3Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_WCL_4">
                                <td valign="top">
                                    <table width="875" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="143">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="143">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="143">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td colspan="4">
                                                <asp:Label ID="lblIfYou" runat="server" 
                                                    meta:resourcekey="lblIfYouResource1"></asp:Label>
                                               
                                            </td>
                                            <td align="center" class="border">
                                                $<asp:TextBox ID="txtCapitalLoan1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtCapitalLoan1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td colspan="4">
                                                <asp:Localize ID="locPara4" runat="server" Text="Enter the credit limit of working capital loans<br />
                                                (Please include overdrafts, trust receipts, factoring loans, short term advances,
                                                revolving credit, etc)" meta:resourcekey="locPara4Resource1"></asp:Localize>
                                            </td>
                                            <td align="center" class="border">
                                                $<asp:TextBox ID="txtCapitalLoan2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtCapitalLoan2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td colspan="4">
                                                <asp:Localize ID="locPara5" runat="server" Text="
                                                Enter the letter of credit, bankers' acceptance and shipping guarantee utilisation
                                                amount as at the last financial year end" 
                                                    meta:resourcekey="locPara5Resource1"></asp:Localize>
                                            </td>
                                            <td align="center" class="border">
                                                $<asp:TextBox ID="txtCapitalLoan4" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" 
                                                    onblur="FormatCells(this);" meta:resourcekey="txtCapitalLoan4Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td colspan="4">
                                                <asp:Label ID="lbl1EnterThe" runat="server" 
                                                    Text="Enter the average interest rate that you are paying for the working capital loans" 
                                                    meta:resourcekey="lbl1EnterTheResource1"></asp:Label>
                                            </td>
                                            <td align="center" class="border">
                                                <asp:TextBox ID="txtCapitalLoanPer" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="6" 
                                                    meta:resourcekey="txtCapitalLoanPerResource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftCapitalLoanPer" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtCapitalLoanPer" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_WCL_5">
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_TL_1">
                                <td>
                                    <strong>
                                        <asp:Label ID="lblExistingTerm" runat="server" 
                                        Text="Existing Term Loan and/or Hire Purchase Loan" 
                                        meta:resourcekey="lblExistingTermResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr id="tr_TL_2">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_TL_3">
                                <td>
                                    <asp:Localize ID="locPara6" runat="server" Text="
                                    Term Loan and hire purchase loan are usually obtained to fund the purchase of property,
                                    machinery, plant and equipment of your business." 
                                        meta:resourcekey="locPara6Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_TL_4">
                                <td valign="top">
                                    <table width="875" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="143">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="143">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="143">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lbl2EnterThe" runat="server" 
                                                    Text="Enter the average interest rate that you are paying for the term loan" 
                                                    meta:resourcekey="lbl2EnterTheResource1"></asp:Label>
                                            </td>
                                            <td align="center" class="border">
                                                <asp:TextBox ID="txtTermLoanPer" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="6" 
                                                    meta:resourcekey="txtTermLoanPerResource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftTermLoanPer" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtTermLoanPer" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" width="143" class="border">
                                                <asp:Label ID="lbl4Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl4EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProYear1" runat="server" Text="Label" 
                                                    meta:resourcekey="lblProYear1Resource1"></asp:Label>($)
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" width="143" class="border">
                                                <asp:Label ID="lbl5Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl5EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProYear2" runat="server" Text="Label" 
                                                    meta:resourcekey="lblProYear2Resource1"></asp:Label>($)
                                            </td>
                                            <td align="center" width="7">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" width="143" class="border">
                                                <asp:Label ID="lbl6Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl6EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProYear3" runat="server" Text="Label" 
                                                    meta:resourcekey="lblProYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left">
                                                &nbsp;
                                            </td>
                                            <td class="border">
                                                <asp:Label ID="lblPlease" runat="server" 
                                                    Text="Please indicate your yearly total loan repayment sum (principal + interests)" 
                                                    meta:resourcekey="lblPleaseResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTermLoanP1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" 
                                                    onblur="FormatCells(this);" meta:resourcekey="txtTermLoanP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTermLoanP2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtTermLoanP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTermLoanP3" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtTermLoanP3Resource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                    <asp:HiddenField ID="hfValue1" runat="server" />
                                    <asp:HiddenField ID="hfValue" runat="server" />
                                    <asp:HiddenField ID="hfPastValues" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                        OnClick="btnSaveNext_Click" OnClientClick="return IsValid();" 
                                        meta:resourcekey="btnSaveNextResource1" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" 
                                        OnClick="btnClear_Click" meta:resourcekey="btnClearResource1" />
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click"
                                        OnClientClick="return ConfirmChoice();" 
                                        meta:resourcekey="btnBackResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td valign="middle">
                                    <asp:Label ID="lblGiven" runat="server" 
                                        Text="Given value is not in a correct format" 
                                        meta:resourcekey="lblGivenResource1"></asp:Label>
                                    <asp:Label ID="lblAreYou" runat="server" 
                                        Text="Are you sure, you want to save the data." 
                                        meta:resourcekey="lblAreYouResource1"></asp:Label>
                                    <asp:Label ID="lblDoYou" runat="server" 
                                        Text="Do you want to save the data before naviagtion? then click OK, otherwise, click Cancel." 
                                        meta:resourcekey="lblDoYouResource1"></asp:Label>
                                    <asp:Label ID="lblDoYouChanges" runat="server" 
                                        Text="Do you want to save the changes you made?" 
                                        meta:resourcekey="lblDoYouChangesResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
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
    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" 
        DynamicServicePath="" Enabled="True" />

    <script type="text/javascript">

        var SplitIds = '<%=strTxtClientIds %>'.split(',');

        function highlightBg(txtObj) {
            document.getElementById(txtObj.id).select();
        }

        function IsValid() {
            var flg = false;
            for (i = 0; i <= SplitIds.length - 1; i++) {
                var txtObj = document.getElementById(SplitIds[i]);
                var flag = checkFormat(txtObj.value);
                if (flag == false) {
                    flg = true;
                    txtObj.style.background = '#DC7171';
                }
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }

            if (flg == true) {
                var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                alert(lblGiven);
                formatCellsWithComma();
                return false;
            }
            //            return confirm('Are you sure, you want to save the data.');
            var lblAreYou = document.getElementById('<%=lblAreYou.ClientID%>').innerHTML
            if (confirm(lblAreYou)) {
                return true;
            }
            else {
                formatCellsWithComma();
                return false;
            }
        }

        function FormatCells(txtId) {
            var flag = checkFormat(txtId.value);
            if (flag == false) {
                var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                alert(lblGiven);
            }
            else {
                document.getElementById(txtId.id).style.background = '#dbeaee';
                for (i = 0; i < SplitIds.length; i++) {
                    var txtObj = document.getElementById(SplitIds[i]);
                    var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                    txtObj.value = removeSplCharacters(tempVal);
                }
                formatCellsWithComma();
            }
        }

        function formatCellsWithComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);

                var val = document.getElementById(SplitIds[i]).value;

                txtObj.value = includeComma(val, 3);
            }

        }
        function hideWCL() {
            for (i = 1; i <= 5; i++) {
                document.getElementById('tr_WCL_' + i.toString()).style.display = 'none';
            }
        }

        function hideTL() {
            for (i = 1; i <= 4; i++) {
                document.getElementById('tr_TL_' + i.toString()).style.display = 'none';
            }
        }

        function Combine(strWCL, strTL) {
            var hfvalue = document.getElementById('<%= hfPastValues.ClientID %>').value;
            if (strWCL == "yes") {
                hideWCL();
            }

            if (strTL == "yes" || hfvalue == "0") {
                hideTL();
            }
            formatCellsWithComma();

        }
        function ConfirmChoice() {
            var lblDoYou = document.getElementById('<%=lblDoYou.ClientID%>').innerHTML
            answer = confirm(lblDoYou)
            if (answer == "0") {
                document.getElementById('<%= hfValue.ClientID %>').value = 0;
                return true;
            }
            else {
                document.getElementById('<%= hfValue.ClientID %>').value = 1;

                var flg = false;
                for (i = 0; i <= SplitIds.length - 1; i++) {
                    var txtObj = document.getElementById(SplitIds[i]);
                    var flag = checkFormat(txtObj.value);
                    if (flag == false) {
                        flg = true;
                        txtObj.style.background = '#DC7171';
                    }
                    var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                    txtObj.value = removeSplCharacters(tempVal);
                }

                if (flg == true) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                    formatCellsWithComma();
                    return false;
                }
                return true;
            }
        }
        function SaveData() {
            var lblDoYouChanges = document.getElementById('<%=lblDoYouChanges.ClientID%>').innerHTML
            answer = confirm(lblDoYouChanges)
            if (answer == "0") {
                document.getElementById('<%= hfValue1.ClientID %>').value = 0;
                return true;
            }
            else {
                document.getElementById('<%= hfValue1.ClientID %>').value = 1;

                var flg = false;
                for (i = 0; i <= SplitIds.length - 1; i++) {
                    var txtObj = document.getElementById(SplitIds[i]);
                    var flag = checkFormat(txtObj.value);
                    if (flag == false) {
                        flg = true;
                        txtObj.style.background = '#DC7171';
                    }
                    var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                    txtObj.value = removeSplCharacters(tempVal);
                }

                if (flg == true) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                    formatCellsWithComma();
                    return false;
                }
                return true;
            }
        }
        function runScript(e) {
            if (e.keyCode == 13) {
                return false;
            }
            else
                return true;
        }
     
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

</asp:Content>
