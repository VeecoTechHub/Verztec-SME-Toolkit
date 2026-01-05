<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ClinicalSession.aspx.cs" Inherits="Public_ClinicalSession"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" ValidateRequest="false" %>

<%@ Register Assembly="Recaptcha" Namespace="Recaptcha" TagPrefix="recaptcha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .star
        {
            color: red;
        }
    </style>
    <script type="text/javascript">
        function mypopup(url) {
            params = 'width=830';
            params += ', height=420, ';
            params += 'status=no, location=no,directories=no,toolbar=no,menubar=no,scrollbars=yes ,minimize=no,copyhistory=no,status=no,titlebar=no, left=90, top=70, titlebar=no, menubar=no, resizable=no';


            newwin = window.open(url, 'windowname4', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
    </script>
    <div align="center">
        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" height="33" class="normal_head" valign="top">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Registration for one-to-one advisory session"
                            meta:resourcekey="lblHeadingResource1"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <table width="865" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" height="5">
                </td>
            </tr>
            <tr>
                <td colspan="2" height="15px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: justify">
                    <asp:Localize ID="locPara1" runat="server" Text="
           Need help to learn more on how to make full use of the Financial Management Toolkit, to interpret the report generated from the financial modeling, or to discuss any financial related issues that you have encountered in your business. Come and sign up for the 1-to-1 complimentary advisory session with our Business Consultant. Each session takes approximately one hour and is sponsored by both The Association of Banks in Singapore and SPRING Singapore. It is for a limited time period only. Please register now.
" meta:resourcekey="locPara1Resource1"></asp:Localize>
                </td>
            </tr>
             <tr>
                <td colspan="2" height="15px">
                </td>
            </tr>
             <tr>
                <td colspan="2" height="15px">
                </td>
            </tr>
             <tr>
                        <td style="width: 251; height: 44;" align="center">
                            <asp:HyperLink ID="hypRHSImg" runat="server" BorderStyle="None" Target="_blank" Height="99px" NavigateUrl="http://www.rsmsingapore.sg/who-we-are/events/60-financial-management-fundamentals-for-business-owners" ImageUrl="~/images/Panel-Financial-Management.jpg"
                                Width="222px">
                            </asp:HyperLink>
                        </td>
                    </tr>

        </table>
        <table width="865" border="0" align="left" cellpadding="0" cellspacing="0" runat="server"
            visible="false">
            <tr>
                <td colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td align="left" width="250px">
                    <b>
                        <asp:Label ID="lblParticipant" runat="server" Text="Participant" meta:resourcekey="lblParticipantResource1"></asp:Label>
                    </b>
                </td>
                <td align="right" width="615px">
                    (<span class="star">*</span>
                    <asp:Label ID="lblRequired" runat="server" Text="Required fields" meta:resourcekey="lblRequiredResource1"></asp:Label>
                    )
                </td>
            </tr>
            <tr>
                <td colspan="2" height="5">
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblTitle" runat="server" Text="Title" meta:resourcekey="lblTitleResource1"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTitle" runat="server" meta:resourcekey="ddlTitleResource1">
                        <asp:ListItem Text="Mr" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                        <asp:ListItem Text="Ms" meta:resourcekey="ListItemResource3"></asp:ListItem>
                        <asp:ListItem Text="Mrs" meta:resourcekey="ListItemResource2"></asp:ListItem>
                        <asp:ListItem Text="Mdm" meta:resourcekey="ListItemResource4"></asp:ListItem>
                        <asp:ListItem Text="Doctor" meta:resourcekey="ListItemResource5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="Label1" runat="server" Text="Name" meta:resourcekey="Label1Resource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtName" runat="server" Style="width: 180px; height: 19px;" MaxLength="50"
                        meta:resourcekey="txtNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName"
                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Name"
                        CssClass="Mandatory" meta:resourcekey="valNameResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblDesignation" runat="server" Text="Designation" meta:resourcekey="lblDesignationResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDesignation" runat="server" Style="width: 180px; height: 19px;"
                        MaxLength="50" meta:resourcekey="txtDesignationResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valDesignation" runat="server" SetFocusOnError="True"
                        ControlToValidate="txtDesignation" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Designation"
                        CssClass="Mandatory" meta:resourcekey="valDesignationResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblCompany" runat="server" Text="Company" meta:resourcekey="lblCompanyResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCompany" runat="server" MaxLength="100" Width="180px" meta:resourcekey="txtCompanyResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCompany" runat="server" ControlToValidate="txtCompany"
                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Company"
                        CssClass="Mandatory" meta:resourcekey="valCompanyResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone" meta:resourcekey="lblTelephoneResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTelephone" runat="server" MaxLength="50" Width="180px" meta:resourcekey="txtTelephoneResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ControlToValidate="txtTelephone"
                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Telephone"
                        CssClass="Mandatory" meta:resourcekey="rfvTelephoneResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" meta:resourcekey="lblEmailResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Width="180px" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email"
                        CssClass="Mandatory" meta:resourcekey="rfvEmailResource1" />
                    <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmail"
                        SetFocusOnError="True" ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                        Display="Dynamic" ErrorMessage="Please enter valid Email" ToolTip="You must enter a valid e-mail address"
                        CssClass="Mandatory" meta:resourcekey="valEmailValidationResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="80">
                    <asp:Label ID="lblIndicate" runat="server" meta:resourcekey="lblIndicateResource1"></asp:Label>
                    <br />
                    <small>(<asp:Label ID="lblPlease" runat="server" meta:resourcekey="lblPleaseResource1"></asp:Label>)</small>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPreferredDates" runat="server" MaxLength="500" Width="180px"
                        CssClass="MultitextboxClinical" TextMode="MultiLine" Height="70px" meta:resourcekey="txtPreferredDatesResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" height="80">
                    <asp:Label ID="lblspecific" runat="server" meta:resourcekey="lblspecificResource1"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTopics" runat="server" MaxLength="500" Width="180px" TextMode="MultiLine"
                        CssClass="MultitextboxClinical" Height="70px" meta:resourcekey="txtTopicsResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" height="90" style="vertical-align: top;">
                    <asp:Label ID="lblwordsshownbelow" runat="server" Text="Please enter the words shown below"
                        meta:resourcekey="lblwordsshownbelowResource1"></asp:Label>
                    &#13;
                </td>
                <%--  <td align="left" height="130" colspan="2">
                    <recaptcha:RecaptchaControl ID="rec1" runat="server" PublicKey="6LfukccSAAAAAKzFubq4e18j3WsbCzvw3Zv7xFv5"
                        PrivateKey="6LfukccSAAAAAKM0-z4TVyWRsUBgNDAqZCzB0XPB" />
                    <asp:Label ID="lblRError" runat="server" CssClass="ManditoryField" Visible="false"></asp:Label>
                </td>--%>
                <td align="left" height="90" valign="top">
                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="text" MaxLength="10" Width="180px"
                        meta:resourcekey="txtCaptchaResource1" />
                    <asp:Label ID="lblNotcase" runat="server" Text="(Not case sensitive)" meta:resourcekey="lblNotcaseResource1"></asp:Label>
                    <cc2:CaptchaControl ID="ccCorporateCaptcha" runat="server" CaptchaBackgroundNoise="None"
                        CaptchaLength="6" CaptchaHeight="60" CaptchaWidth="230" CaptchaMinTimeout="6"
                        CaptchaMaxTimeout="240" BackColor="#F4F4F4" CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789"
                        FontColor="Black" LineColor="Black" meta:resourcekey="ccCorporateCaptchaResource1"
                        NoiseColor="Black" />
                    <%--  <recaptcha:recaptchacontrol id="rec1" runat="server" publickey="6LfukccSAAAAAKzFubq4e18j3WsbCzvw3Zv7xFv5"
                                            privatekey="6LfukccSAAAAAKM0-z4TVyWRsUBgNDAqZCzB0XPB" />--%>
                    <asp:Label ID="lblRError" runat="server" CssClass="ManditoryField" Visible="False"
                        meta:resourcekey="lblRErrorResource1"></asp:Label>
                    <asp:Label ID="lblDes1" runat="server" Visible="False" meta:resourcekey="lblDes1Resource1"></asp:Label>
                    <asp:Label ID="lblDes2" runat="server" Visible="False" meta:resourcekey="lblDes2Resource1"></asp:Label>
                    <asp:Label ID="lblDes3" runat="server" Visible="False" meta:resourcekey="lblDes3Resource1"></asp:Label>
                    <asp:Label ID="lblDes4" runat="server" Visible="False" meta:resourcekey="lblDes4Resource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" height="50">
                    &nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="orange_button" OnClick="btnSubmit_Click"
                        meta:resourcekey="btnSubmitResource1" OnClientClick="return ValidateHtml();" />
                    <%--onclientclick="return ValidateHtml();"--%>
                    <asp:Button ID="btnReset" CausesValidation="False" runat="server" Text="Reset" class="orange_button"
                        PostBackUrl="~/Public/ClinicalSession.aspx" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="orange_button" CausesValidation="False"
                        PostBackUrl="~/Public/Dashboard.aspx" meta:resourcekey="btnCancelResource1" />
                    <%--<input name="button" type="submit" class="orange_button" id="button" value="Register"
                        onclick="parent.location='FinancialModelingTool_AccessActivation.htm'" />--%>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript" language="javascript">

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function ValidateHtml() {

            //            if (str.match(/([\<])([^\>]{1,})*([\>])/i) == null)
            //                return false;
            //            else
            //                return true;


            var isHtml = 1;
            var txtid = document.getElementById('<%=txtPreferredDates.ClientID%>').value;
            if (txtid.indexOf("<") != -1) {
                isHtml = 0;
            }
            else if (txtid.indexOf(">") != -1) {
                isHtml = 0;
            }

            txtid = document.getElementById('<%=txtTopics.ClientID%>').value;
            if (txtid.indexOf("<") != -1) {
                isHtml = 0;
            }
            else if (txtid.indexOf(">") != -1) {
                isHtml = 0;
            }

            txtid = document.getElementById('<%=txtName.ClientID%>').value;
            if (txtid.indexOf("<") != -1) {
                isHtml = 0;
            }
            else if (txtid.indexOf(">") != -1) {
                isHtml = 0;
            }

            txtid = document.getElementById('<%=txtDesignation.ClientID%>').value;
            if (txtid.indexOf("<") != -1) {
                isHtml = 0;
            }
            else if (txtid.indexOf(">") != -1) {
                isHtml = 0;
            }

            txtid = document.getElementById('<%=txtCompany.ClientID%>').value;
            if (txtid.indexOf("<") != -1) {
                isHtml = 0;
            }
            else if (txtid.indexOf(">") != -1) {
                isHtml = 0;
            }

            txtid = document.getElementById('<%=txtTelephone.ClientID%>').value;
            if (txtid.indexOf("<") != -1) {
                isHtml = 0;
            }
            else if (txtid.indexOf(">") != -1) {
                isHtml = 0;
            }

            if (isHtml == 0) {
                alert('HTML entry is not allowed. Please make sure that your entries do not contain any angle brackets like < or >.');
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
