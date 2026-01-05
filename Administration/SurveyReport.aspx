<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="SurveyReport.aspx.cs" Inherits="Administration_SurveyReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>--%>
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
        <tr>
            <td colspan="3">
                <table id="Table1" width="100%" align="left" border="0" cellpadding="3">
                  <%--  <tr>
                        <td class="formlabel" style="width: 15%">
                            Category :
                        </td>
                        <td class="formlabel" style="width: 1%">
                            :
                        </td>
                        <td style="width: 20%">
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="false">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 2%">
                        </td>
                        <td style="width: 62%">
                            &nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="formlabel" style="width: 15%">
                            Start Date :
                        </td>
                        <td class="formlabel" style="width: 1%">
                            :
                        </td>
                        <td style="width: 22%">
                            <cc2:GMDatePicker ID="DatePicker_StartDate" readonly="true" DateFormat="MMM/dd/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue" OnLoad="DatePicker_StartDate_Load"
                                OnPreRender="DatePicker_StartDate_PreRender" MaxDate="9999-12-31">
                            </cc2:GMDatePicker>
                            <%-- <asp:RequiredFieldValidator ID="rfstdt" runat="server" ControlToValidate="DatePicker_StartDate" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 2%">
                            To
                        </td>
                        <td style="width: 60%">
                            <cc2:GMDatePicker ID="DatePicker_EndDate" readonly="true" DateFormat="MMM/dd/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DatePicker_EndDate" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 15%">
                        </td>
                        <td class="" style="width: 1%">
                        </td>
                        <td style="width: 20%">
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_Go_Click">
                            </asp:ImageButton>
                        </td>
                        <td style="width: 2%">
                        </td>
                        <td style="width: 62%" align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 70%;" align="left" valign="middle">
                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="true" CssClass="warnings">Records Not Found</asp:Label>
            </td>
            <td align="right" valign="bottom">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 70%;">
                <%--  <br />
                <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                    type="checkbox" class="formlabel" />
                Select/De-select All--%>
            </td>
            <td style="height: 38px" valign="middle" align="center">
                <%-- <a href='javascript:postForEdit1("<%=ViewState["t_url"]%>","","<%=token %>");' class="btnClasslink"
                    tabindex="5">
                    <img src="../images/add.jpg" border="0" /></a>--%>
                <asp:ImageButton ID="btnExptoExcel" runat="server" ImageUrl="~/images/Export_Excel.gif"
                    OnClick="btnExptoExcel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataGrid ID="DG_NextStep" runat="server" Width="747px" AllowPaging="false" AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" OnItemCreated="DG_NextStep_ItemCreated"
                    OnPageIndexChanged="DG_NextStep_PageIndexChanged" OnSortCommand="DG_NextStep_SortCommand"
                    ShowFooter="false" OnItemDataBound="DG_NextStep_ItemDataBound">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <%--<asp:TemplateColumn HeaderText="Select">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "A")%>'>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <%-- <asp:TemplateColumn HeaderText="Category_Title">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <asp:TemplateColumn HeaderText="Question">
                            <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_question" runat="server" Text='<%#Eval("QDesc") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="A">
                            <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_A" runat="server" Text='<%#Eval("A") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" CssClass="gvItems" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="B">
                            <HeaderStyle ForeColor="Black" Width="110"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_B" runat="server" Text='<%#Eval("B") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" CssClass="gvItems" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="C">
                            <HeaderStyle ForeColor="Black" Width="110"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_c" runat="server" Text='<%#Eval("C") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" CssClass="gvItems" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="D">
                            <HeaderStyle ForeColor="Black" Width="110"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_D" runat="server" Text='<%#Eval("D") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" CssClass="gvItems"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="E">
                            <HeaderStyle ForeColor="Black" Width="110"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_D" runat="server" Text='<%#Eval("E") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" CssClass="gvItems" />
                        </asp:TemplateColumn>
                    </Columns>
                    <ItemStyle CssClass="menu_admin" />
                    <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 50%">
                <%--<td align="left" style="font-weight: bold">--%>
                <asp:GridView ID="gvExport"  runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="QDesc" HeaderText="Question" />
                        <asp:BoundField DataField="A" HeaderText="A" />
                        <asp:BoundField DataField="B" HeaderText="B" />
                        <asp:BoundField DataField="C" HeaderText="C" />
                        <asp:BoundField DataField="D" HeaderText="D" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <%--<td align="right" style="font-weight: bold">--%>
                <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" ForeColor="Black" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
