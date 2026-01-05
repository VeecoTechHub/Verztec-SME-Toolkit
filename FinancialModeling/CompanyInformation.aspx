<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="CompanyInformation.aspx.cs" Inherits="FinancialModeling_CompanyInformation"
    MaintainScrollPositionOnPostback="true" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="33" valign="top" class="sme_title">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="SME Financial Modeling Tool" meta:resourcekey="lblHeadingResource2" 
                                ></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr id="TR1" runat="server">
                    <td align="center" runat="server">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td width="100%" align="center">
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
                                                                meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                            <asp:Label ID="lblStatements" runat="server" Text="Statements" 
                                                                meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                runat="server" OnClick="imgbtnHome_Click" 
                                                                meta:resourcekey="imgbtnHomeResource1" />
                                                            <br />
                                                            <asp:Label ID="lblHome" runat="server" Text="Home" 
                                                                meta:resourcekey="lblHomeResource1"></asp:Label>
                                                        </td>
                                                        <td width="90px" align="center">
                                                            <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" ImageUrl="~/images/icon-report.png"
                                                                runat="server" OnClick="imgBtnGenerateReport_Click" 
                                                                meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                            <asp:Label ID="lblReport" runat="server" Text="Report" 
                                                                meta:resourcekey="lblReportResource1"></asp:Label>
                                                        </td>
                                                        <td style="width: 90px" align="center">
                                                            <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                runat="server" PostBackUrl="~/FinancialModeling/Help.aspx" 
                                                                meta:resourcekey="imgBtnHelpResource1" /><br />
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
                <tr id="TR2" runat="server">
                    <td runat="server">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="300" valign="top">
                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Localize ID="locParagraph1" runat="server" 
                                        Text="The sound management of any business requires the in-depth knowledge of your business.
                            It has been said that you can’t manage what you can’t measure. Gone are the days
                            when businesses can be run at the back of the head or on scrap pieces of paper.
                            The business world today is much too complex for that kind of management practices!" 
                                        meta:resourcekey="locParagraph1Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Localize ID="locParagraph2" runat="server" 
                                        Text="This Financial Management Toolkit has been developed with you, the business owners
                                    and the accountants of businesses, in mind. With some financial information that
                                    you enter, you will get a better understanding of your business’ financial standing,
                                    cashflow and fund requirements by looking ahead based on the assumptions that you
                                    make. Think of this system a crystal glass to get a glimpse of your future." 
                                        meta:resourcekey="locParagraph2Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Localize ID="locParagraph3" runat="server" 
                                        
                                        Text="You are assured that the financial information provided are confidential to you
                                    only. Nevertheless, the quality of the analysis is determined by the accuracy of
                                    your inputs. If no figures are available, you may like to make a best estimate." 
                                        meta:resourcekey="locParagraph3Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    <strong>
                                        <asp:Label ID="lblReadyToBegin" runat="server" Text="Ready to begin?" meta:resourcekey="lblReadyToBeginResource2" 
                                        ></asp:Label></strong>
                                </td>
                            </tr>
                            <tr>
                                <td width="203">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                <asp:Label ID="lblInfoBelow" runat="server" 
                                        Text="First, complete the information below:" meta:resourcekey="lblInfoBelowResource2" 
                                        ></asp:Label>
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
                                                <asp:Label ID="lblError" runat="server" CssClass="ErrorMsg" 
                                                    meta:resourcekey="lblErrorResource2" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="800" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="350" height="30">
                                                         <asp:Label ID="lblYourCompanyName" runat="server" 
                                                                Text="Your Business / Company Name" meta:resourcekey="lblYourCompanyNameResource2" 
                                                                ></asp:Label>
                                                            
                                                        </td>
                                                        <td width="450">
                                                            <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="100" 
                                                                CssClass="txtfield" meta:resourcekey="txtCompanyNameResource2"
                                                                ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="*" 
                                                                ControlToValidate="txtCompanyName" meta:resourcekey="rfvCompanyNameResource2"
                                                                ></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30">
                                                         <asp:Label ID="lblFinYear" runat="server" 
                                                                Text="When is the upcoming financial year end? (DD/MM/YYYY)" meta:resourcekey="lblFinYearResource2" 
                                                                ></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFinEndDate" runat="server" MaxLength="10" meta:resourcekey="txtFinEndDateResource1"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvFinEndDate" runat="server" ErrorMessage="*" CssClass="ErrorMsg"
                                                                ControlToValidate="txtFinEndDate" meta:resourcekey="rfvFinEndDateResource1"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revFinEndDate" ControlToValidate="txtFinEndDate"
                                                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                                                runat="server" ErrorMessage="Invalid Date" meta:resourcekey="revFinEndDateResource1"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="Small" meta:resourcekey="lblMsgResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30">
                                                         <asp:Label ID="lblCurrency" runat="server" Text="Select the operating currency" 
                                                                meta:resourcekey="lblCurrencyResource1"></asp:Label>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCurrency" runat="server" meta:resourcekey="ddlCurrencyResource1">
                                                                <asp:ListItem meta:resourcekey="ListItemResource1" Text="SGD"></asp:ListItem>
                                                                <asp:ListItem meta:resourcekey="ListItemResource2" Text="USD"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30">
                                                        <asp:Label ID="lblPastFinStmts" runat="server" 
                                                                Text="Do you have any past financial statements?" 
                                                                meta:resourcekey="lblPastFinStmtsResource1"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblFG1" runat="server" 
                                                                Text="(e.g. new start-ups in first year to select 'no')" 
                                                                meta:resourcekey="lblFG1Resource1"></asp:Label>
                                                        </td>
                                                        <td valign="top">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblFinStatement" runat="server" RepeatDirection="Horizontal"
                                                                            meta:resourcekey="rblFinStatementResource1">
                                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource3" Text="No"></asp:ListItem>
                                                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource4" Text="Yes"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="rfvFinStatement" runat="server" ErrorMessage="*"
                                                                            CssClass="ErrorMsg" ControlToValidate="rblFinStatement" meta:resourcekey="rfvFinStatementResource1"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30">
                                                            &nbsp;
                                                        </td>
                                                        <td height="35" valign="bottom">
                                                            <asp:Button ID="btnStart" runat="server" Text="Save & Next" OnClientClick="return valid();"
                                                                CssClass="orange_button" OnClick="btnStart_Click" meta:resourcekey="btnStartResource1" />
                                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" OnClientClick="Clear()"
                                                                meta:resourcekey="btnClearResource1"  CausesValidation="false"  />
                                                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click"
                                                                meta:resourcekey="btnBackResource1" CausesValidation="false" />
                                                            <asp:HiddenField ID="hfFsCheck" runat="server" />
                                                        </td>
                                                    </tr>
                                                     <tr style="display:none">
                                                        <td height="30">
                                                            &nbsp;
                                                        </td>
                                                        <td height="35" valign="bottom">
                                                            <asp:Label ID="lbl_existingrecords" runat="server"
                                                                Text="If you change the Financial Statement, the existing records will be deleted. If you want to continue, click OK. Other wise click Cancel." 
                                                                meta:resourcekey="lbl_existingrecordsResource1"></asp:Label>
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
        function valid() {
            var selVal = document.getElementById('<%=hfFsCheck.ClientID %>').value;
            var lbl_existingrecords = document.getElementById('<%=lbl_existingrecords.ClientID%>').innerHTML
            var rad = document.getElementById('<%=rblFinStatement.ClientID %>');
            var inputs = rad.getElementsByTagName("input");
            if ((selVal == 0 && inputs[0].checked) || (selVal == 0 && inputs[1].checked)) {

                //return confirm('If you change the Financial Statement, the existing records will be deleted. If you want to continue, click OK. Other wise click Cancel');
            }
            else if (selVal == 1 && inputs[1].checked) {
            return confirm(lbl_existingrecords);
            }
        }

        function Clear() {
            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "text") {
                    allInputs[i].value = "";
                }
                else if (allInputs[i].type == "radio") {
                    allInputs[i].checked = false;
                }
            }
        }
        function IsNumeric(sText) {
            var ValidChars = "0123456789.";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;

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
