<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="CapitalExpenditure.aspx.cs" Inherits="FinancialModeling_CapitalExpenditure"
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
                                                <img src="../images/icon08.png" width="48" height="47" alt="" />
                                            </td>
                                            <td valign="top" style="padding-top: 5px;" width="784px">
                                                <asp:Label ID="lblCapital" runat="server" 
                                                    Text="5. Capital Expenditure & Other Assets & Liabilities" 
                                                    meta:resourcekey="lblCapitalResource1"></asp:Label>
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
                                        <asp:Label ID="lbl5AOtherAssets" runat="server" 
                                        Text="5A. Other Assets & Liabilities" 
                                        meta:resourcekey="lbl5AOtherAssetsResource1"></asp:Label>
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
                                    Other than the usual fixed assets and current assets like stocks, your business
                                    may also have other forms of assets (e.g. rental deposits) and liabilities (e.g.
                                    other creditors, accrual). If these exist in your business, enter the relevant information
                                    below; otherwise you may skip this section." 
                                        meta:resourcekey="locPara1Resource1"></asp:Localize>
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
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337" class="border">
                                                <asp:Localize ID="locPara2" runat="server" Text="
                                                Estimate and enter the incremental other assets and other liabilities as at the
                                                end of each period" meta:resourcekey="locPara2Resource1"></asp:Localize>
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
                                            <td class="borderBLR">
                                                <asp:Label ID="lblOtherAssets" runat="server" 
                                                    Text="Increase/(Decrease) in Other Assets for the Period" 
                                                    meta:resourcekey="lblOtherAssetsResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOtherAssetsP1" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    Style="width: 100px;" MaxLength="20" onblur="FormatCells(this);" 
                                                    meta:resourcekey="txtOtherAssetsP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOtherAssetsP2" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    Style="width: 100px;" MaxLength="20" onblur="FormatCells(this);" 
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtOtherAssetsP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOtherAssetsP3" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    Style="width: 100px;" MaxLength="20" onblur="FormatCells(this);" 
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtOtherAssetsP3Resource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td class="borderBLR">
                                                <asp:Label ID="lblOtherLiabilities" runat="server" 
                                                    Text="Increase/(Decrease) in Other Liabilities for the Period" 
                                                    meta:resourcekey="lblOtherLiabilitiesResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOtherLiabilitiesP1" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    Style="width: 100px;" MaxLength="20" onblur="FormatCells(this);" 
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtOtherLiabilitiesP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOtherLiabilitiesP2" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    Style="width: 100px;" MaxLength="20" onblur="FormatCells(this);" 
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtOtherLiabilitiesP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtOtherLiabilitiesP3" runat="server" CssClass="txtfieldNew" onkeypress="return runScript(event)"
                                                    Style="width: 100px;" MaxLength="20" onblur="FormatCells(this);" 
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtOtherLiabilitiesP3Resource1"></asp:TextBox>
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
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q1_1">
                                <td>
                                    <strong>
                                        <asp:Label ID="lbl5BCapital" runat="server" Text="5B. Capital Expenditure" 
                                        meta:resourcekey="lbl5BCapitalResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr id="tr_Q1_2">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q1_3">
                                <td>
                                    <asp:Localize ID="locPara5" runat="server" 
                                        Text="
                                    To grow the business, very often, you have to increase your capacity by moving to
                                    larger premises and incur renovation costs, or purchase of motor vehicles, equipment,
                                    etc; these are also known as Capital Expenditure. This section seeks to understand
                                    your planned capital expenditure and how you intend to fund these capital expenditure." 
                                        meta:resourcekey="locPara5Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_Q1_4">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q1_5">
                                <td>
                                    <asp:Localize ID="locPara6" runat="server" Text="
                                    You may like to provide the estimated capital expenditure and any accompanying loan
                                    details below. You can specify up to 3 types of capital expenditure if these differ
                                    in loan/funding requirements." meta:resourcekey="locPara6Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_Q1_6">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_Q1_7">
                                <td align="left" valign="top">
                                    <div class="tabstyle">
                                        <ul>
                                            <li><a id="capex1Hyp" class="active" onclick="tabContent('capex1')">
                                                <asp:Label ID="lbl1Capital" runat="server" Text="Capital Expenditure" 
                                                    meta:resourcekey="lbl1CapitalResource1"></asp:Label>
                                                1</a></li>
                                            <li><a id="capex2Hyp" class="tab" onclick="tabContent('capex2')">
                                                <asp:Label ID="lbl2Capital" runat="server" Text="Capital Expenditure" 
                                                    meta:resourcekey="lbl2CapitalResource1"></asp:Label>
                                                2</a></li>
                                            <li><a id="capex3Hyp" class="tab" onclick="tabContent('capex3')">
                                                <asp:Label ID="lbl3Capital" runat="server" Text="Capital Expenditure" 
                                                    meta:resourcekey="lbl3CapitalResource1"></asp:Label>
                                                3</a></li>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                            <tr id="tr_Q1_8">
                                <td height="2" align="center" valign="top" class="tabBottomCol">
                                </td>
                            </tr>
                            <tr id="tr_Q1_9">
                                <td valign="top" class="tabGradient">
                                    <div id="capex1">
                                        <table width="820" border="0" align="center" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="820" border="0" align="center" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td width="349" class="border">
                                                <asp:Localize ID="locPara7" runat="server" Text="
                                                    Enter the assets class that you are planning to purchase<br />
                                                    (E.g. Motor Vehicles)" meta:resourcekey="locPara7Resource1"></asp:Localize>
                                                </td>
                                                <td width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl4Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl4EstimatesResource1"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblCapex1ProjYear1" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex1ProjYear1Resource1"></asp:Label>($)
                                                </td>
                                                <td width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl5Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl5EstimatesResource1"></asp:Label><br />
                                                    <asp:Label ID="lblCapex1ProjYear2" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex1ProjYear2Resource1"></asp:Label>($)
                                                </td>
                                                <td align="center" width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl6Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl6EstimatesResource1"></asp:Label><br />
                                                    <asp:Label ID="lblCapex1ProjYear3" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex1ProjYear3Resource1"></asp:Label>($)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="borderBLR">
                                                    <asp:TextBox ID="txtExpenditure1" runat="server" CssClass="txtfieldNewText" onkeypress="return runScript(event)"
                                                        MaxLength="250" Style="width: 340px;" 
                                                        meta:resourcekey="txtExpenditure1Resource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1P1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="20" 
                                                        onblur="FormatCells(this);" meta:resourcekey="txtCapex1P1Resource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1P2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex1P2Resource1"></asp:TextBox>
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1P3" runat="server" class="txtfieldNew" Style="width: 100px;"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex1P3Resource1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="borderBLR">
                                                <asp:Label ID="lblEnterThe" runat="server" 
                                                        Text="Enter the estimated useful life (years)" 
                                                        meta:resourcekey="lblEnterTheResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1Years" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1YearsResource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1Years" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1Years" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl1Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl1YearsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtCapex1Years" MinimumValue="1"
                                                        MaximumValue="50" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator1Resource1" />
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
                                                <td colspan="7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="border">
                                                <asp:Label ID="lblNumber" runat="server" 
                                                        Text="Number of months in use of the assets in the year of addition" 
                                                        meta:resourcekey="lblNumberResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex1MonthsP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1MonthsP1Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1MonthsP1" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1MonthsP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl1Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl1MonthsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtCapex1MonthsP1" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator5Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex1MonthsP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1MonthsP2Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1MonthsP2" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1MonthsP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl2Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl2MonthsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator6" ControlToValidate="txtCapex1MonthsP2" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator6Resource1" />
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex1MonthsP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1MonthsP3Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1MonthsP3" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1MonthsP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl3Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl3MonthsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator7" ControlToValidate="txtCapex1MonthsP3" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator7Resource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_1">
                                                <td colspan="7">
                                                    <strong>
                                                     <asp:Label ID="lblIfFin" runat="server" 
                                                        Text="If financing is required on the capital expenditure, enter the following" 
                                                        meta:resourcekey="lblIfFinResource1"></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_2">
                                                <td colspan="7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_3">
                                                <td>
                                                    <asp:Label ID="lbl1Loan" runat="server" Text="Loan Interest Rate (%)" 
                                                        meta:resourcekey="lbl1LoanResource1"></asp:Label>
                                                
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex1InterestRate" runat="server" Style="width: 40px;" onkeypress="return runScript(event)"
                                                        class="txtfieldNew" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1InterestRateResource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1InterestRate" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex1InterestRate" 
                                                        Enabled="True">
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
                                            <tr id="tr_Q5_4">
                                                <td>
                                                <asp:Label ID="lbl1Quantum" runat="server" Text="Loan Quantum (%)" 
                                                        meta:resourcekey="lbl1QuantumResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1QuantumP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1QuantumP1Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1QuantumP1" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex1QuantumP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator8" ControlToValidate="txtCapex1QuantumP1" MinimumValue="1"
                                                        MaximumValue="100" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator8Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex1QuantumP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1QuantumP2Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1QuantumP2" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex1QuantumP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator9" ControlToValidate="txtCapex1QuantumP2" MinimumValue="1"
                                                        MaximumValue="100" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator9Resource1" />
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex1QuantumP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1QuantumP3Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1QuantumP3" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex1QuantumP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator10" ControlToValidate="txtCapex1QuantumP3"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator10Resource1" />
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_5">
                                                <td>
                                                 <asp:Label ID="lbl1Tenure" runat="server" Text="Loan Tenure (Year(s))" 
                                                        meta:resourcekey="lbl1TenureResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1TenureP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1TenureP1Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1TenureP1" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1TenureP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl4Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl4YearsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtCapex1TenureP1" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator2Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1TenureP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1TenureP2Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1TenureP2" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1TenureP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl5Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl5YearsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtCapex1TenureP2" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator3Resource1" />
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex1TenureP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex1TenureP3Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex1TenureP3" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex1TenureP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl6Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl6YearsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txtCapex1TenureP3" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator4Resource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="capex2" style="display: none;">
                                        <table width="820" border="0" align="center" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="820" border="0" align="center" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td width="349" class="border">
                                                 <asp:Localize ID="locPara8" runat="server" Text="
                                                    Enter the assets class that you are planning to purchase<br />
                                                    (E.g. Motor Vehicles)" meta:resourcekey="locPara8Resource1"></asp:Localize>
                                                </td>
                                                <td width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl7Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl7EstimatesResource1"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblCapex2ProjYear1" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex2ProjYear1Resource1"></asp:Label>($)
                                                </td>
                                                <td width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl8Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl8EstimatesResource1"></asp:Label><br />
                                                    <asp:Label ID="lblCapex2ProjYear2" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex2ProjYear2Resource1"></asp:Label>($)
                                                </td>
                                                <td align="center" width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl9Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl9EstimatesResource1"></asp:Label><br />
                                                    <asp:Label ID="lblCapex2ProjYear3" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex2ProjYear3Resource1"></asp:Label>($)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="borderBLR">
                                                    <asp:TextBox ID="txtExpenditure2" runat="server" CssClass="txtfieldNewText" onkeypress="return runScript(event)"
                                                        MaxLength="250" Style="width: 340px;" 
                                                        meta:resourcekey="txtExpenditure2Resource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2P1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex2P1Resource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2P2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex2P2Resource1"></asp:TextBox>
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2P3" runat="server" class="txtfieldNew" Style="width: 100px;"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex2P3Resource1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="borderBLR">
                                                 <asp:Label ID="lbl2EnterThe" runat="server" 
                                                        Text="Enter the estimated useful life (years)" 
                                                        meta:resourcekey="lbl2EnterTheResource1"></asp:Label>
                                                   
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2Years" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2YearsResource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fttxtCapex2Years" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2Years" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl7Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl7YearsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator11" ControlToValidate="txtCapex2Years" MinimumValue="1"
                                                        MaximumValue="50" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator11Resource1" />
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
                                                <td colspan="7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="border">
                                                 <asp:Label ID="lblNumbers" runat="server" 
                                                        Text="Number of months in use of the assets in the year of addition" 
                                                        meta:resourcekey="lblNumbersResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex2MonthsP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2MonthsP1Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2MonthsP1" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2MonthsP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl4Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl4MonthsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator18" ControlToValidate="txtCapex2MonthsP1" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator18Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex2MonthsP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2MonthsP2Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2MonthsP2" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2MonthsP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                  <asp:Label ID="lbl5Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl5MonthsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator19" ControlToValidate="txtCapex2MonthsP2" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator19Resource1" />
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex2MonthsP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2MonthsP3Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2MonthsP3" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2MonthsP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl6Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl6MonthsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator20" ControlToValidate="txtCapex2MonthsP3" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator20Resource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_6">
                                                <td colspan="7">
                                                    <strong>
                                                    <asp:Label ID="lbl2IfFin" runat="server" 
                                                        Text="If financing is required on the capital expenditure, enter the following" 
                                                        meta:resourcekey="lbl2IfFinResource1"></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_7">
                                                <td colspan="7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_8">
                                                <td>
                                                    <asp:Label ID="lbl2LoadInterest" runat="server" Text="Loan Interest Rate (%)" 
                                                        meta:resourcekey="lbl2LoadInterestResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex2InterestRate" runat="server" Style="width: 40px;" onkeypress="return runScript(event)"
                                                        class="txtfieldNew" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2InterestRateResource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2InterestRate" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex2InterestRate" 
                                                        Enabled="True">
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
                                            <tr id="tr_Q5_9">
                                                <td>
                                                    <asp:Label ID="lbl2LoanQuantum" runat="server" Text="Loan Quantum (%)" 
                                                        meta:resourcekey="lbl2LoanQuantumResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2QuantumP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2QuantumP1Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2QuantumP1" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex2QuantumP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator12" ControlToValidate="txtCapex2QuantumP1"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator12Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex2QuantumP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2QuantumP2Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2QuantumP2" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex2QuantumP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator13" ControlToValidate="txtCapex2QuantumP2"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator13Resource1" />
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex2QuantumP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2QuantumP3Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2QuantumP3" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex2QuantumP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator14" ControlToValidate="txtCapex2QuantumP3"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator14Resource1" />
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_10">
                                                <td>
                                                    <asp:Label ID="lbl2LoanTenure" runat="server" Text="Loan Tenure (Year(s))" 
                                                        meta:resourcekey="lbl2LoanTenureResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2TenureP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2TenureP1Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2TenureP1" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2TenureP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl8Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl8YearsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator15" ControlToValidate="txtCapex2TenureP1" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator15Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2TenureP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2TenureP2Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2TenureP2" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2TenureP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl9Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl9YearsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator16" ControlToValidate="txtCapex2TenureP2" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator16Resource1" />
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex2TenureP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex2TenureP3Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex2TenureP3" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex2TenureP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl10Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl10YearsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator17" ControlToValidate="txtCapex2TenureP3" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator17Resource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="capex3" style="display: none;">
                                        <table width="820" border="0" align="center" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="820" border="0" align="center" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td width="349" class="border">
                                                <asp:Localize ID="locPara9" runat="server" Text="
                                                    Enter the assets class that you are planning to purchase<br />
                                                    (E.g. Motor Vehicles)" meta:resourcekey="locPara9Resource1"></asp:Localize>
                                                </td>
                                                <td width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl10Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl10EstimatesResource1"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblCapex3ProjYear1" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex3ProjYear1Resource1"></asp:Label>($)
                                                </td>
                                                <td width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl11Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl11EstimatesResource1"></asp:Label><br />
                                                    <asp:Label ID="lblCapex3ProjYear2" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex3ProjYear2Resource1"></asp:Label>($)
                                                </td>
                                                <td align="center" width="7">
                                                    &nbsp;
                                                </td>
                                                <td align="center" bgcolor="#E9E9E9" width="150" class="border">
                                                    <asp:Label ID="lbl12Estimates" runat="server" Text="Estimates" 
                                                        meta:resourcekey="lbl12EstimatesResource1"></asp:Label><br />
                                                    <asp:Label ID="lblCapex3ProjYear3" runat="server" Text="Label" 
                                                        meta:resourcekey="lblCapex3ProjYear3Resource1"></asp:Label>($)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="borderBLR">
                                                    <asp:TextBox ID="txtExpenditure3" runat="server" CssClass="txtfieldNewText" onkeypress="return runScript(event)"
                                                        MaxLength="250" Style="width: 340px;" 
                                                        meta:resourcekey="txtExpenditure3Resource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3P1" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex3P1Resource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3P2" runat="server" Style="width: 100px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex3P2Resource1"></asp:TextBox>
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="center" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3P3" runat="server" class="txtfieldNew" Style="width: 100px;"
                                                        onkeypress="return runScript(event)" MaxLength="20" onblur="FormatCells(this);"
                                                        onFocus="highlightBg(this);" meta:resourcekey="txtCapex3P3Resource1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="borderBLR">
                                                    <asp:Label ID="lbl3EnterThe" runat="server" 
                                                        Text="Enter the estimated useful life (years)" 
                                                        meta:resourcekey="lbl3EnterTheResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3Years" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3YearsResource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3Years" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3Years" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl11Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl11YearsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator21" ControlToValidate="txtCapex3Years" MinimumValue="1"
                                                        MaximumValue="50" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator21Resource1" />
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
                                                <td colspan="9">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="border">
                                                <asp:Label ID="lbl3NumberOf" runat="server" 
                                                        Text="Number of months in use of the assets in the year of addition" 
                                                        meta:resourcekey="lbl3NumberOfResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex3MonthsP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3MonthsP1Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3MonthsP1" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3MonthsP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl7Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl7MonthsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator28" ControlToValidate="txtCapex3MonthsP1" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator28Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex3MonthsP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3MonthsP2Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3MonthsP2" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3MonthsP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl8Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl8MonthsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator29" ControlToValidate="txtCapex3MonthsP2" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator29Resource1" />
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex3MonthsP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3MonthsP3Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3MonthsP3" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3MonthsP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl9Months" runat="server" Text="Month(s)" 
                                                        meta:resourcekey="lbl9MonthsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator30" ControlToValidate="txtCapex3MonthsP3" MinimumValue="1"
                                                        MaximumValue="12" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator30Resource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="9">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_11">
                                                <td colspan="9">
                                                    <strong>
                                                    <asp:Label ID="lbl3IfFin" runat="server" 
                                                        Text="If financing is required on the capital expenditure, enter the following" 
                                                        meta:resourcekey="lbl3IfFinResource1"></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_12">
                                                <td colspan="9">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_13">
                                                <td>
                                                    <asp:Label ID="lbl3LoanInterest" runat="server" Text="Loan Interest Rate (%)" 
                                                        meta:resourcekey="lbl3LoanInterestResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex3InterestRate" runat="server" Style="width: 40px;" onkeypress="return runScript(event)"
                                                        class="txtfieldNew" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3InterestRateResource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3InterestRate" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex3InterestRate" 
                                                        Enabled="True">
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
                                            <tr id="tr_Q5_14">
                                                <td>
                                                    <asp:Label ID="lbl3LoanQuantum" runat="server" Text="Loan Quantum (%)" 
                                                        meta:resourcekey="lbl3LoanQuantumResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3QuantumP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3QuantumP1Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3QuantumP1" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex3QuantumP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator22" ControlToValidate="txtCapex3QuantumP1"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator22Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex3QuantumP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3QuantumP2Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3QuantumP2" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex3QuantumP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator23" ControlToValidate="txtCapex3QuantumP2"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator23Resource1" />
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="border">
                                                    <asp:TextBox ID="txtCapex3QuantumP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3QuantumP3Resource1"></asp:TextBox>
                                                    %
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3QuantumP3" runat="server"
                                                        ValidChars=".-0123456789" TargetControlID="txtCapex3QuantumP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RangeValidator ID="RangeValidator24" ControlToValidate="txtCapex3QuantumP2"
                                                        MinimumValue="1" MaximumValue="100" Type="Integer" EnableClientScript="False"
                                                        ErrorMessage="*" SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator24Resource1" />
                                                </td>
                                            </tr>
                                            <tr id="tr_Q5_15">
                                                <td>
                                                <asp:Label ID="lbl3LoanTenure" runat="server" Text="Loan Tenure (Year(s))" 
                                                        meta:resourcekey="lbl3LoanTenureResource1"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3TenureP1" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3TenureP1Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3TenureP1" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3TenureP1" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl12Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl12YearsResource1"></asp:Label>
                                                    
                                                    <asp:RangeValidator ID="RangeValidator25" ControlToValidate="txtCapex3TenureP1" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator25Resource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3TenureP2" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3TenureP2Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3TenureP2" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3TenureP2" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl13Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl13YearsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator26" ControlToValidate="txtCapex3TenureP2" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator26Resource1" />
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" class="borderBLR">
                                                    <asp:TextBox ID="txtCapex3TenureP3" runat="server" Style="width: 40px;" class="txtfieldNew"
                                                        onkeypress="return runScript(event)" MaxLength="6" 
                                                        meta:resourcekey="txtCapex3TenureP3Resource1"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftCapex3TenureP3" runat="server"
                                                        ValidChars="-0123456789" TargetControlID="txtCapex3TenureP3" 
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                     <asp:Label ID="lbl14Years" runat="server" Text="Year(s)" 
                                                        meta:resourcekey="lbl14YearsResource1"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator27" ControlToValidate="txtCapex3TenureP3" MinimumValue="1"
                                                        MaximumValue="30" Type="Integer" EnableClientScript="False" ErrorMessage="*"
                                                        SetFocusOnError="True" runat="server" 
                                                        meta:resourcekey="RangeValidator27Resource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="tr_Q1_10">
                                <td valign="middle">
                                    &nbsp;
                                    <asp:HiddenField ID="hfValue" runat="server" />
                                    <asp:HiddenField ID="hfValue1" runat="server" />
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
                            <tr style="display:none">
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
        //        function checkValues(obj) {
        //            var value = obj.value;
        //            var id = obj.id;
        //            alert(id);
        //            if (value > 30) {
        //                alert("you can enter upto 30 years only");
        //               
        //            }
        //        }

        function highlightBg(txtObj) {
            document.getElementById(txtObj.id).select();
        }


        function hideQ1() {
            for (i = 1; i <= 10; i++) {
                document.getElementById('tr_Q1_' + i.toString()).style.display = 'none';
            }
        }
        function hideQ5() {
            for (i = 1; i <= 15; i++) {
                document.getElementById('tr_Q5_' + i.toString()).style.display = 'none';
            }
        }

        var SplitIds = '<%=strTxtClientIds %>'.split(',');

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

        function Combine(hide) {
            formatCellsWithComma();
            if (hide == "yes") {
                hideQ5();
            }

        }

        function HideCapex(hide) {
            formatCellsWithComma();
            if (hide == "yes") {
                hideQ1();
            }

        }


        function formatCellsWithoutComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }
        }

        function tabContent(obj) {
            var Countries = new Array("capex1", "capex2", "capex3");

            for (var i = 0; i < Countries.length; i++) {
                var el = document.getElementById(Countries[i]);
                var elhyp = document.getElementById(Countries[i].toString() + "Hyp");

                //alert(Countries[i]);
                //alert(obj);
                if (Countries[i].toString() == obj.toString()) {

                    el.style.display = 'block';
                    elhyp.className = 'active';
                }
                else {
                    el.style.display = 'none';
                    elhyp.className = 'tab';
                }
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
