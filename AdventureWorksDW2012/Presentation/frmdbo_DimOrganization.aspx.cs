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
    public partial class frmdbo_DimOrganization : System.Web.UI.Page
    {

        private dbo_DimOrganizationDataClass clsdbo_DimOrganizationData = new dbo_DimOrganizationDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimOrganization;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ParentOrganizationKey_SelectedValue"] = "";
                Session["CurrencyKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimOrganization");
                Session.Remove("Row");

                cmbFields.Items.Add("Organization Key");
                cmbFields.Items.Add("Parent Organization Key");
                cmbFields.Items.Add("Percentage Of Ownership");
                cmbFields.Items.Add("Organization Name");
                cmbFields.Items.Add("Currency Key");

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

                LoadGriddbo_DimOrganization();
            }
        }

        private void Loaddbo_DimOrganization_dbo_DimOrganizationComboBox109(GridViewRowEventArgs e)
        {
            List<dbo_DimOrganization_dbo_DimOrganizationClass109> dbo_DimOrganization_dbo_DimOrganizationList = new  List<dbo_DimOrganization_dbo_DimOrganizationClass109>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtParentOrganizationKey = (DropDownList)e.Row.FindControl("txtParentOrganizationKey");
                if (txtParentOrganizationKey != null) {
                    try {
                        dbo_DimOrganization_dbo_DimOrganizationList = dbo_DimOrganization_dbo_DimOrganizationDataClass109.List();
                        txtParentOrganizationKey.DataSource = dbo_DimOrganization_dbo_DimOrganizationList;
                        txtParentOrganizationKey.DataValueField = "OrganizationKey";
                        txtParentOrganizationKey.DataTextField = "OrganizationName";
                        txtParentOrganizationKey.DataBind();
                        txtParentOrganizationKey.SelectedValue = Convert.ToString(Session["ParentOrganizationKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewParentOrganizationKey = (DropDownList)e.Row.FindControl("txtNewParentOrganizationKey");
                if (txtNewParentOrganizationKey != null) {
                    try {
                        dbo_DimOrganization_dbo_DimOrganizationList = dbo_DimOrganization_dbo_DimOrganizationDataClass109.List();
                        txtNewParentOrganizationKey.DataSource = dbo_DimOrganization_dbo_DimOrganizationList;
                        txtNewParentOrganizationKey.DataValueField = "OrganizationKey";
                        txtNewParentOrganizationKey.DataTextField = "OrganizationName";
                        txtNewParentOrganizationKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
                    }
                }
            }
        }

        private void Loaddbo_DimOrganization_dbo_DimCurrencyComboBox112(GridViewRowEventArgs e)
        {
            List<dbo_DimOrganization_dbo_DimCurrencyClass112> dbo_DimOrganization_dbo_DimCurrencyList = new  List<dbo_DimOrganization_dbo_DimCurrencyClass112>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCurrencyKey = (DropDownList)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    try {
                        dbo_DimOrganization_dbo_DimCurrencyList = dbo_DimOrganization_dbo_DimCurrencyDataClass112.List();
                        txtCurrencyKey.DataSource = dbo_DimOrganization_dbo_DimCurrencyList;
                        txtCurrencyKey.DataValueField = "CurrencyKey";
                        txtCurrencyKey.DataTextField = "CurrencyName";
                        txtCurrencyKey.DataBind();
                        txtCurrencyKey.SelectedValue = Convert.ToString(Session["CurrencyKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewCurrencyKey = (DropDownList)e.Row.FindControl("txtNewCurrencyKey");
                if (txtNewCurrencyKey != null) {
                    try {
                        dbo_DimOrganization_dbo_DimCurrencyList = dbo_DimOrganization_dbo_DimCurrencyDataClass112.List();
                        txtNewCurrencyKey.DataSource = dbo_DimOrganization_dbo_DimCurrencyList;
                        txtNewCurrencyKey.DataValueField = "CurrencyKey";
                        txtNewCurrencyKey.DataTextField = "CurrencyName";
                        txtNewCurrencyKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimOrganization()
        {
            try {
                if ((Session["dvdbo_DimOrganization"] != null)) {
                    dvdbo_DimOrganization = (DataView)Session["dvdbo_DimOrganization"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimOrganization = dbo_DimOrganizationDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimOrganization"] = dvdbo_DimOrganization;
                }
                if (dvdbo_DimOrganization.Count > 0) {
                    grddbo_DimOrganization.DataSource = dvdbo_DimOrganization;
                    grddbo_DimOrganization.DataBind();
                }
                if (dvdbo_DimOrganization.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("OrganizationKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("OrganizationName", Type.GetType("System.Int32"));
                    dt.Columns.Add("PercentageOfOwnership", Type.GetType("System.String"));
                    dt.Columns.Add("OrganizationName", Type.GetType("System.String"));
                    dt.Columns.Add("CurrencyName", Type.GetType("System.Int32"));
                    dvdbo_DimOrganization = dt.DefaultView;
                    Session["dvdbo_DimOrganization"] = dvdbo_DimOrganization;

                    grddbo_DimOrganization.DataSource = dvdbo_DimOrganization;
                    grddbo_DimOrganization.DataBind();

                    int TotalColumns = grddbo_DimOrganization.Rows[0].Cells.Count;
                    grddbo_DimOrganization.Rows[0].Cells.Clear();
                    grddbo_DimOrganization.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimOrganization.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimOrganization.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimOrganization.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
            }
        }

        protected void grddbo_DimOrganization_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimOrganization_dbo_DimOrganizationComboBox109(e);
            Loaddbo_DimOrganization_dbo_DimCurrencyComboBox112(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtOrganizationKey = (TextBox)e.Row.FindControl("txtOrganizationKey");
                if (txtOrganizationKey != null) {
                    txtOrganizationKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewOrganizationKey = (TextBox)e.Row.FindControl("txtNewOrganizationKey");
                if (txtNewOrganizationKey != null) {
                    txtNewOrganizationKey.Enabled = false;
                }
                txtNewOrganizationKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimOrganization"));
            }
        }

        protected void grddbo_DimOrganization_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimOrganization.EditIndex = -1;
            LoadGriddbo_DimOrganization();
        }

        protected void grddbo_DimOrganization_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimOrganization.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimOrganization_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimOrganization_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimOrganization_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimOrganization_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimOrganization_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimOrganization.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimOrganization();
        }

        protected void grddbo_DimOrganization_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimOrganization();
        }

        private void Edit()
        {
            try {
                dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
                Label lblOrganizationKey = (Label)grddbo_DimOrganization.Rows[grddbo_DimOrganization.EditIndex].FindControl("lblOrganizationKey");
                clsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(lblOrganizationKey.Text);
                clsdbo_DimOrganization = dbo_DimOrganizationDataClass.Select_Record(clsdbo_DimOrganization);

                Session["ParentOrganizationKey_SelectedValue"] = clsdbo_DimOrganization.ParentOrganizationKey;
                Session["CurrencyKey_SelectedValue"] = clsdbo_DimOrganization.CurrencyKey;

                LoadGriddbo_DimOrganization();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewParentOrganizationKey = (DropDownList)grddbo_DimOrganization.FooterRow.FindControl("txtNewParentOrganizationKey");
                TextBox txtNewPercentageOfOwnership = (TextBox)grddbo_DimOrganization.FooterRow.FindControl("txtNewPercentageOfOwnership");
                TextBox txtNewOrganizationName = (TextBox)grddbo_DimOrganization.FooterRow.FindControl("txtNewOrganizationName");
                DropDownList txtNewCurrencyKey = (DropDownList)grddbo_DimOrganization.FooterRow.FindControl("txtNewCurrencyKey");

                dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewParentOrganizationKey.SelectedValue)) {
                        clsdbo_DimOrganization.ParentOrganizationKey = null;
                    } else {
                        clsdbo_DimOrganization.ParentOrganizationKey = System.Convert.ToInt32(txtNewParentOrganizationKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewPercentageOfOwnership.Text)) {
                        clsdbo_DimOrganization.PercentageOfOwnership = null;
                    } else {
                        clsdbo_DimOrganization.PercentageOfOwnership = txtNewPercentageOfOwnership.Text; }
                    if (string.IsNullOrEmpty(txtNewOrganizationName.Text)) {
                        clsdbo_DimOrganization.OrganizationName = null;
                    } else {
                        clsdbo_DimOrganization.OrganizationName = txtNewOrganizationName.Text; }
                    if (string.IsNullOrEmpty(txtNewCurrencyKey.SelectedValue)) {
                        clsdbo_DimOrganization.CurrencyKey = null;
                    } else {
                        clsdbo_DimOrganization.CurrencyKey = System.Convert.ToInt32(txtNewCurrencyKey.SelectedValue); }
                    bool bSucess = false;
                    bSucess = dbo_DimOrganizationDataClass.Add(clsdbo_DimOrganization);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimOrganization");
                        LoadGriddbo_DimOrganization();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Organization ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtOrganizationKey = (TextBox)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrganizationKey");
                DropDownList txtParentOrganizationKey = (DropDownList)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentOrganizationKey");
                TextBox txtPercentageOfOwnership = (TextBox)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPercentageOfOwnership");
                TextBox txtOrganizationName = (TextBox)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrganizationName");
                DropDownList txtCurrencyKey = (DropDownList)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");

                dbo_DimOrganizationClass oclsdbo_DimOrganization = new dbo_DimOrganizationClass();
                dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
                oclsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(txtOrganizationKey.Text);
                oclsdbo_DimOrganization = dbo_DimOrganizationDataClass.Select_Record(oclsdbo_DimOrganization);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtParentOrganizationKey.SelectedValue)) {
                        clsdbo_DimOrganization.ParentOrganizationKey = null;
                    } else {
                        clsdbo_DimOrganization.ParentOrganizationKey = System.Convert.ToInt32(txtParentOrganizationKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtPercentageOfOwnership.Text)) {
                        clsdbo_DimOrganization.PercentageOfOwnership = null;
                    } else {
                        clsdbo_DimOrganization.PercentageOfOwnership = txtPercentageOfOwnership.Text; }
                    if (string.IsNullOrEmpty(txtOrganizationName.Text)) {
                        clsdbo_DimOrganization.OrganizationName = null;
                    } else {
                        clsdbo_DimOrganization.OrganizationName = txtOrganizationName.Text; }
                    if (string.IsNullOrEmpty(txtCurrencyKey.SelectedValue)) {
                        clsdbo_DimOrganization.CurrencyKey = null;
                    } else {
                        clsdbo_DimOrganization.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue); }
                    bool bSucess = false;
                    bSucess = dbo_DimOrganizationDataClass.Update(oclsdbo_DimOrganization, clsdbo_DimOrganization);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimOrganization");
                        grddbo_DimOrganization.EditIndex = -1;
                        LoadGriddbo_DimOrganization();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Organization ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
            Label lblOrganizationKey = (Label)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblOrganizationKey");
            clsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(lblOrganizationKey.Text);
            clsdbo_DimOrganization = dbo_DimOrganizationDataClass.Select_Record(clsdbo_DimOrganization);
            bool bSucess = false;
            bSucess = dbo_DimOrganizationDataClass.Delete(clsdbo_DimOrganization);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimOrganization");
                LoadGriddbo_DimOrganization();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Organization ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtOrganizationKey = (TextBox)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrganizationKey");
            DropDownList txtParentOrganizationKey = (DropDownList)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentOrganizationKey");
            TextBox txtPercentageOfOwnership = (TextBox)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPercentageOfOwnership");
            TextBox txtOrganizationName = (TextBox)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrganizationName");
            DropDownList txtCurrencyKey = (DropDownList)grddbo_DimOrganization.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewParentOrganizationKey = (DropDownList)grddbo_DimOrganization.FooterRow.FindControl("txtNewParentOrganizationKey");
            TextBox txtNewPercentageOfOwnership = (TextBox)grddbo_DimOrganization.FooterRow.FindControl("txtNewPercentageOfOwnership");
            TextBox txtNewOrganizationName = (TextBox)grddbo_DimOrganization.FooterRow.FindControl("txtNewOrganizationName");
            DropDownList txtNewCurrencyKey = (DropDownList)grddbo_DimOrganization.FooterRow.FindControl("txtNewCurrencyKey");

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
		    grddbo_DimOrganization.PageIndex = 0;
		    grddbo_DimOrganization.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimOrganization();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimOrganization");
		    LoadGriddbo_DimOrganization();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimOrganization");
			if ((Session["dvdbo_DimOrganization"] != null)) {
				dvdbo_DimOrganization = (DataView)Session["dvdbo_DimOrganization"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimOrganization = dbo_DimOrganizationDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimOrganization"] = dvdbo_DimOrganization;
		    	}
                if (dvdbo_DimOrganization.Count > 0) {
                    grddbo_DimOrganization.DataSource = dvdbo_DimOrganization;
                    grddbo_DimOrganization.DataBind();
                }
                if (dvdbo_DimOrganization.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("OrganizationKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("OrganizationName", Type.GetType("System.Int32"));
                    dt.Columns.Add("PercentageOfOwnership", Type.GetType("System.String"));
                    dt.Columns.Add("OrganizationName", Type.GetType("System.String"));
                    dt.Columns.Add("CurrencyName", Type.GetType("System.Int32"));
                    dvdbo_DimOrganization = dt.DefaultView;
                    Session["dvdbo_DimOrganization"] = dvdbo_DimOrganization;

                    grddbo_DimOrganization.DataSource = dvdbo_DimOrganization;
                    grddbo_DimOrganization.DataBind();

                    int TotalColumns = grddbo_DimOrganization.Rows[0].Cells.Count;
                    grddbo_DimOrganization.Rows[0].Cells.Clear();
                    grddbo_DimOrganization.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimOrganization.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimOrganization.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimOrganization.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
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
                    { dt = dbo_DimOrganizationDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimOrganizationDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Organization", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimOrganization"];
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
 
