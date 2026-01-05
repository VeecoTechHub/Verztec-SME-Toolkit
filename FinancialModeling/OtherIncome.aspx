<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="OtherIncome.aspx.cs" Inherits="FinancialModeling_OtherIncome"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    FINANCIAL MANAGEMENT TOOLKIT</div>
            </td>
        </tr>
        <tr>
            <td height="300" valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="77" class="titleBar">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="84" align="center">
                                        <img src="../images/Icon05.png" width="48" height="47" alt="" />
                                    </td>
                                    <td>
                                        3. Other Operating Expenses & Income
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
                            <strong>3B. Other Income</strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Your business may also receive other form of income other than the usual trade sources.
                            Other income could be interest or rental income, if these are not the regular income
                            expected in your trade.
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
                                    <td width="214" class="border">
                                        <strong>Other Income</strong>
                                    </td>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" id="tdActual_1" valign="top" width="115" class="border">
                                        Actual<br />
                                        <asp:Label ID="lblEstmate1" runat="server"></asp:Label>
                                    </td>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9" id="tdActual_5" width="60" class="border">
                                        % of Increase
                                    </td>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top" width="115" class="border">
                                        Estimates<br />
                                        <asp:Label ID="lblProYear1" runat="server"></asp:Label>
                                    </td>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9" width="60" class="border">
                                        % of Increase
                                    </td>
                                    <td align="center" width="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top" width="115" class="border">
                                        Estimates<br />
                                        <asp:Label ID="lblProYear2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center" width="3">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9" width="60" class="border">
                                        % of Increase
                                    </td>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top" width="115" class="border">
                                        Estimates<br />
                                        <asp:Label ID="lblProYear3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borderBLR">
                                        <asp:TextBox ID="txtRecurrIncome" runat="server" MaxLength="250" Style="width: 210px;
                                            text-align: left" class="timesheet_txt_bg"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_2" class="borderBLR">
                                        $<asp:TextBox ID="txtRecurrEst" runat="server" MaxLength="15" Style="width: 75px;"
                                            class="timesheet_txt_bg" onchange="CalculateActualTotal();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_6" class="borderBLR">
                                        <asp:TextBox ID="txtRecurrEstPer" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcRecurrEstIncrease();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        $<asp:TextBox ID="txtRecurrP1" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 75px;" onchange="CalculateEstimate1Total();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtRecurrP1Per" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcRecurrP1Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        $<asp:Label ID="lblRecurrP2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtRecurrP2Per" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcRecurrP2Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        $<asp:Label ID="lblRecurrP3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borderBLR">
                                        <asp:TextBox ID="txtNonRecurrIncome" runat="server" MaxLength="250" Style="width: 210px;
                                            text-align: left" class="timesheet_txt_bg"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_3" class="borderBLR">
                                        $<asp:TextBox ID="txtNonRecurrEst" runat="server" MaxLength="15" Style="width: 75px;"
                                            class="timesheet_txt_bg" onchange="CalculateActualTotal();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_7" class="borderBLR">
                                        <asp:TextBox ID="txtNonRecurrEstPer" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcNonRecurrEstIncrease();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        $<asp:TextBox ID="txtNonRecurrP1" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 75px;" onchange="CalculateEstimate1Total();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtNonRecurrP1Per" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcNonRecurrP1Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        $<asp:Label ID="lblNonRecurrP2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtNonRecurrP2Per" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcNonRecurrP2Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        $<asp:Label ID="lblNonRecurrP3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="borderBLR">
                                        <strong>Total</strong>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_4" class="borderBLR">
                                        $<asp:Label ID="lblIncomeEstTotal" runat="server"></asp:Label>
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
                                        $<asp:Label ID="lblIncomeP1Total" runat="server"></asp:Label>
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
                                        $<asp:Label ID="lblIncomeP2Total" runat="server"></asp:Label>
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
                                        $<asp:Label ID="lblIncomeP3Total" runat="server"></asp:Label>
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
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click" />
                            <asp:Button ID="btnHome" runat="server" Text="Home" CssClass="orange_button" OnClick="btnHome_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" 
                                onclick="btnClear_Click"  />
                            <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                OnClick="btnSaveNext_Click" OnClientClick="return IsValid();" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        //querystring.js - Contains functions to extract querystring parameters from URL
        //The parameters are loaded into the associative array queryString[].

        //In open JavaScript (not inside a function), define the array
        var queryString = new Array();
        // and then pull the querystyring parameters from the URL.
        // The search property of the window location returns the query string.
        // The method substring(1) removes the first character (the question mark).
        // The split function then copies the parameters into an array called "parms"
        var parameters = window.location.search.substring(1).split('&');
        // For each element in the array, find the equal sign that separates the parameter
        // name from the parameter value.  If there is one, divide the expression into
        // the parameter name

        for (var i = 0; i < parameters.length; i++) {

            var pos = parameters[i].indexOf('=');
            // If there is an equal sign, separate the parameter into the name and value,
            // and store it into the queryString array.
            if (pos > 0) {
                var paramname = parameters[i].substring(0, pos);
                var paramval = parameters[i].substring(pos + 1);
                //Here u can write ur logic based on the value
                if (paramval == '0') {

                    //                    document.getElementById('trYes').style.display = 'none';
                }
                else {
                    //                    document.getElementById('trNo').style.display = 'none';

                }

                queryString[paramname] = unescape(paramval.replace(/\+/g, ' '));
            } else {
                //special value when there is a querystring parameter with no value
                queryString[parameters[i]] = ""
            }
        }
        //Hiding the actual yr tds
        if (paramval == '0') {

            for (i = 1; i <= 7; i++) {

                document.getElementById('tdActual_' + i.toString()).innerHTML = '';
                document.getElementById('tdActual_' + i.toString()).style.backgroundColor = '#fbfbfb';
                document.getElementById('tdActual_' + i.toString()).style.border = 'none';
            }

        }

        function Clear() {

            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "text") {
                    allInputs[i].value = "";
                }
            }
        }
        //Other Income section


        function CalculateActualTotal() {
            var flag1 = checkFormat(document.getElementById('<%=txtRecurrEst.ClientID%>').value);
            var flag2 = checkFormat(document.getElementById('<%=txtNonRecurrEst.ClientID%>').value);

            if (flag1 == false || flag2 == false) {
                alert("Given value is not in a correct format");
            }
            else {

                formatCellsWithoutComma();

                var txt1 = document.getElementById('<%=txtRecurrEst.ClientID%>').value
                var txt2 = document.getElementById('<%=txtNonRecurrEst.ClientID%>').value
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
                document.getElementById('<%=lblIncomeEstTotal.ClientID%>').innerText = parseFloat(txt1) + parseFloat(txt2);
                formatCellsWithComma();
                CalcRecurrEstIncrease();
                CalcNonRecurrEstIncrease();
            }

        }
        function CalculateEstimate1Total() {
            var flag1 = checkFormat(document.getElementById('<%=txtRecurrP1.ClientID%>').value);
            var flag2 = checkFormat(document.getElementById('<%=txtNonRecurrP1.ClientID%>').value);

            if (flag1 == false || flag2 == false) {
                alert("Given value is not in a correct format");
            }
            else {

                formatCellsWithoutComma();
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
                document.getElementById('<%=lblIncomeP1Total.ClientID%>').innerText = parseFloat(txt1) + parseFloat(txt2);
                formatCellsWithComma();
                CalcRecurrP1Increase();
                CalcNonRecurrP1Increase();
            }

        }
        function CalculateEstimate2Total() {
            formatCellsWithoutComma();
            var Val1 = document.getElementById('<%=lblRecurrP2.ClientID%>').innerText
            var Val2 = document.getElementById('<%=lblNonRecurrP2.ClientID%>').innerText
            document.getElementById('<%=lblIncomeP2Total.ClientID%>').innerText = parseFloat(checkNanCondition(Val1)) + parseFloat(checkNanCondition(Val2));
            formatCellsWithComma();

        }
        function CalculateEstimate3Total() {
            formatCellsWithoutComma();
            var Val1 = document.getElementById('<%=lblRecurrP3.ClientID%>').innerText
            var Val2 = document.getElementById('<%=lblNonRecurrP3.ClientID%>').innerText
            document.getElementById('<%=lblIncomeP3Total.ClientID%>').innerText = parseFloat(checkNanCondition(Val1)) + parseFloat(checkNanCondition(Val2));
            formatCellsWithComma();
        }


        //Recurring Income
        function CalcRecurrEstIncrease() {
            var flag = checkFormat(document.getElementById('<%=txtRecurrEst.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtGoods = document.getElementById('<%=txtRecurrEst.ClientID%>').value
                var Percent = document.getElementById('<%=txtRecurrEstPer.ClientID%>').value
                if (Percent.trim() != "") {
                    document.getElementById('<%=txtRecurrP1.ClientID%>').value = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                    formatCellsWithComma();
                    CalculateEstimate1Total();
                    CalcRecurrP1Increase();
                }
                formatCellsWithComma();
            }

        }

        function CalcRecurrP1Increase() {
            var flag = checkFormat(document.getElementById('<%=txtRecurrP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtGoods = document.getElementById('<%=txtRecurrP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtRecurrP1Per.ClientID%>').value
                if (Percent.trim() != "") {
                    document.getElementById('<%=lblRecurrP2.ClientID%>').innerText = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                    formatCellsWithComma();
                    CalculateEstimate2Total();
                    CalcRecurrP2Increase();

                }
                formatCellsWithComma();
            }

        }
        function CalcRecurrP2Increase() {

            formatCellsWithoutComma();
            var txtGoods = document.getElementById('<%=lblRecurrP2.ClientID%>').innerText
            var Percent = document.getElementById('<%=txtRecurrP2Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblRecurrP3.ClientID%>').innerText = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                formatCellsWithComma();
                CalculateEstimate3Total();
            }
            formatCellsWithComma();

        }
        // Non Recurring Income
        function CalcNonRecurrEstIncrease() {
            var flag = checkFormat(document.getElementById('<%=txtNonRecurrEst.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtMfSale = document.getElementById('<%=txtNonRecurrEst.ClientID%>').value
                var Percent = document.getElementById('<%=txtNonRecurrEstPer.ClientID%>').value
                if (Percent.trim() != "") {
                    document.getElementById('<%=txtNonRecurrP1.ClientID%>').value = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * Percent) / 100);
                    formatCellsWithComma();
                    CalculateEstimate1Total();
                    CalcNonRecurrP1Increase();
                }
                formatCellsWithComma();
            }

        }
        function CalcNonRecurrP1Increase() {

            var flag = checkFormat(document.getElementById('<%=txtNonRecurrP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtMfSale = document.getElementById('<%=txtNonRecurrP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtNonRecurrP1Per.ClientID%>').value
                if (Percent.trim() != "") {
                    document.getElementById('<%=lblNonRecurrP2.ClientID%>').innerText = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * Percent) / 100);
                    formatCellsWithComma();
                    CalculateEstimate2Total();
                    CalcNonRecurrP2Increase();
                }
                formatCellsWithComma();
            }

        }
        function CalcNonRecurrP2Increase() {

            formatCellsWithoutComma();
            var txtMfSale = document.getElementById('<%=lblNonRecurrP2.ClientID%>').innerText
            var Percent = document.getElementById('<%=txtNonRecurrP2Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblNonRecurrP3.ClientID%>').innerText = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * Percent) / 100);
                formatCellsWithComma();
                CalculateEstimate3Total();
            }
            formatCellsWithComma();

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
                    txtObj.style.backgroundColor = '#DC7171';
                }
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }
            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(lblObj.innerText);
                lblObj.innerText = removeSplCharacters(tempVal);
            }

            if (flg == true) {
                alert("Given values are not in a correct format");
                return false;
            }
            return confirm('Are you sure, you want to save the data.');
        }
        function formatCellsWithComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);

                var val = document.getElementById(SplitIds[i]).value;

                txtObj.value = includeComma(val, 3);
            }

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);

                var val = document.getElementById(lblSplitIds[i]).innerText;

                lblObj.innerText = includeComma(val, 3);
            }

        }


        function formatCellsWithoutComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                //                var val = document.getElementById(SplitIds[i]).value;
                txtObj.value = removeSplCharacters(tempVal);
            }

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(lblObj.innerText);
                //                var val = document.getElementById(lblSplitIds[i]).innerText;
                lblObj.innerText = removeSplCharacters(tempVal);
            }

        }

    </script>

</asp:Content>
