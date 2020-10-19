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
    public partial class frmdbo_FactProductInventory : System.Web.UI.Page
    {

        private dbo_FactProductInventoryDataClass clsdbo_FactProductInventoryData = new dbo_FactProductInventoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactProductInventory;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ProductKey_SelectedValue"] = "";
                Session["DateKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactProductInventory");
                Session.Remove("Row");

                cmbFields.Items.Add("Product Key");
                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Movement Date");
                cmbFields.Items.Add("Unit Cost");
                cmbFields.Items.Add("Units In");
                cmbFields.Items.Add("Units Out");
                cmbFields.Items.Add("Units Balance");

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

                LoadGriddbo_FactProductInventory();
            }
        }

        private void Loaddbo_FactProductInventory_dbo_DimProductComboBox265(GridViewRowEventArgs e)
        {
            List<dbo_FactProductInventory_dbo_DimProductClass265> dbo_FactProductInventory_dbo_DimProductList = new  List<dbo_FactProductInventory_dbo_DimProductClass265>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtProductKey = (DropDownList)e.Row.FindControl("txtProductKey");
                if (txtProductKey != null) {
                    try {
                        dbo_FactProductInventory_dbo_DimProductList = dbo_FactProductInventory_dbo_DimProductDataClass265.List();
                        txtProductKey.DataSource = dbo_FactProductInventory_dbo_DimProductList;
                        txtProductKey.DataValueField = "ProductKey";
                        txtProductKey.DataTextField = "ProductAlternateKey";
                        txtProductKey.DataBind();
                        txtProductKey.SelectedValue = Convert.ToString(Session["ProductKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewProductKey = (DropDownList)e.Row.FindControl("txtNewProductKey");
                if (txtNewProductKey != null) {
                    try {
                        dbo_FactProductInventory_dbo_DimProductList = dbo_FactProductInventory_dbo_DimProductDataClass265.List();
                        txtNewProductKey.DataSource = dbo_FactProductInventory_dbo_DimProductList;
                        txtNewProductKey.DataValueField = "ProductKey";
                        txtNewProductKey.DataTextField = "ProductAlternateKey";
                        txtNewProductKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
                    }
                }
            }
        }

        private void Loaddbo_FactProductInventory_dbo_DimDateComboBox266(GridViewRowEventArgs e)
        {
            List<dbo_FactProductInventory_dbo_DimDateClass266> dbo_FactProductInventory_dbo_DimDateList = new  List<dbo_FactProductInventory_dbo_DimDateClass266>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    try {
                        dbo_FactProductInventory_dbo_DimDateList = dbo_FactProductInventory_dbo_DimDateDataClass266.List();
                        txtDateKey.DataSource = dbo_FactProductInventory_dbo_DimDateList;
                        txtDateKey.DataValueField = "DateKey";
                        txtDateKey.DataTextField = "EnglishDayNameOfWeek";
                        txtDateKey.DataBind();
                        txtDateKey.SelectedValue = Convert.ToString(Session["DateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDateKey = (DropDownList)e.Row.FindControl("txtNewDateKey");
                if (txtNewDateKey != null) {
                    try {
                        dbo_FactProductInventory_dbo_DimDateList = dbo_FactProductInventory_dbo_DimDateDataClass266.List();
                        txtNewDateKey.DataSource = dbo_FactProductInventory_dbo_DimDateList;
                        txtNewDateKey.DataValueField = "DateKey";
                        txtNewDateKey.DataTextField = "EnglishDayNameOfWeek";
                        txtNewDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactProductInventory()
        {
            try {
                if ((Session["dvdbo_FactProductInventory"] != null)) {
                    dvdbo_FactProductInventory = (DataView)Session["dvdbo_FactProductInventory"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactProductInventory = dbo_FactProductInventoryDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactProductInventory"] = dvdbo_FactProductInventory;
                }
                if (dvdbo_FactProductInventory.Count > 0) {
                    grddbo_FactProductInventory.DataSource = dvdbo_FactProductInventory;
                    grddbo_FactProductInventory.DataBind();
                }
                if (dvdbo_FactProductInventory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishDayNameOfWeek", Type.GetType("System.Int32"));
                    dt.Columns.Add("MovementDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("UnitCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("UnitsIn", Type.GetType("System.Int32"));
                    dt.Columns.Add("UnitsOut", Type.GetType("System.Int32"));
                    dt.Columns.Add("UnitsBalance", Type.GetType("System.Int32"));
                    dvdbo_FactProductInventory = dt.DefaultView;
                    Session["dvdbo_FactProductInventory"] = dvdbo_FactProductInventory;

                    grddbo_FactProductInventory.DataSource = dvdbo_FactProductInventory;
                    grddbo_FactProductInventory.DataBind();

                    int TotalColumns = grddbo_FactProductInventory.Rows[0].Cells.Count;
                    grddbo_FactProductInventory.Rows[0].Cells.Clear();
                    grddbo_FactProductInventory.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactProductInventory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactProductInventory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactProductInventory.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
            }
        }

        protected void grddbo_FactProductInventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactProductInventory_dbo_DimProductComboBox265(e);
            Loaddbo_FactProductInventory_dbo_DimDateComboBox266(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtProductKey = (DropDownList)e.Row.FindControl("txtProductKey");
                if (txtProductKey != null) {
                    txtProductKey.Enabled = false;
                }
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    txtDateKey.Enabled = false;
                }
            }
        }

        protected void grddbo_FactProductInventory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactProductInventory.EditIndex = -1;
            LoadGriddbo_FactProductInventory();
        }

        protected void grddbo_FactProductInventory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactProductInventory.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactProductInventory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactProductInventory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactProductInventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactProductInventory_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactProductInventory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactProductInventory.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactProductInventory();
        }

        protected void grddbo_FactProductInventory_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactProductInventory();
        }

        private void Edit()
        {
            try {
                dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
                Label lblProductKey = (Label)grddbo_FactProductInventory.Rows[grddbo_FactProductInventory.EditIndex].FindControl("lblProductKey");
                clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(lblProductKey.Text);
                Label lblDateKey = (Label)grddbo_FactProductInventory.Rows[grddbo_FactProductInventory.EditIndex].FindControl("lblDateKey");
                clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(lblDateKey.Text);
                clsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(clsdbo_FactProductInventory);

                Session["ProductKey_SelectedValue"] = clsdbo_FactProductInventory.ProductKey;
                Session["DateKey_SelectedValue"] = clsdbo_FactProductInventory.DateKey;

                LoadGriddbo_FactProductInventory();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewProductKey = (DropDownList)grddbo_FactProductInventory.FooterRow.FindControl("txtNewProductKey");
                DropDownList txtNewDateKey = (DropDownList)grddbo_FactProductInventory.FooterRow.FindControl("txtNewDateKey");
                TextBox txtNewMovementDate = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewMovementDate");
                TextBox txtNewUnitCost = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitCost");
                TextBox txtNewUnitsIn = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitsIn");
                TextBox txtNewUnitsOut = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitsOut");
                TextBox txtNewUnitsBalance = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitsBalance");

                dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(txtNewProductKey.SelectedValue);
                    clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                    clsdbo_FactProductInventory.MovementDate = System.Convert.ToDateTime(txtNewMovementDate.Text);
                    clsdbo_FactProductInventory.UnitCost = System.Convert.ToDecimal(txtNewUnitCost.Text);
                    clsdbo_FactProductInventory.UnitsIn = System.Convert.ToInt32(txtNewUnitsIn.Text);
                    clsdbo_FactProductInventory.UnitsOut = System.Convert.ToInt32(txtNewUnitsOut.Text);
                    clsdbo_FactProductInventory.UnitsBalance = System.Convert.ToInt32(txtNewUnitsBalance.Text);
                    bool bSucess = false;
                    bSucess = dbo_FactProductInventoryDataClass.Add(clsdbo_FactProductInventory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactProductInventory");
                        LoadGriddbo_FactProductInventory();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Product Inventory ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                DropDownList txtProductKey = (DropDownList)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
                DropDownList txtDateKey = (DropDownList)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                TextBox txtMovementDate = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMovementDate");
                TextBox txtUnitCost = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitCost");
                TextBox txtUnitsIn = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitsIn");
                TextBox txtUnitsOut = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitsOut");
                TextBox txtUnitsBalance = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitsBalance");

                dbo_FactProductInventoryClass oclsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
                dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
                oclsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(txtProductKey.Text);
                oclsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(txtDateKey.Text);
                oclsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(oclsdbo_FactProductInventory);

                if (VerifyData() == true) {
                    clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
                    clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
                    clsdbo_FactProductInventory.MovementDate = System.Convert.ToDateTime(txtMovementDate.Text);
                    clsdbo_FactProductInventory.UnitCost = System.Convert.ToDecimal(txtUnitCost.Text);
                    clsdbo_FactProductInventory.UnitsIn = System.Convert.ToInt32(txtUnitsIn.Text);
                    clsdbo_FactProductInventory.UnitsOut = System.Convert.ToInt32(txtUnitsOut.Text);
                    clsdbo_FactProductInventory.UnitsBalance = System.Convert.ToInt32(txtUnitsBalance.Text);
                    bool bSucess = false;
                    bSucess = dbo_FactProductInventoryDataClass.Update(oclsdbo_FactProductInventory, clsdbo_FactProductInventory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactProductInventory");
                        grddbo_FactProductInventory.EditIndex = -1;
                        LoadGriddbo_FactProductInventory();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Product Inventory ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
            Label lblProductKey = (Label)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblProductKey");
            clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(lblProductKey.Text);
            Label lblDateKey = (Label)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblDateKey");
            clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(lblDateKey.Text);
            clsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(clsdbo_FactProductInventory);
            bool bSucess = false;
            bSucess = dbo_FactProductInventoryDataClass.Delete(clsdbo_FactProductInventory);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactProductInventory");
                LoadGriddbo_FactProductInventory();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Product Inventory ");
            }
        }

        private Boolean VerifyData()
        {
            DropDownList txtProductKey = (DropDownList)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
            DropDownList txtDateKey = (DropDownList)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            TextBox txtMovementDate = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMovementDate");
            TextBox txtUnitCost = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitCost");
            TextBox txtUnitsIn = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitsIn");
            TextBox txtUnitsOut = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitsOut");
            TextBox txtUnitsBalance = (TextBox)grddbo_FactProductInventory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitsBalance");

            if (txtProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Product Inventory ");
                txtProductKey.Focus();
                return false;}
            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Product Inventory ");
                txtDateKey.Focus();
                return false;}
            
            if (txtUnitCost.Text == "") {
                ec.ShowMessage(" Unit Cost is Required. ", " Dbo. Fact Product Inventory ");
                txtUnitCost.Focus();
                return false;}
            if (txtUnitsIn.Text == "") {
                ec.ShowMessage(" Units In is Required. ", " Dbo. Fact Product Inventory ");
                txtUnitsIn.Focus();
                return false;}
            if (txtUnitsOut.Text == "") {
                ec.ShowMessage(" Units Out is Required. ", " Dbo. Fact Product Inventory ");
                txtUnitsOut.Focus();
                return false;}
            if (txtUnitsBalance.Text == "") {
                ec.ShowMessage(" Units Balance is Required. ", " Dbo. Fact Product Inventory ");
                txtUnitsBalance.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewProductKey = (DropDownList)grddbo_FactProductInventory.FooterRow.FindControl("txtNewProductKey");
            DropDownList txtNewDateKey = (DropDownList)grddbo_FactProductInventory.FooterRow.FindControl("txtNewDateKey");
            TextBox txtNewMovementDate = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewMovementDate");
            TextBox txtNewUnitCost = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitCost");
            TextBox txtNewUnitsIn = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitsIn");
            TextBox txtNewUnitsOut = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitsOut");
            TextBox txtNewUnitsBalance = (TextBox)grddbo_FactProductInventory.FooterRow.FindControl("txtNewUnitsBalance");

            if (txtNewProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Product Inventory ");
                txtNewProductKey.Focus();
                return false;}
            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Product Inventory ");
                txtNewDateKey.Focus();
                return false;}
            
            if (txtNewUnitCost.Text == "") {
                ec.ShowMessage(" Unit Cost is Required. ", " Dbo. Fact Product Inventory ");
                txtNewUnitCost.Focus();
                return false;}
            if (txtNewUnitsIn.Text == "") {
                ec.ShowMessage(" Units In is Required. ", " Dbo. Fact Product Inventory ");
                txtNewUnitsIn.Focus();
                return false;}
            if (txtNewUnitsOut.Text == "") {
                ec.ShowMessage(" Units Out is Required. ", " Dbo. Fact Product Inventory ");
                txtNewUnitsOut.Focus();
                return false;}
            if (txtNewUnitsBalance.Text == "") {
                ec.ShowMessage(" Units Balance is Required. ", " Dbo. Fact Product Inventory ");
                txtNewUnitsBalance.Focus();
                return false;}
            if (
                txtNewProductKey.SelectedIndex != -1 
                && txtNewDateKey.SelectedIndex != -1 
            )  {
                dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
                clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(txtNewProductKey.SelectedValue);
                clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                clsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(clsdbo_FactProductInventory);
                if (clsdbo_FactProductInventory != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Fact Product Inventory ");
                    txtNewProductKey.Focus();
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
		    grddbo_FactProductInventory.PageIndex = 0;
		    grddbo_FactProductInventory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactProductInventory();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactProductInventory");
		    LoadGriddbo_FactProductInventory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactProductInventory");
			if ((Session["dvdbo_FactProductInventory"] != null)) {
				dvdbo_FactProductInventory = (DataView)Session["dvdbo_FactProductInventory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactProductInventory"] = dvdbo_FactProductInventory;
		    	}
                if (dvdbo_FactProductInventory.Count > 0) {
                    grddbo_FactProductInventory.DataSource = dvdbo_FactProductInventory;
                    grddbo_FactProductInventory.DataBind();
                }
                if (dvdbo_FactProductInventory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishDayNameOfWeek", Type.GetType("System.Int32"));
                    dt.Columns.Add("MovementDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("UnitCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("UnitsIn", Type.GetType("System.Int32"));
                    dt.Columns.Add("UnitsOut", Type.GetType("System.Int32"));
                    dt.Columns.Add("UnitsBalance", Type.GetType("System.Int32"));
                    dvdbo_FactProductInventory = dt.DefaultView;
                    Session["dvdbo_FactProductInventory"] = dvdbo_FactProductInventory;

                    grddbo_FactProductInventory.DataSource = dvdbo_FactProductInventory;
                    grddbo_FactProductInventory.DataBind();

                    int TotalColumns = grddbo_FactProductInventory.Rows[0].Cells.Count;
                    grddbo_FactProductInventory.Rows[0].Cells.Clear();
                    grddbo_FactProductInventory.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactProductInventory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactProductInventory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactProductInventory.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
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
                    { dt = dbo_FactProductInventoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactProductInventoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Product Inventory", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactProductInventory"];
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
 
