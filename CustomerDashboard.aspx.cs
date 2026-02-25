using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderManagementApp
{
    public partial class CustomerDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Email"] == null)
            {

                Response.Redirect("Login.aspx");
            }



            if (Session["Role"] == null ||
                Session["Role"].ToString() != "Customer")
            {
                
                Response.Redirect("Login.aspx");
            }

            

            if (!IsPostBack)
            {
                lblWelcome.Text = "Welcome, " +
                    Session["Email"].ToString();
            }
        }

        
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();

           
            Response.Redirect("Login.aspx");
        }
    }
}