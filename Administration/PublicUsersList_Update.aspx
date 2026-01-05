<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="PublicUsersList_Update.aspx.cs" Inherits="Administration_PublicUsersList_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="left">
        <table id="Table3" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
            background-repeat: repeat-x; padding-left: 10px;">
            <tr>
                <td width="20" height="40" align="left">
                    <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" />
                </td>
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
            <%-- <tr>
                <td align="left" height="33" valign="top" class="normal_head" valign="top">
                    <div>
                        SME Financial Toolkit User Access Registration
                    </div>
                </td>
            </tr>--%>
            <%--</table>
        <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">--%>
            <tr>
                <td colspan="3" align="left" valign="top">
                    <table id="Table1" width="100%" align="left" border="0" cellpadding="3">
                        <tr>
                            <td class="formlabel" align="left" style="height: 21px;">
                                Your Email
                            </td>
                            <td align="left" width="195" height="21px">
                                <asp:TextBox ID="txtEmail" runat="server" Style="width: 175px;" MaxLength="100" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" CssClass="Mandatory" />
                                <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmail"
                                    ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a valid e-mail address"
                                    CssClass="Mandatory" />
                            </td>
                            <td align="left" width="356">
                                <asp:Label ID="lblEmailMsg" runat="server" Text="Please provide a valid email for activation and Login ID"
                                    CssClass="lblMessage"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="21" class="formlabel" width="220">
                                Password &amp; Retype Password
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPassword" runat="server" Style="width: 83px; height: 19px;" TextMode="Password"
                                    MaxLength="100" onpaste="return false"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory" />--%>
                                <asp:TextBox ID="txtRePassword" runat="server" Style="width: 83px; height: 19px;"
                                    TextMode="Password" MaxLength="100" onpaste="return false"></asp:TextBox>
                                <%--  <asp:RequiredFieldValidator ID="valRePassword" runat="server" ControlToValidate="txtRePassword"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory" />--%>
                                <asp:CompareValidator ID="ValConPwdCompare" runat="server" ErrorMessage="*" ControlToValidate="txtRePassword"
                                    ControlToCompare="txtPassword" Display="Dynamic" ToolTip="Password and Confirm Password must match"
                                    CssClass="Mandatory"></asp:CompareValidator>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPwdMsg" runat="server" Text="Minimum 8 characters; only numbers and alphabets are accepted."
                                    CssClass="lblMessage"></asp:Label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid"
                                    ValidationExpression="[d]?^[^A-Za-z0-9]?^.{8,}$" Display="Dynamic" ControlToValidate="txtPassword"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="21" class="formlabel">
                                Your Name
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlTitle" runat="server">
                                    <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                    <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                                    <asp:ListItem Text="Dr" Value="Dr"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtName" runat="server" Style="width: 87px;" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valName1" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Name" CssClass="Mandatory" />
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3">
                                <strong>To complete the registration, and to start using the SME Toolkit, please provide
                                    the following details about your business:</strong>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="21" class="formlabel">
                                Business or Company Name
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtCompanyNm" runat="server" Style="width: 180px;" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valCompanyNm" runat="server" ControlToValidate="txtCompanyNm"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Company Name" CssClass="Mandatory" />
                            </td>
                        </tr>
                     <%--   <tr>
                            <td align="left" height="21" class="formlabel">
                                Nature of Business
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlNatureofBuss" runat="server" Style="width: 185px;" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valNatureofBuss" runat="server" ControlToValidate="ddlNatureofBuss"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Nature of Business"
                                    InitialValue="0" CssClass="Mandatory" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" height="21" class="formlabel">
                                Industry
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlIndustry" runat="server" Style="width: 185px;" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valIndustry" runat="server" ControlToValidate="ddlIndustry"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Industry" InitialValue="0"
                                    CssClass="Mandatory" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="21" class="formlabel">
                                Business Started In
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 90px;" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Month" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valMonth" runat="server" ControlToValidate="ddlMonth"
                                    InitialValue="0" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Month"
                                    CssClass="Mandatory" />
                                <asp:DropDownList ID="ddlYear" runat="server" Style="width: 90px;">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valYear" runat="server" ControlToValidate="ddlYear"
                                    InitialValue="0" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Year"
                                    CssClass="Mandatory" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="21" class="formlabel">
                                Number of Employees
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtNoofEmps" runat="server" Style="width: 87px;" onkeypress="return onlyNumbers();"
                                    onpaste="return false" MaxLength="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valNoofEmps" runat="server" ControlToValidate="txtNoofEmps"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a No of Employees"
                                    CssClass="Mandatory" />
                                <asp:Label ID="lblNoofEmpsMsg" runat="server" Text="persons" CssClass="lblMessage"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td align="left" height="21" class="formlabel">
                                Total Capital Injected
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtTotalCapital" runat="server" Style="width: 87px;" onkeypress="return onlyNumbers();"
                                    onpaste="return false" MaxLength="20" Visible="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valTotalCapital" runat="server" ControlToValidate="txtTotalCapital"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Total Capital Injected"
                                    CssClass="Mandatory" />
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td align="left" height="21" class="formlabel">
                                Annual Revenue
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAnnualRev" runat="server" Style="width: 87px;" onkeypress="return onlyNumbers();"
                                    onpaste="return false" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valAnnualRev" runat="server" ControlToValidate="txtAnnualRev"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Annual Revenue"
                                    CssClass="Mandatory" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAnnualRevMsg" runat="server" Text="Please estimate if you are a start-up firm"
                                    CssClass="lblMessage"></asp:Label>
                            </td>
                        </tr>
                        <%-- <tr>
                <td align="left" height="130" style="vertical-align: top;">
                    Please enter the words Shown below&#13;
                </td>
                <td align="left" height="130" colspan="2">
                    <recaptcha:RecaptchaControl ID="rec1" runat="server" PublicKey="6LfukccSAAAAAKzFubq4e18j3WsbCzvw3Zv7xFv5"
                        PrivateKey="6LfukccSAAAAAKM0-z4TVyWRsUBgNDAqZCzB0XPB" />
                    <asp:Label ID="lblRError" runat="server" CssClass="ManditoryField" Visible="false"></asp:Label>
                </td>
            </tr>--%>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left" height="50" colspan="2">
                                &nbsp;
                                <asp:ImageButton ID="Button_Update" ImageUrl="~/images/Update.jpg" runat="server"
                                    CausesValidation="true" OnClick="Button_Update_Click"></asp:ImageButton>
                                <%--<asp:ImageButton ID="Button_Back" ImageUrl="~/images/back.jpg" runat="server" 
                        CausesValidation="false" onclick="Button_Back_Click"></asp:ImageButton>--%>
                                <a href='javascript:postForEdit1("<%=ViewState["t_url"]%>","we+XKcjPYmE=","<%=token %>");'>
                                    <img src="../images/back.jpg" border="0" />
                                </a>
                                <asp:ImageButton ID="Button_Resend" ImageUrl="~/images/Resend.jpg" runat="server"
                                    CausesValidation="false" OnClick="Button_Resend_Click"></asp:ImageButton>
                            </td>
                        </tr>
                    </table>
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
