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
    public partial class frmdbo_DimProduct : System.Web.UI.Page
    {

        private dbo_DimProductDataClass clsdbo_DimProductData = new dbo_DimProductDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimProduct;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ProductSubcategoryKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimProduct");
                Session.Remove("Row");

                cmbFields.Items.Add("Product Key");
                cmbFields.Items.Add("Product Alternate Key");
                cmbFields.Items.Add("Product Subcategory Key");
                cmbFields.Items.Add("Weight Unit Measure Code");
                cmbFields.Items.Add("Size Unit Measure Code");
                cmbFields.Items.Add("English Product Name");
                cmbFields.Items.Add("Spanish Product Name");
                cmbFields.Items.Add("French Product Name");
                cmbFields.Items.Add("Standard Cost");
                cmbFields.Items.Add("Finished Goods Flag");
                cmbFields.Items.Add("Color");
                cmbFields.Items.Add("Safety Stock Level");
                cmbFields.Items.Add("Reorder Point");
                cmbFields.Items.Add("List Price");
                cmbFields.Items.Add("Size");
                cmbFields.Items.Add("Size Range");
                cmbFields.Items.Add("Weight");
                cmbFields.Items.Add("Days To Manufacture");
                cmbFields.Items.Add("Product Line");
                cmbFields.Items.Add("Dealer Price");
                cmbFields.Items.Add("Class");
                cmbFields.Items.Add("Style");
                cmbFields.Items.Add("Model Name");
                cmbFields.Items.Add("English Description");
                cmbFields.Items.Add("French Description");
                cmbFields.Items.Add("Chinese Description");
                cmbFields.Items.Add("Arabic Description");
                cmbFields.Items.Add("Hebrew Description");
                cmbFields.Items.Add("Thai Description");
                cmbFields.Items.Add("German Description");
                cmbFields.Items.Add("Japanese Description");
                cmbFields.Items.Add("Turkish Description");
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

                LoadGriddbo_DimProduct();
            }
        }

        private void Loaddbo_DimProduct_dbo_DimProductSubcategoryComboBox(GridViewRowEventArgs e)
        {
            List<dbo_DimProduct_dbo_DimProductSubcategoryClass> dbo_DimProduct_dbo_DimProductSubcategoryList = new  List<dbo_DimProduct_dbo_DimProductSubcategoryClass>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtProductSubcategoryKey = (DropDownList)e.Row.FindControl("txtProductSubcategoryKey");
                if (txtProductSubcategoryKey != null) {
                    try {
                        dbo_DimProduct_dbo_DimProductSubcategoryList = dbo_DimProduct_dbo_DimProductSubcategoryDataClass.List();
                        txtProductSubcategoryKey.DataSource = dbo_DimProduct_dbo_DimProductSubcategoryList;
                        txtProductSubcategoryKey.DataValueField = "ProductSubcategoryKey";
                        txtProductSubcategoryKey.DataTextField = "EnglishProductSubcategoryName";
                        txtProductSubcategoryKey.DataBind();
                        txtProductSubcategoryKey.SelectedValue = Convert.ToString(Session["ProductSubcategoryKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewProductSubcategoryKey = (DropDownList)e.Row.FindControl("txtNewProductSubcategoryKey");
                if (txtNewProductSubcategoryKey != null) {
                    try {
                        dbo_DimProduct_dbo_DimProductSubcategoryList = dbo_DimProduct_dbo_DimProductSubcategoryDataClass.List();
                        txtNewProductSubcategoryKey.DataSource = dbo_DimProduct_dbo_DimProductSubcategoryList;
                        txtNewProductSubcategoryKey.DataValueField = "ProductSubcategoryKey";
                        txtNewProductSubcategoryKey.DataTextField = "EnglishProductSubcategoryName";
                        txtNewProductSubcategoryKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimProduct()
        {
            try {
                if ((Session["dvdbo_DimProduct"] != null)) {
                    dvdbo_DimProduct = (DataView)Session["dvdbo_DimProduct"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimProduct = dbo_DimProductDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimProduct"] = dvdbo_DimProduct;
                }
                if (dvdbo_DimProduct.Count > 0) {
                    grddbo_DimProduct.DataSource = dvdbo_DimProduct;
                    grddbo_DimProduct.DataBind();
                }
                if (dvdbo_DimProduct.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishProductSubcategoryName", Type.GetType("System.Int32"));
                    dt.Columns.Add("WeightUnitMeasureCode", Type.GetType("System.String"));
                    dt.Columns.Add("SizeUnitMeasureCode", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishProductName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishProductName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchProductName", Type.GetType("System.String"));
                    dt.Columns.Add("StandardCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("FinishedGoodsFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Color", Type.GetType("System.String"));
                    dt.Columns.Add("SafetyStockLevel", Type.GetType("System.Int16"));
                    dt.Columns.Add("ReorderPoint", Type.GetType("System.Int16"));
                    dt.Columns.Add("ListPrice", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Size", Type.GetType("System.String"));
                    dt.Columns.Add("SizeRange", Type.GetType("System.String"));
                    dt.Columns.Add("Weight", Type.GetType("System.Decimal"));
                    dt.Columns.Add("DaysToManufacture", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductLine", Type.GetType("System.String"));
                    dt.Columns.Add("DealerPrice", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Class", Type.GetType("System.String"));
                    dt.Columns.Add("Style", Type.GetType("System.String"));
                    dt.Columns.Add("ModelName", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishDescription", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchDescription", Type.GetType("System.String"));
                    dt.Columns.Add("ChineseDescription", Type.GetType("System.String"));
                    dt.Columns.Add("ArabicDescription", Type.GetType("System.String"));
                    dt.Columns.Add("HebrewDescription", Type.GetType("System.String"));
                    dt.Columns.Add("ThaiDescription", Type.GetType("System.String"));
                    dt.Columns.Add("GermanDescription", Type.GetType("System.String"));
                    dt.Columns.Add("JapaneseDescription", Type.GetType("System.String"));
                    dt.Columns.Add("TurkishDescription", Type.GetType("System.String"));
                    dt.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("Status", Type.GetType("System.String"));
                    dvdbo_DimProduct = dt.DefaultView;
                    Session["dvdbo_DimProduct"] = dvdbo_DimProduct;

                    grddbo_DimProduct.DataSource = dvdbo_DimProduct;
                    grddbo_DimProduct.DataBind();

                    int TotalColumns = grddbo_DimProduct.Rows[0].Cells.Count;
                    grddbo_DimProduct.Rows[0].Cells.Clear();
                    grddbo_DimProduct.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimProduct.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimProduct.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimProduct.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
            }
        }

        protected void grddbo_DimProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimProduct_dbo_DimProductSubcategoryComboBox(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtProductKey = (TextBox)e.Row.FindControl("txtProductKey");
                if (txtProductKey != null) {
                    txtProductKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewProductKey = (TextBox)e.Row.FindControl("txtNewProductKey");
                if (txtNewProductKey != null) {
                    txtNewProductKey.Enabled = false;
                }
                txtNewProductKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimProduct"));
            }
        }

        protected void grddbo_DimProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimProduct.EditIndex = -1;
            LoadGriddbo_DimProduct();
        }

        protected void grddbo_DimProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimProduct.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimProduct_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimProduct.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimProduct();
        }

        protected void grddbo_DimProduct_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimProduct();
        }

        private void Edit()
        {
            try {
                dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
                Label lblProductKey = (Label)grddbo_DimProduct.Rows[grddbo_DimProduct.EditIndex].FindControl("lblProductKey");
                clsdbo_DimProduct.ProductKey = System.Convert.ToInt32(lblProductKey.Text);
                clsdbo_DimProduct = dbo_DimProductDataClass.Select_Record(clsdbo_DimProduct);

                Session["ProductSubcategoryKey_SelectedValue"] = clsdbo_DimProduct.ProductSubcategoryKey;

                LoadGriddbo_DimProduct();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewProductAlternateKey = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewProductAlternateKey");
                DropDownList txtNewProductSubcategoryKey = (DropDownList)grddbo_DimProduct.FooterRow.FindControl("txtNewProductSubcategoryKey");
                TextBox txtNewWeightUnitMeasureCode = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewWeightUnitMeasureCode");
                TextBox txtNewSizeUnitMeasureCode = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSizeUnitMeasureCode");
                TextBox txtNewEnglishProductName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewEnglishProductName");
                TextBox txtNewSpanishProductName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSpanishProductName");
                TextBox txtNewFrenchProductName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewFrenchProductName");
                TextBox txtNewStandardCost = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStandardCost");
                CheckBox txtNewFinishedGoodsFlag = (CheckBox)grddbo_DimProduct.FooterRow.FindControl("txtNewFinishedGoodsFlag");
                TextBox txtNewColor = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewColor");
                TextBox txtNewSafetyStockLevel = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSafetyStockLevel");
                TextBox txtNewReorderPoint = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewReorderPoint");
                TextBox txtNewListPrice = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewListPrice");
                TextBox txtNewSize = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSize");
                TextBox txtNewSizeRange = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSizeRange");
                TextBox txtNewWeight = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewWeight");
                TextBox txtNewDaysToManufacture = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewDaysToManufacture");
                TextBox txtNewProductLine = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewProductLine");
                TextBox txtNewDealerPrice = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewDealerPrice");
                TextBox txtNewClass = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewClass");
                TextBox txtNewStyle = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStyle");
                TextBox txtNewModelName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewModelName");
                TextBox txtNewEnglishDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewEnglishDescription");
                TextBox txtNewFrenchDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewFrenchDescription");
                TextBox txtNewChineseDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewChineseDescription");
                TextBox txtNewArabicDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewArabicDescription");
                TextBox txtNewHebrewDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewHebrewDescription");
                TextBox txtNewThaiDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewThaiDescription");
                TextBox txtNewGermanDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewGermanDescription");
                TextBox txtNewJapaneseDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewJapaneseDescription");
                TextBox txtNewTurkishDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewTurkishDescription");
                TextBox txtNewStartDate = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStartDate");
                TextBox txtNewEndDate = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewEndDate");
                TextBox txtNewStatus = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStatus");

                dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewProductAlternateKey.Text)) {
                        clsdbo_DimProduct.ProductAlternateKey = null;
                    } else {
                        clsdbo_DimProduct.ProductAlternateKey = txtNewProductAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtNewProductSubcategoryKey.SelectedValue)) {
                        clsdbo_DimProduct.ProductSubcategoryKey = null;
                    } else {
                        clsdbo_DimProduct.ProductSubcategoryKey = System.Convert.ToInt32(txtNewProductSubcategoryKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewWeightUnitMeasureCode.Text)) {
                        clsdbo_DimProduct.WeightUnitMeasureCode = null;
                    } else {
                        clsdbo_DimProduct.WeightUnitMeasureCode = txtNewWeightUnitMeasureCode.Text; }
                    if (string.IsNullOrEmpty(txtNewSizeUnitMeasureCode.Text)) {
                        clsdbo_DimProduct.SizeUnitMeasureCode = null;
                    } else {
                        clsdbo_DimProduct.SizeUnitMeasureCode = txtNewSizeUnitMeasureCode.Text; }
                    clsdbo_DimProduct.EnglishProductName = System.Convert.ToString(txtNewEnglishProductName.Text);
                    clsdbo_DimProduct.SpanishProductName = System.Convert.ToString(txtNewSpanishProductName.Text);
                    clsdbo_DimProduct.FrenchProductName = System.Convert.ToString(txtNewFrenchProductName.Text);
                    if (string.IsNullOrEmpty(txtNewStandardCost.Text)) {
                        clsdbo_DimProduct.StandardCost = null;
                    } else {
                        clsdbo_DimProduct.StandardCost = System.Convert.ToDecimal(txtNewStandardCost.Text); }
                    clsdbo_DimProduct.FinishedGoodsFlag = System.Convert.ToBoolean(txtNewFinishedGoodsFlag.Checked ? true : false);
                    clsdbo_DimProduct.Color = System.Convert.ToString(txtNewColor.Text);
                    if (string.IsNullOrEmpty(txtNewSafetyStockLevel.Text)) {
                        clsdbo_DimProduct.SafetyStockLevel = null;
                    } else {
                        clsdbo_DimProduct.SafetyStockLevel = System.Convert.ToInt16(txtNewSafetyStockLevel.Text); }
                    if (string.IsNullOrEmpty(txtNewReorderPoint.Text)) {
                        clsdbo_DimProduct.ReorderPoint = null;
                    } else {
                        clsdbo_DimProduct.ReorderPoint = System.Convert.ToInt16(txtNewReorderPoint.Text); }
                    if (string.IsNullOrEmpty(txtNewListPrice.Text)) {
                        clsdbo_DimProduct.ListPrice = null;
                    } else {
                        clsdbo_DimProduct.ListPrice = System.Convert.ToDecimal(txtNewListPrice.Text); }
                    if (string.IsNullOrEmpty(txtNewSize.Text)) {
                        clsdbo_DimProduct.Size = null;
                    } else {
                        clsdbo_DimProduct.Size = txtNewSize.Text; }
                    if (string.IsNullOrEmpty(txtNewSizeRange.Text)) {
                        clsdbo_DimProduct.SizeRange = null;
                    } else {
                        clsdbo_DimProduct.SizeRange = txtNewSizeRange.Text; }
                    if (string.IsNullOrEmpty(txtNewWeight.Text)) {
                        clsdbo_DimProduct.Weight = null;
                    } else {
                        clsdbo_DimProduct.Weight = System.Convert.ToDecimal(txtNewWeight.Text); }
                    if (string.IsNullOrEmpty(txtNewDaysToManufacture.Text)) {
                        clsdbo_DimProduct.DaysToManufacture = null;
                    } else {
                        clsdbo_DimProduct.DaysToManufacture = System.Convert.ToInt32(txtNewDaysToManufacture.Text); }
                    if (string.IsNullOrEmpty(txtNewProductLine.Text)) {
                        clsdbo_DimProduct.ProductLine = null;
                    } else {
                        clsdbo_DimProduct.ProductLine = txtNewProductLine.Text; }
                    if (string.IsNullOrEmpty(txtNewDealerPrice.Text)) {
                        clsdbo_DimProduct.DealerPrice = null;
                    } else {
                        clsdbo_DimProduct.DealerPrice = System.Convert.ToDecimal(txtNewDealerPrice.Text); }
                    if (string.IsNullOrEmpty(txtNewClass.Text)) {
                        clsdbo_DimProduct.Class = null;
                    } else {
                        clsdbo_DimProduct.Class = txtNewClass.Text; }
                    if (string.IsNullOrEmpty(txtNewStyle.Text)) {
                        clsdbo_DimProduct.Style = null;
                    } else {
                        clsdbo_DimProduct.Style = txtNewStyle.Text; }
                    if (string.IsNullOrEmpty(txtNewModelName.Text)) {
                        clsdbo_DimProduct.ModelName = null;
                    } else {
                        clsdbo_DimProduct.ModelName = txtNewModelName.Text; }
                    if (string.IsNullOrEmpty(txtNewEnglishDescription.Text)) {
                        clsdbo_DimProduct.EnglishDescription = null;
                    } else {
                        clsdbo_DimProduct.EnglishDescription = txtNewEnglishDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchDescription.Text)) {
                        clsdbo_DimProduct.FrenchDescription = null;
                    } else {
                        clsdbo_DimProduct.FrenchDescription = txtNewFrenchDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewChineseDescription.Text)) {
                        clsdbo_DimProduct.ChineseDescription = null;
                    } else {
                        clsdbo_DimProduct.ChineseDescription = txtNewChineseDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewArabicDescription.Text)) {
                        clsdbo_DimProduct.ArabicDescription = null;
                    } else {
                        clsdbo_DimProduct.ArabicDescription = txtNewArabicDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewHebrewDescription.Text)) {
                        clsdbo_DimProduct.HebrewDescription = null;
                    } else {
                        clsdbo_DimProduct.HebrewDescription = txtNewHebrewDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewThaiDescription.Text)) {
                        clsdbo_DimProduct.ThaiDescription = null;
                    } else {
                        clsdbo_DimProduct.ThaiDescription = txtNewThaiDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewGermanDescription.Text)) {
                        clsdbo_DimProduct.GermanDescription = null;
                    } else {
                        clsdbo_DimProduct.GermanDescription = txtNewGermanDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewJapaneseDescription.Text)) {
                        clsdbo_DimProduct.JapaneseDescription = null;
                    } else {
                        clsdbo_DimProduct.JapaneseDescription = txtNewJapaneseDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewTurkishDescription.Text)) {
                        clsdbo_DimProduct.TurkishDescription = null;
                    } else {
                        clsdbo_DimProduct.TurkishDescription = txtNewTurkishDescription.Text; }
                    if (string.IsNullOrEmpty(txtNewStartDate.Text)) {
                        clsdbo_DimProduct.StartDate = null;
                    } else {
                        clsdbo_DimProduct.StartDate = System.Convert.ToDateTime(txtNewStartDate.Text); }
                    if (string.IsNullOrEmpty(txtNewEndDate.Text)) {
                        clsdbo_DimProduct.EndDate = null;
                    } else {
                        clsdbo_DimProduct.EndDate = System.Convert.ToDateTime(txtNewEndDate.Text); }
                    if (string.IsNullOrEmpty(txtNewStatus.Text)) {
                        clsdbo_DimProduct.Status = null;
                    } else {
                        clsdbo_DimProduct.Status = txtNewStatus.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimProductDataClass.Add(clsdbo_DimProduct);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimProduct");
                        LoadGriddbo_DimProduct();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Product ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtProductKey = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
                TextBox txtProductAlternateKey = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductAlternateKey");
                DropDownList txtProductSubcategoryKey = (DropDownList)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryKey");
                TextBox txtWeightUnitMeasureCode = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWeightUnitMeasureCode");
                TextBox txtSizeUnitMeasureCode = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSizeUnitMeasureCode");
                TextBox txtEnglishProductName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductName");
                TextBox txtSpanishProductName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishProductName");
                TextBox txtFrenchProductName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchProductName");
                TextBox txtStandardCost = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStandardCost");
                CheckBox txtFinishedGoodsFlag = (CheckBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFinishedGoodsFlag");
                TextBox txtColor = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtColor");
                TextBox txtSafetyStockLevel = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSafetyStockLevel");
                TextBox txtReorderPoint = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtReorderPoint");
                TextBox txtListPrice = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtListPrice");
                TextBox txtSize = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSize");
                TextBox txtSizeRange = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSizeRange");
                TextBox txtWeight = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWeight");
                TextBox txtDaysToManufacture = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDaysToManufacture");
                TextBox txtProductLine = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductLine");
                TextBox txtDealerPrice = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDealerPrice");
                TextBox txtClass = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtClass");
                TextBox txtStyle = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStyle");
                TextBox txtModelName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtModelName");
                TextBox txtEnglishDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishDescription");
                TextBox txtFrenchDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchDescription");
                TextBox txtChineseDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtChineseDescription");
                TextBox txtArabicDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtArabicDescription");
                TextBox txtHebrewDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHebrewDescription");
                TextBox txtThaiDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtThaiDescription");
                TextBox txtGermanDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGermanDescription");
                TextBox txtJapaneseDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtJapaneseDescription");
                TextBox txtTurkishDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTurkishDescription");
                TextBox txtStartDate = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStartDate");
                TextBox txtEndDate = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndDate");
                TextBox txtStatus = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStatus");

                dbo_DimProductClass oclsdbo_DimProduct = new dbo_DimProductClass();
                dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
                oclsdbo_DimProduct.ProductKey = System.Convert.ToInt32(txtProductKey.Text);
                oclsdbo_DimProduct = dbo_DimProductDataClass.Select_Record(oclsdbo_DimProduct);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtProductAlternateKey.Text)) {
                        clsdbo_DimProduct.ProductAlternateKey = null;
                    } else {
                        clsdbo_DimProduct.ProductAlternateKey = txtProductAlternateKey.Text; }
                    if (string.IsNullOrEmpty(txtProductSubcategoryKey.SelectedValue)) {
                        clsdbo_DimProduct.ProductSubcategoryKey = null;
                    } else {
                        clsdbo_DimProduct.ProductSubcategoryKey = System.Convert.ToInt32(txtProductSubcategoryKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtWeightUnitMeasureCode.Text)) {
                        clsdbo_DimProduct.WeightUnitMeasureCode = null;
                    } else {
                        clsdbo_DimProduct.WeightUnitMeasureCode = txtWeightUnitMeasureCode.Text; }
                    if (string.IsNullOrEmpty(txtSizeUnitMeasureCode.Text)) {
                        clsdbo_DimProduct.SizeUnitMeasureCode = null;
                    } else {
                        clsdbo_DimProduct.SizeUnitMeasureCode = txtSizeUnitMeasureCode.Text; }
                    clsdbo_DimProduct.EnglishProductName = System.Convert.ToString(txtEnglishProductName.Text);
                    clsdbo_DimProduct.SpanishProductName = System.Convert.ToString(txtSpanishProductName.Text);
                    clsdbo_DimProduct.FrenchProductName = System.Convert.ToString(txtFrenchProductName.Text);
                    if (string.IsNullOrEmpty(txtStandardCost.Text)) {
                        clsdbo_DimProduct.StandardCost = null;
                    } else {
                        clsdbo_DimProduct.StandardCost = System.Convert.ToDecimal(txtStandardCost.Text); }
                    clsdbo_DimProduct.FinishedGoodsFlag = System.Convert.ToBoolean(txtFinishedGoodsFlag.Checked ? true : false);
                    clsdbo_DimProduct.Color = System.Convert.ToString(txtColor.Text);
                    if (string.IsNullOrEmpty(txtSafetyStockLevel.Text)) {
                        clsdbo_DimProduct.SafetyStockLevel = null;
                    } else {
                        clsdbo_DimProduct.SafetyStockLevel = System.Convert.ToInt16(txtSafetyStockLevel.Text); }
                    if (string.IsNullOrEmpty(txtReorderPoint.Text)) {
                        clsdbo_DimProduct.ReorderPoint = null;
                    } else {
                        clsdbo_DimProduct.ReorderPoint = System.Convert.ToInt16(txtReorderPoint.Text); }
                    if (string.IsNullOrEmpty(txtListPrice.Text)) {
                        clsdbo_DimProduct.ListPrice = null;
                    } else {
                        clsdbo_DimProduct.ListPrice = System.Convert.ToDecimal(txtListPrice.Text); }
                    if (string.IsNullOrEmpty(txtSize.Text)) {
                        clsdbo_DimProduct.Size = null;
                    } else {
                        clsdbo_DimProduct.Size = txtSize.Text; }
                    if (string.IsNullOrEmpty(txtSizeRange.Text)) {
                        clsdbo_DimProduct.SizeRange = null;
                    } else {
                        clsdbo_DimProduct.SizeRange = txtSizeRange.Text; }
                    if (string.IsNullOrEmpty(txtWeight.Text)) {
                        clsdbo_DimProduct.Weight = null;
                    } else {
                        clsdbo_DimProduct.Weight = System.Convert.ToDecimal(txtWeight.Text); }
                    if (string.IsNullOrEmpty(txtDaysToManufacture.Text)) {
                        clsdbo_DimProduct.DaysToManufacture = null;
                    } else {
                        clsdbo_DimProduct.DaysToManufacture = System.Convert.ToInt32(txtDaysToManufacture.Text); }
                    if (string.IsNullOrEmpty(txtProductLine.Text)) {
                        clsdbo_DimProduct.ProductLine = null;
                    } else {
                        clsdbo_DimProduct.ProductLine = txtProductLine.Text; }
                    if (string.IsNullOrEmpty(txtDealerPrice.Text)) {
                        clsdbo_DimProduct.DealerPrice = null;
                    } else {
                        clsdbo_DimProduct.DealerPrice = System.Convert.ToDecimal(txtDealerPrice.Text); }
                    if (string.IsNullOrEmpty(txtClass.Text)) {
                        clsdbo_DimProduct.Class = null;
                    } else {
                        clsdbo_DimProduct.Class = txtClass.Text; }
                    if (string.IsNullOrEmpty(txtStyle.Text)) {
                        clsdbo_DimProduct.Style = null;
                    } else {
                        clsdbo_DimProduct.Style = txtStyle.Text; }
                    if (string.IsNullOrEmpty(txtModelName.Text)) {
                        clsdbo_DimProduct.ModelName = null;
                    } else {
                        clsdbo_DimProduct.ModelName = txtModelName.Text; }
                    if (string.IsNullOrEmpty(txtEnglishDescription.Text)) {
                        clsdbo_DimProduct.EnglishDescription = null;
                    } else {
                        clsdbo_DimProduct.EnglishDescription = txtEnglishDescription.Text; }
                    if (string.IsNullOrEmpty(txtFrenchDescription.Text)) {
                        clsdbo_DimProduct.FrenchDescription = null;
                    } else {
                        clsdbo_DimProduct.FrenchDescription = txtFrenchDescription.Text; }
                    if (string.IsNullOrEmpty(txtChineseDescription.Text)) {
                        clsdbo_DimProduct.ChineseDescription = null;
                    } else {
                        clsdbo_DimProduct.ChineseDescription = txtChineseDescription.Text; }
                    if (string.IsNullOrEmpty(txtArabicDescription.Text)) {
                        clsdbo_DimProduct.ArabicDescription = null;
                    } else {
                        clsdbo_DimProduct.ArabicDescription = txtArabicDescription.Text; }
                    if (string.IsNullOrEmpty(txtHebrewDescription.Text)) {
                        clsdbo_DimProduct.HebrewDescription = null;
                    } else {
                        clsdbo_DimProduct.HebrewDescription = txtHebrewDescription.Text; }
                    if (string.IsNullOrEmpty(txtThaiDescription.Text)) {
                        clsdbo_DimProduct.ThaiDescription = null;
                    } else {
                        clsdbo_DimProduct.ThaiDescription = txtThaiDescription.Text; }
                    if (string.IsNullOrEmpty(txtGermanDescription.Text)) {
                        clsdbo_DimProduct.GermanDescription = null;
                    } else {
                        clsdbo_DimProduct.GermanDescription = txtGermanDescription.Text; }
                    if (string.IsNullOrEmpty(txtJapaneseDescription.Text)) {
                        clsdbo_DimProduct.JapaneseDescription = null;
                    } else {
                        clsdbo_DimProduct.JapaneseDescription = txtJapaneseDescription.Text; }
                    if (string.IsNullOrEmpty(txtTurkishDescription.Text)) {
                        clsdbo_DimProduct.TurkishDescription = null;
                    } else {
                        clsdbo_DimProduct.TurkishDescription = txtTurkishDescription.Text; }
                    if (string.IsNullOrEmpty(txtStartDate.Text)) {
                        clsdbo_DimProduct.StartDate = null;
                    } else {
                        clsdbo_DimProduct.StartDate = System.Convert.ToDateTime(txtStartDate.Text); }
                    if (string.IsNullOrEmpty(txtEndDate.Text)) {
                        clsdbo_DimProduct.EndDate = null;
                    } else {
                        clsdbo_DimProduct.EndDate = System.Convert.ToDateTime(txtEndDate.Text); }
                    if (string.IsNullOrEmpty(txtStatus.Text)) {
                        clsdbo_DimProduct.Status = null;
                    } else {
                        clsdbo_DimProduct.Status = txtStatus.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimProductDataClass.Update(oclsdbo_DimProduct, clsdbo_DimProduct);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimProduct");
                        grddbo_DimProduct.EditIndex = -1;
                        LoadGriddbo_DimProduct();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Product ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
            Label lblProductKey = (Label)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblProductKey");
            clsdbo_DimProduct.ProductKey = System.Convert.ToInt32(lblProductKey.Text);
            clsdbo_DimProduct = dbo_DimProductDataClass.Select_Record(clsdbo_DimProduct);
            bool bSucess = false;
            bSucess = dbo_DimProductDataClass.Delete(clsdbo_DimProduct);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimProduct");
                LoadGriddbo_DimProduct();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Product ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtProductKey = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
            TextBox txtProductAlternateKey = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductAlternateKey");
            DropDownList txtProductSubcategoryKey = (DropDownList)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryKey");
            TextBox txtWeightUnitMeasureCode = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWeightUnitMeasureCode");
            TextBox txtSizeUnitMeasureCode = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSizeUnitMeasureCode");
            TextBox txtEnglishProductName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductName");
            TextBox txtSpanishProductName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishProductName");
            TextBox txtFrenchProductName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchProductName");
            TextBox txtStandardCost = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStandardCost");
            CheckBox txtFinishedGoodsFlag = (CheckBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFinishedGoodsFlag");
            TextBox txtColor = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtColor");
            TextBox txtSafetyStockLevel = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSafetyStockLevel");
            TextBox txtReorderPoint = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtReorderPoint");
            TextBox txtListPrice = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtListPrice");
            TextBox txtSize = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSize");
            TextBox txtSizeRange = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSizeRange");
            TextBox txtWeight = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWeight");
            TextBox txtDaysToManufacture = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDaysToManufacture");
            TextBox txtProductLine = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductLine");
            TextBox txtDealerPrice = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDealerPrice");
            TextBox txtClass = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtClass");
            TextBox txtStyle = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStyle");
            TextBox txtModelName = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtModelName");
            TextBox txtEnglishDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishDescription");
            TextBox txtFrenchDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchDescription");
            TextBox txtChineseDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtChineseDescription");
            TextBox txtArabicDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtArabicDescription");
            TextBox txtHebrewDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtHebrewDescription");
            TextBox txtThaiDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtThaiDescription");
            TextBox txtGermanDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGermanDescription");
            TextBox txtJapaneseDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtJapaneseDescription");
            TextBox txtTurkishDescription = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTurkishDescription");
            TextBox txtStartDate = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStartDate");
            TextBox txtEndDate = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndDate");
            TextBox txtStatus = (TextBox)grddbo_DimProduct.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStatus");

            if (txtEnglishProductName.Text == "") {
                ec.ShowMessage(" English Product Name is Required. ", " Dbo. Dim Product ");
                txtEnglishProductName.Focus();
                return false;}
            if (txtSpanishProductName.Text == "") {
                ec.ShowMessage(" Spanish Product Name is Required. ", " Dbo. Dim Product ");
                txtSpanishProductName.Focus();
                return false;}
            if (txtFrenchProductName.Text == "") {
                ec.ShowMessage(" French Product Name is Required. ", " Dbo. Dim Product ");
                txtFrenchProductName.Focus();
                return false;}
            
            if (txtColor.Text == "") {
                ec.ShowMessage(" Color is Required. ", " Dbo. Dim Product ");
                txtColor.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewProductAlternateKey = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewProductAlternateKey");
            DropDownList txtNewProductSubcategoryKey = (DropDownList)grddbo_DimProduct.FooterRow.FindControl("txtNewProductSubcategoryKey");
            TextBox txtNewWeightUnitMeasureCode = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewWeightUnitMeasureCode");
            TextBox txtNewSizeUnitMeasureCode = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSizeUnitMeasureCode");
            TextBox txtNewEnglishProductName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewEnglishProductName");
            TextBox txtNewSpanishProductName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSpanishProductName");
            TextBox txtNewFrenchProductName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewFrenchProductName");
            TextBox txtNewStandardCost = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStandardCost");
            CheckBox txtNewFinishedGoodsFlag = (CheckBox)grddbo_DimProduct.FooterRow.FindControl("txtNewFinishedGoodsFlag");

            TextBox txtNewColor = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewColor");
            TextBox txtNewSafetyStockLevel = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSafetyStockLevel");
            TextBox txtNewReorderPoint = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewReorderPoint");
            TextBox txtNewListPrice = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewListPrice");
            TextBox txtNewSize = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSize");
            TextBox txtNewSizeRange = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewSizeRange");
            TextBox txtNewWeight = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewWeight");
            TextBox txtNewDaysToManufacture = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewDaysToManufacture");
            TextBox txtNewProductLine = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewProductLine");
            TextBox txtNewDealerPrice = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewDealerPrice");
            TextBox txtNewClass = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewClass");
            TextBox txtNewStyle = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStyle");
            TextBox txtNewModelName = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewModelName");
            TextBox txtNewEnglishDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewEnglishDescription");
            TextBox txtNewFrenchDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewFrenchDescription");
            TextBox txtNewChineseDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewChineseDescription");
            TextBox txtNewArabicDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewArabicDescription");
            TextBox txtNewHebrewDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewHebrewDescription");
            TextBox txtNewThaiDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewThaiDescription");
            TextBox txtNewGermanDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewGermanDescription");
            TextBox txtNewJapaneseDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewJapaneseDescription");
            TextBox txtNewTurkishDescription = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewTurkishDescription");
            TextBox txtNewStartDate = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStartDate");
            TextBox txtNewEndDate = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewEndDate");
            TextBox txtNewStatus = (TextBox)grddbo_DimProduct.FooterRow.FindControl("txtNewStatus");

            if (txtNewEnglishProductName.Text == "") {
                ec.ShowMessage(" English Product Name is Required. ", " Dbo. Dim Product ");
                txtNewEnglishProductName.Focus();
                return false;}
            if (txtNewSpanishProductName.Text == "") {
                ec.ShowMessage(" Spanish Product Name is Required. ", " Dbo. Dim Product ");
                txtNewSpanishProductName.Focus();
                return false;}
            if (txtNewFrenchProductName.Text == "") {
                ec.ShowMessage(" French Product Name is Required. ", " Dbo. Dim Product ");
                txtNewFrenchProductName.Focus();
                return false;}
            
            if (txtNewColor.Text == "") {
                ec.ShowMessage(" Color is Required. ", " Dbo. Dim Product ");
                txtNewColor.Focus();
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
		    grddbo_DimProduct.PageIndex = 0;
		    grddbo_DimProduct.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimProduct();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimProduct");
		    LoadGriddbo_DimProduct();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimProduct");
			if ((Session["dvdbo_DimProduct"] != null)) {
				dvdbo_DimProduct = (DataView)Session["dvdbo_DimProduct"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProduct = dbo_DimProductDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimProduct"] = dvdbo_DimProduct;
		    	}
                if (dvdbo_DimProduct.Count > 0) {
                    grddbo_DimProduct.DataSource = dvdbo_DimProduct;
                    grddbo_DimProduct.DataBind();
                }
                if (dvdbo_DimProduct.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishProductSubcategoryName", Type.GetType("System.Int32"));
                    dt.Columns.Add("WeightUnitMeasureCode", Type.GetType("System.String"));
                    dt.Columns.Add("SizeUnitMeasureCode", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishProductName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishProductName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchProductName", Type.GetType("System.String"));
                    dt.Columns.Add("StandardCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("FinishedGoodsFlag", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Color", Type.GetType("System.String"));
                    dt.Columns.Add("SafetyStockLevel", Type.GetType("System.Int16"));
                    dt.Columns.Add("ReorderPoint", Type.GetType("System.Int16"));
                    dt.Columns.Add("ListPrice", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Size", Type.GetType("System.String"));
                    dt.Columns.Add("SizeRange", Type.GetType("System.String"));
                    dt.Columns.Add("Weight", Type.GetType("System.Decimal"));
                    dt.Columns.Add("DaysToManufacture", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductLine", Type.GetType("System.String"));
                    dt.Columns.Add("DealerPrice", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Class", Type.GetType("System.String"));
                    dt.Columns.Add("Style", Type.GetType("System.String"));
                    dt.Columns.Add("ModelName", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishDescription", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchDescription", Type.GetType("System.String"));
                    dt.Columns.Add("ChineseDescription", Type.GetType("System.String"));
                    dt.Columns.Add("ArabicDescription", Type.GetType("System.String"));
                    dt.Columns.Add("HebrewDescription", Type.GetType("System.String"));
                    dt.Columns.Add("ThaiDescription", Type.GetType("System.String"));
                    dt.Columns.Add("GermanDescription", Type.GetType("System.String"));
                    dt.Columns.Add("JapaneseDescription", Type.GetType("System.String"));
                    dt.Columns.Add("TurkishDescription", Type.GetType("System.String"));
                    dt.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("Status", Type.GetType("System.String"));
                    dvdbo_DimProduct = dt.DefaultView;
                    Session["dvdbo_DimProduct"] = dvdbo_DimProduct;

                    grddbo_DimProduct.DataSource = dvdbo_DimProduct;
                    grddbo_DimProduct.DataBind();

                    int TotalColumns = grddbo_DimProduct.Rows[0].Cells.Count;
                    grddbo_DimProduct.Rows[0].Cells.Clear();
                    grddbo_DimProduct.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimProduct.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimProduct.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimProduct.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
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
                    { dt = dbo_DimProductDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimProductDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Product", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimProduct"];
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
 
