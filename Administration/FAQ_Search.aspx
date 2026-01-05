<%@ Page Language="C#" MasterPageFile="~/Masterpages/admin.master" AutoEventWireup="true"
    CodeFile="FAQ_Search.aspx.cs" Inherits="Administration_FAQ_Search" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            <td colspan="3" align="left" valign="top">
                <table id="Table1" width="770px" align="left" border="0" cellpadding="3">
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Category
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:DropDownList ID="ddlCategory" runat="server">
                            </asp:DropDownList>
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
                        <td class="formlabel" style="width: 200px">
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1px">
                        </td>
                        <td colspan="1" width="370px">
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
                                        <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="False" CssClass="warnings">Faqs not available</asp:Label>
                                    </td>
                                    <td align="right" valign="bottom">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%; height: 38px; font-size: small; font-family: Verdana;" align="left"
                                        valign="bottom">
                                        <span id="spSelect" runat="server">
                                            <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                                                        type="checkbox" class="formlabel" />
                                            Select/De-select All</span>
                                    </td>
                                    <td align="right" style="height: 38px" valign="bottom">
                                        <asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_New_Click">
                                        </asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DataGrid ID="DG_Faq" runat="server" Width="626px" OnPageIndexChanged="DG_Faq_PageIndexChanged"
                                            OnSortCommand="DG_Faq_SortCommand" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="1" BorderColor="Black" AllowSorting="True" OnItemCreated="DG_Faq_ItemCreated"
                                            CaptionAlign="Top">
                                            <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Select">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "FaqId")%>'>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn SortExpression="CategoryName" HeaderText="Category">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                       <%-- <a class="menu_admin" href='FAQ_Update.aspx?FaqId=<%#DataBinder.Eval(Container.DataItem, "FaqId")%>'>
                                                            <%#DataBinder.Eval(Container.DataItem, "CategoryName")%>
                                                        </a>--%>
                                                         <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "CategoryName")%>
                                                        </a>


                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Question">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#CommonFunctions.getContent(DataBinder.Eval(Container.DataItem, "FaqQuestion").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <ItemStyle CssClass="menu_admin" />
                                            <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%; height: 25px;">
                                        <asp:ImageButton ImageUrl="~/images/delete.jpg" ID="Button_Delete" runat="server"
                                            Text="Delete" OnClick="Button_Delete_Click"></asp:ImageButton>
                                    </td>
                                    <td align="right" style="height: 25px">
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
