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
    public partial class frmdbo_DimScenario : System.Web.UI.Page
    {

        private dbo_DimScenarioDataClass clsdbo_DimScenarioData = new dbo_DimScenarioDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimScenario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimScenario");
                Session.Remove("Row");

                cmbFields.Items.Add("Scenario Key");
                cmbFields.Items.Add("Scenario Name");

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

                LoadGriddbo_DimScenario();
            }
        }

        private void LoadGriddbo_DimScenario()
        {
            try {
                if ((Session["dvdbo_DimScenario"] != null)) {
                    dvdbo_DimScenario = (DataView)Session["dvdbo_DimScenario"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimScenario = dbo_DimScenarioDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimScenario"] = dvdbo_DimScenario;
                }
                if (dvdbo_DimScenario.Count > 0) {
                    grddbo_DimScenario.DataSource = dvdbo_DimScenario;
                    grddbo_DimScenario.DataBind();
                }
                if (dvdbo_DimScenario.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ScenarioKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ScenarioName", Type.GetType("System.String"));
                    dvdbo_DimScenario = dt.DefaultView;
                    Session["dvdbo_DimScenario"] = dvdbo_DimScenario;

                    grddbo_DimScenario.DataSource = dvdbo_DimScenario;
                    grddbo_DimScenario.DataBind();

                    int TotalColumns = grddbo_DimScenario.Rows[0].Cells.Count;
                    grddbo_DimScenario.Rows[0].Cells.Clear();
                    grddbo_DimScenario.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimScenario.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimScenario.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimScenario.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Scenario ");
            }
        }

        protected void grddbo_DimScenario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtScenarioKey = (TextBox)e.Row.FindControl("txtScenarioKey");
                if (txtScenarioKey != null) {
                    txtScenarioKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewScenarioKey = (TextBox)e.Row.FindControl("txtNewScenarioKey");
                if (txtNewScenarioKey != null) {
                    txtNewScenarioKey.Enabled = false;
                }
                txtNewScenarioKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimScenario"));
            }
        }

        protected void grddbo_DimScenario_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimScenario.EditIndex = -1;
            LoadGriddbo_DimScenario();
        }

        protected void grddbo_DimScenario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimScenario.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimScenario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimScenario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimScenario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimScenario_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimScenario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimScenario.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimScenario();
        }

        protected void grddbo_DimScenario_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimScenario();
        }

        private void Edit()
        {
            try {
                dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
                Label lblScenarioKey = (Label)grddbo_DimScenario.Rows[grddbo_DimScenario.EditIndex].FindControl("lblScenarioKey");
                clsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(lblScenarioKey.Text);
                clsdbo_DimScenario = dbo_DimScenarioDataClass.Select_Record(clsdbo_DimScenario);


                LoadGriddbo_DimScenario();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewScenarioName = (TextBox)grddbo_DimScenario.FooterRow.FindControl("txtNewScenarioName");

                dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewScenarioName.Text)) {
                        clsdbo_DimScenario.ScenarioName = null;
                    } else {
                        clsdbo_DimScenario.ScenarioName = txtNewScenarioName.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimScenarioDataClass.Add(clsdbo_DimScenario);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimScenario");
                        LoadGriddbo_DimScenario();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Scenario ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtScenarioKey = (TextBox)grddbo_DimScenario.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtScenarioKey");
                TextBox txtScenarioName = (TextBox)grddbo_DimScenario.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtScenarioName");

                dbo_DimScenarioClass oclsdbo_DimScenario = new dbo_DimScenarioClass();
                dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
                oclsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(txtScenarioKey.Text);
                oclsdbo_DimScenario = dbo_DimScenarioDataClass.Select_Record(oclsdbo_DimScenario);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtScenarioName.Text)) {
                        clsdbo_DimScenario.ScenarioName = null;
                    } else {
                        clsdbo_DimScenario.ScenarioName = txtScenarioName.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimScenarioDataClass.Update(oclsdbo_DimScenario, clsdbo_DimScenario);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimScenario");
                        grddbo_DimScenario.EditIndex = -1;
                        LoadGriddbo_DimScenario();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Scenario ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
            Label lblScenarioKey = (Label)grddbo_DimScenario.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblScenarioKey");
            clsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(lblScenarioKey.Text);
            clsdbo_DimScenario = dbo_DimScenarioDataClass.Select_Record(clsdbo_DimScenario);
            bool bSucess = false;
            bSucess = dbo_DimScenarioDataClass.Delete(clsdbo_DimScenario);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimScenario");
                LoadGriddbo_DimScenario();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Scenario ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtScenarioKey = (TextBox)grddbo_DimScenario.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtScenarioKey");
            TextBox txtScenarioName = (TextBox)grddbo_DimScenario.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtScenarioName");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewScenarioName = (TextBox)grddbo_DimScenario.FooterRow.FindControl("txtNewScenarioName");

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
		    grddbo_DimScenario.PageIndex = 0;
		    grddbo_DimScenario.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimScenario();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimScenario");
		    LoadGriddbo_DimScenario();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimScenario");
			if ((Session["dvdbo_DimScenario"] != null)) {
				dvdbo_DimScenario = (DataView)Session["dvdbo_DimScenario"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimScenario = dbo_DimScenarioDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimScenario"] = dvdbo_DimScenario;
		    	}
                if (dvdbo_DimScenario.Count > 0) {
                    grddbo_DimScenario.DataSource = dvdbo_DimScenario;
                    grddbo_DimScenario.DataBind();
                }
                if (dvdbo_DimScenario.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ScenarioKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ScenarioName", Type.GetType("System.String"));
                    dvdbo_DimScenario = dt.DefaultView;
                    Session["dvdbo_DimScenario"] = dvdbo_DimScenario;

                    grddbo_DimScenario.DataSource = dvdbo_DimScenario;
                    grddbo_DimScenario.DataBind();

                    int TotalColumns = grddbo_DimScenario.Rows[0].Cells.Count;
                    grddbo_DimScenario.Rows[0].Cells.Clear();
                    grddbo_DimScenario.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimScenario.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimScenario.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimScenario.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Scenario ");
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
                    { dt = dbo_DimScenarioDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimScenarioDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Scenario", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimScenario"];
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
 
