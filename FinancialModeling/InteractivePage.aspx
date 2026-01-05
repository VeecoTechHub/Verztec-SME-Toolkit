<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="InteractivePage.aspx.cs" Inherits="FinancialModeling_InteractivePage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    SME Financial Modeling Tool</div>
            </td>
        </tr>
        <tr>
            <td height="300" valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblError" CssClass="ErrorMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="203">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="874" border="0" cellspacing="0" cellpadding="3" class="blueborder">
                                            <tr class="blue_bg">
                                                <td>
                                                    <strong>Interactive Page</strong>
                                                </td>
                                                <td align="left">
                                                    <strong><span style="padding-left: 70px;">
                                                        <asp:Label ID="lblPreviousPreviousYear" runat="server"></asp:Label></span></strong>
                                                </td>
                                                <td align="left">
                                                    <strong><span style="padding-left: 70px;">
                                                        <asp:Label ID="lblPreviousYear" runat="server"></asp:Label></span></strong>
                                                </td>
                                                <td align="left">
                                                    <strong><span style="padding-left: 70px;">
                                                        <asp:Label ID="lblCurrentYear" runat="server"></asp:Label></span></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;">
                                                    Revenue Growth
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <asp:TextBox ID="txtPreviousPreviousYearRevenue" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvPreviousPreviousYearRevenue" CssClass="ErrorMsg"
                                                        runat="server" ControlToValidate="txtPreviousPreviousYearRevenue" ErrorMessage="*"
                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftPreviousPreviousYearRevenue" runat="server"
                                                        TargetControlID="txtPreviousPreviousYearRevenue" FilterType="Custom, Numbers"
                                                        ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revPreviousPreviousYearRevenue" runat="server"
                                                        Display="Dynamic" CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtPreviousPreviousYearRevenue"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <asp:TextBox ID="txtPreviousYearRevenue" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvPreviousYearRevenue" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtPreviousYearRevenue" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftPreviousYearRevenue" runat="server"
                                                        TargetControlID="txtPreviousYearRevenue" FilterType="Custom, Numbers" ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revPreviousYearRevenue" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtPreviousYearRevenue"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <asp:TextBox ID="txtCurrentYearRevenue" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvCurrentYearRevenue" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtCurrentYearRevenue" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="fttxtCurrentYearRevenue" runat="server"
                                                        TargetControlID="txtCurrentYearRevenue" FilterType="Custom, Numbers" ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revCurrentYearRevenue" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtCurrentYearRevenue"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;">
                                                    Tax Rate
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <asp:TextBox ID="txtPreviousPreviousTaxRate" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvPreviousPreviousTaxRate" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtPreviousPreviousTaxRate" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftPreviousPreviousTaxRate" runat="server"
                                                        TargetControlID="txtPreviousPreviousTaxRate" FilterType="Custom, Numbers" ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revPreviousPreviousTaxRate" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtPreviousPreviousTaxRate"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <asp:TextBox ID="txtPreviousTaxRate" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvPreviousTaxRate" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtPreviousTaxRate" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="fttxtPreviousTaxRate" runat="server"
                                                        TargetControlID="txtPreviousTaxRate" FilterType="Custom, Numbers" ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revPreviousTaxRate" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtPreviousTaxRate"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <asp:TextBox ID="txtCurrentTaxRate" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvCurrentTaxRate" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtCurrentTaxRate" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftCurrentTaxRate" runat="server"
                                                        TargetControlID="txtCurrentTaxRate" FilterType="Custom, Numbers" ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revCurrentTaxRate" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtCurrentTaxRate"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Debt Repayment period (years)
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDebtRepaymentperiod" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvDebtRepaymentperiod" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtDebtRepaymentperiod" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftDebtRepaymentperiod" runat="server"
                                                        TargetControlID="txtDebtRepaymentperiod" FilterType="Custom, Numbers" ValidChars="-" />
                                                    <asp:RegularExpressionValidator ID="revDebtRepaymentperiod" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtDebtRepaymentperiod"
                                                        ValidationExpression="^(\-)?\d+$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left">
                                                </td>
                                                <td align="left">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Effective Interest on debt (p.a.)
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEffectiveInterest" CssClass="StmtTextBox_Normal" runat="server"></asp:TextBox>%
                                                    <asp:RequiredFieldValidator ID="rfvEffectiveInterest" runat="server" CssClass="ErrorMsg"
                                                        ControlToValidate="txtEffectiveInterest" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftEffectiveInterest" runat="server"
                                                        TargetControlID="txtEffectiveInterest" FilterType="Custom, Numbers" ValidChars="-." />
                                                    <asp:RegularExpressionValidator ID="revEffectiveInterest" runat="server" Display="Dynamic"
                                                        CssClass="ErrorMsg" ErrorMessage="Invalid Number" ControlToValidate="txtEffectiveInterest"
                                                        ValidationExpression="^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left">
                                                </td>
                                                <td align="left">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnNext" runat="server" CssClass="orange_button" CausesValidation="true"
                                Text="Save & Next" OnClick="btnNext_Click" />
                            <input type="button" id="btnClear" onclick="clearData();" class="orange_button" value="Clear" />
                            <asp:Button ID="btnBack" runat="server" CausesValidation="false" CssClass="orange_button"
                                Text="Back" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        function clearData() {
            document.getElementById('<%=txtDebtRepaymentperiod.ClientID %>').value = '';
            document.getElementById('<%=txtPreviousPreviousYearRevenue.ClientID %>').value = '';
            document.getElementById('<%=txtPreviousYearRevenue.ClientID %>').value = '';
            document.getElementById('<%=txtCurrentYearRevenue.ClientID %>').value = '';
            document.getElementById('<%=txtEffectiveInterest.ClientID %>').value = '';
            document.getElementById('<%=txtPreviousPreviousTaxRate.ClientID %>').value = '';
            document.getElementById('<%=txtPreviousTaxRate.ClientID %>').value = '';
            document.getElementById('<%=txtCurrentTaxRate.ClientID %>').value = '';


        }
    </script>
</asp:Content>
