<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="User_Add.aspx.cs" Inherits="Administration_User_Add" Title="Add user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" />
            </td>
            <td width="550" align="left">
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
            <td colspan="3" align="left" valign="top">
                <table id="Table1" width="100%" border="0">
                    <tr>
                        <td colspan="3" width="50%" align="left" valign="top">
                            <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label>
                        </td>
                        <td width="50%">
                            <asp:Label ID="lblError" runat="server" CssClass="warnings" ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" align="left" style="height: 21px">
                            Group
                        </td>
                        <td class="formlabel" style="height: 21px">
                            :
                        </td>
                        <td align="left" colspan="2" style="height: 21px">
                            <asp:DropDownList ID="Lst_Group" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel">
                            User Id<span style="color: red">*</span>
                        </td>
                        <td class="formlabel">
                            :
                        </td>
                        <td colspan="2">
                            <asp:TextBox class="homePageHeadings" ID="Txt_Userid" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="validUserID" runat="server" Display="Dynamic" ControlToValidate="Txt_Userid"
                                InitialValue="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="height: 23px">
                            Password<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" style="height: 23px">
                            :
                        </td>
                        <td colspan="2" style="height: 23px">
                            <asp:TextBox ID="txt_Password" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="validpass" runat="server" ControlToValidate="txt_Password"
                                InitialValue="">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Password"
                                ErrorMessage="Password should be alphanumeric only" ValidationExpression="[0-9a-zA-Z]*">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel">
                            Confirm Password<span style="color: Red">*</span>
                        </td>
                        <td class="formlabel">
                            :
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txt_ConPassword" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="validconpass" runat="server" ControlToValidate="txt_ConPassword"
                                InitialValue="">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_ConPassword"
                                ErrorMessage="Password should be alphanumeric only" ValidationExpression="[0-9a-zA-Z]*">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3">
                            Name<span style="color: red">*</span>
                        </td>
                        <td class="formlabel">
                            :
                        </td>
                        <td height="3" nowrap="nowrap" colspan="2">
                            <asp:TextBox ID="Txt_Name" runat="server" MaxLength="40"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="validName" runat="server" Display="Dynamic" ControlToValidate="Txt_Name"
                                InitialValue="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 175px">
                            Designation
                        </td>
                        <td class="formlabel" height="3">
                            :
                        </td>
                        <td height="3" nowrap="nowrap" colspan="2">
                            <asp:TextBox ID="txtDesg" MaxLength="40" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 175px">
                            Email<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" height="3">
                            :
                        </td>
                        <td nowrap height="3" colspan="2">
                            <asp:TextBox ID="txt_Email" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid E-MailID"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_Email">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvEmailRec" runat="server" ControlToValidate="txt_Email"
                                Display="Dynamic" InitialValue="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel">
                            Phone
                        </td>
                        <td class="formlabel">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Tel" runat="server" MaxLength="30"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" CssClass="warnings"
                                ControlToValidate="txt_Tel" ForeColor=" " ValidationExpression="^[ 0-9 +()-]+$"
                                ErrorMessage="Invalid Phone Number">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" valign="top">
                            <table cellspacing="3" style="vertical-align: top;">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="Button_Save" ImageUrl="~/images/save.jpg" runat="server" CausesValidation="true"
                                            OnClientClick="return confirm('Are you sure to add new staff?');" OnClick="Button_Save_Click">
                                        </asp:ImageButton>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/clear.jpg" CausesValidation="false"
                                            Text="Clear" OnClick="btnClear_Click"></asp:ImageButton>
                                    </td>
                                    <td>
                                        <%--<asp:ImageButton ID="Bttn_Search" runat="server" ImageUrl="~/images/back.jpg" CausesValidation="False"
                                            OnClick="Bttn_Search_Click"></asp:ImageButton>--%>
                                        <a href='javascript:postForEdit1("<%=ViewState["t_urlback"]%>","we+XKcjPYmE=","<%=token %>");'
                                            tabindex="6">
                                            <img src="../images/back.jpg" border="0" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        if (flg) alert('User has been added successfully');
    </script>
</asp:Content>
