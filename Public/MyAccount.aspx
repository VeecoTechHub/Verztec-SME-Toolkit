<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="Public_MyAccount" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="865" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="279" height="30">
                        <asp:Label ID="lblYourEmail" runat="server" Text="Your Email" 
                                meta:resourcekey="lblYourEmailResource1"></asp:Label>
                            
                        </td>
                        <td align="left" width="551">
                            <table>
                                <tr>
                                    <td width="220px">
                                        <asp:TextBox ID="txtEmail" runat="server" Style="width: 180px;" MaxLength="100" 
                                            Enabled="False" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Email" 
                                            CssClass="Mandatory" meta:resourcekey="valEmailResource1" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkbtnChangePassword" runat="server" 
                                            PostBackUrl="~/Public/ChangePassword.aspx" Text="Change Password"
                                            CausesValidation="False" meta:resourcekey="lnkbtnChangePasswordResource1"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="279" height="3">
                        </td>
                        <td align="left" width="551">
                            <asp:CheckBox ID="chbPwd" runat="server" Text="Change Password" Visible="False" OnCheckedChanged="chbPwd_CheckedChanged"
                                AutoPostBack="True" meta:resourcekey="chbPwdResource1" />
                        </td>
                    </tr>
                    <tr id="trPwd" runat="server" visible="False">
                        <td align="left" width="279" height="30" runat="server">
                            <asp:Label ID="lblNewPwd" runat="server" Text="New Password &amp; Retype Password"></asp:Label>
                        </td>
                        <td align="left" width="551" runat="server">
                            <asp:TextBox ID="txtPassword" runat="server" Style="width: 83px; height: 19px;" TextMode="Password"
                                MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword"
                                Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory" />
                            <asp:TextBox ID="txtRePassword" runat="server" Style="width: 83px; height: 19px;"
                                TextMode="Password" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valRePassword" runat="server" ControlToValidate="txtRePassword"
                                Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Password" CssClass="Mandatory" />
                            <asp:CompareValidator ID="ValConPwdCompare" runat="server" ErrorMessage="*" ControlToValidate="txtRePassword"
                                ControlToCompare="txtPassword" Display="Dynamic" ToolTip="Password and Confirm Password must match"
                                CssClass="Mandatory"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                           <asp:Label ID="lblYourName" runat="server" Text="Your Name" 
                                meta:resourcekey="lblYourNameResource1"></asp:Label>
                            
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" Style="width: 87px;" MaxLength="100" 
                                meta:resourcekey="txtNameResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valName1" runat="server" ControlToValidate="txtName"
                                Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Name" 
                                CssClass="Mandatory" meta:resourcekey="valName1Resource1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                           <asp:Label ID="lblBusiness" runat="server" Text="Business or Company Name" 
                                meta:resourcekey="lblBusinessResource1"></asp:Label>
                            
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCompanyNm" runat="server" Style="width: 180px;" 
                                MaxLength="100" meta:resourcekey="txtCompanyNmResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valCompanyNm" runat="server" ControlToValidate="txtCompanyNm"
                                Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Company Name" 
                                CssClass="Mandatory" meta:resourcekey="valCompanyNmResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                           <asp:Label ID="lblIndustry" runat="server" Text="Industry" 
                                meta:resourcekey="lblIndustryResource1"></asp:Label>
                            
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlIndustry" runat="server" Style="width: 185px;" 
                                meta:resourcekey="ddlIndustryResource1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valIndustry" runat="server" ControlToValidate="ddlIndustry"
                                Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Industry" InitialValue="0"
                                CssClass="Mandatory" meta:resourcekey="valIndustryResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                           <asp:Label ID="lblBusinessStarted" runat="server" Text="Business Started In" 
                                meta:resourcekey="lblBusinessStartedResource1"></asp:Label>
                            
                        </td>
                        <td align="left">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlYear" runat="server" Style="width: 90px;" 
                                meta:resourcekey="ddlYearResource1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valYear" runat="server" ControlToValidate="ddlYear"
                                InitialValue="0" Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a Year"
                                CssClass="Mandatory" meta:resourcekey="valYearResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                          <asp:Label ID="lblNoOfEmp" runat="server" Text="Number of Employees" 
                                meta:resourcekey="lblNoOfEmpResource1"></asp:Label>
                            
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNoofEmps" runat="server" Style="width: 87px;" onkeypress="return onlyNumbers();"
                                onpaste="return false" MaxLength="15" 
                                meta:resourcekey="txtNoofEmpsResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valNoofEmps" runat="server" ControlToValidate="txtNoofEmps"
                                Display="Dynamic" ErrorMessage="*" ToolTip="You must enter a No of Employees"
                                CssClass="Mandatory" meta:resourcekey="valNoofEmpsResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" height="50">
                            &nbsp;
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="orange_button" 
                                OnClick="btnUpdate_Click" meta:resourcekey="btnUpdateResource1" />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                                class="orange_button" OnClick="btnCancel_Click" 
                                meta:resourcekey="btnCancelResource1" />
                            <asp:Label ID="lblDes1" runat="server" Visible="False" 
                                meta:resourcekey="lblDes1Resource1"></asp:Label>
                            <asp:Label ID="lblDes2" runat="server" Visible="False" 
                                meta:resourcekey="lblDes2Resource1"></asp:Label>

                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript" language="javascript">

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>

</asp:Content>
