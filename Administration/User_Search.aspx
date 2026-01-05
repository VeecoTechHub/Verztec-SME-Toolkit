<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="User_Search.aspx.cs" Inherits="Administration_User_Search" Title="Search User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table3" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
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
            <td colspan="3" align="left" valign="top">
                <table id="Table1" width="770px" align="left" border="0" cellpadding="3">
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Group
                        </td>
                        <td class="formlabel" style="width: 1px">
                            :
                        </td>
                        <td  width="370px">
                            <asp:DropDownList ID="Lst_Group" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            User Id
                        </td>
                        <td class="formlabel" style="width: 1px; height: 3px;">
                            :
                        </td>
                        <td style=" height: 3px;" width="370px">
                            <asp:TextBox ID="Txt_Userid" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" height="3" style="width: 200px">
                            Name
                        </td>
                        <td class="formlabel" height="3" style="width: 1px">
                            :
                        </td>
                        <td height="3" width="370px">
                            <asp:TextBox ID="Txt_Name" runat="server" MaxLength="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Page Size&nbsp;
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1px">
                            :
                        </td>
                        <td  colspan="1" style="width: 370px">
                            <asp:TextBox ID="Txt_Page_Size" runat="server" MaxLength="2" Width="55px" Columns="3"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="Txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td style="width: 1px">
                        </td>
                        <td colspan="1" height="3" width="370px">
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_Go_Click">
                            </asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3">
                            &nbsp;<table id="Table2" cellspacing="0" cellpadding="2" width="525" border="0" style="width: 525px;
                                height: 34px">
                                <tr>
                                    <td style="width: 70%;" align="left" valign="middle">
                                        <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" ForeColor="Red">User information not available.</asp:Label>
                                        <%--   <asp:panel id="pnluser" runat="server" Width="60%" Height="16px" Visible="False">
                                                Select/De-select All </asp:panel>--%>
                                    </td>
                                    <td align="right" valign="bottom">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%; height: 38px; font-size: small; font-family: Verdana;" align="left"
                                        valign="bottom">
                                        <span id="spselect" runat="server">
                                        <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                                            type="checkbox" class="formlabel" />
                                        Select/De-select All
                                        </span>
                                    </td>
                                    <td align="right" style="height: 38px" valign="bottom">
                                        <%--<asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_New_Click">
                                        </asp:ImageButton>--%>

                                         <a href='javascript:postForEdit1("<%=ViewState["t_urladd"]%>","","<%=token %>");' class="btnClasslink"
                                                    tabindex="5"><img src="../images/add.jpg" border="0" /></a>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DataGrid ID="DG_User_List" runat="server" Width="700px" OnPageIndexChanged="ChangeDGPAGE"
                                            OnSortCommand="DG_User_List_SortCommand" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="1" BorderColor="Black" AllowSorting="True" OnItemCreated="DG_User_List_ItemCreated"
                                            CaptionAlign="Top" >
                                            <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Select">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "USER_ID")%>'>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn SortExpression="USER_ID" HeaderText="User ID">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"USER_ID")%>' ></asp:Label>--%>
                                                        <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "USER_ID")%>
                                                     <%--   <a id="A1" class="menu_admin" href="<%=getEditProfilePage()%>"> <%#DataBinder.Eval(Container.DataItem, "USER_ID")%></a>--%>
                                                       
                                                       <%-- <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>",<%#((Label)DG_User_List.FindControl("lbluserid").Controls[0]).ToString()%>;--%>

                                                      <%-- <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%#=lbluserid.ToString()%>")';--%>
                                                     <%--   <%#Is_Exist(DataBinder.Eval(Container.DataItem, "FUNC_ID").ToString())%>--%>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="USER_NM" SortExpression="USER_NM" HeaderText="Name">
                                                    <ItemStyle CssClass="menu_admin" />
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn SortExpression="GROUP_DESCR" HeaderText="Group">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <a class="menu_admin">
                                                            <%--<%#DataBinder.Eval(Container.DataItem, "GroupID")%>--%>
                                                            <%#DataBinder.Eval(Container.DataItem, "GROUPDESC")%>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%">
                                        <asp:ImageButton ImageUrl="~/images/delete.jpg" ID="Button_Delete" runat="server"
                                            Text="Delete" OnClick="Button_Delete_Click"></asp:ImageButton>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" ForeColor="Black" Font-Bold="True"
                                            CssClass="formlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
