<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Administration_ChangePassword" Title="Change password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor="#FFFFFF"
        style="background-image: url(../images/bg.jpg); background-repeat: repeat-x;
        padding-left: 10px">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" alt="" style="padding-left: 5px" /></td>
            <td width="600" align="left">
                <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                    &gt;&gt;
                    <%=(ViewState["Links"].ToString().Split('|')[4])%>
                </strong>
            </td>
            <td width="199" align="left" valign="middle">
                <p style="padding-top: 5px">
                    <strong class="blue">User:
                        <%=Session["GROUP_ID"].ToString()%>
                        /
                        <%=Session["USER_NM"].ToString()%>
                    </strong>
                </p>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="40%" colspan="3" style="height: 13px">
                            <asp:Label ID="lblError" runat="server" CssClass="warnings" ForeColor="Red" Visible="False"></asp:Label>
                            <asp:CompareValidator ID="valid_password" CssClass="warnings" runat="server" ErrorMessage="New password and confirm password must be same"
                                ControlToCompare="txt_Password" Display="Dynamic" ControlToValidate="txt_ConPassword"></asp:CompareValidator></td>
                        <td style="height: 13px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 13px" width="40%">
                            <asp:Label ID="lblmandatory" CssClass="warnings" runat="server" Text="(Fields marked '*' are compulsory)"></asp:Label></td>
                        <td style="height: 13px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="3" nowrap="" width="20%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td nowrap width="20%" colspan="4" height="3" align="center">
                            <table id="Table3" cellspacing="1" width="100%" border="0" style="padding-left: 3px">
                                <tr>
                                    <td class="formlabel" style="width: 134px" align="left">
                                        Old Password <span style="color: Red;">*</span></td>
                                    <td class="formlabel" style="width: 8px;">
                                        :</td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox ID="txt_oldpassword" runat="server" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            ControlToValidate="txt_oldpassword"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 134px">
                                    </td>
                                    <td style="width: 8px">
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formlabel" style="width: 134px; height: 23px;" align="left">
                                        New Password <span style="color: Red;">*</span></td>
                                    <td class="formlabel" style="width: 8px; height: 23px;">
                                        :</td>
                                    <td colspan="2" style="height: 23px" align="left">
                                        <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            InitialValue="" ControlToValidate="txt_Password"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Password"
                                                ErrorMessage="Password should be alphanumeric only" ValidationExpression="[0-9a-zA-Z]*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 134px">
                                    </td>
                                    <td style="width: 8px">
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formlabel" style="width: 134px; height: 23px;" align="left">
                                        Confirm Password <span style="color: Red;">*</span></td>
                                    <td class="formlabel" style="width: 8px; height: 23px;">
                                        :</td>
                                    <td colspan="2" style="height: 23px" align="left">
                                        <asp:TextBox ID="txt_ConPassword" runat="server" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_ConPassword"
                                            ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                runat="server" ControlToValidate="txt_ConPassword" ErrorMessage="Password should be alphanumeric only"
                                                ValidationExpression="[0-9a-zA-Z]*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 134px">
                                    </td>
                                    <td style="width: 8px">
                                    </td>
                                    <td colspan="2" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 134px; height: 24px;" align="left">
                                        <asp:ImageButton ID="Btn_Save" runat="server" OnClientClick="alert('Are you sure to change your password');"
                                            ImageUrl="~/images/Update.jpg" OnClick="Btn_Save_Click" />
                                        <%--<asp:Button ID="Btn_Save" runat="server" Width="74px" CssClass="btn" Text="Update"
                                            OnClick="Btn_Save_Click" OnClientClick="alert('Are you sure to change your password');">
                                        </asp:Button>--%>
                                    </td>
                                    <td style="width: 8px; height: 24px;">
                                    </td>
                                    <td colspan="2" style="height: 24px">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="20" style="height: 231px" colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>
