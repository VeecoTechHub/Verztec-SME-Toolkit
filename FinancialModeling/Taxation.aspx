<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Taxation.aspx.cs" Inherits="FinancialModeling_Taxation"
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
                                                <img src="../images/icon07.png" width="48" height="47" alt="" />
                                            </td>
                                            <td valign="top" style="padding-top: 5px;" width="784px">
                                                <asp:Label ID="lblTaxation" runat="server" 
                                                    Text="6. Taxation & Depreciation (Optional)" 
                                                    meta:resourcekey="lblTaxationResource1"></asp:Label>
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
                                    <asp:Localize ID="locPara1" runat="server" Text="Taxation and depreciation are the two other financial elements that may affect the
                                    profitability and cash flow of a business. If you know these, enter them below;
                                    leave blank if not applicable." meta:resourcekey="locPara1Resource1"></asp:Localize>
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
                                        <asp:Label ID="lbl1Taxation" runat="server" Text="6.1 Taxation" 
                                        meta:resourcekey="lbl1TaxationResource1"></asp:Label>
                                    </strong>
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
                                        <tr id="TR1" runat="server">
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                <asp:Localize ID="locPara2" runat="server" Text="The income tax expenses expressed as a percentage (%) of your profit before tax
                                                for the most recent financial year was" meta:resourcekey="locPara2Resource1"></asp:Localize>
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td width="143" align="center" class="border">
                                                &nbsp;
                                                <asp:Label ID="lblIncometax" runat="server" 
                                                    meta:resourcekey="lblIncometaxResource1"></asp:Label>
                                                <asp:Label ID="lblPerSymbol" runat="server" Text="%" 
                                                    meta:resourcekey="lblPerSymbolResource1"></asp:Label>
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td width="143" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="7" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="143" align="center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="TR7" runat="server">
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                <asp:Localize ID="locPara3" runat="server" Text="Enter the percentage that you would like to apply on the profit before income tax
                                                for the projection periods to calculate your income tax expenses." 
                                                    meta:resourcekey="locPara3Resource1"></asp:Localize>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="border" width="143">
                                                <asp:TextBox ID="txtIncometax" runat="server" CssClass="txtfieldNew" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" MaxLength="6" 
                                                    meta:resourcekey="txtIncometaxResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftIncometax" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtIncometax" Enabled="True">
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
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="TR2" runat="server">
                                <td>
                                    <strong>
                                        <asp:Label ID="lblDepreciation" runat="server" Text="6.2 Depreciation" 
                                        meta:resourcekey="lblDepreciationResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr id="TR3" runat="server">
                                <td valign="top" runat="server">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="TR4" runat="server">
                                <td>
                                    <asp:Localize ID="locPara4" runat="server" Text="If there is net book value, you are encouraged to estimate the deprecation charges
                                    for the period. Otherwise, the report will not reflect the depreciation charges
                                    of existing assets." meta:resourcekey="locPara4Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="TR5" runat="server">
                                <td valign="top" runat="server">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="TR6" runat="server">
                                <td valign="top">
                                    <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                            <td width="337">
                                                &nbsp;
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td width="143" align="center" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl1Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl1EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear1" runat="server" 
                                                    meta:resourcekey="lblProjYear1Resource1"></asp:Label>($)
                                            </td>
                                            <td width="7">
                                                &nbsp;
                                            </td>
                                            <td width="143" align="center" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl2Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl2EstimatesResource1"></asp:Label><br />
                                                <asp:Label ID="lblProjYear2" runat="server" 
                                                    meta:resourcekey="lblProjYear2Resource1"></asp:Label>($)
                                            </td>
                                            <td width="7" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="143" align="center" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl3Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl3EstimatesResource1"></asp:Label><br />
                                                <asp:Label ID="lblProjYear3" runat="server" 
                                                    meta:resourcekey="lblProjYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="19" align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td class="border">
                                                <asp:Label ID="lblThe" runat="server" 
                                                    Text="The net book value of your fixed assets brought forward" 
                                                    meta:resourcekey="lblTheResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblDepreciationP1" runat="server" Width="100px" 
                                                    CssClass="alignRight" meta:resourcekey="lblDepreciationP1Resource1"></asp:Label>
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
                                            <td align="left" valign="top">
                                                &nbsp;
                                            </td>
                                            <td class="borderBLR">
                                                <asp:Label ID="lblEnter" runat="server" 
                                                    Text="Enter your estimated yearly depreciation charges" 
                                                    meta:resourcekey="lblEnterResource1"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtDepreciationP1" runat="server" CssClass="txtfieldNew" Style="width: 100px;"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="CalcDepreciatonTotal(this,'1');"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtDepreciationP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="border">
                                                <asp:TextBox ID="txtDepreciationP2" runat="server" CssClass="txtfieldNew" Style="width: 100px;"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="CalcDepreciatonTotal(this,'2');"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtDepreciationP2Resource1"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="border">
                                                <asp:TextBox ID="txtDepreciationP3" runat="server" CssClass="txtfieldNew" Style="width: 100px;"
                                                    onkeypress="return runScript(event)" MaxLength="20" onblur="CalcDepreciatonTotal(this,'3');"
                                                    onFocus="highlightBg(this);" meta:resourcekey="txtDepreciationP3Resource1"></asp:TextBox>
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
                                            <td colspan="3">
                                                <asp:Label ID="lblTotal" runat="server" 
                                                    Text="Total Depreciation Charges of the existing assets for the 3 years is" 
                                                    meta:resourcekey="lblTotalResource1"></asp:Label>
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
                                            <td align="center" class="border">
                                                <asp:Label ID="lblDepreciationTotal" runat="server" Width="100px" 
                                                    CssClass="alignRight" meta:resourcekey="lblDepreciationTotalResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="7">
                                                <asp:Label ID="lblErrorMsg" runat="server" Text="Error, the depreciation charges that you have entered exceed the net book value"
                                                    Font-Bold="True" ForeColor="Red" Style="display: none;" 
                                                    meta:resourcekey="lblErrorMsgResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
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
                            <tr style="display: none">
                                <td valign="middle">
                                    &nbsp;
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
        var lblSplitIds = '<%=strLblClientIds %>'.split(',');

        function highlightBg(txtObj) {
            document.getElementById(txtObj.id).select();
        }

        function CalcDepreciatonTotal(txtId, number) {
            var flag1_n = 1;
            var flag2_n = 2;
            var flag3_n = 3;
            var flag1 = true;
            var flag2 = true;
            var flag3 = true;

            if (flag1_n == number)
                var flag1 = checkFormat(document.getElementById('<%=txtDepreciationP1.ClientID%>').value);

            if (flag2_n == number)
                var flag2 = checkFormat(document.getElementById('<%=txtDepreciationP2.ClientID%>').value);

            if (flag3_n == number)
                var flag3 = checkFormat(document.getElementById('<%=txtDepreciationP3.ClientID%>').value);

            if (flag1 == false || flag2 == false || flag3 == false) {
                var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                alert(lblGiven);
                return;
            }
            else {

                document.getElementById(txtId.id).style.background = '#dbeaee';

                formatCellsWithoutComma();

                var val1 = document.getElementById('<%=txtDepreciationP1.ClientID%>').value
                var val2 = document.getElementById('<%=txtDepreciationP2.ClientID%>').value
                var val3 = document.getElementById('<%=txtDepreciationP3.ClientID%>').value

                if (val1.trim() != "") {
                    val1 = val1;
                }
                else
                    val1 = 0;
                if (val2.trim() != "") {
                    val2 = val2;
                }
                else
                    val2 = 0;
                if (val3.trim() != "") {
                    val3 = val3;
                }
                else
                    val3 = 0;

                var total = parseFloat(val1) + parseFloat(val2) + parseFloat(val3);
                document.getElementById('<%=lblDepreciationTotal.ClientID%>').innerHTML = total;
                var netBookValue = document.getElementById('<%=lblDepreciationP1.ClientID%>').innerHTML;
                if (total > netBookValue) {
                    document.getElementById('<%=lblErrorMsg.ClientID%>').style.display = 'block';
                }
                else
                    document.getElementById('<%=lblErrorMsg.ClientID%>').style.display = 'none';

                formatCellsWithComma();
            }

        }



        function IsValid() {
            var flg = false;
            if (SplitIds[0] != "") {
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
            }
            if (lblSplitIds[0] != "") {
                for (i = 0; i <= lblSplitIds.length - 1; i++) {

                    var lblObj = document.getElementById(lblSplitIds[i]);
                    var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                    lblObj.innerHTML = removeSplCharacters(tempVal);
                }
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
            if (SplitIds[0] != "") {

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

        function Combine() {
            formatCellsWithComma();
            document.getElementById('<%=lblErrorMsg.ClientID%>').style.display = 'block';
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
                if (SplitIds[0] != "") {
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
                }
                if (lblSplitIds[0] != "") {
                    for (i = 0; i <= lblSplitIds.length - 1; i++) {

                        var lblObj = document.getElementById(lblSplitIds[i]);
                        var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                        lblObj.innerHTML = removeSplCharacters(tempVal);
                    }
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
                if (SplitIds != '') {
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
