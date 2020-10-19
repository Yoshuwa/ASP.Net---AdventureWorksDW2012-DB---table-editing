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
    public partial class frmdbo_FactCallCenter : System.Web.UI.Page
    {

        private dbo_FactCallCenterDataClass clsdbo_FactCallCenterData = new dbo_FactCallCenterDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactCallCenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["DateKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactCallCenter");
                Session.Remove("Row");

                cmbFields.Items.Add("Fact Call Center I D");
                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Wage Type");
                cmbFields.Items.Add("Shift");
                cmbFields.Items.Add("Level One Operators");
                cmbFields.Items.Add("Level Two Operators");
                cmbFields.Items.Add("Total Operators");
                cmbFields.Items.Add("Calls");
                cmbFields.Items.Add("Automatic Responses");
                cmbFields.Items.Add("Orders");
                cmbFields.Items.Add("Issues Raised");
                cmbFields.Items.Add("Average Time Per Issue");
                cmbFields.Items.Add("Service Grade");
                cmbFields.Items.Add("Date");

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

                LoadGriddbo_FactCallCenter();
            }
        }

        private void Loaddbo_FactCallCenter_dbo_DimDateComboBox(GridViewRowEventArgs e)
        {
            List<dbo_FactCallCenter_dbo_DimDateClass> dbo_FactCallCenter_dbo_DimDateList = new  List<dbo_FactCallCenter_dbo_DimDateClass>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    try {
                        dbo_FactCallCenter_dbo_DimDateList = dbo_FactCallCenter_dbo_DimDateDataClass.List();
                        txtDateKey.DataSource = dbo_FactCallCenter_dbo_DimDateList;
                        txtDateKey.DataValueField = "DateKey";
                        txtDateKey.DataTextField = "FullDateAlternateKey";
                        txtDateKey.DataBind();
                        txtDateKey.SelectedValue = Convert.ToString(Session["DateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDateKey = (DropDownList)e.Row.FindControl("txtNewDateKey");
                if (txtNewDateKey != null) {
                    try {
                        dbo_FactCallCenter_dbo_DimDateList = dbo_FactCallCenter_dbo_DimDateDataClass.List();
                        txtNewDateKey.DataSource = dbo_FactCallCenter_dbo_DimDateList;
                        txtNewDateKey.DataValueField = "DateKey";
                        txtNewDateKey.DataTextField = "FullDateAlternateKey";
                        txtNewDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactCallCenter()
        {
            try {
                if ((Session["dvdbo_FactCallCenter"] != null)) {
                    dvdbo_FactCallCenter = (DataView)Session["dvdbo_FactCallCenter"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactCallCenter = dbo_FactCallCenterDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactCallCenter"] = dvdbo_FactCallCenter;
                }
                if (dvdbo_FactCallCenter.Count > 0) {
                    grddbo_FactCallCenter.DataSource = dvdbo_FactCallCenter;
                    grddbo_FactCallCenter.DataBind();
                }
                if (dvdbo_FactCallCenter.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("FactCallCenterID", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("WageType", Type.GetType("System.String"));
                    dt.Columns.Add("Shift", Type.GetType("System.String"));
                    dt.Columns.Add("LevelOneOperators", Type.GetType("System.Int16"));
                    dt.Columns.Add("LevelTwoOperators", Type.GetType("System.Int16"));
                    dt.Columns.Add("TotalOperators", Type.GetType("System.Int16"));
                    dt.Columns.Add("Calls", Type.GetType("System.Int32"));
                    dt.Columns.Add("AutomaticResponses", Type.GetType("System.Int32"));
                    dt.Columns.Add("Orders", Type.GetType("System.Int32"));
                    dt.Columns.Add("IssuesRaised", Type.GetType("System.Int16"));
                    dt.Columns.Add("AverageTimePerIssue", Type.GetType("System.Int16"));
                    dt.Columns.Add("ServiceGrade", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactCallCenter = dt.DefaultView;
                    Session["dvdbo_FactCallCenter"] = dvdbo_FactCallCenter;

                    grddbo_FactCallCenter.DataSource = dvdbo_FactCallCenter;
                    grddbo_FactCallCenter.DataBind();

                    int TotalColumns = grddbo_FactCallCenter.Rows[0].Cells.Count;
                    grddbo_FactCallCenter.Rows[0].Cells.Clear();
                    grddbo_FactCallCenter.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactCallCenter.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactCallCenter.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactCallCenter.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
            }
        }

        protected void grddbo_FactCallCenter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactCallCenter_dbo_DimDateComboBox(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtFactCallCenterID = (TextBox)e.Row.FindControl("txtFactCallCenterID");
                if (txtFactCallCenterID != null) {
                    txtFactCallCenterID.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewFactCallCenterID = (TextBox)e.Row.FindControl("txtNewFactCallCenterID");
                if (txtNewFactCallCenterID != null) {
                    txtNewFactCallCenterID.Enabled = false;
                }
                txtNewFactCallCenterID.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactCallCenter"));
            }
        }

        protected void grddbo_FactCallCenter_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactCallCenter.EditIndex = -1;
            LoadGriddbo_FactCallCenter();
        }

        protected void grddbo_FactCallCenter_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactCallCenter.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactCallCenter_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactCallCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactCallCenter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactCallCenter_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactCallCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactCallCenter.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactCallCenter();
        }

        protected void grddbo_FactCallCenter_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactCallCenter();
        }

        private void Edit()
        {
            try {
                dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
                Label lblFactCallCenterID = (Label)grddbo_FactCallCenter.Rows[grddbo_FactCallCenter.EditIndex].FindControl("lblFactCallCenterID");
                clsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(lblFactCallCenterID.Text);
                clsdbo_FactCallCenter = dbo_FactCallCenterDataClass.Select_Record(clsdbo_FactCallCenter);

                Session["DateKey_SelectedValue"] = clsdbo_FactCallCenter.DateKey;

                LoadGriddbo_FactCallCenter();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewDateKey = (DropDownList)grddbo_FactCallCenter.FooterRow.FindControl("txtNewDateKey");
                TextBox txtNewWageType = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewWageType");
                TextBox txtNewShift = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewShift");
                TextBox txtNewLevelOneOperators = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewLevelOneOperators");
                TextBox txtNewLevelTwoOperators = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewLevelTwoOperators");
                TextBox txtNewTotalOperators = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewTotalOperators");
                TextBox txtNewCalls = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewCalls");
                TextBox txtNewAutomaticResponses = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewAutomaticResponses");
                TextBox txtNewOrders = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewOrders");
                TextBox txtNewIssuesRaised = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewIssuesRaised");
                TextBox txtNewAverageTimePerIssue = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewAverageTimePerIssue");
                TextBox txtNewServiceGrade = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewServiceGrade");
                TextBox txtNewDate = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewDate");

                dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactCallCenter.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                    clsdbo_FactCallCenter.WageType = System.Convert.ToString(txtNewWageType.Text);
                    clsdbo_FactCallCenter.Shift = System.Convert.ToString(txtNewShift.Text);
                    clsdbo_FactCallCenter.LevelOneOperators = System.Convert.ToInt16(txtNewLevelOneOperators.Text);
                    clsdbo_FactCallCenter.LevelTwoOperators = System.Convert.ToInt16(txtNewLevelTwoOperators.Text);
                    clsdbo_FactCallCenter.TotalOperators = System.Convert.ToInt16(txtNewTotalOperators.Text);
                    clsdbo_FactCallCenter.Calls = System.Convert.ToInt32(txtNewCalls.Text);
                    clsdbo_FactCallCenter.AutomaticResponses = System.Convert.ToInt32(txtNewAutomaticResponses.Text);
                    clsdbo_FactCallCenter.Orders = System.Convert.ToInt32(txtNewOrders.Text);
                    clsdbo_FactCallCenter.IssuesRaised = System.Convert.ToInt16(txtNewIssuesRaised.Text);
                    clsdbo_FactCallCenter.AverageTimePerIssue = System.Convert.ToInt16(txtNewAverageTimePerIssue.Text);
                    clsdbo_FactCallCenter.ServiceGrade = System.Convert.ToDecimal(txtNewServiceGrade.Text);
                    if (string.IsNullOrEmpty(txtNewDate.Text)) {
                        clsdbo_FactCallCenter.Date = null;
                    } else {
                        clsdbo_FactCallCenter.Date = System.Convert.ToDateTime(txtNewDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactCallCenterDataClass.Add(clsdbo_FactCallCenter);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactCallCenter");
                        LoadGriddbo_FactCallCenter();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Call Center ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtFactCallCenterID = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFactCallCenterID");
                DropDownList txtDateKey = (DropDownList)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                TextBox txtWageType = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWageType");
                TextBox txtShift = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShift");
                TextBox txtLevelOneOperators = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLevelOneOperators");
                TextBox txtLevelTwoOperators = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLevelTwoOperators");
                TextBox txtTotalOperators = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalOperators");
                TextBox txtCalls = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalls");
                TextBox txtAutomaticResponses = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAutomaticResponses");
                TextBox txtOrders = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrders");
                TextBox txtIssuesRaised = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtIssuesRaised");
                TextBox txtAverageTimePerIssue = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAverageTimePerIssue");
                TextBox txtServiceGrade = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtServiceGrade");
                TextBox txtDate = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

                dbo_FactCallCenterClass oclsdbo_FactCallCenter = new dbo_FactCallCenterClass();
                dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
                oclsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(txtFactCallCenterID.Text);
                oclsdbo_FactCallCenter = dbo_FactCallCenterDataClass.Select_Record(oclsdbo_FactCallCenter);

                if (VerifyData() == true) {
                    clsdbo_FactCallCenter.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
                    clsdbo_FactCallCenter.WageType = System.Convert.ToString(txtWageType.Text);
                    clsdbo_FactCallCenter.Shift = System.Convert.ToString(txtShift.Text);
                    clsdbo_FactCallCenter.LevelOneOperators = System.Convert.ToInt16(txtLevelOneOperators.Text);
                    clsdbo_FactCallCenter.LevelTwoOperators = System.Convert.ToInt16(txtLevelTwoOperators.Text);
                    clsdbo_FactCallCenter.TotalOperators = System.Convert.ToInt16(txtTotalOperators.Text);
                    clsdbo_FactCallCenter.Calls = System.Convert.ToInt32(txtCalls.Text);
                    clsdbo_FactCallCenter.AutomaticResponses = System.Convert.ToInt32(txtAutomaticResponses.Text);
                    clsdbo_FactCallCenter.Orders = System.Convert.ToInt32(txtOrders.Text);
                    clsdbo_FactCallCenter.IssuesRaised = System.Convert.ToInt16(txtIssuesRaised.Text);
                    clsdbo_FactCallCenter.AverageTimePerIssue = System.Convert.ToInt16(txtAverageTimePerIssue.Text);
                    clsdbo_FactCallCenter.ServiceGrade = System.Convert.ToDecimal(txtServiceGrade.Text);
                    if (string.IsNullOrEmpty(txtDate.Text)) {
                        clsdbo_FactCallCenter.Date = null;
                    } else {
                        clsdbo_FactCallCenter.Date = System.Convert.ToDateTime(txtDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactCallCenterDataClass.Update(oclsdbo_FactCallCenter, clsdbo_FactCallCenter);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactCallCenter");
                        grddbo_FactCallCenter.EditIndex = -1;
                        LoadGriddbo_FactCallCenter();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Call Center ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
            Label lblFactCallCenterID = (Label)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblFactCallCenterID");
            clsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(lblFactCallCenterID.Text);
            clsdbo_FactCallCenter = dbo_FactCallCenterDataClass.Select_Record(clsdbo_FactCallCenter);
            bool bSucess = false;
            bSucess = dbo_FactCallCenterDataClass.Delete(clsdbo_FactCallCenter);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactCallCenter");
                LoadGriddbo_FactCallCenter();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Call Center ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtFactCallCenterID = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFactCallCenterID");
            DropDownList txtDateKey = (DropDownList)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            TextBox txtWageType = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWageType");
            TextBox txtShift = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShift");
            TextBox txtLevelOneOperators = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLevelOneOperators");
            TextBox txtLevelTwoOperators = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtLevelTwoOperators");
            TextBox txtTotalOperators = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalOperators");
            TextBox txtCalls = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalls");
            TextBox txtAutomaticResponses = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAutomaticResponses");
            TextBox txtOrders = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrders");
            TextBox txtIssuesRaised = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtIssuesRaised");
            TextBox txtAverageTimePerIssue = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAverageTimePerIssue");
            TextBox txtServiceGrade = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtServiceGrade");
            TextBox txtDate = (TextBox)grddbo_FactCallCenter.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Call Center ");
                txtDateKey.Focus();
                return false;}
            if (txtWageType.Text == "") {
                ec.ShowMessage(" Wage Type is Required. ", " Dbo. Fact Call Center ");
                txtWageType.Focus();
                return false;}
            if (txtShift.Text == "") {
                ec.ShowMessage(" Shift is Required. ", " Dbo. Fact Call Center ");
                txtShift.Focus();
                return false;}
            if (txtLevelOneOperators.Text == "") {
                ec.ShowMessage(" Level One Operators is Required. ", " Dbo. Fact Call Center ");
                txtLevelOneOperators.Focus();
                return false;}
            if (txtLevelTwoOperators.Text == "") {
                ec.ShowMessage(" Level Two Operators is Required. ", " Dbo. Fact Call Center ");
                txtLevelTwoOperators.Focus();
                return false;}
            if (txtTotalOperators.Text == "") {
                ec.ShowMessage(" Total Operators is Required. ", " Dbo. Fact Call Center ");
                txtTotalOperators.Focus();
                return false;}
            if (txtCalls.Text == "") {
                ec.ShowMessage(" Calls is Required. ", " Dbo. Fact Call Center ");
                txtCalls.Focus();
                return false;}
            if (txtAutomaticResponses.Text == "") {
                ec.ShowMessage(" Automatic Responses is Required. ", " Dbo. Fact Call Center ");
                txtAutomaticResponses.Focus();
                return false;}
            if (txtOrders.Text == "") {
                ec.ShowMessage(" Orders is Required. ", " Dbo. Fact Call Center ");
                txtOrders.Focus();
                return false;}
            if (txtIssuesRaised.Text == "") {
                ec.ShowMessage(" Issues Raised is Required. ", " Dbo. Fact Call Center ");
                txtIssuesRaised.Focus();
                return false;}
            if (txtAverageTimePerIssue.Text == "") {
                ec.ShowMessage(" Average Time Per Issue is Required. ", " Dbo. Fact Call Center ");
                txtAverageTimePerIssue.Focus();
                return false;}
            if (txtServiceGrade.Text == "") {
                ec.ShowMessage(" Service Grade is Required. ", " Dbo. Fact Call Center ");
                txtServiceGrade.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewDateKey = (DropDownList)grddbo_FactCallCenter.FooterRow.FindControl("txtNewDateKey");
            TextBox txtNewWageType = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewWageType");
            TextBox txtNewShift = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewShift");
            TextBox txtNewLevelOneOperators = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewLevelOneOperators");
            TextBox txtNewLevelTwoOperators = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewLevelTwoOperators");
            TextBox txtNewTotalOperators = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewTotalOperators");
            TextBox txtNewCalls = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewCalls");
            TextBox txtNewAutomaticResponses = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewAutomaticResponses");
            TextBox txtNewOrders = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewOrders");
            TextBox txtNewIssuesRaised = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewIssuesRaised");
            TextBox txtNewAverageTimePerIssue = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewAverageTimePerIssue");
            TextBox txtNewServiceGrade = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewServiceGrade");
            TextBox txtNewDate = (TextBox)grddbo_FactCallCenter.FooterRow.FindControl("txtNewDate");

            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Call Center ");
                txtNewDateKey.Focus();
                return false;}
            if (txtNewWageType.Text == "") {
                ec.ShowMessage(" Wage Type is Required. ", " Dbo. Fact Call Center ");
                txtNewWageType.Focus();
                return false;}
            if (txtNewShift.Text == "") {
                ec.ShowMessage(" Shift is Required. ", " Dbo. Fact Call Center ");
                txtNewShift.Focus();
                return false;}
            if (txtNewLevelOneOperators.Text == "") {
                ec.ShowMessage(" Level One Operators is Required. ", " Dbo. Fact Call Center ");
                txtNewLevelOneOperators.Focus();
                return false;}
            if (txtNewLevelTwoOperators.Text == "") {
                ec.ShowMessage(" Level Two Operators is Required. ", " Dbo. Fact Call Center ");
                txtNewLevelTwoOperators.Focus();
                return false;}
            if (txtNewTotalOperators.Text == "") {
                ec.ShowMessage(" Total Operators is Required. ", " Dbo. Fact Call Center ");
                txtNewTotalOperators.Focus();
                return false;}
            if (txtNewCalls.Text == "") {
                ec.ShowMessage(" Calls is Required. ", " Dbo. Fact Call Center ");
                txtNewCalls.Focus();
                return false;}
            if (txtNewAutomaticResponses.Text == "") {
                ec.ShowMessage(" Automatic Responses is Required. ", " Dbo. Fact Call Center ");
                txtNewAutomaticResponses.Focus();
                return false;}
            if (txtNewOrders.Text == "") {
                ec.ShowMessage(" Orders is Required. ", " Dbo. Fact Call Center ");
                txtNewOrders.Focus();
                return false;}
            if (txtNewIssuesRaised.Text == "") {
                ec.ShowMessage(" Issues Raised is Required. ", " Dbo. Fact Call Center ");
                txtNewIssuesRaised.Focus();
                return false;}
            if (txtNewAverageTimePerIssue.Text == "") {
                ec.ShowMessage(" Average Time Per Issue is Required. ", " Dbo. Fact Call Center ");
                txtNewAverageTimePerIssue.Focus();
                return false;}
            if (txtNewServiceGrade.Text == "") {
                ec.ShowMessage(" Service Grade is Required. ", " Dbo. Fact Call Center ");
                txtNewServiceGrade.Focus();
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
		    grddbo_FactCallCenter.PageIndex = 0;
		    grddbo_FactCallCenter.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactCallCenter();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactCallCenter");
		    LoadGriddbo_FactCallCenter();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactCallCenter");
			if ((Session["dvdbo_FactCallCenter"] != null)) {
				dvdbo_FactCallCenter = (DataView)Session["dvdbo_FactCallCenter"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactCallCenter = dbo_FactCallCenterDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactCallCenter"] = dvdbo_FactCallCenter;
		    	}
                if (dvdbo_FactCallCenter.Count > 0) {
                    grddbo_FactCallCenter.DataSource = dvdbo_FactCallCenter;
                    grddbo_FactCallCenter.DataBind();
                }
                if (dvdbo_FactCallCenter.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("FactCallCenterID", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("WageType", Type.GetType("System.String"));
                    dt.Columns.Add("Shift", Type.GetType("System.String"));
                    dt.Columns.Add("LevelOneOperators", Type.GetType("System.Int16"));
                    dt.Columns.Add("LevelTwoOperators", Type.GetType("System.Int16"));
                    dt.Columns.Add("TotalOperators", Type.GetType("System.Int16"));
                    dt.Columns.Add("Calls", Type.GetType("System.Int32"));
                    dt.Columns.Add("AutomaticResponses", Type.GetType("System.Int32"));
                    dt.Columns.Add("Orders", Type.GetType("System.Int32"));
                    dt.Columns.Add("IssuesRaised", Type.GetType("System.Int16"));
                    dt.Columns.Add("AverageTimePerIssue", Type.GetType("System.Int16"));
                    dt.Columns.Add("ServiceGrade", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactCallCenter = dt.DefaultView;
                    Session["dvdbo_FactCallCenter"] = dvdbo_FactCallCenter;

                    grddbo_FactCallCenter.DataSource = dvdbo_FactCallCenter;
                    grddbo_FactCallCenter.DataBind();

                    int TotalColumns = grddbo_FactCallCenter.Rows[0].Cells.Count;
                    grddbo_FactCallCenter.Rows[0].Cells.Clear();
                    grddbo_FactCallCenter.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactCallCenter.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactCallCenter.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactCallCenter.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
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
                    { dt = dbo_FactCallCenterDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactCallCenterDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Call Center", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactCallCenter"];
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
 
