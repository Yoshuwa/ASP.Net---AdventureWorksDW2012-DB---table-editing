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
    public partial class frmdbo_DimCustomer : System.Web.UI.Page
    {

        private dbo_DimCustomerDataClass clsdbo_DimCustomerData = new dbo_DimCustomerDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["GeographyKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimCustomer");
                Session.Remove("Row");

                cmbFields.Items.Add("Customer Key");
                cmbFields.Items.Add("Geography Key");
                cmbFields.Items.Add("Customer Alternate Key");
                cmbFields.Items.Add("Title");
                cmbFields.Items.Add("First Name");
                cmbFields.Items.Add("Middle Name");
                cmbFields.Items.Add("Last Name");
                cmbFields.Items.Add("Name Style");
                cmbFields.Items.Add("Birth Date");
                cmbFields.Items.Add("Marital Status");
                cmbFields.Items.Add("Suffix");
                cmbFields.Items.Add("Gender");
                cmbFields.Items.Add("Email Address");
                cmbFields.Items.Add("Yearly Income");
                cmbFields.Items.Add("Total Children");
                cmbFields.Items.Add("Number Children At Home");
                cmbFields.Items.Add("English Education");
                cmbFields.Items.Add("Spanish Education");
                cmbFields.Items.Add("French Education");
                cmbFields.Items.Add("English Occupation");
                cmbFields.Items.Add("Spanish Occupation");
                cmbFields.Items.Add("French Occupation");
                cmbFields.Items.Add("House Owner Flag");
                cmbFields.Items.Add("Number Cars Owned");
                cmbFields.Items.Add("Address Line1");
                cmbFields.Items.Add("Address Line2");
                cmbFields.Items.Add("Phone");
                cmbFields.Items.Add("Date First Purchase");
                cmbFields.Items.Add("Commute Distance");

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

                LoadGriddbo_DimCustomer();
            }
        }

        private void Loaddbo_DimCustomer_dbo_DimGeographyComboBox(GridViewRowEventArgs e)
        {
            List<dbo_DimCustomer_dbo_DimGeographyClass> dbo_DimCustomer_dbo_DimGeographyList = new  List<dbo_DimCustomer_dbo_DimGeographyClass>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtGeographyKey = (DropDownList)e.Row.FindControl("txtGeographyKey");
                if (txtGeographyKey != null) {
                    try {
                        dbo_DimCustomer_dbo_DimGeographyList = dbo_DimCustomer_dbo_DimGeographyDataClass.List();
                        txtGeographyKey.DataSource = dbo_DimCustomer_dbo_DimGeographyList;
                        txtGeographyKey.DataValueField = "GeographyKey";
                        txtGeographyKey.DataTextField = "StateProvinceName";
                        txtGeographyKey.DataBind();
                        txtGeographyKey.SelectedValue = Convert.ToString(Session["GeographyKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewGeographyKey = (DropDownList)e.Row.FindControl("txtNewGeographyKey");
                if (txtNewGeographyKey != null) {
                    try {
                        dbo_DimCustomer_dbo_DimGeographyList = dbo_DimCustomer_dbo_DimGeographyDataClass.List();
                        txtNewGeographyKey.DataSource = dbo_DimCustomer_dbo_DimGeographyList;
                        txtNewGeographyKey.DataValueField = "GeographyKey";
                        txtNewGeographyKey.DataTextField = "StateProvinceName";
                        txtNewGeographyKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimCustomer()
        {
            try {
                if ((Session["dvdbo_DimCustomer"] != null)) {
                    dvdbo_DimCustomer = (DataView)Session["dvdbo_DimCustomer"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimCustomer = dbo_DimCustomerDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimCustomer"] = dvdbo_DimCustomer;
                }
                if (dvdbo_DimCustomer.Count > 0) {
                    grddbo_DimCustomer.DataSource = dvdbo_DimCustomer;
                    grddbo_DimCustomer.DataBind();
                }
                if (dvdbo_DimCustomer.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("CustomerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("StateProvinceName", Type.GetType("System.Int32"));
                    dt.Columns.Add("CustomerAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("Title", Type.GetType("System.String"));
                    dt.Columns.Add("FirstName", Type.GetType("System.String"));
                    dt.Columns.Add("MiddleName", Type.GetType("System.String"));
                    dt.Columns.Add("LastName", Type.GetType("System.String"));
                    dt.Columns.Add("NameStyle", Type.GetType("System.Boolean"));
                    dt.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("MaritalStatus", Type.GetType("System.String"));
                    dt.Columns.Add("Suffix", Type.GetType("System.String"));
                    dt.Columns.Add("Gender", Type.GetType("System.String"));
                    dt.Columns.Add("EmailAddress", Type.GetType("System.String"));
                    dt.Columns.Add("YearlyIncome", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TotalChildren", Type.GetType("System.Byte"));
                    dt.Columns.Add("NumberChildrenAtHome", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishEducation", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishEducation", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchEducation", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishOccupation", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishOccupation", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchOccupation", Type.GetType("System.String"));
                    dt.Columns.Add("HouseOwnerFlag", Type.GetType("System.String"));
                    dt.Columns.Add("NumberCarsOwned", Type.GetType("System.Byte"));
                    dt.Columns.Add("AddressLine1", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine2", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("DateFirstPurchase", Type.GetType("System.DateTime"));
                    dt.Columns.Add("CommuteDistance", Type.GetType("System.String"));
                    dvdbo_DimCustomer = dt.DefaultView;
                    Session["dvdbo_DimCustomer"] = dvdbo_DimCustomer;

                    grddbo_DimCustomer.DataSource = dvdbo_DimCustomer;
                    grddbo_DimCustomer.DataBind();

                    int TotalColumns = grddbo_DimCustomer.Rows[0].Cells.Count;
                    grddbo_DimCustomer.Rows[0].Cells.Clear();
                    grddbo_DimCustomer.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimCustomer.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimCustomer.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimCustomer.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
            }
        }

        protected void grddbo_DimCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimCustomer_dbo_DimGeographyComboBox(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtCustomerKey = (TextBox)e.Row.FindControl("txtCustomerKey");
                if (txtCustomerKey != null) {
                    txtCustomerKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewCustomerKey = (TextBox)e.Row.FindControl("txtNewCustomerKey");
                if (txtNewCustomerKey != null) {
                    txtNewCustomerKey.Enabled = false;
                }
                txtNewCustomerKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimCustomer"));
            }
        }

        protected void grddbo_DimCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimCustomer.EditIndex = -1;
            LoadGriddbo_DimCustomer();
        }

        protected void grddbo_DimCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimCustomer.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimCustomer_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimCustomer.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimCustomer();
        }

        protected void grddbo_DimCustomer_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimCustomer();
        }

        private void Edit()
        {
            try {
                dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
                Label lblCustomerKey = (Label)grddbo_DimCustomer.Rows[grddbo_DimCustomer.EditIndex].FindControl("lblCustomerKey");
                clsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(lblCustomerKey.Text);
                clsdbo_DimCustomer = dbo_DimCustomerDataClass.Select_Record(clsdbo_DimCustomer);

                Session["GeographyKey_SelectedValue"] = clsdbo_DimCustomer.GeographyKey;

                LoadGriddbo_DimCustomer();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewGeographyKey = (DropDownList)grddbo_DimCustomer.FooterRow.FindControl("txtNewGeographyKey");
                TextBox txtNewCustomerAlternateKey = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewCustomerAlternateKey");
                TextBox txtNewTitle = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewTitle");
                TextBox txtNewFirstName = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewFirstName");
                TextBox txtNewMiddleName = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewMiddleName");
                TextBox txtNewLastName = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewLastName");
                CheckBox txtNewNameStyle = (CheckBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewNameStyle");
                TextBox txtNewBirthDate = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewBirthDate");
                TextBox txtNewMaritalStatus = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewMaritalStatus");
                TextBox txtNewSuffix = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewSuffix");
                TextBox txtNewGender = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewGender");
                TextBox txtNewEmailAddress = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewEmailAddress");
                TextBox txtNewYearlyIncome = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewYearlyIncome");
                TextBox txtNewTotalChildren = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewTotalChildren");
                TextBox txtNewNumberChildrenAtHome = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewNumberChildrenAtHome");
                TextBox txtNewEnglishEducation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewEnglishEducation");
                TextBox txtNewSpanishEducation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewSpanishEducation");
                TextBox txtNewFrenchEducation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewFrenchEducation");
                TextBox txtNewEnglishOccupation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewEnglishOccupation");
                TextBox txtNewSpanishOccupation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewSpanishOccupation");
                TextBox txtNewFrenchOccupation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewFrenchOccupation");
                TextBox txtNewHouseOwnerFlag = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewHouseOwnerFlag");
                TextBox txtNewNumberCarsOwned = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewNumberCarsOwned");
                TextBox txtNewAddressLine1 = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewAddressLine1");
                TextBox txtNewAddressLine2 = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewAddressLine2");
                TextBox txtNewPhone = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewPhone");
                TextBox txtNewDateFirstPurchase = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewDateFirstPurchase");
                TextBox txtNewCommuteDistance = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewCommuteDistance");

                dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewGeographyKey.SelectedValue)) {
                        clsdbo_DimCustomer.GeographyKey = null;
                    } else {
                        clsdbo_DimCustomer.GeographyKey = System.Convert.ToInt32(txtNewGeographyKey.SelectedValue); }
                    clsdbo_DimCustomer.CustomerAlternateKey = System.Convert.ToString(txtNewCustomerAlternateKey.Text);
                    if (string.IsNullOrEmpty(txtNewTitle.Text)) {
                        clsdbo_DimCustomer.Title = null;
                    } else {
                        clsdbo_DimCustomer.Title = txtNewTitle.Text; }
                    if (string.IsNullOrEmpty(txtNewFirstName.Text)) {
                        clsdbo_DimCustomer.FirstName = null;
                    } else {
                        clsdbo_DimCustomer.FirstName = txtNewFirstName.Text; }
                    if (string.IsNullOrEmpty(txtNewMiddleName.Text)) {
                        clsdbo_DimCustomer.MiddleName = null;
                    } else {
                        clsdbo_DimCustomer.MiddleName = txtNewMiddleName.Text; }
                    if (string.IsNullOrEmpty(txtNewLastName.Text)) {
                        clsdbo_DimCustomer.LastName = null;
                    } else {
                        clsdbo_DimCustomer.LastName = txtNewLastName.Text; }
                    clsdbo_DimCustomer.NameStyle = txtNewNameStyle.Checked ? true : false;                        
                    if (string.IsNullOrEmpty(txtNewBirthDate.Text)) {
                        clsdbo_DimCustomer.BirthDate = null;
                    } else {
                        clsdbo_DimCustomer.BirthDate = System.Convert.ToDateTime(txtNewBirthDate.Text); }
                    if (string.IsNullOrEmpty(txtNewMaritalStatus.Text)) {
                        clsdbo_DimCustomer.MaritalStatus = null;
                    } else {
                        clsdbo_DimCustomer.MaritalStatus = txtNewMaritalStatus.Text; }
                    if (string.IsNullOrEmpty(txtNewSuffix.Text)) {
                        clsdbo_DimCustomer.Suffix = null;
                    } else {
                        clsdbo_DimCustomer.Suffix = txtNewSuffix.Text; }
                    if (string.IsNullOrEmpty(txtNewGender.Text)) {
                        clsdbo_DimCustomer.Gender = null;
                    } else {
                        clsdbo_DimCustomer.Gender = txtNewGender.Text; }
                    if (string.IsNullOrEmpty(txtNewEmailAddress.Text)) {
                        clsdbo_DimCustomer.EmailAddress = null;
                    } else {
                        clsdbo_DimCustomer.EmailAddress = txtNewEmailAddress.Text; }
                    if (string.IsNullOrEmpty(txtNewYearlyIncome.Text)) {
                        clsdbo_DimCustomer.YearlyIncome = null;
                    } else {
                        clsdbo_DimCustomer.YearlyIncome = System.Convert.ToDecimal(txtNewYearlyIncome.Text); }
                    if (string.IsNullOrEmpty(txtNewTotalChildren.Text)) {
                        clsdbo_DimCustomer.TotalChildren = null;
                    } else {
                        clsdbo_DimCustomer.TotalChildren = System.Convert.ToByte(txtNewTotalChildren.Text); }
                    if (string.IsNullOrEmpty(txtNewNumberChildrenAtHome.Text)) {
                        clsdbo_DimCustomer.NumberChildrenAtHome = null;
                    } else {
                        clsdbo_DimCustomer.NumberChildrenAtHome = System.Convert.ToByte(txtNewNumberChildrenAtHome.Text); }
                    if (string.IsNullOrEmpty(txtNewEnglishEducation.Text)) {
                        clsdbo_DimCustomer.EnglishEducation = null;
                    } else {
                        clsdbo_DimCustomer.EnglishEducation = txtNewEnglishEducation.Text; }
                    if (string.IsNullOrEmpty(txtNewSpanishEducation.Text)) {
                        clsdbo_DimCustomer.SpanishEducation = null;
                    } else {
                        clsdbo_DimCustomer.SpanishEducation = txtNewSpanishEducation.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchEducation.Text)) {
                        clsdbo_DimCustomer.FrenchEducation = null;
                    } else {
                        clsdbo_DimCustomer.FrenchEducation = txtNewFrenchEducation.Text; }
                    if (string.IsNullOrEmpty(txtNewEnglishOccupation.Text)) {
                        clsdbo_DimCustomer.EnglishOccupation = null;
                    } else {
                        clsdbo_DimCustomer.EnglishOccupation = txtNewEnglishOccupation.Text; }
                    if (string.IsNullOrEmpty(txtNewSpanishOccupation.Text)) {
                        clsdbo_DimCustomer.SpanishOccupation = null;
                    } else {
                        clsdbo_DimCustomer.SpanishOccupation = txtNewSpanishOccupation.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchOccupation.Text)) {
                        clsdbo_DimCustomer.FrenchOccupation = null;
                    } else {
                        clsdbo_DimCustomer.FrenchOccupation = txtNewFrenchOccupation.Text; }
                    if (string.IsNullOrEmpty(txtNewHouseOwnerFlag.Text)) {
                        clsdbo_DimCustomer.HouseOwnerFlag = null;
                    } else {
                        clsdbo_DimCustomer.HouseOwnerFlag = txtNewHouseOwnerFlag.Text; }
                    if (string.IsNullOrEmpty(txtNewNumberCarsOwned.Text)) {
                        clsdbo_DimCustomer.NumberCarsOwned = null;
                    } else {
                        clsdbo_DimCustomer.NumberCarsOwned = System.Convert.ToByte(txtNewNumberCarsOwned.Text); }
                    if (string.IsNullOrEmpty(txtNewAddressLine1.Text)) {
                        clsdbo_DimCustomer.AddressLine1 = null;
                    } else {
                        clsdbo_DimCustomer.AddressLine1 = txtNewAddressLine1.Text; }
                    if (string.IsNullOrEmpty(txtNewAddressLine2.Text)) {
                        clsdbo_DimCustomer.AddressLine2 = null;
                    } else {
                        clsdbo_DimCustomer.AddressLine2 = txtNewAddressLine2.Text; }
                    if (string.IsNullOrEmpty(txtNewPhone.Text)) {
                        clsdbo_DimCustomer.Phone = null;
                    } else {
                        clsdbo_DimCustomer.Phone = txtNewPhone.Text; }
                    if (string.IsNullOrEmpty(txtNewDateFirstPurchase.Text)) {
                        clsdbo_DimCustomer.DateFirstPurchase = null;
                    } else {
                        clsdbo_DimCustomer.DateFirstPurchase = System.Convert.ToDateTime(txtNewDateFirstPurchase.Text); }
                    if (string.IsNullOrEmpty(txtNewCommuteDistance.Text)) {
                        clsdbo_DimCustomer.CommuteDistance = null;
                    } else {
                        clsdbo_DimCustomer.CommuteDistance = txtNewCommuteDistance.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimCustomerDataClass.Add(clsdbo_DimCustomer);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimCustomer");
                        LoadGriddbo_DimCustomer();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Customer ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtCustomerKey = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerKey");
                DropDownList txtGeographyKey = (DropDownList)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGeographyKey");
                TextBox txtCustomerAlternateKey = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerAlternateKey");
                TextBox txtTitle = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTitle");
                TextBox txtFirstName = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstName");
                TextBox txtMiddleName = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMiddleName");
                TextBox txtLastName = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastName");
                CheckBox txtNameStyle = (CheckBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNameStyle");
                TextBox txtBirthDate = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBirthDate");
                TextBox txtMaritalStatus = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaritalStatus");
                TextBox txtSuffix = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSuffix");
                TextBox txtGender = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGender");
                TextBox txtEmailAddress = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmailAddress");
                TextBox txtYearlyIncome = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtYearlyIncome");
                TextBox txtTotalChildren = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalChildren");
                TextBox txtNumberChildrenAtHome = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberChildrenAtHome");
                TextBox txtEnglishEducation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishEducation");
                TextBox txtSpanishEducation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishEducation");
                TextBox txtFrenchEducation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchEducation");
                TextBox txtEnglishOccupation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishOccupation");
                TextBox txtSpanishOccupation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishOccupation");
                TextBox txtFrenchOccupation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchOccupation");
                TextBox txtHouseOwnerFlag = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHouseOwnerFlag");
                TextBox txtNumberCarsOwned = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberCarsOwned");
                TextBox txtAddressLine1 = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine1");
                TextBox txtAddressLine2 = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine2");
                TextBox txtPhone = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
                TextBox txtDateFirstPurchase = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateFirstPurchase");
                TextBox txtCommuteDistance = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCommuteDistance");

                dbo_DimCustomerClass oclsdbo_DimCustomer = new dbo_DimCustomerClass();
                dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
                oclsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(txtCustomerKey.Text);
                oclsdbo_DimCustomer = dbo_DimCustomerDataClass.Select_Record(oclsdbo_DimCustomer);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtGeographyKey.SelectedValue)) {
                        clsdbo_DimCustomer.GeographyKey = null;
                    } else {
                        clsdbo_DimCustomer.GeographyKey = System.Convert.ToInt32(txtGeographyKey.SelectedValue); }
                    clsdbo_DimCustomer.CustomerAlternateKey = System.Convert.ToString(txtCustomerAlternateKey.Text);
                    if (string.IsNullOrEmpty(txtTitle.Text)) {
                        clsdbo_DimCustomer.Title = null;
                    } else {
                        clsdbo_DimCustomer.Title = txtTitle.Text; }
                    if (string.IsNullOrEmpty(txtFirstName.Text)) {
                        clsdbo_DimCustomer.FirstName = null;
                    } else {
                        clsdbo_DimCustomer.FirstName = txtFirstName.Text; }
                    if (string.IsNullOrEmpty(txtMiddleName.Text)) {
                        clsdbo_DimCustomer.MiddleName = null;
                    } else {
                        clsdbo_DimCustomer.MiddleName = txtMiddleName.Text; }
                    if (string.IsNullOrEmpty(txtLastName.Text)) {
                        clsdbo_DimCustomer.LastName = null;
                    } else {
                        clsdbo_DimCustomer.LastName = txtLastName.Text; }
                    clsdbo_DimCustomer.NameStyle = txtNameStyle.Checked ? true : false;                        
                    if (string.IsNullOrEmpty(txtBirthDate.Text)) {
                        clsdbo_DimCustomer.BirthDate = null;
                    } else {
                        clsdbo_DimCustomer.BirthDate = System.Convert.ToDateTime(txtBirthDate.Text); }
                    if (string.IsNullOrEmpty(txtMaritalStatus.Text)) {
                        clsdbo_DimCustomer.MaritalStatus = null;
                    } else {
                        clsdbo_DimCustomer.MaritalStatus = txtMaritalStatus.Text; }
                    if (string.IsNullOrEmpty(txtSuffix.Text)) {
                        clsdbo_DimCustomer.Suffix = null;
                    } else {
                        clsdbo_DimCustomer.Suffix = txtSuffix.Text; }
                    if (string.IsNullOrEmpty(txtGender.Text)) {
                        clsdbo_DimCustomer.Gender = null;
                    } else {
                        clsdbo_DimCustomer.Gender = txtGender.Text; }
                    if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
                        clsdbo_DimCustomer.EmailAddress = null;
                    } else {
                        clsdbo_DimCustomer.EmailAddress = txtEmailAddress.Text; }
                    if (string.IsNullOrEmpty(txtYearlyIncome.Text)) {
                        clsdbo_DimCustomer.YearlyIncome = null;
                    } else {
                        clsdbo_DimCustomer.YearlyIncome = System.Convert.ToDecimal(txtYearlyIncome.Text); }
                    if (string.IsNullOrEmpty(txtTotalChildren.Text)) {
                        clsdbo_DimCustomer.TotalChildren = null;
                    } else {
                        clsdbo_DimCustomer.TotalChildren = System.Convert.ToByte(txtTotalChildren.Text); }
                    if (string.IsNullOrEmpty(txtNumberChildrenAtHome.Text)) {
                        clsdbo_DimCustomer.NumberChildrenAtHome = null;
                    } else {
                        clsdbo_DimCustomer.NumberChildrenAtHome = System.Convert.ToByte(txtNumberChildrenAtHome.Text); }
                    if (string.IsNullOrEmpty(txtEnglishEducation.Text)) {
                        clsdbo_DimCustomer.EnglishEducation = null;
                    } else {
                        clsdbo_DimCustomer.EnglishEducation = txtEnglishEducation.Text; }
                    if (string.IsNullOrEmpty(txtSpanishEducation.Text)) {
                        clsdbo_DimCustomer.SpanishEducation = null;
                    } else {
                        clsdbo_DimCustomer.SpanishEducation = txtSpanishEducation.Text; }
                    if (string.IsNullOrEmpty(txtFrenchEducation.Text)) {
                        clsdbo_DimCustomer.FrenchEducation = null;
                    } else {
                        clsdbo_DimCustomer.FrenchEducation = txtFrenchEducation.Text; }
                    if (string.IsNullOrEmpty(txtEnglishOccupation.Text)) {
                        clsdbo_DimCustomer.EnglishOccupation = null;
                    } else {
                        clsdbo_DimCustomer.EnglishOccupation = txtEnglishOccupation.Text; }
                    if (string.IsNullOrEmpty(txtSpanishOccupation.Text)) {
                        clsdbo_DimCustomer.SpanishOccupation = null;
                    } else {
                        clsdbo_DimCustomer.SpanishOccupation = txtSpanishOccupation.Text; }
                    if (string.IsNullOrEmpty(txtFrenchOccupation.Text)) {
                        clsdbo_DimCustomer.FrenchOccupation = null;
                    } else {
                        clsdbo_DimCustomer.FrenchOccupation = txtFrenchOccupation.Text; }
                    if (string.IsNullOrEmpty(txtHouseOwnerFlag.Text)) {
                        clsdbo_DimCustomer.HouseOwnerFlag = null;
                    } else {
                        clsdbo_DimCustomer.HouseOwnerFlag = txtHouseOwnerFlag.Text; }
                    if (string.IsNullOrEmpty(txtNumberCarsOwned.Text)) {
                        clsdbo_DimCustomer.NumberCarsOwned = null;
                    } else {
                        clsdbo_DimCustomer.NumberCarsOwned = System.Convert.ToByte(txtNumberCarsOwned.Text); }
                    if (string.IsNullOrEmpty(txtAddressLine1.Text)) {
                        clsdbo_DimCustomer.AddressLine1 = null;
                    } else {
                        clsdbo_DimCustomer.AddressLine1 = txtAddressLine1.Text; }
                    if (string.IsNullOrEmpty(txtAddressLine2.Text)) {
                        clsdbo_DimCustomer.AddressLine2 = null;
                    } else {
                        clsdbo_DimCustomer.AddressLine2 = txtAddressLine2.Text; }
                    if (string.IsNullOrEmpty(txtPhone.Text)) {
                        clsdbo_DimCustomer.Phone = null;
                    } else {
                        clsdbo_DimCustomer.Phone = txtPhone.Text; }
                    if (string.IsNullOrEmpty(txtDateFirstPurchase.Text)) {
                        clsdbo_DimCustomer.DateFirstPurchase = null;
                    } else {
                        clsdbo_DimCustomer.DateFirstPurchase = System.Convert.ToDateTime(txtDateFirstPurchase.Text); }
                    if (string.IsNullOrEmpty(txtCommuteDistance.Text)) {
                        clsdbo_DimCustomer.CommuteDistance = null;
                    } else {
                        clsdbo_DimCustomer.CommuteDistance = txtCommuteDistance.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimCustomerDataClass.Update(oclsdbo_DimCustomer, clsdbo_DimCustomer);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimCustomer");
                        grddbo_DimCustomer.EditIndex = -1;
                        LoadGriddbo_DimCustomer();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Customer ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
            Label lblCustomerKey = (Label)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblCustomerKey");
            clsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(lblCustomerKey.Text);
            clsdbo_DimCustomer = dbo_DimCustomerDataClass.Select_Record(clsdbo_DimCustomer);
            bool bSucess = false;
            bSucess = dbo_DimCustomerDataClass.Delete(clsdbo_DimCustomer);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimCustomer");
                LoadGriddbo_DimCustomer();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Customer ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtCustomerKey = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerKey");
            DropDownList txtGeographyKey = (DropDownList)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGeographyKey");
            TextBox txtCustomerAlternateKey = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerAlternateKey");
            TextBox txtTitle = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTitle");
            TextBox txtFirstName = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstName");
            TextBox txtMiddleName = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMiddleName");
            TextBox txtLastName = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastName");
            CheckBox txtNameStyle = (CheckBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNameStyle");
            TextBox txtBirthDate = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBirthDate");
            TextBox txtMaritalStatus = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaritalStatus");
            TextBox txtSuffix = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSuffix");
            TextBox txtGender = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGender");
            TextBox txtEmailAddress = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmailAddress");
            TextBox txtYearlyIncome = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtYearlyIncome");
            TextBox txtTotalChildren = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalChildren");
            TextBox txtNumberChildrenAtHome = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberChildrenAtHome");
            TextBox txtEnglishEducation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishEducation");
            TextBox txtSpanishEducation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishEducation");
            TextBox txtFrenchEducation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchEducation");
            TextBox txtEnglishOccupation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishOccupation");
            TextBox txtSpanishOccupation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishOccupation");
            TextBox txtFrenchOccupation = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchOccupation");
            TextBox txtHouseOwnerFlag = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHouseOwnerFlag");
            TextBox txtNumberCarsOwned = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberCarsOwned");
            TextBox txtAddressLine1 = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine1");
            TextBox txtAddressLine2 = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine2");
            TextBox txtPhone = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
            TextBox txtDateFirstPurchase = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateFirstPurchase");
            TextBox txtCommuteDistance = (TextBox)grddbo_DimCustomer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCommuteDistance");

            if (txtCustomerAlternateKey.Text == "") {
                ec.ShowMessage(" Customer Alternate Key is Required. ", " Dbo. Dim Customer ");
                txtCustomerAlternateKey.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewGeographyKey = (DropDownList)grddbo_DimCustomer.FooterRow.FindControl("txtNewGeographyKey");
            TextBox txtNewCustomerAlternateKey = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewCustomerAlternateKey");
            TextBox txtNewTitle = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewTitle");
            TextBox txtNewFirstName = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewFirstName");
            TextBox txtNewMiddleName = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewMiddleName");
            TextBox txtNewLastName = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewLastName");
            CheckBox txtNewNameStyle = (CheckBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewNameStyle");

            TextBox txtNewBirthDate = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewBirthDate");
            TextBox txtNewMaritalStatus = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewMaritalStatus");
            TextBox txtNewSuffix = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewSuffix");
            TextBox txtNewGender = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewGender");
            TextBox txtNewEmailAddress = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewEmailAddress");
            TextBox txtNewYearlyIncome = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewYearlyIncome");
            TextBox txtNewTotalChildren = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewTotalChildren");
            TextBox txtNewNumberChildrenAtHome = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewNumberChildrenAtHome");
            TextBox txtNewEnglishEducation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewEnglishEducation");
            TextBox txtNewSpanishEducation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewSpanishEducation");
            TextBox txtNewFrenchEducation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewFrenchEducation");
            TextBox txtNewEnglishOccupation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewEnglishOccupation");
            TextBox txtNewSpanishOccupation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewSpanishOccupation");
            TextBox txtNewFrenchOccupation = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewFrenchOccupation");
            TextBox txtNewHouseOwnerFlag = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewHouseOwnerFlag");
            TextBox txtNewNumberCarsOwned = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewNumberCarsOwned");
            TextBox txtNewAddressLine1 = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewAddressLine1");
            TextBox txtNewAddressLine2 = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewAddressLine2");
            TextBox txtNewPhone = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewPhone");
            TextBox txtNewDateFirstPurchase = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewDateFirstPurchase");
            TextBox txtNewCommuteDistance = (TextBox)grddbo_DimCustomer.FooterRow.FindControl("txtNewCommuteDistance");

            if (txtNewCustomerAlternateKey.Text == "") {
                ec.ShowMessage(" Customer Alternate Key is Required. ", " Dbo. Dim Customer ");
                txtNewCustomerAlternateKey.Focus();
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
		    grddbo_DimCustomer.PageIndex = 0;
		    grddbo_DimCustomer.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimCustomer();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimCustomer");
		    LoadGriddbo_DimCustomer();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimCustomer");
			if ((Session["dvdbo_DimCustomer"] != null)) {
				dvdbo_DimCustomer = (DataView)Session["dvdbo_DimCustomer"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimCustomer = dbo_DimCustomerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimCustomer"] = dvdbo_DimCustomer;
		    	}
                if (dvdbo_DimCustomer.Count > 0) {
                    grddbo_DimCustomer.DataSource = dvdbo_DimCustomer;
                    grddbo_DimCustomer.DataBind();
                }
                if (dvdbo_DimCustomer.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("CustomerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("StateProvinceName", Type.GetType("System.Int32"));
                    dt.Columns.Add("CustomerAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("Title", Type.GetType("System.String"));
                    dt.Columns.Add("FirstName", Type.GetType("System.String"));
                    dt.Columns.Add("MiddleName", Type.GetType("System.String"));
                    dt.Columns.Add("LastName", Type.GetType("System.String"));
                    dt.Columns.Add("NameStyle", Type.GetType("System.Boolean"));
                    dt.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("MaritalStatus", Type.GetType("System.String"));
                    dt.Columns.Add("Suffix", Type.GetType("System.String"));
                    dt.Columns.Add("Gender", Type.GetType("System.String"));
                    dt.Columns.Add("EmailAddress", Type.GetType("System.String"));
                    dt.Columns.Add("YearlyIncome", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TotalChildren", Type.GetType("System.Byte"));
                    dt.Columns.Add("NumberChildrenAtHome", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishEducation", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishEducation", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchEducation", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishOccupation", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishOccupation", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchOccupation", Type.GetType("System.String"));
                    dt.Columns.Add("HouseOwnerFlag", Type.GetType("System.String"));
                    dt.Columns.Add("NumberCarsOwned", Type.GetType("System.Byte"));
                    dt.Columns.Add("AddressLine1", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine2", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("DateFirstPurchase", Type.GetType("System.DateTime"));
                    dt.Columns.Add("CommuteDistance", Type.GetType("System.String"));
                    dvdbo_DimCustomer = dt.DefaultView;
                    Session["dvdbo_DimCustomer"] = dvdbo_DimCustomer;

                    grddbo_DimCustomer.DataSource = dvdbo_DimCustomer;
                    grddbo_DimCustomer.DataBind();

                    int TotalColumns = grddbo_DimCustomer.Rows[0].Cells.Count;
                    grddbo_DimCustomer.Rows[0].Cells.Clear();
                    grddbo_DimCustomer.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimCustomer.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimCustomer.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimCustomer.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
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
                    { dt = dbo_DimCustomerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimCustomerDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Customer", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimCustomer"];
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
 
