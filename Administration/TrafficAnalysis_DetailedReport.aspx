<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="TrafficAnalysis_DetailedReport.aspx.cs" Inherits="Administration_TrafficAnalysis_DetailedReport" %>

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
                            Industry
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:DropDownList ID="ddlIndustry" runat="server" Width="200px" AppendDataBoundItems="true">
                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                            </asp:DropDownList>
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
                        <td class="formlabel" style="width: 200px">
                            Language
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:DropDownList ID="ddlCulture" runat="server" Width="125px">
                                <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="English" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Chinese" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        
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
                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="true" CssClass="warnings"></asp:Label>
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
                    OnClick="btnExptoExcel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvTrafficAnalysis" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                    GridLines="Both" Width="100%" CellPadding="1" BorderColor="Black" OnRowDataBound="gvTrafficAnalysis_RowDataBound">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Industry">
                            <HeaderStyle ForeColor="Black" Width="120" BackColor=""></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_IndustryName" runat="server" Text='<%#Eval("Industry") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="120" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NAME") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="160" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <HeaderStyle ForeColor="Black" Width="250"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Company" runat="server" Text='<%#Eval("Company Name") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="250" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Business started in">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_BusinessStartedIn" runat="server" Text='<%#Eval("Business started in") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No Of Employees">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_NoOfEmployees" runat="server" Text='<%#Eval("No Of Employees") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Email" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSubTotal" runat="server" Text="Total - Hit-times" />
                            </FooterTemplate>
                            <FooterStyle Font-Bold="true" />
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Resource Library">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Resourcelibrary" runat="server" Text='<%#Eval("Resource Library") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalR" runat="server" />
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="center" CssClass="gvItems" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Business Profiling">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_BusinessProfiling" runat="server" Text='<%#Eval("Business Profiling") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalBP" runat="server" />
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Capabilities Profiling">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_CapabilitiesProfiling" runat="server" Text='<%#Eval("Capabilities Profiling") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalCP" runat="server" />
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Financial Modeling">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_FinancialModeling" runat="server" Text='<%#Eval("Financial Modeling") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalFM" runat="server" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Learn More">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_LearnMore" runat="server" Text='<%#Eval("Learn More") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalLM" runat="server" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Faqs OnlineHelp">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Faqs" runat="server" Text='<%#Eval("Faqs OnlineHelp") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalFaq" runat="server" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_ROWTOTAL" runat="server"></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalFooter" runat="server" />
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <FooterStyle HorizontalAlign="Right" Width="80" Font-Bold="true" CssClass="gvItems" />
                            <ItemStyle HorizontalAlign="Right" Width="80" CssClass="gvItems" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DataTableId" Visible="false">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_FLAG" runat="server" Text='<%#Eval("FLAG") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="80" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#838B83" ForeColor="White" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
