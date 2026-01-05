<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="FundingCapitalLoan.aspx.cs" Inherits="FinancialModeling_FundingCapitalLoan"
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
                                        <img src="../images/Icon04.png" width="48" height="47" alt="" />
                                    </td>
                                    <td>
                                        4. Funding
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
                            <strong>Existing Working Capital Loan</strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Working capital loans include letters of credit, trust receipts, short term advances,
                            revolving credit, etc., to name a few. Working capital loan is obtained to meet
                            your day-to-day operational cash requirements of your trade prior to collections
                            from your customers.
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
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td align="center" width="106">
                                        &nbsp;
                                    </td>
                                    <td align="center" width="7">
                                        &nbsp;
                                    </td>
                                    <td align="center" width="120">
                                        &nbsp;
                                    </td>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" width="96">
                                        &nbsp;
                                    </td>
                                    <td align="center" width="7">
                                        &nbsp;
                                    </td>
                                    <td align="center" width="106">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left">
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        If you pledge cash / fixed deposits to the banks as collateral for trade
                                        <br />
                                        credit facilities, please enter the amount that is pledged to your banks
                                    </td>
                                    <td align="center" class="border">
                                        $<asp:TextBox ID="txtCapitalLoan1" runat="server" Style="width: 90px;" class="timesheet_txt_bg"
                                            MaxLength="15" onchange="FormatCells(this.value);"></asp:TextBox>
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
                                    <td colspan="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left">
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        Enter the total credit limit of working capital loan?<br />
                                        (Please exclude foreign exchange lines & term loans)
                                    </td>
                                    <td align="center" class="border">
                                        $<asp:TextBox ID="txtCapitalLoan2" runat="server" Style="width: 90px;" class="timesheet_txt_bg"
                                            MaxLength="15" onchange="FormatCells(this.value);"></asp:TextBox>
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
                                    <td colspan="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left">
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        Enter the letter of credit limit included in the total credit lines.
                                    </td>
                                    <td align="center" class="border">
                                        $<asp:TextBox ID="txtCapitalLoan3" runat="server" Style="width: 90px;" class="timesheet_txt_bg"
                                            MaxLength="15" onchange="FormatCells(this.value);"></asp:TextBox>
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
                                    <td colspan="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left">
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        Enter the letter of credit utilisation amount as at the last financial year end.
                                    </td>
                                    <td align="center" class="border">
                                        $<asp:TextBox ID="txtCapitalLoan4" runat="server" Style="width: 90px;" class="timesheet_txt_bg"
                                            MaxLength="15" onchange="FormatCells(this.value);"></asp:TextBox>
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
                                    <td colspan="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left">
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        Enter the average interest rate that you are paying for the working capital loans
                                    </td>
                                    <td align="center" class="border">
                                        <asp:TextBox ID="txtCapitalLoanPer" runat="server" Style="width: 40px;" class="timesheet_txt_bg"
                                            MaxLength="15"></asp:TextBox>%
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
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click" />
                            <asp:Button ID="btnHome" runat="server" Text="Home" CssClass="orange_button" OnClick="btnHome_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" 
                                onclick="btnClear_Click" />
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

        //In open JavaScript (not inside a function), define the array
        var queryString = new Array();
        var parameters = window.location.search.substring(1).split('&');

        for (var i = 0; i < parameters.length; i++) {

            var pos = parameters[i].indexOf('=');
            // If there is an equal sign, separate the parameter into the name and value,
            // and store it into the queryString array.
            if (pos > 0) {
                var paramname = parameters[i].substring(0, pos);
                var paramval = parameters[i].substring(pos + 1);
                //Here u can write ur logic based on the value               

                queryString[paramname] = unescape(paramval.replace(/\+/g, ' '));
            } else {
                //special value when there is a querystring parameter with no value
                queryString[parameters[i]] = ""
            }
        }



        //Hiding the actual yr tds
        if (paramval == '0') {

//            for (i = 1; i <= 3; i++) {

//                document.getElementById('tdActual_' + i.toString()).innerHTML = '';
//                document.getElementById('tdActual_' + i.toString()).style.backgroundColor = 'White';
//            }

        }

        function Clear() {

            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "text") {
                    allInputs[i].value = "";
                }
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
                    txtObj.style.backgroundColor = '#DC7171';
                }
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                txtObj.value = removeSplCharacters(tempVal);
            }

            if (flg == true) {
                alert("Given values are not in a correct format");
                return false;
            }
            return confirm('Are you sure, you want to save the data.');
        }

        function FormatCells(val) {
            var flag = checkFormat(val);
            if (flag == false) {
                alert("Given values are not in a correct format");
            }
            else {
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
        
    </script>

</asp:Content>
