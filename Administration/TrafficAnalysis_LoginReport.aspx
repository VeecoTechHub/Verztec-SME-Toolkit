<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="TrafficAnalysis_LoginReport.aspx.cs" Inherits="Administration_TrafficAnalysis_LoginReport" %>

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
                        <td class="formlabel" style="width:  200px">
                            Industry
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width:  370px">
                          <asp:DropDownList ID="ddlIndustry" runat="server" Width="200px" AppendDataBoundItems="true">
                         <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                         </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width:  200px">
                            Start Date
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <cc2:GMDatePicker ID="DatePicker_StartDate" readonly="true" DateFormat="dd/MMM/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="formlabel" style="width: 200px">
                            End Date
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <cc2:GMDatePicker ID="DatePicker_EndDate" readonly="true" DateFormat="dd/MMM/yyyy"
                                InitialValueMode="Null" runat="server" CalendarTheme="Blue">
                            </cc2:GMDatePicker>
                        </td>
                    </tr>
                     <tr>
                        <td class="formlabel" style="width: 200px">
                            Language
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width: 370px">
                            <asp:DropDownList ID="ddlCulture" runat="server" Width="125px">
                                <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="English" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Chinese" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td nowrap="nowrap" style="width: 1px">
                        </td>
                        <td colspan="1"  width="370px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td style="width: 1px">
                        </td>
                        <td colspan="1" height="3" style="width: 370px">
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg" 
                                onclick="Button_Go_Click"  />
                          
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
       <table style="width: 70%;">
        <tr>
            <td style="width: 70%;" align="left" valign="middle">
                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="true" CssClass="warnings">Records Not Found</asp:Label>
            </td>
            <td align="right" valign="bottom">
            </td>
        </tr>
        <tr>
            <td style="width: 800px; height: 30px;" runat="server" id="tdSelect" align="right">
               <asp:ImageButton ID="btnExptoExcel" runat="server" 
                    ImageUrl="~/images/Export_Excel.gif" Visible="false" 
                    onclick="btnExptoExcel_Click" style="height: 21px"
                    />
                <%--<input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                    type="checkbox" class="formlabel" />
                Select/De-select All--%>
            </td>
            <td align="left" style="height: 30px">
              
         &nbsp;
            </td>
        </tr>
        <tr>           
             
            <td style="width: 800px" align="right" >
                       <asp:GridView ID="gvTrafficAnalysisLogin" Width="800px" runat="server" ShowFooter="true" 
                          AutoGenerateColumns="False"
                    CellPadding="1" BorderColor="Black" AllowSorting="True" CaptionAlign="Top" 
                           onrowdatabound="gvTrafficAnalysisLogin_RowDataBound" >
                    <HeaderStyle CssClass="tableHeading"></HeaderStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Industry">
                            <HeaderStyle ForeColor="Black" Width="200"  Font-Bold="true"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_IndustryName" runat="server" Text='<%#Eval("IndustryName") %>'></asp:Label></ItemTemplate>
                                  <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="Total" />
                            </FooterTemplate>
                          <FooterStyle Font-Bold="true" HorizontalAlign="Right"/>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="New Users">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_NewUsers" runat="server" Text='<%#Eval("NewUsers") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblNewUsers" runat="server" />
                            </FooterTemplate>
                             <FooterStyle Font-Bold="true" HorizontalAlign="Right" CssClass="gvItems"/>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Right"  CssClass="gvItems"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Users">
                            <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbl_TotalUsers" runat="server" Text='<%#Eval("TotalUsers") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUsers" runat="server" />
                            </FooterTemplate>
                             <FooterStyle Font-Bold="true" HorizontalAlign="Right" CssClass="gvItems"/>
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Right" CssClass="gvItems"/>
                        </asp:TemplateField>
                 
                    </Columns>
                      <FooterStyle BackColor="#838B83"  ForeColor="White" HorizontalAlign="Left" Font-Bold="true" />
                    <RowStyle CssClass="menu_admin" />
                    <PagerStyle Font-Bold="True" CssClass="tableHeading"></PagerStyle>
                    <PagerSettings Mode="Numeric" />
                </asp:GridView>
             
            </td>
            
            <td >
            &nbsp;
            </td>
        </tr>
         
       
          <tr>
            <td style=" height:30px" >               
            </td>
           
        </tr>
         
        </table>
        

</asp:Content>

