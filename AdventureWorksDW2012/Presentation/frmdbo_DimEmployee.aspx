<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimEmployee" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimEmployee.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Dim Employee</h2>
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
                    If GridView (grddbo_DimEmployee) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_DimEmployee" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="EmployeeKey" 
                        OnRowCancelingEdit="grddbo_DimEmployee_RowCancelingEdit" OnRowDataBound="grddbo_DimEmployee_RowDataBound" OnRowEditing="grddbo_DimEmployee_RowEditing"
                        OnPageIndexChanging="grddbo_DimEmployee_PageIndexChanging" OnSorting="grddbo_DimEmployee_Sorting" 
                        OnRowUpdating="grddbo_DimEmployee_RowUpdating" OnRowCommand="grddbo_DimEmployee_RowCommand" OnRowDeleting="grddbo_DimEmployee_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EmployeeKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("EmployeeKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEmployeeKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeKey" width="100px" runat="server" Text='<%# Eval("EmployeeKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parent Employee Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FirstName">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtParentEmployeeKey" width="100px" runat="server" CssClass="input" DataTextField="FirstName" DataValueField="ParentEmployeeKey" BackColor="BlanchedAlmond"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="txtNewParentEmployeeKey" width="100px" runat="server" CssClass="input" DataTextField="FirstName" DataValueField="ParentEmployeeKey" BackColor="LightYellow"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblParentEmployeeKey" width="100px" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee National I D Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EmployeeNationalIDAlternateKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeNationalIDAlternateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("EmployeeNationalIDAlternateKey") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEmployeeNationalIDAlternateKey" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeNationalIDAlternateKey" width="100px" runat="server" Text='<%# Eval("EmployeeNationalIDAlternateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parent Employee National I D Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ParentEmployeeNationalIDAlternateKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtParentEmployeeNationalIDAlternateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("ParentEmployeeNationalIDAlternateKey") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewParentEmployeeNationalIDAlternateKey" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblParentEmployeeNationalIDAlternateKey" width="100px" runat="server" Text='<%# Eval("ParentEmployeeNationalIDAlternateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales Territory Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SalesTerritoryAlternateKey">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtSalesTerritoryKey" width="100px" runat="server" CssClass="input" DataTextField="SalesTerritoryAlternateKey" DataValueField="SalesTerritoryAlternateKey" BackColor="BlanchedAlmond"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="txtNewSalesTerritoryKey" width="100px" runat="server" CssClass="input" DataTextField="SalesTerritoryAlternateKey" DataValueField="SalesTerritoryAlternateKey" BackColor="LightYellow"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSalesTerritoryKey" width="100px" runat="server" Text='<%# Eval("SalesTerritoryAlternateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FirstName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstName" width="100px" runat="server" CssClass="input" Text='<%# Eval("FirstName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFirstName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" width="100px" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="LastName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastName" width="100px" runat="server" CssClass="input" Text='<%# Eval("LastName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewLastName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLastName" width="100px" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MiddleName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMiddleName" width="100px" runat="server" CssClass="input" Text='<%# Eval("MiddleName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMiddleName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMiddleName" width="100px" runat="server" Text='<%# Eval("MiddleName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name Style" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="NameStyle">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="txtNameStyle" width="100px" runat="server" CssClass="input" Checked='<%# Eval("NameStyle") %>' style="text-align: center;" BackColor="BlanchedAlmond"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
									</EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="txtNewNameStyle" width="100px" runat="server" CssClass="input" style="text-align: center;" BackColor="LightYellow"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="lblNameStyle" width="100px" runat="server" Checked='<%# Eval("NameStyle") %>' style="text-align: center;"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="Title">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTitle" width="100px" runat="server" CssClass="input" Text='<%# Eval("Title") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewTitle" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" width="100px" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hire Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="HireDate">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtHireDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("HireDate", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageHireDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderHireDate" runat="server" TargetControlID="txtHireDate" PopupButtonID="ImageHireDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewHireDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewHireDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewHireDate" runat="server" TargetControlID="txtNewHireDate" PopupButtonID="ImageNewHireDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblHireDate" width="100px" runat="server" Text='<%# Eval("HireDate", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Birth Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="BirthDate">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtBirthDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("BirthDate", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageBirthDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderBirthDate" runat="server" TargetControlID="txtBirthDate" PopupButtonID="ImageBirthDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewBirthDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewBirthDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewBirthDate" runat="server" TargetControlID="txtNewBirthDate" PopupButtonID="ImageNewBirthDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBirthDate" width="100px" runat="server" Text='<%# Eval("BirthDate", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Login I D" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="LoginID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLoginID" width="100px" runat="server" CssClass="input" Text='<%# Eval("LoginID") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewLoginID" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLoginID" width="100px" runat="server" Text='<%# Eval("LoginID") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Address" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EmailAddress">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmailAddress" width="100px" runat="server" CssClass="input" Text='<%# Eval("EmailAddress") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEmailAddress" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailAddress" width="100px" runat="server" Text='<%# Eval("EmailAddress") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Marital Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MaritalStatus">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaritalStatus" width="100px" runat="server" CssClass="input" Text='<%# Eval("MaritalStatus") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMaritalStatus" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMaritalStatus" width="100px" runat="server" Text='<%# Eval("MaritalStatus") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emergency Contact Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EmergencyContactName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmergencyContactName" width="100px" runat="server" CssClass="input" Text='<%# Eval("EmergencyContactName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEmergencyContactName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmergencyContactName" width="100px" runat="server" Text='<%# Eval("EmergencyContactName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emergency Contact Phone" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EmergencyContactPhone">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmergencyContactPhone" width="100px" runat="server" CssClass="input" Text='<%# Eval("EmergencyContactPhone") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEmergencyContactPhone" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmergencyContactPhone" width="100px" runat="server" Text='<%# Eval("EmergencyContactPhone") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salaried Flag" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SalariedFlag">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="txtSalariedFlag" width="100px" runat="server" CssClass="input" Checked='<%# Eval("SalariedFlag") %>' style="text-align: center;" BackColor="BlanchedAlmond"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
									</EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="txtNewSalariedFlag" width="100px" runat="server" CssClass="input" style="text-align: center;" BackColor="LightYellow"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="lblSalariedFlag" width="100px" runat="server" Checked='<%# Eval("SalariedFlag") %>' style="text-align: center;"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="Gender">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGender" width="100px" runat="server" CssClass="input" Text='<%# Eval("Gender") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewGender" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" width="100px" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pay Frequency" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="PayFrequency">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPayFrequency" width="100px" runat="server" CssClass="input" Text='<%# Eval("PayFrequency") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewPayFrequency" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPayFrequency" width="100px" runat="server" Text='<%# Eval("PayFrequency") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Base Rate" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="BaseRate">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBaseRate" width="100px" runat="server" CssClass="input" Text='<%# Eval("BaseRate") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewBaseRate" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBaseRate" width="100px" runat="server" Text='<%# Eval("BaseRate", "{0:C}") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vacation Hours" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="VacationHours">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtVacationHours" width="100px" runat="server" CssClass="input" Text='<%# Eval("VacationHours") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewVacationHours" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblVacationHours" width="100px" runat="server" Text='<%# Eval("VacationHours") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sick Leave Hours" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SickLeaveHours">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSickLeaveHours" width="100px" runat="server" CssClass="input" Text='<%# Eval("SickLeaveHours") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSickLeaveHours" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSickLeaveHours" width="100px" runat="server" Text='<%# Eval("SickLeaveHours") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Current Flag" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CurrentFlag">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="txtCurrentFlag" width="100px" runat="server" CssClass="input" Checked='<%# Eval("CurrentFlag") %>' style="text-align: center;" BackColor="BlanchedAlmond"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
									</EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="txtNewCurrentFlag" width="100px" runat="server" CssClass="input" style="text-align: center;" BackColor="LightYellow"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="lblCurrentFlag" width="100px" runat="server" Checked='<%# Eval("CurrentFlag") %>' style="text-align: center;"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales Person Flag" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SalesPersonFlag">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="txtSalesPersonFlag" width="100px" runat="server" CssClass="input" Checked='<%# Eval("SalesPersonFlag") %>' style="text-align: center;" BackColor="BlanchedAlmond"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
									</EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="txtNewSalesPersonFlag" width="100px" runat="server" CssClass="input" style="text-align: center;" BackColor="LightYellow"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="lblSalesPersonFlag" width="100px" runat="server" Checked='<%# Eval("SalesPersonFlag") %>' style="text-align: center;"></asp:CheckBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DepartmentName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDepartmentName" width="100px" runat="server" CssClass="input" Text='<%# Eval("DepartmentName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewDepartmentName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartmentName" width="100px" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="StartDate">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtStartDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("StartDate", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageStartDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ImageStartDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewStartDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewStartDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewStartDate" runat="server" TargetControlID="txtNewStartDate" PopupButtonID="ImageNewStartDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" width="100px" runat="server" Text='<%# Eval("StartDate", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EndDate">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtEndDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("EndDate", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageEndDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ImageEndDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewEndDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewEndDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewEndDate" runat="server" TargetControlID="txtNewEndDate" PopupButtonID="ImageNewEndDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" width="100px" runat="server" Text='<%# Eval("EndDate", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="Status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStatus" width="100px" runat="server" CssClass="input" Text='<%# Eval("Status") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewStatus" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" width="100px" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
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
                    <input id="htmlHiddenSortExpression" type="hidden" value="EmployeeKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 
