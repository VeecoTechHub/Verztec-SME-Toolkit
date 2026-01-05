<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="OperatingCost.aspx.cs" Inherits="FinancialModeling_OperatingCost"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">
        function backgroundFilter() {
            var div;
            if (document.getElementById)
                div = document.getElementById('backgroundFilter');
            else if (document.all)
                div = document.all['backgroundFilter'];
            if (div.style.display == '' && div.offsetWidth != undefined && div.offsetHeight != undefined)
                div.style.display = (div.offsetWidth != 0 && div.offsetHeight != 0) ? 'block' : 'none';
            div.style.display = (div.style.display == '' || div.style.display == 'block') ? 'none' : 'block';
        }
        function showpopUp() {

            //             $('#popUpNewTopicDiv').fadeIn('slow');
            var div;
            div = document.getElementById('popUpNewTopicDiv');
            div.style.display = "block"
            backgroundFilter();

        }
        function closepopUp() {

            //             $('#popUpNewTopicDiv').fadeIn('slow');
            var div;
            div = document.getElementById('popUpNewTopicDiv');
            div.style.display = "none"
            backgroundFilter();

        }
        function delay() {
            setTimeout('showpopUp()', 500)
        }      
          
        
    </script>--%>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    Financial Management Self-Evaluation Questionnaire</div>
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
                        <td>
                            <strong>3A. Other Operating Expenses</strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Other than the cost of sales and purchases, your business will naturally incur other
                            operating costs, including selling and distribution costs and other administration
                            expenses.
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Enter the variable selling & distribution expenses expressed as a percentage
                                of sales below:</strong><br />
                            For example, sales commission, selling & distributgion costs (such as freight outwards
                            and transportation charges), marketing expenses, etc.
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="874" border="0" align="center" cellpadding="3" cellspacing="1">
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
                                    <td width="115" align="center" bgcolor="#E9E9E9" valign="top">
                                        As a % of<br />
                                        Total Sales
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
                                    <td width="115">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        Variable Selling & Distribution Expenses
                                    </td>                                    
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTotalSalesPer" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;"></asp:TextBox>
                                        %
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
                                    <td colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        <strong>Enter the estimated other administrative expenses for the next 3 years below:</strong>
                                        <br />
                                        For example, salaries, rental expenses and telecommunication expenses, etc
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Do not include depreciation, amortisation and interests expenses.</strong>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" id="tdActual_1" valign="top">
                                        Actual<br />
                                        <asp:Label ID="lblEstimate" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9" id="tdActual_3">
                                        % of Increase
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top">
                                        Estimates<br />
                                        <asp:Label ID="lblProjYear1" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9">
                                        % of Increase
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top">
                                        Estimates<br />
                                        <asp:Label ID="lblProjYear2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9">
                                        % of Increase
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top">
                                        Estimates<br />
                                        <asp:Label ID="lblProjYear3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Other administrative expenses
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_2">
                                        $<asp:TextBox ID="txtOperatingExpenseEst" runat="server" MaxLength="15" Style="width: 75px;"
                                            class="InputBgColor" onchange="CalcEstimateP1Increase();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_4">
                                        <asp:TextBox ID="txtOperatingExpenseEstPer" runat="server" CssClass="InputBgColor"
                                            MaxLength="15" Style="width: 30px;" onchange="CalcEstimateP1Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtOperatingExpenseP1" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 75px;" onchange="CalcEstimateP2Increase();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtOperatingExpenseP1Per" runat="server" CssClass="InputBgColor"
                                            MaxLength="15" Style="width: 30px;" onchange="CalcEstimateP2Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:Label ID="lblOperatingExpenseP2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtOperatingExpenseP2Per" runat="server" CssClass="InputBgColor"
                                            MaxLength="15" Style="width: 30px;" onchange="CalcEstimateP3Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:Label ID="lblOperatingExpenseP3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        <strong>3B. Other Income</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        Your business may also receive other form of income other than the usual trade sources.
                                        Other income could be interest or rental income, if these are not the regular income
                                        expected in your trade.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Other Income</strong>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" id="tdActual_5" valign="top">
                                        Actual<br />
                                        <asp:Label ID="lblEstmate1" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9" id="tdActual_9">
                                        % of Increase
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top">
                                        Estimates<br />
                                        <asp:Label ID="lblProYear1" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9">
                                        % of Increase
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top">
                                        Estimates<br />
                                        <asp:Label ID="lblProYear2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" bgcolor="#E9E9E9">
                                        % of Increase
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" valign="top">
                                        Estimates<br />
                                        <asp:Label ID="lblProYear3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtRecurrIncome" runat="server" MaxLength="250" Style="width: 210px;text-align:left"
                                            class="InputBgColor"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_6">
                                        $<asp:TextBox ID="txtRecurrEst" runat="server" MaxLength="15" Style="width: 75px;"
                                            class="InputBgColor" onchange="CalculateActualTotal();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_10">
                                        <asp:TextBox ID="txtRecurrEstPer" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcRecurrEstIncrease();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtRecurrP1" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 75px;" onchange="CalculateEstimate1Total();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtRecurrP1Per" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcRecurrP1Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:Label ID="lblRecurrP2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtRecurrP2Per" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcRecurrP2Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:Label ID="lblRecurrP3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtNonRecurrIncome" runat="server" MaxLength="250" Style="width: 210px;text-align:left"
                                            class="InputBgColor"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_7">
                                        $<asp:TextBox ID="txtNonRecurrEst" runat="server" MaxLength="15" Style="width: 75px;"
                                            class="InputBgColor" onchange="CalculateActualTotal();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_11">
                                        <asp:TextBox ID="txtNonRecurrEstPer" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcNonRecurrEstIncrease();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtNonRecurrP1" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 75px;" onchange="CalculateEstimate1Total();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtNonRecurrP1Per" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcNonRecurrP1Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:Label ID="lblNonRecurrP2" runat="server"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtNonRecurrP2Per" runat="server" CssClass="InputBgColor" MaxLength="15"
                                            Style="width: 30px;" onchange="CalcNonRecurrP2Increase();"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:Label ID="lblNonRecurrP3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <strong>Total</strong>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_8">
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
                                    <td align="center">
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
                                    <td align="center">
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
                                    <td align="center">
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
                            <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                OnClick="btnSaveNext_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" OnClientClick="Clear()" />
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                            <asp:HiddenField ID="hfValue" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%-- <div id="backgroundFilter">
    </div>
    <div id="popUpNewTopicDiv" class="popUpClass" style="display: none; width: 500px;
        height: 180px; left: 400px;">
        <table width="100%">
            <tr height="100px">
                <td valign="top">
                    It refers to fixed cash expenses that your business needs to incur, such as payroll,
                    CPF, foreign workers levy, rental charges, telephone charges, utilities, etc. Please
                    also remember to include expenses that are incurred once a year, such as annual
                    wage supplement and bonuses, secretarial & audit fees etc) Please do not include
                    depreciation, amortisation charges and interests costs. If you have entered the
                    factory costs under Section 2, please do not include it here again.
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input type="button" id="btn1" value="Ok" class="orange_button" onclick="closepopUp();"
                        style="width: 80px;" />
                </td>
            </tr>
        </table>
    </div>--%>
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

            for (i = 1; i <= 11; i++) {
                var tdCell = document.getElementById('tdActual_' + i.toString());
                //                var inputs = tdCell.getElementsByTagName('input');
                //                for (var j = 0; j < inputs.length; j++) {
                //                    //                    document.getElementById(inputs[j].id).style.visibility = 'hidden';
                //                    if (i != 1) {
                //                        document.getElementById(inputs[j].id).disabled = true;
                //                        document.getElementById(inputs[j].id).style.backgroundColor = 'White';
                //                    }

                //                }

                document.getElementById('tdActual_' + i.toString()).innerHTML = '';
                if (i == 1 || i == 3 || i == 5 || i == 9)
                document.getElementById('tdActual_' + i.toString()).style.backgroundColor = 'White';

                //document.getElementById('tdActual_' + i.toString()).style.backgroundColor = 'gray';
            }

        }
        function NavigatePage() {
            window.location = 'funding_structure.htm?Id=' + paramval;
        }
        function Clear() {

            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "text") {
                    allInputs[i].value = "";
                }
            }
        }
       
        function CalcEstimateP1Increase() {

            var txtServices = document.getElementById('<%=txtOperatingExpenseEst.ClientID%>').value
            var Percent = document.getElementById('<%=txtOperatingExpenseEstPer.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=txtOperatingExpenseP1.ClientID%>').value = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
            }
            CalcEstimateP2Increase();

        }
        function CalcEstimateP2Increase() {

            var txtServices = document.getElementById('<%=txtOperatingExpenseP1.ClientID%>').value
            var Percent = document.getElementById('<%=txtOperatingExpenseP1Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblOperatingExpenseP2.ClientID%>').innerText = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
            }
            CalcEstimateP3Increase();
        }
        function CalcEstimateP3Increase() {

            var txtServices = document.getElementById('<%=lblOperatingExpenseP2.ClientID%>').innerText
            var Percent = document.getElementById('<%=txtOperatingExpenseP2Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblOperatingExpenseP3.ClientID%>').innerText = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * Percent) / 100);
            }
        }




        //Other Income section


        function CalculateActualTotal() {

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
            CalcRecurrEstIncrease();
            CalcNonRecurrEstIncrease();
           
        }
        function CalculateEstimate1Total() {

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
            CalcRecurrP1Increase();
            CalcNonRecurrP1Increase();           

        }
        function CalculateEstimate2Total() {

            var Val1 = document.getElementById('<%=lblRecurrP2.ClientID%>').innerText
            var Val2 = document.getElementById('<%=lblNonRecurrP2.ClientID%>').innerText
            if (Val1 != "NaN") {
                Val1 = Val1;
            }
            else
                Val1 = 0;
            if (Val2 != "NaN") {
                Val2 = Val2;
            }
            else
                Val2 = 0;
            document.getElementById('<%=lblIncomeP2Total.ClientID%>').innerText = parseFloat(Val1) + parseFloat(Val2);

        }
        function CalculateEstimate3Total() {
            var Val1 = document.getElementById('<%=lblRecurrP3.ClientID%>').innerText
            var Val2 = document.getElementById('<%=lblNonRecurrP3.ClientID%>').innerText
            if (Val1 != "NaN") {
                Val1 = Val1;
            }
            else
                Val1 = 0;
            if (Val2 != "NaN") {
                Val2 = Val2;
            }
            else
                Val2 = 0;
            document.getElementById('<%=lblIncomeP3Total.ClientID%>').innerText = parseFloat(Val1) + parseFloat(Val2);
        }


        //Recurring Income
        function CalcRecurrEstIncrease() {

            var txtGoods = document.getElementById('<%=txtRecurrEst.ClientID%>').value
            var Percent = document.getElementById('<%=txtRecurrEstPer.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=txtRecurrP1.ClientID%>').value = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                CalculateEstimate1Total();
                CalcRecurrP1Increase();
            }

        }

        function CalcRecurrP1Increase() {

            var txtGoods = document.getElementById('<%=txtRecurrP1.ClientID%>').value
            var Percent = document.getElementById('<%=txtRecurrP1Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblRecurrP2.ClientID%>').innerText = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                CalculateEstimate2Total();
                CalcRecurrP2Increase();

            }


        }
        function CalcRecurrP2Increase() {

            var txtGoods = document.getElementById('<%=lblRecurrP2.ClientID%>').innerText
            var Percent = document.getElementById('<%=txtRecurrP2Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblRecurrP3.ClientID%>').innerText = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * Percent) / 100);
                CalculateEstimate3Total();
            }

        }
        // Non Recurring Income
        function CalcNonRecurrEstIncrease() {

            var txtMfSale = document.getElementById('<%=txtNonRecurrEst.ClientID%>').value
            var Percent = document.getElementById('<%=txtNonRecurrEstPer.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=txtNonRecurrP1.ClientID%>').value = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * Percent) / 100);
                CalculateEstimate1Total();
                CalcNonRecurrP1Increase();
            }

        }
        function CalcNonRecurrP1Increase() {

            var txtMfSale = document.getElementById('<%=txtNonRecurrP1.ClientID%>').value
            var Percent = document.getElementById('<%=txtNonRecurrP1Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblNonRecurrP2.ClientID%>').innerText = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * Percent) / 100);
                CalculateEstimate2Total();
                CalcNonRecurrP2Increase();
            }

        }
        function CalcNonRecurrP2Increase() {

            var txtMfSale = document.getElementById('<%=lblNonRecurrP2.ClientID%>').innerText
            var Percent = document.getElementById('<%=txtNonRecurrP2Per.ClientID%>').value
            if (Percent.trim() != "") {
                document.getElementById('<%=lblNonRecurrP3.ClientID%>').innerText = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * Percent) / 100);
                CalculateEstimate3Total();
            }


        }

    </script>
</asp:Content>
