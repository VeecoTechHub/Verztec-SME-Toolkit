<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TradeCycle.ascx.cs" Inherits="UserControls_TradeCycle" %>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="680">
                <tr>
                    <td class="appendix">
                        <asp:Label ID="lblHeading" runat="server" Text="Appendix A - Financial Statements"
                            meta:resourcekey="lblHeadingResource1"></asp:Label>
                        <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/appendixbar.png" />--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" valign="bottom">
            <h3>
                <asp:Label ID="lblIncomeStatement" runat="server" Text="Income Statement" meta:resourcekey="lblIncomeStatementResource1"></asp:Label>
            </h3>
        </td>
    </tr>
    <tr>
        <td width="680px">
            <asp:GridView ID="gvIncomeReport" runat="server" AutoGenerateColumns="False" CssClass="gridStyle"
                GridLines="None" OnRowDataBound="gvIncomeReport_RowDataBound" CellPadding="4"
                Width="680px" meta:resourcekey="gvIncomeReportResource1" 
                EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%# Eval("FsMappingName") %>'
                                meta:resourcekey="lblFsMappingNameResource1"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left" Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Value" runat="server" Text='<%# Eval("C_Value") %>' meta:resourcekey="lbl_C_ValueResource1"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center"  HeaderText="% of Sale" meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Percent" runat="server" Text='<%# Eval("C_Percent") %>' meta:resourcekey="lbl_C_PercentResource1"></asp:Label>%</ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource4">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Value" runat="server" Text='<%# Eval("P1_Value") %>' meta:resourcekey="lbl_P1_ValueResource1"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="% of Sale" meta:resourcekey="TemplateFieldResource5">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%# Eval("P1_Percent") %>' meta:resourcekey="lbl_P1_PercentResource1"></asp:Label>%</ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource6">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Value" runat="server" Text='<%# Eval("P2_Value") %>' meta:resourcekey="lbl_P2_ValueResource1"></asp:Label></ItemTemplate>
                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="% of Sale" meta:resourcekey="TemplateFieldResource7">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%# Eval("P2_Percent") %>' meta:resourcekey="lbl_P2_PercentResource1"></asp:Label>%</ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource8">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Value" runat="server" Text='<%# Eval("P3_Value") %>' meta:resourcekey="lbl_P3_ValueResource1"></asp:Label></ItemTemplate>
                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="% of Sale" meta:resourcekey="TemplateFieldResource9">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%# Eval("P3_Percent") %>' meta:resourcekey="lbl_P3_PercentResource1"></asp:Label>%</ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#376091" ForeColor="White" Height="5" />
            </asp:GridView>
        </td>
    </tr>
    <%-- <tr>
        <td align="left" valign="bottom">
            <h3>
                Balance Sheet</h3>
        </td>
    </tr>
    <tr>
        <td class="FontStyle" width="680px">
            <asp:GridView ID="gvBalanceReport" runat="server" ShowHeader="true" CellPadding="4"
                AutoGenerateColumns="false" CssClass="gridStyle" GridLines="None" OnRowDataBound="gvBalanceReport_RowDataBound"
                Width="680px">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="320px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Value" runat="server" Text='<%#Eval("C_Value")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                 
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
              
              
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                
               
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
               
                </Columns>
                <HeaderStyle BackColor="#376091" ForeColor="White" Height="5" />
            </asp:GridView>
        </td>
    </tr>--%>
    <tr id="HideTR1" runat="server">
        <td style="height: 410px">
            &nbsp;
            <asp:Label ID="lblfy" runat="server" Visible="False" 
                meta:resourcekey="lblfyResource1"></asp:Label>
            <asp:Label ID="lblActual" runat="server" Visible="False" 
                meta:resourcekey="lblActualResource1"></asp:Label>
            <asp:Label ID="lblEstimates" runat="server" Visible="False" 
                meta:resourcekey="lblEstimatesResource1"></asp:Label>
        </td>
    </tr>
    <tr id="HideTR2" runat="server">
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr style="page-break-before: always;">
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" valign="bottom">
            <h3>
                <asp:Label ID="lblCashFlowAnalysis" runat="server" Text="Cash Flow Analysis" meta:resourcekey="lblCashFlowAnalysisResource1"></asp:Label>
            </h3>
        </td>
    </tr>
    <tr>
        <td class="FontStyle" width="680px" style="page-break-inside: avoid">
            <asp:GridView ID="gvCashFlowAnalysisReport" runat="server" CellPadding="4" AutoGenerateColumns="False"
                CssClass="gridStyle" GridLines="None" OnRowDataBound="gvCashFlowAnalysisReport_RowDataBound"
                Width="680px" meta:resourcekey="gvCashFlowAnalysisReportResource1" 
                EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource10">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%# Eval("FsMappingName") %>'
                                meta:resourcekey="lblFsMappingNameResource2"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left" Width="220px" />
                    </asp:TemplateField>
                    <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Value" runat="server" Text='<%#Eval("C_Value")%>'></asp:Label>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>--%>
                    <%--        <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Percent" runat="server" Text='<%#Eval("C_Percent")%>'></asp:Label></ItemTemplate>
                        
                       <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource11">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Value" runat="server" Text='<%# Eval("P1_Value") %>' meta:resourcekey="lbl_P1_ValueResource2"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="180px" />
                    </asp:TemplateField>
                    <%--    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label></ItemTemplate>
                        
                          <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource12">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Value" runat="server" Text='<%# Eval("P2_Value") %>' meta:resourcekey="lbl_P2_ValueResource2"></asp:Label></ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="180px" />
                    </asp:TemplateField>
                    <%--    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent")%>'></asp:Label></ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource13">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Value" runat="server" Text='<%# Eval("P3_Value") %>' meta:resourcekey="lbl_P3_ValueResource2"></asp:Label></ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="center" Width="180px" />
                    </asp:TemplateField>
                    <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent")%>'></asp:Label></ItemTemplate>
                        
                         <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                </Columns>
                <HeaderStyle BackColor="#376091" ForeColor="White" Height="5" />
            </asp:GridView>
            <asp:Label ID="lblFake1" runat="server" Visible="False" 
                meta:resourcekey="lblFake1Resource1"></asp:Label>
            <asp:Label ID="lblFake2" runat="server" Visible="False" 
                meta:resourcekey="lblFake2Resource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td height="5">
            &nbsp;
        </td>
    </tr>
</table>
