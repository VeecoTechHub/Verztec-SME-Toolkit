<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Public_Registration"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Recaptcha" Namespace="Recaptcha" TagPrefix="recaptcha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .star
        {
            color: red;
        }
    </style>
    <script type="text/javascript">
        function mypopup(url) {
            debugger;
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
                        <asp:Label ID="lblHeading" runat="server" Text="SME Financial Toolkit User Access Registration"
                            meta:resourcekey="lblHeadingResource1"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">

                    <asp:Label ID="lblLink" runat="server" meta:resourcekey="lblLinkResource1"></asp:Label>

                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="star" meta:resourcekey="lblErrorMessageResource1"></asp:Label>
                            </td>
                            <td align="right">
                                <span class="star">*</span>
                                <asp:Label ID="lblMandatory" runat="server" Text="Mandatory field" meta:resourcekey="lblMandatoryResource1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" width="279" height="30">
                    <asp:Label ID="lblEmail" runat="server" Text="Your Email as Login ID" meta:resourcekey="lblEmailResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left" width="195">
                    <asp:TextBox ID="txtEmail" runat="server" Style="width: 180px;" MaxLength="100" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" CssClass="Mandatory"
                        meta:resourcekey="valEmailResource1" />
                    <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a valid e-mail address"
                        CssClass="Mandatory" meta:resourcekey="valEmailValidationResource1" />
                </td>
                <td align="left" width="356">
                    <asp:Label ID="lblEmailMsg" runat="server" Text="This must be a valid email address that you have personal access to"
                        CssClass="lblMessage" meta:resourcekey="lblEmailMsgResource1"></asp:Label>
                </td>
            </tr>
            <%-- <tr>
                <td align="left" height="30">
                    Retype Your Email Again&#13;
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtReEmail" runat="server" Style="width: 180px;" MaxLength="100" onpaste="return false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valReEmail" runat="server" ControlToValidate="txtReEmail"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" CssClass="Mandatory" />
                    <asp:RegularExpressionValidator ID="valReEmailValidation" runat="server" ControlToValidate="txtReEmail"
                        ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a valid e-mail address" CssClass="Mandatory" />
                    <asp:CompareValidator ID="ValReEmailCompare" runat="server" ErrorMessage="*" ControlToValidate="txtReEmail"
                        ControlToCompare="txtEmail" ToolTip="Emails must match" CssClass="Mandatory"></asp:CompareValidator>
                </td>
            </tr>--%>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblPwd" runat="server" Text="Password" meta:resourcekey="lblPwdResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPassword" runat="server" Style="width: 180px; height: 19px;"
                        TextMode="Password" MaxLength="100" onpaste="return false" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory"
                        meta:resourcekey="valPasswordResource1" />
                </td>
                <td align="left" style="white-space: nowrap;">
                    <asp:Label ID="lblPwdMsg" runat="server" Text="Minimum 8 characters; only numbers and alphabets are accepted."
                        CssClass="lblMessage" meta:resourcekey="lblPwdMsgResource1"></asp:Label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid"
                        ValidationExpression="[d]?^[^A-Za-z0-9]?^.{8,}$" Display="Dynamic" ControlToValidate="txtPassword"
                        meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblRetypePwd" runat="server" Text="Retype Password" meta:resourcekey="lblRetypePwdResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRePassword" runat="server" Style="width: 180px; height: 19px;"
                        TextMode="Password" MaxLength="100" onpaste="return false" meta:resourcekey="txtRePasswordResource1"></asp:TextBox><asp:RequiredFieldValidator
                            ID="valRePassword" runat="server" ControlToValidate="txtRePassword" Display="Dynamic"
                            ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory" meta:resourcekey="valRePasswordResource1" />
                    <asp:CompareValidator ID="ValConPwdCompare" runat="server" ErrorMessage="*" ControlToValidate="txtRePassword"
                        ControlToCompare="txtPassword" Display="Dynamic" ToolTip="Password and Confirm Password must match"
                        CssClass="Mandatory" meta:resourcekey="ValConPwdCompareResource1"></asp:CompareValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblName" runat="server" Text="Your Name" meta:resourcekey="lblNameResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtName" runat="server" Style="width: 287px;" MaxLength="100" meta:resourcekey="txtNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valName1" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Name" CssClass="Mandatory"
                        meta:resourcekey="valName1Resource1" />
                </td>
            </tr>
            <tr>
                <td height="10" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <strong>
                        <asp:Label ID="lblBasicInfo" runat="server" Text="Basic Information About Your Business or Company"
                            meta:resourcekey="lblBasicInfoResource1"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td height="10" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblbasicCompanyName" runat="server" Text="Business or Company Name"
                        meta:resourcekey="lblbasicCompanyNameResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtCompanyNm" runat="server" Style="width: 480px;" MaxLength="100"
                        meta:resourcekey="txtCompanyNmResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCompanyNm" runat="server" ControlToValidate="txtCompanyNm"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Company Name" CssClass="Mandatory"
                        meta:resourcekey="valCompanyNmResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblIndustry" runat="server" Text="Industry" meta:resourcekey="lblIndustryResource1"></asp:Label>
                    <span class="star">*</span>
                </td>
                <td align="left" colspan="2">
                    <asp:DropDownList ID="ddlIndustry" runat="server" Style="width: 185px;" AppendDataBoundItems="True"
                        meta:resourcekey="ddlIndustryResource1">
                        <asp:ListItem Text="---Select---" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valIndustry" runat="server" ControlToValidate="ddlIndustry"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Industry" InitialValue="0"
                        CssClass="Mandatory" meta:resourcekey="valIndustryResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblBusiStarted" runat="server" Text="Business Started In" meta:resourcekey="lblBusiStartedResource1"></asp:Label>
                </td>
                <td align="left" colspan="2">
                    <asp:DropDownList ID="ddlYear" runat="server" Style="width: 90px;" meta:resourcekey="ddlYearResource1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valYear" runat="server" ControlToValidate="ddlYear"
                        InitialValue="0" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Year"
                        CssClass="Mandatory" meta:resourcekey="valYearResource1" />
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    <asp:Label ID="lblNoofEmps" runat="server" Text="Number of Employees" meta:resourcekey="lblNoofEmpsResource1"></asp:Label>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtNoofEmps" runat="server" Style="width: 87px;" onkeypress="return onlyNumbers();"
                        onpaste="return false" MaxLength="4" meta:resourcekey="txtNoofEmpsResource1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regvaldnoofemp" ControlToValidate="txtNoofEmps"
                        runat="server" ErrorMessage="*" ValidationExpression="\d{0,20}" ToolTip="You must enter Number"
                        meta:resourcekey="regvaldnoofempResource1"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valNoofEmps" runat="server" ControlToValidate="txtNoofEmps"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a No of Employees"
                        CssClass="Mandatory" meta:resourcekey="valNoofEmpsResource1" />
                    <asp:Label ID="lblNoofEmpsMsg" runat="server" CssClass="lblMessage" meta:resourcekey="lblNoofEmpsMsgResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" height="90" style="vertical-align: top;">
                    <asp:Label ID="lblEnterwords" runat="server" Text="Please enter the words shown below"
                        meta:resourcekey="lblEnterwordsResource1"></asp:Label>
                    &#13;
                </td>
                <%--  <td align="left" height="130" colspan="2">
                    <recaptcha:RecaptchaControl ID="rec1" runat="server" PublicKey="6LfukccSAAAAAKzFubq4e18j3WsbCzvw3Zv7xFv5"
                        PrivateKey="6LfukccSAAAAAKM0-z4TVyWRsUBgNDAqZCzB0XPB" />
                    <asp:Label ID="lblRError" runat="server" CssClass="ManditoryField" Visible="false"></asp:Label>
                </td>--%>
                <td align="left" height="90" colspan="2" valign="top">
                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="text" MaxLength="10" meta:resourcekey="txtCaptchaResource1" />
                    <asp:Label ID="lblNotCase" runat="server" Text="(Not case sensitive)" meta:resourcekey="lblNotCaseResource1"></asp:Label>
                    <cc2:CaptchaControl ID="ccCorporateCaptcha" runat="server" CaptchaBackgroundNoise="None"
                        CaptchaLength="6" CaptchaHeight="60" CaptchaWidth="230" CaptchaMinTimeout="6"
                        CaptchaMaxTimeout="240" BackColor="#F4F4F4" CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789"
                        FontColor="Black" LineColor="Black"
                        NoiseColor="Black" />
                    <%--  <recaptcha:recaptchacontrol id="rec1" runat="server" publickey="6LfukccSAAAAAKzFubq4e18j3WsbCzvw3Zv7xFv5"
                                            privatekey="6LfukccSAAAAAKM0-z4TVyWRsUBgNDAqZCzB0XPB" />--%>
                    <asp:Label ID="lblRError" runat="server" CssClass="ManditoryField" Visible="False"
                        meta:resourcekey="lblRErrorResource1"></asp:Label>
                    <asp:Label ID="lblDes1" runat="server" Visible="False" meta:resourcekey="lblDes1Resource1"></asp:Label>
                    <asp:Label ID="lblDes2" runat="server" Visible="False" meta:resourcekey="lblDes2Resource1"></asp:Label>
                    <asp:Label ID="lblDes3" runat="server" Visible="False" meta:resourcekey="lblDes3Resource1"></asp:Label>
                    <asp:Label ID="lblDes4" runat="server" Visible="False" 
                        meta:resourcekey="lblDes4Resource1" ></asp:Label>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" height="50" colspan="2">
                    &nbsp;
                    <asp:Button ID="btnRegister" runat="server" Text="Register" class="orange_button"
                        OnClick="btnRegister_Click" meta:resourcekey="btnRegisterResource1" />
                    <asp:Button ID="btnClear" CausesValidation="False" runat="server" Text="Clear" class="orange_button"
                        OnClick="btnClear_Click" meta:resourcekey="btnClearResource1" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="orange_button" CausesValidation="False"
                        PostBackUrl="~/Default.aspx" meta:resourcekey="btnCancelResource1" />
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

    </script>
</asp:Content>
