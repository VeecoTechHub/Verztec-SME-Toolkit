<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="Admin_AddHealthProfiling.aspx.cs" Inherits="Administration_Admin_AddHealthProfiling" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function popitup(url) {
            newwindow = window.open(url, 'name');
            if (window.focus)
            { newwindow.focus() }

            return false;

        }
    </script>
    <%-- <script type="text/javascript">
      var txt = '<%=id_txt_AddDetails.ClientID %>'; 
     
    </script>--%>
    <%--<script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" src="../tiny_mce/BasicEditor.js"></script>--%>
    <asp:Panel ID="id_panel" runat="server">
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
                                Description :
                            </td>
                            <td class="formlabel" style="height: 21px; width: 2%">
                                :
                            </td>
                            <td align="left" colspan="2" style="height: 21px; width: 75%">
                                <asp:TextBox class="homePageHeadings" ID="txt_Description" runat="server" MaxLength="40"
                                    Height="20px" Width="250px" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="warnings"
                                    ControlToValidate="txt_Description" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="height: 23px">
                                Option A<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td colspan="2" style="height: 23px">
                                <asp:TextBox ID="txt_OptA" runat="server" MaxLength="30" Height="20px" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvoptA" runat="server" ControlToValidate="txt_OptA"
                                    CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="height: 23px">
                                Option B<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td colspan="2" style="height: 23px">
                                <asp:TextBox ID="txt_OptB" runat="server" MaxLength="30" Height="20px" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_OptB"
                                    CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="height: 23px">
                                Option C<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td colspan="2" style="height: 23px">
                                <asp:TextBox ID="txt_OptC" runat="server" MaxLength="30" Height="20px" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_OptC"
                                    CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="height: 23px">
                                Option D<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td colspan="2" style="height: 23px">
                                <asp:TextBox ID="txt_OptD" runat="server" MaxLength="30" Height="20px" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_OptD"
                                    CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td class="formlabel" style="height: 23px">
                                Answer<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td colspan="2" style="height: 23px">
                                <asp:DropDownList ID="ddl_Answer" runat="server">
                                    <asp:ListItem Text="Select" ></asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvanswer" InitialValue="Select" runat="server" ControlToValidate="ddl_Answer"
                                    CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
                        
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
                                            <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/clear.jpg" Visible="false"
                                                CausesValidation="false" OnClick="btnClear_Click" Height="21px"></asp:ImageButton>
                                        </td>
                                        <td style="height: 23px">
                                            <%--<   asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.jpg" CausesValidation="False"
                                                OnClick="btnBack_Click" style="margin-bottom: 0px"></asp:ImageButton>--%>
                                            <%-- <a href='javascript:postforedit1("<%=viewstate["t_url"]%>","we+xkcjpyme=","<%=token %>");'
                                            tabindex="6"><img src="../images/back.jpg" border="0" /> </a>
                                            --%>
                                            <a href='javascript:postForEdit1("<%=ViewState["t_urlback"]%>","we+XKcjPYmE=","<%=token %>");'
                                                tabindex="6">
                                                <img src="../images/back.jpg" border="0" />
                                            </a>
                                            <asp:Label ID="lbloperation" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </script>
    </asp:Panel>
</asp:Content>
