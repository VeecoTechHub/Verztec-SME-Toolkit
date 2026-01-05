<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="Group_Add.aspx.cs" Inherits="Administration_Group_Add" Title="Add Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
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
                <table id="Table1" width="100%" border="0" style="background-image: url(../images/bg.jpg);
                    background-repeat: no-repeat">
                    <tbody>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" height="14">
                                <asp:Label ID="lblError" runat="server" CssClass="warnings" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="width: 8%;" valign="top">
                                Group&nbsp;ID<span style="color: red">*</span>
                            </td>
                            <td class="formlabel" style="width: 1%;" valign="top">
                                :
                            </td>
                            <td style="width: 15%;" valign="top">
                                &nbsp;<asp:TextBox ID="Txt_Group_Id" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td class="formlabel" style="width: 6%;" valign="top">
                                Description<span style="color: #ff0000">*</span>
                            </td>
                            <td class="formlabel" style="width: 1%" valign="top">
                                :
                            </td>
                            <td valign="top">
                                <nobr>
                                    &nbsp;<asp:TextBox ID="Txt_Description" runat="server" MaxLength="30"></asp:TextBox>
                                </nobr>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" colspan="5" height="20px">
                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ControlToValidate="Txt_Group_Id"
                                    CssClass="warnings">Enter Group ID</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="Req_Vldtr_Desc" runat="server" CssClass="warnings"
                                    ControlToValidate="Txt_Description">Enter Description</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formlabel" colspan="3">
                                <strong>Function Association </strong>
                            </td>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="6">
                                <asp:DataGrid ID="DG_Function_List" runat="server" Width="100%" AllowSorting="false"
                                    BorderColor="black" BorderWidth="1" BorderStyle="Solid" GridLines="both" CellPadding="0"
                                    CellSpacing="0" AutoGenerateColumns="False">
                                    <%--<AlternatingItemStyle BackColor="#EFD7C0" />--%>
                                    <HeaderStyle Height="25px" CssClass="tableHeading" VerticalAlign="Bottom"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateColumn SortExpression="FUNC_ID" HeaderText="Select">
                                            <HeaderStyle Height="25px" ForeColor="Black" VerticalAlign="Bottom"></HeaderStyle>
                                            <ItemTemplate>
                                                <input type="checkbox" name="Cbx_Fid" value='<%#DataBinder.Eval(Container.DataItem, "FUNC_ID")%>'>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn SortExpression="SHRT_DESCR" HeaderText="Function ID">
                                            <HeaderStyle Height="25px" ForeColor="Black" VerticalAlign="Bottom"></HeaderStyle>
                                            <ItemTemplate>
                                                <a class="menu_admin">
                                                    <%#DataBinder.Eval(Container.DataItem, "SHRT_DESCR")%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="PARENT_MENU" SortExpression="PARENT_MENU" HeaderText="Parent Menu">
                                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                                            <ItemStyle CssClass="menu_admin" />
                                        </asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid><asp:Label ID="Lblnorecords" CssClass="warnings" Font-Size="Small"
                                    runat="server" Font-Bold="True" ForeColor="Red" Visible="False">No data available.</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" height="24">
                                <table cellspacing="3">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="Button_Save" ImageUrl="~/images/save.jpg" runat="server" Text="Save"
                                                CausesValidation="true" OnClick="Button_Save_Click"></asp:ImageButton>
                                        </td>
                                        <td>
                                            <%--<asp:ImageButton ID="Button_Back" ImageUrl="~/images/back.jpg" runat="server" Text="Back"
                                                CausesValidation="False" OnClick="Button_Back_Click"></asp:ImageButton>--%>
                                            <a href='javascript:postForEdit1("<%=ViewState["t_urlback"]%>","we+XKcjPYmE=","<%=token %>");'
                                                tabindex="6">
                                                <img src="../images/back.jpg" border="0" />
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" height="4d0">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
