<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master" AutoEventWireup="true" CodeFile="GeneralFeedback.aspx.cs" Inherits="Public_GeneralFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
        function validateMyBtn(oSrc, args) {
            var rbtnValue = null;
            var rbtnList = document.getElementsByName('<%= rbtlist.ClientID %>');
            var radio = rbtnList[0].getElementsByTagName("input");
            if (radio[1].checked == true) {
                args.IsValid = !(args.Value == "")
            }
            else {
                args.IsValid = true;
            }

        }
        
    </script>

    <style type="text/css">
        #ctl00_ContentPlaceHolder1_id_GV_FeedBack label
        {
            color: #FFF;
              font-size:1px;
        }
           /* Mozilla based browsers */
 #ctl00_ContentPlaceHolder1_id_GV_FeedBack_ctl02_radio   ::-moz-selection {
       background-color: #FFF;
       color: #FFF;
}

/* Works in Safari */
 #ctl00_ContentPlaceHolder1_id_GV_FeedBack_ctl02_radio   ::selection {
       background-color: #FFF;
       color: #FFF;
}
   
    </style>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    SME Financial Modeling Tool</div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0" id="HideTable"
                    runat="server">
                    <tr>
                        <td>
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
                            On the scale of (poor) to (excellent), please rate the following:<br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        <table border="0" width="800px" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left" style="width: 348px">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="width: 452px">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width:432px;">
                                                    <tbody>
                                                        
                                                        <tr>
                                                            <td><asp:Label ID="Label1" runat="server">Strongly<br /> Agree</asp:Label></td>
                                                            
                                                            <td align="right">
                                                               Strongly<br /> Disagree
                                                            </td>
                                                            <td style="width:50px;">&nbsp;</td>
                                                        </tr>
                                                        </tbody>
                                                    </table>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:432px;">
                                                    <tbody>
                                                        
                                                        <tr>
                                                            <td><asp:Label ID="lbl5" runat="server">5</asp:Label></td>
                                                            <td>
                                                               4
                                                            </td>
                                                            <td>
                                                                3
                                                            </td>
                                                            <td>
                                                                2
                                                            </td>
                                                            <td>
                                                                1
                                                            </td>
                                                        </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="id_GV_FeedBack" runat="server" ShowHeader="false" GridLines="None" BorderStyle="None"
                                            ShowFooter="false" AutoGenerateColumns="false" CellPadding="0" Width="800">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="348" ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left"
                                                    ItemStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfQid" runat="server" Value='<%#Eval("Q_ID")%>' />
                                                        <asp:Label ID="id_lbl_Question" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="452">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList runat="server" ID="radio" RepeatDirection="Horizontal" Width="432px"
                                                            ValidationGroup="g1">
                                                            <asp:ListItem Value="5">.</asp:ListItem>
                                                            <asp:ListItem Value="4">.</asp:ListItem>
                                                            <asp:ListItem Value="3">.</asp:ListItem>
                                                            <asp:ListItem Value="2">.</asp:ListItem>
                                                            <asp:ListItem Value="1">.</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator runat="server" ID="radRfv" ControlToValidate="radio"
                                                            Display="Dynamic">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="800" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                               
                                                <td height="30" colspan="5" valign="middle">
                                                    <table width="452" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="visibility:hidden;">
                                                            <td width="140" height="30">
                                                                <asp:RadioButtonList runat="server" ID="rbtlist" RepeatDirection="Horizontal" ValidationGroup="g1">
                                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                    <asp:ListItem Value="Y">Yes.</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:RequiredFieldValidator runat="server" ID="radRfv1" ControlToValidate="rbtlist"
                                                                    ErrorMessage="Select One option" Display="Dynamic" Style="white-space: nowrap;">*</asp:RequiredFieldValidator>
                                                                <%--<asp:RadioButton ID="rbtNo" runat="server" Text="No" GroupName="g2" />--%>
                                                            </td>
                                                            <%--<td width="57">
                                                                <asp:RadioButton ID="rbtYes" runat="server" Text="Yes." GroupName="g2" />
                                                            </td>--%>
                                                            <td width="312" align="left">
                                                                Enter their Email Id
                                                                <asp:TextBox ID="txtEmailids" runat="server" Width="152px" MaxLength="500" ValidationGroup="g1"></asp:TextBox>
                                                                <asp:CustomValidator ID="MyTxtBoxValidator" runat="server" ControlToValidate="txtEmailids"
                                                                    ValidateEmptyText="true" ErrorMessage="Please enter some values into Textbox"
                                                                    ClientValidationFunction="validateMyBtn" Display="Dynamic">*
                                                                </asp:CustomValidator>
                                                                <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmailids"
                                                                    ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                                                                    Display="Dynamic" ErrorMessage="You must enter a valid e-mail address" ToolTip="You must enter a valid e-mail address"
                                                                    CssClass="Mandatory">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                       
                                                    </table>
                                                </td>
                                            </tr>
                                            </tr>
                                            <tr>
                                                <td colspan="13"><hr /></td>
                                            </tr>
                                            <tr>
                                                <td valign="top" width="348">
                                                   Tell us how we can improve on this SME toolkit. <br />(Max of 500 characters)
                                                </td>
                                                <td height="30" colspan="5" valign="middle">
                                                    &nbsp;<asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="417px"
                                                        CssClass="Multitextbox" Height="75px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="13"><hr /></td>
                                            </tr>
                                              <tr>
                                                <td valign="top" width="348">
                                                  Please inform us if there is a bug  <br />(Max of 500 characters)
                                                </td>
                                                <td height="30" colspan="5" valign="middle">
                                                    &nbsp;<asp:TextBox ID="txtInformBugs" runat="server" TextMode="MultiLine" Width="417px"
                                                        CssClass="Multitextbox" Height="75px"></asp:TextBox>
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
        <tr>
            <td height="35" valign="middle">
                <table>
                    <tr>
                        <td width="400px">
                            &nbsp;
                        </td>
                        <td height="45" colspan="5" valign="bottom">
                            &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="orange_button"
                                OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
        <tr style="display: none;">
            <td valign="middle" colspan="6">
                <asp:GridView ID="gv_excel" runat="server" AutoGenerateColumns="false" CellPadding="0"
                    Width="800">
                    <Columns>
                        <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                            HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="348" ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left"
                            ItemStyle-VerticalAlign="Middle" HeaderText="Questions">
                            <ItemTemplate>
                                <asp:Label ID="id_lbl_Question" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                            HeaderText="Answer">
                            <ItemTemplate>
                                <asp:Label ID="id_lbl_Anser" runat="server" Text='<%#Eval("Answer")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                            HeaderText="Comments">
                            <ItemTemplate>
                                <asp:Label ID="id_lbl_Comments" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

