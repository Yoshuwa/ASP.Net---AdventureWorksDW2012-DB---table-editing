<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimCurrency" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimCurrency.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimCurrency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Dim Currency</h2>
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
                    If GridView (grddbo_DimCurrency) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_DimCurrency" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="CurrencyKey" 
                        OnRowCancelingEdit="grddbo_DimCurrency_RowCancelingEdit" OnRowDataBound="grddbo_DimCurrency_RowDataBound" OnRowEditing="grddbo_DimCurrency_RowEditing"
                        OnPageIndexChanging="grddbo_DimCurrency_PageIndexChanging" OnSorting="grddbo_DimCurrency_Sorting" 
                        OnRowUpdating="grddbo_DimCurrency_RowUpdating" OnRowCommand="grddbo_DimCurrency_RowCommand" OnRowDeleting="grddbo_DimCurrency_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Currency Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CurrencyKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCurrencyKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("CurrencyKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCurrencyKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrencyKey" width="100px" runat="server" Text='<%# Eval("CurrencyKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Currency Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CurrencyAlternateKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCurrencyAlternateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("CurrencyAlternateKey") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCurrencyAlternateKey" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrencyAlternateKey" width="100px" runat="server" Text='<%# Eval("CurrencyAlternateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Currency Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CurrencyName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCurrencyName" width="100px" runat="server" CssClass="input" Text='<%# Eval("CurrencyName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCurrencyName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrencyName" width="100px" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
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
                    <input id="htmlHiddenSortExpression" type="hidden" value="CurrencyKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 
