<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="NextStep.aspx.cs" Inherits="Public_NextStep" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="steps_title">
                <div>
                    Next Steps</div>
            </td>
        </tr>
        <tr>
            <td height="300" valign="top">
                <table width="870" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="203">
                            &nbsp;
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="870" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="80" height="30">
                                                    Category
                                                </td>
                                                <td width="200">
                                                
                                                    <asp:DropDownList ID="id_ddl_Topic" runat="server" Style="width: 185px;">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50" align="right">
                                                    &nbsp;
                                                </td>
                                                <td width="90">
                                                    Course Title
                                                </td>
                                                <td width="200">
                                                    <asp:TextBox ID="id_txt_CategoryTitle" runat="server" Style="width: 180px;" MaxLength="100"></asp:TextBox>
                                                    <ajaxtoolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="id_txt_CategoryTitle"
                                                        ServicePath="~/WebService.asmx" MinimumPrefixLength="1" CompletionInterval="1000"
                                                        CompletionSetCount="12" ServiceMethod="GetCourseDetails_By_Service">
                                                    </ajaxtoolkit:AutoCompleteExtender>
                                                </td>
                                                <td width="250">
                                                    <asp:Button ID="id_btn_Search" runat="server" CssClass="orange_button" Text="Search"
                                                        OnClick="id_btn_Search_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                             
                                <tr>
                                    <td style="height:18px">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"  ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="id_btn_Add" runat="server" BorderWidth="0" Text="Add" Visible="false"
                                            CssClass="blue_bold_link" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gray_bg_newCol" align="center">
                                        <asp:DataList ID="id_datalist" runat="server" CellPadding="0" CellSpacing="0" align="center"
                                            OnItemDataBound="id_datalist_ItemDataBound" OnDataBinding="id_datalist_DataBinding">
                                            <ItemTemplate>
                                                <table border="0" align="center" cellpadding="0" cellspacing="0" width="840" class="gray_bg_new">
                                                    <tr>
                                                        <td height="25" style="padding-bottom: 10px; padding-top: 10px">
                                                            <table width="840" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table border="0" align="center" cellpadding="0" cellspacing="0" width="840">
                                                                            <tr>
                                                                                <td height="25">
                                                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CID")%>' />
                                                                                    <strong>
                                                                                        <%#Eval("Category_Title")%></strong>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="25" class="gray_txt">
                                                                                    Faculty : <span>
                                                                                        <%#Eval("Faculty")%></span>, Duration :
                                                                                    <%#Eval("Duration_From")%>
                                                                                    -
                                                                                    <%#Eval("Duration_To")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="28">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="10%" class="blacktxt">
                                                                                                Category: 
                                                                                            </td>
                                                                                            <td height="25">
                                                                                                <asp:DataList ID="dtCategory" runat="server" RepeatDirection="Horizontal" 
                                                                                                    RepeatColumns="10" onitemcommand="dtCategory_ItemCommand">
                                                                                                    <ItemTemplate>
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                              <%--  test--%>
                                                                                                                    <asp:LinkButton ID="id_hlink_Category" runat="server" Text='<%#Eval("CourseName")%>' CommandArgument='<%#Eval("CourseID")%>'
                                                                                                                        CssClass="tag" CommandName="searchtopic" ></asp:LinkButton>
                                                                                                                </td>
                                                                                                                <td width="5">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </ItemTemplate>
                                                                                                </asp:DataList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td bgcolor="#f1f1f1" style="padding: 5px;">
                                                                                    <%#Eval("Description")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="30" align="left">
                                                                                                <img src="../images/register_icon.png" width="22" height="23" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <%-- OLD  <asp:HyperLink ID="Register" runat="server" NavigateUrl='<%# "CourseRegistration.aspx?cid="+DataBinder.Eval(Container.DataItem,"NS_ID")%>'
                                                                                                    Text="Register for this Course" class="blue_bold_link"></asp:HyperLink>--%>
                                                                                              
                                                                                                <a class="blue_bold_link" href='<%=getEditProfilePage()%>'>Register for this Course</a>
                                                                                               
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td align="right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="seperator">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </SeparatorTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
