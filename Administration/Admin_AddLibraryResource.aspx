<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="Admin_AddLibraryResource.aspx.cs" Inherits="Administration_AdminAddLibraryResources"
    Debug="true" ValidateRequest="false" %>

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
    <script type="text/javascript">
        var txt = '<%=id_txt_AddDetails.ClientID %>,<%=id_txt_ChineseAddDetails.ClientID %>';
   
    </script>
    <script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" src="../tiny_mce/BasicEditor.js"></script>
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
                            <td colspan="3" align="left" valign="top">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" runat="server" CssClass="warnings" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" align="left" style="height: 21px; width: 20%">
                                English Title<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 21px; width: 2%">
                                :
                            </td>
                            <td align="left" style="height: 21px; width: 75%">
                                <asp:TextBox class="homePageHeadings" ID="id_txt_AddTitle" runat="server" Height="20px"
                                    Width="500px" ReadOnly="false" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="warnings"
                                    ControlToValidate="id_txt_AddTitle" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" align="left" style="height: 21px; width: 20%">
                                Chinese Title<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 21px; width: 2%">
                                :
                            </td>
                            <td align="left" style="height: 21px; width: 75%">
                                <asp:TextBox class="homePageHeadings" ID="id_txt_AddChTitle" runat="server" Height="20px"
                                    Width="500px" ReadOnly="false" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="warnings"
                                    ControlToValidate="id_txt_AddChTitle" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" align="left" style="height: 21px; width: 20%">
                                Category
                            </td>
                            <td class="formlabel" style="height: 21px; width: 2%">
                                :
                            </td>
                            <td align="left" style="height: 21px; width: 75%">
                                <%--<asp:CheckBoxList ID="id_cklist" RepeatDirection="Horizontal" AutoPostBack="false"
                                    runat="server" RepeatColumns="2">
                                </asp:CheckBoxList>--%>
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
                                </asp:DropDownList>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="warnings"
                                    ControlToValidate="ddlCategory" Display="Dynamic" ForeColor="" InitialValue="0">*</asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="height: 23px">
                                Select Type
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td style="height: 23px">
                                <asp:DropDownList ID="ddlImage" runat="server" Width="150px">
                                    <asp:ListItem Text="None" Value="None.jpg"></asp:ListItem>
                                    <asp:ListItem Text="New" Value="New.jpg"></asp:ListItem>
                                    <asp:ListItem Text="Recomended" Value="Recomended.jpg"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="height: 23px">
                                Level<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td style="height: 23px">
                                <asp:TextBox ID="txtLevel" runat="server" MaxLength="40" Height="20px" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="warnings"
                                    ControlToValidate="txtLevel" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="formlabel" style="height: 23px">
                                Published On <span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="height: 23px">
                                :
                            </td>
                            <td style="height: 23px">
                                <cc2:GMDatePicker ID="DatePicker_PublishedOn" readonly="true" DateFormat="dd/MMM/yyyy"
                                    InitialValueMode="Null" runat="server" CalendarTheme="Blue" Width="150px">
                                </cc2:GMDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DatePicker_PublishedOn"
                                    CssClass="warnings" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                English Download File<span style="color: red">*</span>
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <asp:FileUpload ID="FURLFileUpload" runat="server" />
                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="warnings"
                                    ControlToValidate="FURLFileUpload" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>--%>
                                &nbsp;&nbsp; (Select Word/Excel/PDF/Powerpoint
                                files)&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnViewFile" runat="server" Visible="false" Font-Bold="true" CausesValidation="false"
                                    OnClick="lbtnViewFile_Click">View File</asp:LinkButton>&nbsp;&nbsp;
                                <asp:ImageButton ID="ibtnDeleteFile" runat="server" ImageUrl="~/images/remove.png"
                                    CausesValidation="false" OnClick="ibtnDeleteFile_Click" OnClientClick="return confirm('Do you want to Delete selected File? Click OK to Delete. Otherwise, Click Cancel.');" />&nbsp;
                                <asp:Label ID="lblDeleteFlag" runat="server" Text="(No File Selected)" Visible="false"></asp:Label>
                                
                            </td>                            
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                Chinese Download File<span style="color: red">*</span>
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <asp:FileUpload ID="ChineseFURLFileUpload" runat="server" />
                                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="warnings"
                                    ControlToValidate="ChineseFURLFileUpload" Display="Dynamic" ForeColor="">*</asp:RequiredFieldValidator>--%>
                                &nbsp;&nbsp; (Select
                                Word/Excel/PDF/Powerpoint files)&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnChineseViewFile" runat="server" Visible="false" Font-Bold="true" CausesValidation="false"
                                    OnClick="lbtnChineseViewFile_Click">View File</asp:LinkButton>&nbsp;&nbsp;
                                <asp:ImageButton ID="ibtnDeleteChineseFile" runat="server" ImageUrl="~/images/remove.png"
                                    CausesValidation="false" OnClick="ibtnDeleteChineseFile_Click" OnClientClick="return confirm('Do you want to Delete selected File? Click OK to Delete. Otherwise, Click Cancel.');" />&nbsp;
                                <asp:Label ID="lblDeleteChineseFlag" runat="server" Text="(No File Selected)" Visible="false"></asp:Label>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                Status
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <asp:RadioButtonList ID="rbtnStatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Active" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                English Description
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <asp:TextBox ID="txtDescription" runat="server" Height="70px" TextMode="MultiLine"
                                    Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                Chinese Description
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <asp:TextBox ID="txtChDescription" runat="server" Height="70px" TextMode="MultiLine"
                                    Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                Recommended Articles
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <asp:ListBox ID="lbArticles" runat="server" Height="120px" Width="500px" SelectionMode="Multiple"
                                    Font-Size="Larger"></asp:ListBox>
                                &nbsp; <b>(Hold Ctrl Key to select multiple articles)</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                English Details
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <%--  <asp:TextBox ID="id_txt_AddDetails" runat="server" class="homePageHeadings" Height="70px"
                                    MaxLength="50" TextMode="MultiLine" Width="500px"></asp:TextBox>--%>
                                <asp:TextBox ID="id_txt_AddDetails" runat="server" Height="550px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 20%; vertical-align: top;" align="left" class="formlabel">
                                Chinese Details
                            </td>
                            <td style="height: 21px; width: 2%; vertical-align: top;" class="formlabel">
                                :
                            </td>
                            <td style="height: 21px; width: 75%;" align="left">
                                <%--  <asp:TextBox ID="id_txt_AddDetails" runat="server" class="homePageHeadings" Height="70px"
                                    MaxLength="50" TextMode="MultiLine" Width="500px"></asp:TextBox>--%>
                                <asp:TextBox ID="id_txt_ChineseAddDetails" runat="server" Height="550px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 23px">
                            </td>
                            <td style="height: 23px">
                            </td>
                            <td style="height: 23px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="35" valign="top">
                                <table cellspacing="3" style="vertical-align: top;">
                                    <tr>
                                        <td style="height: 23px">
                                            <asp:ImageButton ID="Button_Save" runat="server" CausesValidation="true" ImageUrl="~/images/save.jpg"
                                                OnClick="Button_Save_Click" />
                                        </td>
                                        <td style="height: 23px">
                                            <asp:ImageButton ID="btnClear" runat="server" CausesValidation="false" Height="21px"
                                                ImageUrl="~/images/clear.jpg" OnClick="btnClear_Click" Visible="false" />
                                        </td>
                                        <td style="height: 23px">
                                            <%--<   asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.jpg" CausesValidation="False"
                                                OnClick="btnBack_Click" style="margin-bottom: 0px"></asp:ImageButton>--%>
                                            <%-- <a href='javascript:postforedit1("<%=viewstate["t_url"]%>","we+xkcjpyme=","<%=token %>");'
                                            tabindex="6"><img src="../images/back.jpg" border="0" /> </a>
                                            --%>
                                            <a href='javascript:postForEdit1("<%=ViewState["t_urlback"]%>","we+XKcjPYmE=","<%=token %>");'
                                                tabindex="6">
                                                <img border="0" src="../images/back.jpg" />
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
    </asp:Panel>
</asp:Content>
