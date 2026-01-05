<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="MyRLFavourites.aspx.cs" Inherits="Public_MyRLFavourites" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="resource_title">
                <div>
                    <asp:Label ID="lblFav" runat="server" Text="My Favourites" 
                        meta:resourcekey="lblFavResource1"></asp:Label>
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
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="800" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="70" height="30">
                                                    <asp:Label ID="lblCategory" runat="server" Text="Category" 
                                                        meta:resourcekey="lblCategoryResource1"></asp:Label>
                                                    
                                                </td>
                                                <td width="200">
                                                    <asp:DropDownList ID="id_ddl_Topic" runat="server" Style="width: 185px;" 
                                                        meta:resourcekey="id_ddl_TopicResource1">
                                                    </asp:DropDownList>
                                                </td>
                                                <%--  <td width="50" align="right">
                                                    &nbsp;
                                                </td>--%>
                                                <td width="65" align="center">
                                                   <asp:Label ID="lblTitle" runat="server" Text="Title" 
                                                        meta:resourcekey="lblTitleResource1"></asp:Label>
                                                    
                                                </td>
                                                <td width="200">
                                                    <asp:TextBox ID="id_txt_Title" runat="server" Style="width: 180px;" 
                                                        AutoCompleteType="Disabled" meta:resourcekey="id_txt_TitleResource1"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="id_txt_Title"
                                                        ServicePath="~/WebService.asmx" MinimumPrefixLength="1"
                                                        CompletionSetCount="12" ServiceMethod="GetNewsTitles" 
                                                        DelimiterCharacters="" Enabled="True">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                                <td width="265">
                                                    <asp:Button ID="id_btn_Search" runat="server" CssClass="orange_button" Text="Search"
                                                        OnClick="id_btn_Search_Click" meta:resourcekey="id_btn_SearchResource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 18px">
                                        <asp:Label ID="lblAlert1" runat="server" Visible="False" 
                                            meta:resourcekey="lblAlert1Resource1"></asp:Label>
                                        <asp:Label ID="lblAlert2" runat="server" Visible="False" 
                                            meta:resourcekey="lblAlert2Resource1"></asp:Label>
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Records Not Found" 
                                            meta:resourcekey="lblMsgResource1"></asp:Label>
                                               <asp:Label ID="lblFake1" runat="server" Visible="False" 
                                            meta:resourcekey="lblFake1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                     <asp:Label ID="lblFake" runat="server" Text="Do you want to Delete selected Favourite? Click OK to Delete. Otherwise, Click Cancel." Visible="false" 
                                                                    meta:resourcekey="lblFakeResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" runat="server" id="tbdatalist" bgcolor="#FFFFFF">
                                   
                                        <asp:DataList ID="id_datalist" runat="server" align="center" OnItemCommand="id_datalist_ItemCommand"
                                            RepeatColumns="1" Width="100%" meta:resourcekey="id_datalistResource1">
                                            <HeaderTemplate>
                                                <table border="0" cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td width="217" height="30" align="left" style="background: #394c8c; font-weight:bold;
                                                            color: #fff;">
                                                               <asp:Label ID="lblCategory1" runat="server" Text="Category" 
                                                                   meta:resourcekey="lblCategory1Resource1"></asp:Label>
                                                            
                                                        </td>
                                                        <td width="467" height="25" align="left" style="background: #394c8c;font-weight:bold;
                                                            color: #fff;">
                                                              <asp:Label ID="lblTitle1" runat="server" Text="Title" 
                                                                  meta:resourcekey="lblTitle1Resource1"></asp:Label>
                                                            
                                                        </td>
                                                        <td width="200" height="25" align="right"  style="background: #394c8c;font-weight:bold;
                                                            color: #fff;">
                                                                <asp:Label ID="lblRemove" runat="server" Text="Remove from favourite" 
                                                                    meta:resourcekey="lblRemoveResource1"></asp:Label>
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <HeaderStyle BackColor="#F6F5F5" />
                                            <ItemTemplate>
                                                <table border="0" align="left" cellpadding="1" cellspacing="1" class="blueborder">
                                                    <tr>
                                                        <td height="25" width="217" align="left">
                                                            <%#Eval("TopicName")%>
                                                        </td>
                                                        <td height="25" align="left" width="467">
                                                            <asp:HiddenField ID="HiddenField1" runat="server" 
                                                                Value='<%# Eval("RL_ID") %>' />
                                                            <a class="blue_txt" href=''>
                                                                <%#Eval("Title")%></a> </a>
                                                        </td>
                                                        <td width="200" align="center" height="25">
                                                            <asp:ImageButton ID="btnFavourite" runat="server" ImageUrl="../images/favourite_delete.png"
                                                                CommandName="delete" CommandArgument='<%# Eval("RL_ID") %>' 
                                                                BorderWidth="0px" CssClass="blue_bold_link"
                                                                Text="Remove from favourite" Width="20px" Height="20px" border="0" 
                                                       
                                                                meta:resourcekey="btnFavouriteResource1" />
                                                                 

                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <AlternatingItemStyle BackColor="#E9E9E9" />
                                            <HeaderStyle BackColor="#394c8c" ForeColor="#fff" />
                                            <ItemStyle BackColor="#F6F5F5" />
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
       <script type="text/javascript">
           function reportalert() {
               var lblConfirm = document.getElementById('<%=lblFake.ClientID%>').innerHTML
               return confirm(lblConfirm);
           }
    </script>
</asp:Content>

