<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="FinancialModeling_Feedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    SME Financial Modeling Tool</div>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0" id="table1" runat="server">
                    <tr>
                        <td style="height: 19px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="51" class="form_head">
                            <span>Feedback</span><br />
                            You may like to have a copy of your company’s financial health check and analysis
                            emailed to you. We appreciate if you can help us to improve this online tool by
                            complete the following questionnaire.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            On the scale of (poor) to (excellent), please rate the following:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="800" border="0" cellspacing="0" cellpadding="0" >
                                            <tr>
                                                <td width="348" height="30" align="left" valign="middle">
                                                    This toolkit is user-friendly
                                                </td>
                                                <td height="30" align="left" valign="middle">
                                                    <asp:RadioButtonList ID="rdolistUserFriendly" runat="server" RepeatDirection="Horizontal"
                                                        Width="420px">
                                                        <asp:ListItem Text="Excellent" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Above Average" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Average" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Poor" Value="5"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" valign="middle">
                                                    This online toolkit enhances my knowledge
                                                </td>
                                                <td height="30" align="left" valign="middle">
                                                    <asp:RadioButtonList ID="rdolistknowledge" runat="server" RepeatDirection="Horizontal"
                                                        Width="420px">
                                                        <asp:ListItem Text="Excellent" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Above Average" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Average" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Poor" Value="5"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" valign="middle">
                                                    The report is useful/applicable to my organisation
                                                </td>
                                                <td height="30" align="left" valign="middle">
                                                    <asp:RadioButtonList ID="rdolistReport" runat="server" RepeatDirection="Horizontal"
                                                        Width="420px">
                                                        <asp:ListItem Text="Excellent" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Above Average" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Average" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Poor" Value="5"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" valign="middle">
                                                    Would you recommend this site to others?
                                                </td>
                                                <td height="30" colspan="5" valign="middle">
                                                    <table width="452" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="100" height="30">
                                                                <asp:RadioButtonList ID="rdolistRecommend" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td width="312" align="left" valign="middle">
                                                                &nbsp; Enter their Email Id&nbsp;&nbsp;
                                                                <asp:TextBox ID="txtEmailId" runat="server" Width="175px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="id_regval_Email" runat="server" ControlToValidate="txtEmailId"
                                                                    ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    Please give us your comments to improve this toolkit. (Max of 500 characters)
                                                </td>
                                                <td height="30" colspan="5" valign="middle">
                                                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" CssClass="Multitextbox"
                                                        ></asp:TextBox>
                                                    <%-- <textarea rows="30" style="width: 417px; height: 75px;"></textarea>--%>
                                                </td>
                                            </tr>
                                         
                                        </table>
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
                </table>
            </td>
        </tr>
        <tr id="HideTr" runat="server">
            <td height="150px" align="center">
          
              Thank you for downloading report......

                        
            </td>
            
        </tr>
        <tr>
            <td height="45" valign="bottom" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save & Download Report" CssClass="orange_button"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr id="trLast" runat="server">
            <td style="height:110px">
                &nbsp; 
<asp:LinkButton ID="lnkfake" runat="server" onclick="lnkfake_Click"></asp:LinkButton>
<%--<asp:Timer ID="Timer1" runat="server" Interval="4000"></asp:Timer>--%>
            </td>
        </tr>
    </table>
   
 
    <script type="text/javascript" language="javascript">
        function openReport() {
            window.open('Reports_All.aspx');
        }
    </script>
</asp:Content>
