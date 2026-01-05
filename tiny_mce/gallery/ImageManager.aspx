<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageManager.aspx.cs" Inherits="tiny_mce_gallery_ImageManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Manager</title>
    <style type="text/css">
        <!--
            body
            {
                margin-left:0px;
                margin-right:0px;
                margin-top:0px;
                margin-bottom:0px;
            }
        -->
    </style>
    <link href="../../tiny_mce/gallery/Style/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../tiny_mce_popup.js"></script>

    <script language="javascript" type="text/javascript">

var FileBrowserDialogue = {
    init : function () {
        // Here goes your code for setting your custom things onLoad.
    },
    mySubmit : function (imageurl) {
        
        var URL = imageurl;
        var win = tinyMCEPopup.getWindowArg("window");
        
        // insert information now
        var value = tinyMCEPopup.getWindowArg("input") 
        if(value != 'src')
        {
            var file= URL;
            var title = 'Test';
            var ed = tinyMCEPopup.editor, dom = ed.dom;
            tinyMCEPopup.execCommand('mceInsertContent'
                                     ,false
                                     ,dom.createHTML('img', {src : file,alt : title,title : title,border : 0}));
        }
        else
        {
            win.document.getElementById(tinyMCEPopup.getWindowArg("input")).value = URL;
        }

        // are we an image browser
        if (typeof(win.ImageDialog) != "undefined")
        {
            // we are, so update image dimensions and preview if necessary
            if (win.ImageDialog.getImageData) win.ImageDialog.getImageData();
            if (win.ImageDialog.showPreviewImage) win.ImageDialog.showPreviewImage(URL);
        }

        // close popup window
        tinyMCEPopup.close();
    }
    }

    tinyMCEPopup.onInit.add(FileBrowserDialogue.init, FileBrowserDialogue);

    </script>

    <script type="text/javascript" language="javascript">
        function Open() 
        {
			// Add you own code to execute something on click
			var ed = tinyMCEPopup.editor;
			ed.focus();
			var cmsURL =  '<%=ViewState["Url"]%>' + 'tiny_mce/gallery/CreateFolder.aspx?IDE=<%=ViewState["CLocation"] %>&IDE1=<%=ViewState["CurDirectory"] %>';
			tinyMCE.activeEditor.windowManager.open({
			file: cmsURL,
            title: 'Create New Folder',
            width: 500,  // Your dimensions may differ - toy around with them!
            height: 200,
            resizable: "no",
            inline: 1,  // This parameter only has an effect if you use the inlinepopups plugin!
            close_previous: "no"
            }, {
                window : window,
                input : tinyMCEPopup.getWindowArg("input")
                });
        return false;
     }
     
     function Upload() 
        {
			// Add you own code to execute something on click
			var ed = tinyMCEPopup.editor;
			ed.focus();
			var cmsURL =  '<%=ViewState["Url"]%>' + 'tiny_mce/gallery/UploadImage.aspx?IDE=<%=ViewState["CLocation"] %>&IDE1=<%=ViewState["CurDirectory"] %>';
			
			tinyMCE.activeEditor.windowManager.open({
			file: cmsURL,
            title: 'Create New Folder',
            width: 500,  // Your dimensions may differ - toy around with them!
            height: 200,
            resizable: "no",
            inline: 1,  // This parameter only has an effect if you use the inlinepopups plugin!
            close_previous: "no"
            }, {
                window : window,
                input : tinyMCEPopup.getWindowArg("input")
                });
        return false;
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="790" style="background-color: #FFFFFF;"
            align="center">
            <tr>
                <td valign="top">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td class="top-L" valign="top" align="left">
                                    <img height="1" alt="" src="Images/spacer.gif" width="18" /></td>
                                <td class="top-M" valign="top" align="left">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td class="top-R" valign="middle" align="right">
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td width="60%" align="left" style="padding-left: 15px;">
                                                                Current Folder :
                                                                <%=ViewState["CLocation"]%>
                                                            </td>
                                                            <td align="right" width="40%">
                                                                <table cellspacing="0" cellpadding="0" width="280" align="right" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table class="link" cellspacing="0" cellpadding="0" width="92%" border="0">
                                                                                <tbody>
                                                                                    <tr onclick="Open();">
                                                                                        <td width="18">
                                                                                            <img height="22" src="Images/create-folder-icon.png" width="22" /></td>
                                                                                        <td class="top-text" align="left">
                                                                                            Create folder</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td width="12">
                                                                        </td>
                                                                        <td>
                                                                            <table class="link" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr onclick="Upload();">
                                                                                        <td width="18">
                                                                                            <img height="22" src="Images/upload-icon.png" width="22" /></td>
                                                                                        <td class="top-text" align="left">
                                                                                            Upload</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td width="12">
                                                                        </td>
                                                                        <td>
                                                                            <table class="link" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td width="18">
                                                                                            <img height="16" src="Images/refresh-icon.gif" width="16" /></td>
                                                                                        <td class="top-text" align="left">
                                                                                            <asp:LinkButton ID="lnkRefresh" runat="server" Font-Underline="False" OnClick="lnkRefresh_Click">Refresh</asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="spacer">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td width="192" valign="top" style="padding-left: 5px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <img src="Images/leftmenu-bg-top.gif" width="192" height="8" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" background="Images/leftmenu-bg-mid.gif">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="left" valign="top" class="leftmenu-bg" style="padding-left: 10px;">
                                                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="lbltext1">
                                                                                <asp:Image ID="ImageOpen" runat="Server" ImageUrl="~/tiny_mce/gallery/Images/folder-open.gif"
                                                                                    Visible="False" />
                                                                                <asp:Image ID="imgClose" runat="Server" ImageUrl="~/tiny_mce/gallery/Images/folder.gif"
                                                                                    Visible="False" />
                                                                                &nbsp;<asp:LinkButton ID="lnkFiles" runat="server" CssClass="lbltext1" Font-Underline="False"
                                                                                    OnClick="lnkFiles_Click">Files</asp:LinkButton></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="spacer">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="blue-bold">
                                                                                Folders</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:TreeView ID="tvFolders" runat="server" AutoGenerateDataBindings="False" CollapseImageUrl="~/tiny_mce/gallery/Images/folder-open.gif"
                                                                                    ExpandDepth="0" ExpandImageUrl="~/tiny_mce/gallery/Images/Folder.gif" NoExpandImageUrl="~/tiny_mce/gallery/Images/Folder.gif"
                                                                                    OnSelectedNodeChanged="tvFolders_SelectedNodeChanged" OnTreeNodePopulate="tvFolders_TreeNodePopulate">
                                                                                    <ParentNodeStyle Font-Bold="False" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="3px"
                                                                                        VerticalPadding="2px" />
                                                                                    <HoverNodeStyle Font-Underline="False" ForeColor="Black" />
                                                                                    <SelectedNodeStyle Font-Underline="False" ForeColor="Red" HorizontalPadding="5px"
                                                                                        VerticalPadding="2px" NodeSpacing="3px" />
                                                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                                        NodeSpacing="3px" VerticalPadding="2px" />
                                                                                    <RootNodeStyle HorizontalPadding="5px" NodeSpacing="3px" VerticalPadding="2px" />
                                                                                </asp:TreeView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
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
                            </td>
                            <td valign="top" align="center">
                                <table id="tblheight" runat="server" height="440px" visible="false" width="90%">
                                    <tr>
                                        <td class="lbltext1" align="center" style="padding-top: 25px;" valign="top">
                                            <span style="font-size: 9pt">No Images Available in Current Location.<br />
                                                To Upload Images Click on <strong>Upload Images</strong> in Header. </span>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%" height="420">
                                    <tr>
                                        <td colspan="2" align="left" valign="top">
                                            <asp:DataList ID="dlPaging" runat="Server" CellPadding="2" RepeatColumns="20" RepeatDirection="Horizontal"
                                                OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound">
                                                <ItemTemplate>
                                                    <td align="center">
                                                        <asp:LinkButton ID="lbtnpaging_Up" runat="server" CommandName='<%#DataBinder.Eval(Container.DataItem, "PageNo")%>'
                                                            CssClass="paging"><%#DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></td>
                                                </ItemTemplate>
                                            </asp:DataList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" valign="top">
                                            <asp:DataList ID="dlImages" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                                                CellPadding="2" CellSpacing="2">
                                                <ItemTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td height="127" valign="baseline" class="images-bg" align="left">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100">
                                                                    <tr>
                                                                        <td align="center" colspan="2" height="106" valign="middle">
                                                                            <img src='<%#Eval("ImagePath") %>' alt="" height="90" width="70" onclick="FileBrowserDialogue.mySubmit('<%#Eval("ImagePath") %>');" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="100" height="21" align="center" class="text2 p_mdl" colspan="2" valign="bottom">
                                                                            <asp:Label ID="lblText" runat="server" Width="95px" Text='<%# Eval("ImageNameTrim") %>'
                                                                                ToolTip='<%#Eval("ImageName") %>'></asp:Label>
                                                                        </td>
                                                                        <%-- <td width="19%">
                                                                            <img src="../Images/act.gif" width="16" height="16" /></td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="Top" />
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
