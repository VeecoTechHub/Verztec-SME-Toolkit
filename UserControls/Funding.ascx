<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Funding.ascx.cs" Inherits="UserControls_Funding" %>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px">
  <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="funding">
            <asp:Label ID="lblHeading" runat="server" 
                Text="Business Owner's Fund Vs Bank Financing" 
                meta:resourcekey="lblHeadingResource1"></asp:Label>
        
            <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/fundingbar.png" />--%>
        </td>
    </tr>
   
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
    <td  class="FontStyle">
    <asp:Localize ID="locPara1" runat="server" 
            Text="
    If your business is partially funded by borrowings from financial institution/(s), it is important that
     you watch your gearing ratio that measures your business' reliance on bank loans." 
            meta:resourcekey="locPara1Resource1"></asp:Localize>									
							

    
    </td>
    </tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="gvReport" runat="server"  CssClass="gridStyle" Width="600px" GridLines="None"
                AutoGenerateColumns="False" onrowdatabound="gvReport_RowDataBound" 
                meta:resourcekey="gvReportResource1" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="left" 
                            meta:resourcekey="TemplateFieldResource1">
                            <ItemTemplate>
                                <asp:Label ID="lblFsMappingName" runat="server" 
                                    Text='<%# Eval("FsMappingName") %>' 
                                    meta:resourcekey="lblFsMappingNameResource1"></asp:Label>
                            </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                              <ItemStyle HorizontalAlign="left"  Width="300px"/>
                        </asp:TemplateField>
                      
                       
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" 
                            meta:resourcekey="TemplateFieldResource2" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Value" runat="server" Text='<%# Eval("P1_Value") %>' 
                                    meta:resourcekey="lbl_P1_ValueResource1"></asp:Label>
                            </ItemTemplate>
                        
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" 
                            meta:resourcekey="TemplateFieldResource3">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Value" runat="server" Text='<%# Eval("P2_Value") %>' 
                                    meta:resourcekey="lbl_P2_ValueResource1"></asp:Label></ItemTemplate>
                        
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" 
                            meta:resourcekey="TemplateFieldResource4">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Value" runat="server" Text='<%# Eval("P3_Value") %>' 
                                    meta:resourcekey="lbl_P3_ValueResource1"></asp:Label></ItemTemplate>                       

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:TemplateField>
                     
                    </Columns>
                    
                <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="3"/>
            </asp:GridView>
        </td>
    </tr>
    
       <tr>
        <td class="spacer">
            &nbsp;
            
    <asp:Label ID="lblfy" runat="server" Visible="False" meta:resourcekey="lblfyResource1"></asp:Label>
    <asp:Label ID="lblNil" runat="server" Visible="False" 
                meta:resourcekey="lblNilResource1"></asp:Label>

                  <asp:Label ID="lblFakeAdd" runat="server" Visible="False" meta:resourcekey="lblFakeAddResource1"></asp:Label>
        </td>
    </tr>
    <tr>
    <td  class="FontStyle">
    <asp:Localize ID="locPara2" runat="server" Text="
        Net Gearing Ratio refers to<br />
(A) the proportion of funding that is provided by bank(s) and/or financial institution(s) net of cash (assuming the cash
 can be applied to pay down the loan) <br />
RELATIVE TO<br />
(B) the funding provided by business owner(s) which includes past earnings and advances by the owner(s) to the business,
 net of past losses and advances taken out of the business by the owner(s)." 
            meta:resourcekey="locPara2Resource1"></asp:Localize>									
							

    </td>
    </tr>
    
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  class="FontStyle">
     <asp:Localize ID="locPara3" runat="server" Text="
 If the Net Gearing Ratio is <b><u>positive</u></b> amount, it means your business is funded by both share capital & past
  reserves and bank borrowings. For example, if the Net Gearing Ratio is 0.8 times, it means that for every $1 that the
   business owner(s) have invested in the business, the bank is providing $0.80 loan to the business. As a rule of thumb,
    unless you have good collaterals to pledge to the bank(s) and/or financial institution(s), a gearing ratio of below
     1 time is generally acceptable." meta:resourcekey="locPara3Resource1"></asp:Localize>			
    
    </td></tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  class="FontStyle">
     <asp:Localize ID="locPara4" runat="server" 
            Text="
   If the net gearing ratio is 'Nil', you either do not have bank loan or you have sufficient cash to make full settlement of the loan." 
            meta:resourcekey="locPara4Resource1"></asp:Localize>								

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  class="FontStyle">
     <asp:Localize ID="locPara5" runat="server" 
            Text="
 If the Net Gearing Ratio is <b><u>negative</u></b> amount, it means whatever sum you have injected into
  the business has been depleted and the bank(s) and/or financial institution(s) is the financier of your business. Your bank(s
   and/or financial institution(s) is likely to be very concerned and may take action to address the risk of default." 
            meta:resourcekey="locPara5Resource1"></asp:Localize>							
							
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    
</table>
