<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Public_Dashboard"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">
    function GetStatus(chkstatus) {
        var status = chkstatus.checked;
        document.getElementById('<%=hfStatus.ClientID%>').value = status;
    
    }
</script>--%>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/scripts/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/scripts/BannerJS.js") %>"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../scripts/dialog.js"></script>
    <%if (Session["show"].ToString() == "yes")
      { %>
    <script type="text/javascript">

        $(document).ready(function () {

            var id = '#dialog';

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set heigth and width to mask to fill up the whole screen
            $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

            //transition effect		
            $('#mask').fadeIn(1000);
            $('#mask').fadeTo("slow", 0.8);

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            //Set the popup window to center
            $(id).css('top', winH / 2 - $(id).height() / 2);
            $(id).css('left', winW / 2 - $(id).width() / 2);

            //transition effect
            $(id).fadeIn(2000);

            //if close button is clicked
            $('.window .close').click(function (e) {
                //Cancel the link behavior
                e.preventDefault();

                $('#mask').hide();
                $('.window').hide();
            });

            //if mask is clicked
            $('#mask').click(function () {
                $(this).hide();
                $('.window').hide();
            });

        });


    </script>
    <%}%>
    <script type="text/javascript">
        function showReg() {
            $(document).ready(function () {

                var id = '#divReg';

                //Get the screen height and width
                var maskHeight = $(document).height();
                var maskWidth = $(window).width();

                //Set heigth and width to mask to fill up the whole screen
                $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

                //transition effect		
                $('#mask').fadeIn(1000);
                $('#mask').fadeTo("slow", 0.8);

                //Get the window height and width
                var winH = $(window).height();
                var winW = $(window).width();

                //Set the popup window to center
                $(id).css('top', winH / 2 - $(id).height() / 2);
                $(id).css('left', winW / 2 - $(id).width() / 2);

                //transition effect
                $(id).fadeIn(2000);

                //if close button is clicked
                $('.window .close').click(function (e) {
                    //Cancel the link behavior
                    e.preventDefault();

                    $('#mask').hide();
                    $('.window').hide();
                });

                //if mask is clicked
                $('#mask').click(function () {
                    $(this).hide();
                    $('.window').hide();
                });

            });
        }


    </script>
    <%--<%if (Session["MemberRegistrationdate"].ToString() == "yes")
      { %>

    <script type="text/javascript">

        $(document).ready(function() {

            var id = '#divGFb';

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set heigth and width to mask to fill up the whole screen
            $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

            //transition effect		
            $('#mask').fadeIn(1000);
            $('#mask').fadeTo("slow", 0.8);

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            //Set the popup window to center
            $(id).css('top', winH / 2 - $(id).height() / 2);
            $(id).css('left', winW / 2 - $(id).width() / 2);

            //transition effect
            $(id).fadeIn(2000);

            //if close button is clicked
            $('.window .close').click(function(e) {
                //Cancel the link behavior
                e.preventDefault();

                $('#mask').hide();
                $('.window').hide();
            });

            //if mask is clicked
            $('#mask').click(function() {
                $(this).hide();
                $('.window').hide();
            });

        });


    </script>
    
    <%}%>--%>
    <style type="text/css">
        a
        {
            color: #333;
            text-decoration: none;
        }
        a:hover
        {
            color: #ccc;
            text-decoration: none;
        }
        #mask
        {
            position: absolute;
            left: 0;
            top: 0;
            z-index: 9000;
            background-color: #000;
            display: none;
        }
        #boxes .window
        {
            position: absolute;
            left: 0;
            top: 0;
            width: 600px;
            height: 400px;
            display: none;
            z-index: 9999;
            padding: 20px;
        }
        #boxes #dialog
        {
            width: 800px;
            height: 400px;
            padding: 10px;
            background: url(../images/trns.png) repeat;
            font-family: Arial;
            font-size: 14px;
            color: #2A2121;
        }
        #divMainGrayBox .window
        {
            position: absolute;
            left: 0;
            top: 0;
            width: 600px;
            height: 100px; /*Reduces the height of the popUp*/
            display: none;
            z-index: 9999;
            padding: 20px;
        }
        #divMainGrayBox #dialog
        {
            width: 800px;
            height: 400px;
            padding: 10px;
            background: url(../images/trns.png) repeat;
            font-family: Arial;
            font-size: 14px;
            color: #2A2121;
        }
        #divGeneralFB .window
        {
            position: absolute;
            left: 0;
            top: 0;
            width: 874px;
            height: 550px;
            display: none;
            z-index: 9999;
            padding: 20px;
        }
        #divGeneralFB #dialog
        {
            width: 900px;
            height: 530px;
            padding: 5px;
            background: url(../images/trns.png) repeat;
            font-family: Arial;
            font-size: 14px;
            color: #2A2121;
        }
    </style>
    <%--<style type="text/css">
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
   
    </style>--%>
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
        /* // image rotation on home page gallery section */
        
        .gallery
        {
            position: relative;
            height: 125px;
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
        
        /* // image rotation on home page gallery section */
    </style>
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <div class="dynamicTxt_Dashboard">
                <asp:Image ID="imgshadow" Visible="False" runat="server" ImageUrl="~/images/watermark.png"
                    meta:resourcekey="imgshadowResource1" />
            </div>
            <div align="center">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="874" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="29" bgcolor="#FFFFFF">
                                        &nbsp;
                                    </td>
                                    <td width="394" valign="top">
                                        <a href="../FinancialModeling/CompanyInformation.aspx" id="box2" runat="server">
                                            <asp:Image ID="Img2" runat="server" ImageUrl="~/images/box2.png" Width="390px" Height="115px"
                                                BorderStyle="None" meta:resourcekey="Img2Resource1" /></a> <a href="#" onclick="showReg();"
                                                    id="box2_hide" runat="server">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/box2_hide.png" Width="390px"
                                                        Height="115px" BorderStyle="None" meta:resourcekey="Image1Resource1" /></a>
                                        <asp:Label ID="lblFintool" runat="server" Visible="False" meta:resourcekey="lblFintoolResource1"></asp:Label>
                                    </td>
                                    <td width="28">
                                        &nbsp;
                                    </td>
                                    <td width="394">
                                        <a href="ResourceLib.aspx">
                                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/box1.jpg" Width="390px" Height="115px"
                                                BorderStyle="None" meta:resourcekey="img1Resource1" /></a>
                                        <asp:Label ID="lblResLibrary" runat="server" Visible="False" meta:resourcekey="lblResLibraryResource1"></asp:Label>
                                    </td>
                                    <td width="29">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <a href="PublicHealthProfiling.aspx" id="box3" runat="server">
                                            <asp:Image ID="Img3" runat="server" ImageUrl="~/images/box3.jpg" Width="390px" Height="115px"
                                                BorderStyle="None" meta:resourcekey="Img3Resource1" /></a> <a href="#" onclick="showReg();"
                                                    id="box3_hide" runat="server">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/box3_hide.png" Width="390px"
                                                        Height="115px" BorderStyle="None" meta:resourcekey="Image2Resource1" /></a>
                                        <asp:Label ID="lblBusiness" runat="server" Visible="False" meta:resourcekey="lblBusinessResource1"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <a href="ClinicalSession.aspx" id="box4" runat="server" target="_blank">
                                            <asp:Image ID="Img4" runat="server" ImageUrl="~/images/box4.jpg" Width="390px" Height="115px"
                                                BorderStyle="None" meta:resourcekey="Img4Resource1" /></a> <a href="#" onclick="showReg();"
                                                    id="box4_hide" runat="server">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/box4_hide.png" Width="390px"
                                                        Height="115px" BorderStyle="None" meta:resourcekey="Image3Resource1" /></a>
                                        <asp:Label ID="lblLearnMore" runat="server" Visible="False" meta:resourcekey="lblLearnMoreResource1"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <a href="FinancialMgtCapabilities.aspx" id="box5" runat="server">
                                            <asp:Image ID="Img5" runat="server" ImageUrl="~/images/box5.png" Width="390px" Height="115px"
                                                BorderStyle="None" meta:resourcekey="Img5Resource1" /></a> <a href="#" onclick="showReg();"
                                                    id="box5_hide" runat="server">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/box5_hide.png" Width="390px"
                                                        Height="115px" BorderStyle="None" meta:resourcekey="Image4Resource1" /></a>
                                        <asp:Label ID="lblCapabilities" runat="server" Visible="False" meta:resourcekey="lblCapabilitiesResource1"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <a href="faq.aspx" id="box6" runat="server">
                                            <asp:Image ID="Img6" runat="server" ImageUrl="~/images/box6.jpg" Width="390px" Height="115px"
                                                BorderStyle="None" meta:resourcekey="Img6Resource1" /></a> <a href="#" onclick="showReg();"
                                                    id="box6_hide" runat="server">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/box6_hide.png" Width="390px"
                                                        Height="115px" BorderStyle="None" meta:resourcekey="Image5Resource1" /></a>
                                        <asp:Label ID="lblFaqs" runat="server" Visible="False" meta:resourcekey="lblFaqsResource1"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
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
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" width="874">
                                <tr>
                                    <td>
                                        <div class="gallery" style="padding-left: 22px; float: left;">
                                            <%=FooterBanners%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="boxes">
        <div style="top: 199.5px; left: 551.5px; display: none; background-color: #E4E4E4;"
            id="dialog" class="window">
            <table width="800" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" align="right">
                        <asp:ImageButton ID="imgbtnClose" runat="server" ImageUrl="~/images/close.png" OnClick="LinkButton1_Click"
                            CausesValidation="False" meta:resourcekey="imgbtnCloseResource1" />
                        <%-- <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" ForeColor="#2A2121">Close</asp:LinkButton>--%><%--<a href="" class="close"><img src="../images/close_img.png" width="53" height="15" alt="" /></a>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <strong>
                                <asp:Label ID="lblWelcome" runat="server" Text="Welcome to the ABS Financial Management Toolkit for SMEs!"
                                    meta:resourcekey="lblWelcomeResource1"></asp:Label>
                            </strong>
                            <asp:Label ID="lblDes1" runat="server" Text="Thank
                            you for registering to use this financial management self-help portal." meta:resourcekey="lblDes1Resource1"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblDes2" runat="server" Text="Every time you login to this website with your Login ID (email) and password, you
                            will see this page called the &ldquo;Dashboard&rdquo;. From the Dashboard, you can
                            then access the various features of this website, such as the online library and
                            the financial modeling tool." meta:resourcekey="lblDes2Resource1"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblDes3" runat="server" Text="Should you need to view or update your information entered during registration,
                            click on &ldquo;My Account&rdquo; at the top of web page." meta:resourcekey="lblDes3Resource1"></asp:Label>
                            <br />
                            <br />
                            <%--<input name="checkbox" id="checkbox" type="checkbox" onclick="GetStatus(this);" />--%>
                            <%--<asp:HiddenField ID="hfStatus" runat="server" />--%>
                            <asp:CheckBox ID="chkVisit" runat="server" meta:resourcekey="chkVisitResource1" />
                            <asp:Label ID="lblDes4" runat="server" Text="Check this box if you do not want to see this message again."
                                meta:resourcekey="lblDes4Resource1"></asp:Label>
                        </p>
                        <p align="center">
                            <asp:Label ID="lblClick" runat="server" Text="Click" meta:resourcekey="lblClickResource1"></asp:Label><asp:LinkButton
                                ID="LinkButton2" runat="server" OnClick="LinkButton1_Click" Text="here" meta:resourcekey="LinkButton2Resource3"></asp:LinkButton>,
                            <%--<a href="#" class="close"here> here </a>--%>
                            <asp:Label ID="lblToCLose" runat="server" Text="to close this window and start using this website."
                                meta:resourcekey="lblToCLoseResource1"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!-- Mask to cover the whole screen -->
        <div style="width: 1478px; height: 602px; display: none; opacity: 0.8;" id="mask">
        </div>
    </div>
    <div id="divMainGrayBox">
        <div style="top: 199.5px; left: 551.5px; display: none; background-color: #E4E4E4;"
            id="divReg" class="window">
            <table width="600" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" align="right">
                        <asp:ImageButton ID="imgBtnCloseReg" CausesValidation="False" runat="server" ImageUrl="~/images/close.png"
                            OnClick="imgBtnCloseReg_Click" meta:resourcekey="imgBtnCloseRegResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblYouCan" runat="server" Text="You can access all these sections from 15th Aug, 2012. So, please"
                            meta:resourcekey="lblYouCanResource1"></asp:Label>
                        <%--  <asp:LinkButton ID="lnkBtnReg" runat="server" OnClick="lnkBtnReg_Click" Font-Underline="true">Click Here</asp:LinkButton>--%>
                        <asp:HyperLink ID="hyplink" runat="server" NavigateUrl="https://www.abs.org.sg/SME/"
                            Text="Click Here" Target="_blank" Font-Underline="True" ForeColor="Black" meta:resourcekey="hyplinkResource2"></asp:HyperLink>
                        <asp:Label ID="lblToRegister" runat="server" Text="to register for this event." meta:resourcekey="lblToRegisterResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!-- Mask to cover the whole screen -->
        <div style="width: 1478px; height: 602px; display: none; opacity: 0.8;" id="Div3">
        </div>
    </div>
    <script type="text/javascript">
        function openReg() {
            window.open(' https://www.abs.org.sg/SME/');
        }

    </script>
</asp:Content>
