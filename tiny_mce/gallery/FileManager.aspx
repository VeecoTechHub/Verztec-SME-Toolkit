<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileManager.aspx.cs" Inherits="FileManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FileManager</title>
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
        var value = tinyMCEPopup.getWindowArg("input");
        var type = tinyMCEPopup.getWindowArg("type");
        if(value != 'href')
        {
            if(type == 'media')
            {
                win.document.getElementById(tinyMCEPopup.getWindowArg("input")).value = URL;
            }
            else
            {
                var file= URL;
                var title = document.getElementById('lblImageHeading').innerHTML;
                var ed = tinyMCEPopup.editor, dom = ed.dom;
                tinyMCEPopup.execCommand('mceInsertContent'
                                         ,false
                                         ,dom.createHTML('a', {href : file,title : title,innerHTML : title},dom.encode(title)));
            }
        }
        else
        {
            win.document.getElementById(tinyMCEPopup.getWindowArg("input")).value = URL;
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
			var cmsURL =  '<%=ViewState["Url"]%>' + 'tiny_mce/gallery/UploadFile.aspx?IDE=<%=ViewState["CLocation"] %>&IDE1=<%=ViewState["CurDirectory"] %>';
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
        return true;
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="790" style="background-color: #FFFFFF;"
            align="center">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="1" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td width="429" align="right" class="top-bg">
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td width="60%" align="left" style="padding-left: 15px;">
                                                Current Folder :<%=ViewState["CLocation"]%>
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
            <tr>
                <td class="spacer">
                </td>
            </tr>
            <tr>
                <td>
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
                                                    <td align="left" valign="top" class="leftmenu-bg">
                                                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <table id="" align="center">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="blue-bold">
                                                                                    Preview</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="spacer">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="lbltext1">
                                                                                    <asp:Label ID="lblImageHeading" runat="server"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="spacer">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Panel ID="pnlImage" runat="server" Height="200px" HorizontalAlign="Center" ScrollBars="Auto"
                                                                                        Width="180px">
                                                                                        <asp:Image ID="img" runat="server" Height="180px" Width="170px" ImageUrl="~/Image/Picture-Not-Available.gif">
                                                                                        </asp:Image>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="Tr1">
                                                                                <td class="spacer">
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trViewImg" runat="server">
                                                                                <td align="center">
                                                                                    <table width="85%" cellpadding="0" cellspacing="0" border="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <a onclick="window.open('<%=ViewState["img"]%>','mywindow');" href="#" style="text-decoration: none;"
                                                                                                    class="text1">
                                                                                                    <asp:Label ID="lblViewImage" runat="server" Font-Underline="False" Text="View Image"
                                                                                                        CssClass="text1"></asp:Label></a></td>
                                                                                            <td style="background-color: #F0F0EE; width: 1px; border-width: thick;">
                                                                                            </td>
                                                                                            <td>
                                                                                                <a onclick="FileBrowserDialogue.mySubmit('<%=ViewState["img"]%>');" href="#" style="text-decoration: none;"
                                                                                                    class="text1">Insert</a>
                                                                                            </td>
                                                                                            <td style="background-color: #F0F0EE; width: 1px;">
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:LinkButton ID="lbDownload" OnClick="lbDownload_Click" runat="server" CssClass="text1"
                                                                                                    Font-Underline="False">Download</asp:LinkButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trNOImg" runat="server">
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblNOImg" runat="server" Text="View Image" CssClass="text1" Font-Underline="False"></asp:Label>
                                                                                    <asp:Label ID="lblNoDownLoad" runat="server" Text="Download" CssClass="text1" Font-Underline="False"
                                                                                        Enabled="False"></asp:Label></td>
                                                                            </tr>
                                                                            <tr runat="server">
                                                                                <td align="center" class="spacer">
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
                                </table>
                            </td>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="padding-left: 20px;">
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td class="spacer" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" valign="top">
                                            <asp:GridView ID="gvFolder" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                GridLines="Vertical" CellPadding="4" CellSpacing="0" AllowSorting="True" OnRowCommand="gvFolder_RowCommand"
                                                OnRowDataBound="gvFolder_RowDataBound" OnSorting="gvFolder_Sorting" Width="90%"
                                                OnPageIndexChanging="gvFolder_PageIndexChanging" DataKeyNames="FolderName">
                                                <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <HeaderStyle HorizontalAlign="Left" BackColor="#F2F1EE" Width="15px" Height="20px" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblChk" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>'></asp:Label>
                                                            <asp:CheckBox ID="chkId" runat="server" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="#F2F1EE" Width="15px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File Name" SortExpression="FolderName">
                                                        <HeaderStyle ForeColor="Black" HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRootName" runat="server" Text='<%#Eval("FolderName")%>' Visible="false"></asp:Label>
                                                            <asp:ImageButton ID="imgFolder" Height="" Width="" CommandArgument='<%#Eval("FolderName")%>'
                                                                CommandName="getRDetails" runat="server" Style="padding-right: 2px;" />
                                                            <asp:LinkButton ID="lbRootName" runat="server" CommandArgument='<%#Eval("FilePath")%>'
                                                                CommandName="getRDetails" Text='<%#Eval("FolderName")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Size" SortExpression="FileSize">
                                                        <HeaderStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#F2F1EE" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSize" runat="server" Text='<%#Eval("FileSize")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="#F2F1EE" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" SortExpression="FileType">
                                                        <HeaderStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#F2F1EE" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("FileType")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="#F2F1EE" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Modification Date" SortExpression="FileModifyDate">
                                                        <HeaderStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#F2F1EE" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFileModifyDate" runat="server" Text='<%#Eval("FileModifyDate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="#F2F1EE" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <PagerStyle HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="spacer" colspan="2" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div>
            &nbsp;</div>
    </form>
</body>
</html>
