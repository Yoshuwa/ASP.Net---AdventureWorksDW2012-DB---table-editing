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
    public partial class frmdbo_FactFinance : System.Web.UI.Page
    {

        private dbo_FactFinanceDataClass clsdbo_FactFinanceData = new dbo_FactFinanceDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactFinance;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["DateKey_SelectedValue"] = "";
                Session["OrganizationKey_SelectedValue"] = "";
                Session["DepartmentGroupKey_SelectedValue"] = "";
                Session["ScenarioKey_SelectedValue"] = "";
                Session["AccountKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactFinance");
                Session.Remove("Row");

                cmbFields.Items.Add("Finance Key");
                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Organization Key");
                cmbFields.Items.Add("Department Group Key");
                cmbFields.Items.Add("Scenario Key");
                cmbFields.Items.Add("Account Key");
                cmbFields.Items.Add("Amount");
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

                LoadGriddbo_FactFinance();
            }
        }

        private void Loaddbo_FactFinance_dbo_DimDateComboBox229(GridViewRowEventArgs e)
        {
            List<dbo_FactFinance_dbo_DimDateClass229> dbo_FactFinance_dbo_DimDateList = new  List<dbo_FactFinance_dbo_DimDateClass229>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimDateList = dbo_FactFinance_dbo_DimDateDataClass229.List();
                        txtDateKey.DataSource = dbo_FactFinance_dbo_DimDateList;
                        txtDateKey.DataValueField = "DateKey";
                        txtDateKey.DataTextField = "DateKey";
                        txtDateKey.DataBind();
                        txtDateKey.SelectedValue = Convert.ToString(Session["DateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDateKey = (DropDownList)e.Row.FindControl("txtNewDateKey");
                if (txtNewDateKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimDateList = dbo_FactFinance_dbo_DimDateDataClass229.List();
                        txtNewDateKey.DataSource = dbo_FactFinance_dbo_DimDateList;
                        txtNewDateKey.DataValueField = "DateKey";
                        txtNewDateKey.DataTextField = "DateKey";
                        txtNewDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
        }

        private void Loaddbo_FactFinance_dbo_DimOrganizationComboBox230(GridViewRowEventArgs e)
        {
            List<dbo_FactFinance_dbo_DimOrganizationClass230> dbo_FactFinance_dbo_DimOrganizationList = new  List<dbo_FactFinance_dbo_DimOrganizationClass230>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtOrganizationKey = (DropDownList)e.Row.FindControl("txtOrganizationKey");
                if (txtOrganizationKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimOrganizationList = dbo_FactFinance_dbo_DimOrganizationDataClass230.List();
                        txtOrganizationKey.DataSource = dbo_FactFinance_dbo_DimOrganizationList;
                        txtOrganizationKey.DataValueField = "OrganizationKey";
                        txtOrganizationKey.DataTextField = "OrganizationName";
                        txtOrganizationKey.DataBind();
                        txtOrganizationKey.SelectedValue = Convert.ToString(Session["OrganizationKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewOrganizationKey = (DropDownList)e.Row.FindControl("txtNewOrganizationKey");
                if (txtNewOrganizationKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimOrganizationList = dbo_FactFinance_dbo_DimOrganizationDataClass230.List();
                        txtNewOrganizationKey.DataSource = dbo_FactFinance_dbo_DimOrganizationList;
                        txtNewOrganizationKey.DataValueField = "OrganizationKey";
                        txtNewOrganizationKey.DataTextField = "OrganizationName";
                        txtNewOrganizationKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
        }

        private void Loaddbo_FactFinance_dbo_DimDepartmentGroupComboBox231(GridViewRowEventArgs e)
        {
            List<dbo_FactFinance_dbo_DimDepartmentGroupClass231> dbo_FactFinance_dbo_DimDepartmentGroupList = new  List<dbo_FactFinance_dbo_DimDepartmentGroupClass231>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDepartmentGroupKey = (DropDownList)e.Row.FindControl("txtDepartmentGroupKey");
                if (txtDepartmentGroupKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimDepartmentGroupList = dbo_FactFinance_dbo_DimDepartmentGroupDataClass231.List();
                        txtDepartmentGroupKey.DataSource = dbo_FactFinance_dbo_DimDepartmentGroupList;
                        txtDepartmentGroupKey.DataValueField = "DepartmentGroupKey";
                        txtDepartmentGroupKey.DataTextField = "DepartmentGroupName";
                        txtDepartmentGroupKey.DataBind();
                        txtDepartmentGroupKey.SelectedValue = Convert.ToString(Session["DepartmentGroupKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDepartmentGroupKey = (DropDownList)e.Row.FindControl("txtNewDepartmentGroupKey");
                if (txtNewDepartmentGroupKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimDepartmentGroupList = dbo_FactFinance_dbo_DimDepartmentGroupDataClass231.List();
                        txtNewDepartmentGroupKey.DataSource = dbo_FactFinance_dbo_DimDepartmentGroupList;
                        txtNewDepartmentGroupKey.DataValueField = "DepartmentGroupKey";
                        txtNewDepartmentGroupKey.DataTextField = "DepartmentGroupName";
                        txtNewDepartmentGroupKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
        }

        private void Loaddbo_FactFinance_dbo_DimScenarioComboBox232(GridViewRowEventArgs e)
        {
            List<dbo_FactFinance_dbo_DimScenarioClass232> dbo_FactFinance_dbo_DimScenarioList = new  List<dbo_FactFinance_dbo_DimScenarioClass232>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtScenarioKey = (DropDownList)e.Row.FindControl("txtScenarioKey");
                if (txtScenarioKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimScenarioList = dbo_FactFinance_dbo_DimScenarioDataClass232.List();
                        txtScenarioKey.DataSource = dbo_FactFinance_dbo_DimScenarioList;
                        txtScenarioKey.DataValueField = "ScenarioKey";
                        txtScenarioKey.DataTextField = "ScenarioName";
                        txtScenarioKey.DataBind();
                        txtScenarioKey.SelectedValue = Convert.ToString(Session["ScenarioKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewScenarioKey = (DropDownList)e.Row.FindControl("txtNewScenarioKey");
                if (txtNewScenarioKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimScenarioList = dbo_FactFinance_dbo_DimScenarioDataClass232.List();
                        txtNewScenarioKey.DataSource = dbo_FactFinance_dbo_DimScenarioList;
                        txtNewScenarioKey.DataValueField = "ScenarioKey";
                        txtNewScenarioKey.DataTextField = "ScenarioName";
                        txtNewScenarioKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
        }

        private void Loaddbo_FactFinance_dbo_DimAccountComboBox233(GridViewRowEventArgs e)
        {
            List<dbo_FactFinance_dbo_DimAccountClass233> dbo_FactFinance_dbo_DimAccountList = new  List<dbo_FactFinance_dbo_DimAccountClass233>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtAccountKey = (DropDownList)e.Row.FindControl("txtAccountKey");
                if (txtAccountKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimAccountList = dbo_FactFinance_dbo_DimAccountDataClass233.List();
                        txtAccountKey.DataSource = dbo_FactFinance_dbo_DimAccountList;
                        txtAccountKey.DataValueField = "AccountKey";
                        txtAccountKey.DataTextField = "ParentAccountKey";
                        txtAccountKey.DataBind();
                        txtAccountKey.SelectedValue = Convert.ToString(Session["AccountKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewAccountKey = (DropDownList)e.Row.FindControl("txtNewAccountKey");
                if (txtNewAccountKey != null) {
                    try {
                        dbo_FactFinance_dbo_DimAccountList = dbo_FactFinance_dbo_DimAccountDataClass233.List();
                        txtNewAccountKey.DataSource = dbo_FactFinance_dbo_DimAccountList;
                        txtNewAccountKey.DataValueField = "AccountKey";
                        txtNewAccountKey.DataTextField = "ParentAccountKey";
                        txtNewAccountKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactFinance()
        {
            try {
                if ((Session["dvdbo_FactFinance"] != null)) {
                    dvdbo_FactFinance = (DataView)Session["dvdbo_FactFinance"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactFinance = dbo_FactFinanceDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactFinance"] = dvdbo_FactFinance;
                }
                if (dvdbo_FactFinance.Count > 0) {
                    grddbo_FactFinance.DataSource = dvdbo_FactFinance;
                    grddbo_FactFinance.DataBind();
                }
                if (dvdbo_FactFinance.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("FinanceKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("OrganizationName", Type.GetType("System.Int32"));
                    dt.Columns.Add("DepartmentGroupName", Type.GetType("System.Int32"));
                    dt.Columns.Add("ScenarioName", Type.GetType("System.Int32"));
                    dt.Columns.Add("ParentAccountKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("Amount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactFinance = dt.DefaultView;
                    Session["dvdbo_FactFinance"] = dvdbo_FactFinance;

                    grddbo_FactFinance.DataSource = dvdbo_FactFinance;
                    grddbo_FactFinance.DataBind();

                    int TotalColumns = grddbo_FactFinance.Rows[0].Cells.Count;
                    grddbo_FactFinance.Rows[0].Cells.Clear();
                    grddbo_FactFinance.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactFinance.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactFinance.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactFinance.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
            }
        }

        protected void grddbo_FactFinance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactFinance_dbo_DimDateComboBox229(e);
            Loaddbo_FactFinance_dbo_DimOrganizationComboBox230(e);
            Loaddbo_FactFinance_dbo_DimDepartmentGroupComboBox231(e);
            Loaddbo_FactFinance_dbo_DimScenarioComboBox232(e);
            Loaddbo_FactFinance_dbo_DimAccountComboBox233(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtFinanceKey = (TextBox)e.Row.FindControl("txtFinanceKey");
                if (txtFinanceKey != null) {
                    txtFinanceKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewFinanceKey = (TextBox)e.Row.FindControl("txtNewFinanceKey");
                if (txtNewFinanceKey != null) {
                    txtNewFinanceKey.Enabled = false;
                }
                txtNewFinanceKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactFinance"));
            }
        }

        protected void grddbo_FactFinance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactFinance.EditIndex = -1;
            LoadGriddbo_FactFinance();
        }

        protected void grddbo_FactFinance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactFinance.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactFinance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactFinance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactFinance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactFinance_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactFinance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactFinance.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactFinance();
        }

        protected void grddbo_FactFinance_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactFinance();
        }

        private void Edit()
        {
            try {
                dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
                Label lblFinanceKey = (Label)grddbo_FactFinance.Rows[grddbo_FactFinance.EditIndex].FindControl("lblFinanceKey");
                clsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(lblFinanceKey.Text);
                clsdbo_FactFinance = dbo_FactFinanceDataClass.Select_Record(clsdbo_FactFinance);

                Session["DateKey_SelectedValue"] = clsdbo_FactFinance.DateKey;
                Session["OrganizationKey_SelectedValue"] = clsdbo_FactFinance.OrganizationKey;
                Session["DepartmentGroupKey_SelectedValue"] = clsdbo_FactFinance.DepartmentGroupKey;
                Session["ScenarioKey_SelectedValue"] = clsdbo_FactFinance.ScenarioKey;
                Session["AccountKey_SelectedValue"] = clsdbo_FactFinance.AccountKey;

                LoadGriddbo_FactFinance();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewDateKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewDateKey");
                DropDownList txtNewOrganizationKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewOrganizationKey");
                DropDownList txtNewDepartmentGroupKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewDepartmentGroupKey");
                DropDownList txtNewScenarioKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewScenarioKey");
                DropDownList txtNewAccountKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewAccountKey");
                TextBox txtNewAmount = (TextBox)grddbo_FactFinance.FooterRow.FindControl("txtNewAmount");
                TextBox txtNewDate = (TextBox)grddbo_FactFinance.FooterRow.FindControl("txtNewDate");

                dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactFinance.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                    clsdbo_FactFinance.OrganizationKey = System.Convert.ToInt32(txtNewOrganizationKey.SelectedValue);
                    clsdbo_FactFinance.DepartmentGroupKey = System.Convert.ToInt32(txtNewDepartmentGroupKey.SelectedValue);
                    clsdbo_FactFinance.ScenarioKey = System.Convert.ToInt32(txtNewScenarioKey.SelectedValue);
                    clsdbo_FactFinance.AccountKey = System.Convert.ToInt32(txtNewAccountKey.SelectedValue);
                    clsdbo_FactFinance.Amount = System.Convert.ToDecimal(txtNewAmount.Text);
                    if (string.IsNullOrEmpty(txtNewDate.Text)) {
                        clsdbo_FactFinance.Date = null;
                    } else {
                        clsdbo_FactFinance.Date = System.Convert.ToDateTime(txtNewDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactFinanceDataClass.Add(clsdbo_FactFinance);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactFinance");
                        LoadGriddbo_FactFinance();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Finance ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtFinanceKey = (TextBox)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFinanceKey");
                DropDownList txtDateKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                DropDownList txtOrganizationKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrganizationKey");
                DropDownList txtDepartmentGroupKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentGroupKey");
                DropDownList txtScenarioKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtScenarioKey");
                DropDownList txtAccountKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountKey");
                TextBox txtAmount = (TextBox)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAmount");
                TextBox txtDate = (TextBox)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

                dbo_FactFinanceClass oclsdbo_FactFinance = new dbo_FactFinanceClass();
                dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
                oclsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(txtFinanceKey.Text);
                oclsdbo_FactFinance = dbo_FactFinanceDataClass.Select_Record(oclsdbo_FactFinance);

                if (VerifyData() == true) {
                    clsdbo_FactFinance.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
                    clsdbo_FactFinance.OrganizationKey = System.Convert.ToInt32(txtOrganizationKey.SelectedValue);
                    clsdbo_FactFinance.DepartmentGroupKey = System.Convert.ToInt32(txtDepartmentGroupKey.SelectedValue);
                    clsdbo_FactFinance.ScenarioKey = System.Convert.ToInt32(txtScenarioKey.SelectedValue);
                    clsdbo_FactFinance.AccountKey = System.Convert.ToInt32(txtAccountKey.SelectedValue);
                    clsdbo_FactFinance.Amount = System.Convert.ToDecimal(txtAmount.Text);
                    if (string.IsNullOrEmpty(txtDate.Text)) {
                        clsdbo_FactFinance.Date = null;
                    } else {
                        clsdbo_FactFinance.Date = System.Convert.ToDateTime(txtDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactFinanceDataClass.Update(oclsdbo_FactFinance, clsdbo_FactFinance);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactFinance");
                        grddbo_FactFinance.EditIndex = -1;
                        LoadGriddbo_FactFinance();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Finance ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
            Label lblFinanceKey = (Label)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblFinanceKey");
            clsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(lblFinanceKey.Text);
            clsdbo_FactFinance = dbo_FactFinanceDataClass.Select_Record(clsdbo_FactFinance);
            bool bSucess = false;
            bSucess = dbo_FactFinanceDataClass.Delete(clsdbo_FactFinance);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactFinance");
                LoadGriddbo_FactFinance();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Finance ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtFinanceKey = (TextBox)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFinanceKey");
            DropDownList txtDateKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            DropDownList txtOrganizationKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrganizationKey");
            DropDownList txtDepartmentGroupKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentGroupKey");
            DropDownList txtScenarioKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtScenarioKey");
            DropDownList txtAccountKey = (DropDownList)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountKey");
            TextBox txtAmount = (TextBox)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAmount");
            TextBox txtDate = (TextBox)grddbo_FactFinance.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Finance ");
                txtDateKey.Focus();
                return false;}
            if (txtOrganizationKey.Text == "") {
                ec.ShowMessage(" Organization Key is Required. ", " Dbo. Fact Finance ");
                txtOrganizationKey.Focus();
                return false;}
            if (txtDepartmentGroupKey.Text == "") {
                ec.ShowMessage(" Department Group Key is Required. ", " Dbo. Fact Finance ");
                txtDepartmentGroupKey.Focus();
                return false;}
            if (txtScenarioKey.Text == "") {
                ec.ShowMessage(" Scenario Key is Required. ", " Dbo. Fact Finance ");
                txtScenarioKey.Focus();
                return false;}
            if (txtAccountKey.Text == "") {
                ec.ShowMessage(" Account Key is Required. ", " Dbo. Fact Finance ");
                txtAccountKey.Focus();
                return false;}
            if (txtAmount.Text == "") {
                ec.ShowMessage(" Amount is Required. ", " Dbo. Fact Finance ");
                txtAmount.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewDateKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewDateKey");
            DropDownList txtNewOrganizationKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewOrganizationKey");
            DropDownList txtNewDepartmentGroupKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewDepartmentGroupKey");
            DropDownList txtNewScenarioKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewScenarioKey");
            DropDownList txtNewAccountKey = (DropDownList)grddbo_FactFinance.FooterRow.FindControl("txtNewAccountKey");
            TextBox txtNewAmount = (TextBox)grddbo_FactFinance.FooterRow.FindControl("txtNewAmount");
            TextBox txtNewDate = (TextBox)grddbo_FactFinance.FooterRow.FindControl("txtNewDate");

            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Finance ");
                txtNewDateKey.Focus();
                return false;}
            if (txtNewOrganizationKey.Text == "") {
                ec.ShowMessage(" Organization Key is Required. ", " Dbo. Fact Finance ");
                txtNewOrganizationKey.Focus();
                return false;}
            if (txtNewDepartmentGroupKey.Text == "") {
                ec.ShowMessage(" Department Group Key is Required. ", " Dbo. Fact Finance ");
                txtNewDepartmentGroupKey.Focus();
                return false;}
            if (txtNewScenarioKey.Text == "") {
                ec.ShowMessage(" Scenario Key is Required. ", " Dbo. Fact Finance ");
                txtNewScenarioKey.Focus();
                return false;}
            if (txtNewAccountKey.Text == "") {
                ec.ShowMessage(" Account Key is Required. ", " Dbo. Fact Finance ");
                txtNewAccountKey.Focus();
                return false;}
            if (txtNewAmount.Text == "") {
                ec.ShowMessage(" Amount is Required. ", " Dbo. Fact Finance ");
                txtNewAmount.Focus();
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
		    grddbo_FactFinance.PageIndex = 0;
		    grddbo_FactFinance.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactFinance();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactFinance");
		    LoadGriddbo_FactFinance();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactFinance");
			if ((Session["dvdbo_FactFinance"] != null)) {
				dvdbo_FactFinance = (DataView)Session["dvdbo_FactFinance"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactFinance = dbo_FactFinanceDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactFinance"] = dvdbo_FactFinance;
		    	}
                if (dvdbo_FactFinance.Count > 0) {
                    grddbo_FactFinance.DataSource = dvdbo_FactFinance;
                    grddbo_FactFinance.DataBind();
                }
                if (dvdbo_FactFinance.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("FinanceKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("OrganizationName", Type.GetType("System.Int32"));
                    dt.Columns.Add("DepartmentGroupName", Type.GetType("System.Int32"));
                    dt.Columns.Add("ScenarioName", Type.GetType("System.Int32"));
                    dt.Columns.Add("ParentAccountKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("Amount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactFinance = dt.DefaultView;
                    Session["dvdbo_FactFinance"] = dvdbo_FactFinance;

                    grddbo_FactFinance.DataSource = dvdbo_FactFinance;
                    grddbo_FactFinance.DataBind();

                    int TotalColumns = grddbo_FactFinance.Rows[0].Cells.Count;
                    grddbo_FactFinance.Rows[0].Cells.Clear();
                    grddbo_FactFinance.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactFinance.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactFinance.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactFinance.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
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
                    { dt = dbo_FactFinanceDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactFinanceDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Finance", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactFinance"];
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
 
