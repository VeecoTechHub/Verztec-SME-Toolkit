<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MainMaster.master"
    CodeFile="FinancialMgtCapabilities.aspx.cs" Inherits="Public_FinancialMgtCapabilities" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="300" valign="top">
                    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <strong>
                                    <asp:Label ID="lblFin" runat="server" 
                                    Text="Financial Management Capabilities" meta:resourcekey="lblFinResource1"></asp:Label>
                                </strong><br />
                                <br />
                                    <asp:Label ID="lblTick" runat="server" 
                                    Text="Tick the one that best describe the current situation of your businesses." 
                                    meta:resourcekey="lblTickResource1"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:DataList ID="Dl_Questionaire" runat="server" runat="server" Width="100%" 
                                    OnItemDataBound="Dl_Questionaire_ItemDataBound" 
                                    meta:resourcekey="Dl_QuestionaireResource1">
                                    <AlternatingItemStyle CssClass="AlternateGridRow" />
                                    <ItemStyle CssClass="GridRow" />
                                    <HeaderTemplate>
                                        <table width="100%">
                                            <tr class="blue_Big_title">
                                                <td align="left">
                                                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lblQuestion" runat="server" Text="Question" 
                                                        meta:resourcekey="lblQuestionResource1"></asp:Label>
                                                     
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td width="5%" valign="top">
                                                    <asp:Label ID="lblqid" runat="server" Text='<%# Eval("qid") %>' Width="10px" 
                                                        Visible="False" meta:resourcekey="lblqidResource1"></asp:Label>
                                                    <asp:Label ID="lblqdescription" runat="server" Text='<%# Eval("qdescription") %>'
                                                        Width="10px" meta:resourcekey="lblqdescriptionResource1"></asp:Label>
                                                </td>
                                                <td width="95%" valign="top" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="50%" valign="top">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td colspan="2" valign="top">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="lblQ6" runat="server" Text="If you are making money now." 
                                                                                            Visible="False" meta:resourcekey="lblQ6Resource1"></asp:Label>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:RadioButtonList ID="rdbtn_OptA" runat="server" 
                                                                                meta:resourcekey="rdbtn_OptAResource1">
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td valign="top" align="left">
                                                                            <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="rdbtn_opta"
                                                                                Display="Dynamic" ErrorMessage="Must Select" 
                                                                                meta:resourcekey="requiredfieldvalidator1Resource1"><font color="white">.</font></asp:RequiredFieldValidator>
                                                                            <cc1:ValidatorCalloutExtender ID="VldrCalloutExtOpt" runat="server" 
                                                                                TargetControlID="RequiredFieldValidator1" Enabled="True">
                                                                            </cc1:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                          <tr>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:HiddenField ID="hdfldSelectedValues" runat="server" />
                                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" 
                                    CssClass="warnings" Text="Records Not Found" 
                                    meta:resourcekey="lblErrorResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="display:none">
                              <asp:Label ID="lblMsg" runat="server" 
                                    Text="Are you sure, you want to clear all the questions?" 
                                    meta:resourcekey="lblMsgResource1"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                         <tr>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnProcess" runat="server" Text="Process This" OnClick="btnProcess_Click"
                                    class="orange_button" meta:resourcekey="btnProcessResource1" />

                                        <asp:Button ID="btnClearAll" runat="server" Text="Clear All" OnClientClick="clearAll();"
                                    class="orange_button" meta:resourcekey="btnClearAllResource1" />
                                  <%--     <input type="button" value="Clear All" onclick="clearAll();" class="orange_button"
                                    id="btnClearAll" />--%>
                                <br />
                                <br />
                                <asp:Label ID="lblValues" runat="server" meta:resourcekey="lblValuesResource1"></asp:Label>
                            </td>
                        </tr>
                      
                    </table>
                </td>
            </tr>
        </table>
    </div>
     <script type="text/javascript" language="javascript">
         function clearAll() {
             var flag;
             var lblMsg = document.getElementById('<%=lblMsg.ClientID%>').innerHTML
             flag = confirm(lblMsg);

             if (flag == true) {
                 inputs = document.getElementsByTagName('input');
                 for (index = 0; index < inputs.length; ++index) {
                     if (inputs[index].type == 'radio' && inputs[index].checked == true)
                         inputs[index].checked = false;
                 }
             }


         }
    </script>
</asp:Content>
