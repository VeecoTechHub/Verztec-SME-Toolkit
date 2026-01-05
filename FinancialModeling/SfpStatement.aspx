<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="SfpStatement.aspx.cs" Inherits="FinancialModeling_SfpStatement" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <table width="898" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="34" valign="top" class="sme_title_new">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" 
                                Text="THE FINANCIAL MANAGEMENT TOOLKIT" meta:resourcekey="lblHeadingResource1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
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
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="newContentbg">
                        <table width="898" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="840" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="14">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: justify">
                                                <asp:Localize ID="locPara1" runat="server" Text="
                                   Please enter the following information of the most recent complete one financial year's information. If you do not have the financial statement, you are encouraged to make an estimate.  Please note that certain sections of the report may not make sense if information entry is incomplete. 
Skip the entry if you are a new business." meta:resourcekey="locPara1Resource1"></asp:Localize>
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
                                    <table width="811" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="63">
                                                <asp:ImageButton ID="imgbtnIncomeSheet" runat="server" ImageUrl="~/images/left_icon.png"
                                                    Width="53px" Height="58px" OnClientClick="return SaveData();" 
                                                    OnClick="imgbtnIncomeSheet_Click" 
                                                    meta:resourcekey="imgbtnIncomeSheetResource1" />
                                            </td>
                                            <td width="748">
                                                <asp:Label ID="lblClickHere" runat="server" Text="Click here to enter" 
                                                    meta:resourcekey="lblClickHereResource1"></asp:Label>
                                                <br />
                                                <strong>
                                                    <asp:LinkButton ID="lnkBalanceSheet" runat="server" CssClass="footer_link" Text="Income Sheet"
                                                        OnClientClick="return SaveData();" OnClick="lnkBalanceSheet_Click" 
                                                    meta:resourcekey="lnkBalanceSheetResource1"></asp:LinkButton>
                                                </strong>
                                                <br />
                                                <asp:Label ID="lblinformation" runat="server" Text="information" 
                                                    meta:resourcekey="lblinformationResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblError" runat="server" meta:resourcekey="lblErrorResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="750" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="timesheet_bg">
                                                <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="660" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43">
                                                                        <img src="../images/timeSheet_icon.jpg" width="37" height="49" alt="" />
                                                                    </td>
                                                                    <td width="430" height="59">
                                                                        <span class="blue_big1">
                                                                            <asp:Label ID="lblBalanceSheet" runat="server" Text="Balance Sheet" 
                                                                            meta:resourcekey="lblBalanceSheetResource1"></asp:Label>
                                                                        </span>
                                                                        <br />
                                                                        <asp:Label ID="lblAsAtEnd" runat="server" Text="as at end of Actual FY " 
                                                                            meta:resourcekey="lblAsAtEndResource1"></asp:Label>
                                                                        <asp:Label ID="lblHeaderCurrentYear" runat="server" 
                                                                            meta:resourcekey="lblHeaderCurrentYearResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="102" align="right" valign="bottom">
                                                                        <strong>
                                                                            <asp:Label ID="lblCurrency" runat="server" 
                                                                            meta:resourcekey="lblCurrencyResource1"></asp:Label></strong>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="660" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:DataList ID="dlSFP" Width="100%" runat="server" 
                                                                            OnItemDataBound="dlSFP_ItemDataBound" meta:resourcekey="dlSFPResource1">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr id="trSCI" runat="server">
                                                                                        <td width="410" height="40" runat="server">
                                                                                            <asp:HiddenField ID="hfFsMappingId" Value='<%# Eval("FsMappingId") %>' 
                                                                                                runat="server" />
                                                                                            <asp:HiddenField ID="hfStmtRecordId" Value='<%# Eval("StmtRecordId") %>' 
                                                                                                runat="server" />
                                                                                            <asp:HiddenField ID="hfIsFormula" Value='<%# Eval("IsFormula") %>' 
                                                                                                runat="server" />
                                                                                            <asp:Label ID="lblFsMappingName" runat="server" 
                                                                                                Text='<%# Eval("FsMappingName") %>'></asp:Label>
                                                                                        </td>
                                                                                        <td width="250" runat="server">
                                                                                            <strong>$</strong><asp:TextBox ID="txtCurrentYear" CssClass="txtfieldStmts" runat="server"
                                                                                                onkeypress="return runScript(event)" Text='<%# Eval("C_Value") %>' 
                                                                                                Width="233px"></asp:TextBox>
                                                                                            <ajaxcontroltoolkit:FilteredTextBoxExtender ID="ftCurrentYear" runat="server" TargetControlID="txtCurrentYear"
                                                                                                FilterType="Custom, Numbers" ValidChars="-,()" Enabled="True" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="1" colspan="2" class="blue_line">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="50">
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="40">
                                                            <asp:HiddenField ID="hfValue1" runat="server" />
                                                            <asp:HiddenField ID="hfValue" runat="server" />
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                                                OnClick="btnSaveNext_Click" ValidationGroup="g1" 
                                                                OnClientClick="return IsValid();" meta:resourcekey="btnSaveNextResource1" />
                                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" 
                                                                OnClick="btnClear_Click" meta:resourcekey="btnClearResource1" />
                                                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click"
                                                                OnClientClick="return ConfirmChoice();" 
                                                                meta:resourcekey="btnBackResource1" />
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                <asp:Label ID="lblYourBal" runat="server" 
                                                    Text="Your balance sheet is not balanced by $" 
                                                    meta:resourcekey="lblYourBalResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
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
    <ajaxcontroltoolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" 
        DynamicServicePath="" Enabled="True" />

    <script type="text/javascript" language="javascript">
        var SplitIds = '<%=strTxtClientIds %>'.split(',');
        document.getElementById(SplitIds[0]).focus();
        function changeCurentYear(id) {
            for (i = 0; i < 21; i++) {
                var txtObj = document.getElementById(SplitIds[i]);
                if (SplitIds[i] == id) {
                    var flag = checkFormat(txtObj.value);
                    if (flag == false) {
                        var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                        alert(lblGiven);
                        return;
                    }
                }
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }
            formulasList();
            formatCellsWithComma();
        }

        function highlightBg(txtObj) {
            document.getElementById(txtObj).select();
        }
        function focus(txtObj) {
            document.getElementById(txtObj).focus();
        }

        function highLightBalanceSheetInRed() {
            if (document.getElementById(SplitIds[17]).value != 0 && document.getElementById(SplitIds[17]).value != '') {
                document.getElementById(SplitIds[17]).style.background = '#E46869';
            }
            else {
                document.getElementById(SplitIds[17]).style.background = '#E8F2F4';
            }
        }
        function IsValid() {

            var flg = false;
            for (i = 0; i < 21; i++) {
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
                return false;
            }

            for (i = 0; i < 21; i++) {
                var txtObj = document.getElementById(SplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }
            //Checking the balacne sheet bal and updating   
            var lblAreYou = document.getElementById('<%=lblAreYou.ClientID%>').innerHTML
            var lblYourBal = document.getElementById('<%=lblYourBal.ClientID%>').innerHTML
            var strMsg = lblYourBal + document.getElementById(SplitIds[17]).value + '. ';
            if (document.getElementById(SplitIds[17]).value == 0 || document.getElementById(SplitIds[17]).value == '') {
                if (confirm(lblAreYou)) {
                    return true;
                }
                else {
                    formatCellsWithComma();
                    return false;
                }
            }
            else {
                
                if (confirm(strMsg + lblAreYou)) {
                    return true;
                }
                else {
                    formatCellsWithComma();
                    return false;
                }
            }
        }

        function formatCellsWithComma() {

            for (i = 0; i < 21; i++) {


                var txtObj = document.getElementById(SplitIds[i]);

                var val = document.getElementById(SplitIds[i]).value;

                txtObj.value = includeComma(val, 3);

            }
            highLightBalanceSheetInRed();

        }


        function formulasList() {
            //Passing 4 parametrs (Global Id for textbox in datalist, Input Ids that need to be added, Output label Id to be bind,Signs)
            calculateFormulas("0,1,2,3,4", "5", "1,1,1,1,1"); //Total current asset
            calculateFormulas("6", "7", "1"); //Total non-current assets
            calculateFormulas("0,1,2,3,4,6", "8", "1,1,1,1,1,1"); //Total Assets
            calculateFormulas("9,10,11,12,13,14", "15", "1,1,1,1,1,1"); //Total Liabilities
            calculateFormulas("0,1,2,3,4,6,9,10,11,12,13,14,16,18", "17", "1,1,1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1"); //Carry Fwd
            calculateFormulas("16,17,18", "19", "1,1,1"); //Total equity
            calculateFormulas("9,10,11,12,13,14,16,17,18", "20", "1,1,1,1,1,1,1,1,1"); //Liabilities & Equity

        }

        function calculateFormulas(txtIds, txtOutputId, sign) {

            var flagEmpty = checkEmptyCondition(txtIds);
            if (flagEmpty == "1") {
                document.getElementById(SplitIds[txtOutputId]).value = addValues(txtIds, sign);
            }
            else {
                document.getElementById(SplitIds[txtOutputId]).value = "";
            }
        }


        function addValues(txtIds, sign) {
            var spitTxtIds = txtIds.split(",");
            var splitSign = sign.split(",");
            var Result = 0;
            for (var i = 0; i < spitTxtIds.length; i++) {
                Result = Result + parseInt(checkNanCondition(document.getElementById(SplitIds[spitTxtIds[i].toString()]).value)) * parseInt(splitSign[i]);
            }
            return Result;

        }

        //This function returns "0" if, all the values are empty.
        //It takes parameters of controlIds with comma separated.
        function checkEmptyCondition(strValues) {

            var strIds = strValues.split(",");
            var flag = "0";
            for (var i = 0; i < strIds.length; i++) {
                if (document.getElementById(SplitIds[strIds[i].toString()]).value != '') {
                    flag = "1";
                    break;
                }

            }
            return flag;
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

        function ConfirmChoice() {

            //Checking the balacne sheet bal and updating
            var lblDoYou = document.getElementById('<%=lblDoYou.ClientID%>').innerHTML
            var lblYourBal = document.getElementById('<%=lblYourBal.ClientID%>').innerHTML
            var strMsg = lblYourBal + document.getElementById(SplitIds[17]).value + '. ';
            if (document.getElementById(SplitIds[17]).value == 0 || document.getElementById(SplitIds[17]).value == '') {
                answer = confirm(lblDoYou)
                if (answer == "0") {
                    formatCellsWithComma();
                    document.getElementById('<%= hfValue.ClientID %>').value = 0;
                }
                else {

                    document.getElementById('<%= hfValue.ClientID %>').value = 1;
                    var flg = false;
                    for (i = 0; i < 21; i++) {
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
                        return false;
                    }

                    for (i = 0; i < 21; i++) {
                        var txtObj = document.getElementById(SplitIds[i]);
                        var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                        txtObj.value = removeSplCharacters(tempVal);
                    }

                }
            }
            else {
                answer = confirm(strMsg + lblDoYou)
                if (answer == "0") {
                    document.getElementById('<%= hfValue.ClientID %>').value = 0;
                    formatCellsWithComma();
                    //    return true;
                }
                else {
                    document.getElementById('<%= hfValue.ClientID %>').value = 1;
                    var flg = false;
                    for (i = 0; i < 21; i++) {
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
                        return false;
                    }

                    for (i = 0; i < 21; i++) {
                        var txtObj = document.getElementById(SplitIds[i]);
                        var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                        txtObj.value = removeSplCharacters(tempVal);
                    }

                    //   return false;
                }
            }

        }
        function SaveData() {


            //Checking the balacne sheet bal and updating
            var lblDoYouChanges = document.getElementById('<%=lblDoYouChanges.ClientID%>').innerHTML
            var lblYourBal = document.getElementById('<%=lblYourBal.ClientID%>').innerHTML
            var strMsg = lblYourBal + document.getElementById(SplitIds[17]).value + '. ';
            if (document.getElementById(SplitIds[17]).value == 0 || document.getElementById(SplitIds[17]).value == '') {
                answer = confirm(lblDoYouChanges)
                if (answer == "0") {
                    document.getElementById('<%= hfValue1.ClientID %>').value = 0;
                    formatCellsWithComma();
                    //  return true;

                }
                else {

                    document.getElementById('<%= hfValue1.ClientID %>').value = 1;
                    var flg = false;
                    for (i = 0; i < 21; i++) {
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
                        return false;
                    }

                    for (i = 0; i < 21; i++) {
                        var txtObj = document.getElementById(SplitIds[i]);
                        var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                        txtObj.value = removeSplCharacters(tempVal);
                    }
                    //   return false;
                }
            }
            else {
                answer = confirm(strMsg + lblDoYouChanges)
                if (answer == "0") {
                    document.getElementById('<%= hfValue1.ClientID %>').value = 0;
                    formatCellsWithComma();
                    //    return true;
                }
                else {

                    document.getElementById('<%= hfValue1.ClientID %>').value = 1;
                    var flg = false;
                    for (i = 0; i < 21; i++) {
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
                        return false;
                    }

                    for (i = 0; i < 21; i++) {
                        var txtObj = document.getElementById(SplitIds[i]);
                        var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                        txtObj.value = removeSplCharacters(tempVal);
                    }

                    //   return false;
                }
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
