<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="RegistrationAccess.aspx.cs" Inherits="Public_RegistrationAccess"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" height="33" class="normal_head" valign="top">
                    <div>
                        <asp:Label ID="lblHeader" runat="server" Text="SME Financial Toolkit User Access Registration"
                            meta:resourcekey="lblHeaderResource1"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left">
                                <strong>
                                    <asp:Label ID="lblTerms" runat="server" Text="Terms of Use and Privacy Notice" meta:resourcekey="lblTermsResource1"></asp:Label>
                                </strong>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Localize ID="locPara1" runat="server" Text="
                               If you agree to the Terms of Use and the Privacy Notice of this website,
                                please click “I Agree” to proceed. If you DO NOT agree,  click  “I Disagree”
                                 and you will be redirected to our home page." meta:resourcekey="locPara1Resource1"></asp:Localize>
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
                <td style="text-align: justify">
                    <asp:TextBox ID="txtTerms" runat="server" TextMode="MultiLine" Height="300px" Width="800px"
                        meta:resourcekey="txtTermsResource1" 
                        Text="
                    
SME Financial Management Toolkit
Terms of Use and Privacy Notice
General
1. By entering this site, any pages thereof and / or by using the online services, you have acknowledged and agreed to all the terms and conditions stated herein in this document. These Terms of Use apply to all visits to this Website, both now and in the future. If you do not agree to any one of these conditions, please do not use this site.
Proprietary Rights
2. The Association of Banks of Singapore (ABS) is the copyright owner of everything on this site, including but not limited to the information, text, images, photographs, video, graphics as well as any software programs available on or through this Website (&quot;the Contents&quot;), which may not be used an any manner, or for any purpose, without ABS's express written permission, except as provided for herein.
3. The Contents of this Website shall not be reproduced, republished, uploaded, posted, transmitted, distributed, stored, adapted, displayed, altered or otherwise used in whole or in part in any manner, without the prior written consent of ABS.
4. You may use, copy and distribute the Contents found on this Website solely for personal, internal, non-commercial and/or informational purposes only. You may download one copy of any information provided on this Website onto a computer for your own personal and non-commercial use provided that you keep intact all accompanying copyright"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnAgree" runat="server" Text="I Agree " class="orange_button" OnClick="btnAgree_Click"
                        meta:resourcekey="btnAgreeResource1" />
                    <asp:Button ID="btnCancel" runat="server" Text="I Disagree" class="orange_button"
                        meta:resourcekey="btnCancelResource1" onclick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Visible="False" 
                        meta:resourcekey="lblMsgResource1"></asp:Label>
                    &nbsp;

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
