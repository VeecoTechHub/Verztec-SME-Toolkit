<%@ Page Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true"
    CodeFile="Function_Add.aspx.cs" Inherits="Administration_Function_Add" Title="Add Function" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor="#FFFFFF"
        style="background-image: url(../images/bg.jpg); background-repeat: repeat-x;
        padding-left: 10px;">
        <tr>
            <td height="40" style="width: 34px">
                <img src="../images/arrow.GIF" width="13" height="15" align="absmiddle" style="padding-left: 15px" /></td>
            <td width="600" align="left">
                <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                    &gt;&gt;<%=(ViewState["Links"].ToString().Split('|')[4])%></strong></td>
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
            <td colspan="3">
                <table id="Table1" width="100%" border="0" class="adminPanel">
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblError" runat="server" CssClass="warnings" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left">
                            <asp:Label ID="lblmandatory" runat="server" CssClass="warnings" Text="(Fields marked '*' are compulsory)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" style="height: 35px" align="left">
                            Function ID<span style="color: #ff0000">*</span></td>
                        <td class="formlabel" style="width: 1%; height: 35px;">
                            :</td>
                        <td width="30%" style="height: 35px" align="left">
                            &nbsp;<asp:TextBox ID="Txt_Function_Id" runat="server" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Requiredfieldvalidator1" runat="server" CssClass="warnings" ControlToValidate="Txt_Function_Id"
                                InitialValue="">*</asp:RequiredFieldValidator></td>
                        <td class="formlabel" width="20%" style="height: 35px" align="left">
                            Parent Menu<span style="color: #ff0000">*<font color="#ff0000"></font></span></td>
                        <td class="formlabel" style="width: 1%; height: 35px;">
                            :</td>
                        <td width="30%" style="height: 35px" align="left">
                            &nbsp;<asp:DropDownList ID="Lst_Parent_Menu" runat="server">
                            </asp:DropDownList><asp:RequiredFieldValidator ID="rfvlistparent" runat="server"
                                CssClass="warnings" ControlToValidate="Lst_Parent_Menu" InitialValue="0">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            Description<span style="color: #ff0000">*</span></td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td nowrap width="30%" height="3" align="left">
                            &nbsp;<asp:TextBox ID="Txt_Description" runat="server" MaxLength="40"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Req_Vldtr_Desc" runat="server" CssClass="warnings" ControlToValidate="Txt_Description"
                                InitialValue="">*</asp:RequiredFieldValidator></td>
                        <td class="formlabel" nowrap width="20%" height="3" align="left">
                            Short Description<span style="color: #ff0000">*<font color="#ff0000"></font></span></td>
                        <td class="formlabel" height="3" nowrap="nowrap" style="width: 1%">
                            :</td>
                        <td nowrap width="30%" height="3" align="left">
                            &nbsp;<asp:TextBox ID="Txt_Short_Desc" runat="server" MaxLength="40"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Requiredfieldvalidator2" runat="server" CssClass="warnings" ControlToValidate="Txt_Short_Desc"
                                InitialValue="">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            Page Size<span style="color: #ff0000">*</span></td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td width="30%" colspan="4" height="3" align="left">
                            &nbsp;<asp:TextBox ID="txt_Page_Size" runat="server" MaxLength="2" Width="55px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Page_Size"
                                InitialValue="">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            Search URL<font color="#ff0000"></font></td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td width="30%" colspan="4" height="3" align="left">
                            &nbsp;<asp:TextBox ID="Txt_Search_URL" runat="server" MaxLength="70" Width="400px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            New URL<font color="#ff0000"></font></td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td width="30%" colspan="4" height="3" align="left">
                            &nbsp;<asp:TextBox ID="Txt_New_URL" runat="server" MaxLength="70" Width="400px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            Edit URL</td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td width="30%" colspan="4" height="3" align="left">
                            &nbsp;<asp:TextBox ID="Txt_Edit_URL" runat="server" MaxLength="70" Width="400px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            Default Page</td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td width="30%" colspan="4" height="3" align="left">
                            &nbsp;<asp:RadioButton ID="Rad_Search" runat="server" GroupName="Rad_Default_Page"
                                Text="Search"></asp:RadioButton>&nbsp;&nbsp;
                            <asp:RadioButton ID="Rad_New" runat="server" GroupName="Rad_Default_Page" Text="New"
                                Checked="True"></asp:RadioButton></td>
                    </tr>
                    <tr>
                        <td class="formlabel" width="20%" height="3" align="left">
                            Sort Sequence in menu<span style="color: #ff0000">*</span></td>
                        <td class="formlabel" height="3" style="width: 1%">
                            :</td>
                        <td width="30%" colspan="4" height="3" align="left">
                            &nbsp;<asp:TextBox ID="Txt_Sort_Seq" runat="server" MaxLength="3" Width="30px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Requiredfieldvalidator4" runat="server" CssClass="warnings" ControlToValidate="Txt_Sort_Seq"
                                InitialValue="">*</asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator2"
                                    runat="server" ControlToValidate="Txt_Sort_Seq" MaximumValue="999" MinimumValue="1"
                                    Type="Integer" ErrorMessage="Enter numerics only" ForeColor="#ff6633">Enter numerics only</asp:RangeValidator></td>
                    </tr>
                    <tr>
                        <td colspan="6" align="left">
                            <table cellspacing="4">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="Btn_Save" ImageUrl="~/images/save.jpg" runat="server" CausesValidation="true"
                                            OnClick="Btn_Save_Click"></asp:ImageButton></td>
                                    <td>
                                        <asp:ImageButton ID="Btn_Clear" ImageUrl="~/images/clear.jpg" runat="server" CausesValidation="False"
                                            OnClick="Btn_Clear_Click"></asp:ImageButton></td>
                                    <td>
                                        <%--<asp:ImageButton ID="Btn_Search" runat="server" ImageUrl="~/images/back.jpg"
                                            CausesValidation="False" OnClick="Btn_Search_Click"></asp:ImageButton>--%>
                                            
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
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>
