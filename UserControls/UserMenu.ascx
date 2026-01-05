<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserMenu.ascx.cs" Inherits="UserControls_UserMenu" %>
<table border="0" cellspacing="0" cellpadding="0" width="460">
    <tr>
        <td width="30" align="center">
            <img src="<%= Page.ResolveUrl("~/images/icon_account.png") %>" alt="" width="14"
                height="14" align="absmiddle" />
        </td>
        <td>
            <a href="<%= Page.ResolveUrl("~/Public/MyAccount.aspx") %>" class="top_links">
                <asp:Label ID="lblMyAcccount" runat="server" Text="My Account" meta:resourcekey="lblMyAcccountResource1"></asp:Label>
            </a>
        </td>
        <td width="30" align="center">
            <img src="<%= Page.ResolveUrl("~/images/icon_dashboard.jpg") %>" width="14" height="13"
                alt="" />
        </td>
        <td>
            <a href="<%= Page.ResolveUrl("~/Public/Dashboard.aspx") %>" class="top_links">
                <asp:Label ID="lblDashboard" runat="server" Text="Dashboard" meta:resourcekey="lblDashboardResource1"></asp:Label>
            </a>
        </td>
        <td width="30" align="center">
            <img src="<%= Page.ResolveUrl("~/images/favourites_icon.png") %>" width="15" height="15"
                alt="" />
        </td>
        <td>
            <a href="<%= Page.ResolveUrl("~/Public/MyRLFavourites.aspx") %>" class="top_links">
                <asp:Label ID="lblMyFav" runat="server" Text="My Favourites" meta:resourcekey="lblMyFavResource1"></asp:Label>
            </a>
        </td>
        <td width="30" align="center">
            <img src="<%= Page.ResolveUrl("~/images/logout_icon.png") %>" width="14" height="14"
                alt="" />
        </td>
        <td>
            <asp:LinkButton ID="lBtnLogout" runat="server" CssClass="top_links" Text="Logout"
                OnClick="lBtnLogout_Click" CausesValidation="False" meta:resourcekey="lBtnLogoutResource1"></asp:LinkButton>
            <%--<a href="<%= Page.ResolveUrl("~/Default.aspx") %>" class="top_links" onclick="Logout">Logout</a>--%>
        </td>
    </tr>
    <tr>
        <td height="10" colspan="5">
        </td>
    </tr>
</table>
