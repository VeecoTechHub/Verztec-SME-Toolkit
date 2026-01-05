<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="ClinicalSession.aspx.cs" Inherits="Administration_ClinicalSession" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <table id="Table1" width="770px" align="left" border="0" cellpadding="3">
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            CompanyName
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="20" Height="19px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Email
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="20" Height="19px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Start Date
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <cc2:GMDatePicker ID="DatePicker_StartDate" readonly="true" DateFormat="dd/MMM/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            End Date
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <cc2:GMDatePicker ID="DatePicker_EndDate" readonly="true" DateFormat="dd/MMM/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td nowrap="nowrap" style="width: 1px">
                        </td>
                        <td colspan="1" width="370px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td style="width: 1px">
                        </td>
                        <td colspan="1" height="3" style="width: 370px">
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_Go_Click" />
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
            </td>
        </tr>
        <tr>
            <td style="width: 70%; height: 30px;" runat="server" id="tdSelect">
                <br />
                <%--<input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                    type="checkbox" class="formlabel" />
                Select/De-select All--%>
            </td>
            <td align="right" style="height: 30px">
                <asp:ImageButton ID="btnExptoExcel" runat="server" ImageUrl="~/images/Export_Excel.gif"
                    Visible="false" Style="height: 21px" OnClick="btnExptoExcel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvClinicalSession" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" OnRowCommand="gvClinicalSession_RowCommand">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Register No.">
                          <HeaderStyle ForeColor="Black" Width="100" Font-Bold="true"></HeaderStyle>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                             <HeaderStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <HeaderStyle ForeColor="Black" Width="100" Font-Bold="true"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_CompanyName" runat="server" Text='<%#Eval("Company") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Participant Name">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation">
                            <HeaderStyle ForeColor="Black" Width="50"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Designation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="50" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telephone">
                            <HeaderStyle ForeColor="Black" Width="50"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Telephone" runat="server" Text='<%#Eval("Telephone") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="50" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <HeaderStyle ForeColor="Black" BorderStyle="None" HorizontalAlign="Right"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Email" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Date">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_RegistrationDate" runat="server" Text='<%#Eval("CreatedOn") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="100" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preferred Dates">
                            <HeaderStyle ForeColor="Black" Width="50"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_PreferredDates" runat="server" Text='<%#Eval("PreferredDates") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="50" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Topics To Consult">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Topics" runat="server" Text='<%#Eval("Topics") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admin Preferred Date">
                            <HeaderStyle ForeColor="Black" Width="150"></HeaderStyle>
                            <ItemTemplate>
                                <asp:TextBox ID="txt_AdminPreferredDate" runat="server" MaxLength="100" Text='<%#Eval("ADMIN_PREFERREDDATE") %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnSend" Text="Save" CommandName="Save" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.UserID") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="menu_admin" />
                    <PagerStyle Font-Bold="True" CssClass="tableHeading"></PagerStyle>
                    <PagerSettings Mode="Numeric" />
                </asp:GridView>
            </td>
        </tr>
         <tr>
            <td colspan="2">
                <asp:GridView ID="gvExcel" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" Visible="False">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                       <asp:TemplateField HeaderText="Register No.">
                          <HeaderStyle ForeColor="Black" Width="100" Font-Bold="true"></HeaderStyle>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                             <HeaderStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <HeaderStyle ForeColor="Black" Width="200" Font-Bold="true"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_CompanyName" runat="server" Text='<%#Eval("Company") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Participant Name">
                            <HeaderStyle ForeColor="Black" Width="180"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation">
                            <HeaderStyle ForeColor="Black" Width="150"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Designation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telephone">
                            <HeaderStyle ForeColor="Black" Width="150"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Telephone" runat="server" Text='<%#Eval("Telephone") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <HeaderStyle ForeColor="Black" BorderStyle="None" HorizontalAlign="Right"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Email" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="180" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Date">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_RegistrationDate" runat="server" Text='<%#Eval("CreatedOn") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preferred Dates">
                            <HeaderStyle ForeColor="Black" Width="50"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_PreferredDates" runat="server" Text='<%#Eval("PreferredDates") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Topics To Consult">
                            <HeaderStyle ForeColor="Black" Width="130"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Topics" runat="server" Text='<%#Eval("Topics") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="130" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admin Preferred Date">
                            <HeaderStyle ForeColor="Black" Width="150"></HeaderStyle>
                            <ItemTemplate>
                            
                             <asp:Label ID="lbl_ADMIN_PREFERREDDATE" runat="server" Text='<%#Eval("ADMIN_PREFERREDDATE") %>'></asp:Label>
                                <%--<asp:TextBox ID="txt_AdminPreferredDate" runat="server" MaxLength="100" Text='<%#Eval("ADMIN_PREFERREDDATE") %>'></asp:TextBox>--%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150" CssClass="gvItems" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="menu_admin" />
                    <PagerStyle Font-Bold="True" CssClass="tableHeading"></PagerStyle>
                    <PagerSettings Mode="Numeric" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
    </table>
</asp:Content>
