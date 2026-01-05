<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="Function_Update.aspx.cs" Inherits="Administration_Function_Update"
    Title="Update Function" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
<!--

        function btnReset_onclick() {

        }

// -->
    </script>
    <table id="Table2" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td height="40" style="width: 34px">
                <img src="../images/arrow.GIF" width="13" height="15" align="absmiddle" style="padding-left: 15px" />
            </td>
            <td width="600" align="left">
                <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                    &gt;&gt;<%=(ViewState["Links"].ToString().Split('|')[4])%></strong>
            </td>
            <td width="180" align="left" valign="middle">
                <p style="padding-top: 5px">
                    <strong class="blue">User:
                        <%=Session["GROUP_ID"].ToString()%>
                        /
                        <%=Session["USER_NM"].ToString()%>
                    </strong>
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <table id="Table1" width="100%" border="0">
                    <tr>
                        <td colspan="5" style="height: 14px" align="left">
                            <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblError" runat="server" CssClass="warnings" Visible="False" ForeColor="#ff6633"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" nowrap>
                            Function ID<font color="#ff0000"></font>
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1%">
                            :
                        </td>
                        <td width="30%">
                            &nbsp;<asp:TextBox ID="Txt_Function_Id" runat="server" MaxLength="32" Width="203px"
                                ReadOnly="True" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="formlabel" width="20%">
                            Parent Menu<span style="color: #ff0000">*</span>
                        </td>
                        <td class="formlabel" style="width: 1%">
                            :
                        </td>
                        <td width="30%">
                            &nbsp;<asp:DropDownList ID="Lst_Parent_Menu" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVLst_Parent_Menu" runat="server" ControlToValidate="Lst_Parent_Menu"
                                ErrorMessage="RequiredFieldValidator" InitialValue="0">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" style="height: 3px">
                            Description<span style="color: #ff0000">*</span>
                        </td>
                        <td class="formlabel" style="width: 1%; height: 3px;">
                            :
                        </td>
                        <td nowrap width="30%" style="height: 3px">
                            &nbsp;<asp:TextBox ID="Txt_Description" runat="server" MaxLength="160"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Req_Vldtr_Desc" runat="server" ControlToValidate="Txt_Description" CssClass="warnings"
                                InitialValue="">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="formlabel" width="20%" nowrap style="height: 3px">
                            Short Description<span style="color: #ff0000">*<font color="#ff0000"></font></span>
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1%; height: 3px;">
                            :
                        </td>
                        <td nowrap width="30%" style="height: 3px">
                            &nbsp;<asp:TextBox ID="Txt_Short_Desc" runat="server" MaxLength="80"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Requiredfieldvalidator2" runat="server" ControlToValidate="Txt_Short_Desc"
                                CssClass="warnings" InitialValue="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3">
                            Page Size in Search<span style="color: #ff0000">*</span>
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td width="30%" colspan="4" height="3">
                            &nbsp;<asp:TextBox ID="txt_Page_Size" runat="server" MaxLength="2" Width="55px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Page_Size"
                                ErrorMessage="RequiredFieldValidator" InitialValue="">*</asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3">
                            Search URL<font color="#ff0000"></font>
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td width="30%" colspan="4" height="3">
                            &nbsp;<asp:TextBox ID="Txt_Search_URL" runat="server" MaxLength="440" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3">
                            New URL<font color="#ff0000"></font>
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td width="30%" colspan="4" height="3">
                            &nbsp;<asp:TextBox ID="Txt_New_URL" runat="server" MaxLength="440" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3">
                            Edit URL
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td width="30%" colspan="4" height="3">
                            &nbsp;<asp:TextBox ID="Txt_Edit_URL" runat="server" MaxLength="440" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3">
                            Default Page
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td width="30%" colspan="4" height="3">
                            &nbsp;<asp:RadioButton ID="Rad_Search" runat="server" Text="Search" GroupName="Rad_Default_Page">
                            </asp:RadioButton>&nbsp;&nbsp;
                            <asp:RadioButton ID="Rad_New" runat="server" Text="New" GroupName="Rad_Default_Page">
                            </asp:RadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3">
                            Sort Sequence<span style="color: #ff0000">*<font color="#ff0000"></font></span>
                        </td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :
                        </td>
                        <td width="30%" colspan="4" height="3">
                            &nbsp;<asp:TextBox ID="Txt_Sort_Seq" runat="server" MaxLength="3" Width="55px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="Txt_Sort_Seq"
                                ErrorMessage="Enter numerics only" MaximumValue="999" MinimumValue="1" Type="Integer"
                                CssClass="warnings" ForeColor="">Enter numerics only</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" height="35" valign="top">
                            <table cellspacing="3">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="Bttn_Update" CausesValidation="true" runat="server" ImageUrl="~/images/save.jpg"
                                            OnClick="Bttn_Update_Click"></asp:ImageButton>
                                    </td>
                                    <%-- <td>
                                        <input class="btn" type="reset" value="Reset"  id="btnReset" language="javascript"
                                            onclick="return btnReset_onclick()" /></td>--%>
                                    <td>
                                        <%--<asp:ImageButton ID="Bttn_Back" runat="server"  ImageUrl="~/images/back.jpg" OnClick="Bttn_Back_Click"
                                            ></asp:ImageButton>
                                        --%>
                                        <a href='javascript:postForEdit1("<%=ViewState["t_urlback"]%>","we+XKcjPYmE=","<%=token %>");'
                                            tabindex="6">
                                            <img src="../images/back.jpg" border="0" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
