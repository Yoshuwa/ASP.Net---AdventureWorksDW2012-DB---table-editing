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
    public partial class frmdbo_FactResellerSales : System.Web.UI.Page
    {

        private dbo_FactResellerSalesDataClass clsdbo_FactResellerSalesData = new dbo_FactResellerSalesDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactResellerSales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ProductKey_SelectedValue"] = "";
                Session["OrderDateKey_SelectedValue"] = "";
                Session["DueDateKey_SelectedValue"] = "";
                Session["ShipDateKey_SelectedValue"] = "";
                Session["ResellerKey_SelectedValue"] = "";
                Session["EmployeeKey_SelectedValue"] = "";
                Session["PromotionKey_SelectedValue"] = "";
                Session["CurrencyKey_SelectedValue"] = "";
                Session["SalesTerritoryKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactResellerSales");
                Session.Remove("Row");

                cmbFields.Items.Add("Sales Order Number");
                cmbFields.Items.Add("Sales Order Line Number");
                cmbFields.Items.Add("Product Key");
                cmbFields.Items.Add("Order Date Key");
                cmbFields.Items.Add("Due Date Key");
                cmbFields.Items.Add("Ship Date Key");
                cmbFields.Items.Add("Reseller Key");
                cmbFields.Items.Add("Employee Key");
                cmbFields.Items.Add("Promotion Key");
                cmbFields.Items.Add("Currency Key");
                cmbFields.Items.Add("Sales Territory Key");
                cmbFields.Items.Add("Revision Number");
                cmbFields.Items.Add("Order Quantity");
                cmbFields.Items.Add("Unit Price");
                cmbFields.Items.Add("Extended Amount");
                cmbFields.Items.Add("Unit Price Discount Pct");
                cmbFields.Items.Add("Discount Amount");
                cmbFields.Items.Add("Product Standard Cost");
                cmbFields.Items.Add("Total Product Cost");
                cmbFields.Items.Add("Sales Amount");
                cmbFields.Items.Add("Tax Amt");
                cmbFields.Items.Add("Freight");
                cmbFields.Items.Add("Carrier Tracking Number");
                cmbFields.Items.Add("Customer P O Number");
                cmbFields.Items.Add("Order Date");
                cmbFields.Items.Add("Due Date");
                cmbFields.Items.Add("Ship Date");

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

                LoadGriddbo_FactResellerSales();
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimProductComboBox274(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimProductClass274> dbo_FactResellerSales_dbo_DimProductList = new  List<dbo_FactResellerSales_dbo_DimProductClass274>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtProductKey = (DropDownList)e.Row.FindControl("txtProductKey");
                if (txtProductKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimProductList = dbo_FactResellerSales_dbo_DimProductDataClass274.List();
                        txtProductKey.DataSource = dbo_FactResellerSales_dbo_DimProductList;
                        txtProductKey.DataValueField = "ProductKey";
                        txtProductKey.DataTextField = "ProductAlternateKey";
                        txtProductKey.DataBind();
                        txtProductKey.SelectedValue = Convert.ToString(Session["ProductKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewProductKey = (DropDownList)e.Row.FindControl("txtNewProductKey");
                if (txtNewProductKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimProductList = dbo_FactResellerSales_dbo_DimProductDataClass274.List();
                        txtNewProductKey.DataSource = dbo_FactResellerSales_dbo_DimProductList;
                        txtNewProductKey.DataValueField = "ProductKey";
                        txtNewProductKey.DataTextField = "ProductAlternateKey";
                        txtNewProductKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimDateComboBox275(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimDateClass275> dbo_FactResellerSales_dbo_DimDateList = new  List<dbo_FactResellerSales_dbo_DimDateClass275>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtOrderDateKey = (DropDownList)e.Row.FindControl("txtOrderDateKey");
                if (txtOrderDateKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass275.List();
                        txtOrderDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
                        txtOrderDateKey.DataValueField = "DateKey";
                        txtOrderDateKey.DataTextField = "DateKey";
                        txtOrderDateKey.DataBind();
                        txtOrderDateKey.SelectedValue = Convert.ToString(Session["OrderDateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewOrderDateKey = (DropDownList)e.Row.FindControl("txtNewOrderDateKey");
                if (txtNewOrderDateKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass275.List();
                        txtNewOrderDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
                        txtNewOrderDateKey.DataValueField = "DateKey";
                        txtNewOrderDateKey.DataTextField = "DateKey";
                        txtNewOrderDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimDateComboBox276(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimDateClass276> dbo_FactResellerSales_dbo_DimDateList = new  List<dbo_FactResellerSales_dbo_DimDateClass276>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDueDateKey = (DropDownList)e.Row.FindControl("txtDueDateKey");
                if (txtDueDateKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass276.List();
                        txtDueDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
                        txtDueDateKey.DataValueField = "DateKey";
                        txtDueDateKey.DataTextField = "DateKey";
                        txtDueDateKey.DataBind();
                        txtDueDateKey.SelectedValue = Convert.ToString(Session["DueDateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDueDateKey = (DropDownList)e.Row.FindControl("txtNewDueDateKey");
                if (txtNewDueDateKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass276.List();
                        txtNewDueDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
                        txtNewDueDateKey.DataValueField = "DateKey";
                        txtNewDueDateKey.DataTextField = "DateKey";
                        txtNewDueDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimDateComboBox277(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimDateClass277> dbo_FactResellerSales_dbo_DimDateList = new  List<dbo_FactResellerSales_dbo_DimDateClass277>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtShipDateKey = (DropDownList)e.Row.FindControl("txtShipDateKey");
                if (txtShipDateKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass277.List();
                        txtShipDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
                        txtShipDateKey.DataValueField = "DateKey";
                        txtShipDateKey.DataTextField = "DateKey";
                        txtShipDateKey.DataBind();
                        txtShipDateKey.SelectedValue = Convert.ToString(Session["ShipDateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewShipDateKey = (DropDownList)e.Row.FindControl("txtNewShipDateKey");
                if (txtNewShipDateKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass277.List();
                        txtNewShipDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
                        txtNewShipDateKey.DataValueField = "DateKey";
                        txtNewShipDateKey.DataTextField = "DateKey";
                        txtNewShipDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimResellerComboBox278(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimResellerClass278> dbo_FactResellerSales_dbo_DimResellerList = new  List<dbo_FactResellerSales_dbo_DimResellerClass278>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtResellerKey = (DropDownList)e.Row.FindControl("txtResellerKey");
                if (txtResellerKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimResellerList = dbo_FactResellerSales_dbo_DimResellerDataClass278.List();
                        txtResellerKey.DataSource = dbo_FactResellerSales_dbo_DimResellerList;
                        txtResellerKey.DataValueField = "ResellerKey";
                        txtResellerKey.DataTextField = "ResellerKey";
                        txtResellerKey.DataBind();
                        txtResellerKey.SelectedValue = Convert.ToString(Session["ResellerKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewResellerKey = (DropDownList)e.Row.FindControl("txtNewResellerKey");
                if (txtNewResellerKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimResellerList = dbo_FactResellerSales_dbo_DimResellerDataClass278.List();
                        txtNewResellerKey.DataSource = dbo_FactResellerSales_dbo_DimResellerList;
                        txtNewResellerKey.DataValueField = "ResellerKey";
                        txtNewResellerKey.DataTextField = "ResellerKey";
                        txtNewResellerKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimEmployeeComboBox279(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimEmployeeClass279> dbo_FactResellerSales_dbo_DimEmployeeList = new  List<dbo_FactResellerSales_dbo_DimEmployeeClass279>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtEmployeeKey = (DropDownList)e.Row.FindControl("txtEmployeeKey");
                if (txtEmployeeKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimEmployeeList = dbo_FactResellerSales_dbo_DimEmployeeDataClass279.List();
                        txtEmployeeKey.DataSource = dbo_FactResellerSales_dbo_DimEmployeeList;
                        txtEmployeeKey.DataValueField = "EmployeeKey";
                        txtEmployeeKey.DataTextField = "EmployeeKey";
                        txtEmployeeKey.DataBind();
                        txtEmployeeKey.SelectedValue = Convert.ToString(Session["EmployeeKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewEmployeeKey = (DropDownList)e.Row.FindControl("txtNewEmployeeKey");
                if (txtNewEmployeeKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimEmployeeList = dbo_FactResellerSales_dbo_DimEmployeeDataClass279.List();
                        txtNewEmployeeKey.DataSource = dbo_FactResellerSales_dbo_DimEmployeeList;
                        txtNewEmployeeKey.DataValueField = "EmployeeKey";
                        txtNewEmployeeKey.DataTextField = "EmployeeKey";
                        txtNewEmployeeKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimPromotionComboBox280(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimPromotionClass280> dbo_FactResellerSales_dbo_DimPromotionList = new  List<dbo_FactResellerSales_dbo_DimPromotionClass280>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtPromotionKey = (DropDownList)e.Row.FindControl("txtPromotionKey");
                if (txtPromotionKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimPromotionList = dbo_FactResellerSales_dbo_DimPromotionDataClass280.List();
                        txtPromotionKey.DataSource = dbo_FactResellerSales_dbo_DimPromotionList;
                        txtPromotionKey.DataValueField = "PromotionKey";
                        txtPromotionKey.DataTextField = "PromotionKey";
                        txtPromotionKey.DataBind();
                        txtPromotionKey.SelectedValue = Convert.ToString(Session["PromotionKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewPromotionKey = (DropDownList)e.Row.FindControl("txtNewPromotionKey");
                if (txtNewPromotionKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimPromotionList = dbo_FactResellerSales_dbo_DimPromotionDataClass280.List();
                        txtNewPromotionKey.DataSource = dbo_FactResellerSales_dbo_DimPromotionList;
                        txtNewPromotionKey.DataValueField = "PromotionKey";
                        txtNewPromotionKey.DataTextField = "PromotionKey";
                        txtNewPromotionKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimCurrencyComboBox281(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimCurrencyClass281> dbo_FactResellerSales_dbo_DimCurrencyList = new  List<dbo_FactResellerSales_dbo_DimCurrencyClass281>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCurrencyKey = (DropDownList)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimCurrencyList = dbo_FactResellerSales_dbo_DimCurrencyDataClass281.List();
                        txtCurrencyKey.DataSource = dbo_FactResellerSales_dbo_DimCurrencyList;
                        txtCurrencyKey.DataValueField = "CurrencyKey";
                        txtCurrencyKey.DataTextField = "CurrencyKey";
                        txtCurrencyKey.DataBind();
                        txtCurrencyKey.SelectedValue = Convert.ToString(Session["CurrencyKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewCurrencyKey = (DropDownList)e.Row.FindControl("txtNewCurrencyKey");
                if (txtNewCurrencyKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimCurrencyList = dbo_FactResellerSales_dbo_DimCurrencyDataClass281.List();
                        txtNewCurrencyKey.DataSource = dbo_FactResellerSales_dbo_DimCurrencyList;
                        txtNewCurrencyKey.DataValueField = "CurrencyKey";
                        txtNewCurrencyKey.DataTextField = "CurrencyKey";
                        txtNewCurrencyKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactResellerSales_dbo_DimSalesTerritoryComboBox282(GridViewRowEventArgs e)
        {
            List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282> dbo_FactResellerSales_dbo_DimSalesTerritoryList = new  List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtSalesTerritoryKey");
                if (txtSalesTerritoryKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimSalesTerritoryList = dbo_FactResellerSales_dbo_DimSalesTerritoryDataClass282.List();
                        txtSalesTerritoryKey.DataSource = dbo_FactResellerSales_dbo_DimSalesTerritoryList;
                        txtSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
                        txtSalesTerritoryKey.DataTextField = "SalesTerritoryKey";
                        txtSalesTerritoryKey.DataBind();
                        txtSalesTerritoryKey.SelectedValue = Convert.ToString(Session["SalesTerritoryKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtNewSalesTerritoryKey");
                if (txtNewSalesTerritoryKey != null) {
                    try {
                        dbo_FactResellerSales_dbo_DimSalesTerritoryList = dbo_FactResellerSales_dbo_DimSalesTerritoryDataClass282.List();
                        txtNewSalesTerritoryKey.DataSource = dbo_FactResellerSales_dbo_DimSalesTerritoryList;
                        txtNewSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
                        txtNewSalesTerritoryKey.DataTextField = "SalesTerritoryKey";
                        txtNewSalesTerritoryKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactResellerSales()
        {
            try {
                if ((Session["dvdbo_FactResellerSales"] != null)) {
                    dvdbo_FactResellerSales = (DataView)Session["dvdbo_FactResellerSales"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactResellerSales = dbo_FactResellerSalesDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactResellerSales"] = dvdbo_FactResellerSales;
                }
                if (dvdbo_FactResellerSales.Count > 0) {
                    grddbo_FactResellerSales.DataSource = dvdbo_FactResellerSales;
                    grddbo_FactResellerSales.DataBind();
                }
                if (dvdbo_FactResellerSales.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesOrderNumber", Type.GetType("System.String"));
                    dt.Columns.Add("SalesOrderLineNumber", Type.GetType("System.Byte"));
                    dt.Columns.Add("ProductAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ResellerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EmployeeKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("PromotionKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CurrencyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("RevisionNumber", Type.GetType("System.Byte"));
                    dt.Columns.Add("OrderQuantity", Type.GetType("System.Int16"));
                    dt.Columns.Add("UnitPrice", Type.GetType("System.Decimal"));
                    dt.Columns.Add("ExtendedAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("UnitPriceDiscountPct", Type.GetType("System.Decimal"));
                    dt.Columns.Add("DiscountAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("ProductStandardCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TotalProductCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("SalesAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TaxAmt", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Freight", Type.GetType("System.Decimal"));
                    dt.Columns.Add("CarrierTrackingNumber", Type.GetType("System.String"));
                    dt.Columns.Add("CustomerPONumber", Type.GetType("System.String"));
                    dt.Columns.Add("OrderDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("DueDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("ShipDate", Type.GetType("System.DateTime"));
                    dvdbo_FactResellerSales = dt.DefaultView;
                    Session["dvdbo_FactResellerSales"] = dvdbo_FactResellerSales;

                    grddbo_FactResellerSales.DataSource = dvdbo_FactResellerSales;
                    grddbo_FactResellerSales.DataBind();

                    int TotalColumns = grddbo_FactResellerSales.Rows[0].Cells.Count;
                    grddbo_FactResellerSales.Rows[0].Cells.Clear();
                    grddbo_FactResellerSales.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactResellerSales.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactResellerSales.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactResellerSales.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
            }
        }

        protected void grddbo_FactResellerSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactResellerSales_dbo_DimProductComboBox274(e);
            Loaddbo_FactResellerSales_dbo_DimDateComboBox275(e);
            Loaddbo_FactResellerSales_dbo_DimDateComboBox276(e);
            Loaddbo_FactResellerSales_dbo_DimDateComboBox277(e);
            Loaddbo_FactResellerSales_dbo_DimResellerComboBox278(e);
            Loaddbo_FactResellerSales_dbo_DimEmployeeComboBox279(e);
            Loaddbo_FactResellerSales_dbo_DimPromotionComboBox280(e);
            Loaddbo_FactResellerSales_dbo_DimCurrencyComboBox281(e);
            Loaddbo_FactResellerSales_dbo_DimSalesTerritoryComboBox282(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtSalesOrderNumber = (TextBox)e.Row.FindControl("txtSalesOrderNumber");
                if (txtSalesOrderNumber != null) {
                    txtSalesOrderNumber.Enabled = false;
                }
                TextBox txtSalesOrderLineNumber = (TextBox)e.Row.FindControl("txtSalesOrderLineNumber");
                if (txtSalesOrderLineNumber != null) {
                    txtSalesOrderLineNumber.Enabled = false;
                }
            }
        }

        protected void grddbo_FactResellerSales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactResellerSales.EditIndex = -1;
            LoadGriddbo_FactResellerSales();
        }

        protected void grddbo_FactResellerSales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactResellerSales.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactResellerSales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactResellerSales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactResellerSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactResellerSales_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactResellerSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactResellerSales.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactResellerSales();
        }

        protected void grddbo_FactResellerSales_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactResellerSales();
        }

        private void Edit()
        {
            try {
                dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
                Label lblSalesOrderNumber = (Label)grddbo_FactResellerSales.Rows[grddbo_FactResellerSales.EditIndex].FindControl("lblSalesOrderNumber");
                clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(lblSalesOrderNumber.Text);
                Label lblSalesOrderLineNumber = (Label)grddbo_FactResellerSales.Rows[grddbo_FactResellerSales.EditIndex].FindControl("lblSalesOrderLineNumber");
                clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(lblSalesOrderLineNumber.Text);
                clsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(clsdbo_FactResellerSales);

                Session["ProductKey_SelectedValue"] = clsdbo_FactResellerSales.ProductKey;
                Session["OrderDateKey_SelectedValue"] = clsdbo_FactResellerSales.OrderDateKey;
                Session["DueDateKey_SelectedValue"] = clsdbo_FactResellerSales.DueDateKey;
                Session["ShipDateKey_SelectedValue"] = clsdbo_FactResellerSales.ShipDateKey;
                Session["ResellerKey_SelectedValue"] = clsdbo_FactResellerSales.ResellerKey;
                Session["EmployeeKey_SelectedValue"] = clsdbo_FactResellerSales.EmployeeKey;
                Session["PromotionKey_SelectedValue"] = clsdbo_FactResellerSales.PromotionKey;
                Session["CurrencyKey_SelectedValue"] = clsdbo_FactResellerSales.CurrencyKey;
                Session["SalesTerritoryKey_SelectedValue"] = clsdbo_FactResellerSales.SalesTerritoryKey;

                LoadGriddbo_FactResellerSales();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewSalesOrderNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesOrderNumber");
                TextBox txtNewSalesOrderLineNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesOrderLineNumber");
                DropDownList txtNewProductKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewProductKey");
                DropDownList txtNewOrderDateKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewOrderDateKey");
                DropDownList txtNewDueDateKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewDueDateKey");
                DropDownList txtNewShipDateKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewShipDateKey");
                DropDownList txtNewResellerKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewResellerKey");
                DropDownList txtNewEmployeeKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewEmployeeKey");
                DropDownList txtNewPromotionKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewPromotionKey");
                DropDownList txtNewCurrencyKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewCurrencyKey");
                DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesTerritoryKey");
                TextBox txtNewRevisionNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewRevisionNumber");
                TextBox txtNewOrderQuantity = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewOrderQuantity");
                TextBox txtNewUnitPrice = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewUnitPrice");
                TextBox txtNewExtendedAmount = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewExtendedAmount");
                TextBox txtNewUnitPriceDiscountPct = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewUnitPriceDiscountPct");
                TextBox txtNewDiscountAmount = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewDiscountAmount");
                TextBox txtNewProductStandardCost = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewProductStandardCost");
                TextBox txtNewTotalProductCost = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewTotalProductCost");
                TextBox txtNewSalesAmount = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesAmount");
                TextBox txtNewTaxAmt = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewTaxAmt");
                TextBox txtNewFreight = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewFreight");
                TextBox txtNewCarrierTrackingNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewCarrierTrackingNumber");
                TextBox txtNewCustomerPONumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewCustomerPONumber");
                TextBox txtNewOrderDate = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewOrderDate");
                TextBox txtNewDueDate = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewDueDate");
                TextBox txtNewShipDate = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewShipDate");

                dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(txtNewSalesOrderNumber.Text);
                    clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(txtNewSalesOrderLineNumber.Text);
                    clsdbo_FactResellerSales.ProductKey = System.Convert.ToInt32(txtNewProductKey.SelectedValue);
                    clsdbo_FactResellerSales.OrderDateKey = System.Convert.ToInt32(txtNewOrderDateKey.SelectedValue);
                    clsdbo_FactResellerSales.DueDateKey = System.Convert.ToInt32(txtNewDueDateKey.SelectedValue);
                    clsdbo_FactResellerSales.ShipDateKey = System.Convert.ToInt32(txtNewShipDateKey.SelectedValue);
                    clsdbo_FactResellerSales.ResellerKey = System.Convert.ToInt32(txtNewResellerKey.SelectedValue);
                    clsdbo_FactResellerSales.EmployeeKey = System.Convert.ToInt32(txtNewEmployeeKey.SelectedValue);
                    clsdbo_FactResellerSales.PromotionKey = System.Convert.ToInt32(txtNewPromotionKey.SelectedValue);
                    clsdbo_FactResellerSales.CurrencyKey = System.Convert.ToInt32(txtNewCurrencyKey.SelectedValue);
                    clsdbo_FactResellerSales.SalesTerritoryKey = System.Convert.ToInt32(txtNewSalesTerritoryKey.SelectedValue);
                    if (string.IsNullOrEmpty(txtNewRevisionNumber.Text)) {
                        clsdbo_FactResellerSales.RevisionNumber = null;
                    } else {
                        clsdbo_FactResellerSales.RevisionNumber = System.Convert.ToByte(txtNewRevisionNumber.Text); }
                    if (string.IsNullOrEmpty(txtNewOrderQuantity.Text)) {
                        clsdbo_FactResellerSales.OrderQuantity = null;
                    } else {
                        clsdbo_FactResellerSales.OrderQuantity = System.Convert.ToInt16(txtNewOrderQuantity.Text); }
                    if (string.IsNullOrEmpty(txtNewUnitPrice.Text)) {
                        clsdbo_FactResellerSales.UnitPrice = null;
                    } else {
                        clsdbo_FactResellerSales.UnitPrice = System.Convert.ToDecimal(txtNewUnitPrice.Text); }
                    if (string.IsNullOrEmpty(txtNewExtendedAmount.Text)) {
                        clsdbo_FactResellerSales.ExtendedAmount = null;
                    } else {
                        clsdbo_FactResellerSales.ExtendedAmount = System.Convert.ToDecimal(txtNewExtendedAmount.Text); }
                    if (string.IsNullOrEmpty(txtNewUnitPriceDiscountPct.Text)) {
                        clsdbo_FactResellerSales.UnitPriceDiscountPct = null;
                    } else {
                        clsdbo_FactResellerSales.UnitPriceDiscountPct = System.Convert.ToDecimal(txtNewUnitPriceDiscountPct.Text); }
                    if (string.IsNullOrEmpty(txtNewDiscountAmount.Text)) {
                        clsdbo_FactResellerSales.DiscountAmount = null;
                    } else {
                        clsdbo_FactResellerSales.DiscountAmount = System.Convert.ToDecimal(txtNewDiscountAmount.Text); }
                    if (string.IsNullOrEmpty(txtNewProductStandardCost.Text)) {
                        clsdbo_FactResellerSales.ProductStandardCost = null;
                    } else {
                        clsdbo_FactResellerSales.ProductStandardCost = System.Convert.ToDecimal(txtNewProductStandardCost.Text); }
                    if (string.IsNullOrEmpty(txtNewTotalProductCost.Text)) {
                        clsdbo_FactResellerSales.TotalProductCost = null;
                    } else {
                        clsdbo_FactResellerSales.TotalProductCost = System.Convert.ToDecimal(txtNewTotalProductCost.Text); }
                    if (string.IsNullOrEmpty(txtNewSalesAmount.Text)) {
                        clsdbo_FactResellerSales.SalesAmount = null;
                    } else {
                        clsdbo_FactResellerSales.SalesAmount = System.Convert.ToDecimal(txtNewSalesAmount.Text); }
                    if (string.IsNullOrEmpty(txtNewTaxAmt.Text)) {
                        clsdbo_FactResellerSales.TaxAmt = null;
                    } else {
                        clsdbo_FactResellerSales.TaxAmt = System.Convert.ToDecimal(txtNewTaxAmt.Text); }
                    if (string.IsNullOrEmpty(txtNewFreight.Text)) {
                        clsdbo_FactResellerSales.Freight = null;
                    } else {
                        clsdbo_FactResellerSales.Freight = System.Convert.ToDecimal(txtNewFreight.Text); }
                    if (string.IsNullOrEmpty(txtNewCarrierTrackingNumber.Text)) {
                        clsdbo_FactResellerSales.CarrierTrackingNumber = null;
                    } else {
                        clsdbo_FactResellerSales.CarrierTrackingNumber = txtNewCarrierTrackingNumber.Text; }
                    if (string.IsNullOrEmpty(txtNewCustomerPONumber.Text)) {
                        clsdbo_FactResellerSales.CustomerPONumber = null;
                    } else {
                        clsdbo_FactResellerSales.CustomerPONumber = txtNewCustomerPONumber.Text; }
                    if (string.IsNullOrEmpty(txtNewOrderDate.Text)) {
                        clsdbo_FactResellerSales.OrderDate = null;
                    } else {
                        clsdbo_FactResellerSales.OrderDate = System.Convert.ToDateTime(txtNewOrderDate.Text); }
                    if (string.IsNullOrEmpty(txtNewDueDate.Text)) {
                        clsdbo_FactResellerSales.DueDate = null;
                    } else {
                        clsdbo_FactResellerSales.DueDate = System.Convert.ToDateTime(txtNewDueDate.Text); }
                    if (string.IsNullOrEmpty(txtNewShipDate.Text)) {
                        clsdbo_FactResellerSales.ShipDate = null;
                    } else {
                        clsdbo_FactResellerSales.ShipDate = System.Convert.ToDateTime(txtNewShipDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactResellerSalesDataClass.Add(clsdbo_FactResellerSales);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactResellerSales");
                        LoadGriddbo_FactResellerSales();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Reseller Sales ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtSalesOrderNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderNumber");
                TextBox txtSalesOrderLineNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderLineNumber");
                DropDownList txtProductKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
                DropDownList txtOrderDateKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDateKey");
                DropDownList txtDueDateKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDateKey");
                DropDownList txtShipDateKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDateKey");
                DropDownList txtResellerKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerKey");
                DropDownList txtEmployeeKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeKey");
                DropDownList txtPromotionKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionKey");
                DropDownList txtCurrencyKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
                DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
                TextBox txtRevisionNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtRevisionNumber");
                TextBox txtOrderQuantity = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderQuantity");
                TextBox txtUnitPrice = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPrice");
                TextBox txtExtendedAmount = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtExtendedAmount");
                TextBox txtUnitPriceDiscountPct = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPriceDiscountPct");
                TextBox txtDiscountAmount = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDiscountAmount");
                TextBox txtProductStandardCost = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductStandardCost");
                TextBox txtTotalProductCost = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalProductCost");
                TextBox txtSalesAmount = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesAmount");
                TextBox txtTaxAmt = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTaxAmt");
                TextBox txtFreight = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFreight");
                TextBox txtCarrierTrackingNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCarrierTrackingNumber");
                TextBox txtCustomerPONumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerPONumber");
                TextBox txtOrderDate = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDate");
                TextBox txtDueDate = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDate");
                TextBox txtShipDate = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDate");

                dbo_FactResellerSalesClass oclsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
                dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
                oclsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
                oclsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
                oclsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(oclsdbo_FactResellerSales);

                if (VerifyData() == true) {
                    clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
                    clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
                    clsdbo_FactResellerSales.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
                    clsdbo_FactResellerSales.OrderDateKey = System.Convert.ToInt32(txtOrderDateKey.SelectedValue);
                    clsdbo_FactResellerSales.DueDateKey = System.Convert.ToInt32(txtDueDateKey.SelectedValue);
                    clsdbo_FactResellerSales.ShipDateKey = System.Convert.ToInt32(txtShipDateKey.SelectedValue);
                    clsdbo_FactResellerSales.ResellerKey = System.Convert.ToInt32(txtResellerKey.SelectedValue);
                    clsdbo_FactResellerSales.EmployeeKey = System.Convert.ToInt32(txtEmployeeKey.SelectedValue);
                    clsdbo_FactResellerSales.PromotionKey = System.Convert.ToInt32(txtPromotionKey.SelectedValue);
                    clsdbo_FactResellerSales.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
                    clsdbo_FactResellerSales.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue);
                    if (string.IsNullOrEmpty(txtRevisionNumber.Text)) {
                        clsdbo_FactResellerSales.RevisionNumber = null;
                    } else {
                        clsdbo_FactResellerSales.RevisionNumber = System.Convert.ToByte(txtRevisionNumber.Text); }
                    if (string.IsNullOrEmpty(txtOrderQuantity.Text)) {
                        clsdbo_FactResellerSales.OrderQuantity = null;
                    } else {
                        clsdbo_FactResellerSales.OrderQuantity = System.Convert.ToInt16(txtOrderQuantity.Text); }
                    if (string.IsNullOrEmpty(txtUnitPrice.Text)) {
                        clsdbo_FactResellerSales.UnitPrice = null;
                    } else {
                        clsdbo_FactResellerSales.UnitPrice = System.Convert.ToDecimal(txtUnitPrice.Text); }
                    if (string.IsNullOrEmpty(txtExtendedAmount.Text)) {
                        clsdbo_FactResellerSales.ExtendedAmount = null;
                    } else {
                        clsdbo_FactResellerSales.ExtendedAmount = System.Convert.ToDecimal(txtExtendedAmount.Text); }
                    if (string.IsNullOrEmpty(txtUnitPriceDiscountPct.Text)) {
                        clsdbo_FactResellerSales.UnitPriceDiscountPct = null;
                    } else {
                        clsdbo_FactResellerSales.UnitPriceDiscountPct = System.Convert.ToDecimal(txtUnitPriceDiscountPct.Text); }
                    if (string.IsNullOrEmpty(txtDiscountAmount.Text)) {
                        clsdbo_FactResellerSales.DiscountAmount = null;
                    } else {
                        clsdbo_FactResellerSales.DiscountAmount = System.Convert.ToDecimal(txtDiscountAmount.Text); }
                    if (string.IsNullOrEmpty(txtProductStandardCost.Text)) {
                        clsdbo_FactResellerSales.ProductStandardCost = null;
                    } else {
                        clsdbo_FactResellerSales.ProductStandardCost = System.Convert.ToDecimal(txtProductStandardCost.Text); }
                    if (string.IsNullOrEmpty(txtTotalProductCost.Text)) {
                        clsdbo_FactResellerSales.TotalProductCost = null;
                    } else {
                        clsdbo_FactResellerSales.TotalProductCost = System.Convert.ToDecimal(txtTotalProductCost.Text); }
                    if (string.IsNullOrEmpty(txtSalesAmount.Text)) {
                        clsdbo_FactResellerSales.SalesAmount = null;
                    } else {
                        clsdbo_FactResellerSales.SalesAmount = System.Convert.ToDecimal(txtSalesAmount.Text); }
                    if (string.IsNullOrEmpty(txtTaxAmt.Text)) {
                        clsdbo_FactResellerSales.TaxAmt = null;
                    } else {
                        clsdbo_FactResellerSales.TaxAmt = System.Convert.ToDecimal(txtTaxAmt.Text); }
                    if (string.IsNullOrEmpty(txtFreight.Text)) {
                        clsdbo_FactResellerSales.Freight = null;
                    } else {
                        clsdbo_FactResellerSales.Freight = System.Convert.ToDecimal(txtFreight.Text); }
                    if (string.IsNullOrEmpty(txtCarrierTrackingNumber.Text)) {
                        clsdbo_FactResellerSales.CarrierTrackingNumber = null;
                    } else {
                        clsdbo_FactResellerSales.CarrierTrackingNumber = txtCarrierTrackingNumber.Text; }
                    if (string.IsNullOrEmpty(txtCustomerPONumber.Text)) {
                        clsdbo_FactResellerSales.CustomerPONumber = null;
                    } else {
                        clsdbo_FactResellerSales.CustomerPONumber = txtCustomerPONumber.Text; }
                    if (string.IsNullOrEmpty(txtOrderDate.Text)) {
                        clsdbo_FactResellerSales.OrderDate = null;
                    } else {
                        clsdbo_FactResellerSales.OrderDate = System.Convert.ToDateTime(txtOrderDate.Text); }
                    if (string.IsNullOrEmpty(txtDueDate.Text)) {
                        clsdbo_FactResellerSales.DueDate = null;
                    } else {
                        clsdbo_FactResellerSales.DueDate = System.Convert.ToDateTime(txtDueDate.Text); }
                    if (string.IsNullOrEmpty(txtShipDate.Text)) {
                        clsdbo_FactResellerSales.ShipDate = null;
                    } else {
                        clsdbo_FactResellerSales.ShipDate = System.Convert.ToDateTime(txtShipDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactResellerSalesDataClass.Update(oclsdbo_FactResellerSales, clsdbo_FactResellerSales);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactResellerSales");
                        grddbo_FactResellerSales.EditIndex = -1;
                        LoadGriddbo_FactResellerSales();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Reseller Sales ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
            Label lblSalesOrderNumber = (Label)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesOrderNumber");
            clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(lblSalesOrderNumber.Text);
            Label lblSalesOrderLineNumber = (Label)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesOrderLineNumber");
            clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(lblSalesOrderLineNumber.Text);
            clsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(clsdbo_FactResellerSales);
            bool bSucess = false;
            bSucess = dbo_FactResellerSalesDataClass.Delete(clsdbo_FactResellerSales);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactResellerSales");
                LoadGriddbo_FactResellerSales();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Reseller Sales ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtSalesOrderNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderNumber");
            TextBox txtSalesOrderLineNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderLineNumber");
            DropDownList txtProductKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
            DropDownList txtOrderDateKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDateKey");
            DropDownList txtDueDateKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDateKey");
            DropDownList txtShipDateKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDateKey");
            DropDownList txtResellerKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtResellerKey");
            DropDownList txtEmployeeKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeKey");
            DropDownList txtPromotionKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionKey");
            DropDownList txtCurrencyKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
            DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
            TextBox txtRevisionNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtRevisionNumber");
            TextBox txtOrderQuantity = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderQuantity");
            TextBox txtUnitPrice = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPrice");
            TextBox txtExtendedAmount = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtExtendedAmount");
            TextBox txtUnitPriceDiscountPct = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPriceDiscountPct");
            TextBox txtDiscountAmount = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDiscountAmount");
            TextBox txtProductStandardCost = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductStandardCost");
            TextBox txtTotalProductCost = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalProductCost");
            TextBox txtSalesAmount = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesAmount");
            TextBox txtTaxAmt = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTaxAmt");
            TextBox txtFreight = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFreight");
            TextBox txtCarrierTrackingNumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCarrierTrackingNumber");
            TextBox txtCustomerPONumber = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerPONumber");
            TextBox txtOrderDate = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDate");
            TextBox txtDueDate = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDate");
            TextBox txtShipDate = (TextBox)grddbo_FactResellerSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDate");

            if (txtSalesOrderNumber.Text == "") {
                ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Reseller Sales ");
                txtSalesOrderNumber.Focus();
                return false;}
            if (txtSalesOrderLineNumber.Text == "") {
                ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Reseller Sales ");
                txtSalesOrderLineNumber.Focus();
                return false;}
            if (txtProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtProductKey.Focus();
                return false;}
            if (txtOrderDateKey.Text == "") {
                ec.ShowMessage(" Order Date Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtOrderDateKey.Focus();
                return false;}
            if (txtDueDateKey.Text == "") {
                ec.ShowMessage(" Due Date Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtDueDateKey.Focus();
                return false;}
            if (txtShipDateKey.Text == "") {
                ec.ShowMessage(" Ship Date Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtShipDateKey.Focus();
                return false;}
            if (txtResellerKey.Text == "") {
                ec.ShowMessage(" Reseller Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtResellerKey.Focus();
                return false;}
            if (txtEmployeeKey.Text == "") {
                ec.ShowMessage(" Employee Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtEmployeeKey.Focus();
                return false;}
            if (txtPromotionKey.Text == "") {
                ec.ShowMessage(" Promotion Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtPromotionKey.Focus();
                return false;}
            if (txtCurrencyKey.Text == "") {
                ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtCurrencyKey.Focus();
                return false;}
            if (txtSalesTerritoryKey.Text == "") {
                ec.ShowMessage(" Sales Territory Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtSalesTerritoryKey.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewSalesOrderNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesOrderNumber");
            TextBox txtNewSalesOrderLineNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesOrderLineNumber");
            DropDownList txtNewProductKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewProductKey");
            DropDownList txtNewOrderDateKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewOrderDateKey");
            DropDownList txtNewDueDateKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewDueDateKey");
            DropDownList txtNewShipDateKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewShipDateKey");
            DropDownList txtNewResellerKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewResellerKey");
            DropDownList txtNewEmployeeKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewEmployeeKey");
            DropDownList txtNewPromotionKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewPromotionKey");
            DropDownList txtNewCurrencyKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewCurrencyKey");
            DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesTerritoryKey");
            TextBox txtNewRevisionNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewRevisionNumber");
            TextBox txtNewOrderQuantity = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewOrderQuantity");
            TextBox txtNewUnitPrice = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewUnitPrice");
            TextBox txtNewExtendedAmount = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewExtendedAmount");
            TextBox txtNewUnitPriceDiscountPct = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewUnitPriceDiscountPct");
            TextBox txtNewDiscountAmount = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewDiscountAmount");
            TextBox txtNewProductStandardCost = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewProductStandardCost");
            TextBox txtNewTotalProductCost = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewTotalProductCost");
            TextBox txtNewSalesAmount = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewSalesAmount");
            TextBox txtNewTaxAmt = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewTaxAmt");
            TextBox txtNewFreight = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewFreight");
            TextBox txtNewCarrierTrackingNumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewCarrierTrackingNumber");
            TextBox txtNewCustomerPONumber = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewCustomerPONumber");
            TextBox txtNewOrderDate = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewOrderDate");
            TextBox txtNewDueDate = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewDueDate");
            TextBox txtNewShipDate = (TextBox)grddbo_FactResellerSales.FooterRow.FindControl("txtNewShipDate");

            if (txtNewSalesOrderNumber.Text == "") {
                ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewSalesOrderNumber.Focus();
                return false;}
            if (txtNewSalesOrderLineNumber.Text == "") {
                ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewSalesOrderLineNumber.Focus();
                return false;}
            if (txtNewProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewProductKey.Focus();
                return false;}
            if (txtNewOrderDateKey.Text == "") {
                ec.ShowMessage(" Order Date Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewOrderDateKey.Focus();
                return false;}
            if (txtNewDueDateKey.Text == "") {
                ec.ShowMessage(" Due Date Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewDueDateKey.Focus();
                return false;}
            if (txtNewShipDateKey.Text == "") {
                ec.ShowMessage(" Ship Date Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewShipDateKey.Focus();
                return false;}
            if (txtNewResellerKey.Text == "") {
                ec.ShowMessage(" Reseller Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewResellerKey.Focus();
                return false;}
            if (txtNewEmployeeKey.Text == "") {
                ec.ShowMessage(" Employee Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewEmployeeKey.Focus();
                return false;}
            if (txtNewPromotionKey.Text == "") {
                ec.ShowMessage(" Promotion Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewPromotionKey.Focus();
                return false;}
            if (txtNewCurrencyKey.Text == "") {
                ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewCurrencyKey.Focus();
                return false;}
            if (txtNewSalesTerritoryKey.Text == "") {
                ec.ShowMessage(" Sales Territory Key is Required. ", " Dbo. Fact Reseller Sales ");
                txtNewSalesTerritoryKey.Focus();
                return false;}
            if (
                txtNewSalesOrderNumber.Text != "" 
                && txtNewSalesOrderLineNumber.Text != "" 
            )  {
                dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
                clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(txtNewSalesOrderNumber.Text);
                clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(txtNewSalesOrderLineNumber.Text);
                clsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(clsdbo_FactResellerSales);
                if (clsdbo_FactResellerSales != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Fact Reseller Sales ");
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
		    grddbo_FactResellerSales.PageIndex = 0;
		    grddbo_FactResellerSales.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactResellerSales();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactResellerSales");
		    LoadGriddbo_FactResellerSales();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactResellerSales");
			if ((Session["dvdbo_FactResellerSales"] != null)) {
				dvdbo_FactResellerSales = (DataView)Session["dvdbo_FactResellerSales"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactResellerSales"] = dvdbo_FactResellerSales;
		    	}
                if (dvdbo_FactResellerSales.Count > 0) {
                    grddbo_FactResellerSales.DataSource = dvdbo_FactResellerSales;
                    grddbo_FactResellerSales.DataBind();
                }
                if (dvdbo_FactResellerSales.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesOrderNumber", Type.GetType("System.String"));
                    dt.Columns.Add("SalesOrderLineNumber", Type.GetType("System.Byte"));
                    dt.Columns.Add("ProductAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ResellerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EmployeeKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("PromotionKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CurrencyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("RevisionNumber", Type.GetType("System.Byte"));
                    dt.Columns.Add("OrderQuantity", Type.GetType("System.Int16"));
                    dt.Columns.Add("UnitPrice", Type.GetType("System.Decimal"));
                    dt.Columns.Add("ExtendedAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("UnitPriceDiscountPct", Type.GetType("System.Decimal"));
                    dt.Columns.Add("DiscountAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("ProductStandardCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TotalProductCost", Type.GetType("System.Decimal"));
                    dt.Columns.Add("SalesAmount", Type.GetType("System.Decimal"));
                    dt.Columns.Add("TaxAmt", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Freight", Type.GetType("System.Decimal"));
                    dt.Columns.Add("CarrierTrackingNumber", Type.GetType("System.String"));
                    dt.Columns.Add("CustomerPONumber", Type.GetType("System.String"));
                    dt.Columns.Add("OrderDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("DueDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("ShipDate", Type.GetType("System.DateTime"));
                    dvdbo_FactResellerSales = dt.DefaultView;
                    Session["dvdbo_FactResellerSales"] = dvdbo_FactResellerSales;

                    grddbo_FactResellerSales.DataSource = dvdbo_FactResellerSales;
                    grddbo_FactResellerSales.DataBind();

                    int TotalColumns = grddbo_FactResellerSales.Rows[0].Cells.Count;
                    grddbo_FactResellerSales.Rows[0].Cells.Clear();
                    grddbo_FactResellerSales.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactResellerSales.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactResellerSales.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactResellerSales.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
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
                    { dt = dbo_FactResellerSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactResellerSalesDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Reseller Sales", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactResellerSales"];
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
 
