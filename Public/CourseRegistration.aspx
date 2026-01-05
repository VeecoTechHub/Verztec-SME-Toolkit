<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="Public_CourseRegistration" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" height="33" valign="middle" class="steps_title" valign="top">
                    <div>                   
                        Course Registration
                    </div>
                </td>
            </tr>
        </table>
        <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">

         <tr>
                <td align="left" height="30">
                    Title
                </td>
                <td align="left" colspan="2"> 
              <asp:Label ID="lblCourseTitle" runat="server" Style="width: 250px;"></asp:Label>
                   
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    Duration From
                </td>
                <td align="left" colspan="2">  
                <asp:Label ID="lbl_DurationFrom" runat="server"></asp:Label>                 
                    
                </td>
            </tr> 
                 <tr>
                <td align="left" height="30">
                    Duration To
                </td>
                <td align="left" colspan="2"> 
                <asp:Label ID="lbl_DurationTo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" height="30">
                    Name<span style="color: red">*</span>
                </td>
                <td align="left" colspan="2">                   
                    <asp:TextBox ID="txtName" runat="server" Style="width: 150px;" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valName1" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Name" CssClass="Mandatory" />
                </td>
            </tr>
            <tr>
                <td align="left" width="150" height="30">
                    Email<span style="color: red">*</span>
                </td>
                <td align="left" width="800">
                    <asp:TextBox ID="txtEmail" runat="server" Style="width: 250px;" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" CssClass="Mandatory" />
                    <asp:RegularExpressionValidator ID="valEmailValidation" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z0-9._%-]{2,4}$"
                        Display="Dynamic" ErrorMessage="You must enter a valid e-mail address" ToolTip="You must enter a valid e-mail address" CssClass="Mandatory" />
                </td>              
            </tr>
             <tr>
                <td align="left" height="30">
                    NRIC/ID no.<span style="color: red">*</span>
                </td>
                <td align="left" colspan="2">                   
                    <asp:TextBox ID="txtNRICNo" runat="server" Style="width: 150px;" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNricNo" runat="server" ControlToValidate="txtNRICNo"
                        Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a NRIC No." CssClass="Mandatory" />
                </td>
            </tr>
             <tr>
                <td align="left" height="30">
                    Contact Number<span style="color: red">*</span>
                </td>
                <td align="left" colspan="2">                   
                    <asp:TextBox ID="txtContactNumber" runat="server" Style="width: 150px;" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtContactNumber"
                        Display="Dynamic" ErrorMessage="*"  CssClass="Mandatory" />
                </td>
            </tr>
            <tr>
                <td height="10" colspan="3">
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" height="50" colspan="2">
                    &nbsp;
                    <asp:Button ID="btnRegister" runat="server" Text="Register" class="orange_button"
                        OnClick="btnRegister_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="orange_button" 
                        CausesValidation="false" onclick="btnCancel_Click"  />
                   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

