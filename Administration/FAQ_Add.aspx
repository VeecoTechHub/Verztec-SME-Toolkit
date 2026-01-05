<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="FAQ_Add.aspx.cs" Inherits="Administration_FAQ_Add" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" /></td>
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
            <td colspan="3" align="left" valign="top">
                <table id="Table1" width="100%" border="0">
                    <tr>
                        <td colspan="4" align="left" valign="top">
                            <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblError" runat="server" CssClass="warnings" ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" align="left" style="height: 21px; width: 20%">
                            Category</td>
                        <td class="formlabel" style="height: 21px; width: 2%">
                            :</td>
                        <td align="left" colspan="2" style="height: 21px; width: 75%">
                            <asp:DropDownList ID="ddlCategory" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ErrorMessage="*" CssClass="warnings"
                                ControlToValidate="ddlCategory" Display="Dynamic" ForeColor="" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel">
                            Faq Question<span style="color: red">*</span></td>
                        <td class="formlabel">
                            :</td>
                        <td colspan="2">
                            <asp:TextBox class="homePageHeadings" ID="txtQuestion" runat="server" MaxLength="50"
                                Height="70px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" Display="Dynamic" ControlToValidate="txtQuestion"
                                CssClass="warnings" ForeColor="">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="height: 23px">
                            Faq Answer<span style="color: red">*</span></td>
                        <td class="formlabel" style="height: 23px">
                            :</td>
                        <td colspan="2" style="height: 23px">
                            <asp:TextBox ID="txtAnswer" runat="server" MaxLength="50" Height="130px" TextMode="MultiLine"
                                Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer"
                                CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 23px">
                        </td>
                        <td style="height: 23px">
                        </td>
                        <td colspan="2" style="height: 23px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="35" valign="top">
                            <table cellspacing="3" style="vertical-align: top;">
                                <tr>
                                    <td style="height: 23px">
                                        <asp:ImageButton ID="Button_Save" ImageUrl="~/images/save.jpg" runat="server" CausesValidation="true"
                                            OnClick="Button_Save_Click"></asp:ImageButton></td>
                                    <td style="height: 23px">
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/clear.jpg" CausesValidation="false"
                                            OnClick="btnClear_Click"></asp:ImageButton></td>
                                    <td style="height: 23px">
                                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.jpg" CausesValidation="False"
                                            OnClick="btnBack_Click"></asp:ImageButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
