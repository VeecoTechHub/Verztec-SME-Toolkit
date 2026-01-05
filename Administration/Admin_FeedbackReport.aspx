<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="Admin_FeedbackReport.aspx.cs" Inherits="Administration_FeedbackReport" %>

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
                        <td class="formlabel" style="width:  200px">
                            Name
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width:  370px">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="200px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width:  200px">
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
                            Page Size&nbsp;
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1px">
                            :
                        </td>
                        <td width="370px" colspan="1">
                            <asp:TextBox ID="Txt_Page_Size" runat="server" MaxLength="2" Width="55px" Columns="3"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="Txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td nowrap="nowrap" style="width: 1px">
                        </td>
                        <td colspan="1"  width="370px">
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
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 70%;" align="left" valign="middle">
                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="true" CssClass="warnings">Records Not Found</asp:Label>
            </td>
            <td align="right" valign="bottom">
            </td>
        </tr>
        <tr>
            <td style="width: 70%;" runat="server" id="tdSelect">
                <br />
                <%--<input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                    type="checkbox" class="formlabel" />
                Select/De-select All--%>
            </td>
            <td align="right">
                <asp:ImageButton ID="btnExptoExcel" runat="server" ImageUrl="~/images/Export_Excel.gif"
                    OnClick="btnExptoExcel_Click" />
              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="DG_Feedback" runat="server" Width="100%"  AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" OnRowDataBound="DG_Feedback_RowDataBound"
                    OnPageIndexChanging="DG_Feedback_PageIndexChanging" OnRowCreated="DG_Feedback_RowCreated">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                     <asp:TemplateField HeaderText="Industry">
                            <HeaderStyle ForeColor="Black" Width="120"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("IndustryName") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <HeaderStyle ForeColor="Black" Width="120"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("UserName") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Question">
                            <HeaderStyle ForeColor="Black" Width="260"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Question" runat="server" Text='<%#Eval("Question") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer">
                            <HeaderStyle ForeColor="Black" Width="100"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Answer" runat="server" Text='<%#Eval("Answer") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                 
                        <asp:TemplateField HeaderText="Posted On">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_PostedOn" runat="server" Text='<%#Eval("PostedOn") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                       </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="Posted ID" Visible="false">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Posted" runat="server" Text='<%#Eval("PostedID") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
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
                <asp:GridView ID="gvExcel" runat="server" Width="100%"   AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" CaptionAlign="Top" OnRowDataBound="gvExcel_RowDataBound"
                     OnRowCreated="gvExcel_RowCreated">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                     <asp:TemplateField HeaderText="Industry">
                            <HeaderStyle ForeColor="Black" Width="120"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("IndustryName") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <HeaderStyle ForeColor="Black" Width="120"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("UserName") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Question">
                            <HeaderStyle ForeColor="Black" Width="260"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Question" runat="server" Text='<%#Eval("Question") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer">
                            <HeaderStyle ForeColor="Black" Width="100"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Answer" runat="server" Text='<%#Eval("Answer") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                 
                        <asp:TemplateField HeaderText="Posted On">
                            <HeaderStyle ForeColor="Black" Width="120"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_PostedOn" runat="server" Text='<%#Eval("PostedOn") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                       </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="Posted ID" Visible="false">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Posted" runat="server" Text='<%#Eval("PostedID") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="menu_admin" />
                    <PagerStyle Font-Bold="True" CssClass="tableHeading"></PagerStyle>
                    <PagerSettings Mode="Numeric" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">               
            </td>
            <td align="right" style="font-weight: bold">
                <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" ForeColor="Black" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
