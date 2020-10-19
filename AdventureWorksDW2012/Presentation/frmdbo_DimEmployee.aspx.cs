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
    public partial class frmdbo_DimEmployee : System.Web.UI.Page
    {

        private dbo_DimEmployeeDataClass clsdbo_DimEmployeeData = new dbo_DimEmployeeDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimEmployee;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ParentEmployeeKey_SelectedValue"] = "";
                Session["SalesTerritoryKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimEmployee");
                Session.Remove("Row");

                cmbFields.Items.Add("Employee Key");
                cmbFields.Items.Add("Parent Employee Key");
                cmbFields.Items.Add("Employee National I D Alternate Key");
                cmbFields.Items.Add("Parent Employee National I D Alternate Key");
                cmbFields.Items.Add("Sales Territory Key");
                cmbFields.Items.Add("First Name");
                cmbFields.Items.Add("Last Name");
                cmbFields.Items.Add("Middle Name");
                cmbFields.Items.Add("Name Style");
                cmbFields.Items.Add("Title");
                cmbFields.Items.Add("Hire Date");
                cmbFields.Items.Add("Birth Date");
                cmbFields.Items.Add("Login I D");
                cmbFields.Items.Add("Email Address");
                cmbFields.Items.Add("Phone");
                cmbFields.Items.Add("Marital Status");
                cmbFields.Items.Add("Emergency Contact Name");
                cmbFields.Items.Add("Emergency Contact Phone");
                cmbFields.Items.Add("Salaried Flag");
                cmbFields.Items.Add("Gender");
                cmbFields.Items.Add("Pay Frequency");
                cmbFields.Items.Add("Base Rate");
                cmbFields.Items.Add("Vacation Hours");
                cmbFields.Items.Add("Sick Leave Hours");
                cmbFields.Items.Add("Current Flag");
                cmbFields.Items.Add("Sales Person Flag");
                cmbFields.Items.Add("Department Name");
                cmbFields.Items.Add("Start Date");
                cmbFields.Items.Add("End Date");
                cmbFields.Items.Add("Status");

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

                LoadGriddbo_DimEmployee();
            }
        }

        private void Loaddbo_DimEmployee_dbo_DimEmployeeComboBox68(GridViewRowEventArgs e)
        {
            List<dbo_DimEmployee_dbo_DimEmployeeClass68> dbo_DimEmployee_dbo_DimEmployeeList = new  List<dbo_DimEmployee_dbo_DimEmployeeClass68>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtParentEmployeeKey = (DropDownList)e.Row.FindControl("txtParentEmployeeKey");
                if (txtParentEmployeeKey != null) {
                    try {
                        dbo_DimEmployee_dbo_DimEmployeeList = dbo_DimEmployee_dbo_DimEmployeeDataClass68.List();
                        txtParentEmployeeKey.DataSource = dbo_DimEmployee_dbo_DimEmployeeList;
                        txtParentEmployeeKey.DataValueField = "ParentEmployeeKey";
                        txtParentEmployeeKey.DataTextField = "FirstName";
                        txtParentEmployeeKey.DataBind();
                        txtParentEmployeeKey.SelectedValue = Convert.ToString(Session["ParentEmployeeKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewParentEmployeeKey = (DropDownList)e.Row.FindControl("txtNewParentEmployeeKey");
                if (txtNewParentEmployeeKey != null) {
                    try {
                        dbo_DimEmployee_dbo_DimEmployeeList = dbo_DimEmployee_dbo_DimEmployeeDataClass68.List();
                        txtNewParentEmployeeKey.DataSource = dbo_DimEmployee_dbo_DimEmployeeList;
                        txtNewParentEmployeeKey.DataValueField = "ParentEmployeeKey";
                        txtNewParentEmployeeKey.DataTextField = "FirstName";
                        txtNewParentEmployeeKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
                    }
                }
            }
        }

        private void Loaddbo_DimEmployee_dbo_DimSalesTerritoryComboBox71(GridViewRowEventArgs e)
        {
            List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71> dbo_DimEmployee_dbo_DimSalesTerritoryList = new  List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtSalesTerritoryKey");
                if (txtSalesTerritoryKey != null) {
                    try {
                        dbo_DimEmployee_dbo_DimSalesTerritoryList = dbo_DimEmployee_dbo_DimSalesTerritoryDataClass71.List();
                        txtSalesTerritoryKey.DataSource = dbo_DimEmployee_dbo_DimSalesTerritoryList;
                        txtSalesTerritoryKey.DataValueField = "SalesTerritoryAlternateKey";
                        txtSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
                        txtSalesTerritoryKey.DataBind();
                        txtSalesTerritoryKey.SelectedValue = Convert.ToString(Session["SalesTerritoryKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtNewSalesTerritoryKey");
                if (txtNewSalesTerritoryKey != null) {
                    try {
                        dbo_DimEmployee_dbo_DimSalesTerritoryList = dbo_DimEmployee_dbo_DimSalesTerritoryDataClass71.List();
                        txtNewSalesTerritoryKey.DataSource = dbo_DimEmployee_dbo_DimSalesTerritoryList;
                        txtNewSalesTerritoryKey.DataValueField = "SalesTerritoryAlternateKey";
                        txtNewSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
                        txtNewSalesTerritoryKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimEmployee()
        {
            try {
                if ((Session["dvdbo_DimEmployee"] != null)) {
                    dvdbo_DimEmployee = (DataView)Session["dvdbo_DimEmployee"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimEmployee = dbo_DimEmployeeDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimEmployee"] = dvdbo_DimEmployee;
                }
                if (dvdbo_DimEmployee.Count > 0) {
                    grddbo_DimEmployee.DataSource = dvdbo_DimEmployee;
                    grddbo_DimEmployee.DataBind();
                }
                if (dvdbo_DimEmployee.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("EmployeeKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FirstName", Type.GetType("System.Int32"));
                    dt.Columns.Add("EmployeeNationalIDAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("ParentEmployeeNationalIDAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FirstName", Type.GetType("System.String"));
                    dt.Columns.Add("LastName", Type.GetType("System.String"));
                    dt.Columns.Add("MiddleName", Type.GetType("System.String"));
                    dt.Columns.Add("NameStyle", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Title", Type.GetType("System.String"));
                    dt.Columns.Add("HireDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("LoginID", Type.GetType("System.String"));
                    dt.Columns.Add("EmailAddress", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("MaritalStatus", Type.GetType("System.String"));
                    dt.Columns.Add("EmergencyContactName", Type.GetType("System.String"));
                    dt.Columns.Add("EmergencyContactPhone", Type.GetType("System.String"));
                    dt.Columns.Add("SalariedFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Gender", Type.GetType("System.String"));
                    dt.Columns.Add("PayFrequency", Type.GetType("System.Byte"));
                    dt.Columns.Add("BaseRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("VacationHours", Type.GetType("System.Int16"));
                    dt.Columns.Add("SickLeaveHours", Type.GetType("System.Int16"));
                    dt.Columns.Add("CurrentFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("SalesPersonFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("DepartmentName", Type.GetType("System.String"));
                    dt.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("Status", Type.GetType("System.String"));
                    dvdbo_DimEmployee = dt.DefaultView;
                    Session["dvdbo_DimEmployee"] = dvdbo_DimEmployee;

                    grddbo_DimEmployee.DataSource = dvdbo_DimEmployee;
                    grddbo_DimEmployee.DataBind();

                    int TotalColumns = grddbo_DimEmployee.Rows[0].Cells.Count;
                    grddbo_DimEmployee.Rows[0].Cells.Clear();
                    grddbo_DimEmployee.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimEmployee.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimEmployee.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimEmployee.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
            }
        }

        protected void grddbo_DimEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimEmployee_dbo_DimEmployeeComboBox68(e);
            Loaddbo_DimEmployee_dbo_DimSalesTerritoryComboBox71(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtEmployeeKey = (TextBox)e.Row.FindControl("txtEmployeeKey");
                if (txtEmployeeKey != null) {
                    txtEmployeeKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewEmployeeKey = (TextBox)e.Row.FindControl("txtNewEmployeeKey");
                if (txtNewEmployeeKey != null) {
                    txtNewEmployeeKey.Enabled = false;
                }
                txtNewEmployeeKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimEmployee"));
            }
        }

        protected void grddbo_DimEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimEmployee.EditIndex = -1;
            LoadGriddbo_DimEmployee();
        }

        protected void grddbo_DimEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimEmployee.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimEmployee_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimEmployee.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimEmployee();
        }

        protected void grddbo_DimEmployee_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimEmployee();
        }

        private void Edit()
        {
            try {
                dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
                Label lblEmployeeKey = (Label)grddbo_DimEmployee.Rows[grddbo_DimEmployee.EditIndex].FindControl("lblEmployeeKey");
                clsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(lblEmployeeKey.Text);
                clsdbo_DimEmployee = dbo_DimEmployeeDataClass.Select_Record(clsdbo_DimEmployee);

                Session["ParentEmployeeKey_SelectedValue"] = clsdbo_DimEmployee.ParentEmployeeKey;
                Session["SalesTerritoryKey_SelectedValue"] = clsdbo_DimEmployee.SalesTerritoryKey;

                LoadGriddbo_DimEmployee();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewParentEmployeeKey = (DropDownList)grddbo_DimEmployee.FooterRow.FindControl("txtNewParentEmployeeKey");
                TextBox txtNewEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmployeeNationalIDAlternateKey");
                TextBox txtNewParentEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewParentEmployeeNationalIDAlternateKey");
                DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_DimEmployee.FooterRow.FindControl("txtNewSalesTerritoryKey");
                TextBox txtNewFirstName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewFirstName");
                TextBox txtNewLastName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewLastName");
                TextBox txtNewMiddleName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewMiddleName");
                CheckBox txtNewNameStyle = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewNameStyle");
                TextBox txtNewTitle = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewTitle");
                TextBox txtNewHireDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewHireDate");
                TextBox txtNewBirthDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewBirthDate");
                TextBox txtNewLoginID = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewLoginID");
                TextBox txtNewEmailAddress = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmailAddress");
                TextBox txtNewPhone = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewPhone");
                TextBox txtNewMaritalStatus = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewMaritalStatus");
                TextBox txtNewEmergencyContactName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmergencyContactName");
                TextBox txtNewEmergencyContactPhone = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmergencyContactPhone");
                CheckBox txtNewSalariedFlag = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewSalariedFlag");
                TextBox txtNewGender = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewGender");
                TextBox txtNewPayFrequency = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewPayFrequency");
                TextBox txtNewBaseRate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewBaseRate");
                TextBox txtNewVacationHours = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewVacationHours");
                TextBox txtNewSickLeaveHours = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewSickLeaveHours");
                CheckBox txtNewCurrentFlag = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewCurrentFlag");
                CheckBox txtNewSalesPersonFlag = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewSalesPersonFlag");
                TextBox txtNewDepartmentName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewDepartmentName");
                TextBox txtNewStartDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewStartDate");
                TextBox txtNewEndDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEndDate");
                TextBox txtNewStatus = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewStatus");

                dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewParentEmployeeKey.SelectedValue)) {
                        clsdbo_DimEmployee.ParentEmployeeKey = null;
                    } else {
                        clsdbo_DimEmployee.ParentEmployeeKey = System.Convert.ToInt32(txtNewParentEmployeeKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewEmployeeNationalIDAlternateKey.Text)) {
                        clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = null;
                    } else {
                        clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = txtNewEmployeeNationalIDAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtNewParentEmployeeNationalIDAlternateKey.Text)) {
                        clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = null;
                    } else {
                        clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = txtNewParentEmployeeNationalIDAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtNewSalesTerritoryKey.SelectedValue)) {
                        clsdbo_DimEmployee.SalesTerritoryKey = null;
                    } else {
                        clsdbo_DimEmployee.SalesTerritoryKey = System.Convert.ToInt32(txtNewSalesTerritoryKey.SelectedValue); }
                    clsdbo_DimEmployee.FirstName = System.Convert.ToString(txtNewFirstName.Text);
                    clsdbo_DimEmployee.LastName = System.Convert.ToString(txtNewLastName.Text);
                    if (string.IsNullOrEmpty(txtNewMiddleName.Text)) {
                        clsdbo_DimEmployee.MiddleName = null;
                    } else {
                        clsdbo_DimEmployee.MiddleName = txtNewMiddleName.Text; }
                    clsdbo_DimEmployee.NameStyle = System.Convert.ToBoolean(txtNewNameStyle.Checked ? true : false);
                    if (string.IsNullOrEmpty(txtNewTitle.Text)) {
                        clsdbo_DimEmployee.Title = null;
                    } else {
                        clsdbo_DimEmployee.Title = txtNewTitle.Text; }
                    if (string.IsNullOrEmpty(txtNewHireDate.Text)) {
                        clsdbo_DimEmployee.HireDate = null;
                    } else {
                        clsdbo_DimEmployee.HireDate = System.Convert.ToDateTime(txtNewHireDate.Text); }
                    if (string.IsNullOrEmpty(txtNewBirthDate.Text)) {
                        clsdbo_DimEmployee.BirthDate = null;
                    } else {
                        clsdbo_DimEmployee.BirthDate = System.Convert.ToDateTime(txtNewBirthDate.Text); }
                    if (string.IsNullOrEmpty(txtNewLoginID.Text)) {
                        clsdbo_DimEmployee.LoginID = null;
                    } else {
                        clsdbo_DimEmployee.LoginID = txtNewLoginID.Text; }
                    if (string.IsNullOrEmpty(txtNewEmailAddress.Text)) {
                        clsdbo_DimEmployee.EmailAddress = null;
                    } else {
                        clsdbo_DimEmployee.EmailAddress = txtNewEmailAddress.Text; }
                    if (string.IsNullOrEmpty(txtNewPhone.Text)) {
                        clsdbo_DimEmployee.Phone = null;
                    } else {
                        clsdbo_DimEmployee.Phone = txtNewPhone.Text; }
                    if (string.IsNullOrEmpty(txtNewMaritalStatus.Text)) {
                        clsdbo_DimEmployee.MaritalStatus = null;
                    } else {
                        clsdbo_DimEmployee.MaritalStatus = txtNewMaritalStatus.Text; }
                    if (string.IsNullOrEmpty(txtNewEmergencyContactName.Text)) {
                        clsdbo_DimEmployee.EmergencyContactName = null;
                    } else {
                        clsdbo_DimEmployee.EmergencyContactName = txtNewEmergencyContactName.Text; }
                    if (string.IsNullOrEmpty(txtNewEmergencyContactPhone.Text)) {
                        clsdbo_DimEmployee.EmergencyContactPhone = null;
                    } else {
                        clsdbo_DimEmployee.EmergencyContactPhone = txtNewEmergencyContactPhone.Text; }
                    clsdbo_DimEmployee.SalariedFlag = txtNewSalariedFlag.Checked ? true : false;                        
                    if (string.IsNullOrEmpty(txtNewGender.Text)) {
                        clsdbo_DimEmployee.Gender = null;
                    } else {
                        clsdbo_DimEmployee.Gender = txtNewGender.Text; }
                    if (string.IsNullOrEmpty(txtNewPayFrequency.Text)) {
                        clsdbo_DimEmployee.PayFrequency = null;
                    } else {
                        clsdbo_DimEmployee.PayFrequency = System.Convert.ToByte(txtNewPayFrequency.Text); }
                    if (string.IsNullOrEmpty(txtNewBaseRate.Text)) {
                        clsdbo_DimEmployee.BaseRate = null;
                    } else {
                        clsdbo_DimEmployee.BaseRate = System.Convert.ToDecimal(txtNewBaseRate.Text); }
                    if (string.IsNullOrEmpty(txtNewVacationHours.Text)) {
                        clsdbo_DimEmployee.VacationHours = null;
                    } else {
                        clsdbo_DimEmployee.VacationHours = System.Convert.ToInt16(txtNewVacationHours.Text); }
                    if (string.IsNullOrEmpty(txtNewSickLeaveHours.Text)) {
                        clsdbo_DimEmployee.SickLeaveHours = null;
                    } else {
                        clsdbo_DimEmployee.SickLeaveHours = System.Convert.ToInt16(txtNewSickLeaveHours.Text); }
                    clsdbo_DimEmployee.CurrentFlag = System.Convert.ToBoolean(txtNewCurrentFlag.Checked ? true : false);
                    clsdbo_DimEmployee.SalesPersonFlag = System.Convert.ToBoolean(txtNewSalesPersonFlag.Checked ? true : false);
                    if (string.IsNullOrEmpty(txtNewDepartmentName.Text)) {
                        clsdbo_DimEmployee.DepartmentName = null;
                    } else {
                        clsdbo_DimEmployee.DepartmentName = txtNewDepartmentName.Text; }
                    if (string.IsNullOrEmpty(txtNewStartDate.Text)) {
                        clsdbo_DimEmployee.StartDate = null;
                    } else {
                        clsdbo_DimEmployee.StartDate = System.Convert.ToDateTime(txtNewStartDate.Text); }
                    if (string.IsNullOrEmpty(txtNewEndDate.Text)) {
                        clsdbo_DimEmployee.EndDate = null;
                    } else {
                        clsdbo_DimEmployee.EndDate = System.Convert.ToDateTime(txtNewEndDate.Text); }
                    if (string.IsNullOrEmpty(txtNewStatus.Text)) {
                        clsdbo_DimEmployee.Status = null;
                    } else {
                        clsdbo_DimEmployee.Status = txtNewStatus.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimEmployeeDataClass.Add(clsdbo_DimEmployee);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimEmployee");
                        LoadGriddbo_DimEmployee();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Employee ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtEmployeeKey = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeKey");
                DropDownList txtParentEmployeeKey = (DropDownList)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentEmployeeKey");
                TextBox txtEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeNationalIDAlternateKey");
                TextBox txtParentEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentEmployeeNationalIDAlternateKey");
                DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
                TextBox txtFirstName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstName");
                TextBox txtLastName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastName");
                TextBox txtMiddleName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMiddleName");
                CheckBox txtNameStyle = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNameStyle");
                TextBox txtTitle = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTitle");
                TextBox txtHireDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHireDate");
                TextBox txtBirthDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBirthDate");
                TextBox txtLoginID = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLoginID");
                TextBox txtEmailAddress = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmailAddress");
                TextBox txtPhone = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
                TextBox txtMaritalStatus = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaritalStatus");
                TextBox txtEmergencyContactName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmergencyContactName");
                TextBox txtEmergencyContactPhone = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmergencyContactPhone");
                CheckBox txtSalariedFlag = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalariedFlag");
                TextBox txtGender = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGender");
                TextBox txtPayFrequency = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPayFrequency");
                TextBox txtBaseRate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBaseRate");
                TextBox txtVacationHours = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtVacationHours");
                TextBox txtSickLeaveHours = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSickLeaveHours");
                CheckBox txtCurrentFlag = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrentFlag");
                CheckBox txtSalesPersonFlag = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesPersonFlag");
                TextBox txtDepartmentName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentName");
                TextBox txtStartDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStartDate");
                TextBox txtEndDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndDate");
                TextBox txtStatus = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStatus");

                dbo_DimEmployeeClass oclsdbo_DimEmployee = new dbo_DimEmployeeClass();
                dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
                oclsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(txtEmployeeKey.Text);
                oclsdbo_DimEmployee = dbo_DimEmployeeDataClass.Select_Record(oclsdbo_DimEmployee);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtParentEmployeeKey.SelectedValue)) {
                        clsdbo_DimEmployee.ParentEmployeeKey = null;
                    } else {
                        clsdbo_DimEmployee.ParentEmployeeKey = System.Convert.ToInt32(txtParentEmployeeKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtEmployeeNationalIDAlternateKey.Text)) {
                        clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = null;
                    } else {
                        clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = txtEmployeeNationalIDAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtParentEmployeeNationalIDAlternateKey.Text)) {
                        clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = null;
                    } else {
                        clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = txtParentEmployeeNationalIDAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtSalesTerritoryKey.SelectedValue)) {
                        clsdbo_DimEmployee.SalesTerritoryKey = null;
                    } else {
                        clsdbo_DimEmployee.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue); }
                    clsdbo_DimEmployee.FirstName = System.Convert.ToString(txtFirstName.Text);
                    clsdbo_DimEmployee.LastName = System.Convert.ToString(txtLastName.Text);
                    if (string.IsNullOrEmpty(txtMiddleName.Text)) {
                        clsdbo_DimEmployee.MiddleName = null;
                    } else {
                        clsdbo_DimEmployee.MiddleName = txtMiddleName.Text; }
                    clsdbo_DimEmployee.NameStyle = System.Convert.ToBoolean(txtNameStyle.Checked ? true : false);
                    if (string.IsNullOrEmpty(txtTitle.Text)) {
                        clsdbo_DimEmployee.Title = null;
                    } else {
                        clsdbo_DimEmployee.Title = txtTitle.Text; }
                    if (string.IsNullOrEmpty(txtHireDate.Text)) {
                        clsdbo_DimEmployee.HireDate = null;
                    } else {
                        clsdbo_DimEmployee.HireDate = System.Convert.ToDateTime(txtHireDate.Text); }
                    if (string.IsNullOrEmpty(txtBirthDate.Text)) {
                        clsdbo_DimEmployee.BirthDate = null;
                    } else {
                        clsdbo_DimEmployee.BirthDate = System.Convert.ToDateTime(txtBirthDate.Text); }
                    if (string.IsNullOrEmpty(txtLoginID.Text)) {
                        clsdbo_DimEmployee.LoginID = null;
                    } else {
                        clsdbo_DimEmployee.LoginID = txtLoginID.Text; }
                    if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
                        clsdbo_DimEmployee.EmailAddress = null;
                    } else {
                        clsdbo_DimEmployee.EmailAddress = txtEmailAddress.Text; }
                    if (string.IsNullOrEmpty(txtPhone.Text)) {
                        clsdbo_DimEmployee.Phone = null;
                    } else {
                        clsdbo_DimEmployee.Phone = txtPhone.Text; }
                    if (string.IsNullOrEmpty(txtMaritalStatus.Text)) {
                        clsdbo_DimEmployee.MaritalStatus = null;
                    } else {
                        clsdbo_DimEmployee.MaritalStatus = txtMaritalStatus.Text; }
                    if (string.IsNullOrEmpty(txtEmergencyContactName.Text)) {
                        clsdbo_DimEmployee.EmergencyContactName = null;
                    } else {
                        clsdbo_DimEmployee.EmergencyContactName = txtEmergencyContactName.Text; }
                    if (string.IsNullOrEmpty(txtEmergencyContactPhone.Text)) {
                        clsdbo_DimEmployee.EmergencyContactPhone = null;
                    } else {
                        clsdbo_DimEmployee.EmergencyContactPhone = txtEmergencyContactPhone.Text; }
                    clsdbo_DimEmployee.SalariedFlag = txtSalariedFlag.Checked ? true : false;                        
                    if (string.IsNullOrEmpty(txtGender.Text)) {
                        clsdbo_DimEmployee.Gender = null;
                    } else {
                        clsdbo_DimEmployee.Gender = txtGender.Text; }
                    if (string.IsNullOrEmpty(txtPayFrequency.Text)) {
                        clsdbo_DimEmployee.PayFrequency = null;
                    } else {
                        clsdbo_DimEmployee.PayFrequency = System.Convert.ToByte(txtPayFrequency.Text); }
                    if (string.IsNullOrEmpty(txtBaseRate.Text)) {
                        clsdbo_DimEmployee.BaseRate = null;
                    } else {
                        clsdbo_DimEmployee.BaseRate = System.Convert.ToDecimal(txtBaseRate.Text); }
                    if (string.IsNullOrEmpty(txtVacationHours.Text)) {
                        clsdbo_DimEmployee.VacationHours = null;
                    } else {
                        clsdbo_DimEmployee.VacationHours = System.Convert.ToInt16(txtVacationHours.Text); }
                    if (string.IsNullOrEmpty(txtSickLeaveHours.Text)) {
                        clsdbo_DimEmployee.SickLeaveHours = null;
                    } else {
                        clsdbo_DimEmployee.SickLeaveHours = System.Convert.ToInt16(txtSickLeaveHours.Text); }
                    clsdbo_DimEmployee.CurrentFlag = System.Convert.ToBoolean(txtCurrentFlag.Checked ? true : false);
                    clsdbo_DimEmployee.SalesPersonFlag = System.Convert.ToBoolean(txtSalesPersonFlag.Checked ? true : false);
                    if (string.IsNullOrEmpty(txtDepartmentName.Text)) {
                        clsdbo_DimEmployee.DepartmentName = null;
                    } else {
                        clsdbo_DimEmployee.DepartmentName = txtDepartmentName.Text; }
                    if (string.IsNullOrEmpty(txtStartDate.Text)) {
                        clsdbo_DimEmployee.StartDate = null;
                    } else {
                        clsdbo_DimEmployee.StartDate = System.Convert.ToDateTime(txtStartDate.Text); }
                    if (string.IsNullOrEmpty(txtEndDate.Text)) {
                        clsdbo_DimEmployee.EndDate = null;
                    } else {
                        clsdbo_DimEmployee.EndDate = System.Convert.ToDateTime(txtEndDate.Text); }
                    if (string.IsNullOrEmpty(txtStatus.Text)) {
                        clsdbo_DimEmployee.Status = null;
                    } else {
                        clsdbo_DimEmployee.Status = txtStatus.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimEmployeeDataClass.Update(oclsdbo_DimEmployee, clsdbo_DimEmployee);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimEmployee");
                        grddbo_DimEmployee.EditIndex = -1;
                        LoadGriddbo_DimEmployee();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Employee ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
            Label lblEmployeeKey = (Label)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblEmployeeKey");
            clsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(lblEmployeeKey.Text);
            clsdbo_DimEmployee = dbo_DimEmployeeDataClass.Select_Record(clsdbo_DimEmployee);
            bool bSucess = false;
            bSucess = dbo_DimEmployeeDataClass.Delete(clsdbo_DimEmployee);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimEmployee");
                LoadGriddbo_DimEmployee();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Employee ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtEmployeeKey = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeKey");
            DropDownList txtParentEmployeeKey = (DropDownList)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentEmployeeKey");
            TextBox txtEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeNationalIDAlternateKey");
            TextBox txtParentEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentEmployeeNationalIDAlternateKey");
            DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
            TextBox txtFirstName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFirstName");
            TextBox txtLastName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLastName");
            TextBox txtMiddleName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMiddleName");
            CheckBox txtNameStyle = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtNameStyle");
            TextBox txtTitle = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTitle");
            TextBox txtHireDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHireDate");
            TextBox txtBirthDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBirthDate");
            TextBox txtLoginID = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLoginID");
            TextBox txtEmailAddress = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmailAddress");
            TextBox txtPhone = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPhone");
            TextBox txtMaritalStatus = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaritalStatus");
            TextBox txtEmergencyContactName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmergencyContactName");
            TextBox txtEmergencyContactPhone = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmergencyContactPhone");
            CheckBox txtSalariedFlag = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalariedFlag");
            TextBox txtGender = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGender");
            TextBox txtPayFrequency = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPayFrequency");
            TextBox txtBaseRate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtBaseRate");
            TextBox txtVacationHours = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtVacationHours");
            TextBox txtSickLeaveHours = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSickLeaveHours");
            CheckBox txtCurrentFlag = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrentFlag");
            CheckBox txtSalesPersonFlag = (CheckBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesPersonFlag");
            TextBox txtDepartmentName = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentName");
            TextBox txtStartDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStartDate");
            TextBox txtEndDate = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndDate");
            TextBox txtStatus = (TextBox)grddbo_DimEmployee.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStatus");

            if (txtFirstName.Text == "") {
                ec.ShowMessage(" First Name is Required. ", " Dbo. Dim Employee ");
                txtFirstName.Focus();
                return false;}
            if (txtLastName.Text == "") {
                ec.ShowMessage(" Last Name is Required. ", " Dbo. Dim Employee ");
                txtLastName.Focus();
                return false;}
            
            
            
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewParentEmployeeKey = (DropDownList)grddbo_DimEmployee.FooterRow.FindControl("txtNewParentEmployeeKey");
            TextBox txtNewEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmployeeNationalIDAlternateKey");
            TextBox txtNewParentEmployeeNationalIDAlternateKey = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewParentEmployeeNationalIDAlternateKey");
            DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_DimEmployee.FooterRow.FindControl("txtNewSalesTerritoryKey");
            TextBox txtNewFirstName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewFirstName");
            TextBox txtNewLastName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewLastName");
            TextBox txtNewMiddleName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewMiddleName");
            CheckBox txtNewNameStyle = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewNameStyle");

            TextBox txtNewTitle = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewTitle");
            TextBox txtNewHireDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewHireDate");
            TextBox txtNewBirthDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewBirthDate");
            TextBox txtNewLoginID = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewLoginID");
            TextBox txtNewEmailAddress = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmailAddress");
            TextBox txtNewPhone = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewPhone");
            TextBox txtNewMaritalStatus = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewMaritalStatus");
            TextBox txtNewEmergencyContactName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmergencyContactName");
            TextBox txtNewEmergencyContactPhone = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEmergencyContactPhone");
            CheckBox txtNewSalariedFlag = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewSalariedFlag");

            TextBox txtNewGender = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewGender");
            TextBox txtNewPayFrequency = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewPayFrequency");
            TextBox txtNewBaseRate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewBaseRate");
            TextBox txtNewVacationHours = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewVacationHours");
            TextBox txtNewSickLeaveHours = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewSickLeaveHours");
            CheckBox txtNewCurrentFlag = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewCurrentFlag");

            CheckBox txtNewSalesPersonFlag = (CheckBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewSalesPersonFlag");

            TextBox txtNewDepartmentName = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewDepartmentName");
            TextBox txtNewStartDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewStartDate");
            TextBox txtNewEndDate = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewEndDate");
            TextBox txtNewStatus = (TextBox)grddbo_DimEmployee.FooterRow.FindControl("txtNewStatus");

            if (txtNewFirstName.Text == "") {
                ec.ShowMessage(" First Name is Required. ", " Dbo. Dim Employee ");
                txtNewFirstName.Focus();
                return false;}
            if (txtNewLastName.Text == "") {
                ec.ShowMessage(" Last Name is Required. ", " Dbo. Dim Employee ");
                txtNewLastName.Focus();
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
		    grddbo_DimEmployee.PageIndex = 0;
		    grddbo_DimEmployee.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimEmployee();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimEmployee");
		    LoadGriddbo_DimEmployee();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimEmployee");
			if ((Session["dvdbo_DimEmployee"] != null)) {
				dvdbo_DimEmployee = (DataView)Session["dvdbo_DimEmployee"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimEmployee = dbo_DimEmployeeDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimEmployee"] = dvdbo_DimEmployee;
		    	}
                if (dvdbo_DimEmployee.Count > 0) {
                    grddbo_DimEmployee.DataSource = dvdbo_DimEmployee;
                    grddbo_DimEmployee.DataBind();
                }
                if (dvdbo_DimEmployee.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("EmployeeKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FirstName", Type.GetType("System.Int32"));
                    dt.Columns.Add("EmployeeNationalIDAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("ParentEmployeeNationalIDAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FirstName", Type.GetType("System.String"));
                    dt.Columns.Add("LastName", Type.GetType("System.String"));
                    dt.Columns.Add("MiddleName", Type.GetType("System.String"));
                    dt.Columns.Add("NameStyle", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Title", Type.GetType("System.String"));
                    dt.Columns.Add("HireDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("LoginID", Type.GetType("System.String"));
                    dt.Columns.Add("EmailAddress", Type.GetType("System.String"));
                    dt.Columns.Add("Phone", Type.GetType("System.String"));
                    dt.Columns.Add("MaritalStatus", Type.GetType("System.String"));
                    dt.Columns.Add("EmergencyContactName", Type.GetType("System.String"));
                    dt.Columns.Add("EmergencyContactPhone", Type.GetType("System.String"));
                    dt.Columns.Add("SalariedFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Gender", Type.GetType("System.String"));
                    dt.Columns.Add("PayFrequency", Type.GetType("System.Byte"));
                    dt.Columns.Add("BaseRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("VacationHours", Type.GetType("System.Int16"));
                    dt.Columns.Add("SickLeaveHours", Type.GetType("System.Int16"));
                    dt.Columns.Add("CurrentFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("SalesPersonFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("DepartmentName", Type.GetType("System.String"));
                    dt.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("Status", Type.GetType("System.String"));
                    dvdbo_DimEmployee = dt.DefaultView;
                    Session["dvdbo_DimEmployee"] = dvdbo_DimEmployee;

                    grddbo_DimEmployee.DataSource = dvdbo_DimEmployee;
                    grddbo_DimEmployee.DataBind();

                    int TotalColumns = grddbo_DimEmployee.Rows[0].Cells.Count;
                    grddbo_DimEmployee.Rows[0].Cells.Clear();
                    grddbo_DimEmployee.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimEmployee.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimEmployee.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimEmployee.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
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
                    { dt = dbo_DimEmployeeDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimEmployeeDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Employee", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimEmployee"];
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
 
