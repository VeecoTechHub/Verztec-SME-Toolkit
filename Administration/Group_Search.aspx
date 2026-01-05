<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="Group_Search.aspx.cs" Inherits="Administration_Group_Search" Title="Search Group" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table3" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" /></td>
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
            <td colspan="3" align="left">
                <table id="Table1" width="770px" align="center" border="0">
                    <tr>
                        <td class="formlabel" height="3" style="width: 200px">
                            Group ID&nbsp;</td>
                        <td class="formlabel" height="3" style="width: 1px">
                            :</td>
                        <td width="30%" height="3" style="width: 370px">
                            <asp:TextBox ID="Txt_Group_Id" runat="server" MaxLength="15"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 200px">
                            Description&nbsp;</td>
                        <td class="formlabel" height="3" style="width: 1px">
                            :</td>
                        <td height="3" width="370px">
                            <asp:TextBox ID="Txt_Description" runat="server" MaxLength="20"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 200px" class="formlabel">
                            Page Size
                        </td>
                        <td height="3" nowrap="nowrap" class="formlabel" style="width: 1px">
                            :</td>
                        <td width="30%" colspan="1" height="3" style="width: 370px">
                            <asp:TextBox ID="Txt_Page_Size" runat="server" Width="55px" MaxLength="2"></asp:TextBox>&nbsp;
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="Txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
                            <%--                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server">
                                    </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; height: 24px;">
                        </td>
                        <td style="width: 1px; height: 24px;">
                        </td>
                        <td colspan="1" style="height: 24px;" width="370px">
                            <asp:ImageButton ID="Button_go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_go_Click">
                            </asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table id="Table2" cellspacing="0" cellpadding="2" width="526" border="0">
                                <tr>
                                    <td style="height: 18px" colspan="2">
                                        <asp:Label ID="Lblnorecords" runat="server" Visible="False" Font-Bold="True" CssClass="warnings"
                                            Font-Size="Small">No data available.</asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" align="left" valign="top">
                                    </td>
                                    <td align="right" valign="top">
                                        <%--<asp:ImageButton ID="Button_Add" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_Add_Click">
                                        </asp:ImageButton>--%>
                                          <a href='javascript:postForEdit1("<%=ViewState["t_urladd"]%>","","<%=token %>");' class="btnClasslink"
                                                    tabindex="5"><img src="../images/add.jpg" border="0" /></a>
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DataGrid ID="DG_Group_List" runat="server" Width="700px" Visible="False" AllowSorting="True"
                                            BorderColor="black" GridLines="Both" CellPadding="4" CellSpacing="0" AutoGenerateColumns="False"
                                            AllowPaging="True" OnPageIndexChanged="ChangeDGPAGE" HeaderStyle-CssClass="CartListHead"
                                            OnSortCommand="DG_Group_List_SortCommand" OnItemCreated="DG_Group_List_ItemCreated">
                                            <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                                                        type="checkbox" class="formlabel" />Select
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "GROUP_ID")%>'>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn SortExpression="GROUP_ID" HeaderText="Group ID">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%--<a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%#DataBinder.Eval(Container.DataItem, "GROUP_ID")%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "GROUP_ID")%>--%>


                                                               <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "GROUP_ID")%>


                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="GROUP_DESCR" SortExpression="GROUP_DESCR" HeaderText="Description">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemStyle CssClass="menu_admin" />
                                                </asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="Button_delete" runat="server" ImageUrl="~/images/delete.jpg"
                                            OnClick="Button_delete_Click" Height="20px"></asp:ImageButton></td>
                                    <td align="right">
                                        <asp:Label ID="Lbl_Pageinfo" CssClass="formlabel" runat="server" Visible="False"
                                            Font-Bold="True" ForeColor="Black"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="35">
                            <p align="left">
                                <br>
                                &nbsp;</p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p align="left">
                                &nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="35">
                            <p align="left">
                                &nbsp;</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
