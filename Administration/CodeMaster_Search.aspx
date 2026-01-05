<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="CodeMaster_Search.aspx.cs" Inherits="Administration_CodeMaster_Search"
    Title="SSW Administration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x">
        <tbody>
             <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" />
            </td>
            <td width="550" align="left">
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
                <td style="width: 833px"  colspan="3">
                    <table id="Table1" width="770px" align="left" border="0">
                        <tbody>
                            <tr>
                                <td colspan="3" height="14">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 220px; white-space: nowrap;" class="formlabel" align="left" height="3">
                                    Status Type</td>
                                <td style="width: 1" class="formlabel" height="3">
                                    :</td>
                                <td style="width: 370px" align="left" height="3">
                                    <asp:DropDownList ID="ddlStatusType" runat="server">
                                    </asp:DropDownList>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="formlabel" align="left" style="width: 200px" >
                                    Status</td>
                                <td style="width: 1px; height: 3px" class="formlabel">
                                    :</td>
                                <td style="width: 370px; height: 3px" align="left">
                                    <asp:TextBox ID="Txt_Status" runat="server" MaxLength="40"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="formlabel" align="left" style="width: 200px">
                                    Page Size&nbsp;
                                </td>
                                <td class="formlabel" style="width: 1px;" >
                                    :</td>
                                <td style="width: 370px" align="left" colspan="3">
                                    <asp:TextBox ID="Txt_Page_Size" runat="server" MaxLength="2" Columns="3" Width="55px"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                        TargetControlID="Txt_Page_Size">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px" align="left">
                                </td>
                                <td style="width: 1">
                                </td>
                                <td style="width: 370px" align="left" colspan="3">
                                <asp:ImageButton ID ="Button_Go" OnClick="Button_Go_Click" runat="server" ImageUrl ="~/images/search.jpg" />
                                   
                                        
                                        </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                             
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" ForeColor="Red">No data available.</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" CssClass="warnings">* Required Field</asp:Label></td>
                                <td align="left" colspan="3">
                                    <asp:UpdateProgress ID="UpdateProgress11" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <div style="position: absolute; left: 321px; top: 350px; width: 150px; height: 59px;
                                                z-index: 1; background-color: #ffffff; text-align: center;">
                                                <img alt="Updating..." src="../images/loadAdmin.gif" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    &nbsp;
                                    <asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_New_Click" />
                                 <%--   <asp:Button ID="Button_New" OnClick="Button_New_Click" runat="server" CssClass="btn"
                                        Text="Add"></asp:Button>--%>
                                        </td>
                            </tr>
                            <tr>
                                <td width="90%" colspan="6">
                                    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" runat="server" RenderMode="Inline">
                                        <ContentTemplate>
                                            <asp:DataGrid ID="DG_CodeMaster_List" runat="server" Width="100%" OnItemCommand="DG_CodeMaster_List_ItemCommand"
                                                OnPageIndexChanged="ChangeDGPAGE" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="1" BorderColor="Black" AllowSorting="True" OnCancelCommand="DG_CodeMaster_List_CancelCommand"
                                                OnEditCommand="DG_CodeMaster_List_EditCommand" OnUpdateCommand="DG_CodeMaster_List_UpdateCommand"
                                                OnItemCreated="DG_CodeMaster_List_ItemCreated" OnSortCommand="DG_CodeMaster_List_SortCommand"
                                                DataKeyField="codeid">
                                                <EditItemStyle HorizontalAlign="Left" Font-Size="Small" VerticalAlign="Top"></EditItemStyle>
                                                <PagerStyle Mode="NumericPages" CssClass="tableHeading" Font-Bold="True"></PagerStyle>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                                <%--<AlternatingItemStyle BackColor="#EFD7C0" />--%>
                                                <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                                <Columns>
                                                    <asp:EditCommandColumn CancelText="Cancel" UpdateText="Update" EditText="Edit">
                                                        <ItemStyle Width="10%" CssClass ="menu_admin" Font-Size="X-Small"></ItemStyle>
                                                    </asp:EditCommandColumn>
                                                    <asp:TemplateColumn>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtn_delete" CssClass ="menu_admin" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Status Type" SortExpression="STATUS_TYPE">
                                                        <ItemTemplate>
                                                        <a class ="menu_admin">
                                                            <%# DataBinder.Eval(Container, "DataItem.STATUS_TYPE") %>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_edit" CssClass="menu_admin" runat="server" Width="114px" Text='<%# DataBinder.Eval(Container, "DataItem.STATUS_TYPE") %>'>
                                                            </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                CssClass="warnings" ForeColor=" " ControlToValidate="txt_edit" ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Status" SortExpression="STATUS">
                                                        <ItemTemplate>
                                                        <a class="menu_admin">
                                                            <%# DataBinder.Eval(Container, "DataItem.STATUS") %>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_edit1" CssClass="menu_admin"  runat="server" Width="101px" Text='<%# DataBinder.Eval(Container, "DataItem.STATUS") %>'>
                                                            </asp:TextBox>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="warnings"
                                                                ForeColor=" " ControlToValidate="txt_edit1" ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Status Description" SortExpression="STATUS_DESCR">
                                                        <ItemTemplate>
                                                        <a class="menu_admin">
                                                            <%# DataBinder.Eval(Container, "DataItem.STATUS_DESCR") %>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_edit2" runat="server" Width="113px" Text='<%# DataBinder.Eval(Container, "DataItem.STATUS_DESCR") %>'>
                                                            </asp:TextBox>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="warnings"
                                                                ForeColor=" " ControlToValidate="txt_edit2" ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Sort Order" SortExpression="Sort_Order">
                                                        <ItemTemplate>
                                                        <a class="menu_admin">
                                                            <%# DataBinder.Eval(Container, "DataItem.Sort_Order") %>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_edit3" CssClass="menu_admin" runat="server" Width="80px" Text='<%# DataBinder.Eval(Container, "DataItem.Sort_Order") %>'>
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="warnings"
                                                                ForeColor=" " ControlToValidate="txt_edit3" ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="codeid" HeaderText="codeid" ReadOnly="True" Visible="False">
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Value" SortExpression="VALUE">
                                                        <ItemTemplate>
                                                         <a class="menu_admin">
                                                            <%# DataBinder.Eval(Container, "DataItem.VALUE")%>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_edit4" runat="server" Width="80px" Text='<%# DataBinder.Eval(Container, "DataItem.VALUE") %>'>
                                                            </asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Value2">
                                                        <ItemTemplate>
                                                        <a class="menu_admin">
                                                            <%# DataBinder.Eval(Container, "DataItem.VALUE2")%>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtValue2" CssClass="menu_admin" runat="server" MaxLength="100" Text='<%#  DataBinder.Eval(Container, "DataItem.VALUE2") %>'></asp:TextBox>&nbsp;
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Enable/Disable">
                                                        <ItemTemplate>
                                                         <a class="menu_admin">
                                                            <%#Convert.ToInt32(DataBinder.Eval(Container, "DataItem.Code_STATUS"))==1?"ACTIVE":"IN ACTIVE"%>
                                                            </a>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Button_Go" />
                                            <asp:AsyncPostBackTrigger ControlID="Button_New" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="6">
                                    <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" CssClass ="formlabel" Font-Bold="True" ForeColor="Black"></asp:Label>&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
               
            </tr>
        </tbody>
    </table>
</asp:Content>
