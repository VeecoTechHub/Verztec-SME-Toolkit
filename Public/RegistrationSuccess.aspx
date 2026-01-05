<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="RegistrationSuccess.aspx.cs" Inherits="Public_RegistrationSuccess" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" height="33" valign="top" class="normal_head" valign="top">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" 
                            Text="SME Financial Toolkit User Access Registration" 
                            meta:resourcekey="lblHeadingResource1"></asp:Label>
                        
                    </div>
                </td>
            </tr>
        </table>
        <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left">
                              <asp:Label ID="lblCongratulations" runat="server" Text="Congratulations" 
                                    meta:resourcekey="lblCongratulationsResource1"></asp:Label>
                                 <asp:Label ID="lblUserName" runat="server" 
                                    meta:resourcekey="lblUserNameResource1"></asp:Label>
                                  <asp:Label ID="lblCompleted" runat="server" 
                                    Text="Your online registration is completed." 
                                    meta:resourcekey="lblCompletedResource1"></asp:Label>
                                   <br />
                                <br />
                                <%-- <asp:Label ID="lblYourLogin" runat="server" Text="Your login ID is" 
                                    meta:resourcekey="lblYourLoginResource1"></asp:Label>
                                 &nbsp;<asp:Label ID="lblEmailID" runat="server" 
                                    meta:resourcekey="lblEmailIDResource1"></asp:Label>
                                 &nbsp;<asp:Label ID="lblActivation" runat="server" 
                                    Text="and activation email has been delivered to this email. Please check for this email in few minutes and click the activation provided." 
                                    meta:resourcekey="lblActivationResource1"></asp:Label>--%>
                                  
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
                <td align="left">
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" class="orange_button"
                        PostBackUrl="~/Default.aspx" meta:resourcekey="btnContinueResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
