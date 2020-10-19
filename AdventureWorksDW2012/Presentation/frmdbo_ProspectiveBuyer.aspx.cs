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
    public partial class frmdbo_ProspectiveBuyer : System.Web.UI.Page
    {

        private dbo_ProspectiveBuyerDataClass clsdbo_ProspectiveBuyerData = new dbo_ProspectiveBuyerDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_ProspectiveBuyer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_ProspectiveBuyer");
                Session.Remove("Row");

                cmbFields.Items.Add("Prospective Buyer Key");
                cmbFields.Items.Add("Prospect Alternate Key");
                cmbFields.Items.Add("First Name");
                cmbFields.Items.Add("Middle Name");
                cmbFields.Items.Add("Last Name");
                cmbFields.Items.Add("Birth Date");
                cmbFields.Items.Add("Marital Status");
                cmbFields.Items.Add("Gender");
                cmbFields.Items.Add("Email Address");
                cmbFields.Items.Add("Yearly Income");
                cmbFields.Items.Add("Total Children");
                cmbFields.Items.Add("Number Children At Home");
                cmbFields.Items.Add("Education");
                cmbFields.Items.Add("Occupation");
                cmbFields.Items.Add("House Owner Flag");
                cmbFields.Items.Add("Number Cars Owned");
                cmbFields.Items.Add("Address Line1");
                cmbFields.Items.Add("Address Line2");
                cmbFields.Items.Add("City");
                cmbFields.Items.Add("State Province Code");
                cmbFields.Items.Add("Postal Code");
                cmbFields.Items.Add("Phone");
                cmbFields.Items.Add("Salutation");
                cmbFields.Items.Add("Unknown");

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

                LoadGriddbo_ProspectiveBuyer();
            }
        }

        private void LoadGriddbo_ProspectiveBuyer()
        {
            try {
                if ((Session["dvdbo_ProspectiveBuyer"] != null)) {
                    dvdbo_ProspectiveBuyer = (DataView)Session["dvdbo_ProspectiveBuyer"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.SelectAll().DefaultView;
                    Session["dvdbo_ProspectiveBuyer"] = dvdbo_ProspectiveBuyer;
                }
                if (dvdbo_ProspectiveBuyer.Count > 0) {
                    grddbo_ProspectiveBuyer.DataSource = dvdbo_ProspectiveBuyer;
                    grddbo_ProspectiveBuyer.DataBind();
                }
                if (dvdbo_ProspectiveBuyer.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProspectiveBuyerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProspectAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("FirstName", Type.GetType("System.String"));
                    dt.Columns.Add("MiddleName", Type.GetType("System.String"));
                    dt.Columns.Add("LastName", Type.GetType("System.String"));
                    dt.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("MaritalStatus", Type.GetType("System.String"));
                    dt.Columns.Add("Gender", Type.GetType("System.String"));
                    dt.Columns.Add("EmailAddress", Type.GetType("System.String"));
                    dt.Columns.Add("YearlyIncome", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TotalChildren", Type.GetType("System.Byte"));
                    dt.Columns.Add("NumberChildrenAtHome", Type.GetType("System.Byte"));
                    dt.Columns.Add("Education", Type.GetType("System.String"));
                    dt.Columns.Add("Occupation", Type.GetType("System.String"));
                    dt.Columns.Add("HouseOwnerFlag", Type.GetType("System.String"));
                    dt.Columns.Add("NumberCarsOwned", Type.GetType("System.Byte"));
                    dt.Columns.Add("AddressLine1", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine2", Type.GetType("System.String"));
                    dt.Columns.Add("City", Type.GetType("System.String"));
                    dt.Columns.Add("StateProvinceCode", Type.GetType("System.String"));
                    dt.Columns.Add("PostalCode", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("Salutation", Type.GetType("System.String"));
                    dt.Columns.Add("Unknown", Type.GetType("System.Int32"));
                    dvdbo_ProspectiveBuyer = dt.DefaultView;
                    Session["dvdbo_ProspectiveBuyer"] = dvdbo_ProspectiveBuyer;

                    grddbo_ProspectiveBuyer.DataSource = dvdbo_ProspectiveBuyer;
                    grddbo_ProspectiveBuyer.DataBind();

                    int TotalColumns = grddbo_ProspectiveBuyer.Rows[0].Cells.Count;
                    grddbo_ProspectiveBuyer.Rows[0].Cells.Clear();
                    grddbo_ProspectiveBuyer.Rows[0].Cells.Add(new TableCell());
                    grddbo_ProspectiveBuyer.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_ProspectiveBuyer.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_ProspectiveBuyer.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Prospective Buyer ");
            }
        }

        protected void grddbo_ProspectiveBuyer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtProspectiveBuyerKey = (TextBox)e.Row.FindControl("txtProspectiveBuyerKey");
                if (txtProspectiveBuyerKey != null) {
                    txtProspectiveBuyerKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewProspectiveBuyerKey = (TextBox)e.Row.FindControl("txtNewProspectiveBuyerKey");
                if (txtNewProspectiveBuyerKey != null) {
                    txtNewProspectiveBuyerKey.Enabled = false;
                }
                txtNewProspectiveBuyerKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "ProspectiveBuyer"));
            }
        }

        protected void grddbo_ProspectiveBuyer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_ProspectiveBuyer.EditIndex = -1;
            LoadGriddbo_ProspectiveBuyer();
        }

        protected void grddbo_ProspectiveBuyer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_ProspectiveBuyer.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_ProspectiveBuyer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_ProspectiveBuyer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_ProspectiveBuyer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_ProspectiveBuyer_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_ProspectiveBuyer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_ProspectiveBuyer.PageIndex = e.NewPageIndex;
            LoadGriddbo_ProspectiveBuyer();
        }

        protected void grddbo_ProspectiveBuyer_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_ProspectiveBuyer();
        }

        private void Edit()
        {
            try {
                dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
                Label lblProspectiveBuyerKey = (Label)grddbo_ProspectiveBuyer.Rows[grddbo_ProspectiveBuyer.EditIndex].FindControl("lblProspectiveBuyerKey");
                clsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(lblProspectiveBuyerKey.Text);
                clsdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Select_Record(clsdbo_ProspectiveBuyer);


                LoadGriddbo_ProspectiveBuyer();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewProspectAlternateKey = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewProspectAlternateKey");
                TextBox txtNewFirstName = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewFirstName");
                TextBox txtNewMiddleName = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewMiddleName");
                TextBox txtNewLastName = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewLastName");
                TextBox txtNewBirthDate = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewBirthDate");
                TextBox txtNewMaritalStatus = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewMaritalStatus");
                TextBox txtNewGender = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewGender");
                TextBox txtNewEmailAddress = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewEmailAddress");
                TextBox txtNewYearlyIncome = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewYearlyIncome");
                TextBox txtNewTotalChildren = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewTotalChildren");
                TextBox txtNewNumberChildrenAtHome = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewNumberChildrenAtHome");
                TextBox txtNewEducation = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewEducation");
                TextBox txtNewOccupation = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewOccupation");
                TextBox txtNewHouseOwnerFlag = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewHouseOwnerFlag");
                TextBox txtNewNumberCarsOwned = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewNumberCarsOwned");
                TextBox txtNewAddressLine1 = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewAddressLine1");
                TextBox txtNewAddressLine2 = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewAddressLine2");
                TextBox txtNewCity = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewCity");
                TextBox txtNewStateProvinceCode = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewStateProvinceCode");
                TextBox txtNewPostalCode = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewPostalCode");
                TextBox txtNewPhone = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewPhone");
                TextBox txtNewSalutation = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewSalutation");
                TextBox txtNewUnknown = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewUnknown");

                dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewProspectAlternateKey.Text)) {
                        clsdbo_ProspectiveBuyer.ProspectAlternateKey = null;
                    } else {
                        clsdbo_ProspectiveBuyer.ProspectAlternateKey = txtNewProspectAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtNewFirstName.Text)) {
                        clsdbo_ProspectiveBuyer.FirstName = null;
                    } else {
                        clsdbo_ProspectiveBuyer.FirstName = txtNewFirstName.Text; }
                    if (string.IsNullOrEmpty(txtNewMiddleName.Text)) {
                        clsdbo_ProspectiveBuyer.MiddleName = null;
                    } else {
                        clsdbo_ProspectiveBuyer.MiddleName = txtNewMiddleName.Text; }
                    if (string.IsNullOrEmpty(txtNewLastName.Text)) {
                        clsdbo_ProspectiveBuyer.LastName = null;
                    } else {
                        clsdbo_ProspectiveBuyer.LastName = txtNewLastName.Text; }
                    if (string.IsNullOrEmpty(txtNewBirthDate.Text)) {
                        clsdbo_ProspectiveBuyer.BirthDate = null;
                    } else {
                        clsdbo_ProspectiveBuyer.BirthDate = System.Convert.ToDateTime(txtNewBirthDate.Text); }
                    if (string.IsNullOrEmpty(txtNewMaritalStatus.Text)) {
                        clsdbo_ProspectiveBuyer.MaritalStatus = null;
                    } else {
                        clsdbo_ProspectiveBuyer.MaritalStatus = txtNewMaritalStatus.Text; }
                    if (string.IsNullOrEmpty(txtNewGender.Text)) {
                        clsdbo_ProspectiveBuyer.Gender = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Gender = txtNewGender.Text; }
                    if (string.IsNullOrEmpty(txtNewEmailAddress.Text)) {
                        clsdbo_ProspectiveBuyer.EmailAddress = null;
                    } else {
                        clsdbo_ProspectiveBuyer.EmailAddress = txtNewEmailAddress.Text; }
                    if (string.IsNullOrEmpty(txtNewYearlyIncome.Text)) {
                        clsdbo_ProspectiveBuyer.YearlyIncome = null;
                    } else {
                        clsdbo_ProspectiveBuyer.YearlyIncome = System.Convert.ToDecimal(txtNewYearlyIncome.Text); }
                    if (string.IsNullOrEmpty(txtNewTotalChildren.Text)) {
                        clsdbo_ProspectiveBuyer.TotalChildren = null;
                    } else {
                        clsdbo_ProspectiveBuyer.TotalChildren = System.Convert.ToByte(txtNewTotalChildren.Text); }
                    if (string.IsNullOrEmpty(txtNewNumberChildrenAtHome.Text)) {
                        clsdbo_ProspectiveBuyer.NumberChildrenAtHome = null;
                    } else {
                        clsdbo_ProspectiveBuyer.NumberChildrenAtHome = System.Convert.ToByte(txtNewNumberChildrenAtHome.Text); }
                    if (string.IsNullOrEmpty(txtNewEducation.Text)) {
                        clsdbo_ProspectiveBuyer.Education = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Education = txtNewEducation.Text; }
                    if (string.IsNullOrEmpty(txtNewOccupation.Text)) {
                        clsdbo_ProspectiveBuyer.Occupation = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Occupation = txtNewOccupation.Text; }
                    if (string.IsNullOrEmpty(txtNewHouseOwnerFlag.Text)) {
                        clsdbo_ProspectiveBuyer.HouseOwnerFlag = null;
                    } else {
                        clsdbo_ProspectiveBuyer.HouseOwnerFlag = txtNewHouseOwnerFlag.Text; }
                    if (string.IsNullOrEmpty(txtNewNumberCarsOwned.Text)) {
                        clsdbo_ProspectiveBuyer.NumberCarsOwned = null;
                    } else {
                        clsdbo_ProspectiveBuyer.NumberCarsOwned = System.Convert.ToByte(txtNewNumberCarsOwned.Text); }
                    if (string.IsNullOrEmpty(txtNewAddressLine1.Text)) {
                        clsdbo_ProspectiveBuyer.AddressLine1 = null;
                    } else {
                        clsdbo_ProspectiveBuyer.AddressLine1 = txtNewAddressLine1.Text; }
                    if (string.IsNullOrEmpty(txtNewAddressLine2.Text)) {
                        clsdbo_ProspectiveBuyer.AddressLine2 = null;
                    } else {
                        clsdbo_ProspectiveBuyer.AddressLine2 = txtNewAddressLine2.Text; }
                    if (string.IsNullOrEmpty(txtNewCity.Text)) {
                        clsdbo_ProspectiveBuyer.City = null;
                    } else {
                        clsdbo_ProspectiveBuyer.City = txtNewCity.Text; }
                    if (string.IsNullOrEmpty(txtNewStateProvinceCode.Text)) {
                        clsdbo_ProspectiveBuyer.StateProvinceCode = null;
                    } else {
                        clsdbo_ProspectiveBuyer.StateProvinceCode = txtNewStateProvinceCode.Text; }
                    if (string.IsNullOrEmpty(txtNewPostalCode.Text)) {
                        clsdbo_ProspectiveBuyer.PostalCode = null;
                    } else {
                        clsdbo_ProspectiveBuyer.PostalCode = txtNewPostalCode.Text; }
                    if (string.IsNullOrEmpty(txtNewPhone.Text)) {
                        clsdbo_ProspectiveBuyer.Phone = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Phone = txtNewPhone.Text; }
                    if (string.IsNullOrEmpty(txtNewSalutation.Text)) {
                        clsdbo_ProspectiveBuyer.Salutation = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Salutation = txtNewSalutation.Text; }
                    if (string.IsNullOrEmpty(txtNewUnknown.Text)) {
                        clsdbo_ProspectiveBuyer.Unknown = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Unknown = System.Convert.ToInt32(txtNewUnknown.Text); }
                    bool bSucess = false;
                    bSucess = dbo_ProspectiveBuyerDataClass.Add(clsdbo_ProspectiveBuyer);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_ProspectiveBuyer");
                        LoadGriddbo_ProspectiveBuyer();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Prospective Buyer ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtProspectiveBuyerKey = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProspectiveBuyerKey");
                TextBox txtProspectAlternateKey = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProspectAlternateKey");
                TextBox txtFirstName = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstName");
                TextBox txtMiddleName = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMiddleName");
                TextBox txtLastName = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastName");
                TextBox txtBirthDate = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBirthDate");
                TextBox txtMaritalStatus = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaritalStatus");
                TextBox txtGender = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGender");
                TextBox txtEmailAddress = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmailAddress");
                TextBox txtYearlyIncome = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtYearlyIncome");
                TextBox txtTotalChildren = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalChildren");
                TextBox txtNumberChildrenAtHome = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberChildrenAtHome");
                TextBox txtEducation = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEducation");
                TextBox txtOccupation = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOccupation");
                TextBox txtHouseOwnerFlag = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHouseOwnerFlag");
                TextBox txtNumberCarsOwned = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberCarsOwned");
                TextBox txtAddressLine1 = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine1");
                TextBox txtAddressLine2 = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine2");
                TextBox txtCity = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCity");
                TextBox txtStateProvinceCode = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStateProvinceCode");
                TextBox txtPostalCode = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPostalCode");
                TextBox txtPhone = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
                TextBox txtSalutation = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalutation");
                TextBox txtUnknown = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnknown");

                dbo_ProspectiveBuyerClass oclsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
                dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
                oclsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(txtProspectiveBuyerKey.Text);
                oclsdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Select_Record(oclsdbo_ProspectiveBuyer);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtProspectAlternateKey.Text)) {
                        clsdbo_ProspectiveBuyer.ProspectAlternateKey = null;
                    } else {
                        clsdbo_ProspectiveBuyer.ProspectAlternateKey = txtProspectAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtFirstName.Text)) {
                        clsdbo_ProspectiveBuyer.FirstName = null;
                    } else {
                        clsdbo_ProspectiveBuyer.FirstName = txtFirstName.Text; }
                    if (string.IsNullOrEmpty(txtMiddleName.Text)) {
                        clsdbo_ProspectiveBuyer.MiddleName = null;
                    } else {
                        clsdbo_ProspectiveBuyer.MiddleName = txtMiddleName.Text; }
                    if (string.IsNullOrEmpty(txtLastName.Text)) {
                        clsdbo_ProspectiveBuyer.LastName = null;
                    } else {
                        clsdbo_ProspectiveBuyer.LastName = txtLastName.Text; }
                    if (string.IsNullOrEmpty(txtBirthDate.Text)) {
                        clsdbo_ProspectiveBuyer.BirthDate = null;
                    } else {
                        clsdbo_ProspectiveBuyer.BirthDate = System.Convert.ToDateTime(txtBirthDate.Text); }
                    if (string.IsNullOrEmpty(txtMaritalStatus.Text)) {
                        clsdbo_ProspectiveBuyer.MaritalStatus = null;
                    } else {
                        clsdbo_ProspectiveBuyer.MaritalStatus = txtMaritalStatus.Text; }
                    if (string.IsNullOrEmpty(txtGender.Text)) {
                        clsdbo_ProspectiveBuyer.Gender = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Gender = txtGender.Text; }
                    if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
                        clsdbo_ProspectiveBuyer.EmailAddress = null;
                    } else {
                        clsdbo_ProspectiveBuyer.EmailAddress = txtEmailAddress.Text; }
                    if (string.IsNullOrEmpty(txtYearlyIncome.Text)) {
                        clsdbo_ProspectiveBuyer.YearlyIncome = null;
                    } else {
                        clsdbo_ProspectiveBuyer.YearlyIncome = System.Convert.ToDecimal(txtYearlyIncome.Text); }
                    if (string.IsNullOrEmpty(txtTotalChildren.Text)) {
                        clsdbo_ProspectiveBuyer.TotalChildren = null;
                    } else {
                        clsdbo_ProspectiveBuyer.TotalChildren = System.Convert.ToByte(txtTotalChildren.Text); }
                    if (string.IsNullOrEmpty(txtNumberChildrenAtHome.Text)) {
                        clsdbo_ProspectiveBuyer.NumberChildrenAtHome = null;
                    } else {
                        clsdbo_ProspectiveBuyer.NumberChildrenAtHome = System.Convert.ToByte(txtNumberChildrenAtHome.Text); }
                    if (string.IsNullOrEmpty(txtEducation.Text)) {
                        clsdbo_ProspectiveBuyer.Education = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Education = txtEducation.Text; }
                    if (string.IsNullOrEmpty(txtOccupation.Text)) {
                        clsdbo_ProspectiveBuyer.Occupation = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Occupation = txtOccupation.Text; }
                    if (string.IsNullOrEmpty(txtHouseOwnerFlag.Text)) {
                        clsdbo_ProspectiveBuyer.HouseOwnerFlag = null;
                    } else {
                        clsdbo_ProspectiveBuyer.HouseOwnerFlag = txtHouseOwnerFlag.Text; }
                    if (string.IsNullOrEmpty(txtNumberCarsOwned.Text)) {
                        clsdbo_ProspectiveBuyer.NumberCarsOwned = null;
                    } else {
                        clsdbo_ProspectiveBuyer.NumberCarsOwned = System.Convert.ToByte(txtNumberCarsOwned.Text); }
                    if (string.IsNullOrEmpty(txtAddressLine1.Text)) {
                        clsdbo_ProspectiveBuyer.AddressLine1 = null;
                    } else {
                        clsdbo_ProspectiveBuyer.AddressLine1 = txtAddressLine1.Text; }
                    if (string.IsNullOrEmpty(txtAddressLine2.Text)) {
                        clsdbo_ProspectiveBuyer.AddressLine2 = null;
                    } else {
                        clsdbo_ProspectiveBuyer.AddressLine2 = txtAddressLine2.Text; }
                    if (string.IsNullOrEmpty(txtCity.Text)) {
                        clsdbo_ProspectiveBuyer.City = null;
                    } else {
                        clsdbo_ProspectiveBuyer.City = txtCity.Text; }
                    if (string.IsNullOrEmpty(txtStateProvinceCode.Text)) {
                        clsdbo_ProspectiveBuyer.StateProvinceCode = null;
                    } else {
                        clsdbo_ProspectiveBuyer.StateProvinceCode = txtStateProvinceCode.Text; }
                    if (string.IsNullOrEmpty(txtPostalCode.Text)) {
                        clsdbo_ProspectiveBuyer.PostalCode = null;
                    } else {
                        clsdbo_ProspectiveBuyer.PostalCode = txtPostalCode.Text; }
                    if (string.IsNullOrEmpty(txtPhone.Text)) {
                        clsdbo_ProspectiveBuyer.Phone = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Phone = txtPhone.Text; }
                    if (string.IsNullOrEmpty(txtSalutation.Text)) {
                        clsdbo_ProspectiveBuyer.Salutation = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Salutation = txtSalutation.Text; }
                    if (string.IsNullOrEmpty(txtUnknown.Text)) {
                        clsdbo_ProspectiveBuyer.Unknown = null;
                    } else {
                        clsdbo_ProspectiveBuyer.Unknown = System.Convert.ToInt32(txtUnknown.Text); }
                    bool bSucess = false;
                    bSucess = dbo_ProspectiveBuyerDataClass.Update(oclsdbo_ProspectiveBuyer, clsdbo_ProspectiveBuyer);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_ProspectiveBuyer");
                        grddbo_ProspectiveBuyer.EditIndex = -1;
                        LoadGriddbo_ProspectiveBuyer();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Prospective Buyer ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
            Label lblProspectiveBuyerKey = (Label)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblProspectiveBuyerKey");
            clsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(lblProspectiveBuyerKey.Text);
            clsdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Select_Record(clsdbo_ProspectiveBuyer);
            bool bSucess = false;
            bSucess = dbo_ProspectiveBuyerDataClass.Delete(clsdbo_ProspectiveBuyer);
            if (bSucess == true) {
                Session.Remove("dvdbo_ProspectiveBuyer");
                LoadGriddbo_ProspectiveBuyer();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Prospective Buyer ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtProspectiveBuyerKey = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProspectiveBuyerKey");
            TextBox txtProspectAlternateKey = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProspectAlternateKey");
            TextBox txtFirstName = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstName");
            TextBox txtMiddleName = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMiddleName");
            TextBox txtLastName = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastName");
            TextBox txtBirthDate = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBirthDate");
            TextBox txtMaritalStatus = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaritalStatus");
            TextBox txtGender = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGender");
            TextBox txtEmailAddress = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmailAddress");
            TextBox txtYearlyIncome = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtYearlyIncome");
            TextBox txtTotalChildren = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalChildren");
            TextBox txtNumberChildrenAtHome = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberChildrenAtHome");
            TextBox txtEducation = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEducation");
            TextBox txtOccupation = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOccupation");
            TextBox txtHouseOwnerFlag = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHouseOwnerFlag");
            TextBox txtNumberCarsOwned = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNumberCarsOwned");
            TextBox txtAddressLine1 = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine1");
            TextBox txtAddressLine2 = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAddressLine2");
            TextBox txtCity = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCity");
            TextBox txtStateProvinceCode = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStateProvinceCode");
            TextBox txtPostalCode = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPostalCode");
            TextBox txtPhone = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
            TextBox txtSalutation = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalutation");
            TextBox txtUnknown = (TextBox)grddbo_ProspectiveBuyer.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnknown");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewProspectAlternateKey = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewProspectAlternateKey");
            TextBox txtNewFirstName = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewFirstName");
            TextBox txtNewMiddleName = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewMiddleName");
            TextBox txtNewLastName = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewLastName");
            TextBox txtNewBirthDate = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewBirthDate");
            TextBox txtNewMaritalStatus = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewMaritalStatus");
            TextBox txtNewGender = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewGender");
            TextBox txtNewEmailAddress = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewEmailAddress");
            TextBox txtNewYearlyIncome = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewYearlyIncome");
            TextBox txtNewTotalChildren = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewTotalChildren");
            TextBox txtNewNumberChildrenAtHome = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewNumberChildrenAtHome");
            TextBox txtNewEducation = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewEducation");
            TextBox txtNewOccupation = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewOccupation");
            TextBox txtNewHouseOwnerFlag = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewHouseOwnerFlag");
            TextBox txtNewNumberCarsOwned = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewNumberCarsOwned");
            TextBox txtNewAddressLine1 = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewAddressLine1");
            TextBox txtNewAddressLine2 = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewAddressLine2");
            TextBox txtNewCity = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewCity");
            TextBox txtNewStateProvinceCode = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewStateProvinceCode");
            TextBox txtNewPostalCode = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewPostalCode");
            TextBox txtNewPhone = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewPhone");
            TextBox txtNewSalutation = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewSalutation");
            TextBox txtNewUnknown = (TextBox)grddbo_ProspectiveBuyer.FooterRow.FindControl("txtNewUnknown");

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
		    grddbo_ProspectiveBuyer.PageIndex = 0;
		    grddbo_ProspectiveBuyer.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_ProspectiveBuyer();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_ProspectiveBuyer");
		    LoadGriddbo_ProspectiveBuyer();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_ProspectiveBuyer");
			if ((Session["dvdbo_ProspectiveBuyer"] != null)) {
				dvdbo_ProspectiveBuyer = (DataView)Session["dvdbo_ProspectiveBuyer"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_ProspectiveBuyer"] = dvdbo_ProspectiveBuyer;
		    	}
                if (dvdbo_ProspectiveBuyer.Count > 0) {
                    grddbo_ProspectiveBuyer.DataSource = dvdbo_ProspectiveBuyer;
                    grddbo_ProspectiveBuyer.DataBind();
                }
                if (dvdbo_ProspectiveBuyer.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProspectiveBuyerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProspectAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("FirstName", Type.GetType("System.String"));
                    dt.Columns.Add("MiddleName", Type.GetType("System.String"));
                    dt.Columns.Add("LastName", Type.GetType("System.String"));
                    dt.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("MaritalStatus", Type.GetType("System.String"));
                    dt.Columns.Add("Gender", Type.GetType("System.String"));
                    dt.Columns.Add("EmailAddress", Type.GetType("System.String"));
                    dt.Columns.Add("YearlyIncome", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TotalChildren", Type.GetType("System.Byte"));
                    dt.Columns.Add("NumberChildrenAtHome", Type.GetType("System.Byte"));
                    dt.Columns.Add("Education", Type.GetType("System.String"));
                    dt.Columns.Add("Occupation", Type.GetType("System.String"));
                    dt.Columns.Add("HouseOwnerFlag", Type.GetType("System.String"));
                    dt.Columns.Add("NumberCarsOwned", Type.GetType("System.Byte"));
                    dt.Columns.Add("AddressLine1", Type.GetType("System.String"));
                    dt.Columns.Add("AddressLine2", Type.GetType("System.String"));
                    dt.Columns.Add("City", Type.GetType("System.String"));
                    dt.Columns.Add("StateProvinceCode", Type.GetType("System.String"));
                    dt.Columns.Add("PostalCode", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("Salutation", Type.GetType("System.String"));
                    dt.Columns.Add("Unknown", Type.GetType("System.Int32"));
                    dvdbo_ProspectiveBuyer = dt.DefaultView;
                    Session["dvdbo_ProspectiveBuyer"] = dvdbo_ProspectiveBuyer;

                    grddbo_ProspectiveBuyer.DataSource = dvdbo_ProspectiveBuyer;
                    grddbo_ProspectiveBuyer.DataBind();

                    int TotalColumns = grddbo_ProspectiveBuyer.Rows[0].Cells.Count;
                    grddbo_ProspectiveBuyer.Rows[0].Cells.Clear();
                    grddbo_ProspectiveBuyer.Rows[0].Cells.Add(new TableCell());
                    grddbo_ProspectiveBuyer.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_ProspectiveBuyer.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_ProspectiveBuyer.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Prospective Buyer ");
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
                    { dt = dbo_ProspectiveBuyerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_ProspectiveBuyerDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Prospective Buyer", "Many");
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
                    GVExport.DataSource = Session["dvdbo_ProspectiveBuyer"];
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
 
