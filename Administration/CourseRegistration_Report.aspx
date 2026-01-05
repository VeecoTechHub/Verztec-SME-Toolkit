<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="CourseRegistration_Report.aspx.cs" Inherits="Administration_CourseRegistration_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table id="Table3" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="background-image: url(../images/bg.jpg);
        background-repeat: repeat-x; padding-left: 10px;">
        <tr>
            <td width="20" height="40" align="left">
                <img src="../images/arrow.GIF" align="absmiddle" style="padding-left: 5px" />
            </td>
            <td width="600" align="left">
                <strong class="blue">
                    <%=(ViewState["Links"].ToString().Split('|')[3])%>
                    &gt;&gt;
                    <%=(ViewState["Links"].ToString().Split('|')[4])%>
                </strong>
            </td>
            <td width="199" align="left" valign="middle">
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
         <table id="Table1" width="770px" align="left" border="0" cellpadding="3">
                     <tr>
                        <td class="formlabel" style="width: 200px">
                           Title
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                        <asp:TextBox ID="txtTitle" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            Page Size&nbsp;
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1px">
                            :
                        </td>
                        <td colspan="1" style="width: 370px">
                            <asp:TextBox ID="Txt_Page_Size" runat="server" MaxLength="2" Width="55px" Columns="3" ></asp:TextBox>
                            <cc1:filteredtextboxextender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="Txt_Page_Size">
                            </cc1:filteredtextboxextender>                           

                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 200px">
                        </td>
                        <td  nowrap="nowrap" style="width: 1px">
                        </td>
                        <td colspan="1"  width="370px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td style="width: 1px">
                        </td>
                        <td colspan="1" height="3" width="370px">
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" OnClick="Button_Go_Click" />                               
                            </asp:ImageButton>
                        </td>
                    </tr>                    
                    </table>       
        
        </td>        
        </tr>

      </table>
         
            <table>
                <tr>
                    <td style="width: 70%;" align="left" valign="middle">
                        <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="true" CssClass="warnings">Records Not Found</asp:Label>
                    </td>
                    <td align="right" valign="bottom">
                    </td>
                </tr>
                <tr>
                    <td style="width: 70%;"  runat="server" id="tdSelect">       <br />
                       
                        <input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                                                        type="checkbox" class="formlabel" />
                                        Select/De-select All
                    </td>
                    <td align="right">
                      <asp:ImageButton ID="btnExptoExcel" runat="server" ImageUrl="~/images/Export_Excel.gif" 
                            onclick="btnExptoExcel_Click" />                               
                      </asp:ImageButton>
                    </td>
                
                </tr>
                <tr>
                    <td colspan="2">                
                        <asp:DataGrid ID="DG_CourseRegs" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                            CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" OnItemCreated="DG_CourseRegs_ItemCreated"
                             OnPageIndexChanged="DG_CourseRegs_PageIndexChanged" >
                           
                            <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Select">
                                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" name="Cbx_uid" value='<%#DataBinder.Eval(Container.DataItem, "UserID")%>'>
                                    </ItemTemplate>
                                </asp:TemplateColumn>                              
                                  <asp:TemplateColumn  HeaderText="Title">
                                    <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Category_Title") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn> 
                                       <asp:TemplateColumn  HeaderText="Duration From">
                                    <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Duration_From") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn>    
                                   <asp:TemplateColumn  HeaderText="Duration To">
                                    <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Duration_To") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn>        
                                <asp:TemplateColumn  HeaderText="Name">
                                    <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn>                      
                                <asp:TemplateColumn  HeaderText="NRIC/ID No">
                                    <HeaderStyle ForeColor="Black" Width="120"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_NRIC_ID_No" runat="server" Text='<%#Eval("NRIC_ID_Number") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn>
                                  <asp:TemplateColumn  HeaderText="Contact Number">
                                    <HeaderStyle ForeColor="Black" Width="100"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Contact_No" runat="server" Text='<%#Eval("Contact_Number") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="Email">
                                    <HeaderStyle ForeColor="Black" Width="220"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_EmailId" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateColumn>             

                               
                            </Columns>
                            <ItemStyle CssClass="menu_admin" />
                            <PagerStyle Font-Bold="True" CssClass="tableHeading" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                    </td>
                </tr>
                <tr style="display: none;">
                <td colspan="2">                
                <asp:GridView ID="gvExport" runat="server" 
                        AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="category_Title" HeaderText="Title" />
                        <asp:BoundField DataField="Duration_From" HeaderText="Duration From" />
                        <asp:BoundField DataField="Duration_To" HeaderText="Duration To" />
                         <asp:BoundField DataField="Name" HeaderText="Name" />
                         <asp:BoundField DataField="NRIC_ID_Number" HeaderText="NRIC/ID No" />
                         <asp:BoundField DataField="Contact_Number" HeaderText="Contact Number" />
                         <asp:BoundField DataField="EmailID" HeaderText="Email" />
                    </Columns>
                </asp:GridView>
                </td></tr>
                <tr>
                    <td style="width: 50%">
                        <asp:ImageButton ImageUrl="~/images/delete.jpg" ID="id_btn_Delete" runat="server"
                            Text="Delete"  OnClientClick="return confirm('Are you sure you want to delete this User');"  OnClick="id_btn_Delete_Click"
                           >
                           </asp:ImageButton>
                    </td>
                    <td align="right" style="font-weight: bold">
                        <asp:Label ID="Lbl_Pageinfo" runat="server" Visible="False" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
            </table>






</asp:Content>