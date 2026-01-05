<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Public_ResetPassword" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>

        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" height="33" valign="top" class="normal_head" valign="top">
                    <div>
                        <asp:Label ID="lblResetPassword" runat="server" Text="Reset Password" 
                            meta:resourcekey="lblResetPasswordResource1"></asp:Label>
                          
                    </div>
                </td>
            </tr>
        </table>

        <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" style="padding-top:15px;">
                    <table style="width: 70%;" id="tbActiveCode" runat="server">
                        <tr>
                            <td align="left">
                             <asp:Label ID="lblActivationCode" runat="server" Text="Activation Code" 
                                    meta:resourcekey="lblActivationCodeResource1"></asp:Label>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtActivationCode" runat="server" MaxLength="36" Width="300px" 
                                    ValidationGroup="g1" meta:resourcekey="txtActivationCodeResource1"></asp:TextBox>
                                <asp:Button ID="btnActivation" runat="server" Text="Submit" 
                                    class="orange_button" onclick="btnActivation_Click" ValidationGroup="g1" 
                                    meta:resourcekey="btnActivationResource1" />
                    <asp:RequiredFieldValidator ID="valActivationCode" runat="server" ControlToValidate="txtActivationCode"
                        Display="Dynamic" ErrorMessage="*" ToolTip="Activation Code" 
                                    CssClass="Mandatory" ValidationGroup="g1" 
                                    meta:resourcekey="valActivationCodeResource1"/>
                            </td>
                        </tr>                         
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-top:10px;">
                    <table width="70%" border="0" cellspacing="0" cellpadding="0" id="tbActive" runat="server" visible="false" align="center">
                       
                        <tr>
                <td align="left" height="30" width="150" >
                 <asp:Label ID="lblPassword" runat="server" Text="Password" 
                        meta:resourcekey="lblPasswordResource1"></asp:Label>
                     
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPassword" runat="server" 
                        Style="width: 150px; height: 19px;" TextMode="Password"
                        MaxLength="100" onpaste="return false" ValidationGroup="g2" 
                        meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" 
                        CssClass="Mandatory" ValidationGroup="g2" 
                        meta:resourcekey="valPasswordResource1" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ErrorMessage="Invalid"
                     ValidationExpression="[d]?^[^A-Za-z0-9]?^.{8,}$" Display="Dynamic" 
                        ControlToValidate="txtPassword" ValidationGroup="g2" 
                        meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>                    
                </td>                
               </tr>
               <tr>
                   <td align="left" height="30">
                    <asp:Label ID="lblRetypePassword" runat="server" Text="Retype Password" 
                           meta:resourcekey="lblRetypePasswordResource1"></asp:Label>
                   
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRePassword" runat="server" Style="width: 150px; height: 19px;"
                        TextMode="Password" MaxLength="100" onpaste="return false" 
                        ValidationGroup="g2" meta:resourcekey="txtRePasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valRePassword" runat="server" ControlToValidate="txtRePassword"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" 
                        CssClass="Mandatory" ValidationGroup="g2" 
                        meta:resourcekey="valRePasswordResource1"/>
                    <asp:CompareValidator ID="ValConPwdCompare" runat="server" ErrorMessage="*" ControlToValidate="txtRePassword"
                        ControlToCompare="txtPassword" Display="Dynamic" 
                        ToolTip="Password and Confirm Password must match" CssClass="Mandatory" 
                        ValidationGroup="g2" meta:resourcekey="ValConPwdCompareResource1"></asp:CompareValidator>
                </td>            
               
               </tr>
               <tr><td colspan="2"><br /></td></tr>
               <tr>
               
               <td align="left" colspan="2">
                        <asp:Label ID="lblPwdMsg" runat="server" 
                            Text="Note: Minimum 8 characters; only numbers and alphabets are accepted." 
                            CssClass="lblMessage" Font-Size="Small" meta:resourcekey="lblPwdMsgResource1"></asp:Label>                    
                </td>
               </tr>
               <tr><td colspan="2"><br /></td></tr>
            <tr>
            <td>
            </td>            
            
            <td align="left">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="orange_button" 
                        onclick="btnReset_Click" ValidationGroup="g2" 
                        meta:resourcekey="btnResetResource1"/>
                </td>
               
            </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-top:10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbError" runat="server" visible="false">
                        <tr>
                            <td align="Center">
                             <asp:Label ID="lblInvalidActivationKey" runat="server" 
                                    Text="Invalid Activation Key" 
                                    meta:resourcekey="lblInvalidActivationKeyResource1"></asp:Label>
                                !<br />
                                <br />
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td style="padding-top:10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbExpire" runat="server" visible="false">
                        <tr>
                            <td align="Center">
                            <asp:Label ID="lblActivationKeyExpired" runat="server" 
                                    Text="Activation Key Expired" 
                                    meta:resourcekey="lblActivationKeyExpiredResource1"></asp:Label>
                                !<br />
                                <br />
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           <%-- <tr>
                <td>
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td>
                    &nbsp;
                     <asp:Label ID="lblMsg" runat="server" 
                        Text="Password reset completed successfully" Visible="False" 
                        meta:resourcekey="lblMsgResource1"></asp:Label>
                </td>
            </tr>
        </table>
        












</div>
</asp:Content>

