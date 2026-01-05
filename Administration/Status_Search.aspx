<%@ Page AutoEventWireup="true" CodeFile="Status_Search.aspx.cs" Inherits="Masters_Status_Search"
    Language="C#" MasterPageFile="~/Masterpages/Admin.master" Title="Search Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table3" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px">
        <tbody>
            <tr>
                <td height="40" style="width: 34px">
                    <img src="../images/arrow.GIF"  align="absmiddle" style="padding-left: 15px" /></td>
                <td width="635" align="left">
                    <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                     &gt;&gt;   <%=(ViewState["Links"].ToString().Split('|')[4])%>
                        </strong></td>
                <td width="164" align="left" valign="middle">
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
                <td align="left" valign="top" colspan="3">
                    <table id="Table1" width="100%" align="left" border="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
                        background-repeat: repeat-x">
                        <tbody>
                            <tr>
                                <td class="formlabel" colspan="3" height="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="formlabel" height="3" style="width: 20%">
                                    Status Description</td>
                                <td class="formlabel" height="3" style="width: 5">
                                    :</td>
                                <td width="30%" height="3" style="width: 75%">
                                    <asp:TextBox ID="Txt_StatusDescription" runat="server" MaxLength="40"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="formlabel" style="width: 406px">
                                    Page Size&nbsp;
                                </td>
                                <td class="formlabel" style="width: 41px">
                                    :</td>
                                <td width="30%" colspan="3" height="3" style="width: 83%">
                                    <asp:TextBox ID="Txt_Page_Size" runat="server" MaxLength="2" Columns="3" Width="55px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                        TargetControlID="Txt_Page_Size">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 406px">
                                </td>
                                <td style="width: 41px">
                                </td>
                                <td colspan="3" style="width: 83%">
                                    <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_Go_Click" />
                                    <%--<asp:Button ID="Button_Go" runat="server" CssClass="btn" Text="Go" OnClick="Button_Go_Click">
                                    </asp:Button>--%>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" colspan="5">
                                    &nbsp;<table id="Table2" cellspacing="0" cellpadding="2" width="579" border="0" style="width: 579px;
                                        height: 34px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" CssClass="warnings">* Required Field</asp:Label></td>
                                            <td align="right">
                                                <asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_New_Click" />
                                                <%-- <asp:Button ID="Button_New" runat="server" CssClass="btn" Text="Add" OnClick="Button_New_Click">
                                                </asp:Button>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:DataGrid ID="DG_Status_List" runat="server" Width="579px" AllowSorting="True"
                                                    BorderColor="Black" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True"
                                                    OnPageIndexChanged="ChangeDGPAGE" OnCancelCommand="DG_Status_List_CancelCommand"
                                                    OnEditCommand="DG_Status_List_EditCommand" OnItemCommand="DG_Status_List_ItemCommand"
                                                    OnItemCreated="DG_Status_List_ItemCreated" OnSortCommand="DG_Status_List_SortCommand"
                                                    OnUpdateCommand="DG_Status_List_UpdateCommand">
                                                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                                    <Columns>
                                                        <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel"
                                                            EditText="Edit">
                                                            <ItemStyle Font-Size="Smaller" CssClass="menu_admin" Width="10%"></ItemStyle>
                                                        </asp:EditCommandColumn>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbtn_delete" CssClass="menu_admin" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn SortExpression="StatusId" HeaderText="Status Id">
                                                            <ItemTemplate>
                                                                <a class="menu_admin">
                                                                    <%# DataBinder.Eval(Container, "DataItem.StatusId")%>
                                                                </a>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_edit" CssClass="menu_admin" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StatusId") %>'>
                                                                </asp:TextBox>&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="warnings"
                                                                    ErrorMessage="*" ControlToValidate="txt_edit" ForeColor=" "></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="Rangevalidator2" runat="server" ErrorMessage="Enter only  numerics "
                                                                    MinimumValue="1" MaximumValue="999" Type="Integer" ControlToValidate="txt_edit"></asp:RangeValidator>
                                                            </EditItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn SortExpression="StatusDescription" HeaderText="Status Description">
                                                            <ItemTemplate>
                                                                <a class="menu_admin">
                                                                    <%# DataBinder.Eval(Container, "DataItem.StatusDescription")%>
                                                                </a>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_edit1" CssClass="menu_admin" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StatusDescription") %>'>
                                                                </asp:TextBox>&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                    ControlToValidate="txt_edit1" CssClass="warnings" ForeColor=" "></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn Visible="False" DataField="sid" ReadOnly="True" HeaderText="sid"></asp:BoundColumn>
                                                    </Columns>
                                                    <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 23px">
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True" CssClass="formlabel"
                                                    Visible="False">No data available.</asp:Label></td>
                                            <td align="right" style="height: 23px">
                                                <asp:Label ID="Lbl_Pageinfo" runat="server" CssClass="formlabel" Visible="False"
                                                    Font-Bold="True" ForeColor="Black"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
