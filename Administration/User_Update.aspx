<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="User_Update.aspx.cs" Inherits="Administration_User_Update" Title="Update User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" /></td>
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
                <table id="Table1" border="0" style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            <table>
                                <tr>
                                    <td width="60%" align="left">
                                        <p>
                                            <font color="#ff0000">
                                                <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are mandatory)" Font-Size="Small"></asp:Label>
                                            </font>
                                        </p>
                                    </td>
                                    <td width="40%" align="left">
                                        <asp:Label ID="lblError" runat="server" CssClass="warnings" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 133px;">
                            Group</td>
                        <td class="formlabel" style="width: 2px;">
                            :</td>
                        <td style="width: 438px;" nowrap>
                            <asp:DropDownList ID="ddlGroupName" runat="server" DataTextField="GROUP_DESCR" DataValueField="GROUP_ID">
                            </asp:DropDownList><asp:ObjectDataSource ID="ODSGroup" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetDataForGroup" TypeName="AdicioTableAdapters.tbl_groupTableAdapter">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <%--<TR>
								<TD class="formlabel" style="width: 133px;">Department</TD>
                                <td class="formlabel" style="width: 2px;">
                                    :</td>
								<TD style="WIDTH: 438px;" noWrap>
                                    <asp:DropDownList ID="ddlDept" runat="server">
                                    </asp:DropDownList>
                                </TD>
							</TR>--%>
                    <tr>
                        <td class="formlabel" style="width: 133px; height: 3px;">
                            User Id</td>
                        <td class="formlabel" style="width: 2px; height: 3px;">
                            :</td>
                        <td style="width: 438px; height: 3px;" nowrap>
                            <asp:Label class="formLabelMandatory" ID="Txt_Userid" runat="server" CssClass="formLabelDisable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 133px">
                            Name<span style="color: #ff0000">*</span></td>
                        <td class="formlabel" height="3" style="width: 2px">
                            :</td>
                        <td height="3" nowrap="nowrap">
                            <asp:TextBox ID="Txt_Name" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                ID="validName" runat="server" InitialValue="" ControlToValidate="Txt_Name">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 133px; height: 23px">
                            Designation</td>
                        <td class="formlabel" style="width: 2px; height: 23px">
                            :</td>
                        <td nowrap="nowrap" style="height: 23px">
                            <asp:TextBox ID="txtDesg" runat="server" MaxLength="50"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 133px; height: 2px">
                            Email<span style="color: #ff0000">*</span></td>
                        <td class="formlabel" style="width: 2px; height: 2px;">
                            :</td>
                        <td nowrap>
                            <asp:TextBox ID="txt_Email" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                ID="rfvEmailRec" runat="server" ControlToValidate="txt_Email" Display="Dynamic"
                                InitialValue="">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regEmailValid" runat="server" ControlToValidate="txt_Email"
                                ErrorMessage="Invalid EmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid EmailID</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 133px">
                            Phone</td>
                        <td class="formlabel" height="3" style="width: 2px">
                            :</td>
                        <td height="3" nowrap="nowrap">
                            <asp:TextBox ID="txt_Tel" runat="server" MaxLength="30"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" CssClass="warnings"
                                ControlToValidate="txt_Tel" ErrorMessage="Invalid Phone Number" ValidationExpression="^[ 0-9 +()-]+$"
                                ForeColor=" "></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td colspan="3" height="24">
                            <font color="#ff0000"><em>If you don't&nbsp;want to change password&nbsp;, leave following
                                fields&nbsp;blank. </em></font>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2px; vertical-align: top; height: 21px;" class="formlabel">
                            Password<span style="color: #ff0000">*</span></td>
                        <td style="width: 2px; vertical-align: top; height: 21px;" class="formlabel">
                            :</td>
                        <td colspan="1">
                            <asp:TextBox ID="txt_Password" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Password"
                                ErrorMessage="Password should be alphanumeric only" ValidationExpression="[0-9a-zA-Z]*"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; height: 21px;" class="formlabel">
                            Confirm Password<span style="color: #ff0000">*</span></td>
                        <td nowrap="nowrap" class="formlabel" style="width: 2px; vertical-align: top; height: 21px;">
                            :</td>
                        <td colspan="1">
                            <asp:TextBox ID="txt_ConPassword" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox><asp:CompareValidator
                                ID="valid_password" runat="server" ControlToValidate="txt_ConPassword" ControlToCompare="txt_Password"
                                Display="Dynamic"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_ConPassword"
                                ErrorMessage="Password should be alphanumeric only" ValidationExpression="[0-9a-zA-Z]*"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="35" valign="top" align="left">
                            <table cellspacing="3" style="vertical-align: top;">
                                <tr>
                                    <td>
                                        <asp:ImageButton ImageUrl="~/images/save.jpg" CausesValidation="true" ID="Bttn_Save"
                                            runat="server" OnClientClick="return confirm('Are you sure you want to save the details?');"
                                            OnClick="Bttn_Save_Click"></asp:ImageButton></td>
                                    <td>
                                        <asp:ImageButton ID="btnReset" ImageUrl="~/images/reset.jpg" runat="server" CausesValidation="false"
                                            OnClick="btnReset_Click" Height="21px"></asp:ImageButton></td>
                                    <td>
                                        <%--<asp:ImageButton ID="Bttn_Back" ImageUrl="~/images/back.jpg" runat="server" OnClick="Bttn_Back_Click"
                                            CausesValidation="False"></asp:ImageButton>--%>
                                              <a href='javascript:postForEdit1("<%=ViewState["t_url"]%>","we+XKcjPYmE=","<%=token %>");'
                                            tabindex="6"><img src="../images/back.jpg" border="0" /> </a>
                                            
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
