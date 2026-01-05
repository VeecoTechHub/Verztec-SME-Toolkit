<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="FMFeedback.aspx.cs" Inherits="Public_FMFeedback" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<script runat="server">

  
</script>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            font-size: 1px;
        }
    </style>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    <asp:Label ID="lblHeading" runat="server" Text="SME Financial Modeling Tool" 
                        meta:resourcekey="lblHeadingResource1"></asp:Label>
                    </div>
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
                            <span>
                                <asp:Label ID="lblFeedback" runat="server" Text="Feedback" 
                                meta:resourcekey="lblFeedbackResource1"></asp:Label>
                            </span><br />
                             <asp:Label ID="lblAppreciate" runat="server"
                                Text="We appreciate if you can help us to improve this online tool by completing the following questionnaire." 
                                meta:resourcekey="lblAppreciateResource1" ForeColor="Black" 
                                Font-Bold="True" Font-Size="14px" Font-Names="Arial,Helvetica,sans-serif"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                         <asp:Label ID="lblScale" runat="server" 
                                Text="On the scale of (strongly Agree) to (strongly Disagree), please rate the following:" 
                                meta:resourcekey="lblScaleResource1"></asp:Label>
                            <br />
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
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 432px;">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <asp:Label ID="lbl1Strongly" runat="server" Text="Strongly" 
                                                                         meta:resourcekey="lbl1StronglyResource1"></asp:Label>
                                                                   
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lbl2Strongly" runat="server" Text="Strongly" 
                                                                        meta:resourcekey="lbl2StronglyResource1"></asp:Label>
                                                                   
                                                                                                                                        
                                                                </td>
                                                                <td style="width: 50px;">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 432px;">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    &nbsp;&nbsp;5
                                                                </td>
                                                                <td style="width: 87px">
                                                                    &nbsp; 4
                                                                </td>
                                                                <td style="width: 87px">
                                                                    &nbsp; 3
                                                                </td>
                                                                <td style="width: 87px">
                                                                    &nbsp; 2
                                                                </td>
                                                                <td style="width: 87px">
                                                                    &nbsp; 1
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
                                        <asp:GridView ID="id_GV_FeedBack" runat="server" ShowHeader="False" GridLines="None"
                                            BorderStyle="None" AutoGenerateColumns="False" CellPadding="0"
                                            Width="800px" meta:resourcekey="id_GV_FeedBackResource1">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="348" ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left"
                                                    ItemStyle-VerticalAlign="Middle" meta:resourcekey="TemplateFieldResource1">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfQid" runat="server" Value='<%# Eval("Q_ID") %>' />
                                                        <asp:Label ID="id_lbl_Question" runat="server" Text='<%# Eval("Question") %>' 
                                                            meta:resourcekey="id_lbl_QuestionResource1"></asp:Label>
                                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Width="348px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="452" meta:resourcekey="TemplateFieldResource2">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList runat="server" ID="radio" RepeatDirection="Horizontal" Width="432px"
                                                            ValidationGroup="g1" meta:resourcekey="radioResource1">
                                                            <asp:ListItem Value="5" meta:resourcekey="ListItemResource1" Text="."></asp:ListItem>
                                                            <asp:ListItem Value="4" meta:resourcekey="ListItemResource2" Text="."></asp:ListItem>
                                                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource3" Text="."></asp:ListItem>
                                                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource4" Text="."></asp:ListItem>
                                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource5" Text="."></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator runat="server" ID="radRfv" ControlToValidate="radio"
                                                            Display="Dynamic" meta:resourcekey="radRfvResource1" Text="*"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Width="452px"></ItemStyle>
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
                                                        <tr style="visibility: hidden;">
                                                            <td width="140" height="30">
                                                                <asp:RadioButtonList runat="server" ID="rbtlist" RepeatDirection="Horizontal" 
                                                                    ValidationGroup="g1" meta:resourcekey="rbtlistResource1">
                                                                    <asp:ListItem Value="N" Selected="True" meta:resourcekey="ListItemResource6">No</asp:ListItem>
                                                                    <asp:ListItem Value="Y" meta:resourcekey="ListItemResource7">Yes.</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:RequiredFieldValidator runat="server" ID="radRfv1" ControlToValidate="rbtlist"
                                                                    ErrorMessage="Select One option" Display="Dynamic" 
                                                                    Style="white-space: nowrap;" meta:resourcekey="radRfv1Resource1" Text="*"></asp:RequiredFieldValidator>
                                                                <%--<asp:RadioButton ID="rbtNo" runat="server" Text="No" GroupName="g2" />--%>
                                                            </td>
                                                            <%--<td width="57">
                                                                <asp:RadioButton ID="rbtYes" runat="server" Text="Yes." GroupName="g2" />
                                                            </td>--%>
                                                            <td width="312" align="left">
                                                             <asp:Label ID="lblEnter" runat="server" Text="Enter their Email Id" 
                                                                    meta:resourcekey="lblEnterResource1"></asp:Label>
                                                                
                                                                <asp:TextBox ID="txtEmailids" runat="server" Width="152px" MaxLength="500" 
                                                                    ValidationGroup="g1" meta:resourcekey="txtEmailidsResource1"></asp:TextBox>
                                                                <asp:CustomValidator ID="MyTxtBoxValidator" runat="server" ControlToValidate="txtEmailids"
                                                                    ValidateEmptyText="True" ErrorMessage="Please enter some values into Textbox"
                                                                    ClientValidationFunction="validateMyBtn" Display="Dynamic" 
                                                                    meta:resourcekey="MyTxtBoxValidatorResource1" Text="*
                                                                "></asp:CustomValidator>
                                                                <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmailids"
                                                                    ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                                                                    Display="Dynamic" ErrorMessage="You must enter a valid e-mail address" ToolTip="You must enter a valid e-mail address"
                                                                    CssClass="Mandatory" meta:resourcekey="valEmailValidationResource1" 
                                                                    Text="*"></asp:RegularExpressionValidator>
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
                </table>
                <table>
                    <tr>
                        <td height="35" valign="middle">
                            <table>
                                <tr>
                                    <td width="400px">
                                        &nbsp;
                                    </td>
                                    <td height="45" colspan="5" valign="bottom">
                                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save & Download Report" CssClass="orange_button"
                                            OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                           
                                    </td>
                                    <td height="45" colspan="5" valign="bottom">&nbsp;<asp:Button ID="btnSkip" 
                                            CausesValidation="False" runat="server" Text="Skip" 
                                            CssClass="orange_button" onclick="btnSkip_Click" meta:resourcekey="btnSkipResource1"
                                            /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="HideTr" runat="server">
                        <td height="150px" align="center">
                            <asp:Label ID="lblThankYou" runat="server" 
                                Text="Thank you for downloading report......" 
                                meta:resourcekey="lblThankYouResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td valign="middle" colspan="6">
                            <asp:GridView ID="gv_excel" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                Width="800px" meta:resourcekey="gv_excelResource1">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                        HeaderText="User Name" meta:resourcekey="TemplateFieldResource3">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>' 
                                                meta:resourcekey="lblUserNameResource1"></asp:Label>
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="30px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="348" ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Middle" HeaderText="Questions" 
                                        meta:resourcekey="TemplateFieldResource4">
                                        <ItemTemplate>
                                            <asp:Label ID="id_lbl_Question" runat="server" Text='<%# Eval("Question") %>' 
                                                meta:resourcekey="id_lbl_QuestionResource2"></asp:Label>
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Width="348px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                        HeaderText="Answer" meta:resourcekey="TemplateFieldResource5">
                                        <ItemTemplate>
                                            <asp:Label ID="id_lbl_Anser" runat="server" Text='<%# Eval("Answer") %>' 
                                                meta:resourcekey="id_lbl_AnserResource1"></asp:Label>
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="30px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Height="30" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                        HeaderText="Comments" meta:resourcekey="TemplateFieldResource6">
                                        <ItemTemplate>
                                            <asp:Label ID="id_lbl_Comments" runat="server" Text='<%# Eval("Comments") %>' 
                                                meta:resourcekey="id_lbl_CommentsResource1"></asp:Label>
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="30px"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         <asp:Label ID="lblFake" runat="server" Text="Save & Proceed" Visible="False" 
                                meta:resourcekey="lblFakeResource1"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
