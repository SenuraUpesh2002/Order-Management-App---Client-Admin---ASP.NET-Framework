using OrderManagementApp.App_Code;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace OrderManagementApp
{
    public partial class MyOrders : System.Web.UI.Page
    {
        FoodDAL dal = new FoodDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //  Check login session
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

     
        // Load Orders
       
        private void LoadOrders()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            DataTable dt = dal.GetOrdersByUser(userID);

            gvOrders.DataSource = dt;
            gvOrders.DataBind();
        }

       
        // GridView Row Commands
        
        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int orderID = Convert.ToInt32(gvOrders.DataKeys[rowIndex].Value);

            //  View Order Details
            if (e.CommandName == "ViewDetails")
            {
                DataTable dtItems = dal.GetOrderItems(orderID);

                gvOrderItems.DataSource = dtItems;
                gvOrderItems.DataBind();
            }

            //  Cancel Order
            if (e.CommandName == "CancelOrder")
            {
                dal.CancelOrder(orderID);

                LoadOrders();

                gvOrderItems.DataSource = null;
                gvOrderItems.DataBind();
            }
        }

        // Search Orders
       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            DataTable dt = dal.GetOrdersByUser(userID);

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                DataView dv = dt.DefaultView;

                
                dv.RowFilter = "OrderStatus LIKE '%" + txtSearch.Text.Trim() + "%'";

                gvOrders.DataSource = dv;
            }
            else
            {
                gvOrders.DataSource = dt;
            }

            gvOrders.DataBind();
        }
    }
}