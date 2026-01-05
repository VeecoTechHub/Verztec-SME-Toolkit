<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ResourceLibDtls.aspx.cs" Inherits="Public_ResourceLibDtls" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="middle_bg">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="33" valign="top" class="resource_title">
                                        <div>
                                            <asp:Label ID="lblHeading" runat="server" Text="Resource Library" 
                                                meta:resourcekey="lblHeadingResource1"></asp:Label>
                                            </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                           <asp:Label ID="lblMsg1" runat="server" Visible="False" 
                                            meta:resourcekey="lblMsg1Resource1"></asp:Label>
                                           <asp:Label ID="lblMsg2" runat="server" Visible="False" 
                                            meta:resourcekey="lblMsg2Resource1"></asp:Label>
                                           <asp:Label ID="lblMsg3" runat="server" Visible="False" 
                                            meta:resourcekey="lblMsg3Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="300" valign="top">
                                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <%-- <tr>
                                                <td width="203">
                                                    &nbsp;
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <asp:DataList ID="id_datalist" runat="server" CellPadding="0" align="center"
                                                                    OnItemCommand="id_datalist_ItemCommand" RepeatColumns="1" Width="100%" 
                                                                    OnItemDataBound="id_datalist_ItemDataBound" 
                                                                    meta:resourcekey="id_datalistResource1">
                                                                    <ItemTemplate>
                                                                        <table width="874" border="0" cellspacing="0" cellpadding="5">
                                                                            <tr>
                                                                                <td width="429" height="25" class="gray_bg">
                                                                                    <strong>
                                                                                        <%--<%#Eval("CreatedOn")%>--%>
                                                                                        <br />
                                                                                    </strong>
                                                                                    <%#Eval("Title")%>
                                                                                    &nbsp;<img src='<%# GetImg(Eval("CreateImage")) %>' alt="" />
                                                                                </td>
                                                                                <td width="425" align="right" class="gray_bg">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="67%" align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="8%" align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="25%" align="right">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td align="right" width="30">
                                                                                                <img width="20" height="20" runat="server" id="imgFavourite" />
                                                                                            &nbsp;</td>
                                                                                            <td align="right">
                                                                                                <asp:LinkButton ID="linkFavourite" runat="server" CommandName="favourite" CommandArgument='<%# Eval("RL_ID") %>'
                                                                                                    BorderWidth="0px" CssClass="blue_txt" Text="Add to favourite" 
                                                                                                    meta:resourcekey="linkFavouriteResource1" />
                                                                                                <asp:LinkButton ID="linkFavouriteDelete" runat="server" CommandName="favouriteDelete"
                                                                                                    CommandArgument='<%# Eval("RL_ID") %>' BorderWidth="0px" 
                                                                                                    CssClass="blue_txt" Text="Delete favourite" 
                                                                                                    meta:resourcekey="linkFavouriteDeleteResource1" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td align="right" width="30">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td align="right">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="15" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="25" colspan="2">
                                                                                    <%#Eval("RL_Details")%>
                                                                                    <asp:HiddenField ID="docSelection" runat="server" 
                                                                                        Value='<%# Eval("docSelection") %>' />
                                                                                    <asp:HiddenField ID="hyddownload" runat="server" 
                                                                                        Value='<%# Eval("RL_FileName") %>' />
                                                                                    <asp:HiddenField ID="hydTitle" runat="server" Value='<%# Eval("Title") %>' />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="2">
                                                                                    <asp:LinkButton ID="lnkbtnDownload" runat="server" CssClass="orange_button" CommandName="download"
                                                                                        CommandArgument='<%# Eval("RL_ID") %>' BorderWidth="0px" Text="Download" 
                                                                                        meta:resourcekey="lnkbtnDownloadResource1" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="15" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblRecCaptoin" runat="server" 
                                                                                        Text="Recommended articles or resources:" 
                                                                                        meta:resourcekey="lblRecCaptoinResource1"></asp:Label><br />
                                                                                    <asp:DataList ID="dlHypLink" runat="server" CellPadding="0" align="center"
                                                                                        RepeatColumns="1" Width="100%" meta:resourcekey="dlHypLinkResource1">
                                                                                        <ItemTemplate>
                                                                                            <table width="865" border="0" cellspacing="0" cellpadding="5">
                                                                                                <tr>
                                                                                                    <td width="429" height="25">
                                                                                                        <a href='<%=getEditProfilePage()%>' id="A_level" class="levelOne">
                                                                                                            <%#Eval("Title")%></a>
                                                                                                    </td>
                                                                                                    <td width="420" align="right">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="25" colspan="2" align="right">
                                                                                    <a href="ResourceLib.aspx" class="footer_link" id="ctl00_ContentPlaceHolder1_hypLink">
                                                                                       <asp:Label ID="lblBack" runat="server" Text=" » Back to List" 
                                                                                        meta:resourcekey="lblBackResource1"></asp:Label>
                                                                                       </a>
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
                                        </table>
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
