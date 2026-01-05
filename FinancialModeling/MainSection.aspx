<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="MainSection.aspx.cs" Inherits="FinancialModeling_MainSection"
    MaintainScrollPositionOnPostback="true" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function Clear() {

            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "radio") {
                    allInputs[i].checked = false;
                }
            }
        }
    </script>

    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="33" valign="top" class="sme_title">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="FINANCIAL MANAGEMENT TOOLKIT" meta:resourcekey="lblHeadingResource1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td width="100%" align="center">
                                    <table width="100%">
                                        <tr>
                                            <td class="Reportsbg">
                                                <table align="center">
                                                    <tr>
                                                        <td width="60px">
                                                            &nbsp;
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgbtnStatements" ToolTip="Statements" ImageUrl="~/images/icon-statements.png"
                                                                runat="server" OnClick="imgbtnStatements_Click" OnClientClick="return SaveData();"
                                                                Height="69px" meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                            <asp:Label ID="lblStatements" runat="server" Text="Statements" meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                runat="server" OnClick="imgbtnHome_Click" OnClientClick="return SaveData();"
                                                                meta:resourcekey="imgbtnHomeResource1" />
                                                            <br />
                                                            <asp:Label ID="lblHome" runat="server" Text="Home" meta:resourcekey="lblHomeResource1"></asp:Label>
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" OnClientClick="return SaveData();"
                                                                ImageUrl="~/images/icon-report.png" runat="server" OnClick="imgBtnGenerateReport_Click"
                                                                meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                            <asp:Label ID="lblReport" runat="server" Text="Report" meta:resourcekey="lblReportResource1"></asp:Label>
                                                        </td>
                                                        <td style="width: 90px" align="center">
                                                            <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                runat="server" OnClientClick="return SaveData();" OnClick="imgBtnHelp_Click"
                                                                meta:resourcekey="imgBtnHelpResource1" /><br />
                                                            <asp:Label ID="lblHelp" runat="server" Text="Help" meta:resourcekey="lblHelpResource1"></asp:Label>
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
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="300" valign="top">
                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    <table width="875" border="0" align="center" cellpadding="2" cellspacing="1">
                                        <tr valign="top">
                                            <td width="40" align="left" height="30">
                                                <asp:Label ID="lblQ1" runat="server" Text="Q1" meta:resourcekey="lblQ1Resource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblA1" runat="server" Text="Are you required to keep stocks for your business?"
                                                    meta:resourcekey="lblA1Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rblQ1" runat="server" RepeatDirection="Horizontal" onkeypress="return runScript(event)"
                                                    meta:resourcekey="rblQ1Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource1" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource2" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="40" align="left" height="30">
                                                <asp:Label ID="lblQ2" runat="server" Text="Q2" meta:resourcekey="lblQ2Resource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblA2" runat="server" Text="Do you have manufacturing activities?"
                                                    meta:resourcekey="lblA2Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rblQ2" runat="server" RepeatDirection="Horizontal" onkeypress="return runScript(event)"
                                                    meta:resourcekey="rblQ2Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource3" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource4" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="40" align="left" height="30">
                                                <asp:Label ID="lblQ3" runat="server" Text="Q3" meta:resourcekey="lblQ3Resource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Localize ID="locA3" runat="server"
                                                    Text="Do you have existing working capital loan?<br />
                                        (E.g. bank overdraft, trust receipt lines)" meta:resourcekey="locA3Resource1"></asp:Localize>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rblQ3" runat="server" RepeatDirection="Horizontal" onkeypress="return runScript(event)"
                                                    meta:resourcekey="rblQ3Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource5" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource6" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="40" align="left" height="30">
                                                <asp:Label ID="lblQ4" runat="server" Text="Q4" meta:resourcekey="lblQ4Resource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblA4" runat="server" Text="Do you have existing term loan or hire purchase loan?"
                                                    meta:resourcekey="lblA4Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rblQ4" runat="server" RepeatDirection="Horizontal" onkeypress="return runScript(event)"
                                                    meta:resourcekey="rblQ4Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource7" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource8" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="40" align="left" height="30">
                                                <asp:Label ID="lblQ5" runat="server" Text="Q5" meta:resourcekey="lblQ5Resource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Localize ID="locA5" runat="server" meta:resourcekey="lblWarrantyStatementResource1"
                                                    Text="Do you plan to incur capital expenditure for the next 3 years ?<br />
                                        (E.g. purchase of new equipment , renovation expenses, etc)"></asp:Localize>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rblQ5" runat="server" RepeatDirection="Horizontal" onkeypress="return runScript(event)"
                                                    meta:resourcekey="rblQ5Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource9" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource10" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="40" align="left" height="30">
                                                <asp:Label ID="lblQ6" runat="server" Text="Q6" meta:resourcekey="lblQ6Resource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblA6" runat="server" Text="For the planned capital expenditure, do you need to obtain bank loan?"
                                                    meta:resourcekey="lblA6Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rblQ6" runat="server" RepeatDirection="Horizontal" onkeypress="return runScript(event)"
                                                    meta:resourcekey="rblQ6Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource11" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource12" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                    <asp:Label ID="lblError" CssClass="ErrorMsg" runat="server" meta:resourcekey="lblErrorResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                        OnClick="btnSaveNext_Click" meta:resourcekey="btnSaveNextResource1" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" OnClick="btnClear_Click"
                                        meta:resourcekey="btnClearResource1" />
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click"
                                        OnClientClick="return SaveData();" meta:resourcekey="btnBackResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold; color:#000000">
                                    <asp:Label ID="lblImpToNote" runat="server" Text="Important To Note :" meta:resourcekey="lblImpToNoteResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFinRou" runat="server" Text="(1) Please enter all financials rounded to the nearest dollar."
                                        meta:resourcekey="lblFinRouResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMoreDetBusy" runat="server" Text="(2) If you want to have a more detailed business plan, you may like to prepare the
                            following information before you start" meta:resourcekey="lblMoreDetBusyResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 35px;">
                                    <asp:Label ID="lblRecords" runat="server" Text="(a) Records of your sales, cost of sales and operating expenses for your easy reference,
                            if available." meta:resourcekey="lblRecordsResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 35px;">
                                    <asp:Label ID="lblTheFin" runat="server" Text="(b) The financial statements of your business for the most recent past financial
                            year." meta:resourcekey="lblTheFinResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTheReport" runat="server" Text="(3) The report is generated based on your input and the comments are for reference
                            only." meta:resourcekey="lblTheReportResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblWeDoNot" runat="server" Text="(4) We do not warrant the accuracy of the analysis."
                                        meta:resourcekey="lblWeDoNotResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:HiddenField ID="hfValue" runat="server" />
                                 
                                </td>
                            </tr>
                            <tr style="display:none">
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblConfirm" runat="server" 
                                        Text="Do you want to save the changes you made?" 
                                        meta:resourcekey="lblConfirmResource1"></asp:Label>
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
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" DynamicServicePath=""
        Enabled="True" />

    <script type="text/javascript" language="javascript">
        function SaveData() {
            var lblConfirm = document.getElementById('<%=lblConfirm.ClientID%>').innerHTML
            answer = confirm(lblConfirm)
            if (answer == "0") {
                document.getElementById('<%= hfValue.ClientID %>').value = 0;
                return true;
            }
            else {
                document.getElementById('<%= hfValue.ClientID %>').value = 1;
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
