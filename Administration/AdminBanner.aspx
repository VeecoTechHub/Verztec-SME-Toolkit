<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true"
    CodeFile="AdminBanner.aspx.cs" Inherits="Administration_AdminBanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
<!--
        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=280,width=520,top=200,left=250');
            if (window.focus)
            { newwindow.focus() }

            return false;
        }
    


// -->
    </script>
    <table id="Table3" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" />
            </td>
            <td width="600" align="left">
                <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                    &gt;&gt;
                    <%=(ViewState["Links"].ToString().Split('|')[4])%>
                </strong>
            </td>
            <td width="199" align="left" valign="middle">
                <p style="padding-top: 5px">
                    <strong class="blue">User:
                        <%=Session["GROUP_ID"].ToString()%>
                        /
                        <%=Session["USER_NM"].ToString()%>
                    </strong>
                </p>
            </td>
        </tr>
    </table>
    <table>
    <tr><td>
    &nbsp;
    </td></tr>
    <tr>
    <td>
      <asp:RadioButtonList ID="rblCulture" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
            onselectedindexchanged="rblCulture_SelectedIndexChanged">
      <asp:ListItem Selected="True" Value="en-us" Text="English"></asp:ListItem>
      <asp:ListItem Value="zh-SG" Text="Chinese"></asp:ListItem>
      </asp:RadioButtonList>
    </td>   
    </tr>
    <tr><td>
    &nbsp;
    </td></tr>
    </table>
    <table style="border-bottom:1px solid #808080; border-left:1px solid #808080; border-right:1px solid #808080; border-top:1px solid #808080; width:100% ">
        <tr class="tableHeading">
            <td colspan="2" style="width: 100px; border-right:1px solid #808080;  border-bottom:1px solid #808080">
                Banner Name
            </td>
            <td style="width: 180px; text-align: center; border-right:1px solid #808080;  border-bottom:1px solid #808080">
                Image
            </td>
            <td style="width: 80px; border-right:1px solid #808080;  border-bottom:1px solid #808080">
                View Image
            </td>
            <td style="width: 150px; text-align: center; border-right:1px solid #808080;  border-bottom:1px solid #808080">
                URL
            </td>
            <td  style="width: 50px;  border-bottom:1px solid #808080">
            Action
            </td>
        </tr>       
                    <tr >
                        <td  style="width: 80px;  border-bottom:1px solid #808080;" >
                             Banner 1&nbsp;(580 X 201)
                        </td>
                    <td  style="width: 5px; border-right:1px solid #808080;  border-bottom:1px solid #808080;">
                    :
                    </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuTopBanner1" runat="server" />
                           <%-- <asp:RequiredFieldValidator ID="rfvTopBanner1" runat="server" Display="Dynamic" ErrorMessage="*"
                                ToolTip="Please Select TopBanner" ControlToValidate="fuTopBanner1"></asp:RequiredFieldValidator>
