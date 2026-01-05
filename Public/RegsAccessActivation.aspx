<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="RegsAccessActivation.aspx.cs" Inherits="Public_RegsAccessActivation" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <td align="center" style="padding-top: 15px;">
                    <table style="width: 60%;" id="tbActiveCode" runat="server">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblActivation" runat="server" Text="Activation Code:" 
                                    meta:resourcekey="lblActivationResource1"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtActivationCode" runat="server" 
                                    meta:resourcekey="txtActivationCodeResource1"></asp:TextBox>
                                <asp:Button ID="btnActivation" runat="server" Text="Submit" class="orange_button"
                                    OnClick="btnActivation_Click" meta:resourcekey="btnActivationResource1" />
                                <asp:RequiredFieldValidator ID="valActivationCode" runat="server" ControlToValidate="txtActivationCode"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Activation Code"
                                    CssClass="Mandatory" meta:resourcekey="valActivationCodeResource1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbActive" runat="server">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCongrats" runat="server" 
                                    Text="Congratulations! Your access to the SME Financial Toolkit is now activated." 
                                    meta:resourcekey="lblCongratsResource1"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblYouMay" runat="server"  meta:resourcekey="lblYouMayResource1"></asp:Label>
                             
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbError" runat="server">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblError" runat="server" Text="Error!"  Visible="false"
                                    meta:resourcekey="lblErrorResource1"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblInvalid" runat="server" Text="Invalid User."  Visible="false"
                                    meta:resourcekey="lblInvalidResource1"></asp:Label>
                                <asp:Label ID="lblDes1" runat="server" Visible="False" 
                                    meta:resourcekey="lblDes1Resource1"></asp:Label>
                                <asp:Label ID="lblDes2" runat="server" Visible="False" 
                                    meta:resourcekey="lblDes2Resource1"></asp:Label>
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
                    <%-- <asp:Button ID="btnContinue" runat="server" Text="Continue" class="orange_button"
                        PostBackUrl="~/Default.aspx" CausesValidation="false" />--%>
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
