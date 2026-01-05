<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ResourceLib.aspx.cs" Inherits="Public_ResourceLib"
    MaintainScrollPositionOnPostback="true" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

    <script type="text/javascript" src="../scripts/ddaccordion.js">

    /***********************************************
    * Accordion Content script- (c) Dynamic Drive DHTML code library (www.dynamicdrive.com)
    * Visit https://www.dynamicDrive.com for hundreds of DHTML scripts
    * This notice must stay intact for legal use
    ***********************************************/

</script>

    <style type="text/css">
        .mypets
        {
            /*header of 1st demo*/
            cursor: hand;
            cursor: pointer;
            padding: 2px 5px;
            border: 1px solid gray;
            background: #E1E1E1;
        }
        .openpet
        {
            /*class added to contents of 1st demo when they are open*/
            background: yellow;
        }
        .technology
        {
            /*header of 2nd demo*/
            cursor: hand;
            cursor: pointer;
            padding-top: 5px;
        }
        .technology p
        {
            padding-left:45px; padding-right:45px; margin:0; text-align:justify;
            }
        .openlanguage
        {
            /*class added to contents of 2nd demo when they are open*/
            color: #666;
        }
        .closedlanguage
        {
            /*class added to contents of 2nd demo when they are closed*/
            color: #666;
        }
        .mylabel
        {
            line-height: 24px;
            padding-top: 10px;
            font-size:16px;
            vertical-align: top;
        }
         .mylabel_desc
        {
           
            padding-top: 5px;
           vertical-align: top;
        }
        .myspan
        {
            line-height: 24px;
            vertical-align: top;
        }
        .myspan img
        {
            vertical-align: bottom;
        }
        .myspan a
        {
            text-decoration: none;
        }
        .myspan a:hover
        {
            text-decoration: underline;
        }
    </style>

    <script type="text/javascript">

    //Initialize first demo:
    ddaccordion.init({
        headerclass: "mypets", //Shared CSS class name of headers group
        contentclass: "thepet", //Shared CSS class name of contents group
        revealtype: "mouseover", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
        defaultexpanded: [0], //index of content(s) open by default [index1, index2, etc]. [] denotes no content.
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        scrolltoheader: false, //scroll to header each time after it's been expanded by the user?
        persiststate: true, //persist state of opened contents within browser session?
        toggleclass: ["", "openpet"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["none", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function(expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function(header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    })

    //Initialize 2nd demo:
    ddaccordion.init({
        headerclass: "technology", //Shared CSS class name of headers group
        contentclass: "thelanguage", //Shared CSS class name of contents group
        revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
        defaultexpanded: [], //index of content(s) open by default [index1, index2, etc]. [] denotes no content.
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        scrolltoheader: false, //scroll to header each time after it's been expanded by the user?
        persiststate: false, //persist state of opened contents within browser session?
        toggleclass: ["closedlanguage", "openlanguage"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["prefix", "<img src='../images/plus.png' style='width:24px; height:24px' /> ", "<img src='../images/minus.png' style='width:24px; height:24px' /> "], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function(expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function(header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    })

</script>

    <table width="870" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="middle_bg">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="33" valign="top" class="resource_title">
                                        <div>
                                            <asp:Label ID="lblHeading" runat="server" Text="Resource Library" 
                                                meta:resourcekey="lblHeadingResource1"></asp:Label>
                                            </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="300" valign="top">
                                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="203">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 18px">
                                                    <asp:Label ID="lblFake" runat="server" Visible="False" 
                                                        meta:resourcekey="lblFakeResource1"></asp:Label>
                                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Records Not Found" 
                                                        meta:resourcekey="lblMsgResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span class="myspan"><a href="#" onclick="ddaccordion.collapseall('technology'); return false">
                                                        <img src="../images/minus.png" height="24" width="24" alt="" /></a> <a href="#" onclick="ddaccordion.collapseall('technology'); return false">
                                                          <asp:Label ID="lblCollapseall" runat="server" Text="Collapse all" 
                                                        meta:resourcekey="lblCollapseallResource1"></asp:Label>
                                                            </a> | <a href="#" onclick="ddaccordion.expandall('technology'); return false">
                                                                <img src="../images/plus.png" height="24" width="24" alt="" /></a> <a href="#" onclick="ddaccordion.expandall('technology'); return false">
                                                                    <asp:Label ID="lblExpandall" runat="server" Text="Expand all" 
                                                        meta:resourcekey="lblExpandallResource1"></asp:Label>
                                                                    </a> </span>
                                                    <br />
                                                    <br />
                                                    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr height="30" style="background: #394c8c; color: #fff;">
                                                            <td align="left">
                                                                <%--<asp:Image ID="imgPlus" runat="server" ImageUrl="~/images/plus.gif" />--%>
                                                                <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                  <asp:Label ID="lblTitle" runat="server" Text="Title" 
                                                                    meta:resourcekey="lblTitleResource1"></asp:Label>
                                                                 </strong>
                                                            </td>
                                                            <td align="center" width="150">
                                                                <strong>
                                                                  <asp:Label ID="lblAddtoFavourite" runat="server" Text="Add to Favourite" 
                                                                    meta:resourcekey="lblAddtoFavouriteResource1"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="874" border="0" align="left" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DataList ID="id_datalist" runat="server" align="center" RepeatColumns="1" Width="100%"
                                                                    OnItemDataBound="id_datalist_ItemDataBound" CellPadding="0" 
                                                                    meta:resourcekey="id_datalistResource1">
                                                                    <ItemTemplate>
                                                                        <table width="874" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td colspan="3" align="left" bgcolor="#F6F5F5" class="grid_sub_1">
                                                                                    <div class="technology" style="width: 869px; vertical-align: top;">
                                                                                        <asp:HiddenField ID="hdnTopicID" runat="server" 
                                                                                            Value='<%# Eval("TopicID") %>' />
                                                                                        <asp:Label ID="lblTopicName" runat="server" CssClass="mylabel" Font-Bold="True" 
                                                                                            meta:resourcekey="lblTopicNameResource1"></asp:Label>
                                                                                        <p style="padding-left:45px; padding-right:45px; margin:0; text-align:justify;">
                                                                                        <asp:Label ID="lblTopicDesc" runat="server" CssClass="mylabel_desc" 
                                                                                                meta:resourcekey="lblTopicDescResource1"></asp:Label></p>
                                                                                        </div>
                                                                                    <div class="thelanguage">
                                                                                        <asp:DataList ID="id_innerdatalist" runat="server" align="center" OnItemCommand="id_innerdatalist_ItemCommand"
                                                                                            RepeatColumns="1" Width="870px" OnItemDataBound="id_innerdatalist_ItemDataBound"
                                                                                            CellPadding="0" meta:resourcekey="id_innerdatalistResource1">
                                                                                            <ItemTemplate>
                                                                                                <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                                                                                    <tr class="resource_child">
                                                                                                        <td height="30" id="td1" runat="server">
                                                                                                            <asp:HiddenField ID="hdnRLID" runat="server" Value='<%# Eval("RL_ID") %>' />
                                                                                                            <asp:HiddenField ID="hdnLevel" runat="server" Value='<%# Eval("Level") %>' />
                                                                                                            <a href='<%=getEditProfilePage()%>' id="A_level" style="font-weight:bold;">
                                                                                                                <%#Eval("Title")%></a>&nbsp;
                                                                                                            <img src='<%# GetImg(Eval("CreateImage")) %>' title='<%# GetTitle(Eval("CreateImage")) %>' />
                                                                                                        </td>
                                                                                                        <td width="150" height="25" align="center">
                                                                                                            <asp:ImageButton ID="btnFavourite" runat="server" CommandName="favourite" CommandArgument='<%# Eval("RL_ID") %>'
                                                                                                                BorderWidth="0px" CssClass="blue_bold_link" Text="Add to favourite" Width="16px"
                                                                                                                Height="16px" border="0" meta:resourcekey="btnFavouriteResource1" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr class="resource_child">
                                                                                                        <td height="30" id="td2" runat="server">
                                                                                                            <span>
                                                                                                                <p>
                                                                                                                    <%#Eval("Description")%></p>
                                                                                                            </span>
                                                                                                        </td>
                                                                                                        <td width="150" height="25" align="center">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:DataList>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
