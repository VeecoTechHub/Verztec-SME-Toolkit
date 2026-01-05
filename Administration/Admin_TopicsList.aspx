<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="Admin_TopicsList.aspx.cs" Inherits="Administration_Admin_TopicsList" %>

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
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;" align="left" valign="middle">
        <tr>
            <td style="width: 70%;" align="left" valign="middle">
                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="true" CssClass="warnings">Records Not Found</asp:Label>
            </td>
            <td align="right" valign="bottom">
            </td>
        </tr>
        <tr>
            <td>
                <span id="spSelect" runat="server">
                    <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                        type="checkbox" class="formlabel" />
                    Select/De-select All</span>
            </td>
            <td style="height: 38px" valign="bottom" align="right">
            <%--    <asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" 
                    onclick="Button_New_Click1" style="height: 21px" 
                   >
                </asp:ImageButton>--%>

                 <a href='javascript:postForEdit1("<%=ViewState["t_url"]%>","","<%=token %>");' class="btnClasslink"
                                                    tabindex="5"><img src="../images/add.jpg" border="0" /></a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataGrid ID="DG_Topics" runat="server" AllowPaging="True" PageSize="100"
                    AutoGenerateColumns="False" CellPadding="1" BorderColor="Black" AllowSorting="True" Width="100%"
                    CaptionAlign="Top" OnPageIndexChanged="DG_Topics_PageIndexChanged">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Select" Visible="true" ItemStyle-Width="2%">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "TopicID")%>'>
                            </ItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Category" ItemStyle-Width="40%">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                 <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>","<%=token%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "TopicName")%>

                                </a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Description"  ItemStyle-Width="58%">
                            <HeaderStyle ForeColor="Black" Width="100"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_TopicDesc" runat="server" Text='<%#Eval("TopicDesc") %>'></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TopicID")%>' />
                                </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                    </Columns>
                    <ItemStyle CssClass="menu_admin" />
                    <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:ImageButton ImageUrl="~/images/delete.jpg" ID="id_btn_Delete" runat="server" Visible="true"
                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this category');"
                    OnClick="id_btn_Delete_Click" Style="height: 21px"></asp:ImageButton>
                    <asp:HiddenField ID="hdnf" runat="server" />
            </td>
            <td align="right" style="font-weight: bold">
                <asp:Label ID="Lbl_Pageinfo" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

