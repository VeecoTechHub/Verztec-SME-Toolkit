<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="Admin_NextSteps.aspx.cs" Inherits="Administration_Admin_NextSteps" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>--%>
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
                            Category Title
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:TextBox ID="txtCourseTitle" runat="server" MaxLength="40" Width="100px"></asp:TextBox>
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
                        <td nowrap="nowrap" style="width: 1px">
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
            <td style="width: 70%;">
                <br />
                <%--<asp:CheckBox ID="id_ckbx_All" runat="server" Text="Select/De-select All" onclick="toggleAllCheckboexs(this.checked)"/>--%>
                <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                    type="checkbox" class="formlabel" />
                Select/De-select All
            </td>
            <td style="height: 38px" valign="bottom" align="right">
                <%--<asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_New_Click">
                </asp:ImageButton>--%>
                <a href='javascript:postForEdit1("<%=ViewState["t_url"]%>","","<%=token %>");' class="btnClasslink"
                    tabindex="5">
                    <img src="../images/add.jpg" border="0" /></a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <%--<asp:GridView ID="id_GV" runat="server" ShowHeader="true" GridLines="Both" BorderWidth="2"
                            Width="626px" RowStyle-BorderWidth="2px" RowStyle-BorderStyle="Solid" RowStyle-BorderColor="Black"
                            ShowFooter="false" AutoGenerateColumns="false" CellPadding="1" BorderColor="Black"
                            CaptionAlign="Top" AllowPaging="True" AllowSorting="True" PageSize="10" OnPageIndexChanging="id_GV_PageIndexChanging"
                            DataKeyNames="CID" OnSorting="id_GV_Sorting">
                            <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="left" ControlStyle-Height="20px">
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="id_ckbx" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Category_Title" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:Label ID="id_lbl_Title" runat="server" Text="Title"></asp:Label>
                                    </HeaderTemplate>
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" Text='<%# Bind("Category_Title")%>' runat="server"
                                            NavigateUrl='<%#"~/Administration/Admin_AddNextSteps.aspx?CID=" + DataBinder.Eval(Container.DataItem,"CID")%>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Faculty" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:Label ID="id_lblHeader_Faculty" runat="server" Text="Faculty"></asp:Label>
                                    </HeaderTemplate>
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="id_lbl_Faculty" runat="server" Text='<%#Eval("Faculty")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Created_By">
                                    <HeaderTemplate>
                                        <asp:Label ID="id_lbl_Author" runat="server" Text="Author"></asp:Label>
                                    </HeaderTemplate>
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Author" runat="server" Text='<%#Eval("Created_By")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Duration_From">
                                    <HeaderTemplate>
                                        <asp:Label ID="id_lbl_Duration_From" runat="server" Text="PublishedOn"></asp:Label>
                                    </HeaderTemplate>
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Duration_From" runat="server" Text='<%#Eval("Duration_From") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Duration_To">
                                    <HeaderTemplate>
                                        <asp:Label ID="id_lbl_Duration_To" runat="server" Text="Duration_To"></asp:Label>
                                    </HeaderTemplate>
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Duration_To" runat="server" Text='<%#Eval("Duration_To") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Description">
                                    <HeaderTemplate>
                                        <asp:Label ID="id_lbl_Description" runat="server" Text="Description"></asp:Label>
                                    </HeaderTemplate>
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Description" runat="server" Text='<%#Eval("Description")%>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="tableHeading" Font-Bold="true" />
                          <pagersettings mode="Numeric" position="Bottom" pagebuttoncount="10"/>
                        </asp:GridView>--%>
                <asp:DataGrid ID="DG_NextStep" runat="server" Width="747px" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" OnItemCreated="DG_NextStep_ItemCreated"
                    OnPageIndexChanged="DG_NextStep_PageIndexChanged" OnSortCommand="DG_NextStep_SortCommand"
                    OnItemDataBound="DG_NextStep_ItemDataBound">
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Select">
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                            <ItemTemplate>
                                <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "CID")%>'>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Category Title">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <%--<a class="menu_admin" href='Admin_AddNextSteps.aspx?CID=<%#DataBinder.Eval(Container.DataItem, "CID")%>'>
                                            <%#DataBinder.Eval(Container.DataItem, "Category_Title")%>--%>
                                <%-- <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");'>
                                    <%#DataBinder.Eval(Container.DataItem, "Category_Title")%>--%>
                                <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>","<%=token%>");'>
                                    <%#DataBinder.Eval(Container.DataItem, "Category_Title")%>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Duration From">
                            <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Duration_From" runat="server" Text='<%#Eval("Duration_From") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Duration To">
                            <HeaderStyle ForeColor="Black" Width="110"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Duration_To" runat="server" Text='<%#Eval("Duration_To") %>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Description">
                            <HeaderStyle ForeColor="Black" Width="100"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Description" runat="server" Text='<%#Eval("Description")%>'></asp:Label></ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Topic">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CID")%>' />
                                <asp:Label ID="lbl_Topic" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="View Regs Report">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url1"]%>","<%=getEditProfilePage()%>");'>
                                    Regs.Report </a>
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
                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Course');"
                    OnClick="id_btn_Delete_Click"></asp:ImageButton>
            </td>
            <td align="right" style="font-weight: bold">
                <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" ForeColor="Black" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
    <%-- </contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
