<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ResourceLibrary.aspx.cs" Inherits="Public_ResourceLibrary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="resource_title">
                <div>
                    Resource Library</div>
            </td>
        </tr>
        <tr>
            <td height="300" valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
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
                                                <td width="50" height="30">
                                                    Topic
                                                </td>
                                                <td width="200">
                                                    <asp:DropDownList ID="id_ddl_Topic" runat="server" Style="width: 185px;" 
                                                        OnSelectedIndexChanged="id_ddl_Topic_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="50" align="right">
                                                    &nbsp;
                                                </td>
                                                <td width="40">
                                                    Title
                                                </td>
                                                <td width="200">
                                                    <asp:TextBox ID="id_txt_Title" runat="server" Style="width: 180px;"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="id_txt_Title"
                                                        ServicePath="~/WebService.asmx" MinimumPrefixLength="1" CompletionInterval="1000"
                                                        CompletionSetCount="12" ServiceMethod="GetClients">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                                <td width="330">
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
                                            CssClass="blue_bold_link" OnClick="id_btn_Add_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gray_bg_newCol" align="center">
                                        <asp:DataList ID="id_datalist" runat="server" CellPadding="0" CellSpacing="0" align="center"
                                            OnItemCommand="id_datalist_ItemCommand" OnItemDataBound="id_datalist_ItemDataBound">
                                            <ItemTemplate>
                                                <table border="0" align="center" cellpadding="0" cellspacing="0" class="gray_bg_new">
                                                    <tr>
                                                        <td height="25">
                                                            <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px;">
                                                                <tr>
                                                                    <td style="width: 80%;">
                                                                        <table border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td height="25">
                                                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("RL_ID")%>' />
                                                                                    <strong>
                                                                                        <%#Eval("ArticleTitle")%></strong>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="25" class="gray_txt">
                                                                                    Author : <span>
                                                                                        <%#Eval("Author_Name")%></span>, Published on
                                                                                    <%#Eval("CreatedOn")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="28">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="10%" class="blacktxt">
                                                                                                Topics:
                                                                                            </td>
                                                                                            <td height="25">
                                                                                                <asp:DataList ID="dtTopics" runat="server" RepeatDirection="Horizontal" RepeatColumns="10">
                                                                                                    <ItemTemplate>
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:LinkButton ID="id_hlink_Tname1" runat="server" Text='<%#Eval("TopicName")%>'
                                                                                                                        CssClass="tag"></asp:LinkButton>
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
                                                                                <td bgcolor="#f1f1f1" style="padding: 5px;" width="840">
                                                                                    <%#Eval("ArticleDescription")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td align="right">
                                                                        <table border="0" cellspacing="4" cellpadding="0">
                                                                            <tr>
                                                                                <td colspan="3" align="left">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td width="110" align="center" valign="top">
                                                                                                <img src='<%#GetImg(Eval("Rating"))%>' alt="" />
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
                                                                            <tr>
                                                                                <td width="30px" align="right">
                                                                                    <img src="../images/download_rs.png" width="22px" height="23px" alt="" />
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Button ID="Button1" runat="server" BorderWidth="0" CssClass="blue_bold_link"
                                                                                        CommandArgument='<%#Eval("RL_ID")%>' CommandName="Download" Text="Download" />
                                                                                </td>
                                                                                <td width="20">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30" align="right">
                                                                                    <img src="../images/favourites_rs.png" width="22" height="23" alt="" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="Button2" runat="server" CommandName="favourite" CommandArgument='<%#Eval("RL_ID")%>'
                                                                                        BorderWidth="0" CssClass="blue_bold_link" Text="Add to favourite" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
