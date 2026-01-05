<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="AdminResourcesLibrary.aspx.cs" Inherits="Administration_AdminResourcesLibrary" %>

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
            <td colspan="3">
                <table id="Table1" width="770px" align="left" border="0" cellpadding="3">
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Topic
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
                            Article Title
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 200px">
                            <asp:TextBox ID="txtCourseTitle" runat="server" MaxLength="20" Width="55px"></asp:TextBox>
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
                        <td colspan="1"  width="370px">
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
                </table>
            </td>
        </tr>
    </table>
    <table>
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
                <asp:DataGrid ID="DG_ResourcesLibrary" runat="server" Width="747px" AllowPaging="True"
                    AutoGenerateColumns="False" CellPadding="1" BorderColor="Black" AllowSorting="True"
                    CaptionAlign="Top" OnItemCreated="DG_ResourcesLibrary_ItemCreated" OnPageIndexChanged="DG_ResourcesLibrary_PageIndexChanged"
                    OnSortCommand="DG_ResourcesLibrary_SortCommand" OnItemDataBound="DG_ResourcesLibrary_ItemDataBound">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Select">
                            <HeaderStyle ForeColor="Black" Width="10"></HeaderStyle>
                            <ItemTemplate>
                                <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "RL_ID")%>'>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Article Title">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <%--<a class="menu_admin" href='AdminAddResource.aspx?RL_ID=<%#DataBinder.Eval(Container.DataItem, "RL_ID")+"&FName=" + DataBinder.Eval(Container.DataItem,"RL_FIleName")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "ArticleTitle")%>--%>

                          
                          <%--<a class="menu_admin" href='AdminAddResource.aspx?RL_ID=<%#DataBinder.Eval(Container.DataItem, "RL_ID")+"&FName=" + DataBinder.Eval(Container.DataItem,"RL_FIleName")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "ArticleTitle")%>--%>
                                 <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>","<%=token%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "ArticleTitle")%>

                                </a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Author Name">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="id_lbl_Author_Name" runat="server" Text='<%#Eval("Author_Name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Published On">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_PublishedOn" runat="server" Text='<%#Eval("PublishedOn")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Article Description">
                            <HeaderStyle ForeColor="Black" Width="100"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_ArticleDescription" runat="server" Text='<%#Eval("ArticleDescription") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Topic">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("RL_ID")%>' />
                                <asp:Label ID="lbl_Topic" runat="server" Text=""></asp:Label>
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
                <asp:ImageButton ImageUrl="~/images/delete.jpg" ID="id_btn_Delete" runat="server"
                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Title');"
                    OnClick="id_btn_Delete_Click" Style="height: 21px"></asp:ImageButton>
                    <asp:HiddenField ID="hdnf" runat="server" />
            </td>
            <td align="right" style="font-weight: bold">
                <asp:Label ID="Lbl_Pageinfo" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
