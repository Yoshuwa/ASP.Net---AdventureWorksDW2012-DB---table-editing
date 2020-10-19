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
    public partial class frmdbo_DimAccount : System.Web.UI.Page
    {

        private dbo_DimAccountDataClass clsdbo_DimAccountData = new dbo_DimAccountDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ParentAccountKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimAccount");
                Session.Remove("Row");

                cmbFields.Items.Add("Account Key");
                cmbFields.Items.Add("Parent Account Key");
                cmbFields.Items.Add("Account Code Alternate Key");
                cmbFields.Items.Add("Parent Account Code Alternate Key");
                cmbFields.Items.Add("Account Description");
                cmbFields.Items.Add("Account Type");
                cmbFields.Items.Add("Operator");
                cmbFields.Items.Add("Custom Members");
                cmbFields.Items.Add("Value Type");
                cmbFields.Items.Add("Custom Member Options");

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

                LoadGriddbo_DimAccount();
            }
        }

        private void Loaddbo_DimAccount_dbo_DimAccountComboBox4(GridViewRowEventArgs e)
        {
            List<dbo_DimAccount_dbo_DimAccountClass4> dbo_DimAccount_dbo_DimAccountList = new  List<dbo_DimAccount_dbo_DimAccountClass4>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtParentAccountKey = (DropDownList)e.Row.FindControl("txtParentAccountKey");
                if (txtParentAccountKey != null) {
                    try {
                        dbo_DimAccount_dbo_DimAccountList = dbo_DimAccount_dbo_DimAccountDataClass4.List();
                        txtParentAccountKey.DataSource = dbo_DimAccount_dbo_DimAccountList;
                        txtParentAccountKey.DataValueField = "AccountKey";
                        txtParentAccountKey.DataTextField = "ParentAccountKey";
                        txtParentAccountKey.DataBind();
                        txtParentAccountKey.SelectedValue = Convert.ToString(Session["ParentAccountKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewParentAccountKey = (DropDownList)e.Row.FindControl("txtNewParentAccountKey");
                if (txtNewParentAccountKey != null) {
                    try {
                        dbo_DimAccount_dbo_DimAccountList = dbo_DimAccount_dbo_DimAccountDataClass4.List();
                        txtNewParentAccountKey.DataSource = dbo_DimAccount_dbo_DimAccountList;
                        txtNewParentAccountKey.DataValueField = "AccountKey";
                        txtNewParentAccountKey.DataTextField = "ParentAccountKey";
                        txtNewParentAccountKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimAccount()
        {
            try {
                if ((Session["dvdbo_DimAccount"] != null)) {
                    dvdbo_DimAccount = (DataView)Session["dvdbo_DimAccount"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimAccount = dbo_DimAccountDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimAccount"] = dvdbo_DimAccount;
                }
                if (dvdbo_DimAccount.Count > 0) {
                    grddbo_DimAccount.DataSource = dvdbo_DimAccount;
                    grddbo_DimAccount.DataBind();
                }
                if (dvdbo_DimAccount.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("AccountKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ParentAccountKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("AccountCodeAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ParentAccountCodeAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("AccountDescription", Type.GetType("System.String"));
                    dt.Columns.Add("AccountType", Type.GetType("System.String"));
                    dt.Columns.Add("Operator", Type.GetType("System.String"));
                    dt.Columns.Add("CustomMembers", Type.GetType("System.String"));
                    dt.Columns.Add("ValueType", Type.GetType("System.String"));
                    dt.Columns.Add("CustomMemberOptions", Type.GetType("System.String"));
                    dvdbo_DimAccount = dt.DefaultView;
                    Session["dvdbo_DimAccount"] = dvdbo_DimAccount;

                    grddbo_DimAccount.DataSource = dvdbo_DimAccount;
                    grddbo_DimAccount.DataBind();

                    int TotalColumns = grddbo_DimAccount.Rows[0].Cells.Count;
                    grddbo_DimAccount.Rows[0].Cells.Clear();
                    grddbo_DimAccount.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimAccount.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimAccount.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimAccount.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
            }
        }

        protected void grddbo_DimAccount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimAccount_dbo_DimAccountComboBox4(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtAccountKey = (TextBox)e.Row.FindControl("txtAccountKey");
                if (txtAccountKey != null) {
                    txtAccountKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewAccountKey = (TextBox)e.Row.FindControl("txtNewAccountKey");
                if (txtNewAccountKey != null) {
                    txtNewAccountKey.Enabled = false;
                }
                txtNewAccountKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimAccount"));
            }
        }

        protected void grddbo_DimAccount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimAccount.EditIndex = -1;
            LoadGriddbo_DimAccount();
        }

        protected void grddbo_DimAccount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimAccount.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimAccount_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimAccount_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimAccount_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimAccount_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimAccount.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimAccount();
        }

        protected void grddbo_DimAccount_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimAccount();
        }

        private void Edit()
        {
            try {
                dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
                Label lblAccountKey = (Label)grddbo_DimAccount.Rows[grddbo_DimAccount.EditIndex].FindControl("lblAccountKey");
                clsdbo_DimAccount.AccountKey = System.Convert.ToInt32(lblAccountKey.Text);
                clsdbo_DimAccount = dbo_DimAccountDataClass.Select_Record(clsdbo_DimAccount);

                Session["ParentAccountKey_SelectedValue"] = clsdbo_DimAccount.ParentAccountKey;

                LoadGriddbo_DimAccount();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewParentAccountKey = (DropDownList)grddbo_DimAccount.FooterRow.FindControl("txtNewParentAccountKey");
                TextBox txtNewAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewAccountCodeAlternateKey");
                TextBox txtNewParentAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewParentAccountCodeAlternateKey");
                TextBox txtNewAccountDescription = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewAccountDescription");
                TextBox txtNewAccountType = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewAccountType");
                TextBox txtNewOperator = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewOperator");
                TextBox txtNewCustomMembers = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewCustomMembers");
                TextBox txtNewValueType = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewValueType");
                TextBox txtNewCustomMemberOptions = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewCustomMemberOptions");

                dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewParentAccountKey.SelectedValue)) {
                        clsdbo_DimAccount.ParentAccountKey = null;
                    } else {
                        clsdbo_DimAccount.ParentAccountKey = System.Convert.ToInt32(txtNewParentAccountKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewAccountCodeAlternateKey.Text)) {
                        clsdbo_DimAccount.AccountCodeAlternateKey = null;
                    } else {
                        clsdbo_DimAccount.AccountCodeAlternateKey = System.Convert.ToInt32(txtNewAccountCodeAlternateKey.Text); }
                    if (string.IsNullOrEmpty(txtNewParentAccountCodeAlternateKey.Text)) {
                        clsdbo_DimAccount.ParentAccountCodeAlternateKey = null;
                    } else {
                        clsdbo_DimAccount.ParentAccountCodeAlternateKey = System.Convert.ToInt32(txtNewParentAccountCodeAlternateKey.Text); }
                    if (string.IsNullOrEmpty(txtNewAccountDescription.Text)) {
                        clsdbo_DimAccount.AccountDescription = null;
                    } else {
                        clsdbo_DimAccount.AccountDescription = txtNewAccountDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewAccountType.Text)) {
                        clsdbo_DimAccount.AccountType = null;
                    } else {
                        clsdbo_DimAccount.AccountType = txtNewAccountType.Text; }
                    if (string.IsNullOrEmpty(txtNewOperator.Text)) {
                        clsdbo_DimAccount.Operator = null;
                    } else {
                        clsdbo_DimAccount.Operator = txtNewOperator.Text; }
                    if (string.IsNullOrEmpty(txtNewCustomMembers.Text)) {
                        clsdbo_DimAccount.CustomMembers = null;
                    } else {
                        clsdbo_DimAccount.CustomMembers = txtNewCustomMembers.Text; }
                    if (string.IsNullOrEmpty(txtNewValueType.Text)) {
                        clsdbo_DimAccount.ValueType = null;
                    } else {
                        clsdbo_DimAccount.ValueType = txtNewValueType.Text; }
                    if (string.IsNullOrEmpty(txtNewCustomMemberOptions.Text)) {
                        clsdbo_DimAccount.CustomMemberOptions = null;
                    } else {
                        clsdbo_DimAccount.CustomMemberOptions = txtNewCustomMemberOptions.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimAccountDataClass.Add(clsdbo_DimAccount);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimAccount");
                        LoadGriddbo_DimAccount();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Account ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtAccountKey = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountKey");
                DropDownList txtParentAccountKey = (DropDownList)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentAccountKey");
                TextBox txtAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountCodeAlternateKey");
                TextBox txtParentAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentAccountCodeAlternateKey");
                TextBox txtAccountDescription = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountDescription");
                TextBox txtAccountType = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountType");
                TextBox txtOperator = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOperator");
                TextBox txtCustomMembers = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomMembers");
                TextBox txtValueType = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtValueType");
                TextBox txtCustomMemberOptions = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomMemberOptions");

                dbo_DimAccountClass oclsdbo_DimAccount = new dbo_DimAccountClass();
                dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
                oclsdbo_DimAccount.AccountKey = System.Convert.ToInt32(txtAccountKey.Text);
                oclsdbo_DimAccount = dbo_DimAccountDataClass.Select_Record(oclsdbo_DimAccount);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtParentAccountKey.SelectedValue)) {
                        clsdbo_DimAccount.ParentAccountKey = null;
                    } else {
                        clsdbo_DimAccount.ParentAccountKey = System.Convert.ToInt32(txtParentAccountKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtAccountCodeAlternateKey.Text)) {
                        clsdbo_DimAccount.AccountCodeAlternateKey = null;
                    } else {
                        clsdbo_DimAccount.AccountCodeAlternateKey = System.Convert.ToInt32(txtAccountCodeAlternateKey.Text); }
                    if (string.IsNullOrEmpty(txtParentAccountCodeAlternateKey.Text)) {
                        clsdbo_DimAccount.ParentAccountCodeAlternateKey = null;
                    } else {
                        clsdbo_DimAccount.ParentAccountCodeAlternateKey = System.Convert.ToInt32(txtParentAccountCodeAlternateKey.Text); }
                    if (string.IsNullOrEmpty(txtAccountDescription.Text)) {
                        clsdbo_DimAccount.AccountDescription = null;
                    } else {
                        clsdbo_DimAccount.AccountDescription = txtAccountDescription.Text; }
                    if (string.IsNullOrEmpty(txtAccountType.Text)) {
                        clsdbo_DimAccount.AccountType = null;
                    } else {
                        clsdbo_DimAccount.AccountType = txtAccountType.Text; }
                    if (string.IsNullOrEmpty(txtOperator.Text)) {
                        clsdbo_DimAccount.Operator = null;
                    } else {
                        clsdbo_DimAccount.Operator = txtOperator.Text; }
                    if (string.IsNullOrEmpty(txtCustomMembers.Text)) {
                        clsdbo_DimAccount.CustomMembers = null;
                    } else {
                        clsdbo_DimAccount.CustomMembers = txtCustomMembers.Text; }
                    if (string.IsNullOrEmpty(txtValueType.Text)) {
                        clsdbo_DimAccount.ValueType = null;
                    } else {
                        clsdbo_DimAccount.ValueType = txtValueType.Text; }
                    if (string.IsNullOrEmpty(txtCustomMemberOptions.Text)) {
                        clsdbo_DimAccount.CustomMemberOptions = null;
                    } else {
                        clsdbo_DimAccount.CustomMemberOptions = txtCustomMemberOptions.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimAccountDataClass.Update(oclsdbo_DimAccount, clsdbo_DimAccount);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimAccount");
                        grddbo_DimAccount.EditIndex = -1;
                        LoadGriddbo_DimAccount();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Account ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
            Label lblAccountKey = (Label)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblAccountKey");
            clsdbo_DimAccount.AccountKey = System.Convert.ToInt32(lblAccountKey.Text);
            clsdbo_DimAccount = dbo_DimAccountDataClass.Select_Record(clsdbo_DimAccount);
            bool bSucess = false;
            bSucess = dbo_DimAccountDataClass.Delete(clsdbo_DimAccount);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimAccount");
                LoadGriddbo_DimAccount();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Account ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtAccountKey = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountKey");
            DropDownList txtParentAccountKey = (DropDownList)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentAccountKey");
            TextBox txtAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountCodeAlternateKey");
            TextBox txtParentAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentAccountCodeAlternateKey");
            TextBox txtAccountDescription = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountDescription");
            TextBox txtAccountType = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAccountType");
            TextBox txtOperator = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOperator");
            TextBox txtCustomMembers = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomMembers");
            TextBox txtValueType = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtValueType");
            TextBox txtCustomMemberOptions = (TextBox)grddbo_DimAccount.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomMemberOptions");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewParentAccountKey = (DropDownList)grddbo_DimAccount.FooterRow.FindControl("txtNewParentAccountKey");
            TextBox txtNewAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewAccountCodeAlternateKey");
            TextBox txtNewParentAccountCodeAlternateKey = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewParentAccountCodeAlternateKey");
            TextBox txtNewAccountDescription = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewAccountDescription");
            TextBox txtNewAccountType = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewAccountType");
            TextBox txtNewOperator = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewOperator");
            TextBox txtNewCustomMembers = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewCustomMembers");
            TextBox txtNewValueType = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewValueType");
            TextBox txtNewCustomMemberOptions = (TextBox)grddbo_DimAccount.FooterRow.FindControl("txtNewCustomMemberOptions");

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
		    grddbo_DimAccount.PageIndex = 0;
		    grddbo_DimAccount.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimAccount();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimAccount");
		    LoadGriddbo_DimAccount();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimAccount");
			if ((Session["dvdbo_DimAccount"] != null)) {
				dvdbo_DimAccount = (DataView)Session["dvdbo_DimAccount"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimAccount = dbo_DimAccountDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimAccount"] = dvdbo_DimAccount;
		    	}
                if (dvdbo_DimAccount.Count > 0) {
                    grddbo_DimAccount.DataSource = dvdbo_DimAccount;
                    grddbo_DimAccount.DataBind();
                }
                if (dvdbo_DimAccount.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("AccountKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ParentAccountKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("AccountCodeAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ParentAccountCodeAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("AccountDescription", Type.GetType("System.String"));
                    dt.Columns.Add("AccountType", Type.GetType("System.String"));
                    dt.Columns.Add("Operator", Type.GetType("System.String"));
                    dt.Columns.Add("CustomMembers", Type.GetType("System.String"));
                    dt.Columns.Add("ValueType", Type.GetType("System.String"));
                    dt.Columns.Add("CustomMemberOptions", Type.GetType("System.String"));
                    dvdbo_DimAccount = dt.DefaultView;
                    Session["dvdbo_DimAccount"] = dvdbo_DimAccount;

                    grddbo_DimAccount.DataSource = dvdbo_DimAccount;
                    grddbo_DimAccount.DataBind();

                    int TotalColumns = grddbo_DimAccount.Rows[0].Cells.Count;
                    grddbo_DimAccount.Rows[0].Cells.Clear();
                    grddbo_DimAccount.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimAccount.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimAccount.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimAccount.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
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
                    { dt = dbo_DimAccountDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimAccountDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Account", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimAccount"];
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
 
