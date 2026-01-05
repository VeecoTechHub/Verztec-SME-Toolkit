<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="PublicUsersList_Search.aspx.cs" Inherits="Administration_PublicUsersList_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" id="Table3" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF"
        style="background-image: url(../images/bg.jpg); background-repeat: repeat-x;
        padding-left: 10px;">
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
                <table id="Table1" width="850px" align="left" border="0" cellpadding="3">
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Name
                        </td>
                        <td class="formlabel" style="width: 1px">
                            :
                        </td>
                        <td width="370">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="20" Height="19px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Email address
                        </td>
                        <td class="formlabel" style="width: 1px">
                            :
                        </td>
                        <td style="" width="370">
                            <asp:TextBox ID="txtEmailAddress" runat="server" MaxLength="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Company Name
                        </td>
                        <td class="formlabel" style="width: 1px">
                            :
                        </td>
                        <td width="370">
                            <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                      <td class="formlabel" style="width:  200px">
                            Industry
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width:  370px">
                         <asp:DropDownList ID="ddlIndustry" runat="server" Width="161px" AppendDataBoundItems="true">
                         <asp:ListItem Value="0" Text="All"></asp:ListItem>
                         </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Status
                        </td>
                        <td class="formlabel" style="width: 1px; height: 3px;">
                            :
                        </td>
                        <td style="height: 3px;" width="370">
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
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
                        <td colspan="1" width="370">
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
                        <td colspan="1" height="3" width="370">
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search.jpg" OnClick="btnSearch_Click">
                            </asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3">
                            &nbsp;<table id="Table2" cellspacing="0" cellpadding="2"  border="0" style="width: 525px;
                                height: 34px">
                                <tr>
                                    <td style="width: 70%;" align="left" valign="middle">
                                        <asp:Label ID="Lblnorecords" runat="server" Visible="False" Font-Bold="True" ForeColor="Red">No data available.</asp:Label>
                                        <%--   <asp:panel id="pnluser" runat="server" Width="60%" Height="16px" Visible="False">
                                                Select/De-select All </asp:panel>--%>
                                    </td>
                                    <td align="right" valign="bottom">
                                    </td>
                                </tr>
                                <%--  <tr>
                                    <td style="width: 70%; height: 38px; font-size: small; font-family: Verdana;" align="left"
                                        valign="bottom">
                                    </td>
                                    <td align="right" style="height: 38px" valign="bottom">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span id="spSelect" runat="server">
                                            <br />
                                            <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                                                type="checkbox" class="formlabel" />
                                            Select/De-select All</span>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ExporttoExcel" runat="server" ImageUrl="~/images/Export_Excel.gif"
                                            OnClick="ExporttoExcel_Click"></asp:ImageButton>
                                    </td>
                                    <%--  <td style="height: 38px" valign="bottom" align="right">
                <asp:ImageButton ID="Button_New" runat="server" ImageUrl="~/images/add.jpg" OnClick="Button_New_Click1">
                </asp:ImageButton>
            </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DataGrid ID="DG_ResourcesLibrary" runat="server" Width="850px" AllowPaging="True"
                                            AutoGenerateColumns="False" CellPadding="1" BorderColor="Black" AllowSorting="True"
                                            CaptionAlign="Top" OnItemCreated="DG_ResourcesLibrary_ItemCreated" OnPageIndexChanged="ChangeDGPAGE"
                                            OnSortCommand="DG_ResourcesLibrary_SortCommand">
                                            <%--<asp:GridView ID="DG_User_List" runat="server" Width="700px" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="1" BorderColor="Black" AllowSorting="True" PageSize="50" CaptionAlign="Top"
                                            OnRowDataBound="DG_User_List_RowDataBound">--%>
                                            <HeaderStyle CssClass="tableHeading" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Select">
                                                    <HeaderStyle ForeColor="Black" Width="10"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "UserID")%>'>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Name" SortExpression="Name">
                                                    <HeaderStyle ForeColor="Black" Height="20px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%--  <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");''>
                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>--%>
                                                        <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>","<%=token%>");'>
                                                            <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Email ID" SortExpression="EmailID">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("EmailID")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Company name" SortExpression="CompanyNm">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("CompanyNm")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Industry" SortExpression="IndustryName">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("IndustryName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Registered On" SortExpression="CreatedOn">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("CreatedOn")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Status" SortExpression="Status">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("Status")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Resend Link">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="BtnResend" runat="server" Text="Resend" ImageUrl="~/images/Resend.jpg"
                                                            CommandArgument='<%#Eval("UserID")%>' OnClick="BtnResend_Click" Style="height: 21px" />
                                                        <%--    <asp:Button ID="BtnResend" runat="server" Text="Resend" 
                                                            CommandArgument='<%#Eval("UserID")%>' onclick="BtnResend_Click"/>--%>
                                                        <asp:HiddenField ID="hdfldStatus" runat="server" Value='<%#Eval("Status")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px" HorizontalAlign="Center" />
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <ItemStyle CssClass="menu_admin" />
                                            <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                                            <%--<PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>--%>
                                            <%--</asp:GridView>--%>
                                        </asp:DataGrid>
                                        <%--COPIED--%>
                                        <%-- <asp:DataGrid ID="DG_ResourcesLibrary" runat="server" Width="747px" AllowPaging="True"
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
                                <a class="menu_admin" href='AdminAddResource.aspx?RL_ID=<%#DataBinder.Eval(Container.DataItem, "RL_ID")+"&FName=" + DataBinder.Eval(Container.DataItem,"RL_FIleName")%>'>
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
                                <asp:Label ID="lbl_ArticleDescription" runat="server" Text='<%#Eval("ArticleDescription") %>'></asp:Label>
                                </ItemTemplate>
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
                </asp:DataGrid>--%>
                                        <%--COPIED--%>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <%--copied--%>
                                    <td colspan="2">
                                        <asp:DataGrid ID="DG_Export" runat="server" Width="747px" AllowPaging="false" AutoGenerateColumns="False"
                                            CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" OnItemCreated="DG_ResourcesLibrary_ItemCreated">
                                            <%--<asp:GridView ID="DG_User_List" runat="server" Width="700px" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="1" BorderColor="Black" AllowSorting="True" PageSize="50" CaptionAlign="Top"
                                            OnRowDataBound="DG_User_List_RowDataBound">--%>
                                            <HeaderStyle CssClass="tableHeading" />
                                            <Columns>
                                                <%-- <asp:TemplateColumn HeaderText="Select">
                            <HeaderStyle ForeColor="Black" Width="10"></HeaderStyle>
                            <ItemTemplate>
                                <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "UserID")%>'>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                                                <asp:TemplateColumn HeaderText="Name">
                                                    <HeaderStyle ForeColor="Black" Height="20px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%--  <a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>");''>
                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>--%>
                                                        <%--<a class="menu_admin" href='javascript:postForEdit("<%=ViewState["t_url"]%>","<%=getEditProfilePage()%>","<%=token%>");'>--%>
                                                        <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Email ID">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("EmailID")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Company Name">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("CompanyNm")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                 <asp:TemplateColumn HeaderText="Industry">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("IndustryName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Business Started Year">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("BussStartedYear")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="No of Employees">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("NoofEmployees")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Registered On">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("CreatedOn")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Status">
                                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <%#Eval("Status")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <ItemStyle CssClass="menu_admin" />
                                            <%-- <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>--%>
                                            <%--<PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>--%>
                                            <%--</asp:GridView>--%>
                                        </asp:DataGrid>
                                    </td>
                                    <%--copied march--%>
                                </tr>
                                <tr>
                                    <td style="width: 50%">
                                        <asp:ImageButton ImageUrl="~/images/delete.jpg" ID="id_btn_Delete" runat="server" Visible="false"
                                            Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record.');"
                                            OnClick="id_btn_Delete_Click" Style="height: 21px"></asp:ImageButton>
                                        <%--<asp:ImageButton ImageUrl="~/images/delete.jpg" ID="Button_Delete" runat="server"
                                            Text="Delete" OnClick="Button_Delete_Click"></asp:ImageButton>--%>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" ForeColor="Black" Font-Bold="True"></asp:Label>
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
