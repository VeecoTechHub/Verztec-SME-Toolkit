<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Sec_Stock.aspx.cs" Inherits="FinancialModeling_Sec_Stock"
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
                            You will need to keep stocks to ensure availability of goods to supply to your customers
                            as and when they place orders with you. The level of stocks will typically based
                            on the lead time you need to replenish the stocks.
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>2C. Understanding your purchase & delivery cycle.</strong>
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
                                    <td align="center" width="115">
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
                                    <td align="center" width="115">
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
                                    <td width="115">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        <strong>In your business, how many days does it take on the average to ….</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        (a) Have the suppliers deliver the goods to you after you have placed your order?
                                    </td>
                                    <td align="center" class="border">
                                        <asp:TextBox ID="txtOnTheAverageDays1" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcAvgDaysTotal();"></asp:TextBox>
                                        day(s)
                                    </td>
                                    <td colspan="8">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        (b) Receive the goods after it has been shipped to you?
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtOnTheAverageDays2" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcAvgDaysTotal();"></asp:TextBox>
                                        day(s)
                                    </td>
                                    <td colspan="8">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        (c) Process the goods (manufacture, packing, etc) ?
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtOnTheAverageDays3" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcAvgDaysTotal();"></asp:TextBox>
                                        day(s)
                                    </td>
                                    <td colspan="8">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        (d) Transport the goods and bill your customer?
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtOnTheAverageDays4" runat="server" MaxLength="15" Style="width: 40px;"
                                            class="timesheet_txt_bg" onchange="CalcAvgDaysTotal();"></asp:TextBox>
                                        day(s)
                                    </td>
                                    <td colspan="8">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <strong>Total</strong>
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:Label ID="lblAvgDaysTotal" runat="server" Width="40px" style="text-align:right"></asp:Label>&nbsp;day(s)
                                    </td>
                                    <td colspan="8">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        <strong>Analysis of your average stock holding days</strong>
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
                                        <asp:Label ID="lblAvgNumOfDays" runat="server"></asp:Label>
                                        days.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15" id="td2">
                                        Based on the information that you have entered above, you will need to keep approximately
                                        <asp:Label ID="lblAvgStockPeriod" runat="server"></asp:Label>
                                        days worth of stocks to meet your customers' orders promptly, assuming that customers'
                                        orders are constant during the period. Otherwise, the stock levels must be adjusted
                                        to cater to seasonal fluctuation of demands.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;For subsequent projections and financial analysis, you may either use this
                                        figure, or
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" colspan="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="15">
                                        Enter the average stock holding days here:
                                        <asp:TextBox ID="txtAvgStockDays" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" BorderWidth="1px" BorderColor="#348781" BorderStyle="Solid"></asp:TextBox>
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
                                onclick="btnClear_Click" />
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

            document.getElementById('<%=lblAvgDaysTotal.ClientID%>').innerText = (parseInt(Days1) + parseInt(Days2) + parseInt(Days3) + parseInt(Days4));
            document.getElementById('<%=lblAvgStockPeriod.ClientID%>').innerText = (parseInt(Days1) + parseInt(Days2) + parseInt(Days3) + parseInt(Days4));

        }

    </script>

</asp:Content>
