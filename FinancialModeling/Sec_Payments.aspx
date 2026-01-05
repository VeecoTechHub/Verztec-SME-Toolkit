<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Sec_Payments.aspx.cs" Inherits="FinancialModeling_Sec_Payments"
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
                                        <img src="../images/Icon02.png" width="48" height="47" alt="" />
                                    </td>
                                    <td>
                                        2. Cost of Sales & Payments
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
                            Enter the percentage of your purchases and the corresponding days to pay your suppliers.
                            For example, if 60% of your purchases are payable within 30 days, and 40% of your
                            purchases are payable within 45 days, enter 60% and 30 days in first row, and 40%
                            and 45 days in the second row, and so on. If you take on the average 35 days to
                            pay all your suppliers, just enter 100% and 35 days in the first row, and leave
                            the rest blank.
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
                                        % of Cost of Sales
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
                                        Number of days
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
                                        <asp:TextBox ID="txtCostOfSale1" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtNumberOfDays1" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcDaysTotal();"></asp:TextBox>
                                        day(s)
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
                                        <asp:TextBox ID="txtCostOfSale2" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtNumberOfDays2" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcDaysTotal();"></asp:TextBox>
                                        day(s)
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
                                        <asp:TextBox ID="txtCostOfSale3" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtNumberOfDays3" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcDaysTotal();"></asp:TextBox>
                                        day(s)
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
                                        <asp:TextBox ID="txtCostOfSale4" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtNumberOfDays4" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcDaysTotal();"></asp:TextBox>
                                        day(s)
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
                                        <%--  <asp:TextBox ID="txtCostOfSale5" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcSaleTotal();"></asp:TextBox>--%>
                                        <asp:Label ID="lblCostOfSale5" runat="server" Width="40px" style="text-align:right"></asp:Label>
                                        &nbsp;%
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <%-- <asp:TextBox ID="txtNumberOfDays5" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcDaysTotal();"></asp:TextBox>--%>
                                        <asp:Label ID="lblNumberOfDays5" runat="server" Width="40px" Text="0" style="text-align:right"></asp:Label>
                                        &nbsp;day(s)
                                    </td>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <strong>Total</strong>
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:Label ID="lblTotal" runat="server" Width="80px"></asp:Label>
                                    </td>
                                    <td colspan="3" align="right">
                                        <strong>Average</strong>
                                    </td>
                                    <td align="center" valign="middle" class="borderBLR">
                                        <asp:Label ID="lblAverageDays" runat="server" Width="40px" style="text-align:right"></asp:Label>
                                        &nbsp;day(s)
                                    </td>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        <strong>Analysis of your average collection days</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_Days">
                                    <td colspan="15">
                                        Last year, the average number of days it took for you to pay your suppliers was
                                        approximately
                                        <asp:Label ID="lblAvgPaymentDays" runat="server"></asp:Label>
                                        days.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        Based on the information that you have entered above, you will take approximately
                                        <asp:Label ID="lblAvgDays" runat="server"></asp:Label>
                                        days to pay your suppliers. For subsequent projections and financial analysis, you
                                        may either use this figure, or
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        Enter the average payment days you take to pay your suppliers here:
                                        <asp:TextBox ID="txtDays" runat="server" CssClass="timesheet_txt_bg" MaxLength="15" Style="width: 40px;"
                                            BorderWidth="1px" BorderColor="#348781" BorderStyle="Solid"></asp:TextBox>
                                        day(s)
                                        <br />
                                        (Optional)
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
                                OnClick="btnSaveNext_Click" />
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

        //Here u can write ur logic based on the value
        if (paramval == '0') {
            document.getElementById('tr_Days').style.display = 'none';
        }


        function Clear() {

            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "text") {
                    allInputs[i].value = "";
                }
            }
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

            document.getElementById('<%=lblCostOfSale5.ClientID%>').innerText = 100 - (parseFloat(Sales1) + parseFloat(Sales2) + parseFloat(Sales3) + parseFloat(Sales4));
            var Sales5 = document.getElementById('<%=lblCostOfSale5.ClientID%>').innerText;

            if (Sales5.trim() != "") {
                Sales5 = Sales5;
            }
            else
                Sales5 = 0;
            var total = (parseFloat(Sales1) + parseFloat(Sales2) + parseFloat(Sales3) + parseFloat(Sales4) + parseFloat(Sales5));
            document.getElementById('<%=lblTotal.ClientID%>').innerText = total + ' %';
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
            var Sales5 = document.getElementById('<%=lblCostOfSale5.ClientID%>').innerText

            var Days1 = document.getElementById('<%=txtNumberOfDays1.ClientID%>').value
            var Days2 = document.getElementById('<%=txtNumberOfDays2.ClientID%>').value
            var Days3 = document.getElementById('<%=txtNumberOfDays3.ClientID%>').value
            var Days4 = document.getElementById('<%=txtNumberOfDays4.ClientID%>').value
            var Days5 = document.getElementById('<%=lblNumberOfDays5.ClientID%>').innerText
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
            if (Sales5.trim() != "") {
                Sales5 = Sales5;
            }
            else
                Sales5 = 0;


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
            if (Days5.trim() != "") {
                Days5 = Days5;
            }
            else
                Days5 = 0;

            var total = (parseFloat(Sales1) * parseInt(Days1) + parseFloat(Sales2) * parseInt(Days2) + parseFloat(Sales3) * parseInt(Days3) + parseFloat(Sales4) * parseInt(Days4) + parseFloat(Sales5) * parseInt(Days5));
            total = Math.round(total / 100);
            document.getElementById('<%=lblAverageDays.ClientID%>').innerText = total;
            document.getElementById('<%=lblAvgDays.ClientID%>').innerText = total;

        }       

    </script>

</asp:Content>
