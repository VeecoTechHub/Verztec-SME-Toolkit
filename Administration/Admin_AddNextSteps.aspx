<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="Admin_AddNextSteps.aspx.cs" Inherits="Administration_Admin_AddNextSteps" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table1" width="100%" runat="server" cellspacing="0" cellpadding="0">
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
        <tr>
            <td colspan="3" align="left" valign="top">
                <table id="Table2" width="100%" border="0">
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
                            Title<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" style="height: 21px; width: 2%">
                            :
                        </td>
                        <td align="left" colspan="2" style="height: 21px; width: 75%">
                            <asp:TextBox class="homePageHeadings" ID="id_txt_AddTitle" runat="server" MaxLength="40"
                                Height="20px" Width="500px" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="warnings"
                                ControlToValidate="id_txt_AddTitle" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" align="left" style="height: 21px; width: 20%">
                            Faculty<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" style="height: 21px; width: 2%">
                            :
                        </td>
                        <td align="left" colspan="2" style="height: 21px; width: 75%">
                            <asp:TextBox class="homePageHeadings" ID="id_txt_Faculty" runat="server" MaxLength="30"
                                Height="20px" Width="500px" ReadOnly="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFaculty" runat="server" CssClass="warnings" ControlToValidate="id_txt_Faculty"
                                Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" align="left" style="height: 21px; width: 20%">
                            Tags<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" style="height: 21px; width: 2%">
                            :
                        </td>
                        <td align="left" colspan="2" style="height: 21px; width: 75%">
                            <asp:CheckBoxList ID="id_cklist" RepeatDirection="Horizontal" runat="server">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel">
                            Description<span style="color: red">*</span>
                        </td>
                        <td class="formlabel">
                            :
                        </td>
                        <td colspan="2">
                            <asp:TextBox class="homePageHeadings" ID="id_txt_AddDescription" runat="server" MaxLength="50"
                                Height="70px" TextMode="MultiLine" Width="500px"></asp:TextBox><asp:Label ID="id_lbl_sessfilename"
                                    runat="server" Visible="false"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" Display="Dynamic" ControlToValidate="id_txt_AddDescription"
                                CssClass="warnings" ForeColor="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="height: 23px">
                            Duration From<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" style="height: 23px">
                            :
                        </td>
                        <td colspan="2" style="height: 23px">
                            <cc2:GMDatePicker ID="DatePicker_DurationFrom" readonly="true" DateFormat="dd/MMM/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DatePicker_DurationFrom"
                                CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="height: 23px">
                            Duration To<span style="color: red">*</span>
                        </td>
                        <td class="formlabel" style="height: 23px">
                            :
                        </td>
                        <td colspan="2" style="height: 23px">
                            <cc2:GMDatePicker ID="DatePicker_DurationTo" readonly="true" DateFormat="dd/MMM/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                            <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="DatePicker_DurationTo"
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
                                            OnClick="Button_Save_Click"></asp:ImageButton>
                                    </td>
                                    <td style="height: 23px">
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/clear.jpg" CausesValidation="false"
                                            OnClick="btnClear_Click" Visible="false"></asp:ImageButton>
                                    </td>
                                    <td style="height: 23px">
                                        <%--<asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.jpg" CausesValidation="False"
                                            OnClick="btnBack_Click"></asp:ImageButton>--%>
                                        <a href='javascript:postForEdit1("<%=ViewState["t_url"]%>","we+XKcjPYmE=","<%=token %>");'
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
    <div>
        <script type="text/javascript" language="javascript">
            function SuccessRegister() {
                alert("Record(s) Updated Successfully.");
                window.location = "Admin_NextSteps.aspx";
            }
        </script>
    </div>
</asp:Content>
