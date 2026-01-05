<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImage.aspx.cs" Inherits="tiny_mce_gallery_UploadImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Image</title>
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

    <script type="text/javascript" language="javascript" src="../tiny_mce_popup.js"></script>

    <link href="../../tiny_mce/gallery/Style/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        function Close()
        {
           tinyMCEPopup.close();
        }
        
        function SaveSuccess()
        {
           tinyMCEPopup.getWindowArg("window").location.href=tinyMCEPopup.getWindowArg("window").location.href;
           tinyMCEPopup.close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td valign="top">
                    <table width="99%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left" valign="top" class="top-L">
                                <img src="Images/spacer.gif" alt="" width="18" height="1" /></td>
                            <td align="left" valign="top" class="top-M">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" valign="middle" class="top-R">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <img src="Images/upload-icon.png" alt="" height="50" /></td>
                                                    <td valign="middle">
                                                        <span style="font-size: 10pt; font-family: Verdana"><strong>Upload Images</strong></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="spacer">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="3" cellspacing="2" border="0" width="70%">
                        <tr>
                            <td align="left" colspan="3">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Names="Verdana"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="left">
                                <span style="font-size: 10pt; font-family: Verdana">Upload</span></td>
                            <td width="2%">
                                :</td>
                            <td align="left">
                                <asp:FileUpload ID="fupUpload" runat="server" /></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <span style="font-size: 10pt; font-family: Verdana">Path</span></td>
                            <td>
                                :</td>
                            <td align="left" class="lbltext">
                                <%= ViewState["Path"]%>
                            </td>
                        </tr>
                        <tr>
                            <td class="spacer" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Upload"
                                    CssClass="lbltext" />
                                <input id="btnClose" type="submit" value="Close" onclick="Close();" class="lbltext" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
