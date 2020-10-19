<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimGeography" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimGeography.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimGeography" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Dim Geography</h2>
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
                    If GridView (grddbo_DimGeography) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_DimGeography" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="GeographyKey" 
                        OnRowCancelingEdit="grddbo_DimGeography_RowCancelingEdit" OnRowDataBound="grddbo_DimGeography_RowDataBound" OnRowEditing="grddbo_DimGeography_RowEditing"
                        OnPageIndexChanging="grddbo_DimGeography_PageIndexChanging" OnSorting="grddbo_DimGeography_Sorting" 
                        OnRowUpdating="grddbo_DimGeography_RowUpdating" OnRowCommand="grddbo_DimGeography_RowCommand" OnRowDeleting="grddbo_DimGeography_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Geography Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="GeographyKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGeographyKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("GeographyKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewGeographyKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGeographyKey" width="100px" runat="server" Text='<%# Eval("GeographyKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="City">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCity" width="100px" runat="server" CssClass="input" Text='<%# Eval("City") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCity" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" width="100px" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State Province Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="StateProvinceCode">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStateProvinceCode" width="100px" runat="server" CssClass="input" Text='<%# Eval("StateProvinceCode") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewStateProvinceCode" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStateProvinceCode" width="100px" runat="server" Text='<%# Eval("StateProvinceCode") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State Province Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="StateProvinceName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStateProvinceName" width="100px" runat="server" CssClass="input" Text='<%# Eval("StateProvinceName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewStateProvinceName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStateProvinceName" width="100px" runat="server" Text='<%# Eval("StateProvinceName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country Region Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CountryRegionCode">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCountryRegionCode" width="100px" runat="server" CssClass="input" Text='<%# Eval("CountryRegionCode") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCountryRegionCode" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCountryRegionCode" width="100px" runat="server" Text='<%# Eval("CountryRegionCode") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Country Region Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishCountryRegionName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishCountryRegionName" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishCountryRegionName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishCountryRegionName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishCountryRegionName" width="100px" runat="server" Text='<%# Eval("EnglishCountryRegionName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spanish Country Region Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SpanishCountryRegionName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpanishCountryRegionName" width="100px" runat="server" CssClass="input" Text='<%# Eval("SpanishCountryRegionName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSpanishCountryRegionName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpanishCountryRegionName" width="100px" runat="server" Text='<%# Eval("SpanishCountryRegionName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="French Country Region Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FrenchCountryRegionName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFrenchCountryRegionName" width="100px" runat="server" CssClass="input" Text='<%# Eval("FrenchCountryRegionName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFrenchCountryRegionName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrenchCountryRegionName" width="100px" runat="server" Text='<%# Eval("FrenchCountryRegionName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Postal Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="PostalCode">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPostalCode" width="100px" runat="server" CssClass="input" Text='<%# Eval("PostalCode") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewPostalCode" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPostalCode" width="100px" runat="server" Text='<%# Eval("PostalCode") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales Territory Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SalesTerritoryAlternateKey">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtSalesTerritoryKey" width="100px" runat="server" CssClass="input" DataTextField="SalesTerritoryAlternateKey" DataValueField="SalesTerritoryKey" BackColor="BlanchedAlmond"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="txtNewSalesTerritoryKey" width="100px" runat="server" CssClass="input" DataTextField="SalesTerritoryAlternateKey" DataValueField="SalesTerritoryKey" BackColor="LightYellow"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSalesTerritoryKey" width="100px" runat="server" Text='<%# Eval("SalesTerritoryAlternateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ip Address Locator" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="IpAddressLocator">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIpAddressLocator" width="100px" runat="server" CssClass="input" Text='<%# Eval("IpAddressLocator") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewIpAddressLocator" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblIpAddressLocator" width="100px" runat="server" Text='<%# Eval("IpAddressLocator") %>'></asp:Label>
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
                    <input id="htmlHiddenSortExpression" type="hidden" value="GeographyKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 
