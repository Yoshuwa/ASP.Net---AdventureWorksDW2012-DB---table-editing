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
    public partial class frmdbo_FactInternetSales : System.Web.UI.Page
    {

        private dbo_FactInternetSalesDataClass clsdbo_FactInternetSalesData = new dbo_FactInternetSalesDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactInternetSales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ProductKey_SelectedValue"] = "";
                Session["OrderDateKey_SelectedValue"] = "";
                Session["DueDateKey_SelectedValue"] = "";
                Session["ShipDateKey_SelectedValue"] = "";
                Session["CustomerKey_SelectedValue"] = "";
                Session["PromotionKey_SelectedValue"] = "";
                Session["CurrencyKey_SelectedValue"] = "";
                Session["SalesTerritoryKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactInternetSales");
                Session.Remove("Row");

                cmbFields.Items.Add("Sales Order Number");
                cmbFields.Items.Add("Sales Order Line Number");
                cmbFields.Items.Add("Product Key");
                cmbFields.Items.Add("Order Date Key");
                cmbFields.Items.Add("Due Date Key");
                cmbFields.Items.Add("Ship Date Key");
                cmbFields.Items.Add("Customer Key");
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

                LoadGriddbo_FactInternetSales();
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimProductComboBox238(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimProductClass238> dbo_FactInternetSales_dbo_DimProductList = new  List<dbo_FactInternetSales_dbo_DimProductClass238>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtProductKey = (DropDownList)e.Row.FindControl("txtProductKey");
                if (txtProductKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimProductList = dbo_FactInternetSales_dbo_DimProductDataClass238.List();
                        txtProductKey.DataSource = dbo_FactInternetSales_dbo_DimProductList;
                        txtProductKey.DataValueField = "ProductKey";
                        txtProductKey.DataTextField = "EnglishProductName";
                        txtProductKey.DataBind();
                        txtProductKey.SelectedValue = Convert.ToString(Session["ProductKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewProductKey = (DropDownList)e.Row.FindControl("txtNewProductKey");
                if (txtNewProductKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimProductList = dbo_FactInternetSales_dbo_DimProductDataClass238.List();
                        txtNewProductKey.DataSource = dbo_FactInternetSales_dbo_DimProductList;
                        txtNewProductKey.DataValueField = "ProductKey";
                        txtNewProductKey.DataTextField = "EnglishProductName";
                        txtNewProductKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimDateComboBox239(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimDateClass239> dbo_FactInternetSales_dbo_DimDateList = new  List<dbo_FactInternetSales_dbo_DimDateClass239>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtOrderDateKey = (DropDownList)e.Row.FindControl("txtOrderDateKey");
                if (txtOrderDateKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass239.List();
                        txtOrderDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
                        txtOrderDateKey.DataValueField = "DateKey";
                        txtOrderDateKey.DataTextField = "FullDateAlternateKey";
                        txtOrderDateKey.DataBind();
                        txtOrderDateKey.SelectedValue = Convert.ToString(Session["OrderDateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewOrderDateKey = (DropDownList)e.Row.FindControl("txtNewOrderDateKey");
                if (txtNewOrderDateKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass239.List();
                        txtNewOrderDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
                        txtNewOrderDateKey.DataValueField = "DateKey";
                        txtNewOrderDateKey.DataTextField = "FullDateAlternateKey";
                        txtNewOrderDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimDateComboBox240(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimDateClass240> dbo_FactInternetSales_dbo_DimDateList = new  List<dbo_FactInternetSales_dbo_DimDateClass240>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDueDateKey = (DropDownList)e.Row.FindControl("txtDueDateKey");
                if (txtDueDateKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass240.List();
                        txtDueDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
                        txtDueDateKey.DataValueField = "DateKey";
                        txtDueDateKey.DataTextField = "FullDateAlternateKey";
                        txtDueDateKey.DataBind();
                        txtDueDateKey.SelectedValue = Convert.ToString(Session["DueDateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDueDateKey = (DropDownList)e.Row.FindControl("txtNewDueDateKey");
                if (txtNewDueDateKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass240.List();
                        txtNewDueDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
                        txtNewDueDateKey.DataValueField = "DateKey";
                        txtNewDueDateKey.DataTextField = "FullDateAlternateKey";
                        txtNewDueDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimDateComboBox241(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimDateClass241> dbo_FactInternetSales_dbo_DimDateList = new  List<dbo_FactInternetSales_dbo_DimDateClass241>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtShipDateKey = (DropDownList)e.Row.FindControl("txtShipDateKey");
                if (txtShipDateKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass241.List();
                        txtShipDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
                        txtShipDateKey.DataValueField = "DateKey";
                        txtShipDateKey.DataTextField = "FullDateAlternateKey";
                        txtShipDateKey.DataBind();
                        txtShipDateKey.SelectedValue = Convert.ToString(Session["ShipDateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewShipDateKey = (DropDownList)e.Row.FindControl("txtNewShipDateKey");
                if (txtNewShipDateKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass241.List();
                        txtNewShipDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
                        txtNewShipDateKey.DataValueField = "DateKey";
                        txtNewShipDateKey.DataTextField = "FullDateAlternateKey";
                        txtNewShipDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimCustomerComboBox242(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimCustomerClass242> dbo_FactInternetSales_dbo_DimCustomerList = new  List<dbo_FactInternetSales_dbo_DimCustomerClass242>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCustomerKey = (DropDownList)e.Row.FindControl("txtCustomerKey");
                if (txtCustomerKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimCustomerList = dbo_FactInternetSales_dbo_DimCustomerDataClass242.List();
                        txtCustomerKey.DataSource = dbo_FactInternetSales_dbo_DimCustomerList;
                        txtCustomerKey.DataValueField = "CustomerKey";
                        txtCustomerKey.DataTextField = "FirstName";
                        txtCustomerKey.DataBind();
                        txtCustomerKey.SelectedValue = Convert.ToString(Session["CustomerKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewCustomerKey = (DropDownList)e.Row.FindControl("txtNewCustomerKey");
                if (txtNewCustomerKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimCustomerList = dbo_FactInternetSales_dbo_DimCustomerDataClass242.List();
                        txtNewCustomerKey.DataSource = dbo_FactInternetSales_dbo_DimCustomerList;
                        txtNewCustomerKey.DataValueField = "CustomerKey";
                        txtNewCustomerKey.DataTextField = "FirstName";
                        txtNewCustomerKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimPromotionComboBox243(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimPromotionClass243> dbo_FactInternetSales_dbo_DimPromotionList = new  List<dbo_FactInternetSales_dbo_DimPromotionClass243>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtPromotionKey = (DropDownList)e.Row.FindControl("txtPromotionKey");
                if (txtPromotionKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimPromotionList = dbo_FactInternetSales_dbo_DimPromotionDataClass243.List();
                        txtPromotionKey.DataSource = dbo_FactInternetSales_dbo_DimPromotionList;
                        txtPromotionKey.DataValueField = "PromotionKey";
                        txtPromotionKey.DataTextField = "EnglishPromotionName";
                        txtPromotionKey.DataBind();
                        txtPromotionKey.SelectedValue = Convert.ToString(Session["PromotionKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewPromotionKey = (DropDownList)e.Row.FindControl("txtNewPromotionKey");
                if (txtNewPromotionKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimPromotionList = dbo_FactInternetSales_dbo_DimPromotionDataClass243.List();
                        txtNewPromotionKey.DataSource = dbo_FactInternetSales_dbo_DimPromotionList;
                        txtNewPromotionKey.DataValueField = "PromotionKey";
                        txtNewPromotionKey.DataTextField = "EnglishPromotionName";
                        txtNewPromotionKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimCurrencyComboBox244(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimCurrencyClass244> dbo_FactInternetSales_dbo_DimCurrencyList = new  List<dbo_FactInternetSales_dbo_DimCurrencyClass244>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCurrencyKey = (DropDownList)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimCurrencyList = dbo_FactInternetSales_dbo_DimCurrencyDataClass244.List();
                        txtCurrencyKey.DataSource = dbo_FactInternetSales_dbo_DimCurrencyList;
                        txtCurrencyKey.DataValueField = "CurrencyKey";
                        txtCurrencyKey.DataTextField = "CurrencyName";
                        txtCurrencyKey.DataBind();
                        txtCurrencyKey.SelectedValue = Convert.ToString(Session["CurrencyKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewCurrencyKey = (DropDownList)e.Row.FindControl("txtNewCurrencyKey");
                if (txtNewCurrencyKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimCurrencyList = dbo_FactInternetSales_dbo_DimCurrencyDataClass244.List();
                        txtNewCurrencyKey.DataSource = dbo_FactInternetSales_dbo_DimCurrencyList;
                        txtNewCurrencyKey.DataValueField = "CurrencyKey";
                        txtNewCurrencyKey.DataTextField = "CurrencyName";
                        txtNewCurrencyKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void Loaddbo_FactInternetSales_dbo_DimSalesTerritoryComboBox245(GridViewRowEventArgs e)
        {
            List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245> dbo_FactInternetSales_dbo_DimSalesTerritoryList = new  List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtSalesTerritoryKey");
                if (txtSalesTerritoryKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimSalesTerritoryList = dbo_FactInternetSales_dbo_DimSalesTerritoryDataClass245.List();
                        txtSalesTerritoryKey.DataSource = dbo_FactInternetSales_dbo_DimSalesTerritoryList;
                        txtSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
                        txtSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
                        txtSalesTerritoryKey.DataBind();
                        txtSalesTerritoryKey.SelectedValue = Convert.ToString(Session["SalesTerritoryKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtNewSalesTerritoryKey");
                if (txtNewSalesTerritoryKey != null) {
                    try {
                        dbo_FactInternetSales_dbo_DimSalesTerritoryList = dbo_FactInternetSales_dbo_DimSalesTerritoryDataClass245.List();
                        txtNewSalesTerritoryKey.DataSource = dbo_FactInternetSales_dbo_DimSalesTerritoryList;
                        txtNewSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
                        txtNewSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
                        txtNewSalesTerritoryKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactInternetSales()
        {
            try {
                if ((Session["dvdbo_FactInternetSales"] != null)) {
                    dvdbo_FactInternetSales = (DataView)Session["dvdbo_FactInternetSales"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactInternetSales = dbo_FactInternetSalesDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactInternetSales"] = dvdbo_FactInternetSales;
                }
                if (dvdbo_FactInternetSales.Count > 0) {
                    grddbo_FactInternetSales.DataSource = dvdbo_FactInternetSales;
                    grddbo_FactInternetSales.DataBind();
                }
                if (dvdbo_FactInternetSales.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesOrderNumber", Type.GetType("System.String"));
                    dt.Columns.Add("SalesOrderLineNumber", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishProductName", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FirstName", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishPromotionName", Type.GetType("System.Int32"));
                    dt.Columns.Add("CurrencyName", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
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
                    dvdbo_FactInternetSales = dt.DefaultView;
                    Session["dvdbo_FactInternetSales"] = dvdbo_FactInternetSales;

                    grddbo_FactInternetSales.DataSource = dvdbo_FactInternetSales;
                    grddbo_FactInternetSales.DataBind();

                    int TotalColumns = grddbo_FactInternetSales.Rows[0].Cells.Count;
                    grddbo_FactInternetSales.Rows[0].Cells.Clear();
                    grddbo_FactInternetSales.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactInternetSales.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactInternetSales.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactInternetSales.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
            }
        }

        protected void grddbo_FactInternetSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactInternetSales_dbo_DimProductComboBox238(e);
            Loaddbo_FactInternetSales_dbo_DimDateComboBox239(e);
            Loaddbo_FactInternetSales_dbo_DimDateComboBox240(e);
            Loaddbo_FactInternetSales_dbo_DimDateComboBox241(e);
            Loaddbo_FactInternetSales_dbo_DimCustomerComboBox242(e);
            Loaddbo_FactInternetSales_dbo_DimPromotionComboBox243(e);
            Loaddbo_FactInternetSales_dbo_DimCurrencyComboBox244(e);
            Loaddbo_FactInternetSales_dbo_DimSalesTerritoryComboBox245(e);
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

        protected void grddbo_FactInternetSales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactInternetSales.EditIndex = -1;
            LoadGriddbo_FactInternetSales();
        }

        protected void grddbo_FactInternetSales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactInternetSales.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactInternetSales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactInternetSales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactInternetSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactInternetSales_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactInternetSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactInternetSales.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactInternetSales();
        }

        protected void grddbo_FactInternetSales_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactInternetSales();
        }

        private void Edit()
        {
            try {
                dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
                Label lblSalesOrderNumber = (Label)grddbo_FactInternetSales.Rows[grddbo_FactInternetSales.EditIndex].FindControl("lblSalesOrderNumber");
                clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(lblSalesOrderNumber.Text);
                Label lblSalesOrderLineNumber = (Label)grddbo_FactInternetSales.Rows[grddbo_FactInternetSales.EditIndex].FindControl("lblSalesOrderLineNumber");
                clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(lblSalesOrderLineNumber.Text);
                clsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(clsdbo_FactInternetSales);

                Session["ProductKey_SelectedValue"] = clsdbo_FactInternetSales.ProductKey;
                Session["OrderDateKey_SelectedValue"] = clsdbo_FactInternetSales.OrderDateKey;
                Session["DueDateKey_SelectedValue"] = clsdbo_FactInternetSales.DueDateKey;
                Session["ShipDateKey_SelectedValue"] = clsdbo_FactInternetSales.ShipDateKey;
                Session["CustomerKey_SelectedValue"] = clsdbo_FactInternetSales.CustomerKey;
                Session["PromotionKey_SelectedValue"] = clsdbo_FactInternetSales.PromotionKey;
                Session["CurrencyKey_SelectedValue"] = clsdbo_FactInternetSales.CurrencyKey;
                Session["SalesTerritoryKey_SelectedValue"] = clsdbo_FactInternetSales.SalesTerritoryKey;

                LoadGriddbo_FactInternetSales();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewSalesOrderNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesOrderNumber");
                TextBox txtNewSalesOrderLineNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesOrderLineNumber");
                DropDownList txtNewProductKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewProductKey");
                DropDownList txtNewOrderDateKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewOrderDateKey");
                DropDownList txtNewDueDateKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewDueDateKey");
                DropDownList txtNewShipDateKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewShipDateKey");
                DropDownList txtNewCustomerKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCustomerKey");
                DropDownList txtNewPromotionKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewPromotionKey");
                DropDownList txtNewCurrencyKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCurrencyKey");
                DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesTerritoryKey");
                TextBox txtNewRevisionNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewRevisionNumber");
                TextBox txtNewOrderQuantity = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewOrderQuantity");
                TextBox txtNewUnitPrice = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewUnitPrice");
                TextBox txtNewExtendedAmount = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewExtendedAmount");
                TextBox txtNewUnitPriceDiscountPct = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewUnitPriceDiscountPct");
                TextBox txtNewDiscountAmount = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewDiscountAmount");
                TextBox txtNewProductStandardCost = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewProductStandardCost");
                TextBox txtNewTotalProductCost = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewTotalProductCost");
                TextBox txtNewSalesAmount = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesAmount");
                TextBox txtNewTaxAmt = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewTaxAmt");
                TextBox txtNewFreight = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewFreight");
                TextBox txtNewCarrierTrackingNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCarrierTrackingNumber");
                TextBox txtNewCustomerPONumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCustomerPONumber");
                TextBox txtNewOrderDate = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewOrderDate");
                TextBox txtNewDueDate = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewDueDate");
                TextBox txtNewShipDate = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewShipDate");

                dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(txtNewSalesOrderNumber.Text);
                    clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(txtNewSalesOrderLineNumber.Text);
                    clsdbo_FactInternetSales.ProductKey = System.Convert.ToInt32(txtNewProductKey.SelectedValue);
                    clsdbo_FactInternetSales.OrderDateKey = System.Convert.ToInt32(txtNewOrderDateKey.SelectedValue);
                    clsdbo_FactInternetSales.DueDateKey = System.Convert.ToInt32(txtNewDueDateKey.SelectedValue);
                    clsdbo_FactInternetSales.ShipDateKey = System.Convert.ToInt32(txtNewShipDateKey.SelectedValue);
                    clsdbo_FactInternetSales.CustomerKey = System.Convert.ToInt32(txtNewCustomerKey.SelectedValue);
                    clsdbo_FactInternetSales.PromotionKey = System.Convert.ToInt32(txtNewPromotionKey.SelectedValue);
                    clsdbo_FactInternetSales.CurrencyKey = System.Convert.ToInt32(txtNewCurrencyKey.SelectedValue);
                    clsdbo_FactInternetSales.SalesTerritoryKey = System.Convert.ToInt32(txtNewSalesTerritoryKey.SelectedValue);
                    clsdbo_FactInternetSales.RevisionNumber = System.Convert.ToByte(txtNewRevisionNumber.Text);
                    clsdbo_FactInternetSales.OrderQuantity = System.Convert.ToInt16(txtNewOrderQuantity.Text);
                    clsdbo_FactInternetSales.UnitPrice = System.Convert.ToDecimal(txtNewUnitPrice.Text);
                    clsdbo_FactInternetSales.ExtendedAmount = System.Convert.ToDecimal(txtNewExtendedAmount.Text);
                    clsdbo_FactInternetSales.UnitPriceDiscountPct = System.Convert.ToDecimal(txtNewUnitPriceDiscountPct.Text);
                    clsdbo_FactInternetSales.DiscountAmount = System.Convert.ToDecimal(txtNewDiscountAmount.Text);
                    clsdbo_FactInternetSales.ProductStandardCost = System.Convert.ToDecimal(txtNewProductStandardCost.Text);
                    clsdbo_FactInternetSales.TotalProductCost = System.Convert.ToDecimal(txtNewTotalProductCost.Text);
                    clsdbo_FactInternetSales.SalesAmount = System.Convert.ToDecimal(txtNewSalesAmount.Text);
                    clsdbo_FactInternetSales.TaxAmt = System.Convert.ToDecimal(txtNewTaxAmt.Text);
                    clsdbo_FactInternetSales.Freight = System.Convert.ToDecimal(txtNewFreight.Text);
                    if (string.IsNullOrEmpty(txtNewCarrierTrackingNumber.Text)) {
                        clsdbo_FactInternetSales.CarrierTrackingNumber = null;
                    } else {
                        clsdbo_FactInternetSales.CarrierTrackingNumber = txtNewCarrierTrackingNumber.Text; }
                    if (string.IsNullOrEmpty(txtNewCustomerPONumber.Text)) {
                        clsdbo_FactInternetSales.CustomerPONumber = null;
                    } else {
                        clsdbo_FactInternetSales.CustomerPONumber = txtNewCustomerPONumber.Text; }
                    if (string.IsNullOrEmpty(txtNewOrderDate.Text)) {
                        clsdbo_FactInternetSales.OrderDate = null;
                    } else {
                        clsdbo_FactInternetSales.OrderDate = System.Convert.ToDateTime(txtNewOrderDate.Text); }
                    if (string.IsNullOrEmpty(txtNewDueDate.Text)) {
                        clsdbo_FactInternetSales.DueDate = null;
                    } else {
                        clsdbo_FactInternetSales.DueDate = System.Convert.ToDateTime(txtNewDueDate.Text); }
                    if (string.IsNullOrEmpty(txtNewShipDate.Text)) {
                        clsdbo_FactInternetSales.ShipDate = null;
                    } else {
                        clsdbo_FactInternetSales.ShipDate = System.Convert.ToDateTime(txtNewShipDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactInternetSalesDataClass.Add(clsdbo_FactInternetSales);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactInternetSales");
                        LoadGriddbo_FactInternetSales();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Internet Sales ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtSalesOrderNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderNumber");
                TextBox txtSalesOrderLineNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderLineNumber");
                DropDownList txtProductKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
                DropDownList txtOrderDateKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDateKey");
                DropDownList txtDueDateKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDateKey");
                DropDownList txtShipDateKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDateKey");
                DropDownList txtCustomerKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerKey");
                DropDownList txtPromotionKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionKey");
                DropDownList txtCurrencyKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
                DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
                TextBox txtRevisionNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtRevisionNumber");
                TextBox txtOrderQuantity = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderQuantity");
                TextBox txtUnitPrice = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPrice");
                TextBox txtExtendedAmount = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtExtendedAmount");
                TextBox txtUnitPriceDiscountPct = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPriceDiscountPct");
                TextBox txtDiscountAmount = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDiscountAmount");
                TextBox txtProductStandardCost = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductStandardCost");
                TextBox txtTotalProductCost = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalProductCost");
                TextBox txtSalesAmount = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesAmount");
                TextBox txtTaxAmt = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTaxAmt");
                TextBox txtFreight = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFreight");
                TextBox txtCarrierTrackingNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCarrierTrackingNumber");
                TextBox txtCustomerPONumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerPONumber");
                TextBox txtOrderDate = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDate");
                TextBox txtDueDate = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDate");
                TextBox txtShipDate = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDate");

                dbo_FactInternetSalesClass oclsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
                dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
                oclsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
                oclsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
                oclsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(oclsdbo_FactInternetSales);

                if (VerifyData() == true) {
                    clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
                    clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
                    clsdbo_FactInternetSales.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
                    clsdbo_FactInternetSales.OrderDateKey = System.Convert.ToInt32(txtOrderDateKey.SelectedValue);
                    clsdbo_FactInternetSales.DueDateKey = System.Convert.ToInt32(txtDueDateKey.SelectedValue);
                    clsdbo_FactInternetSales.ShipDateKey = System.Convert.ToInt32(txtShipDateKey.SelectedValue);
                    clsdbo_FactInternetSales.CustomerKey = System.Convert.ToInt32(txtCustomerKey.SelectedValue);
                    clsdbo_FactInternetSales.PromotionKey = System.Convert.ToInt32(txtPromotionKey.SelectedValue);
                    clsdbo_FactInternetSales.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
                    clsdbo_FactInternetSales.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue);
                    clsdbo_FactInternetSales.RevisionNumber = System.Convert.ToByte(txtRevisionNumber.Text);
                    clsdbo_FactInternetSales.OrderQuantity = System.Convert.ToInt16(txtOrderQuantity.Text);
                    clsdbo_FactInternetSales.UnitPrice = System.Convert.ToDecimal(txtUnitPrice.Text);
                    clsdbo_FactInternetSales.ExtendedAmount = System.Convert.ToDecimal(txtExtendedAmount.Text);
                    clsdbo_FactInternetSales.UnitPriceDiscountPct = System.Convert.ToDecimal(txtUnitPriceDiscountPct.Text);
                    clsdbo_FactInternetSales.DiscountAmount = System.Convert.ToDecimal(txtDiscountAmount.Text);
                    clsdbo_FactInternetSales.ProductStandardCost = System.Convert.ToDecimal(txtProductStandardCost.Text);
                    clsdbo_FactInternetSales.TotalProductCost = System.Convert.ToDecimal(txtTotalProductCost.Text);
                    clsdbo_FactInternetSales.SalesAmount = System.Convert.ToDecimal(txtSalesAmount.Text);
                    clsdbo_FactInternetSales.TaxAmt = System.Convert.ToDecimal(txtTaxAmt.Text);
                    clsdbo_FactInternetSales.Freight = System.Convert.ToDecimal(txtFreight.Text);
                    if (string.IsNullOrEmpty(txtCarrierTrackingNumber.Text)) {
                        clsdbo_FactInternetSales.CarrierTrackingNumber = null;
                    } else {
                        clsdbo_FactInternetSales.CarrierTrackingNumber = txtCarrierTrackingNumber.Text; }
                    if (string.IsNullOrEmpty(txtCustomerPONumber.Text)) {
                        clsdbo_FactInternetSales.CustomerPONumber = null;
                    } else {
                        clsdbo_FactInternetSales.CustomerPONumber = txtCustomerPONumber.Text; }
                    if (string.IsNullOrEmpty(txtOrderDate.Text)) {
                        clsdbo_FactInternetSales.OrderDate = null;
                    } else {
                        clsdbo_FactInternetSales.OrderDate = System.Convert.ToDateTime(txtOrderDate.Text); }
                    if (string.IsNullOrEmpty(txtDueDate.Text)) {
                        clsdbo_FactInternetSales.DueDate = null;
                    } else {
                        clsdbo_FactInternetSales.DueDate = System.Convert.ToDateTime(txtDueDate.Text); }
                    if (string.IsNullOrEmpty(txtShipDate.Text)) {
                        clsdbo_FactInternetSales.ShipDate = null;
                    } else {
                        clsdbo_FactInternetSales.ShipDate = System.Convert.ToDateTime(txtShipDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactInternetSalesDataClass.Update(oclsdbo_FactInternetSales, clsdbo_FactInternetSales);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactInternetSales");
                        grddbo_FactInternetSales.EditIndex = -1;
                        LoadGriddbo_FactInternetSales();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Internet Sales ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
            Label lblSalesOrderNumber = (Label)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesOrderNumber");
            clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(lblSalesOrderNumber.Text);
            Label lblSalesOrderLineNumber = (Label)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesOrderLineNumber");
            clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(lblSalesOrderLineNumber.Text);
            clsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(clsdbo_FactInternetSales);
            bool bSucess = false;
            bSucess = dbo_FactInternetSalesDataClass.Delete(clsdbo_FactInternetSales);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactInternetSales");
                LoadGriddbo_FactInternetSales();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Internet Sales ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtSalesOrderNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderNumber");
            TextBox txtSalesOrderLineNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesOrderLineNumber");
            DropDownList txtProductKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
            DropDownList txtOrderDateKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDateKey");
            DropDownList txtDueDateKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDateKey");
            DropDownList txtShipDateKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDateKey");
            DropDownList txtCustomerKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerKey");
            DropDownList txtPromotionKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionKey");
            DropDownList txtCurrencyKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
            DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
            TextBox txtRevisionNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtRevisionNumber");
            TextBox txtOrderQuantity = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderQuantity");
            TextBox txtUnitPrice = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPrice");
            TextBox txtExtendedAmount = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtExtendedAmount");
            TextBox txtUnitPriceDiscountPct = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtUnitPriceDiscountPct");
            TextBox txtDiscountAmount = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDiscountAmount");
            TextBox txtProductStandardCost = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductStandardCost");
            TextBox txtTotalProductCost = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTotalProductCost");
            TextBox txtSalesAmount = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesAmount");
            TextBox txtTaxAmt = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtTaxAmt");
            TextBox txtFreight = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFreight");
            TextBox txtCarrierTrackingNumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCarrierTrackingNumber");
            TextBox txtCustomerPONumber = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerPONumber");
            TextBox txtOrderDate = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtOrderDate");
            TextBox txtDueDate = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDueDate");
            TextBox txtShipDate = (TextBox)grddbo_FactInternetSales.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtShipDate");

            if (txtSalesOrderNumber.Text == "") {
                ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Internet Sales ");
                txtSalesOrderNumber.Focus();
                return false;}
            if (txtSalesOrderLineNumber.Text == "") {
                ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Internet Sales ");
                txtSalesOrderLineNumber.Focus();
                return false;}
            if (txtProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Internet Sales ");
                txtProductKey.Focus();
                return false;}
            if (txtOrderDateKey.Text == "") {
                ec.ShowMessage(" Order Date Key is Required. ", " Dbo. Fact Internet Sales ");
                txtOrderDateKey.Focus();
                return false;}
            if (txtDueDateKey.Text == "") {
                ec.ShowMessage(" Due Date Key is Required. ", " Dbo. Fact Internet Sales ");
                txtDueDateKey.Focus();
                return false;}
            if (txtShipDateKey.Text == "") {
                ec.ShowMessage(" Ship Date Key is Required. ", " Dbo. Fact Internet Sales ");
                txtShipDateKey.Focus();
                return false;}
            if (txtCustomerKey.Text == "") {
                ec.ShowMessage(" Customer Key is Required. ", " Dbo. Fact Internet Sales ");
                txtCustomerKey.Focus();
                return false;}
            if (txtPromotionKey.Text == "") {
                ec.ShowMessage(" Promotion Key is Required. ", " Dbo. Fact Internet Sales ");
                txtPromotionKey.Focus();
                return false;}
            if (txtCurrencyKey.Text == "") {
                ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Internet Sales ");
                txtCurrencyKey.Focus();
                return false;}
            if (txtSalesTerritoryKey.Text == "") {
                ec.ShowMessage(" Sales Territory Key is Required. ", " Dbo. Fact Internet Sales ");
                txtSalesTerritoryKey.Focus();
                return false;}
            if (txtRevisionNumber.Text == "") {
                ec.ShowMessage(" Revision Number is Required. ", " Dbo. Fact Internet Sales ");
                txtRevisionNumber.Focus();
                return false;}
            if (txtOrderQuantity.Text == "") {
                ec.ShowMessage(" Order Quantity is Required. ", " Dbo. Fact Internet Sales ");
                txtOrderQuantity.Focus();
                return false;}
            if (txtUnitPrice.Text == "") {
                ec.ShowMessage(" Unit Price is Required. ", " Dbo. Fact Internet Sales ");
                txtUnitPrice.Focus();
                return false;}
            if (txtExtendedAmount.Text == "") {
                ec.ShowMessage(" Extended Amount is Required. ", " Dbo. Fact Internet Sales ");
                txtExtendedAmount.Focus();
                return false;}
            if (txtUnitPriceDiscountPct.Text == "") {
                ec.ShowMessage(" Unit Price Discount Pct is Required. ", " Dbo. Fact Internet Sales ");
                txtUnitPriceDiscountPct.Focus();
                return false;}
            if (txtDiscountAmount.Text == "") {
                ec.ShowMessage(" Discount Amount is Required. ", " Dbo. Fact Internet Sales ");
                txtDiscountAmount.Focus();
                return false;}
            if (txtProductStandardCost.Text == "") {
                ec.ShowMessage(" Product Standard Cost is Required. ", " Dbo. Fact Internet Sales ");
                txtProductStandardCost.Focus();
                return false;}
            if (txtTotalProductCost.Text == "") {
                ec.ShowMessage(" Total Product Cost is Required. ", " Dbo. Fact Internet Sales ");
                txtTotalProductCost.Focus();
                return false;}
            if (txtSalesAmount.Text == "") {
                ec.ShowMessage(" Sales Amount is Required. ", " Dbo. Fact Internet Sales ");
                txtSalesAmount.Focus();
                return false;}
            if (txtTaxAmt.Text == "") {
                ec.ShowMessage(" Tax Amt is Required. ", " Dbo. Fact Internet Sales ");
                txtTaxAmt.Focus();
                return false;}
            if (txtFreight.Text == "") {
                ec.ShowMessage(" Freight is Required. ", " Dbo. Fact Internet Sales ");
                txtFreight.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewSalesOrderNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesOrderNumber");
            TextBox txtNewSalesOrderLineNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesOrderLineNumber");
            DropDownList txtNewProductKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewProductKey");
            DropDownList txtNewOrderDateKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewOrderDateKey");
            DropDownList txtNewDueDateKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewDueDateKey");
            DropDownList txtNewShipDateKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewShipDateKey");
            DropDownList txtNewCustomerKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCustomerKey");
            DropDownList txtNewPromotionKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewPromotionKey");
            DropDownList txtNewCurrencyKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCurrencyKey");
            DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesTerritoryKey");
            TextBox txtNewRevisionNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewRevisionNumber");
            TextBox txtNewOrderQuantity = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewOrderQuantity");
            TextBox txtNewUnitPrice = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewUnitPrice");
            TextBox txtNewExtendedAmount = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewExtendedAmount");
            TextBox txtNewUnitPriceDiscountPct = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewUnitPriceDiscountPct");
            TextBox txtNewDiscountAmount = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewDiscountAmount");
            TextBox txtNewProductStandardCost = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewProductStandardCost");
            TextBox txtNewTotalProductCost = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewTotalProductCost");
            TextBox txtNewSalesAmount = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewSalesAmount");
            TextBox txtNewTaxAmt = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewTaxAmt");
            TextBox txtNewFreight = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewFreight");
            TextBox txtNewCarrierTrackingNumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCarrierTrackingNumber");
            TextBox txtNewCustomerPONumber = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewCustomerPONumber");
            TextBox txtNewOrderDate = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewOrderDate");
            TextBox txtNewDueDate = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewDueDate");
            TextBox txtNewShipDate = (TextBox)grddbo_FactInternetSales.FooterRow.FindControl("txtNewShipDate");

            if (txtNewSalesOrderNumber.Text == "") {
                ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Internet Sales ");
                txtNewSalesOrderNumber.Focus();
                return false;}
            if (txtNewSalesOrderLineNumber.Text == "") {
                ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Internet Sales ");
                txtNewSalesOrderLineNumber.Focus();
                return false;}
            if (txtNewProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewProductKey.Focus();
                return false;}
            if (txtNewOrderDateKey.Text == "") {
                ec.ShowMessage(" Order Date Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewOrderDateKey.Focus();
                return false;}
            if (txtNewDueDateKey.Text == "") {
                ec.ShowMessage(" Due Date Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewDueDateKey.Focus();
                return false;}
            if (txtNewShipDateKey.Text == "") {
                ec.ShowMessage(" Ship Date Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewShipDateKey.Focus();
                return false;}
            if (txtNewCustomerKey.Text == "") {
                ec.ShowMessage(" Customer Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewCustomerKey.Focus();
                return false;}
            if (txtNewPromotionKey.Text == "") {
                ec.ShowMessage(" Promotion Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewPromotionKey.Focus();
                return false;}
            if (txtNewCurrencyKey.Text == "") {
                ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewCurrencyKey.Focus();
                return false;}
            if (txtNewSalesTerritoryKey.Text == "") {
                ec.ShowMessage(" Sales Territory Key is Required. ", " Dbo. Fact Internet Sales ");
                txtNewSalesTerritoryKey.Focus();
                return false;}
            if (txtNewRevisionNumber.Text == "") {
                ec.ShowMessage(" Revision Number is Required. ", " Dbo. Fact Internet Sales ");
                txtNewRevisionNumber.Focus();
                return false;}
            if (txtNewOrderQuantity.Text == "") {
                ec.ShowMessage(" Order Quantity is Required. ", " Dbo. Fact Internet Sales ");
                txtNewOrderQuantity.Focus();
                return false;}
            if (txtNewUnitPrice.Text == "") {
                ec.ShowMessage(" Unit Price is Required. ", " Dbo. Fact Internet Sales ");
                txtNewUnitPrice.Focus();
                return false;}
            if (txtNewExtendedAmount.Text == "") {
                ec.ShowMessage(" Extended Amount is Required. ", " Dbo. Fact Internet Sales ");
                txtNewExtendedAmount.Focus();
                return false;}
            if (txtNewUnitPriceDiscountPct.Text == "") {
                ec.ShowMessage(" Unit Price Discount Pct is Required. ", " Dbo. Fact Internet Sales ");
                txtNewUnitPriceDiscountPct.Focus();
                return false;}
            if (txtNewDiscountAmount.Text == "") {
                ec.ShowMessage(" Discount Amount is Required. ", " Dbo. Fact Internet Sales ");
                txtNewDiscountAmount.Focus();
                return false;}
            if (txtNewProductStandardCost.Text == "") {
                ec.ShowMessage(" Product Standard Cost is Required. ", " Dbo. Fact Internet Sales ");
                txtNewProductStandardCost.Focus();
                return false;}
            if (txtNewTotalProductCost.Text == "") {
                ec.ShowMessage(" Total Product Cost is Required. ", " Dbo. Fact Internet Sales ");
                txtNewTotalProductCost.Focus();
                return false;}
            if (txtNewSalesAmount.Text == "") {
                ec.ShowMessage(" Sales Amount is Required. ", " Dbo. Fact Internet Sales ");
                txtNewSalesAmount.Focus();
                return false;}
            if (txtNewTaxAmt.Text == "") {
                ec.ShowMessage(" Tax Amt is Required. ", " Dbo. Fact Internet Sales ");
                txtNewTaxAmt.Focus();
                return false;}
            if (txtNewFreight.Text == "") {
                ec.ShowMessage(" Freight is Required. ", " Dbo. Fact Internet Sales ");
                txtNewFreight.Focus();
                return false;}
            if (
                txtNewSalesOrderNumber.Text != "" 
                && txtNewSalesOrderLineNumber.Text != "" 
            )  {
                dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
                clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(txtNewSalesOrderNumber.Text);
                clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(txtNewSalesOrderLineNumber.Text);
                clsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(clsdbo_FactInternetSales);
                if (clsdbo_FactInternetSales != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Fact Internet Sales ");
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
		    grddbo_FactInternetSales.PageIndex = 0;
		    grddbo_FactInternetSales.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactInternetSales();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactInternetSales");
		    LoadGriddbo_FactInternetSales();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactInternetSales");
			if ((Session["dvdbo_FactInternetSales"] != null)) {
				dvdbo_FactInternetSales = (DataView)Session["dvdbo_FactInternetSales"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactInternetSales"] = dvdbo_FactInternetSales;
		    	}
                if (dvdbo_FactInternetSales.Count > 0) {
                    grddbo_FactInternetSales.DataSource = dvdbo_FactInternetSales;
                    grddbo_FactInternetSales.DataBind();
                }
                if (dvdbo_FactInternetSales.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesOrderNumber", Type.GetType("System.String"));
                    dt.Columns.Add("SalesOrderLineNumber", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishProductName", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FirstName", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishPromotionName", Type.GetType("System.Int32"));
                    dt.Columns.Add("CurrencyName", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
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
                    dvdbo_FactInternetSales = dt.DefaultView;
                    Session["dvdbo_FactInternetSales"] = dvdbo_FactInternetSales;

                    grddbo_FactInternetSales.DataSource = dvdbo_FactInternetSales;
                    grddbo_FactInternetSales.DataBind();

                    int TotalColumns = grddbo_FactInternetSales.Rows[0].Cells.Count;
                    grddbo_FactInternetSales.Rows[0].Cells.Clear();
                    grddbo_FactInternetSales.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactInternetSales.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactInternetSales.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactInternetSales.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
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
                    { dt = dbo_FactInternetSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactInternetSalesDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Internet Sales", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactInternetSales"];
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
 
