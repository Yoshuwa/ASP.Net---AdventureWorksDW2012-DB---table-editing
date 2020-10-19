<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimReseller" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimReseller.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimReseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Dim Reseller</h2>
            <div style="height: 10px"></div>
            <div style="text-align: center;">
                <div style="display: inline-block;">
                    <asp:DropDownList CssClass="input" ID="cmbFields" Width="150px" runat="server" CausesValidation="False"></asp:DropDownList>
                    <asp:DropDownList CssClass="input" ID="cmbCondition" Width="150px" runat="server" CausesValidation="False"></asp:DropDownList>
                    <asp:TextBox CssClass="input" ID="txtSearch" Width="100px" runat="server"></asp:TextBox>
                    <asp:Button ID="butSearch" Width="70px" Text="Search" runat="server" CausesValidation="False" OnClick="butSearch_Click"></asp:Button>
                    <asp:Button ID="butShowAll" Width="70px" Text="Show All" runat="server" CausesValidation="False" OnClick="butShowAll_Click"></asp:Button>
                </div>
            </div>
            <div style="height: 40px"></div>
            <div>
                <div style="float: left;">
                    <asp:DropDownList ID="ddlFile" Width="100px" runat="server" CssClass="input">
                        <asp:ListItem Value=".pdf">Pdf</asp:ListItem>
                        <asp:ListItem Value=".xls">Excel</asp:ListItem>
                        <asp:ListItem Value=".doc">Word</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnExport" Width="70px" runat="server" Text="Export" CausesValidation="False" OnClick="btnExport_Click"></asp:Button>
                </div>
                <div style="float: right;">
                    <asp:DropDownList CssClass="input" ID="cmbRecords" Width="100px" runat="server" CausesValidation="False"></asp:DropDownList>
                    <asp:Button ID="butRecords" Text="Records" Width="70px" runat="server" CausesValidation="False" OnClick="butRecords_Click"></asp:Button>
                </div>
            </div>
            <div style="height: 40px"></div>
        <%-------------------------------------%>
            <div style="text-align: center;">
                <div style="display: inline-block; overflow: auto;">
                <%-----
                    If GridView (grddbo_DimReseller) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_DimReseller" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ResellerKey" 
                        OnRowCancelingEdit="grddbo_DimReseller_RowCancelingEdit" OnRowDataBound="grddbo_DimReseller_RowDataBound" OnRowEditing="grddbo_DimReseller_RowEditing"
                        OnPageIndexChanging="grddbo_DimReseller_PageIndexChanging" OnSorting="grddbo_DimReseller_Sorting" 
                        OnRowUpdating="grddbo_DimReseller_RowUpdating" OnRowCommand="grddbo_DimReseller_RowCommand" OnRowDeleting="grddbo_DimReseller_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Reseller Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ResellerKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtResellerKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("ResellerKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewResellerKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblResellerKey" width="100px" runat="server" Text='<%# Eval("ResellerKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Geography Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="StateProvinceName">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtGeographyKey" width="100px" runat="server" CssClass="input" DataTextField="StateProvinceName" DataValueField="GeographyKey" BackColor="BlanchedAlmond"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="txtNewGeographyKey" width="100px" runat="server" CssClass="input" DataTextField="StateProvinceName" DataValueField="GeographyKey" BackColor="LightYellow"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGeographyKey" width="100px" runat="server" Text='<%# Eval("StateProvinceName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reseller Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ResellerAlternateKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtResellerAlternateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("ResellerAlternateKey") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewResellerAlternateKey" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblResellerAlternateKey" width="100px" runat="server" Text='<%# Eval("ResellerAlternateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="Phone">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPhone" width="100px" runat="server" CssClass="input" Text='<%# Eval("Phone") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewPhone" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" width="100px" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="BusinessType">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBusinessType" width="100px" runat="server" CssClass="input" Text='<%# Eval("BusinessType") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewBusinessType" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBusinessType" width="100px" runat="server" Text='<%# Eval("BusinessType") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reseller Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ResellerName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtResellerName" width="100px" runat="server" CssClass="input" Text='<%# Eval("ResellerName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewResellerName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblResellerName" width="100px" runat="server" Text='<%# Eval("ResellerName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number Employees" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="NumberEmployees">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNumberEmployees" width="100px" runat="server" CssClass="input" Text='<%# Eval("NumberEmployees") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewNumberEmployees" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNumberEmployees" width="100px" runat="server" Text='<%# Eval("NumberEmployees") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order Frequency" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="OrderFrequency">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtOrderFrequency" width="100px" runat="server" CssClass="input" Text='<%# Eval("OrderFrequency") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewOrderFrequency" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderFrequency" width="100px" runat="server" Text='<%# Eval("OrderFrequency") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order Month" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="OrderMonth">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtOrderMonth" width="100px" runat="server" CssClass="input" Text='<%# Eval("OrderMonth") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewOrderMonth" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderMonth" width="100px" runat="server" Text='<%# Eval("OrderMonth") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Order Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FirstOrderYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstOrderYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("FirstOrderYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFirstOrderYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstOrderYear" width="100px" runat="server" Text='<%# Eval("FirstOrderYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Order Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="LastOrderYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastOrderYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("LastOrderYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewLastOrderYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLastOrderYear" width="100px" runat="server" Text='<%# Eval("LastOrderYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Line" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ProductLine">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProductLine" width="100px" runat="server" CssClass="input" Text='<%# Eval("ProductLine") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewProductLine" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProductLine" width="100px" runat="server" Text='<%# Eval("ProductLine") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address Line1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="AddressLine1">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAddressLine1" width="100px" runat="server" CssClass="input" Text='<%# Eval("AddressLine1") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewAddressLine1" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAddressLine1" width="100px" runat="server" Text='<%# Eval("AddressLine1") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address Line2" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="AddressLine2">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAddressLine2" width="100px" runat="server" CssClass="input" Text='<%# Eval("AddressLine2") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewAddressLine2" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAddressLine2" width="100px" runat="server" Text='<%# Eval("AddressLine2") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Annual Sales" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="AnnualSales">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAnnualSales" width="100px" runat="server" CssClass="input" Text='<%# Eval("AnnualSales") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewAnnualSales" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAnnualSales" width="100px" runat="server" Text='<%# Eval("AnnualSales", "{0:C}") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="BankName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBankName" width="100px" runat="server" CssClass="input" Text='<%# Eval("BankName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewBankName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBankName" width="100px" runat="server" Text='<%# Eval("BankName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Min Payment Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MinPaymentType">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMinPaymentType" width="100px" runat="server" CssClass="input" Text='<%# Eval("MinPaymentType") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMinPaymentType" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMinPaymentType" width="100px" runat="server" Text='<%# Eval("MinPaymentType") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Min Payment Amount" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MinPaymentAmount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMinPaymentAmount" width="100px" runat="server" CssClass="input" Text='<%# Eval("MinPaymentAmount") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMinPaymentAmount" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMinPaymentAmount" width="100px" runat="server" Text='<%# Eval("MinPaymentAmount", "{0:C}") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Annual Revenue" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="AnnualRevenue">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAnnualRevenue" width="100px" runat="server" CssClass="input" Text='<%# Eval("AnnualRevenue") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewAnnualRevenue" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAnnualRevenue" width="100px" runat="server" Text='<%# Eval("AnnualRevenue", "{0:C}") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year Opened" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="YearOpened">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtYearOpened" width="100px" runat="server" CssClass="input" Text='<%# Eval("YearOpened") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewYearOpened" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblYearOpened" width="100px" runat="server" Text='<%# Eval("YearOpened") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                     <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="False" CommandName="Update" Text="Update"></asp:LinkButton>
                                     <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                     <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ShowHeader="True" />
                        </Columns>
                        <PagerSettings Mode="Numeric" />
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <AlternatingRowStyle BackColor="AliceBlue" />
                    </asp:GridView><br />
                    <input id="htmlHiddenSortExpression" type="hidden" value="ResellerKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 
