<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="Recaptcha" Namespace="Recaptcha" TagPrefix="recaptcha" %>--%>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://jqueryjs.googlecode.com/files/jquery-1.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/scripts/BannerJS.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/scripts/jquery-1.4.2.min.js") %>"></script>
    <style type="text/css">
        .home_select_bg
        {
            background: url('images/select_bg.jpg') no-repeat left;
            width: 223px;
            padding: 10px 5px;
            margin: 0;
            border: none;
        }
    </style>
   
    <script type="text/javascript">
        function mypopup(url) {
            debugger;
            params = 'width=830';
            params += ', height=420, ';
            params += 'status=no, location=no,directories=no,toolbar=no,menubar=no,scrollbars=yes ,minimize=no,copyhistory=no,status=no,titlebar=no, left=90, top=70, titlebar=no, menubar=no, resizable=no';


            newwin = window.open(url, 'windowname4', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            //Execute the slideShow
            slideShow();

        });

        function slideShow() {

            //Set the opacity of all images to 0
            $('.gallery a').css({ opacity: 0.0 });

            //Get the first image and display it (set it to full opacity)
            $('.gallery a:first').css({ opacity: 1.0 });

            //Set the caption background to semi-transparent
            $('.gallery .caption').css({ opacity: 0.7 });

            //Resize the width of the caption according to the image width
            $('.gallery .caption').css({ width: $('.gallery a').find('img').css('width') });

            //Get the caption of the first image from REL attribute and display it
            $('.gallery .content').html($('.gallery a:first').find('img').attr('rel'))
	.animate({ opacity: 0.7 }, 400);

            //Call the gallery function to run the slideshow, 7000 = change to next image after 7 seconds
            setInterval('gallery()', 7000);

        }

        function gallery() {

            //if no IMGs have the show class, grab the first image
            var current = ($('.gallery a.show') ? $('.gallery a.show') : $('.gallery a:first'));

            //Get next image, if it reached the end of the slideshow, rotate it back to the first image
            var next = ((current.next().length) ? ((current.next().hasClass('caption')) ? $('.gallery a:first') : current.next()) : $('.gallery a:first'));

            //Get next image caption
            var caption = next.find('img').attr('rel');

            //Set the fade in effect for the next image, show class has higher z-index
            next.css({ opacity: 0.0 })
	.addClass('show')
	.animate({ opacity: 1.0 }, 1000);

            //Hide the current image
            current.animate({ opacity: 0.0 }, 1000)
	.removeClass('show');

            //Set the opacity to 0 and height to 1px
            $('.gallery .caption').animate({ opacity: 0.0 }, { queue: false, duration: 0 }).animate({ height: '1px' }, { queue: true, duration: 300 });

            //Animate the caption, opacity to 0.7 and heigth to 100px, a slide up effect
            $('.gallery .caption').animate({ opacity: 0.7 }, 100).animate({ height: '100px' }, 500);

            //Display the content
            $('.gallery .content').html(caption);

        }

    </script>
    <style>
        /* // image rotation on home page gallery section */.gallery
        {
            position: relative;
            height: 120px;
        }
        .gallery a
        {
            float: left;
            position: absolute;
        }
        .gallery a img
        {
            border: none;
        }
        .gallery a.show
        {
            z-index: 500;
        }
        /* // image rotation on home page gallery section */</style>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="601" height="14" valign="top" class="home_shadow">
                <table width="580" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="42" class="home_head">
                            <h1>
                                <asp:Localize ID="locHeading" runat="server" meta:resourcekey="locHeadingResource1"
                                    Text="
    Welcome to the SME Financial Management Toolkit
                                "></asp:Localize>
                            </h1>
                        </td>
                    </tr>
                    <tr>
                        <td height="152">
                            <div id="banner_Containder">
                                <div id="wrapper">
                                    <div id="websyn">
                                        <ul id="pagination" class="pagination" style="padding-left: 15px;">
                                            <%--   <li onclick="slideshow.pos(0)"></li>
                                            <li onclick="slideshow.pos(1)"></li>
                                            <li onclick="slideshow.pos(2)"></li>--%>
                                            <%=navigation%>
                                        </ul>
                                    </div>
                                    <div id="slider">
                                        <ul>
                                            <%--   <li id="content">
                                                <img src="images/banner.jpg" alt="" /></li>
                                            <li id="Li1">
                                                <img src="images/banner1.jpg" alt="" /></li>
                                            <li id="content2">
                                                <img src="images/banner2.jpg" alt="" /></li>--%>
                                            <%=BannerImages %>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                <tr>
                        <td height="20">
                        </td>
                    </tr>
					<tr>
                        <td>
							<p>
								<b>Scheduled Maintenance</b>
							</p>
							<p>
								The SME Financial Management Toolkit will be undergoing scheduled maintenance on Friday, 11 October, 11:59 PM to Saturday, 12 October, 7:00 AM (GMT+8).
							</p>
							<p>
								During this period, please kindly refrain from registering / logging in as we will be updating the database in the server.
							</p>
							<p>
								We apologise for any inconvenience caused and appreciate your patience during this time.
							</P>
                        </td>
                    </tr>
			
				<!--<tr>
                        <td>
                        <p><b>Scheduled Maintenance</b></p>
						<p>The SME Financial Management Toolkit will be undergoing scheduled maintenance on Sunday, 13 March, Midnight to Sunday, 13 March, 3am (GMT+8)</p>
						<p>During this period, please kindly refrain from registering / logging in as we will be updating the database in the server.</p>
                        <p>We apologise for any inconvenience caused and appreciate your patience during this time.</P>
                        </td>
					</tr>-->
                    
                    <tr>
                        <td>
                                     <asp:Localize ID="locParagraph" runat="server" meta:resourcekey="lblWarrantyStatementResource1"
                                Text="
    This &lt;strong&gt;SME Financial Management Toolkit&lt;/strong&gt; is an online financial management
                                tool developed in partnership with Enterprise Singapore and the corporate advisory unit of RSM in Singapore. The key objective here is to allow SMEs in Singapore to analyse their own
                                financial management capabilities and to provide businesses with resources such
                                as articles and templates to improve their business management from a financial
                                perspective.&lt;br /&gt;
                                &lt;br /&gt;
                                "></asp:Localize>

                           <%--     <asp:Label ID="lblText" runat="server" Text="Please read the" meta:resourcekey="lblTextResource1"></asp:Label>
                            &nbsp;<a href="#" class="footer_link" onclick="javascript:return mypopup('<%= Page.ResolveUrl("~/TermsConditions.aspx") %>');"><asp:Label
                                ID="lblTerms" runat="server" Text="Terms of Use and Privacy Notice" meta:resourcekey="lblTermsResource1"></asp:Label>
                            </a>&nbsp;<asp:Label ID="lblText2" runat="server" Text="should you wish to use this Toolkit."
                                meta:resourcekey="lblText2Resource1"></asp:Label>--%>
                            <asp:Label ID="lblParaWithLink" runat="server"></asp:Label>
                         
                            <%--   <p style="text-align: justify;">
                                <strong>The Association of Banks in Singapore (ABS)</strong> is a non-profit industry
                                body which promotes and represents the interests of the commercial and investment
                                banking community in Singapore. ABS works closely with the Monetary Authority of
                                Singapore and other government and non-government agencies to support their respective
                                roles in developing and upholding a sound financial system in Singapore.
                            This <strong>SME Financial Management Toolkit</strong> is an online financial management
                            tool developed in partnership with Enterprise Singapore and Stone Forest Corporate Advisory
                            Pte Ltd. The key objective here is to allow SMEs in Singapore to analyse their own
                            financial management capabilities and to provide businesses with resources such
                            as articles and templates to improve their business management from a financial
                            perspective.<br />
                            <br />
                            This tool is provided free-of-charge but one-time registration with a valid email
                            address is required. Please read the should you wish to use this Toolkit. </p>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="gallery" style="float: left">
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <div class="gallery">
                                                <%=AdBanners%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="273" valign="top">
                <table width="244" border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="58" class="newGray">
                            <table width="244" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                            <a href="Public/Registration.aspx">
                                            <img  alt="Register" border="0" width="66" height="33" runat="server" id="imgRegister" /></a>
                                        <asp:Label ID="lblFake" runat="server" Visible="False" meta:resourcekey="lblFakeResource1"></asp:Label>
                                    </td>
                                    <td style="white-space: nowrap;">
                                        <asp:Label ID="lblFirstTimeUser" runat="server" Text="First time user?" meta:resourcekey="lblFirstTimeUserResource1"></asp:Label>
                                        <br />
                                        <a href="Public/Registration.aspx" class="register_here">
                                            <asp:Label ID="lblRegPass" runat="server" Text="Register here for a Password" meta:resourcekey="lblRegPassResource1"></asp:Label>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                    <tr>
                        <td style="background: #e3ebee">
                            <table width="240" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="32" class="blue_big">
                                        <%-- <img src="images/login_icon.jpg" alt="" width="24" height="23" align="absbottom" />--%>
                                        <asp:Label ID="lblLogin" runat="server" Text="Login" meta:resourcekey="lblLoginResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" style="background: #eef6f9">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="234" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="25">
                                                    <asp:Label ID="lblEmailId" runat="server" Text="Email ID" meta:resourcekey="lblEmailIdResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="home_select_bg" MaxLength="100" TabIndex="1"
                                                        meta:resourcekey="txtUsernameResource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="valUserName" runat="server" ControlToValidate="txtUsername"
                                                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a EmailID" CssClass="Mandatory"
                                                        meta:resourcekey="valUserNameResource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25">
                                                    <asp:Label ID="lblPassword" runat="server" Text="Password" meta:resourcekey="lblPasswordResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="home_select_bg" TextMode="Password" TabIndex="2"
                                                        MaxLength="100" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword"
                                                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory"
                                                        meta:resourcekey="valPasswordResource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                        
                                        <td align="left" bgcolor="#EAEAEA" colspan="2">
                                          
                                            <div class="valMessage">
                                                <asp:RequiredFieldValidator ID="ValCaptcha" runat="server" ControlToValidate="txtCaptcha"
                                                    Display="Dynamic" />
                                            </div>
                                        </td>
                                    </tr>--%>
                                            <tr id="HideCaptcha" runat="server">
                                                <td align="left" height="130" colspan="2">
                                                    <asp:Label ID="lblType" runat="server" Text="type below image text here" meta:resourcekey="lblTypeResource1"></asp:Label>
                                                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="text" MaxLength="10" meta:resourcekey="txtCaptchaResource1" />
                                                    <cc2:CaptchaControl ID="ccCorporateCaptcha" runat="server" CaptchaBackgroundNoise="None"
                                                        CaptchaLength="6" CaptchaHeight="60" CaptchaWidth="230" CaptchaMinTimeout="6"
                                                        CaptchaMaxTimeout="240" BackColor="#F4F4F4" CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789"
                                                        FontColor="Black" LineColor="Black" meta:resourcekey="ccCorporateCaptchaResource1"
                                                        NoiseColor="Black" />
                                                    <%--  <recaptcha:recaptchacontrol id="rec1" runat="server" publickey="6LfukccSAAAAAKzFubq4e18j3WsbCzvw3Zv7xFv5"
                                            privatekey="6LfukccSAAAAAKM0-z4TVyWRsUBgNDAqZCzB0XPB" />--%>
                                                    <asp:Label ID="lblRError" runat="server" CssClass="ManditoryField" Visible="False"
                                                        meta:resourcekey="lblRErrorResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="orange_button" OnClick="btnLogin_Click" TabIndex="3"
                                                        meta:resourcekey="btnLoginResource1" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="30">
                                        <%--   <asp:LinkButton ID="lnkForgotPwd" runat="server" CssClass="forgot_link" PostBackUrl="~/Public/ForgotPassword.aspx" CausesValidation="false">Forgotten your password?</asp:LinkButton>--%>
                                        <a href="Public/ForgotPassword.aspx" class="forgot_link">
                                            <asp:Label ID="lblForgottenPwd" runat="server" Text="Forgotten your password?" meta:resourcekey="lblForgottenPwdResource1"></asp:Label>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                    <%--  <tr>
                        <td height="30">
                            <a href="Public/Registration.aspx" class="forgot_link">Register Now</a>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td height="30">
                            <a href="ResendConfLink.aspx" class="forgot_link">Resend Link</a>
                        </td>
                    </tr>--%>
                    <tr>
                        <td><asp:Image ID="Image1" Height="1px" ImageUrl="~/images/dummy.png" Width="251px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 251; height: 44; display:none;">
                            <asp:HyperLink ID="hypRHS" runat="server" BorderStyle="None" Target="_blank" Height="144px"
                                Width="251px">
                                <asp:Image ID="imgRHS" Height="144px" Width="251px" runat="server" />
                            </asp:HyperLink>
                        </td>
                    </tr>
                       <tr>
                        <td style="width: 251; height: 44;" align="center">
                            <asp:HyperLink ID="hypRHSImg" runat="server" BorderStyle="None" Target="_blank" Height="99px" NavigateUrl="https://www.rsmsingapore.sg/who-we-are/events/60-financial-management-fundamentals-for-business-owners" ImageUrl="~/images/Panel-Financial-Management.jpg"
                                Width="222px">
                            </asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDes1" runat="server" Visible="False" meta:resourcekey="lblDes1Resource1"></asp:Label>
                            <asp:Label ID="lblDes2" runat="server" Visible="False" meta:resourcekey="lblDes2Resource1"></asp:Label>
                            <asp:Label ID="lblDes3" runat="server" Visible="False" meta:resourcekey="lblDes3Resource1"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>
