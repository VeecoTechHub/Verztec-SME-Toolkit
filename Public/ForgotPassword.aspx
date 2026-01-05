<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Public_ForgotPassword"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" Runat="Server">
</asp:Content>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .lblMessage
        {
            color: Red;
        }
    </style>
    <div>
        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" height="33" valign="top" class="normal_head" valign="top">
                    <div>
                        <asp:Label ID="lblPwdReminder" runat="server" Text="Password Reminder" meta:resourcekey="lblPwdReminderResource1"></asp:Label>
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
                <td colspan="3">
                    <asp:Label ID="lblToHave" runat="server" Text="To have your password sent to you, please re-enter the Login ID (email address) that you have used in registration."
                        meta:resourcekey="lblToHaveResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" style="white-space: nowrap;" height="30">
                    <asp:Label ID="lblEmail" runat="server" Text="Your Login ID (Email address):" meta:resourcekey="lblEmailResource1"></asp:Label>
                </td>
                <td align="left" width="180">
                    <asp:TextBox ID="txtEmail" runat="server" Style="width: 300px;" MaxLength="100" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                </td>
                <td align="left" width="356" style="padding-left: 3px;">
                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" CssClass="Mandatory"
                        meta:resourcekey="valEmailResource1" />
                    <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a valid e-mail address"
                        Text="Please provide a valid email" CssClass="Mandatory" meta:resourcekey="valEmailValidationResource1" />
                    <asp:Label ID="lblEmailMsg" runat="server" CssClass="lblMessage" meta:resourcekey="lblEmailMsgResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" height="50" colspan="2">
                    &nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="orange_button" OnClick="btnSubmit_Click"
                        meta:resourcekey="btnSubmitResource1" />
                    <asp:Button ID="Button1" runat="server" Text="Clear" class="orange_button" CausesValidation="False"
                        OnClick="Button1_Click" meta:resourcekey="Button1Resource1" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="orange_button" CausesValidation="False"
                        PostBackUrl="~/Default.aspx" meta:resourcekey="btnCancelResource1" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 240px">
                    <asp:Label ID="lblDes1" runat="server" Visible="False" meta:resourcekey="lblDes1Resource1"></asp:Label>
                    <asp:Label ID="lblDes2" runat="server" Visible="False" meta:resourcekey="lblDes2Resource1"></asp:Label>
                    <asp:Label ID="lblDes3" runat="server" Visible="False" meta:resourcekey="lblDes3Resource1"></asp:Label>
                    <asp:Label ID="lblDes4" runat="server" Visible="False" meta:resourcekey="lblDes4Resource1"></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
