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
    public partial class frmdbo_FactInternetSalesReason : System.Web.UI.Page
    {

        private dbo_FactInternetSalesReasonDataClass clsdbo_FactInternetSalesReasonData = new dbo_FactInternetSalesReasonDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactInternetSalesReason;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["SalesOrderNumber_SelectedValue"] = "";
                Session["SalesOrderLineNumber_SelectedValue"] = "";
                Session["SalesReasonKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactInternetSalesReason");
                Session.Remove("Row");

                cmbFields.Items.Add("Sales Order Number");
                cmbFields.Items.Add("Sales Order Line Number");
                cmbFields.Items.Add("Sales Reason Key");

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

                LoadGriddbo_FactInternetSalesReason();
            }
        }

        private void Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox262(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262> dbo_FactInternetSalesReason_dbo_FactInternetSalesList = new  List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesOrderNumber = (DropDownList)e.Row.FindControl("txtSalesOrderNumber");
                if (txtSalesOrderNumber != null) {
                    try {
                        dbo_FactInternetSalesReason_dbo_FactInternetSalesList = dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass262.List();
                        txtSalesOrderNumber.DataSource = dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
                        txtSalesOrderNumber.DataValueField = "SalesOrderNumber";
                        txtSalesOrderNumber.DataTextField = "ProductKey";
                        txtSalesOrderNumber.DataBind();
                        txtSalesOrderNumber.SelectedValue = Convert.ToString(Session["SalesOrderNumber_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesOrderNumber = (DropDownList)e.Row.FindControl("txtNewSalesOrderNumber");
                if (txtNewSalesOrderNumber != null) {
                    try {
                        dbo_FactInternetSalesReason_dbo_FactInternetSalesList = dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass262.List();
                        txtNewSalesOrderNumber.DataSource = dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
                        txtNewSalesOrderNumber.DataValueField = "SalesOrderNumber";
                        txtNewSalesOrderNumber.DataTextField = "ProductKey";
                        txtNewSalesOrderNumber.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox263(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263> dbo_FactInternetSalesReason_dbo_FactInternetSalesList = new  List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesOrderLineNumber = (DropDownList)e.Row.FindControl("txtSalesOrderLineNumber");
                if (txtSalesOrderLineNumber != null) {
                    try {
                        dbo_FactInternetSalesReason_dbo_FactInternetSalesList = dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass263.List();
                        txtSalesOrderLineNumber.DataSource = dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
                        txtSalesOrderLineNumber.DataValueField = "SalesOrderLineNumber";
                        txtSalesOrderLineNumber.DataTextField = "ProductKey";
                        txtSalesOrderLineNumber.DataBind();
                        txtSalesOrderLineNumber.SelectedValue = Convert.ToString(Session["SalesOrderLineNumber_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesOrderLineNumber = (DropDownList)e.Row.FindControl("txtNewSalesOrderLineNumber");
                if (txtNewSalesOrderLineNumber != null) {
                    try {
                        dbo_FactInternetSalesReason_dbo_FactInternetSalesList = dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass263.List();
                        txtNewSalesOrderLineNumber.DataSource = dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
                        txtNewSalesOrderLineNumber.DataValueField = "SalesOrderLineNumber";
                        txtNewSalesOrderLineNumber.DataTextField = "ProductKey";
                        txtNewSalesOrderLineNumber.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSalesReason_dbo_DimSalesReasonComboBox264(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264> dbo_FactInternetSalesReason_dbo_DimSalesReasonList = new  List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesReasonKey = (DropDownList)e.Row.FindControl("txtSalesReasonKey");
                if (txtSalesReasonKey != null) {
                    try {
                        dbo_FactInternetSalesReason_dbo_DimSalesReasonList = dbo_FactInternetSalesReason_dbo_DimSalesReasonDataClass264.List();
                        txtSalesReasonKey.DataSource = dbo_FactInternetSalesReason_dbo_DimSalesReasonList;
                        txtSalesReasonKey.DataValueField = "SalesReasonKey";
                        txtSalesReasonKey.DataTextField = "SalesReasonName";
                        txtSalesReasonKey.DataBind();
                        txtSalesReasonKey.SelectedValue = Convert.ToString(Session["SalesReasonKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesReasonKey = (DropDownList)e.Row.FindControl("txtNewSalesReasonKey");
                if (txtNewSalesReasonKey != null) {
                    try {
                        dbo_FactInternetSalesReason_dbo_DimSalesReasonList = dbo_FactInternetSalesReason_dbo_DimSalesReasonDataClass264.List();
                        txtNewSalesReasonKey.DataSource = dbo_FactInternetSalesReason_dbo_DimSalesReasonList;
                        txtNewSalesReasonKey.DataValueField = "SalesReasonKey";
                        txtNewSalesReasonKey.DataTextField = "SalesReasonName";
                        txtNewSalesReasonKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactInternetSalesReason()
        {
            try {
                if ((Session["dvdbo_FactInternetSalesReason"] != null)) {
                    dvdbo_FactInternetSalesReason = (DataView)Session["dvdbo_FactInternetSalesReason"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactInternetSalesReason"] = dvdbo_FactInternetSalesReason;
                }
                if (dvdbo_FactInternetSalesReason.Count > 0) {
                    grddbo_FactInternetSalesReason.DataSource = dvdbo_FactInternetSalesReason;
                    grddbo_FactInternetSalesReason.DataBind();
                }
                if (dvdbo_FactInternetSalesReason.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductKey", Type.GetType("System.String"));
                    dt.Columns.Add("ProductKey", Type.GetType("System.Byte"));
                    dt.Columns.Add("SalesReasonName", Type.GetType("System.Int32"));
                    dvdbo_FactInternetSalesReason = dt.DefaultView;
                    Session["dvdbo_FactInternetSalesReason"] = dvdbo_FactInternetSalesReason;

                    grddbo_FactInternetSalesReason.DataSource = dvdbo_FactInternetSalesReason;
                    grddbo_FactInternetSalesReason.DataBind();

                    int TotalColumns = grddbo_FactInternetSalesReason.Rows[0].Cells.Count;
                    grddbo_FactInternetSalesReason.Rows[0].Cells.Clear();
                    grddbo_FactInternetSalesReason.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactInternetSalesReason.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactInternetSalesReason.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactInternetSalesReason.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
            }
        }

        protected void grddbo_FactInternetSalesReason_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox262(e);
            Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox263(e);
            Loaddbo_FactInternetSalesReason_dbo_DimSalesReasonComboBox264(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesOrderNumber = (DropDownList)e.Row.FindControl("txtSalesOrderNumber");
                if (txtSalesOrderNumber != null) {
                    txtSalesOrderNumber.Enabled = false;
                }
                DropDownList txtSalesOrderLineNumber = (DropDownList)e.Row.FindControl("txtSalesOrderLineNumber");
                if (txtSalesOrderLineNumber != null) {
                    txtSalesOrderLineNumber.Enabled = false;
                }
                DropDownList txtSalesReasonKey = (DropDownList)e.Row.FindControl("txtSalesReasonKey");
                if (txtSalesReasonKey != null) {
                    txtSalesReasonKey.Enabled = false;
                }
            }
        }

        protected void grddbo_FactInternetSalesReason_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactInternetSalesReason.EditIndex = -1;
            LoadGriddbo_FactInternetSalesReason();
        }

        protected void grddbo_FactInternetSalesReason_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactInternetSalesReason.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactInternetSalesReason_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactInternetSalesReason_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactInternetSalesReason_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactInternetSalesReason_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactInternetSalesReason_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactInternetSalesReason.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactInternetSalesReason();
        }

        protected void grddbo_FactInternetSalesReason_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactInternetSalesReason();
        }

        private void Edit()
        {
            try {
                dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
                Label lblSalesOrderNumber = (Label)grddbo_FactInternetSalesReason.Rows[grddbo_FactInternetSalesReason.EditIndex].FindControl("lblSalesOrderNumber");
                clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(lblSalesOrderNumber.Text);
                Label lblSalesOrderLineNumber = (Label)grddbo_FactInternetSalesReason.Rows[grddbo_FactInternetSalesReason.EditIndex].FindControl("lblSalesOrderLineNumber");
                clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(lblSalesOrderLineNumber.Text);
                Label lblSalesReasonKey = (Label)grddbo_FactInternetSalesReason.Rows[grddbo_FactInternetSalesReason.EditIndex].FindControl("lblSalesReasonKey");
                clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(lblSalesReasonKey.Text);
                clsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(clsdbo_FactInternetSalesReason);

                Session["SalesOrderNumber_SelectedValue"] = clsdbo_FactInternetSalesReason.SalesOrderNumber;
                Session["SalesOrderLineNumber_SelectedValue"] = clsdbo_FactInternetSalesReason.SalesOrderLineNumber;
                Session["SalesReasonKey_SelectedValue"] = clsdbo_FactInternetSalesReason.SalesReasonKey;

                LoadGriddbo_FactInternetSalesReason();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewSalesOrderNumber = (DropDownList)grddbo_FactInternetSalesReason.FooterRow.FindControl("txtNewSalesOrderNumber");
                DropDownList txtNewSalesOrderLineNumber = (DropDownList)grddbo_FactInternetSalesReason.FooterRow.FindControl("txtNewSalesOrderLineNumber");
                DropDownList txtNewSalesReasonKey = (DropDownList)grddbo_FactInternetSalesReason.FooterRow.FindControl("txtNewSalesReasonKey");

                dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(txtNewSalesOrderNumber.SelectedValue);
                    clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(txtNewSalesOrderLineNumber.SelectedValue);
                    clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(txtNewSalesReasonKey.SelectedValue);
                    bool bSucess = false;
                    bSucess = dbo_FactInternetSalesReasonDataClass.Add(clsdbo_FactInternetSalesReason);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactInternetSalesReason");
                        LoadGriddbo_FactInternetSalesReason();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Internet Sales Reason ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                DropDownList txtSalesOrderNumber = (DropDownList)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderNumber");
                DropDownList txtSalesOrderLineNumber = (DropDownList)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderLineNumber");
                DropDownList txtSalesReasonKey = (DropDownList)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonKey");

                dbo_FactInternetSalesReasonClass oclsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
                dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
                oclsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
                oclsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
                oclsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(txtSalesReasonKey.Text);
                oclsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(oclsdbo_FactInternetSalesReason);

                if (VerifyData() == true) {
                    clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.SelectedValue);
                    clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.SelectedValue);
                    clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(txtSalesReasonKey.SelectedValue);
                    bool bSucess = false;
                    bSucess = dbo_FactInternetSalesReasonDataClass.Update(oclsdbo_FactInternetSalesReason, clsdbo_FactInternetSalesReason);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactInternetSalesReason");
                        grddbo_FactInternetSalesReason.EditIndex = -1;
                        LoadGriddbo_FactInternetSalesReason();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Internet Sales Reason ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
            Label lblSalesOrderNumber = (Label)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesOrderNumber");
            clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(lblSalesOrderNumber.Text);
            Label lblSalesOrderLineNumber = (Label)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesOrderLineNumber");
            clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(lblSalesOrderLineNumber.Text);
            Label lblSalesReasonKey = (Label)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesReasonKey");
            clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(lblSalesReasonKey.Text);
            clsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(clsdbo_FactInternetSalesReason);
            bool bSucess = false;
            bSucess = dbo_FactInternetSalesReasonDataClass.Delete(clsdbo_FactInternetSalesReason);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactInternetSalesReason");
                LoadGriddbo_FactInternetSalesReason();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Internet Sales Reason ");
            }
        }

        private Boolean VerifyData()
        {
            DropDownList txtSalesOrderNumber = (DropDownList)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderNumber");
            DropDownList txtSalesOrderLineNumber = (DropDownList)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderLineNumber");
            DropDownList txtSalesReasonKey = (DropDownList)grddbo_FactInternetSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonKey");

            if (txtSalesOrderNumber.Text == "") {
                ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Internet Sales Reason ");
                txtSalesOrderNumber.Focus();
                return false;}
            if (txtSalesOrderLineNumber.Text == "") {
                ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Internet Sales Reason ");
                txtSalesOrderLineNumber.Focus();
                return false;}
            if (txtSalesReasonKey.Text == "") {
                ec.ShowMessage(" Sales Reason Key is Required. ", " Dbo. Fact Internet Sales Reason ");
                txtSalesReasonKey.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewSalesOrderNumber = (DropDownList)grddbo_FactInternetSalesReason.FooterRow.FindControl("txtNewSalesOrderNumber");
            DropDownList txtNewSalesOrderLineNumber = (DropDownList)grddbo_FactInternetSalesReason.FooterRow.FindControl("txtNewSalesOrderLineNumber");
            DropDownList txtNewSalesReasonKey = (DropDownList)grddbo_FactInternetSalesReason.FooterRow.FindControl("txtNewSalesReasonKey");

            if (txtNewSalesOrderNumber.Text == "") {
                ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Internet Sales Reason ");
                txtNewSalesOrderNumber.Focus();
                return false;}
            if (txtNewSalesOrderLineNumber.Text == "") {
                ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Internet Sales Reason ");
                txtNewSalesOrderLineNumber.Focus();
                return false;}
            if (txtNewSalesReasonKey.Text == "") {
                ec.ShowMessage(" Sales Reason Key is Required. ", " Dbo. Fact Internet Sales Reason ");
                txtNewSalesReasonKey.Focus();
                return false;}
            if (
                txtNewSalesOrderNumber.SelectedIndex != -1 
                && txtNewSalesOrderLineNumber.SelectedIndex != -1 
                && txtNewSalesReasonKey.SelectedIndex != -1 
            )  {
                dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
                clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(txtNewSalesOrderNumber.SelectedValue);
                clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(txtNewSalesOrderLineNumber.SelectedValue);
                clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(txtNewSalesReasonKey.SelectedValue);
                clsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(clsdbo_FactInternetSalesReason);
                if (clsdbo_FactInternetSalesReason != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Fact Internet Sales Reason ");
                    txtNewSalesOrderNumber.Focus();
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
		    grddbo_FactInternetSalesReason.PageIndex = 0;
		    grddbo_FactInternetSalesReason.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactInternetSalesReason();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactInternetSalesReason");
		    LoadGriddbo_FactInternetSalesReason();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactInternetSalesReason");
			if ((Session["dvdbo_FactInternetSalesReason"] != null)) {
				dvdbo_FactInternetSalesReason = (DataView)Session["dvdbo_FactInternetSalesReason"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactInternetSalesReason"] = dvdbo_FactInternetSalesReason;
		    	}
                if (dvdbo_FactInternetSalesReason.Count > 0) {
                    grddbo_FactInternetSalesReason.DataSource = dvdbo_FactInternetSalesReason;
                    grddbo_FactInternetSalesReason.DataBind();
                }
                if (dvdbo_FactInternetSalesReason.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductKey", Type.GetType("System.String"));
                    dt.Columns.Add("ProductKey", Type.GetType("System.Byte"));
                    dt.Columns.Add("SalesReasonName", Type.GetType("System.Int32"));
                    dvdbo_FactInternetSalesReason = dt.DefaultView;
                    Session["dvdbo_FactInternetSalesReason"] = dvdbo_FactInternetSalesReason;

                    grddbo_FactInternetSalesReason.DataSource = dvdbo_FactInternetSalesReason;
                    grddbo_FactInternetSalesReason.DataBind();

                    int TotalColumns = grddbo_FactInternetSalesReason.Rows[0].Cells.Count;
                    grddbo_FactInternetSalesReason.Rows[0].Cells.Clear();
                    grddbo_FactInternetSalesReason.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactInternetSalesReason.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactInternetSalesReason.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactInternetSalesReason.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
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
                    { dt = dbo_FactInternetSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactInternetSalesReasonDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Internet Sales Reason", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactInternetSalesReason"];
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
 
