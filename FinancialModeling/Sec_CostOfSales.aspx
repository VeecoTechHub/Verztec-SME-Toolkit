<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Sec_CostOfSales.aspx.cs" Inherits="FinancialModeling_Sec_CostOfSales"
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
                                    <table border="0" cellspacing="0" cellpadding="0" width="874">
                                        <tr>
                                            <td width="874" align="center" colspan="2">
                                                <table width="874">
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
                                                <img src="../images/icon02.png" width="48" height="47" alt="" />
                                            </td>
                                            <td valign="top" style="padding-top: 5px;" width="784px">
                                                <asp:Label ID="lblCostOfSales" runat="server" Text="2. Cost of Sales & Payments"
                                                    meta:resourcekey="lblCostOfSalesResource1"></asp:Label>
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
                            Every business will have some cost associated with sales. For a trading business,
                            the costs will be like purchases of goods and transportation charges; for a service
                            business, it could be subcontracting costs. However, cost of sales does not include
                            overheads like rental, salaries and office expenses. This section seeks to understand
                            your cost structure in your business." meta:resourcekey="locPara1Resource1"></asp:Localize>
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
                                        <asp:Label ID="lbl2A" runat="server" Text="2A (1) What is the cost of sales as a percentage of your sales?"
                                            meta:resourcekey="lbl2AResource1"></asp:Label></strong>
                                    <asp:Label ID="lblForExample" runat="server" Text="For example, if your sales is $100 and cost of sales is $56, the cost of sales %
                            shall be 56%." meta:resourcekey="lblForExampleResource1"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblExample" runat="server" Text="Example of cost of sales include materials, subcontract costs and freight charges."
                                        meta:resourcekey="lblExampleResource1"></asp:Label>
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
                                            <td width="214" align="center" valign="top" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lblSources" runat="server" Text="Sources of sales" meta:resourcekey="lblSourcesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblAsEntered" runat="server" Text="(as entered in Section 1)" meta:resourcekey="lblAsEnteredResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="155" align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl2CostOfSales" runat="server" Text="Cost of Sales" meta:resourcekey="lbl2CostOfSalesResource1"></asp:Label>
                                                <br />
                                                
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
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="60">
                                                &nbsp;
                                            </td>
                                            <td width="2">
                                                &nbsp;
                                            </td>
                                            <td width="185">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                &nbsp;<asp:Label ID="lblTradingOfGoods" runat="server" Style="width: 210px;" meta:resourcekey="lblTradingOfGoodsResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                            <table>
                                             <tr><td>
                                                <asp:TextBox ID="txtTradingOfGoodsPer" runat="server" MaxLength="6" Style="width: 30px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" meta:resourcekey="txtTradingOfGoodsPerResource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                %
                                              </td></tr>
                                            </table>
                                                <asp:FilteredTextBoxExtender ID="ftTradingOfGoodsPer" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtTradingOfGoodsPer" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                &nbsp;<asp:Label ID="lblManufacturingSale" runat="server" Style="width: 210px;" meta:resourcekey="lblManufacturingSaleResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                             <table>
                                             <tr><td>
                                                <asp:TextBox ID="txtManufacturingSalePer" runat="server" MaxLength="6" Style="width: 30px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" meta:resourcekey="txtManufacturingSalePerResource1"></asp:TextBox>
                                                  </td>
                                                <td>
                                                %
                                              </td></tr>
                                            </table>
                                                <asp:FilteredTextBoxExtender ID="ftManufacturingSalePer" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtManufacturingSalePer" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                &nbsp;<asp:Label ID="lblServices" runat="server" Style="width: 210px;" meta:resourcekey="lblServicesResource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                            <table>
                                             <tr><td>
                                                <asp:TextBox ID="txtServicesPer" runat="server" MaxLength="6" Style="width: 30px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" meta:resourcekey="txtServicesPerResource1"></asp:TextBox>
                                                  </td>
                                                <td>
                                                %
                                              </td></tr>
                                            </table>
                                                <asp:FilteredTextBoxExtender ID="ftServicesPer" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtServicesPer" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="11" align="left">
                                                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="orange_button"
                                                    OnClick="btnCalculate_Click" meta:resourcekey="btnCalculateResource1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                                    <tr>
                                                        <td width="420px">
                                                            &nbsp;
                                                        </td>
                                                        <td width="10">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" bgcolor="#E9E9E9" valign="top" class="border" width="140px">
                                                            <asp:Label ID="lbl1Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl1EstimatesResource1"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblProYear1" runat="server" meta:resourcekey="lblProYear1Resource1"></asp:Label>
                                                        </td>
                                                        <td width="10">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" bgcolor="#E9E9E9" valign="top" class="border" width="140px">
                                                            <asp:Label ID="lbl2Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl2EstimatesResource1"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblProYear2" runat="server" meta:resourcekey="lblProYear2Resource1"></asp:Label>
                                                        </td>
                                                        <td width="10">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" bgcolor="#E9E9E9" valign="top" class="border" width="140px">
                                                            <asp:Label ID="lbl3Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl3EstimatesResource1"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblProYear3" runat="server" meta:resourcekey="lblProYear3Resource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border">
                                                            <asp:Label ID="lblBased" runat="server" Text="Based on information that you have entered, the average cost of sales as a percentage
                                                    of your overall sales is" meta:resourcekey="lblBasedResource1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" class="borderBLR">
                                                            <asp:Label ID="lblTradingOfGoodsP1" runat="server" meta:resourcekey="lblTradingOfGoodsP1Resource1"></asp:Label>%
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" class="borderBLR">
                                                            <asp:Label ID="lblManufacturingSaleP1" runat="server" meta:resourcekey="lblManufacturingSaleP1Resource1"></asp:Label>%
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" class="borderBLR">
                                                            <asp:Label ID="lblServicesP1" runat="server" meta:resourcekey="lblServicesP1Resource1"></asp:Label>%
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr_Q2" style="display: none">
                                            <td colspan="15" style="font-size: 11px; color: red">
                                                <asp:Label ID="lblSection2" runat="server" Text="Section 2A(2) is not relevant to your business since there is no manufacturing activity in your business."
                                                    meta:resourcekey="lblSection2Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr_Q2_1">
                                            <td colspan="11">
                                                <strong>
                                                    <asp:Label ID="lbl2A2For" runat="server" Text="2A (2) For manufacturing activities, please indicate the yearly fixed overhead
                                                    costs of your business? Please exclude depreciation charges." meta:resourcekey="lbl2A2ForResource1"></asp:Label></strong>
                                                <br />
                                                <asp:Label ID="lblExamples1" runat="server" Text="Examples of fixed costs of sale include, salary of production workers, factory rental,
                                                equipment rental & maintenance, etc" meta:resourcekey="lblExamples1Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr_Q2_2">
                                            <td colspan="11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr_Q2_3">
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl4Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl4EstimatesResource1"></asp:Label>
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
                                                <asp:Label ID="lbl5Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl5EstimatesResource1"></asp:Label>
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
                                                <asp:Label ID="lbl6Estimates" runat="server" Text="Estimates" meta:resourcekey="lbl6EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear3" runat="server" meta:resourcekey="lblProjYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr id="tr_Q2_4">
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtProjectionP1" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    MaxLength="20" Style="width: 100px;" onblur="CalcEstimateP2Increase('1');" meta:resourcekey="txtProjectionP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtProjectionP1Per" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    MaxLength="6" Style="width: 30px;" onblur="CalcEstimateP2Increase('2');" meta:resourcekey="txtProjectionP1PerResource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftProjectionP1Per" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtProjectionP1Per" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblProjectionP2" runat="server" Width="130px" CssClass="alignRight"
                                                    meta:resourcekey="lblProjectionP2Resource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtProjectionP2Per" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    MaxLength="6" Style="width: 30px;" onblur="CalcEstimateP3Increase();" meta:resourcekey="txtProjectionP2PerResource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftProjectionP2Per" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtProjectionP2Per" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblProjectionP3" runat="server" Width="130px" CssClass="alignRight"
                                                    meta:resourcekey="lblProjectionP3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                <asp:Label ID="lbl2BHow" runat="server" Text="2B. How long does it take to pay your various suppliers?"
                                                    meta:resourcekey="lbl2BHowResource1"></asp:Label>
                                                <strong></strong>
                                                <br />
                                                <asp:Localize ID="locPara2" runat="server" Text="
                                                The number of days you take to pay your suppliers also have implications on the
                                                cash and funds, which is part of your working capital, available to your business."
                                                    meta:resourcekey="locPara2Resource1"></asp:Localize>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="11">
                                                <table width="874" border="0" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="350">
                                                            <strong>
                                                                <asp:Label ID="lblDoYouDeal" runat="server" Text="Do you deal in cash terms only?"
                                                                    meta:resourcekey="lblDoYouDealResource1"></asp:Label></strong>
                                                        </td>
                                                        <td align="left" width="100">
                                                            <asp:RadioButtonList ID="rbl_Q2" runat="server" RepeatDirection="Horizontal" ValidationGroup="g1"
                                                                onkeypress="return runScript(event)" onclick="hideQ3();" meta:resourcekey="rbl_Q2Resource1">
                                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource2">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td style="text-align: left; vertical-align: bottom">
                                                            <asp:RequiredFieldValidator runat="server" ID="radRfv1" ControlToValidate="rbl_Q2"
                                                                ErrorMessage="Select One option" Display="Dynamic" ValidationGroup="g1" meta:resourcekey="radRfv1Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
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
                            <tr id="tr_Q3_1">
                                <td>
                                    <asp:Localize ID="locPara3" runat="server" Text="
                                    Enter the percentage of your purchases and the corresponding days to pay your suppliers.
                                    For example, if 60% of your purchases are payable within 30 days, and 40% of your
                                    purchases are payable within 45 days, enter 60% and 30 days in the first row, and
                                    40% and 45 days in the second row, and so on. If you take on the average 35 days
                                    to pay all your suppliers, just enter 100% and 35 days in the first row, and leave
                                    the rest blank." meta:resourcekey="locPara3Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_Q3_2">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q3_3">
                                <td valign="top">
                                    <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="214">
                                                &nbsp;
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="115">
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
                                            <td align="center" bgcolor="#E9E9E9" width="115" class="border">
                                                <asp:Label ID="lblPercentageOfTotal" runat="server" Text="Percentage of Total Cost of Sale"
                                                    meta:resourcekey="lblPercentageOfTotalResource1"></asp:Label>
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
                                            <td align="center" bgcolor="#E9E9E9" width="115" class="border">
                                                <asp:Label ID="lblCorresponding" runat="server" Text="Corresponding Days to Pay"
                                                    meta:resourcekey="lblCorrespondingResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="60">
                                                &nbsp;
                                            </td>
                                            <td width="2">
                                                &nbsp;
                                            </td>
                                            <td width="115">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCostOfSale1" runat="server" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcSaleTotal();"
                                                    meta:resourcekey="txtCostOfSale1Resource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftCostOfSale1" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtCostOfSale1" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNumberOfDays1" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcDaysTotal();"
                                                    meta:resourcekey="txtNumberOfDays1Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl1days" runat="server" Text="day(s)" meta:resourcekey="lbl1daysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftNumberOfDays1" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtNumberOfDays1" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCostOfSale2" runat="server" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcSaleTotal();"
                                                    meta:resourcekey="txtCostOfSale2Resource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftCostOfSale2" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtCostOfSale2" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNumberOfDays2" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcDaysTotal();"
                                                    meta:resourcekey="txtNumberOfDays2Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl2Days" runat="server" Text="day(s)" meta:resourcekey="lbl2DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftNumberOfDays2" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtNumberOfDays2" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCostOfSale3" runat="server" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcSaleTotal();"
                                                    meta:resourcekey="txtCostOfSale3Resource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftCostOfSale3" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtCostOfSale3" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNumberOfDays3" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcDaysTotal();"
                                                    meta:resourcekey="txtNumberOfDays3Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl3Days" runat="server" Text="day(s)" meta:resourcekey="lbl3DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftNumberOfDays3" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtNumberOfDays3" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtCostOfSale4" runat="server" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcSaleTotal();"
                                                    meta:resourcekey="txtCostOfSale4Resource1"></asp:TextBox>%
                                                <asp:FilteredTextBoxExtender ID="ftCostOfSale4" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtCostOfSale4" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtNumberOfDays4" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcDaysTotal();"
                                                    meta:resourcekey="txtNumberOfDays4Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl4Days" runat="server" Text="day(s)" meta:resourcekey="lbl4DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftNumberOfDays4" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtNumberOfDays4" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right">
                                                <strong>
                                                    <asp:Label ID="lblTotal1" runat="server" Text="Total" meta:resourcekey="lblTotal1Resource1"></asp:Label></strong>
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblTotal" runat="server" Width="80px" meta:resourcekey="lblTotalResource1"></asp:Label>
                                            </td>
                                            <td colspan="3" align="right">
                                                <strong>
                                                    <asp:Label ID="lblAverage" runat="server" Text="Average" meta:resourcekey="lblAverageResource1"></asp:Label></strong>
                                            </td>
                                            <td align="center" valign="middle" class="borderBLR">
                                                <asp:Label ID="lblAverageDays" runat="server" Width="40px" Style="text-align: right"
                                                    meta:resourcekey="lblAverageDaysResource1"></asp:Label>&nbsp;
                                                <asp:Label ID="lblAvgDays1" runat="server" Text="day(s)" meta:resourcekey="lblAvgDays1Resource1"></asp:Label>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                <strong>
                                                    <asp:Label ID="lblAnalysis" runat="server" Text="Analysis of your average payment days"
                                                        meta:resourcekey="lblAnalysisResource1"></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr_Days" runat="server">
                                            <td colspan="15" runat="server">
                                                <asp:Label ID="lblLastYear" runat="server" Text="Last year, the average number of days it took for you to pay your suppliers was
                                                approximately" meta:resourcekey="lblLastYearResource1"></asp:Label>
                                                <asp:Label ID="lblAvgPaymentDays" runat="server"></asp:Label>
                                                <asp:Label ID="lbl7Days" runat="server" Text="days." meta:resourcekey="lbl7DaysResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                <asp:Label ID="lblBasedOnThe" runat="server" Text="Based on the information that you have entered above, you will take approximately"
                                                    meta:resourcekey="lblBasedOnTheResource1"></asp:Label>
                                                <asp:Label ID="lblAvgDays" runat="server" meta:resourcekey="lblAvgDaysResource1"></asp:Label>&nbsp;
                                                <asp:Label ID="lblDaysToPay" runat="server" Text="days to pay your suppliers.
                                                For subsequent projections and financial analysis, you may either use this figure,
                                                or" meta:resourcekey="lblDaysToPayResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                <asp:Label ID="lblENterTheAvg" runat="server" Text="Enter the average payment days you take to pay your suppliers here:"
                                                    meta:resourcekey="lblENterTheAvgResource1"></asp:Label>
                                                <asp:TextBox ID="txtDays" runat="server" CssClass="txtfieldNew" MaxLength="10" onkeypress="return runScript(event)"
                                                    Style="width: 40px;" BorderWidth="1px" BorderColor="#348781" BorderStyle="Solid"
                                                    meta:resourcekey="txtDaysResource1"></asp:TextBox>
                                                <asp:Label ID="lblDaysFake" runat="server" Text="day(s)" meta:resourcekey="lblAvgDays1Resource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblOptional" runat="server" Text="(Optional)" meta:resourcekey="lblOptionalResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftDays" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtDays" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
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
                            <tr id="tr_Q4_1">
                                <td>
                                    <asp:Localize ID="locPara4" runat="server" Text="
                                    You will need to keep stocks to ensure availability of goods to supply to your customers
                                    as and when they place orders with you. The level of stocks will typically based
                                    on the lead time you need to replenish the stocks." meta:resourcekey="locPara4Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_Q4_2">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q4_3">
                                <td>
                                    <strong>
                                        <asp:Label ID="lbl2CUnderstanding" runat="server" Text="2C. Understanding your purchase & delivery cycle."
                                            meta:resourcekey="lbl2CUnderstandingResource1"></asp:Label></strong>
                                </td>
                            </tr>
                            <tr id="tr_Q4_4">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q4_5">
                                <td valign="top">
                                    <table width="874" border="0" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td colspan="15" width="874px">
                                                <strong>
                                                    <asp:Label ID="lblInYour" runat="server" Text="In your business, how many days does it take on the average to …."
                                                        meta:resourcekey="lblInYourResource1"></asp:Label>
                                                </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" width="80%" style="white-space: nowrap;">
                                                <asp:Label ID="lblAHave" runat="server" Text="(a) Have the suppliers deliver the goods to you after you have placed your order?"
                                                    meta:resourcekey="lblAHaveResource1"></asp:Label>
                                            </td>
                                            <td align="center" class="border" width="200px">
                                                <asp:TextBox ID="txtOnTheAverageDays1" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcAvgDaysTotal();"
                                                    meta:resourcekey="txtOnTheAverageDays1Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl8Days" runat="server" Text="day(s)" meta:resourcekey="lbl8DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftOnTheAverageDays1" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtOnTheAverageDays1" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4" width="2px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" width="672">
                                                <asp:Label ID="lblReceive" runat="server" Text="(b) Receive the goods after it has been shipped to you?"
                                                    meta:resourcekey="lblReceiveResource1"></asp:Label>
                                            </td>
                                            <td align="center" class="borderBLR" width="200">
                                                <asp:TextBox ID="txtOnTheAverageDays2" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcAvgDaysTotal();"
                                                    meta:resourcekey="txtOnTheAverageDays2Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl9Days" runat="server" Text="day(s)" meta:resourcekey="lbl9DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftOnTheAverageDays2" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtOnTheAverageDays2" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4" width="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" width="672">
                                                <asp:Label ID="lblProcess" runat="server" Text="(c) Process the goods (manufacture, packing, etc) ?"
                                                    meta:resourcekey="lblProcessResource1"></asp:Label>
                                            </td>
                                            <td align="center" class="borderBLR" width="200">
                                                <asp:TextBox ID="txtOnTheAverageDays3" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcAvgDaysTotal();"
                                                    meta:resourcekey="txtOnTheAverageDays3Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl10Days" runat="server" Text="day(s)" meta:resourcekey="lbl10DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftOnTheAverageDays3" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtOnTheAverageDays3" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4" width="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" width="672">
                                                <asp:Label ID="lblTransport" runat="server" Text="(d) Transport the goods and bill your customer?"
                                                    meta:resourcekey="lblTransportResource1"></asp:Label>
                                            </td>
                                            <td align="center" class="borderBLR" width="200">
                                                <asp:TextBox ID="txtOnTheAverageDays4" runat="server" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" class="txtfieldNew" onblur="CalcAvgDaysTotal();"
                                                    meta:resourcekey="txtOnTheAverageDays4Resource1"></asp:TextBox>
                                                <asp:Label ID="lbl11Days" runat="server" Text="day(s)" meta:resourcekey="lbl11DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftOnTheAverageDays4" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtOnTheAverageDays4" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4" width="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" align="right" width="80%">
                                                <strong>
                                                    <asp:Label ID="lbl2Total" runat="server" Text="Total" meta:resourcekey="lbl2TotalResource1"></asp:Label></strong>
                                            </td>
                                            <td align="center" class="borderBLR" width="200">
                                                <asp:Label ID="lblAvgDaysTotal" runat="server" Width="40px" Style="text-align: right"
                                                    meta:resourcekey="lblAvgDaysTotalResource1"></asp:Label>&nbsp;
                                                <asp:Label ID="lbl12Days" runat="server" Text="day(s)" meta:resourcekey="lbl12DaysResource1"></asp:Label>
                                            </td>
                                            <td colspan="4" width="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                <strong>
                                                    <asp:Label ID="lbl1Analysis" runat="server" Text="Analysis of your average stock holding days"
                                                        meta:resourcekey="lbl1AnalysisResource1"></asp:Label>
                                                </strong>
                                            </td>
                                        </tr>
                                        <tr id="tr_Days1" runat="server">
                                            <td colspan="15" runat="server">
                                                <asp:Label ID="lbl1Lastyear" runat="server" Text="Last year, the average number of days it took for you to hold your stock was approximately"
                                                    meta:resourcekey="lbl1LastyearResource1"></asp:Label>
                                                <asp:Label ID="lblAvgNumOfDays" runat="server"></asp:Label>
                                                <asp:Label ID="lbl13Days" runat="server"  meta:resourcekey="lbl13DaysResource1" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15" id="td2">
                                                <asp:Label ID="lbl2BasedOnThe" runat="server" Text="Based on the information that you have entered above, you will need to keep approximately"
                                                    meta:resourcekey="lbl2BasedOnTheResource1"></asp:Label>
                                                <asp:Label ID="lblAvgStockPeriod" runat="server" meta:resourcekey="lblAvgStockPeriodResource1"></asp:Label>
                                                <asp:Localize ID="locPara5" runat="server" Text="
                                                days worth of stocks
                                                to meet your customers' orders promptly, assuming that customers' orders are constant
                                                during the period. Otherwise, the stock levels must be adjusted to cater to seasonal
                                                fluctuation of demands." meta:resourcekey="locPara5Resource1"></asp:Localize>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                                <asp:Label ID="lblForSubsequent" runat="server" Text="For subsequent projections and financial analysis, you may either use this
                                                figure, or" meta:resourcekey="lblForSubsequentResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                <asp:Label ID="lblEnter1The" runat="server" Text="Enter the average stock holding days here:"
                                                    meta:resourcekey="lblEnter1TheResource1"></asp:Label>
                                                <asp:TextBox ID="txtAvgStockDays" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    MaxLength="10" Style="width: 40px;" BorderWidth="1px" BorderColor="#348781" BorderStyle="Solid"
                                                    meta:resourcekey="txtAvgStockDaysResource1"></asp:TextBox>
                                                <asp:Label ID="lbl15Days" runat="server" Text="day(s)" meta:resourcekey="lbl15DaysResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lbl2Optional" runat="server" Text="(Optional)" meta:resourcekey="lbl2OptionalResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftAvgStockDays" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtAvgStockDays" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:HiddenField ID="hfValue1" runat="server" />
                                    <asp:HiddenField ID="hfValue" runat="server" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                        OnClick="btnSaveNext_Click" ValidationGroup="g1" OnClientClick="return IsValid();"
                                        meta:resourcekey="btnSaveNextResource1" />
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
                                    <asp:Label ID="lblPercentage" runat="server" Text="Percentage of Total Sales Must Be 100%."
                                        meta:resourcekey="lblPercentageResource1"></asp:Label>
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

        //        var queryString = new Array();       
        //        var parameters = window.location.search.substring(1).split('&');       

        //        for (var i = 0; i < parameters.length; i++) {

        //            var pos = parameters[i].indexOf('=');
        //           
        //            if (pos > 0) {
        //                var paramname = parameters[i].substring(0, pos);
        //                var paramval = parameters[i].substring(pos + 1);              

        //                queryString[paramname] = unescape(paramval.replace(/\+/g, ' '));
        //            } else {
        //                //special value when there is a querystring parameter with no value
        //                queryString[parameters[i]] = ""
        //            }
        //        }
        //Hiding the actual yr tds
        //        if (paramval == '0') {
        //            document.getElementById('tr_Days').style.display = 'none';
        //            document.getElementById('tr_Days1').style.display = 'none';
        //        }

        var radioSelectedValue;
        var saleTotal;
        function CalcEstimateP2Increase(txtId) {
            var flag = checkFormat(document.getElementById('<%=txtProjectionP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                document.getElementById('<%=txtProjectionP1.ClientID%>').style.background = '#dbeaee';
                var txtServices = document.getElementById('<%=txtProjectionP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtProjectionP1Per.ClientID%>').value
                if (Percent.trim() != "" && txtServices.trim() != "") {
                    document.getElementById('<%=lblProjectionP2.ClientID%>').innerHTML = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
                }
                else {
                    document.getElementById('<%=lblProjectionP2.ClientID%>').innerHTML = "";
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
            var txtServices = document.getElementById('<%=lblProjectionP2.ClientID%>').innerHTML
            var Percent = document.getElementById('<%=txtProjectionP2Per.ClientID%>').value
            if (Percent.trim() != "" && txtServices.trim() != "") {
                document.getElementById('<%=lblProjectionP3.ClientID%>').innerHTML = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
            }
            else {
                document.getElementById('<%=lblProjectionP3.ClientID%>').innerHTML = "";
            }
            formatCellsWithComma();

        }
        function CalcSaleTotal() {

            var Sales1 = document.getElementById('<%=txtCostOfSale1.ClientID%>').value
            var Sales2 = document.getElementById('<%=txtCostOfSale2.ClientID%>').value
            var Sales3 = document.getElementById('<%=txtCostOfSale3.ClientID%>').value
            var Sales4 = document.getElementById('<%=txtCostOfSale4.ClientID%>').value
            if (Sales1.trim() != "") {
                Sales1 = Sales1;
            }
            else
                Sales1 = 0;
            if (Sales2.trim() != "") {
                Sales2 = Sales2;
            }
            else
                Sales2 = 0;
            if (Sales3.trim() != "") {
                Sales3 = Sales3;
            }
            else
                Sales3 = 0;
            if (Sales4.trim() != "") {
                Sales4 = Sales4;
            }
            else
                Sales4 = 0;

            var total = (parseFloat(Sales1) + parseFloat(Sales2) + parseFloat(Sales3) + parseFloat(Sales4));
            saleTotal = total;
            document.getElementById('<%=lblTotal.ClientID%>').innerHTML = total + ' %';
            if (total != 100) {
                document.getElementById('<%=lblTotal.ClientID%>').style.backgroundColor = '#DC7171';
            }
            else {
                document.getElementById('<%=lblTotal.ClientID%>').style.backgroundColor = 'White';
            }
            CalcDaysTotal();
        }
        function CalcDaysTotal() {

            var Sales1 = document.getElementById('<%=txtCostOfSale1.ClientID%>').value
            var Sales2 = document.getElementById('<%=txtCostOfSale2.ClientID%>').value
            var Sales3 = document.getElementById('<%=txtCostOfSale3.ClientID%>').value
            var Sales4 = document.getElementById('<%=txtCostOfSale4.ClientID%>').value


            var Days1 = document.getElementById('<%=txtNumberOfDays1.ClientID%>').value
            var Days2 = document.getElementById('<%=txtNumberOfDays2.ClientID%>').value
            var Days3 = document.getElementById('<%=txtNumberOfDays3.ClientID%>').value
            var Days4 = document.getElementById('<%=txtNumberOfDays4.ClientID%>').value

            if (Sales1.trim() != "") {
                Sales1 = Sales1;
            }
            else
                Sales1 = 0;
            if (Sales2.trim() != "") {
                Sales2 = Sales2;
            }
            else
                Sales2 = 0;
            if (Sales3.trim() != "") {
                Sales3 = Sales3;
            }
            else
                Sales3 = 0;
            if (Sales4.trim() != "") {
                Sales4 = Sales4;
            }
            else
                Sales4 = 0;



            if (Days1.trim() != "") {
                Days1 = Days1;
            }
            else
                Days1 = 0;
            if (Days2.trim() != "") {
                Days2 = Days2;
            }
            else
                Days2 = 0;
            if (Days3.trim() != "") {
                Days3 = Days3;
            }
            else
                Days3 = 0;
            if (Days4.trim() != "") {
                Days4 = Days4;
            }
            else
                Days4 = 0;


            var total = (parseFloat(Sales1) * parseInt(Days1) + parseFloat(Sales2) * parseInt(Days2) + parseFloat(Sales3) * parseInt(Days3) + parseFloat(Sales4) * parseInt(Days4));
            total = Math.round(total / 100);
            document.getElementById('<%=lblAverageDays.ClientID%>').innerHTML = total;
            document.getElementById('<%=lblAvgDays.ClientID%>').innerHTML = total;

        }

        function CalcAvgDaysTotal() {

            var Days1 = document.getElementById('<%=txtOnTheAverageDays1.ClientID%>').value
            var Days2 = document.getElementById('<%=txtOnTheAverageDays2.ClientID%>').value
            var Days3 = document.getElementById('<%=txtOnTheAverageDays3.ClientID%>').value
            var Days4 = document.getElementById('<%=txtOnTheAverageDays4.ClientID%>').value

            if (Days1.trim() != "") {
                Days1 = Days1;
            }
            else
                Days1 = 0;
            if (Days2.trim() != "") {
                Days2 = Days2;
            }
            else
                Days2 = 0;
            if (Days3.trim() != "") {
                Days3 = Days3;
            }
            else
                Days3 = 0;
            if (Days4.trim() != "") {
                Days4 = Days4;
            }
            else
                Days4 = 0;

            document.getElementById('<%=lblAvgDaysTotal.ClientID%>').innerHTML = (parseInt(Days1) + parseInt(Days2) + parseInt(Days3) + parseInt(Days4));
            document.getElementById('<%=lblAvgStockPeriod.ClientID%>').innerHTML = (parseInt(Days1) + parseInt(Days2) + parseInt(Days3) + parseInt(Days4));

        }

        //        function checkEmptyCondition(strValue) {

        //            if (strValue.trim() != "") {
        //                return strValue;
        //            }
        //            else
        //                return strValue;
        //        }



        var SplitIds = '<%=strTxtClientIds %>'.split(',');
        var lblSplitIds = '<%=strLblClientIds %>'.split(',');

        function IsValid() {
            var flg = false;

            hideQ3();
            CalcSaleTotal();
            if (radioSelectedValue == "0") {
                if (saleTotal != 100) {
                    var lblPercentage = document.getElementById('<%=lblPercentage.ClientID%>').innerHTML
                    alert(lblPercentage);
                    return false;
                }
            }

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
        function hideQ2() {
            document.getElementById('tr_Q2').style.display = '';
            for (i = 1; i <= 4; i++) {
                document.getElementById('tr_Q2_' + i.toString()).style.display = 'none';
            }

        }
        function hideQ2_withCondition(hideQ2, hideQ2C) {
            if (hideQ2 == "0") {
                document.getElementById('tr_Q2').style.display = '';
                for (i = 1; i <= 4; i++) {
                    document.getElementById('tr_Q2_' + i.toString()).style.display = 'none';
                }
            }
            if (hideQ2C == "yes") {
                hideQ4();
            }

        }
        function hideQ3() {

            var radio = document.getElementById('<%=rbl_Q2.ClientID%>');
            var rdbItem = radio.getElementsByTagName("input");
            var selectedvalue;
            for (var j = 0; j < rdbItem.length; j++) {
                if (rdbItem[j].checked) {
                    selectedvalue = rdbItem[j].value;
                    radioSelectedValue = selectedvalue;
                    break;
                }
            }
            if (selectedvalue == "1") {
                for (i = 1; i <= 3; i++) {
                    document.getElementById('tr_Q3_' + i.toString()).style.display = 'none';
                }
            }
            if (selectedvalue == "0") {
                for (i = 1; i <= 3; i++) {
                    document.getElementById('tr_Q3_' + i.toString()).style.display = '';
                }
            }

            //            for (i = 1; i <= 3; i++) {
            //                document.getElementById('tr_Q3_' + i.toString()).style.display = 'none';
            //            }

        }
        function hideQ4() {

            for (i = 1; i <= 5; i++) {
                document.getElementById('tr_Q4_' + i.toString()).style.display = 'none';
            }

        }
        function Combine(hide2, hide3, hide4) {
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

            if (hide2 == "yes") {
                hideQ2();
            }
            if (hide3 == "yes") {
                hideQ3();
            }
            if (hide4 == "yes") {
                hideQ4();
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

                hideQ3();
                CalcSaleTotal();
                if (radioSelectedValue == "0") {
                    if (saleTotal != 100) {
                        var lblPercentage = document.getElementById('<%=lblPercentage.ClientID%>').innerHTML
                        alert(lblPercentage);
                        return false;
                    }
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

                hideQ3();
                CalcSaleTotal();
                if (radioSelectedValue == "0") {
                    if (saleTotal != 100) {
                        var lblPercentage = document.getElementById('<%=lblPercentage.ClientID%>').innerHTML
                        alert(lblPercentage);
                        return false;
                    }
                }
                return true; ;
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
