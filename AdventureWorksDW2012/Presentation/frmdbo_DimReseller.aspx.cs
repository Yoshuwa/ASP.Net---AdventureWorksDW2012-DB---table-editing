using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.IO;

namespace AdventureWorksDW2012
{
    public partial class frmdbo_DimReseller : System.Web.UI.Page
    {

        private dbo_DimResellerDataClass clsdbo_DimResellerData = new dbo_DimResellerDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimReseller;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["GeographyKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimReseller");
                Session.Remove("Row");

                cmbFields.Items.Add("Reseller Key");
                cmbFields.Items.Add("Geography Key");
                cmbFields.Items.Add("Reseller Alternate Key");
                cmbFields.Items.Add("Phone");
                cmbFields.Items.Add("Business Type");
                cmbFields.Items.Add("Reseller Name");
                cmbFields.Items.Add("Number Employees");
                cmbFields.Items.Add("Order Frequency");
                cmbFields.Items.Add("Order Month");
                cmbFields.Items.Add("First Order Year");
                cmbFields.Items.Add("Last Order Year");
                cmbFields.Items.Add("Product Line");
                cmbFields.Items.Add("Address Line1");
                cmbFields.Items.Add("Address Line2");
                cmbFields.Items.Add("Annual Sales");
                cmbFields.Items.Add("Bank Name");
                cmbFields.Items.Add("Min Payment Type");
                cmbFields.Items.Add("Min Payment Amount");
                cmbFields.Items.Add("Annual Revenue");
                cmbFields.Items.Add("Year Opened");

                cmbCondition.Items.Add("Contains");
                cmbCondition.Items.Add("Equals");
                cmbCondition.Items.Add("Starts with...");
                cmbCondition.Items.Add("More than...");
                cmbCondition.Items.Add("Less than...");
                cmbCondition.Items.Add("Equal or more than...");
                cmbCondition.Items.Add("Equal or less than...");
			    
                cmbRecords.Items.Add("5");
                cmbRecords.Items.Add("10");
                cmbRecords.Items.Add("25");
                cmbRecords.Items.Add("50");
                cmbRecords.Items.Add("100");
                cmbRecords.Items.Add("500");

