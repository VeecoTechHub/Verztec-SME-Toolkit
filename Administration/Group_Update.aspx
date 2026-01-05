<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="Group_Update.aspx.cs" Inherits="Administration_Group_Update" Title="Update Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x">
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
            <td colspan="3" align="left">
                <table id="Table1" width="100%" border="0">
                    <tr>
                        <td colspan="6" style="height: 15px">
                            <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="15%" valign="top">
                            Group&nbsp;ID<span style="color: #ff0000">*</span>
                        </td>
                        <td class="formlabel" style="width: 1%;" valign="top">
                            :
                        </td>
                        <td style="width: 17%;" valign="top">
                            &nbsp;<asp:TextBox ID="Txt_Group_Id" runat="server" ReadOnly="True" Width="169px"
                                BorderStyle="None" MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="Requiredfieldvalidator1"
                                    runat="server" ForeColor="#ff6633" ErrorMessage="*" CssClass="warnings" ControlToValidate="Txt_Group_Id"></asp:RequiredFieldValidator>
                        </td>
                        <td class="formlabel" style="width: 6%;" valign="top">
                            Description<span style="color: #ff0000">*</span>
                        </td>
                        <td class="formlabel" style="width: 1%;" valign="top">
                            :
                        </td>
                        <td valign="top">
                            <nobr>
                                &nbsp;<asp:TextBox ID="Txt_Description" runat="server" MaxLength="120"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="Req_Vldtr_Desc" runat="server" ControlToValidate="Txt_Description" CssClass="warnings"
                                    ErrorMessage="*" ForeColor="#ff6633"></asp:RequiredFieldValidator>&nbsp;
                            </nobr>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 20px">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="warnings" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" colspan="3">
                            Function Association
                        </td>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="6">
                            <asp:DataGrid ID="DG_Function_List" runat="server" Width="100%" AutoGenerateColumns="False"
                                CellSpacing="0" CellPadding="0" GridLines="Both" OnSortCommand="DG_Function_List_SortCommand">
                                <HeaderStyle CssClass="tableHeading" Height="25px"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="Select">
                                        <HeaderStyle ForeColor="Black" Height="25px"></HeaderStyle>
                                        <ItemTemplate>
                                            <input type="checkbox" name="Cbx_Fid" value='<%#DataBinder.Eval(Container.DataItem, "FUNC_ID")%>'
                                                <%#Is_Exist(DataBinder.Eval(Container.DataItem, "FUNC_ID").ToString())%>>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn SortExpression="SHRT_DESCR" HeaderText="Function ID">
                                        <HeaderStyle ForeColor="Black" Height="25px"></HeaderStyle>
                                        <ItemTemplate>
                                            <a class="menu_admin">
                                                <%#DataBinder.Eval(Container.DataItem, "SHRT_DESCR")%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="PARENT_MENU" HeaderText="Parent Menu" SortExpression="PARENT_MENU">
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle CssClass="menu_admin" />
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                            <asp:Label ID="Lblnorecords" runat="server" Visible="False" Font-Bold="False" CssClass="warnings">No data available.</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" height="35">
                            <table cellspacing="3" valign="top">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="Bttn_Save" runat="server" CausesValidation="true" ImageUrl="~/images/save.jpg"
                                            OnClick="Bttn_Save_Click"></asp:ImageButton>
                                    </td>
                                    <td>
                                        <%--    <asp:ImageButton ID="Bttn_Back" runat="server" ImageUrl="~/images/back.jpg" OnClick="Bttn_Back_Click"
                                            CausesValidation="False"></asp:ImageButton>--%>
                                        <a href='javascript:postForEdit1("<%=ViewState["t_urlback"]%>","we+XKcjPYmE=","<%=token %>");'
                                            tabindex="6">
                                            <img src="../images/back.jpg" border="0" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" height="40">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
