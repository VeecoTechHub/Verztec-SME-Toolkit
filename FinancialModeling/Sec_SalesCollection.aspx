<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Sec_SalesCollection.aspx.cs" Inherits="FinancialModeling_Sec_SalesCollection"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        var queryString = new Array();
        var parameters = window.location.search.substring(1).split('&');

        for (var i = 0; i < parameters.length; i++) {
            var pos = parameters[i].indexOf('=');

            if (pos > 0) {
                var paramname = parameters[i].substring(0, pos);
                var paramval = parameters[i].substring(pos + 1);


                queryString[paramname] = unescape(paramval.replace(/\+/g, ' '));
            } else {
                //special value when there is a querystring parameter with no value
                queryString[parameters[i]] = ""
            }
        }


    </script>

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
                                        <img src="../images/icon01.png" width="48" height="47" alt="" />
                                    </td>
                                    <td>
                                        1. Sales & Collections
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
                            Enter the percentage of your total sales and the corresponding days you take to
                            collect from your customers. For example, if 60% of your sales, you collection within
                            30 days, and 40% of sales, you collect in 45 days, enter 60% and 30 days in first
                            row, and 40% and 45 days in the second row, and so on.
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td width="214" valign="top">
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="115">
                                        &nbsp;
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="60">
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="115" align="center" bgcolor="#E9E9E9" class="border">
                                        % Sale
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="60">
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="115" align="center" bgcolor="#E9E9E9" class="border">
                                        Number of days
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="60">
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="115">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtSales1" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtDays1" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcDaysTotal();"></asp:TextBox>
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
                                        <asp:TextBox ID="txtSales2" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtDays2" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcDaysTotal();"></asp:TextBox>
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
                                        <asp:TextBox ID="txtSales3" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtDays3" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcDaysTotal();"></asp:TextBox>
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
                                        <asp:TextBox ID="txtSales4" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcSaleTotal();"></asp:TextBox>
                                        %
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:TextBox ID="txtDays4" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcDaysTotal();"></asp:TextBox>
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
                                        <%--  <asp:TextBox ID="txtSales5" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcSaleTotal();"></asp:TextBox>--%>
                                        <asp:Label ID="lblSales5" runat="server" Width="40px" style="text-align:right"></asp:Label>
                                        &nbsp;%
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <%--  <asp:TextBox ID="txtDays5" runat="server" CssClass="timesheet_txt_bg" MaxLength="15"
                                            Style="width: 40px;" onchange="CalcDaysTotal();"></asp:TextBox>--%>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblDays5" runat="server" Text="0" Width="30px" style="text-align:right"></asp:Label>
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
                                        &nbsp;<asp:Label ID="lblTotal" runat="server" Width="80px"></asp:Label>
                                    </td>
                                    <td colspan="3" align="right">
                                        <strong>Average</strong>
                                    </td>
                                    <td align="center" class="borderBLR">
                                        <asp:Label ID="lblAvgNumberofDays" runat="server" Width="40px" style="text-align:right"></asp:Label>
                                        &nbsp;day(s)
                                    </td>
                                    <td colspan="3">
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
                        <td>
                            <strong>Analysis of your average collection days</strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr_Days">
                        <td>
                            Last year, the average number of days it took for you to collect from your customers
                            was approximately
                            <asp:Label ID="lblCollectionDays" runat="server"></asp:Label>
                            days.
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Based on the information that you have entered above, on the average you take approximately
                            <asp:Label ID="lblAvgDays" runat="server"></asp:Label>&nbsp; days to collect from
                            your customers. For subsequent projections and financial analysis, you may either
                            use this figure, or
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Enter the average collection days you take to collect from your customers :
                            <asp:TextBox ID="txtDays" runat="server" CssClass="timesheet_txt_bg" MaxLength="15" Style="width: 40px;"
                                BorderWidth="1px" BorderColor="#348781" BorderStyle="Solid"></asp:TextBox>
                            day(s)
                            <br />
                            (Optional)
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

            var Sales1 = document.getElementById('<%=txtSales1.ClientID%>').value
            var Sales2 = document.getElementById('<%=txtSales2.ClientID%>').value
            var Sales3 = document.getElementById('<%=txtSales3.ClientID%>').value
            var Sales4 = document.getElementById('<%=txtSales4.ClientID%>').value


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

            document.getElementById('<%=lblSales5.ClientID%>').innerText = 100 - (parseFloat(Sales1) + parseFloat(Sales2) + parseFloat(Sales3) + parseFloat(Sales4));
            var Sales5 = document.getElementById('<%=lblSales5.ClientID%>').innerText;
            //            if (Sales5.trim() != "") {
            //                Sales5 = Sales5;
            //            }
            //            else
            //                Sales5 = 0;
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

            var Sales1 = document.getElementById('<%=txtSales1.ClientID%>').value
            var Sales2 = document.getElementById('<%=txtSales2.ClientID%>').value
            var Sales3 = document.getElementById('<%=txtSales3.ClientID%>').value
            var Sales4 = document.getElementById('<%=txtSales4.ClientID%>').value
            var Sales5 = document.getElementById('<%=lblSales5.ClientID%>').innerText

            var Days1 = document.getElementById('<%=txtDays1.ClientID%>').value
            var Days2 = document.getElementById('<%=txtDays2.ClientID%>').value
            var Days3 = document.getElementById('<%=txtDays3.ClientID%>').value
            var Days4 = document.getElementById('<%=txtDays4.ClientID%>').value
            var Days5 = document.getElementById('<%=lblDays5.ClientID%>').innerText

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
            document.getElementById('<%=lblAvgNumberofDays.ClientID%>').innerText = total;
            document.getElementById('<%=txtDays.ClientID%>').innerText = total;
            document.getElementById('<%=lblAvgDays.ClientID%>').innerText = total;
        }
    </script>

</asp:Content>