                LoadGriddbo_DimReseller();
            }
        }

        private void Loaddbo_DimReseller_dbo_DimGeographyComboBox(GridViewRowEventArgs e)
        {
            List<dbo_DimReseller_dbo_DimGeographyClass> dbo_DimReseller_dbo_DimGeographyList = new  List<dbo_DimReseller_dbo_DimGeographyClass>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtGeographyKey = (DropDownList)e.Row.FindControl("txtGeographyKey");
                if (txtGeographyKey != null) {
                    try {
                        dbo_DimReseller_dbo_DimGeographyList = dbo_DimReseller_dbo_DimGeographyDataClass.List();
                        txtGeographyKey.DataSource = dbo_DimReseller_dbo_DimGeographyList;
                        txtGeographyKey.DataValueField = "GeographyKey";
                        txtGeographyKey.DataTextField = "StateProvinceName";
                        txtGeographyKey.DataBind();
                        txtGeographyKey.SelectedValue = Convert.ToString(Session["GeographyKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewGeographyKey = (DropDownList)e.Row.FindControl("txtNewGeographyKey");
                if (txtNewGeographyKey != null) {
                    try {
                        dbo_DimReseller_dbo_DimGeographyList = dbo_DimReseller_dbo_DimGeographyDataClass.List();
                        txtNewGeographyKey.DataSource = dbo_DimReseller_dbo_DimGeographyList;
                        txtNewGeographyKey.DataValueField = "GeographyKey";
                        txtNewGeographyKey.DataTextField = "StateProvinceName";
                        txtNewGeographyKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimReseller()
        {
            try {
                if ((Session["dvdbo_DimReseller"] != null)) {
                    dvdbo_DimReseller = (DataView)Session["dvdbo_DimReseller"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimReseller = dbo_DimResellerDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimReseller"] = dvdbo_DimReseller;
                }
                if (dvdbo_DimReseller.Count > 0) {
                    grddbo_DimReseller.DataSource = dvdbo_DimReseller;
                    grddbo_DimReseller.DataBind();
                }
                if (dvdbo_DimReseller.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ResellerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("StateProvinceName", Type.GetType("System.Int32"));
                    dt.Columns.Add("ResellerAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("BusinessType", Type.GetType("System.String"));
                    dt.Columns.Add("ResellerName", Type.GetType("System.String"));
                    dt.Columns.Add("NumberEmployees", Type.GetType("System.Int32"));
                    dt.Columns.Add("OrderFrequency", Type.GetType("System.String"));
                    dt.Columns.Add("OrderMonth", Type.GetType("System.Byte"));
                    dt.Columns.Add("FirstOrderYear", Type.GetType("System.Int32"));
                    dt.Columns.Add("LastOrderYear", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductLine", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine1", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine2", Type.GetType("System.String"));
                    dt.Columns.Add("AnnualSales", Type.GetType("System.Decimal"));
                    dt.Columns.Add("BankName", Type.GetType("System.String"));
                    dt.Columns.Add("MinPaymentType", Type.GetType("System.Byte"));
                    dt.Columns.Add("MinPaymentAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("AnnualRevenue", Type.GetType("System.Decimal"));
                    dt.Columns.Add("YearOpened", Type.GetType("System.Int32"));
                    dvdbo_DimReseller = dt.DefaultView;
                    Session["dvdbo_DimReseller"] = dvdbo_DimReseller;

                    grddbo_DimReseller.DataSource = dvdbo_DimReseller;
                    grddbo_DimReseller.DataBind();

                    int TotalColumns = grddbo_DimReseller.Rows[0].Cells.Count;
                    grddbo_DimReseller.Rows[0].Cells.Clear();
                    grddbo_DimReseller.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimReseller.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimReseller.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimReseller.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
            }
        }

        protected void grddbo_DimReseller_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimReseller_dbo_DimGeographyComboBox(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtResellerKey = (TextBox)e.Row.FindControl("txtResellerKey");
                if (txtResellerKey != null) {
                    txtResellerKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewResellerKey = (TextBox)e.Row.FindControl("txtNewResellerKey");
                if (txtNewResellerKey != null) {
                    txtNewResellerKey.Enabled = false;
                }
                txtNewResellerKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimReseller"));
            }
        }

        protected void grddbo_DimReseller_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimReseller.EditIndex = -1;
            LoadGriddbo_DimReseller();
        }

        protected void grddbo_DimReseller_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimReseller.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimReseller_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimReseller_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimReseller_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimReseller_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimReseller_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimReseller.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimReseller();
        }

        protected void grddbo_DimReseller_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimReseller();
        }

        private void Edit()
        {
            try {
                dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
                Label lblResellerKey = (Label)grddbo_DimReseller.Rows[grddbo_DimReseller.EditIndex].FindControl("lblResellerKey");
                clsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(lblResellerKey.Text);
                clsdbo_DimReseller = dbo_DimResellerDataClass.Select_Record(clsdbo_DimReseller);

                Session["GeographyKey_SelectedValue"] = clsdbo_DimReseller.GeographyKey;

                LoadGriddbo_DimReseller();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewGeographyKey = (DropDownList)grddbo_DimReseller.FooterRow.FindControl("txtNewGeographyKey");
                TextBox txtNewResellerAlternateKey = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewResellerAlternateKey");
                TextBox txtNewPhone = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewPhone");
                TextBox txtNewBusinessType = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewBusinessType");
                TextBox txtNewResellerName = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewResellerName");
                TextBox txtNewNumberEmployees = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewNumberEmployees");
                TextBox txtNewOrderFrequency = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewOrderFrequency");
                TextBox txtNewOrderMonth = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewOrderMonth");
                TextBox txtNewFirstOrderYear = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewFirstOrderYear");
                TextBox txtNewLastOrderYear = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewLastOrderYear");
                TextBox txtNewProductLine = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewProductLine");
                TextBox txtNewAddressLine1 = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAddressLine1");
                TextBox txtNewAddressLine2 = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAddressLine2");
                TextBox txtNewAnnualSales = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAnnualSales");
                TextBox txtNewBankName = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewBankName");
                TextBox txtNewMinPaymentType = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewMinPaymentType");
                TextBox txtNewMinPaymentAmount = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewMinPaymentAmount");
                TextBox txtNewAnnualRevenue = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAnnualRevenue");
                TextBox txtNewYearOpened = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewYearOpened");

                dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewGeographyKey.SelectedValue)) {
                        clsdbo_DimReseller.GeographyKey = null;
                    } else {
                        clsdbo_DimReseller.GeographyKey = System.Convert.ToInt32(txtNewGeographyKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewResellerAlternateKey.Text)) {
                        clsdbo_DimReseller.ResellerAlternateKey = null;
                    } else {
                        clsdbo_DimReseller.ResellerAlternateKey = txtNewResellerAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtNewPhone.Text)) {
                        clsdbo_DimReseller.Phone = null;
                    } else {
                        clsdbo_DimReseller.Phone = txtNewPhone.Text; }
                    clsdbo_DimReseller.BusinessType = System.Convert.ToString(txtNewBusinessType.Text);
                    clsdbo_DimReseller.ResellerName = System.Convert.ToString(txtNewResellerName.Text);
                    if (string.IsNullOrEmpty(txtNewNumberEmployees.Text)) {
                        clsdbo_DimReseller.NumberEmployees = null;
                    } else {
                        clsdbo_DimReseller.NumberEmployees = System.Convert.ToInt32(txtNewNumberEmployees.Text); }
                    if (string.IsNullOrEmpty(txtNewOrderFrequency.Text)) {
                        clsdbo_DimReseller.OrderFrequency = null;
                    } else {
                        clsdbo_DimReseller.OrderFrequency = txtNewOrderFrequency.Text; }
                    if (string.IsNullOrEmpty(txtNewOrderMonth.Text)) {
                        clsdbo_DimReseller.OrderMonth = null;
                    } else {
                        clsdbo_DimReseller.OrderMonth = System.Convert.ToByte(txtNewOrderMonth.Text); }
                    if (string.IsNullOrEmpty(txtNewFirstOrderYear.Text)) {
                        clsdbo_DimReseller.FirstOrderYear = null;
                    } else {
                        clsdbo_DimReseller.FirstOrderYear = System.Convert.ToInt32(txtNewFirstOrderYear.Text); }
                    if (string.IsNullOrEmpty(txtNewLastOrderYear.Text)) {
                        clsdbo_DimReseller.LastOrderYear = null;
                    } else {
                        clsdbo_DimReseller.LastOrderYear = System.Convert.ToInt32(txtNewLastOrderYear.Text); }
                    if (string.IsNullOrEmpty(txtNewProductLine.Text)) {
                        clsdbo_DimReseller.ProductLine = null;
                    } else {
                        clsdbo_DimReseller.ProductLine = txtNewProductLine.Text; }
                    if (string.IsNullOrEmpty(txtNewAddressLine1.Text)) {
                        clsdbo_DimReseller.AddressLine1 = null;
                    } else {
                        clsdbo_DimReseller.AddressLine1 = txtNewAddressLine1.Text; }
                    if (string.IsNullOrEmpty(txtNewAddressLine2.Text)) {
                        clsdbo_DimReseller.AddressLine2 = null;
                    } else {
                        clsdbo_DimReseller.AddressLine2 = txtNewAddressLine2.Text; }
                    if (string.IsNullOrEmpty(txtNewAnnualSales.Text)) {
                        clsdbo_DimReseller.AnnualSales = null;
                    } else {
                        clsdbo_DimReseller.AnnualSales = System.Convert.ToDecimal(txtNewAnnualSales.Text); }
                    if (string.IsNullOrEmpty(txtNewBankName.Text)) {
                        clsdbo_DimReseller.BankName = null;
                    } else {
                        clsdbo_DimReseller.BankName = txtNewBankName.Text; }
                    if (string.IsNullOrEmpty(txtNewMinPaymentType.Text)) {
                        clsdbo_DimReseller.MinPaymentType = null;
                    } else {
                        clsdbo_DimReseller.MinPaymentType = System.Convert.ToByte(txtNewMinPaymentType.Text); }
                    if (string.IsNullOrEmpty(txtNewMinPaymentAmount.Text)) {
                        clsdbo_DimReseller.MinPaymentAmount = null;
                    } else {
                        clsdbo_DimReseller.MinPaymentAmount = System.Convert.ToDecimal(txtNewMinPaymentAmount.Text); }
                    if (string.IsNullOrEmpty(txtNewAnnualRevenue.Text)) {
                        clsdbo_DimReseller.AnnualRevenue = null;
                    } else {
                        clsdbo_DimReseller.AnnualRevenue = System.Convert.ToDecimal(txtNewAnnualRevenue.Text); }
                    if (string.IsNullOrEmpty(txtNewYearOpened.Text)) {
                        clsdbo_DimReseller.YearOpened = null;
                    } else {
                        clsdbo_DimReseller.YearOpened = System.Convert.ToInt32(txtNewYearOpened.Text); }
                    bool bSucess = false;
                    bSucess = dbo_DimResellerDataClass.Add(clsdbo_DimReseller);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimReseller");
                        LoadGriddbo_DimReseller();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Reseller ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtResellerKey = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerKey");
                DropDownList txtGeographyKey = (DropDownList)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGeographyKey");
                TextBox txtResellerAlternateKey = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerAlternateKey");
                TextBox txtPhone = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
                TextBox txtBusinessType = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBusinessType");
                TextBox txtResellerName = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerName");
                TextBox txtNumberEmployees = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberEmployees");
                TextBox txtOrderFrequency = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderFrequency");
                TextBox txtOrderMonth = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderMonth");
                TextBox txtFirstOrderYear = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstOrderYear");
                TextBox txtLastOrderYear = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastOrderYear");
                TextBox txtProductLine = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductLine");
                TextBox txtAddressLine1 = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine1");
                TextBox txtAddressLine2 = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine2");
                TextBox txtAnnualSales = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAnnualSales");
                TextBox txtBankName = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBankName");
                TextBox txtMinPaymentType = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMinPaymentType");
                TextBox txtMinPaymentAmount = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMinPaymentAmount");
                TextBox txtAnnualRevenue = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAnnualRevenue");
                TextBox txtYearOpened = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtYearOpened");

                dbo_DimResellerClass oclsdbo_DimReseller = new dbo_DimResellerClass();
                dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
                oclsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(txtResellerKey.Text);
                oclsdbo_DimReseller = dbo_DimResellerDataClass.Select_Record(oclsdbo_DimReseller);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtGeographyKey.SelectedValue)) {
                        clsdbo_DimReseller.GeographyKey = null;
                    } else {
                        clsdbo_DimReseller.GeographyKey = System.Convert.ToInt32(txtGeographyKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtResellerAlternateKey.Text)) {
                        clsdbo_DimReseller.ResellerAlternateKey = null;
                    } else {
                        clsdbo_DimReseller.ResellerAlternateKey = txtResellerAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtPhone.Text)) {
                        clsdbo_DimReseller.Phone = null;
                    } else {
                        clsdbo_DimReseller.Phone = txtPhone.Text; }
                    clsdbo_DimReseller.BusinessType = System.Convert.ToString(txtBusinessType.Text);
                    clsdbo_DimReseller.ResellerName = System.Convert.ToString(txtResellerName.Text);
                    if (string.IsNullOrEmpty(txtNumberEmployees.Text)) {
                        clsdbo_DimReseller.NumberEmployees = null;
                    } else {
                        clsdbo_DimReseller.NumberEmployees = System.Convert.ToInt32(txtNumberEmployees.Text); }
                    if (string.IsNullOrEmpty(txtOrderFrequency.Text)) {
                        clsdbo_DimReseller.OrderFrequency = null;
                    } else {
                        clsdbo_DimReseller.OrderFrequency = txtOrderFrequency.Text; }
                    if (string.IsNullOrEmpty(txtOrderMonth.Text)) {
                        clsdbo_DimReseller.OrderMonth = null;
                    } else {
                        clsdbo_DimReseller.OrderMonth = System.Convert.ToByte(txtOrderMonth.Text); }
                    if (string.IsNullOrEmpty(txtFirstOrderYear.Text)) {
                        clsdbo_DimReseller.FirstOrderYear = null;
                    } else {
                        clsdbo_DimReseller.FirstOrderYear = System.Convert.ToInt32(txtFirstOrderYear.Text); }
                    if (string.IsNullOrEmpty(txtLastOrderYear.Text)) {
                        clsdbo_DimReseller.LastOrderYear = null;
                    } else {
                        clsdbo_DimReseller.LastOrderYear = System.Convert.ToInt32(txtLastOrderYear.Text); }
                    if (string.IsNullOrEmpty(txtProductLine.Text)) {
                        clsdbo_DimReseller.ProductLine = null;
                    } else {
                        clsdbo_DimReseller.ProductLine = txtProductLine.Text; }
                    if (string.IsNullOrEmpty(txtAddressLine1.Text)) {
                        clsdbo_DimReseller.AddressLine1 = null;
                    } else {
                        clsdbo_DimReseller.AddressLine1 = txtAddressLine1.Text; }
                    if (string.IsNullOrEmpty(txtAddressLine2.Text)) {
                        clsdbo_DimReseller.AddressLine2 = null;
                    } else {
                        clsdbo_DimReseller.AddressLine2 = txtAddressLine2.Text; }
                    if (string.IsNullOrEmpty(txtAnnualSales.Text)) {
                        clsdbo_DimReseller.AnnualSales = null;
                    } else {
                        clsdbo_DimReseller.AnnualSales = System.Convert.ToDecimal(txtAnnualSales.Text); }
                    if (string.IsNullOrEmpty(txtBankName.Text)) {
                        clsdbo_DimReseller.BankName = null;
                    } else {
                        clsdbo_DimReseller.BankName = txtBankName.Text; }
                    if (string.IsNullOrEmpty(txtMinPaymentType.Text)) {
                        clsdbo_DimReseller.MinPaymentType = null;
                    } else {
                        clsdbo_DimReseller.MinPaymentType = System.Convert.ToByte(txtMinPaymentType.Text); }
                    if (string.IsNullOrEmpty(txtMinPaymentAmount.Text)) {
                        clsdbo_DimReseller.MinPaymentAmount = null;
                    } else {
                        clsdbo_DimReseller.MinPaymentAmount = System.Convert.ToDecimal(txtMinPaymentAmount.Text); }
                    if (string.IsNullOrEmpty(txtAnnualRevenue.Text)) {
                        clsdbo_DimReseller.AnnualRevenue = null;
                    } else {
                        clsdbo_DimReseller.AnnualRevenue = System.Convert.ToDecimal(txtAnnualRevenue.Text); }
                    if (string.IsNullOrEmpty(txtYearOpened.Text)) {
                        clsdbo_DimReseller.YearOpened = null;
                    } else {
                        clsdbo_DimReseller.YearOpened = System.Convert.ToInt32(txtYearOpened.Text); }
                    bool bSucess = false;
                    bSucess = dbo_DimResellerDataClass.Update(oclsdbo_DimReseller, clsdbo_DimReseller);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimReseller");
                        grddbo_DimReseller.EditIndex = -1;
                        LoadGriddbo_DimReseller();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Reseller ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
            Label lblResellerKey = (Label)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblResellerKey");
            clsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(lblResellerKey.Text);
            clsdbo_DimReseller = dbo_DimResellerDataClass.Select_Record(clsdbo_DimReseller);
            bool bSucess = false;
            bSucess = dbo_DimResellerDataClass.Delete(clsdbo_DimReseller);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimReseller");
                LoadGriddbo_DimReseller();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Reseller ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtResellerKey = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerKey");
            DropDownList txtGeographyKey = (DropDownList)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGeographyKey");
            TextBox txtResellerAlternateKey = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerAlternateKey");
            TextBox txtPhone = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
            TextBox txtBusinessType = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBusinessType");
            TextBox txtResellerName = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerName");
            TextBox txtNumberEmployees = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberEmployees");
            TextBox txtOrderFrequency = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderFrequency");
            TextBox txtOrderMonth = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderMonth");
            TextBox txtFirstOrderYear = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstOrderYear");
            TextBox txtLastOrderYear = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastOrderYear");
            TextBox txtProductLine = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductLine");
            TextBox txtAddressLine1 = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine1");
            TextBox txtAddressLine2 = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine2");
            TextBox txtAnnualSales = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAnnualSales");
            TextBox txtBankName = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBankName");
            TextBox txtMinPaymentType = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMinPaymentType");
            TextBox txtMinPaymentAmount = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMinPaymentAmount");
            TextBox txtAnnualRevenue = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAnnualRevenue");
            TextBox txtYearOpened = (TextBox)grddbo_DimReseller.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtYearOpened");

            if (txtBusinessType.Text == "") {
                ec.ShowMessage(" Business Type is Required. ", " Dbo. Dim Reseller ");
                txtBusinessType.Focus();
                return false;}
            if (txtResellerName.Text == "") {
                ec.ShowMessage(" Reseller Name is Required. ", " Dbo. Dim Reseller ");
                txtResellerName.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewGeographyKey = (DropDownList)grddbo_DimReseller.FooterRow.FindControl("txtNewGeographyKey");
            TextBox txtNewResellerAlternateKey = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewResellerAlternateKey");
            TextBox txtNewPhone = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewPhone");
            TextBox txtNewBusinessType = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewBusinessType");
            TextBox txtNewResellerName = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewResellerName");
            TextBox txtNewNumberEmployees = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewNumberEmployees");
            TextBox txtNewOrderFrequency = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewOrderFrequency");
            TextBox txtNewOrderMonth = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewOrderMonth");
            TextBox txtNewFirstOrderYear = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewFirstOrderYear");
            TextBox txtNewLastOrderYear = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewLastOrderYear");
            TextBox txtNewProductLine = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewProductLine");
            TextBox txtNewAddressLine1 = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAddressLine1");
            TextBox txtNewAddressLine2 = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAddressLine2");
            TextBox txtNewAnnualSales = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAnnualSales");
            TextBox txtNewBankName = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewBankName");
            TextBox txtNewMinPaymentType = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewMinPaymentType");
            TextBox txtNewMinPaymentAmount = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewMinPaymentAmount");
            TextBox txtNewAnnualRevenue = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewAnnualRevenue");
            TextBox txtNewYearOpened = (TextBox)grddbo_DimReseller.FooterRow.FindControl("txtNewYearOpened");

            if (txtNewBusinessType.Text == "") {
                ec.ShowMessage(" Business Type is Required. ", " Dbo. Dim Reseller ");
                txtNewBusinessType.Focus();
                return false;}
            if (txtNewResellerName.Text == "") {
                ec.ShowMessage(" Reseller Name is Required. ", " Dbo. Dim Reseller ");
                txtNewResellerName.Focus();
                return false;}
            return true;
        }

        private string GetSortDirection(string column)
        {
            dynamic sortDirection = "ASC";
            dynamic sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    dynamic lastDirection = ViewState["SortDirection"] as string;
                    if (lastDirection != null && lastDirection == "ASC")
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimReseller.PageIndex = 0;
		    grddbo_DimReseller.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimReseller();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimReseller");
		    LoadGriddbo_DimReseller();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimReseller");
			if ((Session["dvdbo_DimReseller"] != null)) {
				dvdbo_DimReseller = (DataView)Session["dvdbo_DimReseller"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimReseller = dbo_DimResellerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimReseller"] = dvdbo_DimReseller;
		    	}
                if (dvdbo_DimReseller.Count > 0) {
                    grddbo_DimReseller.DataSource = dvdbo_DimReseller;
                    grddbo_DimReseller.DataBind();
                }
                if (dvdbo_DimReseller.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ResellerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("StateProvinceName", Type.GetType("System.Int32"));
                    dt.Columns.Add("ResellerAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("BusinessType", Type.GetType("System.String"));
                    dt.Columns.Add("ResellerName", Type.GetType("System.String"));
                    dt.Columns.Add("NumberEmployees", Type.GetType("System.Int32"));
                    dt.Columns.Add("OrderFrequency", Type.GetType("System.String"));
                    dt.Columns.Add("OrderMonth", Type.GetType("System.Byte"));
                    dt.Columns.Add("FirstOrderYear", Type.GetType("System.Int32"));
                    dt.Columns.Add("LastOrderYear", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductLine", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine1", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine2", Type.GetType("System.String"));
                    dt.Columns.Add("AnnualSales", Type.GetType("System.Decimal"));
                    dt.Columns.Add("BankName", Type.GetType("System.String"));
                    dt.Columns.Add("MinPaymentType", Type.GetType("System.Byte"));
                    dt.Columns.Add("MinPaymentAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("AnnualRevenue", Type.GetType("System.Decimal"));
                    dt.Columns.Add("YearOpened", Type.GetType("System.Int32"));
                    dvdbo_DimReseller = dt.DefaultView;
                    Session["dvdbo_DimReseller"] = dvdbo_DimReseller;

                    grddbo_DimReseller.DataSource = dvdbo_DimReseller;
                    grddbo_DimReseller.DataBind();

                    int TotalColumns = grddbo_DimReseller.Rows[0].Cells.Count;
                    grddbo_DimReseller.Rows[0].Cells.Clear();
                    grddbo_DimReseller.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimReseller.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimReseller.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimReseller.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
		    }
        }

        public void btnExport_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (ddlFile.SelectedValue == ".pdf")
                {
                    DataTable dt = new DataTable();
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    { dt = dbo_DimResellerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimResellerDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Reseller", "Many");
                    Document document = pdfForm.CreateDocument();
                    PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                    renderer.Document = document;
                    renderer.RenderDocument();

                    MemoryStream stream = new MemoryStream();
                    renderer.PdfDocument.Save(stream, false);

                    Response.Clear();
                    Response.ContentType = "application/" + ddlFile.SelectedItem.Text + ddlFile.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + "Report" + ddlFile.SelectedValue);
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Charset = "";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/" + ddlFile.SelectedItem.Text + ddlFile.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + "Report" + ddlFile.SelectedValue);

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    GridView GVExport = new GridView();
                    GVExport.DataSource = Session["dvdbo_DimReseller"];
                    GVExport.DataBind();
                    GVExport.RenderControl(htw);

                    Response.Write(sw);
                    sw = null;
                    htw = null;
                    Response.Flush();
                    Response.End();
                }
            }
            catch
            {
            }
        }

    }
}
 
