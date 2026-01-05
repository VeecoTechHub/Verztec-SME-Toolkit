<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="TrafficAnalysis_DetailedReportDL.aspx.cs" Inherits="Administration_TrafficAnalysis_DetailedReportDL" %>

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
                            Name
                        </td>
                        <td class="formlabel" style="width: 1">
                            :
                        </td>
                        <td style="width:  370px">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="200px" ></asp:TextBox>
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
                            Page Size&nbsp;
                        </td>
                        <td class="formlabel" nowrap="nowrap" style="width: 1px">
                            :
                        </td>
                        <td width="370px" colspan="1">
                            <asp:TextBox ID="Txt_Page_Size" runat="server" MaxLength="2" Width="55px" Columns="3"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbePageSize" runat="server" FilterType="Numbers"
                                TargetControlID="Txt_Page_Size">
                            </cc1:FilteredTextBoxExtender>
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
                            <asp:ImageButton ID="Button_Go" runat="server" ImageUrl="~/images/search.jpg"  />
                          
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
            <td style="width: 70%; height: 30px;" runat="server" id="tdSelect">
                <br />
                <%--<input id="ChkAll" onclick="javascript:SelectAllCheckBoxes_New(this);" runat="server"
                    type="checkbox" class="formlabel" />
                Select/De-select All--%>
            </td>
            <td align="right" style="height: 30px">
                <asp:ImageButton ID="btnExptoExcel" runat="server" ImageUrl="~/images/Export_Excel.gif" Visible="false"
                    />
         
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataList ID="id_datalist" runat="server" CellPadding="0" CellSpacing="0" 
                                            align="center" onitemdatabound="id_datalist_ItemDataBound"  >
                                            <ItemTemplate>
                                              <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Id")%>' />
                                                <table border="0" align="center" cellpadding="0" cellspacing="0" Width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvTrafficAnalysis" runat="server" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="true" GridLines="Both" Width="100%"
                                                                CellPadding="1" BorderColor="Black" AllowSorting="True" OnRowDataBound="gvTrafficAnalysis_RowDataBound" >
                                                             
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Industry" HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="120" BackColor=""></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_IndustryName" runat="server" Text='<%#Eval("INDUSTRYNAME") %>'></asp:Label></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="120" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="160"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NAME") %>'></asp:Label></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="160"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Company Name"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="250"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Company" runat="server" Text='<%#Eval("COMPANYNM") %>'></asp:Label></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="250"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Business Started In"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_BusinessStartedIn" runat="server" Text='<%#Eval("BUSSSTARTEDYEAR") %>'></asp:Label></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No Of Employees"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_NoOfEmployees" runat="server" Text='<%#Eval("NOOFEMPLOYEES") %>'></asp:Label></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email Address"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Email" runat="server" Text='<%#Eval("EMAILID") %>'></asp:Label></ItemTemplate>
                                                                             <FooterTemplate>
                                                                            <asp:Label ID="lblSubTotal" runat="server" Text="Sub Total" />
                                                                        </FooterTemplate>
                                                                        <FooterStyle Font-Bold="true" />
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Resource Library" HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Resourcelibrary" runat="server" Text='<%#Eval("RESOURCELIBRARY") %>'></asp:Label></ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotalR" runat="server" />
                                                                        </FooterTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Business Profiling"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_BusinessProfiling" runat="server" Text='<%#Eval("BUSINESSPROFILING") %>'></asp:Label></ItemTemplate>
                                                                          <FooterTemplate>
                                                                            <asp:Label ID="lblTotalBP" runat="server" />
                                                                        </FooterTemplate>
                                                                        
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        
                                                                        
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Capabilities Profiling"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_CapabilitiesProfiling" runat="server" Text='<%#Eval("CAPABILITIESPROFILING") %>'></asp:Label></ItemTemplate>
                                                                           <FooterTemplate>
                                                                            <asp:Label ID="lblTotalCP" runat="server" />
                                                                        </FooterTemplate>
                                                                       
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Financial Modeling"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_FinancialModeling" runat="server" Text='<%#Eval("FINANCIALMODELING") %>'></asp:Label></ItemTemplate>
                                                                         <FooterTemplate>
                                                                            <asp:Label ID="lblTotalFM" runat="server" />
                                                                        </FooterTemplate>
                                                                      
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Learn More"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_LearnMore" runat="server" Text='<%#Eval("LEARNMORE") %>'></asp:Label></ItemTemplate>
                                                                           <FooterTemplate>
                                                                            <asp:Label ID="lblTotalLM" runat="server" />
                                                                        </FooterTemplate>
                                                                       
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Faqs OnlineHelp"  HeaderStyle-Font-Size="Small">
                                                                        <HeaderStyle ForeColor="Black" Width="80"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Faqs" runat="server" Text='<%#Eval("FAQSONLINEHELP") %>'></asp:Label></ItemTemplate>
                                                                            <FooterTemplate>
                                                                            <asp:Label ID="lblTotalFaq" runat="server" />
                                                                        </FooterTemplate>
                                                                       
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Total"  >
                                                                        <HeaderStyle ForeColor="Black" ></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Total" runat="server"></asp:Label></ItemTemplate>
                                                                              <FooterTemplate>
                                                                            <asp:Label ID="lblTotalFooter" runat="server" />
                                                                        </FooterTemplate>
                                                                        <HeaderStyle HorizontalAlign="left"  />
                                                                        <ItemStyle HorizontalAlign="left" Width="80" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="left" Width="80"/>
                                                                    </asp:TemplateField>
                                                                    
                                                                </Columns>
                                                                 <FooterStyle BackColor="#838B83"  ForeColor="White" HorizontalAlign="Left" />
                                                                                                                    
                                                                <PagerSettings Mode="Numeric" />
                                                            </asp:GridView>
                                                          
                                                        </td>
                                                    </tr>
                                                 
                                                </table>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td  style="height:30px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </SeparatorTemplate>
                                        </asp:DataList>
            </td>
        </tr>
          <tr>
        
        <td>
           <table style="background-color:#BEBEBE; font-weight:bold" width="1000" >
           
           <tr >
           <td width="300px" align="left">
           
               &nbsp;</td>
           <td width="150px" align="left">
          TOTAL - Hit-times :
           
           </td>
           <td width="60px" align="center"><asp:Label ID="Label1" runat="server"></asp:Label></td>
           <td width="60px" align="center"><asp:Label ID="Label2" runat="server"></asp:Label></td>
           <td width="60px" align="center"><asp:Label ID="Label3" runat="server"></asp:Label></td>
           <td width="60px" align="center"><asp:Label ID="Label4" runat="server"></asp:Label></td>
           <td width="60px" align="center"><asp:Label ID="Label5" runat="server"></asp:Label></td>
           <td width="60px" align="center"><asp:Label ID="Label6" runat="server"></asp:Label></td>
           <td width="60px" align="center"><asp:Label ID="Label7" runat="server"></asp:Label></td>
           </tr>
           </table>
        </td>
    </tr>
    </table>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
    </table>
</asp:Content>

