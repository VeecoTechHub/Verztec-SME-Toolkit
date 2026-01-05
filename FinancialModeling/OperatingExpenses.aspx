<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="OperatingExpenses.aspx.cs" Inherits="FinancialModeling_OperatingExpenses"
    MaintainScrollPositionOnPostback="true" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

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
                            <asp:Label ID="lblHeading" runat="server" Text="FINANCIAL MANAGEMENT TOOLKIT" meta:resourcekey="lblHeadingResource1"></asp:Label>
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
                                                                            runat="server" OnClick="imgbtnStatements_Click" OnClientClick="return SaveData();"
                                                                            meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                                        <asp:Label ID="lblStatements" runat="server" Text="Statements" meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                            runat="server" OnClick="imgbtnHome_Click" OnClientClick="return SaveData();"
                                                                            meta:resourcekey="imgbtnHomeResource1" />
                                                                        <br />
                                                                        <asp:Label ID="lblHome" runat="server" Text="Home" meta:resourcekey="lblHomeResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" OnClientClick="return SaveData();"
                                                                            ImageUrl="~/images/icon-report.png" runat="server" OnClick="imgBtnGenerateReport_Click"
                                                                            meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                                        <asp:Label ID="lblReport" runat="server" Text="Report" meta:resourcekey="lblReportResource1"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 90px" align="center">
                                                                        <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                            runat="server" OnClientClick="return SaveData();" OnClick="imgBtnHelp_Click"
                                                                            meta:resourcekey="imgBtnHelpResource1" /><br />
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
                                        <tr>
                                            <td width="90" align="center">
                                                <img src="../images/icon03.png" width="48" height="47" alt="" />
                                            </td>
                                            <td valign="top" style="padding-top: 5px;" width="784px">
                                                <asp:Label ID="lblOtherOperating" runat="server" Text="3. Other Operating Expenses & Income"
                                                    meta:resourcekey="lblOtherOperatingResource1"></asp:Label>
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
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="lbl3AOther" runat="server" Text="3A. Other Operating Expenses" meta:resourcekey="lbl3AOtherResource1"></asp:Label>
                                    </strong>
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
                            Other than the cost of sales and purchases, your business will naturally incur other
                            operating costs, including selling and distribution costs and other administration
                            expenses." meta:resourcekey="locPara1Resource1"></asp:Localize>
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
                                        <asp:Label ID="lblEnterThe" runat="server" Text="Enter the variable selling & distribution expenses expressed as a percentage
                                of sales below:" meta:resourcekey="lblEnterTheResource1"></asp:Label>
                                    </strong>
                                    <br />
                                    <asp:Localize ID="locPara2" runat="server" Text="
                            For example, sales commission, selling & distribution costs (such as freight outwards
                            and transportation charges), marketing expenses, etc." meta:resourcekey="locPara2Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="214">
                                                &nbsp;
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="155" align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lblAsaOf" runat="server"  meta:resourcekey="lblAsaOfResource1"></asp:Label>
                                             
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="60">
                                                &nbsp;
                                            </td>
                                            <td width="3" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="185">
                                                &nbsp;
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="60">
                                                &nbsp;
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="185">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" class="border">
                                                <asp:Label ID="lblVariableSelling" runat="server" Text="Variable Selling & Distribution Expenses"
                                                    meta:resourcekey="lblVariableSellingResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTotalSalesPer" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" meta:resourcekey="txtTotalSalesPerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftTotalSalesPer" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtTotalSalesPer" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                <strong>
                                                    <asp:Label ID="lbl1EnterThe" runat="server" Text="Enter the estimated other administrative expenses for the next 3 years below:"
                                                        meta:resourcekey="lbl1EnterTheResource1"></asp:Label>
                                                </strong>
                                                <br />
                                                <asp:Label ID="lblForEx" runat="server" Text="For example, salaries, rental expenses and telecommunication expenses, etc"
                                                    meta:resourcekey="lblForExResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="border" width="214px">
                                                <strong>
                                                    <asp:Label ID="lblDoNot" runat="server" Text="Do not include depreciation, amortisation and interests expenses."
                                                        meta:resourcekey="lblDoNotResource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl1Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl1EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear1" runat="server" meta:resourcekey="lblProjYear1Resource1"></asp:Label>($)
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" valign="top" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl1Increase" runat="server" Text="% of Increase" meta:resourcekey="lbl1IncreaseResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl2Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl2EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear2" runat="server" meta:resourcekey="lblProjYear2Resource1"></asp:Label>($)
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" valign="top" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl2Increase" runat="server" Text="% of Increase" meta:resourcekey="lbl2IncreaseResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl3Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl3EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear3" runat="server" meta:resourcekey="lblProjYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                <asp:Label ID="lbl3OtherAdmin" runat="server" Text="Other administrative expenses"
                                                    meta:resourcekey="lbl3OtherAdminResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOperatingExpenseP1" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    MaxLength="20" Style="width: 100px;" onblur="CalcEstimateP2Increase('1');" meta:resourcekey="txtOperatingExpenseP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOperatingExpenseP1Per" runat="server" CssClass="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="6" Style="width: 30px;" onblur="CalcEstimateP2Increase('2');"
                                                    meta:resourcekey="txtOperatingExpenseP1PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftOperatingExpenseP1Per" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtOperatingExpenseP1Per" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblOperatingExpenseP2" runat="server" Width="130px" CssClass="alignRight"
                                                    meta:resourcekey="lblOperatingExpenseP2Resource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOperatingExpenseP2Per" runat="server" CssClass="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="6" Style="width: 30px;" onblur="CalcEstimateP3Increase();"
                                                    meta:resourcekey="txtOperatingExpenseP2PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftOperatingExpenseP2Per" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtOperatingExpenseP2Per" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblOperatingExpenseP3" runat="server" Width="130px" CssClass="alignRight"
                                                    meta:resourcekey="lblOperatingExpenseP3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr colspan="11">
                                            <td valign="middle">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                <strong>
                                                    <asp:Label ID="lbl3BIncome" runat="server" Text="3B. Other Income" meta:resourcekey="lbl3BIncomeResource1"></asp:Label>
                                                </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                <asp:Localize ID="locPara3" runat="server" Text="
                                        Your business may also receive other form of income other than the usual trade sources.
                                        Other income could be interest or rental income, if these are not the regular income
                                        expected in your trade." meta:resourcekey="locPara3Resource1"></asp:Localize>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="214" class="border">
                                                <strong>
                                                    <asp:Label ID="lbl4OtherIncome" runat="server" Text="Other Income" meta:resourcekey="lbl4OtherIncomeResource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" width="155" class="border">
                                                <asp:Label ID="lbl4Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl4EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProYear1" runat="server" meta:resourcekey="lblProYear1Resource1"></asp:Label>($)
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" valign="top" bgcolor="#E9E9E9" width="60" class="border">
                                                <asp:Label ID="lbl3Increase" runat="server" Text=" % of Increase" meta:resourcekey="lbl3IncreaseResource1"></asp:Label>
                                            </td>
                                            <td align="center" width="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" width="185" class="border">
                                                <asp:Label ID="lbl5Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl5EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProYear2" runat="server" meta:resourcekey="lblProYear2Resource1"></asp:Label>($)
                                            </td>
                                            <td align="center" width="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" valign="top" bgcolor="#E9E9E9" width="60" class="border">
                                                <asp:Label ID="lbl4Increase" runat="server" Text=" % of Increase" meta:resourcekey="lbl4IncreaseResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" width="185" class="border">
                                                <asp:Label ID="lbl6Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl6EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProYear3" runat="server" meta:resourcekey="lblProYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                <asp:Label ID="lblRecurrIncome" runat="server" Text="Recurring in nature" meta:resourcekey="lblRecurrIncomeResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtRecurrP1" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" Style="width: 100px;" onblur="CalculateEstimate1Total(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtRecurrP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtRecurrP1Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" onblur="CalcRecurrP1Increase('1');"
                                                    meta:resourcekey="txtRecurrP1PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftRecurrP1Per" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtRecurrP1Per" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblRecurrP2" runat="server" Width="110px" CssClass="alignRight" meta:resourcekey="lblRecurrP2Resource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtRecurrP2Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" onblur="CalcRecurrP2Increase();"
                                                    meta:resourcekey="txtRecurrP2PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftRecurrP2Per" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtRecurrP2Per" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblRecurrP3" runat="server" Width="110px" CssClass="alignRight" meta:resourcekey="lblRecurrP3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                <asp:Label ID="lblNonRecurrIncome" runat="server" Text="Nonrecurring in nature" meta:resourcekey="lblNonRecurrIncomeResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNonRecurrP1" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" Style="width: 100px;" onblur="CalculateEstimate1Total(this);"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtNonRecurrP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                <%--<asp:TextBox ID="txtNonRecurrP1Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                            Style="width: 30px;" onblur="CalcNonRecurrP1Increase();"></asp:TextBox>
                                        %--%>&nbsp;</td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNonRecurrP2" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" Style="width: 100px;" onblur="CalculateEstimate2Total(this);"
                                                    meta:resourcekey="txtNonRecurrP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                <%-- <asp:TextBox ID="txtNonRecurrP2Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                            Style="width: 30px;" onblur="CalcNonRecurrP2Increase();"></asp:TextBox>
                                        %--%>&nbsp;</td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNonRecurrP3" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" Style="width: 100px;" onblur="CalculateEstimate3Total(this);"
                                                    meta:resourcekey="txtNonRecurrP3Resource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="borderBLR">
                                                <strong>
                                                    <asp:Label ID="lblTotal" runat="server" Text="Total" 
                                                    meta:resourcekey="lblTotalResource1"></asp:Label>
                                                
                                                </strong>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblIncomeP1Total" runat="server" Width="100px" CssClass="alignRight"
                                                    meta:resourcekey="lblIncomeP1TotalResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblIncomeP2Total" runat="server" Width="110px" CssClass="alignRight"
                                                    meta:resourcekey="lblIncomeP2TotalResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblIncomeP3Total" runat="server" Width="110px" CssClass="alignRight"
                                                    meta:resourcekey="lblIncomeP3TotalResource1"></asp:Label>
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
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                        OnClick="btnSaveNext_Click" OnClientClick="return IsValid();" meta:resourcekey="btnSaveNextResource1" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" OnClick="btnClear_Click"
                                        meta:resourcekey="btnClearResource1" />
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click"
                                        OnClientClick="return ConfirmChoice();" meta:resourcekey="btnBackResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td valign="middle">
                                    <asp:Label ID="lblGiven" runat="server" Text="Given value is not in a correct format"
                                        meta:resourcekey="lblGivenResource1"></asp:Label>
                                    <asp:Label ID="lblAreYou" runat="server" Text="Are you sure, you want to save the data."
                                        meta:resourcekey="lblAreYouResource1"></asp:Label>
                                    <asp:Label ID="lblDoYou" runat="server" Text="Do you want to save the data before naviagtion? then click OK, otherwise, click Cancel."
                                        meta:resourcekey="lblDoYouResource1"></asp:Label>
                                    <asp:Label ID="lblDoYouChanges" runat="server" Text="Do you want to save the changes you made?"
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
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" DynamicServicePath=""
        Enabled="True" />

    <script type="text/javascript">

        function highlightBg(txtObj) {
            document.getElementById(txtObj.id).select();
        }

        function CalcEstimateP2Increase(txtId) {


            var flag = checkFormat(document.getElementById('<%=txtOperatingExpenseP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                document.getElementById('<%=txtOperatingExpenseP1.ClientID%>').style.background = '#dbeaee';
                var txtServices = document.getElementById('<%=txtOperatingExpenseP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtOperatingExpenseP1Per.ClientID%>').value
                if (Percent.trim() != "" && txtServices.trim() != "") {
                    document.getElementById('<%=lblOperatingExpenseP2.ClientID%>').innerHTML = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
                }
                else {
                    document.getElementById('<%=lblOperatingExpenseP2.ClientID%>').innerHTML = "";
                }
                formatCellsWithComma();
                CalcEstimateP3Increase();
            }
            else {
                if (txtId != 2) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                }
            }
        }
        function CalcEstimateP3Increase() {
            formatCellsWithoutComma();
            var txtServices = document.getElementById('<%=lblOperatingExpenseP2.ClientID%>').innerHTML
            var Percent = document.getElementById('<%=txtOperatingExpenseP2Per.ClientID%>').value
            if (Percent.trim() != "" && txtServices.trim() != "") {
                document.getElementById('<%=lblOperatingExpenseP3.ClientID%>').innerHTML = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
            }
            else {
                document.getElementById('<%=lblOperatingExpenseP3.ClientID%>').innerHTML = "";
            }
            formatCellsWithComma();
        }



        //Other Income section



        function CalculateEstimate1Total(txtId) {
            var flag1 = checkFormat(document.getElementById('<%=txtRecurrP1.ClientID%>').value);
            var flag2 = checkFormat(document.getElementById('<%=txtNonRecurrP1.ClientID%>').value);

            if (flag1 == false || flag2 == false) {
                var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                alert(lblGiven);
            }
            else {

                formatCellsWithoutComma();
                document.getElementById(txtId.id).style.background = '#dbeaee';
                var txt1 = document.getElementById('<%=txtRecurrP1.ClientID%>').value
                var txt2 = document.getElementById('<%=txtNonRecurrP1.ClientID%>').value
                if (txt1.trim() != "") {
                    txt1 = txt1;
                }
                else
                    txt1 = 0;
                if (txt2.trim() != "") {
                    txt2 = txt2;
                }
                else
                    txt2 = 0;
                //                if (txt1.trim() != "" || txt2.trim() != "")
                document.getElementById('<%=lblIncomeP1Total.ClientID%>').innerHTML = parseFloat(txt1) + parseFloat(txt2);
                //                else
                //                    document.getElementById('<%=lblIncomeP1Total.ClientID%>').innerHTML = "";
                formatCellsWithComma();
                CalcRecurrP1Increase();
            }
        }


        function CalculateEstimate2Total() {
            formatCellsWithoutComma();
            var Val1 = document.getElementById('<%=lblRecurrP2.ClientID%>').innerHTML
            var Val2 = document.getElementById('<%=txtNonRecurrP2.ClientID%>').value
            if (Val1.trim() != "" || Val2.trim() != "")
                document.getElementById('<%=lblIncomeP2Total.ClientID%>').innerHTML = parseFloat(checkNanCondition(Val1)) + parseFloat(checkNanCondition(Val2));
            else
                document.getElementById('<%=lblIncomeP2Total.ClientID%>').innerHTML = "";
            formatCellsWithComma();


        }
        function CalculateEstimate3Total() {
            formatCellsWithoutComma();
            var Val1 = document.getElementById('<%=lblRecurrP3.ClientID%>').innerHTML
            var Val2 = document.getElementById('<%=txtNonRecurrP3.ClientID%>').value
            if (Val1.trim() != "" || Val2.trim() != "")
                document.getElementById('<%=lblIncomeP3Total.ClientID%>').innerHTML = parseFloat(checkNanCondition(Val1)) + parseFloat(checkNanCondition(Val2));
            else
                document.getElementById('<%=lblIncomeP3Total.ClientID%>').innerHTML = "";
            formatCellsWithComma();
        }
        //Recurring Income


        function CalcRecurrP1Increase(txtId) {
            var flag = checkFormat(document.getElementById('<%=txtRecurrP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtGoods = document.getElementById('<%=txtRecurrP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtRecurrP1Per.ClientID%>').value
                if (Percent.trim() != "" && txtGoods.trim() != "") {
                    var total = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                    if (total >= 0)
                        document.getElementById('<%=lblRecurrP2.ClientID%>').innerHTML = total;
                }
                else
                    document.getElementById('<%=lblRecurrP2.ClientID%>').innerHTML = "";
                formatCellsWithComma();
                CalculateEstimate2Total();
                CalcRecurrP2Increase();
            }
            else {
                if (txtId != 1) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                }
            }

        }
        function CalcRecurrP2Increase() {

            formatCellsWithoutComma();
            var txtGoods = document.getElementById('<%=lblRecurrP2.ClientID%>').innerHTML
            var Percent = document.getElementById('<%=txtRecurrP2Per.ClientID%>').value
            if (Percent.trim() != "" && txtGoods.trim() != "") {
                var total = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                if (total >= 0)
                    document.getElementById('<%=lblRecurrP3.ClientID%>').innerHTML = total;
            }
            else
                document.getElementById('<%=lblRecurrP3.ClientID%>').innerHTML = "";
            formatCellsWithComma();
            CalculateEstimate3Total();

        }


        function checkNanCondition(tempValue) {
            var check = isNaN(parseInt(tempValue));
            if (check == false) {
                return tempValue;
            }
            else {
                return 0;
            }


        }



        var SplitIds = '<%=strTxtClientIds %>'.split(',');
        var lblSplitIds = '<%=strLblClientIds %>'.split(',');

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
            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                lblObj.innerHTML = removeSplCharacters(tempVal);
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
        function formatCellsWithComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);

                var val = document.getElementById(SplitIds[i]).value;

                txtObj.value = includeComma(val, 3);
            }

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);

                var val = document.getElementById(lblSplitIds[i]).innerHTML;

                lblObj.innerHTML = includeComma(val, 3);
            }

        }


        function formatCellsWithoutComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                lblObj.innerHTML = removeSplCharacters(tempVal);
            }

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
                //formatCellsWithComma();

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
                for (i = 0; i <= lblSplitIds.length - 1; i++) {

                    var lblObj = document.getElementById(lblSplitIds[i]);
                    var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                    lblObj.innerHTML = removeSplCharacters(tempVal);
                }

                if (flg == true) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                    formatCellsWithComma();
                    return false;
                }
                return true; ;
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
