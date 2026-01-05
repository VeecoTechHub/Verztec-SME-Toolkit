<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Public_ChangePassword" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="middle_bg">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="33" valign="top" class="normal_head">
                                        <div>
                                            <asp:Label ID="lblChangePwd" runat="server" Text="Change Password" 
                                                meta:resourcekey="lblChangePwdResource1"></asp:Label>
                                            </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="300" valign="top">
                                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="203">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="2">
                                                        <tr>
                                                            <td colspan="4">
                                                              <asp:Label ID="lblToChange" runat="server" 
                                                                    Text="To change your password, please enter the details below" 
                                                                    meta:resourcekey="lblToChangeResource1"></asp:Label>
                                                               
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="Mandatory" 
                                                                    Visible="False" meta:resourcekey="lblErrorMessageResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                               <asp:Label ID="lblLogin" runat="server" Text="Your Login ID (Email address):" 
                                                                    meta:resourcekey="lblLoginResource1"></asp:Label>
                                                                
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtEmail" runat="server" Style="width: 280px;" MaxLength="100" 
                                                                    meta:resourcekey="txtEmailResource1"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                                                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" 
                                                                    CssClass="Mandatory" meta:resourcekey="valEmailResource1" />
                                                                <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmail"
                                                                    ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                                                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a valid e-mail address"
                                                                    CssClass="Mandatory" meta:resourcekey="valEmailValidationResource1" />
                                                                <asp:Label ID="lblEmailWrong" runat="server" Visible="False" ForeColor="Red" 
                                                                    meta:resourcekey="lblEmailWrongResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblExisting" runat="server" Text="Existing Password:" 
                                                                    meta:resourcekey="lblExistingResource1"></asp:Label>
                                                                
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtExistingPassword" runat="server" Style="width: 180px; height: 19px;"
                                                                    TextMode="Password" MaxLength="100" onpaste="return false" 
                                                                    meta:resourcekey="txtExistingPasswordResource1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtExistingPassword"
                                                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" 
                                                                    CssClass="Mandatory" meta:resourcekey="valPasswordResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                              <asp:Label ID="lblNew" runat="server" Text="New Password:" 
                                                                    meta:resourcekey="lblNewResource1"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtPassword" runat="server" Style="width: 180px; height: 19px;"
                                                                    TextMode="Password" MaxLength="100" onpaste="return false" 
                                                                    meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                                                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" 
                                                                    CssClass="Mandatory" meta:resourcekey="RequiredFieldValidator1Resource1" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid"
                                                                    ValidationExpression="[d]?^[^A-Za-z0-9]?^.{8,}$" Display="Dynamic" 
                                                                    ControlToValidate="txtPassword" 
                                                                    meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblPwdMsg" runat="server" Text="Minimum 8 characters; only numbers and alphabets are accepted."
                                                                    CssClass="lblMessage" meta:resourcekey="lblPwdMsgResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                               <asp:Label ID="lblRetype" runat="server" Text="Retype New Password:" 
                                                                    meta:resourcekey="lblRetypeResource1"></asp:Label>
                                                                
                                                            </td>
                                                            <td align="left" colspan="2">
                                                                <asp:TextBox ID="txtRePassword" runat="server" Style="width: 180px; height: 19px;"
                                                                    TextMode="Password" MaxLength="100" onpaste="return false" 
                                                                    meta:resourcekey="txtRePasswordResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="valRePassword" runat="server" ControlToValidate="txtRePassword"
                                                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" 
                                                                    CssClass="Mandatory" meta:resourcekey="valRePasswordResource1" />
                                                                <asp:CompareValidator ID="ValConPwdCompare" runat="server" ErrorMessage="New Password and Retype New Password should be same"
                                                                    ControlToValidate="txtRePassword" ControlToCompare="txtPassword" Display="Dynamic"
                                                                    ToolTip="Password and Confirm Password must match" CssClass="Mandatory" 
                                                                    meta:resourcekey="ValConPwdCompareResource1"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" height="50" colspan="3">
                                                                &nbsp;
                                                                <asp:Button ID="btnRegister" runat="server" Text="Submit" class="orange_button" 
                                                                    OnClick="btnRegister_Click" meta:resourcekey="btnRegisterResource1" />
                                                                <asp:Button ID="btnClear" CausesValidation="False" runat="server" Text="Clear" class="orange_button"
                                                                    OnClick="btnClear_Click" meta:resourcekey="btnClearResource1" />
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="orange_button" CausesValidation="False"
                                                                    PostBackUrl="~/Public/Dashboard.aspx" meta:resourcekey="btnCancelResource1" />
                                                                <%--<input name="button" type="submit" class="orange_button" id="button" value="Register"
                        onclick="parent.location='FinancialModelingTool_AccessActivation.htm'" />--%>
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
                                        <asp:Label ID="lblDes1" runat="server" Visible="False" 
                                            meta:resourcekey="lblDes1Resource1"></asp:Label>
                                        <asp:Label ID="lblDes2" runat="server" Visible="False" 
                                            meta:resourcekey="lblDes2Resource1"></asp:Label>
                                        <asp:Label ID="lblDes3" runat="server" Visible="False" 
                                            meta:resourcekey="lblDes3Resource1"></asp:Label>
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
</asp:Content>