--%>                            <asp:RegularExpressionValidator ID="revTopBanner1" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuTopBanner1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 100px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--  <asp:LinkButton ID="lnkTopBanner" runat="server" Visible="false"  
                                     >ViewImage</asp:LinkButton>--%>
                                <asp:HyperLink ID="hlTopBanner" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                            <%--    <a id="hlTopBanner" target="_blank">View Image</a>--%>
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtTopBannerUrl" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revTopBannerUrl" runat="server" ErrorMessage="*"
                                ControlToValidate="txtTopBannerUrl" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width:80px">
                        
                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080;">
                             Banner 2 &nbsp;(580 X 201)
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080; border-bottom:1px solid #808080;">
                    :
                    </td>
                        <td colspan="1" style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuBanner2" runat="server" />
                         <%--   <asp:RequiredFieldValidator ID="rfvBanner2" runat="server" ErrorMessage="*" ControlToValidate="fuBanner2"
                                ToolTip="Please Select Banner2" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="revBanner2" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuBanner2" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:HyperLink ID="hlBanner2" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtBannerUrl2" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revBannerUrl2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtBannerUrl2" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px;  border-bottom:1px solid #808080;">

                        
                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080; ">
                             Banner 3 &nbsp;(580 X 201)
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080; ">
                    :
                    </td>
                        <td colspan="1" style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuBanner3" runat="server" />
                            <asp:RegularExpressionValidator ID="revfuBanner3" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuBanner3" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--  <asp:LinkButton ID="lnkBanner3" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlBanner3" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                        &nbsp;</td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtBannerUrl3" runat="server" Width="180px" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revBannerUrl3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtBannerUrl3" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">

                            <asp:ImageButton ID="ibtnBanner3" runat="server" ImageUrl="~/images/delete.jpg"  OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false"  
                                   onclick="ibtnBanner3_Click" />
                        
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px;  border-bottom:1px solid #808080; ">
                             Banner 4 &nbsp;(580 X 201)
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td width="150px" colspan="1" style="border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuBanner4" runat="server" />
                            <asp:RegularExpressionValidator ID="revfuBanner4" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuBanner4" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkBanner4" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlBanner4" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtBannerUrl4" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revBannerUrl4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtBannerUrl4" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">
                            <asp:ImageButton ID="ibtnBanner4" runat="server" ImageUrl="~/images/delete.jpg"  OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false"  
                                   Height="21px" onclick="ibtnBanner4_Click" 
                                   />

                        
                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080;">
                             Banner 5 &nbsp;(580 X 201)
                        </td>
                          <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td colspan="1" style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuBanner5" runat="server" />
                            <asp:RegularExpressionValidator ID="revfuBanner5" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuBanner5" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkBanner5" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlBanner5" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtBannerUrl5" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revBanner5" runat="server" ErrorMessage="*" ControlToValidate="txtBannerUrl5"
                                ToolTip="Enter Valid URL" Display="Dynamic" ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">

                            <asp:ImageButton ID="ibtnBanner5" runat="server" ImageUrl="~/images/delete.jpg" onclick="ibtnBanner5_Click"  OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false"
                                  />
                        
                        </td>
                    </tr>
                  
                    <tr>
                        <td  style="width: 80px; border-bottom:1px solid #808080;">
                            RHS Banner &nbsp;
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td colspan="1" style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuRHSBanner7" runat="server" />
                            <asp:RegularExpressionValidator ID="revRHSBanner7" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuRHSBanner7" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkRHSBanner7" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlRHSBanner7" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtRHSBannerUrl7" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revRHSBannerUrl7" runat="server" ErrorMessage="*"
                                ControlToValidate="txtRHSBannerUrl7" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080;">

                            <asp:ImageButton ID="ibtnRHSBanner" runat="server" ImageUrl="~/images/delete.jpg"  OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false"
                                   onclick="ibtnRHSBanner_Click" />
                        
                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080;">
                            Footer Banner 1 &nbsp;
                        </td>
                         <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td width="150px" colspan="1" style="border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuFooterBanner1" runat="server" />
                            <asp:RegularExpressionValidator ID="revFooterBanner1" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuFooterBanner1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkFooterBanner6" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlFooterBanner1" runat="server" Target="_blank" NavigateUrl="#"
                                Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtFooterBannerUrl1" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revFooterBannerUrl1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFooterBannerUrl1" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">
                            <asp:ImageButton ID="ibtnFooterBanner1" runat="server"   OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false" 
                                   ImageUrl="~/images/delete.jpg" onclick="ibtnFooterBanner1_Click" />

                        
                        </td>
                    </tr>
                     <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080;">
                            Footer Banner 2 &nbsp;
                        </td>
                         <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td width="150px" colspan="1" style="border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuFooterBanner2" runat="server" />
                            <asp:RegularExpressionValidator ID="revFooterBanner2" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuFooterBanner2" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkFooterBanner6" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlFooterBanner2" runat="server" Target="_blank" NavigateUrl="#"
                                Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtFooterBannerUrl2" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1FooterBanner2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFooterBannerUrl2" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">
                            <asp:ImageButton ID="ibtnFooterBanner2" runat="server"   
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false" 
                                   ImageUrl="~/images/delete.jpg" onclick="ibtnFooterBanner2_Click"  />

                        
                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080;">
                            Footer Banner 3 &nbsp;
                        </td>
                         <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td width="150px" colspan="1" style="border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuFooterBanner3" runat="server" />
                            <asp:RegularExpressionValidator ID="revFooterBanner3" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuFooterBanner3" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkFooterBanner3" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlFooterBanner3" runat="server" Target="_blank" NavigateUrl="#"
                                Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtFooterBannerUrl3" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1FooterBanner3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFooterBannerUrl3" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">
                            <asp:ImageButton ID="ibtnFooterBanner3" runat="server"   
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false" 
                                   ImageUrl="~/images/delete.jpg" onclick="ibtnFooterBanner3_Click"  />

                        
                        </td>
                    </tr>
                      <tr>
                        <td  style="width: 80px;  border-bottom:1px solid #808080;">
                            Footer Banner 4 &nbsp;
                        </td>
                         <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080">
                    :
                    </td>
                        <td width="150px" colspan="1" style="border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:FileUpload ID="fuFooterBanner4" runat="server" />
                            <asp:RegularExpressionValidator ID="revFooterBanner4" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuFooterBanner4" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <%--<asp:LinkButton ID="lnkFooterBanner4" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlFooterBanner4" runat="server" Target="_blank" NavigateUrl="#"
                                Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px;  border-bottom:1px solid #808080;  border-right:1px solid #808080">
                            <asp:TextBox ID="txtFooterBannerUrl4" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1FooterBanner4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFooterBannerUrl4" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080">
                            <asp:ImageButton ID="ibtnFooterBanner4" runat="server"   
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" Visible="false" 
                                   ImageUrl="~/images/delete.jpg" onclick="ibtnFooterBanner4_Click"  />

                        
                        </td>
                    </tr>
                      <tr>
                        <td  style="width: 80px; border-bottom:1px solid #808080; ">
                            Ad Banner 1 &nbsp;
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080; ">
                    :
                    </td>
                        <td colspan="1" 
                              style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080; ;">
                            <asp:FileUpload ID="fuAdBanner1" runat="server" />
                            <asp:RegularExpressionValidator ID="revAdBanner1" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuAdBanner1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <%--<asp:LinkButton ID="lnkRHSBanner7" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlkAdBanner1" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  &nbsp;
                        </td>
                        <td style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <asp:TextBox ID="txtAdBannerURL1" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1AdBanner1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAdBannerURL1" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080; ">

                            <asp:ImageButton ID="imgbtnAdBanner1" runat="server" 
                                   ImageUrl="~/images/delete.jpg"  
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" 
                                   Visible="false" onclick="imgbtnAdBanner1_Click"
                                   />
                        
                        </td>
                    </tr>
                     <tr>
                        <td  style="width: 80px; border-bottom:1px solid #808080; ">
                            Ad Banner 2 &nbsp;
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080; ">
                    :
                    </td>
                        <td colspan="1" 
                              style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080; ;">
                            <asp:FileUpload ID="fuAdBanner2" runat="server" />
                            <asp:RegularExpressionValidator ID="revAdBanner2" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuAdBanner2" ValidationExpression="(.*?)\.(jpg|jpeg|png|

gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <%--<asp:LinkButton ID="lnkRHSBanner7" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlkAdBanner2" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  

&nbsp;
                        </td>
                        <td style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <asp:TextBox ID="txtAdBannerURL2" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1AdBanner2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAdBannerURL2" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" 

ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080; ">

                            <asp:ImageButton ID="imgbtnAdBanner2" runat="server" 
                                   ImageUrl="~/images/delete.jpg"  
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" 
                                   Visible="false" onclick="imgbtnAdBanner2_Click" 
                                   />
                        
                        </td>
                    </tr>
                     <tr>
                        <td  style="width: 80px; border-bottom:1px solid #808080; ">
                            Ad Banner 3 &nbsp;
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080; ">
                    :
                    </td>
                        <td colspan="1" 
                              style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080; ;">
                            <asp:FileUpload ID="fuAdBanner3" runat="server" />
                            <asp:RegularExpressionValidator ID="revAdBanner3" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuAdBanner3" ValidationExpression="(.*?)\.(jpg|jpeg|png|

gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <%--<asp:LinkButton ID="lnkRHSBanner7" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlkAdBanner3" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  

&nbsp;
                        </td>
                        <td style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <asp:TextBox ID="txtAdBannerURL3" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1AdBanner3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAdBannerURL3" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" 

ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080; ">

                            <asp:ImageButton ID="imgbtnAdBanner3" runat="server" 
                                   ImageUrl="~/images/delete.jpg"  
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" 
                                   Visible="false" onclick="imgbtnAdBanner3_Click" 
                                   />
                        
                        </td>
                    </tr>
                     <tr>
                        <td  style="width: 80px; border-bottom:1px solid #808080; ">
                            Ad Banner 4 &nbsp;
                        </td>
                        <td  style="width: 5px;  border-bottom:1px solid #808080; border-right:1px solid #808080; ">
                    :
                    </td>
                        <td colspan="1" 
                              style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080; ;">
                            <asp:FileUpload ID="fuAdBanner4" runat="server" />
                            <asp:RegularExpressionValidator ID="revAdBanner4" runat="server" ToolTip="Only Jpeg,Png and GIF are allowed"
                                Display="Dynamic" ErrorMessage="*" ControlToValidate="fuAdBanner4" ValidationExpression="(.*?)\.(jpg|jpeg|png|

gif)$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 80px;  border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <%--<asp:LinkButton ID="lnkRHSBanner4" runat="server" Visible="false">ViewImage</asp:LinkButton>--%>
                            <asp:HyperLink ID="hlkAdBanner4" runat="server" Target="_blank" NavigateUrl="#" Visible="false">View Image</asp:HyperLink>  

&nbsp;
                        </td>
                        <td style="width: 150px; border-bottom:1px solid #808080;  border-right:1px solid #808080;">
                            <asp:TextBox ID="txtAdBannerURL4" runat="server" Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1AdBanner4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAdBannerURL4" ToolTip="Enter Valid URL" Display="Dynamic"
                                ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)" 

ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                           <td style="width:80px; border-bottom:1px solid #808080; ">

                            <asp:ImageButton ID="imgbtnAdBanner4" runat="server" 
                                   ImageUrl="~/images/delete.jpg"  
                                   OnClientClick="return confirm('Are you sure you want to delete this Banner');" 
                                   Visible="false" onclick="imgbtnAdBanner4_Click" 
                                   />
                        
                        </td>
                    </tr>
                    <tr class="tableHeading">

                       
                        <td colspan="6" style="height:10px">
                        </td>
                    </tr>
                  
                </table>
        
  
  
    <table><tr><td>
      <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/save.jpg" OnClick="Button_Go_Click">
                            </asp:ImageButton>
    
    </td></tr></table>
</asp:Content>
