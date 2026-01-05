<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginLogDetails.ascx.cs"
    Inherits="UserControls_LoginLogDetails" %>
<table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td height="68" class="graybox">
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" width="70%">
                        <strong>
                            <asp:Label ID="lblWelcome" runat="server" Text="Welcome" meta:resourcekey="lblWelcomeResource1"></asp:Label>
                            <span class="blue_big1">
                               </span>
                            <asp:Label ID="lblCompanyName" runat="server" meta:resourcekey="lblCompanyNameResource1"></asp:Label>
                            <asp:Label ID="lblof" runat="server" Text="of" meta:resourcekey="lblofResource1"></asp:Label>
                             <asp:Label ID="lblCurrentUser" runat="server" meta:resourcekey="lblCurrentUserResource1"></asp:Label>
                        </strong>
                        <br />
                        <%--Your last login was on 08/12/11 at 11:30 AM--%>
                        <asp:Label ID="lblDate" runat="server" meta:resourcekey="lblDateResource1"></asp:Label>
                        <asp:Label ID="lblTime" runat="server" meta:resourcekey="lblTimeResource1"></asp:Label>
                    </td>
                    <td  width="25%">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:LinkButton ID="lnkEnglish" runat="server" OnClick="lnkEnglish_Click" CausesValidation="false"
                                        class="LanguageLinks">English</asp:LinkButton>
                            
                                </td>
                                <td  align="left">
                                    <asp:LinkButton ID="lnkChinese" runat="server" OnClick="lnkChinese_Click" CausesValidation="false"
                                        class="LanguageLinks">Chinese</asp:LinkButton>
                                </td>
                             
                            </tr>
                       
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblDes1" runat="server" Visible="False" meta:resourcekey="lblDes1Resource1"></asp:Label>
                        <asp:Label ID="lblDes2" runat="server" Visible="False" meta:resourcekey="lblDes2Resource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
