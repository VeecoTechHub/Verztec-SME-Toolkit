<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguageSelection.ascx.cs" Inherits="UserControls_LanguageSelection" %>
<table border="0" cellspacing="0" cellpadding="0" width="100%">
    <tr align="right">
      <td width="45%" >
        
        </td>
        <td width="15%" >
            <asp:LinkButton ID="lnkEnglish" runat="server" onclick="lnkEnglish_Click" CausesValidation="false" class="LanguageLinks">English</asp:LinkButton>
        </td>
      
        <td width="15%">
         <asp:LinkButton ID="lnkChinese" runat="server" onclick="lnkChinese_Click" CausesValidation="false" class="LanguageLinks">Chinese</asp:LinkButton>
        </td>
          <td width="25%" >
        
        </td>
      
    </tr>
    <tr align="right">
        <td height="10" colspan="3">
        </td>
    </tr>
</table>