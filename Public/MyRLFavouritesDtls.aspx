<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master" AutoEventWireup="true" CodeFile="MyRLFavouritesDtls.aspx.cs" Inherits="Public_MyRLFavouritesDtls" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                                            My Favourites</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
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
                                                                <asp:DataList ID="id_datalist" runat="server" CellPadding="0" CellSpacing="0" align="center"
                                                                    OnItemCommand="id_datalist_ItemCommand" RepeatColumns="1" Width="100%">
                                                                    <ItemTemplate>
                                                                        <table width="874" border="0" cellspacing="0" cellpadding="5">
                                                                            <tr>
                                                                                <td width="429" height="25" class="gray_bg">
                                                                                    <strong>
                                                                                        <%--<%#Eval("CreatedOn")%>--%>
                                                                                        <%# DateFormat(System.Convert.ToDateTime(Eval("PublishedOn")))%><br />
                                                                                    </strong>
                                                                                    <%#Eval("Title")%>
                                                                                </td>
                                                                                <td width="425" align="right" class="gray_bg">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="57%" align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="8%" align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="35%" align="right">
                                                                                                <img src='<%#GetImg(Eval("Rating"))%>' alt="" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td align="right" width="30">
                                                                                                <img width="22" height="23" alt="" src="../images/favourite_delete.png" />
                                                                                            </td>
                                                                                            <td align="right">                                                                                         
                                                                                                <asp:LinkButton ID="linkFavourite" runat="server" CommandName="delete" CommandArgument='<%#Eval("RL_ID")%>'
                                                                                                    BorderWidth="0" CssClass="blue_txt" Text="Remove from favourite" />
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
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="25" colspan="2" align="right">
                                                                                    <a href="MyRLFavourites.aspx" class="footer_link" id="ctl00_ContentPlaceHolder1_hypLink">
                                                                                        » Back to List</a>
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

