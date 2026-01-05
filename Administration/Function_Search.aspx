<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="Function_Search.aspx.cs" Inherits="Administration_Function_Search"
    Title="Search Function" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF"
        style="background-image: url(../images/bg.jpg); background-repeat: repeat-x;
        padding-left: 10px;">
        <tr>
            <td height="40" style="width: 34px">
                <img src="../images/arrow.GIF" width="13" height="15" align="absmiddle" style="padding-left: 15px" />
            </td>
            <td width="600" align="left">
                <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                    &gt;&gt;<%=(ViewState["Links"].ToString().Split('|')[4])%></strong>
            </td>
            <td width="180" align="left" valign="middle">
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
            <td colspan="3" align="left">
                <table id="Table1" width="100%" align="center" border="0">
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 11%">
                            Function Id&nbsp;
                        </td>
                        <td class="formlabel" style="width: 1%">
                            :
                        </td>
                        <td style="width: 15%">
                            <asp:TextBox ID="Txt_FunctionId" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                        <td class="formlabel" style="width: 15%">
                            Parent Menu&nbsp;
                        </td>
                        <td class="formlabel" style="width: 1%">
                            :
                        </td>
                        <td width="30%">
                            <asp:DropDownList ID="Lst_Parent_Menu" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 11%">
                            Description&nbsp;
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td height="3" style="width: 15%">
                            <asp:TextBox ID="Txt_Description" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                        <td class="formlabel" nowrap height="3" style="width: 15%">
                            Short Description&nbsp;
                        </td>
                        <td class="formlabel" height="3" nowrap="nowrap" style="width: 1%">
                            :
                        </td>
                        <td width="30%" height="3">
                            <asp:TextBox ID="Txt_Short_Desc" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 11%;">
                            Page Size&nbsp;
                        </td>
                        <td class="formlabel">
                            :
                        </td>
                        <td width="30%" colspan="4">
                            <asp:TextBox ID="Txt_Page_Size" runat="server" Width="55px" MaxLength="2"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="Txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11%">
                        </td>
                        <td style="width: 1%">
                        </td>
                        <td colspan="4" width="30%">
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_Go_Click">
                            </asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <table id="Table2" cellspacing="0" cellpadding="2" width="526" border="0">
                                <tr>
                                    <td style="width: 70%">
                                        <asp:Label ID="Lblnorecords" runat="server" Visible="False" Font-Bold="True" ForeColor="Red">No data available.</asp:Label>
                                    </td>
                                    <td align="right" valign="top">
                                        <%--<asp:ImageButton ID="Button_add" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_add_Click">
                                        </asp:ImageButton>--%>
                                        <a href='javascript:postForEdit1("<%=ViewState["t_urladd"]%>","","<%=token %>");'
                                            class="btnClasslink" tabindex="5">
                                            <img src="../images/add.jpg" border="0" /></a>
                                    </td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DataGrid ID="DG_Function_List" runat="server" Width="100%" Visible="False" AllowSorting="True"
                                BorderColor="black" GridLines="Both" CellPadding="4" CellSpacing="0" AutoGenerateColumns="False"
                                AllowPaging="True" OnPageIndexChanged="ChangeDGPAGE" HeaderStyle-CssClass="CartListHead"
                                OnSortCommand="DG_Function_List_SortCommand" OnItemCreated="DG_Function_List_ItemCreated">
                                <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="Select">
                                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                                        <HeaderTemplate>
                                            <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                                                type="checkbox" class="formlabel" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "FUNC_ID")%>'>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="FUNC_ID" HeaderText="Function ID">
                                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                                        <ItemTemplate>
                                            <%--OLD  <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%#DataBinder.Eval(Container.DataItem, "FUNC_ID")%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "FUNC_ID")%>--%>
                                            <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");'>
                                                <%#DataBinder.Eval(Container.DataItem, "FUNC_ID")%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="DESCR" SortExpression="DESCR" HeaderText="Description">
                                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                                        <ItemStyle CssClass="menu_admin" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PARENT_MENU" SortExpression="PARENT_MENU" HeaderText="Parent Menu">
                                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                                        <ItemStyle CssClass="menu_admin" />
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                    <%--changes pk --%>
                       <td colspan="2">
                       <table width="100%" border="0">
                       <tr>
                        <td style="width: 10%">
                       
                            <asp:ImageButton ID="Button_delete" runat="server" OnClick="Button_delete_Click"
                                ImageUrl="~/images/delete.jpg"></asp:ImageButton>
                        </td>
                        <td align="right" width="90%" >
                            <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" CssClass="formlabel"
                                ForeColor="Black" Font-Bold="True"></asp:Label>
                        </td>
                       </tr>
                       </table>
                       </td>
                    </tr>
                    <tr>
                        <td style="width: 293px">
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
            <tr>
                <td colspan="6" height="35">
                    <p align="left">
                        &nbsp;&nbsp;</p>
                    <p align="left">
                        &nbsp;</p>
                    <!--</asp:panel>-->
                </td>
            </tr>
            <tr>
                <td colspan="6" height="35">
                    <p align="left">
                        &nbsp;</p>
                </td>
            </tr>
            </table> </td>
        </tr>
    </table>
</asp:Content>
