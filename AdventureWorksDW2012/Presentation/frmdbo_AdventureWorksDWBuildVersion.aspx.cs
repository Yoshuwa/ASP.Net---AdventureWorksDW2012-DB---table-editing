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
    public partial class frmdbo_AdventureWorksDWBuildVersion : System.Web.UI.Page
    {

        private dbo_AdventureWorksDWBuildVersionDataClass clsdbo_AdventureWorksDWBuildVersionData = new dbo_AdventureWorksDWBuildVersionDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_AdventureWorksDWBuildVersion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
                Session.Remove("Row");

                cmbFields.Items.Add("D B Version");
                cmbFields.Items.Add("Version Date");

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

                LoadGriddbo_AdventureWorksDWBuildVersion();
            }
        }

        private void LoadGriddbo_AdventureWorksDWBuildVersion()
        {
            try {
                if ((Session["dvdbo_AdventureWorksDWBuildVersion"] != null)) {
                    dvdbo_AdventureWorksDWBuildVersion = (DataView)Session["dvdbo_AdventureWorksDWBuildVersion"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.SelectAll().DefaultView;
                    Session["dvdbo_AdventureWorksDWBuildVersion"] = dvdbo_AdventureWorksDWBuildVersion;
                }
                if (dvdbo_AdventureWorksDWBuildVersion.Count > 0) {
                    grddbo_AdventureWorksDWBuildVersion.DataSource = dvdbo_AdventureWorksDWBuildVersion;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();
                }
                if (dvdbo_AdventureWorksDWBuildVersion.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("DBVersion", Type.GetType("System.String"));
                    dt.Columns.Add("VersionDate", Type.GetType("System.DateTime"));
                    dvdbo_AdventureWorksDWBuildVersion = dt.DefaultView;
                    Session["dvdbo_AdventureWorksDWBuildVersion"] = dvdbo_AdventureWorksDWBuildVersion;

                    grddbo_AdventureWorksDWBuildVersion.DataSource = dvdbo_AdventureWorksDWBuildVersion;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();

                    int TotalColumns = grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells.Count;
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells.Clear();
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells.Add(new TableCell());
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_AdventureWorksDWBuildVersion.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Adventure Works D W Build Version ");
            }
        }

        protected void grddbo_AdventureWorksDWBuildVersion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtDBVersion = (TextBox)e.Row.FindControl("txtDBVersion");
                if (txtDBVersion != null) {
                    txtDBVersion.Enabled = false;
                }
                TextBox txtVersionDate = (TextBox)e.Row.FindControl("txtVersionDate");
                if (txtVersionDate != null) {
                    txtVersionDate.Enabled = false;
                }
            }
        }

        protected void grddbo_AdventureWorksDWBuildVersion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_AdventureWorksDWBuildVersion.EditIndex = -1;
            LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        protected void grddbo_AdventureWorksDWBuildVersion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_AdventureWorksDWBuildVersion.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_AdventureWorksDWBuildVersion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_AdventureWorksDWBuildVersion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_AdventureWorksDWBuildVersion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_AdventureWorksDWBuildVersion_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_AdventureWorksDWBuildVersion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_AdventureWorksDWBuildVersion.PageIndex = e.NewPageIndex;
            LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        protected void grddbo_AdventureWorksDWBuildVersion_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        private void Edit()
        {
            try {
                dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
                Label lblDBVersion = (Label)grddbo_AdventureWorksDWBuildVersion.Rows[grddbo_AdventureWorksDWBuildVersion.EditIndex].FindControl("lblDBVersion");
                clsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(lblDBVersion.Text);
                clsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(clsdbo_AdventureWorksDWBuildVersion);


                LoadGriddbo_AdventureWorksDWBuildVersion();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewDBVersion = (TextBox)grddbo_AdventureWorksDWBuildVersion.FooterRow.FindControl("txtNewDBVersion");
                TextBox txtNewVersionDate = (TextBox)grddbo_AdventureWorksDWBuildVersion.FooterRow.FindControl("txtNewVersionDate");

                dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewDBVersion.Text)) {
                        clsdbo_AdventureWorksDWBuildVersion.DBVersion = null;
                    } else {
                        clsdbo_AdventureWorksDWBuildVersion.DBVersion = txtNewDBVersion.Text; }
                    if (string.IsNullOrEmpty(txtNewVersionDate.Text)) {
                        clsdbo_AdventureWorksDWBuildVersion.VersionDate = null;
                    } else {
                        clsdbo_AdventureWorksDWBuildVersion.VersionDate = System.Convert.ToDateTime(txtNewVersionDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_AdventureWorksDWBuildVersionDataClass.Add(clsdbo_AdventureWorksDWBuildVersion);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
                        LoadGriddbo_AdventureWorksDWBuildVersion();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Adventure Works D W Build Version ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtDBVersion = (TextBox)grddbo_AdventureWorksDWBuildVersion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDBVersion");
                TextBox txtVersionDate = (TextBox)grddbo_AdventureWorksDWBuildVersion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtVersionDate");

                dbo_AdventureWorksDWBuildVersionClass oclsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
                dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
                oclsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(txtDBVersion.Text);
                oclsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(oclsdbo_AdventureWorksDWBuildVersion);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtDBVersion.Text)) {
                        clsdbo_AdventureWorksDWBuildVersion.DBVersion = null;
                    } else {
                        clsdbo_AdventureWorksDWBuildVersion.DBVersion = txtDBVersion.Text; }
                    if (string.IsNullOrEmpty(txtVersionDate.Text)) {
                        clsdbo_AdventureWorksDWBuildVersion.VersionDate = null;
                    } else {
                        clsdbo_AdventureWorksDWBuildVersion.VersionDate = System.Convert.ToDateTime(txtVersionDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_AdventureWorksDWBuildVersionDataClass.Update(oclsdbo_AdventureWorksDWBuildVersion, clsdbo_AdventureWorksDWBuildVersion);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
                        grddbo_AdventureWorksDWBuildVersion.EditIndex = -1;
                        LoadGriddbo_AdventureWorksDWBuildVersion();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Adventure Works D W Build Version ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
            Label lblDBVersion = (Label)grddbo_AdventureWorksDWBuildVersion.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblDBVersion");
            clsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(lblDBVersion.Text);
            clsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(clsdbo_AdventureWorksDWBuildVersion);
            bool bSucess = false;
            bSucess = dbo_AdventureWorksDWBuildVersionDataClass.Delete(clsdbo_AdventureWorksDWBuildVersion);
            if (bSucess == true) {
                Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
                LoadGriddbo_AdventureWorksDWBuildVersion();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Adventure Works D W Build Version ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtDBVersion = (TextBox)grddbo_AdventureWorksDWBuildVersion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDBVersion");
            TextBox txtVersionDate = (TextBox)grddbo_AdventureWorksDWBuildVersion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtVersionDate");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewDBVersion = (TextBox)grddbo_AdventureWorksDWBuildVersion.FooterRow.FindControl("txtNewDBVersion");
            TextBox txtNewVersionDate = (TextBox)grddbo_AdventureWorksDWBuildVersion.FooterRow.FindControl("txtNewVersionDate");

            if (
                txtNewDBVersion.Text != "" 
            )  {
                dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
                clsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(txtNewDBVersion.Text);
                clsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(clsdbo_AdventureWorksDWBuildVersion);
                if (clsdbo_AdventureWorksDWBuildVersion != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Adventure Works D W Build Version ");
                    txtNewDBVersion.Focus();
                    return false; }
            }
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
		    grddbo_AdventureWorksDWBuildVersion.PageIndex = 0;
		    grddbo_AdventureWorksDWBuildVersion.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
		    LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
			if ((Session["dvdbo_AdventureWorksDWBuildVersion"] != null)) {
				dvdbo_AdventureWorksDWBuildVersion = (DataView)Session["dvdbo_AdventureWorksDWBuildVersion"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_AdventureWorksDWBuildVersion"] = dvdbo_AdventureWorksDWBuildVersion;
		    	}
                if (dvdbo_AdventureWorksDWBuildVersion.Count > 0) {
                    grddbo_AdventureWorksDWBuildVersion.DataSource = dvdbo_AdventureWorksDWBuildVersion;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();
                }
                if (dvdbo_AdventureWorksDWBuildVersion.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("DBVersion", Type.GetType("System.String"));
                    dt.Columns.Add("VersionDate", Type.GetType("System.DateTime"));
                    dvdbo_AdventureWorksDWBuildVersion = dt.DefaultView;
                    Session["dvdbo_AdventureWorksDWBuildVersion"] = dvdbo_AdventureWorksDWBuildVersion;

                    grddbo_AdventureWorksDWBuildVersion.DataSource = dvdbo_AdventureWorksDWBuildVersion;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();

                    int TotalColumns = grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells.Count;
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells.Clear();
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells.Add(new TableCell());
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_AdventureWorksDWBuildVersion.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_AdventureWorksDWBuildVersion.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Adventure Works D W Build Version ");
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
                    { dt = dbo_AdventureWorksDWBuildVersionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_AdventureWorksDWBuildVersionDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Adventure Works D W Build Version", "Many");
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
                    GVExport.DataSource = Session["dvdbo_AdventureWorksDWBuildVersion"];
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
 
